<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistraJovem.aspx.cs" Inherits="SGFJU.UI.Views.RegistraJovem" %>


<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register assembly="Telerik.Web.Design" namespace="Telerik.Web.Design" tagprefix="design" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
    <link href="../Styles/UI_App.css" rel="stylesheet" />    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FolderContent" runat="server">           
    <nav:FolderNavigationControl runat="server" ID="FolderNavigationControl" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <script language="javascript" type="text/javascript">

        $telerik.$(document).ready(function () {

            //PrencheCombosEstados();
        });

        function PrencheCombosEstados() {
            $telerik.$.ajax({
                type: "get",
                url: 'http://localhost:55792/api/estados',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    estadosBrasil = data;
                    for (var i = 0; i < data.length; i++) {

                        AdicionaItemCombo(data[i].Id, data[i].NomeEstado);
                        AdicionaItemComboEstadosBrasil(data[i].Id, data[i].NomeEstado);
                    };
                }
            });
        };

        function AdicionaItemCombo(ID_Estado, nomeEstado) {
            var combo = $find("<%= cboEstado.ClientID %>");
            //var item = combo.findItemByText(itemText);
            var comboItem = new Telerik.Web.UI.RadComboBoxItem();
            comboItem.set_text(nomeEstado);
            comboItem.set_value(ID_Estado);
            combo.trackChanges();
            combo.get_items().add(comboItem);
            comboItem.select();
            combo.commitChanges();
        };

        function AdicionaItemComboEstadosBrasil(ID_Estado, nomeEstado) {
            var combo = $find("<%= cboEstadosBrasil.ClientID %>");
            //var item = combo.findItemByText(itemText);
            var comboItem = new Telerik.Web.UI.RadComboBoxItem();
            comboItem.set_text(nomeEstado);
            comboItem.set_value(ID_Estado);
            combo.trackChanges();
            combo.get_items().add(comboItem);
            comboItem.select();
            combo.commitChanges();
        };
        //AddInformacoesProjeto
        function AddInformacoesProjeto(sender, args) {
            var wnd = null;
            var rbProjetosFJU = $find("<%=rbListaProjetos.ClientID%>");

            var items = rbProjetosFJU.get_items();
            var selectedIndex = rbProjetosFJU.get_selectedIndex();

            if (selectedIndex == -1) {
                radalert('Selecione um projeto, para inserir os detalhes do mesmo!');
                args.set_cancel(true);
            }

            var items = rbProjetosFJU.get_items();
            for (var i = 0; i < items.length; i++) {
                if (items[i].get_selected()) {
                    //radalert('selecionou projeto' + items[i].get_text());
                    var nomeProjeto = items[i].get_text();
                    switch (nomeProjeto) {
                        case 'Cultura':
                            //wnd = window.GetRadWindowManager().open('formInformacoesAdicionaisCultura.aspx', null);
                            //wnd.setSize(750, 550);
                            wnd = $find("<%=RadWindowManager1.ClientID %>").open('formInformacoesAdicionaisCultura.aspx', null, null, 580, 650);                                                        
                            wnd.set_title('Preenchimento de informações adicionais do projeto: Cultura');
                            wnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close);
                            wnd.set_modal(true);
                            break;
                        case 'Esporte':
                            //wnd = window.radopen('formInformacoesAdicionaisEsporte.aspx', null);
                            wnd = $find("<%=RadWindowManager1.ClientID %>").open('formInformacoesAdicionaisEsporte.aspx', null, null, 720, 370);                            
                            wnd.set_title('Preenchimento de informações adicionais do Projeto Esporte:');
                            wnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close);
                            wnd.set_modal(true);
                            //wnd.setSize(800, 400);
                            break;
                        case 'Midía':
                            wnd = $find("<%=RadWindowManager1.ClientID %>").open('formInformacoesAdicionaisMidia.aspx', null, null, 800, 305);
                            //wnd = window.radopen('formInformacoesAdicionaisMidia.aspx', null);
                            //wnd.setSize(800, 305);
                            wnd.set_title('Preenchimento de informações adicionais do projeto: Mídia');
                            wnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close);
                            wnd.set_modal(true);
                            break;
                        case 'Universitários':
                            wnd = $find("<%=RadWindowManager1.ClientID %>").open('formInformacoesAdicionaisUniversitarios.aspx', null, null, 700, 300);
                            //wnd = window.radopen('formInformacoesAdicionaisUniversitarios.aspx', null);
                            //wnd.setSize(650, 345);
                            wnd.set_title('Preenchimento de informações adicionais do projeto: Universitários');
                            wnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close);
                            wnd.set_modal(true);
                            break;
                        case '':
                            break;
                        default:
                            wnd = $find("<%=RadWindowManager1.ClientID %>").open('formInformacoesAdicionaisProjeto.aspx?nomeProjeto=' + items[i].get_text(), null, null, 670, 220);
                            //wnd = window.radopen('formInformacoesAdicionaisProjeto.aspx?nomeProjeto=' + items[i].get_text(), null);
                            wnd.set_title('Preenchimento de informações adicionais do Projeto: ' + items[i].get_text());
                            wnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close);
                            wnd.set_modal(true);
                            //wnd.setSize(670, 220);
                            wnd.add_close(OnClientClose);
                    }


                    args.set_cancel(true);
                }
            }
        };

        function OnClientClose(oWnd, args) {
            var arg = args.get_argument();
            if (arg) {
                //alert(arg.NomeProjeto);
            }
        }

        function chkEhObreiro2_Clicking(sender, args) {




        }

        function chkEhObreiro2_CheckedChanged(sender, args) {
            var txtAnosColaborador = $find("<%=txtAnosEhColaborador.ClientID%>");
            var txtMeseColaborador = $find("<%=txtMesesEhColaborador.ClientID%>");
            var txtAnosInicioCPO2 = $find("<%=txtMesesInicioCPO.ClientID%>");
            var txtMesesInicioCPO = $find("<%=txtAnosInicioCPO2.ClientID%>");
            alert(args.get_checked());
            if (args.get_checked()) {
                txtAnosColaborador.set_enabled(false);
            }
            else {
                txtAnosColaborador.set_enabled(true);
            }
        }

        function OnClientFileSelected(sender, args) {
            var currentFileName = args.get_fileName();
            $telerik.$('#<%= lblNomeArquivoJovem.ClientID %>').html(currentFileName);
        }

        function OnClientFileUploadRemoved(sender, args) {
            $telerik.$('#<%= lblNomeArquivoJovem.ClientID %>').html('');
        }

        function onNodeClicking(sender, args) {
            alert("OnClientNodeClicking: " + args.get_node().get_text());
        }

    </script>

    <style type="text/css">
        
        .txt1 {
	        font-family: Verdana, Arial, Helvetica, sans-serif;
	        font-size: 9px;
	        font-style: normal;
	        line-height: normal;
	        font-weight: bold;
	        font-variant: normal;
	        text-transform: none;
	        color: #003366;
        }
        .txt2 {

	        font-family: Verdana, Arial, Helvetica, sans-serif;
	        font-size: 9px;
	        font-style: normal;
	        line-height: normal;
	        font-weight: bold;
	        font-variant: normal;
	        text-transform: none;	
	        color: #FFFFFF;
        }
        .txt3 {


	        font-family: Verdana, Arial, Helvetica, sans-serif;
	        font-size: 9px;
	        font-style: normal;
	        line-height: normal;
	        font-weight: normal;
	        font-variant: normal;
	        text-transform: none;
	        color: #003366;
        }
        .txt4 {
            font-family: OutlookSampleApp;
	        font-size: 14px;
	        font-style: normal;
	        line-height: normal;
	        font-weight: bold;
	        font-variant: normal;
	        text-transform: none;
	        color: #003366;
        }
        .txtConfirmacao {            
	        font-family: OutlookSampleApp;
	        font-size: 16px;
	        font-style: normal;
	        line-height: normal;
	        font-weight: bold;
	        font-variant: normal;
	        text-transform: none;	
	        color: #FFFFFF;        
        }
    </style>

    <telerik:RadWindowManager ID="rwmUIApp" Skin="WebBlue" runat="server" />

        
        <telerik:RadAjaxManager runat="Server" 
                                ID="RadAjaxManager1" >
            <AjaxSettings>                            
			    
                <telerik:AjaxSetting AjaxControlID="cboEstado">
				    <UpdatedControls>					    
                        <telerik:AjaxUpdatedControl ControlID="cboBloco" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="cboRegiao" LoadingPanelID="RadAjaxLoadingPanel1" />                        
                        <telerik:AjaxUpdatedControl ControlID="cboIgreja" LoadingPanelID="RadAjaxLoadingPanel1" />   
				    </UpdatedControls>
			    </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="cboBloco">
				    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cboRegiao" LoadingPanelID="RadAjaxLoadingPanel1" />                        
                        <telerik:AjaxUpdatedControl ControlID="cboIgreja" LoadingPanelID="RadAjaxLoadingPanel1" />   
				    </UpdatedControls>
			    </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="cboRegiao">
				    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cboIgreja" LoadingPanelID="RadAjaxLoadingPanel1" />   
				    </UpdatedControls>
			    </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="btnUploadFotoJovem">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="uploadFotosJovem" LoadingPanelID="RadAjaxLoadingPanel1" />   
				    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        
        <telerik:RadAjaxLoadingPanel runat="server" ID="RadAjaxLoadingPanel1" >
	    </telerik:RadAjaxLoadingPanel>

    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" />

    <telerik:RadNavigation runat="server" ID="contactNavigation" Skin="Vista" CssClass="secondaryMenu">
        <Nodes>                        
            <telerik:NavigationNode Text="Novo Jovem" SpriteCssClass="icon icon-Send" NavigateUrl="RegistraJovem.aspx" ></telerik:NavigationNode>
            <telerik:NavigationNode CssClass="rightScndNav">                
                <NodeTemplate>                    
                    <%--<telerik:RadSearchBox runat="server" Skin="BlackMetroTouch" Width="340px" DropDownSettings-Height="300px" ID="mainSearch"
                        CssClass="hidden" ShowLoadingIcon="false">
                    </telerik:RadSearchBox>--%>
                    <%--<span class="button searchBtn"><span class="icon icon-Search"></span></span>--%>
                </NodeTemplate>
            </telerik:NavigationNode>
        </Nodes>
    </telerik:RadNavigation>

    <div class="demo-container">

        <div class="wizardHeader">

            <telerik:RadWizard RenderMode="Lightweight" 
                               ID="RadWizard1" 
                               runat="server"  
                               Height="520px" 
                               Culture="pt-BR" 
                               Skin="WebBlue" 
                               BackColor="#d3e1ee"                
                               OnFinishButtonClick="RadWizard1_FinishButtonClick" >
                <WizardSteps>

                    <telerik:RadWizardStep ID="stepStart" 
                                           Title="Dados iniciais" 
                                           runat="server" 
                                           StepType="Start" 
                                           CausesValidation="true" 
                                           ValidationGroup="StepInicialValidation"
                                           BackColor="#d3e1ee" >

                        <div id="divDadosIniciais">

                            <table border="0" cellspacing="0" cellpadding="0" id="tbl1" class="txt1">
														    <tr>
															    <td class="auto-style17" ><div align="right">Nome:
																    </div>
															    </td>
															    <td class="auto-style18">
																    &nbsp;&nbsp;&nbsp; &nbsp;</td>
                                                            
															    <td class="auto-style18" colspan="2">&nbsp;&nbsp;
                                                                    <telerik:RadTextBox ID="txtNome" runat="server" MaxLength="250" ValidationGroup="StepInicialValidation" Width="350px">
                                                                    </telerik:RadTextBox>
                                                                </td>
                                                            
															    <td class="auto-style17">
																
                                                                    </td>
															    <td class="auto-style20">
																
                                                                    <div aling="right">
                                                                        Data de Nascimento
                                                                    </div>                                                                    

															    </td>
															    <td class="auto-style21">
																
																    &nbsp;</td>
															    <td class="auto-style17">
																
                                                                    <telerik:RadDatePicker ID="txtDataNascimento" 
                                                                                           Runat="server" 
                                                                                           Skin="WebBlue" 
                                                                                           DateInput-MaxLength="10"
                                                                                           Width="100%">
                                                                    </telerik:RadDatePicker>

															        &nbsp;

															    </td>
														        <td class="auto-style17">
                                                                    &nbsp;
                                                                    </td>
														        <td class="auto-style17">
                                                                    &nbsp;</td>
														    </tr>
														    <tr>
                                                                <td class="auto-style17">&nbsp;</td>
                                                                <td class="auto-style18">&nbsp;</td>
                                                                <td class="auto-style18" colspan="2">&nbsp;</td>
                                                                <td class="auto-style17">&nbsp;</td>
                                                                <td class="auto-style20">&nbsp;</td>
                                                                <td class="auto-style21">&nbsp;</td>
                                                                <td class="auto-style17">&nbsp;</td>
                                                                <td class="auto-style17">&nbsp;</td>
                                                                <td class="auto-style17">&nbsp;</td>
                                                            </tr>
														    <tr >
                                                                <td class="auto-style17">&nbsp;</td>
                                                                <td class="auto-style18">
                                                                    &nbsp;</td>
                                                                <td class="auto-style18" colspan="2">
                                                                    <asp:RequiredFieldValidator ID="reqNome" runat="server" ControlToValidate="txtNome" EnableClientScript="true" ErrorMessage="O campos nome não pode ficar em branco" ForeColor="Red" ValidationGroup="StepInicialValidation" />
                                                                </td>
                                                                <td class="auto-style17">&nbsp;</td>
                                                                <td class="auto-style20">&nbsp;</td>
                                                                <td class="auto-style21">&nbsp;</td>
                                                                <td class="auto-style17">&nbsp;</td>
                                                                <td class="auto-style17">&nbsp;</td>
                                                                <td class="auto-style17">&nbsp;</td>
                                                            </tr>
														    <tr>
                                                                <td class="auto-style17">
                                                                    <div aling="right">
                                                                        Sexo:
                                                                    </div>
                                                                </td>
                                                                <td class="auto-style18">
                                                                    &nbsp;</td>
                                                                <td class="auto-style18" colspan="2">&nbsp;&nbsp;&nbsp;<telerik:RadComboBox ID="cboSexo" runat="server" AutoPostBack="false" Height="100px" Skin="WebBlue" Width="170px">
                                                                    <Items>
                                                                        <telerik:RadComboBoxItem Text="Masculino" />
                                                                        <telerik:RadComboBoxItem Text="Feminino" />
                                                                    </Items>
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td class="auto-style17">&nbsp;</td>
                                                                <td class="auto-style20">
                                                                    <div aling="right">
                                                                        Foto:
                                                                    </div>
                                                                </td>
                                                                <td class="auto-style21">&nbsp;</td>
                                                                <td class="auto-style17">
                                                                    <telerik:RadAsyncUpload ID="uploadFotosJovem" 
                                                                                            runat="server" 
                                                                                            AllowedFileExtensions=".jpeg,.jpg,.png" 
                                                                                            MaxFileInputsCount="1" 
                                                                                            PostbackTriggers="btnUploadFotoJovem" 
                                                                                            RenderMode="Lightweight" 
                                                                                            OnClientFileSelected="OnClientFileSelected"
                                                                                            OnClientFileUploadRemoved="OnClientFileUploadRemoved"
                                                                                            TargetFolder="../FotosJovens/" />
                                                                </td>
                                                                <td class="auto-style17">
                                                                    <telerik:RadButton runat="server" 
                                                                                       ID="btnUploadFotoJovem" 
                                                                                       Text="Salvar foto jovem" 
                                                                                       OnClick="btnUploadFotoJovem_Click"></telerik:RadButton>
                                                                    </td>
                                                                <td class="auto-style17">
                                                                    &nbsp;</td>
                                                            </tr>
														    <tr>
                                                                <td class="auto-style17">&nbsp;</td>
                                                                <td class="auto-style18">&nbsp;</td>
                                                                <td class="auto-style18" colspan="2">&nbsp;</td>
                                                                <td class="auto-style17">&nbsp;</td>
                                                                <td class="auto-style20" colspan="3">
                                                                    <div aling="right">
                                                                        Arquivo da foto do jovem:
                                                                        <asp:Label ID="lblNomeArquivoJovem" ForeColor="Red" Text="" runat="server" />
                                                                    </div>
                                                                </td>
                                                                <td class="auto-style17">&nbsp;</td>
                                                                <td class="auto-style17">&nbsp;</td>
                                                            </tr>
														    <tr>
                                                                <td class="auto-style17">&nbsp;</td>
                                                                <td class="auto-style18">&nbsp;</td>
                                                                <td class="auto-style18" colspan="2">&nbsp;</td>
                                                                <td class="auto-style17">&nbsp;</td>
                                                                <td class="auto-style20" colspan="3">&nbsp;</td>
                                                                <td class="auto-style17">&nbsp;</td>
                                                                <td class="auto-style17">&nbsp;</td>
                                                            </tr>
														    <tr cellspacing="10px">
															    <td class="auto-style2">
                                                                    <div align="right">Estado:
																    </div>
															    </td>
															    <td class="auto-style3">
                                                                
                                                                    &nbsp;</td>
															    <td class="auto-style3">&nbsp;&nbsp;
                                                                    <div aling="left">
                                                                        <telerik:RadComboBox ID="cboEstado" runat="server" AutoPostBack="true" Height="100px" OnItemSelected="cboEstado_ItemSelected" OnSelectedIndexChanged="cboEstado_SelectedIndexChanged" Skin="WebBlue" Width="210px">
                                                                        </telerik:RadComboBox>
                                                                    </div>
                                                                    
                                                                </td>
															    <td class="auto-style10">
															        <div align="right">

                                                                        Bloco</div>
                                                                </td>

                                                                <td class="auto-style2">
                                                                
                                                                    &nbsp;</td>

                                                                <td class="auto-style16">
                                                                
                                                                    
                                                                        <telerik:RadDropDownList ID="cboBloco" 
                                                                                                 runat="server" 
                                                                                                 Height="17px" 
                                                                                                 Width="210px" 
                                                                                                 Skin="WebBlue" 
                                                                                                 AutoPostBack="true" 
                                                                            OnItemSelected="cboBloco_ItemSelected">
                                                                        </telerik:RadDropDownList>
                                                                    

																    </td>

                                                                <td class="auto-style14">
                                                                
                                                                    &nbsp;</td>

                                                                <td class="auto-style2">
                                                                
                                                                    &nbsp;</td>
														        <td class="auto-style2" colspan="2">
                                                                    &nbsp;</td>
														    </tr>
														    <tr cellspacing="10px">
                                                                <td class="auto-style2">&nbsp;</td>
                                                                <td class="auto-style3">&nbsp;</td>
                                                                <td class="auto-style3">&nbsp;</td>
                                                                <td class="auto-style10">&nbsp;</td>
                                                                <td class="auto-style2">&nbsp;</td>
                                                                <td class="auto-style16">&nbsp;</td>
                                                                <td class="auto-style14">&nbsp;</td>
                                                                <td class="auto-style2">&nbsp;</td>
                                                                <td class="auto-style2" colspan="2">&nbsp;</td>
                                                            </tr>
														    <tr>
															    <td class="auto-style2"><div align="right">Região:
																    </div>
															    </td>
															    <td class="auto-style3">
                                                                    &nbsp;</td>
															    <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                    <div align="left">
                                                                        <telerik:RadDropDownList ID="cboRegiao" runat="server" AutoPostBack="True" Height="21px" OnItemSelected="cboRegiao_ItemSelected1" Skin="WebBlue" Width="210px">
                                                                        </telerik:RadDropDownList>
                                                                    </div>
                                                                </td>
															    <td class="auto-style10" >
															        &nbsp;
															        <div align="right">

                                                                        Igreja</div>

                                                                    </td>

                                                                <td class="auto-style2">
																    &nbsp;</td>

                                                                <td class="auto-style16">
                                                                    <telerik:RadDropDownList ID="cboIgreja" 
                                                                                                runat="server" 
                                                                                                Width="210px" 
                                                                                                Skin="WebBlue">
                                                                    </telerik:RadDropDownList>
                                                                </td>

                                                                <td class="auto-style14">
																    &nbsp;</td>

                                                                <td class="auto-style2">
																
                                                                    &nbsp;</td>
														        <td class="auto-style2">&nbsp;</td>
														        <td class="auto-style2">&nbsp;</td>
														    </tr>
														    <tr>
                                                                <td class="auto-style2">&nbsp;</td>
                                                                <td class="auto-style3">&nbsp;</td>
                                                                <td class="auto-style3">&nbsp;</td>
                                                                <td class="auto-style10">&nbsp;</td>
                                                                <td class="auto-style2">&nbsp;</td>
                                                                <td class="auto-style16">&nbsp;</td>
                                                                <td class="auto-style14">&nbsp;</td>
                                                                <td class="auto-style2">&nbsp;</td>
                                                                <td class="auto-style2">&nbsp;</td>
                                                                <td class="auto-style2">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style2" colspan="10">
                                                                    <%--<asp:ValidationSummary ID="ValidationSummary1" 
                                                                        DisplayMode="BulletList"
                                                                        ShowMessageBox="false"
                                                                                           runat="server" />--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style2">&nbsp;</td>
                                                                <td class="auto-style3">&nbsp;</td>
                                                                <td class="auto-style3">&nbsp;</td>
                                                                <td class="auto-style10">&nbsp;</td>
                                                                <td class="auto-style2">&nbsp;</td>
                                                                <td class="auto-style16">&nbsp;</td>
                                                                <td class="auto-style14">&nbsp;</td>
                                                                <td class="auto-style2">&nbsp;</td>
                                                                <td class="auto-style2">&nbsp;</td>
                                                                <td class="auto-style2">&nbsp;</td>
                                                            </tr>
														    </table>

                        </div>

                    </telerik:RadWizardStep>

                    <telerik:RadWizardStep ID="stepEndereçoRS" 
                                           Title="Ende. Redes Sociais" 
                                           runat="server" 
                                           StepType="Step" 
                                           CausesValidation="true"
                                           BackColor="#d3e1ee">

                        <div id="divEndeRedeSocial" class="txt1">
                            
                            <table border="0" cellspacing="0" cellpadding="0" id="tbl1" class="auto-style11">
														    <tr>
															    <td class="txt1"><div align="right">Whatsapp:
																    </div>
															    </td>
															    <td class="auto-style28">
																    &nbsp;&nbsp;
																																
                                                                    <%--<telerik:RadTextBox ID="txtNumeroWhats" 
                                                                                        runat="server" 
                                                                                        Skin="WebBlue" 
                                                                                        InputType="Tel"                                                                        
                                                                                        MaxLength="14">
                                                                    </telerik:RadTextBox>--%>
                                                                    <telerik:RadMaskedTextBox RenderMode="Lightweight" 
                                                                                              ID="txtNumeroWhats2" 
                                                                                              runat="server" 
                                                                                              Mask="(##) #####-####" 
                                                                                              Width="150px"                                                                        
                                                                                              ValidationGroup="Group1">
                                                                    </telerik:RadMaskedTextBox>
																    <img src="../Images/logoWhats.png" border="0"  height="20px" width="20px" /></td>
                                                            
															    <td  class="txt1">
																    <div align="right">Tel. Fixo
																    </div>
															    </td>
															    <td class="auto-style30">
																
                                                                    </td>
															    <td class="auto-style31">
																
                                                                    <%--<telerik:RadTextBox ID="txtTelefoneFixo" 
                                                                                        runat="server" 
                                                                                        Skin="WebBlue" 
                                                                                        InputType="Tel"
                                                                                        MaxLength="13">
                                                                    </telerik:RadTextBox>--%>
																    <telerik:RadMaskedTextBox RenderMode="Lightweight" 
                                                                                              ID="txtTelefoneFixo2" 
                                                                                              runat="server" 
                                                                                              Mask="(##) #####-####" 
                                                                                              Width="150px"                                                                        
                                                                                              ValidationGroup="Group1">
                                                                    </telerik:RadMaskedTextBox>
                                                                    </td>
															    <td class="auto-style22">
																
																
															    </td>
															    <td class="auto-style30">
																
                                                                    </td>
														    </tr>
														    <tr>
															    <td class="txt1"><div align="right" class="auto-style36">Telefone de emergência:
																    </div>
															    </td>
															    <td class="auto-style18">
																
                                                                    &nbsp;&nbsp;
																
                                                                    <%--<telerik:RadTextBox ID="txtTelefoneEmergencia" 
                                                                                        runat="server" 
                                                                                        Skin="WebBlue" 
                                                                                        InputType="Tel"
                                                                                        MaxLength="14">
                                                                    </telerik:RadTextBox>--%>
																    <telerik:RadMaskedTextBox RenderMode="Lightweight" 
                                                                                              ID="txtTelefoneEmergencia2" 
                                                                                              runat="server" 
                                                                                              Mask="(##) #####-####" 
                                                                                              Width="150px"                                                                        
                                                                                              ValidationGroup="Group1">
                                                                    </telerik:RadMaskedTextBox>
                                                                    </td>
															    <td  class="txt1">
																    <div align="right">&nbsp;Falar com:</div>
															    </td>
															    <td class="auto-style20">
																
                                                                    </td>
															    <td class="auto-style21">
																
                                                                    <telerik:RadTextBox ID="txtContatoEmergencia" 
                                                                                        runat="server" 
                                                                                        Skin="WebBlue" 
                                                                                        InputType="Tel"
                                                                                        MaxLength="100">
                                                                    </telerik:RadTextBox>
																
                                                                    </td>
															    <td class="auto-style27">
																
																
															    </td>
															    <td class="auto-style20">
																
                                                                    </td>
														    </tr>														
														    <tr>
															    <td  class="txt1">
                                                                    <div align="right">Endereço:
																    </div>
															    </td>
															    <td class="auto-style3">
                                                                
                                                                    &nbsp;&nbsp;
                                                                
                                                                    <telerik:RadTextBox ID="txtEnhdereco" 
                                                                                        runat="server" 
                                                                                        Skin="WebBlue" 
                                                                                        InputType="Tel"
                                                                                        MaxLength="245">
                                                                    </telerik:RadTextBox>
                                                                
                                                                    </td>
															    <td  class="txt1">
															        <div align="right">
                                                                        Cidade
															        </div>
                                                                </td>

                                                                <td class="auto-style2">
                                                                
                                                                    &nbsp;</td>

                                                                <td class="auto-style16">
                                                                
                                                                    <telerik:RadTextBox ID="txtCidade" 
                                                                                        runat="server" 
                                                                                        Skin="WebBlue" 
                                                                                        InputType="Tel"
                                                                                        MaxLength="150">
                                                                    </telerik:RadTextBox>
																    </td>

                                                                <td class="auto-style14">
                                                                
                                                                    &nbsp;</td>

                                                                <td class="auto-style2">
                                                                
                                                                    &nbsp;</td>
														    </tr>
														    <tr>
															    <td  class="txt1">
                                                                    <div align="right">&nbsp;Bairro:
																    </div>
															    </td>
															    <td class="auto-style40">
                                                                
                                                                    &nbsp;&nbsp;
                                                                
                                                                    <telerik:RadTextBox ID="txtBairro" 
                                                                                        runat="server" 
                                                                                        Skin="WebBlue" 
                                                                                        InputType="Tel"
                                                                        MaxLength="150">
                                                                    </telerik:RadTextBox>
                                                                
                                                                    </td>
															    <td  class="txt1">
															        <div align="right">
                                                                        Estado:
															        </div>&nbsp;
															        </td>
															    <td class="auto-style41">
																    </td>
															    <td class="auto-style42">
																
                                                                    <telerik:RadComboBox ID="cboEstadosBrasil"
                                                                        runat="server"
                                                                        Skin="WebBlue"
                                                                        Height="100px"
                                                                        Width="220px" Culture="pt-BR">
                                                                        <Items>
                                                                            <telerik:RadComboBoxItem runat="server" Text="Acre" Value="Acre" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Alagoas" Value="Alagoas" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Amapá" Value="Amapá" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Amazonas" Value="Amazonas" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Bahia" Value="Bahia" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Campos" Value="Campos" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Ceará" Value="Ceará" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Distrito Federal" Value="Distrito Federal" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Espírito Santo" Value="Espírito Santo" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Goiás" Value="Goiás" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Maranhão" Value="Maranhão" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Mato Grosso" Value="Mato Grosso" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Mato Grosso do Sul" Value="Mato Grosso do Sul" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Minas Gerais" Value="Minas Gerais" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Pará" Value="Pará" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Paraíba" Value="Paraíba" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Paraná" Value="Paraná" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Pernambuco" Value="Pernambuco" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Piauí" Value="Piauí" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Rio de Janeiro" Value="Rio de Janeiro" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Rio Grande do Norte" Value="Rio Grande do Norte" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Rio Grande do Sul" Value="Rio Grande do Sul" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Rondônia" Value="Rondônia" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Roraima" Value="Roraima" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Santa Catarina" Value="Santa Catarina" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="São Paulo" Value="São Paulo" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Sergipe" Value="Sergipe" />
                                                                            <telerik:RadComboBoxItem runat="server" Text="Tocantins" Value="Tocantins" />
                                                                        </Items>
                                                                    </telerik:RadComboBox>

															    </td>
															    <td class="auto-style43">
																    </td>
															    <td class="auto-style41">
																
                                                                    </td>
														    </tr>
														    <tr>
															    <td  class="txt1">
                                                                    <div align="right">Mora com quem?
																    </div>
															    </td>
															    <td colspan="5">
															        &nbsp;&nbsp;
															        <telerik:RadRadioButtonList ID="rbTipoMoradia" 
                                                                                                    runat="server" 
                                                                                                    Text="Sim" 
                                                                                                    Direction="Horizontal" 
                                                                                                    SelectedIndex="0" 
                                                                                                    SelectedValue="0" 
                                                                                                    Width="472px"
                                                                                                    AutoPostBack="false">                                                                        
                                                                    </telerik:RadRadioButtonList>
                                                               </td>

                                                                <td>
																
                                                                    </td>
														    </tr>
														    <tr>
															    <td height="12" class="auto-style23">&nbsp;</td>
															    <td class="auto-style1">
                                                                    &nbsp;&nbsp;
                                                                    </td>
															    <td class="auto-style9">

															        <span id="lblChurchName" />
                                                                </td>

                                                                <td>
                                                                    &nbsp;</td>

                                                                <td class="auto-style15">
																    &nbsp;</td>

                                                                <td class="auto-style13">
																    &nbsp;</td>

                                                                <td>
																    &nbsp;</td>
														    </tr>
														    <tr>
															    <td height="12" class="txt1">
															        <div align="right">

                                                                        Instagram</div>

															    </td>
															    <td class="auto-style1">
                                                                    &nbsp;
																
                                                                    &nbsp;
                                                            																
                                                                    <telerik:RadTextBox ID="txtInstagram" 
                                                                                        runat="server" 
                                                                                        Skin="WebBlue" 
                                                                                        InputType="Text"
                                                                                        MaxLength="240">
                                                                    </telerik:RadTextBox>
																
                                                                </td>
															    <td class="txt1">
															        <div align="right">

                                                                        Facebook</div>

                                                                </td>

                                                                <td>
                                                                    &nbsp;&nbsp; &nbsp;</td>

                                                                <td class="auto-style15">
																
                                                                    <telerik:RadTextBox ID="txtFacebook" 
                                                                                        runat="server" 
                                                                                        Skin="WebBlue" 
                                                                                        InputType="Text"
                                                                                        MaxLength="240">
                                                                    </telerik:RadTextBox>
																
                                                                    <br />
                                                                </td>

                                                                <td class="auto-style13">
                                                                    &nbsp;</td>

                                                                <td>
                                                                    &nbsp;</td>
														    </tr>
														    <tr>
															    <td height="12" class="txt1">
															        <div align="right">

                                                                        E-mail</div>

															    </td>
															    <td class="auto-style1">
																
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;
																
                                                                    <telerik:RadTextBox ID="txtEmail" 
                                                                                        runat="server" 
                                                                                        Skin="WebBlue" 
                                                                                        InputType="Email"
                                                                                        MaxLength="240">
                                                                    </telerik:RadTextBox>
																
                                                                </td>
															    <td  class="txt1">
															        <div align="right">

                                                                        Twitter</div>

                                                                </td>

                                                                <td>
                                                                    &nbsp;</td>

                                                                <td class="auto-style15">
																
                                                                    <telerik:RadTextBox ID="txtTwitter" 
                                                                                        runat="server" 
                                                                                        Skin="WebBlue" 
                                                                                        InputType="Tel"
                                                                                        MaxLength="140">
                                                                    </telerik:RadTextBox>
																
                                                                </td>

                                                                <td class="auto-style13">
                                                                    &nbsp;</td>

                                                                <td>
                                                                    &nbsp;</td>
														    </tr>
														    <tr>
															    <td height="12" class="auto-style23">
															        &nbsp;</td>
															    <td class="auto-style1">
                                                                    &nbsp;</td>
															    <td class="auto-style9">
															        &nbsp;</td>

                                                                <td>
                                                                    &nbsp;</td>

                                                                <td class="auto-style15">
                                                                    &nbsp;</td>

                                                                <td class="auto-style13">
                                                                    &nbsp;</td>

                                                                <td>
                                                                    &nbsp;</td>
														    </tr>
													    </table>

                        </div>

                    </telerik:RadWizardStep>
                    <telerik:RadWizardStep ID="stepDadosCivisProfissionais" 
                                           Title="Dados civis e profissionais" 
                                           runat="server" 
                                           StepType="Step" 
                                           CausesValidation="true"
                                           BackColor="#d3e1ee">

                        <div id="divDadosCivisProfissionais" class="txt1">

                            <table border="0" cellspacing="0" cellpadding="0" id="tbl3" class="auto-style11">
														    <tr>
															    <td class="txt1"><div align="right">
                                                                    Estado Civil:
																    </div>
															    </td>
															    <td colspan="6">
																    &nbsp;&nbsp;<telerik:RadRadioButtonList ID="rbTipoEstadoCivil" 
                                                                                                    runat="server" 
                                                                                                    Text="Sim" 
                                                                                                    Direction="Horizontal" 
                                                                                                    SelectedIndex="0" 
                                                                                                    SelectedValue="0" 
                                                                                                    Width="472px"
                                                                                                    AutoPostBack="false">                                                                        
                                                                    </telerik:RadRadioButtonList>
                                                               &nbsp;</td>
                                                            
														    </tr>
														    <tr>
															    <td class="txt1"><div align="right" class="auto-style36">
                                                                    Nome Cônjuge:
																    </div>
															    </td>
															    <td class="auto-style18">
																
                                                                    &nbsp;&nbsp;
																
                                                                    <telerik:RadTextBox ID="txtNomeconjuge" 
                                                                                        runat="server" 
                                                                                        Skin="WebBlue"
                                                                                        MaxLength="200">
                                                                    </telerik:RadTextBox>
																
                                                                    </td>
															    <td class="txt1">
																    <div align="right">&nbsp;Data casamento:</div>
															    </td>
															    <td class="auto-style20">
																
                                                                    </td>
															    <td class="auto-style44">
																
                                                                    <telerik:RadDatePicker ID="txtDataCasamento" 
                                                                                           Runat="server" 
                                                                                           Skin="WebBlue" 
                                                                                           Width="100%"
                                                                                           Culture="PT-BR"
                                                                                           DateInput-MaxLength="10">
                                                                    </telerik:RadDatePicker>
																
                                                                    </td>
															    <td class="auto-style27">
																
																
															    </td>
															    <td class="auto-style20">
																
                                                                    </td>
														    </tr>														
														    <tr>
															    <td class="txt1">
                                                                    <div align="right">Cônjuge é da igreja?:
																    </div>
															    </td>
															    <td class="auto-style3">
                                                                
                                                                    &nbsp;&nbsp;
                                                                
                                                                    <telerik:RadRadioButtonList ID="rbConjugeEhIURD" 
                                                                                                    runat="server" 
                                                                                                    Text="Sim" 
                                                                                                    Direction="Horizontal" 
                                                                                                    SelectedIndex="0" 
                                                                                                    SelectedValue="0" 
                                                                                                    Width="109px" AutoPostBack="False" >
                                                                        <Items>
                                                                            <telerik:ButtonListItem Text="Sim" Value="0" />
                                                                            <telerik:ButtonListItem Text="Não" Value="1" />
                                                                        </Items>
                                                                    </telerik:RadRadioButtonList>
                                                           

															    </td>
															    <td class="txt1">
															        <div align="right">
                                                                        Possui filhos?
															        </div>
                                                                </td>

                                                                <td class="auto-style2">
                                                                
                                                                    &nbsp;</td>

                                                                <td class="auto-style45">
                                                                
                                                                    <telerik:RadRadioButtonList ID="rbPossuiFilhos" 
                                                                                                    runat="server" 
                                                                                                    Text="Sim" 
                                                                                                    Direction="Horizontal" 
                                                                                                    SelectedIndex="0" 
                                                                                                    SelectedValue="0" 
                                                                                                    AutoPostBack="false"
                                                                                                    Width="109px" >
                                                                        <Items>
                                                                            <telerik:ButtonListItem  Text="Sim" Value="0" />
                                                                            <telerik:ButtonListItem Text="Não" Value="1" />
                                                                        </Items>
                                                                    </telerik:RadRadioButtonList>
                                                           

																    </td>

                                                                <td class="auto-style14">
                                                                
                                                                     Quantos?                                                                     
                                                                    <telerik:RadNumericTextBox ID="txtQtdFilhos2"
                                                                                         runat="server" 
                                                                                         Width="45px"
                                                                                         RenderMode="Lightweight"
                                                                                         NumberFormat-DecimalDigits="0"                                                                                         
                                                                                         Value="0"
                                                                                         ShowSpinButtons="false"
                                                                                         MaxLength="2"/>    
                                                                </td>

                                                                <td class="auto-style2">
                                                                
                                                                    &nbsp;</td>
														    </tr>
														    <tr>
															    <td class="txt1">
                                                                    &nbsp;</td>
															    <td class="auto-style3">
                                                                
                                                                    &nbsp;</td>
															    <td class="txt1">
															        &nbsp;</td>

                                                                <td class="auto-style2">
                                                                
                                                                    &nbsp;</td>

                                                                <td class="auto-style45">
                                                                
                                                                    &nbsp;</td>

                                                                <td class="auto-style14">
                                                                
                                                                     &nbsp;</td>

                                                                <td class="auto-style2">
                                                                
                                                                    &nbsp;</td>
														    </tr>
														    <tr>
															    <td class="txt1">
                                                                    <div align="right">&nbsp;Trabalha?
																    </div>
															    </td>
															    <td class="auto-style40">
                                                                
                                                                    &nbsp;&nbsp;
                                                                
                                                                    <telerik:RadRadioButtonList ID="rbTrabalha" 
                                                                                                    runat="server" 
                                                                                                    Text="Sim" 
                                                                                                    Direction="Horizontal" 
                                                                                                    SelectedIndex="0" 
                                                                                                    SelectedValue="0" 
                                                                                                    AutoPostBack="false"
                                                                                                    Width="131px" >
                                                                        <Items>
                                                                            <telerik:ButtonListItem  Text="Sim" Value="0" />
                                                                            <telerik:ButtonListItem Text="Não" Value="1" />
                                                                        </Items>
                                                                    </telerik:RadRadioButtonList>
                                                                
                                                                    </td>
															    <td class="txt1">
															        <div align="right">
                                                                        Estuda?
															        </div>&nbsp;
															        </td>
															    <td class="auto-style41">
																    </td>
															    <td class="auto-style46">
																
															        <telerik:RadRadioButtonList ID="rbEstuda" 
                                                                                                    runat="server" 
                                                                                                    Text="Sim" 
                                                                                                    Direction="Horizontal" 
                                                                                                    SelectedIndex="0" 
                                                                                                    SelectedValue="0" 
                                                                                                    AutoPostBack="false"
                                                                                                    Width="131px" >
                                                                        <Items>
                                                                            <telerik:ButtonListItem  Text="Sim" Value="0" />
                                                                            <telerik:ButtonListItem Text="Não" Value="1" />
                                                                        </Items>
                                                                    </telerik:RadRadioButtonList>
																
															    </td>
															    <td class="auto-style43">
																    </td>
															    <td class="auto-style41">
																
                                                                    </td>
														    </tr>
														    <tr>
															    <td class="txt1">
                                                                    <div align="right">Profissão
																    </div>
															    </td>
															    <td class="auto-style40">
                                                                
															        &nbsp;&nbsp;&nbsp;&nbsp;
																
                                                                    <telerik:RadTextBox ID="txtProfissao" 
                                                                                        runat="server" 
                                                                                        Skin="WebBlue"
                                                                                        MaxLength="100">
                                                                    </telerik:RadTextBox>
																
                                                                </td>
															    <td class="txt1">
															    
                                                                    <div align="right">
                                                                        Grau:
                                                                    </div>
															    </td>
															    <td class="auto-style41">
																    &nbsp;</td>
															    <td class="auto-style46">
																
                                                                    <telerik:RadTextBox ID="txtGrau" 
                                                                                        runat="server" 
                                                                                        Skin="WebBlue" 
                                                                                        InputType="Text"
                                                                                        MaxLength="40">
                                                                    </telerik:RadTextBox>
																
															    </td>
															    <td class="auto-style43">
																    &nbsp;</td>
															    <td class="auto-style41">
																
                                                                    &nbsp;</td>
														    </tr>
														    <tr>
															    <td height="12"  class="txt1">
															        <div align="right">

                                                                        Empresa</div>

															    </td>
															    <td class="auto-style1">
                                                                    &nbsp; &nbsp;&nbsp;
                                                            																
                                                                    <telerik:RadTextBox ID="txtEmpresa" 
                                                                                        runat="server" 
                                                                                        Skin="WebBlue"
                                                                                        MaxLength="130">
                                                                    </telerik:RadTextBox>
																
                                                                </td>
															    <td class="txt1">
															        <div align="right">

                                                                        Onde estuda</div>

                                                                </td>

                                                                <td>
                                                                    &nbsp;&nbsp; &nbsp;</td>

                                                                <td class="auto-style47">
																
                                                                    <telerik:RadTextBox ID="txtInstituicaoOndeEstuda" 
                                                                                        runat="server" 
                                                                                        Skin="WebBlue" 
                                                                                        InputType="Tel"
                                                                                        MaxLength="150">
                                                                    </telerik:RadTextBox>
																
                                                                    <br />
                                                                </td>

                                                                <td class="auto-style13">
                                                                    &nbsp;</td>

                                                                <td>
                                                                    &nbsp;</td>
														    </tr>
														    <tr>
															    <td height="12"class="txt1">
															        <div align="right">

                                                                        Tem título de eleitor?</div>

															    </td>
															    <td class="auto-style1">
																
                                                                    &nbsp;&nbsp;
                                                                
                                                                    <telerik:RadRadioButtonList ID="rbPossuiTituloeleitor" 
                                                                                                    runat="server" 
                                                                                                    Text="Sim" 
                                                                                                    Direction="Horizontal" 
                                                                                                    SelectedIndex="0" 
                                                                                                    SelectedValue="0" 
                                                                                                    AutoPostBack="false"
                                                                                                    Width="131px" >
                                                                        <Items>
                                                                            <telerik:ButtonListItem  Text="Sim" Value="0" />
                                                                            <telerik:ButtonListItem Text="Não" Value="1" />
                                                                        </Items>
                                                                    </telerik:RadRadioButtonList>
                                                                
                                                                    &nbsp;</td>
															    <td class="txt1">
															        <div align="right">

                                                                        Grau instrução</div>

                                                                </td>

                                                                <td>
                                                                    &nbsp;</td>

                                                                <td class="auto-style47">
																
                                                                    <telerik:RadTextBox ID="txtGrauInstrucao" 
                                                                                        runat="server" 
                                                                                        Skin="WebBlue" 
                                                                                        InputType="Tel" >
                                                                    </telerik:RadTextBox>
																
                                                                </td>

                                                                <td class="auto-style13">
                                                                    &nbsp;</td>

                                                                <td>
                                                                    &nbsp;</td>
														    </tr>
														    <tr>
															    <td height="12" class="auto-style23">
															        &nbsp;</td>
															    <td class="auto-style1">
                                                                    &nbsp;</td>
															    <td class="auto-style9">
															        &nbsp;</td>

                                                                <td>
                                                                    &nbsp;</td>

                                                                <td class="auto-style47">
                                                                    &nbsp;</td>

                                                                <td class="auto-style13">
                                                                    &nbsp;</td>

                                                                <td>
                                                                    &nbsp;</td>
														    </tr>
													    </table>

                        </div>

                    </telerik:RadWizardStep>
                    <telerik:RadWizardStep ID="stepDadosEspirituais" 
                                           Title="Dados espirituais" 
                                           runat="server" 
                                           StepType="Step" 
                                           CausesValidation="true"
                                           BackColor="#d3e1ee">

                        <div id="divDadosEspirituais" class="txt1">

                            <telerik:RadToolTip RenderMode="Lightweight" 
                                                runat="server" 
                                                ID="rttMesAno" 
                                                Width="200px" 
                                                ShowEvent="onmouseover"
                                                RelativeTo="Element" 
                                                Animation="Resize" 
                                                TargetControlID="txtMesAnoAfastou" 
                                                IsClientID="true"
                                                HideEvent="LeaveTargetAndToolTip" 
                                                Position="TopRight" 
                                                Text="Preencha este campo da seguinte forma: <b>Mês/Ano</b>"></telerik:RadToolTip>
                            <table border="0" cellspacing="0" cellpadding="0" id="tbl3" class="auto-style11">
														    <tr>
															    <td class="style1"><div align="right">É membro da IURD?
																    </div>
															    </td>
															    <td class="auto-style1">
																    &nbsp;&nbsp;
																    <telerik:RadRadioButtonList ID="rbEhMembroIURD" 
                                                                                                    runat="server" 
                                                                                                    Text="Sim" 
                                                                                                    Direction="Horizontal" 
                                                                                                    SelectedIndex="0" 
                                                                                                    SelectedValue="0" 
                                                                                                    AutoPostBack="false"
                                                                                                    Width="128px" >
                                                                        <Items>
                                                                            <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                            <telerik:ButtonListItem Text="Não" Value="N" />
                                                                        </Items>
                                                                    </telerik:RadRadioButtonList>
																    </td>
                                                            
															    <td class="auto-style9">
																    <div align="right">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mês e ano que chegou?</div>
															    </td>
															    <td>
																
                                                                    &nbsp;</td>
															    <td class="auto-style15">
																
                                                                    <%--<telerik:RadTextBox ID="txtMesAnoChegadaIURD" 
                                                                        Runat="server" 
                                                                        Skin="WebBlue"
                                                                        EmptyMessage="Digite: Mês/Ano"
                                                                        MaxLength="7">
                                                                    </telerik:RadTextBox>--%>
																    <telerik:RadMaskedTextBox RenderMode="Lightweight" 
                                                                                              ID="txtMesAnoChegadaIURD" 
                                                                                              runat="server" 
                                                                                              Mask="##/####" 
                                                                                              Width="150px"                                                                        
                                                                                              DisplayText="00/0000"
                                                                                              ValidationGroup="Group1">
                                                                    </telerik:RadMaskedTextBox>
                                                                </td>
															    <td class="auto-style13">
																
																    <div align="right">Como conheceu?: &nbsp;</div>
															    </td>
															    <td>
																
                                                                    <telerik:RadTextBox ID="txtComoConheceuIURD" Runat="server" Skin="WebBlue" >
                                                                    </telerik:RadTextBox>
																
                                                                </td>
														    </tr>
														    <tr>
															    <td height="30" class="style1"><div align="right">Já se afastou alguma vez?
																    </div>
															    </td>
															    <td class="auto-style1">
																
                                                                    &nbsp;&nbsp;
																
                                                                    <telerik:RadRadioButtonList ID="rbJaSeAfastou" 
                                                                                                    runat="server" 
                                                                                                    Text="Sim" 
                                                                                                    Direction="Horizontal" 
                                                                                                    SelectedIndex="0" 
                                                                                                    SelectedValue="0" 
                                                                                                    Width="128px" 
                                                                                                    AutoPostBack="false">
                                                                        <Items>
                                                                            <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                            <telerik:ButtonListItem Text="Não" Value="N" />
                                                                        </Items>
                                                                    </telerik:RadRadioButtonList>
																
                                                                </td>
															    <td class="auto-style9">
																    <div align="right">&nbsp;Porque?</div>
															    </td>
															    <td>
																
                                                                    &nbsp;</td>
															    <td class="auto-style15">
																
                                                                    <telerik:RadTextBox ID="txctMotivoAfastamento" Runat="server" Skin="WebBlue" InputType="Tel" >
                                                                    </telerik:RadTextBox>
																
                                                                </td>
															    <td class="auto-style13">
																
																    &nbsp;</td>
															    <td>
																
                                                                    &nbsp;</td>
														    </tr>														
														    <tr>
															    <td height="12" class="style1"><div align="right">Quado se afastou?
																    </div>
															    </td>
															    <td class="auto-style1">
                                                                
                                                                    &nbsp;&nbsp;
                                                                
                                                                    <%--<telerik:RadTextBox ID="txtMesAnoAfastou" 
                                                                                        Runat="server" 
                                                                                        Skin="WebBlue" 
                                                                                        EmptyMessage="Digite: Mês/Ano"
                                                                                        MaxLength="7" >
                                                                    </telerik:RadTextBox>--%>
                                                                    <telerik:RadMaskedTextBox RenderMode="Lightweight" 
                                                                                              ID="txtMesAnoAfastou2" 
                                                                                              runat="server" 
                                                                                              Mask="##/####" 
                                                                                              Width="150px"                                                                        
                                                                                              DisplayText="00/0000"
                                                                                              ValidationGroup="Group1">
                                                                    </telerik:RadMaskedTextBox>
																
                                                                    </td>
															    <td class="auto-style9">
																    <div align="right">Por quanto tempo?</div>
															    </td>
															    <td>
																
                                                                    &nbsp;</td>
															    <td class="auto-style15">
																
                                                                    <telerik:RadTextBox ID="txtPorQuantoTempoSeAfastou" Runat="server" Skin="WebBlue" InputType="Tel" >
                                                                    </telerik:RadTextBox>
																
                                                                </td>
															    <td class="auto-style14">
																    <div align="right">Está firme desde quando?</div>
															    </td>
															    <td>
																
                                                                    <%--<telerik:RadMonthYearPicker ID="txtDesdeQuandoFirme2" 
                                                                                                Runat="server" 
                                                                                                Skin="WebBlue" 
                                                                                                Width="110px"
                                                                                                EmptyMessage="Digite: Mês/Ano"
                                                                                                MaxLength="7">
                                                                    </telerik:RadMonthYearPicker>--%>
                                                                    <telerik:RadMaskedTextBox RenderMode="Lightweight" 
                                                                                              ID="txtDesdeQuandoFirme" 
                                                                                              runat="server" 
                                                                                              Mask="##/####" 
                                                                                              Width="150px"                                                                        
                                                                                              DisplayText="00/0000"
                                                                                              ValidationGroup="Group1">
                                                                    </telerik:RadMaskedTextBox>
																
                                                                </td>
														    </tr>
														    <tr>
															    <td class="auto-style2">
                                                                    <div align="right">Tem familiares na Universal?</div>
															    </td>
															    <td class="auto-style3">
                                                                
                                                                    &nbsp;&nbsp;
                                                                
                                                                    <telerik:RadRadioButtonList ID="rbTemFamiliaresIURD" 
                                                                                                    runat="server" 
                                                                                                    Text="Sim" 
                                                                                                    Direction="Horizontal" 
                                                                                                    SelectedIndex="0" 
                                                                                                    SelectedValue="0" 
                                                                                                    Width="128px" 
                                                                                                    AutoPostBack="false">
                                                                        <Items>
                                                                            <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                            <telerik:ButtonListItem Text="Não" Value="N" />
                                                                        </Items>
                                                                    </telerik:RadRadioButtonList>
                                                                
                                                                </td>
															    <td class="auto-style10">
															        <div align="right">

                                                                        Quem são?</div>
                                                                </td>

                                                                <td class="auto-style2">
                                                                
                                                                    &nbsp;</td>

                                                                <td class="auto-style16" colspan="2">
                                                                
                                                                    <telerik:RadTextBox ID="txtFamiliaresIURD" Runat="server" Skin="WebBlue" InputType="Tel" Width="200px" >
                                                                    </telerik:RadTextBox>
																
																    </td>

                                                                <td class="auto-style2">
                                                                
                                                                    &nbsp;</td>
														    </tr>
														    <tr>
															    <td class="auto-style2">
                                                                    &nbsp;</td>
															    <td class="auto-style3">
                                                                
                                                                    &nbsp;&nbsp;
                                                                
                                                                    </td>
															    <td class="auto-style10">
															        &nbsp;
															        </td>
															    <td class="auto-style2">
																    &nbsp;</td>
															    <td class="auto-style16">
																    &nbsp;</td>
															    <td class="auto-style14">
																    &nbsp;</td>
															    <td class="auto-style2">
																
                                                                    &nbsp;</td>
														    </tr>
														    <tr>
															    <td class="auto-style2"><div align="right">Batizado nas águas?</div>
															    </td>
															    <td class="auto-style3">
																    <telerik:RadRadioButtonList ID="rbBatizadoAguas" 
                                                                        runat="server" 
                                                                        Text="Sim" 
                                                                        Direction="Horizontal" 
                                                                        SelectedIndex="0" 
                                                                        SelectedValue="0"                                                                    
                                                                        AutoPostBack="false"
                                                                        Width="128px" >
                                                                        <Items>
                                                                            <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                            <telerik:ButtonListItem Text="Não" Value="N" />
                                                                        </Items>
                                                                    </telerik:RadRadioButtonList>
                                                                </td>
															    <td class="auto-style10" >
															        &nbsp;
															        <div align="right">

                                                                        Quando?</div>

                                                                    </td>

                                                                <td class="auto-style2">
																    &nbsp;</td>

                                                                <td class="auto-style16">
																
                                                                    <%--<telerik:RadTextBox ID="txtQuandoSeBatizouAguas" 
                                                                                        Runat="server" 
                                                                                        Skin="WebBlue" 
                                                                                        Width="120px"
                                                                                        EmptyMessage="Digite: Mês/Ano"
                                                                                        MaxLength="7">
                                                                    </telerik:RadTextBox>--%>
                                                                    <telerik:RadMaskedTextBox RenderMode="Lightweight" 
                                                                                              ID="txtQuandoSeBatizouAguas2" 
                                                                                              runat="server" 
                                                                                              Mask="##/####" 
                                                                                              Width="150px"                                                                        
                                                                                              DisplayText="00/0000"
                                                                                              ValidationGroup="Group1">
                                                                    </telerik:RadMaskedTextBox>
																
                                                                </td>

                                                                <td class="auto-style14">
																    Foi na igreja universal?</td>

                                                                <td class="auto-style2">
																
																    <telerik:RadRadioButtonList ID="rbBatismoAguasNaIURD" 
                                                                                                runat="server" 
                                                                                                Text="Sim" 
                                                                                                Direction="Horizontal" 
                                                                                                SelectedIndex="0" 
                                                                                                SelectedValue="0" 
                                                                                                AutoPostBack="false"
                                                                                                Width="128px" >
                                                                        <Items>
                                                                            <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                            <telerik:ButtonListItem Text="Não" Value="N" />
                                                                        </Items>
                                                                    </telerik:RadRadioButtonList>
																    </td>
														    </tr>
														    <tr>
															    <td height="12" class="style1"><div align="right">Batizado com o Espírito Santo?</div>
															    </td>
															    <td class="auto-style1">
                                                                    &nbsp;&nbsp;
                                                                    <telerik:RadRadioButtonList ID="rbBatizadoEspiritoSanto" runat="server" Text="Sim" 
                                                                                                Direction="Horizontal" 
                                                                                                SelectedIndex="0" 
                                                                                                SelectedValue="0" 
                                                                                                Width="128px"
                                                                                                AutoPostBack="false">
                                                                        <Items>
                                                                            <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                            <telerik:ButtonListItem Text="Não" Value="N" />
                                                                        </Items>
                                                                    </telerik:RadRadioButtonList>
                                                                </td>
															    <td class="auto-style9">
															        <div align="right">

                                                                        Quando?</div>

															        <span id="lblChurchName0" />
                                                                </td>

                                                                <td>
                                                                    &nbsp;</td>

                                                                <td class="auto-style15">
																
                                                                    <%--<telerik:RadTextBox ID="txtQuandoSeBatizadoES" 
                                                                                        Runat="server" 
                                                                                        Skin="WebBlue" 
                                                                                        EmptyMessage="Digite: Mês/Ano"
                                                                                        MaxLength="7"
                                                                                        Width="120px" >
                                                                    </telerik:RadTextBox>--%>
                                                                    <telerik:RadMaskedTextBox RenderMode="Lightweight" 
                                                                                              ID="txtQuandoSeBatizadoES1" 
                                                                                              runat="server" 
                                                                                              Mask="##/####" 
                                                                                              Width="150px"                                                                        
                                                                                              DisplayText="00/0000"
                                                                                              ValidationGroup="Group1">
                                                                    </telerik:RadMaskedTextBox>
																
                                                                </td>

                                                                <td class="auto-style13">
																    Onde?</td>

                                                                <td>
																
                                                                    <telerik:RadTextBox ID="txtOndeBatismoEspiritoSanto" Runat="server" Skin="WebBlue" InputType="Tel" Width="120px" >
                                                                    </telerik:RadTextBox>
																
                                                                </td>
														    </tr>
														    <tr>
															    <td height="12" class="style1">
															        &nbsp;</td>
															    <td class="auto-style1">
                                                                    &nbsp;
																
                                                                    &nbsp;
                                                                </td>
															    <td class="auto-style9">
															        &nbsp;</td>

                                                                <td>
                                                                    &nbsp;&nbsp; &nbsp;</td>

                                                                <td class="auto-style15">
																
                                                                    <br />
                                                                </td>

                                                                <td class="auto-style13">
                                                                    &nbsp;</td>

                                                                <td>
                                                                    &nbsp;</td>
														    </tr>
														    <tr>
															    <td height="12" class="style1">
															        Como conheceu a força jovem universal</td>
															    <td class="auto-style1" colspan="5">
																
                                                                    <telerik:RadTextBox ID="txtComoConheceuFJU" Runat="server" Skin="WebBlue" InputType="Tel" Width="360px" >
                                                                    </telerik:RadTextBox>
																
                                                                </td>

                                                                <td>
                                                                    &nbsp;</td>
														    </tr>
														    <tr>
															    <td height="12" class="style1">
															        Quando entrou na FJU?</td>
															    <td class="auto-style1">
																
                                                                    <%--<telerik:RadTextBox ID="txtQuandoEntrouFJU" 
                                                                                        Runat="server" 
                                                                                        Skin="WebBlue" 
                                                                                        EmptyMessage="Digite: Mês/Ano"
                                                                                        MaxLength="7">
                                                                    </telerik:RadTextBox>--%>
                                                                    <telerik:RadMaskedTextBox RenderMode="Lightweight" 
                                                                                              ID="txtQuandoEntrouFJU" 
                                                                                              runat="server" 
                                                                                              Mask="##/####" 
                                                                                              Width="150px"                                                                        
                                                                                              DisplayText="00/0000"
                                                                                              ValidationGroup="Group1">
                                                                    </telerik:RadMaskedTextBox>
																
                                                                </td>
															    <td class="auto-style9">
															        Porque?</td>

                                                                <td>
                                                                    &nbsp;</td>

                                                                <td class="auto-style15" colspan="2">
																
                                                                    <telerik:RadTextBox ID="txtMotivoEntrouFJU" MaxLength="255" Runat="server" Skin="WebBlue" InputType="Tel" Width="260px" >
                                                                    </telerik:RadTextBox>
																
                                                                </td>

                                                                <td>
                                                                    &nbsp;</td>
														    </tr>
													    </table>

                        </div>

                    </telerik:RadWizardStep>
                    <telerik:RadWizardStep ID="stepSituacaoIURD_FJU" 
                                           Title="Situação IURD e FJU" 
                                           runat="server" 
                                           StepType="Step" 
                                           CausesValidation="true"
                                           BackColor="#d3e1ee">

                        <div id="divSituacaoIURD_FJU" class="txt1">

                            <table border="0" cellspacing="0" cellpadding="0" id="tbl3" class="auto-style11">
														    <tr>
															    <td background="../images/top_tit.jpg" class="auto-style4"  colspan="8">Qual sua situação atual na IURD e na FJU?( marque todas as opções que se encaixa )</td>
														    </tr>
														    <tr>
															    <td class="style1" colspan="2">&nbsp;
                                                                    <%--<asp:CheckBox ID="chkEhObreiro" 
                                                                                  runat="server" 
                                                                                  Text="Obreiro?" />--%>
                                                                    <telerik:RadCheckBox ID="chkEhObreiro2" 
                                                                                  runat="server" 
                                                                                  Text="Obreiro?"
                                                                                  AutoPostBack="false" />
                                                                    &nbsp;
															    </td>
                                                            
															    <td class="auto-style9">
																    <div align="left">Tempo de obreiro</div>
															    </td>
															    <td colspan="2">
																
                                                                    &nbsp;</td>
															    <td class="auto-style15">
																
                                                                    Anos
																
                                                                    <%--<telerik:RadTextBox ID="txtAnosEhObreiro" Runat="server" Skin="WebBlue" InputType="Number" Width="40px" >
                                                                    </telerik:RadTextBox>--%>
																    <telerik:RadNumericTextBox ID="txtAnosEhObreiro"
                                                                                               runat="server" 
                                                                                               Width="45px"
                                                                                               RenderMode="Lightweight"
                                                                                               NumberFormat-DecimalDigits="0"
                                                                                               MinValue="0"
                                                                                               Value="0"
                                                                                               ShowSpinButtons="false"
                                                                                               MaxLength="2"/>
                                                                &nbsp;Meses
																
                                                                    <telerik:RadNumericTextBox ID="txtMesesEhObreiro" 
                                                                                        runat="server" 
                                                                                               Width="45px"
                                                                                               RenderMode="Lightweight"
                                                                                               NumberFormat-DecimalDigits="0"
                                                                                               MinValue="0"
                                                                                               MaxValue="12"
                                                                                               Value="0"
                                                                                               MaxLength="2"/>
																
                                                                </td>
															    <td class="auto-style13">
																
																    <div align="right">
                                                                        <asp:CheckBox ID="CheckBox1" runat="server" Text="Colaborador" />
                                                                        ? &nbsp;</div>
															    </td>
															    <td>
																
                                                                    Tempo de Colaborador
                                                                    Anos
																
                                                                    <telerik:RadNumericTextBox ID="txtAnosEhColaborador"
                                                                                               runat="server" 
                                                                                               Skin="WebBlue"
                                                                                               MinValue="0"
                                                                                               ShowSpinButtons="false"
                                                                                               Width="45px"
                                                                                               NumberFormat-DecimalDigits="0" 
                                                                                               Value="0"
                                                                                               MaxLength="2">
																    </telerik:RadNumericTextBox>
                                                                &nbsp;Meses
																
                                                                    <telerik:RadNumericTextBox ID="txtMesesEhColaborador"
                                                                                               runat="server" 
                                                                                               Skin="WebBlue"
                                                                                               Width="45px"
                                                                                                ShowSpinButtons="false"
                                                                                               MinValue="0"
                                                                                               MaxValue="12"
                                                                                               Value="0"
                                                                                               NumberFormat-DecimalDigits="0"
                                                                                               MaxLength="2">
                                                                    </telerik:RadNumericTextBox>
																
                                                                </td>
														    </tr>
														    <tr>
															    <td height="30" class="style1" colspan="2">&nbsp;&nbsp;
																    <div align="left">
                                                                        <asp:CheckBox ID="chkCursandoCPO" runat="server" Text="Cursando CPO( Curso preparatório de Obreiros )" />
																    </div>
															    </td>
															    <td class="auto-style9">
																    <div align="right">&nbsp;Quando iniciou?</div>
															    </td>
															    <td colspan="2">
																
                                                                    &nbsp;</td>
															    <td class="auto-style15">
																
                                                                    Anos
																
                                                                    <telerik:RadNumericTextBox ID="txtAnosInicioCPO2"
                                                                                               runat="server" 
                                                                                               Skin="WebBlue"
                                                                                               Width="45px"
                                                                                               NumberFormat-DecimalDigits="0"
                                                                                               MaxLength="2"
                                                                                               MinValue="0"
                                                                                               Value="0">
                                                                    </telerik:RadNumericTextBox>
                                                                &nbsp;Meses                              
																    <telerik:RadNumericTextBox ID="txtMesesInicioCPO"
                                                                                               runat="server" 
                                                                                               Skin="WebBlue"
                                                                                               Width="45px"
                                                                                               NumberFormat-DecimalDigits="0"
                                                                                               MaxLength="2"
                                                                                               MinValue="0"
                                                                                               MaxValue="12"
                                                                                               Value="0">
                                                                    </telerik:RadNumericTextBox>
                                                                </td>
															    <td class="auto-style13">
																
																    &nbsp;</td>
															    <td>
																
                                                                    &nbsp;</td>
														    </tr>														
														    <tr>
															    <td height="12" class="style1" colspan="2">
                                                                
                                                                    <asp:CheckBox ID="chkMembroFJU" runat="server" Text="Membro da Força Jovem Universal ?" />
                                                                
                                                                    &nbsp;&nbsp;
                                                                
                                                                    </td>
															    <td class="auto-style9" colspan="4">
																    <asp:CheckBox ID="chkEhCoordenadorFJU" runat="server" Text="Coordenador da Força Jovem?" />
															    </td>
															    <td class="auto-style14">
																    <div align="right">Desde quando?</div>
															    </td>
															    <td>
																
                                                                    Anos
																
                                                                    <telerik:RadNumericTextBox ID="txtAnosInicioCoordenacaoFJU2"
                                                                                               runat="server"
                                                                                               Skin="WebBlue"
                                                                                               Width="45px"
                                                                                               NumberFormat-DecimalDigits="0"
                                                                                               MaxLength="2"
                                                                                               MinValue="0"
                                                                                               Value="0">

																    </telerik:RadNumericTextBox>
                                                                &nbsp;Meses
																
                                                                    <telerik:RadNumericTextBox ID="txtMesesInicioCoordenacaoFJU2"
                                                                                               runat="server"
                                                                                               Skin="WebBlue"
                                                                                               Width="45px"
                                                                                               NumberFormat-DecimalDigits="0"
                                                                                               MaxLength="2"
                                                                                               MinValue="0"
                                                                                               MaxValue="12"
                                                                                               Value="0"></telerik:RadNumericTextBox>
                                                                </td>
														    </tr>
														    <tr>
															    <td height="12" class="style1" colspan="2">
                                                                
                                                                    <asp:CheckBox ID="chkLiderTribo" runat="server" Text="Líder de Tribo" />
                                                                
                                                                    </td>
															    <td class="auto-style9" colspan="2">
															        <div align="right">

                                                                        Qual tribo? </div>
															    </td>
															    <td class="auto-style9" colspan="2">
                                                                
                                                                    &nbsp;&nbsp;&nbsp;
                                                                
                                                                    <telerik:RadDropDownList ID="cboTribos"                                                                     
                                                                                             runat="server" 
                                                                                             Skin="WebBlue" 
                                                                                             Height="16px" Width="120px">
                                                                    </telerik:RadDropDownList>

															    </td>
															    <td class="auto-style14">
                                                                
                                                                    Há quanto tempo&nbsp;?</td>
															    <td>
																
                                                                    Anos
																                                                                    
																    <telerik:RadNumericTextBox ID="txtAnosInicioCoordenacaoTribo2"
                                                                                               runat="server"
                                                                                               Skin="WebBlue"
                                                                                               Width="45px"
                                                                                               NumberFormat-DecimalDigits="0"
                                                                                               MaxLength="2"
                                                                                               MinValue="0"
                                                                                               Value="0"></telerik:RadNumericTextBox>

                                                                &nbsp;Meses
																                                                                    
                                                                    <telerik:RadNumericTextBox ID="txtMesesInicioCoordenacaoTribo2"
                                                                                                runat="server"
                                                                                               Skin="WebBlue"
                                                                                               Width="45px"
                                                                                               NumberFormat-DecimalDigits="0"
                                                                                               MaxLength="2"
                                                                                               MinValue="0"
                                                                                               MaxValue="12"
                                                                                               Value="0"></telerik:RadNumericTextBox>
																
                                                                </td>
														    </tr>
														    <tr>
															    <td height="12" class="style1" colspan="2">
                                                                
                                                                    <asp:CheckBox ID="chkLiderProjeto" runat="server" Text="Líder de Projeto" />
                                                                
                                                                    </td>
															    <td class="auto-style9" colspan="2">
															        <div align="right">

                                                                        Qual projeto?</div>
															    </td>
															    <td class="auto-style9" colspan="2">
                                                                
                                                                    &nbsp;&nbsp;&nbsp;
                                                                
                                                                    <telerik:RadDropDownList ID="cboProjetoFJU"                                                                     
                                                                                             runat="server" 
                                                                                             Skin="WebBlue" 
                                                                                             Height="16px" Width="120px">
                                                                    </telerik:RadDropDownList>

															    </td>
															    <td class="auto-style14">
                                                                
                                                                    Há quanto tempo&nbsp;?</td>
															    <td>
																
                                                                    Anos
																                                                                    
                                                                    <telerik:RadNumericTextBox ID="txtAnosInicioCoordenacaoProjeto2"
                                                                                               runat="server"
                                                                                               Skin="WebBlue"
                                                                                               Width="45px"
                                                                                               NumberFormat-DecimalDigits="0"
                                                                                               MaxLength="2"
                                                                                               MinValue="0"
                                                                                               Value="0"></telerik:RadNumericTextBox>
																
                                                                &nbsp;Meses
																                                                                    
                                                                    <telerik:RadNumericTextBox ID="txtMesesInicioCoordenacaoProjeto2"
                                                                                               runat="server"
                                                                                               Skin="WebBlue"
                                                                                               Width="45px"
                                                                                               NumberFormat-DecimalDigits="0"
                                                                                               MaxLength="2"
                                                                                               MinValue="0"
                                                                                               MaxValue="12"
                                                                                               Value="0"></telerik:RadNumericTextBox>
																
                                                                </td>
														    </tr>
														    <tr>
															    <td height="12" class="style1">&nbsp;</td>
															    <td class="auto-style1" align="center">
                                                                
                                                                    &nbsp;</td>
															    <td class="auto-style9" colspan="2">
															        &nbsp;</td>
															    <td class="auto-style9" colspan="2">
                                                                
                                                                    &nbsp;</td>
															    <td class="auto-style14">
                                                                
                                                                    &nbsp;</td>
															    <td>
																
                                                                    &nbsp;</td>
														    </tr>
														    <tr>
															    <td height="12" class="style1">Já foi obreiro antes ?</td>
															    <td class="auto-style1" align="center">
                                                                
                                                                    <telerik:RadRadioButtonList ID="rbJaFoiObreiroAntes" runat="server" Text="Sim" 
                                                                                                Direction="Horizontal" 
                                                                                                SelectedIndex="0" 
                                                                                                SelectedValue="0" 
                                                                                                Width="128px" 
                                                                                                Skin="WebBlue" 
                                                                                                AutoPostBack="false">
                                                                        <Items>
                                                                            <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                            <telerik:ButtonListItem Text="Não" Value="N" />
                                                                        </Items>
                                                                    </telerik:RadRadioButtonList>
                                                                
                                                                    </td>
															    <td class="auto-style9" colspan="2">
															        &nbsp;</td>
															    <td class="auto-style9" colspan="2">
                                                                
                                                                    Se sim, saiu porque?</td>
															    <td class="auto-style14" colspan="2">
                                                                
                                                                    <telerik:RadTextBox ID="txtMotivoSaidaObreiro" Runat="server" Skin="WebBlue" InputType="Tel" Width="260px" >
                                                                    </telerik:RadTextBox>
																
                                                                </td>
														    </tr>
														    <tr>
															    <td class="auto-style1">Já foi Pastor/Esposa antes ?</td>
															    <td class="auto-style1" align="center">
                                                                
                                                                    <telerik:RadRadioButtonList ID="rbJaFoiPastoEsposaAntes" 
                                                                                                runat="server" 
                                                                                                Text="Sim"
                                                                                                Direction="Horizontal" 
                                                                                                SelectedIndex="0"
                                                                                                SelectedValue="0" 
                                                                                                Width="128px" 
                                                                                                Skin="WebBlue" 
                                                                                                AutoPostBack="false">
                                                                        <Items>
                                                                            <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                            <telerik:ButtonListItem Text="Não" Value="N" />
                                                                        </Items>
                                                                    </telerik:RadRadioButtonList>
                                                                
                                                                    </td>
															    <td class="auto-style1" colspan="2">
															    </td>
															    <td class="auto-style1" colspan="2">
                                                                
                                                                    Se sim, saiu porque?</td>
															    <td class="auto-style1" colspan="2">
                                                                
                                                                    <telerik:RadTextBox ID="txtMotivoSaidaPastorEsposa" Runat="server" Skin="WebBlue" InputType="Tel" Width="260px" >
                                                                    </telerik:RadTextBox>
																
                                                                </td>
														    </tr>
														    <tr>
															    <td class="auto-style1">&nbsp;</td>
															    <td class="auto-style1" align="center">
                                                                
                                                                    &nbsp;</td>
															    <td class="auto-style1" colspan="2">
															        &nbsp;</td>
															    <td class="auto-style1" colspan="2">
                                                                
                                                                    &nbsp;</td>
															    <td class="auto-style1" colspan="2">
                                                                
                                                                    &nbsp;</td>
														    </tr>
														    <tr>
															    <td class="auto-style1">Tem desejo de ser obreiro ?</td>
															    <td class="auto-style1" align="center">
                                                                
                                                                    <telerik:RadRadioButtonList ID="rbDesejaSerObreiro"
                                                                                                runat="server" 
                                                                                                Text="Sim" 
                                                                                                Direction="Horizontal" 
                                                                                                SelectedIndex="0" 
                                                                                                SelectedValue="0" 
                                                                                                Width="128px" 
                                                                                                Skin="WebBlue"
                                                                                                AutoPostBack="false">
                                                                        <Items>
                                                                            <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                            <telerik:ButtonListItem Text="Não" Value="N" />
                                                                        </Items>
                                                                    </telerik:RadRadioButtonList>
                                                                
                                                                    </td>
															    <td class="auto-style1" colspan="2">
															        &nbsp;</td>
															    <td class="auto-style1" colspan="2">
                                                                
                                                                    Porque?</td>
															    <td class="auto-style1" colspan="2">
                                                                
                                                                    <telerik:RadTextBox ID="txtMotivoDesejaSErObreiro" Runat="server" Skin="WebBlue" InputType="Text" Width="260px" >
                                                                    </telerik:RadTextBox>
																
                                                                </td>
														    </tr>
														    <tr>
															    <td class="auto-style1">Tem desejo de fazer a obre no altar(pastor/esposa )?</td>
															    <td class="auto-style1" align="center">
                                                                
                                                                    <telerik:RadRadioButtonList ID="rbDesejaFazerObraAltar" 
                                                                                                runat="server" 
                                                                                                Text="Sim" 
                                                                                                Direction="Horizontal" 
                                                                                                SelectedIndex="0" 
                                                                                                SelectedValue="0" 
                                                                                                Width="128px" 
                                                                                                Skin="WebBlue"
                                                                                                AutoPostBack="false">
                                                                        <Items>
                                                                            <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                            <telerik:ButtonListItem Text="Não" Value="N" />
                                                                        </Items>
                                                                    </telerik:RadRadioButtonList>
                                                                
                                                                    </td>
															    <td class="auto-style1" colspan="2">
															        &nbsp;</td>
															    <td class="auto-style1" colspan="2">
                                                                
                                                                    Esta no Altar Jovem?</td>
															    <td class="auto-style1" colspan="2">
                                                                
                                                                    <telerik:RadRadioButtonList ID="rbEstaNoAltarJovem" 
                                                                                                runat="server" 
                                                                                                Text="Sim" 
                                                                                                Direction="Horizontal" 
                                                                                                SelectedIndex="0" 
                                                                                                SelectedValue="0" 
                                                                                                Width="128px" 
                                                                                                Skin="WebBlue" 
                                                                                                AutoPostBack="false">
                                                                        <Items>
                                                                            <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                            <telerik:ButtonListItem Text="Não" Value="N" />
                                                                        </Items>
                                                                    </telerik:RadRadioButtonList>
                                                                </td>
														    </tr>
														    <tr>
															    <td class="txt1" colspan="2">
                                                                
                                                                    &nbsp;&nbsp;
                                                                
                                                                    </td>
															    <td class="auto-style10">
															        &nbsp;</td>

                                                                <td class="auto-style2" colspan="2">
                                                                
                                                                    &nbsp;</td>

                                                                <td class="auto-style16" colspan="2">
                                                                
                                                                    &nbsp;</td>

                                                                <td class="txt1">
                                                                
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;
																
                                                                </td>
														    </tr>
														    <tr>
															    <td class="txt1">
                                                                    Faz parte do Intellimen?</td>
															    <td class="auto-style3">
                                                                
                                                                    <telerik:RadRadioButtonList ID="rbFazParteIntellimen" 
                                                                                                runat="server" 
                                                                                                Text="Sim" 
                                                                                                Direction="Horizontal" 
                                                                                                SelectedIndex="0" 
                                                                                                SelectedValue="0" 
                                                                                                Width="128px" 
                                                                                                Skin="WebBlue"                 
                                                                                                AutoPostBack="false" >
                                                                        <Items>
                                                                            <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                            <telerik:ButtonListItem Text="Não" Value="N" />
                                                                        </Items>
                                                                    </telerik:RadRadioButtonList>
                                                                
                                                                    </td>
															    <td class="auto-style10">
															        &nbsp;
															        Completou os desafios?</td>
															    <td class="auto-style2" colspan="2">
																    &nbsp;</td>
															    <td class="auto-style16">
                                                                
                                                                    <telerik:RadRadioButtonList ID="rbCompletouDesafios" 
                                                                                                runat="server" 
                                                                                                Text="Sim"
                                                                                                Direction="Horizontal" 
                                                                                                SelectedIndex="0"
                                                                                                SelectedValue="0"
                                                                                                Width="128px"
                                                                                                Skin="WebBlue" 
                                                                                                AutoPostBack="false">
                                                                        <Items>
                                                                            <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                            <telerik:ButtonListItem Text="Não" Value="N" />
                                                                        </Items>
                                                                    </telerik:RadRadioButtonList>
                                                                
                                                                    </td>
															    <td class="auto-style14">
																    Esta em qual?</td>
															    <td class="auto-style2">
																                                                                    
																    <telerik:RadNumericTextBox ID="txtNumeroDesafioIntellimen"
                                                                                               runat="server"
                                                                                               Skin="WebBlue"
                                                                                               Width="45px"
                                                                                               NumberFormat-DecimalDigits="0"
                                                                                               MaxLength="2"
                                                                                               MinValue="0"
                                                                                               MaxValue="53"
                                                                                               Value="0"></telerik:RadNumericTextBox>
                                                                </td>
														    </tr>
														    <tr>
															    <td class="txt1">
                                                                    Qual o nome do seu parceiro no projeto Intellimen</td>
															    <td class="auto-style3" colspan="2">
                                                                
                                                                    <telerik:RadTextBox ID="txtNomeParceiroIntellimen" Runat="server" Skin="WebBlue" Width="260px" >
                                                                    </telerik:RadTextBox>
																
                                                                    </td>
															    <td class="auto-style2" colspan="2">
																    &nbsp;</td>
															    <td class="auto-style16">
																    Telefone:</td>
															    <td class="auto-style14">
																
                                                                    <%--<telerik:RadTextBox ID="txtTelefoneParceiroIntellimen" Runat="server" Skin="WebBlue" InputType="Tel" Width="110px" >
                                                                    </telerik:RadTextBox>--%>
																    <telerik:RadMaskedTextBox RenderMode="Lightweight" 
                                                                                              ID="txtTelefoneParceiroIntellimen2" 
                                                                                              runat="server" 
                                                                                              Mask="(##) #####-####" 
                                                                                              Width="110px"                                                                        
                                                                                              ValidationGroup="Group1">
                                                                    </telerik:RadMaskedTextBox>
                                                                </td>
															    <td class="auto-style2">
																
                                                                    &nbsp;</td>
														    </tr>
														    </table>

                        </div>

                    </telerik:RadWizardStep>                
                    <telerik:RadWizardStep ID="stepProjetos" 
                                           Title="Projetos FJU" 
                                           runat="server" 
                                           StepType="Step" 
                                           CausesValidation="true"
                                           BackColor="#d3e1ee">

                        <div id="divInformacoesProjetosFJU" class="txt1">
                            <table id="tbl4" border="0" cellpadding="0" cellspacing="0" class="auto-style11">
                            <tr>
                                <td background="../images/top_tit.jpg" class="auto-style4" colspan="7">De qual projeto você faz parte?( marque apenas uma opção )</td>
                            </tr>
                            <tr>
                                <td class="style1" colspan="7">
                                    <div align="left">
                                        <telerik:RadRadioButtonList ID="rbListaProjetos" runat="server" AutoPostBack="false" Direction="Horizontal" Skin="WebBlue" />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1" height="30">Está a quanto tempo no projeto</td>
                                <td class="style1" height="30">Anos                                    
                                    <telerik:RadNumericTextBox ID="txtAnosProjeto2"
                                                               Runat="server" 
                                                               Skin="WebBlue"
                                                               MinValue="0"
                                                               NumberFormat-DecimalDigits="0"
                                                               MaxLength="2"
                                                               Width="40px">
                                    </telerik:RadNumericTextBox>
                                    &nbsp;Meses                                    
                                    <telerik:RadNumericTextBox ID="txtMesesProjeto2"
                                                               Runat="server" 
                                                               Skin="WebBlue"
                                                               MinValue="0"
                                                               NumberFormat-DecimalDigits="0"
                                                               MaxLength="2"
                                                               Width="40px">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td class="auto-style9">Já esteve em outro?</td>
                                <td>&nbsp;</td>
                                <td class="auto-style15">
                                    <telerik:RadRadioButtonList ID="rbJaEsteveEmOutroProjeto0" runat="server" AutoPostBack="false" Direction="Horizontal" SelectedIndex="0" SelectedValue="0" Skin="WebBlue" Text="Sim" Width="128px">
                                        <Items>
                                            <telerik:ButtonListItem  Text="Sim" Value="S" />
                                            <telerik:ButtonListItem Text="Não" Value="N" />
                                        </Items>
                                    </telerik:RadRadioButtonList>
                                </td>
                                <td class="auto-style13">Qual?</td>
                                <td>
                                    <telerik:RadDropDownList ID="cboProjetoAnterior0" runat="server" Height="16px" Skin="WebBlue" Width="120px">
                                    </telerik:RadDropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1" height="30">Tem camisa da FJU?</td>
                                <td class="style1" height="30">
                                    <telerik:RadRadioButtonList ID="rbTemCamisaFJU0" runat="server" AutoPostBack="false" Direction="Horizontal" SelectedIndex="0" SelectedValue="0" Skin="WebBlue" Text="Sim" Width="128px">
                                        <Items>
                                            <telerik:ButtonListItem Text="Sim" Value="S" />
                                            <telerik:ButtonListItem Text="Não" Value="N" />
                                        </Items>
                                    </telerik:RadRadioButtonList>
                                </td>
                                <td class="auto-style9">Qual?</td>
                                <td>&nbsp;</td>
                                <td class="auto-style15">
                                    <telerik:RadDropDownList ID="cboCamisasFJU0" runat="server" Height="16px" SelectedText="Coordenador" Skin="WebBlue" Width="180px">
                                        <Items>
                                            <telerik:DropDownListItem runat="server" Text="selecione" />
                                            <telerik:DropDownListItem runat="server" Text="Não possui" />
                                            <telerik:DropDownListItem runat="server" Text="Coordenador" />
                                            <telerik:DropDownListItem runat="server" Text="Jovem Masculina" />
                                            <telerik:DropDownListItem runat="server" Text="Jovem Feminina" />
                                            <telerik:DropDownListItem runat="server" Text="Atalaia" />
                                            <telerik:DropDownListItem runat="server" Text="Help" />
                                            <telerik:DropDownListItem runat="server" Text="Esporte" />
                                            <telerik:DropDownListItem runat="server" Text="Cultura" />
                                            <telerik:DropDownListItem runat="server" Text="Universitários" />
                                            <telerik:DropDownListItem runat="server" Text="Mídia" />
                                            <telerik:DropDownListItem runat="server" Text="Uniforça" />
                                            <telerik:DropDownListItem runat="server" Text="Arcanjos" />
                                        </Items>
                                    </telerik:RadDropDownList>
                                </td>
                                <td class="auto-style13">Tamenho que veste</td>
                                <td>
                                    <telerik:RadDropDownList ID="cboTamanhoCamisaFJU0" runat="server" DropDownWidth="70px" Height="16px" SelectedText="P" SelectedValue="P" Skin="WebBlue" Width="60px">
                                        <Items>
                                            <telerik:DropDownListItem runat="server" Text="P" Value="P" />
                                            <telerik:DropDownListItem runat="server" Text="M" Value="M" />
                                            <telerik:DropDownListItem runat="server" Text="G" Value="G" />
                                            <telerik:DropDownListItem runat="server" Text="GG" Value="GG" />
                                            <telerik:DropDownListItem runat="server" Text="XG" Value="XG" />
                                        </Items>
                                    </telerik:RadDropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1" colspan="5" height="12">&nbsp;&nbsp; </td>
                                <td class="auto-style14">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style1" colspan="7" height="12">
                                    <telerik:RadButton ID="btnAddInformacoesProjeto" 
                                                       runat="server" 
                                                       Skin="WebBlue"
                                                       OnClientClicking="AddInformacoesProjeto"
                                                       Text="Adicionar informações referentes ao projeto selecionado">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                        </table>
                        </div>

                    </telerik:RadWizardStep>
                    <telerik:RadWizardStep ID="stepIdiomas" 
                                           Title="Idiomas" 
                                           runat="server" 
                                           StepType="Step" 
                                           CausesValidation="true"
                                           BackColor="#d3e1ee">

                        <div id="divIdiomas">

                            <table border="0" cellspacing="0" cellpadding="0" id="tbl8" class="auto-style11">
														<tr>
															<td background="../images/top_tit.jpg" class="txt2"  colspan="7">IDIOMAS</td>
														</tr>
														<tr>
															<td class="txt1" colspan="7">&nbsp;&nbsp;
																															
                                                                <div align="left">
                                                                    Você fala algum idioma estrangeiro e qual fluência? Marque&nbsp; &#39;1&#39; para REGULAR, &#39;2&#39; para BOM e &#39;3&#39; para EXCELENTE</div>
															</td>
                                                            
														</tr>
														<tr>
															<td class="style1">&nbsp;</td>
                                                            
															<td class="style1">&nbsp;</td>
                                                            
															<td class="auto-style9">
																&nbsp;</td>
															<td>
																
                                                                &nbsp;</td>
															<td class="auto-style15">
																
                                                                &nbsp;</td>
															<td class="auto-style13">
																
																&nbsp;</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>
														<tr class="txt1">
															<td colspan="7">&nbsp;</td>
                                                            
														</tr>
														<tr class="txt1">
															<td class="style1">INGLÊS</td>
                                                            
															<td class="style1">
                                                                
                                                                <telerik:RadRadioButtonList ID="rbNivelIngles" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
                                                            
															<td class="auto-style9">
																&nbsp;</td>
															<td>
																
                                                                &nbsp;</td>
															<td class="auto-style15">
																
                                                                ITALIANO</td>
															<td class="auto-style13">
																
                                                                <telerik:RadRadioButtonList ID="rbNivelItaliano" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>
														<tr class="txt1">
															<td class="style1">ESPANHOL</td>
                                                            
															<td class="style1">
                                                                
                                                                <telerik:RadRadioButtonList ID="rbNivelEspanhol" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
                                                            
															<td class="auto-style9">
																&nbsp;</td>
															<td>
																
                                                                &nbsp;</td>
															<td class="auto-style15">
																
                                                                JAPONÊS</td>
															<td class="auto-style13">
																
                                                                <telerik:RadRadioButtonList ID="rbNivelJapones" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>
														<tr class="txt1">
															<td class="style1">FRANCÊS</td>
                                                            
															<td class="style1">
                                                                
                                                                <telerik:RadRadioButtonList ID="rbNivelFrances" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
                                                            
															<td class="auto-style9">
															    <div align="right">

                                                                    Outro</div>
															</td>
															<td>
																
                                                                &nbsp;</td>
															<td class="auto-style15">
																
                                                                <telerik:RadTextBox ID="txtIdiomaExtra" Runat="server" Skin="WebBlue" Width="100px" >
                                                                </telerik:RadTextBox>
																
															</td>
															<td class="auto-style13">
																
                                                                <telerik:RadRadioButtonList ID="rbNivelOutroIdioma" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>
														</table>

                        </div>

                    </telerik:RadWizardStep>
                    <telerik:RadWizardStep ID="stepOutros" 
                                           Title="Outros" 
                                           runat="server" 
                                           StepType="Step" 
                                           CausesValidation="true"
                                           BackColor="#d3e1ee">

                        <div id="divInformacoesAdicionais" class="txt1">

                            <table border="0" cellspacing="0" cellpadding="0" id="tbl6" class="auto-style11">
														    <tr>
															    <td background="../images/top_tit.jpg" class="txt2"  colspan="6">INFORMAÇÕES ADICIONAIS</td>
														    </tr>
														    <tr>
															    <td class="style1" colspan="6">&nbsp;&nbsp;
																															
                                                                
															        <div align="left">
                                                                        Quais reuniões da FJU você frequenta?                                                                        
																        <telerik:RadCheckBoxList ID="chkReunioesFJU2" 
                                                                                                 runat="server"
                                                                                                 Direction="Horizontal"
                                                                                                 Skin="WebBlue"
                                                                                                 AutoPostBack="false"></telerik:RadCheckBoxList>
															        </div>
															    </td>
                                                            
														    </tr>
														    <tr>
															    <td class="style1">Você faz parte de algum grupo de mulheres na universal?</td>
                                                            
															    <td class="style1">
                                                                
                                                                    <telerik:RadRadioButtonList ID="rbPertenceGrupoMulheres" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="0" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                        <Items>
                                                                            <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                            <telerik:ButtonListItem Text="Não" Value="N" />
                                                                        </Items>
                                                                    </telerik:RadRadioButtonList>
                                                                
															    </td>
                                                            
															    <td class="auto-style9" colspan="3">
																    Qual?&nbsp;&nbsp;
																
                                                                    <telerik:RadTextBox ID="txtNomeGrupoMulheresUniversal" Runat="server" Skin="WebBlue" Width="180px" >
                                                                    </telerik:RadTextBox>
																
															    </td>
															    <td>
																
                                                                    &nbsp;</td>
														    </tr>
														    <tr>
															    <td class="style1" colspan="3">
                                                                    <div align="left">
                                                                        Você é seguidor do perfil OFICIALFJU no Instagram?                                                                
                                                                        <telerik:RadRadioButtonList ID="rbEhSeguidorOFICIALFJU" 
                                                                            runat="server" 
                                                                            Text="Sim" 
                                                                            Direction="Horizontal" 
                                                                            SelectedIndex="0" 
                                                                            SelectedValue="0" 
                                                                            Width="80px"
                                                                            Skin="WebBlue" AutoPostBack="False" >
                                                                            <Items>
                                                                                <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                                <telerik:ButtonListItem Text="Não" Value="N" />
                                                                            </Items>
                                                                        </telerik:RadRadioButtonList>
                                                                    </div>                                                                
                                                                
															    </td>
                                                            
															    <td class="style1" colspan="3">
                                                                    &nbsp;
                                                                    <div align="left">
                                                                        E no YouTube?
                                                                        <telerik:RadRadioButtonList ID="rbEhSeguidorFJUYouTube" 
                                                                            runat="server" 
                                                                            Text="Sim" 
                                                                            Direction="Horizontal" 
                                                                            SelectedIndex="0" 
                                                                            SelectedValue="0" 
                                                                            Skin="WebBlue"
                                                                            AutoPostBack="false">
                                                                            <Items>
                                                                                <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                                <telerik:ButtonListItem Text="Não" Value="N" />
                                                                            </Items>
                                                                        </telerik:RadRadioButtonList>
                                                                    </div>
															    </td>
                                                            
														    </tr>
														    <tr>
															    <td class="style1" colspan="6"                                                                
                                                                    <div align="left">
                                                                        Você é seguidor do Canal da FJU no aplicativo INSTAGRAM chamado FJU Brasil?		
                                                                        <telerik:RadRadioButtonList ID="rbSegueFJUTelegram" 
                                                                            runat="server" 
                                                                            Text="Sim" 
                                                                            Direction="Horizontal" 
                                                                            SelectedIndex="0" 
                                                                            SelectedValue="0" 
                                                                            Skin="WebBlue" AutoPostBack="False" >
                                                                            <Items>
                                                                                <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                                <telerik:ButtonListItem Text="Não" Value="N" />
                                                                            </Items>
                                                                        </telerik:RadRadioButtonList>
															        </div>
															    </td>
                                                            
														    </tr>
														    <tr>
															    <td class="style1" colspan="2">
                                                                    Você é assinante do UNIVERVIDEO 
                                                                    <telerik:RadRadioButtonList ID="RBaSSINANTEunivervideo" 
                                                                            runat="server" 
                                                                            Text="Sim" 
                                                                            Direction="Horizontal" 
                                                                            SelectedIndex="0" 
                                                                            SelectedValue="0" 
                                                                            Skin="WebBlue"
                                                                            AutoPostBack="false">
                                                                            <Items>
                                                                                <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                                <telerik:ButtonListItem Text="Não" Value="N" />
                                                                            </Items>
                                                                        </telerik:RadRadioButtonList>
															    </td>
                                                            
															    <td class="auto-style9">
                                                                
                                                                    Assiste com qual frequência?</td>
															    <td colspan="3">
																
                                                                    <telerik:RadTextBox ID="txtFrequenciaAssisteUniver" Runat="server" Skin="WebBlue" Width="100px" >
                                                                    </telerik:RadTextBox>
																
                                                                </td>
														    </tr>
														    <tr>
															    <td class="style1" colspan="2">
                                                                
                                                                    <div alig="left">
                                                                        Você tem bíblia ?
                                                                        <telerik:RadRadioButtonList ID="rbTemBiblia" 
                                                                            runat="server" 
                                                                            Text="Sim" 
                                                                            Direction="Horizontal" 
                                                                            SelectedIndex="0" 
                                                                            SelectedValue="0" 
                                                                            Skin="WebBlue" AutoPostBack="False" >
                                                                            <Items>
                                                                                <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                                <telerik:ButtonListItem Text="Não" Value="N" />
                                                                            </Items>
                                                                        </telerik:RadRadioButtonList>
                                                                    </div>
															    </td>
                                                            
															    <td class="auto-style9">
                                                                
                                                                
                                                                    <div alig="left">
                                                                        E no celular?
                                                                        <telerik:RadRadioButtonList ID="rbTemBibliaNoCelular" 
                                                                            runat="server" 
                                                                            Text="Sim" 
                                                                            Direction="Horizontal" 
                                                                            SelectedIndex="0" 
                                                                            SelectedValue="0" 
                                                                            Skin="WebBlue" AutoPostBack="False" >
                                                                            <Items>
                                                                                <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                                <telerik:ButtonListItem Text="Não" Value="N" />
                                                                            </Items>
                                                                        </telerik:RadRadioButtonList>
                                                                    </div>

															    </td>
															    <td>
																
                                                                    &nbsp;</td>
															    <td class="auto-style15">
																
                                                                    <div alig="left">
                                                                        Já leu a bíblia toda #jlbt
                                                                        <telerik:RadRadioButtonList ID="rbJaLeuBibliaToda" 
                                                                            runat="server" 
                                                                            Text="Sim" 
                                                                            Direction="Horizontal" 
                                                                            SelectedIndex="0" 
                                                                            SelectedValue="0" 
                                                                            Skin="WebBlue" AutoPostBack="False" >
                                                                            <Items>
                                                                                <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                                <telerik:ButtonListItem Text="Não" Value="N" />
                                                                            </Items>
                                                                        </telerik:RadRadioButtonList>
                                                                    </div>

															    </td>
															    <td>
																
                                                                    &nbsp;</td>
														    </tr>
														    <tr>
															    <td class="style1" colspan="6">
                                                                    <div align="left">
                                                                        Com que frequência você lê a bíblia 
                                                                        <telerik:RadRadioButtonList ID="rbFrequenciaLeituraBiblia" 
                                                                            runat="server" 
                                                                            Text="Sim" 
                                                                            Direction="Horizontal" 
                                                                            SelectedIndex="0" 
                                                                            SelectedValue="0" 
                                                                            Skin="WebBlue" AutoPostBack="False" >
                                                                        </telerik:RadRadioButtonList>
                                                                    </div>                                                                

															    </td>
                                                            
														    </tr>
														    <tr>
															    <td class="style1" colspan="3">&nbsp;
                                                                    <div align="left">
                                                                        Você Lê diariamente o blog do Bispo Macedo?
                                                                        <telerik:RadRadioButtonList ID="rbLeDiariamenteBlogBM" 
                                                                            runat="server" 
                                                                            Text="Sim" 
                                                                            Direction="Horizontal" 
                                                                            Skin="WebBlue"
                                                                            AutoPostBack="false">
                                                                            <Items>
                                                                                <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                                <telerik:ButtonListItem Text="Não" Value="N" />
                                                                            </Items>
                                                                        </telerik:RadRadioButtonList>
                                                                    </div>
															    </td>                                                            
															    <td>
																
                                                                    &nbsp;</td>
															    <td class="auto-style15" colspan="2">
																
                                                                    <div align="left">
                                                                        E a página Universal.org
                                                                        <telerik:RadRadioButtonList ID="rbLeitorSiteUniversalOrg" 
                                                                            runat="server" 
                                                                            Text="Sim" 
                                                                            Direction="Horizontal" 
                                                                            SelectedIndex="0" 
                                                                            SelectedValue="0" 
                                                                            Skin="WebBlue" AutoPostBack="False" >
                                                                            <Items>
                                                                                <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                                <telerik:ButtonListItem Text="Não" Value="N" />
                                                                            </Items>
                                                                        </telerik:RadRadioButtonList>
                                                                    </div>

															    </td>
														    </tr>
														    <tr>
															    <td class="style1" colspan="2">
                                                                    <div align="left">
                                                                        Você tem celular com acesso à internet?
                                                                        <telerik:RadRadioButtonList ID="rbTemCelularComInternet" 
                                                                            runat="server" 
                                                                            Text="Sim" 
                                                                            Direction="Horizontal" 
                                                                            SelectedIndex="0" 
                                                                            SelectedValue="0" 
                                                                            Skin="WebBlue" AutoPostBack="False" >
                                                                            <Items>
                                                                                <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                                <telerik:ButtonListItem Text="Não" Value="N" />
                                                                            </Items>
                                                                        </telerik:RadRadioButtonList>
                                                                    </div>
															    </td>   
															    <td colspan="3">
																    <div align="left">
                                                                        Você tem computador em casa?
                                                                        <telerik:RadRadioButtonList ID="rbTemComputadorEmCasa" 
                                                                            runat="server" 
                                                                            Text="Sim" 
                                                                            Direction="Horizontal" 
                                                                            SelectedIndex="0" 
                                                                            SelectedValue="0" 
                                                                            Skin="WebBlue" AutoPostBack="False" >
                                                                            <Items>
                                                                                <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                                <telerik:ButtonListItem Text="Não" Value="N" />
                                                                            </Items>
                                                                        </telerik:RadRadioButtonList>
																    </div>
                                                                

															    </td>
														    </tr>
														    <tr>
															    <td class="style1" colspan="2">                                                                
                                                                    <div align="left">
                                                                        Você já leu algum dos livros abaixo?
                                                                    </div>
															    </td>
                                                            
															    <td class="auto-style9">
                                                                
                                                                    &nbsp;</td>
															    <td>
																
                                                                    &nbsp;</td>
															    <td class="auto-style15">
																
                                                                
															        &nbsp;</td>
															    <td>
																
                                                                    &nbsp;</td>
														    </tr>
														    <tr>
															    <td class="style1" colspan="6">
                                                                    <div align="left">
                                                                        <telerik:RadCheckBoxList ID="chkLivros2" 
                                                                                                 Skin="WebBlue" 
                                                                                                 Direction="Horizontal"
                                                                                                 AutoPostBack="false"
                                                                                                 runat="server">
                                                                        </telerik:RadCheckBoxList>
                                                                    </div>
															    </td>
                                                            
														    </tr>
														    </table>

                        </div>

                    </telerik:RadWizardStep>
                    <telerik:RadWizardStep ID="stepTestemunho" 
                                           Title="Testemunho" 
                                           runat="server" 
                                           StepType="Step" 
                                           CausesValidation="true"
                                           BackColor="#d3e1ee">

                        <div id="divTestemunho" class="txt1">

                            <table border="0" cellspacing="0" cellpadding="0" id="tbl9" class="auto-style11">
														<tr>
															<td background="../images/top_tit.jpg" class="auto-style4"  colspan="6">INFORMAÇÕES ADICIONAIS</td>
														</tr>
														<tr>
															<td class="style1">&nbsp;&nbsp;
																															
                                                                
															    <div align="left">
                                                                    Já sofreu com depressão?
                                                                </div>                                                                
                                                                
															</td>
                                                            
															<td class="style1">
                                                                <div align="left">
                                                                    &nbsp;<telerik:RadRadioButtonList ID="rbJaSofreuDepressao" 
                                                                        runat="server" 
                                                                        Text="Sim" 
                                                                        Direction="Horizontal" 
                                                                        SelectedIndex="0" 
                                                                        SelectedValue="0" 
                                                                        Skin="WebBlue" AutoPostBack="False" >
                                                                        <Items>
                                                                            <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                            <telerik:ButtonListItem Text="Não" Value="N" />
                                                                        </Items>
                                                                    </telerik:RadRadioButtonList>
                                                                </div>
															</td>
                                                            
															<td class="style1">
                                                                <div align="left">
                                                                    Por quanto tempo?
                                                                </div>                                                                
                                                                
															</td>
                                                            
															<td class="style1">
																
                                                                <telerik:RadTextBox ID="txtTempoSofreuDepressao" Runat="server" Skin="WebBlue" Width="100px" >
                                                                </telerik:RadTextBox>
																
															</td>
                                                            
															<td class="style1">
                                                                <div align="left">
                                                                    Está livre desde?
                                                                </div>                                                                
                                                                
															</td>
                                                            
															<td class="style1">
																
                                                                <telerik:RadTextBox ID="txtTempoLivreDepressao" Runat="server" Skin="WebBlue" Width="100px" >
                                                                </telerik:RadTextBox>
																
															</td>
                                                            
														</tr>
														<tr>
															<td class="style1">
                                                                <div align="left">
                                                                    E com Automutilação?
                                                                </div>                                                                
                                                                
															</td>
                                                            
															<td class="style1">
                                                                <div align="left">
                                                                    &nbsp;<telerik:RadRadioButtonList ID="rbJaSofreuAutomutilacao" 
                                                                        runat="server" 
                                                                        Text="Sim" 
                                                                        Direction="Horizontal" 
                                                                        SelectedIndex="0" 
                                                                        SelectedValue="0" 
                                                                        Skin="WebBlue" AutoPostBack="False" >
                                                                        <Items>
                                                                            <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                            <telerik:ButtonListItem Text="Não" Value="N" />
                                                                        </Items>
                                                                    </telerik:RadRadioButtonList>
                                                                </div>
															</td>
                                                            
															<td class="style1">
                                                                <div align="left">
                                                                    Por quanto tempo?
                                                                </div>                                                                
                                                                
															</td>
                                                            
															<td class="style1">
																
                                                                <telerik:RadTextBox ID="txtTempoSofreuAutomutilacao" Runat="server" Skin="WebBlue" Width="100px" >
                                                                </telerik:RadTextBox>
																
															</td>
                                                            
															<td class="style1">
                                                                <div align="left">
                                                                    Está livre desde?
                                                                </div>                                                                
                                                                
															</td>
                                                            
															<td class="style1">
																
                                                                <telerik:RadTextBox ID="txtTempoLivreAutomutilacao" Runat="server" Skin="WebBlue" Width="100px" >
                                                                </telerik:RadTextBox>
																
															</td>
                                                            
														</tr>
														<tr>
															<td class="style1">
                                                                <div align="left">
                                                                    Já teve algum vício?
                                                                </div>                                                                
                                                                
															</td>
                                                            
															<td class="style1">
                                                                <div align="left">
                                                                    &nbsp;<telerik:RadRadioButtonList ID="rbJaTeveVicio" 
                                                                        runat="server" 
                                                                        Text="Sim" 
                                                                        Direction="Horizontal" 
                                                                        SelectedIndex="0" 
                                                                        SelectedValue="0" 
                                                                        Skin="WebBlue" AutoPostBack="False" >
                                                                        <Items>
                                                                            <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                            <telerik:ButtonListItem Text="Não" Value="N" />
                                                                        </Items>
                                                                    </telerik:RadRadioButtonList>
                                                                </div>
															</td>
                                                            
															<td class="style1">
                                                                <div align="left">
                                                                    Qual?
                                                                </div>                                                                
                                                                
															</td>
                                                            
															<td class="style1" colspan="2">
																
                                                                <telerik:RadTextBox ID="txtNomeVicio" Runat="server" Skin="WebBlue" Width="200px" >
                                                                </telerik:RadTextBox>
																
															</td>
                                                            
															<td class="style1">&nbsp;</td>
                                                            
														</tr>
														<tr>
															<td class="auto-style10">Por quanto tempo permaneceu viciado??</td>
                                                            
															<td class="auto-style10">
																
                                                                <telerik:RadTextBox ID="txtTempoVicio" Runat="server" Skin="WebBlue" Width="100px" >
                                                                </telerik:RadTextBox>
																
															</td>
                                                            
															<td class="auto-style10" colspan="2">
                                                                <div align="left">
                                                                    Está livre dos vícios ha quanto tempo
                                                                </div>                                                                
                                                                
															</td>
                                                            
															<td class="auto-style10">
																
                                                                <telerik:RadTextBox ID="txtTempoLivreVicios" Runat="server" Skin="WebBlue" Width="100px" >
                                                                </telerik:RadTextBox>
																
															</td>
                                                            
															<td class="auto-style10">
															</td>
                                                            
														</tr>
														<tr>
															<td class="style1">
                                                                <div align="left">
                                                                    Já tentou suicídio algume vez?
                                                                </div>                                                                
                                                                
															</td>
                                                            
															<td class="style1">
                                                                <div align="left">
                                                                    &nbsp;<telerik:RadRadioButtonList ID="rbJaTentouSuicidio" 
                                                                        runat="server" 
                                                                        Text="Sim" 
                                                                        Direction="Horizontal" 
                                                                        SelectedIndex="0" 
                                                                        SelectedValue="0" 
                                                                        Skin="WebBlue" AutoPostBack="False" >
                                                                        <Items>
                                                                            <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                            <telerik:ButtonListItem Text="Não" Value="N" />
                                                                        </Items>
                                                                    </telerik:RadRadioButtonList>
                                                                </div>
															</td>
                                                            
															<td class="style1">
                                                                <div align="left">
                                                                    Quantas vezes?
                                                                </div>                                                                
                                                                
															</td>
                                                            
															<td class="style1">
																
                                                                <telerik:RadTextBox ID="txtNumeroTentativasSuicidio" Runat="server" Skin="WebBlue" InputType="Number" Width="80px" >
                                                                </telerik:RadTextBox>
																
															</td>
                                                            
															<td class="style1">
                                                                <div align="left">
                                                                    Quando?
                                                                </div>                                                                
                                                                
															</td>
                                                            
															<td class="style1">
																
                                                                <telerik:RadTextBox ID="txtQuandoTentouSuicidio" Runat="server" Skin="WebBlue" Width="170px" >
                                                                </telerik:RadTextBox>
																
															</td>
                                                            
														</tr>
														<tr>
															<td class="style1">
                                                                <div align="left">
                                                                    Como foi a tentativa de suicídio?
                                                                </div>                                                                
                                                                
															</td>
                                                            
															<td class="style1" colspan="2">
																
                                                                <telerik:RadTextBox ID="txtDescricaoTentativaSuicidio" Runat="server" Skin="WebBlue" Width="250px" >
                                                                </telerik:RadTextBox>
																
															</td>
                                                            
															<td class="style1">&nbsp;</td>
                                                            
															<td class="style1">&nbsp;</td>
                                                            
															<td class="style1">&nbsp;</td>
                                                            
														</tr>
														<tr>
															<td class="style1">&nbsp;</td>
                                                            
															<td class="style1" colspan="2">&nbsp;</td>
                                                            
															<td class="style1">&nbsp;</td>
                                                            
															<td class="style1">&nbsp;</td>
                                                            
															<td class="style1">&nbsp;</td>
                                                            
														</tr>
														<tr>
															<td class="style1" colspan="6">
                                                                
                                                                <div align="left">
                                                                    <telerik:RadEditor ID="textoTestemunho"
                                                                                        runat="server"
                                                                                        Height="170px"
                                                                                        Width="680px" 
                                                                        Skin="WebBlue"
                                                                                        EditModes="Design" Language="pt-BR" >
																		<Tools>
																			<telerik:EditorToolGroup Tag="MainToolbar">
																						<telerik:EditorTool Name="FindAndReplace" />
																						<telerik:EditorSeparator />
																						<telerik:EditorSplitButton Name="Undo">
																						</telerik:EditorSplitButton>
																						<telerik:EditorSplitButton Name="Redo">
																						</telerik:EditorSplitButton>
																						<telerik:EditorSeparator />
																						<telerik:EditorTool Name="Cut" />
																						<telerik:EditorTool Name="Copy" />
																						<telerik:EditorTool Name="Paste" ShortCut="CTRL+V / CMD+V" />
																			</telerik:EditorToolGroup>
																			<telerik:EditorToolGroup Tag="Formatting">
																						<telerik:EditorTool Name="Bold" />
																						<telerik:EditorTool Name="Italic" />
																						<telerik:EditorTool Name="Underline" />
																						<telerik:EditorSeparator />
																						<telerik:EditorSplitButton Name="ForeColor">
																						</telerik:EditorSplitButton>
																						<telerik:EditorSplitButton Name="BackColor">
																						</telerik:EditorSplitButton>
																						<telerik:EditorSeparator />
																						<telerik:EditorDropDown Name="FontName">
																						</telerik:EditorDropDown>
																						<telerik:EditorDropDown Name="RealFontSize">
																						</telerik:EditorDropDown>
																					</telerik:EditorToolGroup>
																		</Tools>
																		<Content>
																		</Content>
																		<TrackChangesSettings CanAcceptTrackChanges="False"></TrackChangesSettings>
																	</telerik:RadEditor>
                                                                </div>

															</td>
                                                            
														</tr>
														</table>

                        </div>

                    </telerik:RadWizardStep>
                    <telerik:RadWizardStep ID="stepSugestao" 
                                           Title="Sugestão" 
                                           runat="server" 
                                           StepType="Finish" 
                                           CausesValidation="true"
                                           BackColor="#d3e1ee">

                        <div id="divSugestao">

                            <table border="0" cellspacing="0" cellpadding="0" id="tbl7" class="auto-style11">
														    <tr>
															    <td background="../images/top_tit.jpg" class="auto-style4">&nbsp;</td>
														    </tr>
														    <tr class="txt1">
															    <td height="12" class="style1">
                                                                
                                                                    A sua opinião é muito importante. O que você gostária de ver mais na força Jovem Universal?<br />
                                                                    Tem alguma idéia legal para agente poder implementar?</td>
														    </tr>
														    <tr>
															    <td height="12" class="style1">
                                                                
                                                                    <div align="left">
                                                                        <telerik:RadEditor ID="textoSugestao"
                                                                                            runat="server"
                                                                                            Height="220px"
                                                                                            Width="680px" 
                                                                                            EditModes="Design" 
                                                                                            Language="pt-BR"
                                                                                            Skin="WebBlue">
																		    <Tools>
																			    <telerik:EditorToolGroup Tag="MainToolbar">
																						    <telerik:EditorTool Name="FindAndReplace" />
																						    <telerik:EditorSeparator />
																						    <telerik:EditorSplitButton Name="Undo">
																						    </telerik:EditorSplitButton>
																						    <telerik:EditorSplitButton Name="Redo">
																						    </telerik:EditorSplitButton>
																						    <telerik:EditorSeparator />
																						    <telerik:EditorTool Name="Cut" />
																						    <telerik:EditorTool Name="Copy" />
																						    <telerik:EditorTool Name="Paste" ShortCut="CTRL+V / CMD+V" />
																			    </telerik:EditorToolGroup>
																			    <telerik:EditorToolGroup Tag="Formatting">
																						    <telerik:EditorTool Name="Bold" />
																						    <telerik:EditorTool Name="Italic" />
																						    <telerik:EditorTool Name="Underline" />
																						    <telerik:EditorSeparator />
																						    <telerik:EditorSplitButton Name="ForeColor">
																						    </telerik:EditorSplitButton>
																						    <telerik:EditorSplitButton Name="BackColor">
																						    </telerik:EditorSplitButton>
																						    <telerik:EditorSeparator />
																						    <telerik:EditorDropDown Name="FontName">
																						    </telerik:EditorDropDown>
																						    <telerik:EditorDropDown Name="RealFontSize">
																						    </telerik:EditorDropDown>
																					    </telerik:EditorToolGroup>
																		    </Tools>
																		    <Content>
																		    </Content>
																		    <TrackChangesSettings CanAcceptTrackChanges="False"></TrackChangesSettings>
																	    </telerik:RadEditor>
                                                                    </div>

															    </td>
														    </tr>
														    </table>

                        </div>

                    </telerik:RadWizardStep>
                    <telerik:RadWizardStep ID="stepMsgConfirmacao" 
                                           Title="Sugestão" 
                                           runat="server" 
                                           StepType="complete" 
                                           CausesValidation="true"
                                           BackColor="#d3e1ee">
                        <div align="center">
                            <table border="0" cellspacing="0" cellpadding="0" id="tbl10" >
														<tr>
															<td background="../images/top_tit.jpg" class="txtConfirmacao">
                                                                JOVEM CADASTRADO COM SUCESSO !!!!&nbsp;
															</td>
														</tr>
														<tr>
															<td class="txt4">&nbsp;&nbsp;
																															
                                                                <div align="left">
                                                                    Para realizar um novo cadastro, basta clicar no botão na barra de ferramentas: &quot;Novo Jovem&quot;</div>
															</td>
                                                            
														</tr>
														<tr>
															<td class="style1">
																
                                                                <img width="80px" height="80px" src="../Images/confirmacao.png" /></td>
                                                            
														</tr>
														</table>
                        </div>
                    </telerik:RadWizardStep>
                
                </WizardSteps>
            </telerik:RadWizard>
            
        </div>        

    </div>
    
</asp:Content>
