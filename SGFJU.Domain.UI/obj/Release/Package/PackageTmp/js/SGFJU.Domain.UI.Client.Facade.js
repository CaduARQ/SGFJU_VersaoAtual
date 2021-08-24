ClientFactory.Register('SGFJU.Domain.Model.UI.Client.Facade.JovemFacade');
ClientFactory.Register('SGFJU.Domain.Model.UI.Client.Facade.UsuarioFacade');

var urlBase = 'api/Jovens/';
var hostUrl = "https://" + document.location.hostname + ":" + window.location.port;
//abaixo produção
//var urlFotoUser = "http://" + document.location.hostname + "/SGFJU2.0/FotosUsuarios/"
var urlFotoUser = "https://" + document.location.hostname + ":" + window.location.port + "/FotosUsuarios/"
//var apiUrl = '/api/bookings/';

SGFJU.Domain.Model.UI.Client.Facade.JovemFacade = function () {
    return {
        RetornaTodosJovens: function () {
            $.ajax({
                type: "GET",
                url: urlBase + 'Todos',
                contentType: "application/json"
            }).done(function (res) {
                alert('res', res);
            });
        }
    };
};

SGFJU.Domain.Model.UI.Client.Facade.UsuarioFacade = function () {
    return {
        ConfigurarPaginaX072470: function () {
            $.ajax({
                type: "GET",
                url: "api/Usuarios/X072470/",
                contentType: "application/json"
            }).done(function (retorno) {
                $("#lblNomeUsuario").html(retorno.NomeUsuario);
                $('#lblPerfilUsuario').html(retorno.NomePerfil + '<b class="caret"></b>');
                $('#imgUserConn').attr('height', '48px');
                $('#imgUserConn').attr('width', '48px');
                $('#imgUserConn').attr('src', urlFotoUser + retorno.PathImagemUsuario);
                console.log(urlFotoUser + retorno.PathImagemUsuario);
            });
        } ,
        ExecutarActionX072433: function () {
            $.ajax({
                type: "GET",
                url: "api/Usuarios/X072433/",
                contentType: "application/json"
            }).done(function () {
                window.location.replace('formLogin.aspx');
            });
        }
    };
};