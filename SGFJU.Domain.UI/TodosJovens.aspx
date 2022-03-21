<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TodosJovens.aspx.cs" Inherits="SGFJU.Domain.UI.TesteDataTable" %>

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
                <li class="dropdown">
                    <a class="dropdown-toggle count-info" data-toggle="dropdown" href="#">
                        <i class="fa fa-envelope"></i>  <span class="label label-warning">16</span>
                    </a>
                    <ul class="dropdown-menu dropdown-messages dropdown-menu-right">
                        <li>
                            <div class="dropdown-messages-box">
                                <a class="dropdown-item float-left" href="profile.html">
                                    <img alt="image" class="rounded-circle" src="img/a7.jpg">
                                </a>
                                <div class="media-body">
                                    <small class="float-right">46h ago</small>
                                    <strong>Mike Loreipsum</strong> started following <strong>Monica Smith</strong>. <br>
                                    <small class="text-muted">3 days ago at 7:58 pm - 10.06.2014</small>
                                </div>
                            </div>
                        </li>
                        <li class="dropdown-divider"></li>
                        <li>
                            <div class="dropdown-messages-box">
                                <a class="dropdown-item float-left" href="profile.html">
                                    <img alt="image" class="rounded-circle" src="img/a4.jpg">
                                </a>
                                <div class="media-body ">
                                    <small class="float-right text-navy">5h ago</small>
                                    <strong>Chris Johnatan Overtunk</strong> started following <strong>Monica Smith</strong>. <br>
                                    <small class="text-muted">Yesterday 1:21 pm - 11.06.2014</small>
                                </div>
                            </div>
                        </li>
                        <li class="dropdown-divider"></li>
                        <li>
                            <div class="dropdown-messages-box">
                                <a class="dropdown-item float-left" href="profile.html">
                                    <img alt="image" class="rounded-circle" src="img/profile.jpg">
                                </a>
                                <div class="media-body ">
                                    <small class="float-right">23h ago</small>
                                    <strong>Monica Smith</strong> love <strong>Kim Smith</strong>. <br>
                                    <small class="text-muted">2 days ago at 2:30 am - 11.06.2014</small>
                                </div>
                            </div>
                        </li>
                        <li class="dropdown-divider"></li>
                        <li>
                            <div class="text-center link-block">
                                <a href="mailbox.html" class="dropdown-item">
                                    <i class="fa fa-envelope"></i> <strong>Read All Messages</strong>
                                </a>
                            </div>
                        </li>
                    </ul>
                </li>
                <li class="dropdown">
                    <a class="dropdown-toggle count-info" data-toggle="dropdown" href="#">
                        <i class="fa fa-bell"></i>  <span class="label label-primary">8</span>
                    </a>
                    <ul class="dropdown-menu dropdown-alerts">
                        <li>
                            <a href="mailbox.html" class="dropdown-item">
                                <div>
                                    <i class="fa fa-envelope fa-fw"></i> You have 16 messages
                                    <span class="float-right text-muted small">4 minutes ago</span>
                                </div>
                            </a>
                        </li>

                    </ul>
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
                                    <div class="col-md-4">

                                        <p class="font-bold">
                                            Igreja
                                        </p>
                                        <select required id="cboIgreja" name="cboIgreja" class="form-control">
                                            <option></option>
                                        </select>
                                    </div>

                                </div>

                                <hr class="hr-line-solid" />

                                <div class="row">
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label class="text-danger font-bold" for="form_name">Foto está no diretório</label>
                                            <div class="row">
                                                <div class="col-2">
                                                    <div class="radio radio-danger  radio-inline">
                                                        <input type="radio" name="rbTemFoto" id="rbTemFoto_S" value="S">
                                                        <label for="rbTemFoto_S">
                                                            Sim
                                                        </label>
                                                    </div>
                                                </div>
                                                <div class="col-2">
                                                    <div class="radio radio-danger radio-inline">
                                                        <input type="radio" name="rbTemFoto" id="rbTemFoto_N" value="N" >
                                                        <label for="rbTemFoto_N">
                                                            Não
                                                        </label>
                                                    </div>
                                                </div>
                                            </div>  
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-3">
                        <div class="panel panel-success">
                            <div class="panel-heading">
                                Ações
                            </div>
                            <div class="panel-body" align="center">
                                <button id="btnPesquisa" onclick="PesquisarPorParametro('')" class="btn btn-success " type="button"><i class="fa fa-search"></i>&nbsp;Pesquisar</button>
                                <button id="btnRefresh" onclick="resetaPesquisa()" class="btn btn-info " type="button"><i class="fa fa-recycle"></i>&nbsp;Reseta Pesquisa</button>
                                <button id="btnFichasExpiradas" onclick="PesquisarPorParametro('S')" class="btn btn-danger " type="button"><i class="fa fa-recycle"></i>&nbsp;Fichas Expiradas</button>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                Número de Jovens retornados pela consulta
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
                                <h5>Resultado da pesquisa</h5>
                            </div>
                            <div class="ibox-content">
                                <div class="panel panel-success" id="pnlPesquisa">
                            <div class="panel-heading">
                                Dados Retornados
                            </div>
                            <div class="panel-body" align="center">
                                <!-- DataTable-->
                                <div class="table-responsive">
                                    <table id="tblTodosJovens" 
                                            class="table table-striped table-bordered table-hover dataTables-example" >
                                        <thead>
                                            <tr>
                                                <th>IdJovem</th>
                                                <th>IdX</th>
                                                <th>Estado</th>
                                                <th>Bloco</th>
                                                <th>Região</th>
                                                <th>Igreja</th>
                                                <th>Nome</th>                                                
                                                <th>Foto</th>
                                                <th>AV</th>
                                                <th>Whatsapp</th>
                                                <th>Editar</th>
                                            </tr>
                                        </thead>
                                        <tbody>

                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <th>IdJovem</th>
                                                <th>IdX</th>
                                                <th>Estado</th>
                                                <th>Bloco</th>
                                                <th>Região</th>
                                                <th>Igreja</th>
                                                <th>Nome</th>
                                                <th>Foto</th>
                                                <th>Whatsapp</th>
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

        var __resultSetTodosJovens = null;
        var facadeUser = new SGFJU.Domain.Model.UI.Client.Facade.UsuarioFacade();
        var tblTodosJovens;
        var dadoJovemSelecionado = undefined;
        var hostUrl = "http://" + document.location.hostname;
        var primeiraPesquisa = false;
        var vExisteUltimoPesquisaRetorno = false;
        var __EH_RESULTSET_FICHAS_EXPIRADAS = undefined;

        $(document).ready(function () {

            $("#cboBloco").select2();
            $("#cboRegiao").select2();
            $("#cboIgreja").select2();

            /**/
            $.ajax({
                type: "GET",
                url: 'api/Jovens/ObterUltimaPesquisaTodosJovens/',
                contentType: "application/json"
            }).done(function (retorno) {

                if (retorno.ExisteUltimaPesquisa) {

                    var resultSetRetorno = retorno.ResultSetUltimaPesquisa;
                    __resultSetTodosJovens = resultSetRetorno;

                    tblTodosJovens = $('#tblTodosJovens').DataTable({
                        data: resultSetRetorno,
                        dom: 'Bfrtip',
                        buttons: [
                            'csv', 'excel', 'pdf', 'print'
                        ],
                        columns: [
                            { data: 'IdJovem' },
                            { data: 'NomeEstado' },
                            { data: 'NomeBlocoJovem' },
                            { data: 'NomeRegiaoJovem' },
                            { data: 'NomeIgrejaJovem' },
                            { data: 'NomeJovem' },
                            {
                                data: 'FotoEstaNoDiretorio',
                                render: function (data, type, row) {
                                    console.log(row.NomeArquivoFoto);
                                    if (data == "S") {
                                        var urlImgEncoded = encodeURI(__HOST_CONFIGURADO + '/FotosJovens/' + row.NomeArquivoFoto);
                                        return "<img src=" + urlImgEncoded + " class='rounded-circle img-sm'  />";
                                    }
                                    else {
                                        return "<img src=" + __HOST_CONFIGURADO + '/img/jovemsemfoto.jpg' + " class='rounded-circle img-sm' />"
                                    }
                                }
                            },
                            {
                                data: 'EstaSendoAcompanhadoAV',
                                width: "10%",
                                render: function (data, type, row) {
                                    if (data == true) {
                                        return "<img src=" + __HOST_CONFIGURADO + '/img/details_open.png' + " class='rounded-circle img-sm' />"
                                    }
                                    else {
                                        return "<img src=" + __HOST_CONFIGURADO + '/img/details_close.png' + " class='rounded-circle img-sm' />"
                                    }
                                }
                            },
                            { data: 'Whatsapp' },
                            {
                                data: null,
                                defaultContent: '<div class="btn-group"> <button type="button" alt="Visualizar" class="btn btn-info btn-xs dt-view" style="margin-right:16px;"><span class="glyphicon glyphicon-search " aria-hidden="true"></span></button>  <button type="button" class="btn btn-primary btn-xs dt-edit" style="margin-right:16px;"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></button> <button type="button" class="btn btn-danger btn-xs dt-delete"><span class="glyphicon glyphicon-remove glyphicon-trash" aria-hidden="true"></span></button></div>' 
                            }
                        ],
                        columnDefs: [
                            {
                                targets: [0, 1],
                                visible: false,
                                searchable: false
                            }]
                    });

                    $('#lblQuantidadeResgistrosRetornados').html(tblTodosJovens.data().count());
                }
            });
            /**/
            
            $('#tblTodosJovens tbody').on('click', 'button', function () {
                var classeDoBotao = $(this).prop('class');
                var indiceDaLinha = tblTodosJovens.row($(this).parents('tr')).index();
                var idJovem = __resultSetTodosJovens[indiceDaLinha].IdJovem;
                var idX = __resultSetTodosJovens[indiceDaLinha].IdX;
                var nomeJovem = __resultSetTodosJovens[indiceDaLinha].NomeJovem;
                dadoJovemSelecionado = __resultSetTodosJovens[indiceDaLinha];

                if (classeDoBotao == 'btn btn-primary btn-xs dt-edit')
                    location.href = 'AlteraJovem.aspx?idJovem=' + idJovem;
                else if (classeDoBotao == 'btn btn-danger btn-xs dt-delete')
                    excluirJovem(idJovem, nomeJovem);
                else if (classeDoBotao == 'btn btn-info btn-xs dt-view')
                    location.href = 'VisualizaJovemE.html?idJovem=' + idJovem + '&SPG=TJ';
                else if (classeDoBotao == 'btn btn-warning btn-xs dt-button-info') 
                    location.href = 'GerenciaArvoreVidaAcompanhamento.html?x=' + idX;
            });
            
            facadeUser.ConfigurarPaginaX072470();

            ConfiguraPerfilUsuarioLogadoTJ();

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
                $('#ibox1').children('.ibox-content').toggleClass('sk-loading');
                $('#cboRegiao').empty().trigger("change");
                $('#cboIgreja').empty().trigger("change");
                var data = e.params.data;
                preencherComboRegioes(data.id);
            });

            $('.select2_demo_5').on('select2:select', function (e) {     
                $('#ibox1').children('.ibox-content').toggleClass('sk-loading');//#spinner
                $('#cboIgreja').empty().trigger("change");
                var data = e.params.data;
                preencherComboIgrejas(data.id);
            });

        });

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

        function PesquisarPorParametro(EhPararListarExpiradas) {
            $('#iBoxResultadoPesquisa').children('.ibox-content').toggleClass('sk-loading');//#spinner
            var vEhPararListarExpiradas = (EhPararListarExpiradas != '') ? EhPararListarExpiradas : '';
            __EH_RESULTSET_FICHAS_EXPIRADAS = (EhPararListarExpiradas != '') ? true : false;

            var parametroPesquisaDTO = {
                IdEstado: 0,
                IdBlocoJovem: $('#cboBloco').val(),
                IdRegiaoJovem: $('#cboRegiao').val(),
                IdIgreja: $('#cboIgreja').val(),
                FotoEstaNoDiretorio: $('input[name=rbTemFoto]:checked').val(),
                EhParaListarFichasExpiradas: vEhPararListarExpiradas
            };
            
            $.ajax({
                type: "post",
                data: JSON.stringify(parametroPesquisaDTO),
                url: "api/Jovens/PesquisarPorParametro",
                contentType: "application/json"
            }).done(function (resultSetPesquisa) {
                __resultSetTodosJovens = resultSetPesquisa;
                $('#iBoxResultadoPesquisa').children('.ibox-content').toggleClass('sk-loading');//#spinner

                if (primeiraPesquisa == false) {
                    primeiraPesquisa = true;

                    tblTodosJovens = $('#tblTodosJovens').DataTable({
                        data: resultSetPesquisa,
                        destroy: true,
                        dom: 'Bfrtip',
                        buttons: [
                            'csv', 'excel', 'pdf', 'print'
                        ],
                        columns: [
                            { data: 'IdJovem' },
                            { data: 'IdX' },
                            { data: 'NomeEstado' },
                            { data: 'NomeBlocoJovem' },
                            { data: 'NomeRegiaoJovem' },
                            { data: 'NomeIgrejaJovem' },
                            {
                                data: 'NomeJovem',
                                render: function (data, type, row) {
                                    //'NomeJovem'
                                    console.log('::valor do parâmetro ->'+EhPararListarExpiradas);
                                    if (vEhPararListarExpiradas == 'S')
                                        return '<span id="lblClassificacao" class="label-danger">' + row.NomeJovem + '</span>';
                                    else
                                        return row.NomeJovem;
                                }
                            },
                            {
                                data: 'FotoEstaNoDiretorio',
                                render: function (data, type, row) {
                                    if (data == "S") {
                                        var urlImgEncoded = encodeURI(__HOST_CONFIGURADO + '/FotosJovens/' + row.NomeArquivoFoto);
                                        return "<img src=" + urlImgEncoded + " class='rounded-circle img-sm'  />";
                                    }
                                    else {
                                        return "<img src=" + __HOST_CONFIGURADO + '/img/jovemsemfoto.jpg' + " class='rounded-circle img-sm' />" 
                                    }
                                }
                            },
                            {
                                data: 'EstaSendoAcompanhadoAV',
                                width: "10%",
                                render: function (data, type, row) {
                                    if (data == true) {
                                        return "<img src=" + __HOST_CONFIGURADO + '/img/details_open.png' + " class='rounded-circle img-sm' />"
                                    }
                                    else {
                                        return "<img src=" + __HOST_CONFIGURADO + '/img/details_close.png' + " class='rounded-circle img-sm' />"
                                    }
                                }
                            },
                            { data: 'Whatsapp' },
                            {
                                data: null,
                                defaultContent: '<div class="btn-group"> <button type="button" alt="Visualizar" class="btn btn-info btn-xs dt-view" style="margin-right:16px;"><span class="glyphicon glyphicon-search " aria-hidden="true"></span></button>  <button type="button" class="btn btn-primary btn-xs dt-edit" style="margin-right:16px;"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></button> <button type="button" class="btn btn-danger btn-xs dt-delete"><span class="glyphicon glyphicon-remove glyphicon-trash" aria-hidden="true"></span></button></div>' 
                            }
                        ],
                        columnDefs: [
                            {
                                targets: [0,1],
                                visible: false,
                                searchable: false
                            }]
                    });

                    
                    
                    $('#lblQuantidadeResgistrosRetornados').html(tblTodosJovens.data().count());
                }
                else {
                    var table = $('#tblTodosJovens').DataTable();
                    table.clear();
                    table.rows.add(resultSetPesquisa).draw();

                    $('#lblQuantidadeResgistrosRetornados').html(table.data().count());
                }

                vEhPararListarExpiradas = undefined;
            });
        }

        function RefreshGrid() {
            var table = $('#tblTodosJovens').DataTable();
            table.clear();
            table.rows.add(__resultSetTodosJovens).draw();
        }

        function excluirJovem(idJovem, nomeJovem) {
            var todosJovensDTO = {
                IdJovem: idJovem
            };
            
            swal({
                title: "Deseja realmente excluir o jovem? " +  nomeJovem,
                text: "Esta ação NÃO poderá ser revertida",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Sim, Desejo Excluir!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    type: "POST",
                    data: JSON.stringify(todosJovensDTO),
                    url: "api/Jovens/ExcluirJovem",
                    contentType: "application/json"
                }).done(function (respostaExclusao) {                    
                    swal({
                        title: "Confirmação",
                        text: "Jovem excluido com sucesso!",
                        type: "success"
                    });

                });
            });
            
        }

        function resetaPesquisa() {
            $('#cboBloco').val($('#cboBloco option:first-child').val()).trigger('change');
            $('#cboRegiao').empty().trigger("change");
            $('#cboIgreja').empty().trigger("change");
            $('#lblQuantidadeResgistrosRetornados').html('');

            $.ajax({
                type: "GET",
                url: "api/Jovens/LimpaPesquisaTJ/",
                contentType: "application/json"
            }).done(function (retorno) {
                var objTable = $('#tblTodosJovens').DataTable();
                objTable.clear().draw();
                swal({
                    title: "Mensagem de notificação",
                    text: retorno.MensagemRespostaRequisicao,
                    type: "success"
                });
            });
        }

        function ConfiguraPerfilUsuarioLogadoTJ() {
            $.ajax({
                type: "GET",
                url: "api/Usuarios/X072470/",
                contentType: "application/json"
            }).done(function (retorno) {

                if (retorno.NomePerfil == 'Secretárias Estadual') {
                    _PERFILLOGADO = 'Secretárias Estadual'
                }
                else if (retorno.NomePerfil == 'Secretária de Bloco') {
                    _PERFILLOGADO = 'Secretária de Bloco'

                    configComboPerfilBloco();
                }
                else if (retorno.NomePerfil == 'Secretária de Região') {
                    _PERFILLOGADO = 'Secretária de Região';

                    configComboPerfilRegiaoTJ();
                }
                else if (retorno.NomePerfil == 'Secretária de Igreja') {
                    _PERFILLOGADO = 'Secretária de Igreja'
                }
            });
        }

        function configComboPerfilBloco() {
            $.ajax({
                type: "GET",
                url: "api/Usuarios/X072470/",
                contentType: "application/json"
            }).done(function (retorno) {

                preencherComboBlocosToBlocos(retorno.IdEstadoUsuarioLogado, retorno.IdBloco);

                preencherComboRegioes(retorno.IdBloco);

                $('#ibox1').children('.ibox-content').toggleClass('sk-loading');//#spinner
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

        function configComboPerfilRegiaoTJ() {
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

                $('#ibox1').children('.ibox-content').toggleClass('sk-loading');//#spinner
            });
        }
    </script>
</body>
</html>
