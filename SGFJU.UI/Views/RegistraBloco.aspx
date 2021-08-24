<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistraBloco.aspx.cs" Inherits="SGFJU.UI.Views.RegistraBloco" %>



<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register assembly="Telerik.Web.Design" namespace="Telerik.Web.Design" tagprefix="design" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/common.css" rel="stylesheet" />
    <link href="../Styles/mail.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FolderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script language="javascript" type="text/javascript">
        <%--function btnCadastraBloco_Clicking(sender, args) {
            var nomeBloco = $find("<%= txtNome.ClientID %>").get_text();
            radalert('Nome do bloco não pode ficar em branco !!', 450, 200, 'Validação do formulário', null, null);
            //if (nomeBloco == '') {
            //    radalert('Nome do bloco não pode ficar em branco !!', 450, 200, 'Validação do formulário', null, null);
            //    args.set_cancel(true);
            //}
            args.set_cancel(false);
        }--%>
    </script>
    <telerik:RadWindowManager ID="rwmUIApp" Skin="WebBlue" runat="server" />
    <telerik:RadNavigation runat="server" Skin="Vista" OnClientNodeClicked="nodeClicked" CssClass="secondaryMenu">
        <Nodes>
            <telerik:NavigationNode Text="Novo Jovem" SpriteCssClass="icon icon-Send" NavigateUrl="RegistraJovem.aspx" ></telerik:NavigationNode>            
            <telerik:NavigationNode Text="Cancelar" NavigateUrl="default.aspx"></telerik:NavigationNode>
        </Nodes>
    </telerik:RadNavigation>
    
    <div class="scroller">

        <div class="sidebarScnd">
            
        </div>
        <div class="editorWrapper">            
            <table border="0" cellspacing="0" cellpadding="0" id="tbl1" class="txt1">
														    <tr>
															    <td class="txt1" ><div align="right">Nome:
																    </div>
															    </td>
															    <td class="auto-style18" colspan="2">
																    &nbsp;&nbsp;
																    <telerik:RadTextBox id="txtNome" 
                                                                                        ValidationGroup="StepInicialValidation" 
                                                                                        runat="server" 
                                                                                        Width="350px"
                                                                                        MaxLength="250"
                                                                        ></telerik:RadTextBox></td>
                                                            
															    <td class="auto-style17">
																
                                                                    </td>
															    <td class="auto-style20">
																
                                                                    &nbsp;</td>
															    <td class="auto-style21">
																
																    &nbsp;</td>
															    <td class="auto-style17">
																
															        &nbsp;

															    </td>
														        <td class="auto-style17">
                                                                    &nbsp;
                                                                    </td>
														        <td class="auto-style17">
                                                                    &nbsp;</td>
														    </tr>
														    <tr >
                                                                <td class="auto-style17">&nbsp;</td>
                                                                <td class="auto-style18" colspan="2">
                                                                    <asp:RequiredFieldValidator ID="reqNome" 
                                                                                                runat="server"
                                                                                                ControlToValidate="txtNome"
                                                                                                ValidationGroup="StepInicialValidation"
                                                                                                EnableClientScript="true"
                                                                                                ErrorMessage="O campos nome não pode ficar em branco"
                                                                                                ForeColor="Red" />
                                                                </td>
                                                                <td class="auto-style17">&nbsp;</td>
                                                                <td class="auto-style20">&nbsp;</td>
                                                                <td class="auto-style21">&nbsp;</td>
                                                                <td class="auto-style17">&nbsp;</td>
                                                                <td class="auto-style17">&nbsp;</td>
                                                                <td class="auto-style17">&nbsp;</td>
                                                            </tr>
														    <tr>
                                                                <td class="auto-style17" colspan="9">
                                                                    <div aling="right">
                                                                    </div>
                                                                </td>
                                                            </tr>
														    <tr cellspacing="10px">
															    <td class="auto-style2">
                                                                    <div align="right">Estado:
																    </div>
															    </td>
															    <td class="auto-style3">
                                                                
                                                                    &nbsp;&nbsp;
                                                                
                                                                    <telerik:RadComboBox ID="cboEstado"
                                                                        runat="server" 
                                                                        Height="100px" 
                                                                        Width="210px"
                                                                        Skin="WebBlue"
                                                                        AutoPostBack="true">

                                                                    </telerik:RadComboBox>
                                                                
                                                                </td>
															    <td class="auto-style10">
															        &nbsp;</td>

                                                                <td class="auto-style2">
                                                                
                                                                    &nbsp;</td>

                                                                <td class="auto-style16">
                                                                
                                                                    &nbsp;</td>

                                                                <td class="auto-style14">
                                                                
                                                                    &nbsp;</td>

                                                                <td class="auto-style2">
                                                                
                                                                    &nbsp;</td>
														        <td class="auto-style2" colspan="2">
                                                                    &nbsp;</td>
														    </tr>
														    <tr>
															    <td class="auto-style2" colspan="9">
                                                                    <div algin="center">
                                                                        <telerik:RadButton ID="btnCadastrBloco" 
                                                                                           runat="server" 
                                                                                           Skin="WebBlue"
                                                                                           Text="Cadastrar Bloco" 
                                                                                           OnClientClicking="btnCadastraBloco_Clicking"
                                                                                           OnClick="btnCadastrBloco_Click"/>
                                                                    </div>                                                                    
															    </td>
														    </tr>
														    <tr>
                                                                <td class="auto-style2">&nbsp;</td>
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
                                                                <td class="auto-style2" colspan="9">
                                                                    <%--<asp:ValidationSummary ID="ValidationSummary1" 
                                                                        DisplayMode="BulletList"
                                                                        ShowMessageBox="false"
                                                                                           runat="server" />--%>
                                                                    <telerik:RadGrid runat="server" 
                                                                                     ID="grdTodosBlocos" 
                                                                                     AutoGenerateColumns="False" 
                                                                                     Height="100%"
                                                                                     EnableViewState="False" 
                                                                                     AllowPaging="True"                
                                                                                     AllowSorting="True" 
                                                                                     ShowGroupPanel="True" Culture="pt-BR" OnPageIndexChanged="grdTodosBlocos_PageIndexChanged">
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
                                                                                <telerik:GridBoundColumn DataField="EstadoBloco.NomeEstado" UniqueName="Nome" HeaderText="Estado" HeaderStyle-Width="200px" >
                                                                                    <HeaderStyle Width="200px"></HeaderStyle>
                                                                                </telerik:GridBoundColumn>
                                                                                <telerik:GridBoundColumn DataField="NomeBloco" UniqueName="IgrejaAQualJovemPertence.NomeIgreja" HeaderText="Nome do Bloco" ItemStyle-CssClass="subject" >
                                                                                    <ItemStyle CssClass="subject"></ItemStyle>
                                                                                </telerik:GridBoundColumn>
                                                                            </Columns>
                                                                        </MasterTableView>
                                                                    </telerik:RadGrid>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style2">&nbsp;</td>
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

    </div>

</asp:Content>
