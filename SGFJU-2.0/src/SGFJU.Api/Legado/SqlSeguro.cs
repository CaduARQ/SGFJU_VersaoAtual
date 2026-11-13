using System;
using System.Globalization;
using System.Linq;
using SGFJU.ServicesLayer.DTO;

namespace SGFJU.Api.Legado
{
    /// <summary>
    /// Os repositórios antigos montam SQL juntando texto (ex.: "NOME LIKE '%" + nome + "%'").
    /// Enquanto as consultas não são reescritas com parâmetros, todo filtro de texto que vai para
    /// essas consultas passa por aqui: datas e telefones são validados, e textos têm aspas e barras escapadas.
    /// </summary>
    public static class SqlSeguro
    {
        /// <summary>Escapa um texto para uso dentro de '...' no MySQL.</summary>
        public static string Texto(string valor, int max = 120)
        {
            if (string.IsNullOrWhiteSpace(valor)) return null;
            var v = valor.Trim();
            if (v.Length > max) v = v.Substring(0, max);
            return v.Replace("\0", "").Replace("\\", "\\\\").Replace("'", "''");
        }

        /// <summary>Aceita só datas aaaa-mm-dd válidas; qualquer outra coisa vira vazio (filtro ignorado).</summary>
        public static string Data(string valor) =>
            !string.IsNullOrWhiteSpace(valor) && DateTime.TryParseExact(valor.Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var d)
                ? d.ToString("yyyy-MM-dd") : "";

        public static string Digitos(string valor)
        {
            var d = new string((valor ?? "").Where(char.IsDigit).ToArray());
            return d.Length == 0 ? null : d.Length > 15 ? d.Substring(0, 15) : d;
        }

        private static char Sn(char c) => char.ToUpperInvariant(c) == 'S' ? 'S' : char.ToUpperInvariant(c) == 'N' ? 'N' : '\0';

        private static RangeParametroDataDTO Faixa(RangeParametroDataDTO f)
        {
            if (f == null) return null;
            var ini = Data(f.DataInicial); var fim = Data(f.DataFinal);
            return ini != "" && fim != "" ? new RangeParametroDataDTO { DataInicial = ini, DataFinal = fim } : null;
        }

        /// <summary>Normaliza todos os campos da Consulta Geral antes de irem para o repositório.</summary>
        public static void Sanitizar(ConsultaGeralDTO p)
        {
            p.Nome = Texto(p.Nome);
            p.Profissao = Texto(p.Profissao);
            p.Escolaridade = Texto(p.Escolaridade);
            p.NomeCursoSuperior = Texto(p.NomeCursoSuperior);
            p.Email = Texto(p.Email);
            p.CodigoAutorizacaoSGFJU = Texto(p.CodigoAutorizacaoSGFJU, 40);
            p.CodigoAltarJovem318 = Texto(p.CodigoAltarJovem318, 40);
            p.CodigosHabilidades = null;
            p.Whatsapp = Digitos(p.Whatsapp);
            p.DataNascimento = Data(p.DataNascimento);
            p.DataCadastro = Data(p.DataCadastro);
            p.DataUltimaAtualizacao = Data(p.DataUltimaAtualizacao);
            p.RangeDataNascimento = Faixa(p.RangeDataNascimento);
            p.RangeDataCadastro = Faixa(p.RangeDataCadastro);
            p.RangeDataUltimaAtualizacao = Faixa(p.RangeDataUltimaAtualizacao);

            p.Idade = Math.Clamp(p.Idade, 0, 120);
            p.IdadeInicial = Math.Clamp(p.IdadeInicial, 0, 120);
            p.IdadeFinal = Math.Clamp(p.IdadeFinal, 0, 120);
            if (p.IdadeInicial > 0 && p.IdadeFinal == 0) p.IdadeFinal = 120;
            if (p.IdadeFinal > 0 && p.IdadeInicial == 0) p.IdadeInicial = 1;

            p.Sexo = p.Sexo == 'M' || p.Sexo == 'F' ? p.Sexo : '\0';
            p.ClassificacaoJovem = "AINFLCDO".Contains(p.ClassificacaoJovem) && p.ClassificacaoJovem != '\0' ? p.ClassificacaoJovem : '\0';
            p.EhParaListarFichasExpiradas = Sn(p.EhParaListarFichasExpiradas);

            // Todos os Sim/Não do formulário
            p.ConjugeEhIURD = Sn(p.ConjugeEhIURD); p.TrabalhaAtualmente = Sn(p.TrabalhaAtualmente); p.EstudaAtualmente = Sn(p.EstudaAtualmente);
            p.PossuiTituloEleitor = Sn(p.PossuiTituloEleitor); p.EhMembroIURD = Sn(p.EhMembroIURD); p.JaSeAfastou = Sn(p.JaSeAfastou);
            p.TemFamiliaresIURD = Sn(p.TemFamiliaresIURD); p.FoiObreiro = Sn(p.FoiObreiro); p.FoiPastor = Sn(p.FoiPastor);
            p.DesejaSerObreiro = Sn(p.DesejaSerObreiro); p.PertenceIntellimen = Sn(p.PertenceIntellimen); p.DesafiosConcluidos = Sn(p.DesafiosConcluidos);
            p.PertenceGrupoMulheresIURD = Sn(p.PertenceGrupoMulheresIURD); p.EhSeguidorOficialFJU = Sn(p.EhSeguidorOficialFJU);
            p.EhSeguidorYoutube = Sn(p.EhSeguidorYoutube); p.EhSeguidorTelegram = Sn(p.EhSeguidorTelegram); p.EhAssinanteUNIVER = Sn(p.EhAssinanteUNIVER);
            p.EhLeitorBlogBM = Sn(p.EhLeitorBlogBM); p.EhLeitorUniversalorg = Sn(p.EhLeitorUniversalorg); p.PossuiBiblia = Sn(p.PossuiBiblia);
            p.PossuiBibliaNoCelular = Sn(p.PossuiBibliaNoCelular); p.LeuTodaBiblia = Sn(p.LeuTodaBiblia);
            p.PossuiCelularComInternet = Sn(p.PossuiCelularComInternet); p.PossuiComputador = Sn(p.PossuiComputador);
            p.PossuiNivelSuperior = Sn(p.PossuiNivelSuperior); p.DesejaCursarNivelSuperior = Sn(p.DesejaCursarNivelSuperior);
            p.SofreuComDepressao = Sn(p.SofreuComDepressao); p.SofreuAutomutilacao = Sn(p.SofreuAutomutilacao);
            p.SofreuVicio = Sn(p.SofreuVicio); p.TentouSuicidio = Sn(p.TentouSuicidio);
            p.EhAltarJovem318 = Sn(p.EhAltarJovem318); p.EhObreiro = Sn(p.EhObreiro); p.EhColaborador = Sn(p.EhColaborador);
            p.EhCPO = Sn(p.EhCPO); p.EhMembroFJU = Sn(p.EhMembroFJU); p.EhCoordenadorFJU = Sn(p.EhCoordenadorFJU);
            p.EhLiderTribo = Sn(p.EhLiderTribo); p.EhLiderProjeto = Sn(p.EhLiderProjeto); p.EhBatizadoAguas = Sn(p.EhBatizadoAguas);
            p.EhBatizadoEspiritoSanto = Sn(p.EhBatizadoEspiritoSanto); p.EhAltarJovem = Sn(p.EhAltarJovem); p.DesejaFazerObraAltar = Sn(p.DesejaFazerObraAltar);
        }
    }
}
