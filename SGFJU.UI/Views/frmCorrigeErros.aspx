<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCorrigeErros.aspx.cs" Inherits="SGFJU.UI.Views.frmCorrigeErros" %>

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

                alert("Informações atualizadas com sucesso!!!")

                currentWindow.close(departamentoProjetoObject);
            }
        </script>

        <link href="../Styles/common.css" rel="stylesheet" /> 

        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        <div>
            <table border="0" cellspacing="0" cellpadding="0" id="tbl6" class="auto-style11">
														<tr>
															<td background="../images/top_tit.jpg" class="txt8"  colspan="5">&nbsp;Atualize os dados abaixo</td>
														</tr>
														<tr>
															<td class="txt7" colspan="5">
                                                                <div align="left">
                                                                    NOME DO JOVEM: <asp:label ID="lblNomeJovem" runat="server" /></div>
                                                                
															</td>
                                                            
														</tr>
														<tr>
															<td class="txt7">Data do Batismo nas águas</td>
                                                            
															<td class="auto-style9">
                                                                <telerik:RadMaskedTextBox RenderMode="Lightweight" 
                                                                                              ID="txtDataBatismoAguas" 
                                                                                              runat="server" 
                                                                                              Mask="##/####" 
                                                                                              Width="150px"                                                                        
                                                                                              DisplayText="00/0000"
                                                                                              ValidationGroup="Group1">
                                                                    </telerik:RadMaskedTextBox>
                                                                &nbsp;</td>
															<td class="txt7">
																
                                                                Data de Casamento</td>
															<td class="auto-style15">
																
                                                                <telerik:RadDatePicker ID="txtDataCasamento" 
                                                                                           Runat="server" 
                                                                                           Skin="WebBlue" 
                                                                                           Width="100%"
                                                                                           Culture="PT-BR"
                                                                                           DateInput-MaxLength="10">
                                                                    </telerik:RadDatePicker>
															</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td class="txt7">Data do Batismo com o Espírito Santo</td>
                                                            
															<td class="auto-style9">
                                                                <telerik:RadMaskedTextBox RenderMode="Lightweight" 
                                                                                              ID="txtDataBatismoEspiritoSanto" 
                                                                                              runat="server" 
                                                                                              Mask="##/####" 
                                                                                              Width="150px"                                                                        
                                                                                              DisplayText="00/0000"
                                                                                              ValidationGroup="Group1">
                                                                    </telerik:RadMaskedTextBox>
                                                                </td>
															<td class="txt7">
																
                                                                Tempo Afastamento</td>
															<td class="auto-style15">
																
                                                                
															    <div align="left">
																															
                                                                
															    <div align="left">
															    <telerik:RadTextBox ID="txtTempoAfastamento" Runat="server" Skin="WebBlue" Width="190px" >
                                                                </telerik:RadTextBox>
																
															    </div>
																
															    </div>
															</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td class="txt7">Mês e ano do Afastamento</td>
                                                            
															<td class="auto-style9">
                                                                <telerik:RadMaskedTextBox RenderMode="Lightweight" 
                                                                                              ID="txtMesAnoAfastamento" 
                                                                                              runat="server" 
                                                                                              Mask="##/####" 
                                                                                              Width="150px"                                                                        
                                                                                              DisplayText="00/0000"
                                                                                              ValidationGroup="Group1">
                                                                    </telerik:RadMaskedTextBox>
                                                                </td>
															<td class="txt7">
																
                                                                Possui filhos</td>
															<td class="auto-style15">
																<telerik:RadRadioButtonList ID="rbPossuiFilhos" 
                                                                                                    runat="server" 
                                                                                                    Text="Sim" 
                                                                                                    Direction="Horizontal" 
                                                                                                    SelectedIndex="0" 
                                                                                                    SelectedValue="0" 
                                                                                                    AutoPostBack="false"
                                                                                                    Width="109px" >
                                                                        <Items>
                                                                            <telerik:ButtonListItem  Text="Sim" Value="0" />
                                                                            <telerik:ButtonListItem Text="Não" Value="1" />
                                                                        </Items>
                                                                    </telerik:RadRadioButtonList>
                                                                
															    </td>
															<td>
																
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td class="txt7">Quais vícios</td>
                                                            
															<td class="auto-style9">
																															
                                                                
															    <div align="left">
															    <telerik:RadTextBox ID="txtNomeVicio" Runat="server" Skin="WebBlue" Width="150px" >
                                                                </telerik:RadTextBox>
																
															    </div>
																
                                                                </td>
															<td class="txt7">
																
                                                                &nbsp;</td>
															<td class="auto-style15">
																&nbsp;</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td class="style1">&nbsp;</td>
                                                            
															<td class="auto-style9">
                                                                
                                                                &nbsp;</td>
															<td>
																
                                                                &nbsp;</td>
															<td class="auto-style15">
																
                                                                
															    &nbsp;</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td class="style1">&nbsp;</td>
                                                            
															<td class="auto-style9" colspan="2">
                                                                
                                                                <telerik:RadButton ID="btnAtualizaInformacoesJovem"
                                                                                   runat="server"
                                                                                   Text="Atualizar informações do jovem"
                                                                                   Skin="WebBlue" OnClick="btnAtualizaInformacoesJovem_Click" style="top: 0px; left: 0px"  />

															</td>
															<td class="auto-style15">
																
                                                                
															    &nbsp;</td>
															<td>
																
                                                                &nbsp;</td>
														</tr>
														</table>
        </div>
    </form>
</body>
</html>
