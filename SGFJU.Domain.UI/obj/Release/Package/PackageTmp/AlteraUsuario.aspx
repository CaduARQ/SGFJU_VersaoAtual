<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlteraUsuario.aspx.cs" Inherits="SGFJU.Domain.UI.AlteraUsuario" %>

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
    
    <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.1/css/bootstrap-datepicker3.min.css" rel="stylesheet"/>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.1/css/bootstrap-datepicker.min.css" rel="stylesheet"/>

    
    <!-- Sweet Alert -->
    <link href="css/plugins/sweetalert/sweetalert.css" rel="stylesheet">

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
            <form role="search" class="navbar-form-custom" action="">
                <div class="form-group">
                    <input type="text" placeholder="" class="form-control" name="top-search" id="top-search">
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
                <div class="row  border-bottom white-bg dashboard-header">

                    <div class="col-lg-12">
                        <div class="row text-left">

                            <div class="col">

                                <!-- Aqui entra a tab-->
                                <div class="ibox" id="ibox1">
                        <div class="ibox-title">
                            <a href="GerenciaUsuariosEstado.aspx" id="lnkLinkAlteracao" class="text-danger font-bold">
                                <span class="glyphicon glyphicon-search" aria-hidden="true"></span><span class="glyphicon glyphicon-user" aria-hidden="true"></span> 
                                Todos Usuários                                
                            </a>                            
                        </div>
                        <div class="ibox-content">
                            <h2 class="text-success font-bold">
                                Alteração de Usuário
                                <span class="glyphicon glyphicon-user" aria-hidden="true"></span>
                            </h2>
                            <p>
                                Preencha com atenção.
                            </p>

                            <form id="form" action="AlteraUsuario.aspx" method="post" runat="server" class="wizard-big">

                                <h1>Finish</h1>
                                <fieldset>
                                    <h2>Informações de Credenciais</h2>

                                    <hr class="hr-line-solid" />
                                    
                                    <div class="row">


                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_phone">Nome do Usuário</label>                                                            
                                                <input type="text" id="txtNomeUsuario" name="txtNomeUsuario" class="form-control" required>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_phone">Login</label>    
	                                            <div class="input-group">
		                                            <div class="input-group-prepend">
		                                                <span class="input-group-text"> <i class="fa fa-user"></i> </span>
		                                             </div>
		                                            <input id="txtLogin" name="txtLogin" class="form-control" placeholder="Login" type="text" required>
	                                            </div>
	                                        </div>
                                        </div>
                                        
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_phone">Senha</label>    
	                                            <div class="input-group">
		                                            <div class="input-group-prepend">
		                                                <span class="input-group-text"> <i class="fa fa-lock"></i> </span>
		                                             </div>
	                                                <input id="txtPwd" name="txtPwd" class="form-control" placeholder="******" type="password" required>
	                                            </div>
	                                        </div> 
                                        </div>
                                        
                                    </div>

                                    <div class="clearfix"></div>

                                    <div class="row">
                                        
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_name">Tipo de Usuário</label>
                                                <select required id="cboTipoUsuario" name="cboTipoUsuario" class="select2_demo_11 form-control">
                                                    <option></option>
                                                    <option value="6">Secretária Estadual</option>
                                                    <option value="7">Secretária Bloco</option>
                                                    <option value="9">Secretária Região</option>
                                                </select>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_name">Estado *</label><br />
                                                <select id="cboEstado" class="select2_demo_3 form-control" >
                                                    <option></option>
                                                    <option value="28">São Paulo</option>
                                                    <option value="29">Acre</option>
                                                    <option value="30">Alagoas</option>
                                                    <option value="31">Amapá</option>
                                                    <option value="32">Amazonas</option>
                                                    <option value="33">Bahia</option>
                                                    <option value="34">Ceará</option>
                                                    <option value="35">Distrito Federal</option>
                                                    <option value="36">Espírito Santo</option>
                                                    <option value="37">Goiás</option>
                                                    <option value="38">Maranhão</option>
                                                    <option value="39">Mato Grosso</option>
                                                    <option value="40">Mato Grosso Dos Sul</option>
                                                    <option value="41">Minas Gerais</option>
                                                    <option value="42">Pará</option>
                                                    <option value="43">Paraíba</option>
                                                    <option value="44">Paraná</option>
                                                    <option value="45">Pernambuco</option>
                                                    <option value="46">Piauí</option>
                                                    <option value="47">Rio de Janeiro</option>
                                                    <option value="48">Rio Grande do Norte</option>
                                                    <option value="49">Rio Grande do Sul</option>
                                                    <option value="50">Rondônia</option>
                                                    <option value="51">Roraima</option>
                                                    <option value="52">Santa Catarina</option>
                                                    <option value="53">Sergipe</option>
                                                    <option value="54">Tocantins</option>
                                                    <option value="55">Campos</option>
                                                </select>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_bloco">Bloco *</label><br />
                                                <select id="cboBloco" name="cboBloco" class="select2_demo_4 form-control" disabled>
                                                    <option></option>
                                                </select>
                                            </div>
                                        </div>
                                        
                                    </div>

                                    <hr class="hr-line-solid" />

                                    <div class="row">

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_phone">Região *</label><br />
                                                <select id="cboRegiao" name="cboRegiao" class="select2_demo_5 form-control" disabled>
                                                    <option></option>                                                    
                                                </select>
                                            </div>
                                        </div>

                                        <%--<div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_name">Igreja *</label><br />
                                                <select required id="cboIgreja" name="cboIgreja" class="form-control">
                                                    <option></option>
                                                </select>
                                            </div>
                                        </div>--%>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_email">Inserir Foto *</label>
                                                <br />
                                                <button id="btnAdicionarFoto" data-toggle="modal" data-target="#fotoJovemModal" class="btn btn-danger " type="button"><i class="fa fa-search"></i>&nbsp;Adicionar foto</button>
                                                <span class="input-group-btn">
                                                    <button class="btn btn-success" 
                                                            id="btnVisualizaFotoJovemAlterar" 
                                                            type="button" 
                                                            data-toggle="modal" 
                                                            data-tt="tooltip" 
                                                            title="Foto já cadastrada do usuário" 
                                                            data-target="#VisualizaFotoJovemAlteracao">
                                                        <i class="fa fa-photo"></i>
                                                    </button>
                                                </span>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="modal inmodal" id="fotoJovemModal" tabindex="-1" role="dialog" aria-hidden="true">
                                        <div class="modal-dialog">
                                        <div class="modal-content animated bounceInRight">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                                                    <i class="fa fa-laptop modal-icon"></i>
                                                    <h4 class="modal-title">Selecione a foto do perfil do usuário</h4>
                                                    <small class="font-bold">foto do perfil do Usuário</small>
                                                </div>
                                                <div class="modal-body">
                                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-white" data-dismiss="modal">Fechar</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- Foto para visualizar foto do jovem -->
                                    <div class="modal inmodal" id="VisualizaFotoJovemAlteracao" tabindex="-1" role="dialog" aria-hidden="true">
                                        <div class="modal-dialog">
                                        <div class="modal-content animated bounceInRight">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                                                    <i class="fa fa-photo modal-icon"></i>
                                                    <h4 class="modal-title">Selecione a foto do perfil do usuário</h4>
                                                    <small class="font-bold">foto do perfil do Usuário</small>
                                                </div>
                                                <div class="modal-body">
                                                    <center><canvas id="canvas" width=160 height="116"></canvas></center>
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-white" data-dismiss="modal">Fechar</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!---->
                                    
                                </fieldset>

                            </form>
                        </div>
                    </div>
                                <!-- Aqui encerra-se o código da tab-->

                            </div>

                        </div>
                    </div>

            </div>
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
   <%--<script src="js/plugins/datapicker/bootstrap-datepicker.js"></script>--%>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.1/js/bootstrap-datepicker.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.1/locales/bootstrap-datepicker.pt-BR.min.js"></script>


    <!-- iCheck -->
    <script src="js/plugins/iCheck/icheck.min.js"></script>

    <!-- Nestable List -->
    <script src="js/plugins/nestable/jquery.nestable.js"></script>

    <!-- Toastr script -->
    <script src="js/plugins/toastr/toastr.min.js"></script>

    <!-- Sweet alert -->
    <script src="js/plugins/sweetalert/sweetalert.min.js"></script>

    <!-- SGFJU Scripts -->
    <script src="js/SGFJU.Domain.UI.Client.js"></script>
    <script src="js/SGFJU.Domain.UI.Client.Facade.js"></script>
    <script src="js/SGFJU.Domain.UI.PageSetup.js"></script>

    <script>
        //--------
        var facadeUser = new SGFJU.Domain.Model.UI.Client.Facade.UsuarioFacade();
        var __URL_FOTO_ALTERACAO = '';
        var __HOST_LOCAL = 'https://' + window.location.hostname + ':' + window.location.port + '/FotosUsuarios/';
        var __HOST_PRODUCAO = 'http://' + window.location.hostname + '/SGFJU2.0/FotosUsuarios/';
        var HOST_NAME_APP = document.location.hostname;

        $(document).ready(function () {


            $("#wizard").steps();
            $("#form").steps({
                bodyTag: "fieldset",
                onStepChanging: function (event, currentIndex, newIndex) {
                    // Always allow going backward even if the current step contains invalid fields!
                    if (currentIndex > newIndex) {
                        return true;
                    }

                    // Forbid suppressing "Warning" step if the user is to young
                    if (newIndex === 3 && Number($("#age").val()) < 18) {
                        return false;
                    }

                    var form = $(this);

                    // Clean up if user went backward before
                    if (currentIndex < newIndex) {
                        // To remove error styles
                        $(".body:eq(" + newIndex + ") label.error", form).remove();
                        $(".body:eq(" + newIndex + ") .error", form).removeClass("error");
                    }

                    // Disable validation on fields that are disabled or hidden.
                    form.validate().settings.ignore = ":disabled,:hidden";

                    // Start validation; Prevent going forward if false
                    return form.valid();
                },
                onStepChanged: function (event, currentIndex, priorIndex) {
                    // Suppress (skip) "Warning" step if the user is old enough.
                    if (currentIndex === 2 && Number($("#age").val()) >= 18) {
                        $(this).steps("next");
                    }

                    // Suppress (skip) "Warning" step if the user is old enough and wants to the previous step.
                    if (currentIndex === 2 && priorIndex === 3) {
                        $(this).steps("previous");
                    }
                },
                onFinishing: function (event, currentIndex) {
                    var form = $(this);

                    // Disable validation on fields that are disabled.
                    // At this point it's recommended to do an overall check (mean ignoring only disabled fields)
                    form.validate().settings.ignore = ":disabled";

                    // Start validation; Prevent form submission if false
                    return form.valid();
                },
                onFinished: function (event, currentIndex) {
                    var form = $(this);

                    // Submit form input
                    form.submit();
                    $('#ibox1').children('.ibox-content').toggleClass('sk-loading');
                    __doPostBack(this, 'SalvarJovem');
                }
            }).validate({
                errorPlacement: function (error, element) {
                    element.before(error);
                },
                rules: {                    
                }
            });

            $("#cboEstado").select2();
            $("#cboBloco").select2();
            $("#cboRegiao").select2();
            $("#cboIgreja").select2();
            $('#cboTipoUsuario').select2();


            $('.select2_demo_3').on('select2:select', function (e) {
                $('#ibox1').children('.ibox-content').toggleClass('sk-loading');//sk-loading                
                var data = e.params.data;
                preencherComboBlocos(data.id);
            });

            $('.select2_demo_4').on('select2:select', function (e) {
                console.log('preenche ou não preenche combo reg ?' + $('.select2_demo_11').val());
                if ($('.select2_demo_11').val() == 9) {
                    $('#ibox1').children('.ibox-content').toggleClass('sk-loading');
                    $('#cboRegiao').empty().trigger("change");
                    $('#cboIgreja').empty().trigger("change");
                    var data = e.params.data;

                    preencherComboRegioes(data.id);
                }
            });

            $('.select2_demo_5').on('select2:select', function (e) {                
                $('#cboIgreja').empty().trigger("change");
                var data = e.params.data;
            });

            $('.select2_demo_11').on('select2:select', function (e) {
                var data = e.params.data;

                if (data.id == 6) {
                    $('#cboBloco').empty().trigger("change");
                    $('#cboBloco').prop('disabled', true);

                    $('#cboRegiao').empty().trigger("change");
                    $('#cboRegiao').prop('disabled', true);
                }
                else if (data.id == 7) {
                    $('#cboBloco').removeAttr('disabled');
                    $('#cboBloco').empty().trigger("change");
                    preencherComboBlocos($('#cboEstado').val());
                    $('#cboBloco').empty().trigger("change");
                    //$('#cboBloco').val($('#cboBloco option:first-child').val()).trigger('change');
                    

                    $('#cboRegiao').empty().trigger("change");
                    $('#cboRegiao').prop('disabled', true);
                    
                }
                else if (data.id == 9) {

                    $('#cboBloco').removeAttr('disabled');
                    $('#cboBloco').empty().trigger("change");
                    preencherComboBlocos($('#cboEstado').val());
                    //$('#cboBloco').val($('#cboBloco option:first-child').val()).trigger('change');

                    $('#cboRegiao').empty().trigger("change");
                    $('#cboRegiao').removeAttr('disabled');
                    
                }
            });

            facadeUser.ConfigurarPaginaX072470();

            preencheFormularioAtualizacao();

            $('#fotoJovemModal').on('hide.bs.modal', function () {
                var arquivoFotoJovem = $('#FileUpload1').val()
                var file = $('#FileUpload1');
                var tamanhoDoArquivo = (arquivoFotoJovem != '')?file[0].files[0].size:0;
                var TAMANHO_MAXIMO = 307200;

                if (arquivoFotoJovem != '') {
                    if (tamanhoDoArquivo > TAMANHO_MAXIMO) {
                        swal({
                            title: "Validação Foto",
                            text: "Foto selecionada, excede tamanho máximo permitido!",
                            imageUrl: 'img/delete.jpg'
                        });
                        var arquivoFotoJovem = $('#FileUpload1').val('');
                    }
                    else {
                        if (arquivoFotoJovem != '')
                            swal({
                                title: "Foto do Usuário",
                                text: "Foto Adicionada com sucesso!",
                                imageUrl: 'img/ok.png'
                            });
                        else
                            swal({
                                title: "Validação Foto",
                                text: "É necessário adicionar uma foto!",
                                imageUrl: 'img/delete.jpg'
                            });
                    }
                }
            });

            $('#VisualizaFotoJovemAlteracao').on('shown.bs.modal', function () {
                console.log('ao abrir modal ' + __URL_FOTO_ALTERACAO);
                configuraFotoUsuarioAlteracao(__URL_FOTO_ALTERACAO);
            });
        });

        function configComboEstado() {
            $.ajax({
                type: "GET",
                url: "api/Usuarios/X072470/",
                contentType: "application/json"
            }).done(function (retorno) {
                //console.log(retorno.IdEstadoUsuarioLogado);
                $("#cboEstado").val(retorno.IdEstadoUsuarioLogado).trigger('change.select2');
                $('#cboEstado').prop("disabled", true);
                preencherComboBlocos(retorno.IdEstadoUsuarioLogado);
            });
        }

        function preencherComboBlocos(idEstado) {
            $.ajax({
                type: "GET",
                url: "api/blocos/ObterPorEstado/" + idEstado,
                contentType: "application/json"
            }).done(function (retorno) {
                $.each(retorno, function () {
                    $("#cboBloco").append($("<option     />").val(this.Id).text(this.NomeBloco));
                });
                $("#cboBloco").prepend('<option selected class="placeholdered" value="">Selecione o bloco</option>');
                $('#cboBloco').select2().trigger('change');
                $('#cboBloco').removeAttr('selected');
                //$('#ibox1').children('.ibox-content').toggleClass('sk-loading');//#spinner
            });
        }

        function preencherComboBlocosToBlocos(idEstado, idBloco) {
            $.ajax({
                type: "GET",
                url: "api/blocos/ObterPorEstado/" + idEstado,
                contentType: "application/json"
            }).done(function (retorno) {

                $.each(retorno, function () {
                    $("#cboBloco").append($("<option     />").val(this.Id).text(this.NomeBloco));
                });

                $("#cboBloco").val(idBloco).attr('selected', true);
                $('#cboBloco').select2().trigger('change');
                $('#cboBloco').removeAttr('disabled');
                
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
                $('#ibox1').children('.ibox-content').toggleClass('sk-loading');//#spinner
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
                $('#cboRegiao').removeAttr('disabled');
            });
        }

        function preencherComboIgrejas(idRegiao) {
            $.ajax({
                type: "GET",
                url: "api/Igrejas/ObterPorRegiao/" + idRegiao,
                contentType: "application/json"
            }).done(function (retorno) {
                $.each(retorno, function () {
                    $("#cboIgreja").append($("<option     />").val(this.IdIgreja).text(this.NomeIgreja));
                });
                $("#cboIgreja").prepend('<option selected class="placeholdered" value="">Selecione a igreja</option>');
                $('#cboIgreja').select2().trigger('change');
                $('#cboIgreja').removeAttr('selected');
                $('#ibox1').children('.ibox-content').toggleClass('sk-loading');//#spinner
            });
        }

        function mensagemConfirmacaoCadastro() {
            var msgConfirmacaoCadastro = "Realizado com sucesso alteração do Usuário ";
            swal({
                title: "Usuáio alterado com sucesso !",
                text: msgConfirmacaoCadastro,
                type: "success"
            });
        }

        function preencheFormularioAtualizacao() {
            var url_ = new URL(location.href);
            var vIdUsuario = url_.searchParams.get("x");
            var usuarioDTO = {
                IdUsuarioX: vIdUsuario
            };

            $.ajax({
                type: "POST",
                data: JSON.stringify(usuarioDTO),
                url: "api/Usuarios/RetornaUsuario",
                contentType: "application/json"
            }).done(function (retornoUsuario) {

                $('#txtNomeUsuario').val(retornoUsuario.NomeUsuario);
                $('#txtLogin').val(retornoUsuario.Login);
                $('#txtPwd').val(retornoUsuario.Pwd);

                $('.select2_demo_11').val(retornoUsuario.IdPerfilUsuario).trigger('change.select2');
                ///$('.select2_demo_11').val(retornoUsuario.IdPerfilUsuario).attr('selected', true);
                //$('.select2_demo_11').select2().trigger('change');

                $("#cboEstado").val(retornoUsuario.IdEstadoUsuario).trigger('change.select2');
                $('#cboEstado').prop("disabled", true);

                if (retornoUsuario.IdBloco != 0 && retornoUsuario.IdRegiao == 0) {

                    preencherComboBlocosToBlocos(retornoUsuario.IdEstadoUsuario, retornoUsuario.IdBloco);

                }
                
                if (retornoUsuario.IdBloco != 0 && retornoUsuario.IdRegiao != 0) {
                    
                    preencherComboBlocosToBlocos(retornoUsuario.IdEstadoUsuario, retornoUsuario.IdBloco);

                    preencherComboRegioesToRegioes(retornoUsuario.IdBloco, retornoUsuario.IdRegiao);
                    
                }

                if (HOST_NAME_APP.indexOf('localhost') !== -1) {
                    __URL_FOTO_ALTERACAO = __HOST_LOCAL + retornoUsuario.PathImagemUsuario;                    
                }
                else {
                    if (retornoUsuario.PathImagemUsuario == '')
                        __URL_FOTO_ALTERACAO = __HOST_PRODUCAO + 'jovemsemfoto.jpg';
                    else
                        __URL_FOTO_ALTERACAO = __HOST_PRODUCAO + retornoUsuario.PathImagemUsuario;
                }

            });
        }

        function configuraFotoUsuarioAlteracao(urlFoto) {

            //VisualizaFotoJovemAlteracao
            var canvas = document.getElementById("canvas");
            var ctx = canvas.getContext("2d");
            var img = new Image();
            img.onload = function () {

                // set size proportional to image
                canvas.height = 165;//canvas.width * (img.height / img.width);
                //190 old value of with of canvas

                // step 1 - resize to 50%
                var oc = document.createElement('canvas'),
                    octx = oc.getContext('2d');

                oc.width = img.width * 0.5;
                oc.height = img.height * 0.5;
                octx.drawImage(img, 0, 0, oc.width, oc.height);

                // step 2
                octx.drawImage(oc, 0, 0, oc.width * 0.5, oc.height * 0.5);

                // step 3, resize to final size
                ctx.drawImage(oc, 0, 0, oc.width * 0.5, oc.height * 0.5,
                    0, 0, canvas.width, canvas.height);
            }
            img.src = urlFoto;
        }

    </script>
</body>
</html>
