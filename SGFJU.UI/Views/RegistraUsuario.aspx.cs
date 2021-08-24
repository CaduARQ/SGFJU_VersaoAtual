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
    public partial class RegistraUsuario : SGFJUPaginaBase
    {
        protected void Page_Load(object sender, EventArgs e) {
            if (!Page.IsPostBack)
                CarregaControles();
        }

        private void CarregaControles()
        {
            var facade = new FacadeBaseImpl<Estado>();

            cboEstado.DataTextField = "NomeEstado";
            cboEstado.DataValueField = "ID";
            var estadosBrasil = facade.ListAll();
            cboEstado.DataSource = estadosBrasil;
            cboEstado.DataBind();
        }

        protected void btnCadastrarTestemunho_Click(object sender, EventArgs e)
        {            
            try {
                var controler = new FacadeBaseImpl<Usuario>();
                //var senha = Encoding.ASCII.GetBytes(txtSenha.Text);
                var mensagemValidação = "";


                if (string.IsNullOrEmpty(txtNome.Text))
                {
                    mensagemValidação += "<b><font color=red>Os campos abaixo não pode estar em branco:</font></b> <br>";
                    mensagemValidação += "<b>Campo Nome</b><br>";
                }

                if (string.IsNullOrEmpty(txtLogin.Text))
                    mensagemValidação += "<b>Campo Login</b><br>";

                if (string.IsNullOrEmpty(txtSenha.Text))
                    mensagemValidação += "<b>Campo senha</b><br>";

                if (cboTipoUsuario.SelectedIndex == 0)
                    mensagemValidação += "<b>Tipode Usuário</b><br>";

                if (cboEstado.SelectedIndex == -1)
                    mensagemValidação += "<b>Campo Estado</b><br>";

                if (!string.IsNullOrEmpty(mensagemValidação)) {
                    RadWindowManager1.RadAlert(mensagemValidação, 500, 250, "Validação", null);
                    return;
                }

                var novoUsuario = new Usuario
                {
                    Login = txtLogin.Text,
                    Senha = txtSenha.Text,
                    EstadoUsuario = new Estado
                    {
                        Id = int.Parse(cboEstado.SelectedValue)
                    },
                    PerfilUsuario = new Domain.Model.ValueObjects.PerfilUsuario { Code = int.Parse(cboTipoUsuario.SelectedValue) }
                };

                controler.Save(novoUsuario);
                RadWindowManager1.RadAlert("Usuário cadastrado com sucesso!!!", 200, 200, "Confirmação", null);
                limpaControles();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void limpaControles()
        {
            txtNome.Text = "";
            txtSenha.Text = "";
            txtLogin.Text = "";
            cboTipoUsuario.ClearSelection();
            cboEstado.ClearSelection();
        }
    }
}