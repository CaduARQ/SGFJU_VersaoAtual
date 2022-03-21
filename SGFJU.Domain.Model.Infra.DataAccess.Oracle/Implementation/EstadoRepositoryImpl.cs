using MySql.Data.MySqlClient;
using NHibernate.Criterion;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.DataAccess.MySql.Common;
using SGFJU.Domain.Model.Repositories;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Implementation
{
    public class EstadoRepositoryImpl : RepositoryImpl<Estado>, EstadoRepository
    {
        public IList<Bloco> obterBlocosDoEstado(Estado estadoParametro)
        {
            try
            {
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                var sqlQuery = new StringBuilder();
                var retornoBlocosEstado = new List<Bloco>();
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;

                sqlQuery.Append(" SELECT BL.ID_BLOCO,                         ");
                sqlQuery.Append("	     BL.NOMEBLOCO,                        ");
                sqlQuery.Append("	     ETD.ID_ESTADO,                       ");
                sqlQuery.Append("	     ETD.NOMEESTADO                       ");
                sqlQuery.Append("	FROM      SGFJU_DEV.SGFJU_TBL_BLOCO   BL  ");
                sqlQuery.Append("   INNER JOIN SGFJU_DEV.SGFJU_TBL_ESTADO  ETD ");
                sqlQuery.Append("		   ON ETD.ID_ESTADO  = BL.ID_ESTADO    ");
                sqlQuery.Append(" WHERE ETD.ID_ESTADO = " + estadoParametro.Id);

                using (conexao = _DAO.GetConnection()){
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(sqlQuery.ToString(), ref conexao)) {
                        while (resultadoReader.Read()) {
                            retornoBlocosEstado.Add(new Bloco {
                                EstadoBloco = new Estado { 
                                    Id = int.Parse(resultadoReader["ID_ESTADO"].ToString()),
                                    NomeEstado = tinfo.ToTitleCase(resultadoReader["NOMEESTADO"].ToString()),
                                },

                                Id = int.Parse(resultadoReader["ID_BLOCO"].ToString()),
                                NomeBloco = tinfo.ToTitleCase(resultadoReader["NOMEBLOCO"].ToString())
                            });
                        }
                    }
                }

                return retornoBlocosEstado;
            }
            catch (Exception dataException)
            {
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "obterBlocosDoEstado", dataException.Message);
                throw new DomainException(erroMessage, dataException);
            }
        }
        public IList<RegiaoDTO> ObterRegioesPorEstado(Estado estadoParametro) { 
            try
            {
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                var sqlQuery = new StringBuilder();
                var retornoRegioesEstado = new List<RegiaoDTO>();
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;

                sqlQuery.Append(" SELECT RG.ID_REGIAO,                        ");
                sqlQuery.Append("	     RG.NOMEREGIAO,                       ");
                sqlQuery.Append("	     BL.ID_BLOCO,                         ");
                sqlQuery.Append("	     BL.NOMEBLOCO,                        ");
                sqlQuery.Append("	     ETD.ID_ESTADO,                       ");
                sqlQuery.Append("	     ETD.NOMEESTADO                       ");
                sqlQuery.Append("	FROM      SGFJU_DEV.SGFJU_TBL_REGIAO  RG  ");
                sqlQuery.Append("   INNER JOIN SGFJU_DEV.SGFJU_TBL_BLOCO   BL  ");
                sqlQuery.Append("		   ON RG.ID_BLOCO  = BL.ID_BLOCO       ");
                sqlQuery.Append("   INNER JOIN SGFJU_DEV.SGFJU_TBL_ESTADO  ETD ");
                sqlQuery.Append("		   ON ETD.ID_ESTADO  = BL.ID_ESTADO    ");
                sqlQuery.Append(" WHERE ETD.ID_ESTADO = " + estadoParametro.Id);

                using (conexao = _DAO.GetConnection()){
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(sqlQuery.ToString(), ref conexao)) {
                        while (resultadoReader.Read()) {
                            retornoRegioesEstado.Add(new RegiaoDTO {
                                IdEstado = int.Parse(resultadoReader["ID_ESTADO"].ToString()),
                                NomeEstado = tinfo.ToTitleCase(resultadoReader["NOMEESTADO"].ToString()),

                                idBloco = int.Parse(resultadoReader["ID_BLOCO"].ToString()),
                                NomeBloco = tinfo.ToTitleCase(resultadoReader["NOMEBLOCO"].ToString()),

                                IdRegiao = int.Parse(resultadoReader["ID_REGIAO"].ToString()),
                                NomeRegiao = tinfo.ToTitleCase(resultadoReader["NOMEREGIAO"].ToString()),

                            });
                        }
                    }
                }

                return retornoRegioesEstado;
            }
            catch (Exception dataException)
            {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "ObterJovemInformacoesDetalhadas", dataException.Message);
                throw new DomainException(erroMessage, dataException);
            }
        }
        public IList<Regiao> obterRegioesDoBloco(Bloco blocoParametro)
        {
            try
            {
                using (var session = __sessionFactory.OpenSession())
                {
                    var criteria = session.CreateCriteria<Regiao>();
                    criteria.Add(Restrictions.Eq("BlocoRegiao.Id", blocoParametro.Id));
                    return criteria.List<Regiao>();
                }
            }
            catch (Exception dataException)
            {
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "obterRegioesDoBloco", dataException.Message);
                throw new DomainException(erroMessage, dataException);
            }
        }
        public IList<Igreja> obterIgrejasDaRegiao(Regiao regiaoParametro)
        {
            try
            {
                using (var session = __sessionFactory.OpenSession())
                {
                    var criteria = session.CreateCriteria<Igreja>();
                    criteria.Add(Restrictions.Eq("RegiaoIgreja.Id", regiaoParametro.Id));
                    return criteria.List<Igreja>();
                }
            }
            catch (Exception dataException)
            {
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "obterIgrejasDaRegiao", dataException.Message);
                throw new DomainException(erroMessage, dataException);
            }
        }
        public IList<Regiao> obterTodasRegioesDoEstado(Estado estadoParametro) {
            try
            {
                using (var session = __sessionFactory.OpenSession()) {
                    var HQLQuery = string
                                      .Format("select reg " +
                                              "  from Regiao      as reg " +
                                              " inner join reg.BlocoRegiao  as bl " +
                                              " where bl.EstadoBloco.Id = {0} ", estadoParametro.Id.ToString());
                    return session.CreateQuery(HQLQuery)
                                  .List<Regiao>();
                }
            }
            catch (Exception dataException)
            {
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "obterIgrejasDaRegiao", dataException.Message);
                throw new DomainException(erroMessage, dataException);
            }
        }
        public IList<IgrejaDTO> obterTodasIgrejasDoEstado(Estado estadoParametro)
        {
            try {
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                var sqlQuery = new StringBuilder();
                var retornoIgrejasEstado = new List<IgrejaDTO>();
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;

                sqlQuery.Append(" SELECT IG.ID_IGREJA,                        ");
                sqlQuery.Append("	     IG.NOMEIGREJA,                       ");
                sqlQuery.Append("	     RG.ID_REGIAO,                        ");
                sqlQuery.Append("	     RG.NOMEREGIAO,                       ");
                sqlQuery.Append("	     BL.ID_BLOCO,                         ");
                sqlQuery.Append("	     BL.NOMEBLOCO,                        ");
                sqlQuery.Append("	     ETD.ID_ESTADO,                       ");
                sqlQuery.Append("	     ETD.NOMEESTADO                       ");
                sqlQuery.Append("	FROM      SGFJU_DEV.SGFJU_TBL_IGREJA  IG   ");
                sqlQuery.Append("   INNER JOIN SGFJU_DEV.SGFJU_TBL_REGIAO  RG  ");
                sqlQuery.Append("		   ON IG.ID_REGIAO = RG.ID_REGIAO     ");
                sqlQuery.Append("   INNER JOIN SGFJU_DEV.SGFJU_TBL_BLOCO   BL  ");
                sqlQuery.Append("		   ON RG.ID_BLOCO  = BL.ID_BLOCO      ");
                sqlQuery.Append("   INNER JOIN SGFJU_DEV.SGFJU_TBL_ESTADO  ETD ");
                sqlQuery.Append("		   ON ETD.ID_ESTADO  = BL.ID_ESTADO   ");
                sqlQuery.Append(" WHERE ETD.ID_ESTADO = " + estadoParametro.Id.ToString() );
                sqlQuery.Append(" ORDER BY BL.NOMEBLOCO ASC");

                using (conexao = _DAO.GetConnection()){
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(sqlQuery.ToString(), ref conexao)) {
                        while (resultadoReader.Read())
                        {
                            retornoIgrejasEstado.Add(new IgrejaDTO
                            {
                                IdEstado = int.Parse(resultadoReader["ID_ESTADO"].ToString()),
                                NomeEstado = tinfo.ToTitleCase(resultadoReader["NOMEESTADO"].ToString()),
                                IdBlocoJovem = int.Parse(resultadoReader["ID_BLOCO"].ToString()),
                                NomeBlocoJovem = tinfo.ToTitleCase(resultadoReader["NOMEBLOCO"].ToString()),
                                IdRegiao = int.Parse(resultadoReader["ID_REGIAO"].ToString()),
                                NomeRegiaoJovem = tinfo.ToTitleCase(resultadoReader["NOMEREGIAO"].ToString()),
                                IdIgreja = int.Parse(resultadoReader["ID_IGREJA"].ToString()),
                                NomeIgreja = tinfo.ToTitleCase(resultadoReader["NOMEIGREJA"].ToString()),
                            });
                        }
                    }
                }

                return retornoIgrejasEstado;
            }
            catch (Exception dataException)
            {
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "obterIgrejasDaRegiao", dataException.Message);
                throw new DomainException(erroMessage, dataException);
            }
        }

        public ResultadoExclusaoBlocoDTO PodeExcluirBloco(Bloco bloco) {
            var podeExcluirDTO = new ResultadoExclusaoBlocoDTO { PodeExcluir = true };
            var dao = new DAO();
            var sqlQuery = new StringBuilder();
            MySqlConnection conexao = null;
            MySqlDataReader resultado = null;
            sqlQuery.Append("SELECT distinct QTDREGIAO, QTDIGREJAS, QTDJOVENSBLOCO   ");
            sqlQuery.Append(" FROM                                                   ");
            sqlQuery.Append("(                                                       ");
            sqlQuery.Append("SELECT  COUNT(RG.ID_REGIAO) AS 'QtdRegiao',             ");
            sqlQuery.Append("        0                      AS  'QtdIgrejas',        ");
            sqlQuery.Append("        0                      AS  'QtdJovensBloco'     ");
            sqlQuery.Append("  FROM      SGFJU_DEV.SGFJU_TBL_BLOCO   BL               ");
            sqlQuery.Append(" INNER JOIN SGFJU_DEV.SGFJU_TBL_REGIAO  RG               ");
            sqlQuery.Append("         ON BL.ID_BLOCO = RG.ID_BLOCO                   ");
            sqlQuery.Append(" WHERE BL.ID_BLOCO  = " + bloco.Id.ToString() + "       ");
            sqlQuery.Append(" UNION                                                  ");
            sqlQuery.Append(" SELECT 0                      AS 'QtdRegiao',          ");
            sqlQuery.Append("       COUNT(IG.ID_IGREJA) AS  'QtdIgrejas',            ");
            sqlQuery.Append("       0                      AS  'QtdJovensBloco'      ");
            sqlQuery.Append("	FROM      SGFJU_DEV.SGFJU_TBL_IGREJA  IG              ");
            sqlQuery.Append("   INNER JOIN SGFJU_DEV.SGFJU_TBL_REGIAO  RG             ");
            sqlQuery.Append("		   ON IG.ID_REGIAO = RG.ID_REGIAO                ");
            sqlQuery.Append("   INNER JOIN SGFJU_DEV.SGFJU_TBL_BLOCO   BL             ");
            sqlQuery.Append("		   ON RG.ID_BLOCO  = BL.ID_BLOCO                 ");
            sqlQuery.Append("   WHERE BL.ID_BLOCO  = " + bloco.Id.ToString() + "     ");
            sqlQuery.Append("UNION                                                   ");
            sqlQuery.Append(" SELECT 0                      AS 'QtdRegiao',          ");
            sqlQuery.Append("        0                      AS  'QtdIgrejas',        ");
            sqlQuery.Append("        COUNT(JV.ID_JOVEM)  AS  'QtdJovensBloco'        ");
            sqlQuery.Append("   FROM      SGFJU_DEV.SGFJU_TBL_JOVEM   JV              ");
            sqlQuery.Append("  INNER JOIN SGFJU_DEV.SGFJU_TBL_IGREJA  IG              ");
            sqlQuery.Append("          ON JV.ID_IGREJA = IG.ID_IGREJA                ");
            sqlQuery.Append("  INNER JOIN SGFJU_DEV.SGFJU_TBL_REGIAO  RG              ");
            sqlQuery.Append("		   ON IG.ID_REGIAO = RG.ID_REGIAO                ");
            sqlQuery.Append("  INNER JOIN SGFJU_DEV.SGFJU_TBL_BLOCO   BL              ");
            sqlQuery.Append("		   ON RG.ID_BLOCO  = BL.ID_BLOCO                 ");
            sqlQuery.Append(" WHERE BL.ID_BLOCO = " + bloco.Id.ToString() + ") tblPanoramaBloco         ");
            
            var contator = 0;
            using (conexao = dao.GetConnection()){
                    conexao.Open();
                    using (resultado = dao.ExecuteQuery(sqlQuery.ToString(), ref conexao)) {
                        if (resultado.HasRows)
                        {
                            while (resultado.Read())
                            {
                                switch (contator)
                                {
                                    case 0:
                                        podeExcluirDTO.QuantidadeRegioes = int.Parse(resultado["QtdRegiao"].ToString());
                                        break;
                                    case 1:
                                        podeExcluirDTO.QuantidadeIgrejas = int.Parse(resultado["QtdIgrejas"].ToString());
                                        break;
                                    case 2:
                                        podeExcluirDTO.QuantidadeJovens = int.Parse(resultado["QtdJovensBloco"].ToString());
                                        break;
                                }
                                contator++;
                            }

                            /*
                            if (podeExcluirDTO.QuantidadeRegioes > 0 ||
                               podeExcluirDTO.QuantidadeIgrejas > 0 ||
                               podeExcluirDTO.QuantidadeJovens > 0)
                                podeExcluirDTO.PodeExcluir = false;
                            */
                            if (podeExcluirDTO.QuantidadeJovens > 0)
                                podeExcluirDTO.PodeExcluir = false;
                        }
                    }
             }              

            return podeExcluirDTO;
        }
        public ResultadoExclusaoRegiaoDTO PodeExcluirRegiao(Regiao regiao) {
            var podeExcluirDTO = new ResultadoExclusaoRegiaoDTO { PodeExcluir = true };
            var dao = new DAO();
            var sqlQuery = new StringBuilder();
            MySqlConnection conexao = null;
            MySqlDataReader resultado = null;
            sqlQuery.Append("SELECT distinct QTDIGREJAS, QTDJOVENSREGIAO              ");
            sqlQuery.Append(" FROM                                                   ");
            sqlQuery.Append("(                                                       ");            
            sqlQuery.Append(" SELECT COUNT(IG.ID_IGREJA)     AS  'QtdIgrejas',       ");
            sqlQuery.Append("        0                       AS  'QtdJovensRegiao'   ");
            sqlQuery.Append("	FROM      SGFJU_DEV.SGFJU_TBL_IGREJA  IG              ");
            sqlQuery.Append("   INNER JOIN SGFJU_DEV.SGFJU_TBL_REGIAO  RG             ");
            sqlQuery.Append("		   ON IG.ID_REGIAO = RG.ID_REGIAO                ");
            sqlQuery.Append("   WHERE RG.ID_REGIAO  = " + regiao.Id.ToString() + "     ");
            sqlQuery.Append("UNION                                                   ");
            sqlQuery.Append(" SELECT 0                   AS  'QtdIgrejas',        ");
            sqlQuery.Append("        COUNT(JV.ID_JOVEM)  AS  'QtdJovensRegiao'        ");
            sqlQuery.Append("   FROM      SGFJU_DEV.SGFJU_TBL_JOVEM   JV              ");
            sqlQuery.Append("  INNER JOIN SGFJU_DEV.SGFJU_TBL_IGREJA  IG              ");
            sqlQuery.Append("          ON JV.ID_IGREJA = IG.ID_IGREJA                ");
            sqlQuery.Append("  INNER JOIN SGFJU_DEV.SGFJU_TBL_REGIAO  RG              ");
            sqlQuery.Append("		   ON IG.ID_REGIAO = RG.ID_REGIAO                ");
            sqlQuery.Append(" WHERE RG.ID_REGIAO = " + regiao.Id.ToString() + ") tblPanoramaBloco         ");
            
            var contator = 0;
            using (conexao = dao.GetConnection()){
                conexao.Open();
                using (resultado = dao.ExecuteQuery(sqlQuery.ToString(), ref conexao)) {
                    if (resultado.HasRows)
                    {
                        while (resultado.Read())
                        {
                            switch (contator)
                            {
                                case 0:
                                    podeExcluirDTO.QuantidadeIgrejas = int.Parse(resultado["QtdIgrejas"].ToString());
                                    break;
                                case 1:
                                    podeExcluirDTO.QuantidadeJovens = int.Parse(resultado["QtdJovensRegiao"].ToString());
                                    break;
                            }
                            contator++;
                        }

                        /*
                        if (podeExcluirDTO.QuantidadeIgrejas > 0 ||
                           podeExcluirDTO.QuantidadeJovens > 0)
                            podeExcluirDTO.PodeExcluir = false;
                        */
                        if (podeExcluirDTO.QuantidadeJovens > 0)
                            podeExcluirDTO.PodeExcluir = false;
                    }
                }
            }  

            return podeExcluirDTO;
        }
        public ResultadoExclusaoIgrejaDTO PodeExcluirIgreja(Igreja igreja) {
            var podeExcluirDTO = new ResultadoExclusaoIgrejaDTO { PodeExcluir = true };
            var dao = new DAO();
            var sqlQuery = new StringBuilder();
            MySqlConnection conexao = null;
            MySqlDataReader resultado = null;
            sqlQuery.Append(" SELECT COUNT(JV.ID_JOVEM)  AS  'QtdJovensIgreja' ");
            sqlQuery.Append("   FROM  SGFJU_DEV.SGFJU_TBL_JOVEM   JV        ");
            sqlQuery.Append(" WHERE JV.ID_IGREJA = " + igreja.Id.ToString()     );
            
            using (conexao = dao.GetConnection()){
                conexao.Open();
                using (resultado = dao.ExecuteQuery(sqlQuery.ToString(), ref conexao)) {                        
                    if (resultado.HasRows) {
                        while (resultado.Read()) {
                            if (int.Parse(resultado["QtdJovensIgreja"].ToString()) > 0) {
                                podeExcluirDTO.QuantidadeJovens = int.Parse(resultado["QtdJovensIgreja"].ToString());
                                podeExcluirDTO.PodeExcluir = false;
                            }
                        }
                    }  
                }
            }

            return podeExcluirDTO;
        }

        public void ExcluirBlocoDoEstado(Bloco blocoParaExclusao) { 
            try {
                var dao = new DAO();
                var sqlQuery = new StringBuilder();
                sqlQuery.Append("DELETE FROM SGFJU_DEV.SGFJU_TBL_BLOCO WHERE ID_BLOCO = " + blocoParaExclusao.Id);

                dao.ExecuteNonQuery(sqlQuery.ToString());
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
        public void ExcluirRegiaoDoEstado(Regiao regiaoParaExclusao) { 
            try {
                var dao = new DAO();
                var sqlQuery = new StringBuilder();
                sqlQuery.Append("DELETE FROM SGFJU_DEV.SGFJU_TBL_REGIAO WHERE ID_REGIAO = " + regiaoParaExclusao.Id);

                dao.ExecuteNonQuery(sqlQuery.ToString());
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
        public void ExcluirIgrejaDoEstado(Igreja igrejaParaExclusao) {
            try {
                var dao = new DAO();
                var sqlQuery = new StringBuilder();
                sqlQuery.Append("DELETE FROM SGFJU_DEV.SGFJU_TBL_IGREJA WHERE ID_IGREJA = " + igrejaParaExclusao.Id + ";");
                sqlQuery.Append("DELETE FROM SGFJU_DEV.SGFJU_TBL_IGREJA_COORDENADOR WHERE ID_IGREJA = " + igrejaParaExclusao.Id + ";");

                dao.ExecuteNonQuery(sqlQuery.ToString());
            }
            catch (Exception dataException)
            {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
        public IList<IgrejaCoordenadorDTO> RetornaInformacoesIgrejasEstado(Estado estadoParametro) {
            try {
                using (var session = __sessionFactory.OpenSession())
                {
                    var HQLQuery = string
                                      .Format("select ic " +
                                              "  from IgrejaCoordenador    as ic  " +
                                              " inner join ic.IgrejaFJU    as ig  " +
                                              " inner join ig.RegiaoIgreja as reg " +
                                              " inner join reg.BlocoRegiao as blc " +
                                              " where blc.EstadoBloco.Id = {0} ", estadoParametro.Id.ToString());
                    return session.CreateQuery(HQLQuery)
                                  .List<IgrejaCoordenador>()
                                  .Select(ic => new IgrejaCoordenadorDTO {
                                      //idIgreja                         = ic.IgrejaFJU.Id,
                                      NomeIgreja                       = ic.IgrejaFJU.NomeIgreja,
                                      //idCoordenadorFJU                 = ic.CoordenadorFJU.Id,
                                      NomeCoordenador                  = ic.CoordenadorFJU.Nome,
                                      NomeTipoCoordenador              = (ic.CoordenadorFJU.EhPastor)?"Pastor":"Obreiro(a)",
                                      //MesesCoordenandoFJU              = ic.MesesCoordenandoFJU,
                                      //AnosCoordenandoFJU               = ic.AnosCoordenandoFJU,
                                      QuantidadeJovensEncontroAnterior = ic.QuantidadeJovensEncontroAnterior,
                                      QuantidadeJovensEncontroAtual    = ic.QuantidadeJovensEncontroAtual
                                  }).ToList();
                }
            }
            catch (Exception dataException)
            {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "ObterJovemInformacoesDetalhadas", dataException.Message);
                throw new DomainException(erroMessage, dataException);
            }
        }
        public bool IgrejaPossuiCoordenador(IgrejaCoordenador igrejaCoordenadorParametro) {
            try {
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                var sqlQuery = new StringBuilder();
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;

                sqlQuery.Append(" SELECT ID_IGREJA_COORDENADOR                         ");
                sqlQuery.Append("	FROM SGFJU_DEV.SGFJU_TBL_IGREJA_COORDENADOR  IGC   ");
                sqlQuery.Append(" WHERE IGC.ID_IGREJA = " + igrejaCoordenadorParametro.IgrejaFJU.Id);
                sqlQuery.Append("  AND IGC.DATASAIDACOORDENADOR IS NULL ");
                sqlQuery.Append("  AND IGC.ID_JOVEM IS NOT NULL ");

                using (conexao = _DAO.GetConnection()){
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(sqlQuery.ToString(), ref conexao)) {                        
                        if (resultadoReader.HasRows){
                            return true;
                        }
                    }
                }

                return false;
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "ObterJovemInformacoesDetalhadas", dataException.Message);
                throw new DomainException(erroMessage, dataException);
            }
        }

        public void AtualizarIgreja(Igreja igrejaAAtualizar) {
            try {
                /*
                using (var session = __sessionFactory.OpenSession()){
                    using (var transaction = session.BeginTransaction()) {
                        var igrejaParaAtualizacao = session.Get<Igreja>(igrejaAAtualizar.Id);
                        igrejaParaAtualizacao.NomeIgreja = igrejaAAtualizar.NomeIgreja;

                        session.SaveOrUpdate(igrejaParaAtualizacao);

                        transaction.Commit();
                    }
                }*/
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                var sqlCMD = new StringBuilder();
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;

                sqlCMD.Append(" UPDATE SGFJU_DEV.SGFJU_TBL_IGREJA ");
                sqlCMD.Append("    SET NOMEIGREJA = '" + igrejaAAtualizar.NomeIgreja + "' ");
                sqlCMD.Append("  WHERE ID_IGREJA = " + igrejaAAtualizar.Id);

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();
                    _DAO.ExecuteNonQuery(sqlCMD.ToString());
                }
            }
            catch (Exception dataException)
            {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "ObterJovemInformacoesDetalhadas", dataException.Message);
                throw new DomainException(erroMessage, dataException);
            }
        }

        public bool JaExisteIgrejaNaRegiao(IgrejaDTO igrejaAVerificar) {
            try {
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                var sqlQuery = new StringBuilder();
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;

                sqlQuery.Append(" SELECT IG.ID_IGREJA                          ");
                sqlQuery.Append("	FROM      SGFJU_DEV.SGFJU_TBL_IGREJA  IG   ");
                sqlQuery.Append("   INNER JOIN SGFJU_DEV.SGFJU_TBL_REGIAO  RG  ");
                sqlQuery.Append("		   ON IG.ID_REGIAO = RG.ID_REGIAO      ");
                sqlQuery.Append("   INNER JOIN SGFJU_DEV.SGFJU_TBL_BLOCO   BL  ");
                sqlQuery.Append("		   ON RG.ID_BLOCO  = BL.ID_BLOCO       ");
                sqlQuery.Append("   INNER JOIN SGFJU_DEV.SGFJU_TBL_ESTADO  ETD ");
                sqlQuery.Append("		   ON ETD.ID_ESTADO  = BL.ID_ESTADO    ");
                sqlQuery.Append(" WHERE RG.ID_REGIAO = " + igrejaAVerificar.IdRegiao);
                sqlQuery.Append("  AND IG.NOMEIGREJA LIKE '%" + igrejaAVerificar.NomeIgreja + "%'");

                using (conexao = _DAO.GetConnection()){
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(sqlQuery.ToString(), ref conexao)) {
                        if (resultadoReader.HasRows) {
                            return true;
                        }
                    }
                }

                return false;
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "ObterJovemInformacoesDetalhadas", dataException.Message);
                throw new DomainException(erroMessage, dataException);
            }
        }

        public IList<IgrejaDTO> PesquisarIgrejasPorParametro(IgrejaDTO parametros) {
            try
            {
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                var sqlQuery = new StringBuilder();
                var retornoIgrejasEstado = new List<IgrejaDTO>();
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;

                sqlQuery.Append(" SELECT IG.ID_IGREJA,                        ");
                sqlQuery.Append("	     IG.NOMEIGREJA,                       ");
                sqlQuery.Append("	     RG.ID_REGIAO,                        ");
                sqlQuery.Append("	     RG.NOMEREGIAO,                       ");
                sqlQuery.Append("	     BL.ID_BLOCO,                         ");
                sqlQuery.Append("	     BL.NOMEBLOCO,                        ");
                sqlQuery.Append("	     ETD.ID_ESTADO,                       ");
                sqlQuery.Append("	     ETD.NOMEESTADO                       ");
                sqlQuery.Append("	FROM      SGFJU_DEV.SGFJU_TBL_IGREJA  IG   ");
                sqlQuery.Append("   INNER JOIN SGFJU_DEV.SGFJU_TBL_REGIAO  RG  ");
                sqlQuery.Append("		   ON IG.ID_REGIAO = RG.ID_REGIAO      ");
                sqlQuery.Append("   INNER JOIN SGFJU_DEV.SGFJU_TBL_BLOCO   BL  ");
                sqlQuery.Append("		   ON RG.ID_BLOCO  = BL.ID_BLOCO       ");
                sqlQuery.Append("   INNER JOIN SGFJU_DEV.SGFJU_TBL_ESTADO  ETD ");
                sqlQuery.Append("		   ON ETD.ID_ESTADO  = BL.ID_ESTADO    ");
                sqlQuery.Append(" WHERE 1=1 ");

                if (parametros.IdEstado != 0) {
                    sqlQuery.Append(" AND ETD.ID_ESTADO = " + parametros.IdEstado);
                }

                if (parametros.IdBlocoJovem != 0) {
                    sqlQuery.Append(" AND BL.ID_BLOCO = " + parametros.IdBlocoJovem);
                }

                if (parametros.IdRegiao != 0) {
                    sqlQuery.Append(" AND RG.ID_REGIAO = " + parametros.IdRegiao);
                }

                using (conexao = _DAO.GetConnection()){
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(sqlQuery.ToString(), ref conexao)) {
                        while (resultadoReader.Read())
                        {
                            retornoIgrejasEstado.Add(new IgrejaDTO
                            {
                                IdEstado = int.Parse(resultadoReader["ID_ESTADO"].ToString()),
                                NomeEstado = tinfo.ToTitleCase(resultadoReader["NOMEESTADO"].ToString()),
                                IdBlocoJovem = int.Parse(resultadoReader["ID_BLOCO"].ToString()),
                                NomeBlocoJovem = tinfo.ToTitleCase(resultadoReader["NOMEBLOCO"].ToString()),
                                IdRegiao = int.Parse(resultadoReader["ID_REGIAO"].ToString()),
                                NomeRegiaoJovem = tinfo.ToTitleCase(resultadoReader["NOMEREGIAO"].ToString()),
                                IdIgreja = int.Parse(resultadoReader["ID_IGREJA"].ToString()),
                                NomeIgreja = tinfo.ToTitleCase(resultadoReader["NOMEIGREJA"].ToString()),
                            });
                        }
                    }
                }

                return retornoIgrejasEstado;
            }
            catch (Exception dataException)
            {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "ObterJovemInformacoesDetalhadas", dataException.Message);
                throw new DomainException(erroMessage, dataException);
            }
        }

        public bool TranfereIgrejaDeRegiao(IgrejaDTO igrejaASerTransferida, RegiaoDTO regiaoDestino) {
            try {
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                var sqlCMD = new StringBuilder();
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;

                sqlCMD.Append(" UPDATE SGFJU_DEV.SGFJU_TBL_IGREJA ");
                sqlCMD.Append("    SET ID_REGIAO = " + regiaoDestino.IdRegiao + " ");
                sqlCMD.Append("  WHERE ID_IGREJA = " + igrejaASerTransferida.IdIgreja);

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();
                    _DAO.ExecuteNonQuery(sqlCMD.ToString());
                }
                return true;
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "ObterJovemInformacoesDetalhadas", dataException.Message);
                throw new DomainException(erroMessage, dataException);
            }
        }
        public bool TranfereRegiaoDeBloco(RegiaoDTO regiaoASerTransferida, BlocoDTO blocoDestino) { 
            try {
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                var sqlCMD = new StringBuilder();
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;

                sqlCMD.Append(" UPDATE SGFJU_DEV.SGFJU_TBL_REGIAO ");
                sqlCMD.Append("    SET ID_BLOCO = " + blocoDestino.idBloco + " ");
                sqlCMD.Append("  WHERE ID_REGIAO = " + regiaoASerTransferida.IdRegiao);

                using (conexao = _DAO.GetConnection())
                {
                    conexao.Open();
                    _DAO.ExecuteNonQuery(sqlCMD.ToString());
                }
                return true;
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "ObterJovemInformacoesDetalhadas", dataException.Message);
                throw new DomainException(erroMessage, dataException);
            }
        }
    }
}
