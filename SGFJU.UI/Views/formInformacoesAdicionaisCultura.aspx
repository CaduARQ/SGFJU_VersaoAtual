<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formInformacoesAdicionaisCultura.aspx.cs" Inherits="SGFJU.UI.Views.formInformacoesAdicionaisCultura" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="frmCultura" runat="server">


        <link href="../Styles/common.css" rel="stylesheet" /> 

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
        
        <div>
            <telerik:RadWindowManager ID="rwin" runat="server" Skin="WebBlue" />
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
            <table border="0" cellspacing="0" cellpadding="0" id="tbl4" class="auto-style11">
														<tr>
															<td background="../images/top_tit.jpg" class="txt8"  colspan="7">PROJETO CULTURA</td>
														</tr>
														<tr>
															<td class="txt1" colspan="7">&nbsp;<div align="left">
                                                                    DE QUAL DEPARTAMENTO DO PROJETO CULTURA VOCÊ FAZ PARTE                                                                       
                                                                    <telerik:RadCheckBoxList ID="chkDepartamentosCultura"
                                                                                             runat="server" 
                                                                                             Text="Sim" 
                                                                                             Direction="Horizontal" 
                                                                                             AutoPostBack="false"
                                                                                             Width="128px" 
                                                                                             Skin="WebBlue">
                                                                    </telerik:RadCheckBoxList>
                                                                </div>
															</td>
                                                            
														</tr>
														<tr>
															<td class="style1">&nbsp;</td>
                                                            
															<td class="style1">&nbsp;</td>
                                                            
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
														<tr class="txt1">
															<td colspan="7">DANÇA - Nível: Marque &#39;1&#39; para INICIANTE, &#39;2&#39; para INTERMEDIÁRIO e &#39;3&#39; para AVANÇADO</td>
                                                            
														</tr>
														<tr>
															<td class="style1">Hip-Hop</td>
                                                            
															<td class="style1">
                                                                
                                                                <telerik:RadRadioButtonList ID="rbNivelHipHop" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="1" Value="I" />
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
																
                                                                Ballet Clássico</td>
															<td class="auto-style13">
																
                                                                <telerik:RadRadioButtonList ID="rbNivelBalletClassico" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td class="style1">Popping</td>
                                                            
															<td class="style1">
                                                                
                                                                <telerik:RadRadioButtonList ID="rbNivelPopping" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="1" Value="I" />
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
																
                                                                Neo Clássico</td>
															<td class="auto-style13">
																
                                                                <telerik:RadRadioButtonList ID="rbNivelNeoClassico" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td class="style1">Break Dance</td>
                                                            
															<td class="style1">
                                                                
                                                                <telerik:RadRadioButtonList ID="rbNivelBreakDance" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="1" Value="I" />
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
																
                                                                Jazz</td>
															<td class="auto-style13">
																
                                                                <telerik:RadRadioButtonList ID="rbNivelJazz" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td class="style1">Looking</td>
                                                            
															<td class="style1">
                                                                
                                                                <telerik:RadRadioButtonList ID="rbNivelLooking" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="1" Value="I" />
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
																
                                                                Estilo Livre</td>
															<td class="auto-style13">
																
                                                                <telerik:RadRadioButtonList ID="rbNivelEstiloLivre" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td class="style1">All Style</td>
                                                            
															<td class="style1">
                                                                
                                                                <telerik:RadRadioButtonList ID="rbNivelAllStyle" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="1" Value="I" />
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
																
                                                                Ballet Teatral</td>
															<td class="auto-style13">
																
                                                                <telerik:RadRadioButtonList ID="rbNivelBalletTeatral" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td class="style1">Street Dance</td>
                                                            
															<td class="style1">
                                                                
                                                                <telerik:RadRadioButtonList ID="rbNivelStreetDance" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
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
																
                                                                <telerik:RadTextBox ID="txtHabilidadeExtraDanca" Runat="server" Skin="WebBlue" Width="100px" >
                                                                </telerik:RadTextBox>
																
															</td>
															<td class="auto-style13">
																
                                                                <telerik:RadRadioButtonList ID="rbNivelHabilidadeExtraDanca" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td height="30" class="style1">&nbsp;&nbsp;
																
                                                                </td>
															<td height="30" class="style1">&nbsp;</td>
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
															<td class="auto-style9" colspan="7">BANDA - CANTORES: Qual sua classificação vocal</td>
														</tr>														
														<tr>
															<td height="30" class="txt1" colspan="7">
																															
                                                                <div align="left">
                                                                    &nbsp;<telerik:RadRadioButtonList ID="rbClassificacaoVocal" 
                                                                                                      runat="server" 
                                                                                                      Text="Sim" 
                                                                                                      AutoPostBack="false"
                                                                                                      Direction="Horizontal" 
                                                                                                      Width="128px" 
                                                                                                      Skin="WebBlue" >
                                                                    </telerik:RadRadioButtonList>
                                                                </div>
																
                                                                </td>
														</tr>														
														<tr>
															<td height="30" class="txt1" colspan="7">BANDA - INSTRUMENTISTAS - Nível: Marque &#39;1&#39; para INICIANTE, &#39;2&#39; para INTERMEDIÁRIO e &#39;3&#39; para AVANÇADO</td>
														</tr>														
														<tr>
															<td height="30" class="style1">Teclado</td>
															<td height="30" class="style1">
                                                                
                                                                <telerik:RadRadioButtonList ID="rbNivelITeclado" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="1" Value="I" />
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
																
                                                                Violino</td>
															<td class="auto-style13">
																
                                                                <telerik:RadRadioButtonList ID="rbNivelViolino" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>														
														<tr>
															<td height="30" class="style1">Violão</td>
															<td height="30" class="style1">
                                                                
                                                                <telerik:RadRadioButtonList ID="rbNivelViolao" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="1" Value="I" />
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
																
                                                                Bateria</td>
															<td class="auto-style13">
																
                                                                <telerik:RadRadioButtonList ID="rbNivelBateria" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>														
														<tr>
															<td height="30" class="style1">Baixo</td>
															<td height="30" class="style1">
                                                                
                                                                <telerik:RadRadioButtonList ID="rbNivelBaixo" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="1" Value="I" />
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
																
                                                                Percussão</td>
															<td class="auto-style13">
																
                                                                <telerik:RadRadioButtonList ID="rbNivelPercussao" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>														
														<tr>
															<td height="30" class="style1">Guitarra</td>
															<td height="30" class="style1">
                                                                
                                                                <telerik:RadRadioButtonList ID="rbNivelGuitarra" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="1" Value="I" />
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
																
                                                                Saxofone</td>
															<td class="auto-style13">
																
                                                                <telerik:RadRadioButtonList ID="rbNivelSaxofone" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="1" Value="I" />
                                                                        <telerik:ButtonListItem Text="2" Value="IN" />
                                                                        <telerik:ButtonListItem Text="3" Value="A" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>														
														<tr>
															<td height="30" class="style1">Cavaquinho</td>
															<td height="30" class="style1">
                                                                
                                                                <telerik:RadRadioButtonList ID="rbNivelCavaquinho" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
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
																
                                                                <telerik:RadTextBox ID="txtHabilidadeExtraInstrumento" Runat="server" Skin="WebBlue" Width="100px" >
                                                                </telerik:RadTextBox>
																
                                                            </td>
															<td class="auto-style13">
																
                                                                <telerik:RadRadioButtonList ID="rbNivelHabilidadeExtraInstrumentos" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
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
															<td height="30" class="style1" colspan="7">
															    <div align="left">

                                                                    Já fez algum curso relacionado ao projeto cultura?

															    <telerik:RadTextBox ID="txtCursoRelacionadoProjetoCultura" Runat="server" Skin="WebBlue" Width="190px" >
                                                                </telerik:RadTextBox>
																
															    </div>
															</td>
														</tr>														
														<tr>
															<td height="30" class="style1" colspan="7">
															    <div align="center">
                                                                    <telerik:RadButton ID="btnAdicionaInformacoesProjeto"
                                                                                   runat="server"
                                                                                   Text="Adicionar informações"
                                                                                   Skin="WebBlue" OnClick="btnAdicionaInformacoesProjeto_Click" />
															    </div>

															</td>
														</tr>														
														</table>
        </div>
    </form>
</body>
</html>
