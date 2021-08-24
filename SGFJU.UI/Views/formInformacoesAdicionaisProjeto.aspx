<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formInformacoesAdicionaisProjeto.aspx.cs" Inherits="SGFJU.UI.Views.formInformacoesAdicionaisProjeto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .txt1 {
	        font-family: Verdana, Arial, Helvetica, sans-serif;
	        font-size: 11px;
	        font-style: normal;
	        line-height: normal;
	        font-weight: bold;
	        font-variant: normal;
	        text-transform: none;
	        color: #003366;
        }
        .txt2 {

	        font-family: Verdana, Arial, Helvetica, sans-serif;
	        font-size: 12px;
	        font-style: normal;
	        line-height: normal;
	        font-weight: bold;
	        font-variant: normal;
	        text-transform: none;	
	        color: #FFFFFF;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
        <script language="javascript" type="text/javascript">
            $telerik.$(document).ready(function () {
                var url_ = new URL(location.href);
                var parametroNomeProjeto = url_.searchParams.get("nomeProjeto");

                configuraNomeProjeto(parametroNomeProjeto);
                escondeLinhaCursoAdicionalUF(parametroNomeProjeto);

                <%--var button = $find("<%=btnAdicionaInformacoesProjeto.ClientID %>");
                button.add_clicked(CloseWindow);--%>

            });

            <%--function configuraNomeProjeto() {
                var url_ = new URL(location.href);
                var parametroNomeProjeto = url_.searchParams.get("nomeProjeto");

                $telerik.$('#<%= lblNomeProjeto.ClientID %>').html(parametroNomeProjeto);
                $telerik.$('#<%= lblProjeto2.ClientID %>').html(parametroNomeProjeto);
            };--%>
            function configuraNomeProjeto(parametroNomeProjeto) {

                $telerik.$('#<%= lblNomeProjeto.ClientID %>').html(parametroNomeProjeto);
                $telerik.$('#<%= lblProjeto2.ClientID %>').html(parametroNomeProjeto);
            };

            function escondeLinhaCursoAdicionalUF(parametroNomeProjeto) {
                if (parametroNomeProjeto == 'Uniforça') {
                    $telerik.$('#tblInforAddProjeto tr[id=linhaCursoPadraoUniforca]').show();
                    $telerik.$('#tblInforAddProjeto tr[id=linhaCursoAdicional]').hide();
                }
                else {
                    $telerik.$('#tblInforAddProjeto tr[id=linhaCursoPadraoUniforca]').hide();
                    $telerik.$('#tblInforAddProjeto tr[id=linhaCursoAdicional]').show();
                }                    
            };

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
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
            <telerik:RadWindowManager ID="rwinamanger" runat="server" Skin="WebBlue" />
            <table id="tblInforAddProjeto" 
                   border="0" 
                   cellpadding="0" 
                   cellspacing="0" 
                   class="auto-style11">
                                                    <tr>
                                                        <td background="../images/top_tit.jpg" class="txt2" colspan="7">PROJETO <asp:Label ID="lblNomeProjeto" Text="" runat="server" /></td>
                                                    </tr>
                                                    <tr class="txt1">
                                                        <td colspan="7">Você fez algum curso( ou tem alguma habilidade ) que seja útil ao projeto <asp:Label ID="lblProjeto2" runat="server" /> &nbsp;
                                                                <telerik:RadRadioButtonList ID="rbPossuiCursoRelacionadoProjeto" 
                                                                    runat="server" 
                                                                    Text="Sim" 
                                                                    Direction="Horizontal" 
                                                                    AutoPostBack="false"
                                                                    Width="128px" 
                                                                    Skin="WebBlue" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Text="Sim" Value="S" />
                                                                        <telerik:ButtonListItem Text="Não" Value="N" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
                                                        </td>
                                                    </tr>
                                                    <tr id="linhaCursoAdicional">
                                                        <td class="txt1" colspan="7"><div align="left">
                                                                    Qual?
															        <telerik:RadTextBox ID="txtNomeCursoAdicionaoProjeto" Runat="server" Skin="WebBlue" Width="280px" >
                                                                    </telerik:RadTextBox>
																
															    </div>
															</td>
                                                    </tr>
                                                    <tr id="linhaCursoPadraoUniforca">
                                                        <td class="txt1">
                                                            <asp:CheckBoxList ID="chkCursosExtraUF" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Value="NPS">Noções de primeiros socorros</asp:ListItem>
                                                                <asp:ListItem Value="PSA">Primeiros Socorros avançado</asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </td>
                                                        <td class="style1">
                                                            &nbsp;</td>
                                                        <td class="txt1">
                                                            <div align="right">
                                                                Outro. Qual?</div>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td class="auto-style15">
																
                                                                <telerik:RadTextBox ID="txtCursoExtraUF" Runat="server" Skin="WebBlue" Width="100px" >
                                                                </telerik:RadTextBox>
																
                                                        </td>
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
                                                                <div align="center">
                                                                    <telerik:RadButton ID="btnAdicionaInformacoesProjeto"
                                                                                   runat="server"
                                                                                   Text="Adicionar informações"
                                                                                   Skin="WebBlue"
                                                                                   OnClick="btnAdicionaInformacoesProjeto_Click" />
                                                                </div>
                                                                

                                                        </td>
                                                    </tr>
                                                </table>
        </div>
    </form>
</body>
</html>
