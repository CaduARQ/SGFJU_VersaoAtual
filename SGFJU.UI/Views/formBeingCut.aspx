<%@ Page Title="" Language="C#" MasterPageFile="~/UI_App.Master" AutoEventWireup="true" CodeBehind="formBeingCut.aspx.cs" Inherits="SGFJU.UI.Views.formBeingCut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/LabForm.css" rel="stylesheet" /> 
    <link href="../Styles/UI_App.css" rel="stylesheet" /> 
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>    
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>

    <script language="javascript" type="text/javascript">
            $(function () {
                $('.button-checkbox').each(function () {

                    // Settings
                    var $widget = $(this),
                        $button = $widget.find('button'),
                        $checkbox = $widget.find('input:checkbox'),
                        color = $button.data('color'),
                        settings = {
                            on: {
                                icon: 'glyphicon glyphicon-check'
                            },
                            off: {
                                icon: 'glyphicon glyphicon-unchecked'
                            }
                        };

                    // Event Handlers
                    $button.on('click', function () {
                        $checkbox.prop('checked', !$checkbox.is(':checked'));
                        $checkbox.triggerHandler('change');
                        updateDisplay();
                    });
                    $checkbox.on('change', function () {
                        updateDisplay();
                    });

                    // Actions
                    function updateDisplay() {
                        var isChecked = $checkbox.is(':checked');

                        // Set the button's state
                        $button.data('state', (isChecked) ? "on" : "off");

                        // Set the button's icon
                        $button.find('.state-icon')
                            .removeClass()
                            .addClass('state-icon ' + settings[$button.data('state')].icon);

                        // Update the button's color
                        if (isChecked) {
                            $button
                                .removeClass('btn-default')
                                .addClass('btn-' + color + ' active');
                        }
                        else {
                            $button
                                .removeClass('btn-' + color + ' active')
                                .addClass('btn-default');
                        }
                    }

                    // Initialization
                    function init() {

                        updateDisplay();

                        // Inject the icon if applicable
                        if ($button.find('.state-icon').length === 0) {
                            $button.prepend('<i class="state-icon ' + settings[$button.data('state')].icon + '"></i> ');
                        }
                    }
                    init();
                });
            });





            var new_checkbox_button = function (name, id) {
                return "<li><span class='button-checkbox'><button type='button' class='btn btn-sm btn-primary active' data-color='primary'><i class='state-icon glyphicon glyphicon-check'></i>&nbsp;" + name + "</button><input type='checkbox' class='hidden' checked=''></span></li>";
            };

            $("#add").click(function () {
                $("#selected_targets").append(new_checkbox_button("lallalala", "1111"));
            });


        </script>

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
    

    <telerik:RadNavigation runat="server" ID="contactNavigation" Skin="Vista" CssClass="secondaryMenu">
        <Nodes>                        
            <telerik:NavigationNode Text="Novo Jovem" SpriteCssClass="icon icon-Send" NavigateUrl="RegistraJovem.aspx" ></telerik:NavigationNode>
            <telerik:NavigationNode CssClass="rightScndNav">                
                <NodeTemplate>                                        
                </NodeTemplate>
            </telerik:NavigationNode>
        </Nodes>
    </telerik:RadNavigation>    

    <div class="demo-container">

        <div class="wizardHeader">

            <telerik:RadWizard RenderMode="Lightweight" 
                               ID="RadWizard1" 
                               runat="server"  
                               Height="670px" 
                               Width="1100px"
                              Skin="WebBlue"
                               Culture="pt-BR" >

                <WizardSteps>

                    <telerik:RadWizardStep ID="stepStart" 
                                           Title="Pessoal" 
                                           runat="server" 
                                           StepType="Start" 
                                           CausesValidation="true" 
                                           ValidationGroup="StepInicialValidation">

                        <div class="container-fluid bg-light py-3">

                            <form id="contact-form" role="form">

                                <legend>Informações Pessoais </legend>

                                <div class="controls">

                                    <div class="row">

                                        <div class="col-sm-4">
                                        <div class="form-group">
                                                <label for="form_name">Nome *</label>
                                                <input id="form_name" type="text" name="surname" class="form-control" placeholder="Porfavor informe seu nome *" required="required" data-error="name is required.">
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_email">Data de Nascimento *</label>
                                                <input id="form_email" type="email" name="email" class="form-control" placeholder="Por favor informe sua data de nascimento *" required="required" data-error="Valid email is required.">
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_name">Estado *</label><br />
                                                <telerik:RadComboBox ID="cboEstado" 
                                                                     runat="server" 
                                                                     AutoPostBack="true" 
                                                                     Height="100px" 
                                                                     OnSelectedIndexChanged="cboEstado_SelectedIndexChanged"
                                                                     Skin="Bootstrap" 
                                                                     Width="280px" />                                                
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>

                                    </div>

                                    <!-- Primeiro separador -->
                                    <div class="clearfix"></div>

                                    <div class="row">                                        

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_email">Bloco *</label><br />
                                                <telerik:RadComboBox ID="cboBloco" 
                                                                     runat="server" 
                                                                     AutoPostBack="true" 
                                                                     Height="100px" 
                                                                     Skin="Bootstrap" 
                                                                     OnSelectedIndexChanged="cboBloco_SelectedIndexChanged"
                                                                     Width="280px"></telerik:RadComboBox>
                                                <%--<input id="form_email" type="email" name="email" class="form-control" placeholder="Por favor informe sua data de nascimento *" required="required" data-error="Valid email is required.">--%>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_phone">Região</label><br />
                                                <telerik:RadComboBox ID="cboRegiao"
                                                                     runat="server" 
                                                                     AutoPostBack="True" 
                                                                     Height="110px" 
                                                                     OnSelectedIndexChanged="cboRegiao_SelectedIndexChanged"
                                                                     Skin="Bootstrap" 
                                                                     Width="280px"></telerik:RadComboBox>
                                                <%--<input id="form_phone" type="tel" name="phone" class="form-control" placeholder="Please enter your phone number">--%>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_name">Igreja *</label><br />
                                                <%--<input id="form_name" type="text" name="surname" class="form-control" placeholder="Porfavor informe seu nome *" required="required" data-error="name is required.">--%>
                                                <telerik:RadDropDownList ID="cboIgreja" 
                                                                     runat="server" 
                                                                     Width="280px" 
                                                                     Skin="Bootstrap"></telerik:RadDropDownList>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>

                                    </div>

                                    <!-- Separador entre a segunda e terceira linha de controles do formulário -->
                                    <div class="clearfix"></div>

                                    <div class="row">                                        

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_email">Arquivo da Foto do Jovem *</label>
                                                <input id="form_email" type="email" name="email" class="form-control" placeholder="Por favor informe sua data de nascimento *" required="required" data-error="Valid email is required.">
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_name">Whatsapp *</label>
                                                <br />
                                                <telerik:RadMaskedTextBox RenderMode="Lightweight" 
                                                                          ID="txtNumeroWhats2" 
                                                                          runat="server" 
                                                                          Mask="(##) #####-####" 
                                                                          Width="150px"                                                                        
                                                                          Skin="Bootstrap"
                                                                          ValidationGroup="Group1">
                                                </telerik:RadMaskedTextBox>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_email">Telefone fixo </label>
                                                <br />
                                                <telerik:RadMaskedTextBox RenderMode="Lightweight" 
                                                                          ID="txtTelefoneFixo2" 
                                                                          runat="server" 
                                                                          Mask="(##) #####-####" 
                                                                          Width="150px"                                                                        
                                                                          Skin="Bootstrap"
                                                                          ValidationGroup="Group1">
                                                </telerik:RadMaskedTextBox>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>


                                    </div>

                                    <div class="clearfix"></div>

                                    <div class="row">

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_phone">Telefone de emergência</label>
                                                <br>
                                                <telerik:RadMaskedTextBox RenderMode="Lightweight" 
                                                                          ID="txtTelefoneEmergencia2" 
                                                                          runat="server" 
                                                                          Mask="(##) #####-####" 
                                                                          Width="150px"                                                                        
                                                                          Skin="Bootstrap"
                                                                          ValidationGroup="Group1">
                                                </telerik:RadMaskedTextBox>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_name">Contato telefone emergência</label>
                                                <input id="form_contatoemergencia" type="text" name="contatoEmergencia" class="form-control" placeholder="Por favor nome do contato" required="" data-error="name is required.">
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>

                                    </div>

                                </div>

                            </form>

                        </div>

                    </telerik:RadWizardStep>

                    <telerik:RadWizardStep ID="stepEndereçoRS" 
                                           Title="Sociais" 
                                           runat="server" 
                                           StepType="Step" 
                                           CausesValidation="true">

                        <div class="panel with-nav-tabs panel-info">
                            <div class="panel-heading">
                                    <ul class="nav nav-tabs">
                                        <li class="active"><a href="#tab1info" data-toggle="tab">Informações de Logradouro</a></li>
                                        <li><a href="#tab2info" data-toggle="tab">Conectvidade e Redes Sociais</a></li>                                                        
                                    </ul>
                            </div>
                            <div class="panel-body">
                                <div class="tab-content">

                                    <div class="tab-pane fade in active" id="tab1info">

                                        <form id="contact-formEndereco" role="form">

                                            <legend>Informações de Logradouro</legend>

                                            <div class="controls">

                                                <div class="row">

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_email">Endereço *</label>
                                                            <input id="form_email" type="email" name="email" class="form-control" placeholder="Por favor informe sua data de nascimento *" required="required" data-error="Valid email is required.">
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_bairro">Bairro</label>
                                                            <input id="form_bairro" type="tel" name="phone" class="form-control" placeholder="Please enter your phone number">
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Cidade *</label>
                                                            <br />
                                                            <telerik:RadComboBox ID="cboEstadosBrasil"
                                                                                    runat="server"
                                                                                    Skin="Bootstrap"
                                                                                    Height="100px"
                                                                                    Width="220px">
                                                                                </telerik:RadComboBox>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                </div>

                                                <!-- Separador entre a segunda e terceira linha de controles do formulário -->
                                                <div class="clearfix"></div>

                                                <div class="row">

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_email">Estado *</label>
                                                            <input id="form_email" type="email" name="email" class="form-control" placeholder="Por favor informe sua data de nascimento *" required="required" data-error="Valid email is required.">
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_phone">Mora com quem?</label>
                                                            <br />
                                                            <telerik:RadRadioButtonList ID="rbTipoMoradia" 
                                                                                        runat="server" 
                                                                                        Text="Sim" 
                                                                                        Direction="Horizontal" 
                                                                                        SelectedIndex="0" 
                                                                                        SelectedValue="0" 
                                                                                        Skin="Bootstrap"
                                                                                        Width="472px"
                                                                                        AutoPostBack="false">                                                                        
                                                        </telerik:RadRadioButtonList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                </div>

                                            </div>

                                        </form>

                                    </div>
                                    <div class="tab-pane fade" id="tab2info">
                                        <!-- BEGIN -->
                                        <form id="contact-formRS" role="form">

                                            <legend>Redes Sociais</legend>

                                            <div class="controls">

                                                <div class="row">

                                                    <div class="col-sm-4">
                                                    <div class="form-group">
                                                            <label for="form_name">Instagram </label>
                                                            <input id="form_nameInsta" type="text" name="form_nameInsta" class="form-control" placeholder="Porfavor informe seu Username do Instagram " required="required" data-error="name is required.">
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_email">Facebook </label>
                                                            <input id="form_email" type="email" name="email" class="form-control" placeholder="Por favor informe seu usuário do Facebook" required="" >
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_phone">E-mail</label>
                                                            <input id="form_email" type="email" name="email" class="form-control" placeholder="Por favor informe sua data de nascimento *" required="required" data-error="Valid email is required.">
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Twitter *</label>
                                                            <input id="form_name" type="text" name="surname" class="form-control" placeholder="Porfavor informe seu nome *" required="required" data-error="name is required.">
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">É seguidor do @OficialFJU?</label>
                                                            <telerik:RadRadioButtonList ID="rbEhSeguidorOFICIALFJU" 
                                                                                            runat="server" 
                                                                                            Direction="Horizontal" 
                                                                                            SelectedIndex="0" 
                                                                                            SelectedValue="0" 
                                                                                            SkinID="Bootstrap"
                                                                                            Width="128px" 
                                                                                            Skin="WebBlue" 
                                                                                            AutoPostBack="false">
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                        <telerik:ButtonListItem Text="Não" Value="N" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Segue FJU no Youtube?</label>
                                                            <telerik:RadRadioButtonList ID="rbEhSeguidorFJUYouTube" 
                                                                                            runat="server" 
                                                                                            Direction="Horizontal" 
                                                                                            SelectedIndex="0" 
                                                                                            SelectedValue="0" 
                                                                                            SkinID="Bootstrap"
                                                                                            Width="128px" 
                                                                                            Skin="WebBlue" 
                                                                                            AutoPostBack="false">
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                        <telerik:ButtonListItem Text="Não" Value="N" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Segue canal da FJU no TELEGRAM?</label>
                                                            <telerik:RadRadioButtonList ID="rbSegueFJUTelegram" 
                                                                                            runat="server" 
                                                                                            Direction="Horizontal" 
                                                                                            SelectedIndex="0" 
                                                                                            SelectedValue="0" 
                                                                                            SkinID="Bootstrap"
                                                                                            Width="128px" 
                                                                                            Skin="WebBlue" 
                                                                                            AutoPostBack="false">
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                        <telerik:ButtonListItem Text="Não" Value="N" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Você é assinante do UNIVERVIDEO?</label>
                                                            <telerik:RadRadioButtonList ID="rbAssinanteUNIVERVIDEO" 
                                                                                            runat="server" 
                                                                                            Direction="Horizontal" 
                                                                                            SelectedIndex="0" 
                                                                                            SelectedValue="0" 
                                                                                            SkinID="Bootstrap"
                                                                                            Width="128px" 
                                                                                            Skin="WebBlue" 
                                                                                            AutoPostBack="false">
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                        <telerik:ButtonListItem Text="Não" Value="N" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Assiste com qual Frequência?</label>
                                                            <select required id="txtFrequenciaAssisteUniver" name="txtFrequenciaAssisteUniver" class="form-control">
                                                                    <option value=""></option>
                                                                      <option value="Todos os dias">Todos os dias</option>
                                                                      <option value="Cinco dias por semana">Cinco dias por semana</option>
                                                                      <option value="Três dias por semana">Três dias por semana</option>
                                                                      <option value="Um dia por semana">Um dia por semana</option>
                                                                      <option value="De vez enquando">De vez enquando</option>
                                                                      <option value="Sou assinante, mais não assisto">Sou assinante, mais não assisto</option>
                                                              </select>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Você Lê diariamente o Blog do Bispo Macedo?</label>
                                                            <telerik:RadRadioButtonList ID="rbLeDiariamenteBlogBM" 
                                                                                            runat="server" 
                                                                                            Direction="Horizontal" 
                                                                                            SelectedIndex="0" 
                                                                                            SelectedValue="0" 
                                                                                            SkinID="Bootstrap"
                                                                                            Width="128px" 
                                                                                            Skin="WebBlue" 
                                                                                            AutoPostBack="false">
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                        <telerik:ButtonListItem Text="Não" Value="N" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Você acessa diariamente o página universal.org?</label>
                                                            <telerik:RadRadioButtonList ID="rbLeitorSiteUniversalOrg" 
                                                                                            runat="server" 
                                                                                            Direction="Horizontal" 
                                                                                            SelectedIndex="0" 
                                                                                            SelectedValue="0" 
                                                                                            SkinID="Bootstrap"
                                                                                            Width="128px" 
                                                                                            Skin="WebBlue" 
                                                                                            AutoPostBack="false">
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                        <telerik:ButtonListItem Text="Não" Value="N" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Você tem celular com acesso à internet?</label>
                                                            <telerik:RadRadioButtonList ID="rbTemCelularComInternet" 
                                                                                            runat="server" 
                                                                                            Direction="Horizontal" 
                                                                                            SelectedIndex="0" 
                                                                                            SelectedValue="0" 
                                                                                            SkinID="Bootstrap"
                                                                                            Width="128px" 
                                                                                            Skin="WebBlue" 
                                                                                            AutoPostBack="false">
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                        <telerik:ButtonListItem Text="Não" Value="N" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Você tem computador em casa?</label>
                                                            <telerik:RadRadioButtonList ID="rbTemComputadorEmCasa" 
                                                                                            runat="server" 
                                                                                            Direction="Horizontal" 
                                                                                            SelectedIndex="0" 
                                                                                            SelectedValue="0" 
                                                                                            SkinID="Bootstrap"
                                                                                            Width="128px" 
                                                                                            Skin="WebBlue" 
                                                                                            AutoPostBack="false">
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                        <telerik:ButtonListItem Text="Não" Value="N" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                </div>

                                            </div>

                                        </form>

                                        <!-- END -->
                                    </div>
                                </div>
                            </div>
                        </div>

                    </telerik:RadWizardStep>


                    <telerik:RadWizardStep ID="stepDadosCivisProfissionais" 
                                           Title="Profissionais" 
                                           runat="server" 
                                           StepType="Step" 
                                           CausesValidation="true">

                        <div class="panel with-nav-tabs panel-info">
                            <div class="panel-heading">
                                    <ul class="nav nav-tabs">
                                        <li class="active"><a href="#tab1infoCivis" data-toggle="tab">Informações Civís</a></li>
                                        <li><a href="#tab2infoProf" data-toggle="tab">Informações Profissionais</a></li>                                                        
                                    </ul>
                            </div>
                            <div class="panel-body">
                                <div class="tab-content">

                                    <div class="tab-pane fade in active" id="tab1infoCivis">

                                        <form id="contact-formCivis" role="form">

                                            <legend>Civís</legend>

                                            <div class="controls">

                                                

                                                <!-- Separador entre a segunda e terceira linha de controles do formulário -->
                                                <div class="clearfix"></div>

                                                <div class="row">
                                                    <!---->
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Estado civil *</label>
                                                            <br>
                                                            <telerik:RadRadioButtonList ID="rbTipoEstadoCivil" 
                                                                                        runat="server" 
                                                                                        Text="Sim" 
                                                                                        Skin="Bootstrap"
                                                                                        Direction="Horizontal" 
                                                                                        SelectedIndex="0" 
                                                                                        SelectedValue="0" 
                                                                                        Width="472px"
                                                                                        AutoPostBack="false">                                                                        
                                                            </telerik:RadRadioButtonList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>
                                                    <!---->
                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">
                                                    <!---->
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_email">Nome do cônjuge *</label>
                                                            <input id="form_nNomeConjuge" type="text" name="form_nNomeConjuge" class="form-control" placeholder="Por favor informe nome do conjuge" required="" >
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_phone">Data do casamento</label>
                                                            <input id="form_phone" type="tel" name="phone" class="form-control" placeholder="Please enter your phone number">
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Cônjuge é da IURD? *</label>
                                                            <input id="form_name" type="text" name="surname" class="form-control" placeholder="Porfavor informe seu nome *" required="required" data-error="name is required.">
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>
                                                    <!---->
                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">
                                                    <!---->
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_email">Possui filhos? *</label>
                                                            <telerik:RadRadioButtonList ID="RadRadioButtonList2" 
                                                                                            runat="server" 
                                                                                            Text="Sim" 
                                                                                            Direction="Horizontal" 
                                                                                            Skin="Bootstrap"
                                                                                            SelectedIndex="0" 
                                                                                            SelectedValue="0" 
                                                                                            AutoPostBack="false"
                                                                                            Width="109px" >
                                                                <Items>
                                                                    <telerik:ButtonListItem  Text="Sim" Value="0" />
                                                                    <telerik:ButtonListItem Text="Não" Value="1" />
                                                                </Items>
                                                            </telerik:RadRadioButtonList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_phone">Quantos?</label>
                                                            <input class="form-control" type="number" value="0" id="example-number-input" min="0" max="30" >
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>
                                                    <!---->
                                                </div>

                                            </div>

                                        </form>

                                    </div>
                                    <div class="tab-pane fade" id="tab2infoProf">
                                        <!-- BEGIN -->
                                        <form id="contact-formInfoProfissionais" role="form">

                                            <legend>Profissionais e Escolaridade</legend>

                                            <div class="controls">
                                                <!---->
                                                <div class="row">
                                                    <!---->
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Trabalha? *</label>
                                                            <telerik:RadRadioButtonList ID="RadRadioButtonList3" 
                                                                                        runat="server" 
                                                                                        Text="Sim" 
                                                                                        Skin="Bootstrap"
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
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_email">Empresa *</label>
                                                            <input id="form_nomeEmpresa" type="text" name="form_nomeEmpresa" class="form-control" placeholder="Por favor informe nome da sua empresa *" required="" >
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_phone">Profissao</label>
                                                            <input id="form_profissao" type="text" name="form_profissao" class="form-control" placeholder="Informe sua profissão">
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>
                                                    <!---->
                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">
                                                    <!---->
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Estuda? *</label>
                                                            <telerik:RadRadioButtonList ID="RadRadioButtonList4" 
                                                                                        runat="server" 
                                                                                        Text="Sim" 
                                                                                        Skin="Bootstrap"
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
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_email">Grau *</label>
                                                            <input id="form_grau" type="text" name="form_grau" class="form-control" placeholder="Por favor informe grau que está cursando" required="" >
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_phone">Grau de instrução</label>
                                                              <select required id="escolaridade" name="escolaridade" class="form-control">
                                                                    <option value=""></option>
                                                                      <option value="Analfabeto">Analfabeto</option>
                                                                      <option value="Fundamental Incompleto">Fundamental Incompleto</option>
                                                                      <option value="Fundamental Completo">Fundamental Completo</option>
                                                                      <option value="Médio Incompleto">Médio Incompleto</option>
                                                                      <option value="Médio Completo">Médio Completo</option>
                                                                      <option value="Superior Incompleto">Superior Incompleto</option>
                                                                      <option value="Superior Completo">Superior Completo</option>
                                                              </select>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>
                                                    <!---->
                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">
                                                    <!-- -->
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Possui titulo de eleitor? *</label>
                                                            <telerik:RadRadioButtonList ID="RadRadioButtonList5" 
                                                                                                    runat="server" 
                                                                                                    Text="Sim" 
                                                                                                    Direction="Horizontal" 
                                                                                                    Skin="Bootstrap"
                                                                                                    SelectedIndex="0" 
                                                                                                    SelectedValue="0" 
                                                                                                    AutoPostBack="false"
                                                                                                    Width="131px" >
                                                                        <Items>
                                                                            <telerik:ButtonListItem  Text="Sim" Value="0" />
                                                                            <telerik:ButtonListItem Text="Não" Value="1" />
                                                                        </Items>
                                                                    </telerik:RadRadioButtonList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Instituição onde estuda </label>
                                                            <input id="form_name" type="text" name="surname" class="form-control" placeholder="Porfavor informe seu nome *" required="required" data-error="name is required.">
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <!-- -->
                                                </div>
                                                <!---->
                                            </div>

                                        </form>

                                        <!-- END -->
                                    </div>
                                </div>
                            </div>
                        </div>

                    </telerik:RadWizardStep>

                    <telerik:RadWizardStep ID="stepDadosEspirituais" 
                                           Title="Espiritual" 
                                           runat="server" 
                                           StepType="Step" 
                                           CausesValidation="true">

                        <div class="panel with-nav-tabs panel-info">
                            <div class="panel-heading">
                                    <ul class="nav nav-tabs">
                                        <li class="active"><a href="#tabInfoEspirituais" data-toggle="tab">Informações Espirituais</a></li>
                                        <li><a href="#tabDadosBatismo" data-toggle="tab">Dados do Batismo</a></li>                                                        
                                        <li><a href="#tabLivrosLidos" data-toggle="tab">Livros Lidos</a></li>          
                                    </ul>
                            </div>
                            <div class="panel-body">
                                <div class="tab-content">
                                    <div class="tab-pane fade in active" id="tabInfoEspirituais">
                                        <!---->
                                        <form id="contact-formInfoEspirituais" role="form">

                                            <legend>Informações Espirituais </legend>

                                            <div class="controls">
                                                                                                <div class="row">

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">É membro da IURD? *</label>
                                                            <telerik:RadRadioButtonList ID="rbEhMembroIURD" 
                                                                                        runat="server" 
                                                                                        Direction="Horizontal" 
                                                                                        SelectedIndex="0" 
                                                                                        SelectedValue="0" 
                                                                                        SkinID="Bootstrap"
                                                                                        Width="128px" 
                                                                                        Skin="WebBlue" 
                                                                                        AutoPostBack="false">
                                                                <Items>
                                                                    <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                    <telerik:ButtonListItem Text="Não" Value="N" />
                                                                </Items>
                                                            </telerik:RadRadioButtonList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_email">Mês e ano que chegou? *</label>
                                                            <br />
                                                            <telerik:RadMaskedTextBox RenderMode="Lightweight" 
                                                                                        ID="txtMesAnoChegadaIURD" 
                                                                                        runat="server" 
                                                                                        Mask="##/####" 
                                                                                        Width="150px"                                                                        
                                                                                        DisplayText="00/0000"
                                                                                        ValidationGroup="Group1">
                                                            </telerik:RadMaskedTextBox>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_phone">Como conheceu?</label>
                                                            <input id="txtComoConheceuIURD" type="text" name="txtComoConheceuIURD" class="form-control" placeholder="Informe como conheceu">
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                </div>

                                                <!-- Primeiro separador -->
                                                <div class="clearfix"></div>

                                                <div class="row">

                                                    <div class="col-sm-4">
                                                    <div class="form-group">
                                                            <label for="form_name">Já se afastou alguma vez? *</label>
                                                            <br>
                                                        <telerik:RadMaskedTextBox RenderMode="Lightweight" 
                                                                                    ID="rbJaSeAfastou" 
                                                                                    runat="server" 
                                                                                    Mask="##/####" 
                                                                                    Width="150px"                                                                        
                                                                                    DisplayText="00/0000"
                                                                                    ValidationGroup="Group1">
                                                        </telerik:RadMaskedTextBox>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_email">Porque? *</label>
                                                            <input id="txctMotivoAfastamento" type="text" name="txctMotivoAfastamento" class="form-control" placeholder="Por favor informe motivo do afastamento" required="required" data-error="Valid email is required.">
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_phone">Quando?</label>
                                                            <br />
                                                            <telerik:RadMaskedTextBox RenderMode="Lightweight" 
                                                                                        ID="txtMesAnoAfastou2" 
                                                                                        runat="server" 
                                                                                        Mask="##/####" 
                                                                                        Width="150px"                                                                        
                                                                                        DisplayText="00/0000"
                                                                                        ValidationGroup="Group1">
                                                            </telerik:RadMaskedTextBox>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                </div>

                                                <!-- Separador  -->
                                                <div class="clearfix"></div>

                                                <div class="row">

                                                    <div class="col-sm-4">
                                                    <div class="form-group">
                                                            <label for="form_name">Por quanto tempo? *</label>
                                                            <input id="txtPorQuantoTempoSeAfastou" type="text" name="txtPorQuantoTempoSeAfastou" class="form-control" placeholder="Por quanto tempo esteve afastado" required="">
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_email">Esta firme desde quando? *</label>
                                                            <br>
                                                            <telerik:RadMaskedTextBox RenderMode="Lightweight" 
                                                                                        ID="txtDesdeQuandoFirme" 
                                                                                        runat="server" 
                                                                                        Mask="##/####" 
                                                                                        Width="150px"                                                                        
                                                                                        DisplayText="00/0000"
                                                                                        ValidationGroup="Group1">
                                                            </telerik:RadMaskedTextBox>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_phone">Tem familiares na Universal?</label>
                                                            <br />
                                                            <telerik:RadRadioButtonList ID="rbTemFamiliaresIURD" 
                                                                                        runat="server" 
                                                                                        Direction="Horizontal" 
                                                                                        SelectedIndex="0" 
                                                                                        SelectedValue="0" 
                                                                                        SkinID="Bootstrap"
                                                                                        Width="128px" 
                                                                                        Skin="WebBlue" 
                                                                                        AutoPostBack="false">
                                                                <Items>
                                                                    <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                    <telerik:ButtonListItem Text="Não" Value="N" />
                                                                </Items>
                                                            </telerik:RadRadioButtonList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Quem são? *</label>
                                                            <input id="txtFamiliaresIURD" type="text" name="txtFamiliaresIURD" class="form-control" placeholder="Por favor quais familiares são da universal" required="">
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>

                                        </form>
                                        <!---->
                                    </div>
                                    <div class="tab-pane fade" id="tabDadosBatismo">
                                        <!---->
                                        <form id="contact-formInfoBatismo" role="form">

                                            <legend>Informações de Batismo </legend>

                                            <div class="controls">

                                                <div class="row">
                                        
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_email">Batizado nas águas? *</label>
                                                            <br />
                                                            <telerik:RadRadioButtonList ID="rbBatizadoAguas" 
                                                                                        runat="server" 
                                                                                        Direction="Horizontal" 
                                                                                        SelectedIndex="0" 
                                                                                        SelectedValue="0" 
                                                                                        SkinID="Bootstrap"
                                                                                        Width="128px" 
                                                                                        Skin="WebBlue" 
                                                                                        AutoPostBack="false">
                                                                <Items>
                                                                    <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                    <telerik:ButtonListItem Text="Não" Value="N" />
                                                                </Items>
                                                            </telerik:RadRadioButtonList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_phone">Quando(Mês/ano)?</label>
                                                            <br />
                                                            <telerik:RadMaskedTextBox RenderMode="Lightweight" 
                                                                                        ID="txtQuandoSeBatizouAguas" 
                                                                                        runat="server" 
                                                                                        Mask="##/####" 
                                                                                        Width="150px"                                                                        
                                                                                        DisplayText="00/0000"
                                                                                        ValidationGroup="Group1">
                                                            </telerik:RadMaskedTextBox>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Foi na igreja Universal? *</label>
                                                            <br />
                                                            <telerik:RadRadioButtonList ID="rbBatismoAguasNaIURD" 
                                                                                        runat="server" 
                                                                                        Direction="Horizontal" 
                                                                                        SelectedIndex="0" 
                                                                                        SelectedValue="0" 
                                                                                        SkinID="Bootstrap"
                                                                                        Width="128px" 
                                                                                        Skin="WebBlue" 
                                                                                        AutoPostBack="false">
                                                                <Items>
                                                                    <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                    <telerik:ButtonListItem Text="Não" Value="N" />
                                                                </Items>
                                                            </telerik:RadRadioButtonList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">                                        

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_email">Batizado com Espírito Santo? *</label>
                                                            <br />
                                                            <telerik:RadRadioButtonList ID="rbBatizadoEspiritoSanto" 
                                                                                        runat="server" 
                                                                                        Direction="Horizontal" 
                                                                                        SelectedIndex="0" 
                                                                                        SelectedValue="0" 
                                                                                        SkinID="Bootstrap"
                                                                                        Width="128px" 
                                                                                        Skin="WebBlue" 
                                                                                        AutoPostBack="false">
                                                                <Items>
                                                                    <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                    <telerik:ButtonListItem Text="Não" Value="N" />
                                                                </Items>
                                                            </telerik:RadRadioButtonList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_phone">Quando(Mês/Ano)?</label>
                                                            <br>
                                                            <telerik:RadMaskedTextBox RenderMode="Lightweight" 
                                                                                        ID="txtQuandoSeBatizadoES" 
                                                                                        runat="server" 
                                                                                        Mask="##/####" 
                                                                                        Width="150px"                                                                        
                                                                                        DisplayText="00/0000"
                                                                                        ValidationGroup="Group1">
                                                            </telerik:RadMaskedTextBox>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Onde? *</label>
                                                            <input id="txtOndeBatismoEspiritoSanto" type="text" name="txtOndeBatismoEspiritoSanto" class="form-control" placeholder="Onde foi seu batizado com o Espírito Santo" required="" >
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">
                                        
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_email">Como conheceu a força jovem universa? </label>
                                                            <input id="txtComoConheceuFJU" type="text" name="txtComoConheceuFJU" class="form-control" placeholder="Por favor informe como conheceu a FJU" required="required" data-error="Valid email is required.">
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_phone">Quando(Mês/Ano) entrou na FJU?</label>
                                                            <br />
                                                            <telerik:RadMaskedTextBox RenderMode="Lightweight" 
                                                                                        ID="txtQuandoEntrouFJU" 
                                                                                        runat="server" 
                                                                                        Mask="##/####" 
                                                                                        Width="150px"                                                                        
                                                                                        DisplayText="00/0000"
                                                                                        ValidationGroup="Group1">
                                                            </telerik:RadMaskedTextBox>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Porque? *</label>
                                                            <input id="txtMotivoEntrouFJU" type="text" name="txtMotivoEntrouFJU" class="form-control" placeholder="Por favor informe motivo de sua entrada na FJU" required="" >
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>         

                                                </div>

                                            </div>

                                        </form>
                                        <!---->
                                    </div>
                                    <div class="tab-pane fade" id="tabLivrosLidos">
                                        <!---->
                                        <form id="contact-formInfoLivrosLidos" role="form">

                                            <legend>Livros lidos e informações adicionais </legend>

                                            <div class="controls">

                                                <div class="row">
                                                    <!---->
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Você tem Bíblia ? </label>
                                                            <telerik:RadRadioButtonList ID="rbTemBiblia" 
                                                                                        runat="server" 
                                                                                        Direction="Horizontal" 
                                                                                        SelectedIndex="0" 
                                                                                        SelectedValue="0" 
                                                                                        SkinID="Bootstrap"
                                                                                        Width="128px" 
                                                                                        Skin="WebBlue" 
                                                                                        AutoPostBack="false">
                                                                <Items>
                                                                    <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                    <telerik:ButtonListItem Text="Não" Value="N" />
                                                                </Items>
                                                            </telerik:RadRadioButtonList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Tem Bíblia no celular? </label>
                                                            <telerik:RadRadioButtonList ID="rbTemBibliaNoCelular" 
                                                                                        runat="server" 
                                                                                        Direction="Horizontal" 
                                                                                        SelectedIndex="0" 
                                                                                        SelectedValue="0" 
                                                                                        SkinID="Bootstrap"
                                                                                        Width="128px" 
                                                                                        Skin="WebBlue" 
                                                                                        AutoPostBack="false">
                                                                <Items>
                                                                    <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                    <telerik:ButtonListItem Text="Não" Value="N" />
                                                                </Items>
                                                            </telerik:RadRadioButtonList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Já leu a Bíblia toda? </label>
                                                            <telerik:RadRadioButtonList ID="rbJaLeuBibliaToda" 
                                                                                        runat="server" 
                                                                                        Direction="Horizontal" 
                                                                                        SelectedIndex="0" 
                                                                                        SelectedValue="0" 
                                                                                        SkinID="Bootstrap"
                                                                                        Width="128px" 
                                                                                        Skin="WebBlue" 
                                                                                        AutoPostBack="false">
                                                                <Items>
                                                                    <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                    <telerik:ButtonListItem Text="Não" Value="N" />
                                                                </Items>
                                                            </telerik:RadRadioButtonList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>
                                                    <!---->
                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">
                                                    <!---->
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Com que frequência você lê a Bíblia? </label>
                                                            <telerik:RadRadioButtonList ID="rbFrequenciaLeituraBiblia" 
                                                                                        runat="server" 
                                                                                        Direction="Horizontal" 
                                                                                        SelectedIndex="0" 
                                                                                        SelectedValue="0" 
                                                                                        SkinID="Bootstrap"
                                                                                        Width="128px" 
                                                                                        Skin="WebBlue" 
                                                                                        AutoPostBack="false">
                                                            </telerik:RadRadioButtonList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>
                                                    <!---->
                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">
                                                    <!---->
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Pertence a algum grupo de mulheres na universal? </label>
                                                            <telerik:RadRadioButtonList ID="rbFazParteGrupoMulheresUniversal" 
                                                                                        runat="server" 
                                                                                        Direction="Horizontal" 
                                                                                        SelectedIndex="0" 
                                                                                        SelectedValue="0" 
                                                                                        SkinID="Bootstrap"
                                                                                        Width="128px" 
                                                                                        Skin="WebBlue" 
                                                                                        AutoPostBack="false">
                                                                <Items>
                                                                    <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                    <telerik:ButtonListItem Text="Não" Value="N" />
                                                                </Items>
                                                            </telerik:RadRadioButtonList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Qual? </label>
                                                            <input id="txtNomeGrupoMulheresUniversal" type="text" name="txtNomeGrupoMulheresUniversal" class="form-control" placeholder="Por favor informe seu nome *" required="" >
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>
                                                    <!---->
                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Marque quais reuniões jovem participa</label>
                                                            <br />
                                                            <telerik:RadCheckBoxList ID="chkReunioesFJU2" 
                                                                                    runat="server"
                                                                                    Direction="Horizontal"
                                                                                    Skin="WebBlue"
                                                                                    AutoPostBack="false"></telerik:RadCheckBoxList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Marque os livros que o jovem já leu</label>
                                                            <br />
                                                            <telerik:RadCheckBoxList ID="chkLivros" 
                                                                                     Skin="Bootstrap" 
                                                                                     Direction="Horizontal"
                                                                                     AutoPostBack="false"
                                                                                     Columns="5"
                                                                Layout="Flow"
                                                                                     runat="server">
                                                            </telerik:RadCheckBoxList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>         
                                                    
                                                </div>

                                            </div>

                                        </form>
                                        <!---->
                                    </div>
                                </div>
                            </div>
                        </div>                        

                    </telerik:RadWizardStep>

                    <telerik:RadWizardStep ID="stepSituação" 
                                           Title="Situação" 
                                           runat="server" 
                                           StepType="Step" 
                                           CausesValidation="true">
                        <!---->
                        <div class="panel with-nav-tabs panel-info">
                                <div class="panel-heading">
                                        <ul class="nav nav-tabs">
                                            <li class="active"><a href="#tab1infoIURD" data-toggle="tab">IURD</a></li>
                                            <li><a href="#tab2infoFJU" data-toggle="tab">FJU</a></li>                                           
                                            <li><a href="#tab2infoIntellimen" data-toggle="tab">Intellimen</a></li>
                                        </ul>                                </div>
                                <div class="panel-body">
                                    <div class="tab-content">

                                        <div class="tab-pane fade in active" id="tab1infoIURD">
                                            <!-- BEGIN -->
                                            <form id="contact-formIURD" role="form">

                                                <legend>IURD</legend>

                                                <div class="controls">                                                

                                                    <!-- -->
                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Õbreiro ?</label>
                                                                <br />
                                                                <span class="button-checkbox">
                                                                    <button type="button" id="chkEhObreiro" name="chkEhObreiro" class="btn" data-color="primary">Sim</button>
                                                                    <input type="checkbox" class="hidden"  />
                                                                </span>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Tempo de Obreiro( Quantos anos / Quantos meses ) </label>
                                                                <br />
                                                                <!-- begin teste-->
                                                                <telerik:RadNumericTextBox ID="RadNumericTextBox1"
                                                                                                   runat="server" 
                                                                                                   Skin="Bootstrap"
                                                                                                   MinValue="0"
                                                                                                   ShowSpinButtons="false"
                                                                                                   Width="45px"
                                                                                                   NumberFormat-DecimalDigits="0" 
                                                                                                   Value="0"
                                                                                                   MaxLength="2">
																        </telerik:RadNumericTextBox>
                                                                        <telerik:RadNumericTextBox ID="RadNumericTextBox2"
                                                                                                   runat="server" 
                                                                                                   Skin="Bootstrap"
                                                                                                   Width="45px"
                                                                                                    ShowSpinButtons="false"
                                                                                                   MinValue="0"
                                                                                                   MaxValue="12"
                                                                                                   Value="0"
                                                                                                   NumberFormat-DecimalDigits="0"
                                                                                                   MaxLength="2">
                                                                        </telerik:RadNumericTextBox>
                                                                <!-- end teste-->
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>
                                                        <!---->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Colaborador ?</label>
                                                                <br />
                                                                <span class="button-checkbox">
                                                                    <button type="button" id="chkEhColaborador" name="chkEhColaborador" class="btn" data-color="primary">Sim</button>
                                                                    <input type="checkbox" class="hidden"  />
                                                                </span>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Tempo de Colaborador( Quantos anos / Quantos meses ) </label>
                                                                <br />
                                                                <telerik:RadNumericTextBox ID="RadNumericTextBox3"
                                                                                            runat="server" 
                                                                                            Skin="Bootstrap"
                                                                                            MinValue="0"
                                                                                            ShowSpinButtons="false"
                                                                                            Width="45px"
                                                                                            NumberFormat-DecimalDigits="0" 
                                                                                            Value="0"
                                                                                            MaxLength="2">
															    </telerik:RadNumericTextBox>                                                                
                                                                <telerik:RadNumericTextBox ID="RadNumericTextBox4"
                                                                                            runat="server" 
                                                                                            Skin="Bootstrap"
                                                                                            Width="45px"
                                                                                            ShowSpinButtons="false"
                                                                                            MinValue="0"
                                                                                            MaxValue="12"
                                                                                            Value="0"
                                                                                            NumberFormat-DecimalDigits="0"
                                                                                            MaxLength="2">
                                                                </telerik:RadNumericTextBox>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>
                                                        <!---->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">CPO(Curso Preparatório de Obreiros) ?</label>
                                                                <br />
                                                                <span class="button-checkbox">
                                                                    <button type="button" id="chkCursandoCPO" name="chkCursandoCPO" class="btn" data-color="primary">Sim</button>
                                                                    <input type="checkbox" class="hidden"  />
                                                                </span>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Tempo no CPO( Quantos anos / Quantos meses ) </label>
                                                                <br />
                                                                <telerik:RadNumericTextBox ID="RadNumericTextBox5"
                                                                                                   runat="server" 
                                                                                                   Skin="Bootstrap"
                                                                                                   Width="45px"
                                                                                                   NumberFormat-DecimalDigits="0"
                                                                                                   MaxLength="2"
                                                                                                   MinValue="0"
                                                                                                   Value="0">
                                                                        </telerik:RadNumericTextBox>         
																        <telerik:RadNumericTextBox ID="RadNumericTextBox6"
                                                                                                   runat="server" 
                                                                                                   Skin="Bootstrap"
                                                                                                   Width="45px"
                                                                                                   NumberFormat-DecimalDigits="0"
                                                                                                   MaxLength="2"
                                                                                                   MinValue="0"
                                                                                                   MaxValue="12"
                                                                                                   Value="0">
                                                                        </telerik:RadNumericTextBox>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>
                                                        <!---->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Já foi obreiro antes? </label>
                                                                <telerik:RadRadioButtonList ID="RadRadioButtonList9" 
                                                                                            runat="server" 
                                                                                            Direction="Horizontal" 
                                                                                            SelectedIndex="0" 
                                                                                            SelectedValue="0" 
                                                                                            SkinID="Bootstrap"
                                                                                            Width="128px" 
                                                                                            Skin="WebBlue" 
                                                                                            AutoPostBack="false">
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                        <telerik:ButtonListItem Text="Não" Value="N" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Se sim, saiu porque? </label>
                                                                <input id="txtMotivoSaidaObreiro" type="text" name="txtMotivoSaidaObreiro" class="form-control" placeholder="Por favor informe motivo saída de obreiro" required="" >
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>                                        
                                                        <!---->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Já foi Pastor/Esposa antes? </label>
                                                                <telerik:RadRadioButtonList ID="RadRadioButtonList10" 
                                                                                            runat="server" 
                                                                                            Direction="Horizontal" 
                                                                                            SelectedIndex="0" 
                                                                                            SelectedValue="0" 
                                                                                            SkinID="Bootstrap"
                                                                                            Width="128px" 
                                                                                            Skin="WebBlue" 
                                                                                            AutoPostBack="false">
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                        <telerik:ButtonListItem Text="Não" Value="N" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Se sim, saiu porque? </label>
                                                                <input id="txtMotivoSaidaPastorEsposa" type="text" name="txtMotivoSaidaPastorEsposa" class="form-control" placeholder="Por favor informe motivo saída de pastor/esposa" required="" >
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>
                                                        <!---->
                                                    </div>

                                                </div>

                                            </form>
                                            <!-- END -->
                                        </div>
                                        <div class="tab-pane fade" id="tab2infoFJU">
                                            <!-- BEGIN -->
                                            <form id="contact-formInfoFJU" role="form">

                                                <legend>FJU</legend>

                                                <div class="controls">
                                                    <!---->
                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Membro da Força Jovem Universal ?</label>
                                                                <br />
                                                                <span class="button-checkbox">
                                                                    <button type="button" id="chkMembroFJU" name="chkMembroFJU" class="btn" data-color="primary">Sim</button>
                                                                    <input type="checkbox" class="hidden"  />
                                                                </span>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Coordenador da Força Jovem?</label>   
                                                                <br />
                                                                <span class="button-checkbox">
                                                                    <button type="button" id="chkEhCoordenadorFJU" name="chkEhCoordenadorFJU" class="btn" data-color="primary">Sim</button>
                                                                    <input type="checkbox" class="hidden"  />
                                                                </span>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>


                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Desde quando?( Quantos anos / Quantos meses ) </label>
                                                                <br />
                                                                <telerik:RadNumericTextBox ID="RadNumericTextBox7"
                                                                                                   runat="server" 
                                                                                                   Skin="Bootstrap"
                                                                                                   Width="45px"
                                                                                                   NumberFormat-DecimalDigits="0"
                                                                                                   MaxLength="2"
                                                                                                   MinValue="0"
                                                                                                   Value="0">
                                                                        </telerik:RadNumericTextBox>         
																        <telerik:RadNumericTextBox ID="RadNumericTextBox8"
                                                                                                   runat="server" 
                                                                                                   Skin="Bootstrap"
                                                                                                   Width="45px"
                                                                                                   NumberFormat-DecimalDigits="0"
                                                                                                   MaxLength="2"
                                                                                                   MinValue="0"
                                                                                                   MaxValue="12"
                                                                                                   Value="0">
                                                                        </telerik:RadNumericTextBox>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>
                                                        <!---->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Líder de Tribo ?</label>
                                                                <br />
                                                                <span class="button-checkbox">
                                                                    <button type="button" id="chkLiderTribo" name="chkLiderTribo" class="btn" data-color="primary">Sim</button>
                                                                    <input type="checkbox" class="hidden"  />
                                                                </span>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Qual Tribo ?</label>
                                                                <br />
                                                                <telerik:RadDropDownList ID="cboTribos"                                                                     
                                                                                         runat="server" 
                                                                                         Skin="Bootstrap" 
                                                                                         Height="16px" Width="120px">
                                                                </telerik:RadDropDownList>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Há quanto tempo?( Quantos anos / Quantos meses ) </label>
                                                                <br />
                                                                <telerik:RadNumericTextBox ID="RadNumericTextBox9"
                                                                                                   runat="server" 
                                                                                                   Skin="Bootstrap"
                                                                                                   Width="45px"
                                                                                                   NumberFormat-DecimalDigits="0"
                                                                                                   MaxLength="2"
                                                                                                   MinValue="0"
                                                                                                   Value="0">
                                                                        </telerik:RadNumericTextBox>         
																        <telerik:RadNumericTextBox ID="RadNumericTextBox10"
                                                                                                   runat="server" 
                                                                                                   Skin="Bootstrap"
                                                                                                   Width="45px"
                                                                                                   NumberFormat-DecimalDigits="0"
                                                                                                   MaxLength="2"
                                                                                                   MinValue="0"
                                                                                                   MaxValue="12"
                                                                                                   Value="0">
                                                                        </telerik:RadNumericTextBox>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>
                                                        <!---->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!-- -->                                                    
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Líder de Projeto ?</label>
                                                                <br />
                                                                <span class="button-checkbox">
                                                                    <button type="button" id="chkLiderProjeto" name="chkLiderProjeto" class="btn" data-color="primary">Sim</button>
                                                                    <input type="checkbox" class="hidden"  />
                                                                </span>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Qual Projeto ?</label>
                                                                <br />
                                                                <telerik:RadDropDownList ID="cboProjetoFJU"                                                                     
                                                                                         runat="server" 
                                                                                         Skin="Bootstrap" 
                                                                                         Height="16px" Width="120px">
                                                                </telerik:RadDropDownList>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Há quanto tempo?( Quantos anos / Quantos meses ) </label>
                                                                <br />
                                                                <telerik:RadNumericTextBox ID="RadNumericTextBox11"
                                                                                                   runat="server" 
                                                                                                   Skin="Bootstrap"
                                                                                                   Width="45px"
                                                                                                   NumberFormat-DecimalDigits="0"
                                                                                                   MaxLength="2"
                                                                                                   MinValue="0"
                                                                                                   Value="0">
                                                                        </telerik:RadNumericTextBox>         
																        <telerik:RadNumericTextBox ID="RadNumericTextBox12"
                                                                                                   runat="server" 
                                                                                                   Skin="Bootstrap"
                                                                                                   Width="45px"
                                                                                                   NumberFormat-DecimalDigits="0"
                                                                                                   MaxLength="2"
                                                                                                   MinValue="0"
                                                                                                   MaxValue="12"
                                                                                                   Value="0">
                                                                        </telerik:RadNumericTextBox>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>
                                                        <!-- -->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Tem desejo de ser obreiro ? </label>
                                                                <telerik:RadRadioButtonList ID="RadRadioButtonList11" 
                                                                                            runat="server" 
                                                                                            Direction="Horizontal" 
                                                                                            SelectedIndex="0" 
                                                                                            SelectedValue="0" 
                                                                                            SkinID="Bootstrap"
                                                                                            Width="128px" 
                                                                                            Skin="WebBlue" 
                                                                                            AutoPostBack="false">
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                        <telerik:ButtonListItem Text="Não" Value="N" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Porque? </label>
                                                                <input id="txtMotivoDesejaSErObreiro" type="text" name="txtMotivoDesejaSErObreiro" class="form-control" placeholder="Por favor informe motivo do desejo de ser obreiro" required="" >
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>                                        
                                                        <!---->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Tem desejo de fazer a obre no altar? </label>
                                                                <telerik:RadRadioButtonList ID="RadRadioButtonList12" 
                                                                                            runat="server" 
                                                                                            Direction="Horizontal" 
                                                                                            SelectedIndex="0" 
                                                                                            SelectedValue="0" 
                                                                                            SkinID="Bootstrap"
                                                                                            Width="128px" 
                                                                                            Skin="WebBlue" 
                                                                                            AutoPostBack="false">
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                        <telerik:ButtonListItem Text="Não" Value="N" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Esta no Altar Jovem? </label>
                                                                <telerik:RadRadioButtonList ID="RadRadioButtonList13" 
                                                                                            runat="server" 
                                                                                            Direction="Horizontal" 
                                                                                            SelectedIndex="0" 
                                                                                            SelectedValue="0" 
                                                                                            SkinID="Bootstrap"
                                                                                            Width="128px" 
                                                                                            Skin="WebBlue" 
                                                                                            AutoPostBack="false">
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                        <telerik:ButtonListItem Text="Não" Value="N" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>                                        
                                                        <!---->
                                                    </div>
                                                    <!---->
                                                </div>

                                            </form>

                                            <!-- END -->
                                        </div>
                                        <div class="tab-pane fade" id="tab2infoIntellimen">
                                            <!-- BEGIN -->
                                            <form id="contact-formInfoIntellimen" role="form">

                                                <legend>Intellimen</legend>

                                                <div class="controls">
                                                    <!---->
                                                    <div class="row">
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Faz parte do intellimen ? </label>
                                                                <telerik:RadRadioButtonList ID="RadRadioButtonList14" 
                                                                                            runat="server" 
                                                                                            Direction="Horizontal" 
                                                                                            SelectedIndex="0" 
                                                                                            SelectedValue="0" 
                                                                                            SkinID="Bootstrap"
                                                                                            Width="128px" 
                                                                                            Skin="WebBlue" 
                                                                                            AutoPostBack="false">
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                        <telerik:ButtonListItem Text="Não" Value="N" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Completou os desáfios ? </label>
                                                                <telerik:RadRadioButtonList ID="RadRadioButtonList15" 
                                                                                            runat="server" 
                                                                                            Direction="Horizontal" 
                                                                                            SelectedIndex="0" 
                                                                                            SelectedValue="0" 
                                                                                            SkinID="Bootstrap"
                                                                                            Width="128px" 
                                                                                            Skin="WebBlue" 
                                                                                            AutoPostBack="false">
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                        <telerik:ButtonListItem Text="Não" Value="N" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Está em qual ? </label>
                                                                <br />
                                                                <telerik:RadNumericTextBox ID="RadNumericTextBox13"
                                                                                           runat="server" 
                                                                                           Skin="Bootstrap"
                                                                                           Width="45px"
                                                                                           ShowSpinButtons="false"
                                                                                           MinValue="0"
                                                                                           MaxValue="53"
                                                                                           Value="0"
                                                                                           NumberFormat-DecimalDigits="0"
                                                                                           MaxLength="2">
                                                                </telerik:RadNumericTextBox>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>                                                
                                                
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Qual o nome do seu parceiro</label>
                                                                <input id="txtNomeParceiroIntellimen" type="text" name="txtNomeParceiroIntellimen" class="form-control" placeholder="Por favor informe seu nome *" required="" >
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Telefone</label>
                                                                <br>
                                                                <telerik:RadMaskedTextBox RenderMode="Lightweight" 
                                                                                          ID="RadMaskedTextBox1" 
                                                                                          runat="server" 
                                                                                          Mask="(##) #####-####" 
                                                                                          Width="150px"                                                                        
                                                                                          Skin="Bootstrap"
                                                                                          ValidationGroup="Group1">
                                                                </telerik:RadMaskedTextBox>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>
                                                        <!---->
                                                    </div>
                                                    <!---->
                                                </div>

                                            </form>

                                        </div>
                                        <!-- END -->
                                    </div>
                                </div>                            
                        </div>
                        <!---->
                    </telerik:RadWizardStep>                    

                    <telerik:RadWizardStep ID="stepProjetos" 
                                           Title="Projetos" 
                                           runat="server" 
                                           StepType="Step" 
                                           CausesValidation="true">

                        <div class="container-fluid bg-light py-3">

                            <form id="contact-form" role="form">

                                <legend>Projetos FJU </legend>

                            </form>

                        </div>

                    </telerik:RadWizardStep>

                    <telerik:RadWizardStep ID="stepIdiomas" 
                                           Title="Idiomas" 
                                           runat="server" 
                                           StepType="Step" 
                                           CausesValidation="true">

                        <div class="container-fluid bg-light py-3">

                            <form id="contact-form" role="form">

                                <legend>Informações sobre Idiomas falados pelo jovem</legend>

                            </form>

                        </div>

                    </telerik:RadWizardStep>               

                    <telerik:RadWizardStep ID="stepTestemunho" 
                                           Title="Testemunho" 
                                           runat="server" 
                                           StepType="Step" 
                                           CausesValidation="true">

                        <div class="panel with-nav-tabs panel-info">
                            <div class="panel-heading">
                                    <ul class="nav nav-tabs">
                                        <li class="active"><a href="#tabDetalhes" data-toggle="tab">Detalhes</a></li>
                                        <li><a href="#tabTestemunho" data-toggle="tab">Resumo</a></li>
                                        <li><a href="#tabSugestao" data-toggle="tab">Sugestões para o trabalho da FJU</a></li>                                                        
                                    </ul>
                            </div>
                            <div class="panel-body">
                                <div class="tab-content">

                                    <div class="tab-pane fade in active" id="tabDetalhes">

                                        <form id="contact-formDetalhes" role="form">

                                            <legend>Detalhes</legend>

                                            <div class="controls">

                                                <div class="row">
                                                    <!--  -->
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Já sofreu com depressão? </label>
                                                            <telerik:RadRadioButtonList ID="rbJaSofreuDepressao" 
                                                                                        runat="server" 
                                                                                        Direction="Horizontal" 
                                                                                        SelectedIndex="0" 
                                                                                        SelectedValue="0" 
                                                                                        SkinID="Bootstrap"
                                                                                        Width="128px" 
                                                                                        Skin="WebBlue" 
                                                                                        AutoPostBack="false">
                                                                <Items>
                                                                    <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                    <telerik:ButtonListItem Text="Não" Value="N" />
                                                                </Items>
                                                            </telerik:RadRadioButtonList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Por quanto tempo? </label>
                                                            <input id="txtTempoSofreuDepressao" type="text" name="txtTempoSofreuDepressao" class="form-control" placeholder="Por quanto tempo sofreu com depressão" required="" >
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Está livre desde? </label>
                                                            <input id="txtTempoLivreDepressao" type="text" name="txtTempoLivreDepressao" class="form-control" placeholder="Há quanto tempo está livre da depressão" required="" >
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>
                                                    <!--  -->
                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">
                                                    <!--  -->
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Já sofreu com Automutilação? </label>
                                                            <telerik:RadRadioButtonList ID="rbJaSofreuAutomutilacao" 
                                                                                        runat="server" 
                                                                                        Direction="Horizontal" 
                                                                                        SelectedIndex="0" 
                                                                                        SelectedValue="0" 
                                                                                        SkinID="Bootstrap"
                                                                                        Width="128px" 
                                                                                        Skin="WebBlue" 
                                                                                        AutoPostBack="false">
                                                                <Items>
                                                                    <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                    <telerik:ButtonListItem Text="Não" Value="N" />
                                                                </Items>
                                                            </telerik:RadRadioButtonList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Por quanto tempo? </label>
                                                            <input id="txtTempoSofreuAutomutilacao" type="text" name="txtTempoSofreuAutomutilacao" class="form-control" placeholder="Por quanto tempo sofreu com Automutilação" required="" >
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Está livre desde? </label>
                                                            <input id="txtTempoLivreAutomutilacao" type="text" name="txtTempoLivreAutomutilacao" class="form-control" placeholder="Há quanto está tempo livre da Automutilação" required="" >
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>
                                                    <!--  -->
                                                </div>
                                                
                                                <div class="clearfix"></div>

                                                <div class="row">
                                                    <!--  -->
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Já teve algum vício? </label>
                                                            <telerik:RadRadioButtonList ID="rbJaTeveVicio" 
                                                                                        runat="server" 
                                                                                        Direction="Horizontal" 
                                                                                        SelectedIndex="0" 
                                                                                        SelectedValue="0" 
                                                                                        SkinID="Bootstrap"
                                                                                        Width="128px" 
                                                                                        Skin="WebBlue" 
                                                                                        AutoPostBack="false">
                                                                <Items>
                                                                    <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                    <telerik:ButtonListItem Text="Não" Value="N" />
                                                                </Items>
                                                            </telerik:RadRadioButtonList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Qual vício? </label>
                                                            <input id="txtNomeVicio" type="text" name="txtNomeVicio" class="form-control" placeholder="Por favor informe qual vício teve" required="" >
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Por quanto tempo permaneceu viciado? </label>
                                                            <input id="txtTempoVicio" type="text" name="txtTempoVicio" class="form-control" placeholder="Por quanto tempo permaneceu nos vícios" required="" >
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>
                                                    <!--  -->
                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">
                                                    <!---->
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Está livre dos vícios há quanto tempo? </label>
                                                            <input id="txtTempoLivreVicios" type="text" name="txtTempoLivreVicios" class="form-control" placeholder="Quais vícios teve" required="" >
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Já tentou suicídio alguma vez? </label>
                                                            <telerik:RadRadioButtonList ID="RadRadioButtonList6" 
                                                                                        runat="server" 
                                                                                        Direction="Horizontal" 
                                                                                        SelectedIndex="0" 
                                                                                        SelectedValue="0" 
                                                                                        SkinID="Bootstrap"
                                                                                        Width="128px" 
                                                                                        Skin="WebBlue" 
                                                                                        AutoPostBack="false">
                                                                <Items>
                                                                    <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                    <telerik:ButtonListItem Text="Não" Value="N" />
                                                                </Items>
                                                            </telerik:RadRadioButtonList>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Quantas vezes? </label>
                                                            <br />
                                                            <telerik:RadNumericTextBox ID="txtNumeroTentativasSuicidio"
                                                                                        runat="server" 
                                                                                        Skin="Bootstrap"
                                                                                        MinValue="0"
                                                                                        ShowSpinButtons="false"
                                                                                        Width="60px"
                                                                                        NumberFormat-DecimalDigits="0" 
                                                                                        Value="0"
                                                                                        MaxLength="2">
															</telerik:RadNumericTextBox>         
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>
                                                    <!---->
                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">
                                                    <!---->
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Quando foi a tentativa? </label>
                                                            <input id="txtQuandoTentouSuicidio" type="text" name="txtQuandoTentouSuicidio" class="form-control" placeholder="Quando tentou suicídio" required="" >
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Como foi a tentativa? </label>
                                                            <input id="txtDescricaoTentativaSuicidio" type="text" name="txtDescricaoTentativaSuicidio" class="form-control" placeholder="Como foi a tentativa de suicídio" required="" >
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>
                                                    <!---->
                                                </div>
                                            </div>

                                        </form>

                                    </div>
                                    <div class="tab-pane fade" id="tabTestemunho">
                                        <!-- BEGIN -->
                                        <form id="contact-formInfoTestemunho" role="form">

                                            <legend>Testemunho</legend>

                                            <div class="controls">

                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                        <label for="form_name">Resumo do Testemunho </label>
                                                        <telerik:RadEditor ID="textoTestemunho"
                                                                            runat="server"
                                                                            Height="300px"
                                                                            Width="780px" 
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
                                                        <div class="help-block with-errors"></div>
                                                    </div>
                                                </div>

                                            </div>

                                        </form>

                                        <!-- END -->
                                    </div>
                                    <div class="tab-pane fade" id="tabSugestao">

                                        <form id="contact-formSugestao" role="form">

                                            <legend>Sugestões para o trabalho da FJU</legend>

                                            <div class="controls">

                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                        <label for="form_name">Texto da Sugestão </label>
                                                        <telerik:RadEditor ID="textoSugestao"
                                                                            runat="server"
                                                                            Height="300px"
                                                                            Width="780px" 
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
                                                        <div class="help-block with-errors"></div>
                                                    </div>
                                                </div>

                                            </div>

                                        </form>

                                    </div>

                                </div>
                            </div>
                        </div>                        

                    </telerik:RadWizardStep>
                    
                    <telerik:RadWizardStep id="stepTeste"
                                           runat="server" 
                                           StepType="Step" 
                                           CausesValidation="true">
                        

                        <div class="panel with-nav-tabs panel-info">
                                <div class="panel-heading">
                                        <ul class="nav nav-tabs">
                                            <li class="active"><a href="#tab1infoIURD" data-toggle="tab">IURD</a></li>
                                            <li><a href="#tab2infoFJU" data-toggle="tab">FJU</a></li>                                           
                                            <li><a href="#tab2infoIntellimen" data-toggle="tab">Intellimen</a></li>
                                        </ul>
                                </div>
                                <div class="panel-body">
                                    <div class="tab-content">

                                        <div class="tab-pane fade in active" id="tab1infoIURD">
                                            <!-- BEGIN -->
                                            <form id="contact-formIURD" role="form">

                                                <legend>IURD</legend>

                                                <div class="controls">                                                

                                                    <!-- -->
                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Obreiro? *</label>
                                                                <telerik:RadRadioButtonList ID="rbEhObreiro" 
                                                                                            runat="server" 
                                                                                            Text="Sim" 
                                                                                            Skin="Bootstrap"
                                                                                            Direction="Horizontal" 
                                                                                            SelectedIndex="0" 
                                                                                            SelectedValue="0" 
                                                                                            AutoPostBack="false"
                                                                                            Width="131px" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="Sim" Value="0" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Tempo de Obreiro( Quantos anos / Quantos meses ) </label>
                                                                <br />
                                                                <!-- begin teste-->
                                                                <telerik:RadNumericTextBox ID="txtAnosEhObreiro"
                                                                                                   runat="server" 
                                                                                                   Skin="Bootstrap"
                                                                                                   MinValue="0"
                                                                                                   ShowSpinButtons="false"
                                                                                                   Width="45px"
                                                                                                   NumberFormat-DecimalDigits="0" 
                                                                                                   Value="0"
                                                                                                   MaxLength="2">
																        </telerik:RadNumericTextBox>
                                                                        <telerik:RadNumericTextBox ID="txtMesesEhObreiro"
                                                                                                   runat="server" 
                                                                                                   Skin="Bootstrap"
                                                                                                   Width="45px"
                                                                                                    ShowSpinButtons="false"
                                                                                                   MinValue="0"
                                                                                                   MaxValue="12"
                                                                                                   Value="0"
                                                                                                   NumberFormat-DecimalDigits="0"
                                                                                                   MaxLength="2">
                                                                        </telerik:RadNumericTextBox>
                                                                <!-- end teste-->
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>
                                                        <!---->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Colaborador? *</label>
                                                                <telerik:RadRadioButtonList ID="RadRadioButtonList1" 
                                                                                            runat="server" 
                                                                                            Text="Sim" 
                                                                                            Skin="Bootstrap"
                                                                                            Direction="Horizontal" 
                                                                                            SelectedIndex="0" 
                                                                                            SelectedValue="0" 
                                                                                            AutoPostBack="false"
                                                                                            Width="131px" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="Sim" Value="0" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Tempo de Colaborador( Quantos anos / Quantos meses ) </label>
                                                                <br />
                                                                <telerik:RadNumericTextBox ID="txtAnosEhColaborador"
                                                                                            runat="server" 
                                                                                            Skin="Bootstrap"
                                                                                            MinValue="0"
                                                                                            ShowSpinButtons="false"
                                                                                            Width="45px"
                                                                                            NumberFormat-DecimalDigits="0" 
                                                                                            Value="0"
                                                                                            MaxLength="2">
															    </telerik:RadNumericTextBox>                                                                
                                                                <telerik:RadNumericTextBox ID="txtMesesEhColaborador"
                                                                                            runat="server" 
                                                                                            Skin="Bootstrap"
                                                                                            Width="45px"
                                                                                            ShowSpinButtons="false"
                                                                                            MinValue="0"
                                                                                            MaxValue="12"
                                                                                            Value="0"
                                                                                            NumberFormat-DecimalDigits="0"
                                                                                            MaxLength="2">
                                                                </telerik:RadNumericTextBox>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>
                                                        <!---->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">CPO( Curso preparatório de Obreiros )? </label>
                                                                <telerik:RadRadioButtonList ID="RBCursandoCPO" 
                                                                                            runat="server" 
                                                                                            Text="Sim" 
                                                                                            Skin="Bootstrap"
                                                                                            Direction="Horizontal" 
                                                                                            SelectedIndex="0" 
                                                                                            SelectedValue="0" 
                                                                                            AutoPostBack="false"
                                                                                            Width="100px" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="Sim" Value="0" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Tempo no CPO( Quantos anos / Quantos meses ) </label>
                                                                <br />
                                                                <telerik:RadNumericTextBox ID="txtAnosInicioCPO2"
                                                                                                   runat="server" 
                                                                                                   Skin="Bootstrap"
                                                                                                   Width="45px"
                                                                                                   NumberFormat-DecimalDigits="0"
                                                                                                   MaxLength="2"
                                                                                                   MinValue="0"
                                                                                                   Value="0">
                                                                        </telerik:RadNumericTextBox>         
																        <telerik:RadNumericTextBox ID="txtMesesInicioCPO"
                                                                                                   runat="server" 
                                                                                                   Skin="Bootstrap"
                                                                                                   Width="45px"
                                                                                                   NumberFormat-DecimalDigits="0"
                                                                                                   MaxLength="2"
                                                                                                   MinValue="0"
                                                                                                   MaxValue="12"
                                                                                                   Value="0">
                                                                        </telerik:RadNumericTextBox>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>
                                                        <!---->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Já foi obreiro antes? </label>
                                                                <telerik:RadRadioButtonList ID="rbJaFoiObreiroAntes" 
                                                                                            runat="server" 
                                                                                            Direction="Horizontal" 
                                                                                            SelectedIndex="0" 
                                                                                            SelectedValue="0" 
                                                                                            SkinID="Bootstrap"
                                                                                            Width="128px" 
                                                                                            Skin="WebBlue" 
                                                                                            AutoPostBack="false">
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                        <telerik:ButtonListItem Text="Não" Value="N" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Se sim, saiu porque? </label>
                                                                <input id="txtMotivoSaidaObreiro2" type="text" name="txtMotivoSaidaObreiro" class="form-control" placeholder="Por favor informe motivo saída de obreiro" required="" >
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>                                        
                                                        <!---->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Já foi Pastor/Esposa antes? </label>
                                                                <telerik:RadRadioButtonList ID="rbJaFoiPastoEsposaAntes" 
                                                                                            runat="server" 
                                                                                            Direction="Horizontal" 
                                                                                            SelectedIndex="0" 
                                                                                            SelectedValue="0" 
                                                                                            SkinID="Bootstrap"
                                                                                            Width="128px" 
                                                                                            Skin="WebBlue" 
                                                                                            AutoPostBack="false">
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                        <telerik:ButtonListItem Text="Não" Value="N" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Se sim, saiu porque? </label>
                                                                <input id="txtMotivoSaidaPastorEsposa2" type="text" name="txtMotivoSaidaPastorEsposa" class="form-control" placeholder="Por favor informe motivo saída de pastor/esposa" required="" >
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>
                                                        <!---->
                                                    </div>

                                                </div>

                                            </form>
                                            <!-- END -->
                                        </div>
                                        <div class="tab-pane fade" id="tab2infoFJU">
                                            <!-- BEGIN -->
                                            <form id="contact-formInfoFJU" role="form">

                                                <legend>FJU</legend>

                                                <div class="controls">
                                                    <!---->
                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Membro da Força Jovem Universal ?</label>
                                                                <br />
                                                                <span class="button-checkbox">
                                                                    <button type="button" id="chkMembroFJU2" name="chkMembroFJU" class="btn" data-color="primary">Sim</button>
                                                                    <input type="checkbox" class="hidden"  />
                                                                </span>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Coordenador da Força Jovem?</label>   
                                                                <br />
                                                                <span class="button-checkbox">
                                                                    <button type="button" id="chkEhCoordenadorFJU2" name="chkEhCoordenadorFJU" class="btn" data-color="primary">Sim</button>
                                                                    <input type="checkbox" class="hidden"  />
                                                                </span>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>


                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Desde quando?( Quantos anos / Quantos meses ) </label>
                                                                <br />
                                                                <telerik:RadNumericTextBox ID="txtAnosInicioCoordenacaoFJU"
                                                                                                   runat="server" 
                                                                                                   Skin="Bootstrap"
                                                                                                   Width="45px"
                                                                                                   NumberFormat-DecimalDigits="0"
                                                                                                   MaxLength="2"
                                                                                                   MinValue="0"
                                                                                                   Value="0">
                                                                        </telerik:RadNumericTextBox>         
																        <telerik:RadNumericTextBox ID="txtMesesInicioCoordenacaoFJU"
                                                                                                   runat="server" 
                                                                                                   Skin="Bootstrap"
                                                                                                   Width="45px"
                                                                                                   NumberFormat-DecimalDigits="0"
                                                                                                   MaxLength="2"
                                                                                                   MinValue="0"
                                                                                                   MaxValue="12"
                                                                                                   Value="0">
                                                                        </telerik:RadNumericTextBox>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>
                                                        <!---->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Líder de Tribo ?</label>
                                                                <br />
                                                                <span class="button-checkbox">
                                                                    <button type="button" id="chkLiderTribo" name="chkLiderTribo" class="btn" data-color="primary">Sim</button>
                                                                    <input type="checkbox" class="hidden"  />
                                                                </span>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Qual Tribo ?</label>
                                                                <br />
                                                                <telerik:RadDropDownList ID="cboTribos22"                                                                     
                                                                                         runat="server" 
                                                                                         Skin="Bootstrap" 
                                                                                         Height="16px" Width="120px">
                                                                </telerik:RadDropDownList>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Há quanto tempo?( Quantos anos / Quantos meses ) </label>
                                                                <br />
                                                                <telerik:RadNumericTextBox ID="txtAnosInicioCoordenacaoTribo"
                                                                                                   runat="server" 
                                                                                                   Skin="Bootstrap"
                                                                                                   Width="45px"
                                                                                                   NumberFormat-DecimalDigits="0"
                                                                                                   MaxLength="2"
                                                                                                   MinValue="0"
                                                                                                   Value="0">
                                                                        </telerik:RadNumericTextBox>         
																        <telerik:RadNumericTextBox ID="txtMesesInicioCoordenacaoTribo"
                                                                                                   runat="server" 
                                                                                                   Skin="Bootstrap"
                                                                                                   Width="45px"
                                                                                                   NumberFormat-DecimalDigits="0"
                                                                                                   MaxLength="2"
                                                                                                   MinValue="0"
                                                                                                   MaxValue="12"
                                                                                                   Value="0">
                                                                        </telerik:RadNumericTextBox>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>
                                                        <!---->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!-- -->                                                    
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Líder de Projeto ?</label>
                                                                <br />
                                                                <span class="button-checkbox">
                                                                    <button type="button" id="chkLiderProjeto2" name="chkLiderProjeto" class="btn" data-color="primary">Sim</button>
                                                                    <input type="checkbox" class="hidden"  />
                                                                </span>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Qual Projeto ?</label>
                                                                <br />
                                                                <telerik:RadDropDownList ID="cboProjetoFJU22"                                                                     
                                                                                         runat="server" 
                                                                                         Skin="Bootstrap" 
                                                                                         Height="16px" Width="120px">
                                                                </telerik:RadDropDownList>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Há quanto tempo?( Quantos anos / Quantos meses ) </label>
                                                                <br />
                                                                <telerik:RadNumericTextBox ID="txtAnosInicioCoordenacaoProjeto"
                                                                                                   runat="server" 
                                                                                                   Skin="Bootstrap"
                                                                                                   Width="45px"
                                                                                                   NumberFormat-DecimalDigits="0"
                                                                                                   MaxLength="2"
                                                                                                   MinValue="0"
                                                                                                   Value="0">
                                                                        </telerik:RadNumericTextBox>         
																        <telerik:RadNumericTextBox ID="txtMesesInicioCoordenacaoProjeto"
                                                                                                   runat="server" 
                                                                                                   Skin="Bootstrap"
                                                                                                   Width="45px"
                                                                                                   NumberFormat-DecimalDigits="0"
                                                                                                   MaxLength="2"
                                                                                                   MinValue="0"
                                                                                                   MaxValue="12"
                                                                                                   Value="0">
                                                                        </telerik:RadNumericTextBox>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>
                                                        <!-- -->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Tem desejo de ser obreiro ? </label>
                                                                <telerik:RadRadioButtonList ID="rbDesejaSerObreiro" 
                                                                                            runat="server" 
                                                                                            Direction="Horizontal" 
                                                                                            SelectedIndex="0" 
                                                                                            SelectedValue="0" 
                                                                                            SkinID="Bootstrap"
                                                                                            Width="128px" 
                                                                                            Skin="WebBlue" 
                                                                                            AutoPostBack="false">
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                        <telerik:ButtonListItem Text="Não" Value="N" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Porque? </label>
                                                                <input id="txtMotivoDesejaSErObreiro2" type="text" name="txtMotivoDesejaSErObreiro" class="form-control" placeholder="Por favor informe motivo do desejo de ser obreiro" required="" >
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>                                        
                                                        <!---->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Tem desejo de fazer a obre no altar? </label>
                                                                <telerik:RadRadioButtonList ID="rbDesejaFazerObraAltar" 
                                                                                            runat="server" 
                                                                                            Direction="Horizontal" 
                                                                                            SelectedIndex="0" 
                                                                                            SelectedValue="0" 
                                                                                            SkinID="Bootstrap"
                                                                                            Width="128px" 
                                                                                            Skin="WebBlue" 
                                                                                            AutoPostBack="false">
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                        <telerik:ButtonListItem Text="Não" Value="N" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Esta no Altar Jovem? </label>
                                                                <telerik:RadRadioButtonList ID="rbEstaNoAltarJovem" 
                                                                                            runat="server" 
                                                                                            Direction="Horizontal" 
                                                                                            SelectedIndex="0" 
                                                                                            SelectedValue="0" 
                                                                                            SkinID="Bootstrap"
                                                                                            Width="128px" 
                                                                                            Skin="WebBlue" 
                                                                                            AutoPostBack="false">
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                        <telerik:ButtonListItem Text="Não" Value="N" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>                                        
                                                        <!---->
                                                    </div>
                                                    <!---->
                                                </div>

                                            </form>

                                            <!-- END -->
                                        </div>
                                        <div class="tab-pane fade" id="tab2infoIntellimen">
                                            <!-- BEGIN -->
                                            <form id="contact-formInfoIntellimen" role="form">

                                                <legend>Intellimen</legend>

                                                <div class="controls">
                                                    <!---->
                                                    <div class="row">
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Faz parte do intellimen ? </label>
                                                                <telerik:RadRadioButtonList ID="rbFazParteIntellimen" 
                                                                                            runat="server" 
                                                                                            Direction="Horizontal" 
                                                                                            SelectedIndex="0" 
                                                                                            SelectedValue="0" 
                                                                                            SkinID="Bootstrap"
                                                                                            Width="128px" 
                                                                                            Skin="WebBlue" 
                                                                                            AutoPostBack="false">
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                        <telerik:ButtonListItem Text="Não" Value="N" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Completou os desáfios ? </label>
                                                                <telerik:RadRadioButtonList ID="rbCompletouDesafios" 
                                                                                            runat="server" 
                                                                                            Direction="Horizontal" 
                                                                                            SelectedIndex="0" 
                                                                                            SelectedValue="0" 
                                                                                            SkinID="Bootstrap"
                                                                                            Width="128px" 
                                                                                            Skin="WebBlue" 
                                                                                            AutoPostBack="false">
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="Sim" Value="S" />
                                                                        <telerik:ButtonListItem Text="Não" Value="N" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Está em qual ? </label>
                                                                <br />
                                                                <telerik:RadNumericTextBox ID="txtNumeroDesafioIntellimen"
                                                                                           runat="server" 
                                                                                           Skin="Bootstrap"
                                                                                           Width="45px"
                                                                                           ShowSpinButtons="false"
                                                                                           MinValue="0"
                                                                                           MaxValue="53"
                                                                                           Value="0"
                                                                                           NumberFormat-DecimalDigits="0"
                                                                                           MaxLength="2">
                                                                </telerik:RadNumericTextBox>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>                                                
                                                
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Qual o nome do seu parceiro</label>
                                                                <input id="txtNomeParceiroIntellimen" type="text" name="txtNomeParceiroIntellimen" class="form-control" placeholder="Por favor informe seu nome *" required="" >
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Telefone</label>
                                                                <br>
                                                                <telerik:RadMaskedTextBox RenderMode="Lightweight" 
                                                                                          ID="txtTelefoneParceiroIntellimen" 
                                                                                          runat="server" 
                                                                                          Mask="(##) #####-####" 
                                                                                          Width="150px"                                                                        
                                                                                          Skin="Bootstrap"
                                                                                          ValidationGroup="Group1">
                                                                </telerik:RadMaskedTextBox>
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>
                                                        <!---->
                                                    </div>
                                                    <!---->
                                                </div>

                                            </form>

                                        </div>
                                        <!-- END -->
                                    </div>
                                </div>                            
                        </div>

                    </telerik:RadWizardStep>

                </WizardSteps>

            </telerik:RadWizard>


        </div>

    </div>

</asp:Content>
