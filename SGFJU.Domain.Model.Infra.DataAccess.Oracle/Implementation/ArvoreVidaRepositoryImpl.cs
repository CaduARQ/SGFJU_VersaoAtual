using MySql.Data.MySqlClient;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.DataAccess.MySql.Common;
using SGFJU.Domain.Model.Infra.Security;
using SGFJU.Domain.Model.Infra.Util;
using SGFJU.Domain.Model.Repositories;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Implementation
{
    public class ArvoreVidaRepositoryImpl : RepositoryImpl<Jovem>, ArvoreVidaRepository
    {
        private const string QUERY_BASE = " SELECT JV.NOME,                                               " +
                                          "        JV.ID_JOVEM,                                           " +
                                          "        JV.DATANASCIMENTO,                                     " +
                                          "        JV.NOMEARQUIVOFOTO,                                     " +
                                          "        ED.ID_ESTADO,                                          " +
                                          "        ED.NOMEESTADO,                                         " +
                                          "        BL.ID_BLOCO,                                           " +
                                          "        BL.NOMEBLOCO,                                          " +
                                          "        REG.ID_REGIAO,                                         " +
                                          "        REG.NOMEREGIAO,                                        " +
                                          "        IGJ.ID_IGREJA,                                         " +
                                          "        IGJ.NOMEIGREJA,                                        " +
                                          "        JVOBR.NOME 'NOMEOBREIRO',                              " +
                                          "        JVOBR.ID_JOVEM 'ID_OBREIRO',                           " +
                                          "        CTT.WHATSAPP,                                          " +
                                          "        TCIV.DESCRICAOTIPOESTADOCIVIL,                         " +
                                          "        ENDE.DESCRICAOENDERECO,                                " +
                                          "        DESP.MESANOENTRADAFJU,                                 " +
                                          "        DESP.DESCRICAOMODOCHEGOUFJU,                           " +
                                          "        PROJ.NOMEPROJETO,                                      " +
                                          "        DESP.EHBATIZADOAGUAS,                                  " +
                                          "        DESP.MESANOBATISMOAGUAS,                               " +
                                          "        DESP.BATISMOAGUASIURD,                                 " +
                                          "        DESP.EHBATIZADOESPIRITOSANTO,                          " +
                                          "        DESP.MESANOBATISMOESPIRITOSANTO                        " +
                                          "   FROM      SGFJU_DEV.SGFJU_TBL_JOVEM JV                      " +
                                          "  INNER JOIN SGFJU_DEV.SGFJU_TBL_ARVOREVIDA_JOVEMOBREIRO JOBR  " +
                                          "          ON JV.ID_JOVEM = JOBR.ID_JOVEM                       " +
                                          "  INNER JOIN SGFJU_DEV.SGFJU_TBL_JOVEM JVOBR                   " +
                                          "          ON JVOBR.ID_JOVEM = JOBR.ID_OBREIRO                  " +
                                          "  INNER JOIN sgfju_dev.SGFJU_TBL_IGREJA IGJ                    " +
                                          "          ON JV.ID_IGREJA = IGJ.ID_IGREJA                      " +
                                          "  INNER JOIN sgfju_dev.SGFJU_TBL_REGIAO REG                    " +
                                          "          ON IGJ.ID_REGIAO = REG.ID_REGIAO                     " +
                                          "  INNER JOIN sgfju_dev.SGFJU_TBL_BLOCO  BL                     " +
                                          "          ON REG.ID_BLOCO = BL.ID_BLOCO                        " +
                                          "  INNER JOIN sgfju_dev.SGFJU_TBL_ESTADO ED                     " +
                                          "          ON BL.ID_ESTADO = ED.ID_ESTADO                       " +
                                          "  INNER JOIN SGFJU_DEV.SGFJU_TBL_CONTATO CTT                   " +
                                          "          ON JV.ID_CONTATO = CTT.ID_CONTATO                    " +
                                          "  INNER JOIN SGFJU_DEV.SGFJU_TBL_DADOSESPIRITUAIS DESP         " +
                                          "          ON JV.ID_DADOSESPIRITUAIS = DESP.ID_DADOSESPIRITUAIS " +
                                          "  INNER JOIN SGFJU_DEV.SGFJU_TBL_TIPOESTADOCIVIL TCIV          " +
                                          "          ON JV.ID_TIPOESTADOCIVIL = TCIV.ID_TIPOESTADOCIVIL   " +
                                          "  INNER JOIN SGFJU_DEV.SGFJU_TBL_ENDERECO ENDE                 " +
                                          "          ON JV.ID_ENDERECO = ENDE.ID_ENDERECO                 " +
                                          "  LEFT OUTER JOIN SGFJU_DEV.SGFJU_TBL_JOVEM_PROJETO JPROJ      " +
                                          "		     ON JPROJ.ID_JOVEM = JV.ID_JOVEM                      " +
                                          "  LEFT OUTER JOIN SGFJU_DEV.SGFJU_TBL_PROJETO PROJ             " +
                                          "		     ON JPROJ.ID_PROJETO = PROJ.ID_PROJETO                " ;
        public void AssociaJovensAObreiro(IList<JovemAcompanhamentoDTO> JovensAcompanhados, ObreiroDTO ObreiroQueAcompanha) {
            try {
                using (var session = __sessionFactory.OpenSession()) {
                    using (var transaction = session.BeginTransaction()) {
                        foreach (var jovemEmAcompanhamento in JovensAcompanhados) {
                            session.Save(new JovemObreiro { 
                                Jovem = new Jovem { Id = jovemEmAcompanhamento.IdJovem },
                                Obreiro = new Jovem { Id = ObreiroQueAcompanha.IdObreiro },
                                DataInicioAcompanhamento = DateTime.Parse(jovemEmAcompanhamento.DataInicioAcompanhamento),
                                DataAssociacao = DateTime.Now
                            });
                        }
                        transaction.Commit();
                    }
                }
            }
            catch (Exception dataException) {                
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }

        public IList<TodosJovensDTO> ListaJovensAcompanhadosPorObreiro(ObreiroDTO obreiro) {
            try {
                var retorno = new List<TodosJovensDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                var SQLQuery = new StringBuilder();
                var SQLWhere = new StringBuilder();
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var SQLOrderBy = " ORDER BY JV.NOME ASC ";
                SQLWhere.Append(" WHERE 1 = 1 ");

                SQLQuery.Append(QUERY_BASE);

                SQLWhere.Append(" AND JOBR.ID_OBREIRO = " + obreiro.IdObreiro);

                using (conexao = _DAO.GetConnection()){
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString() + SQLWhere.ToString() + SQLOrderBy, ref conexao)) {
                        var TELEFONE_FORMATADO = "";
                        while (resultadoReader.Read()) {
                            TELEFONE_FORMATADO = FormataTelefone(resultadoReader["WHATSAPP"].ToString());
                            retorno.Add(new TodosJovensDTO {
                                IdJovem = int.Parse(resultadoReader["ID_JOVEM"].ToString()),
                                NomeJovem = resultadoReader["Nome"].ToString(),
                                DataNascimento = DateTime.Parse(resultadoReader["DATANASCIMENTO"].ToString()).ToString("dd/MM/yyyy"),
                                NomeArquivoFoto = resultadoReader["NOMEARQUIVOFOTO"].ToString(),
                                NomeArquivoFotoFormatado = (!resultadoReader.IsDBNull(resultadoReader.GetOrdinal("NOMEARQUIVOFOTO")))?
                                                              ConfigurationManager.AppSettings["HOST_PROD"] + resultadoReader["NOMEARQUIVOFOTO"].ToString() :
                                                              ConfigurationManager.AppSettings["HOST_PROD"] + "UsuarioNaoSelecionado.png",
                                NomeEstado = resultadoReader["NOMEESTADO"].ToString(),
                                NomeBlocoJovem = resultadoReader["NOMEBLOCO"].ToString(),
                                NomeRegiaoJovem = resultadoReader["NOMEREGIAO"].ToString(),
                                NomeIgrejaJovem = resultadoReader["NOMEIGREJA"].ToString(),
                                Whatsapp = TELEFONE_FORMATADO,
                                EstadoCivil = resultadoReader["DESCRICAOTIPOESTADOCIVIL"].ToString(),
                                Endereco = resultadoReader["DESCRICAOENDERECO"].ToString(),
                                DataIngressouFJU = Formatter.formataMesAno( resultadoReader["MESANOENTRADAFJU"].ToString() ),
                                ProjetoJovemPertence = resultadoReader["NOMEPROJETO"].ToString(),
                                ComoConheceuFJU = resultadoReader["DESCRICAOMODOCHEGOUFJU"].ToString(),
                                EhBatizadoAguas = (resultadoReader["EHBATIZADOAGUAS"].ToString() == "S") ? "S" : "N",
                                DataBatismoAguas = resultadoReader["MESANOBATISMOAGUAS"].ToString(),
                                FoiNaIurd = (resultadoReader["BATISMOAGUASIURD"].ToString() == "S")?"S":"N",
                                EhBatizadoEspiritoSanto = (resultadoReader["EHBATIZADOESPIRITOSANTO"].ToString() == "S")?"S":"N",
                                DataBatismoEspiritoSanto = resultadoReader["MESANOBATISMOESPIRITOSANTO"].ToString()
                            });
                        }
                    }
                }

                return retorno;
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }

        public void RegistraHistoricoJovem(JovemHistorico historicoDoJovem) {
            try {
                var _DAO = new DAO();
                var sqlRegistraHistorico = "";
                MySqlConnection conexao = null;

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();
                    sqlRegistraHistorico = "INSERT INTO `SGFJU_DEV`.`SGFJU_TBL_ARVOREVIDA_HISTORICOACOMPANHAMENTO` (`ID_JOVEM`, `ID_OBREIRO`, `ID_STATUSACOMPANHAMENTO`, `TEXTOOBSERVACAO`, `DATAHISTORICOACOMPANHAMENTO`)"+
                                          $" VALUES( {historicoDoJovem.Jovem.Id}, {historicoDoJovem.Obreiro.Id}, {historicoDoJovem.StatusJovem.Code}, '{historicoDoJovem.TextoObservacao}', '{historicoDoJovem.DataHistoricoAcompanhamento.ToString("yyyy-MM-dd")}' )";
                    _DAO.ExecuteNonQuery(sqlRegistraHistorico); 
                }
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }

        public ObreiroDTO RetornaObreiroQueAcompanhaJovem(Jovem jovemParametro) {
            try {
                ObreiroDTO retorno = null;
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var SQLQuery = new StringBuilder();
                var SQLWhere = new StringBuilder();
                SQLWhere.Append(" WHERE 1 = 1 ");

                SQLQuery.Append(QUERY_BASE);//NÃO UTILIZAR QUERY BASE

                SQLWhere.Append(" AND JV.ID_JOVEM = " + jovemParametro.Id);

                using (conexao = _DAO.GetConnection()){
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString() + SQLWhere.ToString(), ref conexao)) {                        
                        while (resultadoReader.Read()) {
                            retorno = new ObreiroDTO { 
                                IdObreiro = int.Parse(resultadoReader["ID_OBREIRO"].ToString()),
                                NomeObreiro = resultadoReader["NOMEOBREIRO"].ToString()
                            };
                        }
                    }
                }

                return retorno;
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }

        public IList<ObreiroDTO> PesquisaObreiroPorParametro(ParametroPesquisaObreiroDTO parametroPesquisaObreiro) { 
            try {
                var retorno = new List<ObreiroDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                var SQLQuery = new StringBuilder();
                var SQLWhere = new StringBuilder();
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var SQLOrderBy = " ORDER BY NOMEBLOCO ASC";
                SQLWhere.Append(" WHERE 1 = 1 ");

                SQLQuery.Append("SELECT * FROM SGFJU_DEV.SGFJU_VW_OBREIROS ");

                if (parametroPesquisaObreiro.IdObreiro != 0) {
                    SQLWhere.Append(" AND ID_OBREIRO = " + parametroPesquisaObreiro.IdObreiro);
                }

                if (parametroPesquisaObreiro.IdEstado != 0) {
                    SQLWhere.Append(" AND ID_ESTADO = " + parametroPesquisaObreiro.IdEstado);
                }

                if (parametroPesquisaObreiro.IdBloco != 0) {
                    SQLWhere.Append(" AND ID_BLOCO = " + parametroPesquisaObreiro.IdBloco);
                }

                if (parametroPesquisaObreiro.IdRegiao != 0) {
                    SQLWhere.Append(" AND ID_REGIAO = " + parametroPesquisaObreiro.IdRegiao);
                }

                if (parametroPesquisaObreiro.IdIgreja != 0) {
                    SQLWhere.Append(" AND ID_IGREJA = " + parametroPesquisaObreiro.IdIgreja);
                }

                if (!string.IsNullOrEmpty(parametroPesquisaObreiro.NomeObreiro)){
                    SQLWhere.Append(" AND NOMEOBREIRO LIKE'%" + parametroPesquisaObreiro.NomeObreiro + "%' ");
                }

                using (conexao = _DAO.GetConnection()){
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString() + SQLWhere.ToString() + SQLOrderBy, ref conexao)) {
                        while (resultadoReader.Read()) {
                            retorno.Add(new ObreiroDTO {
                                IdObreiro = int.Parse(resultadoReader["ID_OBREIRO"].ToString()),
                                IdObreiroX = EncryptionHelper.Encrypt(resultadoReader["ID_OBREIRO"].ToString()),
                                NomeObreiro = tinfo.ToTitleCase(resultadoReader["NomeOBREIRO"].ToString()),
                                AnosObreiro = (resultadoReader["ANOSOBREIRO"].ToString() != "0" || resultadoReader["ANOSOBREIRO"].ToString() != "") ?
                                                 int.Parse(resultadoReader["ANOSOBREIRO"].ToString()) : 0,
                                MesesObreiro = (resultadoReader["MESESOBREIRO"].ToString() != "0" || resultadoReader["MESESOBREIRO"].ToString() != "") ?
                                                 int.Parse(resultadoReader["MESESOBREIRO"].ToString()) : 0,
                                MesAnoFoiLevantadoObreiro = resultadoReader["MESANOFOILEVANTADOOBREIRO"].ToString(),
                                IdEstado = int.Parse(resultadoReader["ID_ESTADO"].ToString()),
                                NomeEstado = tinfo.ToTitleCase(resultadoReader["NOMEESTADO"].ToString()),
                                IdBloco = int.Parse(resultadoReader["ID_BLOCO"].ToString()),
                                NomeBloco = tinfo.ToTitleCase(resultadoReader["NOMEBLOCO"].ToString()),
                                IdRegiao = int.Parse(resultadoReader["ID_REGIAO"].ToString()),
                                NomeRegiao = tinfo.ToTitleCase(resultadoReader["NOMEREGIAO"].ToString()),
                                IdIgreja = int.Parse(resultadoReader["ID_IGREJA"].ToString()),
                                NomeIgreja = tinfo.ToTitleCase(resultadoReader["NOMEIGREJA"].ToString()),
                                NomeArquivoFoto = resultadoReader["NOMEARQUIVOFOTO"].ToString()
                            });
                        }
                    }
                }

                return retorno;
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }

        public IList<TodosJovensDTO> ListaJovensIgrejaObreiroSemAcompanhamento(ObreiroDTO obreiroParametro) {
            try
            {
                var retorno = new List<TodosJovensDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var SQLQuery = new StringBuilder();
                var SQLOrderBy = " ORDER BY JV.NOME ASC";
                SQLQuery.Append("  SELECT JV.ID_JOVEM,                          ");
                SQLQuery.Append("         JV.NOME,                              ");
                SQLQuery.Append("         JV.NOMEARQUIVOFOTO,                   ");
                SQLQuery.Append("         ED.NOMEESTADO,                        ");
                SQLQuery.Append("         BL.NOMEBLOCO,                         ");
                SQLQuery.Append("         REG.NOMEREGIAO,                       ");
                SQLQuery.Append("         IGJ.NOMEIGREJA,                       ");
                SQLQuery.Append("         CT.WHATSAPP                           ");
                SQLQuery.Append("	FROM      sgfju_dev.SGFJU_TBL_JOVEM JV      ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_CONTATO CT   ");
                SQLQuery.Append("			ON JV.ID_CONTATO = CT.ID_CONTATO    ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_IGREJA IGJ   ");
                SQLQuery.Append("			ON JV.ID_IGREJA = IGJ.ID_IGREJA     ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_REGIAO REG   ");
                SQLQuery.Append("			ON IGJ.ID_REGIAO = REG.ID_REGIAO    ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_BLOCO  BL    ");
                SQLQuery.Append("		   ON REG.ID_BLOCO = BL.ID_BLOCO        ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_ESTADO ED    ");
                SQLQuery.Append("		   ON BL.ID_ESTADO = ED.ID_ESTADO       ");
                SQLQuery.Append("   INNER JOIN SGFJU_DEV.SGFJU_TBL_SITUACAO_IURD_FJU SIT ");
                SQLQuery.Append("           ON JV.ID_SITUACAO_IURD_FJU = SIT.ID_SITUACAO_IURD_FJU ");
                SQLQuery.Append("   INNER JOIN SGFJU_DEV.SGFJU_TBL_DADOSESPIRITUAIS DESP ");
                SQLQuery.Append("           ON JV.ID_DADOSESPIRITUAIS = DESP.ID_DADOSESPIRITUAIS ");


                var SQLWhere = new StringBuilder();
                SQLWhere.Append(" WHERE 1 = 1 AND JV.ID_JOVEM NOT IN ( SELECT ID_JOVEM FROM SGFJU_DEV.SGFJU_TBL_ARVOREVIDA_JOVEMOBREIRO ) ");
                SQLWhere.Append(" AND ( ( SIT.EHOBREIRO IS NULL OR UPPER(SIT.EHOBREIRO) = 'N' ) or ( SIT.EHCOLABORADOR IS NULL OR UPPER(SIT.EHCOLABORADOR) = 'N' ) ) ");
                SQLWhere.Append(" AND ( DESP.EHBATIZADOESPIRITOSANTO IS NULL OR UPPER(DESP.EHBATIZADOESPIRITOSANTO) = 'N' ) ");
                SQLWhere.Append(" AND ( JV.ClassificacaoJovem is null or UPPER(JV.ClassificacaoJovem) <> 'I' ) ");

                if (obreiroParametro.IdIgreja != 0)
                {
                    SQLWhere.Append(" AND IGJ.ID_IGREJA = " + obreiroParametro.IdIgreja);
                }

                using (conexao = _DAO.GetConnection()){
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString() + SQLWhere.ToString() + SQLOrderBy, ref conexao)) {                        
                        while (resultadoReader.Read()) {
                            var TELEFONE_FORMATADO = FormataTelefone(resultadoReader["WHATSAPP"].ToString());
                            retorno.Add(new TodosJovensDTO {
                                IdJovem = int.Parse(resultadoReader["ID_JOVEM"].ToString()),
                                NomeJovem = tinfo.ToTitleCase(resultadoReader["Nome"].ToString()),
                                NomeEstado = tinfo.ToTitleCase(resultadoReader["NOMEESTADO"].ToString()),
                                NomeBlocoJovem = tinfo.ToTitleCase(resultadoReader["NOMEBLOCO"].ToString()),
                                NomeRegiaoJovem = tinfo.ToTitleCase(resultadoReader["NOMEREGIAO"].ToString()),
                                NomeIgrejaJovem = tinfo.ToTitleCase(resultadoReader["NOMEIGREJA"].ToString()),
                                Whatsapp = TELEFONE_FORMATADO,   //string.Format("{0:(##) #####-####}", resultadoReader["WHATSAPP"].ToString().Replace('-', ' ').Trim()),
                                WhatsappSemFormatacao = resultadoReader["WHATSAPP"].ToString(),
                                NomeArquivoFoto = resultadoReader["NOMEARQUIVOFOTO"].ToString(),
                            });
                        }
                    }
                }

                return retorno;
            }
            catch (Exception dataException)
            {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
        public string FormataTelefone(string telefone)
        {
            var telefoneformatado = string.Empty;

            if (string.IsNullOrWhiteSpace(telefone))
            {
                return "(00) 0000-0000";
            }
            else
            {

                if (telefone.Length == 10)
                {
                    telefone = telefone.Substring(0, 2) + "9" + telefone.Substring(2, telefone.Length - 2);
                }

                var match = Regex.Replace(telefone, @"(\d{2})(\d{5})(\d{4})", "($1) $2-$3");
                telefoneformatado = match;
                //telefoneformatado = $"({match.Groups[1]}) {match.Groups[2]}-{match.Groups[3]}";
                return telefoneformatado;
            }
        }

        public AcompanhamentoJovemDTO RetornaHistoricoAcompanhamentoJovem(JovemDTO jovemParametro) {
            try {
                AcompanhamentoJovemDTO retorno = new AcompanhamentoJovemDTO();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var SQLQuery = new StringBuilder();
                var SQLOrderBy = " ORDER BY HACOMP.DATAHISTORICOACOMPANHAMENTO DESC";
                var SQLWhere = " WHERE JV.ID_JOVEM = " + jovemParametro.Id;
                var i = 0;


                SQLQuery.Append(" SELECT JV.NOME,                                               " );
                SQLQuery.Append("        JV.ID_JOVEM,                                           " );
                SQLQuery.Append("        JV.DATANASCIMENTO,                                     " );
                SQLQuery.Append("        JV.NOMEARQUIVOFOTO,                                     " );
                SQLQuery.Append("        ED.ID_ESTADO,                                          " );
                SQLQuery.Append("        ED.NOMEESTADO,                                         " );
                SQLQuery.Append("        BL.ID_BLOCO,                                           " );
                SQLQuery.Append("        BL.NOMEBLOCO,                                          " );
                SQLQuery.Append("        REG.ID_REGIAO,                                         " );
                SQLQuery.Append("        REG.NOMEREGIAO,                                        " );
                SQLQuery.Append("        IGJ.ID_IGREJA,                                         " );
                SQLQuery.Append("        IGJ.NOMEIGREJA,                                        " );
                SQLQuery.Append("        JVOBR.NOME 'NOMEOBREIRO',                              " );
                SQLQuery.Append("        JVOBR.ID_JOVEM 'ID_OBREIRO',                           " );
                SQLQuery.Append("        CTT.WHATSAPP,                                          " );
                SQLQuery.Append("        JOBR.DATAINICIOACOMPANHAMENTO,                         ");
                SQLQuery.Append("        JOBR.DATATERMINOACOMPANHAMENTO,                         ");
                SQLQuery.Append("        HACOMP.ID_HISTORICO,                                   ");
                SQLQuery.Append("        HACOMP.ID_STATUSACOMPANHAMENTO,                        ");
                SQLQuery.Append("        HACOMP.TEXTOOBSERVACAO,                                ");
                SQLQuery.Append("        HACOMP.DATAHISTORICOACOMPANHAMENTO,                     ");
                SQLQuery.Append("        SACOMP.DESCRICAOSTATUSACOMPANHAMENTO                     ");
                SQLQuery.Append("   FROM      SGFJU_DEV.SGFJU_TBL_JOVEM JV                      " );
                SQLQuery.Append("  INNER JOIN SGFJU_DEV.SGFJU_TBL_ARVOREVIDA_JOVEMOBREIRO JOBR  " );
                SQLQuery.Append("          ON JV.ID_JOVEM = JOBR.ID_JOVEM                       " );
                SQLQuery.Append("   LEFT JOIN SGFJU_DEV.SGFJU_TBL_ARVOREVIDA_HISTORICOACOMPANHAMENTO HACOMP  ");
                SQLQuery.Append("          ON JV.ID_JOVEM = HACOMP.ID_JOVEM                     ");
                SQLQuery.Append("   LEFT JOIN SGFJU_DEV.SGFJU_TBL_STATUSACOMPANHAMENTO SACOMP  ");
                SQLQuery.Append("          ON SACOMP.ID_STATUSACOMPANHAMENTO = HACOMP.ID_STATUSACOMPANHAMENTO ");
                SQLQuery.Append("  INNER JOIN SGFJU_DEV.SGFJU_TBL_JOVEM JVOBR                   " );
                SQLQuery.Append("          ON JVOBR.ID_JOVEM = JOBR.ID_OBREIRO                  " );
                SQLQuery.Append("  INNER JOIN sgfju_dev.SGFJU_TBL_IGREJA IGJ                    " );
                SQLQuery.Append("          ON JV.ID_IGREJA = IGJ.ID_IGREJA                      " );
                SQLQuery.Append("  INNER JOIN sgfju_dev.SGFJU_TBL_REGIAO REG                    " );
                SQLQuery.Append("          ON IGJ.ID_REGIAO = REG.ID_REGIAO                     " );
                SQLQuery.Append("  INNER JOIN sgfju_dev.SGFJU_TBL_BLOCO  BL                     " );
                SQLQuery.Append("          ON REG.ID_BLOCO = BL.ID_BLOCO                        " );
                SQLQuery.Append("  INNER JOIN sgfju_dev.SGFJU_TBL_ESTADO ED                     " );
                SQLQuery.Append("          ON BL.ID_ESTADO = ED.ID_ESTADO                       " );
                SQLQuery.Append("  INNER JOIN SGFJU_DEV.SGFJU_TBL_CONTATO CTT                   " );
                SQLQuery.Append("          ON JV.ID_CONTATO = CTT.ID_CONTATO                    " );

                using (conexao = _DAO.GetConnection()){
                    conexao.Open();

                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString() + SQLWhere.ToString() + SQLOrderBy, ref conexao)){
                        while (resultadoReader.Read()) {
                            if (i ==0){
                                retorno.IdJovemEmAcompanhamento = int.Parse(resultadoReader["ID_JOVEM"].ToString());
                                retorno.NomeJovemEmAcompanhamento = resultadoReader["NOME"].ToString();
                                retorno.NomeArquivoFoto = resultadoReader["NOMEARQUIVOFOTO"].ToString();
                                retorno.IdObreiro = int.Parse(resultadoReader["ID_OBREIRO"].ToString());
                                retorno.NomeObreiro = resultadoReader["NOMEOBREIRO"].ToString();
                                retorno.DataInicioAcompanhamento = DateTime.Parse(resultadoReader["DATAINICIOACOMPANHAMENTO"].ToString()).ToString("dd/MM/yyyy");
                                retorno.DataTerminoAcompanhamento = (!resultadoReader.IsDBNull(resultadoReader.GetOrdinal("DATATERMINOACOMPANHAMENTO")))?DateTime.Parse(resultadoReader["DATATERMINOACOMPANHAMENTO"].ToString()).ToString("dd/MM/yyyy"):"";
                                retorno.InformacoesIgreja = new IgrejaDTO {
                                    IdEstado = int.Parse(resultadoReader["ID_ESTADO"].ToString()),
                                    NomeEstado = resultadoReader["NOMEESTADO"].ToString(),
                                    IdBlocoJovem = int.Parse(resultadoReader["ID_BLOCO"].ToString()),
                                    NomeBlocoJovem = resultadoReader["NOMEBLOCO"].ToString(),
                                    IdRegiao = int.Parse(resultadoReader["ID_REGIAO"].ToString()),
                                    NomeRegiaoJovem = resultadoReader["NOMEREGIAO"].ToString(),
                                    IdIgreja = int.Parse(resultadoReader["ID_IGREJA"].ToString()),
                                    NomeIgreja = resultadoReader["NOMEIGREJA"].ToString()
                                };
                            }
                            var mesDataHistorico = (!resultadoReader.IsDBNull(resultadoReader.GetOrdinal("DATAHISTORICOACOMPANHAMENTO"))) ? 
                                                      DateTime.Parse(resultadoReader["DATAHISTORICOACOMPANHAMENTO"].ToString()).Month : 0;

                            if (
                                (!resultadoReader.IsDBNull(resultadoReader.GetOrdinal("ID_STATUSACOMPANHAMENTO")))     &&
                                (!resultadoReader.IsDBNull(resultadoReader.GetOrdinal("DATAHISTORICOACOMPANHAMENTO")))
                               ) {
                                retorno.HistoricoAcompanhamento.Add(new ItemAcompanhamentoHistoricoDTO { 
                                        IdHistorico = int.Parse(resultadoReader["ID_HISTORICO"].ToString()),
                                        IdObreiroqueAcompanha = int.Parse(resultadoReader["ID_OBREIRO"].ToString()),
                                        IdStatusAcompanhamento = int.Parse(resultadoReader["ID_STATUSACOMPANHAMENTO"].ToString()),
                                        DescricaoStatusAcompanhamento = resultadoReader["DESCRICAOSTATUSACOMPANHAMENTO"].ToString(),
                                        TextoHistorico = resultadoReader["TEXTOOBSERVACAO"].ToString(),
                                        DataHistorico = DateTime.Parse(resultadoReader["DATAHISTORICOACOMPANHAMENTO"].ToString()).ToString("dd/MM/yyyy"),
                                        MesDataHistorico = new CultureInfo("pt-BR").DateTimeFormat.GetMonthName(mesDataHistorico)
                                });
                            }
                            //DateTime.Parse(resultadoReader["DATAHISTORICOACOMPANHAMENTO"].ToString()).Month;

                            i++;
                        }
                    }
                }

                return retorno;
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
        public void DesassociaJovensDeObreiro(IList<JovemAcompanhamentoDTO> JovensAcompanhados, ObreiroDTO ObreiroQueAcompanhava) {
            try {
                var _DAO = new DAO();
                var comandosDeExclusao = new List<string>();
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var SQLQuery = new StringBuilder();

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();
                    foreach (var jovemParaDesassociar in JovensAcompanhados) {
                        comandosDeExclusao.Add($"DELETE FROM SGFJU_DEV.SGFJU_TBL_ARVOREVIDA_JOVEMOBREIRO WHERE ID_JOVEM = {jovemParaDesassociar.IdJovem} AND ID_OBREIRO = {ObreiroQueAcompanhava.IdObreiro}");
                    }
                    _DAO.ExecuteNonQuery(conexao, comandosDeExclusao);
                }
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }

        public IList<TodosJovensDTO> ListaJovensEmAcompanhamentoPorParametro(PesquisaGeralDTO parametroPesquisa) {
            try
            {
                var retorno = new List<TodosJovensDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                var SQLQuery = new StringBuilder();
                var SQLWhere = new StringBuilder();
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var SQLOrderBy = " ORDER BY NOME ASC ";
                SQLWhere.Append(" WHERE 1 = 1 ");

                SQLQuery.Append("SELECT * FROM SGFJU_DEV.SGFJU_VW_ARVOREVIDA_JOVENS_EM_ACOMPANHAMENTO");

                if (parametroPesquisa.IdEstado != 0) {
                    SQLWhere.Append(" AND ID_ESTADO = " + parametroPesquisa.IdEstado);
                }

                if (parametroPesquisa.IdBloco != 0) {
                    SQLWhere.Append(" AND ID_BLOCO = " + parametroPesquisa.IdBloco);
                }

                if (parametroPesquisa.IdRegiao != 0) {
                    SQLWhere.Append(" AND ID_REGIAO = " + parametroPesquisa.IdRegiao);
                }

                if (parametroPesquisa.IdIgreja != 0) {
                    SQLWhere.Append(" AND ID_IGREJA = " + parametroPesquisa.IdIgreja);
                }

                if (!string.IsNullOrEmpty(parametroPesquisa.Nome)) {
                    SQLWhere.Append(" AND NOME LIKE '%" + parametroPesquisa.Nome + "%' ");
                }

                using (conexao = _DAO.GetConnection())
                {
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString() + SQLWhere.ToString() + SQLOrderBy, ref conexao)) {
                        while (resultadoReader.Read()) {
                            retorno.Add(new TodosJovensDTO {
                                IdJovem = int.Parse(resultadoReader["ID_JOVEM"].ToString()),   
                                IdX = EncryptionHelper.Encrypt(resultadoReader["ID_JOVEM"].ToString()),
                                NomeJovem = resultadoReader["NOME"].ToString(),
                                DataNascimento = DateTime.Parse(resultadoReader["DATANASCIMENTO"].ToString()).ToString("dd/MM/yyyy"),
                                NomeArquivoFoto = resultadoReader["NOMEARQUIVOFOTO"].ToString(),
                                NomeArquivoFotoFormatado = (!resultadoReader.IsDBNull(resultadoReader.GetOrdinal("NOMEARQUIVOFOTO"))) ?
                                                              ConfigurationManager.AppSettings["HOST_PROD"] + resultadoReader["NOMEARQUIVOFOTO"].ToString() :
                                                              ConfigurationManager.AppSettings["HOST_PROD"] + "UsuarioNaoSelecionado.png",
                                IdEstado = int.Parse(resultadoReader["ID_ESTADO"].ToString()),
                                NomeEstado = resultadoReader["NOMEESTADO"].ToString(),
                                IdBlocoJovem = int.Parse(resultadoReader["ID_BLOCO"].ToString()),
                                NomeBlocoJovem = resultadoReader["NOMEBLOCO"].ToString(),
                                IdRegiaoJovem = int.Parse(resultadoReader["ID_REGIAO"].ToString()),
                                NomeRegiaoJovem = resultadoReader["NOMEREGIAO"].ToString(),
                                IdIgreja = int.Parse(resultadoReader["ID_IGREJA"].ToString()),
                                NomeIgrejaJovem = resultadoReader["NOMEIGREJA"].ToString(),
                                IdObreiroAcompanha = int.Parse(resultadoReader["ID_OBREIRO"].ToString()),
                                NomeObreiroAcompanha = resultadoReader["NOMEOBREIRO"].ToString()
                            });
                        }
                    }
                }

                return retorno;
            }
            catch (Exception dataException)
            {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }

        public DataValidaHistoricoDTO EhDataHistoricoAcompanhamentoValida(string pDataHistorico, int pIdJovem) {
            try
            {
                DataValidaHistoricoDTO retorno = new DataValidaHistoricoDTO();
                var _DAO = new DAO();
                var SQLQuery = $"SELECT ID_HISTORICO FROM SGFJU_DEV.SGFJU_TBL_ARVOREVIDA_HISTORICOACOMPANHAMENTO WHERE ID_JOVEM = {pIdJovem} AND DataHistoricoAcompanhamento = '{pDataHistorico}'";
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString(), ref conexao)) {
                        if (resultadoReader.HasRows) {
                            return new DataValidaHistoricoDTO { EhDataValida = false, MensagemValidacao = "Já existe um registro de histórico de acompanhamento nesta data!" };
                        }
                    }
                }

                return new DataValidaHistoricoDTO { EhDataValida = true };
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
        public ObreiroDTO ObterObreiroPorIDX(IdXDTO idxObreiroParametro) { 
            try {
                var retorno = new ObreiroDTO();
                var _DAO = new DAO();
                var SQLQuery = "SELECT OBR.*,  " +
                               "       JV.ID_JOVEM, " +
                               "       JV.NOME, " +
                               "       JV.NOMEARQUIVOFOTO AS NOMEARQUIVOFOTO_JOVEM, " +
                               "   FROM SGFJU_DEV.SGFJU_VW_OBREIROS obr " +
                               "  LEFT JOIN SGFJU_DEV.SGFJU_TBL_ARVOREVIDA_JOVEMOBREIRO JOBR " +
                               "         ON OBR.ID_OBREIRO = JOBR.ID_OBREIRO " +
                               "  LEFT JOIN SGFJU_DEV.SGFJU_TBL_JOVEM JV " +
                               "         ON JOBR.ID_JOVEM = JV.ID_JOVEM " +
                               $"  WHERE OBR.ID_OBREIRO = {EncryptionHelper.Decrypt(idxObreiroParametro.IdX)}; ";
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                var i = 0;

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString(), ref conexao)) {
                        while (resultadoReader.Read()) {
                            if (i == 0) {
                                retorno.IdObreiro = int.Parse(resultadoReader["ID_OBREIRO"].ToString());
                                retorno.IdObreiroX = EncryptionHelper.Encrypt(resultadoReader["ID_OBREIRO"].ToString());
                                retorno.NomeObreiro = tinfo.ToTitleCase(resultadoReader["NomeOBREIRO"].ToString());
                                retorno.AnosObreiro = (resultadoReader["ANOSOBREIRO"].ToString() != "0" || resultadoReader["ANOSOBREIRO"].ToString() != "") ?
                                                    int.Parse(resultadoReader["ANOSOBREIRO"].ToString()) : 0;
                                retorno.MesesObreiro = (resultadoReader["MESESOBREIRO"].ToString() != "0" || resultadoReader["MESESOBREIRO"].ToString() != "") ?
                                                    int.Parse(resultadoReader["MESESOBREIRO"].ToString()) : 0;
                                retorno.MesAnoFoiLevantadoObreiro = resultadoReader["MESANOFOILEVANTADOOBREIRO"].ToString();
                                retorno.IdEstado = int.Parse(resultadoReader["ID_ESTADO"].ToString());
                                retorno.NomeEstado = tinfo.ToTitleCase(resultadoReader["NOMEESTADO"].ToString());
                                retorno.IdBloco = int.Parse(resultadoReader["ID_BLOCO"].ToString());
                                retorno.NomeBloco = tinfo.ToTitleCase(resultadoReader["NOMEBLOCO"].ToString());
                                retorno.IdRegiao = int.Parse(resultadoReader["ID_REGIAO"].ToString());
                                retorno.NomeRegiao = tinfo.ToTitleCase(resultadoReader["NOMEREGIAO"].ToString());
                                retorno.IdIgreja = int.Parse(resultadoReader["ID_IGREJA"].ToString());
                                retorno.NomeIgreja = tinfo.ToTitleCase(resultadoReader["NOMEIGREJA"].ToString());
                                retorno.NomeArquivoFoto = resultadoReader["NOMEARQUIVOFOTO"].ToString();
                            }
                            retorno.JovensQueObreiroAcompanha.Add(new JovemDTO { 
                                IdX = EncryptionHelper.Encrypt(resultadoReader["ID_JOVEM"].ToString()),
                                Nome = resultadoReader["NOME"].ToString(),
                                NomeArquivoFoto = resultadoReader["NOMEARQUIVOFOTO"].ToString(),
                                NomeArquivoFotoFormatado = (!resultadoReader.IsDBNull(resultadoReader.GetOrdinal("NOMEARQUIVOFOTO"))) ?
                                                              ConfigurationManager.AppSettings["HOST_PROD"] + resultadoReader["NOMEARQUIVOFOTO_JOVEM"].ToString() :
                                                              ConfigurationManager.AppSettings["HOST_PROD"] + "UsuarioNaoSelecionado.png",
                            });
                            i++;
                        }
                    }
                }

                return retorno;
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }

        public IList<ObreiroDTO> ListaObreirosComRamosPorParametro(PesquisaGeralDTO parametrosPesquisa) { 
            try {
                var retorno = new ObreiroDTO();
                var _DAO = new DAO();
                var SQLQuery = "SELECT OBR.*,  " +
                               "       JOBR.* " +
                               "   FROM SGFJU_DEV.SGFJU_VW_ARVOREVIDA_JOVENS_EM_ACOMPANHAMENTO JOBR " +
                               "  INNER JOIN SGFJU_DEV.SGFJU_VW_OBREIROS obr " +
                               "         ON OBR.ID_OBREIRO = JOBR.ID_OBREIRO " +
                               "  WHERE 1=1 ";
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                var obreirosQueAcompanham = new List<ObreiroDTO>();
                var jovensEmAcompanhamento = new List<JovemDTO>();
                var listaRetorno = new List<ObreiroDTO>();
                var listaObreirosSemRepeticao = new List<ObreiroDTO>();

                if (parametrosPesquisa.IdEstado != 0)
                {
                    SQLQuery += $" AND OBR.ID_ESTADO = {parametrosPesquisa.IdEstado} ";
                }

                if (parametrosPesquisa.IdBloco != 0)
                {
                    SQLQuery += $" AND OBR.ID_BLOCO = {parametrosPesquisa.IdBloco} ";
                }

                if (parametrosPesquisa.IdRegiao != 0) {
                    SQLQuery += $" AND OBR.ID_REGIAO = {parametrosPesquisa.IdRegiao} ";
                }

                if (parametrosPesquisa.IdIgreja != 0) {
                    SQLQuery += $" AND OBR.ID_IGREJA = {parametrosPesquisa.IdIgreja} ";
                }

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString(), ref conexao)) {
                        try {
                            while (resultadoReader.Read()) {
                                obreirosQueAcompanham.Add(new ObreiroDTO {
                                    IdObreiro = int.Parse(resultadoReader["ID_OBREIRO"].ToString()),
                                    //IdObreiroX = EncryptionHelper.Encrypt(resultadoReader["ID_OBREIRO"].ToString()),
                                    NomeObreiro = tinfo.ToTitleCase(resultadoReader["NomeOBREIRO"].ToString()),
                                    AnosObreiro = (resultadoReader["ANOSOBREIRO"].ToString() != "0" || resultadoReader["ANOSOBREIRO"].ToString() != "") ?
                                                        int.Parse(resultadoReader["ANOSOBREIRO"].ToString()) : 0,
                                    MesesObreiro = (resultadoReader["MESESOBREIRO"].ToString() != "0" || resultadoReader["MESESOBREIRO"].ToString() != "") ?
                                                        int.Parse(resultadoReader["MESESOBREIRO"].ToString()) : 0,
                                    MesAnoFoiLevantadoObreiro = resultadoReader["MESANOFOILEVANTADOOBREIRO"].ToString(),
                                    IdEstado = int.Parse(resultadoReader["ID_ESTADO"].ToString()),
                                    NomeEstado = tinfo.ToTitleCase(resultadoReader["NOMEESTADO"].ToString()),
                                    IdBloco = int.Parse(resultadoReader["ID_BLOCO"].ToString()),
                                    NomeBloco = tinfo.ToTitleCase(resultadoReader["NOMEBLOCO"].ToString()),
                                    IdRegiao = int.Parse(resultadoReader["ID_REGIAO"].ToString()),
                                    NomeRegiao = tinfo.ToTitleCase(resultadoReader["NOMEREGIAO"].ToString()),
                                    IdIgreja = int.Parse(resultadoReader["ID_IGREJA"].ToString()),
                                    NomeIgreja = tinfo.ToTitleCase(resultadoReader["NOMEIGREJA"].ToString()),
                                    NomeArquivoFoto = resultadoReader["NOMEARQUIVOFOTO_OBREIRO"].ToString(),
                                });
                            
                                jovensEmAcompanhamento.Add(new JovemDTO { 
                                    Id = int.Parse(resultadoReader["ID_JOVEM"].ToString()),
                                    //IdX = EncryptionHelper.Encrypt(resultadoReader["ID_JOVEM"].ToString()),
                                    Nome = resultadoReader["NOME"].ToString(),
                                    NomeArquivoFoto = resultadoReader["NOMEARQUIVOFOTO_JOVEM"].ToString(),
                                    NomeArquivoFotoFormatado = (!resultadoReader.IsDBNull(resultadoReader.GetOrdinal("NOMEARQUIVOFOTO_JOVEM"))) ?
                                                                  ConfigurationManager.AppSettings["HOST_PROD"] + resultadoReader["NOMEARQUIVOFOTO_JOVEM"].ToString() :
                                                                  ConfigurationManager.AppSettings["HOST_PROD"] + "UsuarioNaoSelecionado.png",
                                    ArvoreVidaAcompanhamento = new AcompanhamentoJovemDTO { 
                                        IdObreiro = int.Parse( resultadoReader["ID_OBREIRO"].ToString() ) 
                                    }
                                });
                            }
                        }
                        catch (Exception excReader) {
                            var msgError = ExceptionManager.ExceptionManager.FormatExceptionMessage(excReader, "CAMADA_ORM"); 
                        }                        
                    }
                }

                listaObreirosSemRepeticao = obreirosQueAcompanham.Distinct(new ComparadorObreiroDTO()).ToList();
                var bb = obreirosQueAcompanham.Distinct(new ComparadorObreiroDTO()).ToList().Count;
                var aa = obreirosQueAcompanham.Distinct().ToList().Count;
                /*
                foreach (var obreiroArvoreVida in obreirosQueAcompanham) {
                    if (listaObreirosSemRepeticao.Count != 0) {
                        
                    }
                    else
                        listaObreirosSemRepeticao.Add(obreiroArvoreVida);
                }*/

                foreach (var obreiroAV in listaObreirosSemRepeticao) {
                    var jovensAcompanhadosPeloObreiro = jovensEmAcompanhamento.Where(ob => ob.ArvoreVidaAcompanhamento.IdObreiro == obreiroAV.IdObreiro).ToList();
                    (obreiroAV.JovensQueObreiroAcompanha as List<JovemDTO>)
                        .AddRange(jovensAcompanhadosPeloObreiro);
                }

                listaRetorno.AddRange(listaObreirosSemRepeticao);

                return listaRetorno;
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }

        public IList<ObreiroDTO> ListarObreirosSemRamosAVPorParametro(PesquisaGeralDTO parametrosPesquisa) {
            try
            {
                var retorno = new ObreiroDTO();
                var _DAO = new DAO();
                var SQLQuery = "SELECT VWO.* " +
                               "  FROM SGFJU_DEV.SGFJU_VW_OBREIROS VWO " +
                              $" WHERE 1=1 "; 
                var clausulaNotIn = "   AND VWO.ID_OBREIRO NOT IN ( SELECT ID_OBREIRO  " +
                                    "                                 FROM SGFJU_DEV.SGFJU_VW_ARVOREVIDA_JOVENS_EM_ACOMPANHAMENTO );  ";
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                var listaRetorno = new List<ObreiroDTO>();

                if (parametrosPesquisa.IdEstado != 0) {
                    SQLQuery += $" AND VWO.ID_ESTADO = {parametrosPesquisa.IdEstado} ";
                }

                if (parametrosPesquisa.IdBloco != 0) {
                    SQLQuery += $" AND VWO.ID_BLOCO = {parametrosPesquisa.IdBloco} ";
                }

                if (parametrosPesquisa.IdRegiao != 0) {
                    SQLQuery += $" AND VWO.ID_REGIAO = {parametrosPesquisa.IdRegiao} ";
                }

                if (parametrosPesquisa.IdIgreja != 0) {
                    SQLQuery += $" AND VWO.ID_IGREJA = {parametrosPesquisa.IdIgreja} ";
                }
                //" VWO.ID_ESTADO = {parametrosPesquisa.IdEstado} ";
                SQLQuery += clausulaNotIn;

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString(), ref conexao)) {
                        while (resultadoReader.Read()) {
                            listaRetorno.Add(new ObreiroDTO {
                                IdObreiro       = int.Parse(resultadoReader["ID_OBREIRO"].ToString()),
                                IdObreiroX      = EncryptionHelper.Encrypt(resultadoReader["ID_OBREIRO"].ToString()),
                                NomeObreiro     = tinfo.ToTitleCase(resultadoReader["NomeOBREIRO"].ToString()),
                                AnosObreiro     = (resultadoReader["ANOSOBREIRO"].ToString() != "0" || resultadoReader["ANOSOBREIRO"].ToString() != "") ?
                                                    int.Parse(resultadoReader["ANOSOBREIRO"].ToString()) : 0,
                                MesesObreiro    = (resultadoReader["MESESOBREIRO"].ToString() != "0" || resultadoReader["MESESOBREIRO"].ToString() != "") ?
                                                    int.Parse(resultadoReader["MESESOBREIRO"].ToString()) : 0,
                                MesAnoFoiLevantadoObreiro 
                                                = resultadoReader["MESANOFOILEVANTADOOBREIRO"].ToString(),
                                IdEstado        = int.Parse(resultadoReader["ID_ESTADO"].ToString()),
                                NomeEstado      = tinfo.ToTitleCase(resultadoReader["NOMEESTADO"].ToString()),
                                IdBloco         = int.Parse(resultadoReader["ID_BLOCO"].ToString()),
                                NomeBloco       = tinfo.ToTitleCase(resultadoReader["NOMEBLOCO"].ToString()),
                                IdRegiao        = int.Parse(resultadoReader["ID_REGIAO"].ToString()),
                                NomeRegiao      = tinfo.ToTitleCase(resultadoReader["NOMEREGIAO"].ToString()),
                                IdIgreja        = int.Parse(resultadoReader["ID_IGREJA"].ToString()),
                                NomeIgreja      = tinfo.ToTitleCase(resultadoReader["NOMEIGREJA"].ToString()),
                                NomeArquivoFoto = resultadoReader["NOMEARQUIVOFOTO"].ToString(),
                                NomeArquivoFotoFormatado 
                                               = (!resultadoReader.IsDBNull(resultadoReader.GetOrdinal("NOMEARQUIVOFOTO"))) ?
                                                    ConfigurationManager.AppSettings["HOST_PROD"] + resultadoReader["NOMEARQUIVOFOTO"].ToString() :
                                                    ConfigurationManager.AppSettings["HOST_PROD"] + "UsuarioNaoSelecionado.png",
                            });
                        }
                    }
                }

                return listaRetorno;
            }
            catch (Exception dataException)
            {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
    }
}
