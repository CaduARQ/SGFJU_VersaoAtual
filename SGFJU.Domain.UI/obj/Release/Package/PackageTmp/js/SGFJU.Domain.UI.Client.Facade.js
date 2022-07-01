ClientFactory.Register('SGFJU.Domain.Model.UI.Client.Facade.JovemFacade');
ClientFactory.Register('SGFJU.Domain.Model.UI.Client.Facade.UsuarioFacade');
ClientFactory.Register('SGFJU.Domain.Model.UI.Client.Facade.AltarJovemFacade');

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

SGFJU.Domain.Model.UI.Client.Facade.AltarJovemFacade = function () {
    return {
        RetornaJovensLevantadosAltar: function (idControToBeBinded, objectParameter) {
            console.log( JSON.stringify( objectParameter ) );

            $.ajax({
                type: "POST",
                data: JSON.stringify(objectParameter),
                url: "api/AltarJovem/ListaJovensLevantadosParaOAltarPorParametro",
                contentType: "application/json"
            }).done(function (resultSetJovensLevantadosAltar) {

                for (var i = 0; i < resultSetJovensLevantadosAltar.length; i++) {
                    var urlFotoJovem = '';
                    var urlProfile = '';

                    //console.log('nome: ' + resultSetJovensLevantadosAltar[i].NomeJovem + ' | ID:: ' + resultSetJovensLevantadosAltar[i].IdJovem );

                    if (HOST_NAME_APP.indexOf('localhost') !== -1) {
                        urlProfile = "https://" + document.location.hostname + ":" + document.location.port + "/";

                        if (resultSetJovensLevantadosAltar[i].NomeArquivoFoto == '')
                            urlFotoJovem = encodeURI(hostUrl + ':44388/FotosJovens/' + 'jovemsemfoto.jpg');
                        else
                            urlFotoJovem = encodeURI(hostUrl + ':44388/FotosJovens/' + resultSetJovensLevantadosAltar[i].NomeArquivoFoto);
                    }
                    else {
                        urlProfile = "http://" + document.location.hostname + "/SGFJU2.0/"

                        if (resultSetJovensLevantadosAltar[i].NomeArquivoFoto == '')
                            urlFotoJovem = encodeURI(hostUrl + '/SGFJU2.0/FotosJovens/' + 'jovemsemfoto.jpg');
                        else
                            urlFotoJovem = encodeURI(hostUrl + '/SGFJU2.0/FotosJovens/' + resultSetJovensLevantadosAltar[i].NomeArquivoFoto);
                    }

                    console.log('::Host -> ' + HOST_NAME_APP);

                    $('#' + idControToBeBinded).append(
                        __boxLevantadoAltar
                            .replace('#LINK_FOTO_JOVEM#', urlFotoJovem)
                            .replace('#NOME_JOVEM#', resultSetJovensLevantadosAltar[i].NomeJovem)
                            .replace('#LINK_PERFIL_JOVEM#', urlProfile + 'VisualizaJovemE.html?idJovem=' + resultSetJovensLevantadosAltar[i].IdJovem)
                            .replace('#ESTADO#', resultSetJovensLevantadosAltar[i].NomeEstado)
                            .replace('#BLOCO#', resultSetJovensLevantadosAltar[i].NomeBlocoJovem)
                            .replace('#REGIAO#', resultSetJovensLevantadosAltar[i].NomeRegiaoJovem)
                            .replace('#IGREJA#', resultSetJovensLevantadosAltar[i].NomeIgrejaJovem)
                            .replace('#WHATSAPP#', resultSetJovensLevantadosAltar[i].Whatsapp)
                    );

                }

                spinnerOff();

            });
        },
        RetornaJovensLevantadosAltarCallback: function (objectParameter, callbackToReceiveDataSource) {
            $.ajax({
                type: "POST",
                data: JSON.stringify(objectParameter),
                url: "api/AltarJovem/ListaJovensLevantadosParaOAltarPorParametro",
                success: function (responseFromCalled) {
                    callbackToReceiveDataSource(responseFromCalled);
                },
                contentType: "application/json"
            });
        }
    }
}