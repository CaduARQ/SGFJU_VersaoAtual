using MySql.Data.MySqlClient;
using NHibernate;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.DataAccess.MySql.Common;
using SGFJU.Domain.Model.Infra.Security;
using SGFJU.Domain.Model.Repositories;
using SGFJU.Domain.Model.ValueObjects;
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
    public class JovemRepositoryImpl : RepositoryImpl<Jovem>, JovemRepository
    {
        private const string NOME_CLASSE = "JovemRepositoryImpl";

        public void SalvarJovem(Jovem                         aggregateRoot,
                                IList<JovemIdioma>            idiomasFaladosJovem,
                                IList<JovemHabilidadeProjeto> habilidadesPossuidasPeloJovem,
                                JovemProjeto                  projetoAQualJovemPertence,
                                Testemunho                    testemunhoDoJovem)
        {            
            using (var session = __sessionFactory.OpenSession()) {
                using (var transaction = session.BeginTransaction()) {
                    try {
                        var data = DateTime.Now.ToString("yyyy-MM-dd");
                        var hora = DateTime.Now.Hour.ToString();
                        var siglaEstado = aggregateRoot.SiglaEstadoJovem;
                        var idJovem = 0;
                        string arquivoFormatadoJovem = "";
                        string arquivoDocumentoAutorizacaoJovem = "";
                        string CODIGO_SGFJU_AUTORIZACAO_COMPRA_CAMISA = $"CASGFJU{idJovem}{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Millisecond}";

                        session.SaveOrUpdate(aggregateRoot.ContatoJovem);
                        session.SaveOrUpdate(aggregateRoot.EnderecoJovem);
                        session.SaveOrUpdate(aggregateRoot.RedeSocialJovem);
                        session.SaveOrUpdate(aggregateRoot.DadosProfissionaisJovem);
                        session.SaveOrUpdate(aggregateRoot.DadosEspirituaisJovem);
                        session.SaveOrUpdate(aggregateRoot.DadosEducacionaisJovem);
                        session.SaveOrUpdate(aggregateRoot.SituacaoJovemIURDFJU);

                        session.SaveOrUpdate(aggregateRoot);

                        idJovem = aggregateRoot.Id;

                        arquivoFormatadoJovem = $"{siglaEstado}_ID_{idJovem}_{data}{hora}_";
                        arquivoDocumentoAutorizacaoJovem = $"DocAutorizacao_{siglaEstado}_ID_{idJovem}_{data}{hora}_";

                        aggregateRoot.NomeArquivoFoto = arquivoFormatadoJovem + aggregateRoot.NomeArquivoFoto;
                        aggregateRoot.NomeArquivoAutorizacao = arquivoDocumentoAutorizacaoJovem + "";

                        if (idiomasFaladosJovem != null) { 
                            foreach (var idioma in idiomasFaladosJovem) {

                                if (idioma.Idioma.Code == 0)
                                    session.Save(idioma.Idioma);

                                session.SaveOrUpdate(idioma);
                            };
                        }

                        if (habilidadesPossuidasPeloJovem != null) { 
                            foreach (var habilidade in habilidadesPossuidasPeloJovem) {

                                if (habilidade.Habilidade.Code == 0) {
                                    session.Save(habilidade.Habilidade);
                                }

                                session.SaveOrUpdate(habilidade);
                            };
                        }

                        if(projetoAQualJovemPertence != null)
                            session.SaveOrUpdate(projetoAQualJovemPertence);

                        if(testemunhoDoJovem != null)
                            session.SaveOrUpdate(testemunhoDoJovem);

                        session.SaveOrUpdate(aggregateRoot);

                        transaction.Commit();
                    }
                    catch (HibernateException ORM_TierException)
                    {
                        transaction.Rollback();
                        var stack = ORM_TierException.StackTrace;
                        var sourceExc = ORM_TierException.Source;
                        var innerExcMsg = ORM_TierException.Message;                        
                        string NOME_METODO = "SalvarJovem";
                        var mensagemErroformatada = "Camada ORM Erro ocorrido \n\n " +
                                                    $" Classe: {NOME_CLASSE}.{NOME_METODO} \n\n" +
                                                    $" StackTrace: {stack}: \n\n" +
                                                    $" Source: {sourceExc}  \n\n" +
                                                    $" Inner Exception Message: {innerExcMsg} \n\n " +
                                                    "--------------------------------------";
                        throw new DomainException(mensagemErroformatada);
                    }
                    catch (Exception repositoryException)
                    {
                        transaction.Rollback();
                        var stack = repositoryException.StackTrace;
                        var sourceExc = repositoryException.Source;
                        var innerExcMsg = repositoryException.Message;
                        string NOME_METODO = "SalvarJovem";
                        var mensagemErroformatada = "Camada ORM Erro ocorrido \n\n " +
                                                    $" Classe: {NOME_CLASSE}.{NOME_METODO} \n\n" +
                                                    $" StackTrace: {stack}: \n\n" +
                                                    $" Source: {sourceExc}  \n\n" +
                                                    $" Inner Exception Message: {innerExcMsg} \n\n " +
                                                    "--------------------------------------";                                                                   
                        var mensagemDetalhada = $"{NOME_CLASSE}.{NOME_METODO} - " + repositoryException.Message;
                        throw new DomainException(mensagemErroformatada);
                    }
                }
            }
        }
        public void AtualizarJovem(Jovem                         aggregateRoot,                            
                                   IList<JovemIdioma>            idiomasFaladosJovem,
                                   IList<JovemIdioma>            idiomasParaExcluirDoJovem,
                                   IList<JovemHabilidadeProjeto> habilidadesPossuidasPeloJovem,
                                   IList<JovemHabilidadeProjeto> habilidadesParaExcluirDoJovem,
                                   JovemProjetoContainer         projetoAQualJovemPertence,
                                   Testemunho                    testemunhoDoJovem){
            using (var session = __sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(aggregateRoot.ContatoJovem);
                        session.SaveOrUpdate(aggregateRoot.EnderecoJovem);
                        session.SaveOrUpdate(aggregateRoot.RedeSocialJovem);
                        session.SaveOrUpdate(aggregateRoot.DadosProfissionaisJovem);
                        session.SaveOrUpdate(aggregateRoot.DadosEspirituaisJovem);
                        session.SaveOrUpdate(aggregateRoot.DadosEducacionaisJovem);
                        session.SaveOrUpdate(aggregateRoot.SituacaoJovemIURDFJU);

                        session.SaveOrUpdate(aggregateRoot);

                        if (idiomasFaladosJovem != null)
                        {
                            foreach (var idioma in idiomasFaladosJovem)
                            {

                                if (idioma.Idioma.Code == 0)
                                    session.Save(idioma.Idioma);

                                session.SaveOrUpdate(idioma);
                            };
                        }

                        if (habilidadesPossuidasPeloJovem != null)
                        {
                            foreach (var habilidade in habilidadesPossuidasPeloJovem)
                            {

                                if (habilidade.Habilidade.Code == 0)
                                {
                                    session.Save(habilidade.Habilidade);
                                }

                                session.SaveOrUpdate(habilidade);
                            };
                        }

                        if (projetoAQualJovemPertence != null) {
                            if (projetoAQualJovemPertence.EmNenhumProjeto){
                                if(projetoAQualJovemPertence.ProjetoAnterior != null)
                                    session.Delete(projetoAQualJovemPertence.ProjetoAnterior);
                            }
                            else if (projetoAQualJovemPertence.PassouATerProjeto){                                
                                session.SaveOrUpdate(projetoAQualJovemPertence.ProjetoAtual);
                            }
                            else if (projetoAQualJovemPertence.DeixouOProjeto){
                                if (projetoAQualJovemPertence.ProjetoAnterior != null)
                                    session.Delete(projetoAQualJovemPertence.ProjetoAnterior);
                            }
                            else if (projetoAQualJovemPertence.ProjetoAnteriorMudou){
                                session.Delete(projetoAQualJovemPertence.ProjetoAnterior);
                                session.SaveOrUpdate(projetoAQualJovemPertence.ProjetoAtual);
                            }
                            else {
                                //session.SaveOrUpdate(projetoAQualJovemPertence.ProjetoAnterior);
                                session.SaveOrUpdate(projetoAQualJovemPertence.ProjetoAtual);
                            }
                        }

                        if (testemunhoDoJovem != null)
                            session.SaveOrUpdate(testemunhoDoJovem);

                        if (habilidadesParaExcluirDoJovem != null) {
                            if (habilidadesParaExcluirDoJovem.Count > 0) {
                                foreach (var habilidadeParaExcluir in habilidadesParaExcluirDoJovem) {
                                    session.Delete(habilidadeParaExcluir);
                                }
                            }
                        }

                        if (idiomasParaExcluirDoJovem != null) {
                            if (idiomasParaExcluirDoJovem.Count > 0) {
                                foreach (var idiomaParaExcluir in idiomasParaExcluirDoJovem) {
                                    session.Delete(idiomaParaExcluir);
                                }
                            }
                        }

                        transaction.Commit();
                    }
                    catch (HibernateException ORM_TierException) {
                        transaction.Rollback();
                        var stack = ORM_TierException.StackTrace;
                        var sourceExc = ORM_TierException.Source;
                        var innerExcMsg = ORM_TierException.Message;
                        string NOME_METODO = "AtualizarJovem";
                        var mensagemErroformatada = "Camada ORM Erro ocorrido \n\n " +
                                                    $" Classe: {NOME_CLASSE}.{NOME_METODO} \n\n" +
                                                    $" StackTrace: {stack}: \n\n" +
                                                    $" Source: {sourceExc}  \n\n" +
                                                    $" Inner Exception Message: {innerExcMsg} \n\n " +
                                                    "--------------------------------------";
                        throw new DomainException(mensagemErroformatada);
                    }
                    catch (Exception repositoryException) {
                        transaction.Rollback();
                        var stack = repositoryException.StackTrace;
                        var sourceExc = repositoryException.Source;
                        var innerExcMsg = repositoryException.Message;
                        string NOME_METODO = "AtualizarJovem";
                        var mensagemErroformatada = "Camada ORM Erro ocorrido \n\n " +
                                                    $" Classe: {NOME_CLASSE}.{NOME_METODO} \n\n" +
                                                    $" StackTrace: {stack}: \n\n" +
                                                    $" Source: {sourceExc}  \n\n" +
                                                    $" Inner Exception Message: {innerExcMsg} \n\n " +
                                                    "--------------------------------------";
                        var mensagemDetalhada = $"{NOME_CLASSE}.{NOME_METODO} - " + repositoryException.Message;
                        throw new DomainException(mensagemErroformatada);
                    }
                }
            }
        }
        public void TransferirJovem(TodosJovensDTO jovemParaTranferir) {
            using (var session = __sessionFactory.OpenSession()) {
                using (var transaction = session.BeginTransaction()) {
                    try {
                        var entityForTranfer = session.Get<Jovem>(jovemParaTranferir.IdJovem);
                        entityForTranfer.IgrejaAQualJovemPertence = new Igreja { Id = jovemParaTranferir.IdIgreja };
                        session.SaveOrUpdate(entityForTranfer);
                        transaction.Commit();
                    }
                    catch (Exception exception)
                    {
                        var stack = exception.StackTrace;
                        var sourceExc = exception.Source;
                        var innerExcStr = exception.Message;
                        var mensagemErroformatada = "Camada ORM Erro ocorrido \n\n " +
                                                    $" StackTrace: {stack}: \n\n" +
                                                    $" Source: {sourceExc}  \n\n" +
                                                    $" Inner Exception: {innerExcStr} \n\n " +
                                                    "--------------------------------------";
                        transaction.Rollback();
                        string NOME_METODO = "TranferirJovem";
                        var mensagemDetalhada = $"{NOME_CLASSE}.{NOME_METODO} - " + exception.Message;
                        throw new DomainException(mensagemErroformatada);
                    }
                }
            }
        }
        public void TransferirJovensEntreIgrejas(int idIgrejaOrigem, int idIgrejaDestino, bool tranferirTodos, IList<TodosJovensDTO> jovensParaTransferir, int idUsuarioTranferiu) {
            try {
                var _DAO = new DAO();
                var comandosDeAtualizacao = new List<string>();
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var SQLQuery = new StringBuilder();

                SQLQuery.Append("  SELECT JV.ID_JOVEM,                          ");
                SQLQuery.Append("         IGJ.ID_IGREJA                         ");
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

                var SQLWhere = new StringBuilder();
                SQLWhere.Append(" WHERE 1 = 1 ");

                SQLWhere.Append(" AND IGJ.ID_IGREJA = " + idIgrejaOrigem + " ");

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();

                    if (tranferirTodos) {
                        using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString() + SQLWhere.ToString(), ref conexao)) {
                            while (resultadoReader.Read()){
                                var _SQL_UPDATE_JOVEM = $"UPDATE SGFJU_DEV.SGFJU_TBL_JOVEM SET ID_IGREJA = {idIgrejaDestino} WHERE ID_JOVEM = " + resultadoReader["ID_JOVEM"].ToString();
                                var _SQL_INSERE_HISTORICO_TRANSFERENCIA =
                                    "INSERT INTO `sgfju_dev`.`sgfju_tbl_historico_transferencia_jovem` " +
                                    "(`ID_JOVEM`, " +
                                    "`ID_IGREJA_ORIGEM`, " +
                                    "`ID_IGREJA_DESTINO`, " +
                                    "`ID_USUARIO_REALIZOU_TRANSFERENCIA`, " +
                                    "`DataTransferencia`) " +
                                    "VALUES" +
                                    $"({ resultadoReader["ID_JOVEM"].ToString() }," +
                                    $" { resultadoReader["ID_IGREJA"].ToString() }," +
                                    $" { idIgrejaDestino }," +
                                    $" { idUsuarioTranferiu }," +
                                    $" '{ DateTime.Now.ToString("yyyy-MM-dd") }') ;" ;
                                comandosDeAtualizacao.Add(_SQL_UPDATE_JOVEM);
                                comandosDeAtualizacao.Add(_SQL_INSERE_HISTORICO_TRANSFERENCIA);
                            }
                            resultadoReader.Close();
                        
                            _DAO.ExecuteNonQuery(conexao, comandosDeAtualizacao);
                        }
                    }
                    else {
                        foreach (var jovemEmTransferencia in jovensParaTransferir){
                            var _SQL_UPDATE_JOVEM = $"UPDATE SGFJU_DEV.SGFJU_TBL_JOVEM SET ID_IGREJA = {idIgrejaDestino} WHERE ID_JOVEM = " + jovemEmTransferencia.IdJovem;
                            var _SQL_INSERE_HISTORICO_TRANSFERENCIA =
                                    "INSERT INTO `sgfju_dev`.`sgfju_tbl_historico_transferencia_jovem` " +
                                    "(`ID_JOVEM`, " +
                                    "`ID_IGREJA_ORIGEM`, " +
                                    "`ID_IGREJA_DESTINO`, " +
                                    "`ID_USUARIO_REALIZOU_TRANSFERENCIA`, " +
                                    "`DataTransferencia`) " +
                                    "VALUES " +
                                    $"({ jovemEmTransferencia.IdJovem }," +
                                    $" { idIgrejaOrigem }," +
                                    $" { idIgrejaDestino }," +
                                    $" { idUsuarioTranferiu }," +
                                    $" '{ DateTime.Now.ToString("yyyy-MM-dd") }' );";
                            comandosDeAtualizacao.Add(_SQL_UPDATE_JOVEM);
                            comandosDeAtualizacao.Add(_SQL_INSERE_HISTORICO_TRANSFERENCIA);
                        }
                        _DAO.ExecuteNonQuery(conexao, comandosDeAtualizacao);
                    }
                }
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }

        public IList<HistoricoTransferenciaDTO> ObterHistoricoTransferenciasRealizadas() {
            try {
                var _DAO = new DAO();
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var listaDeRetorno = new List<HistoricoTransferenciaDTO>();
                var SQLQuery = "SELECT JV.ID_JOVEM, " +
                                "       JV.NOME, " +
                                "       IJG_O.ID_IGREJA AS 'ID_IGREJA_ORIGEM' , " +
                                "       IJG_O.NOMEIGREJA AS 'NOME_IGREJA_ORIGEM', " +
                                "       IJG_D.ID_IGREJA AS 'ID_IGREJA_DESTINO' , " +
                                "       IJG_D.NOMEIGREJA AS 'NOME_IGREJA_DESTINO', " +
                                "       HJV.DATATRANSFERENCIA " +
                                "   FROM sgfju_dev.sgfju_tbl_historico_transferencia_jovem hjv " +
                                " INNER JOIN SGFJU_DEV.SGFJU_TBL_JOVEM JV " +
                                "         ON hjv.ID_JOVEM = jv.ID_JOVEM " +
                                " INNER JOIN SGFJU_DEV.SGFJU_TBL_IGREJA IJG_O " +
                                "         ON HJV.ID_IGREJA_ORIGEM = IJG_O.ID_IGREJA " +
                                " INNER JOIN SGFJU_DEV.SGFJU_TBL_IGREJA IJG_D " +
                                "         ON HJV.ID_IGREJA_DESTINO = IJG_D.ID_IGREJA; ";


                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();

                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString(), ref conexao)) {
                        while (resultadoReader.Read()) {
                            listaDeRetorno.Add(new HistoricoTransferenciaDTO {
                                IdJovem = int.Parse(resultadoReader["ID_JOVEM"].ToString()),
                                NomeJovem = resultadoReader["NOME"].ToString(),
                                IdIgrejaOrigem = int.Parse(resultadoReader["ID_IGREJA_ORIGEM"].ToString()),
                                NomeIgrejaOrigem = resultadoReader["NOME_IGREJA_ORIGEM"].ToString(),
                                IdIgrejaDestino = int.Parse(resultadoReader["ID_IGREJA_DESTINO"].ToString()),
                                NomeIgrejaDestino = resultadoReader["NOME_IGREJA_DESTINO"].ToString(),
                                DataTransferencia = DateTime.Parse(resultadoReader["DATATRANSFERENCIA"].ToString()).ToString("dd/MM/yyyy")                                
                            });
                        }
                    }
                }

                return listaDeRetorno;
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
        public IList<HistoricoTransferenciaDTO> ObterHistoricoTransferenciasRealizadasPorParametro(ParametroPesquisaHistoricoTransferenciaDTO parametroPesquisa) {
            try
            {
                var _DAO = new DAO();
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var listaDeRetorno = new List<HistoricoTransferenciaDTO>();
                var SQLQuery = "SELECT JV.ID_JOVEM, " +
                                "       JV.NOME, " +
                                "       IJG_O.ID_IGREJA AS 'ID_IGREJA_ORIGEM' , " +
                                "       IJG_O.NOMEIGREJA AS 'NOME_IGREJA_ORIGEM', " +
                                "       IJG_D.ID_IGREJA AS 'ID_IGREJA_DESTINO' , " +
                                "       IJG_D.NOMEIGREJA AS 'NOME_IGREJA_DESTINO', " +
                                "       HJV.DATATRANSFERENCIA " +
                                "   FROM sgfju_dev.sgfju_tbl_historico_transferencia_jovem hjv " +
                                " INNER JOIN SGFJU_DEV.SGFJU_TBL_JOVEM JV " +
                                "         ON hjv.ID_JOVEM = jv.ID_JOVEM " +
                                " INNER JOIN SGFJU_DEV.SGFJU_TBL_IGREJA IJG_O " +
                                "         ON HJV.ID_IGREJA_ORIGEM = IJG_O.ID_IGREJA " +
                                " INNER JOIN SGFJU_DEV.SGFJU_TBL_IGREJA IJG_D " +
                                "         ON HJV.ID_IGREJA_DESTINO = IJG_D.ID_IGREJA " +
                                " WHERE 1=1 ";

                if (parametroPesquisa.IdJovem != 0) {
                    SQLQuery += $" AND JV.ID_JOVEM = {parametroPesquisa.IdJovem} ";
                }

                if (parametroPesquisa.IdUsuarioRealizouTransferencia != 0) {
                    SQLQuery += $" AND HJV.ID_USUARIO_REALIZOU_TRANSFERENCIA = {parametroPesquisa.IdUsuarioRealizouTransferencia} ";
                }

                if (parametroPesquisa.IdIgrejaOrigem != 0) {
                    SQLQuery += $" AND HJV.ID_IGREJA_ORIGEM = {parametroPesquisa.IdIgrejaOrigem} ";
                }

                if (parametroPesquisa.IdIgrejaDestino != 0) {
                    SQLQuery += $" AND HJV.ID_IGREJA_DESTINO = {parametroPesquisa.IdIgrejaDestino} ";
                }

                if (!string.IsNullOrEmpty(parametroPesquisa.DataTransferencia)) {
                    SQLQuery += $" AND DATE(HJV.DATATRANSFERENCIA) = '{parametroPesquisa.DataTransferencia}' ";
                }

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();

                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString(), ref conexao)) {
                        while (resultadoReader.Read()) {
                            listaDeRetorno.Add(new HistoricoTransferenciaDTO {
                                IdJovem = int.Parse(resultadoReader["ID_JOVEM"].ToString()),
                                NomeJovem = resultadoReader["NOME"].ToString(),
                                IdIgrejaOrigem = int.Parse(resultadoReader["ID_IGREJA_ORIGEM"].ToString()),
                                NomeIgrejaOrigem = resultadoReader["NOME_IGREJA_ORIGEM"].ToString(),
                                IdIgrejaDestino = int.Parse(resultadoReader["ID_IGREJA_DESTINO"].ToString()),
                                NomeIgrejaDestino = resultadoReader["NOME_IGREJA_DESTINO"].ToString(),
                                DataTransferencia = DateTime.Parse(resultadoReader["DATATRANSFERENCIA"].ToString()).ToString("dd/MM/yyyy")
                            });
                        }
                    }
                }

                return listaDeRetorno;
            }
            catch (Exception dataException)
            {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "obterIgrejasDaRegiao", dataException.Message);
                throw new DomainException(erroMessage, dataException);
            }
        }
        public void ExcluirInformacoesJovem(Jovem jovemParaExcluir){
            try {
                var _DAO = new DAO();
                var comandosDeExclusao = new List<string> {
                    "DELETE FROM SGFJU_DEV.SGFJU_TBL_JOVEM_HABILIDADE WHERE ID_JOVEM =" + jovemParaExcluir.Id,
                    "DELETE FROM SGFJU_DEV.SGFJU_TBL_JOVEM_PROJETO WHERE ID_JOVEM = " + jovemParaExcluir.Id,
                    "DELETE FROM SGFJU_DEV.SGFJU_TBL_JOVEM_IDIOMA WHERE ID_JOVEM = " + jovemParaExcluir.Id,
                    "DELETE FROM SGFJU_DEV.SGFJU_TBL_TESTEMUNHO WHERE ID_JOVEM = " + jovemParaExcluir.Id,
                    "DELETE FROM SGFJU_DEV.SGFJU_TBL_JOVEM_LIVROLIDO WHERE JOVEM_ID = " + jovemParaExcluir.Id,
                    "DELETE FROM SGFJU_DEV.SGFJU_TBL_JOVEM_REUNIAOFJU WHERE JOVEM_ID = " + jovemParaExcluir.Id,
                    "DELETE FROM SGFJU_DEV.SGFJU_TBL_JOVEM_CURSO_REL_PROJ WHERE ID_JOVEM = " + jovemParaExcluir.Id,
                    "DELETE FROM SGFJU_DEV.SGFJU_TBL_JOVEM_DEPTO_PROJETO WHERE JOVEM_ID = " + jovemParaExcluir.Id,
                    "DELETE FROM SGFJU_DEV.SGFJU_TBL_JOVEM WHERE ID_JOVEM = " + jovemParaExcluir.Id
                };

                _DAO.ExecuteNonQuery(comandosDeExclusao);
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "obterIgrejasDaRegiao", dataException.Message);
                throw new DomainException(erroMessage, dataException);
            }
        }
        public IList<Jovem> ObterJovensPorBloco(Bloco blocoParametro)
        {
            throw new NotImplementedException();
        }
        public IList<Jovem> ObterJovensPorEstado(Estado estadoParametro)
        {
            try {
                using (var session = __sessionFactory.OpenSession()) {
                    var HQLQuery = string
                                      .Format("select jov " +
                                              "  from Jovem      as jov " +
                                              " inner join jov.IgrejaAQualJovemPertence  as ig " +
                                              " inner join ig.RegiaoIgreja              as reg " +
                                              " inner join reg.BlocoRegiao              as bl " +
                                              " where bl.EstadoBloco.Id = {0} ", estadoParametro.Id.ToString());
                    return session.CreateQuery(HQLQuery)
                                  .List<Jovem>();
                }
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "obterIgrejasDaRegiao", dataException.Message);
                throw new DomainException(erroMessage, dataException);
            }
        }
        public IList<Jovem> ObterJovensPorRegiao(Regiao regiaoParametro){
            throw new NotImplementedException();
        }
        public IList<Jovem> ObterPorParametro(ParametroPesquisaDetalhadaDTO parametroPesquisaDetalhada){
            throw new NotImplementedException();
        }

        public IList<TodosJovensDTO> ObterJovensPorParametro(ParametroPesquisaTodosJovensDTO parametrosPesquisa) {
            try {
                var retornoConsultaGeral = new List<TodosJovensDTO>();


                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var SQLQuery = new StringBuilder();
                SQLQuery.Append("  SELECT JV.ID_JOVEM,                          ");
                SQLQuery.Append("         JV.NOME,                              ");
                SQLQuery.Append("         JV.DATANASCIMENTO,                    ");
                SQLQuery.Append("         JV.NOMEARQUIVOFOTO,                   ");
                SQLQuery.Append("         JV.DATACADASTRO,                      ");
                SQLQuery.Append("         ED.ID_ESTADO,                         ");
                SQLQuery.Append("         ED.NOMEESTADO,                        ");
                SQLQuery.Append("         BL.ID_BLOCO,                          ");
                SQLQuery.Append("         BL.NOMEBLOCO,                         ");
                SQLQuery.Append("         REG.ID_REGIAO,                        ");
                SQLQuery.Append("         REG.NOMEREGIAO,                       ");
                SQLQuery.Append("         IGJ.ID_IGREJA,                        ");
                SQLQuery.Append("         IGJ.NOMEIGREJA,                       ");
                SQLQuery.Append("         CT.WHATSAPP,                           ");
                SQLQuery.Append("         AVJB.ID_OBREIRO                        "); 
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
                SQLQuery.Append("   LEFT JOIN sgfju_dev.SGFJU_TBL_ARVOREVIDA_JOVEMOBREIRO AVJB    ");
                SQLQuery.Append("		   ON JV.ID_JOVEM = AVJB.ID_JOVEM       ");

                var SQLWhere = new StringBuilder();
                SQLWhere.Append(" WHERE 1 = 1 ");

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

                if (parametrosPesquisa.EhParaListarFichasExpiradas == 'S') {
                    SQLWhere.Append(" AND ( TIMESTAMPDIFF(month, NOW(), DATAULTIMAATUALIZACAO) >= 6 OR DATAULTIMAATUALIZACAO IS NULL ) ");
                }

                using (conexao = _DAO.GetConnection()){
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString() + SQLWhere.ToString() + " ORDER BY JV.DATACADASTRO DESC", ref conexao)) {                        
                        while (resultadoReader.Read()){
                            var TELEFONE_FORMATADO = FormataTelefone(resultadoReader["WHATSAPP"].ToString());
                            retornoConsultaGeral.Add(new TodosJovensDTO { 
                                IdJovem               = int.Parse(resultadoReader["ID_JOVEM"].ToString()),
                                IdX                   = EncryptionHelper.Encrypt(resultadoReader["ID_JOVEM"].ToString()),
                                NomeJovem             = tinfo.ToTitleCase( resultadoReader["Nome"].ToString()       ),
                                DataNascimento        = resultadoReader["DATANASCIMENTO"].ToString(),
                                IdEstado              = int.Parse(resultadoReader["ID_ESTADO"].ToString()),
                                NomeEstado            = tinfo.ToTitleCase( resultadoReader["NOMEESTADO"].ToString() ),
                                IdBlocoJovem          = int.Parse(resultadoReader["ID_BLOCO"].ToString()),
                                NomeBlocoJovem        = tinfo.ToTitleCase( resultadoReader["NOMEBLOCO"].ToString()  ),
                                IdRegiaoJovem         = int.Parse(resultadoReader["ID_REGIAO"].ToString()),
                                NomeRegiaoJovem       = tinfo.ToTitleCase( resultadoReader["NOMEREGIAO"].ToString() ),
                                IdIgreja              = int.Parse(resultadoReader["ID_IGREJA"].ToString()),
                                NomeIgrejaJovem       = tinfo.ToTitleCase( resultadoReader["NOMEIGREJA"].ToString() ),
                                Whatsapp              = TELEFONE_FORMATADO,   //string.Format("{0:(##) #####-####}", resultadoReader["WHATSAPP"].ToString().Replace('-', ' ').Trim()),
                                WhatsappSemFormatacao = resultadoReader["WHATSAPP"].ToString(),
                                NomeArquivoFoto = resultadoReader["NOMEARQUIVOFOTO"].ToString(),
                                EstaSendoAcompanhadoAV = (!resultadoReader.IsDBNull(resultadoReader.GetOrdinal("ID_OBREIRO"))) ?
                                                                         true : false,
                                IdObreiroAcompanha = (!resultadoReader.IsDBNull(resultadoReader.GetOrdinal("ID_OBREIRO"))) ?
                                                                         int.Parse(resultadoReader["ID_OBREIRO"].ToString()) : 0
                            });
                        }
                    }
                }

                return retornoConsultaGeral;
            }
            catch(HibernateException hibernateExc) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(hibernateExc, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, hibernateExc);
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
        public Testemunho ObterTestemunhoDoJovem(Jovem jovemParametro) {
            try
            {
                using (var session = __sessionFactory.OpenSession())
                {
                    var HQLQuery = string
                                      .Format("select tes " +
                                              "  from Testemunho as tes " +
                                              " where tes.JovemTestemunho.Id = {0} ", jovemParametro.Id.ToString());
                    return session.CreateQuery(HQLQuery)
                                  .UniqueResult<Testemunho>();
                }
            }
            catch (Exception dataException)
            {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "ObterTestemunhoDoJovem", dataException.Message);
                throw new DomainException(erroMessage, dataException);
            }
        }

        public JovemDTO ObterJovemInformacoesDetalhadas(Jovem jovemParametro) {
            try {
                JovemDTO jovemRetorno = null;

                using (var session = __sessionFactory.OpenSession()) {
                    var jovemRetornadoBanco = session.Get<Jovem>(jovemParametro.Id);

                    if (jovemRetornadoBanco != null) {

                        var mesAnoChegadaIURD = "";
                        var tempoEstaFirme = "";
                        var chegadaNafju = "";
                        var mesAnoBatismoAguas = "";
                        var mesAnoBatismoEspiritoSanto = "";

                        mesAnoChegadaIURD = formataMesAno(jovemRetornadoBanco.DadosEspirituaisJovem.MesAnoChegadaIURD);
                        tempoEstaFirme = formataMesAno(jovemRetornadoBanco.DadosEspirituaisJovem.TempoEstaFirme);
                        chegadaNafju = formataMesAno(jovemRetornadoBanco.DadosEspirituaisJovem.MesAnoEntradaFJU);
                        mesAnoBatismoAguas = formataMesAno(jovemRetornadoBanco.DadosEspirituaisJovem.MesAnoBatismoAguas);
                        mesAnoBatismoEspiritoSanto = formataMesAno(jovemRetornadoBanco.DadosEspirituaisJovem.MesAnoBatismoEspiritoSanto);

                        jovemRetorno = new JovemDTO {
                            ContatoJovem = new ContatoDTO {
                                Code                  = jovemRetornadoBanco.ContatoJovem.Code,
                                Whatsapp              = jovemRetornadoBanco.ContatoJovem.Whatsapp,
                                TelefoneFixo          = jovemRetornadoBanco.ContatoJovem.TelefoneFixo,
                                TelefoneEmergencia    = jovemRetornadoBanco.ContatoJovem.TelefoneEmergencia,
                                NomeContatoEmergencia = jovemRetornadoBanco.ContatoJovem.NomeContatoEmergencia
                            },
                            EnderecoJovem = new EnderecoDTO {
                                Code              = jovemRetornadoBanco.EnderecoJovem.Code,
                                DescricaoEndereco = jovemRetornadoBanco.EnderecoJovem.DescricaoEndereco,
                                Bairro            = jovemRetornadoBanco.EnderecoJovem.Bairro,
                                Cidade            = jovemRetornadoBanco.EnderecoJovem.Cidade,
                                idTipoDeMoradia   = (jovemRetornadoBanco.EnderecoJovem.TipoDeMoradia != null) ?jovemRetornadoBanco.EnderecoJovem.TipoDeMoradia.Code:0,
                                DescricaoTipoDeMoradia = (jovemRetornadoBanco.EnderecoJovem.TipoDeMoradia != null) ? jovemRetornadoBanco.EnderecoJovem.TipoDeMoradia.Descricao : "",
                            },
                            RedeSocialJovem = new RedeSocialDTO {
                                Code                     = jovemRetornadoBanco.RedeSocialJovem.Code,
                                Email                    = jovemRetornadoBanco.RedeSocialJovem.Email,
                                Instagram                = jovemRetornadoBanco.RedeSocialJovem.Instagram,
                                Facebook                 = jovemRetornadoBanco.RedeSocialJovem.Facebook,
                                Twitter                  = jovemRetornadoBanco.RedeSocialJovem.Twitter,
                                EhLeitorBlogBM           = jovemRetornadoBanco.RedeSocialJovem.EhLeitorBlogBM,
                                EhAssinanteUNIVER        = jovemRetornadoBanco.RedeSocialJovem.EhAssinanteUNIVER,
                                EhLeitorUniversalorg     = jovemRetornadoBanco.RedeSocialJovem.EhLeitorUniversalorg,
                                EhSeguidorOficialFJU     = jovemRetornadoBanco.RedeSocialJovem.EhSeguidorOficialFJU,
                                EhSeguidorTelegram       = jovemRetornadoBanco.RedeSocialJovem.EhSeguidorTelegram,
                                EhSeguidorYoutube        = jovemRetornadoBanco.RedeSocialJovem.EhSeguidorYoutube,
                                PossuiCelularComInternet = jovemRetornadoBanco.RedeSocialJovem.PossuiCelularComInternet,
                                FrequenciaAssisteUNIVER  = jovemRetornadoBanco.RedeSocialJovem.FrequenciaAssisteUNIVER,
                                PossuiComputador         = jovemRetornadoBanco.RedeSocialJovem.PossuiComputador
                            },
                            DadosProfissionaisJovem = new DadosProfissionaisDTO {
                                Code               = jovemRetornadoBanco.DadosProfissionaisJovem.Code,
                                NomeEmpresa        = jovemRetornadoBanco.DadosProfissionaisJovem.NomeEmpresa,
                                TrabalhaAtualmente = jovemRetornadoBanco.DadosProfissionaisJovem.TrabalhaAtualmente,
                                Profissao          = jovemRetornadoBanco.DadosProfissionaisJovem.Profissao
                            },
                            DadosEspirituaisJovem = new DadosEspirituaisDTO {
                                Code                        = jovemRetornadoBanco.DadosEspirituaisJovem.Code,
                                EhMembroIURD                = jovemRetornadoBanco.DadosEspirituaisJovem.EhMembroIURD,
                                MesAnoChegadaIURD           = mesAnoChegadaIURD,
                                AnoChegadaiurd              = jovemRetornadoBanco.DadosEspirituaisJovem.AnoChegadaiurd,
                                MesChegadaiurd              = jovemRetornadoBanco.DadosEspirituaisJovem.MesChegadaiurd,
                                ComoConheceuIURD            = jovemRetornadoBanco.DadosEspirituaisJovem.ComoConheceuIURD,
                                JaSeAfastou                 = jovemRetornadoBanco.DadosEspirituaisJovem.JaSeAfastou,
                                MotivoSeAfastou             = jovemRetornadoBanco.DadosEspirituaisJovem.MotivoSeAfastou,
                                TempoEstaFirme              = tempoEstaFirme,//
                                TempoAfastamento            = jovemRetornadoBanco.DadosEspirituaisJovem.TempoAfastamento,
                                MesAnoAfastamento           = jovemRetornadoBanco.DadosEspirituaisJovem.MesAnoAfastamento,
                                BatismoAguasIURD            = jovemRetornadoBanco.DadosEspirituaisJovem.BatismoAguasIURD,
                                EhBatizadoAguas             = jovemRetornadoBanco.DadosEspirituaisJovem.EhBatizadoAguas,
                                MesAnoBatismoAguas          = mesAnoBatismoAguas,//jovemRetornadoBanco.DadosEspirituaisJovem.MesAnoBatismoAguas,//
                                EhBatizadoEspiritoSanto     = jovemRetornadoBanco.DadosEspirituaisJovem.EhBatizadoEspiritoSanto,
                                MesAnoBatismoEspiritoSanto  = mesAnoBatismoEspiritoSanto,//jovemRetornadoBanco.DadosEspirituaisJovem.MesAnoBatismoEspiritoSanto,//
                                OcasiaoBatismoEspiritoSanto = jovemRetornadoBanco.DadosEspirituaisJovem.OcasiaoBatismoEspiritoSanto,
                                TemFamiliaresIURD           = jovemRetornadoBanco.DadosEspirituaisJovem.TemFamiliaresIURD,
                                DescricaoFamiliaresIURD     = jovemRetornadoBanco.DadosEspirituaisJovem.DescricaoFamiliaresIURD,
                                DescricaoModoChegouFJU      = jovemRetornadoBanco.DadosEspirituaisJovem.DescricaoModoChegouFJU,
                                MotivoEntradaFJU            = jovemRetornadoBanco.DadosEspirituaisJovem.MotivoEntradaFJU,
                                MesAnoEntradaFJU            = chegadaNafju,//jovemRetornadoBanco.DadosEspirituaisJovem.MesAnoEntradaFJU,//
                                idFrequenciaLeituraBiblia   = (jovemRetornadoBanco.DadosEspirituaisJovem.FrequenciaLeituraBiblia != null) ? jovemRetornadoBanco.DadosEspirituaisJovem.FrequenciaLeituraBiblia.Code : 0,
                                LeuTodaBiblia               = jovemRetornadoBanco.DadosEspirituaisJovem.LeuTodaBiblia,
                                PossuiBiblia                = jovemRetornadoBanco.DadosEspirituaisJovem.PossuiBiblia,
                                PossuiBibliaNoCelular       = jovemRetornadoBanco.DadosEspirituaisJovem.PossuiBibliaNoCelular
                            },
                            DadosEducacionaisJovem = new DadosEducacionaisDTO {
                                Code                              = jovemRetornadoBanco.DadosEducacionaisJovem.Code,
                                GrauEscolaridade                  = jovemRetornadoBanco.DadosEducacionaisJovem.GrauEscolaridade,
                                EstudaAtualmente                  = jovemRetornadoBanco.DadosEducacionaisJovem.EstudaAtualmente,
                                NomeInstituicaoEnsino             = jovemRetornadoBanco.DadosEducacionaisJovem.NomeInstituicaoEnsino,
                                NomeCursoSuperior                 = jovemRetornadoBanco.DadosEducacionaisJovem.NomeCursoSuperior,
                                DesejaCursarNivelSuperior         = jovemRetornadoBanco.DadosEducacionaisJovem.DesejaCursarNivelSuperior,
                                idModalidadeCursadaEnsinoSuperior = (jovemRetornadoBanco.DadosEducacionaisJovem.ModalidadeCursadaEnsinoSuperior != null) ? jovemRetornadoBanco.DadosEducacionaisJovem.ModalidadeCursadaEnsinoSuperior.Code : 0,
                                PeriodoAtualNivelFaculdade        = jovemRetornadoBanco.DadosEducacionaisJovem.PeriodoAtualNivelFaculdade,
                                PossuiNivelSuperior               = jovemRetornadoBanco.DadosEducacionaisJovem.PossuiNivelSuperior,                                
                                PrevisaoConclusaoCurso            = jovemRetornadoBanco.DadosEducacionaisJovem.PrevisaoConclusaoCurso
                            },
                            SituacaoJovemIURDFJU = new SituacaoIURDFJUDTO {
                                Code                    = jovemRetornadoBanco.SituacaoJovemIURDFJU.Code,
                                EhObreiro               = jovemRetornadoBanco.SituacaoJovemIURDFJU.EhObreiro,
                                AnosObreiro             = jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosObreiro,
                                MesesObreiro            = jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesObreiro,
                                EhColaborador           = jovemRetornadoBanco.SituacaoJovemIURDFJU.EhColaborador,
                                MesesColaborador        = jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesColaborador,
                                AnosColaborador         = jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosColaborador,
                                MesAnoInicioCPO         = jovemRetornadoBanco.SituacaoJovemIURDFJU.MesAnoInicioCPO,
                                EstaCursandoCPO         = jovemRetornadoBanco.SituacaoJovemIURDFJU.EstaCursandoCPO,
                                EhPertencenteFJU        = jovemRetornadoBanco.SituacaoJovemIURDFJU.EhPertencenteFJU,
                                EhCoordenadorFJU        = jovemRetornadoBanco.SituacaoJovemIURDFJU.EhCoordenadorFJU,
                                MesAnoCoordenandoFJU    = jovemRetornadoBanco.SituacaoJovemIURDFJU.MesAnoCoordenandoFJU,
                                MesesCoordenandoFJU     = jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesCoordenandoFJU,
                                AnosCoordenandoFJU      = jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosCoordenandoFJU,
                                EhLiderTribo            = jovemRetornadoBanco.SituacaoJovemIURDFJU.EhLiderTribo,
                                idTriboQueLidera        = (jovemRetornadoBanco.SituacaoJovemIURDFJU.TriboQueLidera != null) ? jovemRetornadoBanco.SituacaoJovemIURDFJU.TriboQueLidera.Code : 0,
                                PeriodoCoordenandoTribo = jovemRetornadoBanco.SituacaoJovemIURDFJU.PeriodoCoordenandoTribo,
                                MesesCoordenandoTribo   = jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesCoordenandoTribo,
                                AnosCoordenandoTribo    = jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosCoordenandoTribo,

                                EhLiderProjeto            = jovemRetornadoBanco.SituacaoJovemIURDFJU.EhLiderProjeto,
                                idProjetoQueCoordena      = (jovemRetornadoBanco.SituacaoJovemIURDFJU.ProjetoQueCoordena != null) ? jovemRetornadoBanco.SituacaoJovemIURDFJU.ProjetoQueCoordena.Code : 0,
                                PeriodoCoordenandoProjeto = jovemRetornadoBanco.SituacaoJovemIURDFJU.PeriodoCoordenandoProjeto,
                                MesesCoordenandoProjeto   = jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesCoordenandoProjeto,
                                AnosCoordenandoProjeto    = jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosCoordenandoProjeto,

                                PossuiCamisaProjeto        = jovemRetornadoBanco.SituacaoJovemIURDFJU.PossuiCamisaProjeto,
                                NomeCamisaFJU              = jovemRetornadoBanco.SituacaoJovemIURDFJU.NomeCamisaFJU,
                                TamanhoCamisa              = jovemRetornadoBanco.SituacaoJovemIURDFJU.TamanhoCamisa,
                                FoiObreiro                 = jovemRetornadoBanco.SituacaoJovemIURDFJU.FoiObreiro,
                                MotivoSaiuObreiro          = jovemRetornadoBanco.SituacaoJovemIURDFJU.MotivoSaiuObreiro,
                                FoiPastor                  = jovemRetornadoBanco.SituacaoJovemIURDFJU.FoiPastor,
                                MotivoSaidaPastor          = jovemRetornadoBanco.SituacaoJovemIURDFJU.MotivoSaidaPastor,
                                DesejaSerObreiro           = jovemRetornadoBanco.SituacaoJovemIURDFJU.DesejaSerObreiro,
                                MotivoDesejaSerObreiro     = jovemRetornadoBanco.SituacaoJovemIURDFJU.MotivoDesejaSerObreiro,
                                DesejaFazerObraNoAltar     = jovemRetornadoBanco.SituacaoJovemIURDFJU.DesejaFazerObraNoAltar,
                                PertenceAltarJovem         = jovemRetornadoBanco.SituacaoJovemIURDFJU.PertenceAltarJovem,
                                PertenceIntellimen         = jovemRetornadoBanco.SituacaoJovemIURDFJU.PertenceIntellimen,
                                DesafiosConcluidos         = jovemRetornadoBanco.SituacaoJovemIURDFJU.DesafiosConcluidos,
                                DesafioAtual               = jovemRetornadoBanco.SituacaoJovemIURDFJU.DesafioAtual,
                                NomeParceiroIntellimen     = jovemRetornadoBanco.SituacaoJovemIURDFJU.NomeParceiroIntellimen,
                                TelefoneParceiroIntellimen = jovemRetornadoBanco.SituacaoJovemIURDFJU.TelefoneParceiroIntellimen
                            },
                            Id                        = jovemRetornadoBanco.Id,
                            Nome                      = jovemRetornadoBanco.Nome,
                            DataNascimento            = jovemRetornadoBanco.DataNascimento.ToString("dd/MM/yyyy"),
                            DataCadastro              = jovemRetornadoBanco.DataCadastro.ToString("dd/MM/yyyy"),
                            DataPreenchimentoFormulario = (jovemRetornadoBanco.DataPreenchimentoFormulario != null)?jovemRetornadoBanco.DataPreenchimentoFormulario.ToString("dd/MM/yyyy") : "",
                            DataUltimaAtualizacao     = (jovemRetornadoBanco.DataUltimaAtualizacao != null) ? jovemRetornadoBanco.DataUltimaAtualizacao.Value.ToString("dd/MM/yyyy") : "",
                            ConjugeEhIURD             = jovemRetornadoBanco.ConjugeEhIURD,
                            NomeConjuge               = jovemRetornadoBanco.NomeConjuge,
                            DataCasamento             = (jovemRetornadoBanco.DataCasamento != null)?jovemRetornadoBanco.DataCasamento.Value.ToString("dd/MM/yyyy"):"",
                            PossuiTituloEleitor       = jovemRetornadoBanco.PossuiTituloEleitor,
                            PossuiFilhos              = jovemRetornadoBanco.PossuiFilhos,
                            QuantidadeFilhos          = jovemRetornadoBanco.QuantidadeFilhos,
                            NomeArquivoFoto           = jovemRetornadoBanco.NomeArquivoFoto,
                            TextoSugestao             = jovemRetornadoBanco.TextoSugestao,
                            Sexo                      = jovemRetornadoBanco.Sexo,            
                            ClassificacaoJovem        = jovemRetornadoBanco.ClassificacaoJovem,
                            PertenceGrupoMulheresIURD = jovemRetornadoBanco.PertenceGrupoMulheresIURD,
                            NomeGrupoMulheresIURD     = jovemRetornadoBanco.NomeGrupoMulheresIURD,
                            idEstadoCivilJovem        = (jovemRetornadoBanco.EstadoCivilJovem != null) ? jovemRetornadoBanco.EstadoCivilJovem.Code : 0,
                            DescricaoEstadoCivilJovem = (jovemRetornadoBanco.EstadoCivilJovem != null) ? jovemRetornadoBanco.EstadoCivilJovem.Descricao : "",
                            EhAltarJovem318           = jovemRetornadoBanco.EhAltarJovem318,
                            CodigoAltarJovem318       = jovemRetornadoBanco.CodigoAltarJovem318,
                            TipoJovem                 = retornaTipoJovem(jovemRetornadoBanco),
                            EhPalestranteHelp         = jovemRetornadoBanco.EhPalestranteHelp,
                            EhAtendenteWhatsappHelp   = jovemRetornadoBanco.EhAtendenteWhatsappHelp,
                            //NomeAutorizadorCompraCamisa = jovemRetornadoBanco.NomeAutorizadorCompraCamisa,
                            //DataAutorizacaoCompraCamisa = (jovemRetornadoBanco.DataAutorizacaoCompraCamisa.HasValue)?jovemRetornadoBanco.DataAutorizacaoCompraCamisa.Value.ToString("dd/MM/yyyy"):"",
                            //CodigoAutorizacaoCompraCamisa = jovemRetornadoBanco.CodigoAutorizacaoCompraCamisa,
                            //OrigemCompraCamisa = jovemRetornadoBanco.OrigemCompraCamisa,
                            IgrejaAQualJovemPertence  = new IgrejaDTO {
                                IdEstado        = jovemRetornadoBanco.IgrejaAQualJovemPertence.RegiaoIgreja.BlocoRegiao.EstadoBloco.Id,
                                NomeEstado      = jovemRetornadoBanco.IgrejaAQualJovemPertence.RegiaoIgreja.BlocoRegiao.EstadoBloco.NomeEstado,
                                IdBlocoJovem    = jovemRetornadoBanco.IgrejaAQualJovemPertence.RegiaoIgreja.BlocoRegiao.Id,
                                NomeBlocoJovem  = jovemRetornadoBanco.IgrejaAQualJovemPertence.RegiaoIgreja.BlocoRegiao.NomeBloco,
                                IdRegiao        = jovemRetornadoBanco.IgrejaAQualJovemPertence.RegiaoIgreja.Id,
                                NomeRegiaoJovem = jovemRetornadoBanco.IgrejaAQualJovemPertence.RegiaoIgreja.NomeRegiao,
                                IdIgreja        = jovemRetornadoBanco.IgrejaAQualJovemPertence.Id,
                                NomeIgreja      = jovemRetornadoBanco.IgrejaAQualJovemPertence.NomeIgreja,
                            }
                        };

                        if (jovemRetornadoBanco.SituacaoJovemIURDFJU.EhObreiro == 'S') {
                            jovemRetorno.NomePerfilCadastro = "Obreiro";
                            
                            //
                            var EXPRESSAO_ANOS = "";
                            var EXPRESSAO_MESES = "";

                            if (jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosObreiro > 0 &&
                               jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesObreiro > 0) {
                                EXPRESSAO_ANOS = (jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosObreiro == 1) ? "ano" : "anos";
                                EXPRESSAO_MESES = (jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesObreiro == 1) ? "mês" : "meses";
                                jovemRetorno.PeriodoPerfilFJU = jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosObreiro + $" {EXPRESSAO_ANOS} e " + jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesObreiro + $" {EXPRESSAO_MESES}";
                            }
                            else if (jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosObreiro > 0 &&
                                     jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesObreiro <= 0) {
                                EXPRESSAO_ANOS = (jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosObreiro == 1) ? "ano" : "anos";
                                //jovemRetorno.PeriodoPerfilFJU = jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosObreiro + " anos";
                                jovemRetorno.PeriodoPerfilFJU = jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosObreiro + $" {EXPRESSAO_ANOS}";
                            }
                            else if (jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosObreiro <= 0 &&
                                     jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesObreiro > 0) {
                                EXPRESSAO_MESES = (jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesObreiro == 1) ? "mês" : " meses";
                                jovemRetorno.PeriodoPerfilFJU = jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesObreiro + $" {EXPRESSAO_MESES}";
                            }
                        }
                        else if (jovemRetornadoBanco.SituacaoJovemIURDFJU.EhColaborador == 'S') {

                            jovemRetorno.NomePerfilCadastro = "Colaborador";

                            var EXPRESSAO_ANOS = "";
                            var EXPRESSAO_MESES = "";

                            if (jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosColaborador > 0 &&
                               jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesColaborador > 0)
                            {
                                EXPRESSAO_ANOS = (jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosColaborador == 1) ? "ano" : "anos";
                                EXPRESSAO_MESES = (jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesColaborador == 1) ? "mês" : "meses";
                                jovemRetorno.PeriodoPerfilFJU = jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosColaborador + " anos e " + jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesColaborador + " meses";
                            }
                            else if (jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosColaborador > 0 &&
                                     jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesColaborador <= 0)
                            {
                                EXPRESSAO_ANOS = (jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosColaborador == 1) ? "ano" : "anos";
                                jovemRetorno.PeriodoPerfilFJU = jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosColaborador + " anos";
                            }
                            else if (jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosColaborador <= 0 &&
                                     jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesColaborador > 0)
                            {
                                EXPRESSAO_MESES = (jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesColaborador == 1) ? "mês" : " meses";
                                jovemRetorno.PeriodoPerfilFJU = jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesColaborador + " meses";
                            }
                            /*
                            var temAnos = (jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosColaborador > 0) ? true : false;
                            var temMeses = (jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesColaborador > 0) ? true : false;

                            if (temAnos && temMeses)
                                jovemRetorno.PeriodoPerfilFJU = jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesColaborador.ToString() + "/" + jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosColaborador.ToString();
                            else if (temAnos && !temMeses)
                                jovemRetorno.PeriodoPerfilFJU = "00/" + jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosColaborador.ToString();
                            else if (!temAnos && temMeses)
                                jovemRetorno.PeriodoPerfilFJU = jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesColaborador + "/0000";
                            */
                        }
                        else if (jovemRetornadoBanco.SituacaoJovemIURDFJU.EstaCursandoCPO == 'S') {
                            var EXPRESSAO_ANOS = "";
                            var EXPRESSAO_MESES = "";
                            var TemPeriodicidade = (jovemRetornadoBanco.SituacaoJovemIURDFJU.MesAnoInicioCPO.Length == 1 && jovemRetornadoBanco.SituacaoJovemIURDFJU.MesAnoInicioCPO.IndexOf('#') != -1) ? false : true;
                            //var TemAnosCPO = (Regex.Match(jovemRetornadoBanco.SituacaoJovemIURDFJU.MesAnoInicioCPO, @"[1-9]#").Success) ? true : false;
                            //var TemMesesCPO = (Regex.Match(jovemRetornadoBanco.SituacaoJovemIURDFJU.MesAnoInicioCPO, @"#[1-9]").Success) ? true : false;
                            var TemMesesCPO = (Regex.Match(jovemRetornadoBanco.SituacaoJovemIURDFJU.MesAnoInicioCPO, @"[1-9]#").Success) ? true : false;
                            var TemAnosCPO = (Regex.Match(jovemRetornadoBanco.SituacaoJovemIURDFJU.MesAnoInicioCPO, @"#[1-9]").Success) ? true : false;
                            var periodoCPO = jovemRetornadoBanco.SituacaoJovemIURDFJU.MesAnoInicioCPO;
                            var anosCPO = "";
                            var mesesCPO = "";

                            if (TemPeriodicidade) {
                                if (TemAnosCPO && TemMesesCPO) {
                                    anosCPO = jovemRetornadoBanco.SituacaoJovemIURDFJU.MesAnoInicioCPO.Split('#')[1];
                                    mesesCPO = jovemRetornadoBanco.SituacaoJovemIURDFJU.MesAnoInicioCPO.Split('#')[0];

                                    EXPRESSAO_ANOS = (int.Parse(anosCPO) == 1) ? "ano" : "anos";
                                    EXPRESSAO_MESES = (int.Parse(mesesCPO) == 1) ? "mês" : "meses";
                                    periodoCPO = $"{anosCPO} {EXPRESSAO_ANOS} e {mesesCPO} {EXPRESSAO_MESES}";
                                }
                                else if (TemAnosCPO && !TemMesesCPO) {
                                    anosCPO = Regex.Match(jovemRetornadoBanco.SituacaoJovemIURDFJU.MesAnoInicioCPO, @"#[1-9]").Value.Replace("#", "");

                                    EXPRESSAO_ANOS = (int.Parse(anosCPO) == 1) ? "ano" : "anos";
                                    periodoCPO = $"{anosCPO} {EXPRESSAO_ANOS}";
                                }
                                else if (!TemAnosCPO && TemMesesCPO) {
                                    mesesCPO = Regex.Match(jovemRetornadoBanco.SituacaoJovemIURDFJU.MesAnoInicioCPO, @"[1-9]#").Value.Replace("#", "");

                                    EXPRESSAO_MESES = (int.Parse(mesesCPO) == 1) ? "mês" : "meses";
                                    periodoCPO = $"{mesesCPO} {EXPRESSAO_MESES}";
                                }
                            }
                            else
                                periodoCPO = "";

                            jovemRetorno.NomePerfilCadastro = "CPO";
                            jovemRetorno.PeriodoPerfilFJU = periodoCPO;

                        }

                        if (jovemRetornadoBanco.SituacaoJovemIURDFJU.EhCoordenadorFJU == 'S') {
                            jovemRetorno.PossuiCoordenacaoFJU = "Sim";
                            jovemRetorno.NomeCoordenacao = "Coordenador da FJU";

                            var EXPRESSAO_ANOS = "";
                            var EXPRESSAO_MESES = "";

                            if (jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosCoordenandoFJU > 0 &&
                               jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesCoordenandoFJU > 0) {
                                EXPRESSAO_ANOS = (jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosCoordenandoFJU == 1) ? "ano" : "anos";
                                EXPRESSAO_MESES = (jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesCoordenandoFJU == 1) ? "mês" : "meses";
                                jovemRetorno.PeriodoCoordenacao = jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosCoordenandoFJU + " anos e " + jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesCoordenandoFJU + " meses";
                            }
                            else if (jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosCoordenandoFJU > 0 &&
                                     jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesCoordenandoFJU <= 0) {
                                EXPRESSAO_ANOS = (jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosCoordenandoFJU == 1) ? "ano" : "anos";
                                jovemRetorno.PeriodoCoordenacao = jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosCoordenandoFJU + " anos";
                            }
                            else if (jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosCoordenandoFJU <= 0 &&
                                     jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesCoordenandoFJU > 0) {
                                EXPRESSAO_MESES = (jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesCoordenandoFJU == 1) ? "mês" : "meses";
                                jovemRetorno.PeriodoCoordenacao = jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesCoordenandoFJU + " meses";
                            }
                        }
                        else if (jovemRetornadoBanco.SituacaoJovemIURDFJU.EhLiderTribo == 'S'){
                            jovemRetorno.PossuiCoordenacaoFJU = "Sim";
                            jovemRetorno.NomeCoordenacao = "Coordenador de Tribo";

                            var EXPRESSAO_ANOS = "";
                            var EXPRESSAO_MESES = "";

                            if (jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosCoordenandoTribo > 0 &&
                               jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesCoordenandoTribo > 0) {
                                EXPRESSAO_ANOS = (jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosCoordenandoTribo == 1) ? "ano" : "anos";
                                EXPRESSAO_MESES = (jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesCoordenandoTribo == 1) ? "mês" : "meses";
                                jovemRetorno.PeriodoCoordenacao = jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosCoordenandoTribo + " anos e " + jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesCoordenandoTribo + " meses";
                            }
                            else if (jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosCoordenandoTribo > 0 &&
                                     jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesCoordenandoTribo <= 0) {
                                EXPRESSAO_ANOS = (jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosCoordenandoTribo == 1) ? "ano" : "anos";
                                jovemRetorno.PeriodoCoordenacao = jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosCoordenandoTribo + " anos";
                            }
                            else if (jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosCoordenandoTribo <= 0 &&
                                     jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesCoordenandoTribo > 0) {
                                EXPRESSAO_MESES = (jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesCoordenandoTribo == 1) ? "mês" : "meses";
                                jovemRetorno.PeriodoCoordenacao = jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesCoordenandoTribo + "meses";
                            }
                        }
                        else if (jovemRetornadoBanco.SituacaoJovemIURDFJU.EhLiderProjeto == 'S'){
                            jovemRetorno.PossuiCoordenacaoFJU = "Sim";
                            jovemRetorno.NomeCoordenacao = "Coordenador de Projeto";
                            var EXPRESSAO_ANOS = "";
                            var EXPRESSAO_MESES = "";

                            if (jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosCoordenandoProjeto > 0 &&
                               jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesCoordenandoProjeto > 0){
                                EXPRESSAO_ANOS = (jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosCoordenandoProjeto == 1) ? "ano" : "anos";
                                EXPRESSAO_MESES = (jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesCoordenandoProjeto == 1) ? "mês" : "meses";
                                jovemRetorno.PeriodoCoordenacao = jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosCoordenandoProjeto + $" {EXPRESSAO_ANOS} e " + jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesCoordenandoProjeto + $" {EXPRESSAO_MESES}";
                            }
                            else if (jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosCoordenandoProjeto > 0 &&
                                     jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesCoordenandoProjeto <= 0) {
                                EXPRESSAO_ANOS = (jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosCoordenandoProjeto == 1) ? "ano" : "anos";
                                jovemRetorno.PeriodoCoordenacao = jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosCoordenandoProjeto + $" {EXPRESSAO_ANOS}";
                            }
                            else if (jovemRetornadoBanco.SituacaoJovemIURDFJU.AnosCoordenandoProjeto <= 0 &&
                                     jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesCoordenandoProjeto > 0) {
                                EXPRESSAO_MESES = (jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesCoordenandoProjeto == 1) ? "mês" : "meses";
                                jovemRetorno.PeriodoCoordenacao = jovemRetornadoBanco.SituacaoJovemIURDFJU.MesesCoordenandoProjeto + $" {EXPRESSAO_MESES}";
                            }
                        }
                        
                        if (jovemRetornadoBanco.CursosRelacionados.Count() > 0) {
                            foreach (var curso in jovemRetornadoBanco.CursosRelacionados) {
                                jovemRetorno.CursosRelacionados.Add(new CursoDTO
                                {
                                    Code                 = curso.Code,
                                    IdProjetoRelacionado = (curso.ProjetoRelacionado != null) ? curso.ProjetoRelacionado.Code : 0,
                                    NomeCurso            = curso.NomeCurso,
                                    NomeProjeto          = (curso.ProjetoRelacionado != null) ? curso.ProjetoRelacionado.NomeProjeto : "",
                                });
                            }
                        }

                        if (jovemRetornadoBanco.ReunioesFJUAssistidasPeloJovem.Count > 0) {
                            foreach (var reuniao in jovemRetornadoBanco.ReunioesFJUAssistidasPeloJovem) {
                                jovemRetorno.ReunioesFJUAssistidasPeloJovem.Add(new ReuniaoFJUDTO
                                {
                                    idReuniao = reuniao.Code,
                                    NomeReuniaoFJU = reuniao.NomeReuniaoFJU
                                });
                            }
                        }

                        if (jovemRetornadoBanco.LivrosLidosPeloJovem.Count > 0) {
                            foreach (var livro in jovemRetornadoBanco.LivrosLidosPeloJovem) {
                                jovemRetorno.LivrosLidosPeloJovem.Add(new LivroDTO
                                {
                                    idLivro = livro.Code,
                                    NomeLivro = livro.NomeLivro
                                });
                            }
                        }

                        if (jovemRetornadoBanco.DepartamentosProjetoJovemFazParte.Count() > 0) {
                            foreach (var departamento in jovemRetornadoBanco.DepartamentosProjetoJovemFazParte) {
                                jovemRetorno.DepartamentosProjetoJovemFazParte.Add(new DepartamentoProjetoDTO
                                {
                                    IdDepartamento = departamento.Code,
                                    NomeDepartamento = departamento.NomeDepartamentoProjeto,
                                    IdProjeto = (departamento.Projeto != null) ? departamento.Projeto.Code : 0,
                                    NomeProjeto = (departamento.Projeto != null) ? departamento.Projeto.NomeProjeto : "",
                                });
                            }
                        }

                        var habilidadesDoJovem = session.QueryOver<JovemHabilidadeProjeto>()
                                                        .Where(h => h.Jovem.Id == jovemParametro.Id)
                                                        .List<JovemHabilidadeProjeto>();

                        if (habilidadesDoJovem.Count > 0) {
                            foreach (var habilidade in habilidadesDoJovem){
                                jovemRetorno.HabilidadesJovemPossui.Add(new HabilidadeProjetoNivelDTO { 
                                    IdHabilidade     = habilidade.Habilidade.Code,
                                    NomeHabilidade   = habilidade.Habilidade.NomeHabilidade + " - " + habilidade.Nivel.Descricao, // se não der certo comentar
                                    IdDepartamento   = (habilidade.Habilidade.DepartamentoRelacionado != null) ?habilidade.Habilidade.DepartamentoRelacionado.Code:0,
                                    NomeDepartamento = (habilidade.Habilidade.DepartamentoRelacionado != null)? habilidade.Habilidade.DepartamentoRelacionado.NomeDepartamentoProjeto: "",
                                    IdNivel          = habilidade.Nivel.Code,
                                    IdProjeto        = (habilidade.Habilidade.ProjetoRelacionado != null)? habilidade.Habilidade.ProjetoRelacionado.Code:0,
                                    NomeProjeto      = (habilidade.Habilidade.ProjetoRelacionado != null)? habilidade.Habilidade.ProjetoRelacionado.NomeProjeto:"",
                                });
                            };
                        }                        

                        var idiomasDoJovem = session.QueryOver<JovemIdioma>()
                                                    .Where(i => i.Jovem.Id == jovemParametro.Id)
                                                    .List<JovemIdioma>();

                        if (idiomasDoJovem.Count > 0) {
                            foreach (var idioma in idiomasDoJovem) {
                                jovemRetorno.IdiomasQueOJovemFala.Add(new IdiomaNivelDTO { 
                                    CodigoIdioma    = idioma.Idioma.Code,
                                    DescricaoIdioma = idioma.Idioma.NomeIdioma,
                                    CodigoNivel     = idioma.Nivel.Code,
                                    DescricaoNivel  = idioma.Nivel.Descricao
                                });
                            }
                        }

                        var projetosJovemRelacionado = session.QueryOver<JovemProjeto>()
                                                              .Where(p => p.Jovem.Id == jovemParametro.Id)
                                                              .List<JovemProjeto>();
                        if (projetosJovemRelacionado.Count > 0) {
                            foreach (var projeto in projetosJovemRelacionado){
                                var periodicidadeProjeto = "";
                                var EXPRESSAO_ANOS = "";
                                var EXPRESSAO_MESES = "";

                                if (projeto.AnosProjeto > 0 &&
                                    projeto.MesesProjeto > 0) {
                                    EXPRESSAO_ANOS = (projeto.AnosProjeto == 1) ? "ano" : "anos";
                                    EXPRESSAO_MESES = (projeto.MesesProjeto == 1) ? "mês" : "meses";
                                    periodicidadeProjeto = projeto.AnosProjeto + $" {EXPRESSAO_ANOS} e " + projeto.MesesProjeto + $" {EXPRESSAO_MESES}";
                                }
                                else if (projeto.AnosProjeto > 0 &&
                                         projeto.MesesProjeto <= 0) {
                                    EXPRESSAO_ANOS = (projeto.AnosProjeto == 1) ? "ano" : "anos";
                                    periodicidadeProjeto = projeto.AnosProjeto + $" {EXPRESSAO_ANOS}";
                                }
                                else if (projeto.AnosProjeto <= 0 &&
                                         projeto.MesesProjeto > 0){
                                    EXPRESSAO_MESES = (projeto.MesesProjeto == 1) ? "mês" : "meses";
                                    periodicidadeProjeto = projeto.MesesProjeto + $" {EXPRESSAO_MESES}";
                                }
                                else
                                    periodicidadeProjeto = "";

                                jovemRetorno.ProjetosAosQuaisJovemEstaLigado.Add(new JovemProjetoDTO { 
                                    idProjeto             = projeto.Projeto.Code,
                                    NomeProjeto           = projeto.Projeto.NomeProjeto,
                                    AnosProjeto           = projeto.AnosProjeto,
                                    MesesProjeto          = projeto.MesesProjeto,
                                    TempoProjeto          = periodicidadeProjeto,
                                    idProjetoAnterior     = (projeto.ProjetoAnterior != null)? projeto.ProjetoAnterior.Code:0,
                                    NomeProjetoAnterior   = (projeto.ProjetoAnterior != null)? projeto.ProjetoAnterior.NomeProjeto:"",
                                    PertenceuOutroProjeto = projeto.PertenceuOutroProjeto
                                });
                            }
                        }

                        var obreiroQueAcompanhaJovem = session.QueryOver<JovemObreiro>()
                                                              .Where(p => p.Jovem.Id == jovemParametro.Id)
                                                              .List<JovemObreiro>();
                        if (obreiroQueAcompanhaJovem.Count > 0) {
                            jovemRetorno.ArvoreVidaAcompanhamento = new AcompanhamentoJovemDTO
                            {
                                IdObreiro = obreiroQueAcompanhaJovem[0].Obreiro.Id,
                                NomeObreiro = obreiroQueAcompanhaJovem[0].Obreiro.Nome,
                                DataInicioAcompanhamento = obreiroQueAcompanhaJovem[0].DataInicioAcompanhamento.ToString("dd/MM/yyyy"),
                            };
                        }

                        var autorizacoesCamisaQueOJovemPossui = session.QueryOver<JovemAutorizacao>()
                                                              .Where(p => p.JovemAutorizado.Id == jovemParametro.Id)
                                                              .List<JovemAutorizacao>();
                        if(autorizacoesCamisaQueOJovemPossui != null)
                            jovemRetorno.AutorizacoesCompraCamisa 
                                = autorizacoesCamisaQueOJovemPossui.Select(aut => new AutorizacaoCompraCamisaDTO {
                                    IdJovem = aut.JovemAutorizado.Id,
                                    IdAutorizacao = aut.Id,
                                    CodigoAutorizacaoCompraCamisa = aut.CodigoAutorizacaoCompraCamisa,
                                    DataAutorizacaoCompraCamisa = aut.DataAutorizacaoCompraCamisa.Value.ToString("dd/MM/yyyy"),                                    
                                    NomeAutorizadorCompraCamisa = aut.NomeAutorizadorCompraCamisa,
                                    NomeCamisaAutorizada = aut.NomeCamisaAutorizada,
                                    OrigemCompraCamisa = aut.OrigemCompraCamisa
                                }).ToList();

                        var HQLQuery = string
                                      .Format("select tes " +
                                              "  from Testemunho as tes " +
                                              " where tes.JovemTestemunho.Id = {0} ", jovemParametro.Id.ToString());
                        var testemunhoJovem =  session.CreateQuery(HQLQuery)
                                                      .UniqueResult<Testemunho>();
                        if (testemunhoJovem != null) {
                            jovemRetorno.TestemunhoJovem = new TestemunhoDTO { 
                                Code                       = testemunhoJovem.Code,
                                TextoTestemunho            = testemunhoJovem.TextoTestemunho,
                                DescricaoTentativaSuicidio = testemunhoJovem.DescricaoTentativaSuicidio,
                                DescricaoVicio             = testemunhoJovem.DescricaoVicio,
                                MesAnoTentativaSuicidio    = testemunhoJovem.MesAnoTentativaSuicidio,
                                NumeroTentativasSuicidio   = testemunhoJovem.NumeroTentativasSuicidio,
                                SofreuAutomutilacao        = testemunhoJovem.SofreuAutomutilacao,
                                SofreuComDepressao         = testemunhoJovem.SofreuComDepressao,
                                SofreuVicio                = testemunhoJovem.SofreuVicio,
                                TempoLivreDepressao        = testemunhoJovem.TempoLivreDepressao,
                                TempoLivreAutomutilacao    = testemunhoJovem.TempoLivreAutomutilacao,
                                TempoLivreVicios           = testemunhoJovem.TempoLivreVicios,
                                TempoSofreuAutomutilacao   = testemunhoJovem.TempoSofreuAutomutilacao,
                                TempoSofreuDepressao       = testemunhoJovem.TempoSofreuDepressao,
                                TempoVicio                 = testemunhoJovem.TempoVicio,
                                TentouSuicidio             = testemunhoJovem.TentouSuicidio
                            };
                        }
                    }
                }

                return jovemRetorno;
            }
            catch(HibernateException hibernateExc) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(hibernateExc, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, hibernateExc);
            }
            catch (MySqlException excSpecificMySqlDB) {
                var mensagemErroformatada = ExceptionManager.ExceptionManager.FormatExceptionMessage(excSpecificMySqlDB, "ExecuteQuery", "CAMADA_ORM.DAO");
                throw new DomainException(mensagemErroformatada);
            }
            catch (Exception exc) {
                var mensagemErroformatada = ExceptionManager.ExceptionManager.FormatExceptionMessage(exc, "ExecuteQuery", "CAMADA_ORM.DAO");
                throw new DomainException(mensagemErroformatada);
            }
        }
        public string retornaTipoJovem(Jovem jovemParametro) { 
            if(jovemParametro.SituacaoJovemIURDFJU != null) {
                if (jovemParametro.SituacaoJovemIURDFJU.EhObreiro == 'S')
                    return "Obreiro";
                else if (jovemParametro.SituacaoJovemIURDFJU.EhColaborador == 'S')
                    return "Colaborador";
                else if (jovemParametro.SituacaoJovemIURDFJU.EstaCursandoCPO == 'S')
                    return "CPO";
                else if (jovemParametro.SituacaoJovemIURDFJU.EhCoordenadorFJU == 'S')
                    return "Coordenador";
            }
            return "Jovem";
        }
        public IList<JovemDTO> ObterJovensPorHabilidade(ParametroPesquisaHabilidadeProjetoDTO parametrosPesquisa) { 
            try
            {
                using (var session = __sessionFactory.OpenSession())
                {
                    var HQLQuery = "select hab from JovemHabilidadeProjeto as hab where 1=1 ";

                    if(parametrosPesquisa.IdHabilidade != 0)
                      HQLQuery += " And hab.Habilidade.Code = " + parametrosPesquisa.IdHabilidade.ToString();

                    if (parametrosPesquisa.IdProjeto != 0)
                        HQLQuery += " And hab.Habilidade.ProjetoRelacionado.Code = " + parametrosPesquisa.IdProjeto.ToString();

                    if (parametrosPesquisa.IdNivel != 0)
                        HQLQuery += " And hab.Nivel.Code = " + parametrosPesquisa.IdNivel.ToString();

                    var resultadoQuery = session.CreateQuery(HQLQuery).List<JovemHabilidadeProjeto>();
                    var jovensRetorno = new List<JovemDTO>();

                    if (resultadoQuery != null && resultadoQuery.Count > 0) {

                        foreach (var habilidadeJovem in resultadoQuery){
                            jovensRetorno.Add(new JovemDTO { 
                                Nome = habilidadeJovem.Jovem.Nome,
                                DataNascimento = habilidadeJovem.Jovem.DataNascimento.ToString("dd/MM/yyyy"),
                                IgrejaAQualJovemPertence = new IgrejaDTO { 
                                    IdBlocoJovem    = habilidadeJovem.Jovem.IgrejaAQualJovemPertence.RegiaoIgreja.BlocoRegiao.Id,
                                    NomeBlocoJovem  = habilidadeJovem.Jovem.IgrejaAQualJovemPertence.RegiaoIgreja.BlocoRegiao.NomeBloco,
                                    IdRegiao        = habilidadeJovem.Jovem.IgrejaAQualJovemPertence.RegiaoIgreja.Id,
                                    NomeRegiaoJovem = habilidadeJovem.Jovem.IgrejaAQualJovemPertence.RegiaoIgreja.NomeRegiao,
                                    IdIgreja        = habilidadeJovem.Jovem.IgrejaAQualJovemPertence.Id,
                                    NomeIgreja      = habilidadeJovem.Jovem.IgrejaAQualJovemPertence.NomeIgreja,
                                }
                            });
                        }
                    }

                    return jovensRetorno;
                }
            }
            catch(HibernateException hibernateExc) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(hibernateExc, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, hibernateExc);
            }
            catch (Exception dataException)
            {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }

        public IList<JovemDTO> ObterPastoresPorEstado(Estado estadoParametro) {
            try {
                using (var session = __sessionFactory.OpenSession()) {
                    var HQLQuery = string
                                      .Format("select jov " +
                                              "  from Jovem      as jov " +
                                              " inner join jov.IgrejaAQualJovemPertence  as ig " +
                                              " inner join ig.RegiaoIgreja              as reg " +
                                              " inner join reg.BlocoRegiao              as bl " +
                                              " where jov.EhPastor = 1" +
                                              "   and bl.EstadoBloco.Id = {0} ", estadoParametro.Id.ToString());
                    var pastoresEstado = session.CreateQuery(HQLQuery)
                                                .List<Jovem>()
                                                .Select(p => new JovemDTO { 
                                                    Id = p.Id,
                                                    Nome = p.Nome
                                                });
                    return pastoresEstado.ToList();
                }
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
        public IList<JovemDTO> ObterObreirosPorIgreja(Igreja igrejaParametro) {
            try {
                using (var session = __sessionFactory.OpenSession()) {
                    var HQLQuery = string
                                      .Format("select jov " +
                                              "  from Jovem      as jov " +
                                              " inner join jov.IgrejaAQualJovemPertence  as ig " +
                                              " inner join ig.RegiaoIgreja              as reg " +
                                              " inner join reg.BlocoRegiao              as bl " +
                                              " where jov.EhPastor = 0" +
                                              "   and jov.SituacaoJovemIURDFJU.EhObreiro = 'S'" +
                                              "   and ig.Id = {0} ", igrejaParametro.Id.ToString());
                    var obreirosIgreja = session.CreateQuery(HQLQuery)
                                                .List<Jovem>()
                                                .Select(p => new JovemDTO { 
                                                    Id = p.Id,
                                                    Nome = p.Nome,
                                                    NomeArquivoFotoFormatado = (!string.IsNullOrEmpty(p.NomeArquivoFoto)) ?
                                                              SGFJU.Domain.Model.Infra.Util.SgfjuConfig.Get("HOST_PROD") + p.NomeArquivoFoto :
                                                              SGFJU.Domain.Model.Infra.Util.SgfjuConfig.Get("HOST_PROD") + "UsuarioNaoSelecionado.png",
                                                    NomeConjuge = p.NomeConjuge,
                                                    DataNascimento = p.DataNascimento.ToString("dd/MM/yyyy"),
                                                    QuantidadeFilhos = p.QuantidadeFilhos,
                                                    PossuiFilhos = p.PossuiFilhos,
                                                    ConjugeEhObreiro = p.ConjugeEhObreiro,
                                                    idEstadoCivilJovem = p.EstadoCivilJovem.Code,
                                                    DescricaoEstadoCivilJovem = p.EstadoCivilJovem.Descricao,
                                                    SituacaoJovemIURDFJU = new SituacaoIURDFJUDTO { 
                                                        FoiPastor = p.SituacaoJovemIURDFJU.FoiObreiro,
                                                        MotivoSaidaPastor = p.SituacaoJovemIURDFJU.MotivoSaidaPastor,
                                                        DesejaFazerObraNoAltar = p.SituacaoJovemIURDFJU.DesejaFazerObraNoAltar,
                                                        MesAnoFoiLevantadoObreiro = p.SituacaoJovemIURDFJU.MesAnoFoiLevantadoObreiro,
                                                        MesAnoSaiuObra = p.SituacaoJovemIURDFJU.MesAnoSaidaObra
                                                    }
                                                });
                    return obreirosIgreja.ToList();
                }
            }
            catch(HibernateException hibernateExc) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(hibernateExc, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, hibernateExc);
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
        public IList<TodosJovensDTO> ListaJovensConsultaGeral(ConsultaGeralDTO parametrosConsultaGeral) {
            try {
                var retornoConsultaGeral = new List<TodosJovensDTO>();
                

                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                var joinRealizadoTabelasituacao = false;
                var joinRealizadoTabelaHabilidade = false;
                var joinRealizadoTabelaDEspirituais = false;
                var joinRealizadoTabelaProfissao = false;
                var joinRealizadoTabelaEscolaridade = false;
                var joinRealizadoTabelaRedesSociais = false;
                var joinRealizadoTabelaTestemunho = false;
                var joinRealizadoTabelaDepartamento = false;
                var joinRealizadoTabelaProjeto = false;
                var joinRealizadoTabelaContato = false;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var SQLQuery = new StringBuilder();
                SQLQuery.Append("  SELECT JV.ID_JOVEM,                          ");
                SQLQuery.Append("         JV.NOME,                              ");
                SQLQuery.Append("         JV.DATANASCIMENTO,                    ");
                SQLQuery.Append("         JV.NOMEARQUIVOFOTO,                   ");
                SQLQuery.Append("         JV.CLASSIFICACAOJOVEM,                ");
                SQLQuery.Append("         ED.NOMEESTADO,                        ");
                SQLQuery.Append("         ED.SIGLAESTADO,                       ");
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

                var SQLWhere = new StringBuilder();
                SQLWhere.Append(" WHERE 1 = 1 ");

                if (parametrosConsultaGeral.IdEstado != 0) {
                    SQLWhere.Append(" AND ED.ID_ESTADO = " + parametrosConsultaGeral.IdEstado.ToString() + " ");
                }

                if (parametrosConsultaGeral.IdBlocoJovem != 0){
                    SQLWhere.Append(" AND BL.ID_BLOCO = " + parametrosConsultaGeral.IdBlocoJovem.ToString() + " ");
                }

                if (parametrosConsultaGeral.IdRegiao != 0) {
                    SQLWhere.Append(" AND REG.ID_REGIAO = " + parametrosConsultaGeral.IdRegiao.ToString() + " ");
                }

                if (parametrosConsultaGeral.IdIgreja != 0) {
                    SQLWhere.Append(" AND IGJ.ID_IGREJA = " + parametrosConsultaGeral.IdIgreja.ToString() + " ");
                }

                if (!string.IsNullOrEmpty(parametrosConsultaGeral.Nome)) {
                    SQLWhere.Append(" AND JV.NOME LIKE '%" + parametrosConsultaGeral.Nome + "%' ");
                }

                if (parametrosConsultaGeral.EhParaListarFichasExpiradas == 'S') {
                    SQLWhere.Append(" AND ( TIMESTAMPDIFF(month, NOW(), DATAULTIMAATUALIZACAO) >= 6 OR DATAULTIMAATUALIZACAO IS NULL ) ");
                }

                if (parametrosConsultaGeral.IdTipoEstadoCivil != 0) {
                    SQLWhere.Append(" AND JV.ID_TIPOESTADOCIVIL = " + parametrosConsultaGeral.IdTipoEstadoCivil);
                }

                if (parametrosConsultaGeral.PertenceGrupoMulheresIURD == 'S' ||
                    parametrosConsultaGeral.PertenceGrupoMulheresIURD == 'N') {
                    SQLWhere.Append(" AND JV.PERTENCEGRUPOMULHERESIURD = '" + parametrosConsultaGeral.PertenceGrupoMulheresIURD + "' ");
                }

                /* Status e Sexo */
                if (parametrosConsultaGeral.Sexo == 'M' ||
                    parametrosConsultaGeral.Sexo == 'F'){
                    SQLWhere.Append(" AND JV.Sexo = '" + parametrosConsultaGeral.Sexo + "' ");
                }

                if ( parametrosConsultaGeral.ClassificacaoJovem == 'A' ||
                     parametrosConsultaGeral.ClassificacaoJovem == 'I' ||
                     parametrosConsultaGeral.ClassificacaoJovem == 'N' ||
                     parametrosConsultaGeral.ClassificacaoJovem == 'F' ||
                     parametrosConsultaGeral.ClassificacaoJovem == 'L' ||
                     parametrosConsultaGeral.ClassificacaoJovem == 'C' ||
                     parametrosConsultaGeral.ClassificacaoJovem == 'D' )
                {
                    SQLWhere.Append(" AND JV.ClassificacaoJovem = '" + parametrosConsultaGeral.ClassificacaoJovem + "' ");
                }
                else if(parametrosConsultaGeral.ClassificacaoJovem == 'O')
                    SQLWhere.Append(" AND JV.ClassificacaoJovem IS NULL ");

                if (parametrosConsultaGeral.EhAltarJovem318 == 'S') {
                    SQLWhere.Append(" AND JV.EhAltarJovem318 = 'S' ");
                }

                if (parametrosConsultaGeral.Idade != 0)
                    SQLWhere.Append($" AND ( YEAR( CURDATE() ) - YEAR( JV.DataNascimento) ) = {parametrosConsultaGeral.Idade} ");

                if (parametrosConsultaGeral.AnoNascimento != 0)
                    SQLWhere.Append($" AND YEAR( JV.DataNascimento) = {parametrosConsultaGeral.AnoNascimento} ");

                if ( parametrosConsultaGeral.IdadeInicial != 0 &&
                     parametrosConsultaGeral.IdadeFinal   != 0 )
                    SQLWhere.Append($" AND ( YEAR( CURDATE() ) - YEAR( JV.DataNascimento) ) BETWEEN {parametrosConsultaGeral.IdadeInicial} AND {parametrosConsultaGeral.IdadeFinal} ");

                if ( parametrosConsultaGeral.DataNascimento != "" &&
                     parametrosConsultaGeral.DataNascimento != null )
                    SQLWhere
                        .Append($" AND DATE(JV.DATANASCIMENTO) = '{parametrosConsultaGeral.DataNascimento}' ");
                //SQLWhere.Append($" AND JV.DATANASCIMENTO = '{DateTime.ParseExact(parametrosConsultaGeral.DataNascimento,"yyyy-MM-dd", null)}' ");

                if ( parametrosConsultaGeral.DataCadastro != "" &&
                     parametrosConsultaGeral.DataCadastro != null )
                    SQLWhere
                        .Append($" AND DATE(JV.DATACADASTRO) = '{parametrosConsultaGeral.DataCadastro}' ");

                if ( parametrosConsultaGeral.DataUltimaAtualizacao != "" &&
                     parametrosConsultaGeral.DataUltimaAtualizacao != null )
                    SQLWhere
                        .Append($" AND DATE(JV.DATAULTIMAATUALIZACAO) = '{parametrosConsultaGeral.DataUltimaAtualizacao}' ");

                /* Ranges de Data */                
                if ( 
                    parametrosConsultaGeral.RangeDataNascimento != null && 
                    (
                         ( parametrosConsultaGeral.RangeDataNascimento.DataInicial != "" &&
                           parametrosConsultaGeral.RangeDataNascimento.DataInicial != null ) 
                         &&
                         ( parametrosConsultaGeral.RangeDataNascimento.DataFinal != "" &&
                           parametrosConsultaGeral.RangeDataNascimento.DataFinal != null ) 
                    )
                   )
                    SQLWhere
                        .Append($" AND JV.DATANASCIMENTO BETWEEN '{DateTime.Parse(parametrosConsultaGeral.RangeDataNascimento.DataInicial).ToString("yyyy-MM-dd")}' AND '{DateTime.Parse(parametrosConsultaGeral.RangeDataNascimento.DataFinal).ToString("yyyy-MM-dd")}' ");

                if (
                    parametrosConsultaGeral.RangeDataCadastro != null &&
                    (
                         ( parametrosConsultaGeral.RangeDataCadastro.DataInicial != "" &&
                           parametrosConsultaGeral.RangeDataCadastro.DataInicial != null ) 
                         &&
                         ( parametrosConsultaGeral.RangeDataCadastro.DataFinal != "" &&
                           parametrosConsultaGeral.RangeDataCadastro.DataFinal != null)
                    )
                   )
                    SQLWhere
                        .Append($" AND JV.DATACADASTRO BETWEEN '{DateTime.Parse(parametrosConsultaGeral.RangeDataCadastro.DataInicial).ToString("yyyy-MM-dd")}' AND '{DateTime.Parse(parametrosConsultaGeral.RangeDataCadastro.DataFinal).ToString("yyyy-MM-dd")}' ");

                if (
                    parametrosConsultaGeral.RangeDataUltimaAtualizacao != null &&
                   (
                         ( parametrosConsultaGeral.RangeDataUltimaAtualizacao.DataInicial != "" &&
                           parametrosConsultaGeral.RangeDataUltimaAtualizacao.DataInicial != null ) 
                         &&
                         ( parametrosConsultaGeral.RangeDataUltimaAtualizacao.DataFinal != "" &&
                           parametrosConsultaGeral.RangeDataUltimaAtualizacao.DataFinal != null )
                    )
                   )
                    SQLWhere
                        .Append($" AND JV.DATAULTIMAATUALIZACAO BETWEEN '{DateTime.Parse(parametrosConsultaGeral.RangeDataUltimaAtualizacao.DataInicial).ToString("yyyy-MM-dd")}' AND '{DateTime.Parse(parametrosConsultaGeral.RangeDataUltimaAtualizacao.DataFinal).ToString("yyyy-MM-dd")}' ");
                /* Fim Ranges de Data */

                if (parametrosConsultaGeral.EhSeguidorOficialFJU == 'S' || 
                    parametrosConsultaGeral.EhSeguidorOficialFJU == 'N') {
                    if (!joinRealizadoTabelaRedesSociais) {
                        joinRealizadoTabelaRedesSociais = true;
                        SQLQuery.Append(" INNER JOIN SGFJU_DEV.SGFJU_TBL_REDESOCIAL RSOCI ");
                        SQLQuery.Append("         ON JV.ID_REDESOCIAL = RSOCI.ID_REDESOCIAL ");
                    }

                    SQLWhere.Append(" AND RSOCI.EHSEGUIDOROFICIALFJU = '" + parametrosConsultaGeral.EhSeguidorOficialFJU + "' " );
                }

                if (!string.IsNullOrEmpty(parametrosConsultaGeral.Email) && 
                    parametrosConsultaGeral.Email != null) {
                    if (!joinRealizadoTabelaRedesSociais) {
                        joinRealizadoTabelaRedesSociais = true;
                        SQLQuery.Append(" INNER JOIN SGFJU_DEV.SGFJU_TBL_REDESOCIAL RSOCI ");
                        SQLQuery.Append("         ON JV.ID_REDESOCIAL = RSOCI.ID_REDESOCIAL ");
                    }

                    SQLWhere.Append(" AND REPLACE( RSOCI.EMAIL, ' ', '' ) = '" + parametrosConsultaGeral.Email + "' ");
                }
                    

                if (parametrosConsultaGeral.EhSeguidorYoutube == 'S' || 
                    parametrosConsultaGeral.EhSeguidorYoutube == 'N') {
                    if (!joinRealizadoTabelaRedesSociais) {
                        joinRealizadoTabelaRedesSociais = true;
                        SQLQuery.Append(" INNER JOIN SGFJU_DEV.SGFJU_TBL_REDESOCIAL RSOCI ");
                        SQLQuery.Append("         ON JV.ID_REDESOCIAL = RSOCI.ID_REDESOCIAL ");
                    }

                    SQLWhere.Append(" AND RSOCI.EHSEGUIDORYOUTUBE = '" + parametrosConsultaGeral.EhSeguidorYoutube + "' ");
                }

                if (parametrosConsultaGeral.EhSeguidorTelegram == 'S' ||
                    parametrosConsultaGeral.EhSeguidorTelegram == 'N')
                {
                    if (!joinRealizadoTabelaRedesSociais)
                    {
                        joinRealizadoTabelaRedesSociais = true;
                        SQLQuery.Append(" INNER JOIN SGFJU_DEV.SGFJU_TBL_REDESOCIAL RSOCI ");
                        SQLQuery.Append("         ON JV.ID_REDESOCIAL = RSOCI.ID_REDESOCIAL ");
                    }

                    SQLWhere.Append(" AND RSOCI.EHSEGUIDORTELEGRAM = '" + parametrosConsultaGeral.EhSeguidorTelegram + "' ");
                }

                if (parametrosConsultaGeral.EhAssinanteUNIVER == 'S' ||
                    parametrosConsultaGeral.EhAssinanteUNIVER == 'N')
                {
                    if (!joinRealizadoTabelaRedesSociais)
                    {
                        joinRealizadoTabelaRedesSociais = true;
                        SQLQuery.Append(" INNER JOIN SGFJU_DEV.SGFJU_TBL_REDESOCIAL RSOCI ");
                        SQLQuery.Append("         ON JV.ID_REDESOCIAL = RSOCI.ID_REDESOCIAL ");
                    }

                    SQLWhere.Append(" AND RSOCI.EHASSINANTEUNIVER = '" + parametrosConsultaGeral.EhAssinanteUNIVER + "' ");
                }

                if (parametrosConsultaGeral.EhLeitorBlogBM == 'S' ||
                    parametrosConsultaGeral.EhLeitorBlogBM == 'N')
                {
                    if (!joinRealizadoTabelaRedesSociais)
                    {
                        joinRealizadoTabelaRedesSociais = true;
                        SQLQuery.Append(" INNER JOIN SGFJU_DEV.SGFJU_TBL_REDESOCIAL RSOCI ");
                        SQLQuery.Append("         ON JV.ID_REDESOCIAL = RSOCI.ID_REDESOCIAL ");
                    }

                    SQLWhere.Append(" AND RSOCI.EHLEITORBLOGBM = '" + parametrosConsultaGeral.EhLeitorBlogBM + "' ");
                }

                if (parametrosConsultaGeral.EhLeitorUniversalorg == 'S' ||
                    parametrosConsultaGeral.EhLeitorUniversalorg == 'N')
                {
                    if (!joinRealizadoTabelaRedesSociais)
                    {
                        joinRealizadoTabelaRedesSociais = true;
                        SQLQuery.Append(" INNER JOIN SGFJU_DEV.SGFJU_TBL_REDESOCIAL RSOCI ");
                        SQLQuery.Append("         ON JV.ID_REDESOCIAL = RSOCI.ID_REDESOCIAL ");
                    }

                    SQLWhere.Append(" AND RSOCI.EHLEITORUNIVERSALORG = '" + parametrosConsultaGeral.EhLeitorUniversalorg + "' ");
                }

                //
                if (parametrosConsultaGeral.PossuiCelularComInternet == 'S' ||
                    parametrosConsultaGeral.PossuiCelularComInternet == 'N')
                {
                    if (!joinRealizadoTabelaRedesSociais)
                    {
                        joinRealizadoTabelaRedesSociais = true;
                        SQLQuery.Append(" INNER JOIN SGFJU_DEV.SGFJU_TBL_REDESOCIAL RSOCI ");
                        SQLQuery.Append("         ON JV.ID_REDESOCIAL = RSOCI.ID_REDESOCIAL ");
                    }

                    SQLWhere.Append(" AND RSOCI.POSSUICELULARCOMINTERNET = '" + parametrosConsultaGeral.PossuiCelularComInternet + "' ");
                }

                if (parametrosConsultaGeral.PossuiComputador == 'S' ||
                    parametrosConsultaGeral.PossuiComputador == 'N')
                {
                    if (!joinRealizadoTabelaRedesSociais)
                    {
                        joinRealizadoTabelaRedesSociais = true;
                        SQLQuery.Append(" INNER JOIN SGFJU_DEV.SGFJU_TBL_REDESOCIAL RSOCI ");
                        SQLQuery.Append("         ON JV.ID_REDESOCIAL = RSOCI.ID_REDESOCIAL ");
                    }

                    SQLWhere.Append(" AND RSOCI.POSSUICOMPUTADOR = '" + parametrosConsultaGeral.PossuiComputador + "' ");
                }
                /**/

                if (!string.IsNullOrEmpty(parametrosConsultaGeral.Whatsapp) &&
                    parametrosConsultaGeral.Whatsapp!= null)
                    SQLWhere.Append(" AND REPLACE( REPLACE( REPLACE( (TRIM(  '(' FROM CT.WHATSAPP )), ')', '' ), '-', ''), ' ', '' ) = '" + parametrosConsultaGeral.Whatsapp + "' ");                

                if (parametrosConsultaGeral.IdTipoMoradia != 0) {
                    SQLQuery.Append(" INNER JOIN SGFJU_DEV.SGFJU_TBL_ENDERECO ENDE ");
                    SQLQuery.Append("         ON JV.ID_ENDERECO = ENDE.ID_ENDERECO ");

                    SQLWhere.Append(" AND ENDE.ID_TIPOMORADIA = " + parametrosConsultaGeral.IdTipoMoradia);
                }

                if (parametrosConsultaGeral.ConjugeEhIURD == 'S' || 
                    parametrosConsultaGeral.ConjugeEhIURD == 'N') {
                    SQLWhere.Append(" AND JV.ConjugeEhIURD = '" + parametrosConsultaGeral.ConjugeEhIURD + "' ");
                }

                if (parametrosConsultaGeral.PossuiTituloEleitor == 'S' ||
                    parametrosConsultaGeral.PossuiTituloEleitor == 'N') {
                    SQLWhere.Append(" AND JV.POSSUITITULOELEITOR = '" + parametrosConsultaGeral.PossuiTituloEleitor + "' ");
                }

                if (parametrosConsultaGeral.TrabalhaAtualmente == 'S' ||
                    parametrosConsultaGeral.TrabalhaAtualmente == 'N') {
                    joinRealizadoTabelaProfissao = true;
                    SQLQuery.Append(" INNER JOIN SGFJU_DEV.SGFJU_TBL_DADOS_PROFISSIONAIS DPROF ");
                    SQLQuery.Append("         ON JV.ID_DADOS_PROFISSIONAIS = DPROF.ID_DADOS_PROFISSIONAIS ");

                    SQLWhere.Append(" AND DPROF.TRABALHAATUALMENTE = '" + parametrosConsultaGeral.TrabalhaAtualmente + "' ");
                }

                if (!string.IsNullOrEmpty(parametrosConsultaGeral.Profissao)){
                    if (!joinRealizadoTabelaProfissao) {
                        joinRealizadoTabelaProfissao = true;
                        SQLQuery.Append(" INNER JOIN SGFJU_DEV.SGFJU_TBL_DADOS_PROFISSIONAIS DPROF ");
                        SQLQuery.Append("         ON JV.ID_DADOS_PROFISSIONAIS = DPROF.ID_DADOS_PROFISSIONAIS ");
                    }
                    SQLWhere.Append(" AND DPROF.PROFISSAO LIKE '%" + parametrosConsultaGeral.Profissao + "%' ");
                }

                if (parametrosConsultaGeral.EstudaAtualmente == 'S' ||
                    parametrosConsultaGeral.EstudaAtualmente == 'N') {
                    joinRealizadoTabelaEscolaridade = true;
                    SQLQuery.Append(" INNER JOIN SGFJU_DEV.SGFJU_TBL_DADOSEDUCACIONAL DEDU ");
                    SQLQuery.Append("         ON JV.ID_DADOSESCOLARES = DEDU.ID_DADOSESCOLARES ");

                    SQLWhere.Append(" AND DEDU.ESTUDAATUALMENTE = '" + parametrosConsultaGeral.EstudaAtualmente + "' ");
                }
                //
                if (!string.IsNullOrEmpty(parametrosConsultaGeral.Escolaridade)){
                    if (!joinRealizadoTabelaEscolaridade) {
                        joinRealizadoTabelaEscolaridade = true;
                        SQLQuery.Append(" INNER JOIN SGFJU_DEV.SGFJU_TBL_DADOSEDUCACIONAL DEDU ");
                        SQLQuery.Append("         ON JV.ID_DADOSESCOLARES = DEDU.ID_DADOSESCOLARES ");
                    }
                    SQLWhere.Append(" AND DEDU.GRAUESCOLARIDADE LIKE '%" + parametrosConsultaGeral.Escolaridade + "%' ");
                }

                //
                if (parametrosConsultaGeral.PossuiNivelSuperior == 'S' ||
                    parametrosConsultaGeral.PossuiNivelSuperior == 'N') {
                    if (!joinRealizadoTabelaEscolaridade) {
                        joinRealizadoTabelaEscolaridade = true;
                        SQLQuery.Append(" INNER JOIN SGFJU_DEV.SGFJU_TBL_DADOSEDUCACIONAL DEDU ");
                        SQLQuery.Append("         ON JV.ID_DADOSESCOLARES = DEDU.ID_DADOSESCOLARES ");
                    }

                    SQLWhere.Append(" AND DEDU.POSSUINIVELSUPERIOR = '" + parametrosConsultaGeral.PossuiNivelSuperior + "' ");
                }

                if (parametrosConsultaGeral.idModalidadeCursadaEnsinoSuperior != 0) {
                    if (!joinRealizadoTabelaEscolaridade) {
                        joinRealizadoTabelaEscolaridade = true;
                        SQLQuery.Append(" INNER JOIN SGFJU_DEV.SGFJU_TBL_DADOSEDUCACIONAL DEDU ");
                        SQLQuery.Append("         ON JV.ID_DADOSESCOLARES = DEDU.ID_DADOSESCOLARES ");
                    }

                    SQLWhere.Append(" AND DEDU.ID_MODALIDADE_NIVEL_SUPERIOR = " + parametrosConsultaGeral.idModalidadeCursadaEnsinoSuperior + " ");
                }

                if (parametrosConsultaGeral.DesejaCursarNivelSuperior == 'S' ||
                    parametrosConsultaGeral.DesejaCursarNivelSuperior == 'N')
                {
                    if (!joinRealizadoTabelaEscolaridade)
                    {
                        joinRealizadoTabelaEscolaridade = true;
                        SQLQuery.Append(" INNER JOIN SGFJU_DEV.SGFJU_TBL_DADOSEDUCACIONAL DEDU ");
                        SQLQuery.Append("         ON JV.ID_DADOSESCOLARES = DEDU.ID_DADOSESCOLARES ");
                    }

                    SQLWhere.Append(" AND DEDU.DESEJACURSARNIVELSUPERIOR = '" + parametrosConsultaGeral.DesejaCursarNivelSuperior + "' ");
                }

                //NomeCursoSuperior
                if (!string.IsNullOrEmpty(parametrosConsultaGeral.NomeCursoSuperior)){
                    if (!joinRealizadoTabelaEscolaridade) {
                        joinRealizadoTabelaEscolaridade = true;
                        SQLQuery.Append(" INNER JOIN SGFJU_DEV.SGFJU_TBL_DADOSEDUCACIONAL DEDU ");
                        SQLQuery.Append("         ON JV.ID_DADOSESCOLARES = DEDU.ID_DADOSESCOLARES ");
                    }

                    SQLWhere.Append(" AND DEDU.NOMECURSOSUPERIOR LIKE '%" + parametrosConsultaGeral.NomeCursoSuperior + "%' ");
                }

                if (parametrosConsultaGeral.EhObreiro == 'S' ||
                    parametrosConsultaGeral.EhObreiro == 'N' ) {
                    joinRealizadoTabelasituacao = true;
                    SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_SITUACAO_IURD_FJU SIFJ         ");
                    SQLQuery.Append("		   ON SIFJ.ID_SITUACAO_IURD_FJU = JV.ID_SITUACAO_IURD_FJU ");

                    SQLWhere.Append(" AND SIFJ.EHOBREIRO = '" + parametrosConsultaGeral.EhObreiro + "' ");
                }

                if (parametrosConsultaGeral.EhColaborador == 'S' ||
                    parametrosConsultaGeral.EhColaborador == 'N') {
                    if (!joinRealizadoTabelasituacao) {
                        joinRealizadoTabelasituacao = true;
                        SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_SITUACAO_IURD_FJU SIFJ         ");
                        SQLQuery.Append("		   ON SIFJ.ID_SITUACAO_IURD_FJU = JV.ID_SITUACAO_IURD_FJU ");
                    }

                    SQLWhere.Append(" AND SIFJ.EHCOLABORADOR = '" + parametrosConsultaGeral.EhColaborador + "' ");
                }

                if (parametrosConsultaGeral.EhCPO == 'S' ||
                    parametrosConsultaGeral.EhCPO == 'N') {
                    if (!joinRealizadoTabelasituacao) {
                        joinRealizadoTabelasituacao = true;
                        SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_SITUACAO_IURD_FJU SIFJ         ");
                        SQLQuery.Append("		   ON SIFJ.ID_SITUACAO_IURD_FJU = JV.ID_SITUACAO_IURD_FJU ");
                    }

                    SQLWhere.Append(" AND SIFJ.ESTACURSANDOCPO = '" + parametrosConsultaGeral.EhCPO + "' ");
                }

                if (parametrosConsultaGeral.EhMembroFJU == 'S'){
                    if (!joinRealizadoTabelasituacao) {
                        joinRealizadoTabelasituacao = true;
                        SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_SITUACAO_IURD_FJU SIFJ         ");
                        SQLQuery.Append("		   ON SIFJ.ID_SITUACAO_IURD_FJU = JV.ID_SITUACAO_IURD_FJU ");
                    }

                    SQLWhere.Append(" AND SIFJ.EHPERTENCENTEFJU = '" + parametrosConsultaGeral.EhMembroFJU + "' ");
                }

                if (parametrosConsultaGeral.EhCoordenadorFJU == 'S' ||
                    parametrosConsultaGeral.EhCoordenadorFJU == 'N') {
                    if (!joinRealizadoTabelasituacao) {
                        joinRealizadoTabelasituacao = true;
                        SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_SITUACAO_IURD_FJU SIFJ         ");
                        SQLQuery.Append("		   ON SIFJ.ID_SITUACAO_IURD_FJU = JV.ID_SITUACAO_IURD_FJU ");
                    }

                    SQLWhere.Append(" AND SIFJ.EHCOORDENADORFJU = '" + parametrosConsultaGeral.EhCoordenadorFJU + "' ");
                }

                if (parametrosConsultaGeral.EhLiderProjeto == 'S' ||
                    parametrosConsultaGeral.EhLiderProjeto == 'N') {
                    if (!joinRealizadoTabelasituacao) {
                        joinRealizadoTabelasituacao = true;
                        SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_SITUACAO_IURD_FJU SIFJ         ");
                        SQLQuery.Append("		   ON SIFJ.ID_SITUACAO_IURD_FJU = JV.ID_SITUACAO_IURD_FJU ");
                    }

                    SQLWhere.Append(" AND SIFJ.EHLIDERPROJETO = '" + parametrosConsultaGeral.EhLiderProjeto + "' ");
                }

                if (parametrosConsultaGeral.EhLiderTribo == 'S' ||
                    parametrosConsultaGeral.EhLiderTribo == 'N') {
                    if (!joinRealizadoTabelasituacao) {
                        joinRealizadoTabelasituacao = true;
                        SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_SITUACAO_IURD_FJU SIFJ         ");
                        SQLQuery.Append("		   ON SIFJ.ID_SITUACAO_IURD_FJU = JV.ID_SITUACAO_IURD_FJU ");
                    }

                    SQLWhere.Append(" AND SIFJ.EHLIDERTRIBO = '" + parametrosConsultaGeral.EhLiderTribo + "' ");
                }

                if (parametrosConsultaGeral.DesejaFazerObraAltar == 'S'){
                    if (!joinRealizadoTabelasituacao) {
                        joinRealizadoTabelasituacao = true;
                        SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_SITUACAO_IURD_FJU SIFJ         ");
                        SQLQuery.Append("		   ON SIFJ.ID_SITUACAO_IURD_FJU = JV.ID_SITUACAO_IURD_FJU ");
                    }

                    SQLWhere.Append(" AND SIFJ.DESEJAFAZEROBRANOALTAR = '" + parametrosConsultaGeral.DesejaFazerObraAltar + "' ");
                }

                if (parametrosConsultaGeral.EhAltarJovem == 'S' ||
                    parametrosConsultaGeral.EhAltarJovem == 'N'){
                    if (!joinRealizadoTabelasituacao) {
                        joinRealizadoTabelasituacao = true;
                        SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_SITUACAO_IURD_FJU SIFJ         ");
                        SQLQuery.Append("		   ON SIFJ.ID_SITUACAO_IURD_FJU = JV.ID_SITUACAO_IURD_FJU ");
                    }

                    SQLWhere.Append(" AND SIFJ.PERTENCEALTARJOVEM = '" + parametrosConsultaGeral.EhAltarJovem + "' ");
                }

                /**/
                if (parametrosConsultaGeral.FoiPastor == 'S' ||
                    parametrosConsultaGeral.FoiPastor == 'N')
                {
                    if (!joinRealizadoTabelasituacao) {
                        joinRealizadoTabelasituacao = true;
                        SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_SITUACAO_IURD_FJU SIFJ         ");
                        SQLQuery.Append("		   ON SIFJ.ID_SITUACAO_IURD_FJU = JV.ID_SITUACAO_IURD_FJU ");
                    }

                    SQLWhere.Append(" AND SIFJ.FOIPASTOR = '" + parametrosConsultaGeral.FoiPastor + "' ");
                }

                if (parametrosConsultaGeral.FoiObreiro == 'S' ||
                    parametrosConsultaGeral.FoiObreiro == 'N') {
                    if (!joinRealizadoTabelasituacao) {
                        joinRealizadoTabelasituacao = true;
                        SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_SITUACAO_IURD_FJU SIFJ         ");
                        SQLQuery.Append("		   ON SIFJ.ID_SITUACAO_IURD_FJU = JV.ID_SITUACAO_IURD_FJU ");
                    }

                    SQLWhere.Append(" AND SIFJ.FOIOBREIRO = '" + parametrosConsultaGeral.FoiObreiro + "' ");
                }

                if (parametrosConsultaGeral.DesejaSerObreiro == 'S' ||
                    parametrosConsultaGeral.DesejaSerObreiro == 'N')
                {
                    if (!joinRealizadoTabelasituacao) {
                        joinRealizadoTabelasituacao = true;
                        SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_SITUACAO_IURD_FJU SIFJ         ");
                        SQLQuery.Append("		   ON SIFJ.ID_SITUACAO_IURD_FJU = JV.ID_SITUACAO_IURD_FJU ");
                    }

                    SQLWhere.Append(" AND SIFJ.DESEJASEROBREIRO = '" + parametrosConsultaGeral.DesejaSerObreiro + "' ");
                }


                if (parametrosConsultaGeral.PertenceIntellimen == 'S' ||
                    parametrosConsultaGeral.PertenceIntellimen == 'N')
                {
                    if (!joinRealizadoTabelasituacao) {
                        joinRealizadoTabelasituacao = true;
                        SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_SITUACAO_IURD_FJU SIFJ         ");
                        SQLQuery.Append("		   ON SIFJ.ID_SITUACAO_IURD_FJU = JV.ID_SITUACAO_IURD_FJU ");
                    }

                    SQLWhere.Append(" AND SIFJ.PERTENCEINTELLIMEN = '" + parametrosConsultaGeral.PertenceIntellimen + "' ");
                }
                
                if (parametrosConsultaGeral.DesafiosConcluidos == 'S' ||
                    parametrosConsultaGeral.DesafiosConcluidos == 'N')
                {
                    if (!joinRealizadoTabelasituacao) {
                        joinRealizadoTabelasituacao = true;
                        SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_SITUACAO_IURD_FJU SIFJ         ");
                        SQLQuery.Append("		   ON SIFJ.ID_SITUACAO_IURD_FJU = JV.ID_SITUACAO_IURD_FJU ");
                    }

                    SQLWhere.Append(" AND SIFJ.DESAFIOSCONCLUIDOS = '" + parametrosConsultaGeral.DesafiosConcluidos + "' ");
                }

                /**/

                if (parametrosConsultaGeral.EhBatizadoAguas == 'S' ||
                    parametrosConsultaGeral.EhBatizadoAguas == 'N') {
                    joinRealizadoTabelaDEspirituais = true;
                    SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_DADOSESPIRITUAIS DESP         ");
                    SQLQuery.Append("           ON DESP.ID_DADOSESPIRITUAIS = JV.ID_DADOSESPIRITUAIS ");

                    SQLWhere.Append(" AND DESP.EhBATIZADOAGUAS = '"+ parametrosConsultaGeral.EhBatizadoAguas +"'");
                }

                if (parametrosConsultaGeral.EhBatizadoEspiritoSanto == 'S' ||
                    parametrosConsultaGeral.EhBatizadoEspiritoSanto == 'N') { 
                    if (!joinRealizadoTabelaDEspirituais) {
                        joinRealizadoTabelaDEspirituais = true;
                        SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_DADOSESPIRITUAIS DESP         ");
                        SQLQuery.Append("           ON DESP.ID_DADOSESPIRITUAIS = JV.ID_DADOSESPIRITUAIS ");
                    }

                    SQLWhere.Append(" AND DESP.EhBATIZADOESPIRITOSANTO = '" + parametrosConsultaGeral.EhBatizadoEspiritoSanto + "'");
                }

                
                if (parametrosConsultaGeral.EhMembroIURD == 'S' ||
                    parametrosConsultaGeral.EhMembroIURD == 'N') {
                    if (!joinRealizadoTabelaDEspirituais) {
                        joinRealizadoTabelaDEspirituais = true;
                        SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_DADOSESPIRITUAIS DESP         ");
                        SQLQuery.Append("           ON DESP.ID_DADOSESPIRITUAIS = JV.ID_DADOSESPIRITUAIS ");
                    }

                    SQLWhere.Append(" AND DESP.EHMEMBROIURD = '" + parametrosConsultaGeral.EhMembroIURD + "'");
                }

                if (parametrosConsultaGeral.JaSeAfastou == 'S' ||
                    parametrosConsultaGeral.JaSeAfastou == 'N') {
                    if (!joinRealizadoTabelaDEspirituais) {
                        joinRealizadoTabelaDEspirituais = true;
                        SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_DADOSESPIRITUAIS DESP         ");
                        SQLQuery.Append("           ON DESP.ID_DADOSESPIRITUAIS = JV.ID_DADOSESPIRITUAIS ");
                    }

                    SQLWhere.Append(" AND DESP.JASEAFASTOU = '" + parametrosConsultaGeral.JaSeAfastou + "'");
                }

                if (parametrosConsultaGeral.TemFamiliaresIURD == 'S' ||
                    parametrosConsultaGeral.TemFamiliaresIURD == 'N') {
                    if (!joinRealizadoTabelaDEspirituais) {
                        joinRealizadoTabelaDEspirituais = true;
                        SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_DADOSESPIRITUAIS DESP         ");
                        SQLQuery.Append("           ON DESP.ID_DADOSESPIRITUAIS = JV.ID_DADOSESPIRITUAIS ");
                    }

                    SQLWhere.Append(" AND DESP.TEMFAMILIARESIURD = '" + parametrosConsultaGeral.TemFamiliaresIURD + "'");
                }

                //
                if (parametrosConsultaGeral.PossuiBiblia == 'S' ||
                    parametrosConsultaGeral.PossuiBiblia == 'N')
                {
                    if (!joinRealizadoTabelaDEspirituais)
                    {
                        joinRealizadoTabelaDEspirituais = true;
                        SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_DADOSESPIRITUAIS DESP         ");
                        SQLQuery.Append("           ON DESP.ID_DADOSESPIRITUAIS = JV.ID_DADOSESPIRITUAIS ");
                    }

                    SQLWhere.Append(" AND DESP.POSSUIBIBLIA = '" + parametrosConsultaGeral.PossuiBiblia + "'");
                }

                if (parametrosConsultaGeral.PossuiBibliaNoCelular == 'S' ||
                    parametrosConsultaGeral.PossuiBibliaNoCelular == 'N')
                {
                    if (!joinRealizadoTabelaDEspirituais)
                    {
                        joinRealizadoTabelaDEspirituais = true;
                        SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_DADOSESPIRITUAIS DESP         ");
                        SQLQuery.Append("           ON DESP.ID_DADOSESPIRITUAIS = JV.ID_DADOSESPIRITUAIS ");
                    }

                    SQLWhere.Append(" AND DESP.POSSUIBIBLIANOCELULAR = '" + parametrosConsultaGeral.PossuiBibliaNoCelular + "'");
                }

                if (parametrosConsultaGeral.LeuTodaBiblia == 'S' ||
                    parametrosConsultaGeral.LeuTodaBiblia == 'N')
                {
                    if (!joinRealizadoTabelaDEspirituais)
                    {
                        joinRealizadoTabelaDEspirituais = true;
                        SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_DADOSESPIRITUAIS DESP         ");
                        SQLQuery.Append("           ON DESP.ID_DADOSESPIRITUAIS = JV.ID_DADOSESPIRITUAIS ");
                    }

                    SQLWhere.Append(" AND DESP.LEUTODABIBLIA = '" + parametrosConsultaGeral.LeuTodaBiblia + "'");
                }

                //
                if (parametrosConsultaGeral.SofreuComDepressao == 'S' ||
                    parametrosConsultaGeral.SofreuComDepressao == 'N') {
                    if (!joinRealizadoTabelaTestemunho){
                        joinRealizadoTabelaTestemunho = true;
                        SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_TESTEMUNHO TESTEM         ");
                        SQLQuery.Append("           ON JV.ID_JOVEM = TESTEM.ID_JOVEM ");
                    }

                    SQLWhere.Append(" AND TESTEM.SOFREUCOMDEPRESSAO = '" + parametrosConsultaGeral.SofreuComDepressao + "'");
                }

                if (parametrosConsultaGeral.SofreuAutomutilacao == 'S' ||
                    parametrosConsultaGeral.SofreuAutomutilacao == 'N') {
                    if (!joinRealizadoTabelaTestemunho) {
                        joinRealizadoTabelaTestemunho = true;
                        SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_TESTEMUNHO TESTEM         ");
                        SQLQuery.Append("           ON JV.ID_JOVEM = TESTEM.ID_JOVEM ");
                    }

                    SQLWhere.Append(" AND TESTEM.SOFREUAUTOMUTILACAO = '" + parametrosConsultaGeral.SofreuAutomutilacao + "'");
                }

                if (parametrosConsultaGeral.SofreuVicio == 'S' ||
                    parametrosConsultaGeral.SofreuVicio == 'N') {
                    if (!joinRealizadoTabelaTestemunho){
                        joinRealizadoTabelaTestemunho = true;
                        SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_TESTEMUNHO TESTEM         ");
                        SQLQuery.Append("           ON JV.ID_JOVEM = TESTEM.ID_JOVEM ");
                    }

                    SQLWhere.Append(" AND TESTEM.SOFREUVICIO = '" + parametrosConsultaGeral.SofreuVicio + "'");
                }


                if (parametrosConsultaGeral.TentouSuicidio == 'S' ||
                    parametrosConsultaGeral.TentouSuicidio == 'N') {
                    if (!joinRealizadoTabelaTestemunho){
                        joinRealizadoTabelaTestemunho = true;
                        SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_TESTEMUNHO TESTEM         ");
                        SQLQuery.Append("           ON JV.ID_JOVEM = TESTEM.ID_JOVEM ");
                    }

                    SQLWhere.Append(" AND TESTEM.TENTOUSUICIDIO = '" + parametrosConsultaGeral.TentouSuicidio + "'");
                }


                if (parametrosConsultaGeral.IdsProjetosSelecionadosParaPesquisa != null &&
                    parametrosConsultaGeral.IdsProjetosSelecionadosParaPesquisa.Count > 0) {
                    foreach (var projetoSelecionado in parametrosConsultaGeral.IdsProjetosSelecionadosParaPesquisa){
                        if (!joinRealizadoTabelaProjeto) {
                            joinRealizadoTabelaProjeto = true;

                            SQLQuery.Append("   LEFT JOIN sgfju_dev.SGFJU_TBL_JOVEM_PROJETO JPROJ ");
                            SQLQuery.Append("		   ON JPROJ.ID_JOVEM = JV.ID_JOVEM            ");

                            SQLWhere.Append(" AND JPROJ.ID_PROJETO = " + projetoSelecionado + " ");
                        }
                        else {
                            SQLWhere.Append(" OR (JPROJ.ID_PROJETO = " + projetoSelecionado + " )");
                        }
                    }
                }

                if (parametrosConsultaGeral.DepartamentosSelecionados != null &&
                    parametrosConsultaGeral.DepartamentosSelecionados.Count >0){
                    foreach (var departamentoSelecionadoParaPesquisa in parametrosConsultaGeral.DepartamentosSelecionados){
                        if (!joinRealizadoTabelaDepartamento){
                            joinRealizadoTabelaDepartamento = true;
                            SQLQuery.Append("   LEFT JOIN sgfju_dev.SGFJU_TBL_JOVEM_DEPTO_PROJETO JDP_PROJ ");
                            SQLQuery.Append("		   ON JDP_PROJ.JOVEM_ID = JV.ID_JOVEM            ");

                            SQLWhere.Append("  AND JDP_PROJ.DEPARTAMENTOPROJETO_ID = " + departamentoSelecionadoParaPesquisa + " ");
                        }
                        else {
                            SQLWhere.Append("  OR ( JDP_PROJ.DEPARTAMENTOPROJETO_ID = " + departamentoSelecionadoParaPesquisa + " )");
                        }
                    }
                }

                if (parametrosConsultaGeral.ParametrosHabilidade != null &&
                    parametrosConsultaGeral.ParametrosHabilidade.Count > 0) {
                    foreach (var parametroHabilidade in parametrosConsultaGeral.ParametrosHabilidade) {                        
                        if (!joinRealizadoTabelaHabilidade) {
                            joinRealizadoTabelaHabilidade = true;
                            SQLQuery.Append("   LEFT JOIN sgfju_dev.SGFJU_TBL_JOVEM_HABILIDADE JHAB ");
                            SQLQuery.Append("		   ON JHAB.ID_JOVEM = JV.ID_JOVEM            ");

                            SQLWhere.Append(" AND JHAB.ID_HABILIDADE = " + parametroHabilidade.IdHabilidade + " ");
                            SQLWhere.Append(" AND JHAB.ID_NIVEL = " + parametroHabilidade.IdNivel + " ");
                        }
                        else {
                            SQLWhere.Append(" OR JHAB.ID_HABILIDADE = " + parametroHabilidade.IdHabilidade + " ");
                            SQLWhere.Append(" AND JHAB.ID_NIVEL = " + parametroHabilidade.IdNivel + " ");
                        }
                    }
                }

                var iteradorHabilidadeEsporte = -1;

                if (parametrosConsultaGeral.HabilidadesEsporteSelecionadas       != null &&
                    parametrosConsultaGeral.HabilidadesEsporteSelecionadas.Count >  0) {
                    foreach (var idHabilidadeEsporte in parametrosConsultaGeral.HabilidadesEsporteSelecionadas){
                        iteradorHabilidadeEsporte++;
                        if (!joinRealizadoTabelaHabilidade) {
                            joinRealizadoTabelaHabilidade = true;
                            SQLQuery.Append("   LEFT JOIN sgfju_dev.SGFJU_TBL_JOVEM_HABILIDADE JHAB ");
                            SQLQuery.Append("		   ON JHAB.ID_JOVEM = JV.ID_JOVEM            ");

                            SQLWhere.Append(" AND JHAB.ID_HABILIDADE = " + idHabilidadeEsporte + " ");
                            SQLWhere.Append(" AND JHAB.ID_NIVEL = " + parametrosConsultaGeral.IdsNivelHabilidadesEsporteSelecionadas[iteradorHabilidadeEsporte] + " ");
                        }
                        else {
                            SQLWhere.Append(" OR JHAB.ID_HABILIDADE = " + idHabilidadeEsporte + " ");
                            SQLWhere.Append(" AND JHAB.ID_NIVEL = " + parametrosConsultaGeral.IdsNivelHabilidadesEsporteSelecionadas[iteradorHabilidadeEsporte] + " ");
                        }
                    }
                }

                if (parametrosConsultaGeral.TonsDeVozSelecionados       != null &&
                    parametrosConsultaGeral.TonsDeVozSelecionados.Count >  0 ) {
                    foreach (var tonDeVozSelecionadoParaPesquisa in parametrosConsultaGeral.TonsDeVozSelecionados){
                        if (!joinRealizadoTabelaHabilidade) {
                            joinRealizadoTabelaHabilidade = true;
                            SQLQuery.Append("   LEFT JOIN sgfju_dev.SGFJU_TBL_JOVEM_HABILIDADE JHAB ");
                            SQLQuery.Append("		   ON JHAB.ID_JOVEM = JV.ID_JOVEM            ");

                            SQLWhere.Append(" AND JHAB.ID_HABILIDADE = " + tonDeVozSelecionadoParaPesquisa + " ");
                        }
                        else {
                            SQLWhere.Append(" OR JHAB.ID_HABILIDADE = " + tonDeVozSelecionadoParaPesquisa + " ");
                        }
                    }
                }

                if (parametrosConsultaGeral.IdReuniaoFJU != 0) {
                    SQLQuery.Append("   LEFT JOIN sgfju_dev.SGFJU_TBL_JOVEM_REUNIAOFJU RFJU ");
                    SQLQuery.Append("		   ON RFJU.JOVEM_ID = JV.ID_JOVEM            ");

                    SQLWhere.Append(" AND RFJU.REUNIAOFJU_ID = " + parametrosConsultaGeral.IdReuniaoFJU + " ");
                }

                if (parametrosConsultaGeral.IdIdiomaFalado != 0) {
                    SQLQuery.Append("   LEFT JOIN sgfju_dev.SGFJU_TBL_JOVEM_IDIOMA IDI ");
                    SQLQuery.Append("		   ON IDI.ID_JOVEM = JV.ID_JOVEM            ");

                    SQLWhere.Append(" AND IDI.ID_IDIOMA = " + parametrosConsultaGeral.IdIdiomaFalado + " ");

                    if(parametrosConsultaGeral.IdNivelIdiomaFalado != 0)
                        SQLWhere.Append(" AND IDI.ID_NIVEL = " + parametrosConsultaGeral.IdNivelIdiomaFalado + " ");
                }
                
                using (conexao = _DAO.GetConnection()){
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString() + SQLWhere.ToString(), ref conexao)) {                        
                        while (resultadoReader.Read()){
                            var TELEFONE_FORMATADO = FormataTelefone(resultadoReader["WHATSAPP"].ToString());
                            retornoConsultaGeral.Add(new TodosJovensDTO { 
                                IdJovem = int.Parse(resultadoReader["ID_JOVEM"].ToString()),
                                NomeJovem             = tinfo.ToTitleCase( resultadoReader["Nome"].ToString()       ),
                                NomeEstado            = tinfo.ToTitleCase( resultadoReader["NOMEESTADO"].ToString() ),
                                NomeBlocoJovem        = tinfo.ToTitleCase( resultadoReader["NOMEBLOCO"].ToString()  ),
                                NomeRegiaoJovem       = tinfo.ToTitleCase( resultadoReader["NOMEREGIAO"].ToString() ),
                                NomeIgrejaJovem       = tinfo.ToTitleCase( resultadoReader["NOMEIGREJA"].ToString() ),
                                DataNascimento        = DateTime.Parse( resultadoReader["DATANASCIMENTO"].ToString() ).ToString("dd/MM/yyyy"),
                                Whatsapp              = TELEFONE_FORMATADO,   //string.Format("{0:(##) #####-####}", resultadoReader["WHATSAPP"].ToString().Replace('-', ' ').Trim()),
                                WhatsappSemFormatacao = resultadoReader["WHATSAPP"].ToString(),
                                NomeArquivoFoto = resultadoReader["NOMEARQUIVOFOTO"].ToString(),
                                ClassificacaoJovem = (!resultadoReader.IsDBNull(resultadoReader.GetOrdinal("CLASSIFICACAOJOVEM"))) ?
                                                         resultadoReader["CLASSIFICACAOJOVEM"].ToString() :
                                                         (string.IsNullOrEmpty(resultadoReader["CLASSIFICACAOJOVEM"].ToString()))?
                                                            "O":"",
                                SiglaEstado = resultadoReader["SIGLAESTADO"].ToString(),
                                NomeArquivoFotoFormatado = (!resultadoReader.IsDBNull(resultadoReader.GetOrdinal("NOMEARQUIVOFOTO"))) ?
                                                              SGFJU.Domain.Model.Infra.Util.SgfjuConfig.Get("HOST_PROD") + resultadoReader["NOMEARQUIVOFOTO"].ToString() :
                                                              SGFJU.Domain.Model.Infra.Util.SgfjuConfig.Get("HOST_PROD") + "UsuarioNaoSelecionado.png",
                            });
                        }
                    }
                }

                return retornoConsultaGeral;                
            }
            catch (Exception dataException){
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }

        public string FormataTelefone(string telefone) {
            var telefoneformatado = string.Empty;

            if (string.IsNullOrWhiteSpace(telefone)) {
                return "(00) 0000-0000";
            }
            else {

                if (telefone.Length == 10) {
                    telefone = telefone.Substring(0, 2) + "9" + telefone.Substring(2, telefone.Length - 2);
                }

                var match = Regex.Replace(telefone, @"(\d{2})(\d{5})(\d{4})", "($1) $2-$3");
                telefoneformatado = match;
                //telefoneformatado = $"({match.Groups[1]}) {match.Groups[2]}-{match.Groups[3]}";
                return telefoneformatado;
            }
        }

        protected string formataMesAno(string mesAnoParametro) {
            if (string.IsNullOrEmpty(mesAnoParametro) || mesAnoParametro == null)
                return "";
            var mesAnoRetorno = string.Empty;
            var dataParametro = new DateTime();
            if (ehMesEAnoValido(mesAnoParametro)) {
                mesAnoRetorno = mesAnoParametro;
                mesAnoRetorno = (mesAnoRetorno.IndexOf('/') != -1) ?
                                   mesAnoParametro :
                                   (mesAnoRetorno.Length == 6) ?
                                      mesAnoRetorno.Substring(0, 2) + "/" + mesAnoRetorno.Substring(2, 4) :
                                      mesAnoRetorno;
            }
            else if (ehDataInvertida(mesAnoParametro)) {
                var ano = Regex.Match(mesAnoParametro, @"[0-9]{4}/").Value.Replace("/", "");
                var mes = Regex.Match(mesAnoParametro, @"/[0-9]{1,2}").Value.Replace("/", "");
                mesAnoRetorno = mes + "/" + ano;
            }
            else if (DateTime.TryParse(mesAnoParametro, out dataParametro)) {
                var ano = DateTime.Parse(mesAnoParametro).Year;
                var mes = DateTime.Parse(mesAnoParametro).Month;
                mesAnoRetorno = mes + "/" + ano;
            }
            return mesAnoRetorno;
        }
        protected bool ehMesEAnoValido(string pMesAnoChegadaIURD)
        {
            var mesEAnoValido = false;

            if (string.IsNullOrEmpty(pMesAnoChegadaIURD)) {
                mesEAnoValido = false;
            }
            else if (pMesAnoChegadaIURD.IndexOf('/') != -1 &&
                     pMesAnoChegadaIURD.Length < 6) {
                mesEAnoValido = false;
            }
            else if (pMesAnoChegadaIURD.IndexOf('/') == -1 &&
                     pMesAnoChegadaIURD.Length == 6)
            {
                mesEAnoValido = true;
            }
            else if (pMesAnoChegadaIURD.IndexOf('/') != -1 &&
                     (pMesAnoChegadaIURD.Length == 7 ||pMesAnoChegadaIURD.Length == 6) &&
                     (!ehDataInvertida(pMesAnoChegadaIURD)))
            {
                mesEAnoValido = true;
            }
            else if (pMesAnoChegadaIURD.IndexOf('/') == -1 &&
                     pMesAnoChegadaIURD.Length == 4 &&
                     (int.Parse(pMesAnoChegadaIURD) >= 1977 && int.Parse(pMesAnoChegadaIURD) <= DateTime.Now.Year))
            {
                mesEAnoValido = true;
            }

            return mesEAnoValido;
        }

        protected bool ehDataInvertida(string pMesAno)
        {
            var dataEstaInvertida = (Regex.Match(pMesAno, @"[0-9]{4}/").Value.Replace("/", "").Length == 4) ? true : false;
            if (dataEstaInvertida)
            {
                return true;
            }
            return false;
        }

        public RespostaAprovacaoCompraCamisa SolicitarAutorizacaoCompraCamisa(IList<AutorizacaoCompraCamisaDTO> pSolicitacoesAutorizacaoCompra) {
            try {
                using (var session = __sessionFactory.OpenSession()) {
                    using (var transaction = session.BeginTransaction()) {
                        try {
                            foreach (var solicitacao in pSolicitacoesAutorizacaoCompra) {
                                var novaAutorizacao = new JovemAutorizacao
                                {
                                    JovemAutorizado = new Jovem { Id = solicitacao.IdJovem },
                                    CodigoAutorizacaoCompraCamisa = solicitacao.CodigoAutorizacaoCompraCamisa,
                                    NomeAutorizadorCompraCamisa = solicitacao.NomeAutorizadorCompraCamisa,
                                    NomeCamisaAutorizada = solicitacao.NomeCamisaAutorizada,
                                    OrigemCompraCamisa = solicitacao.OrigemCompraCamisa,
                                    DataAutorizacaoCompraCamisa = DateTime.Parse(solicitacao.DataAutorizacaoCompraCamisa)
                                };
                                session.Save(novaAutorizacao);

                                session.Save(new JovemAutorizacaoHistorico
                                {
                                    Id = novaAutorizacao.Id,
                                    JovemAutorizado = new Jovem { Id = solicitacao.IdJovem },
                                    CodigoAutorizacaoCompraCamisa = solicitacao.CodigoAutorizacaoCompraCamisa,
                                    NomeAutorizadorCompraCamisa = solicitacao.NomeAutorizadorCompraCamisa,
                                    NomeCamisaAutorizada = solicitacao.NomeCamisaAutorizada,
                                    OrigemCompraCamisa = solicitacao.OrigemCompraCamisa,
                                    DataAutorizacaoCompraCamisa = DateTime.Parse(solicitacao.DataAutorizacaoCompraCamisa)
                                });
                            }

                            transaction.Commit();
                        }
                        catch (Exception dataException){
                            transaction.Rollback();
                            var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                            throw new DomainException(mensagemTratada, dataException);
                        }
                    }
                }

                return new RespostaAprovacaoCompraCamisa {
                    RespostaSoliciticao = "Solicitação realizada com sucesso!",
                    SolicitacaoBemSucedida = true
                };
                /*
                var CODIGO_SGFJU_AUTORIZACAO_COMPRA_CAMISA = (pAutorizacaoSolicitacao.OrigemCompraCamisa == "S")?
                                                                $"CASGFJU{pAutorizacaoSolicitacao.IdJovem}{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Millisecond}":
                                                                pAutorizacaoSolicitacao.CodigoAutorizacaoCompraCamisa;
                var vSQL = "UPDATE SGFJU_DEV.SGFJU_TBL_JOVEM_AUTORIZAO " +
                           $"  SET CodigoAutorizacaoCompraCamisa = '{CODIGO_SGFJU_AUTORIZACAO_COMPRA_CAMISA}',             " +
                           $"      DataAutorizacaoCompraCamisa = '{pAutorizacaoSolicitacao.DataAutorizacaoCompraCamisa}',  " +
                           $"      NomeAutorizadorCompraCamisa = '{pAutorizacaoSolicitacao.NomeAutorizadorCompraCamisa}' , " +
                           $"      OrigemCompraCamisa = '{pAutorizacaoSolicitacao.OrigemCompraCamisa}'                     " +
                           $" WHERE ID_JOVEM = {pAutorizacaoSolicitacao.IdJovem} ";

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();

                    using (reader = _DAO.ExecuteQuery($"SELECT IFNULL(CodigoAutorizacaoCompraCamisa, 0) as 'CodigoAutorizacaoCompraCamisa' FROM SGFJU_DEV.SGFJU_TBL_JOVEM WHERE ID_JOVEM = {pAutorizacaoSolicitacao.IdJovem}",ref conexao)) {
                        while (reader.Read()) {
                            if(reader["CodigoAutorizacaoCompraCamisa"].ToString() != "0")
                                return new RespostaAprovacaoCompraCamisa { SolicitacaoBemSucedida = false, RespostaSoliciticao = "Já foi solicitado camisa para este Jovem" };
                        }
                    }

                    _DAO.ExecuteNonQuery(vSQL);
                }

                
                return new RespostaAprovacaoCompraCamisa { 
                    CodigoAutorizacaoSGFJU  = CODIGO_SGFJU_AUTORIZACAO_COMPRA_CAMISA, 
                    EhSolicitacaoSGFJU = (pAutorizacaoSolicitacao.OrigemCompraCamisa == "S")?true:false, 
                    RespostaSoliciticao = "Solicitação realizada com sucesso!",
                    SolicitacaoBemSucedida = true
                };*/
            }
            catch (Exception dataException){
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
        public IList<JovemAutorizacaoCamisaDTO> PesquisaAutorizacoesCamisaFJUPorParametro(ConsultaGeralDTO parametrosConsultaGeral) {
            try {
                var retornoConsultaGeral = new List<JovemAutorizacaoCamisaDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var SQLQuery = new StringBuilder();
                SQLQuery.Append("  SELECT JV.ID_JOVEM,                          ");
                SQLQuery.Append("         JV.NOME,                              ");
                SQLQuery.Append("         JV.NOMEARQUIVOFOTO,                   ");
                SQLQuery.Append("         AUT.CODIGOAUTORIZACAOCOMPRACAMISA,     ");
                SQLQuery.Append("         AUT.DATAAUTORIZACAOCOMPRACAMISA,       "); 
                SQLQuery.Append("         AUT.NOMEAUTORIZADORCOMPRACAMISA,       "); 
                SQLQuery.Append("         AUT.ORIGEMCOMPRACAMISA,                ");
                SQLQuery.Append("         AUT.NOMECAMISAAUTORIZADA,              ");
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
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_JOVEM_AUTORIZACAO AUT    ");
                SQLQuery.Append("		   ON JV.ID_JOVEM = AUT.ID_JOVEM       ");

                var SQLWhere = new StringBuilder();
                SQLWhere.Append(" WHERE 1 = 1 ");

                if (parametrosConsultaGeral.IdEstado != 0)
                {
                    SQLWhere.Append(" AND ED.ID_ESTADO = " + parametrosConsultaGeral.IdEstado.ToString() + " ");
                }

                if (parametrosConsultaGeral.IdBlocoJovem != 0)
                {
                    SQLWhere.Append(" AND BL.ID_BLOCO = " + parametrosConsultaGeral.IdBlocoJovem.ToString() + " ");
                }

                if (parametrosConsultaGeral.IdRegiao != 0)
                {
                    SQLWhere.Append(" AND REG.ID_REGIAO = " + parametrosConsultaGeral.IdRegiao.ToString() + " ");
                }

                if (parametrosConsultaGeral.IdIgreja != 0)
                {
                    SQLWhere.Append(" AND IGJ.ID_IGREJA = " + parametrosConsultaGeral.IdIgreja.ToString() + " ");
                }

                if (!string.IsNullOrEmpty(parametrosConsultaGeral.Nome))
                {
                    SQLWhere.Append(" AND JV.NOME LIKE '%" + parametrosConsultaGeral.Nome + "%' ");
                }

                if (!string.IsNullOrEmpty(parametrosConsultaGeral.CodigoAutorizacaoSGFJU))
                {
                    SQLWhere.Append(" AND AUT.CODIGOAUTORIZACAOCOMPRACAMISA = '" + parametrosConsultaGeral.CodigoAutorizacaoSGFJU + "' ");
                }

                using (conexao = _DAO.GetConnection()){
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString() + SQLWhere.ToString(), ref conexao)) {                        
                        while (resultadoReader.Read()){
                            var TELEFONE_FORMATADO = FormataTelefone(resultadoReader["WHATSAPP"].ToString());
                            retornoConsultaGeral.Add(new JovemAutorizacaoCamisaDTO { 
                                IdJovem = int.Parse(resultadoReader["ID_JOVEM"].ToString()),
                                NomeJovem             = tinfo.ToTitleCase( resultadoReader["Nome"].ToString()       ),
                                NomeEstado            = tinfo.ToTitleCase( resultadoReader["NOMEESTADO"].ToString() ),
                                NomeBlocoJovem        = tinfo.ToTitleCase( resultadoReader["NOMEBLOCO"].ToString()  ),
                                NomeRegiaoJovem       = tinfo.ToTitleCase( resultadoReader["NOMEREGIAO"].ToString() ),
                                NomeIgrejaJovem       = tinfo.ToTitleCase( resultadoReader["NOMEIGREJA"].ToString() ),
                                Whatsapp              = TELEFONE_FORMATADO,   //string.Format("{0:(##) #####-####}", resultadoReader["WHATSAPP"].ToString().Replace('-', ' ').Trim()),
                                WhatsappSemFormatacao = resultadoReader["WHATSAPP"].ToString(),
                                NomeArquivoFoto = resultadoReader["NOMEARQUIVOFOTO"].ToString(),
                                NomeArquivoFotoFormatado = (!string.IsNullOrEmpty(resultadoReader["NOMEARQUIVOFOTO"].ToString())) ?
                                                              SGFJU.Domain.Model.Infra.Util.SgfjuConfig.Get("HOST_PROD") + resultadoReader["NOMEARQUIVOFOTO"].ToString() :
                                                              SGFJU.Domain.Model.Infra.Util.SgfjuConfig.Get("HOST_PROD") + "UsuarioNaoSelecionado.png",
                                CodigoAutorizacaoCompraCamisa = resultadoReader["CODIGOAUTORIZACAOCOMPRACAMISA"].ToString(),
                                OrigemCompraCamisa = resultadoReader["ORIGEMCOMPRACAMISA"].ToString(),
                                DataAutorizacaoCompraCamisa = DateTime.Parse( resultadoReader["DATAAUTORIZACAOCOMPRACAMISA"].ToString() ).ToString("dd/MM/yyyy"),
                                NomeAutorizadorCompraCamisa = resultadoReader["NOMEAUTORIZADORCOMPRACAMISA"].ToString(),
                                NomeCamisaAutorizada = resultadoReader["NOMECAMISAAUTORIZADA"].ToString()
                            });
                        }
                    }
                }

                return retornoConsultaGeral;
            }
            catch (Exception dataException){
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }

        public bool JaExistemSolicitacoesCadastradas(int pIdJovem) {
            try
            {
                var retornoConsultaGeral = new List<JovemAutorizacaoCamisaDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var SQLQuery = $"SELECT COUNT(*) AS QTDSOLICITACOESCAMISA FROM SGFJU_DEV.SGFJU_TBL_JOVEM_AUTORIZACAO WHERE ID_JOVEM = {pIdJovem}";

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery, ref conexao)) {
                        while (resultadoReader.Read()) {
                            var qtdSolicitacoes = int.Parse(resultadoReader["QTDSOLICITACOESCAMISA"].ToString());
                            if (qtdSolicitacoes > 0)
                                return true;
                        }
                    }
                }

                return false;
            }
            catch (Exception dataException)
            {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
        public RespostaAprovacaoCompraCamisa VerificaCodigoArcacenter(AutorizacaoCompraCamisaDTO codigoArcaCenter) {
            try
            {
                var retornoConsultaGeral = new List<JovemAutorizacaoCamisaDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var SQLQuery = $"SELECT IFNULL(AT.CODIGOAUTORIZACAOCOMPRACAMISA, 0) AS 'CODIGOAUTORIZACAOCOMPRACAMISA2', "+ 
                                "       JV.NOME,      " +
                                "       AT.NOMECAMISAAUTORIZADA," +
                                "       AT.DATAAUTORIZACAOCOMPRACAMISA " +
                                "  FROM SGFJU_DEV.SGFJU_TBL_JOVEM_AUTORIZACAO AT " +
                                " INNER JOIN SGFJU_DEV.SGFJU_TBL_JOVEM JV " +
                                "         ON JV.ID_JOVEM = AT.ID_JOVEM    " +
                                $" WHERE  AT.CODIGOAUTORIZACAOCOMPRACAMISA = '{codigoArcaCenter.CodigoAutorizacaoCompraCamisa}' ";

                using (conexao = _DAO.GetConnection())
                {
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery, ref conexao))
                    {
                        while (resultadoReader.Read()) {
                            var nomeCamisa = resultadoReader["NOMECAMISAAUTORIZADA"].ToString();
                            var nomeJovem = resultadoReader["NOME"].ToString();
                            var dataCompraCamisa = DateTime.Parse(resultadoReader["DATAAUTORIZACAOCOMPRACAMISA"].ToString()).ToString("dd/MM/yyyy");
                            if (resultadoReader.HasRows)
                                return new RespostaAprovacaoCompraCamisa { SolicitacaoBemSucedida = false, RespostaSoliciticao = $"O Jovem {nomeJovem} utilizou o referido Código do Arcacenter, para comprar a seguinte camisa: {nomeCamisa} na data: {dataCompraCamisa}, portanto não pode mais ser utilizado ! " };
                        }
                    }
                }

                return new RespostaAprovacaoCompraCamisa { SolicitacaoBemSucedida = true, RespostaSoliciticao = "Solicitação bem sucedida!" };
            }
            catch (Exception dataException)
            {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }

        public RespostaAprovacaoCompraCamisa DarBaixaCamisa(AutorizacaoCompraCamisaDTO codigoAutorizacaASerDadoBaixa) {
            try {
                var retornoConsultaGeral = new List<JovemAutorizacaoCamisaDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var SQLQuery = $"UPDATE SGFJU_DEV.SGFJU_TBL_JOVEM_AUTORIZACAO " +
                                " SET CamisaJaRetirada = 'S' " +
                                $" WHERE CODIGOAUTORIZACAOCOMPRACAMISA = '{codigoAutorizacaASerDadoBaixa.CodigoAutorizacaoCompraCamisa}' ";

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();
                    _DAO.ExecuteNonQuery(new List<string> { SQLQuery });
                }

                return new RespostaAprovacaoCompraCamisa { SolicitacaoBemSucedida = true, RespostaSoliciticao = "Baixa realizada com sucesso !" };
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }

        public bool AindaPodeSolicitarCamisa(int pIdJovem) {            
            try
            {
                var retornoConsultaGeral = new List<JovemAutorizacaoCamisaDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var SQLQuery = $"SELECT * FROM SGFJU_DEV.SGFJU_TBL_JOVEM_AUTORIZACAO WHERE ID_JOVEM = {pIdJovem}";
                var possuiCamisaDeObreiro = false;
                var possuiCamisaDeProjeto = false;

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery, ref conexao)) {
                        while (resultadoReader.Read()) {
                            if (resultadoReader["NOMECAMISAAUTORIZADA"].ToString() == "Obreiro")
                                possuiCamisaDeObreiro = true;
                            else if (resultadoReader["NOMECAMISAAUTORIZADA"].ToString() != "Obreiro")
                                possuiCamisaDeProjeto = true;
                        }
                    }
                }

                if (possuiCamisaDeObreiro && possuiCamisaDeProjeto)
                    return false;

                return true;
            }
            catch (Exception dataException)
            {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }

        public void ExcluirAutorizacaoCamisa(AutorizacaoCompraCamisaDTO autorizacaoParaExcluir) {
            try {
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var SQLQuery = $"DELETE FROM SGFJU_DEV.SGFJU_TBL_JOVEM_AUTORIZACAO " +
                               $" WHERE ID_AUTORIZACAO = {autorizacaoParaExcluir.IdAutorizacao} " ;

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();
                    _DAO.ExecuteNonQuery(new List<string> { SQLQuery });
                }
            }
            catch (Exception dataException)
            {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }

        public IList<AutorizacaoCompraCamisaDTO> RetornaHistoricoSolicitacoesCamisa(JovemDTO pJovem) {
            try
            {
                var retornoConsultaGeral = new List<JovemAutorizacaoCamisaDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                var historicoRetorno = new List<AutorizacaoCompraCamisaDTO>();
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var SQLQuery = $"SELECT * FROM SGFJU_DEV.SGFJU_TBL_HISTORICO_AUTORIZACAO_CAMISA WHERE ID_JOVEM = {pJovem.Id}";
                var possuiCamisaDeObreiro = false;
                var possuiCamisaDeProjeto = false;

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery, ref conexao)) {
                        while (resultadoReader.Read()){
                            historicoRetorno.Add(new AutorizacaoCompraCamisaDTO {
                                IdJovem = int.Parse(resultadoReader["ID_JOVEM"].ToString()),
                                IdAutorizacao = int.Parse(resultadoReader["ID_AUTORIZACAO"].ToString()),
                                CodigoAutorizacaoCompraCamisa = resultadoReader["CodigoAutorizacaoCompraCamisa"].ToString(),
                                DataAutorizacaoCompraCamisa = DateTime.Parse( resultadoReader["DataAutorizacaoCompraCamisa"].ToString() ).ToString("dd/MM/yyyy"),
                                NomeAutorizadorCompraCamisa = resultadoReader["NomeAutorizadorCompraCamisa"].ToString(),
                                NomeCamisaAutorizada = resultadoReader["NOMECAMISAAUTORIZADA"].ToString(),
                                OrigemCompraCamisa = resultadoReader["OrigemCompraCamisa"].ToString()
                            });
                        }
                    }
                }

                return historicoRetorno;
            }
            catch (Exception dataException)
            {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }

        public void AlteraClassificacaoJovem(JovemDTO jovemParametro) {
            try
            {
                var retornoConsultaGeral = new List<JovemAutorizacaoCamisaDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                string vDataIngressoObraFormatado = (!string.IsNullOrEmpty(jovemParametro.DataIngressoObra)) ?
                                                       $"'{DateTime.Parse(jovemParametro.DataIngressoObra).ToString("yyyy-MM-dd")}'"  :
                                                       "null";
                var SQLQuery = $"UPDATE SGFJU_DEV.SGFJU_TBL_JOVEM " +
                               $" SET ClassificacaoJovem = '{jovemParametro.ClassificacaoJovem}', " +
                               $"     DataMudancaClassificacaoJovem = '{DateTime.Now.ToString("yyyy-MM-dd")}', " +
                               $"     DescricaoMudancaClassificacaoJovem = '{jovemParametro.DescricaoMudancaClassificacaoJovem}', " +
                               $"     AutorizadorMudancaClassificacaoJovem = '{jovemParametro.AutorizadorMudancaClassificacaoJovem}', " +
                               $"     DataIngressoObra = {vDataIngressoObraFormatado} " +
                               $" WHERE ID_JOVEM = {jovemParametro.Id} ";

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();
                    _DAO.ExecuteNonQuery(new List<string> { SQLQuery });
                }
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }

        
    }
}
