using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SGFJU.Api.Legado;
using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.Util;
using SGFJU.Domain.Model.ValueObjects;
using SGFJU.ServicesLayer.DTO;
using SGFJU.ServicesLayer.DTO.Relatorios;

namespace SGFJU.Api.Controllers
{
    /// <summary>
    /// Árvore da Vida 2.0 (acompanhamento de jovens por obreiros).
    /// Diferenças em relação às rotas antigas:
    /// - sem sessão: tudo vem pela URL ou pelo corpo do pedido;
    /// - toda consulta é limitada ao escopo do usuário (estado; bloco para secretaria de bloco; região para regional);
    /// - antes de associar, desassociar ou registrar histórico, confere se o obreiro/jovem está nesse escopo
    ///   (as rotas antigas aceitavam qualquer id);
    /// - "jovens sem acompanhamento" sempre filtra pela igreja do obreiro (a antiga, com igreja 0, listava o país inteiro).
    /// </summary>
    [ApiController]
    [Route("api/v2/arvore-vida")]
    public class ArvoreVidaV2Controller : ControllerBase
    {
        private const int PERFIL_SECRETARIA_BLOCO = 7;
        private const int PERFIL_SECRETARIA_REGIONAL = 9;

        public static readonly IReadOnlyList<object> STATUS = new[]
        {
            new { Id = 1, Nome = "Iniciando na fé" },
            new { Id = 2, Nome = "Batizado nas águas" },
            new { Id = 3, Nome = "Batizado com o Espírito Santo" },
        };

        // ------------------------------------------------------------------ escopo do usuário
        private sealed class Escopo
        {
            public bool EhAdm { get; set; }
            public int IdEstado { get; set; }
            public int IdBloco { get; set; }
            public int IdRegiao { get; set; }

            public bool Permite(int idEstado, int idBloco, int idRegiao) =>
                EhAdm || (idEstado == IdEstado && (IdBloco == 0 || idBloco == IdBloco) && (IdRegiao == 0 || idRegiao == IdRegiao));
        }

        private static Escopo ObterEscopo()
        {
            var u = SessionHelper.RetornaUsuarioLogado();
            int.TryParse(SgfjuConfig.Get("CodeADM"), out var codigoAdm);
            var perfil = u?.PerfilUsuario?.Code ?? 0;
            return new Escopo
            {
                EhAdm = perfil == codigoAdm,
                IdEstado = u?.EstadoUsuario?.Id ?? -1,
                IdBloco = perfil == PERFIL_SECRETARIA_BLOCO ? u?.BlocoUsuario?.Id ?? -1 : 0,
                IdRegiao = perfil == PERFIL_SECRETARIA_REGIONAL ? u?.RegiaoUsuario?.Id ?? -1 : 0,
            };
        }

        /// <summary>Aplica o escopo sobre os filtros pedidos (ADM pode escolher o estado).</summary>
        private static PesquisaGeralDTO Filtro(Escopo e, int idEstado, int idBloco, int idRegiao, int idIgreja, string nome) => new PesquisaGeralDTO
        {
            IdEstado = e.EhAdm ? idEstado : e.IdEstado,
            IdBloco = e.IdBloco != 0 ? e.IdBloco : idBloco,
            IdRegiao = e.IdRegiao != 0 ? e.IdRegiao : idRegiao,
            IdIgreja = idIgreja,
            Nome = string.IsNullOrWhiteSpace(nome) ? null : nome.Trim(),
        };

        private static ObreiroDTO BuscarObreiro(int idObreiro, Escopo e)
        {
            var obreiro = new FacadeArvoreVidaImpl()
                .PesquisaObreiroPorParametro(new ParametroPesquisaObreiroDTO { IdObreiro = idObreiro })
                .FirstOrDefault(o => o.IdObreiro == idObreiro);
            return obreiro != null && e.Permite(obreiro.IdEstado, obreiro.IdBloco, obreiro.IdRegiao) ? obreiro : null;
        }

        private static string FotoUrl(int idJovem, string nomeArquivo) =>
            string.IsNullOrWhiteSpace(nomeArquivo) || !new[] { ".jpg", ".jpeg", ".png", ".webp" }.Contains(System.IO.Path.GetExtension(nomeArquivo).ToLowerInvariant())
                ? null : $"/api/v2/jovens/{idJovem}/foto";

        private static object Obreiro(ObreiroDTO o) => new
        {
            o.IdObreiro, o.NomeObreiro, o.IdEstado, o.NomeEstado, o.IdBloco, o.NomeBloco, o.IdRegiao, o.NomeRegiao,
            o.IdIgreja, o.NomeIgreja, o.AnosObreiro, o.MesesObreiro, FotoUrl = FotoUrl(o.IdObreiro, o.NomeArquivoFoto),
        };

        private void Registrar(string acao)
        {
            try
            {
                var u = SessionHelper.RetornaUsuarioLogado();
                SessionHelper.ObterLoogerParaController().WriteUserAction(u?.Id ?? 0, u?.EstadoUsuario?.SiglaEstado, $"O usuário {u?.Login} {acao} (SGFJU 2.0)");
            }
            catch (Exception exc) { LoggerHelper.WriteLogError("Falha ao registrar ação: " + exc.Message); }
        }

        // ------------------------------------------------------------------ painel
        [HttpGet("status")]
        public IActionResult Status() => Ok(STATUS);

        /// <summary>Totais. ADM recebe o total nacional e a lista por estado; os demais, só o próprio estado.</summary>
        [HttpGet("totais")]
        public IActionResult Totais()
        {
            var e = ObterEscopo();
            var facade = new AVDashboardFacadeImpl();
            if (!e.EhAdm)
                return Ok(new { Estados = new[] { facade.ListaTotaisArvoreVidaPorEstado(new EstadoDTO { IdEstado = e.IdEstado }) }.Where(x => x != null) });

            var estados = facade.ListaTotaisArvoreVidaGeral() ?? new List<TotaisArvoreVidaEstadoDTO>();
            return Ok(new { Estados = estados.OrderByDescending(x => x.QuantidadeJovens) });
        }

        // ------------------------------------------------------------------ obreiros
        [HttpGet("obreiros")]
        public IActionResult Obreiros(int idEstado = 0, int idBloco = 0, int idRegiao = 0, int idIgreja = 0, string nome = null)
        {
            var e = ObterEscopo();
            var f = Filtro(e, idEstado, idBloco, idRegiao, idIgreja, nome);
            var lista = new FacadeArvoreVidaImpl().PesquisaObreiroPorParametro(new ParametroPesquisaObreiroDTO
            {
                IdEstado = f.IdEstado, IdBloco = f.IdBloco, IdRegiao = f.IdRegiao, IdIgreja = f.IdIgreja, NomeObreiro = f.Nome
            });
            return Ok(lista.Where(o => e.Permite(o.IdEstado, o.IdBloco, o.IdRegiao)).Select(Obreiro));
        }

        /// <summary>Obreiro + jovens que ele acompanha + jovens da igreja dele que ainda não têm acompanhamento.</summary>
        [HttpGet("obreiros/{idObreiro:int}")]
        public IActionResult ObreiroDetalhe(int idObreiro)
        {
            var obreiro = BuscarObreiro(idObreiro, ObterEscopo());
            if (obreiro == null) return NotFound(new { mensagem = "Obreiro não encontrado no seu escopo." });

            var facade = new FacadeArvoreVidaImpl();
            var acompanhados = facade.ListaJovensAcompanhadosPorObreiro(new ObreiroDTO { IdObreiro = idObreiro }) ?? new List<TodosJovensDTO>();
            var disponiveis = obreiro.IdIgreja > 0
                ? facade.ListaJovensIgrejaObreiroSemAcompanhamento(new ObreiroDTO { IdObreiro = idObreiro, IdIgreja = obreiro.IdIgreja }) ?? new List<TodosJovensDTO>()
                : new List<TodosJovensDTO>();

            return Ok(new
            {
                Obreiro = Obreiro(obreiro),
                Acompanhados = acompanhados.GroupBy(j => j.IdJovem).Select(g => g.First()),
                Disponiveis = disponiveis.Where(j => j.IdJovem != idObreiro).GroupBy(j => j.IdJovem).Select(g => g.First()),
            });
        }

        public sealed class AssociacaoRequest
        {
            public List<int> IdsJovens { get; set; } = new List<int>();
            public DateTime? DataInicio { get; set; }
        }

        [HttpPost("obreiros/{idObreiro:int}/associar")]
        public IActionResult Associar(int idObreiro, [FromBody] AssociacaoRequest r)
        {
            var obreiro = BuscarObreiro(idObreiro, ObterEscopo());
            if (obreiro == null) return NotFound(new { mensagem = "Obreiro não encontrado no seu escopo." });
            var ids = (r?.IdsJovens ?? new List<int>()).Distinct().Where(i => i > 0 && i != idObreiro).ToList();
            if (ids.Count == 0) return BadRequest(new { mensagem = "Selecione ao menos um jovem." });

            // Só pode associar jovens da igreja do obreiro que ainda não têm acompanhamento.
            var facade = new FacadeArvoreVidaImpl();
            var permitidos = facade.ListaJovensIgrejaObreiroSemAcompanhamento(new ObreiroDTO { IdObreiro = idObreiro, IdIgreja = obreiro.IdIgreja })
                .Select(j => j.IdJovem).ToHashSet();
            var invalidos = ids.Where(i => !permitidos.Contains(i)).ToList();
            if (invalidos.Count > 0)
                return BadRequest(new { mensagem = "Alguns jovens não estão disponíveis para este obreiro (já acompanhados ou de outra igreja).", invalidos });

            var inicio = (r.DataInicio ?? DateTime.Today).ToString("yyyy-MM-dd");
            facade.AssociaJovensAObreiro(
                ids.Select(i => new JovemAcompanhamentoDTO { IdJovem = i, DataInicioAcompanhamento = inicio }).ToList(),
                new ObreiroDTO { IdObreiro = idObreiro });
            Registrar($"associou os jovens {string.Join(",", ids)} ao obreiro {idObreiro}");
            return Ok(new { Associados = ids.Count });
        }

        public sealed class DesassociacaoRequest { public List<int> IdsJovens { get; set; } = new List<int>(); }

        [HttpPost("obreiros/{idObreiro:int}/desassociar")]
        public IActionResult Desassociar(int idObreiro, [FromBody] DesassociacaoRequest r)
        {
            var obreiro = BuscarObreiro(idObreiro, ObterEscopo());
            if (obreiro == null) return NotFound(new { mensagem = "Obreiro não encontrado no seu escopo." });

            var facade = new FacadeArvoreVidaImpl();
            var acompanhados = facade.ListaJovensAcompanhadosPorObreiro(new ObreiroDTO { IdObreiro = idObreiro }).Select(j => j.IdJovem).ToHashSet();
            var ids = (r?.IdsJovens ?? new List<int>()).Distinct().Where(acompanhados.Contains).ToList();
            if (ids.Count == 0) return BadRequest(new { mensagem = "Selecione ao menos um jovem acompanhado por este obreiro." });

            facade.DesassociaJovensDeObreiro(ids.Select(i => new JovemAcompanhamentoDTO { IdJovem = i }).ToList(), new ObreiroDTO { IdObreiro = idObreiro });
            Registrar($"desassociou os jovens {string.Join(",", ids)} do obreiro {idObreiro}");
            return Ok(new { Desassociados = ids.Count });
        }

        // ------------------------------------------------------------------ acompanhamento
        [HttpGet("acompanhamentos")]
        public IActionResult Acompanhamentos(int idEstado = 0, int idBloco = 0, int idRegiao = 0, int idIgreja = 0, string nome = null)
        {
            var e = ObterEscopo();
            var lista = new FacadeArvoreVidaImpl().ListaJovensEmAcompanhamentoPorParametro(Filtro(e, idEstado, idBloco, idRegiao, idIgreja, nome))
                ?? new List<TodosJovensDTO>();
            return Ok(lista.Where(j => e.Permite(j.IdEstado, j.IdBlocoJovem, j.IdRegiaoJovem)).GroupBy(j => j.IdJovem).Select(g => g.First()));
        }

        [HttpGet("acompanhamentos/{idJovem:int}")]
        public IActionResult Historico(int idJovem)
        {
            var e = ObterEscopo();
            var a = new FacadeArvoreVidaImpl().RetornaHistoricoAcompanhamentoJovem(new JovemDTO { Id = idJovem });
            var ig = a?.InformacoesIgreja;
            if (a == null || a.IdJovemEmAcompanhamento == 0 || (ig != null && !e.Permite(ig.IdEstado, ig.IdBlocoJovem, ig.IdRegiao)))
                return NotFound(new { mensagem = "Acompanhamento não encontrado no seu escopo." });

            return Ok(new
            {
                IdJovem = a.IdJovemEmAcompanhamento,
                Nome = a.NomeJovemEmAcompanhamento,
                FotoUrl = FotoUrl(a.IdJovemEmAcompanhamento, a.NomeArquivoFoto),
                a.IdObreiro, a.NomeObreiro, a.DataInicioAcompanhamento, a.DataTerminoAcompanhamento,
                Igreja = ig,
                Historico = (a.HistoricoAcompanhamento ?? new List<ItemAcompanhamentoHistoricoDTO>())
                    .OrderByDescending(h => h.IdHistorico)
                    .Select(h => new { h.IdHistorico, h.IdStatusAcompanhamento, h.DescricaoStatusAcompanhamento, h.TextoHistorico, h.DataHistorico }),
            });
        }

        public sealed class HistoricoRequest
        {
            public int IdStatus { get; set; }
            public string Texto { get; set; }
        }

        [HttpPost("acompanhamentos/{idJovem:int}/historico")]
        public IActionResult RegistrarHistorico(int idJovem, [FromBody] HistoricoRequest r)
        {
            if (r == null || !new[] { 1, 2, 3 }.Contains(r.IdStatus)) return BadRequest(new { mensagem = "Escolha a situação do jovem." });
            var texto = (r.Texto ?? "").Trim();
            if (texto.Length < 3) return BadRequest(new { mensagem = "Escreva como está o acompanhamento." });
            if (texto.Length > 4000) texto = texto.Substring(0, 4000);

            var e = ObterEscopo();
            var facade = new FacadeArvoreVidaImpl();
            var a = facade.RetornaHistoricoAcompanhamentoJovem(new JovemDTO { Id = idJovem });
            var ig = a?.InformacoesIgreja;
            if (a == null || a.IdObreiro == 0 || (ig != null && !e.Permite(ig.IdEstado, ig.IdBlocoJovem, ig.IdRegiao)))
                return NotFound(new { mensagem = "Este jovem não está em acompanhamento no seu escopo." });

            facade.RegistraHistoricoJovem(new JovemHistorico
            {
                Jovem = new Jovem { Id = idJovem },
                Obreiro = new Jovem { Id = a.IdObreiro },
                TextoObservacao = texto,
                StatusJovem = new StatusAcompanhamento { Code = r.IdStatus },
                DataHistoricoAcompanhamento = DateTime.Now,
            });
            Registrar($"registrou histórico de acompanhamento do jovem {idJovem}");
            return Ok(new { Mensagem = "Histórico registrado." });
        }

        // ------------------------------------------------------------------ panorama
        /// <summary>Obreiros com e sem "ramos" (jovens acompanhados) no escopo.</summary>
        [HttpGet("panorama")]
        public IActionResult Panorama(int idEstado = 0, int idBloco = 0, int idRegiao = 0, int idIgreja = 0, string nome = null)
        {
            var e = ObterEscopo();
            var f = Filtro(e, idEstado, idBloco, idRegiao, idIgreja, nome);
            if (e.EhAdm && f.IdEstado == 0) return BadRequest(new { mensagem = "Escolha um estado." });
            var facade = new FacadeArvoreVidaImpl();
            var com = (facade.ListaObreirosComRamosPorParametro(f) ?? new List<ObreiroDTO>()).Where(o => e.Permite(o.IdEstado, o.IdBloco, o.IdRegiao));
            var sem = (facade.ListarObreirosSemRamosAVPorParametro(f) ?? new List<ObreiroDTO>()).Where(o => e.Permite(o.IdEstado, o.IdBloco, o.IdRegiao));
            return Ok(new
            {
                ComRamos = com.Select(o => new { Obreiro = Obreiro(o), Jovens = (o.JovensQueObreiroAcompanha ?? new List<JovemDTO>()).Count }),
                SemRamos = sem.Select(Obreiro),
            });
        }
    }
}
