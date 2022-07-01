<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistraDespesa.aspx.cs" Inherits="SGFJU.Domain.UI.RegistraDespesa" %>

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
                <div class="row  border-bottom white-bg dashboard-header">

                    <div class="col-lg-12">
                        <div class="row text-left">

                            <div class="col">

                                <!-- Aqui entra a tab-->
                                <div class="ibox" id="ibox1">
                        <div class="ibox-title">
                            <a href="#" id="lnkLinkAlteracao" class="text-danger font-bold">
                                <span class="glyphicon glyphicon-search" aria-hidden="true"></span><span class="glyphicon glyphicon-user" aria-hidden="true"></span> 
                                Todos
                            </a>                            
                        </div>
                        <div class="ibox-content">
                            <h2 class="text-success font-bold">
                                Cadastro de Despesa
                                <span class="glyphicon glyphicon-user" aria-hidden="true"></span>
                            </h2>
                            <p>
                                Preencha com atenção.
                            </p>

                            <form id="form" action="RegistraDespesa.aspx" method="post" runat="server" class="wizard-big">

                                <h1>Finish</h1>
                                <fieldset>
                                    <h2>Informações de Credenciais</h2>

                                    <hr class="hr-line-solid" />
                                    
                                    <div class="row">


                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_phone">Valor</label>                                                            
                                                <input type="number" id="txtValor" name="txtValor" class="form-control" required>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group" id="data_1">
                                                <label class="text-success font-bold">Data</label>
                                                <div class="input-group date">                                                    
                                                    <input type="date" name="txtData" class="form-control" required >
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_name">Descrição </label>
                                                <input id="txtDescricao" type="text" name="txtDescricao" class="form-control" >
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>
                                        
                                    </div>

                                    <div class="clearfix"></div>

                                    <div class="row">
                                        
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_name">Número do Cupom </label>
                                                <input id="txtNumeroCupom" type="text" name="txtNumeroCupom" class="form-control" >
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_name">Estado *</label><br />
                                                <select id="cboEstado" name="cboEstado" class="select2_demo_3 form-control" >
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

                                        
                                    </div>

                                    <hr class="hr-line-solid" />

                                    <div class="row">

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_email">Inserir Foto *</label>
                                                <br />
                                                <button id="btnAdicionarFoto" data-toggle="modal" data-target="#fotoNotaModal" class="btn btn-danger " type="button"><i class="fa fa-search"></i>&nbsp;Adicionar foto nota</button>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="modal inmodal" id="fotoNotaModal" tabindex="-1" role="dialog" aria-hidden="true">
                                        <div class="modal-dialog">
                                        <div class="modal-content animated bounceInRight">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                                                    <i class="fa fa-laptop modal-icon"></i>
                                                    <h4 class="modal-title">Selecione a foto da Nota Fiscal</h4>
                                                    <small class="font-bold">Selecione a foto da Nota Fiscal</small>
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
        var ID_SOLTEIRO = 7;
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


            facadeUser.ConfigurarPaginaX072470();

            configComboEstado();

            /*
            $('#fotoNotaModal').on('hide.bs.modal', function () {
                var arquivoFotoJovem = $('#FileUpload1').val()
                var file = $('#FileUpload1');
                var tamanhoDoArquivo = file[0].files[0].size;
                var TAMANHO_MAXIMO = 307200;

                console.log(':: Tamanho do arquivo -> '+tamanhoDoArquivo);

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
            });*/
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

        function mensagemConfirmacaoCadastro() {
            var msgConfirmacaoCadastro = "Realizado com sucesso cadastro do Usuário ";
            swal({
                title: "Usuário Cadastrado com sucesso !",
                text: msgConfirmacaoCadastro,
                type: "success"
            });
        }

    </script>
</body>
</html>
