using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGFJU.Api.Legado;
using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.ValueObjects;

namespace SGFJU.Api.Controllers
{
    /// <summary>
    /// Cadastro de jovem da versão 2.0. Substitui o postback do RegistraJovem.aspx.
    /// Diferente da tela antiga, NÃO usa sessão: idiomas, habilidades e cursos chegam todos
    /// juntos no mesmo JSON. Os campos são os mesmos do formulário antigo.
    /// </summary>
    [ApiController]
    [Route("api/v2/jovens")]
    public class JovensCadastroController : ControllerBase
    {
        // ------------------------------------------------------------------ contrato
        public sealed class NovoJovemRequest
        {
            // Identificação
            public int IdIgreja { get; set; }
            public string Nome { get; set; }
            public DateTime? DataNascimento { get; set; }
            public string Sexo { get; set; }                 // M | F
            public string ClassificacaoJovem { get; set; }   // A | I | N
            public int? IdEstadoCivil { get; set; }
            public DateTime? DataPreenchimentoFormulario { get; set; }

            // Família
            public string NomeConjuge { get; set; }
            public string ConjugeEhIURD { get; set; }
            public DateTime? DataCasamento { get; set; }
            public string PossuiFilhos { get; set; }
            public int QuantidadeFilhos { get; set; }
            public string PossuiTituloEleitor { get; set; }
            public string PertenceGrupoMulheresIURD { get; set; }
            public string NomeGrupoMulheresIURD { get; set; }

            public ContatoReq Contato { get; set; } = new ContatoReq();
            public EnderecoReq Endereco { get; set; } = new EnderecoReq();
            public RedesReq Redes { get; set; } = new RedesReq();
            public EspiritualReq Espiritual { get; set; } = new EspiritualReq();
            public ObraReq Obra { get; set; } = new ObraReq();
            public EstudoReq Estudo { get; set; } = new EstudoReq();
            public TrabalhoReq Trabalho { get; set; } = new TrabalhoReq();
            public ProjetoReq Projeto { get; set; } = new ProjetoReq();
            public TestemunhoReq Testemunho { get; set; } = new TestemunhoReq();

            public List<ItemNivel> Idiomas { get; set; } = new List<ItemNivel>();
            public List<HabilidadeReq> Habilidades { get; set; } = new List<HabilidadeReq>();
            public List<CursoReq> Cursos { get; set; } = new List<CursoReq>();
            public List<int> TonsDeVoz { get; set; } = new List<int>();
            public List<int> Departamentos { get; set; } = new List<int>();
            public List<int> Reunioes { get; set; } = new List<int>();
            public List<int> Livros { get; set; } = new List<int>();

            public string EhPalestranteHelp { get; set; }
            public string EhAtendenteWhatsappHelp { get; set; }
            public string EhAltarJovem318 { get; set; }
            public string CodigoAltarJovem318 { get; set; }
            public string TextoSugestao { get; set; }
        }

        /// <summary>Resposta do GET de edição: o mesmo formato do cadastro + dados de apoio para a tela.</summary>
        public sealed class JovemEdicaoResponse
        {
            public int IdJovem { get; set; }
            public NovoJovemRequest Dados { get; set; }
            public int IdEstado { get; set; }
            public int IdBloco { get; set; }
            public int IdRegiao { get; set; }
            public string FotoUrl { get; set; }
            public bool TemDocumentoAutorizacao { get; set; }
            public DateTime? DataUltimaAtualizacao { get; set; }
        }

        public sealed class ContatoReq { public string Whatsapp { get; set; } public string TelefoneFixo { get; set; } public string TelefoneEmergencia { get; set; } public string NomeContatoEmergencia { get; set; } }
        public sealed class EnderecoReq { public string Endereco { get; set; } public string Bairro { get; set; } public string Cidade { get; set; } public int? IdTipoMoradia { get; set; } }
        public sealed class RedesReq
        {
            public string Email { get; set; } public string Instagram { get; set; } public string Facebook { get; set; } public string Twitter { get; set; }
            public string EhSeguidorOficialFJU { get; set; } public string EhSeguidorYoutube { get; set; } public string EhSeguidorTelegram { get; set; }
            public string EhAssinanteUNIVER { get; set; } public string FrequenciaAssisteUNIVER { get; set; } public string EhLeitorBlogBM { get; set; }
            public string EhLeitorUniversalorg { get; set; } public string PossuiCelularComInternet { get; set; } public string PossuiComputador { get; set; }
        }
        public sealed class EspiritualReq
        {
            public string EhMembroIURD { get; set; } public string MesAnoChegadaIURD { get; set; } public string ComoConheceuIURD { get; set; }
            public string JaSeAfastou { get; set; } public string MotivoSeAfastou { get; set; } public string MesAnoAfastamento { get; set; }
            public string TempoAfastamento { get; set; } public string TempoEstaFirme { get; set; } public string DescricaoFamiliaresIURD { get; set; }
            public string EhBatizadoAguas { get; set; } public string MesAnoBatismoAguas { get; set; } public string BatismoAguasIURD { get; set; }
            public string EhBatizadoEspiritoSanto { get; set; } public string MesAnoBatismoEspiritoSanto { get; set; } public string OcasiaoBatismoEspiritoSanto { get; set; }
            public string DescricaoModoChegouFJU { get; set; } public string MotivoEntradaFJU { get; set; } public string MesAnoEntradaFJU { get; set; }
            public string PossuiBiblia { get; set; } public string LeuTodaBiblia { get; set; } public int? IdFrequenciaLeituraBiblia { get; set; }
        }
        public sealed class ObraReq
        {
            public string EhObreiro { get; set; } public int AnosObreiro { get; set; } public int MesesObreiro { get; set; }
            public string EhColaborador { get; set; } public int AnosColaborador { get; set; } public int MesesColaborador { get; set; }
            public string EstaCursandoCPO { get; set; } public int? MesInicioCPO { get; set; } public int? AnoInicioCPO { get; set; }
            public string EhPertencenteFJU { get; set; }
            public string EhCoordenadorFJU { get; set; } public int MesesCoordenandoFJU { get; set; } public int AnosCoordenandoFJU { get; set; }
            public string EhLiderTribo { get; set; } public int? IdTribo { get; set; } public int MesesCoordenandoTribo { get; set; } public int AnosCoordenandoTribo { get; set; }
            public string EhLiderProjeto { get; set; } public int? IdProjetoQueCoordena { get; set; } public int MesesCoordenandoProjeto { get; set; } public int AnosCoordenandoProjeto { get; set; }
            public string PossuiCamisaProjeto { get; set; } public string NomeCamisaFJU { get; set; } public string TamanhoCamisa { get; set; }
            public string FoiObreiro { get; set; } public string MotivoSaiuObreiro { get; set; }
            public string FoiPastor { get; set; } public string MotivoSaidaPastor { get; set; }
            public string DesejaSerObreiro { get; set; } public string MotivoDesejaSerObreiro { get; set; }
            public string DesejaFazerObraNoAltar { get; set; } public string PertenceAltarJovem { get; set; }
            public string PertenceIntellimen { get; set; } public string DesafiosConcluidos { get; set; } public int DesafioAtual { get; set; }
            public string NomeParceiroIntellimen { get; set; } public string TelefoneParceiroIntellimen { get; set; }
        }
        public sealed class EstudoReq
        {
            public string GrauEscolaridade { get; set; } public string EstudaAtualmente { get; set; } public string NomeInstituicaoEnsino { get; set; }
            public string NomeCursoSuperior { get; set; } public string PeriodoAtualNivelFaculdade { get; set; } public int? IdModalidade { get; set; }
            public string PossuiNivelSuperior { get; set; } public string PrevisaoConclusaoCurso { get; set; }
            public string DesejaCursarNivelSuperior { get; set; } public string NomeCursoSuperiorDesejaCursar { get; set; }
        }
        public sealed class TrabalhoReq { public string TrabalhaAtualmente { get; set; } public string Profissao { get; set; } public string NomeEmpresa { get; set; } }
        public sealed class ProjetoReq
        {
            public int IdProjeto { get; set; } public int Meses { get; set; } public int Anos { get; set; }
            public string PertenceuOutroProjeto { get; set; } public int IdProjetoAnterior { get; set; }
        }
        public sealed class TestemunhoReq
        {
            public string SofreuComDepressao { get; set; } public string TempoSofreuDepressao { get; set; } public string TempoLivreDepressao { get; set; }
            public string TentouSuicidio { get; set; } public string DescricaoTentativaSuicidio { get; set; } public string MesAnoTentativaSuicidio { get; set; } public int NumeroTentativasSuicidio { get; set; }
            public string SofreuAutomutilacao { get; set; } public string TempoSofreuAutomutilacao { get; set; }
            public string TempoLivreAutomutilacao { get; set; }
            public string SofreuVicio { get; set; } public string DescricaoVicio { get; set; } public string TempoVicio { get; set; } public string TempoLivreVicios { get; set; }
            public string TextoTestemunho { get; set; }
        }
        public sealed class ItemNivel { public int Id { get; set; } public int IdNivel { get; set; } public string NomeExtra { get; set; } }
        public sealed class HabilidadeReq { public int IdHabilidade { get; set; } public int IdNivel { get; set; } public string NomeHabilidadeExtra { get; set; } public string Nome { get; set; } }
        public sealed class CursoReq { public int Code { get; set; } public string NomeCurso { get; set; } public int IdProjeto { get; set; } }

        // Nível usado pela tela antiga para tons de voz, e os ids dos tons (Tenor..Contralto).
        private const int NIVEL_TOM_DE_VOZ = 5;
        private static readonly int[] TONS_DE_VOZ = { 51, 52, 53, 54, 55, 56 };

        // ------------------------------------------------------------------ endpoints
        [HttpPost]
        public ActionResult<object> Cadastrar([FromBody] NovoJovemRequest r)
        {
            var erros = Validar(r);
            if (erros.Count > 0) return BadRequest(new { mensagem = string.Join(" ", erros), erros });

            var usuario = SessionHelper.RetornaUsuarioLogado();
            var siglaEstado = usuario?.EstadoUsuario?.SiglaEstado ?? string.Empty;

            var jovem = new Jovem { DataCadastro = DateTime.Now, SiglaEstadoJovem = siglaEstado, ArquivoAutorizacaoOk = 'N' };
            Preencher(jovem, r);
            var testemunho = MontarTestemunho(r.Testemunho, jovem, 0);
            var idiomas = MontarIdiomas(r, jovem);
            var habilidades = MontarHabilidades(r, jovem);

            var projeto = MontarProjeto(r, jovem);

            new FacadeJovemImpl().SalvarJovem(
                jovem,
                idiomas.Count > 0 ? idiomas : null,
                habilidades.Count > 0 ? habilidades : null,
                projeto,
                testemunho);

            try
            {
                SessionHelper.ObterLoogerParaController().WriteUserAction(
                    usuario?.Id ?? 0, siglaEstado, $"O usuário {usuario?.Login} cadastrou o jovem de ID {jovem.Id} (SGFJU 2.0)");
            }
            catch (Exception exc) { LoggerHelper.WriteLogError("Falha ao registrar ação: " + exc.Message); }

            return Ok(new { IdJovem = jovem.Id, Mensagem = "Jovem cadastrado com sucesso." });
        }

        /// <summary>Carrega um jovem no mesmo formato do cadastro, para a tela de edição.</summary>
        [HttpGet("{idJovem:int}")]
        public ActionResult<JovemEdicaoResponse> Obter(int idJovem)
        {
            var facade = new FacadeJovemImpl();
            var jovem = facade.GetByID(idJovem);
            if (jovem == null) return NotFound(new { mensagem = "Jovem não encontrado." });
            var detalhe = facade.ObterJovemInformacoesDetalhadas(new Jovem { Id = idJovem });

            string sn(char c) => c == 'S' || c == 's' ? "S" : c == 'N' || c == 'n' ? "N" : "";
            var esp = jovem.DadosEspirituaisJovem ?? new DadosEspirituais();
            var sit = jovem.SituacaoJovemIURDFJU ?? new SituacaoIURDFJU();
            var edu = jovem.DadosEducacionaisJovem ?? new DadosEducacionais();
            var red = jovem.RedeSocialJovem ?? new RedeSocial();
            var tes = detalhe?.TestemunhoJovem;
            var projetoAtual = detalhe?.ProjetosAosQuaisJovemEstaLigado?.FirstOrDefault();
            var (mesCpo, anoCpo) = MesAnoHash(sit.MesAnoInicioCPO);

            var dados = new NovoJovemRequest
            {
                IdIgreja = jovem.IgrejaAQualJovemPertence?.Id ?? 0,
                Nome = jovem.Nome,
                DataNascimento = jovem.DataNascimento,
                Sexo = jovem.Sexo == 'M' || jovem.Sexo == 'F' ? jovem.Sexo.ToString() : "",
                ClassificacaoJovem = jovem.ClassificacaoJovem == '\0' ? "N" : jovem.ClassificacaoJovem.ToString(),
                IdEstadoCivil = jovem.EstadoCivilJovem?.Code,
                DataPreenchimentoFormulario = jovem.DataPreenchimentoFormulario,
                NomeConjuge = jovem.NomeConjuge, ConjugeEhIURD = sn(jovem.ConjugeEhIURD), DataCasamento = jovem.DataCasamento,
                PossuiFilhos = sn(jovem.PossuiFilhos), QuantidadeFilhos = jovem.QuantidadeFilhos,
                PossuiTituloEleitor = sn(jovem.PossuiTituloEleitor),
                PertenceGrupoMulheresIURD = sn(jovem.PertenceGrupoMulheresIURD), NomeGrupoMulheresIURD = jovem.NomeGrupoMulheresIURD,
                EhPalestranteHelp = sn(jovem.EhPalestranteHelp), EhAtendenteWhatsappHelp = sn(jovem.EhAtendenteWhatsappHelp),
                EhAltarJovem318 = sn(jovem.EhAltarJovem318), CodigoAltarJovem318 = jovem.CodigoAltarJovem318,
                TextoSugestao = jovem.TextoSugestao,
                Contato = new ContatoReq
                {
                    Whatsapp = jovem.ContatoJovem?.Whatsapp, TelefoneFixo = jovem.ContatoJovem?.TelefoneFixo,
                    TelefoneEmergencia = jovem.ContatoJovem?.TelefoneEmergencia, NomeContatoEmergencia = jovem.ContatoJovem?.NomeContatoEmergencia
                },
                Endereco = new EnderecoReq
                {
                    Endereco = jovem.EnderecoJovem?.DescricaoEndereco, Bairro = jovem.EnderecoJovem?.Bairro,
                    Cidade = jovem.EnderecoJovem?.Cidade, IdTipoMoradia = jovem.EnderecoJovem?.TipoDeMoradia?.Code
                },
                Redes = new RedesReq
                {
                    Email = red.Email, Instagram = red.Instagram, Facebook = red.Facebook, Twitter = red.Twitter,
                    EhSeguidorOficialFJU = sn(red.EhSeguidorOficialFJU), EhSeguidorYoutube = sn(red.EhSeguidorYoutube), EhSeguidorTelegram = sn(red.EhSeguidorTelegram),
                    EhAssinanteUNIVER = sn(red.EhAssinanteUNIVER), FrequenciaAssisteUNIVER = red.FrequenciaAssisteUNIVER, EhLeitorBlogBM = sn(red.EhLeitorBlogBM),
                    EhLeitorUniversalorg = sn(red.EhLeitorUniversalorg), PossuiCelularComInternet = sn(red.PossuiCelularComInternet), PossuiComputador = sn(red.PossuiComputador)
                },
                Espiritual = new EspiritualReq
                {
                    EhMembroIURD = sn(esp.EhMembroIURD), MesAnoChegadaIURD = esp.MesAnoChegadaIURD, ComoConheceuIURD = esp.ComoConheceuIURD,
                    JaSeAfastou = sn(esp.JaSeAfastou), MotivoSeAfastou = esp.MotivoSeAfastou, MesAnoAfastamento = esp.MesAnoAfastamento,
                    TempoAfastamento = esp.TempoAfastamento, TempoEstaFirme = esp.TempoEstaFirme, DescricaoFamiliaresIURD = esp.DescricaoFamiliaresIURD,
                    EhBatizadoAguas = sn(esp.EhBatizadoAguas), MesAnoBatismoAguas = esp.MesAnoBatismoAguas, BatismoAguasIURD = sn(esp.BatismoAguasIURD),
                    EhBatizadoEspiritoSanto = sn(esp.EhBatizadoEspiritoSanto), MesAnoBatismoEspiritoSanto = esp.MesAnoBatismoEspiritoSanto,
                    OcasiaoBatismoEspiritoSanto = esp.OcasiaoBatismoEspiritoSanto, DescricaoModoChegouFJU = esp.DescricaoModoChegouFJU,
                    MotivoEntradaFJU = esp.MotivoEntradaFJU, MesAnoEntradaFJU = esp.MesAnoEntradaFJU,
                    PossuiBiblia = sn(esp.PossuiBiblia), LeuTodaBiblia = sn(esp.LeuTodaBiblia), IdFrequenciaLeituraBiblia = esp.FrequenciaLeituraBiblia?.Code
                },
                Obra = new ObraReq
                {
                    EhObreiro = sn(sit.EhObreiro), AnosObreiro = sit.AnosObreiro, MesesObreiro = sit.MesesObreiro,
                    EhColaborador = sn(sit.EhColaborador), AnosColaborador = sit.AnosColaborador, MesesColaborador = sit.MesesColaborador,
                    EstaCursandoCPO = sn(sit.EstaCursandoCPO), MesInicioCPO = mesCpo, AnoInicioCPO = anoCpo,
                    EhPertencenteFJU = sn(sit.EhPertencenteFJU),
                    EhCoordenadorFJU = sn(sit.EhCoordenadorFJU), MesesCoordenandoFJU = sit.MesesCoordenandoFJU, AnosCoordenandoFJU = sit.AnosCoordenandoFJU,
                    EhLiderTribo = sn(sit.EhLiderTribo), IdTribo = sit.TriboQueLidera?.Code, MesesCoordenandoTribo = sit.MesesCoordenandoTribo, AnosCoordenandoTribo = sit.AnosCoordenandoTribo,
                    EhLiderProjeto = sn(sit.EhLiderProjeto), IdProjetoQueCoordena = sit.ProjetoQueCoordena?.Code,
                    MesesCoordenandoProjeto = sit.MesesCoordenandoProjeto, AnosCoordenandoProjeto = sit.AnosCoordenandoProjeto,
                    PossuiCamisaProjeto = sn(sit.PossuiCamisaProjeto), NomeCamisaFJU = sit.NomeCamisaFJU, TamanhoCamisa = sit.TamanhoCamisa,
                    FoiObreiro = sn(sit.FoiObreiro), MotivoSaiuObreiro = sit.MotivoSaiuObreiro, FoiPastor = sn(sit.FoiPastor), MotivoSaidaPastor = sit.MotivoSaidaPastor,
                    DesejaSerObreiro = sn(sit.DesejaSerObreiro), MotivoDesejaSerObreiro = sit.MotivoDesejaSerObreiro,
                    DesejaFazerObraNoAltar = sn(sit.DesejaFazerObraNoAltar), PertenceAltarJovem = sn(sit.PertenceAltarJovem),
                    PertenceIntellimen = sn(sit.PertenceIntellimen), DesafiosConcluidos = sn(sit.DesafiosConcluidos), DesafioAtual = sit.DesafioAtual,
                    NomeParceiroIntellimen = sit.NomeParceiroIntellimen, TelefoneParceiroIntellimen = sit.TelefoneParceiroIntellimen
                },
                Estudo = new EstudoReq
                {
                    GrauEscolaridade = edu.GrauEscolaridade, EstudaAtualmente = sn(edu.EstudaAtualmente), NomeInstituicaoEnsino = edu.NomeInstituicaoEnsino,
                    NomeCursoSuperior = edu.NomeCursoSuperior, PeriodoAtualNivelFaculdade = edu.PeriodoAtualNivelFaculdade, IdModalidade = edu.ModalidadeCursadaEnsinoSuperior?.Code,
                    PossuiNivelSuperior = sn(edu.PossuiNivelSuperior), PrevisaoConclusaoCurso = edu.PrevisaoConclusaoCurso,
                    DesejaCursarNivelSuperior = sn(edu.DesejaCursarNivelSuperior), NomeCursoSuperiorDesejaCursar = edu.NomeCursoSuperiorDesejaCursar
                },
                Trabalho = new TrabalhoReq
                {
                    TrabalhaAtualmente = sn(jovem.DadosProfissionaisJovem?.TrabalhaAtualmente ?? '\0'),
                    Profissao = jovem.DadosProfissionaisJovem?.Profissao, NomeEmpresa = jovem.DadosProfissionaisJovem?.NomeEmpresa
                },
                Projeto = projetoAtual == null ? new ProjetoReq() : new ProjetoReq
                {
                    IdProjeto = projetoAtual.idProjeto, Meses = projetoAtual.MesesProjeto, Anos = projetoAtual.AnosProjeto,
                    PertenceuOutroProjeto = sn(projetoAtual.PertenceuOutroProjeto), IdProjetoAnterior = projetoAtual.idProjetoAnterior
                },
                Testemunho = tes == null ? new TestemunhoReq() : new TestemunhoReq
                {
                    SofreuComDepressao = sn(tes.SofreuComDepressao), TempoSofreuDepressao = tes.TempoSofreuDepressao, TempoLivreDepressao = tes.TempoLivreDepressao,
                    TentouSuicidio = sn(tes.TentouSuicidio), DescricaoTentativaSuicidio = tes.DescricaoTentativaSuicidio,
                    MesAnoTentativaSuicidio = tes.MesAnoTentativaSuicidio, NumeroTentativasSuicidio = tes.NumeroTentativasSuicidio,
                    SofreuAutomutilacao = sn(tes.SofreuAutomutilacao), TempoSofreuAutomutilacao = tes.TempoSofreuAutomutilacao, TempoLivreAutomutilacao = tes.TempoLivreAutomutilacao,
                    SofreuVicio = sn(tes.SofreuVicio), DescricaoVicio = tes.DescricaoVicio, TempoVicio = tes.TempoVicio, TempoLivreVicios = tes.TempoLivreVicios,
                    TextoTestemunho = tes.TextoTestemunho
                },
                Idiomas = (detalhe?.IdiomasQueOJovemFala ?? new List<SGFJU.ServicesLayer.DTO.IdiomaNivelDTO>())
                    .Select(i => new ItemNivel { Id = i.CodigoIdioma, IdNivel = i.CodigoNivel, NomeExtra = i.DescricaoIdioma }).ToList(),
                Habilidades = (detalhe?.HabilidadesJovemPossui ?? new List<SGFJU.ServicesLayer.DTO.HabilidadeProjetoNivelDTO>())
                    .Where(h => !TONS_DE_VOZ.Contains(h.IdHabilidade))
                    .Select(h => new HabilidadeReq { IdHabilidade = h.IdHabilidade, IdNivel = h.IdNivel, Nome = h.NomeHabilidade }).ToList(),
                TonsDeVoz = (detalhe?.HabilidadesJovemPossui ?? new List<SGFJU.ServicesLayer.DTO.HabilidadeProjetoNivelDTO>())
                    .Where(h => TONS_DE_VOZ.Contains(h.IdHabilidade)).Select(h => h.IdHabilidade).ToList(),
                Cursos = (jovem.CursosRelacionados ?? Enumerable.Empty<CursoRelacionadoProjeto>())
                    .Select(c => new CursoReq { Code = c.Code, NomeCurso = c.NomeCurso, IdProjeto = c.ProjetoRelacionado?.Code ?? 0 }).ToList(),
                Departamentos = (jovem.DepartamentosProjetoJovemFazParte ?? Enumerable.Empty<DepartamentoProjeto>()).Select(d => d.Code).ToList(),
                Reunioes = (jovem.ReunioesFJUAssistidasPeloJovem ?? new List<ReuniaoFJU>()).Select(x => x.Code).ToList(),
                Livros = (jovem.LivrosLidosPeloJovem ?? new List<Livro>()).Select(x => x.Code).ToList()
            };

            var igreja = detalhe?.IgrejaAQualJovemPertence;
            return Ok(new JovemEdicaoResponse
            {
                IdJovem = jovem.Id,
                Dados = dados,
                IdEstado = igreja?.IdEstado ?? 0,
                IdBloco = igreja?.IdBlocoJovem ?? 0,
                IdRegiao = igreja?.IdRegiao ?? 0,
                FotoUrl = TemFoto(jovem) ? $"/api/v2/jovens/{jovem.Id}/foto" : null,
                TemDocumentoAutorizacao = jovem.ArquivoAutorizacaoOk == 'S',
                DataUltimaAtualizacao = jovem.DataUltimaAtualizacao
            });
        }

        /// <summary>Salva a edição. Calcula sozinho o que incluir/excluir (a tela antiga guardava isso na sessão).</summary>
        [HttpPut("{idJovem:int}")]
        public ActionResult<object> Atualizar(int idJovem, [FromBody] NovoJovemRequest r)
        {
            var erros = Validar(r);
            if (erros.Count > 0) return BadRequest(new { mensagem = string.Join(" ", erros), erros });

            var facade = new FacadeJovemImpl();
            var jovem = facade.GetByID(idJovem);
            if (jovem == null) return NotFound(new { mensagem = "Jovem não encontrado." });
            var atual = facade.ObterJovemInformacoesDetalhadas(new Jovem { Id = idJovem });

            Preencher(jovem, r);
            jovem.DataUltimaAtualizacao = DateTime.Now;

            // Idiomas: grava os desejados (atualiza o nível dos que já existem) e exclui os que saíram.
            var idiomas = MontarIdiomas(r, jovem);
            var idsIdiomas = idiomas.Select(i => i.Idioma.Code).Where(c => c > 0).ToHashSet();
            var idiomasExcluir = (atual?.IdiomasQueOJovemFala ?? new List<SGFJU.ServicesLayer.DTO.IdiomaNivelDTO>())
                .Where(i => !idsIdiomas.Contains(i.CodigoIdioma))
                .Select(i => new JovemIdioma { Idioma = new Idioma { Code = i.CodigoIdioma }, Nivel = new Nivel { Code = i.CodigoNivel }, Jovem = jovem })
                .ToList();

            // Habilidades (incluindo tons de voz): mesma lógica.
            var habilidades = MontarHabilidades(r, jovem);
            var idsHab = habilidades.Select(h => h.Habilidade.Code).Where(c => c > 0).ToHashSet();
            var habilidadesExcluir = (atual?.HabilidadesJovemPossui ?? new List<SGFJU.ServicesLayer.DTO.HabilidadeProjetoNivelDTO>())
                .Where(h => !idsHab.Contains(h.IdHabilidade))
                .Select(h => new JovemHabilidadeProjeto { Habilidade = new HabilidadeProjeto { Code = h.IdHabilidade }, Nivel = new Nivel { Code = h.IdNivel }, Jovem = jovem })
                .ToList();

            // Projeto: o repositório decide entre incluir, trocar ou excluir comparando anterior × atual.
            var projetoAnteriorDto = atual?.ProjetosAosQuaisJovemEstaLigado?.FirstOrDefault();
            var container = new JovemProjetoContainer
            {
                ProjetoAnterior = projetoAnteriorDto == null ? null : new JovemProjeto { Projeto = new Projeto { Code = projetoAnteriorDto.idProjeto }, Jovem = jovem },
                ProjetoAtual = MontarProjeto(r, jovem)
            };

            var testemunho = MontarTestemunho(r.Testemunho, jovem, atual?.TestemunhoJovem?.Code ?? 0);

            facade.AtualizarJovem(jovem, idiomas.Count > 0 ? idiomas : null, idiomasExcluir, habilidades.Count > 0 ? habilidades : null, habilidadesExcluir, container, testemunho);

            try
            {
                var usuario = SessionHelper.RetornaUsuarioLogado();
                SessionHelper.ObterLoogerParaController().WriteUserAction(
                    usuario?.Id ?? 0, usuario?.EstadoUsuario?.SiglaEstado, $"O usuário {usuario?.Login} atualizou o jovem de ID {idJovem} (SGFJU 2.0)");
            }
            catch (Exception exc) { LoggerHelper.WriteLogError("Falha ao registrar ação: " + exc.Message); }

            return Ok(new { IdJovem = idJovem, Mensagem = "Alterações salvas." });
        }

        /// <summary>Devolve a foto do jovem a partir da pasta de dados (FotosJovens).</summary>
        [HttpGet("{idJovem:int}/foto")]
        public IActionResult Foto(int idJovem)
        {
            var jovem = new FacadeJovemImpl().GetByID(idJovem);
            if (jovem == null || !TemFoto(jovem)) return NotFound();
            var caminho = Path.Combine(AmbienteLegado.MapPath("~/FotosJovens"), Path.GetFileName(jovem.NomeArquivoFoto));
            if (!System.IO.File.Exists(caminho)) return NotFound();
            var tipo = Path.GetExtension(caminho).ToLowerInvariant() switch { ".png" => "image/png", ".webp" => "image/webp", _ => "image/jpeg" };
            Response.Headers.CacheControl = "private, max-age=300";
            return PhysicalFile(caminho, tipo);
        }

        // O repositório antigo grava um prefixo mesmo sem foto (ex.: "SP_ID_3_2026-11-1223_"); só conta se tiver extensão de imagem.
        private static bool TemFoto(Jovem j) =>
            !string.IsNullOrWhiteSpace(j.NomeArquivoFoto) && new[] { ".jpg", ".jpeg", ".png", ".webp" }.Contains(Path.GetExtension(j.NomeArquivoFoto).ToLowerInvariant());

        /// <summary>Envia foto e/ou documento de autorização depois do cadastro (mesmo padrão de nome do sistema antigo).</summary>
        [HttpPost("{idJovem:int}/arquivos")]
        [RequestSizeLimit(15 * 1024 * 1024)]
        public async Task<ActionResult<object>> EnviarArquivos(int idJovem, IFormFile foto, IFormFile documento)
        {
            if (foto == null && documento == null) return BadRequest(new { mensagem = "Nenhum arquivo enviado." });

            var facade = new FacadeJovemImpl();
            var jovem = facade.GetByID(idJovem);
            if (jovem == null) return NotFound(new { mensagem = "Jovem não encontrado." });

            var sigla = SessionHelper.RetornaUsuarioLogado()?.EstadoUsuario?.SiglaEstado ?? string.Empty;
            var carimbo = DateTime.Now.ToString("yyyy-MM-dd") + DateTime.Now.Hour.ToString(CultureInfo.InvariantCulture);

            if (foto != null)
            {
                if (!EhImagem(foto)) return BadRequest(new { mensagem = "A foto precisa ser JPG, PNG ou WEBP." });
                jovem.NomeArquivoFoto = await Salvar(foto, "~/FotosJovens", $"{sigla}_ID_{idJovem}_{carimbo}_");
            }
            if (documento != null)
            {
                jovem.NomeArquivoAutorizacao = await Salvar(documento, "~/DocumentosAutorizacao", $"DocAutorizacao_{sigla}_ID_{idJovem}_{carimbo}_");
                jovem.ArquivoAutorizacaoOk = 'S';
            }
            facade.Save(jovem);
            return Ok(new { jovem.NomeArquivoFoto, jovem.NomeArquivoAutorizacao });
        }

        // ------------------------------------------------------------------ montagem
        private static List<string> Validar(NovoJovemRequest r)
        {
            var erros = new List<string>();
            if (r == null) { erros.Add("Dados não enviados."); return erros; }
            if (string.IsNullOrWhiteSpace(r.Nome)) erros.Add("Informe o nome.");
            if (r.IdIgreja <= 0) erros.Add("Selecione a igreja.");
            if (r.DataNascimento == null) erros.Add("Informe a data de nascimento.");
            else if (r.DataNascimento > DateTime.Today || r.DataNascimento < new DateTime(1900, 1, 1)) erros.Add("Data de nascimento inválida.");
            if (r.Sexo != "M" && r.Sexo != "F") erros.Add("Informe o sexo.");
            return erros;
        }

        /// <summary>Copia os dados do formulário para o jovem (novo ou carregado do banco), preservando os ids dos registros relacionados.</summary>
        private static void Preencher(Jovem jovem, NovoJovemRequest r)
        {
            var e = r.Espiritual ?? new EspiritualReq();
            var o = r.Obra ?? new ObraReq();
            var s = r.Estudo ?? new EstudoReq();
            var red = r.Redes ?? new RedesReq();
            var (mesChegada, anoChegada) = MesAno(e.MesAnoChegadaIURD);

            jovem.ContatoJovem ??= new Contato();
            jovem.EnderecoJovem ??= new Endereco();
            jovem.RedeSocialJovem ??= new RedeSocial();
            jovem.DadosProfissionaisJovem ??= new DadosProfissionais();
            jovem.DadosEspirituaisJovem ??= new DadosEspirituais();
            jovem.DadosEducacionaisJovem ??= new DadosEducacionais();
            jovem.SituacaoJovemIURDFJU ??= new SituacaoIURDFJU();

            Copiar(jovem, new Jovem
            {
                Nome = r.Nome.Trim(),
                DataNascimento = r.DataNascimento.Value,
                DataPreenchimentoFormulario = r.DataPreenchimentoFormulario ?? DateTime.Today,
                Sexo = r.Sexo[0],
                ClassificacaoJovem = string.IsNullOrEmpty(r.ClassificacaoJovem) ? 'N' : r.ClassificacaoJovem[0],
                EstadoCivilJovem = r.IdEstadoCivil > 0 ? new TipoEstadoCivil { Code = r.IdEstadoCivil.Value } : null,
                NomeConjuge = Txt(r.NomeConjuge),
                ConjugeEhIURD = Sn(r.ConjugeEhIURD),
                DataCasamento = r.DataCasamento,
                PossuiFilhos = Sn(r.PossuiFilhos),
                QuantidadeFilhos = Math.Max(0, r.QuantidadeFilhos),
                PossuiTituloEleitor = Sn(r.PossuiTituloEleitor),
                PertenceGrupoMulheresIURD = Sn(r.PertenceGrupoMulheresIURD),
                NomeGrupoMulheresIURD = Txt(r.NomeGrupoMulheresIURD),
                TextoSugestao = Txt(r.TextoSugestao),
                EhPalestranteHelp = Sn(r.EhPalestranteHelp),
                EhAtendenteWhatsappHelp = Sn(r.EhAtendenteWhatsappHelp),
                EhAltarJovem318 = Sn(r.EhAltarJovem318),
                CodigoAltarJovem318 = Txt(r.CodigoAltarJovem318),
                IgrejaAQualJovemPertence = new Igreja { Id = r.IdIgreja },

                ContatoJovem = new Contato
                {
                    Whatsapp = Txt(r.Contato?.Whatsapp),
                    TelefoneFixo = Txt(r.Contato?.TelefoneFixo),
                    TelefoneEmergencia = Txt(r.Contato?.TelefoneEmergencia),
                    NomeContatoEmergencia = Txt(r.Contato?.NomeContatoEmergencia)
                },
                EnderecoJovem = new Endereco
                {
                    DescricaoEndereco = Txt(r.Endereco?.Endereco),
                    Bairro = Txt(r.Endereco?.Bairro),
                    Cidade = Txt(r.Endereco?.Cidade),
                    TipoDeMoradia = r.Endereco?.IdTipoMoradia > 0 ? new TipoMoradia { Code = r.Endereco.IdTipoMoradia.Value } : null
                },
                RedeSocialJovem = new RedeSocial
                {
                    Email = Txt(red.Email), Instagram = Txt(red.Instagram), Facebook = Txt(red.Facebook), Twitter = Txt(red.Twitter),
                    EhSeguidorOficialFJU = Sn(red.EhSeguidorOficialFJU), EhSeguidorYoutube = Sn(red.EhSeguidorYoutube),
                    EhSeguidorTelegram = Sn(red.EhSeguidorTelegram), EhAssinanteUNIVER = Sn(red.EhAssinanteUNIVER),
                    FrequenciaAssisteUNIVER = Txt(red.FrequenciaAssisteUNIVER), EhLeitorBlogBM = Sn(red.EhLeitorBlogBM),
                    EhLeitorUniversalorg = Sn(red.EhLeitorUniversalorg), PossuiCelularComInternet = Sn(red.PossuiCelularComInternet),
                    PossuiComputador = Sn(red.PossuiComputador)
                },
                DadosProfissionaisJovem = new DadosProfissionais
                {
                    TrabalhaAtualmente = Sn(r.Trabalho?.TrabalhaAtualmente),
                    Profissao = Txt(r.Trabalho?.Profissao),
                    NomeEmpresa = Txt(r.Trabalho?.NomeEmpresa)
                },
                DadosEspirituaisJovem = new DadosEspirituais
                {
                    EhMembroIURD = Sn(e.EhMembroIURD),
                    MesAnoChegadaIURD = Txt(e.MesAnoChegadaIURD),
                    AnoChegadaiurd = anoChegada,
                    MesChegadaiurd = mesChegada, // a tela antiga gravava o ano aqui por engano
                    ComoConheceuIURD = Txt(e.ComoConheceuIURD),
                    JaSeAfastou = Sn(e.JaSeAfastou),
                    MotivoSeAfastou = Txt(e.MotivoSeAfastou),
                    TempoEstaFirme = Txt(e.TempoEstaFirme),
                    TempoAfastamento = Txt(e.TempoAfastamento),
                    MesAnoAfastamento = Txt(e.MesAnoAfastamento),
                    EhBatizadoAguas = Sn(e.EhBatizadoAguas),
                    BatismoAguasIURD = Sn(e.BatismoAguasIURD),
                    MesAnoBatismoAguas = Txt(e.MesAnoBatismoAguas),
                    EhBatizadoEspiritoSanto = Sn(e.EhBatizadoEspiritoSanto),
                    MesAnoBatismoEspiritoSanto = Txt(e.MesAnoBatismoEspiritoSanto),
                    OcasiaoBatismoEspiritoSanto = Txt(e.OcasiaoBatismoEspiritoSanto),
                    DescricaoFamiliaresIURD = Txt(e.DescricaoFamiliaresIURD),
                    DescricaoModoChegouFJU = Txt(e.DescricaoModoChegouFJU),
                    MotivoEntradaFJU = Txt(e.MotivoEntradaFJU),
                    MesAnoEntradaFJU = Txt(e.MesAnoEntradaFJU),
                    FrequenciaLeituraBiblia = e.IdFrequenciaLeituraBiblia > 0 ? new FrequenciaLeitura { Code = e.IdFrequenciaLeituraBiblia.Value } : null,
                    LeuTodaBiblia = Sn(e.LeuTodaBiblia),
                    PossuiBiblia = Sn(e.PossuiBiblia)
                },
                DadosEducacionaisJovem = new DadosEducacionais
                {
                    GrauEscolaridade = Txt(s.GrauEscolaridade),
                    EstudaAtualmente = Sn(s.EstudaAtualmente),
                    NomeInstituicaoEnsino = Txt(s.NomeInstituicaoEnsino),
                    NomeCursoSuperior = Txt(s.NomeCursoSuperior),
                    DesejaCursarNivelSuperior = Sn(s.DesejaCursarNivelSuperior),
                    NomeCursoSuperiorDesejaCursar = Txt(s.NomeCursoSuperiorDesejaCursar),
                    ModalidadeCursadaEnsinoSuperior = s.IdModalidade > 0 ? new ModalidadeEnsinoSuperior { Code = s.IdModalidade.Value } : null,
                    PeriodoAtualNivelFaculdade = Txt(s.PeriodoAtualNivelFaculdade),
                    PossuiNivelSuperior = Sn(s.PossuiNivelSuperior),
                    PrevisaoConclusaoCurso = Txt(s.PrevisaoConclusaoCurso)
                },
                SituacaoJovemIURDFJU = new SituacaoIURDFJU
                {
                    EhObreiro = Sn(o.EhObreiro), AnosObreiro = o.AnosObreiro, MesesObreiro = o.MesesObreiro,
                    EhColaborador = Sn(o.EhColaborador), AnosColaborador = o.AnosColaborador, MesesColaborador = o.MesesColaborador,
                    EstaCursandoCPO = Sn(o.EstaCursandoCPO), MesAnoInicioCPO = $"{o.MesInicioCPO}#{o.AnoInicioCPO}",
                    EhPertencenteFJU = Sn(o.EhPertencenteFJU),
                    EhCoordenadorFJU = Sn(o.EhCoordenadorFJU), MesAnoCoordenandoFJU = $"{o.MesesCoordenandoFJU}#{o.AnosCoordenandoFJU}",
                    MesesCoordenandoFJU = o.MesesCoordenandoFJU, AnosCoordenandoFJU = o.AnosCoordenandoFJU,
                    EhLiderTribo = Sn(o.EhLiderTribo), TriboQueLidera = o.IdTribo > 0 ? new Tribo { Code = o.IdTribo.Value } : null,
                    PeriodoCoordenandoTribo = $"{o.MesesCoordenandoTribo}#{o.AnosCoordenandoTribo}",
                    MesesCoordenandoTribo = o.MesesCoordenandoTribo, AnosCoordenandoTribo = o.AnosCoordenandoTribo,
                    EhLiderProjeto = Sn(o.EhLiderProjeto), ProjetoQueCoordena = o.IdProjetoQueCoordena > 0 ? new Projeto { Code = o.IdProjetoQueCoordena.Value } : null,
                    PeriodoCoordenandoProjeto = $"{o.MesesCoordenandoProjeto}#{o.AnosCoordenandoProjeto}",
                    MesesCoordenandoProjeto = o.MesesCoordenandoProjeto, AnosCoordenandoProjeto = o.AnosCoordenandoProjeto,
                    PossuiCamisaProjeto = Sn(o.PossuiCamisaProjeto), NomeCamisaFJU = Txt(o.NomeCamisaFJU), TamanhoCamisa = Txt(o.TamanhoCamisa),
                    FoiObreiro = Sn(o.FoiObreiro), MotivoSaiuObreiro = Txt(o.MotivoSaiuObreiro),
                    FoiPastor = Sn(o.FoiPastor), MotivoSaidaPastor = Txt(o.MotivoSaidaPastor),
                    DesejaSerObreiro = Sn(o.DesejaSerObreiro), MotivoDesejaSerObreiro = Txt(o.MotivoDesejaSerObreiro),
                    DesejaFazerObraNoAltar = Sn(o.DesejaFazerObraNoAltar), PertenceAltarJovem = Sn(o.PertenceAltarJovem),
                    PertenceIntellimen = Sn(o.PertenceIntellimen), DesafiosConcluidos = Sn(o.DesafiosConcluidos), DesafioAtual = o.DesafioAtual,
                    NomeParceiroIntellimen = Txt(o.NomeParceiroIntellimen), TelefoneParceiroIntellimen = Txt(o.TelefoneParceiroIntellimen)
                }
            });

            var cursos = r.Cursos
                .Where(c => !string.IsNullOrWhiteSpace(c.NomeCurso))
                .Select(c => new CursoRelacionadoProjeto { Code = c.Code, NomeCurso = c.NomeCurso.Trim(), ProjetoRelacionado = c.IdProjeto > 0 ? new Projeto { Code = c.IdProjeto } : null })
                .ToList();
            jovem.SincronizarCursos(cursos);
            jovem.SincronizarDepartamentos(r.Departamentos.Distinct().Where(d => d > 0).ToList());
            jovem.SincronizarReunioes(r.Reunioes.Distinct().Where(x => x > 0).ToList());
            jovem.SincronizarLivros(r.Livros.Distinct().Where(x => x > 0).ToList());
        }

        /// <summary>
        /// Copia os campos simples e os valores dos objetos relacionados de "origem" para "destino",
        /// mantendo os ids (Code) dos registros relacionados que já existem no banco.
        /// </summary>
        private static void Copiar(Jovem destino, Jovem origem)
        {
            destino.Nome = origem.Nome;
            destino.DataNascimento = origem.DataNascimento;
            destino.DataPreenchimentoFormulario = origem.DataPreenchimentoFormulario;
            destino.Sexo = origem.Sexo;
            destino.ClassificacaoJovem = origem.ClassificacaoJovem;
            destino.EstadoCivilJovem = origem.EstadoCivilJovem;
            destino.NomeConjuge = origem.NomeConjuge;
            destino.ConjugeEhIURD = origem.ConjugeEhIURD;
            destino.DataCasamento = origem.DataCasamento;
            destino.PossuiFilhos = origem.PossuiFilhos;
            destino.QuantidadeFilhos = origem.QuantidadeFilhos;
            destino.PossuiTituloEleitor = origem.PossuiTituloEleitor;
            destino.PertenceGrupoMulheresIURD = origem.PertenceGrupoMulheresIURD;
            destino.NomeGrupoMulheresIURD = origem.NomeGrupoMulheresIURD;
            destino.TextoSugestao = origem.TextoSugestao;
            destino.EhPalestranteHelp = origem.EhPalestranteHelp;
            destino.EhAtendenteWhatsappHelp = origem.EhAtendenteWhatsappHelp;
            destino.EhAltarJovem318 = origem.EhAltarJovem318;
            destino.CodigoAltarJovem318 = origem.CodigoAltarJovem318;
            destino.IgrejaAQualJovemPertence = origem.IgrejaAQualJovemPertence;

            CopiarValores(destino.ContatoJovem, origem.ContatoJovem);
            CopiarValores(destino.EnderecoJovem, origem.EnderecoJovem);
            CopiarValores(destino.RedeSocialJovem, origem.RedeSocialJovem);
            CopiarValores(destino.DadosProfissionaisJovem, origem.DadosProfissionaisJovem);
            CopiarValores(destino.DadosEspirituaisJovem, origem.DadosEspirituaisJovem);
            CopiarValores(destino.DadosEducacionaisJovem, origem.DadosEducacionaisJovem);
            CopiarValores(destino.SituacaoJovemIURDFJU, origem.SituacaoJovemIURDFJU);
        }

        /// <summary>Copia todas as propriedades graváveis, exceto o id (Code) e coleções.</summary>
        private static void CopiarValores<T>(T destino, T origem) where T : class
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                if (!prop.CanWrite || !prop.CanRead || prop.Name == "Code") continue;
                if (typeof(System.Collections.IEnumerable).IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(string)) continue;
                prop.SetValue(destino, prop.GetValue(origem));
            }
        }

        private static List<JovemIdioma> MontarIdiomas(NovoJovemRequest r, Jovem jovem) =>
            // Idioma com Id = 0 e NomeExtra preenchido é criado na hora pelo repositório (idioma fora da lista).
            r.Idiomas
                .Where(i => i.Id > 0 || !string.IsNullOrWhiteSpace(i.NomeExtra))
                .GroupBy(i => i.Id > 0 ? i.Id.ToString() : "x:" + i.NomeExtra.Trim().ToLowerInvariant()).Select(g => g.First())
                .Select(i => new JovemIdioma
                {
                    Idioma = new Idioma { Code = i.Id, NomeIdioma = i.Id > 0 ? null : i.NomeExtra.Trim() },
                    Nivel = new Nivel { Code = i.IdNivel },
                    Jovem = jovem
                })
                .ToList();

        private static List<JovemHabilidadeProjeto> MontarHabilidades(NovoJovemRequest r, Jovem jovem) =>
            r.Habilidades
                .Where(h => h.IdHabilidade > 0 || !string.IsNullOrWhiteSpace(h.NomeHabilidadeExtra))
                .GroupBy(h => h.IdHabilidade > 0 ? h.IdHabilidade.ToString() : "x:" + h.NomeHabilidadeExtra.Trim().ToLowerInvariant()).Select(g => g.First())
                .Select(h => new JovemHabilidadeProjeto
                {
                    Habilidade = new HabilidadeProjeto { Code = h.IdHabilidade, NomeHabilidade = h.IdHabilidade == 0 ? h.NomeHabilidadeExtra.Trim() : "" },
                    Nivel = new Nivel { Code = h.IdNivel },
                    Jovem = jovem
                })
                .Concat(r.TonsDeVoz.Distinct().Where(t => TONS_DE_VOZ.Contains(t)).Select(t => new JovemHabilidadeProjeto
                {
                    Habilidade = new HabilidadeProjeto { Code = t, NomeHabilidade = "" },
                    Nivel = new Nivel { Code = NIVEL_TOM_DE_VOZ },
                    Jovem = jovem
                }))
                .ToList();

        private static JovemProjeto MontarProjeto(NovoJovemRequest r, Jovem jovem)
        {
            if (!(r.Projeto?.IdProjeto > 0)) return null;
            return new JovemProjeto
            {
                Projeto = new Projeto { Code = r.Projeto.IdProjeto },
                MesesProjeto = r.Projeto.Meses,
                AnosProjeto = r.Projeto.Anos,
                PertenceuOutroProjeto = Sn(r.Projeto.PertenceuOutroProjeto),
                ProjetoAnterior = r.Projeto.IdProjetoAnterior > 0 ? new Projeto { Code = r.Projeto.IdProjetoAnterior } : null,
                TempoProjeto = $"{r.Projeto.Meses}#{r.Projeto.Anos}",
                Jovem = jovem
            };
        }

        /// <summary>Lê o padrão "mes#ano" gravado pela tela antiga.</summary>
        private static (int? mes, int? ano) MesAnoHash(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor)) return (null, null);
            var partes = valor.Split('#');
            int? ler(int i) => partes.Length > i && int.TryParse(partes[i], out var n) && n > 0 ? n : (int?)null;
            return (ler(0), ler(1));
        }

        private static Testemunho MontarTestemunho(TestemunhoReq t, Jovem jovem, int code)
        {
            t ??= new TestemunhoReq();
            return new Testemunho
            {
                Code = code,
                TempoLivreAutomutilacao = Txt(t.TempoLivreAutomutilacao),
                DescricaoVicio = Txt(t.DescricaoVicio),
                SofreuComDepressao = Sn(t.SofreuComDepressao), TempoSofreuDepressao = Txt(t.TempoSofreuDepressao), TempoLivreDepressao = Txt(t.TempoLivreDepressao),
                TentouSuicidio = Sn(t.TentouSuicidio), DescricaoTentativaSuicidio = Txt(t.DescricaoTentativaSuicidio),
                MesAnoTentativaSuicidio = Txt(t.MesAnoTentativaSuicidio), NumeroTentativasSuicidio = Math.Max(0, t.NumeroTentativasSuicidio),
                SofreuAutomutilacao = Sn(t.SofreuAutomutilacao), TempoSofreuAutomutilacao = Txt(t.TempoSofreuAutomutilacao),
                SofreuVicio = Sn(t.SofreuVicio), TempoVicio = Txt(t.TempoVicio), TempoLivreVicios = Txt(t.TempoLivreVicios),
                TextoTestemunho = Txt(t.TextoTestemunho),
                JovemTestemunho = jovem
            };
        }

        // ------------------------------------------------------------------ utilitários
        /// <summary>Normaliza Sim/Não para 'S'/'N' (a tela antiga às vezes gravava 's' minúsculo).</summary>
        private static char Sn(string valor) =>
            !string.IsNullOrEmpty(valor) && char.ToUpperInvariant(valor[0]) == 'S' ? 'S' : 'N';

        private static string Txt(string valor) => string.IsNullOrWhiteSpace(valor) ? null : valor.Trim();

        private static (int mes, int ano) MesAno(string mesAno)
        {
            if (string.IsNullOrWhiteSpace(mesAno)) return (0, 0);
            var m = Regex.Match(mesAno, @"^\s*(\d{1,2})\s*/\s*(\d{4})\s*$");
            return m.Success ? (int.Parse(m.Groups[1].Value), int.Parse(m.Groups[2].Value)) : (0, 0);
        }

        private static bool EhImagem(IFormFile f) =>
            new[] { ".jpg", ".jpeg", ".png", ".webp" }.Contains(Path.GetExtension(f.FileName).ToLowerInvariant());

        private static async Task<string> Salvar(IFormFile arquivo, string pastaVirtual, string prefixo)
        {
            var pasta = AmbienteLegado.MapPath(pastaVirtual);
            Directory.CreateDirectory(pasta);
            // Só o nome do arquivo, sem caminho, e sem caracteres perigosos.
            var nomeOriginal = Regex.Replace(Path.GetFileName(arquivo.FileName), @"[^\w.\-]", "_");
            var nomeFinal = prefixo + nomeOriginal;
            await using var destino = System.IO.File.Create(Path.Combine(pasta, nomeFinal));
            await arquivo.CopyToAsync(destino);
            return nomeFinal;
        }
    }
}
