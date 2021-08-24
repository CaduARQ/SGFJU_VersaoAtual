<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistraBlocos.aspx.cs" Inherits="SGFJU.UI.Views.PaginaTeste" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/UI_App.css" rel="stylesheet" /> 
        <script language="javascript" type="text/javascript">
            function AtualizarBloco(idBloco, nomeBloco) {
                //alert(idRegiao);
                wnd = $find("<%=rwmUIApp.ClientID %>").open('formAtualizaBloco.aspx?idBloco=' + idBloco + '&nomeBloco=' + nomeBloco, null, null, 720, 615);
                wnd.set_title('Atualizar Bloco');
                wnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close);
                wnd.add_close(OnClientClose);
                wnd.set_modal(true);
            }

            function OnClientClose(oWnd, args) {                
                var arg = args.get_argument();
                if (arg) {
                    location.href = "RegistraBlocos.aspx";
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
	
	<telerik:RadWindowManager ID="rwmUIApp" Skin="WebBlue" runat="server" />
    <telerik:RadAjaxManager runat="Server" 
                                ID="RadAjaxManager1" >
            <AjaxSettings>                            
			    
                <telerik:AjaxSetting AjaxControlID="btnCadastrBloco">
				    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cboEstado" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="grdTodosBlocos" LoadingPanelID="RadAjaxLoadingPanel1" />
				    </UpdatedControls>
			    </telerik:AjaxSetting>
                <%--<telerik:AjaxSetting AjaxControlID="grdTodosBlocos">
				    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cboEstado" LoadingPanelID="RadAjaxLoadingPanel1" />
				    </UpdatedControls>
			    </telerik:AjaxSetting>--%>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        
        <telerik:RadAjaxLoadingPanel runat="server" ID="RadAjaxLoadingPanel1" >
	    </telerik:RadAjaxLoadingPanel>

<form class="form-horizontal">

        <legend>Informações sobre Novo Bloco </legend>

        <div class="form-group">
            <label class="col-md-4 control-label" for="nomeBloco">Bloco:</label>  
            <div class="col-md-8">
                <input id="nomeBloco" name="nomeBloco" type="text" placeholder="Nome do Bloco" class="form-control input-md" required="">
                <span class="help-block">Insira o nome do Bloco</span>  
            </div>
        </div>

        <div class="form-group">
            <label class="col-md-4 control-label" for="nomeRegiao">Estado</label>  
            <div class="col-md-8">
                <telerik:RadComboBox ID="cboEstado" 
                                    runat="server" 
                                    AutoPostBack="false" 
                                    Height="100px" 
                                    Skin="Bootstrap" 
                                    Width="280px" />
                <span class="help-block">Selecione o estado à qual bloco pertence</span>  
            </div>
        </div>

        <div class="form-group">            
            <div class="col-md-8">
                <telerik:RadButton ID="btnCadastraBloco" runat="server" Skin="Bootstrap" Text="Cadastrar Bloco" OnClick="btnCadastrBloco_Click1" />
                <%--<span class="help-block">Selecione o bloco, à qual região pertence</span>  --%>
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-8">
                <telerik:RadGrid runat="server" 
                                    ID="grdTodosBlocos" 
                                    AutoGenerateColumns="False" 
                                    Skin="Bootstrap"
                                    EnableViewState="False" 
                                    AllowPaging="True" 
                                    Culture="pt-BR" 
                                    PageSize="7" 
                                    OnPageIndexChanged="grdTodosBlocos_PageIndexChanged" 
                                    OnNeedDataSource="grdTodosBlocos_NeedDataSource">
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
                    <MasterTableView PageSize="7">
                        <CommandItemSettings ShowAddNewRecordButton="False" ShowRefreshButton="False" />
                        <Columns>
                            <telerik:GridBoundColumn EmptyDataText="Id" UniqueName="Id" Visible="False"/>
                            <telerik:GridBoundColumn DataField="EstadoBloco.NomeEstado" UniqueName="Nome" HeaderText="Estado" HeaderStyle-Width="200px" >
                                <HeaderStyle Width="200px"></HeaderStyle>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NomeBloco" UniqueName="IgrejaAQualJovemPertence.NomeIgreja" HeaderText="Nome do Bloco" ItemStyle-CssClass="subject" >
                                <ItemStyle CssClass="subject"></ItemStyle>
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Atualizar">
                                <ItemStyle Width="200px" HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <img src="../images/delete_inbox.gif" width="30px" height="30px"  onclick="AtualizarBloco(' <%# Eval("Id") %> ' , ' <%# Eval("NomeBloco") %> ' )" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </div>
        </div>

    </form>
    
</asp:Content>
