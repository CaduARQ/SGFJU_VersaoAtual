<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formInformacoesAdicionaisUniversitarios.aspx.cs" Inherits="SGFJU.UI.Views.formInformacoesAdicionaisUniversitarios" %>

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

                alert("Informações adicionadas com sucesso!!!")

                currentWindow.close(departamentoProjetoObject);
            }
        </script>

        <link href="../Styles/common.css" rel="stylesheet" /> 

        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        <div>
            <table border="0" cellspacing="0" cellpadding="0" id="tbl6" class="auto-style11">
														<tr>
															<td background="../images/top_tit.jpg" class="txt8"  colspan="7">PROJETO UNIVERSITÁRIOS</td>
														</tr>
														<tr>
															<td class="txt7" colspan="7">&nbsp;&nbsp;
																															
                                                                
															    <div align="left">
                                                                    (Faculdade/Universidade) - Qual curso estuda?&nbsp;&nbsp;&nbsp;
															    <telerik:RadTextBox ID="txtNomeCursoFaculdadeJovem" Runat="server" Skin="WebBlue" Width="190px" >
                                                                </telerik:RadTextBox>
																
															    </div>
															</td>
                                                            
														</tr>
														<tr>
															<td class="txt7">Já se formou?</td>
                                                            
															<td class="style1">
                                                                
                                                                <telerik:RadRadioButtonList ID="rbJaSeFormou" 
                                                                                            runat="server" 
                                                                                            Text="Sim" 
                                                                                            Direction="Horizontal" 
                                                                                            SelectedIndex="0" 
                                                                                            SelectedValue="0" 
                                                                                            Width="128px" 
                                                                                            Skin="WebBlue"
                                                                                            AutoPostBack="false">
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="Sim" Value="S" />
                                                                        <telerik:ButtonListItem Text="Não" Value="N" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
                                                            
															<td class="txt7">
																Em qual perioro está</td>
															<td>
																
                                                                <telerik:RadTextBox ID="txtPeriodoCursando" Runat="server" Skin="WebBlue" Width="80px" >
                                                                </telerik:RadTextBox>
																
                                                            </td>
															<td class="txt7">
																
                                                                Quando vai se forma</td>
															<td class="auto-style13">
																
                                                                <telerik:RadTextBox ID="txtPrevisaoFormatura" Runat="server" Skin="WebBlue" Width="80px" >
                                                                </telerik:RadTextBox>
																
															</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td class="txt7" colspan="7">
                                                                <div align="left">
                                                                    Qual modalidade de ensino você está cursando
                                                                
                                                                <telerik:RadRadioButtonList ID="rbModalidadeNivelSuperior" 
                                                                                            runat="server" 
                                                                                            Text="Sim" 
                                                                                            Direction="Horizontal" 
                                                                                            Width="128px" 
                                                                                            Skin="WebBlue"
                                                                                            AutoPostBack="false">                                                                    
                                                                </telerik:RadRadioButtonList>
                                                                </div>
                                                                
															</td>
                                                            
														</tr>
														<tr>
															<td class="txt7" colspan="2">Se ainda não ingressou tem vontade?</td>
                                                            
															<td class="auto-style9">
                                                                
                                                                <telerik:RadRadioButtonList ID="rbDesejaCursarNivelSuperior" 
                                                                                            runat="server" 
                                                                                            Text="Sim" 
                                                                                            Direction="Horizontal" 
                                                                                            Width="128px" 
                                                                                            Skin="WebBlue"
                                                                                            AutoPostBack="false">
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="Sim" Value="S" />
                                                                        <telerik:ButtonListItem Text="Não" Value="N" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
															</td>
															<td class="txt7">
																
                                                                Qual curso?</td>
															<td class="auto-style15" colspan="2">
																
                                                                
															    <div align="left">
                                                                    &nbsp;&nbsp;
															    <telerik:RadTextBox ID="txtNomeCursoDesejaCursar" Runat="server" Skin="WebBlue" Width="190px" >
                                                                </telerik:RadTextBox>
																
															    </div>
															</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td class="style1" colspan="2">&nbsp;</td>
                                                            
															<td class="auto-style9">
                                                                
                                                                &nbsp;</td>
															<td>
																
                                                                &nbsp;</td>
															<td class="auto-style15" colspan="2">
																
                                                                
															    &nbsp;</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td class="style1" colspan="2">&nbsp;</td>
                                                            
															<td class="auto-style9" colspan="2">
                                                                
                                                                <telerik:RadButton ID="btnAdicionaInformacoesProjeto"
                                                                                   runat="server"
                                                                                   Text="Adicionar informações"
                                                                                   Skin="WebBlue" OnClick="btnAdicionaInformacoesProjeto_Click" />

															</td>
															<td class="auto-style15" colspan="2">
																
                                                                
															    &nbsp;</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>
														</table>
        </div>
    </form>
</body>
</html>
