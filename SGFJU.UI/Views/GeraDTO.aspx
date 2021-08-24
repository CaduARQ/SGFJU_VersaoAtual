<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeraDTO.aspx.cs" Inherits="SGFJU.UI.Views.GeraDTO" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="GERAR" />
        <asp:Button ID="Button2" runat="server" Text="gerar JSON Bloco Estados" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Gera DTO Regiões" />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Gerar DTO Igrejas" />
    </form>
</body>
</html>
