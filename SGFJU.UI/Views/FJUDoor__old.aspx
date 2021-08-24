<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FJUDoor__old.aspx.cs" Inherits="SGFJU.UI.Views.FJUDoor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 254px;
            height: 96px;
        }
		.txt1 {
	        font-family: Verdana, Arial, Helvetica, sans-serif;
	        font-size: 12px;
	        font-style: normal;
	        line-height: normal;
	        font-weight: bold;
	        font-variant: normal;
	        text-transform: none;
	        color: #003366;
        }
        .txt2 {

	        font-family: Verdana, Arial, Helvetica, sans-serif;
	        font-size: 9px;
	        font-style: normal;
	        line-height: normal;
	        font-weight: bold;
	        font-variant: normal;
	        text-transform: none;	
	        color: #FFFFFF;
        }
        .txt3 {


	        font-family: Verdana, Arial, Helvetica, sans-serif;
	        font-size: 9px;
	        font-style: normal;
	        line-height: normal;
	        font-weight: normal;
	        font-variant: normal;
	        text-transform: none;
	        color: #003366;
        }
    </style>
</head>
<body style="background-color: #d3e1ee">
<form id="frmForumLogin" runat="server" >

		<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                </asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>

		<script language="javascript" type="text/javascript">
            //$(document).ready(function () {        
                
            //});


            function ValidateInformations(sender, args) {
                var txtLogin = $find("<%= txtLogin.ClientID %>").get_value();
                var txtSenha = $find("<%= txtSenha.ClientID %>").get_value();
                var msg = "";

                if (txtLogin == "") {
                    msg += "Para efetuar o logon é necessario digitar o login </br>";
                }

                if (txtSenha == "") {
                    msg += "Para efetuar o logon é necessário digitar a senha </br>";
                }

                if (msg != "") {
                    window.radalert(msg);
                    args.set_cancel(true);
                }
            }

            

        </script>

		    
		    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" />
			<table cellSpacing="0" cellPadding="0" width="100%" border="0" BackColor="#d3e1ee">
				<tr>
					<td background="../images/fundo_site_topo.jpg">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td width="54%"><IMG height="146" src="../images/topoExtendSGR.jpg" width="562"></td>
								<td width="46%">
									<div visible="fase" align="center"><IMG src="../images/FJU(LOGO) BRANCO.png" class="auto-style1"></div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td vAlign="top" background="../images/fundo_site.jpg" height="441">
						<center>
							<table cellSpacing="0" cellPadding="0" width="651" border="0">
								<tr class="txt1">
									<td height="47">&nbsp;</td>
									<td>&nbsp;</td>
									<td>&nbsp;</td>
								</tr>
								<tr class="txt1">
									<td width="60" height="42">&nbsp;</td>
									<td width="435">Login:&nbsp; &nbsp; &nbsp;<telerik:RadTextBox id="txtLogin" Skin="WebBlue" runat="server"></telerik:RadTextBox></td>
									<td width="156">&nbsp;</td>
								</tr>
								<tr class="txt1">
									<td height="40">&nbsp;</td>
									<td>Senha:&nbsp; &nbsp; <telerik:RadTextBox id="txtSenha" runat="server" Skin="WebBlue" TextMode="Password"></telerik:RadTextBox></td>
									<td>&nbsp;</td>
								</tr>
								<TR>
									<TD height="40"></TD>
									<TD><telerik:RadButton id="btnLogin" 

                                                    runat="server" 
												    Skin="WebBlue"
                                                    Text="Login" 
													OnClientClicking="ValidateInformations"
                                                    onclick="btnLogin_Click1"></telerik:RadButton></TD>
									<TD></TD>
								</TR>
							</table>
						</center>
					</td>
				</tr>
			</table>
			<CENTER></CENTER>
		</form>
</body>
</html>
