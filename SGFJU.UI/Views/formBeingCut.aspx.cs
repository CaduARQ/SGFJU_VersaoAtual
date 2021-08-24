
using HibernatingRhinos.Profiler.Appender.NHibernate;
using SGFJU.Bussiness.Facade;
using SGFJU.Bussiness.Facade.Exceptions;
using SGFJU.Common.UnityContainer;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.Model.Infra.Logging.Implementation;
using SGFJU.Domain.Model.Infra.Serialization;
using SGFJU.Domain.Model.ValueObjects;
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
    public partial class formBeingCut : SGFJUPaginaBase
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
                PreencheComboEstados();

                if (UsuarioLogado != null)
                {
                    if (UsuarioLogado.PerfilUsuario.Code != codigoPerfilADM)
                    {
                        cboEstado_SelectedIndexChanged(this, new RadComboBoxSelectedIndexChangedEventArgs(
                            UsuarioLogado.EstadoUsuario.NomeEstado,
                            UsuarioLogado.EstadoUsuario.NomeEstado,
                            UsuarioLogado.EstadoUsuario.Id.ToString(),
                            UsuarioLogado.EstadoUsuario.Id.ToString()
                        ));
                        cboEstado.Enabled = false;
                    }
                }

                PreencheComboProjetos();
                PreencheComboTribos();
                PreencheCheckLivros();
                PreencheRadioTipoMoradia();
                PreencheRadioTipoEstadoCivil();
                PreencheCheckReunioesFJU();
                PreencheControleFrequenciaLeitura();
                //CarregaDepartamentosProjeto();
                //CarregaNivel();
                //CarregaParaSessaoTodasHabilidades();
            }
            catch (Exception excLoadControles)
            {
                var mensagemErroExcecao = string.Format("Ocorreu o seguinte erro, ao carregar controles da página{0}", excLoadControles.Message);
                //base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
                rwmUIApp.RadAlert("O sistema de comportou de forma inadequada, por favor tente mais tarde",
                                           400,
                                           150,
                                           "Mensagem de alerta",
                                           null);
            }
        }
        protected void PreencheComboEstados()
        {
            var facade = new FacadeBaseImpl<Estado>();
            var estadosBrasil = facade.ListAll();

            cboEstado.Items.Clear();
            cboEstadosBrasil.Items.Clear();

            cboEstado.Items.Add(new Telerik.Web.UI.RadComboBoxItem { Value = "0", Text = "Selecione" });
            cboEstadosBrasil.Items.Add(new Telerik.Web.UI.RadComboBoxItem { Value = "0", Text = "Selecione" });
            foreach (var estado in estadosBrasil)
            {
                cboEstado.Items.Add(new Telerik.Web.UI.RadComboBoxItem { Value = estado.Id.ToString(), Text = estado.NomeEstado });
                cboEstadosBrasil.Items.Add(new Telerik.Web.UI.RadComboBoxItem { Value = estado.Id.ToString(), Text = estado.NomeEstado });
            }
        }
        private void PreencheComboProjetos()
        {

            var facade = new FacadeBaseImpl<Estado>();

            List<ProjetoDTO> todosProjetosFJU = null;
            var arquivoProjetosSerializados = this.retornaCaminhoFisicoCompleto(ConfigurationManager.AppSettings["ProjectsSerializedFileName"]);            

            Func<Projeto, ProjetoDTO> projetoToProjetoDTO = (Projeto p) => new ProjetoDTO {
                IdProjeto = p.Code,
                NomeProjeto = p.NomeProjeto
            };
            todosProjetosFJU = facade.ListAllObjectsFromTypeAsDTO<Projeto, ProjetoDTO>(projetoToProjetoDTO, arquivoProjetosSerializados).ToList();

            //rbListaProjetos.Items.Add(new Telerik.Web.UI.ButtonListItem { Text = "Nenhum", Value = "0" });
            //cboProjetoAnterior0.Items.Add(new DropDownListItem { Text = "Selecione", Value = "0" });
            cboProjetoFJU.Items.Add(new DropDownListItem { Text = "Selecione", Value = "0" });
            foreach (var projeto in todosProjetosFJU)
            {
                //rbListaProjetos.Items.Add(new Telerik.Web.UI.ButtonListItem { Text = projeto.NomeProjeto, Value = projeto.IdProjeto.ToString() });

                //cboProjetoAnterior0.Items.Add(new Telerik.Web.UI.DropDownListItem { Text = projeto.NomeProjeto, Value = projeto.IdProjeto.ToString() });

                cboProjetoFJU.Items.Add(new Telerik.Web.UI.DropDownListItem { Text = projeto.NomeProjeto, Value = projeto.IdProjeto.ToString() });
            }


            Session.Add("TodosProjetosFJU", todosProjetosFJU);
        }
        private void PreencheRadioTipoMoradia()
        {
            var serializer = (new UnityDIContainer()).GetServiceImplementationToType<Serializer>();
            var facade = new FacadeBaseImpl<Estado>();
            var todosTiposMoradia = new List<TipoMoradia>();
            var arquivoTiposMoradiaSerializados = this.retornaCaminhoFisicoCompleto(ConfigurationManager.AppSettings["TiposMoradiaSerializedFileName"]);
            if (System.IO.File.Exists(arquivoTiposMoradiaSerializados))
                todosTiposMoradia = facade.ListAllValueObjectsFromJson<TipoMoradia>(arquivoTiposMoradiaSerializados) as List<TipoMoradia>;
            else
            {
                todosTiposMoradia = facade.ListAllValueObjects<TipoMoradia>().ToList();
                (serializer as JSONSerializer).SerializeToJSON(todosTiposMoradia, arquivoTiposMoradiaSerializados);
            }
            foreach (var tipoMoradia in todosTiposMoradia)
            {
                rbTipoMoradia.Items.Add(new Telerik.Web.UI.ButtonListItem { Text = tipoMoradia.Descricao, Value = tipoMoradia.Code.ToString() });
            }
        }
        private void PreencheRadioTipoEstadoCivil()
        {
            var serializer = (new UnityDIContainer()).GetServiceImplementationToType<Serializer>();
            var facade = new FacadeBaseImpl<Estado>();
            var todosEstadoCivis = new List<TipoEstadoCivil>();
            var arquivoEstadoCivisSerializados = this.retornaCaminhoFisicoCompleto(ConfigurationManager.AppSettings["EstadosCivisSerializedFileName"]);
            if (System.IO.File.Exists(arquivoEstadoCivisSerializados))
                todosEstadoCivis = facade.ListAllValueObjectsFromJson<TipoEstadoCivil>(arquivoEstadoCivisSerializados) as List<TipoEstadoCivil>;
            else
            {
                todosEstadoCivis = facade.ListAllValueObjects<TipoEstadoCivil>().ToList();
                (serializer as JSONSerializer).SerializeToJSON(todosEstadoCivis, arquivoEstadoCivisSerializados);
            }
            if (todosEstadoCivis != null)
            {
                foreach (var estadoCivil in todosEstadoCivis)
                {
                    rbTipoEstadoCivil.Items.Add(new Telerik.Web.UI.ButtonListItem { Text = estadoCivil.Descricao, Value = estadoCivil.Code.ToString() });
                }
            }
        }
        private void PreencheComboTribos()
        {
            var facade = new FacadeBaseImpl<Estado>();
            var tribos = facade.ListAllValueObjects<Tribo>();
            cboTribos.Items.Add(new DropDownListItem { Text = "Selecione", Value = "0" });
            foreach (var tribo in tribos)
            {
                cboTribos.Items.Add(new DropDownListItem { Text = tribo.Descricao, Value = tribo.Code.ToString() });
            }
            //cboTribos.DataSource = tribos;
            //cboTribos.DataTextField = "Descricao";
            //cboTribos.DataValueField = "Code";
            //cboTribos.DataBind();
        }
        private void PreencheCheckLivros()
        {
            var facade = new FacadeBaseImpl<Estado>();
            var livrosIURD = facade.ListAllValueObjects<Livro>();

            foreach (var livro in livrosIURD) {                
                chkLivros.Items.Add(new Telerik.Web.UI.ButtonListItem { Text = livro.NomeLivro, Value = livro.Code.ToString() });
            }
        }
        private void PreencheCheckReunioesFJU()
        {
            var facade = new FacadeBaseImpl<Estado>();
            var reunioesFJU = facade.ListAllValueObjects<ReuniaoFJU>();

            foreach (var reuniao in reunioesFJU)
            {
                chkReunioesFJU2.Items.Add(new Telerik.Web.UI.ButtonListItem { Text = reuniao.NomeReuniaoFJU, Value = reuniao.Code.ToString() });
            }
        }
        private void PreencheControleFrequenciaLeitura()
        {
            var facade = new FacadeBaseImpl<Estado>();
            var frequenciaLeitura = facade.ListAllValueObjects<FrequenciaLeitura>();
            foreach (var frequencia in frequenciaLeitura)
            {
                rbFrequenciaLeituraBiblia.Items.Add(new Telerik.Web.UI.ButtonListItem { Text = frequencia.Descricao, Value = frequencia.Code.ToString() });
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

                cboRegiao.ClearSelection();
                cboRegiao.Items.Clear();

                cboIgreja.ClearSelection();
                cboIgreja.Items.Clear();
            }
            else
            {
                cboBloco.ClearSelection();
                cboBloco.Items.Clear();

                cboRegiao.ClearSelection();
                cboRegiao.Items.Clear();

                cboIgreja.ClearSelection();
                cboIgreja.Items.Clear();
            }
        }
        protected void cboBloco_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            var idBloco = e.Value != string.Empty ? e.Value : "0";
            var facade = new FacadeEstadoImpl();
            var regioesDoBloco = facade.obterRegioesDoBloco(new Bloco { Id = int.Parse(idBloco) });

            if (regioesDoBloco.Count > 0)
            {
                cboRegiao.DataSource = regioesDoBloco;
                cboRegiao.DataValueField = "Id";
                cboRegiao.DataTextField = "NomeRegiao";
                cboRegiao.DataBind();
            }
            else
            {
                cboRegiao.ClearSelection();
                cboRegiao.Items.Clear();
            }

            cboIgreja.ClearSelection();
            cboIgreja.Items.Clear();
        }
        protected void cboRegiao_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            var idRegiao = e.Value != string.Empty ? e.Value : "0";
            var facade = new FacadeEstadoImpl();
            var igrejasDaRegiao = facade.obterIgrejasDaRegiao(new Regiao { Id = int.Parse(idRegiao) });
            Session.Add("IgrejasDaRegiao", igrejasDaRegiao);

            cboIgreja.DataSource = igrejasDaRegiao;
            cboIgreja.DataValueField = "Id";
            cboIgreja.DataTextField = "NomeIgreja";
            cboIgreja.DataBind();
        }
        protected string retornaCaminhoFisicoCompleto(string nomeArquivo)
        {
            var caminhoPastaArquivosSerializados = ConfigurationManager.AppSettings["PathArquivosObjetosSerializados"];
            return System.Web.Hosting.HostingEnvironment.MapPath(caminhoPastaArquivosSerializados + "\\" + nomeArquivo);
        }
    }
}