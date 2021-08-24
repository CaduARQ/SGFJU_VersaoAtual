using SGFJU.Bussiness.Facade;
using SGFJU.Bussiness.Facade.Exceptions;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGFJU.UI.Views
{
    public partial class formAdicionaIgrejasRegiao : SGFJUPaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                configuraControles(Request.QueryString["IdRegiao"]);                
            }
        }
        private void configuraControles(string idRegiao){
            configuraComboRegiao(idRegiao);
        }        
        private void configuraComboRegiao(string idRegiao)
        {
            Func<Regiao, bool> condicadoRegiao = (Regiao reg) => reg.Id == int.Parse(idRegiao);
            Regiao regiaoSelecionada = null;

            if(Session["RegioesNaSessao"] != null)
                regiaoSelecionada = (Session["RegioesNaSessao"] as IList<Regiao>).Where(condicadoRegiao).First();
            else if (Session["RegioesFiltradasPorBloco"] != null)
               regiaoSelecionada = (Session["RegioesFiltradasPorBloco"] as IList<Regiao>).Where(condicadoRegiao).First();
            cboRegiaoSelecionada.Items.Add(
                    new Telerik.Web.UI.RadComboBoxItem {
                        Value = regiaoSelecionada.Id.ToString(),
                        Text = regiaoSelecionada.NomeRegiao
                    }
                );
            cboRegiaoSelecionada.Enabled = false;

            if (Session["IgrejasRegiao"] != null)
                Session.Remove("IgrejasRegiao");
        }        
        protected void grdIgrejasRegiao_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            var novasIgrejas = (Session["IgrejasRegiao"] as IList<Igreja>);
            grdIgrejasRegiao.DataSource = novasIgrejas;
        }

        protected void grdIgrejasRegiao_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            grdIgrejasRegiao.CurrentPageIndex = e.NewPageIndex;
            grdIgrejasRegiao.Rebind();
        }

        protected void btnCadastraIgreja_Click(object sender, EventArgs e) {
            try {
                if (!HaIgrejasParaSalvar()) {
                    rwmUIApp.RadAlert("<b><font color=red>Não há igrejas adicionadas para salvar!</font></b>",
                                      400,
                                      150,
                                      "Mensagem de alerta",
                                      null);
                    return;
                }

                var facade = new FacadeBaseImpl<Igreja>();
                var igrejasParaSalvar = (Session["IgrejasRegiao"] as IList<Igreja>);

                facade.SaveBatch(igrejasParaSalvar);
                //limpaControles();
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

        private void limpaControles() {
            var listaVaziaIgrejas = new List<Igreja>();
            grdIgrejasRegiao.DataSource = listaVaziaIgrejas;
            grdIgrejasRegiao.DataBind();
        }

        private bool HaIgrejasParaSalvar() {
            if ((Session["IgrejasRegiao"] as IList<Igreja>).Count == 0)
                return false;
            else
                return true;
        }

        protected void btnAdicionarIgreja_Click(object sender, EventArgs e)
        {

            var nomeIgreja = Request.Form["txtNomeIgreja"];
            if (string.IsNullOrEmpty(nomeIgreja)) {
                rwmUIApp.RadAlert("<b><font color=blue>Para adicionar a igreja, é necessário informar o nome!</font></b><img src='~/Images/Warning.gif'>",
                                 400,
                                 150,
                                 "Mensagem de confirmação",
                                 null);
                return;
            }


            var igrejaNova = new Igreja
                            {
                                NomeIgreja = nomeIgreja,
                                RegiaoIgreja = new Regiao { Id = int.Parse(cboRegiaoSelecionada.SelectedValue) }
                            };
            if (!IgrejaJaAdicionada(igrejaNova)) {
                AdicionaIgrejaNova(igrejaNova);
                PreencheGridIgrejasRegiao();
                rwmUIApp.RadAlert("<b><font color=blue>Igreja adicionada com sucesso!</font></b> <br> <b><font color=red>Não esqueça de Salvar as igrejas após adicionar todas as que pertencem à região</font></b>",
                                 400,
                                 150,
                                 "Mensagem de confirmação",
                                 null);
            }
            else
                rwmUIApp.RadAlert("<b><font color=red>Já existe uma igreja de mesmo nome adicionada!</font></b>",
                                400,
                                150,
                                "Mensagem de alerta",
                                null);
            
        }
        private void AdicionaIgrejaNova(Igreja igrejaNova)
        {
            if (Session["IgrejasRegiao"] != null)
                (Session["IgrejasRegiao"] as IList<Igreja>).Add(igrejaNova);                
            else {
                var igrejas = new List<Igreja>();
                igrejas.Add(igrejaNova);
                Session.Add("IgrejasRegiao", igrejas);
            }
        }
        private bool IgrejaJaAdicionada(Igreja igrejaNova) {
            if (Session["IgrejasRegiao"] == null)
                return false;

            var novasIgrejas = (Session["IgrejasRegiao"] as IList<Igreja>);

            foreach (var igreja in novasIgrejas) {
                if (string.Equals(igrejaNova.NomeIgreja, igreja.NomeIgreja, StringComparison.OrdinalIgnoreCase))
                    return true; 
            }
            return false;
        }
        private void PreencheGridIgrejasRegiao() {
            var novasIgrejas = (Session["IgrejasRegiao"] as IList<Igreja>);
            grdIgrejasRegiao.DataSource = novasIgrejas;
            grdIgrejasRegiao.DataBind();
        }

        protected void grdIgrejasJaCadastradas_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e) {
            //var igrejasJaCadastradas = (Session["IGREJAS_JA_CADASTRADAS"] as IList<Igreja>);
            //grdIgrejasJaCadastradas.DataSource = igrejasJaCadastradas;
        }

        protected void grdIgrejasJaCadastradas_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e) {
            //grdIgrejasJaCadastradas.CurrentPageIndex = e.NewPageIndex;
            //grdIgrejasJaCadastradas.Rebind();
        }
    }
}