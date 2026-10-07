<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formLogin.aspx.cs" Inherits="SGFJU.Domain.UI.formLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <title>SGFJU | Login</title>

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet">

    <!-- Sweet Alert -->
    <link href="css/plugins/sweetalert/sweetalert.css" rel="stylesheet">

    <link href="css/animate.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">
    <link href="css/fju-tema.css" rel="stylesheet">
    

    <style type="text/css">
        html,body{
        background-image: url('img/bgfju3.jpg');
        background-size: cover;
        background-repeat: no-repeat;
        height: 100%;
        font-family: 'Numans', sans-serif;
        }
    </style>
</head>
<body class="gray-bg">

    
    <div class="loginColumns animated fadeInDown">
        <div class="row">

            <div class="col-md-6">

                <h2 class="label label-success font-bold text-white">Seja Bem-Vindo</h2>
                <img id="imgLogo" src="img/SGFJU.png" height="200px" width="320px" alt="image"  />

            </div>
            <div class="col-md-6">
                <div class="ibox-content">
                    <form class="m-t" role="form" method="post" action="formlogin.aspx">
                        <div class="form-group">
                            <input type="text" class="form-control" id="login" name="login" placeholder="Login" required="" autocomplete="off" />
                        </div>
                        <div class="form-group">
                            <input type="password" class="form-control" id="senha" name="senha" placeholder="Senha" required="" />
                        </div>
                        <button type="submit" class="btn btn-primary block full-width m-b">Login</button>

                        <a href="#">
                            
                        </a>

                        <p class="text-muted text-center">
                            
                        </p>
                        
                    </form>
                    <p class="m-t">
                        
                    </p>
                </div>
            </div>
        </div>
        <hr/>
        <div class="row">
            <div class="col-md-6">
                
            </div>
            <div class="col-md-6 text-right">
               
            </div>
        </div>
    </div>

    <!-- Sweet alert -->
    <script src="js/plugins/sweetalert/sweetalert.min.js"></script>
    <script src="js/jquery-3.1.1.min.js"></script>
    <script>
        
        $(document).ready(function () {
            window.setInterval(function () {

                window.setTimeout(function () {
                    $(document.body).css('background-image', 'url(https://fjuoficial.org/SGFJU2.0/img/bgfju3.jpg)');
                }, 3000);
                $(document.body).css('background-image', 'url(https://fjuoficial.org/SGFJU2.0/img/bgfju2.jpg)');                
            }, 5000);
        });

        function exibeMensagemUsuarioNaoEncontrado() {
            swal({
                title: "Usuário não encontrado !",
                text: "verifique suas credenciais",
                type: "error"
            });
        }
    </script>

</body>
</html>
