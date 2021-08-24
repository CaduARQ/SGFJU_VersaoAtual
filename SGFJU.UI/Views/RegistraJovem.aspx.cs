
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
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace SGFJU.UI.Views
{
    public partial class RegistraJovem : SGFJUPaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                this.CarregaControles();
            }
        }

        private void CarregaControles()
        {
            var codigoPerfilADM = int.Parse(ConfigurationManager.AppSettings["CodeADM"]);
            try {
                PreencheComboEstados();

                if (UsuarioLogado != null)
                {
                    if (UsuarioLogado.PerfilUsuario.Code != codigoPerfilADM)
                    {
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
                }

                PreencheComboProjetos();
                PreencheComboTribos();
                PreencheCheckLivros();
                PreencheRadioTipoMoradia();
                PreencheRadioTipoEstadoCivil();
                PreencheCheckReunioesFJU();
                PreencheControleFrequenciaLeitura();
                CarregaDepartamentosProjeto();
                CarregaNivel();
                CarregaParaSessaoTodasHabilidades();
            }
            catch (Exception excLoadControles ) {
                //var mensagemErroExcecao = string.Format("Ocorreu o seguinte erro, ao carregar controles da página{0}", excLoadControles.Message);
                var mensagemFormatada = ExceptionManager.FormatExceptionMessage(excLoadControles);
                base.LoggerErrorApp.WriteLog(string.Format("Ocorreu o seguinte erro, ao carregar controles da página{0} - ", mensagemFormatada));
                RadWindowManager1.RadAlert("O sistema de comportou de forma inadequada, por favor tente mais tarde",
                                           400,
                                           150,
                                           "Mensagem de alerta",
                                           null);
            }
        }

        private void CarregaParaSessaoTodasHabilidades()
        {
            var serializer = (new UnityDIContainer()).GetServiceImplementationToType<Serializer>();
            var facade = new FacadeBaseImpl<Estado>();
            var todasHabilidade = new List<HabilidadeProjetoDTO>();
            var arquivoHabilidadeCivisSerializados = this.retornaCaminhoFisicoCompleto(ConfigurationManager.AppSettings["HabilitiesSerializedFileName"]);
            if (System.IO.File.Exists(arquivoHabilidadeCivisSerializados))
                todasHabilidade = facade.ListAllValueObjectsFromJson<HabilidadeProjetoDTO>(arquivoHabilidadeCivisSerializados) as List<HabilidadeProjetoDTO>;
            else
            {
                var habilidadeProjetoFJU = facade.ListAllValueObjects<HabilidadeProjeto>()
                                                .Select(t => new HabilidadeProjetoDTO
                                                {
                                                    IdProjeto = t.ProjetoRelacionado.Code,
                                                    NomeProjeto = t.ProjetoRelacionado.NomeProjeto,
                                                    IdDepartamento = (t.DepartamentoRelacionado != null)?t.DepartamentoRelacionado.Code:0,
                                                    NomeDepartamento = (t.DepartamentoRelacionado != null) ? t.DepartamentoRelacionado.NomeDepartamentoProjeto : string.Empty,
                                                    IdHabilidade = t.Code,
                                                    NomeHabilidade = t.NomeHabilidade
                                                }).ToList();
                todasHabilidade = habilidadeProjetoFJU;
                (serializer as JSONSerializer).SerializeToJSON(todasHabilidade, arquivoHabilidadeCivisSerializados);
            }
            Session.Add("TodasHabilidades", todasHabilidade);
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
            if (todosEstadoCivis != null) {
                foreach (var estadoCivil in todosEstadoCivis)
                {
                    rbTipoEstadoCivil.Items.Add(new Telerik.Web.UI.ButtonListItem { Text = estadoCivil.Descricao, Value = estadoCivil.Code.ToString() });
                }
            }
        }

        private void PreencheRadioTipoMoradia()
        {
            var serializer = (new UnityDIContainer()).GetServiceImplementationToType<Serializer>();
            var facade = new FacadeBaseImpl<Estado>();
            var todosTiposMoradia = new List<TipoMoradia>();
            var arquivoTiposMoradiaSerializados = this.retornaCaminhoFisicoCompleto(ConfigurationManager.AppSettings["TiposMoradiaSerializedFileName"]);
            if (System.IO.File.Exists(arquivoTiposMoradiaSerializados))
                todosTiposMoradia = facade.ListAllValueObjectsFromJson<TipoMoradia>(arquivoTiposMoradiaSerializados) as List<TipoMoradia>;
            else {
                todosTiposMoradia = facade.ListAllValueObjects<TipoMoradia>().ToList();
                (serializer as JSONSerializer).SerializeToJSON(todosTiposMoradia, arquivoTiposMoradiaSerializados);
            }
            foreach (var tipoMoradia in todosTiposMoradia){
                rbTipoMoradia.Items.Add(new Telerik.Web.UI.ButtonListItem { Text = tipoMoradia.Descricao, Value = tipoMoradia.Code.ToString() });
            }
        }

        private void CarregaNivel()
        {
            var serializer = (new UnityDIContainer()).GetServiceImplementationToType<Serializer>();
            var facade = new FacadeBaseImpl<Estado>();
            var todosNiveis = new List<Nivel>();
            var arquivoNiveisSerializados = this.retornaCaminhoFisicoCompleto(ConfigurationManager.AppSettings["NiveisSerializedFileName"]);
            if (System.IO.File.Exists(arquivoNiveisSerializados))
                todosNiveis = facade.ListAllValueObjectsFromJson<Nivel>(arquivoNiveisSerializados) as List<Nivel>;
            else {
                todosNiveis = facade.ListAllValueObjects<Nivel>().ToList();
                (serializer as JSONSerializer).SerializeToJSON(todosNiveis, arquivoNiveisSerializados);
            }
            Session.Add("todosNiveis", todosNiveis);
        }

        private void CarregaDepartamentosProjeto()
        {
            var serializer = (new UnityDIContainer()).GetServiceImplementationToType<Serializer>();
            var facade = new FacadeBaseImpl<Estado>();

            List<DepartamentoProjetoDTO> todosDepartamentosProjetos = null;
            var arquivoDepartamentoProjetosSerializados = this.retornaCaminhoFisicoCompleto(ConfigurationManager.AppSettings["DepartamentsProjectsSerializedFileName"]);

            if (System.IO.File.Exists(arquivoDepartamentoProjetosSerializados))
                //todosDepartamentosProjetos = serializer.Deserialized<IList<DepartamentoProjetoDTO>>(arquivoDepartamentoProjetosSerializados) as List<DepartamentoProjetoDTO>;
                todosDepartamentosProjetos = facade.ListAllValueObjectsFromJson<DepartamentoProjetoDTO>(arquivoDepartamentoProjetosSerializados) as List<DepartamentoProjetoDTO>;
            else
            {
                var departamentosProjetosFJU = facade.ListAllValueObjects<DepartamentoProjeto>();
                todosDepartamentosProjetos = departamentosProjetosFJU.Select(t => new DepartamentoProjetoDTO
                {
                    IdProjeto = t.Projeto.Code,
                    NomeProjeto = t.Projeto.NomeProjeto,
                    IdDepartamento = t.Code,
                    NomeDepartamento = t.NomeDepartamentoProjeto
                }).ToList();
                (serializer as JSONSerializer).SerializeToJSON(todosDepartamentosProjetos, arquivoDepartamentoProjetosSerializados);
            }

            Session.Add("DepartamentosProjeto", todosDepartamentosProjetos);
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

        protected void PreencheComboEstados()
        {
            var facade = new FacadeBaseImpl<Estado>();
            var estadosBrasil = facade.ListAll();

            Session.Add("TodosEstados", estadosBrasil);

            cboEstado.Items.Clear();

            if (this.EhADM) {
                cboEstado.Items.Add(new Telerik.Web.UI.RadComboBoxItem { Value = "0", Text = "Selecione" });

                foreach (var estado in estadosBrasil)
                {
                    cboEstado.Items.Add(new Telerik.Web.UI.RadComboBoxItem { Value = estado.Id.ToString(), Text = estado.NomeEstado });
                }
            }
        }
        private void PreencheComboProjetos()
        {

            var serializer = (new UnityDIContainer()).GetServiceImplementationToType<Serializer>();
            var facade = new FacadeBaseImpl<Estado>();

            List<ProjetoDTO> todosProjetosFJU = null;
            var arquivoProjetosSerializados = this.retornaCaminhoFisicoCompleto(ConfigurationManager.AppSettings["ProjectsSerializedFileName"]);


            //if (System.IO.File.Exists(arquivoProjetosSerializados))
            //    todosProjetosFJU = serializer.Deserialized<IList<ProjetoDTO>>(arquivoProjetosSerializados) as List<ProjetoDTO>;
            //else
            //{
            //    var projetosFJU = facade.ListAllValueObjects<Projeto>();
            //    todosProjetosFJU = projetosFJU.Select(t => new ProjetoDTO
            //    {
            //        IdProjeto = t.Code,
            //        NomeProjeto = t.NomeProjeto
            //    }).ToList();
            //    (serializer as JSONSerializer).SerializeToJSON(todosProjetosFJU, arquivoProjetosSerializados);
            //}

            //----
            try{
                if (System.IO.File.Exists(arquivoProjetosSerializados))
                    todosProjetosFJU = serializer.Deserialized<IList<ProjetoDTO>>(arquivoProjetosSerializados) as List<ProjetoDTO>;
                else {
                    var projetosFJU = facade.ListAllValueObjects<Projeto>();
                    todosProjetosFJU = projetosFJU.Select(t => new ProjetoDTO
                    {
                        IdProjeto = t.Code,
                        NomeProjeto = t.NomeProjeto
                    }).ToList();
                    (serializer as JSONSerializer).SerializeToJSON(todosProjetosFJU, arquivoProjetosSerializados);
                }
            }
            catch (Exception exc){
                var pathArquivoLoggerError =
                    System.Web.Hosting.HostingEnvironment.MapPath(
                        ConfigurationManager.AppSettings["LoggerFilePath"] +
                        ConfigurationManager.AppSettings["LoggerErrorFileName"]
                    );//System.Web.Hosting.HostingEnvironment.MapPath("~/LogWebApp/ErrorApp.txt");
                var errorLogger = new ErrorLoggerImpl(pathArquivoLoggerError);
                errorLogger.WriteLog("ao ler arquivo JSON: " + exc.InnerException.Message + "\n " +
                                     "             target: " + exc.StackTrace             + "\n" +
                                     "             source: " + exc.Source     );
            }
            //--


            rbListaProjetos.Items.Add(new Telerik.Web.UI.ButtonListItem { Text = "Nenhum", Value = "0" });
            cboProjetoAnterior0.Items.Add(new DropDownListItem { Text = "Selecione", Value = "0" });
            cboProjetoFJU.Items.Add(new DropDownListItem { Text = "Selecione", Value = "0" });
            foreach (var projeto in todosProjetosFJU) {
                rbListaProjetos.Items.Add(new Telerik.Web.UI.ButtonListItem { Text = projeto.NomeProjeto, Value = projeto.IdProjeto.ToString() });

                cboProjetoAnterior0.Items.Add(new Telerik.Web.UI.DropDownListItem { Text = projeto.NomeProjeto, Value = projeto.IdProjeto.ToString() });

                cboProjetoFJU.Items.Add(new Telerik.Web.UI.DropDownListItem { Text = projeto.NomeProjeto, Value = projeto.IdProjeto.ToString() });
            }

            //cboProjetoFJU.DataSource = todosProjetosFJU;
            //cboProjetoFJU.DataTextField = "NomeProjeto";
            //cboProjetoFJU.DataValueField = "IdProjeto";
            //cboProjetoFJU.DataBind();

            //cboProjetoAnterior0.DataSource = todosProjetosFJU;
            //cboProjetoAnterior0.DataTextField = "NomeProjeto";
            //cboProjetoAnterior0.DataValueField = "IdProjeto";
            //cboProjetoAnterior0.DataBind();

            Session.Add("TodosProjetosFJU", todosProjetosFJU);
        }
        private void PreencheComboTribos()
        {
            var facade = new FacadeBaseImpl<Estado>();
            var tribos = facade.ListAllValueObjects<Tribo>();
            cboTribos.Items.Add(new DropDownListItem { Text = "Selecione", Value = "0" });
            foreach (var tribo in tribos){
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

            foreach (var livro in livrosIURD)
            {                
                chkLivros2.Items.Add(new Telerik.Web.UI.ButtonListItem{ Text = livro.NomeLivro, Value = livro.Code.ToString() });
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
        protected void RadWizard1_FinishButtonClick(object sender, Telerik.Web.UI.WizardEventArgs e)
        {
            try
            {
                NHibernateProfiler.Initialize();

                if (cboIgreja.SelectedIndex == -1) {
                    RadWindowManager1.RadAlert("<b><font color=red>Para finalizar o cadastro do Jovem é necessário selecionar uma igreja!!</font></b>",
                                           400,
                                           150,
                                           "Mensagem de validação",
                                           null);
                }

                var facade = new FacadeJovemImpl();
                var contatoJovem = new Contato
                {
                    Whatsapp = txtNumeroWhats2.Text,
                    TelefoneFixo = txtTelefoneFixo2.Text,
                    TelefoneEmergencia = txtTelefoneEmergencia2.Text,
                    NomeContatoEmergencia = txtContatoEmergencia.Text
                };
                var enderecoJovem = new Endereco
                {
                    DescricaoEndereco = txtEnhdereco.Text,
                    NomeEstado = txtCidade.Text,
                    Bairro = txtBairro.Text,
                    Cidade = txtCidade.Text,
                    TipoDeMoradia = (rbTipoMoradia.SelectedIndex != -1) ? new TipoMoradia { Code = int.Parse(rbTipoMoradia.SelectedValue) } : null
                };
                var redesSociaisJovem = new RedeSocial
                {
                    Email = txtEmail.Text,
                    Instagram = txtInstagram.Text,
                    Facebook = txtFacebook.Text,
                    Twitter = txtTwitter.Text,
                    EhLeitorBlogBM = (rbLeDiariamenteBlogBM.SelectedIndex == 0) ? 'S' : 'N',
                    EhAssinanteUNIVER = (RBaSSINANTEunivervideo.SelectedIndex == 0) ? 'S' : 'N',
                    EhLeitorUniversalorg = (rbLeitorSiteUniversalOrg.SelectedIndex == 0) ? 'S' : 'N',
                    EhSeguidorOficialFJU = (rbEhSeguidorOFICIALFJU.SelectedIndex == 0) ? 'S' : 'N',
                    EhSeguidorTelegram = (rbSegueFJUTelegram.SelectedIndex == 0) ? 'S' : 'N',
                    EhSeguidorYoutube = (rbEhSeguidorFJUYouTube.SelectedIndex == 0) ? 'S' : 'N',
                    PossuiCelularComInternet = (rbTemCelularComInternet.SelectedIndex == 0) ? 'S' : 'N',
                    FrequenciaAssisteUNIVER = txtFrequenciaAssisteUniver.Text,
                    PossuiComputador = (rbTemComputadorEmCasa.SelectedIndex == 0) ? 'S' : 'N'
                };
                var dadosProfissionaisJovem = new DadosProfissionais
                {
                    NomeEmpresa = txtEmpresa.Text,
                    TrabalhaAtualmente = (rbTrabalha.SelectedIndex == 0) ? 'S' : 'N',
                    Profissao = txtProfissao.Text
                };
                var dadosEspirituais = new DadosEspirituais
                {
                    EhMembroIURD = (rbEhMembroIURD.SelectedIndex == 0) ? 'S' : 'N',
                    MesAnoChegadaIURD = txtMesAnoChegadaIURD.Text,
                    AnoChegadaiurd = (txtMesAnoChegadaIURD.Text != "000000" && txtMesAnoChegadaIURD.Text != "" && txtMesAnoChegadaIURD.Text.Count() == 6) ? int.Parse(txtMesAnoChegadaIURD.Text.Substring(0, 2)) : 0,
                    MesChegadaiurd = (txtMesAnoChegadaIURD.Text != "000000" && txtMesAnoChegadaIURD.Text != "" && txtMesAnoChegadaIURD.Text.Count() == 6) ? int.Parse(txtMesAnoChegadaIURD.Text.Substring(2, 4)) : 0,
                    ComoConheceuIURD = txtComoConheceuIURD.Text,

                    JaSeAfastou = (rbJaSeAfastou.SelectedIndex == 0) ? 'S' : 'N',
                    MotivoSeAfastou = txctMotivoAfastamento.Text,
                    TempoEstaFirme = txtDesdeQuandoFirme.Text,
                    TempoAfastamento = txtPorQuantoTempoSeAfastou.Text,//
                    MesAnoAfastamento = txtMesAnoAfastou2.Text,//

                    BatismoAguasIURD = (rbBatismoAguasNaIURD.SelectedIndex == 0) ? 'S' : 'N',
                    EhBatizadoAguas = (rbBatizadoAguas.SelectedIndex == 0) ? 'S' : 'N',
                    MesAnoBatismoAguas = txtQuandoSeBatizouAguas2.Text,//
                    EhBatizadoEspiritoSanto = (rbBatizadoEspiritoSanto.SelectedIndex == 0) ? 'S' : 'N',
                    MesAnoBatismoEspiritoSanto = txtQuandoSeBatizadoES1.Text,//
                    OcasiaoBatismoEspiritoSanto = txtOndeBatismoEspiritoSanto.Text,
                    DescricaoFamiliaresIURD = txtFamiliaresIURD.Text,
                    DescricaoModoChegouFJU = txtComoConheceuFJU.Text,
                    MotivoEntradaFJU = txtMotivoEntrouFJU.Text,
                    MesAnoEntradaFJU = (txtQuandoEntrouFJU.Text != "000000") ? txtQuandoEntrouFJU.Text : "",
                    LeuTodaBiblia = (rbJaLeuBibliaToda.SelectedIndex == 0) ? 'S' : 'N',
                    PossuiBiblia = (rbTemBiblia.SelectedIndex == 0) ? 'S' : 'N',
                    PossuiBibliaNoCelular = (rbTemBibliaNoCelular.SelectedIndex == 0) ? 'S' : 'N'
                };
                DadosEducacionais dadosEducacionais = null;
                if (Session["InformacoesNivelSuperiorJovem"] != null) {
                    dadosEducacionais = (Session["InformacoesNivelSuperiorJovem"] as DadosEducacionais);
                    dadosEducacionais.EstudaAtualmente = (rbEstuda.SelectedIndex == 0) ? 'S' : 'N';
                    dadosEducacionais.Grau = txtGrau.Text;
                    dadosEducacionais.GrauEscolaridade = txtGrauInstrucao.Text;
                    dadosEducacionais.EstudaAtualmente = (rbEstuda.SelectedIndex == 0) ? 'S' : 'N';
                    dadosEducacionais.NomeInstituicaoEnsino = txtInstituicaoOndeEstuda.Text;
                }
                else {
                    dadosEducacionais = new DadosEducacionais {
                        Grau = txtGrau.Text,
                        GrauEscolaridade = txtGrauInstrucao.Text,
                        EstudaAtualmente = (rbEstuda.SelectedIndex == 0) ? 'S' : 'N',
                        NomeInstituicaoEnsino = txtInstituicaoOndeEstuda.Text
                    };
                }
                var dadosSituacaoIURD_FJU = new SituacaoIURDFJU
                {
                    EhObreiro = (chkEhObreiro2.Checked.Value) ? 'S' : 'N',
                    AnosObreiro = (txtAnosEhObreiro.Text != string.Empty) ? int.Parse(txtAnosEhObreiro.Text) : 0,
                    MesesObreiro = (txtMesesEhObreiro.Text != string.Empty) ? int.Parse(txtMesesEhObreiro.Text) : 0,
                    EhColaborador = (chkCursandoCPO.Checked) ? 'S' : 'N',
                    MesesColaborador = (txtMesesEhColaborador.Text != string.Empty) ? int.Parse(txtMesesEhColaborador.Text) : 0,
                    AnosColaborador = (txtAnosEhColaborador.Text != string.Empty) ? int.Parse(txtAnosEhColaborador.Text) : 0,
                    MesAnoInicioCPO = txtAnosInicioCPO2.Text + "#" + txtMesesInicioCPO.Text,
                    EstaCursandoCPO = (chkCursandoCPO.Checked) ? 'S' : 'N',

                    EhPertencenteFJU = (chkMembroFJU.Checked) ? 'S' : 'N',
                    EhCoordenadorFJU = (chkEhCoordenadorFJU.Checked) ? 'S' : 'N',
                    MesAnoCoordenandoFJU = txtMesesInicioCoordenacaoFJU2.Text + "#" + txtAnosInicioCoordenacaoFJU2.Text,
                    MesesCoordenandoFJU = (txtMesesInicioCoordenacaoFJU2.Text != string.Empty) ? int.Parse(txtMesesInicioCoordenacaoFJU2.Text) : 0,
                    AnosCoordenandoFJU = (txtAnosInicioCoordenacaoFJU2.Text != string.Empty) ? int.Parse(txtAnosInicioCoordenacaoFJU2.Text) : 0,

                    EhLiderTribo = (chkLiderTribo.Checked) ? 'S' : 'N',
                    TriboQueLidera = (cboTribos.SelectedIndex != 0) ? new Tribo { Code = int.Parse(cboTribos.SelectedValue) } : null,
                    PeriodoCoordenandoTribo = txtMesesInicioCoordenacaoTribo2.Text + "#" + txtAnosInicioCoordenacaoTribo2.Text,
                    MesesCoordenandoTribo = (txtMesesInicioCoordenacaoTribo2.Text != string.Empty) ? int.Parse(txtMesesInicioCoordenacaoTribo2.Text) : 0,
                    AnosCoordenandoTribo = (txtAnosInicioCoordenacaoTribo2.Text != string.Empty) ? int.Parse(txtAnosInicioCoordenacaoTribo2.Text) : 0,

                    EhLiderProjeto = (chkLiderProjeto.Checked) ? 'S' : 'N',
                    ProjetoQueCoordena = (cboProjetoFJU.SelectedIndex != 0) ? new Projeto { Code = int.Parse(cboProjetoFJU.SelectedValue) } : null,
                    PeriodoCoordenandoProjeto = txtMesesInicioCoordenacaoProjeto2.Text + "#" + txtAnosInicioCoordenacaoProjeto2.Text,
                    MesesCoordenandoProjeto = (txtMesesInicioCoordenacaoProjeto2.Text != string.Empty) ? int.Parse(txtMesesInicioCoordenacaoProjeto2.Text) : 0,
                    AnosCoordenandoProjeto = (txtAnosInicioCoordenacaoProjeto2.Text != string.Empty) ? int.Parse(txtAnosInicioCoordenacaoProjeto2.Text) : 0,

                    PossuiCamisaProjeto = (rbTemCamisaFJU0.SelectedIndex == 0) ? 'S' : 'N',
                    NomeCamisaFJU = (cboCamisasFJU0.SelectedIndex == 0) ? "Não possui" : cboCamisasFJU0.SelectedText,
                    TamanhoCamisa = cboTamanhoCamisaFJU0.SelectedText,
                    FoiObreiro = (rbJaFoiObreiroAntes.SelectedIndex == 0) ? 'S' : 'N',
                    MotivoSaiuObreiro = txtMotivoSaidaObreiro.Text,
                    FoiPastor = (rbJaFoiPastoEsposaAntes.SelectedIndex == 0) ? 'S' : 'N',
                    MotivoSaidaPastor = txtMotivoSaidaPastorEsposa.Text,
                    DesejaSerObreiro = (rbDesejaSerObreiro.SelectedIndex == 0) ? 'S' : 'N',
                    MotivoDesejaSerObreiro = txtMotivoDesejaSErObreiro.Text,
                    DesejaFazerObraNoAltar = (rbDesejaFazerObraAltar.SelectedIndex == 0) ? 'S' : 'N',
                    PertenceAltarJovem = (rbEstaNoAltarJovem.SelectedIndex == 0) ? 'S' : 'N',
                    PertenceIntellimen = (rbFazParteIntellimen.SelectedIndex == 0) ? 'S' : 'N',
                    DesafiosConcluidos = (rbCompletouDesafios.SelectedIndex == 0) ? 'S' : 'N',
                    DesafioAtual = (txtNumeroDesafioIntellimen.Text != string.Empty) ? int.Parse(txtNumeroDesafioIntellimen.Text) : 0,
                    NomeParceiroIntellimen = txtNomeParceiroIntellimen.Text,
                    TelefoneParceiroIntellimen = txtTelefoneParceiroIntellimen2.Text
                };
                var igrejaJovem = new Igreja { Id = int.Parse(cboIgreja.SelectedValue) };
                var novoJovem = new Jovem {
                    Nome = txtNome.Text,
                    DataNascimento = (txtDataNascimento.SelectedDate != null) ? (DateTime)txtDataNascimento.SelectedDate : DateTime.Parse("01/01/1990"),
                    DataCadastro = DateTime.Now,
                    ConjugeEhIURD = (rbConjugeEhIURD.SelectedIndex == 0) ? 'S' : 'N',
                    NomeConjuge = txtNomeconjuge.Text,
                    DataCasamento = (txtDataCasamento.SelectedDate != null) ? (DateTime) txtDataCasamento.SelectedDate : new Nullable<DateTime>(),
                    PossuiTituloEleitor = (rbPossuiTituloeleitor.SelectedIndex == 0) ? 'S' : 'N',
                    PossuiFilhos = (rbPossuiFilhos.SelectedIndex == 0) ? 'S' : 'N',
                    QuantidadeFilhos = (!string.IsNullOrEmpty(txtQtdFilhos2.Text)) ? int.Parse(txtQtdFilhos2.Text) : 0,
                    NomeArquivoFoto = ObtemNomeArquivoFotoJovem(),
                    TextoSugestao = textoSugestao.Text,
                    Sexo = (cboSexo.SelectedIndex == 0) ? 'M' : 'F',
                    ContatoJovem = contatoJovem,
                    EnderecoJovem = enderecoJovem,
                    RedeSocialJovem = redesSociaisJovem,
                    DadosProfissionaisJovem = dadosProfissionaisJovem,
                    DadosEspirituaisJovem = dadosEspirituais,
                    DadosEducacionaisJovem = dadosEducacionais,
                    SituacaoJovemIURDFJU = dadosSituacaoIURD_FJU,
                    PertenceGrupoMulheresIURD = (rbPertenceGrupoMulheres.SelectedIndex == 0)?'S':'N',
                    NomeGrupoMulheresIURD = txtNomeGrupoMulheresUniversal.Text,
                    EstadoCivilJovem = (rbTipoEstadoCivil.SelectedIndex != -1)?new TipoEstadoCivil { Code = int.Parse(rbTipoEstadoCivil.SelectedValue) }: null,
                    IgrejaAQualJovemPertence = igrejaJovem
                };

                var testemunhoJovem = new Testemunho
                {
                    SofreuComDepressao = (rbJaSofreuDepressao.SelectedIndex == 0) ? 'S' : 'N',
                    TempoSofreuDepressao = txtTempoLivreDepressao.Text,
                    TentouSuicidio = (rbJaTentouSuicidio.SelectedIndex == 0) ? 'S' : 'N',
                    DescricaoTentativaSuicidio = txtDescricaoTentativaSuicidio.Text,
                    MesAnoTentativaSuicidio = txtQuandoTentouSuicidio.Text,
                    NumeroTentativasSuicidio = (txtNumeroTentativasSuicidio.Text != string.Empty) ? int.Parse(txtNumeroTentativasSuicidio.Text) : 0,
                    TempoLivreDepressao = txtTempoLivreDepressao.Text,
                    SofreuAutomutilacao = (rbJaSofreuAutomutilacao.SelectedIndex == 0) ? 'S' : 'N',
                    TempoSofreuAutomutilacao = txtTempoSofreuAutomutilacao.Text,
                    TempoLivreAutomutilacao = txtTempoLivreAutomutilacao.Text,
                    SofreuVicio = (rbJaTeveVicio.SelectedIndex == 0) ? 'S' : 'N',
                    DescricaoVicio = txtNomeVicio.Text,
                    TempoLivreVicios = txtTempoLivreVicios.Text,
                    TempoVicio = txtTempoVicio.Text,
                    TextoTestemunho = textoTestemunho.Text,
                    JovemTestemunho = novoJovem 
                };
                
                var cursosAdicionaisJovem = (Session["CursosAdicionaisJovem"] as IList<CursoRelacionadoProjeto>);
                if (cursosAdicionaisJovem != null && cursosAdicionaisJovem.Count > 0) {
                    novoJovem.AddCursosRelacionados(cursosAdicionaisJovem);
                }

                var departamentosAosQuaisJovemEstaLigado = (Session["DepartamentosAosQuaisJovemEstaLigado"] as IList<DepartamentoProjeto>);
                if (departamentosAosQuaisJovemEstaLigado != null && departamentosAosQuaisJovemEstaLigado.Count > 0)
                {
                    novoJovem.addDepartamentosProjetoJovemFazParte(departamentosAosQuaisJovemEstaLigado);
                }

                if (RetornaReunioesQueOJovemAssiste().Count > 0)
                    novoJovem.addReunioesFJUAssistidaPeloJovem(RetornaReunioesQueOJovemAssiste());

                if (RetornaLivrosLidosPeloJovem().Count > 0)
                    novoJovem.addLivrosLidoPeloJovem(RetornaLivrosLidosPeloJovem());

                var idiomasFaladoPeloJovem = retornaIdiomasFaladosPeloJovem();
                if (idiomasFaladoPeloJovem.Count() > 0) {
                    foreach (var idiomaJovem in idiomasFaladoPeloJovem) {
                        idiomaJovem.Jovem = novoJovem;
                    }
                }

                var habilidadesSelecionadasParaOJovem = (Session["HabilidadesQueOJovemPossui"] as IList<JovemHabilidadeProjeto>);
                if (habilidadesSelecionadasParaOJovem != null && habilidadesSelecionadasParaOJovem.Count > 0) {
                    foreach (var HabilidadeJovemProjeto in habilidadesSelecionadasParaOJovem) {
                        HabilidadeJovemProjeto.Jovem = novoJovem;
                    }
                }

                JovemProjeto jovemProjeto = null;
                if (rbListaProjetos.SelectedIndex > 0) {
                    jovemProjeto = new JovemProjeto {
                        Projeto = obterProjetoSelecionado(),
                        MesesProjeto = (txtMesesProjeto2.Text != string.Empty) ? int.Parse(txtMesesProjeto2.Text) : 0,
                        AnosProjeto = (txtAnosProjeto2.Text != string.Empty) ? int.Parse(txtAnosProjeto2.Text) : 0,
                        PertenceuOutroProjeto = (rbJaEsteveEmOutroProjeto0.SelectedIndex == 0) ? 'S' : 'N',
                        ProjetoAnterior = (cboProjetoAnterior0.SelectedIndex != 0) ? new Projeto { Code = int.Parse(cboProjetoAnterior0.SelectedValue) } : null,
                        TempoProjeto = txtAnosProjeto2.Text + "#" + txtMesesProjeto2.Text,
                        Jovem = novoJovem
                    };
                }

                //-------------------------------------------------------------------------------------------------------------------------
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                facade.SalvarJovem(novoJovem, idiomasFaladoPeloJovem, habilidadesSelecionadasParaOJovem, jovemProjeto, testemunhoJovem);

                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;

                //// Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                //-------------------------------------------------------------------------------------------------------------------------

                //
                var novoJovemDTO = new TodosJovensDTO
                {
                    IdEstado = (cboEstado.SelectedIndex != 0)? int.Parse(cboEstado.SelectedValue):0,
                    NomeEstado = (cboEstado.SelectedIndex != 0)? cboEstado.Text:"",
                    IdBlocoJovem = (cboBloco.SelectedIndex != -1)? int.Parse(cboBloco.SelectedValue):0,
                    NomeBlocoJovem = (cboBloco.SelectedIndex != -1) ? cboBloco.SelectedText : "",
                    IdRegiaoJovem = (cboRegiao.SelectedIndex != -1)?int.Parse(cboRegiao.SelectedValue):0,
                    NomeRegiaoJovem = (cboRegiao.SelectedIndex != -1) ? cboRegiao.SelectedText : "",
                    IdIgreja = (cboIgreja.SelectedIndex != -1) ? int.Parse(cboIgreja.SelectedValue) : 0,
                    NomeIgrejaJovem = (cboIgreja.SelectedIndex != -1) ? cboIgreja.SelectedText : "",
                    IdJovem = (novoJovem.Id != 0)?novoJovem.Id:0,
                    NomeJovem = novoJovem.Nome,
                    DataNascimento = novoJovem.DataNascimento.ToString("dd/MM/yyyy")
                };
                RegerarArquivoDTO(facade, novoJovemDTO);
                //

                rwmUIApp.RadAlert("Jovem cadastrado com sucesso !", 300, 180, "Confirmação", null);
            }
            catch (DomainException excDominio) {
                var mensagemErroExcecao = string.Format("Ocorreu o seguinte erro na camada de domínio {0} : ", excDominio.Message);
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
                RadWindowManager1.RadAlert("O sistema de comportou de forma inadequada, por favor realizar tente mais tarde",
                                           400,
                                           150,
                                           "Mensagem de alerta",
                                           null);
            }
            catch (FacadeException excBussiness) {
                var mensagemErroExcecao = string.Format("Ocorreu o seguinte erro na camada de negócios {0} : ", excBussiness.Message);
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
                RadWindowManager1.RadAlert("O sistema de comportou de forma inadequada, por favor realizar tente mais tarde",
                                           400,
                                           150,
                                           "Mensagem de alerta",
                                           null);
            }
            catch (Exception generalException) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(generalException, "CAMADA_APP");
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
                RadWindowManager1.RadAlert("O sistema de comportou de forma inadequada, por favor realizar tente mais tarde",
                                           400,
                                           150,
                                           "Mensagem de alerta",
                                           null);
            }
        }
        private string ObtemNomeArquivoFotoJovem() {
            var nomeArquivoRetorno = "";
            if (Session["NomeArquivoFotoJovem"] != null)
                nomeArquivoRetorno = Session["NomeArquivoFotoJovem"].ToString();
            return nomeArquivoRetorno;
        }
        private IList<Livro> RetornaLivrosLidosPeloJovem()
        {
            var livrosLidosPeloJovem = new List<Livro>();
            if (chkLivros2.SelectedIndices.Count() != -1) {
                foreach (ButtonListItem itemLivro in chkLivros2.Items) {
                    if(itemLivro.Selected)
                        livrosLidosPeloJovem.Add(new Livro { 
                            Code = int.Parse(itemLivro.Value)
                        });
                }
            }
            return livrosLidosPeloJovem;
        }
        private IList<ReuniaoFJU> RetornaReunioesQueOJovemAssiste()
        {
            var reunioesAssistidasPeloJovem = new List<ReuniaoFJU>();
            if (chkReunioesFJU2.SelectedItems.Count != -1) {
                foreach (ButtonListItem itemReuniao in chkReunioesFJU2.Items){
                    if(itemReuniao.Selected)
                        reunioesAssistidasPeloJovem.Add(new ReuniaoFJU { 
                            Code = int.Parse(itemReuniao.Value)
                        });
                }
            }
            return reunioesAssistidasPeloJovem;
        }
        private IList<JovemIdioma> retornaIdiomasFaladosPeloJovem()
        {
            var listaRetorno = new List<JovemIdioma>();
            try {                
                var arquivoTodosIdiomasSerializados = ConfigurationManager.AppSettings["IdiomasSerializedFileName"];
                var idiomas = (new FacadeBaseImpl<Estado>()).ListAllValueObjects<Idioma>();
                var todosNiveis = (Session["todosNiveis"] as List<Nivel>);

                if (rbNivelIngles.SelectedIndex != -1) {
                    var codigoIdiomaIngles = RetornaCodigoIdioma(idiomas, "Inglês");//idiomas.Where(t => t.NomeIdioma == "Inglês").ToList()[0].Code;
                    int codigoNivel = 0;
                    switch (rbNivelIngles.SelectedIndex)
                    {
                        case 0:
                            codigoNivel = todosNiveis.Where(t => t.Descricao == "Bom").ToList()[0].Code;
                            break;
                        case 1:
                            codigoNivel = todosNiveis.Where(t => t.Descricao == "Regular").ToList()[0].Code;
                            break;
                        case 2:
                            codigoNivel = todosNiveis.Where(t => t.Descricao == "Excelente").ToList()[0].Code;
                            break;
                    }
                    listaRetorno.Add(new JovemIdioma
                    {
                        Idioma = new Idioma { Code = codigoIdiomaIngles },
                        Nivel = new Nivel { Code = codigoNivel }
                    });
                }

                if (rbNivelEspanhol.SelectedIndex != -1) {
                    var codigoIdiomaEspanhol = RetornaCodigoIdioma(idiomas, "Espanhol");//idiomas.Where(t => t.NomeIdioma == "Espanhol").ToList()[0].Code;
                    int codigoNivel = 0;
                    switch (rbNivelEspanhol.SelectedIndex)
                    {
                        case 0:
                            codigoNivel = todosNiveis.Where(t => t.Descricao == "Bom").ToList()[0].Code;
                            break;
                        case 1:
                            codigoNivel = todosNiveis.Where(t => t.Descricao == "Regular").ToList()[0].Code;
                            break;
                        case 2:
                            codigoNivel = todosNiveis.Where(t => t.Descricao == "Excelente").ToList()[0].Code;
                            break;
                    }
                    listaRetorno.Add(new JovemIdioma
                    {
                        Idioma = new Idioma { Code = codigoIdiomaEspanhol },
                        Nivel = new Nivel { Code = codigoNivel }
                    });
                }

                if (rbNivelFrances.SelectedIndex != -1) {
                    var codigoIdiomaFrances = RetornaCodigoIdioma(idiomas, "Francês");//idiomas.Where(t => t.NomeIdioma == "Francês").ToList()[0].Code;
                    int codigoNivel = 0;
                    switch (rbNivelFrances.SelectedIndex)
                    {
                        case 0:
                            codigoNivel = todosNiveis.Where(t => t.Descricao == "Bom").ToList()[0].Code;
                            break;
                        case 1:
                            codigoNivel = todosNiveis.Where(t => t.Descricao == "Regular").ToList()[0].Code;
                            break;
                        case 2:
                            codigoNivel = todosNiveis.Where(t => t.Descricao == "Excelente").ToList()[0].Code;
                            break;
                    }
                    listaRetorno.Add(new JovemIdioma
                    {
                        Idioma = new Idioma { Code = codigoIdiomaFrances },
                        Nivel = new Nivel { Code = codigoNivel }
                    });
                }

                if (rbNivelItaliano.SelectedIndex != -1) {
                    var codigoIdiomaItaliano = idiomas.Where(t => t.NomeIdioma == "Italiano").ToList()[0].Code;
                    int codigoNivel = 0;
                    switch (rbNivelItaliano.SelectedIndex)
                    {
                        case 0:
                            codigoNivel = todosNiveis.Where(t => t.Descricao == "Bom").ToList()[0].Code;
                            break;
                        case 1:
                            codigoNivel = todosNiveis.Where(t => t.Descricao == "Regular").ToList()[0].Code;
                            break;
                        case 2:
                            codigoNivel = todosNiveis.Where(t => t.Descricao == "Excelente").ToList()[0].Code;
                            break;
                    }
                    listaRetorno.Add(new JovemIdioma
                    {
                        Idioma = new Idioma { Code = codigoIdiomaItaliano },
                        Nivel = new Nivel { Code = codigoNivel }
                    });
                }

                if (rbNivelJapones.SelectedIndex != -1) {
                    var codigoIdiomaJapones = idiomas.Where(t => t.NomeIdioma == "Japonês").ToList()[0].Code;
                    int codigoNivel = 0;
                    switch (rbNivelJapones.SelectedIndex)
                    {
                        case 0:
                            codigoNivel = todosNiveis.Where(t => t.Descricao == "Bom").ToList()[0].Code;
                            break;
                        case 1:
                            codigoNivel = todosNiveis.Where(t => t.Descricao == "Regular").ToList()[0].Code;
                            break;
                        case 2:
                            codigoNivel = todosNiveis.Where(t => t.Descricao == "Excelente").ToList()[0].Code;
                            break;
                    }
                    listaRetorno.Add(new JovemIdioma
                    {
                        Idioma = new Idioma { Code = codigoIdiomaJapones },
                        Nivel = new Nivel { Code = codigoNivel }
                    });
                }

                if (string.IsNullOrEmpty(txtIdiomaExtra.Text) == false) {
                    int codigoNivel = 0;
                    switch (rbNivelOutroIdioma.SelectedIndex)
                    {
                        case 0:
                            codigoNivel = todosNiveis.Where(t => t.Descricao == "Bom").ToList()[0].Code;
                            break;
                        case 1:
                            codigoNivel = todosNiveis.Where(t => t.Descricao == "Regular").ToList()[0].Code;
                            break;
                        case 2:
                            codigoNivel = todosNiveis.Where(t => t.Descricao == "Excelente").ToList()[0].Code;
                            break;
                    }
                    listaRetorno.Add(new JovemIdioma
                    {
                        Idioma = new Idioma { NomeIdioma = txtIdiomaExtra.Text },
                        Nivel = new Nivel { Code = codigoNivel }
                    });
                }
            }
            catch (Exception excIdiomas) {
                var mensagemFormatada = ExceptionManager.FormatExceptionMessage(excIdiomas);
                throw new Exception(mensagemFormatada);
            }

            return listaRetorno;
        }
        private int RetornaCodigoIdioma(IList<Idioma> todosIdiomasParametro, string nomeIdiomaParametro) {
            int codigoIdiomaRetorno = 0;
            foreach (var idioma in todosIdiomasParametro){
                if (string.Equals(idioma.NomeIdioma, nomeIdiomaParametro, StringComparison.OrdinalIgnoreCase))
                    return idioma.Code;
            }
            return codigoIdiomaRetorno;
        }
        private IList<ReuniaoFJU> obterReunioesAssistidasPeloJovem()
        {
            var reunioesSelecionadas = chkReunioesFJU2.SelectedItems.Select(t => new ReuniaoFJU { Code = int.Parse(t.Value) }).ToList();
            return reunioesSelecionadas;
        }
        private IList<Livro> obterLivrosSelecionados()
        {
            var livrosSelecionados = chkLivros2.SelectedItems.Select(t => new Livro { Code = int.Parse(t.Value) }).ToList();
            return livrosSelecionados;
        }
        private Projeto obterProjetoSelecionado()
        {
            return new Projeto { Code = int.Parse( rbListaProjetos.SelectedValue ) };
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
        protected void cboBloco_ItemSelected(object sender, Telerik.Web.UI.DropDownListEventArgs e)
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
        protected void cboRegiao_ItemSelected1(object sender, Telerik.Web.UI.DropDownListEventArgs e)
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
        protected string retornaCaminhoFisicoCompleto(string nomeArquivo) {
            var caminhoPastaArquivosSerializados = ConfigurationManager.AppSettings["PathArquivosObjetosSerializados"];
            return System.Web.Hosting.HostingEnvironment.MapPath(caminhoPastaArquivosSerializados + "\\" + nomeArquivo);
        }

        protected void btnUploadFotoJovem_Click(object sender, EventArgs e)
        {
            foreach (UploadedFile f in uploadFotosJovem.UploadedFiles)
            {
                string fileName = f.GetName();
                string title = f.GetFieldValue("TextBox");
                Session.Add("NomeArquivoFotoJovem", fileName);
                //ProcessFile(fileName, title);
            }
            RadWindowManager1.RadAlert("Foto do jovem adicionada com sucesso!!!",
                                           400,
                                           150,
                                           "Mensagem de alerta",
                                           null);
        }

        private void RegerarArquivoDTO(FacadeJovemImpl facade, TodosJovensDTO jovemnovoDTO) {
            var serializer = (new UnityDIContainer()).GetServiceImplementationToType<Serializer>();
            var caminhoPastaArquivosSerializados = ConfigurationManager.AppSettings["PathArquivosObjetosSerializados"];
            var caminhoPastaArquivosOndeSerializar = Server.MapPath(caminhoPastaArquivosSerializados + "\\" + "Todos.txt");
            var todosJovensDTO = facade.ListAllValueObjectsFromJson<TodosJovensDTO>(caminhoPastaArquivosOndeSerializar);
            todosJovensDTO.Add(jovemnovoDTO);
            (serializer as JSONSerializer).SerializeToJSON(todosJovensDTO, caminhoPastaArquivosOndeSerializar);
        }
    }
}


