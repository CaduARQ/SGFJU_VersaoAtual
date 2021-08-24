<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FJUDoor.aspx.cs" Inherits="SGFJU.UI.Views.FJUDoor2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>SGFJU - Sistema de Informações da FJU</title>
    <link href="../Styles/login.css" rel="stylesheet" /> 
    <link href="../Styles/MainsLogin.css" rel="stylesheet" /> 
    <link rel="icon" type="image/png" sizes="14x14" href="../Images/favicon-16x16.png">
</head>
<body>
    <form id="login" runat="server" class="box">
        <telerik:RadScriptManager ID="scrm" runat="server" />
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server" />

            <h1></h1>

            <div class="input">
                <input class="text-lower" name="username" type="text" autocomplete="off" placeholder="Usuário">                
                <span class="ico login"></span>
            </div>

            <div class="input">
                <input name="password" type="password" autocomplete="off" placeholder="Senha">                
                <span class="ico pass"></span>
            </div>

            <div class="actions">
                <%--<label class="trigger-recovery">Esqueci minha senha</label>--%>
            </div>

            <%--<input type="submit" id="enter" value="Entrar">--%>
            <asp:Button Text="Entrar" runat="server" OnClick="Unnamed1_Click" />

            <div class="alertBox"></div>
        </form>
</body>
</html>
