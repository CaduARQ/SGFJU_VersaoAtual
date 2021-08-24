function ConfiguraPerfilUsuarioLogado() {
    $.ajax({
        type: "GET",
        url: "api/Usuarios/X072470/",
        contentType: "application/json"
    }).done(function (retorno) {

        if (retorno.NomePerfil == 'Secretárias Estadual') {
            _PERFILLOGADO = 'Secretárias Estadual'
            $('#lblIdentificadorEstado_Bloco').text('Estado ' + retorno.NomeEstadoUsuarioLogado);
            $('#lblIdentificadorEstado_Bloco2').text('Estado ' + retorno.NomeEstadoUsuarioLogado);

            configComboEstado();
        }
        else if (retorno.NomePerfil == 'Secretária de Bloco') {
            _PERFILLOGADO = 'Secretária de Bloco'
            $('#lblIdentificadorEstado_Bloco').text('Bloco ' + retorno.NomeBlocoUsuario);
            $('#lblIdentificadorEstado_Bloco2').text('Bloco ' + retorno.NomeBlocoUsuario);

            configComboPerfilBloco();
        }
        else if (retorno.NomePerfil == 'Secretária de Região') {
            _PERFILLOGADO = 'Secretária de Região'

            $('#lblIdentificadorEstado_Bloco').text('Região ' + retorno.NomeRegiaoUsuario);
            $('#lblIdentificadorEstado_Bloco2').text('Região ' + retorno.NomeRegiaoUsuario);

            configComboPerfilRegiao();
        }
        else if (retorno.NomePerfil == 'Secretária de Igreja') {
            _PERFILLOGADO = 'Secretária de Igreja'
        }
    });
}

function configComboEstado() {
    $.ajax({
        type: "GET",
        url: "api/Usuarios/X072470/",
        contentType: "application/json"
    }).done(function (retorno) {
        $("#cboEstado").val(retorno.IdEstadoUsuarioLogado).trigger('change.select2');
        $('#cboEstado').prop("disabled", true);
        preencherComboBlocos(retorno.IdEstadoUsuarioLogado);
    });
}

function configComboPerfilBloco() {
    $.ajax({
        type: "GET",
        url: "api/Usuarios/X072470/",
        contentType: "application/json"
    }).done(function (retorno) {

        $("#cboEstado").val(retorno.IdEstadoUsuarioLogado).trigger('change.select2');
        $('#cboEstado').prop("disabled", true);

        preencherComboBlocosToBlocos(retorno.IdEstadoUsuarioLogado, retorno.IdBloco);

        preencherComboRegioes(retorno.IdBloco);
    });
}

function configComboPerfilRegiao() {
    $.ajax({
        type: "GET",
        url: "api/Usuarios/X072470/",
        contentType: "application/json"
    }).done(function (retorno) {

        $("#cboEstado").val(retorno.IdEstadoUsuarioLogado).trigger('change.select2');
        $('#cboEstado').prop("disabled", true);

        preencherComboBlocosToBlocos(retorno.IdEstadoUsuarioLogado, retorno.IdBloco);

        preencherComboRegioesToRegioes(retorno.IdBloco, retorno.IdRegiao);

        preencherComboIgrejas(retorno.IdRegiao);
    });
}

function preencherComboBlocos(idEstado) {
    $.ajax({
        type: "GET",
        url: "api/blocos/ObterPorEstado/" + idEstado,
        contentType: "application/json"
    }).done(function (retorno) {
        __blocosEstadoLogado = retorno;

        $.each(retorno, function () {
            $("#cboBloco").append($("<option     />").val(this.Id).text(this.NomeBloco));
        });
        $("#cboBloco").prepend('<option selected class="placeholdered" value="">Selecione o bloco</option>');
        $('#cboBloco').select2().trigger('change');
        $('#cboBloco').removeAttr('selected');
    });
}

function preencherComboBlocosToBlocos(idEstado, idBloco) {
    $.ajax({
        type: "GET",
        url: "api/blocos/ObterPorEstado/" + idEstado,
        contentType: "application/json"
    }).done(function (retorno) {
        __blocosEstadoLogado = retorno;

        $.each(retorno, function () {
            $("#cboBloco").append($("<option     />").val(this.Id).text(this.NomeBloco));
        });

        $("#cboBloco").val(idBloco).attr('selected', true);
        $('#cboBloco').select2().trigger('change');
        $('#cboBloco').prop("disabled", true);
    });
}

function preencherComboRegioes(idBloco) {
    $.ajax({
        type: "GET",
        url: "api/Regioes/ObterPorBloco/" + idBloco,
        contentType: "application/json"
    }).done(function (retorno) {
        $.each(retorno, function () {
            $("#cboRegiao").append($("<option     />").val(this.IdRegiao).text(this.NomeRegiao));
        });
        $("#cboRegiao").prepend('<option selected class="placeholdered" value="">Selecione a região</option>');
        $('#cboRegiao').select2().trigger('change');
        $('#cboRegiao').removeAttr('selected');
    });
}

function preencherComboRegioesToRegioes(idBloco, idRegiao) {
    $.ajax({
        type: "GET",
        url: "api/Regioes/ObterPorBloco/" + idBloco,
        contentType: "application/json"
    }).done(function (retorno) {
        $.each(retorno, function () {
            $("#cboRegiao").append($("<option     />").val(this.IdRegiao).text(this.NomeRegiao));
        });

        $("#cboRegiao").val(idRegiao).attr('selected', true);
        $('#cboRegiao').select2().trigger('change');
        $('#cboRegiao').prop("disabled", true);
    });
}

function preencherComboIgrejas(idRegiao) {
    $.ajax({
        type: "get",
        url: "api/Igrejas/ObterPorRegiao/" + idRegiao,
        contentType: "application/json"
    }).done(function (retorno) {
        $.each(retorno, function () {
            $("#cboIgreja").append($("<option     />").val(this.IdIgreja).text(this.NomeIgreja));
        });
        $("#cboIgreja").prepend('<option selected class="placeholdered" value="">Selecione a igreja</option>');
        $('#cboIgreja').select2().trigger('change');
        $('#cboIgreja').removeAttr('selected');
    });
}