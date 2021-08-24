<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmVisualizarIgrejas.aspx.cs" Inherits="SGFJU.UI.Views.frmVisualizarIgrejas" %>

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

            <legend>Igrejas da Região </legend>

            <div class="controls">

                <div class="row">

                    <div class="col-sm-4">
                        <div class="form-group">
                            <label for="form_name">Região selecionada</label>
                            <br />
                            <telerik:RadLabel ID="lblNomeRegiao" Skin="Bootstrap" runat="server" ></telerik:RadLabel>
                            <div class="help-block with-errors"></div>
                        </div>
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
                                        PageSize="5" OnNeedDataSource="grdIgrejasRegiao_NeedDataSource" OnPageIndexChanged="grdIgrejasRegiao_PageIndexChanged"  >
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
                        <MasterTableView NoMasterRecordsText="Sem registros para exibir..">
                            <CommandItemSettings ShowAddNewRecordButton="False" ShowRefreshButton="False"  />
                            <RowIndicatorColumn Visible="False">
                                <HeaderStyle Width="41px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Created="True">
                                <HeaderStyle Width="41px" />
                            </ExpandCollapseColumn>
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
