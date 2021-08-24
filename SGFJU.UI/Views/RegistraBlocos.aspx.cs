using SGFJU.Bussiness.Facade;
using SGFJU.Bussiness.Facade.Exceptions;
using SGFJU.Common.UnityContainer;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.Model.Infra.Serialization;
using SGFJU.Interfaces;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGFJU.UI.Views
{
    public partial class PaginaTeste : SGFJUPaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                CarregaControles();
            }
        }
        private void CarregaControles()
        {
            CarregaComboEstados();
            CarregaBlocos();
        }
        private void CarregaComboEstados()
        {
            if (this.EhADM)
            {
                //var facade = new FacadeBaseImpl<Estado>();
                var estadosBrasil = (Session["TodosEstados"] as IList<Estado>).ToList(); // facade.ListAll();                
                cboEstado.Items.Add(new Telerik.Web.UI.RadComboBoxItem { Value = "0", Text = "Selecione" });
                foreach (var estado in estadosBrasil)
                {
                    cboEstado.Items.Add(new Telerik.Web.UI.RadComboBoxItem { Value = estado.Id.ToString(), Text = estado.NomeEstado });
                }
            }
            else
            {
                cboEstado.Items.Add(new Telerik.Web.UI.RadComboBoxItem
                {
                    Value = this.UsuarioLogado.EstadoUsuario.Id.ToString(),
                    Text = this.UsuarioLogado.EstadoUsuario.NomeEstado
                });
                cboEstado.Enabled = false;
            }
        }
        private void CarregaBlocos()
        {
            var facade = new FacadeEstadoImpl();
            var blocos = new List<Bloco>();
            if (this.EhADM)
            {
                blocos = facade.ListAllValueObjects<Bloco>().ToList();
            }
            else
            {
                blocos = facade.obterBlocosDoEstado(this.UsuarioLogado.EstadoUsuario).ToList();
            }
            Session.Add("Blocos", blocos);
            grdTodosBlocos.DataSource = blocos;
            grdTodosBlocos.DataBind();
        }
        protected void btnCadastrBloco_Click1(object sender, EventArgs e)
        {
            try {
                var nomeEstadoBlocoNovo = cboEstado.Text;
                var facade = new FacadeEstadoImpl();
                var novoBloco = new Bloco { 
                    NomeBloco = Request.Form["nomeBloco"],
                    EstadoBloco = new Estado { 
                        Id = int.Parse(cboEstado.SelectedValue)
                    }
                };
                facade.SaveValueObject<Bloco>(novoBloco);                
                rwmUIApp.RadAlert("<b><font colocar=blue>Bloco cadastrado com sucesso !</font></b>", 300, 180, "Confirmação", null);
                limpaControles();
                novoBloco.EstadoBloco.NomeEstado = nomeEstadoBlocoNovo;
                RegerarArquivoJSONDTO(facade, new BlocoDTO { 
                    idBloco = novoBloco.Id,
                    IdEstadoBloco = novoBloco.EstadoBloco.Id,
                    NomeBloco = novoBloco.NomeBloco
                });
                RecarregarGridBlocos(novoBloco);
            }
            catch (DomainException excDominio) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excDominio, "CAMADA_APP");
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
                rwmUIApp.RadAlert("O sistema de comportou de forma inadequada, por favor realizar pesquisa mais tarde",
                                           400,
                                           150,
                                           "Mensagem de alerta",
                                           null);
            }
            catch (FacadeException excBussiness) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excBussiness, "CAMADA_APP");
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
                rwmUIApp.RadAlert("O sistema de comportou de forma inadequada, por favor realizar pesquisa mais tarde",
                                           400,
                                           150,
                                           "Mensagem de alerta",
                                           null);
            }
            catch (Exception generalException) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(generalException, "CAMADA_APP");
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
                rwmUIApp.RadAlert("O sistema de comportou de forma inadequada, por favor realizar pesquisa mais tarde",
                                           400,
                                           150,
                                           "Mensagem de alerta",
                                           null);
            }
        }
        private void RecarregarGridBlocos(Bloco novoBloco) {
            var blocosNaSessao = (Session["Blocos"] as IList<Bloco>);
            blocosNaSessao.Add(novoBloco);
            grdTodosBlocos.DataSource = blocosNaSessao;
            grdTodosBlocos.Rebind();
        }
        private void limpaControles()
        {            
            cboEstado.SelectedIndex = 0;
        }

        protected void grdTodosBlocos_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            grdTodosBlocos.CurrentPageIndex = e.NewPageIndex;
            grdTodosBlocos.Rebind();
        }
        protected void grdTodosBlocos_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e) {
            var todosBlocos = (Session["Blocos"] as IList<Bloco>);
            grdTodosBlocos.DataSource = todosBlocos;
        }

        private void RegerarArquivoJSONDTO(FacadeEstadoImpl facade, BlocoDTO blocoNovoDTO)
        {
            var serializer = (new UnityDIContainer()).GetServiceImplementationToType<Serializer>();
            var caminhoPastaArquivosSerializados = ConfigurationManager.AppSettings["PathArquivosObjetosSerializados"];
            var caminhoPastaArquivosOndeSerializar = "";
            var sigalEstado = "";
            if (this.EhADM)
                sigalEstado = (Session["TodosEstados"] as IList<Estado>).Where(e => e.Id == blocoNovoDTO.IdEstadoBloco).FirstOrDefault().SiglaEstado;
            else
                sigalEstado = UsuarioLogado.EstadoUsuario.SiglaEstado;
            caminhoPastaArquivosOndeSerializar = Server.MapPath(caminhoPastaArquivosSerializados + "\\" + sigalEstado + "_Blocos.txt");
            var todosBlocoDTO = facade.ListAllValueObjectsFromJson<BlocoDTO>(caminhoPastaArquivosOndeSerializar);
            todosBlocoDTO.Add(blocoNovoDTO);
            (serializer as JSONSerializer).SerializeToJSON(todosBlocoDTO, caminhoPastaArquivosOndeSerializar);
        }
    }
}