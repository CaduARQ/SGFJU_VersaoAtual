using MySql.Data.MySqlClient;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.DataAccess.MySql.Common;
using SGFJU.Domain.Model.Repositories;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Implementation
{
    public class AltarJovemRepositoryImpl : RepositoryImpl<Jovem>, AltarJovemRepository
    {
        public IList<AltarJovemDTO> ObterTodosBR() {
            try {
                var retorno = new List<AltarJovemDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;

                var SQLQuery = new StringBuilder();
                SQLQuery.Append("  SELECT JV.ID_JOVEM,                                             ");
                SQLQuery.Append("         JV.NOME,                                                 ");
                SQLQuery.Append("         JV.NOMEARQUIVOFOTO,                                      ");
                SQLQuery.Append("         ED.NOMEESTADO,                                           ");
                SQLQuery.Append("         BL.NOMEBLOCO,                                            ");
                SQLQuery.Append("         REG.NOMEREGIAO,                                          ");
                SQLQuery.Append("         IGJ.NOMEIGREJA,                                          ");
                SQLQuery.Append("         CT.WHATSAPP                                              ");
                SQLQuery.Append("	FROM      sgfju_dev.SGFJU_TBL_JOVEM JV                         ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_CONTATO CT                      ");
                SQLQuery.Append("			ON JV.ID_CONTATO = CT.ID_CONTATO                       ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_SITUACAO_IURD_FJU SIFJ          ");
                SQLQuery.Append("		    ON SIFJ.ID_SITUACAO_IURD_FJU = JV.ID_SITUACAO_IURD_FJU ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_DADOSESPIRITUAIS DESP           ");
                SQLQuery.Append("           ON DESP.ID_DADOSESPIRITUAIS = JV.ID_DADOSESPIRITUAIS   ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_IGREJA IGJ                      ");
                SQLQuery.Append("			ON JV.ID_IGREJA = IGJ.ID_IGREJA                        ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_REGIAO REG                      ");
                SQLQuery.Append("			ON IGJ.ID_REGIAO = REG.ID_REGIAO                       ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_BLOCO  BL                       ");
                SQLQuery.Append("		   ON REG.ID_BLOCO = BL.ID_BLOCO                           ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_ESTADO ED                       ");
                SQLQuery.Append("		   ON BL.ID_ESTADO = ED.ID_ESTADO                          ");

                var SQLWhere = new StringBuilder();
                SQLWhere.Append(" WHERE JV.EHPASTOR = 0 ");
                SQLWhere.Append(" AND SIFJ.PERTENCEALTARJOVEM = 'S' ");

                using (conexao = _DAO.GetConnection()){
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString() + SQLWhere.ToString(), ref conexao)) { 
                        while (resultadoReader.Read()){
                            retorno.Add(new AltarJovemDTO
                            {
                                IdJovem = int.Parse(resultadoReader["ID_JOVEM"].ToString()),
                                NomeJovem = tinfo.ToTitleCase(resultadoReader["Nome"].ToString()),
                                NomeEstado = tinfo.ToTitleCase(resultadoReader["NOMEESTADO"].ToString()),
                                NomeBlocoJovem = tinfo.ToTitleCase(resultadoReader["NOMEBLOCO"].ToString()),
                                NomeRegiaoJovem = tinfo.ToTitleCase(resultadoReader["NOMEREGIAO"].ToString()),
                                NomeIgrejaJovem = tinfo.ToTitleCase(resultadoReader["NOMEIGREJA"].ToString()),
                                Whatsapp = FormataTelefone(resultadoReader["WHATSAPP"].ToString()),//string.Format("{0:(##) #####-####}", resultadoReader["WHATSAPP"].ToString().Replace('-', ' ').Trim()),
                                WhatsappSemFormatacao = resultadoReader["WHATSAPP"].ToString(),
                                NomeArquivoFoto = resultadoReader["NomeArquivoFoto"].ToString()
                            });
                        }
                    }                
                }

                return retorno;
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "obterIgrejasDaRegiao", dataException.Message);
                throw new DomainException(erroMessage, dataException);
            }
        }

        public IList<AltarJovemDTO> ObterJovensAltarJovemPorParametro(AltarJovemParametroPesquisaDTO parametros) { 
            
            try {
                var retorno = new List<AltarJovemDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;

                var SQLQuery = new StringBuilder();
                SQLQuery.Append("  SELECT JV.ID_JOVEM,                                             ");
                SQLQuery.Append("         JV.NOME,                                                 ");
                SQLQuery.Append("         JV.NOMEARQUIVOFOTO,                                      ");
                SQLQuery.Append("         ED.NOMEESTADO,                                           ");
                SQLQuery.Append("         BL.NOMEBLOCO,                                            ");
                SQLQuery.Append("         REG.NOMEREGIAO,                                          ");
                SQLQuery.Append("         IGJ.NOMEIGREJA,                                          ");
                SQLQuery.Append("         CT.WHATSAPP                                              ");
                SQLQuery.Append("	FROM      sgfju_dev.SGFJU_TBL_JOVEM JV                         ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_CONTATO CT                      ");
                SQLQuery.Append("			ON JV.ID_CONTATO = CT.ID_CONTATO                       ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_SITUACAO_IURD_FJU SIFJ          ");
                SQLQuery.Append("		    ON SIFJ.ID_SITUACAO_IURD_FJU = JV.ID_SITUACAO_IURD_FJU ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_DADOSESPIRITUAIS DESP           ");
                SQLQuery.Append("           ON DESP.ID_DADOSESPIRITUAIS = JV.ID_DADOSESPIRITUAIS   ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_IGREJA IGJ                      ");
                SQLQuery.Append("			ON JV.ID_IGREJA = IGJ.ID_IGREJA                        ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_REGIAO REG                      ");
                SQLQuery.Append("			ON IGJ.ID_REGIAO = REG.ID_REGIAO                       ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_BLOCO  BL                       ");
                SQLQuery.Append("		   ON REG.ID_BLOCO = BL.ID_BLOCO                           ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_ESTADO ED                       ");
                SQLQuery.Append("		   ON BL.ID_ESTADO = ED.ID_ESTADO                          ");

                var SQLWhere = new StringBuilder();
                SQLWhere.Append(" WHERE JV.EHPASTOR = 0 ");
                SQLWhere.Append(" AND SIFJ.PERTENCEALTARJOVEM = 'S' ");

                if (parametros.IdEstado != 0)
                {
                    SQLWhere.Append(" AND ED.ID_ESTADO = " + parametros.IdEstado.ToString() + " ");
                }

                if (parametros.IdBlocoJovem != 0)
                {
                    SQLWhere.Append(" AND BL.ID_BLOCO = " + parametros.IdBlocoJovem.ToString() + " ");
                }

                if (parametros.IdRegiaoJovem != 0)
                {
                    SQLWhere.Append(" AND REG.ID_REGIAO = " + parametros.IdRegiaoJovem.ToString() + " ");
                }

                if (parametros.IdIgreja != 0)
                {
                    SQLWhere.Append(" AND IGJ.ID_IGREJA = " + parametros.IdIgreja.ToString() + " ");
                }

                if (!string.IsNullOrEmpty(parametros.Sexo)) {
                    SQLWhere.Append(" AND JV.SEXO = '" + parametros.Sexo + "' ");
                }

                if (parametros.EhAltarJovem318 == 'S') {
                    SQLWhere.Append(" AND JV.EhAltarJovem318 = 'S' ");
                }

                if (parametros.GruposSelecionadosPesquisa != null &&
                    parametros.GruposSelecionadosPesquisa.Count > 0) {
                    foreach (var grupoParaPesquisar in parametros.GruposSelecionadosPesquisa){
                        switch (grupoParaPesquisar)
                        {
                            case "Agua":
                                SQLWhere.Append(" AND DESP.EhBATIZADOAGUAS = 'S'");
                                break;
                            case "Oleo":
                                SQLWhere.Append(" AND DESP.EhBATIZADOESPIRITOSANTO = 'S'");
                                break;
                            case "Sal":
                                SQLWhere.Append(" AND SIFJ.ESTACURSANDOCPO = 'S' ");
                                break;
                            case "Luz":
                                SQLWhere.Append(" AND SIFJ.EHOBREIRO = 'S' ");
                                break;
                        }
                    }
                }

                using (conexao = _DAO.GetConnection()){
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString() + SQLWhere.ToString(), ref conexao)) {                        
                        while (resultadoReader.Read()) {
                            retorno.Add(new AltarJovemDTO {
                                IdJovem = int.Parse(resultadoReader["ID_JOVEM"].ToString()),
                                NomeJovem = tinfo.ToTitleCase(resultadoReader["Nome"].ToString()),
                                NomeEstado = tinfo.ToTitleCase(resultadoReader["NOMEESTADO"].ToString()),
                                NomeBlocoJovem = tinfo.ToTitleCase(resultadoReader["NOMEBLOCO"].ToString()),
                                NomeRegiaoJovem = tinfo.ToTitleCase(resultadoReader["NOMEREGIAO"].ToString()),
                                NomeIgrejaJovem = tinfo.ToTitleCase(resultadoReader["NOMEIGREJA"].ToString()),
                                Whatsapp = FormataTelefone(resultadoReader["WHATSAPP"].ToString()),//string.Format("{0:(##) #####-####}", resultadoReader["WHATSAPP"].ToString().Replace('-', ' ').Trim()),
                                WhatsappSemFormatacao = resultadoReader["WHATSAPP"].ToString(),
                                NomeArquivoFoto = resultadoReader["NomeArquivoFoto"].ToString(),
                            });
                        }
                    }
                }

                return retorno;
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "obterIgrejasDaRegiao", dataException.Message);
                throw new DomainException(mensagemTratada, dataException);
            }
        }
        
        public IList<AltarJovemDTO> ObterTodosJovensAltarJovemPorEstado(Estado estado){
            try {
                var retorno = new List<AltarJovemDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;

                var SQLQuery = new StringBuilder();
                SQLQuery.Append("  SELECT JV.ID_JOVEM,                                             ");
                SQLQuery.Append("         JV.NOME,                                                 ");
                SQLQuery.Append("         ED.NOMEESTADO,                                           ");
                SQLQuery.Append("         BL.NOMEBLOCO,                                            ");
                SQLQuery.Append("         REG.NOMEREGIAO,                                          ");
                SQLQuery.Append("         IGJ.NOMEIGREJA,                                          ");
                SQLQuery.Append("         CT.WHATSAPP                                              ");
                SQLQuery.Append("	FROM      sgfju_dev.SGFJU_TBL_JOVEM JV                         ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_CONTATO CT                      ");
                SQLQuery.Append("			ON JV.ID_CONTATO = CT.ID_CONTATO                       ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_SITUACAO_IURD_FJU SIFJ          ");
                SQLQuery.Append("		    ON SIFJ.ID_SITUACAO_IURD_FJU = JV.ID_SITUACAO_IURD_FJU ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_DADOSESPIRITUAIS DESP           ");
                SQLQuery.Append("           ON DESP.ID_DADOSESPIRITUAIS = JV.ID_DADOSESPIRITUAIS   ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_IGREJA IGJ                      ");
                SQLQuery.Append("			ON JV.ID_IGREJA = IGJ.ID_IGREJA                        ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_REGIAO REG                      ");
                SQLQuery.Append("			ON IGJ.ID_REGIAO = REG.ID_REGIAO                       ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_BLOCO  BL                       ");
                SQLQuery.Append("		   ON REG.ID_BLOCO = BL.ID_BLOCO                           ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_ESTADO ED                       ");
                SQLQuery.Append("		   ON BL.ID_ESTADO = ED.ID_ESTADO                          ");

                var SQLWhere = new StringBuilder();
                SQLWhere.Append(" WHERE JV.EHPASTOR = 0 ");
                SQLWhere.Append(" AND SIFJ.PERTENCEALTARJOVEM = 'S' ");

                if (estado.Id != 0) {
                    SQLWhere.Append(" AND ED.ID_ESTADO = " + estado.Id + " ");
                }

                using (conexao = _DAO.GetConnection()){
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString() + SQLWhere.ToString(), ref conexao)) {                        
                        while (resultadoReader.Read()) {
                            retorno.Add(new AltarJovemDTO {
                                IdJovem = int.Parse(resultadoReader["ID_JOVEM"].ToString()),
                                NomeJovem = tinfo.ToTitleCase(resultadoReader["Nome"].ToString()),
                                NomeEstado = tinfo.ToTitleCase(resultadoReader["NOMEESTADO"].ToString()),
                                NomeBlocoJovem = tinfo.ToTitleCase(resultadoReader["NOMEBLOCO"].ToString()),
                                NomeRegiaoJovem = tinfo.ToTitleCase(resultadoReader["NOMEREGIAO"].ToString()),
                                NomeIgrejaJovem = tinfo.ToTitleCase(resultadoReader["NOMEIGREJA"].ToString()),
                                Whatsapp = FormataTelefone(resultadoReader["WHATSAPP"].ToString()),//string.Format("{0:(##) #####-####}", resultadoReader["WHATSAPP"].ToString().Replace('-', ' ').Trim()),
                                WhatsappSemFormatacao = resultadoReader["WHATSAPP"].ToString()
                            });
                        }
                    }
                }

                return retorno;
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "obterIgrejasDaRegiao", dataException.Message);
                throw new DomainException(mensagemTratada, dataException);
            }
        }

        public IList<AltarJovemDTO> ObterTodosJovensAltarJovemPorBloco(Bloco bloco){
            try {
                return null;
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "obterIgrejasDaRegiao", dataException.Message);
                throw new DomainException(erroMessage, dataException);
            }
        }

        public IList<AltarJovemDTO> ObterTodosJovensAltarJovemAgua() {
            try {
                var retorno = new List<AltarJovemDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;

                var SQLQuery = new StringBuilder();
                SQLQuery.Append("  SELECT JV.ID_JOVEM,                                             ");
                SQLQuery.Append("         JV.NOME,                                                 ");
                SQLQuery.Append("         ED.NOMEESTADO,                                           ");
                SQLQuery.Append("         BL.NOMEBLOCO,                                            ");
                SQLQuery.Append("         REG.NOMEREGIAO,                                          ");
                SQLQuery.Append("         IGJ.NOMEIGREJA,                                          ");
                SQLQuery.Append("         CT.WHATSAPP                                              ");
                SQLQuery.Append("	FROM      sgfju_dev.SGFJU_TBL_JOVEM JV                         ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_CONTATO CT                      ");
                SQLQuery.Append("			ON JV.ID_CONTATO = CT.ID_CONTATO                       ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_SITUACAO_IURD_FJU SIFJ          ");
                SQLQuery.Append("		    ON SIFJ.ID_SITUACAO_IURD_FJU = JV.ID_SITUACAO_IURD_FJU ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_DADOSESPIRITUAIS DESP           ");
                SQLQuery.Append("           ON DESP.ID_DADOSESPIRITUAIS = JV.ID_DADOSESPIRITUAIS   ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_IGREJA IGJ                      ");
                SQLQuery.Append("			ON JV.ID_IGREJA = IGJ.ID_IGREJA                        ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_REGIAO REG                      ");
                SQLQuery.Append("			ON IGJ.ID_REGIAO = REG.ID_REGIAO                       ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_BLOCO  BL                       ");
                SQLQuery.Append("		   ON REG.ID_BLOCO = BL.ID_BLOCO                           ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_ESTADO ED                       ");
                SQLQuery.Append("		   ON BL.ID_ESTADO = ED.ID_ESTADO                          ");

                var SQLWhere = new StringBuilder();
                SQLWhere.Append(" WHERE JV.EHPASTOR = 0 ");
                SQLWhere.Append(" AND SIFJ.PERTENCEALTARJOVEM = 'S' ");
                SQLWhere.Append(" AND DESP.EhBATIZADOAGUAS = 'S'");

                using (conexao = _DAO.GetConnection()){
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString() + SQLWhere.ToString(), ref conexao)) {                        
                        while (resultadoReader.Read()) {
                            retorno.Add(new AltarJovemDTO {
                                IdJovem = int.Parse(resultadoReader["ID_JOVEM"].ToString()),
                                NomeJovem = tinfo.ToTitleCase(resultadoReader["Nome"].ToString()),
                                NomeEstado = tinfo.ToTitleCase(resultadoReader["NOMEESTADO"].ToString()),
                                NomeBlocoJovem = tinfo.ToTitleCase(resultadoReader["NOMEBLOCO"].ToString()),
                                NomeRegiaoJovem = tinfo.ToTitleCase(resultadoReader["NOMEREGIAO"].ToString()),
                                NomeIgrejaJovem = tinfo.ToTitleCase(resultadoReader["NOMEIGREJA"].ToString()),
                                Whatsapp = string.Format("{0:(##) #####-####}", resultadoReader["WHATSAPP"].ToString().Replace('-', ' ').Trim()),
                                WhatsappSemFormatacao = resultadoReader["WHATSAPP"].ToString()
                            });
                        }
                    }
                }

                return retorno;
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "obterIgrejasDaRegiao", dataException.Message);
                throw new DomainException(erroMessage, dataException);
            }
        }
        public IList<AltarJovemDTO> ObterTodosJovensAltarJovemOleo(){
            try {
                var retorno = new List<AltarJovemDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;

                var SQLQuery = new StringBuilder();
                SQLQuery.Append("  SELECT JV.ID_JOVEM,                                             ");
                SQLQuery.Append("         JV.NOME,                                                 ");
                SQLQuery.Append("         ED.NOMEESTADO,                                           ");
                SQLQuery.Append("         BL.NOMEBLOCO,                                            ");
                SQLQuery.Append("         REG.NOMEREGIAO,                                          ");
                SQLQuery.Append("         IGJ.NOMEIGREJA,                                          ");
                SQLQuery.Append("         CT.WHATSAPP                                              ");
                SQLQuery.Append("	FROM      sgfju_dev.SGFJU_TBL_JOVEM JV                         ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_CONTATO CT                      ");
                SQLQuery.Append("			ON JV.ID_CONTATO = CT.ID_CONTATO                       ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_SITUACAO_IURD_FJU SIFJ          ");
                SQLQuery.Append("		    ON SIFJ.ID_SITUACAO_IURD_FJU = JV.ID_SITUACAO_IURD_FJU ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_DADOSESPIRITUAIS DESP           ");
                SQLQuery.Append("           ON DESP.ID_DADOSESPIRITUAIS = JV.ID_DADOSESPIRITUAIS   ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_IGREJA IGJ                      ");
                SQLQuery.Append("			ON JV.ID_IGREJA = IGJ.ID_IGREJA                        ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_REGIAO REG                      ");
                SQLQuery.Append("			ON IGJ.ID_REGIAO = REG.ID_REGIAO                       ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_BLOCO  BL                       ");
                SQLQuery.Append("		   ON REG.ID_BLOCO = BL.ID_BLOCO                           ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_ESTADO ED                       ");
                SQLQuery.Append("		   ON BL.ID_ESTADO = ED.ID_ESTADO                          ");

                var SQLWhere = new StringBuilder();
                SQLWhere.Append(" WHERE JV.EHPASTOR = 0 ");
                SQLWhere.Append(" AND SIFJ.PERTENCEALTARJOVEM = 'S' ");
                SQLWhere.Append(" AND DESP.EhBATIZADOAGUAS = 'S'");
                SQLWhere.Append(" AND DESP.EhBATIZADOESPIRITOSANTO = 'S'");

                using (conexao = _DAO.GetConnection()){
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString() + SQLWhere.ToString(), ref conexao)) {
                        while (resultadoReader.Read())
                        {
                            retorno.Add(new AltarJovemDTO
                            {
                                IdJovem = int.Parse(resultadoReader["ID_JOVEM"].ToString()),
                                NomeJovem = tinfo.ToTitleCase(resultadoReader["Nome"].ToString()),
                                NomeEstado = tinfo.ToTitleCase(resultadoReader["NOMEESTADO"].ToString()),
                                NomeBlocoJovem = tinfo.ToTitleCase(resultadoReader["NOMEBLOCO"].ToString()),
                                NomeRegiaoJovem = tinfo.ToTitleCase(resultadoReader["NOMEREGIAO"].ToString().ToUpper()),
                                NomeIgrejaJovem = tinfo.ToTitleCase(resultadoReader["NOMEIGREJA"].ToString().ToUpper()),
                                Whatsapp = string.Format("{0:(##) #####-####}", resultadoReader["WHATSAPP"].ToString().Replace('-', ' ').Trim()),
                                WhatsappSemFormatacao = resultadoReader["WHATSAPP"].ToString()
                            });
                        }
                    }
                }

                return retorno;
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "obterIgrejasDaRegiao", dataException.Message);
                throw new DomainException(erroMessage, dataException);
            }
        }
        public IList<AltarJovemDTO> ObterTodosJovensAltarJovemSal(){
            try {
                var retorno = new List<AltarJovemDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;

                var SQLQuery = new StringBuilder();
                SQLQuery.Append("  SELECT JV.ID_JOVEM,                                             ");
                SQLQuery.Append("         JV.NOME,                                                 ");
                SQLQuery.Append("         ED.NOMEESTADO,                                           ");
                SQLQuery.Append("         BL.NOMEBLOCO,                                            ");
                SQLQuery.Append("         REG.NOMEREGIAO,                                          ");
                SQLQuery.Append("         IGJ.NOMEIGREJA,                                          ");
                SQLQuery.Append("         CT.WHATSAPP                                              ");
                SQLQuery.Append("	FROM      sgfju_dev.SGFJU_TBL_JOVEM JV                         ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_CONTATO CT                      ");
                SQLQuery.Append("			ON JV.ID_CONTATO = CT.ID_CONTATO                       ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_SITUACAO_IURD_FJU SIFJ          ");
                SQLQuery.Append("		    ON SIFJ.ID_SITUACAO_IURD_FJU = JV.ID_SITUACAO_IURD_FJU ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_DADOSESPIRITUAIS DESP           ");
                SQLQuery.Append("           ON DESP.ID_DADOSESPIRITUAIS = JV.ID_DADOSESPIRITUAIS   ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_IGREJA IGJ                      ");
                SQLQuery.Append("			ON JV.ID_IGREJA = IGJ.ID_IGREJA                        ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_REGIAO REG                      ");
                SQLQuery.Append("			ON IGJ.ID_REGIAO = REG.ID_REGIAO                       ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_BLOCO  BL                       ");
                SQLQuery.Append("		   ON REG.ID_BLOCO = BL.ID_BLOCO                           ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_ESTADO ED                       ");
                SQLQuery.Append("		   ON BL.ID_ESTADO = ED.ID_ESTADO                          ");

                var SQLWhere = new StringBuilder();
                SQLWhere.Append(" WHERE JV.EHPASTOR = 0 ");
                SQLWhere.Append(" AND SIFJ.PERTENCEALTARJOVEM = 'S' ");
                SQLWhere.Append(" AND SIFJ.ESTACURSANDOCPO = 'S' ");

                using (conexao = _DAO.GetConnection()){
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString() + SQLWhere.ToString(), ref conexao)) {                        
                        while (resultadoReader.Read())
                        {
                            retorno.Add(new AltarJovemDTO
                            {
                                IdJovem = int.Parse(resultadoReader["ID_JOVEM"].ToString()),
                                NomeJovem = tinfo.ToTitleCase(resultadoReader["Nome"].ToString()),
                                NomeEstado = tinfo.ToTitleCase(resultadoReader["NOMEESTADO"].ToString()),
                                NomeBlocoJovem = tinfo.ToTitleCase(resultadoReader["NOMEBLOCO"].ToString()),
                                NomeRegiaoJovem = tinfo.ToTitleCase(resultadoReader["NOMEREGIAO"].ToString().ToUpper()),
                                NomeIgrejaJovem = tinfo.ToTitleCase(resultadoReader["NOMEIGREJA"].ToString().ToUpper()),
                                Whatsapp = string.Format("{0:(##) #####-####}", resultadoReader["WHATSAPP"].ToString().Replace('-', ' ').Trim()),
                                WhatsappSemFormatacao = resultadoReader["WHATSAPP"].ToString()
                            });
                        }
                    }
                }

                return retorno;
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "obterIgrejasDaRegiao", dataException.Message);
                throw new DomainException(erroMessage, dataException);
            }
        }

        public IList<AltarJovemDTO> ObterTodosJovensAltarJovemLuz(){
            try {
                var retorno = new List<AltarJovemDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;

                var SQLQuery = new StringBuilder();
                SQLQuery.Append("  SELECT JV.ID_JOVEM,                                             ");
                SQLQuery.Append("         JV.NOME,                                                 ");
                SQLQuery.Append("         ED.NOMEESTADO,                                           ");
                SQLQuery.Append("         BL.NOMEBLOCO,                                            ");
                SQLQuery.Append("         REG.NOMEREGIAO,                                          ");
                SQLQuery.Append("         IGJ.NOMEIGREJA,                                          ");
                SQLQuery.Append("         CT.WHATSAPP                                              ");
                SQLQuery.Append("	FROM      sgfju_dev.SGFJU_TBL_JOVEM JV                         ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_CONTATO CT                      ");
                SQLQuery.Append("			ON JV.ID_CONTATO = CT.ID_CONTATO                       ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_SITUACAO_IURD_FJU SIFJ          ");
                SQLQuery.Append("		    ON SIFJ.ID_SITUACAO_IURD_FJU = JV.ID_SITUACAO_IURD_FJU ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_DADOSESPIRITUAIS DESP           ");
                SQLQuery.Append("           ON DESP.ID_DADOSESPIRITUAIS = JV.ID_DADOSESPIRITUAIS   ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_IGREJA IGJ                      ");
                SQLQuery.Append("			ON JV.ID_IGREJA = IGJ.ID_IGREJA                        ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_REGIAO REG                      ");
                SQLQuery.Append("			ON IGJ.ID_REGIAO = REG.ID_REGIAO                       ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_BLOCO  BL                       ");
                SQLQuery.Append("		   ON REG.ID_BLOCO = BL.ID_BLOCO                           ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_ESTADO ED                       ");
                SQLQuery.Append("		   ON BL.ID_ESTADO = ED.ID_ESTADO                          ");

                var SQLWhere = new StringBuilder();
                SQLWhere.Append(" WHERE JV.EHPASTOR = 0 ");
                SQLWhere.Append(" AND SIFJ.PERTENCEALTARJOVEM = 'S' ");
                SQLWhere.Append(" AND SIFJ.EHOBREIRO = 'S' ");

                using (conexao = _DAO.GetConnection()){
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString() + SQLWhere.ToString(), ref conexao)) {
                        while (resultadoReader.Read())
                        {
                            retorno.Add(new AltarJovemDTO
                            {
                                IdJovem = int.Parse(resultadoReader["ID_JOVEM"].ToString()),
                                NomeJovem = tinfo.ToTitleCase(resultadoReader["Nome"].ToString()),
                                NomeEstado = tinfo.ToTitleCase(resultadoReader["NOMEESTADO"].ToString()),
                                NomeBlocoJovem = tinfo.ToTitleCase(resultadoReader["NOMEBLOCO"].ToString()),
                                NomeRegiaoJovem = tinfo.ToTitleCase(resultadoReader["NOMEREGIAO"].ToString().ToUpper()),
                                NomeIgrejaJovem = tinfo.ToTitleCase(resultadoReader["NOMEIGREJA"].ToString().ToUpper()),
                                Whatsapp = string.Format("{0:(##) #####-####}", resultadoReader["WHATSAPP"].ToString().Replace('-', ' ').Trim()),
                                WhatsappSemFormatacao = resultadoReader["WHATSAPP"].ToString()
                            });
                        }
                    }
                }

                return retorno;
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "obterIgrejasDaRegiao", dataException.Message);
                throw new DomainException(erroMessage, dataException);
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
        public IList<TodosJovensDTO> ListaJovensLevantadosParaOAltarPorParametro(AltarJovemParametroPesquisaDTO parametrosPesquisa) {
            try {
                var retornoConsultaGeral = new List<TodosJovensDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var SQLQuery = new StringBuilder();
                var SQLWhere = new StringBuilder();
                SQLWhere.Append(" WHERE 1 = 1 ");

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

                SQLWhere.Append(" AND JV.ClassificacaoJovem = 'L' ");

                if (parametrosPesquisa.IdEstado != 0)
                {
                    SQLWhere.Append(" AND ED.ID_ESTADO = " + parametrosPesquisa.IdEstado.ToString() + " ");
                }

                if (parametrosPesquisa.IdBlocoJovem != 0)
                {
                    SQLWhere.Append(" AND BL.ID_BLOCO = " + parametrosPesquisa.IdBlocoJovem.ToString() + " ");
                }

                if (parametrosPesquisa.IdRegiaoJovem != 0)
                {
                    SQLWhere.Append(" AND REG.ID_REGIAO = " + parametrosPesquisa.IdRegiaoJovem.ToString() + " ");
                }

                if (parametrosPesquisa.IdIgreja != 0)
                {
                    SQLWhere.Append(" AND IGJ.ID_IGREJA = " + parametrosPesquisa.IdIgreja.ToString() + " ");
                }

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString() + SQLWhere.ToString(), ref conexao))
                    {
                        while (resultadoReader.Read())
                        {
                            var TELEFONE_FORMATADO = FormataTelefone(resultadoReader["WHATSAPP"].ToString());
                            retornoConsultaGeral.Add(new TodosJovensDTO
                            {
                                IdJovem = int.Parse(resultadoReader["ID_JOVEM"].ToString()),
                                NomeJovem = tinfo.ToTitleCase(resultadoReader["Nome"].ToString()),
                                NomeEstado = tinfo.ToTitleCase(resultadoReader["NOMEESTADO"].ToString()),
                                NomeBlocoJovem = tinfo.ToTitleCase(resultadoReader["NOMEBLOCO"].ToString()),
                                NomeRegiaoJovem = tinfo.ToTitleCase(resultadoReader["NOMEREGIAO"].ToString()),
                                NomeIgrejaJovem = tinfo.ToTitleCase(resultadoReader["NOMEIGREJA"].ToString()),
                                Whatsapp = TELEFONE_FORMATADO,   //string.Format("{0:(##) #####-####}", resultadoReader["WHATSAPP"].ToString().Replace('-', ' ').Trim()),
                                WhatsappSemFormatacao = resultadoReader["WHATSAPP"].ToString(),
                                NomeArquivoFoto = resultadoReader["NOMEARQUIVOFOTO"].ToString(),
                                NomeArquivoFotoFormatado = (!string.IsNullOrEmpty(resultadoReader["NOMEARQUIVOFOTO"].ToString())) ?
                                                              ConfigurationManager.AppSettings["HOST_PROD"] + resultadoReader["NOMEARQUIVOFOTO"].ToString() :
                                                              ConfigurationManager.AppSettings["HOST_PROD"] + "UsuarioNaoSelecionado.png"
                            });
                        }
                    }
                }

                return retornoConsultaGeral;
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
    }
}
