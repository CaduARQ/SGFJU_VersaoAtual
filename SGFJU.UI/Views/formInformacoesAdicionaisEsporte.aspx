<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formInformacoesAdicionaisEsporte.aspx.cs" Inherits="SGFJU.UI.Views.formInformacoesAdicionaisEsporte" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <script language="javascript" type="text/javascript">
            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow;
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
                return oWindow;
            };

            function CloseWindow(button, args) {
                var currentWindow = GetRadWindow();
                var departamentoProjetoObject = { NomeProjeto: 'Teste', NomeDepartamento: 'Departamento vitória' };

                alert("Habilidades adicionadas com sucesso!!!")

                currentWindow.close(departamentoProjetoObject);
            }
        </script>
        <link href="../Styles/common.css" rel="stylesheet" /> 
        <div>
            <telerik:RadWindowManager ID="rwin" runat="server" Skin="WebBlue" />
            <telerik:RadScriptManager ID="rsManager" runat="server"></telerik:RadScriptManager>
            <table border="0" cellspacing="0" cellpadding="0" id="tbl5" class="auto-style11">
														<tr>
															<td background="../images/top_tit.jpg" class="txt2"  colspan="7">PROJETO ESPORTE</td>
														</tr>
														<tr class="txt7">
															<td colspan="7">Marque os que você pratica e o nível de habilidade. Marque &#39;1&#39; para REGULAR, &#39;2&#39; para BOM e &#39;3&#39; para EXCELENTE</td>
                                                            
														</tr>
														<tr>
															<td class="style1">Futebol</td>
                                                            
															<td class="style1">
                                                                
                                                                <telerik:RadRadioButtonList ID="rbNivelFutebol" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
                                                            
															<td class="auto-style9">
																&nbsp;</td>
															<td>
																
                                                                &nbsp;</td>
															<td class="auto-style15">
																
                                                                Surf</td>
															<td class="auto-style13">
																
                                                                <telerik:RadRadioButtonList ID="rbNivelSurf" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td class="style1">Volley</td>
                                                            
															<td class="style1">
                                                                
                                                                <telerik:RadRadioButtonList ID="rbNivelVolley" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
                                                            
															<td class="auto-style9">
																&nbsp;</td>
															<td>
																
                                                                &nbsp;</td>
															<td class="auto-style15">
																
                                                                Skate</td>
															<td class="auto-style13">
																
                                                                <telerik:RadRadioButtonList ID="rbNivelSkate" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td class="style1">Basquete</td>
                                                            
															<td class="style1">
                                                                
                                                                <telerik:RadRadioButtonList ID="rbNivelBasquete" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
                                                            
															<td class="auto-style9">
																&nbsp;</td>
															<td>
																
                                                                &nbsp;</td>
															<td class="auto-style15">
																
                                                                Atletismo</td>
															<td class="auto-style13">
																
                                                                <telerik:RadRadioButtonList ID="rbNivelAtletismo" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td class="style1">Esporte de mesa</td>
                                                            
															<td class="style1">
                                                                
                                                                <telerik:RadRadioButtonList ID="rbNivelEsporteDeMesa" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
                                                            
															<td class="auto-style9">
															    <div align="right">

                                                                    Outro</div>
															</td>
															<td>
																
                                                                &nbsp;</td>
															<td class="auto-style15">
																
                                                                <telerik:RadTextBox ID="txtHabilidadeExtraEsporte" Runat="server" Skin="WebBlue" Width="100px" >
                                                                </telerik:RadTextBox>
																
                                                            </td>
															<td class="auto-style13">
																
                                                                <telerik:RadRadioButtonList ID="rbNivelHabilidadeExtraEsporte" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td class="auto-style12">
																
                                                                </td>
															<td class="auto-style12"></td>
															<td class="auto-style12">
                                                                
                                                                </td>
															<td class="auto-style12">
																
                                                                </td>
															<td class="auto-style12">
																
                                                                </td>
															<td class="auto-style12">
																
                                                                </td>
															<td class="auto-style12">
																
                                                                </td>
														</tr>														
														<tr>
															<td height="30" class="txt7" colspan="7">&nbsp;No caso de Artes Marciais, qual nível de habilidade? &#39;1&#39; para REGULAR, &#39;2&#39; para BOM e &#39;3&#39; para EXCELENTE</td>
														</tr>														
														<tr>
															<td height="30" class="style1">Jiu-Jitsu</td>
															<td height="30" class="style1">
                                                                
                                                                <telerik:RadRadioButtonList ID="rbNivelJiuJitsu" 
                                                                    runat="server" 
                                                                    Text="Sim" 
                                                                    Direction="Horizontal" 
                                                                    SelectedIndex="0" 
                                                                    SelectedValue="I" 
                                                                    Width="128px" 
                                                                    Skin="WebBlue" 
                                                                    AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
															<td class="auto-style9">
																&nbsp;</td>
															<td>
																
                                                                &nbsp;</td>
															<td class="auto-style15">
																
                                                                Capoeira</td>
															<td class="auto-style13">
																
                                                                <telerik:RadRadioButtonList ID="rbNivelCapoeira" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>														
														<tr>
															<td height="30" class="style1">Boxe</td>
															<td height="30" class="style1">
                                                                
                                                                <telerik:RadRadioButtonList ID="rbNivelBoxe" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
															<td class="auto-style9">
																&nbsp;</td>
															<td>
																
                                                                &nbsp;</td>
															<td class="auto-style15">
																
                                                                Taekwondo</td>
															<td class="auto-style13">
																
                                                                <telerik:RadRadioButtonList ID="rbNivelTaekwondo" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>														
														<tr>
															<td height="30" class="style1">Muay Thay</td>
															<td height="30" class="style1">
                                                                
                                                                <telerik:RadRadioButtonList ID="rbNivelMuayThay" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
															<td class="auto-style9">
															    <div align="right">

                                                                    Outro</div>
															</td>
															<td>
																
                                                                &nbsp;</td>
															<td class="auto-style15">
																
                                                                <telerik:RadTextBox ID="txtHabilidadeExtraArteMarcial" Runat="server" Skin="WebBlue" Width="100px" >
                                                                </telerik:RadTextBox>
																
                                                            </td>
															<td class="auto-style13">
																
                                                                <telerik:RadRadioButtonList ID="rbNivelHabilidadeExtraInstrumentos0" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>														
														<tr>
															<td height="30" class="style1">&nbsp;</td>
															<td height="30" class="style1">
                                                                
                                                                &nbsp;</td>
															<td class="auto-style9">
															    &nbsp;</td>
															<td>
																
                                                                &nbsp;</td>
															<td class="auto-style15">
																
                                                                &nbsp;</td>
															<td class="auto-style13">
																
                                                                &nbsp;</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>														
														<tr>
															<td height="30" class="style1">&nbsp;</td>
															<td height="30" class="style1" colspan="4">
                                                                <div align="center">
                                                                    <telerik:RadButton ID="btnAdicionaInformacoesProjeto"
                                                                                   runat="server"
                                                                                   Text="Adicionar informações"
                                                                                   OnClick="btnAdicionaInformacoesProjeto_Click"
                                                                                   Skin="WebBlue" />
                                                                </div>

															</td>
															<td class="auto-style13">
																
                                                                &nbsp;</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>														
														</table>
        </div>
    </form>
</body>
</html>
