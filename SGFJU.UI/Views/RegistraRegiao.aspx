<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistraRegiao.aspx.cs" Inherits="SGFJU.UI.Views.RegistraRegiao" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register assembly="Telerik.Web.Design" namespace="Telerik.Web.Design" tagprefix="design" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
    <link href="../Styles/UI_App.css" rel="stylesheet" />
    <link href="../Styles/mail.css" rel="stylesheet" />


    <link href="../Styles/UI_App.css" rel="stylesheet" /> 
        <script language="javascript" type="text/javascript">
            function AtualizarRegiao(idRegiao, nomeRegiao) {
                //alert(idRegiao);
                wnd = $find("<%=rwmUIApp.ClientID %>").open('formAtualizaRegiao.aspx?idRegiao=' + idRegiao + '&nomeRegiao=' + nomeRegiao, null, null, 720, 615);
                wnd.set_title('Atualizar Regiao');
                wnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close);
                wnd.add_close(OnClientClose);
                wnd.set_modal(true);
            }

            function OnClientClose(oWnd, args) {                
                var arg = args.get_argument();
                if (arg) {
                    location.href = "RegistraRegiao.aspx";
                }
            }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FolderContent" runat="server">           
    <nav:FolderNavigationControl runat="server" ID="FolderNavigationControl" />
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
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
            <telerik:AjaxSetting AjaxControlID="grdTodasRegioes">
				<UpdatedControls>					    
                    <telerik:AjaxUpdatedControl ControlID="cboEstado" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="cboBloco" LoadingPanelID="RadAjaxLoadingPanel1" />
				</UpdatedControls>
			</telerik:AjaxSetting>

            <telerik:AjaxSetting AjaxControlID="btnCadastraRegiao">
				<UpdatedControls>					    
                    <telerik:AjaxUpdatedControl ControlID="cboEstado" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="cboBloco" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdTodasRegioes" LoadingPanelID="RadAjaxLoadingPanel1" />
				</UpdatedControls>
			</telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>

    <telerik:RadAjaxLoadingPanel runat="server" ID="RadAjaxLoadingPanel1" >
	    </telerik:RadAjaxLoadingPanel>

    <telerik:RadWindowManager ID="rwmUIApp" Skin="WebBlue" runat="server" />

    <form class="form-horizontal">

        <legend>Informações sobre Nova Região </legend>

        <div class="form-group">
            <label class="col-md-4 control-label" for="nomeRegiao">Nome Da nova Região</label>  
            <div class="col-md-8">
                <input id="nomeRegiao" name="nomeRegiao" type="text" placeholder="Nome da Região" class="form-control input-md" required="">
                <span class="help-block">Insira o nome da Região</span>  
            </div>
        </div>

        <div class="form-group">
            <label class="col-md-4 control-label" for="nomeRegiao">Estado</label>  
            <div class="col-md-8">
                <telerik:RadComboBox ID="cboEstado" 
                                    runat="server" 
                                    AutoPostBack="true" 
                                    Height="100px" 
                                    OnSelectedIndexChanged="cboEstado_SelectedIndexChanged"
                                    Skin="Bootstrap" 
                                    Width="280px" />
                <span class="help-block">Selecione o estado, logo em seguida bloco à qual região pertence</span>  
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
                                     Width="280px"></telerik:RadComboBox>
                <span class="help-block">Selecione o bloco, à qual região pertence</span>  
            </div>
        </div>

        <div class="form-group">            
            <div class="col-md-8">
                <telerik:RadButton ID="btnCadastraRegiao" runat="server" Skin="Bootstrap" Text="Cadastrar Região" OnClick="btnCadastraRegiao_Click" />
                <br />
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
                                OnPageIndexChanged="grdTodasRegioes_PageIndexChanged" 
                                PageSize="7" 
                                OnNeedDataSource="grdTodasRegioes_NeedDataSource"               >
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
                        <telerik:GridBoundColumn DataField="BlocoRegiao.EstadoBloco.NomeEstado" UniqueName="Nome" HeaderText="Estado" HeaderStyle-Width="200px" >
                            <HeaderStyle Width="200px"></HeaderStyle>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="BlocoRegiao.NomeBloco" UniqueName="BlocoRegiao.NomeBloco" HeaderText="Bloco" HeaderStyle-Width="200px" >
                            <HeaderStyle Width="200px"></HeaderStyle>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NomeRegiao" UniqueName="NomeRegiao" HeaderText="Nome da Região" ItemStyle-CssClass="subject" >
                            <ItemStyle Width="300px" CssClass="subject"></ItemStyle>
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn HeaderText="Atualizar">
                            <ItemStyle Width="200px" HorizontalAlign="Center"></ItemStyle>
                            <ItemTemplate>
                                <img src="../images/delete_inbox.gif" width="30px" height="30px"  onclick="AtualizarRegiao(' <%# Eval("Id") %> ' , ' <%# Eval("NomeRegiao") %> ' )" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
            </div>
        </div>

    </form>

</asp:Content>
