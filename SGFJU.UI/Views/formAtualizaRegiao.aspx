<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formAtualizaRegiao.aspx.cs" Inherits="SGFJU.UI.Views.formAtualizaRegiao" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    
            <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>    
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>

        <script language="javascript" type="text/javascript">
            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow;
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
                return oWindow;
            };

            function CloseWindow(button, args) {
                var currentWindow = GetRadWindow();

                alert("Região alterada com sucesso!!!");

                currentWindow.close('RecarregarBlocos');
            }        
        </script>


    <div class="container-fluid bg-light py-3">

        <form id="contactform" runat="server">            
            <telerik:RadWindowManager ID="rwmUIApp" Skin="WebBlue" runat="server" />
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
            <legend>Atualização do nome da Região</legend>

            <div class="controls">

                <div class="row">

                    <div class="col-sm-4">
                        <div class="form-group">
                            <label for="form_name">Nome antigo da Região</label>
                            <br />
                            <asp:Label ID="lblNomeAntigoRegiao" runat="server" />
                        </div>

                        <div class="form-group">
                            <label for="form_name">Nome da Região</label>
                            <input id="txtNomeRegiao" type="text" name="txtNomeRegiao" required class="form-control"  >
                            <div class="help-block with-errors"></div>
                        </div>

                    </div>

                </div>

                <div class="clearfix"></div>

                <div class="row">

                    <div class="col-md-8">
                        <telerik:RadButton ID="btnAtualizarRegiao" runat="server"  Text="Atualizar Região" OnClick="btnAtualizarRegiao_Click"  />
                                    
                    </div>

                </div>                

            </div>

        </form>

    </div>

</body>
</html>
