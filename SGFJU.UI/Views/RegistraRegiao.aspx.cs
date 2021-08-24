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
using Telerik.Web.UI;

namespace SGFJU.UI.Views
{
    public partial class RegistraRegiao : SGFJUPaginaBase
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
            try
            {
                //PreencheComboEstados();                

                if (UsuarioLogado != null)
                {
                    if(EhADM) {
                        PreencheComboEstados();
                    }
                    else {
                        cboEstado.Items.Add(new Telerik.Web.UI.RadComboBoxItem
                        {
                            Value = this.UsuarioLogado.EstadoUsuario.Id.ToString(),
                            Text = this.UsuarioLogado.EstadoUsuario.NomeEstado
                        });
                        cboEstado.Enabled = false;
                        cboEstado_SelectedIndexChanged(this, new RadComboBoxSelectedIndexChangedEventArgs(
                            UsuarioLogado.EstadoUsuario.NomeEstado,
                            UsuarioLogado.EstadoUsuario.NomeEstado,
                            UsuarioLogado.EstadoUsuario.Id.ToString(),
                            UsuarioLogado.EstadoUsuario.Id.ToString()
                        ));
                    }
                    PreencheGridRegioes();
                }
            }
            catch (DomainException excDominio) {
                var mensagemErroExcecao = string.Format("Ocorreu o seguinte erro na camada de domínio {0} : ", excDominio.Message);
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
                rwmUIApp.RadAlert("O sistema de comportou de forma inadequada, por favor realizar tente mais tarde",
                                           400,
                                           150,
                                           "Mensagem de alerta",
                                           null);
            }
            catch (FacadeException excBussiness) {
                var mensagemErroExcecao = string.Format("Ocorreu o seguinte erro na camada de negócios {0} : ", excBussiness.Message);
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
                rwmUIApp.RadAlert("O sistema de comportou de forma inadequada, por favor realizar tente mais tarde",
                                           400,
                                           150,
                                           "Mensagem de alerta",
                                           null);
            }
            catch (Exception generalException) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(generalException, "CAMADA_APP");
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
                rwmUIApp.RadAlert("O sistema de comportou de forma inadequada, por favor realizar tente mais tarde",
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
            if (this.EhADM)
            {
                regioes = facade.ListAllValueObjects<Regiao>().ToList();
            }
            else
            {
                regioes = facade.obterTodasRegioesDoEstado(this.UsuarioLogado.EstadoUsuario).ToList();
            }
            Session.Add("RegioesNaSessao", regioes);
            grdTodasRegioes.DataSource = regioes;
            grdTodasRegioes.DataBind();
        }

        protected void PreencheComboEstados()
        {
            //var facade = new FacadeBaseImpl<Estado>();
            var estadosBrasil = (Session["TodosEstados"] as IList<Estado>).ToList();//facade.ListAll();

            cboEstado.Items.Clear();
            //cboEstadosBrasil.Items.Clear();

            cboEstado.Items.Add(new Telerik.Web.UI.RadComboBoxItem { Value = "0", Text = "Selecione" });
            //cboEstadosBrasil.Items.Add(new Telerik.Web.UI.RadComboBoxItem { Value = "0", Text = "Selecione" });
            foreach (var estado in estadosBrasil)
            {
                cboEstado.Items.Add(new Telerik.Web.UI.RadComboBoxItem { Value = estado.Id.ToString(), Text = estado.NomeEstado });
                //cboEstadosBrasil.Items.Add(new Telerik.Web.UI.RadComboBoxItem { Value = estado.Id.ToString(), Text = estado.NomeEstado });
            }
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
        protected void grdTodasRegioes_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            grdTodasRegioes.CurrentPageIndex = e.NewPageIndex;
            grdTodasRegioes.Rebind();
        }

        protected void grdTodasRegioes_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            var regioes = (Session["RegioesNaSessao"] as IList<Regiao>);
            grdTodasRegioes.DataSource = regioes;
        }

        protected void btnCadastraRegiao_Click(object sender, EventArgs e) {
            try {
                if (cboBloco.Items.Count == 0) {
                    rwmUIApp.RadAlert("<b><font color=red>É necessário escolher o bloco à qual região pertence</font></b>",
                                           400,
                                           150,
                                           "Mensagem de alerta",
                                           null);
                    return;
                }

                var idEstado = (cboEstado.SelectedIndex != -1) ? int.Parse(cboEstado.SelectedValue) : 0;
                var nomeEstado = cboEstado.Text; //depois tirar
                var nomeBloco = cboBloco.Text; //depois tirar
                var facade = new FacadeEstadoImpl();
                var novaRegiao = new Regiao { 
                    NomeRegiao = Request.Form["nomeRegiao"],
                    BlocoRegiao = new Bloco { 
                        Id = int.Parse(cboBloco.SelectedValue)
                    }
                };
                facade.SaveValueObject<Regiao>(novaRegiao);
                rwmUIApp.RadAlert("<b><font color=blue>Região cadastrada com sucesso!!!</font></b>",
                                           400,
                                           150,
                                           "Mensagem de confirmação",
                                           null);
                limpaControles();
                novaRegiao.BlocoRegiao.NomeBloco = nomeBloco;
                novaRegiao.BlocoRegiao.EstadoBloco = new Estado { NomeEstado = nomeEstado };
                RegerarArquivoJSONDTO(facade, new RegiaoDTO{
                    idBloco = novaRegiao.BlocoRegiao.Id,
                    IdRegiao = novaRegiao.Id,
                    NomeRegiao = novaRegiao.NomeRegiao
                }, idEstado);
                RecarregarGridRegioes(novaRegiao);
            }
            catch (DomainException excDominio) {
                var mensagemErroExcecao = string.Format("Ocorreu o seguinte erro na camada de domínio {0} : ", excDominio.Message);
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
                rwmUIApp.RadAlert("O sistema de comportou de forma inadequada, por favor realizar tente mais tarde",
                                           400,
                                           150,
                                           "Mensagem de alerta",
                                           null);
            }
            catch (FacadeException excBussiness) {
                var mensagemErroExcecao = string.Format("Ocorreu o seguinte erro na camada de negócios {0} : ", excBussiness.Message);
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
                rwmUIApp.RadAlert("O sistema de comportou de forma inadequada, por favor realizar tente mais tarde",
                                           400,
                                           150,
                                           "Mensagem de alerta",
                                           null);
            }
            catch (Exception generalException) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(generalException, "CAMADA_APP");
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
                rwmUIApp.RadAlert("O sistema de comportou de forma inadequada, por favor realizar tente mais tarde",
                                           400,
                                           150,
                                           "Mensagem de alerta",
                                           null);
            }
        }
        private void limpaControles()
        {
            if (this.EhADM) {
                cboEstado.SelectedIndex = 0;
                cboBloco.Items.Clear();
                cboBloco.ClearSelection();
            }
        }
        private void RecarregarGridRegioes(Regiao novaRegiao)
        {
            var regioesNaSessao = (Session["RegioesNaSessao"] as IList<Regiao>);
            regioesNaSessao.Add(novaRegiao);
            grdTodasRegioes.DataSource = regioesNaSessao;
            grdTodasRegioes.Rebind();
        }

        protected void RegerarArquivoJSONDTO(FacadeEstadoImpl facade, RegiaoDTO regiaoDTO, int idEstadoParametro) {
            var serializer = (new UnityDIContainer()).GetServiceImplementationToType<Serializer>();
            var caminhoPastaArquivosSerializados = ConfigurationManager.AppSettings["PathArquivosObjetosSerializados"];
            var caminhoPastaArquivosOndeSerializar = "";
            var sigalEstado = "";
            if (System.IO.File.Exists(caminhoPastaArquivosOndeSerializar)) {
                if (this.EhADM)
                    sigalEstado = (Session["TodosEstados"] as IList<Estado>).Where(e => e.Id == idEstadoParametro).FirstOrDefault().SiglaEstado;
                else
                    sigalEstado = UsuarioLogado.EstadoUsuario.SiglaEstado;
                caminhoPastaArquivosOndeSerializar = Server.MapPath(caminhoPastaArquivosSerializados + "\\" + sigalEstado + "_Regioes.txt");
                var todasRegioesDTO = facade.ListAllValueObjectsFromJson<RegiaoDTO>(caminhoPastaArquivosOndeSerializar);
                todasRegioesDTO.Add(regiaoDTO);
                (serializer as JSONSerializer).SerializeToJSON(todasRegioesDTO, caminhoPastaArquivosOndeSerializar);
            }
        }
    }
}