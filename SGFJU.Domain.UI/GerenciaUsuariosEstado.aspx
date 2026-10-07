<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GerenciaUsuariosEstado.aspx.cs" Inherits="SGFJU.Domain.UI.GerenciaUsuariosEstado" %>

<!DOCTYPE html>
<html>

<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">

    <title>SGFJU | Sistema de Informações da FJU</title>

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet">

    <!-- Toastr style -->
    <link href="css/plugins/toastr/toastr.min.css" rel="stylesheet">

    <!-- Gritter -->
    <link href="js/plugins/gritter/jquery.gritter.css" rel="stylesheet">
    <link href="css/plugins/iCheck/custom.css" rel="stylesheet">
    <link href="css/plugins/steps/jquery.steps.css" rel="stylesheet">
    <link href="css/plugins/jasny/jasny-bootstrap.min.css" rel="stylesheet">

    <link href="css/plugins/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css" rel="stylesheet">    

    <link href="css/plugins/select2/select2.min.css" rel="stylesheet">
    
    <link href="css/plugins/datapicker/datepicker3.css" rel="stylesheet"

    <!-- Sweet Alert -->
    <link href="css/plugins/sweetalert/sweetalert.css" rel="stylesheet">

    <link href="css/plugins/dataTables/datatables.min.css" rel="stylesheet">

    <link href="css/animate.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">
    <link href="css/fju-tema.css" rel="stylesheet">
    

</head>

<body>
    <div id="wrapper">
        <nav class="navbar-default navbar-static-side" role="navigation">
            <div class="sidebar-collapse">
                <ul class="nav metismenu" id="side-menu">
                    <li class="nav-header">
                        <div class="dropdown profile-element">
                            <img id="imgUserConn" alt="image" class="rounded-circle" /><!-- se não der certo colocar novamente o arquivo anterior  -->
                            <a data-toggle="dropdown" class="dropdown-toggle" href="#">
                                <span id="lblNomeUsuario" class="block m-t-xs font-bold"></span>
                                <span id="lblPerfilUsuario" class="text-muted text-xs block">Art Director <b class="caret"></b></span>
                            </a>
                            <ul class="dropdown-menu animated fadeInRight m-t-xs">
                                <li><a class="dropdown-item" href="PerfilUsuario.html">Perfil</a></li>
                                <li class="dropdown-divider"></li>
                                <li><a class="dropdown-item" onclick="ExecutarActionX072433()"><i class="fa fa-sign-out"></i> Logout</a></li>
                            </ul>
                        </div>
                        <div class="logo-element">
                            FJU
                        </div>
                    </li>
                    <li>
                        <a href="RegistraJovem.aspx"><i class="fa fa-th-large"></i> <span class="nav-label">Voluntários</span> <span class="fa arrow"></span></a>
                        <ul class="nav nav-second-level">
                            <li><a href="RegistraJovem.aspx">Novo Jovem</a></li>
                        </ul>
                    </li>
                    <li>
                        <a href="#"><i class="fa fa-table"></i> <span class="nav-label">Consultas</span><span class="fa arrow"></span></a>
                        <ul class="nav nav-second-level collapse">
                            <li><a href="ConsultaGeralParametros.html">Geral Parâmetros</a></li>
                            <li><a href="TodosJovens.aspx">Todos</a></li>
                        </ul>
                    </li>
                    <li>
                        <a href="#"><i class="fa fa-edit"></i> <span class="nav-label">Gerenciar</span><span class="fa arrow"></span></a>
                        <ul class="nav nav-second-level collapse">                            
                            <li><a href="GerenciaIgrejasEstado.html">Igrejas</a></li>
                            <li><a href="GerenciaCoordenadoresEstado.html">Coordenadores</a></li>
                            <li><a href="GerenciaEstadualAltarJovem.html">Altar Jovem</a></li>
                            <li>
                                <a href="#"><i class="fa fa-tree"></i>Árvore da Vida <span class="fa arrow"></span></a>
                                <ul class="nav nav-third-level">
                                    <li>
                                        <a href="GerenciaArvoreDaVidaEstadual.html">Associar Jovens</a>
                                    </li>
                                    <li>
                                        <a href="GerenciaArvoreVidaObreiros.html">Obreiros</a>
                                    </li>
                                    <li>
                                        <a href="GerenciaArvoreVidaAcompanhamento.html">Acompanhamento</a>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </li>
                </ul>

            </div>
        </nav>

        <div id="page-wrapper" class="gray-bg dashbard-1">
        <div class="row border-bottom">
        <nav class="navbar navbar-static-top" role="navigation" style="margin-bottom: 0">
        <div class="navbar-header">
            <a class="navbar-minimalize minimalize-styl-2 btn btn-primary " href="#"><i class="fa fa-bars"></i> </a>
            <form role="search" class="navbar-form-custom" action="search_results.html">
                <div class="form-group">
                    <input type="text" placeholder="Pesquise por palavra-chave..." class="form-control" name="top-search" id="top-search">
                </div>
            </form>
        </div>
            <ul class="nav navbar-top-links navbar-right">
                <li style="padding: 20px">
                    <span class="m-r-sm text-muted welcome-message">Seja bem-vindo(a) ao SGFJU.</span>
                </li>                

                <li>
                    <a onclick="ExecutarActionX072433()">
                        <i class="fa fa-sign-out"></i> Log out
                    </a>
                </li>
                <li>
                    <a class="right-sidebar-toggle">
                        <i class="fa fa-tasks"></i>
                    </a>
                </li>
            </ul>

        </nav>
        </div>
            <!--Box abaixo doa parâmetros-->

            <div class="wrapper wrapper-content">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="ibox" id="iBoxParametrosPesquisa">
                            <div class="ibox-title">
                                <h5>Parâmetros de pesquisa</h5>
                            </div>
                            <div class="ibox-content">
                                <p>
                                
                                </p>

                                <div class="row">
                                    <div class="col-md-4">

                                        <p class="font-bold">
                                            Bloco
                                        </p>
                                        <select id="cboBloco" class="select2_demo_4 form-control">
                                            <option></option>
                                        </select>
                                    </div>
                                    <div class="col-md-4">
                                        <p class="font-bold">
                                            Região
                                        </p>
                                        <select id="cboRegiao" class="select2_demo_5 form-control">
                                            <option></option>                                                    
                                        </select>
                                    </div>
                                    <%--<div class="col-md-4">

                                        <p class="font-bold">
                                            Igreja
                                        </p>
                                        <select required id="cboIgreja" name="cboIgreja" class="form-control">
                                            <option></option>
                                        </select>
                                    </div>--%>

                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4">
                        <div class="panel panel-success">
                            <div class="panel-heading">
                                Ações
                            </div>
                            <div class="panel-body" align="center">
                                <button id="btnPesquisa" onclick="PesquisarPorParametro()" class="btn btn-success " type="button"><i class="fa fa-search"></i>&nbsp;Pesquisar</button>
                                <button id="btnRefresh" onclick="resetaPesquisa()" class="btn btn-info " type="button"><i class="fa fa-recycle"></i>&nbsp;Resetar</button>
                                <button id="btnCadastraUsuario" onclick="registraUsuario()" class="btn btn-info " type="button"><i class="fa fa-user-plus"></i>&nbsp;Cadastrar</button>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                Usuários retornados pela consulta
                            </div>
                            <div class="panel-body" align="center">
                                <h1 class="no-margins" id="lblQuantidadeResgistrosRetornados"></h1>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row" id="rowResultado">
                    <div class="col-lg-12">
                        <div class="ibox" id="iBoxResultadoPesquisa">
                            <div class="ibox-title">
                                <h5>Usuários do Estado</h5>
                            </div>
                            <div class="ibox-content">
                                <div class="panel panel-success" id="pnlPesquisa">
                            <div class="panel-heading">
                                Dados Retornados
                            </div>
                            <div class="panel-body" align="center">
                                <!-- DataTable-->
                                <div class="table-responsive">
                                    <table id="tblTodosUsuarios" 
                                            class="table table-striped table-bordered table-hover dataTables-example" >
                                        <thead>
                                            <tr>
                                                <th>IdUsuario</th>
                                                <th>Estado</th>
                                                <th>Bloco</th>
                                                <th>Região</th>
                                                <th>Nome do Usuario</th>
                                                <th>Login</th>
                                                <th>Perfil</th>
                                                <th>Editar</th>
                                            </tr>
                                        </thead>
                                        <tbody>

                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <th>IdUsuario</th>
                                                <th>Estado</th>
                                                <th>Bloco</th>
                                                <th>Região</th>
                                                <th>Nome do Usuario</th>
                                                <th>Login</th>
                                                <th>Perfil</th>
                                                <th>Editar</th>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </div>
                                <!-- End DataTable -->
                            </div>
                        </div>
                            </div>

                        </div>
                        
                    </div>
                </div>
            </div>

            <!-- modal fora da tab para testar se é enxergada gglobalmente -->
            <div class="modal inmodal" id="visualizaJovemModal" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content animated bounceInRight">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                            <%--<i class="fa fa-laptop modal-icon"></i>--%>
                            <i class="glyphicon glyphicon-transfer modal-icon"></i>
                            <h4 class="modal-title">Visualização de dados</h4>
                            <small class="font-bold">Dados do Jovem</small>
                        </div>
                        <div class="modal-body">
                            <!---->
                            <div class="contact-box center-version">

                                

                                    <img alt="image" class="rounded-circle" src="" id="imgFotoJovem">


                                    <h3 class="m-b-xs" id="lblNomeJovem"><strong></strong></h3>

                                    <div class="font-bold">Informações</div>
                                    <address class="m-t-md">
                                        <strong><span id="lblEstado"></span></strong><br>
                                        <span id="lblBloco"></span><br>
                                        <span id="lblRegiao"></span><br>
                                        <span id="lblIgreja"></span><br>
                                        <abbr title="Phone" id="lblWhats">Whatsapp</abbr>
                                    </address>

                                
                                <div class="contact-box-footer">
                                    <div class="m-t-xs btn-group">
                                        <a href=""  class="btn btn-xs btn-white"><i class="fa fa-phone"></i> Call </a>
                                        <a href=""  class="btn btn-xs btn-white"><i class="fa fa-envelope"></i> Email</a>
                                        <a href=""  class="btn btn-xs btn-white"><i class="fa fa-user-plus"></i> Follow</a>
                                    </div>
                                </div>

                            </div>
                            <!---->
                        <div class="modal-footer">
                            <button type="button" class="btn btn-white" data-dismiss="modal">Fechar</button>
                        </div>
                    </div>
                </div>
            </div>
            <!---->
            <!-- box abaixo da grid -->
            
            <div class="wrapper wrapper-content">
            <div class="row">
                <div class="col-lg-12">
                        <div class="row">

                            <div class="col-lg-4">
                            
                            
                            </div>
                            <div class="col-lg-4">
                                

                            </div>
                            <div class="col-lg-4">
                            
                            </div>

                        </div>
                </div>

            </div>
        </div>
            <div class="footer">
                <div class="float-right">
                     <strong></strong> 
                </div>
                <div>
                    <strong>Copyright</strong> FJU Oficial &copy; 2020
                </div>
            </div>
        </div>
    </div>

    <!-- Mainly scripts -->
    <script src="js/jquery-3.1.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.js"></script>
    <script src="js/plugins/metisMenu/jquery.metisMenu.js"></script>
    <script src="js/plugins/slimscroll/jquery.slimscroll.min.js"></script>

    <!-- Custom and plugin javascript -->
    <script src="js/inspinia.js"></script>
    <script src="js/plugins/pace/pace.min.js"></script>

    <!-- Steps -->
    <script src="js/plugins/steps/jquery.steps.min.js"></script>

    <!-- Jquery Validate -->
    <script src="js/plugins/validate/jquery.validate.min.js"></script>

    <!-- Select2 -->
    <script src="js/plugins/select2/select2.full.min.js"></script>

    <!-- Input Mask-->
    <script src="js/plugins/jasny/jasny-bootstrap.min.js"></script>

   <!-- Data picker -->
   <script src="js/plugins/datapicker/bootstrap-datepicker.js"></script>

    <!-- iCheck -->
    <script src="js/plugins/iCheck/icheck.min.js"></script>

    <script src="js/plugins/dataTables/datatables.min.js"></script>
    <script src="js/plugins/dataTables/dataTables.bootstrap4.min.js"></script>

    <!-- Toastr script -->
    <script src="js/plugins/toastr/toastr.min.js"></script>

    <!-- Sweet alert -->
    <script src="js/plugins/sweetalert/sweetalert.min.js"></script>

    <script src="js/SGFJU.Domain.UI.Client.js"></script>
    <script src="js/SGFJU.Domain.UI.Client.Facade.js"></script>
    <script src="js/SGFJU.Domain.UI.PageSetup.js"></script>

    <script>

        var __resultSetTodosUsuarios = null;
        var __resultSetTodosUsuariosEstado = null;
        var facadeUser = new SGFJU.Domain.Model.UI.Client.Facade.UsuarioFacade();
        var tblTodosUsuarios;
        var dadoUsuarioSelecionado = undefined;
        var hostUrl = "http://" + document.location.hostname;
        var primeiraPesquisa = false;
        var vExisteUltimoPesquisaRetorno = false;

        $(document).ready(function () {

            $("#cboBloco").select2();
            $("#cboRegiao").select2();
            $("#cboIgreja").select2();

            todosUsuariosEstadoLogado();
            
            $('#tblTodosUsuarios tbody').on('click', 'button', function () {
                var classeDoBotao = $(this).prop('class');
                var indiceDaLinha = tblTodosUsuarios.row($(this).parents('tr')).index();
                var idUsuarioX = __resultSetTodosUsuarios[indiceDaLinha].IdUsuarioX;
                var nomeUsuario = __resultSetTodosUsuarios[indiceDaLinha].NomeUsuario;
                dadoUsuarioSelecionado = __resultSetTodosUsuarios[indiceDaLinha];

                if (classeDoBotao == 'btn btn-primary btn-xs dt-edit')
                    location.href = 'AlteraUsuario.aspx?x=' + idUsuarioX;
                else if (classeDoBotao == 'btn btn-danger btn-xs dt-delete')
                    excluirUsuario(idUsuarioX, nomeUsuario);
            });
            
            facadeUser.ConfigurarPaginaX072470();

            $('#iBoxParametrosPesquisa').children('.ibox-content').toggleClass('sk-loading');

            $.ajax({
                type: "GET",
                url: 'api/blocos/ObterPorEstadoLogado',
                contentType: "application/json"
            }).done(function (retorno) {
                $('#iBoxParametrosPesquisa').children('.ibox-content').toggleClass('sk-loading');
                $.each(retorno, function () {
                    $("#cboBloco").append($("<option     />").val(this.idBloco).text(this.NomeBloco));
                });
                $("#cboBloco").prepend('<option selected class="placeholdered" value="">Selecione o bloco</option>');
                $('#cboBloco').select2().trigger('change');
                $('#cboBloco').removeAttr('selected');
            });

            $('.select2_demo_4').on('select2:select', function (e) {                
                var data = e.params.data;
                preencherComboRegioes(data.id);
            });

            $('.select2_demo_5').on('select2:select', function (e) {                
                var data = e.params.data;
                preencherComboIgrejas(data.id);
            });

        });

        function todosUsuariosEstadoLogado() {
            $.ajax({
                type: "GET",
                url: 'api/Usuarios/RetornaUsuarioEstadoLogado',
                contentType: "application/json"
            }).done(function (resultSetRetorno) {
                __resultSetTodosUsuarios = resultSetRetorno;
                __resultSetTodosUsuariosEstado = resultSetRetorno;

                tblTodosUsuarios = $('#tblTodosUsuarios').DataTable({
                    data: resultSetRetorno,
                    destroy: true,
                    pageLength: 30,
                    paging: true,
                    dom: 'Bfrtip',
                    buttons: [
                        'csv', 'excel', 'pdf', 'print'
                    ],
                    columns: [
                        { data: 'IdUsuarioX' },
                        { data: 'NomeEstadoUsuario' },
                        { data: 'NomeBlocoUsuario' },
                        { data: 'NomeRegiaoUsuario' },
                        { data: 'NomeUsuario' },
                        { data: 'Login' },
                        { data: 'NomePerfil' },
                        {
                            data: null,
                            defaultContent: '<div class="btn-group"> <button type="button" class="btn btn-primary btn-xs dt-edit" style="margin-right:16px;"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></button><button type="button" class="btn btn-danger btn-xs dt-delete"><span class="glyphicon glyphicon-remove glyphicon-trash" aria-hidden="true"></span></button></div>'
                        }
                    ],
                    columnDefs: [
                        {
                            targets: [0],
                            visible: false,
                            searchable: false
                        }]
                });
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

        function PesquisarPorParametro() {
            $('#iBoxResultadoPesquisa').children('.ibox-content').toggleClass('sk-loading');//#spinner
            var parametroPesquisaDTO = {
                IdEstado: 0,
                IdBloco: $('#cboBloco').val(),
                IdRegiao: $('#cboRegiao').val()
            };
            
            $.ajax({
                type: "post",
                data: JSON.stringify(parametroPesquisaDTO),
                url: "api/Usuarios/PesquisaUsuariosPorParametro",
                contentType: "application/json"
            }).done(function (resultSetPesquisa) {
                __resultSetTodosUsuarios = resultSetPesquisa;
                $('#iBoxResultadoPesquisa').children('.ibox-content').toggleClass('sk-loading');//#spinner

                tblTodosUsuarios = $('#tblTodosUsuarios').DataTable({
                    data: resultSetPesquisa,
                    destroy: true,
                    dom: 'Bfrtip',
                    buttons: [
                        'csv', 'excel', 'pdf', 'print'
                    ],
                    columns: [
                        { data: 'IdUsuarioX' },
                        { data: 'NomeEstadoUsuario' },
                        { data: 'NomeBlocoUsuario' },
                        { data: 'NomeRegiaoUsuario' },
                        { data: 'NomeUsuario' },
                        { data: 'Login' },
                        { data: 'NomePerfil' },
                        {
                            data: null,
                            defaultContent: '<div class="btn-group"> <button type="button" class="btn btn-primary btn-xs dt-edit" style="margin-right:16px;"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></button><button type="button" class="btn btn-danger btn-xs dt-delete"><span class="glyphicon glyphicon-remove glyphicon-trash" aria-hidden="true"></span></button></div>'
                        }
                    ],
                    columnDefs: [
                        {
                            targets: [0],
                            visible: false,
                            searchable: false
                        }]
                });

                $('#lblQuantidadeResgistrosRetornados').html(tblTodosUsuarios.data().count());
            });
        }

        function RefreshGrid() {
            var table = $('#tblTodosUsuarios').DataTable();
            table.clear();
            table.rows.add(__resultSetTodosUsuariosEstado).draw();
        }

        function registraUsuario() {
            location.href = 'RegistraUsuario.aspx';
        }

        function excluirUsuario(idUsuario, nomeUsuario) {
            $('#iBoxResultadoPesquisa').children('.ibox-content').toggleClass('sk-loading');//#spinner

            var usuarioParaExcluirDTO = {
                IdUsuarioX: idUsuario
            };

            swal({
                title: "Deseja realmente excluir o Usuário? " + nomeUsuario,
                text: "Esta ação NÃO poderá ser revertida",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Sim, Desejo Excluir!",
                closeOnConfirm: false
            }, function (isConfirm) {
                    if (isConfirm) {
                        $.ajax({
                            type: "POST",
                            data: JSON.stringify(usuarioParaExcluirDTO),
                            url: "api/Usuarios/ExcluirUsuario",
                            contentType: "application/json"
                        }).done(function (respostaExclusao) {
                            $('#iBoxResultadoPesquisa').children('.ibox-content').toggleClass('sk-loading');//#spinner
                            swal({
                                title: "Confirmação",
                                text: "Usuario excluido com sucesso!",
                                type: "success"
                            }, function () {
                                todosUsuariosEstadoLogado();
                            });

                        });
                    }
                    else {
                        $('#iBoxResultadoPesquisa').children('.ibox-content').toggleClass('sk-loading');//#spinner
                    }
            });
        }

        function resetaPesquisa() {
            RefreshGrid();
            $('#cboBloco').val($('#cboBloco option:first-child').val()).trigger('change');
            $('#cboRegiao').empty().trigger('change');
            $('#lblQuantidadeResgistrosRetornados').html('');
        }
    </script>
</body>
</html>
