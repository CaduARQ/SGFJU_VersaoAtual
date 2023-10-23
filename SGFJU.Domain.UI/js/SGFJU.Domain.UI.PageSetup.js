ClientFactory.Register('SGFJU.Domain.UI.PageSetup');

var hostUrl = "http://" + document.location.hostname;
var __HOST = document.location.hostname;
var __AMBIENTE = '';
var __PERFILLOGADO = '';
var __HOST_CONFIGURADO = '';

SGFJU.Domain.UI.PageSetup = function () {
    return {
        Init: function () {

        }
    };
};

function ExecutarActionX072433() {

    swal({
        title: "Deseja realmente sair do sistema?",
        text: "Esta ação vai efetuar o Logout do sistema!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Sim, Desejo sair!",
        closeOnConfirm: false
    }, function () {
            $.ajax({
                type: "GET",
                url: "api/Usuarios/X072433/",
                contentType: "application/json"
            }).done(function () {
                window.location.replace('formLogin.aspx');
            });
    });

}

function ExecutaActionX072477() {
    $.ajax({
        type: "GET",
        url: "api/Usuarios/X072477/",
        contentType: "application/json"
    }).done(function (retorno) {
        $('#lnkDashboard').attr('href', retorno);
    });
}

var DI_LOGGED;

function ConfigurarPaginaX072470() {
    $.ajax({
        type: "GET",
        url: "api/Usuarios/X072470/",
        contentType: "application/json"
    }).done(function (retorno) {
        DI_LOGGED = retorno.IdEstadoUsuarioLogado;
        $("#lblNomeUsuario").html(retorno.NomeUsuario);
        $('#lblPerfilUsuario').html(retorno.NomePerfil + '<b class="caret"></b>');
        $('#imgUserConn').attr('height', '48px');
        $('#imgUserConn').attr('width', '48px');
        $('#imgUserConn').attr('src', hostUrl + retorno.PathImagemUsuario);
    });
}

function ToTitleCase(str) {

    if (str == null || str == undefined)
        return '';

    str = str.toLowerCase().split(' ');

    let final = [];

    for (let word of str) {
        final.push(word.charAt(0).toUpperCase() + word.slice(1));
    }

    return final.join(' ')

}

function camelize(str) {
    return str.replace(/(?:^\w|[A-Z]|\b\w|\s+)/g, function (match, index) {
        if (+match === 0) return ""; // or if (/\s+/.test(match)) for white spaces
        return index === 0 ? match.toLowerCase() : match.toUpperCase();
    });
}

function verificaAmbiente() {
    if (__HOST.indexOf('localhost') !== -1) {
        __AMBIENTE = 'Local';
    }
    else {
        __AMBIENTE = 'Produção';
    }
}

function configuraHOST() {
    if (__AMBIENTE == 'Local') {
        __HOST_CONFIGURADO = 'https://' + window.location.hostname + ':' + window.location.port;
    }
    else {
        __HOST_CONFIGURADO = 'http://' + window.location.hostname + '/SGFJU2.0/';
    }

}

function ConfiguraPerfilLogado() {
    var retornoFuncao = '';
    $.ajax({
        type: "GET",
        url: "api/Usuarios/X072470/",
        contentType: "application/json"
    }).done(function (retorno) {

        if (retorno.NomePerfil == 'Coordenador FJU Estadual') {
            configuraPerfilMenuSecretariaEstadual();
            retornoFuncao = 'Secretárias Estadual';
        }
        else if (retorno.NomePerfil == 'Secretárias Estadual') {
            configuraPerfilMenuSecretariaEstadual();
            retornoFuncao = 'Secretárias Estadual';
        }
        else if (retorno.NomePerfil == 'Secretária de Bloco') {
            retornoFuncao = 'Secretária de Bloco'
        }
        else if (retorno.NomePerfil == 'Secretária de Região') {
            retornoFuncao = 'Secretária de Região'
        }
        else if (retorno.NomePerfil == 'Secretária de Igreja') {
            retornoFuncao = 'Secretária de Igreja'
        }
    });

    return retornoFuncao;
}

function configuraPerfilMenuSecretariaEstadual() {
    
    var __TEMPLATE_ITEM_MENU = '<li><a class="dropdown-item" href="GerenciaUsuariosEstado.aspx"><i class="fa fa-address-book-o"></i> Gerenciar Usuários</a></li>';
    var ___ITEM_MENU_GERENCIA_ACOES = '<li><a class="dropdown-item" href="GerenciaAcoesUsuarios.html"><i class="fa fa-user-md"></i> Log de Ações dos Usuários</a></li>';
    //
    var menu = $('#itensMenuApp');

    if (menu != undefined && menu != null) {
        $('.dropdown-menu li:eq(0)').after(__TEMPLATE_ITEM_MENU);
        $('.dropdown-menu li:eq(0)').after(___ITEM_MENU_GERENCIA_ACOES);
    }
}

function configuraSinalizadorFichasExpiradas() {
    

}

function verify_IS() {
    $.ajax({
        type: "GET",
        url: "api/X/__IS",
        contentType: "application/json"
    }).done(function (retorno) {
        console.log('::Está logado !?!' + retorno.RequisicaoBemSucedida);
        if (!retorno.RequisicaoBemSucedida) {
            location.href = 'formlogin.aspx';
        }
    });
}

function registraSpinner() {
    var htmlSpinner = '<div id="overlay" onclick="spinnerOff()"> ' +
                      '< div class="w-100 d-flex justify-content-center align-items-center" > ' +
                      '    <div class="spinner"></div> ' +
                      '            </div > '+
                      '        </div >';

    
    $('.wrapper-content').append(htmlSpinner);
}

function spinnerOn() {
    document.getElementById("overlay").style.display = "flex";
}

function spinnerOff() {
    document.getElementById("overlay").style.display = "none";
}

function RRM_Function() {

    $.ajax({
        type: "GET",
        url: "api/X/RMM",
        contentType: "application/json"
    }).done(function (RMM) {

        $('.metismenu').append(RMM);

        $(".metismenu").metisMenu('dispose');
        $(".metismenu").metisMenu();
    });

}

$(document).ready(function () {
    //registraSpinner();

    verificaAmbiente();
    //console.log(__AMBIENTE);
    configuraHOST();
    //console.log('::: SGFJU.Host configurado é -> ' + __HOST_CONFIGURADO);
    verify_IS();

    RRM_Function();

    __PERFILLOGADO = ConfiguraPerfilLogado();
    console.log(__PERFILLOGADO);
});