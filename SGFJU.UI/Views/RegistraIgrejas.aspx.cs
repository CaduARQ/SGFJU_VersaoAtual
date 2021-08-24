using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace SGFJU.UI.Views
{
    public partial class RegistraIgrejas : SGFJUPaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.CarregaControles();
            }
        }

        private void CarregaControles()
        {
            var codigoPerfilADM = int.Parse(ConfigurationManager.AppSettings["CodeADM"]);
            try {                                
                if (UsuarioLogado != null)
                {
                    if (EhADM) {
                        PreencheComboEstados();                        
                    }
                    else {
                        cboEstado.Items.Add(new Telerik.Web.UI.RadComboBoxItem
                        {
                            Value = this.UsuarioLogado.EstadoUsuario.Id.ToString(),
                            Text = this.UsuarioLogado.EstadoUsuario.NomeEstado
                        });
                        cboEstado_SelectedIndexChanged(this, new RadComboBoxSelectedIndexChangedEventArgs(
                            UsuarioLogado.EstadoUsuario.NomeEstado,
                            UsuarioLogado.EstadoUsuario.NomeEstado,
                            UsuarioLogado.EstadoUsuario.Id.ToString(),
                            UsuarioLogado.EstadoUsuario.Id.ToString()
                        ));
                        cboEstado.Enabled = false;
                    }
                    PreencheGridRegioes();
                }
            }
            catch (Exception excLoadControles)
            {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excLoadControles);
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
                rwmUIApp.RadAlert("O sistema de comportou de forma inadequada, por favor tente mais tarde",
                                           400,
                                           150,
                                           "Mensagem de alerta",
                                           null);
            }
        }

        private void PreencheGridRegioes()
        {
            var facade = new FacadeEstadoImpl();
            var regioes = new List<Regiao>();
            if (this.EhADM) {
                regioes = facade.ListAllValueObjects<Regiao>().ToList();
            }
            else {
                regioes = facade.obterTodasRegioesDoEstado(this.UsuarioLogado.EstadoUsuario).ToList();
            }
            Session.Add("RegioesNaSessao", regioes);
            grdTodasRegioes.DataSource = regioes;
            grdTodasRegioes.DataBind();
        }

        protected void PreencheComboEstados()
        {
            var facade = new FacadeBaseImpl<Estado>();
            var estadosBrasil = facade.ListAll();

            cboEstado.Items.Clear();

            cboEstado.Items.Add(new Telerik.Web.UI.RadComboBoxItem { Value = "0", Text = "Selecione" });
            foreach (var estado in estadosBrasil)
            {
                cboEstado.Items.Add(new Telerik.Web.UI.RadComboBoxItem { Value = estado.Id.ToString(), Text = estado.NomeEstado });
            }
        }

        protected void cboBloco_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            var idBloco = e.Value != string.Empty ? e.Value : "0";
            var facade = new FacadeEstadoImpl();
            var regioesDoBloco = facade.obterRegioesDoBloco(new Bloco { Id = int.Parse(idBloco) });

            Session.Add("RegioesBlocoSelecionado", regioesDoBloco);
            grdTodasRegioes.DataSource = regioesDoBloco;
            grdTodasRegioes.DataBind();
        }

        protected void cboEstado_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            var idEstado = e.Value != string.Empty ? e.Value : "0";


            var facade = new FacadeEstadoImpl();
            var blocosDoEstado = facade.obterBlocosDoEstado(new Estado { Id = int.Parse(idEstado) });

            if (blocosDoEstado.Count > 0)
            {
                cboBloco.DataSource = blocosDoEstado;
                cboBloco.DataTextField = "NomeBloco";
                cboBloco.DataValueField = "Id";
                cboBloco.DataBind();
            }
            else
            {
                cboBloco.ClearSelection();
                cboBloco.Items.Clear();
            }
        }

        protected void grdTodasRegioes_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            var regioes = (Session["RegioesNaSessao"] as IList<Regiao>);
            grdTodasRegioes.DataSource = regioes;
        }

        protected void grdTodasRegioes_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            grdTodasRegioes.CurrentPageIndex = e.NewPageIndex;
            grdTodasRegioes.Rebind();
        }
    }
}