<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListaTodosJovens.aspx.cs" Inherits="SGFJU.UI.Views.ListaTodosJovens" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register assembly="Telerik.Web.Design" namespace="Telerik.Web.Design" tagprefix="design" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/mail.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../Styles/newMail.css" />

    <style type="text/css">
        html .RadGrid .rgMasterTable {
            height: auto;
        }

        .subject {
            position: relative;
        }


    </style>

    <script language="javascript" type="text/javascript">

        function corrigirDadosJovem(idJovem) {
            //alert(idRegiao);
            wnd = $find("<%=rwmUIApp.ClientID %>").open('frmCorrigeErros.aspx?IdJovem=' + idJovem , null, null, 800, 280);
            wnd.set_title('Correção dos dados do Jovem ' + nomeJovem);
            wnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close);
            wnd.set_modal(true);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FolderContent" runat="server">    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">    
    <telerik:RadNavigation runat="server" Skin="Vista" CssClass="secondaryMenu">
        <Nodes>
            <telerik:NavigationNode Text="Novo Jovem" SpriteCssClass="icon icon-Send" NavigateUrl="RegistraJovem.aspx" ></telerik:NavigationNode>
        </Nodes>
    </telerik:RadNavigation>

    <telerik:RadWindowManager ID="rwmUIApp" Skin="WebBlue" runat="server" />

    <div class="scroller">

        
        <div class="editorWrapper">
            <telerik:RadGrid runat="server" 
                             ID="grdTodosJovens" 
                             AutoGenerateColumns="False" 
                             Height="100%"
                             EnableViewState="False" 
                             AllowPaging="True"                
                             AllowSorting="True" 
                             ShowGroupPanel="True" Culture="pt-BR" PageSize="12" 
                             OnNeedDataSource="grdTodosJovens_NeedDataSource" 
                             OnPageIndexChanged="grdTodosJovens_PageIndexChanged">
                <GroupingSettings ShowUnGroupButton="true"></GroupingSettings>
                <ExportSettings>
                    <Pdf PageWidth="">
                    </Pdf>
                </ExportSettings>
                <ClientSettings AllowDragToGroup="true" 
                                EnableRowHoverStyle="true" 
                                AllowKeyboardNavigation="false">
                    <Scrolling AllowScroll="false" UseStaticHeaders="true" />
                    <Selecting AllowRowSelect="true" />
                </ClientSettings>
                <MasterTableView>                    
                    <Columns>
                        <telerik:GridBoundColumn EmptyDataText="IdJovem" UniqueName="IdJovem" Visible="False"/>
                        <telerik:GridBoundColumn DataField="NomeEstado" UniqueName="NomeEstado" HeaderText="Estado" ItemStyle-CssClass="subject" >
                            <ItemStyle CssClass="subject"></ItemStyle>
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="NomeBlocoJovem" UniqueName="NomeBlocoJovem" HeaderText="Bloco" ItemStyle-CssClass="subject" >
                            <ItemStyle CssClass="subject"></ItemStyle>
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="NomeRegiaoJovem" UniqueName="NomeRegiaoJovem" HeaderText="Região" ItemStyle-CssClass="subject" >
                            <ItemStyle CssClass="subject"></ItemStyle>
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="NomeIgrejaJovem" UniqueName="NomeIgrejaJovem" HeaderText="Igreja" ItemStyle-CssClass="subject" >
                            <ItemStyle CssClass="subject"></ItemStyle>
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="NomeJovem" UniqueName="NomeJovem" HeaderText="Nome" HeaderStyle-Width="200px" >
                            <HeaderStyle Width="200px"></HeaderStyle>
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="DataNascimento" UniqueName="DataNascimento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Data de Nascimento"  >
                            <HeaderStyle Width="200px"></HeaderStyle>
                        </telerik:GridBoundColumn>
                        
                        <telerik:GridTemplateColumn HeaderText="Corrigir Dados">
                            <ItemStyle Width="200px" HorizontalAlign="Center"></ItemStyle>
                            <ItemTemplate>
                                <img src="../images/delete_inbox.gif" width="20px" height="20px"   onclick="corrigirDadosJovem(' <%# Eval("IdJovem") %> ')" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </div>

    </div>
</asp:Content>
