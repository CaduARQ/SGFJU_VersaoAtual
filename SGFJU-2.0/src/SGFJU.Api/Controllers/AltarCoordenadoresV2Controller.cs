using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SGFJU.Api.Legado;
using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Entities;
using SGFJU.ServicesLayer.DTO;

namespace SGFJU.Api.Controllers
{
    /// <summary>
    /// Altar Jovem e Coordenadores na versão 2.0.
    /// Tudo limitado ao escopo do usuário; a troca de coordenador confere se o coordenador está nesse escopo.
    /// </summary>
    [ApiController]
    [Route("api/v2")]
    public class AltarCoordenadoresV2Controller : ControllerBase
    {
        // Grupos do Altar Jovem (mesmos códigos usados pelo repositório antigo).
        private static readonly Dictionary<string, string> GRUPOS = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            ["Agua"] = "Batizados nas águas",
            ["Oleo"] = "Batizados no Espírito Santo",
            ["Sal"] = "Cursando o CPO",
            ["Luz"] = "Obreiros",
        };

        private static string FotoUrl(int id, string arquivo) =>
            string.IsNullOrWhiteSpace(arquivo) || !new[] { ".jpg", ".jpeg", ".png", ".webp" }.Contains(System.IO.Path.GetExtension(arquivo).ToLowerInvariant())
                ? null : $"/api/v2/jovens/{id}/foto";

        // ------------------------------------------------------------------ Altar Jovem
        public sealed class AltarFiltro
        {
            public int IdEstado { get; set; }
            public int IdBloco { get; set; }
            public int IdRegiao { get; set; }
            public int IdIgreja { get; set; }
            public string Nome { get; set; }
            public string Sexo { get; set; }
            public List<string> Grupos { get; set; } = new List<string>();
            public bool Somente318 { get; set; }
        }

        [HttpGet("altar-jovem/grupos")]
        public IActionResult Grupos() => Ok(GRUPOS.Select(g => new { Id = g.Key, Nome = g.Value }));

        /// <summary>Jovens que pertencem ao Altar Jovem. Grupos marcados precisam valer todos ao mesmo tempo (E).</summary>
        [HttpPost("altar-jovem/consulta")]
        public IActionResult ConsultarAltar([FromBody] AltarFiltro f)
        {
            f ??= new AltarFiltro();
            var e = EscopoUsuario.Atual();
            var (estado, bloco, regiao) = e.Aplicar(f.IdEstado, f.IdBloco, f.IdRegiao);
            if (!e.EhAdm && estado <= 0) return Ok(new List<object>());
            if (e.EhAdm && estado == 0 && bloco == 0 && f.IdIgreja == 0 && (f.Grupos?.Count ?? 0) == 0 && !f.Somente318 && string.IsNullOrWhiteSpace(f.Nome))
                return BadRequest(new { mensagem = "Escolha ao menos um estado ou filtro para não trazer o país inteiro." });

            var lista = new AltarJovemFacadeImpl().ObterJovensAltarJovemPorParametro(new AltarJovemParametroPesquisaDTO
            {
                IdEstado = estado,
                IdBlocoJovem = bloco,
                IdRegiaoJovem = regiao,
                IdIgreja = f.IdIgreja,
                // Só M/F chegam ao SQL (o repositório concatena o valor).
                Sexo = f.Sexo == "M" || f.Sexo == "F" ? f.Sexo : null,
                // Só os 4 códigos conhecidos.
                GruposSelecionadosPesquisa = (f.Grupos ?? new List<string>()).Where(GRUPOS.ContainsKey).Select(g => GRUPOS.Keys.First(k => k.Equals(g, StringComparison.OrdinalIgnoreCase))).Distinct().ToList(),
                EhAltarJovem318 = f.Somente318 ? 'S' : '\0',
            }) ?? new List<AltarJovemDTO>();

            // O repositório ignora o nome; filtramos aqui.
            var nome = (f.Nome ?? "").Trim();
            // O escopo já vai no SQL (estado/bloco/região forçados acima); estas consultas antigas
            // não devolvem os ids da estrutura, então não dá para conferir de novo linha a linha.
            var resultado = lista
                .Where(j => nome.Length == 0 || (j.NomeJovem ?? "").Contains(nome, StringComparison.OrdinalIgnoreCase))
                .GroupBy(j => j.IdJovem).Select(g => g.First())
                .Select(j => new
                {
                    j.IdJovem, j.NomeJovem, j.DataNascimento, j.NomeEstado, j.NomeBlocoJovem, j.NomeRegiaoJovem, j.NomeIgrejaJovem,
                    j.Whatsapp, j.WhatsappSemFormatacao, FotoUrl = FotoUrl(j.IdJovem, j.NomeArquivoFoto),
                })
                .ToList();
            return Ok(resultado);
        }

        /// <summary>Jovens com classificação "Levantado para o altar".</summary>
        [HttpGet("altar-jovem/levantados")]
        public IActionResult Levantados(int idEstado = 0, int idBloco = 0, int idRegiao = 0, int idIgreja = 0)
        {
            var e = EscopoUsuario.Atual();
            var (estado, bloco, regiao) = e.Aplicar(idEstado, idBloco, idRegiao);
            var lista = new AltarJovemFacadeImpl().ListaJovensLevantadosParaOAltarPorParametro(new AltarJovemParametroPesquisaDTO
            {
                IdEstado = estado, IdBlocoJovem = bloco, IdRegiaoJovem = regiao, IdIgreja = idIgreja,
            }) ?? new List<TodosJovensDTO>();
            if (!e.EhAdm && estado <= 0) return Ok(new List<TodosJovensDTO>());
            return Ok(lista.GroupBy(j => j.IdJovem).Select(g => g.First()));
        }

        // ------------------------------------------------------------------ Coordenadores
        private static object Coordenador(IgrejaCoordenadorDTO c) => new
        {
            c.IdIgrejaCoordenador, c.IdCoordenadorFJU, NomeCoordenador = c.NomeCoordenador ?? c.Nome, c.NomeTipoCoordenador,
            c.IdEstado, c.NomeEstado, IdBloco = c.IdBlocoJovem, NomeBloco = c.NomeBlocoJovem, c.IdRegiao, NomeRegiao = c.NomeRegiaoJovem,
            c.IdIgreja, c.NomeIgreja, c.DataNascimento, c.DataEntradaCoordenador, c.PeriodoCoordenando,
            c.TotalAnosCoordenandoFJU, c.TotalMesesCoordenandoFJU, c.AnosCoordenandoIgrejaAtualFJU, c.MesesCoordenandoIgrejaAtualFJU,
            c.QuantidadeJovensEncontroAnterior, c.QuantidadeJovensEncontroAtual,
            FotoUrl = c.IdCoordenadorFJU > 0 ? FotoUrl(c.IdCoordenadorFJU, c.NomeArquivoFoto) : null,
        };

        private static List<IgrejaCoordenadorDTO> BuscarCoordenadores(EscopoUsuario e, int idEstado, int idBloco, int idRegiao, int idIgreja)
        {
            var (estado, bloco, regiao) = e.Aplicar(idEstado, idBloco, idRegiao);
            return (new FacadeCoordenadorImpl().PesquisarCoordenadorPorParametro(new IgrejaCoordenadorParametroDTO
            {
                IdEstado = estado, IdBlocoJovem = bloco, IdRegiaoJovem = regiao, IdIgreja = idIgreja
            }) ?? new List<IgrejaCoordenadorDTO>())
                .Where(c => e.Permite(c.IdEstado, c.IdBlocoJovem, c.IdRegiao))
                .ToList();
        }

        [HttpGet("coordenadores")]
        public IActionResult Coordenadores(int idEstado = 0, int idBloco = 0, int idRegiao = 0, int idIgreja = 0)
        {
            var e = EscopoUsuario.Atual();
            if (e.EhAdm && idEstado == 0) return BadRequest(new { mensagem = "Escolha um estado." });
            return Ok(BuscarCoordenadores(e, idEstado, idBloco, idRegiao, idIgreja)
                .GroupBy(c => c.IdIgrejaCoordenador).Select(g => g.First()).Select(Coordenador));
        }

        /// <summary>Panorama: igrejas com coordenador, sem coordenador e sem FJU. ADM sem estado recebe o nacional.</summary>
        [HttpGet("coordenadores/panorama")]
        public IActionResult Panorama(int idEstado = 0)
        {
            var e = EscopoUsuario.Atual();
            var facade = new FacadeCoordenadorImpl();
            var estado = e.EhAdm ? idEstado : e.IdEstado;
            var lista = (estado == 0 ? facade.ObterPanoramaGeralCoordenadorNacional() : facade.ObterPanoramaGeralCoordenadorPorEstado(new EstadoDTO { IdEstado = estado }))
                ?? new List<IgrejaCoordenadorDTO>();
            lista = lista.Where(c => e.Permite(c.IdEstado, c.IdBlocoJovem, c.IdRegiao)).ToList();

            // Mesmas regras do controller antigo.
            var com = lista.Where(c => c.IdCoordenadorFJU != 0 && c.IdIgrejaCoordenador != 0).ToList();
            var semCoordenador = lista.Where(c => c.IdCoordenadorFJU == 0 && c.IdIgrejaCoordenador == 0).ToList();
            var semFju = lista.Where(c => c.IdIgrejaCoordenador > 0 && c.IdCoordenadorFJU == 0).ToList();

            var porEstado = lista.GroupBy(c => new { c.IdEstado, c.NomeEstado }).Select(g => new
            {
                g.Key.IdEstado, g.Key.NomeEstado,
                ComCoordenador = g.Count(c => c.IdCoordenadorFJU != 0 && c.IdIgrejaCoordenador != 0),
                SemCoordenador = g.Count(c => c.IdCoordenadorFJU == 0 && c.IdIgrejaCoordenador == 0),
                SemFju = g.Count(c => c.IdIgrejaCoordenador > 0 && c.IdCoordenadorFJU == 0),
            }).OrderBy(x => x.NomeEstado);

            return Ok(new
            {
                Totais = new { ComCoordenador = com.Count, SemCoordenador = semCoordenador.Count, SemFju = semFju.Count, Igrejas = lista.Count },
                PorEstado = porEstado,
                IgrejasSemCoordenador = semCoordenador.Select(c => new { c.IdIgreja, c.NomeIgreja, NomeRegiao = c.NomeRegiaoJovem, NomeBloco = c.NomeBlocoJovem, c.NomeEstado }).OrderBy(x => x.NomeIgreja),
            });
        }

        public sealed class TrocaRequest
        {
            public DateTime? DataSaida { get; set; }
            public string Motivo { get; set; }
            public string NomePastor { get; set; }
            public string NomeNovoCoordenador { get; set; }
        }

        /// <summary>Registra a saída do coordenador atual (troca). Confere se ele está no escopo do usuário.</summary>
        [HttpPost("coordenadores/{idIgrejaCoordenador:int}/troca")]
        public IActionResult Trocar(int idIgrejaCoordenador, [FromBody] TrocaRequest r)
        {
            if (r == null || r.DataSaida == null) return BadRequest(new { mensagem = "Informe a data de saída." });
            if (r.DataSaida > DateTime.Today) return BadRequest(new { mensagem = "A data de saída não pode ser no futuro." });
            if (string.IsNullOrWhiteSpace(r.Motivo) || r.Motivo.Trim().Length < 3) return BadRequest(new { mensagem = "Explique o motivo da troca." });
            if (string.IsNullOrWhiteSpace(r.NomePastor)) return BadRequest(new { mensagem = "Informe quem fez a troca." });

            var e = EscopoUsuario.Atual();
            var facade = new FacadeCoordenadorImpl();
            var atual = facade.ObterIgrejaCoordenadorPorID(idIgrejaCoordenador);
            if (atual == null) return NotFound(new { mensagem = "Coordenador não encontrado." });
            var igreja = atual.IgrejaFJU?.Id ?? 0;
            var noEscopo = BuscarCoordenadores(e, e.EhAdm ? 0 : e.IdEstado, 0, 0, igreja).Any(c => c.IdIgrejaCoordenador == idIgrejaCoordenador);
            if (!e.EhAdm && !noEscopo) return NotFound(new { mensagem = "Coordenador não encontrado no seu escopo." });

            facade.TrocarCoordenador(new IgrejaCoordenador
            {
                Id = idIgrejaCoordenador,
                DataSaidaCoordenador = r.DataSaida.Value,
                MotivoTrocaCoordenador = r.Motivo.Trim(),
                NomePastorEfetuouTroca = r.NomePastor.Trim(),
                NomeNovoCoordenador = string.IsNullOrWhiteSpace(r.NomeNovoCoordenador) ? null : r.NomeNovoCoordenador.Trim(),
            });
            try
            {
                var u = SessionHelper.RetornaUsuarioLogado();
                SessionHelper.ObterLoogerParaController().WriteUserAction(u?.Id ?? 0, u?.EstadoUsuario?.SiglaEstado, $"O usuário {u?.Login} registrou a troca do coordenador {idIgrejaCoordenador} (SGFJU 2.0)");
            }
            catch (Exception exc) { LoggerHelper.WriteLogError("Falha ao registrar ação: " + exc.Message); }
            return Ok(new { Mensagem = "Troca registrada." });
        }
    }
}
