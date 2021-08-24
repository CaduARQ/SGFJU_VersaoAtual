<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="formRelatorioTotalPorEstado.aspx.cs" Inherits="SGFJU.UI.Views.formRelatorioTotalPorEstado" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register assembly="Telerik.Web.Design" namespace="Telerik.Web.Design" tagprefix="design" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/mail.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FolderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table id="tblInforAddProjeto" 
                   border="0" 
                   cellpadding="0" 
                   cellspacing="0" 
                   class="auto-style11">
                                                    <tr>
                                                        <td background="../images/top_tit.jpg" class="txt2" colspan="7">Total de Jovens por estado</td>
                                                    </tr>
                                                    <tr class="txt7">
                                                        <td colspan="7">&nbsp;</td>
                                                    </tr>
                                                    <tr id="linhaCursoAdicional">
                                                        <td class="txt7" colspan="7"><div align="left">
                                                                    Estado&nbsp; <asp:Label ID="lblNomeEstado" runat="server" />
																
															    </div>
															</td>
                                                    </tr>
                                                    <tr id="linhaCursoPadraoUniforca">
                                                        <td class="txt1">
                                                            &nbsp;</td>
                                                        <td class="style1">
                                                            &nbsp;</td>
                                                        <td class="txt1">
                                                            <div align="right">
                                                                </div>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td class="auto-style15">
																
                                                                &nbsp;</td>
                                                        <td class="auto-style13">
                                                            &nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style1">
                                                                <div align="center">
                                                                </div>
                                                                

                                                        </td>
                                                        <td class="style1">
                                                            &nbsp;</td>
                                                        <td class="auto-style9">
                                                            &nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td class="auto-style15">
																
                                                                &nbsp;</td>
                                                        <td class="auto-style13">
                                                            &nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style1">
                                                            &nbsp;</td>
                                                        <td class="style1">
                                                            &nbsp;</td>
                                                        <td class="auto-style9">
                                                            &nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td class="auto-style15">
																
                                                                &nbsp;</td>
                                                        <td class="auto-style13">
                                                            &nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style1">
                                                            &nbsp;</td>
                                                        <td class="style1">
                                                            &nbsp;</td>
                                                        <td class="auto-style9">
                                                            &nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td class="auto-style15">
																
                                                                &nbsp;</td>
                                                        <td class="auto-style13">
                                                            &nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style1" colspan="7">
                                                            <!---->
                                                            <telerik:RadGrid runat="server" 
                                                                 ID="grdTotalJovensPorBloco" 
                                                                 AutoGenerateColumns="False" 
                                                                 Height="100%"
                                                                 EnableViewState="False" 
                                                                 AllowPaging="True"                
                                                                 AllowSorting="True" 
                                                                 ShowGroupPanel="True" Culture="pt-BR" PageSize="12" OnNeedDataSource="grdTotalJovensPorBloco_NeedDataSource" OnPageIndexChanged="grdTotalJovensPorBloco_PageIndexChanged" >
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
                                                            <telerik:GridBoundColumn EmptyDataText="IdEStado" UniqueName="IdEStado" Visible="False"/>
                                                            <telerik:GridBoundColumn EmptyDataText="IdBloco" UniqueName="IdBloco" Visible="False"/>
                                                            <telerik:GridBoundColumn DataField="NomeEstado" UniqueName="NomeEstado" HeaderText="Região" ItemStyle-CssClass="subject" >
                                                                <ItemStyle CssClass="subject"></ItemStyle>
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="NomeBloco" UniqueName="NomeBloco" HeaderText="Bloco" ItemStyle-CssClass="subject" >
                                                                <ItemStyle CssClass="subject"></ItemStyle>
                                                            </telerik:GridBoundColumn>

                                                            <telerik:GridBoundColumn DataField="TotalJovensBloco" UniqueName="TotalJovensBloco" HeaderText="Total de Jovens" ItemStyle-CssClass="subject" >
                                                                <ItemStyle CssClass="subject"></ItemStyle>
                                                            </telerik:GridBoundColumn>

                        

                                                        </Columns>
                                                    </MasterTableView>
                                                </telerik:RadGrid>
                                                            <!---->
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style1" colspan="7">
                                                                <div align="center">
                                                                </div>
                                                                

                                                        </td>
                                                    </tr>
                                                </table>
</asp:Content>
