<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistraUsuario.aspx.cs" Inherits="SGFJU.UI.Views.RegistraUsuario" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register assembly="Telerik.Web.Design" namespace="Telerik.Web.Design" tagprefix="design" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link href="../Styles/UI_App.css" rel="stylesheet" /> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FolderContent" runat="server">
	<nav:FolderNavigationControl runat="server" ID="FolderNavigationControl" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <telerik:RadWindowManager ID="RadWindowManager1" Skin="WebBlue" runat="server" />
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td height="173" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
										<tr bgcolor="#bed3e6">

                                            <td width="26" height="25" background="../images/top_tit.jpg">&nbsp;</td>
											<td width="1014" background="../images/top_tit.jpg" class="txt2"><div align="left">|
                                                    Formulário de cadastramento&nbsp; de Usuário</div>
											</td>
										</tr>
										<tr bgcolor="#bed3e8">

                                            <td height="22">

                                                <div align="center">

                                                    <span class="txt3">
											            &nbsp;</span></div>
											</td>
											<td height="22" class="txt1"><div align="left">Passo 1 - Informações básicas
                                                </div>
											</td>
										</tr>
										<tr bgcolor="#d3e1ee">

                                            <td height="140"><div align="center"></div>

                                            </td>

                                            <td height="140" valign="top" class="txt1">
												<div align="left">

                                                    <table border="0" cellspacing="0" cellpadding="0" id="tbl1" 
                                                        style="width: 656px">
														<tr>
															<td class="style1">
																<div align="right">Nome:
																</div>
															</td>
															<td class="auto-style1">
																<asp:TextBox id="txtNome" runat="server" Width="212px" 
                                                                    ></asp:TextBox></td>
                                                            
															<td>
																<div align="right">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
																</div>
															</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td class="style1">
																<div align="right">
																	Login:
																</div>

															</td>
															<td class="auto-style1">
																<asp:TextBox id="txtLogin" runat="server" Width="212px" 
                                                                    ></asp:TextBox></td>
                                                            
															<td>
																&nbsp;</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td height="30" class="style1"><div align="right">Senha:
																</div>
															</td>
															<td class="auto-style1">
																
																<asp:TextBox id="txtSenha" runat="server" Width="118px" TextMode="Password" 
                                                                    ></asp:TextBox>
																
                                                            </td>
															<td>
																<div align="right">&nbsp;</div>
															</td>
															<td>
																&nbsp;</td>
														</tr>														
														<tr>
															<td height="12" class="style1"><div align="right">Tipo do Usuário:
																</div>
															</td>
															<td class="auto-style1">
                                                                
                                                                <telerik:RadDropDownList ID="cboTipoUsuario"                                                                     
                                                                                         runat="server" Skin="WebBlue">
                                                                    <Items>
                                                                        <telerik:DropDownListItem runat="server" Text="Administrador" Value="1" />
                                                                        <telerik:DropDownListItem runat="server" Text="Secretária" Value="3" />
                                                                    </Items>
                                                                </telerik:RadDropDownList>
                                                                
                                                                </td>
															<td>
																<div align="right">&nbsp;</div>
															</td>
															<td>
																&nbsp;</td>
														</tr>
														<tr>
															<td class="auto-style2">
                                                                <div align="right">Estado:
																</div>
															</td>
															<td class="auto-style3">
                                                                
                                                                <telerik:RadDropDownList ID="cboEstado" 
																						 runat="server" 
																						 Height="16px" 
																						 Width="210px"
																						 Skin="WebBlue">
                                                                </telerik:RadDropDownList>
                                                                
                                                            </td>
															<td class="auto-style2">
															    &nbsp;
															    <div align="left">

                                                                </div>

                                                            </td>

                                                            <td class="auto-style2">
																</td>
														</tr>
														</table>
												</div>
											</td>
										</tr>
										<tr bgcolor="#bed3e8">
											<td height="22"><div align="center"></div>
											</td>
											<td height="22" class="txt1"><div align="left">Passo 2 - Efetuar cadastro
												</div>
											</td>
										</tr>  
										<tr bgcolor="#d3e1ee">
											<td style="height: 20px"></td>
											<td class="txt1" style="height: 20px">
												&nbsp;<telerik:RadButton ID="btnCadastrarTestemunho" runat="server" OnClick="btnCadastrarTestemunho_Click" Skin="WebBlue" Text="Cadastrar Usuário">
                                                </telerik:RadButton>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td height="22" bgcolor="#bed4e9">                                    
								    <%--<telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
                                    </telerik:RadScriptManager>--%>
								</td>
							</tr>
							</table>
					</td>
				</tr>
			</table>
</asp:Content>
