<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarPatrimonio.aspx.cs" Inherits="SGFJU.Domain.UI.RegistrarPatrimonio" %>

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

    <%--
    <link href="css/plugins/datapicker/datepicker3.css" rel="stylesheet" />--%>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.1/css/bootstrap-datepicker3.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.1/css/bootstrap-datepicker.min.css" rel="stylesheet" />


    <!-- Sweet Alert -->
    <link href="css/plugins/sweetalert/sweetalert.css" rel="stylesheet">


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
                                    <h5>Novo Item de Patrimônio</h5>
                                    <div class="ibox-tools">
                                        <a class="collapse-link">
                                            <i class="fa fa-chevron-up"></i>
                                        </a>
                                        <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                                            <i class="fa fa-wrench"></i>
                                        </a>
                                        <ul class="dropdown-menu dropdown-user">
                                            <li>
                                                <a href="#" class="dropdown-item">Config option 1</a>
                                            </li>
                                            <li>
                                                <a href="#" class="dropdown-item">Config option 2</a>
                                            </li>
                                        </ul>
                                        <a class="close-link">
                                            <i class="fa fa-times"></i>
                                        </a>
                                    </div>
                                </div>
                                <div class="ibox-content">
                                    <h2 class="text-success font-bold">
                                        Cadastro de Patrimônio - SGFJU
                                    </h2>
                                    <p>
                                        Preencha com atenção.
                                    </p>

                                    
                                    <form id="form" action="RegistraPatrimonio.aspx" method="post" runat="server" class="wizard-big">
                                        <h1>Informações Básicas</h1>
                                        <fieldset>
                                            <h2>Informações referentes ao novo patrimônio</h2>
                                            <hr class="hr-line-solid">
                                            <div class="row">

                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                        <label class="text-success font-bold" for="form_name">Estado *</label><br />
                                                        <select id="cboEstado" class="select2_demo_3 form-control">
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
                                                        <select id="cboBloco" class="select2_demo_4 form-control">
                                                            <option></option>
                                                        </select>
                                                    </div>
                                                </div>

                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                        <label class="text-success font-bold" for="form_phone">Região *</label><br />
                                                        <select id="cboRegiao" class="select2_demo_5 form-control" required>
                                                            <option></option>
                                                        </select>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="clearfix"></div>

                                            <div class="row">


                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                        <label class="text-success font-bold" for="form_name">Igreja *</label><br />
                                                        <input id="txtNome" type="text" name="txtNome" class="form-control" required="required" data-error="name is required.">
                                                    </div>
                                                </div>

                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                        <label class="text-success font-bold" for="form_name">Nome do Item</label><br />
                                                        <input id="txtNomeItemPatrimonio" type="text" name="txtNomeItemPatrimonio" class="form-control" required="required" data-error="name is required.">
                                                    </div>
                                                </div>

                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                        <label class="text-success font-bold" for="form_name">Descrição Item</label><br />
                                                        <input id="txtDescricaoPatrimonio" type="text" name="txtDescricaoPatrimonio" class="form-control" >
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="clearfix"></div>

                                            <div class="row">

                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                        <label class="text-success font-bold" for="form_name">Modelo</label><br />
                                                        <input id="txtModelo" type="text" name="txtModelo" class="form-control" >
                                                    </div>
                                                </div>

                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                        <label class="text-success font-bold" for="form_name">Marca</label><br />
                                                        <input id="txtMarca" type="text" name="txtMarca" class="form-control" >
                                                    </div>
                                                </div>

                                                <div class="col-sm-4">
                                                    <div class="form-group" id="data_1">
                                                        <label class="text-success font-bold">Data da Compra</label>
                                                        <div class="input-group date">
                                                            <input type="date" name="txtDataCompra" class="form-control" required >
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="clearfix"></div>

                                            <div class="row">

                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                        <label class="text-success font-bold" for="form_name">Local da Compra</label><br />
                                                        <input id="txtLocalCompra" type="text" name="txtLocalCompra" class="form-control" >
                                                    </div>
                                                </div>

                                            </div>

                                        </fieldset>

                                        <h1>Fotos do Patrimônio</h1>
                                        <fieldset>

                                            <div class="row">

                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                        <label class="text-success font-bold"  for="form_email">Inserir Foto 1</label>
                                                        <br />
                                                        <button id="btnAdicionarFoto" data-toggle="modal" data-target="#fotoPatrimonioModal1" class="btn btn-danger " type="button"><i class="fa fa-search"></i>&nbsp;Adicionar foto</button>
                                                        <button id="btnStatusFoto" 
                                                                data-tt="tooltip" 
                                                                title="Adicionar foto 1 do patrimônio" 
                                                                class="btn btn-warning rounded-circle" type="button" > 
                                                            <i class="fa fa-image"></i>
                                                        </button>
                                                    </div>
                                                </div>

                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                        <label class="text-success font-bold"  for="form_email">Inserir Foto 2</label>
                                                        <br />
                                                        <button id="btnAdicionarFoto2" data-toggle="modal" data-target="#fotoPatrimonioModal2" class="btn btn-danger " type="button"><i class="fa fa-search"></i>&nbsp;Adicionar foto</button>
                                                        <button id="btnStatusFoto2" 
                                                                data-tt="tooltip" 
                                                                title="Adicionar foto 2 do patrimônio" 
                                                                class="btn btn-warning rounded-circle" type="button" > 
                                                            <i class="fa fa-image"></i>
                                                        </button>
                                                    </div>
                                                </div>

                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                        <label class="text-success font-bold"  for="form_email">Inserir Foto 3</label>
                                                        <br />
                                                        <button id="btnAdicionarFoto3" data-toggle="modal" data-target="#fotoPatrimonioModal3" class="btn btn-danger " type="button"><i class="fa fa-search"></i>&nbsp;Adicionar foto</button>
                                                        <button id="btnStatusFoto3" 
                                                                data-tt="tooltip" 
                                                                title="Adicionar foto 3 do patrimônio" 
                                                                class="btn btn-warning rounded-circle" type="button" > 
                                                            <i class="fa fa-image"></i>
                                                        </button>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="clearfix"></div>

                                            <div class="row">

                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                        <label class="text-success font-bold" for="form_email">Inserir Foto 4</label>
                                                        <br />
                                                        <button id="btnAdicionarFoto4" data-toggle="modal" data-target="#fotoPatrimonioModal4" class="btn btn-danger " type="button"><i class="fa fa-search"></i>&nbsp;Adicionar foto</button>
                                                        <button id="btnStatusFoto4" 
                                                                data-tt="tooltip" 
                                                                title="Adicionar foto 4 do patrimônio" 
                                                                class="btn btn-warning rounded-circle" type="button" > 
                                                            <i class="fa fa-image"></i>
                                                        </button>
                                                    </div>
                                                </div>

                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                        <label class="text-success font-bold"  for="form_email">Inserir Foto 5</label>
                                                        <br />
                                                        <button id="btnAdicionarFoto5" data-toggle="modal" data-target="#fotoPatrimonioModal5" class="btn btn-danger " type="button"><i class="fa fa-search"></i>&nbsp;Adicionar foto</button>
                                                        <button id="btnStatusFoto5" 
                                                                data-tt="tooltip" 
                                                                title="Adicionar foto 5 do patrimônio" 
                                                                class="btn btn-warning rounded-circle" type="button" > 
                                                            <i class="fa fa-image"></i>
                                                        </button>
                                                    </div>
                                                </div>

                                            </div>

                                        </fieldset>

                                        <!-- modais upload da foto do patrimonio -->
                                        <!-- -->
                                        <div class="modal inmodal" id="fotoPatrimonioModal1" tabindex="-1" role="dialog" aria-hidden="true">
                                            <div class="modal-dialog">
                                            <div class="modal-content animated bounceInRight">
                                                    <div class="modal-header">
                                                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                                                        <i class="fa fa-laptop modal-icon"></i>
                                                        <h4 class="modal-title">Selecione a 1º foto do Patrimônio</h4>
                                                        <small class="font-bold">foto do perfil do Patrimônio</small>
                                                    </div>
                                                    <div class="modal-body">
                                                        <!---->
                                                        <%--<form action="api/FotosJovens/UploadFotoJovem" enctype="multipart/form-data" method="post">
                                                            <input type="file" name="FileUpload1" id="FileUpload1" />
                                                        </form>--%>
                                                        <asp:FileUpload ID="FileUploadPatrimonio1" runat="server" />
                                                        <!---->
                                                    </div>
                                                    <div class="modal-footer">
                                                        <button type="button" class="btn btn-white" data-dismiss="modal">Fechar</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>                                        
                                        <!-- -->
                                        <div class="modal inmodal" id="fotoPatrimonioModal2" tabindex="-1" role="dialog" aria-hidden="true">
                                            <div class="modal-dialog">
                                            <div class="modal-content animated bounceInRight">
                                                    <div class="modal-header">
                                                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                                                        <i class="fa fa-laptop modal-icon"></i>
                                                        <h4 class="modal-title">Selecione a 2º foto do Patrimônio</h4>
                                                        <small class="font-bold">foto do perfil do Patrimônio</small>
                                                    </div>
                                                    <div class="modal-body">
                                                        <!---->
                                                        <%--<form action="api/FotosJovens/UploadFotoJovem" enctype="multipart/form-data" method="post">
                                                            <input type="file" name="FileUpload1" id="FileUpload1" />
                                                        </form>--%>
                                                        <asp:FileUpload ID="FileUploadPatrimonio2" runat="server" />
                                                        <!---->
                                                    </div>
                                                    <div class="modal-footer">
                                                        <button type="button" class="btn btn-white" data-dismiss="modal">Fechar</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!---->
                                        <div class="modal inmodal" id="fotoPatrimonioModal3" tabindex="-1" role="dialog" aria-hidden="true">
                                            <div class="modal-dialog">
                                            <div class="modal-content animated bounceInRight">
                                                    <div class="modal-header">
                                                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                                                        <i class="fa fa-laptop modal-icon"></i>
                                                        <h4 class="modal-title">Selecione a 3º foto do Patrimônio</h4>
                                                        <small class="font-bold">foto do perfil do Patrimônio</small>
                                                    </div>
                                                    <div class="modal-body">
                                                        <!---->
                                                        <%--<form action="api/FotosJovens/UploadFotoJovem" enctype="multipart/form-data" method="post">
                                                            <input type="file" name="FileUpload1" id="FileUpload1" />
                                                        </form>--%>
                                                        <asp:FileUpload ID="FileUploadPatrimonio3" runat="server" />
                                                        <!---->
                                                    </div>
                                                    <div class="modal-footer">
                                                        <button type="button" class="btn btn-white" data-dismiss="modal">Fechar</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!---->
                                        <div class="modal inmodal" id="fotoPatrimonioModal4" tabindex="-1" role="dialog" aria-hidden="true">
                                            <div class="modal-dialog">
                                            <div class="modal-content animated bounceInRight">
                                                    <div class="modal-header">
                                                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                                                        <i class="fa fa-laptop modal-icon"></i>
                                                        <h4 class="modal-title">Selecione a 4º foto do Patrimônio</h4>
                                                        <small class="font-bold">foto do perfil do Patrimônio</small>
                                                    </div>
                                                    <div class="modal-body">
                                                        <!---->
                                                        <%--<form action="api/FotosJovens/UploadFotoJovem" enctype="multipart/form-data" method="post">
                                                            <input type="file" name="FileUpload1" id="FileUpload1" />
                                                        </form>--%>
                                                        <asp:FileUpload ID="FileUploadPatrimonio4" runat="server" />
                                                        <!---->
                                                    </div>
                                                    <div class="modal-footer">
                                                        <button type="button" class="btn btn-white" data-dismiss="modal">Fechar</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!---->
                                        <div class="modal inmodal" id="fotoPatrimonioModal5" tabindex="-1" role="dialog" aria-hidden="true">
                                            <div class="modal-dialog">
                                            <div class="modal-content animated bounceInRight">
                                                    <div class="modal-header">
                                                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                                                        <i class="fa fa-laptop modal-icon"></i>
                                                        <h4 class="modal-title">Selecione a 5º foto do Patrimônio</h4>
                                                        <small class="font-bold">foto do perfil do Patrimônio</small>
                                                    </div>
                                                    <div class="modal-body">
                                                        <!---->
                                                        <%--<form action="api/FotosJovens/UploadFotoJovem" enctype="multipart/form-data" method="post">
                                                            <input type="file" name="FileUpload1" id="FileUpload1" />
                                                        </form>--%>
                                                        <asp:FileUpload ID="FileUploadPatrimonio5" runat="server" />
                                                        <!---->
                                                    </div>
                                                    <div class="modal-footer">
                                                        <button type="button" class="btn btn-white" data-dismiss="modal">Fechar</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!---->

                                        <!-- end -->

                                        <h1>Finish</h1>
                                        <fieldset>

                                            <div class="row">

                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                        <label class="text-success font-bold" for="form_name">Categoria do Patrimônio</label><br />
                                                        <select id="cboCategoriaPatrimonio" class="select2_demo_3 form-control">
                                                            <option></option>
                                                            <option value="28">Instrumentos musicais</option>
                                                            <option value="29">Eletro/eletrônicos</option>
                                                            <option value="30">Escritório</option>
                                                            <option value="31">Equipamentos de áudio visual</option>
                                                            <option value="31">Geral</option>
                                                        </select>
                                                    </div>
                                                </div>

                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                        <label class="text-success font-bold" for="form_name">Valor</label><br />
                                                        <input id="txtValor" type="number" step="0.01" min="1.00" name="txtValor" class="form-control" >
                                                    </div>
                                                </div>

                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                        <label class="text-success font-bold" for="form_name">Quantidade do Item</label><br />
                                                        <input id="txtQuantidade" type="number" min="0" name="txtQuantidade" class="form-control" >
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="row">

                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                        <label class="text-success font-bold"  for="form_email">Inserir Arquivo da Carta de Doação</label>
                                                        <br />
                                                        <button id="btnAdicionarArquivoCartaDoacao" data-toggle="modal" data-target="#arquivoCartaDoacaoModal" class="btn btn-success " type="button"><i class="fa fa-file-pdf-o"></i>&nbsp;Adicionar Carta de Doação</button>
                                                        <button id="btnCartaDoacao" 
                                                                data-tt="tooltip" 
                                                                title="Adicionar carta de doação do patrimônio" 
                                                                class="btn btn-warning rounded-circle" type="button" > 
                                                            <i class="fa fa-image"></i>
                                                        </button>
                                                    </div>
                                                </div>

                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                        <label class="text-success font-bold"  for="form_email">Inserir Arquivo da Nota Fiscal</label>
                                                        <br />
                                                        <button id="btnAdicionarArquivoNotaFiscal" data-toggle="modal" data-target="#arquivoNotaFiscalModal" class="btn btn-success " type="button"><i class="fa fa-file-pdf-o"></i>&nbsp;Adicionar Nota Fiscal</button>
                                                        <button id="btnNotaFiscal" 
                                                                data-tt="tooltip" 
                                                                title="Adicionar nota fiscal do patrimônio" 
                                                                class="btn btn-warning rounded-circle" type="button" > 
                                                            <i class="fa fa-image"></i>
                                                        </button>
                                                    </div>
                                                </div>


                                            </div>

                                        </fieldset>

                                        <!-- -->
                                        <div class="modal inmodal" id="arquivoCartaDoacaoModal" tabindex="-1" role="dialog" aria-hidden="true">
                                            <div class="modal-dialog">
                                            <div class="modal-content animated bounceInRight">
                                                    <div class="modal-header">
                                                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                                                        <i class="fa fa-laptop modal-icon"></i>
                                                        <h4 class="modal-title">Selecione o arquivo da carta de doação do Patrimônio</h4>
                                                        <small class="font-bold">Carta de doação do Patrimônio</small>
                                                    </div>
                                                    <div class="modal-body">
                                                        <!---->
                                                        <%--<form action="api/FotosJovens/UploadFotoJovem" enctype="multipart/form-data" method="post">
                                                            <input type="file" name="FileUpload1" id="FileUpload1" />
                                                        </form>--%>
                                                        <asp:FileUpload ID="FileUploadCartaDoacao" runat="server" />
                                                        <!---->
                                                    </div>
                                                    <div class="modal-footer">
                                                        <button type="button" class="btn btn-white" data-dismiss="modal">Fechar</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!---->
                                        <div class="modal inmodal" id="arquivoNotaFiscalModal" tabindex="-1" role="dialog" aria-hidden="true">
                                            <div class="modal-dialog">
                                            <div class="modal-content animated bounceInRight">
                                                    <div class="modal-header">
                                                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                                                        <i class="fa fa-laptop modal-icon"></i>
                                                        <h4 class="modal-title">Selecione o arquivo da nota fiscal do Patrimônio</h4>
                                                        <small class="font-bold">Nota fiscal do Patrimônio</small>
                                                    </div>
                                                    <div class="modal-body">
                                                        <!---->
                                                        <%--<form action="api/FotosJovens/UploadFotoJovem" enctype="multipart/form-data" method="post">
                                                            <input type="file" name="FileUpload1" id="FileUpload1" />
                                                        </form>--%>
                                                        <asp:FileUpload ID="FileUploadNotaFiscal" runat="server" />
                                                        <!---->
                                                    </div>
                                                    <div class="modal-footer">
                                                        <button type="button" class="btn btn-white" data-dismiss="modal">Fechar</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!---->

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
            <%--</div>--%>
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

    <script src="js/plugins/steps/jquery.steps.min.js"></script>

    <!-- Jquery Validate -->
    <script src="js/plugins/validate/jquery.validate.min.js"></script>

    <!-- Select2 -->
    <script src="js/plugins/select2/select2.full.min.js"></script>

    <!-- Input Mask-->
    <script src="js/plugins/jasny/jasny-bootstrap.min.js"></script>

    <!-- Data picker -->
    <%--
    <script src="js/plugins/datapicker/bootstrap-datepicker.js"></script>--%>
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
                    //form.submit();
                    cadastrarIgreja();
                    $('#ibox1').children('.ibox-content').toggleClass('sk-loading');
                    
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


            $('.select2_demo_3').on('select2:select', function (e) {
                $('#ibox1').children('.ibox-content').toggleClass('sk-loading');//sk-loading
                var data = e.params.data;
                preencherComboBlocos(data.id);
            });

            $('.select2_demo_4').on('select2:select', function (e) {
                $('#ibox1').children('.ibox-content').toggleClass('sk-loading');
                var data = e.params.data;
                preencherComboRegioes(data.id);
            });

            /*
            $('.select2_demo_5').on('select2:select', function (e) {
                $('#ibox1').children('.ibox-content').toggleClass('sk-loading');//#spinner
                var data = e.params.data;
                //preencherComboIgrejas(data.id);
            });*/

            facadeUser.ConfigurarPaginaX072470();


            /*
            configComboEstado();


            $('#fotoJovemModal').on('hide.bs.modal', function () {
                var arquivoFotoJovem = $('#FileUpload1').val()
                if(arquivoFotoJovem != '')
                    swal({
                        title: "Foto Do Jovem",
                        text: "Foto Adicionada com sucesso!",
                        imageUrl: 'img/ok.png'
                    });
                else
                    swal({
                        title: "Validação Foto",
                        text: "É necessário adicionar uma foto!",
                        imageUrl: 'img/delete.jpg'
                    });
            });

            */

            ExecutaActionX072477();

        });

        function configComboEstado() {
            $.ajax({
                type: "GET",
                url: "api/Usuarios/X072470/",
                contentType: "application/json"
            }).done(function (retorno) {
                console.log(retorno.IdEstadoUsuarioLogado);
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
                $('#ibox1').children('.ibox-content').toggleClass('sk-loading');//#spinner
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
                $('#ibox1').children('.ibox-content').toggleClass('sk-loading');//#spinner
            });
        }

        function mensagemConfirmacaoCadastro() {
            var msgConfirmacaoCadastro = "Realizado com sucesso cadastro do patrimônio ";
            swal({
                title: "Patrimônio Cadastrado com sucesso !",
                text: msgConfirmacaoCadastro,
                type: "success"
            });
        }

    </script>
</body>
</html>
