<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formInformacoesAdicionaisMidia.aspx.cs" Inherits="SGFJU.UI.Views.formInformacoesAdicionaisMidia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

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
        <telerik:RadWindowManager ID="rwin" runat="server" Skin="WebBlue" />
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        <div>
            <table border="0" cellspacing="0" cellpadding="0" id="tbl5" class="auto-style11">
														<tr>
															<td background="../images/top_tit.jpg" class="txt8"  colspan="7">PROJETO MÍDIA</td>
														</tr>
														<tr class="txt7">
															<td colspan="7">De qual departamento você faz parte, e qual a habilidade. Marque &#39;1&#39; para REGULAR, &#39;2&#39; para BOM e &#39;3&#39; para EXCELENTE</td>
                                                            
														</tr>
														<tr>
															<td class="style1">fotográfia</td>
                                                            
															<td class="style1">
                                                                
                                                                <telerik:RadRadioButtonList ID="rbNivelFotografia" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
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
																
                                                                Audio visual</td>
															<td class="auto-style13">
																
                                                                <telerik:RadRadioButtonList ID="rbNivelAudiovisual" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
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
															<td class="style1">Jornalistmo</td>
                                                            
															<td class="style1">
                                                                
                                                                <telerik:RadRadioButtonList ID="rbNivelJornalismo" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
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
																
                                                                Design gráfico</td>
															<td class="auto-style13">
																
                                                                <telerik:RadRadioButtonList ID="rbNivelDesigngrafico" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
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
															<td class="style1">Marketing</td>
                                                            
															<td class="style1">
                                                                
                                                                <telerik:RadRadioButtonList ID="rbNivelMarketing" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
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
																
                                                                <telerik:RadTextBox ID="txtHabilidadeExtraMidia" Runat="server" Skin="WebBlue" Width="100px" >
                                                                </telerik:RadTextBox>
																
                                                            </td>
															<td class="auto-style13">
																
                                                                <telerik:RadRadioButtonList ID="rbNivelCursoExtraProjetoMidia" runat="server" Text="Sim" Direction="Horizontal" SelectedIndex="0" SelectedValue="I" Width="128px" Skin="WebBlue" AutoPostBack="False" >
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
															<td height="30" class="txt7" colspan="7">
															    <div align="left">

                                                                    Já fez algum curso relacionado ao projeto Mídia? Qual?&nbsp;

															    <telerik:RadTextBox ID="txtCursoExtraProjetoMidia" Runat="server" Skin="WebBlue" Width="190px" >
                                                                </telerik:RadTextBox>
																
															    </div>
															</td>
														</tr>		
                                                        <tr>
															<td height="30" class="style1" colspan="7">
															    &nbsp;</td>
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
