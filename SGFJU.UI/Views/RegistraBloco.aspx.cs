using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGFJU.UI.Views
{
    public partial class RegistraBloco : SGFJUPaginaBase
    {
        protected void Page_Load(object sender, EventArgs e) {
            if (!Page.IsPostBack) {
                CarregaControles();                
            }
        }
        private void CarregaControles() {
            CarregaComboEstados();
            CarregaBlocos();
        }
        private void CarregaComboEstados() {
            if (this.EhADM) {
                var facade = new FacadeBaseImpl<Estado>();
                var estadosBrasil = facade.ListAll();
                cboEstado.Items.Add(new Telerik.Web.UI.RadComboBoxItem { Value = "0", Text = "Selecione" });
                foreach (var estado in estadosBrasil) {
                    cboEstado.Items.Add(new Telerik.Web.UI.RadComboBoxItem { Value = estado.Id.ToString(), Text = estado.NomeEstado });
                }
            }
            else {
                cboEstado.Items.Add(new Telerik.Web.UI.RadComboBoxItem
                {
                    Value = this.UsuarioLogado.EstadoUsuario.Id.ToString(),
                    Text = this.UsuarioLogado.EstadoUsuario.NomeEstado
                });
                cboEstado.Enabled = false;
            }
        }
        private void CarregaBlocos() {
            var facade = new FacadeEstadoImpl();
            var blocos = new List<Bloco>();
            if (this.EhADM) {
                blocos = facade.ListAllValueObjects<Bloco>().ToList();
            }
            else {
                blocos = facade.obterBlocosDoEstado(this.UsuarioLogado.EstadoUsuario).ToList();
            }
            Session.Add("BlocosListados", blocos);
            grdTodosBlocos.DataSource = blocos;
            grdTodosBlocos.DataBind();
        }

        protected void btnCadastrBloco_Click(object sender, EventArgs e) {
            var facade = new FacadeEstadoImpl();
            var novoBloco = new Bloco { 
                NomeBloco = txtNome.Text,
                EstadoBloco = new Estado { 
                    Id = int.Parse(cboEstado.SelectedValue)
                }
            };
            if (txtNome.Text == string.Empty)
                rwmUIApp.RadAlert("Nome do Bloco não pode ficar em branco !", 300, 180, "Confirmação", null);
            else {
                facade.SaveValueObject<Bloco>(novoBloco);
                rwmUIApp.RadAlert("Bloco cadastrado com sucesso !", 300, 180, "Confirmação", null);
            }
        }

        protected void grdTodosBlocos_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            grdTodosBlocos.CurrentPageIndex = e.NewPageIndex;
            Rebind();
        }

        private void Rebind(){
            if (Session["BlocosListados"] != null)
                grdTodosBlocos.DataSource = (Session["BlocosListados"] as IList<Bloco>).ToList();
            grdTodosBlocos.DataBind();
        }
    }
}