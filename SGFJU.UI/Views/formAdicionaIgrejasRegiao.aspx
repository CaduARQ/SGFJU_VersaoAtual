<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formAdicionaIgrejasRegiao.aspx.cs" Inherits="SGFJU.UI.Views.formAdicionaIgrejasRegiao" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register assembly="Telerik.Web.Design" namespace="Telerik.Web.Design" tagprefix="design" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>

    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>    
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>

    <script language="javascript" type="text/javascript">
            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow;
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
                return oWindow;
            };

            function CloseWindow(button, args) {
                var currentWindow = GetRadWindow();

                alert("Igrejas cadastradas com sucesso!!!");

                currentWindow.close();
            }
        </script>

    <div class="container-fluid bg-light py-3">

        <form id="contactform" runat="server">            


	<telerik:RadWindowManager ID="rwmUIApp" Skin="WebBlue" runat="server" />
    <telerik:RadAjaxManager runat="Server" 
                                ID="RadAjaxManager1" >
            <AjaxSettings>                            
			    
                <telerik:AjaxSetting AjaxControlID="btnAdicionarIgreja">
				    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cboRegiaoSelecionada" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="grdIgrejasRegiao" LoadingPanelID="RadAjaxLoadingPanel1" />
				    </UpdatedControls>
			    </telerik:AjaxSetting>

                <telerik:AjaxSetting AjaxControlID="btnCadastraIgreja">
				    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cboRegiaoSelecionada" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="grdIgrejasRegiao" LoadingPanelID="RadAjaxLoadingPanel1" />
				    </UpdatedControls>
			    </telerik:AjaxSetting>

            </AjaxSettings>
        </telerik:RadAjaxManager>
        
        <telerik:RadAjaxLoadingPanel runat="server" ID="RadAjaxLoadingPanel1" >
	    </telerik:RadAjaxLoadingPanel>

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                <Scripts>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                    </asp:ScriptReference>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                    </asp:ScriptReference>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                    </asp:ScriptReference>
                </Scripts>
            </telerik:RadScriptManager>

            <legend>Cadastro das igrejas da Região selecionada</legend>

            <div class="controls">

                <div class="row">

                    <div class="col-sm-4">
                        <div class="form-group">
                            <label for="form_name">Região selecionada</label>
                            <br />
                            <telerik:RadComboBox ID="cboRegiaoSelecionada" 
                                                 runat="server" 
                                                 Height="100px" 
                                                 Skin="Bootstrap" 
                                                 Width="280px" Culture="pt-BR"></telerik:RadComboBox>
                            <div class="help-block with-errors"></div>
                        </div>

                        <div class="form-group">
                            <label for="form_name">Nome da igreja*</label>
                            <input id="txtNomeIgreja" type="text" name="txtNomeIgreja" class="form-control" placeholder="Por favor informe o nome da igreja, depois clique no botão adicionar igreja." >
                            <div class="help-block with-errors"></div>
                        </div>

                    </div>

                </div>

                <div class="clearfix"></div>

                <div class="row">

                    <div class="col-md-8">
                        <telerik:RadButton ID="btnAdicionarIgreja" runat="server" Skin="WebBlue" Text="Adicionar Igreja" OnClick="btnAdicionarIgreja_Click"  />
                        <telerik:RadButton ID="btnCadastraIgreja" runat="server" Skin="WebBlue" Text="Salvar Igrejas" OnClick="btnCadastraIgreja_Click"  />
                        
                    </div>

                    <div class="col-md-8">
                        <%--<telerik:RadButton ID="btnCadastraIgreja" runat="server" Skin="Bootstrap" Text="Cadastrar Igreja" OnClick="btnCadastraIgreja_Click"  />--%>
                        
                    </div>

                </div>

                <div class="clearfix"></div>

                <div class="row">
                    
                     <telerik:RadGrid runat="server" 
                                        ID="grdIgrejasRegiao" 
                                        AutoGenerateColumns="False" 
                                        Height="200px"
                                        Skin="Bootstrap"
                                        EnableViewState="False" 
                                        AllowPaging="True" 
                                        Culture="pt-BR" 
                                        PageSize="4" OnNeedDataSource="grdIgrejasRegiao_NeedDataSource" OnPageIndexChanged="grdIgrejasRegiao_PageIndexChanged" >
                        <GroupingSettings ShowUnGroupButton="true"></GroupingSettings>
                            <ExportSettings>
                                <Pdf PageWidth="">
                                </Pdf>
                            </ExportSettings>
                        <ClientSettings 
                                        EnableRowHoverStyle="true" 
                                        AllowKeyboardNavigation="false">
                            <Scrolling AllowScroll="false" UseStaticHeaders="true" />
                        </ClientSettings>
                        <MasterTableView PageSize="5" NoMasterRecordsText="Sem registros para exibir.">
                            <CommandItemSettings ShowAddNewRecordButton="False" ShowRefreshButton="False" />
                            <Columns>                                                                
                                <telerik:GridBoundColumn DataField="NomeIgreja" UniqueName="NomeIgreja" HeaderText="Nome da Igreja" ItemStyle-CssClass="subject" >
                                    <ItemStyle Width="250px" CssClass="subject"></ItemStyle>
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>

                </div>

            </div>

        </form>

    </div>

    
</body>
</html>
