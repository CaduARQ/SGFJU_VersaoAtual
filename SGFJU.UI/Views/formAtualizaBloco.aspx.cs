using SGFJU.Bussiness.Facade;
using SGFJU.Bussiness.Facade.Exceptions;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGFJU.UI.Views
{
    public partial class formAtualizaBloco : SGFJUPaginaBase
    {
        protected void Page_Load(object sender, EventArgs e) {
            if (!Page.IsPostBack)
                carregaBlocoAtualizar(Request.QueryString["idBloco"]);
        }

        private void carregaBlocoAtualizar(string idBloco) {
            var blocoAtualizar = (Session["Blocos"] as IList<Bloco>).Where(b => b.Id == int.Parse(idBloco)).FirstOrDefault();
            if (blocoAtualizar != null) {
                Session.Add("BlocoParaAtualizar", blocoAtualizar);
                lblNomeAntigoBloco.Text = blocoAtualizar.NomeBloco;
            }
        }

        protected void btnAtualizarBloco_Click(object sender, EventArgs e)
        {
            try
            {
                var facade = new FacadeBaseImpl<Bloco>();
                var blocoParaAtualizar = (Session["BlocoParaAtualizar"] as Bloco);
                blocoParaAtualizar.NomeBloco = Request.Form["txtNomeBloco"];
                facade.Save(blocoParaAtualizar);
                string script = "function f(){CloseWindow(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
            }
            catch (DomainException excDominio)
            {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excDominio, "CAMADA_APP");
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
                rwmUIApp.RadAlert("O sistema de comportou de forma inadequada, por favor realizar pesquisa mais tarde",
                                           400,
                                           150,
                                           "Mensagem de alerta",
                                           null);
            }
            catch (FacadeException excBussiness)
            {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excBussiness, "CAMADA_APP");
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
                rwmUIApp.RadAlert("O sistema de comportou de forma inadequada, por favor realizar pesquisa mais tarde",
                                           400,
                                           150,
                                           "Mensagem de alerta",
                                           null);
            }
            catch (Exception generalException)
            {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(generalException, "CAMADA_APP");
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
                rwmUIApp.RadAlert("O sistema de comportou de forma inadequada, por favor realizar pesquisa mais tarde",
                                           400,
                                           150,
                                           "Mensagem de alerta",
                                           null);
            }
        }
    }
}