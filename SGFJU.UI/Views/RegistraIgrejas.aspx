<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistraIgrejas.aspx.cs" Inherits="SGFJU.UI.Views.RegistraIgrejas" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register assembly="Telerik.Web.Design" namespace="Telerik.Web.Design" tagprefix="design" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/UI_App.css" rel="stylesheet" /> 

    <script language="javascript" type="text/javascript">
        function AdicionarIgrejasDaRegiao(idRegiao) {
            //alert(idRegiao);
            wnd = $find("<%=rwmUIApp.ClientID %>").open('formAdicionaIgrejasRegiao.aspx?IdRegiao=' + idRegiao, null, null, 720, 615);
            wnd.set_title('Cadastrar Igrejas da Região');
            wnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close);
            wnd.set_modal(true);
        }

        function VisualizaIgrejasDaRegiao(idRegiao, nomeRegiao) {
            //alert(idRegiao);
            wnd = $find("<%=rwmUIApp.ClientID %>").open('frmVisualizarIgrejas.aspx?IdRegiao=' + idRegiao + '&nomeRegiao=' + nomeRegiao, null, null, 720, 500);
            wnd.set_title('Igrejas da Região ' + nomeRegiao);
            wnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close);
            wnd.set_modal(true);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FolderContent" runat="server">
    <nav:FolderNavigationControl runat="server" ID="FolderNavigationControl" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <%--<link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">--%>    
    <%--<script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>--%>
    <link href="../Styles/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>    
	
    <telerik:RadAjaxManager runat="Server" 
                            ID="RadAjaxManager1" >
        <AjaxSettings>                            			    
            <telerik:AjaxSetting AjaxControlID="cboEstado">
				<UpdatedControls>					    
                    <telerik:AjaxUpdatedControl ControlID="cboBloco" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdTodasRegioes" LoadingPanelID="RadAjaxLoadingPanel1" />
				</UpdatedControls>
			</telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cboBloco">
				<UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdTodasRegioes" LoadingPanelID="RadAjaxLoadingPanel1" />
				</UpdatedControls>
			</telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdTodasRegioes">
				<UpdatedControls>					    
                    <telerik:AjaxUpdatedControl ControlID="cboEstado" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="cboBloco" LoadingPanelID="RadAjaxLoadingPanel1" />
				</UpdatedControls>
			</telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>

    <telerik:RadAjaxLoadingPanel runat="server" ID="RadAjaxLoadingPanel1" >
	    </telerik:RadAjaxLoadingPanel>

    <telerik:RadWindowManager ID="rwmUIApp" Skin="WebBlue" runat="server" />


    <form class="form-horizontal">
        

        <legend>Cadastro de igrejas por Região </legend>

        <div class="form-group">
            <label class="col-md-4 control-label" for="nomeRegiao">Estado</label>  
            <div class="col-md-8">
                <telerik:RadComboBox ID="cboEstado" 
                                    runat="server" 
                                    AutoPostBack="true" 
                                    OnSelectedIndexChanged="cboEstado_SelectedIndexChanged"
                                    Skin="Bootstrap" 
                    Height="140px"
                                    Width="280px" />
                <span class="help-block">Selecione o estado, logo em seguida o bloco </span>  
            </div>
        </div>

        <div class="form-group">
            <label class="col-md-4 control-label" for="nomeRegiao">Bloco</label>  
            <br />
            <div class="col-md-8">
                <telerik:RadComboBox ID="cboBloco" 
                                     runat="server" 
                                     AutoPostBack="true" 
                                     Height="100px" 
                                     Skin="Bootstrap" 
                                     Width="280px" OnSelectedIndexChanged="cboBloco_SelectedIndexChanged"></telerik:RadComboBox>
                <span class="help-block">Selecione o bloco para listar regiões</span>  
            </div>
        </div>

        <div class="form-group">            
            <div class="col-md-8">                
                <%--<span class="help-block">Selecione o bloco, à qual região pertence</span>  --%>
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-8">
                <telerik:RadGrid runat="server" 
                                ID="grdTodasRegioes" 
                                AutoGenerateColumns="False" 
                                Skin="Bootstrap"
                                EnableViewState="False" 
                                AllowPaging="True" 
                                Culture="pt-BR" 
                                Width="800px"
                                PageSize="7" OnNeedDataSource="grdTodasRegioes_NeedDataSource" OnPageIndexChanged="grdTodasRegioes_PageIndexChanged"                >
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
                <MasterTableView>
                    <CommandItemSettings ShowAddNewRecordButton="False" ShowRefreshButton="False" />                    
                    <Columns>
                        <telerik:GridBoundColumn EmptyDataText="Id" UniqueName="Id" Visible="False"/>
                        <telerik:GridBoundColumn DataField="BlocoRegiao.EstadoBloco.NomeEstado" UniqueName="Nome" HeaderText="Estado" HeaderStyle-Width="200px" >
                            <HeaderStyle Width="200px"></HeaderStyle>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="BlocoRegiao.NomeBloco" UniqueName="BlocoRegiao.NomeBloco" HeaderText="Bloco" HeaderStyle-Width="200px" >
                            <HeaderStyle Width="200px"></HeaderStyle>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NomeRegiao" UniqueName="NomeRegiao" HeaderText="Nome da Região" ItemStyle-CssClass="subject" >
                            <ItemStyle Width="250px" CssClass="subject"></ItemStyle>
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn HeaderText="Visualizar Igrejas">
                            <ItemStyle Width="200px" HorizontalAlign="Center"></ItemStyle>
                            <ItemTemplate>
                                <img src="../images/search_60x60.gif" width="30px" height="30px"  onclick="VisualizaIgrejasDaRegiao(' <%# Eval("Id") %> ' , ' <%# Eval("NomeRegiao") %> ' )" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Cadastrar Igrejas">
                            <ItemStyle Width="200px" HorizontalAlign="Center"></ItemStyle>
                            <ItemTemplate>
                                <img src="../images/delete_inbox.gif" width="20px" height="20px"   onclick="AdicionarIgrejasDaRegiao(' <%# Eval("Id") %> ')" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                    
                </MasterTableView>
            </telerik:RadGrid>
            </div>
        </div>

    </form>


</asp:Content>
