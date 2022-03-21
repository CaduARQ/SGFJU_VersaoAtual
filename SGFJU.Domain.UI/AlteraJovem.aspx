
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlteraJovem.aspx.cs" Inherits="SGFJU.Domain.UI.AlteraJovem" %>

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
    
    <%--<link href="css/plugins/datapicker/datepicker3.css" rel="stylesheet" />--%>
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
                            <h5 id="lblNomeJovemEmAlteracao"></h5>
                            <div class="ibox-tools">
                                
                            </div>
                        </div>
                        <div class="ibox-content">
                            <h2 class="text-success font-bold">
                                Alteração de Cadastro de Membro da Força Jovem Universal
                            </h2>
                            <a href="#" id="lnkLinkVisualizarFicha" class="text-danger font-bold">
                                <span class="glyphicon glyphicon-search" aria-hidden="true"></span> Visualizar ficha
                            </a>
                            <p>
                                
                            </p>

                            <form id="form" action="AlteraJovem.aspx" method="post" runat="server" class="wizard-big">
                                <h1>Pessoal</h1>
                                <fieldset>
                                    <h2>Informações Pessoais</h2>
                                    <!-- begin -->
                                    <div class="row">                                        

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_name">Estado *</label><br />
                                                <select id="cboEstado" class="select2_demo_3 form-control" >
                                                    <option></option>
                                                    <option value="1">São Paulo</option>
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
                                                    <option value="56">[BLOCO DE TESTE]</option>
                                                </select>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_bloco">Bloco *</label><br />
                                                <select id="cboBloco" class="select2_demo_4 form-control">
                                                    <option></option>
                                                </select>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_phone">Região *</label><br />
                                                <select id="cboRegiao" class="select2_demo_5 form-control">
                                                    <option></option>                                                    
                                                </select>
                                            </div>
                                        </div>

                                    </div>

                                    <!-- Primeiro separador -->
                                    <div class="clearfix"></div>

                                    <div class="row">                                        
                                        

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_name">Igreja *</label><br />
                                                <select required id="cboIgreja" name="cboIgreja" class="form-control">
                                                    <option></option>
                                                </select>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_name">Nome *</label>
                                                <input type="text" id="txtNome" name="txtNome" class="form-control" required="required" data-error="name is required.">
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_name">Data de Nascimento</label>
                                                <%--<input type="text" id="txtDataNascimento" name="txtDataNascimento" class="form-control" />--%>
                                                <%--<button type="button" 
                                                        alt="Editar Data de Nascimento" 
                                                        class="btn btn-info btn-xs dt-view" 
                                                        style="margin-right:16px;">
                                                <span class="glyphicon glyphicon-calendar" aria-hidden="true"></span></button>--%>
                                                <div class="input-group">
                                                  <input type="text" class="form-control" id="txtDataNascimento" name="txtDataNascimento" >
                                                  <input type="hidden" id="txtHiddenDataNascimento" runat="server" />
                                                  <span class="input-group-btn">
                                                    <button class="btn btn-danger" type="button" data-toggle="modal" data-target="#alteraDataNascimento">
                                                        <i class="fa fa-calendar"></i>
                                                    </button>
                                                  </span>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <!-- Separador entre a segunda e terceira linha de controles do formulário -->
                                    <div class="clearfix"></div>

                                    <div class="row">                                        
                                        

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_name">Whatsapp</label>
                                                <input type="text" id="txtWhatsapp" name="txtWhatsapp" class="form-control" data-mask="(99) 99999-9999" placeholder="">
                                                <span class="form-text">(DDD) 99999-9999</span>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_email">Telefone fixo </label>
                                                <input type="text" id="txtTelefoneFixo" name="txtTelefoneFixo" class="form-control" data-mask="(99) 9999-9999" placeholder="">
                                                <span class="form-text">(DDD) 9999-9999</span>                                                
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_phone">Telefone de Emergência</label>
                                                <input type="text" id="txtTelefoneEmergencia" name="txtTelefoneEmergencia" class="form-control" data-mask="(99) 99999-9999" placeholder="">
                                                <span class="form-text">(DDD) 99999-9999</span>
                                            </div>
                                        </div>


                                    </div>

                                    <div class="clearfix"></div>

                                    <div class="row">                                        

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_name">Contato </label>
                                                <input id="txtContatoEmergencia" type="text" name="txtContatoEmergencia" class="form-control"  >
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_email">Endereço *</label>
                                                <input id="txtEndereco" type="text" name="txtEndereco" class="form-control" required="required"  >
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_bairro">Bairro</label>
                                                <input id="txtBairro" type="tel" name="txtBairro" class="form-control" >
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="clearfix"></div>

                                    <div class="row">

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_bairro">Cidade</label>
                                                <input id="txtCidade" type="tel" name="txtCidade" class="form-control" >
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_bairro">Mora com quem?</label>
                                                <select id="cboTipoMoradia" name="cboTipoMoradia" class="select2_demo_3 form-control">
                                                    <option></option>
                                                    <option value="2">Sozinho</option>
                                                    <option value="3">Família</option>
                                                    <option value="4">Amigo</option>
                                                    <option value="5">Hostel/Albergue</option>
                                                    <%--<option value="1">Família</option>
                                                    <option value="2">Sozinho</option>
                                                    <option value="3">Amigo</option>
                                                    <option value="4">Hostel/Albergue</option>--%>
                                                </select>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_email">Inserir Foto *</label>
                                                <br />
                                                <button id="btnAdicionarFoto" 
                                                        data-toggle="modal" 
                                                        data-target="#fotoJovemModal" 
                                                        class="btn btn-danger " 
                                                        type="button"><i class="fa fa-search"></i>&nbsp;Adicionar foto</button>
                                                <span class="input-group-btn">
                                                    <button class="btn btn-success" 
                                                            id="btnVisualizaFotoJovemAlterar" 
                                                            type="button" 
                                                            data-toggle="modal" 
                                                            data-tt="tooltip" 
                                                            title="Foto já cadastrada do jovem" 
                                                            data-target="#VisualizaFotoJovemAlteracao">
                                                        <i class="fa fa-photo"></i>
                                                    </button>
                                                </span>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="clearfix"></div>

                                    <div class="row">
                                        <!---->

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="font-normal">Data de Preenchimento do Formulário</label>
                                                <div class="input-group">
                                                  <input type="text" class="form-control" id="txtDataPreenchimentoFormulario" name="txtDataPreenchimentoFormulario" >
                                                  <input type="hidden" id="txtHiddenDataPreenchimentoFormulario" runat="server" />
                                                  <span class="input-group-btn">
                                                    <button class="btn btn-danger" type="button" data-toggle="modal" data-target="#alteraDataPreenchimentoFormulario">
                                                        <i class="fa fa-calendar"></i>
                                                    </button>
                                                  </span>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="font-normal">Classificação</label>
                                                <div class="input-group">
                                                    <select id="cboClassificacaoJovem" name="cboClassificacaoJovem" class="select2_demo_3 form-control">
                                                    <option value="A">Ativo</option>
                                                    <option value="I">Inativo</option>
                                                        <option value="F">Afastado</option>
                                                    <option value="N">Iniciante</option>
                                                </select>
                                                </div>
                                            </div>
                                        </div>
                                        <!---->
                                    </div>
                                    
                                                

                                    <!-- modal fora da tab para testar se é enxergada gglobalmente -->
                                    <div class="modal inmodal" id="fotoJovemModal" tabindex="-1" role="dialog" aria-hidden="true">
                                        <div class="modal-dialog">
                                        <div class="modal-content animated bounceInRight">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                                                    <i class="fa fa-laptop modal-icon"></i>
                                                    <h4 class="modal-title">Selecione a foto do Jovem</h4>
                                                    <small class="font-bold">foto do perfil do jovem</small>
                                                </div>
                                                <div class="modal-body">
                                                    <!---->
                                                    <%--<form action="api/FotosJovens/UploadFotoJovem" enctype="multipart/form-data" method="post">
                                                        <input type="file" name="FileUpload1" id="FileUpload1" />
                                                    </form>--%>
                                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                                    <!---->
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-white" data-dismiss="modal">Fechar</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!---->

                                    <!-- Foto para visualizar foto do jovem -->
                                    <div class="modal inmodal" id="VisualizaFotoJovemAlteracao" tabindex="-1" role="dialog" aria-hidden="true">
                                        <div class="modal-dialog">
                                        <div class="modal-content animated bounceInRight">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                                                    <i class="fa fa-photo modal-icon"></i>
                                                    <h4 class="modal-title">Foto Cadastrada</h4>
                                                    <small class="font-bold">Foto do Jovem</small>
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

                                    <!---->
                                    <div class="modal inmodal" id="alteraDataNascimento" tabindex="-1" role="dialog" aria-hidden="true">
                                        <div class="modal-dialog">
                                        <div class="modal-content animated bounceInRight">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                                                    <i class="fa fa-calendar-check-o modal-icon"></i>
                                                    <h4 class="modal-title">Alterar Data de Nascimento</h4>
                                                    <small class="font-bold">Digite abaixo a Data de Nascimento corrigida</small>
                                                </div>
                                                <div class="modal-body">
                                                    <!---->
                                                    
                                                        <div class="form-group"><label>Data de Nascimento Anterior</label> <input id="txtDatanascimentoAnterior" type="text" class="form-control"></div>
                                                        <div class="form-group"><label>Nova Data de Nascimento</label> <input id="txtNovaDataNascimento" type="date" class="form-control"></div>
                                                        <div>
                                                            <button class="btn btn-sm btn-primary float-right m-t-n-xs" type="button" onclick="atualizaDataNascimento()"><strong>Atualizar Data</strong></button>
                                                        </div>
                                                    
                                                    <!---->
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-white" data-dismiss="modal">Fechar</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    
                                    <!-- abaixo modal que altera data de cadastro do fomulário -->
                                    <div class="modal inmodal" id="alteraDataPreenchimentoFormulario" tabindex="-1" role="dialog" aria-hidden="true">
                                        <div class="modal-dialog">
                                        <div class="modal-content animated bounceInRight">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                                                    <i class="fa fa-calendar-check-o modal-icon"></i>
                                                    <h4 class="modal-title">Alterar Data de Preenchimento do formulário</h4>
                                                    <small class="font-bold">Digite abaixo a Data de Preenchimento do formulário corrigida</small>
                                                </div>
                                                <div class="modal-body">
                                                    <!---->
                                                    
                                                        <div class="form-group"><label>Data de preenchimento do formulário Anterior</label> <input id="txtDataPreenchimentoFormularioAnterior" type="text" class="form-control"></div>
                                                        <div class="form-group"><label>Nova Data de preenchimento do formulário</label> <input id="txtNovaDataPreenchimentoFormulario" type="date" class="form-control"></div>
                                                        <div>
                                                            <button class="btn btn-sm btn-primary float-right m-t-n-xs" type="button" onclick="atualizaDataPreenchimentoFormulario()"><strong>Atualizar Data</strong></button>
                                                        </div>
                                                    
                                                    <!---->
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-white" data-dismiss="modal">Fechar</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- end -->
                                </fieldset>

                                <h1>Sociais</h1>
                                <fieldset>
                                    <h2>Conectividade e Redes Sociais</h2>
                                    
                                    <div class="row">

                                                    <div class="col-sm-4">
                                                        <label for="form_name">Instagram </label>
                                                        <div class="input-group m-b">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-addon">@</span>
                                                            </div>
                                                            <input type="text" id="txtInstagram" name="txtInstagram" class="form-control">
                                                        </div>
                                                    </div>
                                        
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_email">Facebook </label>
                                                            <input id="txtFacebook" type="text" name="txtFacebook" class="form-control"  >
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_phone">E-mail</label>
                                                            <input id="txtEmail" type="email" name="txtEmail" class="form-control" >
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Twitter </label>
                                                                <div class="input-group m-b">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-addon">@</span>
                                                                    </div>
                                                                <input type="text" id="txtTwitter" name="txtTwitter" class="form-control">
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">É seguidor do @OficialFJU?</label>
                                                            <div class="row">
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger  radio-inline">
                                                                        <input type="radio" name="rbEhSeguidorOFICIALFJU" id="rbEhSeguidorOFICIALFJURadio_S" value="S">
                                                                        <label for="rbEhSeguidorOFICIALFJURadio_S">
                                                                            Sim
                                                                        </label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger  radio-inline">                                                                        
                                                                        <input type="radio" name="rbEhSeguidorOFICIALFJU" id="rbEhSeguidorOFICIALFJURadio_N" value="N" >
                                                                        <label for="rbEhSeguidorOFICIALFJURadio_N">
                                                                            Não
                                                                        </label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            

                                                            <%--<div class="radio radio-danger radio-inline">
                                                                <input type="radio" name="rbEhSeguidorOFICIALFJU" id="radio4" value="option2" checked="">
                                                                <label for="radio4">
                                                                    Não
                                                                </label>
                                                            </div>--%>

                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Segue FJU no Youtube?</label>
                                                            <div class="row">
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger  radio-inline">
                                                                        <input type="radio" name="rbEhSeguidorFJUYouTube" id="rbEhSeguidorFJUYouTube_S" value="S">
                                                                        <label for="rbEhSeguidorFJUYouTube_S">
                                                                            Sim
                                                                        </label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger  radio-inline">
                                                                        <input type="radio" name="rbEhSeguidorFJUYouTube" id="rbEhSeguidorFJUYouTube_N" value="N" >
                                                                        <label for="rbEhSeguidorFJUYouTube_N">
                                                                            Não
                                                                        </label>
                                                                    </div>
                                                                </div>
                                                            </div>                                                            
                                                        </div>
                                                    </div>

                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Segue canal da FJU no TELEGRAM?</label>
                                                            <div class="row">
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger  radio-inline">
                                                                        <input type="radio" name="rbSegueFJUTelegram" id="rbSegueFJUTelegram_S" value="S">
                                                                        <label for="rbSegueFJUTelegram_S">
                                                                            Sim
                                                                        </label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger radio-inline">
                                                                        <input type="radio" name="rbSegueFJUTelegram" id="rbSegueFJUTelegram_N" value="N" >
                                                                        <label for="rbSegueFJUTelegram_N">
                                                                            Não
                                                                        </label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Você é assinante do UNIVERVIDEO?</label>
                                                            <div class="row">
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger  radio-inline">
                                                                        <input type="radio" name="rbAssinanteUNIVERVIDEO" id="rbAssinanteUNIVERVIDEO_S" value="S">
                                                                        <label for="rbAssinanteUNIVERVIDEO_S">
                                                                            Sim
                                                                        </label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger radio-inline">
                                                                        <input type="radio" name="rbAssinanteUNIVERVIDEO" id="rbAssinanteUNIVERVIDEO_N" value="n" >
                                                                        <label for="rbAssinanteUNIVERVIDEO_N">
                                                                            Não
                                                                        </label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Assiste com qual Frequência?</label>
                                                            <select id="txtFrequenciaAssisteUniver" name="txtFrequenciaAssisteUniver" class="form-control">
                                                                    <option value=""></option>
                                                                      <option value="Todos os dias">Todos os dias</option>
                                                                      <option value="Cinco dias por semana">Cinco dias por semana</option>
                                                                      <option value="Três dias por semana">Três dias por semana</option>
                                                                      <option value="Um dia por semana">Um dia por semana</option>
                                                                      <option value="De vez enquando">De vez enquando</option>
                                                                      <option value="Sou assinante, mais não assisto">Sou assinante, mais não assisto</option>
                                                              </select>                                                            
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Você Lê diariamente o Blog do Bispo Macedo?</label>
                                                            <div class="row">
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger  radio-inline">
                                                                        <input type="radio" name="rbLeDiariamenteBlogBM" id="rbLeDiariamenteBlogBM_S" value="S">
                                                                        <label for="rbLeDiariamenteBlogBM_S">
                                                                            Sim
                                                                        </label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger radio-inline">
                                                                        <input type="radio" name="rbLeDiariamenteBlogBM" id="rbLeDiariamenteBlogBM_N" value="N" >
                                                                        <label for="rbLeDiariamenteBlogBM_N">
                                                                            Não
                                                                        </label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Você acessa diariamente o página universal.org?</label>
                                                            <div class="row">
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger  radio-inline">
                                                                        <input type="radio" name="rbLeitorSiteUniversalOrg" id="rbLeitorSiteUniversalOrg_S" value="S">
                                                                        <label for="rbLeitorSiteUniversalOrg_S">
                                                                            Sim
                                                                        </label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger radio-inline">
                                                                        <input type="radio" name="rbLeitorSiteUniversalOrg" id="rbLeitorSiteUniversalOrg_N" value="N" >
                                                                        <label for="rbLeitorSiteUniversalOrg_N">
                                                                            Não
                                                                        </label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Você tem celular com acesso à internet?</label>
                                                            <div class="row">
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger  radio-inline">
                                                                        <input type="radio" name="rbTemCelularComInternet" id="rbTemCelularComInternet_S" value="S">
                                                                        <label for="rbTemCelularComInternet_S">
                                                                            Sim
                                                                        </label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger radio-inline">
                                                                        <input type="radio" name="rbTemCelularComInternet" id="rbTemCelularComInternet_N" value="N" >
                                                                        <label for="rbTemCelularComInternet_N">
                                                                            Não
                                                                        </label>
                                                                    </div>
                                                                </div>
                                                            </div>                                                            
                                                        </div>
                                                    </div>

                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">

                                                    <div class="col-sm-4">
                                                        <div class="form-group inline">
                                                            <label for="form_name">Você tem computador em casa?</label>
                                                            <div class="row">
                                                                <div class="col-3">
                                                                    <div class="radio radio-danger radio-inline">
                                                                        <input type="radio" id="rbTemComputadorEmCasa_S" value="S" name="rbTemComputadorEmCasa" >
                                                                        <label for="rbTemComputadorEmCasa_S"> Sim </label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-4">
                                                                    <div class="radio radio-danger radio-inline">
                                                                        <input type="radio" id="rbTemComputadorEmCasa_N" value="N" name="rbTemComputadorEmCasa">
                                                                        <label for="rbTemComputadorEmCasa_N"> Não </label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                    
                                </fieldset>

                                <h1>Complementares</h1>
                                <fieldset>
                                    <!-- bEGIN TABS PROFISSIONAIS -->
                                    <div class="tabs-container">
                                        <ul class="nav nav-tabs" role="tablist">
                                            <li><a class="nav-link active" data-toggle="tab" href="#tabInfoCivis"> Informações Civís</a></li>
                                            <li><a class="nav-link" data-toggle="tab" href="#tab-2">Informações Profissionais</a></li>
                                        </ul>
                                        <div class="tab-content">
                                            <div role="tabpanel" id="tabInfoCivis" class="tab-pane active">
                                                <div class="panel-body">
                                                    <!---->
                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Estado civil *</label>
                                                                <select required id="cboTipoEstadoCivil" name="cboTipoEstadoCivil" class="select2_demo_3 form-control">
                                                                    <option></option>
                                                                    <option value="6">Casado(a)</option>
                                                                    <option value="7">Solteiro(a)</option>
                                                                    <option value="8">Divorciado(a)</option>
                                                                    <option value="9">Viúvo(a)</option>
                                                                    <option value="10">Morando Junto</option>
                                                                    <%--<option value="1">Casado(a)</option>
                                                                    <option value="2">Solteiro(a)</option>
                                                                    <option value="3">Divorciado(a)</option>
                                                                    <option value="4">Viúvo(a)</option>
                                                                    <option value="5">Morando Junto</option>--%>
                                                                </select>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Sexo *</label>
                                                                <select required id="cboSexo" name="cboSexo" class="select2_demo_3 form-control">
                                                                    <option></option>
                                                                    <option value="M">Masculino</option>
                                                                    <option value="F">Feminino</option>
                                                                </select>
                                                            </div>
                                                        </div>
                                                        <!---->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_email">Nome do cônjuge </label>
                                                                <input id="txtNomeconjuge" type="text" name="txtNomeconjuge" class="form-control"   >
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Data de Casamento</label>
                                                                <div class="input-group">
                                                                  <input type="text" class="form-control" id="txtDataCasamento" name="txtDataCasamento" >
                                                                  <input type="hidden" id="Hidden1" runat="server" />
                                                                  <span class="input-group-btn">
                                                                    <button class="btn btn-danger" type="button" data-toggle="modal" data-target="#alteraDataCasamento">
                                                                        <i class="fa fa-calendar"></i>
                                                                    </button>
                                                                  </span>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <%--<div class="col-sm-4">
                                                            <div class="form-group" id="data_2">
                                                                <label class="font-normal">Data de Casamento</label>
                                                                <div class="input-group date">
                                                                    <input type="date" name="txtDataCasamento" class="form-control" required >
                                                                </div>
                                                            </div>
                                                        </div>--%>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Cônjuge é da Universal ?</label>
                                                                <div class="row">
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbConjugeEhIURD_S" value="S" name="rbConjugeEhIURD" >
                                                                            <label for="rbConjugeEhIURD_S"> Sim </label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbConjugeEhIURD_N" value="N" name="rbConjugeEhIURD">
                                                                            <label for="rbConjugeEhIURD_N"> Não </label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!---->
                                                    </div>

                                                    <!---->
                                                    <div class="modal inmodal" id="alteraDataCasamento" tabindex="-1" role="dialog" aria-hidden="true">
                                                        <div class="modal-dialog">
                                                         <div class="modal-content animated bounceInRight">
                                                                <div class="modal-header">
                                                                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                                                                    <i class="fa fa-calendar-check-o modal-icon"></i>
                                                                    <h4 class="modal-title">Alterar Data de Casamento</h4>
                                                                    <small class="font-bold">Digite abaixo a Data de Casamento corrigida</small>
                                                                </div>
                                                                <div class="modal-body">
                                                                    <!---->
                                                    
                                                                        <div class="form-group"><label>Data de Casamento Anterior</label> <input id="txtDataCasamentoAnterior" type="text" class="form-control"></div>
                                                                        <div class="form-group"><label>Nova Data de Casamento</label> <input id="txtNovaDataCasamento" type="date" class="form-control"></div>
                                                                        <div>
                                                                            <button class="btn btn-sm btn-primary float-right m-t-n-xs" type="button" onclick="atualizaDataCasamento()"><strong>Atualizar Data</strong></button>
                                                                        </div>
                                                    
                                                                    <!---->
                                                                </div>
                                                                <div class="modal-footer">
                                                                    <button type="button" class="btn btn-white" data-dismiss="modal">Fechar</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!--  -->

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_email">Possui filhos ?</label>
                                                                <div class="row">
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbPossuiFilhos_S" value="S" name="rbPossuiFilhos" >
                                                                            <label for="rbPossuiFilhos_S"> Sim </label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbPossuiFilhos_N" value="N" name="rbPossuiFilhos">
                                                                            <label for="rbPossuiFilhos_N"> Não </label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_phone">Quantos ?</label>
                                                                <input class="form-control" name="txtQtdFilhos" type="number" value="0" id="txtQtdFilhos" min="0" max="30" >
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>
                                                        <!---->
                                                    </div>
                                                    <!---->
                                                </div>
                                            </div>
                                            <div role="tabpanel" id="tab-2" class="tab-pane">
                                                <div class="panel-body">
                                                    <!---->
                                                <div class="row">
                                                    <!---->
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Trabalha ? </label>
                                                            <div class="row">
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger radio-inline">
                                                                        <input type="radio" id="rbTrabalha_S" value="S" name="rbTrabalha" >
                                                                        <label for="rbTrabalha_S"> Sim </label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger radio-inline">
                                                                        <input type="radio" id="rbTrabalha_N" value="S" name="rbTrabalha">
                                                                        <label for="rbTrabalha_N"> Não </label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_email">Empresa </label>
                                                            <input id="txtEmpresa" type="text" name="txtEmpresa" class="form-control" data-error="Campo Endereço é obrigatório."  >
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_phone">Profissão</label>
                                                            <input id="txtProfissao" type="text" name="txtProfissao" class="form-control" >
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>
                                                    <!---->
                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">
                                                    <!---->
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Estuda ? </label>
                                                            <div class="row">
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger radio-inline">
                                                                        <input type="radio" id="rbEstuda_S" value="S" name="rbEstuda" >
                                                                        <label for="rbEstuda_S"> Sim </label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger radio-inline">
                                                                        <input type="radio" id="rbEstuda_N" value="N" name="rbEstuda">
                                                                        <label for="rbEstuda_N"> Não </label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_phone">Grau de Instrução</label>
                                                              <select id="escolaridade" name="escolaridade" class="form-control">
                                                                    <option value=""></option>
                                                                      <option value="Analfabeto">Analfabeto</option>
                                                                      <option value="Fundamental Incompleto">Fundamental Incompleto</option>
                                                                      <option value="Fundamental Cursando">Fundamental Cursando</option>
                                                                      <option value="Fundamental Completo">Fundamental Completo</option>
                                                                      <option value="Médio Incompleto">Médio Incompleto</option>
                                                                      <option value="Médio Cursando">Médio Cursando</option>
                                                                      <option value="Médio Completo">Médio Completo</option>
                                                                      <option value="Superior Incompleto">Superior Incompleto</option>
                                                                      <option value="Superior Cursando">Superior Cursando</option>
                                                                      <option value="Superior Completo">Superior Completo</option>
                                                              </select>
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Instituição onde estuda </label> 
                                                            <input id="txtInstituicaoOndeEstuda" type="text" name="txtInstituicaoOndeEstuda" class="form-control" >                                                            
                                                        </div>
                                                    </div>
                                                    <!---->
                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">
                                                    <!-- -->
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Possui Titulo de Eleitor ? </label>
                                                            <div class="row">
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger radio-inline">
                                                                        <input type="radio" id="rbPossuiTituloeleitor_S" value="S" name="rbPossuiTituloeleitor" >
                                                                        <label for="rbPossuiTituloeleitor_S"> Sim </label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger radio-inline">
                                                                        <input type="radio" id="rbPossuiTituloeleitor_N" value="N" name="rbPossuiTituloeleitor">
                                                                        <label for="rbPossuiTituloeleitor_N"> Não </label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <!-- -->
                                                </div>
                                                <!---->
                                                </div>
                                            </div>
                                        </div>


                                    </div>
                                    <!-- END-->
                                </fieldset>

                                <h1>Espiritual</h1>
                                <fieldset>
                                    <!-- bEGIN TABS PROFISSIONAIS -->
                                    <div class="tabs-container">
                                        <ul class="nav nav-tabs" role="tablist">
                                            <li><a class="nav-link active" data-toggle="tab" href="#InfoEspirituais"> Informações Espírituais</a></li>
                                            <li><a class="nav-link" data-toggle="tab" href="#DadosBatismo">Dados do Batismo</a></li>
                                            <li><a class="nav-link" data-toggle="tab" href="#LivrosLidos">Complemento</a></li>
                                        </ul>
                                        <div class="tab-content">
                                            <div role="tabpanel" id="InfoEspirituais" class="tab-pane active">
                                                <div class="panel-body">
                                                    <!---->
                                                     <div class="row">

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">É membro da Universal ?</label>
                                                                <div class="row">
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbEhMembroIURD_S" value="S" name="rbEhMembroIURD" >
                                                                            <label for="rbEhMembroIURD_S"> Sim </label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbEhMembroIURD_N" value="N" name="rbEhMembroIURD">
                                                                            <label for="rbEhMembroIURD_N"> Não </label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_email">Mês e Ano que chegou ?</label>
                                                                <input type="text" id="txtMesAnoChegadaIURD" name="txtMesAnoChegadaIURD" class="form-control" data-mask="99/9999" >
                                                                <span class="form-text">MM/AAAA </span>
                                                                                                                                
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_phone">Como conheceu ?</label>
                                                                <input id="txtComoConheceuIURD" type="text" name="txtComoConheceuIURD" class="form-control" >
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                    </div>

                                                    <!-- Primeiro separador -->
                                                    <div class="clearfix"></div>

                                                    <div class="row">

                                                        <div class="col-sm-4">
                                                        <div class="form-group">
                                                                <label for="form_name">Já se afastou alguma vez ?</label>
                                                                <div class="row">
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbJaSeAfastou_S" value="S" name="rbJaSeAfastou" >
                                                                            <label for="rbJaSeAfastou_S"> Sim </label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbJaSeAfastou_N" value="N" name="rbJaSeAfastou">
                                                                            <label for="rbJaSeAfastou_N"> Não </label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_email">Porque ?</label>
                                                                <input id="txtMotivoAfastamento" type="text" name="txtMotivoAfastamento" class="form-control" >
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_phone">Quando ?</label>
                                                                <input type="text" id="txtMesAnoAfastou" name="txtMesAnoAfastou" class="form-control" data-mask="99/9999" >
                                                                <span class="form-text">MM/AAAA </span>
                                                                
                                                            </div>
                                                        </div>

                                                    </div>

                                                    <!-- Separador  -->
                                                    <div class="clearfix"></div>

                                                    <div class="row">

                                                        <div class="col-sm-4">
                                                        <div class="form-group">
                                                                <label for="form_name">Por quanto tempo ? </label>
                                                                <input id="txtPorQuantoTempoSeAfastou" type="text" name="txtPorQuantoTempoSeAfastou" class="form-control"  >
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_email">Esta firme desde quando ? </label>
                                                                <input type="text" id="txtDesdeQuandoFirme" name="txtDesdeQuandoFirme" class="form-control" data-mask="99/9999" >
                                                                <span class="form-text">MM/AAAA </span>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_phone">Tem familiares na Universal ?</label>                                                                
                                                                <div class="row">
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbTemFamiliaresIURD_S" value="S" name="rbTemFamiliaresIURD" >
                                                                            <label for="rbTemFamiliaresIURD_S"> Sim </label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbTemFamiliaresIURD_N" value="N" name="rbTemFamiliaresIURD">
                                                                            <label for="rbTemFamiliaresIURD_N"> Não </label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Quem são ? </label>
                                                                <input id="txtFamiliaresIURD" type="text" name="txtFamiliaresIURD" class="form-control"  >
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <!---->
                                                </div>
                                            </div>
                                            <div role="tabpanel" id="DadosBatismo" class="tab-pane">
                                                <div class="panel-body">
                                                    <!---->
                                                    <div class="row">
                                        
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_email">Batizado nas águas ?</label>                                                            
                                                            <div class="row">
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger radio-inline">
                                                                        <input type="radio" id="rbBatizadoAguas_S" value="S" name="rbBatizadoAguas" >
                                                                        <label for="rbBatizadoAguas_S"> Sim </label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger radio-inline">
                                                                        <input type="radio" id="rbBatizadoAguas_N" value="N" name="rbBatizadoAguas">
                                                                        <label for="rbBatizadoAguas_N"> Não </label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_phone">Quando (Mês/Ano) ?</label>                                                            
                                                            <input type="text" id="txtQuandoSeBatizouAguas" name="txtQuandoSeBatizouAguas" class="form-control" data-mask="99/9999" >
                                                                <span class="form-text">MM/AAAA </span>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Foi na Universal ? </label>
                                                            <div class="row">
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger radio-inline">
                                                                        <input type="radio" id="rbBatismoAguasNaIURD_S" value="S" name="rbBatismoAguasNaIURD" >
                                                                        <label for="rbBatismoAguasNaIURD_S"> Sim </label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger radio-inline">
                                                                        <input type="radio" id="rbBatismoAguasNaIURD_N" value="N" name="rbBatismoAguasNaIURD">
                                                                        <label for="rbBatismoAguasNaIURD_N"> Não </label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                                                                                        
                                                        </div>
                                                    </div>

                                                </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">                                        

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_email">Batizado com Espírito Santo ? </label>
                                                                <div class="row">
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbBatizadoEspiritoSanto_S" value="S" name="rbBatizadoEspiritoSanto" >
                                                                            <label for="rbBatizadoEspiritoSanto_S"> Sim </label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbBatizadoEspiritoSanto_N" value="N" name="rbBatizadoEspiritoSanto">
                                                                            <label for="rbBatizadoEspiritoSanto_N"> Não </label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_phone">Quando (Mês/Ano) ?</label>
                                                                <input type="text" id="txtQuandoSeBatizadoES" name="txtQuandoSeBatizadoES" class="form-control" data-mask="99/9999" >
                                                                <span class="form-text">MM/AAAA </span>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Onde? *</label>
                                                                <input id="txtOndeBatismoEspiritoSanto" type="text" name="txtOndeBatismoEspiritoSanto" class="form-control" >
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                        
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_email">Como conheceu a força jovem universa ? </label>
                                                                <input id="txtComoConheceuFJU" type="text" name="txtComoConheceuFJU" class="form-control" >
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_phone">Quando (Mês/Ano) entrou na FJU ?</label>
                                                                <input type="text" id="txtQuandoEntrouFJU" name="txtQuandoEntrouFJU" class="form-control" data-mask="99/9999" >
                                                                <span class="form-text">MM/AAAA </span>

                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Porque ? </label>
                                                                <input id="txtMotivoEntrouFJU" type="text" name="txtMotivoEntrouFJU" class="form-control" >
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>         

                                                    </div>
                                                    <!---->
                                                </div>
                                            </div>
                                            <div role="tabpanel" id="LivrosLidos" class="tab-pane">
                                                <div class="panel-body">
                                                    <!---->
                                                    <div class="row">
                                                    <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Você tem Bíblia ? </label>
                                                                <div class="row">
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbTemBiblia_S" value="S" name="rbTemBiblia" >
                                                                            <label for="rbTemBiblia_S"> Sim </label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbTemBiblia_N" value="N" name="rbTemBiblia">
                                                                            <label for="rbTemBiblia_N"> Não </label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Tem Bíblia no celular ? </label>
                                                                <div class="row">
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbTemBibliaNoCelular_S" value="S" name="rbTemBibliaNoCelular" >
                                                                            <label for="rbTemBibliaNoCelular_S"> Sim </label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbTemBibliaNoCelular_N" value="N" name="rbTemBibliaNoCelular">
                                                                            <label for="rbTemBibliaNoCelular_N"> Não </label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                
                                                                
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Já leu a Bíblia toda ? </label>
                                                                <div class="row">
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbJaLeuBibliaToda_S" value="S" name="rbJaLeuBibliaToda" >
                                                                            <label for="rbJaLeuBibliaToda_S"> Sim </label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbJaLeuBibliaToda_N" value="N" name="rbJaLeuBibliaToda">
                                                                            <label for="rbJaLeuBibliaToda_N"> Não </label>
                                                                        </div>
                                                                    </div>
                                                                </div>                                                                
                                                                
                                                            </div>
                                                        </div>
                                                        <!---->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Com que frequência você lê a Bíblia ? </label>
                                                                <select id="cboFrequenciaLeituraBiblia" name="cboFrequenciaLeituraBiblia" class="form-control">
                                                                        <option value=""></option>
                                                                          <option value="5">Todos os dias</option>
                                                                          <option value="6">3x na semana</option>
                                                                          <option value="7">1x na semana</option>
                                                                          <option value="8">Não leio</option>
                                                                    <%--<option value="1">Todos os dias</option>
                                                                    <option value="2">3x na semana</option>
                                                                    <option value="3">1x na semana</option>
                                                                    <option value="4">Não leio</option>--%>
                                                                </select>
                                                                <!---->
                                                            </div>
                                                        </div>
                                                        <!---->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Pertence a algum grupo de mulheres na Universal ? </label>
                                                                <div class="row">
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbFazParteGrupoMulheresUniversal_S" value="S" name="rbFazParteGrupoMulheresUniversal" >
                                                                            <label for="rbFazParteGrupoMulheresUniversal_S"> Sim </label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbFazParteGrupoMulheresUniversal_N" value="N" name="rbFazParteGrupoMulheresUniversal">
                                                                            <label for="rbFazParteGrupoMulheresUniversal_N"> Não </label>
                                                                        </div>
                                                                    </div>
                                                                </div>                                                                
                                                                
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Qual ? </label>
                                                                <input id="txtNomeGrupoMulheresUniversal" type="text" name="txtNomeGrupoMulheresUniversal" class="form-control" >                                                                
                                                            </div>
                                                        </div>
                                                        <!---->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <div class="col-sm-6">
                                                            <div class="form-group">
                                                                <label for="form_name">Marque quais reuniões jovem participa</label>
                                                                <div class="row">

                                                                    <div class="checkbox checkbox-primary">
                                                                        <input id="chkEncontroJovem" name="chkEncontroJovem" type="checkbox" value="10" >
                                                                        <label for="chkEncontroJovem">
                                                                            Encontro Jovem
                                                                        </label>
                                                                    </div>
                                                                    <div class="checkbox checkbox-primary">
                                                                        <input id="chkReuniaoAlgoAMais" name="chkReuniaoAlgoAMais" type="checkbox" value="11">
                                                                        <label for="chkReuniaoAlgoAMais">
                                                                            Algo a Mais
                                                                        </label>
                                                                    </div>
                                                                    <div class="checkbox checkbox-primary">
                                                                        <input id="chkReuniaoaltarJovem" name="chkReuniaoaltarJovem" type="checkbox" value="12">
                                                                        <label for="chkReuniaoaltarJovem">
                                                                            Altar Jovem
                                                                        </label>
                                                                    </div>
                                                                    <div class="checkbox checkbox-primary">
                                                                        <input id="chkReuniaoProjeto" name="chkReuniaoProjeto" type="checkbox" value="13">
                                                                        <label for="chkReuniaoProjeto">
                                                                            Projeto
                                                                        </label>
                                                                    </div>
                                                                    <%--<div class="checkbox checkbox-primary">
                                                                        <input id="chkEncontroJovem" name="chkEncontroJovem" type="checkbox" value="6" >
                                                                        <label for="chkEncontroJovem">
                                                                            Encontro Jovem
                                                                        </label>
                                                                    </div>
                                                                    <div class="checkbox checkbox-primary">
                                                                        <input id="chkReuniaoAlgoAMais" name="chkReuniaoAlgoAMais" type="checkbox" value="7">
                                                                        <label for="chkReuniaoAlgoAMais">
                                                                            Algo a Mais
                                                                        </label>
                                                                    </div>
                                                                    <div class="checkbox checkbox-primary">
                                                                        <input id="chkReuniaoaltarJovem" name="chkReuniaoaltarJovem" type="checkbox" value="8">
                                                                        <label for="chkReuniaoaltarJovem">
                                                                            Altar Jovem
                                                                        </label>
                                                                    </div>
                                                                    <div class="checkbox checkbox-primary">
                                                                        <input id="chkReuniaoProjeto" name="chkReuniaoProjeto" type="checkbox" value="9">
                                                                        <label for="chkReuniaoProjeto">
                                                                            Projeto
                                                                        </label>
                                                                    </div>--%>
                                                                    
                                                                </div>
                                                                <!---->
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">

                                                        <div class="col-sm-12">
                                                            <div class="form-group">
                                                                <label for="form_name">Marque os livros que o jovem já leu</label>
                                                                <div class="row">
                                                                    <div class="checkbox checkbox-primary">
                                                                        <input id="chkLivroPassosJesus" name="chkLivroPassosJesus" type="checkbox" value="16" >
                                                                        <label for="chkLivroPassosJesus">
                                                                            Nos passos de Jesus
                                                                        </label>
                                                                    </div>
                                                                    <div class="checkbox checkbox-primary">
                                                                        <input id="chkLivroDamaFe" name="chkLivroDamaFe" type="checkbox" value="17">
                                                                        <label for="chkLivroDamaFe">
                                                                            A Dama da Fé
                                                                        </label>
                                                                    </div>
                                                                    <div class="checkbox checkbox-primary">
                                                                        <input id="chkLivroOEspiritoSanto" name="chkLivroOEspiritoSanto" type="checkbox" value="18">
                                                                        <label for="chkLivroOEspiritoSanto">
                                                                            O Espírito Santo
                                                                        </label>
                                                                    </div>
                                                                    <div class="checkbox checkbox-primary">
                                                                        <input id="chkLivroCB" name="chkLivroCB" type="checkbox" value="19">
                                                                        <label for="chkLivroCB">
                                                                            Casamento Blindado
                                                                        </label>
                                                                    </div>
                                                                    <div class="checkbox checkbox-primary">
                                                                        <input id="chkLivroGuerrasDaFe" name="chkLivroGuerrasDaFe" type="checkbox" value="15">
                                                                        <label for="chkLivroGuerrasDaFe">
                                                                            Como vencer suas guerras pela fé
                                                                        </label>
                                                                    </div>
                                                                    <%--<div class="checkbox checkbox-primary">
                                                                        <input id="chkLivroPassosJesus" name="chkLivroPassosJesus" type="checkbox" value="1" >
                                                                        <label for="chkLivroPassosJesus">
                                                                            Nos passos de Jesus
                                                                        </label>
                                                                    </div>
                                                                    <div class="checkbox checkbox-primary">
                                                                        <input id="chkLivroDamaFe" name="chkLivroDamaFe" type="checkbox" value="4">
                                                                        <label for="chkLivroDamaFe">
                                                                            A Dama da Fé
                                                                        </label>
                                                                    </div>
                                                                    <div class="checkbox checkbox-primary">
                                                                        <input id="chkLivroOEspiritoSanto" name="chkLivroOEspiritoSanto" type="checkbox" value="5">
                                                                        <label for="chkLivroOEspiritoSanto">
                                                                            O Espírito Santo
                                                                        </label>
                                                                    </div>
                                                                    <div class="checkbox checkbox-primary">
                                                                        <input id="chkLivroCB" name="chkLivroCB" type="checkbox" value="6">
                                                                        <label for="chkLivroCB">
                                                                            Casamento Blindado
                                                                        </label>
                                                                    </div>
                                                                    <div class="checkbox checkbox-primary">
                                                                        <input id="chkLivroGuerrasDaFe" name="chkLivroGuerrasDaFe" type="checkbox" value="2">
                                                                        <label for="chkLivroGuerrasDaFe">
                                                                            Como vencer suas guerras pela fé
                                                                        </label>
                                                                    </div>--%>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="checkbox checkbox-primary">
                                                                        <input id="chkLivroNB" name="chkLivroNB" type="checkbox" value="20" >
                                                                        <label for="chkLivroNB">
                                                                            Namoro Blindado
                                                                        </label>
                                                                    </div>
                                                                    <div class="checkbox checkbox-primary">
                                                                        <input id="chkLivroMelhorSapatos" name="chkLivroMelhorSapatos" type="checkbox" value="21">
                                                                        <label for="chkLivroMelhorSapatos">
                                                                            Melhor Que Comprar Sapatos
                                                                        </label>
                                                                    </div>
                                                                    <div class="checkbox checkbox-primary">
                                                                        <input id="chkLivroAMulherV" name="chkLivroAMulherV" type="checkbox" value="22">
                                                                        <label for="chkLivroAMulherV">
                                                                            A Mulher V
                                                                        </label>
                                                                    </div>
                                                                    <div class="checkbox checkbox-primary">
                                                                        <input id="chkLivroLinda40" name="chkLivroLinda40" type="checkbox" value="23">
                                                                        <label for="chkLivroLinda40">
                                                                            Mais Linda em 40 dias
                                                                        </label>
                                                                    </div>
                                                                    <div class="checkbox checkbox-primary">
                                                                        <input id="chkLivro40Segredos" name="chkLivro40Segredos" type="checkbox" value="24">
                                                                        <label for="chkLivro40Segredos">
                                                                            40 Segredos Que Toda Solteira Deveria Saber
                                                                        </label>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="checkbox checkbox-primary">
                                                                        <input id="chkLivroNP" name="chkLivroNP" type="checkbox" value="25">
                                                                        <label for="chkLivroNP">
                                                                            Nada A Perder
                                                                        </label>
                                                                    </div>
                                                                    <div class="checkbox checkbox-primary">
                                                                        <input id="chkLivroObraDeus" name="chkLivroObraDeus" type="checkbox" value="26">
                                                                        <label for="chkLivroObraDeus">
                                                                            Como Fazer a Obra de Deus
                                                                        </label>
                                                                    </div>
                                                                    <div class="checkbox checkbox-primary">
                                                                        <input id="chkLivroOrixasEGuias" name="chkLivroOrixasEGuias" type="checkbox" value="27">
                                                                        <label for="chkLivroOrixasEGuias">
                                                                            Orixás, caboclos e guias, Deuses ou demônios
                                                                        </label>
                                                                    </div>
                                                                </div>
                                                                <!---->
                                                                
                                                            </div>
                                                        </div>         
                                                    
                                                    </div>
                                                    <!---->
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- END-->
                                </fieldset>

                                <h1>Situação</h1>
                                <fieldset>
                                    <!-- Begin TABS SITUAÇÃO -->
                                    <div class="tabs-container">
                                        <ul class="nav nav-tabs" role="tablist">
                                            <li><a class="nav-link active" data-toggle="tab" href="#tab1infoIURD"> IURD</a></li>
                                            <li><a class="nav-link" data-toggle="tab" href="#tab2infoFJU">FJU</a></li>
                                            <li><a class="nav-link" data-toggle="tab" href="#tab2infoIntellimen">Intellimen</a></li>
                                        </ul>
                                        <div class="tab-content">
                                        
                                            <div role="tabpanel" id="tab1infoIURD" class="tab-pane active">
                                                <div class="panel-body">
                                                <!---->
                                                <div class="clearfix"></div>

                                                <div class="row">
                                                    <!---->
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Obreiro ?</label>
                                                            <div class="checkbox checkbox-primary">
                                                                <input id="chkEhObreiro" name="chkEhObreiro" type="checkbox" value="S">
                                                                <label for="chkEhObreiro">
                                                                    Sim
                                                                </label>
                                                            </div>
                                                        </div>
                                                    </div>


                                                    <div class="col-sm-4 inline">
                                                        <%--<div class="form-group row">
                                                            <label for="form_name">Tempo de Obreiro( Quantos anos / Quantos meses ) </label>
                                                            <div class="col-md-4">
                                                                <input type="number" min="0" max="30" class="form-control">
                                                                <input type="number" min="0" max="30" class="form-control">
                                                            </div>
                                                        </div>--%>
                                                        <div class="form-group">
                                                            <label>Tempo de Obreiro (Anos/Meses)</label>                                                             
                                                            <div class="row">
                                                                
                                                                <div class="col-4">
                                                                    <input type="number" id="txtAnosEhObreiro" name="txtAnosEhObreiro" min="0" max="30" class="form-control">
                                                                </div>
                                                                <div class="col-4">
                                                                    <input type="number" id="txtMesesEhObreiro" name="txtMesesEhObreiro" min="0" max="30" class="form-control">
                                                                </div>
                                                                
                                                            </div>
                                                            
                                                        </div>
                                                    </div>
                                                    <!---->
                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">
                                                    <!---->
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Colaborador ?</label>
                                                            <div class="checkbox checkbox-primary">
                                                                <input id="chkEhColaborador" name="chkEhColaborador" type="checkbox" value="S">
                                                                <label for="chkEhColaborador">
                                                                    Sim
                                                                </label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Tempo de Colaborador (Anos/Meses) </label>
                                                            <div class="row">
                                                                
                                                                <div class="col-4">
                                                                    <input type="number" id="txtAnosEhColaborador" name="txtAnosEhColaborador" min="0" max="30" class="form-control">
                                                                </div>
                                                                <div class="col-4">
                                                                    <input type="number" id="txtMesesEhColaborador" name="txtMesesEhColaborador" min="0" max="30" class="form-control">
                                                                </div>
                                                                
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!---->
                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">
                                                    <!---->
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">CPO (Curso Preparatório de Obreiros) ?</label>
                                                            <div class="checkbox checkbox-primary">
                                                                <input id="chkCursandoCPO" name="chkCursandoCPO" type="checkbox" value="S">
                                                                <label for="chkCursandoCPO">
                                                                    Sim
                                                                </label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Tempo no CPO (Anos/Meses) </label>
                                                            <div class="row">
                                                                
                                                                <div class="col-4">
                                                                    <input type="number" id="txtAnosInicioCPO" min="0" max="30" class="form-control">
                                                                </div>
                                                                <div class="col-4">
                                                                    <input type="number" id="txtMesesInicioCPO" name="txtMesesInicioCPO" min="0" max="30" class="form-control">
                                                                </div>
                                                                
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!---->
                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">
                                                    <!---->
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Já foi obreiro antes ? </label>                                                            
                                                            <div class="row">
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger radio-inline">
                                                                        <input type="radio" id="rbJaFoiObreiroAntes_S" value="S" name="rbJaFoiObreiroAntes" >
                                                                        <label for="rbJaFoiObreiroAntes_S"> Sim </label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger radio-inline">
                                                                        <input type="radio" id="rbJaFoiObreiroAntes_N" value="N" name="rbJaFoiObreiroAntes">
                                                                        <label for="rbJaFoiObreiroAntes_N"> Não </label>
                                                                    </div>
                                                                </div>
                                                            </div>                                                                
                                                                
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Se sim, saiu porque ? </label>
                                                            <input id="txtMotivoSaidaObreiro" type="text" name="txtMotivoSaidaObreiro" class="form-control"  >
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>                                        
                                                    <!---->
                                                </div>

                                                <div class="clearfix"></div>

                                                <div class="row">
                                                    <!---->
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Já foi Pastor/Esposa antes ? </label>
                                                            <div class="row">
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger radio-inline">
                                                                        <input type="radio" id="rbJaFoiPastoEsposaAntes_S" value="S" name="rbJaFoiPastorEsposaAntes" >
                                                                        <label for="rbJaFoiPastoEsposaAntes_S"> Sim </label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger radio-inline">
                                                                        <input type="radio" id="rbJaFoiPastoEsposaAntes_N" value="N" name="rbJaFoiPastorEsposaAntes">
                                                                        <label for="rbJaFoiPastoEsposaAntes_N"> Não </label>
                                                                    </div>
                                                                </div>
                                                            </div>                                                            
                                                            
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Se sim, saiu porque ? </label>
                                                            <input id="txtMotivoSaidaPastorEsposa" type="text" name="txtMotivoSaidaPastorEsposa" class="form-control" >
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>
                                                    <!---->
                                                </div>
                                                <!---->
                                            </div>
                                            </div>
                                            <div role="tabpanel" id="tab2infoFJU" class="tab-pane">
                                                <div class="panel-body">
                                                <!---->
                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Membro da Força Jovem Universal ?</label>
                                                                <div class="checkbox checkbox-primary">
                                                                    <input id="chkMembroFJU" name="chkMembroFJU" type="checkbox" value="s">
                                                                    <label for="chkMembroFJU">
                                                                        Sim
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Coordenador da Força Jovem ?</label>   
                                                                <div class="checkbox checkbox-primary">
                                                                    <input id="chkEhCoordenadorFJU" name="chkEhCoordenadorFJU" type="checkbox" value="s">
                                                                    <label for="chkEhCoordenadorFJU">
                                                                        Sim
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>


                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Desde quando ? (Anos/Meses) </label>
                                                                <div class="row">
                                                                
                                                                    <div class="col-4">
                                                                        <input type="number" id="txtAnosInicioCoordenacaoFJU" name="txtAnosInicioCoordenacaoFJU" min="0" max="30" class="form-control">
                                                                    </div>
                                                                    <div class="col-4">
                                                                        <input type="number" id="txtMesesInicioCoordenacaoFJU" name="txtMesesInicioCoordenacaoFJU" min="0" max="30" class="form-control">
                                                                    </div>
                                                                
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!---->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Líder de Tribo ?</label>
                                                                <div class="checkbox checkbox-primary">
                                                                    <input id="chkLiderTribo" name="chkLiderTribo" type="checkbox" value="S">
                                                                    <label for="chkLiderTribo">
                                                                        Sim
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Qual Tribo ?</label>
                                                                <select id="cboTribo" name="cboTribo" class="select2_demo_3 form-control" >
                                                                    <option></option>
                                                                    <option value="13">Rúben</option>
                                                                    <option value="14">Simeão</option>
                                                                    <option value="15">Levi</option>
                                                                    <option value="16">Judá</option>
                                                                    <option value="17">Zebulom</option>
                                                                    <option value="18">Issacar</option>
                                                                    <option value="19">Manassés</option>
                                                                    <option value="20">Gade</option>
                                                                    <option value="21">Aser</option>
                                                                    <option value="22">Naftali</option>
                                                                    <option value="25">Efraim</option>
                                                                    <option value="24">Benjamin</option>
                                                                    <%--<option value="1">Rúben</option>
                                                                    <option value="2">Simeão</option>
                                                                    <option value="3">Levi</option>
                                                                    <option value="4">Judá</option>
                                                                    <option value="5">Zebulom</option>
                                                                    <option value="6">Issacar</option>
                                                                    <option value="7">Manassés</option>
                                                                    <option value="8">Gade</option>
                                                                    <option value="9">Aser</option>
                                                                    <option value="10">Naftali</option>
                                                                    <option value="11">Efraim</option>
                                                                    <option value="12">Benjamin</option>--%>
                                                                </select>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Há quanto tempo ? (Quantos anos/Quantos meses) </label>
                                                                <div class="row">
                                                                
                                                                    <div class="col-4">
                                                                        <input type="number" id="txtAnosInicioCoordenacaoTribo" name="txtAnosInicioCoordenacaoTribo" min="0" max="30" class="form-control">
                                                                    </div>
                                                                    <div class="col-4">
                                                                        <input type="number" id="txtMesesInicioCoordenacaoTribo" name="txtMesesInicioCoordenacaoTribo" min="0" max="30" class="form-control">
                                                                    </div>
                                                                
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!---->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!-- -->                                                    
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Líder de Projeto ?</label>
                                                                <div class="checkbox checkbox-primary">
                                                                    <input id="chkLiderProjeto" name="chkLiderProjeto" type="checkbox" value="s">
                                                                    <label for="chkLiderProjeto">
                                                                        Sim
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Qual Projeto ?</label>
                                                                <select id="cboProjetoFJU" name="cboProjetoFJU" class="select2_demo_3 form-control" >
                                                                    <option></option>
                                                                    <option value="10">Help</option>
                                                                    <option value="11">Arcanjos</option>
                                                                    <option value="12">Esporte</option>
                                                                    <option value="13">Uniforça</option>
                                                                    <option value="14">Atalaia</option>
                                                                    <option value="15">Universitários</option>
                                                                    <option value="16">Mídia</option>
                                                                    <option value="17">Secretárias</option>
                                                                    <option value="18">Cultura</option>
                                                                    <%--<option value="1">Help</option>
                                                                    <option value="2">Arcanjos</option>
                                                                    <option value="3">Esporte</option>
                                                                    <option value="4">Uniforça</option>
                                                                    <option value="5">Atalaia</option>
                                                                    <option value="6">Universitários</option>
                                                                    <option value="7">Mídia</option>
                                                                    <option value="8">Secretárias</option>
                                                                    <option value="9">Cultura</option>--%>
                                                                </select>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Há quanto tempo ? (Quantos anos/Quantos meses) </label>
                                                                <div class="row">
                                                                
                                                                    <div class="col-4">
                                                                        <input type="number" id="txtAnosInicioCoordenacaoProjeto" name="txtAnosInicioCoordenacaoProjeto" min="0" max="30" class="form-control">
                                                                    </div>
                                                                    <div class="col-4">
                                                                        <input type="number" id="txtMesesInicioCoordenacaoProjeto" name="txtMesesInicioCoordenacaoProjeto" min="0" max="30" class="form-control">
                                                                    </div>
                                                                
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- -->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Tem desejo de ser obreiro ? </label>
                                                                <div class="row">
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbDesejaSerObreiro_S" value="S" name="rbDesejaSerObreiro" >
                                                                            <label for="rbDesejaSerObreiro_S"> Sim </label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbDesejaSerObreiro_N" value="N" name="rbDesejaSerObreiro">
                                                                            <label for="rbDesejaSerObreiro_N"> Não </label>
                                                                        </div>
                                                                    </div>
                                                                </div>                                                                
                                                                
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Porque ? </label>
                                                                <input id="txtMotivoDesejaSErObreiro" type="text" name="txtMotivoDesejaSErObreiro" class="form-control" >
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>                                  
                                                        <!---->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Deseja fazer a obra no altar ? </label>
                                                                <div class="row">
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbDesejaFazerObraAltar_S" value="S" name="rbDesejaFazerObraAltar" >
                                                                            <label for="rbDesejaFazerObraAltar_S"> Sim </label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbDesejaFazerObraAltar_N" value="N" name="rbDesejaFazerObraAltar">
                                                                            <label for="rbDesejaFazerObraAltar_N"> Não </label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                
                                                                
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Esta no Altar Jovem ? </label>
                                                                <div class="row">
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbEstaNoAltarJovem_S" value="S" name="rbEstaNoAltarJovem" >
                                                                            <label for="rbEstaNoAltarJovem_S"> Sim </label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbEstaNoAltarJovem_N" value="N" name="rbEstaNoAltarJovem">
                                                                            <label for="rbEstaNoAltarJovem_N"> Não </label>
                                                                        </div>
                                                                    </div>
                                                                </div>                                                                
                                                                
                                                            </div>
                                                        </div>             
                                                        
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label class="text-success font-bold" style="font-family: Helvetica;" for="form_name">Esta no Projeto Altar Jovem 600 ? </label>
                                                                <div class="row">
                                                                    <br /><br />
                                                                    <div class="checkbox checkbox-primary">
                                                                        <input id="chkAltarJovem318" name="chkAltarJovem318" type="checkbox" value="S">
                                                                        <label for="chkAltarJovem318">
                                                                            Sim
                                                                        </label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>             
                                                        <!---->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label class="text-success font-bold" style="font-family: Helvetica;" for="form_name">Código Altar Jovem 600 ? </label>
                                                                <input id="txtCodigoAltarJovem318" type="number" value="0" min="1" max="600" name="txtCodigoAltarJovem318" class="form-control" >
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!---->
                                            </div>
                                            </div>
                                            <div role="tabpanel" id="tab2infoIntellimen" class="tab-pane">
                                                <div class="panel-body">
                                                <!---->
                                                    <div class="row">
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Faz parte do intellimen ? </label>
                                                                <div class="row">
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbFazParteIntellimen_S" value="S" name="rbFazParteIntellimen" >
                                                                            <label for="rbFazParteIntellimen_S"> Sim </label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbFazParteIntellimen_N" value="N" name="rbFazParteIntellimen">
                                                                            <label for="rbFazParteIntellimen_N"> Não </label>
                                                                        </div>
                                                                    </div>
                                                                </div>                                                                                                                                
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Completou os desáfios ? </label>
                                                                <div class="row">
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbCompletouDesafios_S" value="S" name="rbCompletouDesafios" >
                                                                            <label for="rbCompletouDesafios_S"> Sim </label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbCompletouDesafios_N" value="N" name="rbCompletouDesafios">
                                                                            <label for="rbCompletouDesafios_N"> Não </label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Está em qual ? </label>
                                                                <input class="form-control" type="number" value="0" id="txtNumeroDesafioIntellimen" name="txtNumeroDesafioIntellimen" min="0" max="53" >
                                                            </div>
                                                        </div>                                                
                                                
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Qual o nome do seu parceiro</label>
                                                                <input id="txtNomeParceiroIntellimen" type="text" name="txtNomeParceiroIntellimen" class="form-control"  >
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Telefone Parceiro</label>
                                                                    <input id="txtTelefoneParceiroIntellimen" name="txtTelefoneParceiroIntellimen" type="text" class="form-control" data-mask="(99) 99999-9999" placeholder="">
                                                                <span class="form-text">(99) 99999-9999</span>

                                                            </div>
                                                        </div>
                                                        <!---->
                                                    </div>
                                                    <!---->
                                            </div>
                                            </div>

                                        </div>
                                    </div>
                                    <!-- END TABS SITUAÇÃO -->
                                </fieldset>

                                <h1>Projetos</h1>
                                <fieldset>
                                    <h2>Informações relacionadas aos Projetos</h2>
                                    
                                    <div class="row">

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_name">Qual Projeto jovem pertence ?</label>
                                                <select id="cboProjetoJovemPertence" name="cboProjetoJovemPertence" class="select2_demo_3 form-control" >
                                                    <option value="0">Nenhum</option>
                                                    <option value="10">Help</option>
                                                    <option value="11">Arcanjos</option>
                                                    <option value="12">Esporte</option>
                                                    <option value="13">Uniforça</option>
                                                    <option value="14">Atalaia</option>
                                                    <option value="15">Universitários</option>
                                                    <option value="16">Mídia</option>
                                                    <option value="17">Secretárias</option>
                                                    <option value="18">Cultura</option>
                                                    <%--<option value="1">Help</option>
                                                    <option value="2">Arcanjos</option>
                                                    <option value="3">Esporte</option>
                                                    <option value="4">Uniforça</option>
                                                    <option value="5">Atalaia</option>
                                                    <option value="6">Universitários</option>
                                                    <option value="7">Mídia</option>
                                                    <option value="8">Secretárias</option>
                                                    <option value="9">Cultura</option>--%>
                                                </select>
                                            </div>
                                        </div>

                                        <div class="col-sm-4 inline">
                                            <div class="form-group">
                                                <label>Tempo no Projeto (Anos/Meses)</label>
                                                <div class="row">
                                                                
                                                    <div class="col-4">
                                                        <input type="number" id="txtAnosProjeto" name="txtAnosProjeto" min="0" max="30" class="form-control">
                                                    </div>
                                                    <div class="col-4">
                                                        <input type="number" id="txtMesesProjeto" name="txtMesesProjeto" min="0" max="30" class="form-control">
                                                    </div>
                                                                
                                                </div>
                                                            
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_name">Esteve em outro Projeto ? </label>
                                                <div class="row">
                                                    <div class="col-2">
                                                        <div class="radio radio-danger radio-inline">
                                                            <input type="radio" id="rbJaEsteveEmOutroProjeto_S" value="S" name="rbJaEsteveEmOutroProjeto" >
                                                            <label for="rbJaEsteveEmOutroProjeto_S"> Sim </label>
                                                        </div>
                                                    </div>
                                                    <div class="col-2">
                                                        <div class="radio radio-danger radio-inline">
                                                            <input type="radio" id="rbJaEsteveEmOutroProjeto_N" value="N" name="rbJaEsteveEmOutroProjeto">
                                                            <label for="rbJaEsteveEmOutroProjeto_N"> Não </label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="clearfix"></div>

                                    <div class="row">
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_name">Qual Projeto Anterior ?</label>
                                                <select id="cboProjetoAnterior" name="cboProjetoAnterior" class="select2_demo_3 form-control" >
                                                    <option value="0">Nenhum</option>
                                                    <option value="10">Help</option>
                                                    <option value="11">Arcanjos</option>
                                                    <option value="12">Esporte</option>
                                                    <option value="13">Uniforça</option>
                                                    <option value="14">Atalaia</option>
                                                    <option value="15">Universitários</option>
                                                    <option value="16">Mídia</option>
                                                    <option value="17">Secretárias</option>
                                                    <option value="18">Cultura</option>
                                                    <%--<option value="1">Help</option>
                                                    <option value="2">Arcanjos</option>
                                                    <option value="3">Esporte</option>
                                                    <option value="4">Uniforça</option>
                                                    <option value="5">Atalaia</option>
                                                    <option value="6">Universitários</option>
                                                    <option value="7">Mídia</option>
                                                    <option value="8">Secretárias</option>
                                                    <option value="9">Cultura</option>--%>
                                                </select>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_name">Tem camisa da FJU ? </label>
                                                <div class="row">
                                                    <div class="col-2">
                                                        <div class="radio radio-danger radio-inline">
                                                            <input type="radio" id="rbTemCamisaFJU_S" value="S" name="rbTemCamisaFJU" >
                                                            <label for="rbTemCamisaFJU_S"> Sim </label>
                                                        </div>
                                                    </div>
                                                    <div class="col-2">
                                                        <div class="radio radio-danger radio-inline">
                                                            <input type="radio" id="rbTemCamisaFJU_N" value="N" name="rbTemCamisaFJU">
                                                            <label for="rbTemCamisaFJU_N"> Não </label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_name">Qual Camisa ?</label>
                                                <select id="cboCamisasFJU" name="cboCamisasFJU" class="select2_demo_3 form-control" >
                                                    <option value="0">Não possui</option>
                                                    <option value="Coordenador">Coordenador</option>
                                                    <option value="Obreiro Masculina">Obreiro Masculina</option>
                                                    <option value="Obreira Feminina">Obreira Feminina</option>
                                                    <option value="Jovem Masculina">Jovem Masculina</option>
                                                    <option value="Jovem Feminina">Jovem Feminina</option>
                                                    <option value="Atalaia">Atalaia</option>
                                                    <option value="Help">Help</option>
                                                    <option value="Universitários">Universitários</option>
                                                    <option value="Mídia">Mídia</option>
                                                    <option value="Secretárias">Secretárias</option>
                                                    <option value="Cultura">Cultura</option>
                                                    <option value="Arcanjos">Arcanjos</option>
                                                    <option value="Uniforça">Uniforça</option>
                                                </select>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="clearfix"></div>

                                    <div class="row">

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_name">Tamanho</label>
                                                <select id="cboTamanhoCamisaFJU" name="cboTamanhoCamisaFJU" class="select2_demo_3 form-control" >
                                                    <option value="P">P</option>
                                                    <option value="M">M</option>
                                                    <option value="G">G</option>
                                                    <option value="GG">GG</option>
                                                    <option value="XG">XG</option>
                                                    <option value="XGG">XGG</option>
                                                </select>
                                            </div>
                                        </div>

                                    </div>

                                </fieldset>

                                <h1>Habilidades e Idiomas</h1>
                                <fieldset>                                    
                                    <div class="tabs-container">
                                        <ul class="nav nav-tabs" role="tablist">
                                            <li><a class="nav-link active" data-toggle="tab" href="#tabCultura"> Cultura</a></li>
                                            <li><a class="nav-link" data-toggle="tab" href="#tabEsporte">Esporte</a></li>
                                            <li><a class="nav-link" data-toggle="tab" href="#tabMidia">Mídia</a></li>
                                            <li><a class="nav-link" data-toggle="tab" href="#tabUniversitarios">Universitários</a></li>
                                            <li><a class="nav-link" data-toggle="tab" href="#tabcursosAdicionais">Cursos Adicionais</a></li>
                                            <li><a class="nav-link" data-toggle="tab" href="#tabIdiomas">Idiomas</a></li>
                                        </ul>
                                        <div class="tab-content">
                                            <div role="tabpanel" id="tabCultura" class="tab-pane active">
                                                <div class="panel-body">
                                                    <div class="ibox">
                                                                <div class="ibox-title">
                                                                    <h5>Adicione as habilidades relacionadas ao Projeto Cultura</h5>
                                                                </div>
                                                                <div class="ibox-content">

                                                                    <div class="row">
                                                                        <label for="form_name">Selecione o departamento </label>
                                                                        <div class="checkbox checkbox-primary">
                                                                                        <input id="chkDanca" name="chkDanca" type="checkbox" value="9" >
                                                                                         <%--<input id="chkDanca" name="chkDanca" type="checkbox" value="5" >--%>
                                                                                        <label for="chkDanca">
                                                                                            Dança
                                                                                        </label>
                                                                                    </div>

                                                                                    <div class="checkbox checkbox-primary">
                                                                                        <input id="chkBanda" name="chkBanda" type="checkbox" value="8">
                                                                                        <%--<input id="chkBanda" name="chkBanda" type="checkbox" value="6">--%>
                                                                                        <label for="chkBanda">
                                                                                            Banda
                                                                                        </label>
                                                                                    </div>

                                                                                    <div class="checkbox checkbox-primary">
                                                                                        <input id="chkTeatro" name="chkTeatro" type="checkbox" value="14">
                                                                                        <%--<input id="chkTeatro" name="chkTeatro" type="checkbox" value="14">--%>
                                                                                        <label for="chkTeatro">
                                                                                            Teatro
                                                                                        </label>
                                                                                    </div>
                                                                    </div>

                                                                    <div class="clearfix"></div>

                                                                    <div class="row">
                                                                        <div class="col-md-4">
                                                                            <p>
                                                                                Modalidades Dança 
                                                                            </p>
                                                                            <select required id="cboHabilidadesDanca" class="select2_demo_1 form-control">
                                                                                <option value="0"></option>
                                                                                <%--<option value="3">Hip Hop</option>
                                                                                <option value="4">Popping</option>
                                                                                <option value="5">Break Dance</option>
                                                                                <option value="6">Locking</option>
                                                                                <option value="7">All Style</option>
                                                                                <option value="8">Street Dance</option>
                                                                                <option value="9">Ballet Clássico</option>
                                                                                <option value="10">Neo Clássico</option>
                                                                                <option value="11">Jazz</option>
                                                                                <option value="12">Estilo Livre</option>
                                                                                <option value="13">Ballet Teatral</option>--%>
                                                                                <option value="40">Hip Hop</option>
                                                                                <option value="41">Popping</option>
                                                                                <option value="42">Break Dance</option>
                                                                                <option value="43">Locking</option>
                                                                                <option value="44">All Style</option>
                                                                                <option value="45">Street Dance</option>
                                                                                <option value="46">Ballet Clássico</option>
                                                                                <option value="47">Neo Clássico</option>
                                                                                <option value="48">Jazz</option>
                                                                                <option value="49">Estilo Livre</option>
                                                                                <option value="50">Ballet Teatral</option>
                                                                            </select>
                                                                        </div>

                                                                        <div class="col-md-4">
                                                                            <p>
                                                                                Nível
                                                                            </p>
                                                                            <select required id="cboNivelHabilidadeDanca" class="select2_demo_3 form-control">
                                                                                <option></option>
                                                                                <option value="5">1 (Regular)</option>
                                                                                <option value="4">2 (Bom)</option>
                                                                                <option value="6">3 (Excelente)</option>
                                                                                <%--<option value="1">1 (Regular)</option>
                                                                                <option value="2">2 (Bom)</option>
                                                                                <option value="3">3 (Excelente)</option>--%>
                                                                            </select>

                                                                        </div>
                                                                        <div class="col-md-4">
                                                                            <p>
                                                                                &nbsp;
                                                                            </p>
                                                                            <button id="btnAdicionaHabilidadeCultura" onclick="AdicionarHabilidadeProjetoCulturaDanca('DANCA')" class="btn btn-primary " type="button"><i class="fa fa-check"></i>&nbsp;Adicionar</button>
                                                                            <button id="btnVisualizaHabilidadeCultura" data-toggle="modal" data-target="#habilidadesModal" class="btn btn-success " type="button"><i class="fa fa-search"></i>&nbsp;Visualizar</button>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                    <!-- Box abaixo refernte às habilidades da banda -->
                                                    <div class="ibox">
                                                                <div class="ibox-title">
                                                                    <h5>Instrumentos e Classificação Vocal</h5>
                                                                </div>
                                                                <div class="ibox-content">

                                                                    <div class="row">
                                                                        <label for="form_name">Selecione a Classificação Vocal </label>
                                                                        <div class="checkbox checkbox-primary">
                                                                            <input id="chkTonTenor" name="chkTonTenor" type="checkbox" value="51" >
                                                                            <%--<input id="chkTonTenor" name="chkTonTenor" type="checkbox" value="14" >--%>
                                                                            <label for="chkTonTenor">
                                                                                Tenor
                                                                            </label>
                                                                        </div>

                                                                        <div class="checkbox checkbox-primary">
                                                                            <input id="chkTonBaritono" name="chkTonBaritono" type="checkbox" value="52">
                                                                            <%--<input id="chkTonBaritono" name="chkTonBaritono" type="checkbox" value="15">--%>
                                                                            <label for="chkTonBaritono">
                                                                                Baritono
                                                                            </label>
                                                                        </div>

                                                                        <div class="checkbox checkbox-primary">
                                                                            <input id="chkTonBaixo" name="chkTonBaixo" type="checkbox" value="53">
                                                                            <%--<input id="chkTonBaixo" name="chkTonBaixo" type="checkbox" value="16">--%>
                                                                            <label for="chkTonBaixo">
                                                                                Baixo
                                                                            </label>
                                                                        </div>

                                                                        <div class="checkbox checkbox-primary">
                                                                            <input id="chkTonSoprano" name="chkTonSoprano" type="checkbox" value="54">
                                                                            <%--<input id="chkTonSoprano" name="chkTonSoprano" type="checkbox" value="17">--%>
                                                                            <label for="chkTonSoprano">
                                                                                Soprano
                                                                            </label>
                                                                        </div>

                                                                        <div class="checkbox checkbox-primary">
                                                                            <input id="chkTonMezzosoprano" name="chkTonMezzosoprano" type="checkbox" value="55">
                                                                            <%--<input id="chkTonMezzosoprano" name="chkTonMezzosoprano" type="checkbox" value="18">--%>
                                                                            <label for="chkTonMezzosoprano">
                                                                                MezzoSoprano
                                                                            </label>
                                                                        </div>

                                                                        <div class="checkbox checkbox-primary">
                                                                            <input id="chkTonContralto" name="chkTonContralto" type="checkbox" value="56">
                                                                            <%--<input id="chkTonContralto" name="chkTonContralto" type="checkbox" value="19">--%>
                                                                            <label for="chkTonContralto">
                                                                                Contralto
                                                                            </label>
                                                                        </div>
                                                                    </div>

                                                                    <div class="clearfix"></div>

                                                                    <div class="row">
                                                                        <div class="col-md-4">
                                                                            <p>
                                                                                Modalidades Instrumentista 
                                                                            </p>
                                                                            <select required id="cboHabilidadesBANDA" class="select2_demo_1 form-control">
                                                                                <option value="0"></option>
                                                                                <%--<option value="20">Teclado</option>
                                                                                <option value="21">Violão</option>
                                                                                <option value="22">Baixo</option>
                                                                                <option value="23">Guitarra</option>
                                                                                <option value="24">Cavaquinho</option>
                                                                                <option value="25">Violino</option>
                                                                                <option value="26">Bateria</option>
                                                                                <option value="27">Percussão</option>--%>
                                                                                <option value="57">Teclado</option>
                                                                                <option value="58">Violão</option>
                                                                                <option value="59">Baixo</option>
                                                                                <option value="60">Guitarra</option>
                                                                                <option value="61">Cavaquinho</option>
                                                                                <option value="62">Violino</option>
                                                                                <option value="63">Bateria</option>
                                                                                <option value="64">Percussão</option>
                                                                            </select>
                                                                        </div>

                                                                        <div class="col-md-4">
                                                                            <p>
                                                                                Nível
                                                                            </p>
                                                                            <select required id="cboNivelHabilidadeBANDA" class="select2_demo_3 form-control">
                                                                                <option></option>
                                                                                <option value="5">1 (Regular)</option>
                                                                                <option value="4">2 (Bom)</option>
                                                                                <option value="6">3 (Excelente)</option>
                                                                                <%--<option value="1">1 (Regular)</option>
                                                                                <option value="2">2 (Bom)</option>
                                                                                <option value="3">3 (Excelente)</option>--%>
                                                                            </select>

                                                                        </div>
                                                                        <div class="col-md-4">
                                                                            <p>
                                                                                &nbsp;
                                                                            </p>
                                                                            <button id="btnAdicionaHabilidadesInstrumentosCultura" onclick="AdicionarHabilidadeProjetoCulturaDanca('BANDA')" class="btn btn-primary " type="button"><i class="fa fa-check"></i>&nbsp;Adicionar</button>
                                                                            <button id="btnVisualizaHabilidadesInstrumentoCultura" data-toggle="modal" data-target="#habilidadesModal" class="btn btn-success " type="button"><i class="fa fa-search"></i>&nbsp;Visualizar</button>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                </div>
                                            </div>
                                            <div role="tabpanel" id="tabEsporte" class="tab-pane">
                                                <div class="panel-body">
                                                    <div class="row">
                                                        <div class="col-lg-12">

                                                            <div class="ibox">
                                                                <div class="ibox-title">
                                                                    <h5>Adicione as habilidades relacionadas ao Projeto Esporte</h5>
                                                                </div>
                                                                <div class="ibox-content">

                                                                    <div class="row">
                                                                        <div class="col-md-4">
                                                                            <p>
                                                                                Modalidades
                                                                            </p>
                                                                            <select required id="cboHabilidadesESPORTE" class="select2_demo_1 form-control">
                                                                                <option value="0"></option>
                                                                                <%--<option value="76">Atletismo</option>--%>
                                                                                <option value="70">Futebol</option>
                                                                                <option value="71">Voley</option>
                                                                                <option value="72">Basquete</option>
                                                                                <option value="73">Esporte de Mesa</option>
                                                                                <option value="74">Surf</option>
                                                                                <option value="75">Skate</option>                                                                                
                                                                                <option value="65">Jiu-Jitsu</option>
                                                                                <option value="66">Boxe</option>
                                                                                <option value="67">Muay-Thai</option>
                                                                                <option value="68">Capoeira</option>
                                                                                <option value="69">Taekwondo</option>
                                                                                <%--<option value="33">Futebol</option>
                                                                                <option value="34">Voley</option>
                                                                                <option value="35">Basquete</option>
                                                                                <option value="36">Esporte de Mesa</option>
                                                                                <option value="37">Surf</option>
                                                                                <option value="38">Skate</option>                                                                                
                                                                                <option value="28">Jiu-Jitsu</option>
                                                                                <option value="29">Boxe</option>
                                                                                <option value="30">Muay-Thai</option>
                                                                                <option value="31">Capoeira</option>
                                                                                <option value="32">Taekwondo</option>--%>
                                                                            </select>
                                                                        </div>

                                                                        <div class="col-md-4">
                                                                            <p>
                                                                                Nível
                                                                            </p>
                                                                            <select required id="cboNivelHabilidadesESPORTE" class="select2_demo_3 form-control">
                                                                                <option></option>
                                                                                <option value="5">1 (Regular)</option>
                                                                                <option value="4">2 (Bom)</option>
                                                                                <option value="6">3 (Excelente)</option>
                                                                                <%--<option value="1">1 (Regular)</option>
                                                                                <option value="2">2 (Bom)</option>
                                                                                <option value="3">3 (Excelente)</option>--%>
                                                                            </select>

                                                                        </div>
                                                                        <div class="col-md-4">
                                                                            <p>
                                                                                &nbsp;
                                                                            </p>
                                                                            <button class="btn btn-primary " onclick="AdicionarHabilidadeProjetoCulturaDanca('ESPORTE')" type="button"><i class="fa fa-check"></i>&nbsp;Adicionar</button>
                                                                            <button id="btnVisualizaHabilidadeEsporte" class="btn btn-success " type="button" data-toggle="modal" data-target="#habilidadesModal" ><i class="fa fa-search"></i>&nbsp;Visualizar</button>                                                                            
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div role="tabpanel" id="tabMidia" class="tab-pane">
                                                <div class="panel-body">
                                                    <div class="row">
                                                        <div class="col-lg-12">

                                                            <div class="ibox">
                                                                <div class="ibox-title">
                                                                    <h5>Adicione as habilidades relacionadas ao Projeto Mídia</h5>
                                                                </div>
                                                                <div class="ibox-content">

                                                                    <div class="row">
                                                                        <div class="col-md-4">
                                                                            <p>
                                                                                Modalidades
                                                                            </p>
                                                                            <select required id="cboHabilidadesMIDIA" class="select2_demo_1 form-control">
                                                                                <option value="0"></option>
                                                                                <option value="40">Fotográfia</option>
                                                                                <option value="41">Jornalismo</option>
                                                                                <option value="42">Marketing</option>
                                                                                <option value="43">Audio Visual</option>
                                                                                <option value="44">Design Gráfico</option>
                                                                                <%--<option value="40">Fotográfia</option>
                                                                                <option value="41">Jornalismo</option>
                                                                                <option value="42">Marketing</option>
                                                                                <option value="43">Audio Visual</option>
                                                                                <option value="44">Design Gráfico</option>--%>
                                                                            </select>
                                                                        </div>

                                                                        <div class="col-md-4">
                                                                            <p>
                                                                                Nível
                                                                            </p> 
                                                                            <select required id="cboNivelHabilidadeMIDIA" class="select2_demo_3 form-control">
                                                                                <option></option>
                                                                                <option value="5">1 (Regular)</option>
                                                                                <option value="4">2 (Bom)</option>
                                                                                <option value="6">3 (Excelente)</option>
                                                                                <%--<option value="1">1 (Regular)</option>
                                                                                <option value="2">2 (Bom)</option>
                                                                                <option value="3">3 (Excelente)</option>--%>
                                                                            </select>

                                                                        </div>
                                                                        <div class="col-md-4">
                                                                            <p>
                                                                                &nbsp;
                                                                            </p>
                                                                            <button class="btn btn-primary " onclick="AdicionarHabilidadeProjetoCulturaDanca('MIDIA')" type="button"><i class="fa fa-check"></i>&nbsp;Adicionar</button>
                                                                            <button id="btnVisualizaHabilidadeMidia" data-toggle="modal" data-target="#habilidadesModal" class="btn btn-success " type="button"><i class="fa fa-search"></i>&nbsp;Visualizar</button>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div role="tabpanel" id="tabUniversitarios" class="tab-pane">
                                                <div class="panel-body">
                                                    <div class="row">
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Qual curso estuda ? </label>
                                                                <input class="form-control" type="text" name="txtNomeCursoFaculdadeJovem" id="txtNomeCursoFaculdadeJovem" >
                                                            </div>
                                                        </div>
                                                        
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Já se formou ? </label>
                                                                <div class="row">
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbJaSeFormou_S" value="s" name="rbJaSeFormou">
                                                                            <label for="rbJaSeFormou_S"> Sim </label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbJaSeFormou_N" value="n" name="rbJaSeFormou">
                                                                            <label for="rbJaSeFormou_N"> Não </label>
                                                                        </div>
                                                                    </div>
                                                                </div>                                                                                                                                
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Qual modalidade está cursando ? </label>
                                                                <div class="row">
                                                                    <div class="col-4">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbModalidadeNivelSuperior_S" value="3" name="rbModalidadeNivelSuperior" >
                                                                            <label for="rbModalidadeNivelSuperior_S"> Presencial </label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-6">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbModalidadeNivelSuperior_N" value="4" name="rbModalidadeNivelSuperior">
                                                                            <label for="rbModalidadeNivelSuperior_N"> Semi-Presencial </label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>                                                        
                                                
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Em qual período está </label>
                                                                <input class="form-control" type="number" min="0" max="100" name="txtPeriodoCursando" id="txtPeriodoCursando" >
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Quando vai se formar </label>
                                                                <input type="text" id="txtPrevisaoFormatura" name="txtPrevisaoFormatura" class="form-control" data-mask="99/9999" placeholder="">
                                                                <span class="form-text">MM/AAAA </span>
                                                            </div>
                                                        </div>
                                                        
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Se ainda não ingressou tem vontade ? </label>
                                                                <div class="row">
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbDesejaCursarNivelSuperior_S" value="S" name="rbDesejaCursarNivelSuperior" >
                                                                            <label for="rbDesejaCursarNivelSuperior_S"> Sim </label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbDesejaCursarNivelSuperior_N" value="N" name="rbDesejaCursarNivelSuperior">
                                                                            <label for="rbDesejaCursarNivelSuperior_N"> Não </label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>                                                        
                                                
                                                    </div>
                                                    
                                                    <div class="clearfix"></div>

                                                    <div class="row">

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Qual curso deseja cursar ? </label>
                                                                <input class="form-control" type="text" name="txtNomeCursoDesejaCursar" id="txtNomeCursoDesejaCursar" >
                                                            </div>
                                                        </div>                                 
                                                
                                                    </div>
                                                </div>
                                            </div>
                                            <div role="tabpanel" id="tabcursosAdicionais" class="tab-pane">
                                                <div class="panel-body">
                                                    <div class="row">
                                                        <div class="col-lg-12">

                                                            <div class="ibox">
                                                                <div class="ibox-title">
                                                                    <h5>Adicione os Cursos/Habilidades adicionais que possúi</h5>
                                                                </div>
                                                                <div class="ibox-content">

                                                                    <div class="row">
                                                                        <div class="col-md-4">
                                                                            <p>
                                                                                Nome do Curso
                                                                            </p>
                                                                            <input class="form-control" type="text" id="txtNomeCursoHabilidadeAdicional" name="txtNomeCursoHabilidadeAdicional" id="txtNomeCursoHabilidadeAdicional" >
                                                                        </div>

                                                                        <div class="col-md-4">
                                                                            <p>
                                                                                Projeto associado ao curso
                                                                            </p>
                                                                            <select id="cboProjetoAssociadoCurso" class="select2_demo_3 form-control" >
                                                                                <option></option>
                                                                                <option value="10">Help</option>
                                                                                <option value="11">Arcanjos</option>
                                                                                <option value="12">Esporte</option>
                                                                                <option value="13">Uniforça</option>
                                                                                <option value="14">Atalaia</option>
                                                                                <option value="15">Universitários</option>
                                                                                <option value="16">Mídia</option>
                                                                                <option value="17">Secretárias</option>
                                                                                <option value="18">Cultura</option>
                                                                                <%--<option value="1">Help</option>
                                                                                <option value="2">Arcanjos</option>
                                                                                <option value="3">Esporte</option>
                                                                                <option value="4">Uniforça</option>
                                                                                <option value="5">Atalaia</option>
                                                                                <option value="6">Universitários</option>
                                                                                <option value="7">Mídia</option>
                                                                                <option value="8">Secretárias</option>
                                                                                <option value="9">Cultura</option>--%>
                                                                            </select>

                                                                        </div>
                                                                        <div class="col-md-4">
                                                                            <p>
                                                                                &nbsp;
                                                                            </p>
                                                                            <button class="btn btn-primary " onclick="AdicionarCursoRelacionadoProjeto()" type="button"><i class="fa fa-check"></i>&nbsp;Adicionar</button>
                                                                            <button id="btnVisualizaCursosAdicionais" data-toggle="modal" data-target="#cursosModal" class="btn btn-success " type="button"><i class="fa fa-search"></i>&nbsp;Visualizar</button>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <!-- begin box hablidades extras -->
                                                            <div class="ibox">
                                                                <div class="ibox-title">
                                                                    <h5>Adicione as Habilidades extras</h5>
                                                                </div>
                                                                <div class="ibox-content">

                                                                    <div class="row">
                                                                        <div class="col-md-4">
                                                                            <p>
                                                                                Nome da Habilidade
                                                                            </p>
                                                                            <input class="form-control" type="text" id="txtNomeHabilidadeExtra" name="txtNomeHabilidadeExtra" >
                                                                        </div>

                                                                        <div class="col-md-4">
                                                                            <p>
                                                                                Projeto associado à Habilidade Extra
                                                                            </p>
                                                                            <select id="cboProjetoAssociadoHabilidadeExtra" class="select2_demo_3 form-control" >
                                                                                <option></option>
                                                                                <option value="10">Help</option>
                                                                                <option value="11">Arcanjos</option>
                                                                                <option value="12">Esporte</option>
                                                                                <option value="13">Uniforça</option>
                                                                                <option value="14">Atalaia</option>
                                                                                <option value="15">Universitários</option>
                                                                                <option value="16">Mídia</option>
                                                                                <option value="17">Secretárias</option>
                                                                                <option value="18">Cultura</option>
                                                                                <%--<option value="1">Help</option>
                                                                                <option value="2">Arcanjos</option>
                                                                                <option value="3">Esporte</option>
                                                                                <option value="4">Uniforça</option>
                                                                                <option value="5">Atalaia</option>
                                                                                <option value="6">Universitários</option>
                                                                                <option value="7">Mídia</option>
                                                                                <option value="8">Secretárias</option>
                                                                                <option value="9">Cultura</option>--%>
                                                                            </select>

                                                                        </div>
                                                                        <div class="col-md-4">
                                                                            <p>
                                                                                &nbsp;
                                                                            </p>
                                                                            <button class="btn btn-primary " onclick="AdicionarHabilidadeProjetoCulturaDanca('EXTRA')" type="button"><i class="fa fa-check"></i>&nbsp;Adicionar</button>
                                                                            <button id="btnVisualizaHabilidadesExtra" data-toggle="modal" data-target="#HabilidadesExtraModal" class="btn btn-success " type="button"><i class="fa fa-search"></i>&nbsp;Visualizar</button>
                                                                        </div>
                                                                    </div>

                                                                    <div class="row">
                                                                        <div class="col-md-4">
                                                                            <p>
                                                                                Nível nesta Habilidade Extra
                                                                            </p>
                                                                            <select required id="cboNivelHabilidadeExtra" class="select2_demo_3 form-control">
                                                                            <option></option>
                                                                                <option value="5">1 (Regular)</option>
                                                                                <option value="4">2 (Bom)</option>
                                                                                <option value="6">3 (Excelente)</option>
                                                                                <%--<option value="1">1 (Regular)</option>
                                                                                <option value="2">2 (Bom)</option>
                                                                                <option value="3">3 (Excelente)</option>--%>
                                                                        </select>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!-- end habilidades extras -->
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div role="tabpanel" id="tabIdiomas" class="tab-pane">
                                                <div class="panel-body">
                                                    <div class="ibox">
                                                        <div class="ibox-title">
                                                            <h5>Adicione os Idiomas</h5>
                                                        </div>
                                                        <div class="ibox-content">

                                                            <div class="row">
                                                                <div class="col-md-4">
                                                                    <p>
                                                                        Idiomas
                                                                    </p>
                                                                    <select required id="cboIdiomas" class="select2_demo_1 form-control">
                                                                        <option value="0"></option>
                                                                        <option value="6">Português</option>
                                                                        <option value="7">Inglês</option>
                                                                        <option value="9">Espanhol</option>
                                                                        <option value="17">Frânces</option>
                                                                        <option value="8">Italiano</option>
                                                                        <option value="11">Japonês</option>
                                                                        <%--<option value="28">Hebraico</option>--%>
                                                                        <%--<option value="8">Português</option>
                                                                        <option value="1">Inglês</option>
                                                                        <option value="3">Espanhol</option>
                                                                        <option value="2">Frânces</option>
                                                                        <option value="4">Italiano</option>
                                                                        <option value="5">Japonês</option>--%>
                                                                    </select>
                                                                </div>

                                                                <div class="col-md-4">
                                                                    <p>
                                                                        Nível
                                                                    </p>
                                                                    <select required id="cboNivelIdioma" class="select2_demo_3 form-control">
                                                                        <option></option>
                                                                        <option value="5">1 (Regular)</option>
                                                                        <option value="4">2 (Bom)</option>
                                                                        <option value="6">3 (Excelente)</option>
                                                                        <%--<option value="1">1 (Regular)</option>
                                                                        <option value="2">2 (Bom)</option>
                                                                        <option value="3">3 (Excelente)</option>--%>
                                                                    </select>

                                                                </div>
                                                                <div class="col-md-4">
                                                                    <p>
                                                                        &nbsp;
                                                                    </p>
                                                                    <button class="btn btn-primary " onclick="AdicionarIdioma('JaCadastrado')" type="button"><i class="fa fa-check"></i>&nbsp;Adicionar</button>
                                                                    <button id="btnVisualizaIdiomasAdicionados" data-toggle="modal" data-target="#idiomasModal" class="btn btn-success " type="button"><i class="fa fa-search"></i>&nbsp;Visualizar</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <!--demarca-->


                                                    <!-- begin box idioma extras -->
                                                    <div class="ibox">
                                                        <div class="ibox-title">
                                                            <h5>Jovem fala algum idioma que não está na lista, adicione</h5>
                                                        </div>
                                                        <div class="ibox-content">

                                                            <div class="row">
                                                                <div class="col-md-4">
                                                                    <p>
                                                                        Nome do Idioma
                                                                    </p>
                                                                    <input class="form-control" type="text" id="txtNomeIdiomaExtra" name="txtNomeIdiomaExtra" >
                                                                </div>

                                                                <div class="col-md-4">
                                                                    <p>
                                                                        Nível do Idioma Extra
                                                                    </p>
                                                                    <select required id="cboNivelIdiomaExtra" class="select2_demo_3 form-control">
                                                                        <option></option>
                                                                        <option value="5">1 (Regular)</option>
                                                                        <option value="4">2 (Bom)</option>
                                                                        <option value="6">3 (Excelente)</option>
                                                                        <%--<option value="1">1 (Regular)</option>
                                                                        <option value="2">2 (Bom)</option>
                                                                        <option value="3">3 (Excelente)</option>--%>
                                                                    </select>

                                                                </div>
                                                                <div class="col-md-4">
                                                                    <p>
                                                                        &nbsp;
                                                                    </p>
                                                                    <button class="btn btn-primary " onclick="AdicionarIdioma('Extra')" type="button"><i class="fa fa-check"></i>&nbsp;Adicionar</button>
                                                                    <button id="btnVisualizaIdiomaExtra" data-toggle="modal" data-target="#idiomasModal" class="btn btn-success " type="button"><i class="fa fa-search"></i>&nbsp;Visualizar</button>
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>
                                                    <!-- end habilidades extras -->


                                                    <!--fim demarcação-->
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <!-- modal fora da tab para testar se é enxergada gglobalmente -->
                                    <div class="modal inmodal" id="habilidadesModal" tabindex="-1" role="dialog" aria-hidden="true">
                                        <div class="modal-dialog">
                                        <div class="modal-content animated bounceInRight">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                                                    <i class="fa fa-laptop modal-icon"></i>
                                                    <h4 class="modal-title">Habilidades Adicionadas</h4>
                                                    <small class="font-bold">Lista de modalidades adicionadas</small>
                                                </div>
                                                <div class="modal-body">
                                                    <!---->
                                                    <div class="table-wrapper">
                                                        <div class="table-title">
                                                            <div class="row">
                                                                <div class="col-sm-8"><h2>Habilidades <b>Detalhes</b></h2></div>
                                                            </div>
                                                        </div>
                                                        <table class="table table-bordered" id="tblHabilidades">
                                                            <thead>
                                                                <tr>
                                                                    <th>Habilidade</th>
                                                                    <th>Projeto</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <%--<tr>
                                                                    <td>Habilidade</td>
                                                                    <td>Cutura</td>
                                                                    <td>
                                                                        <a class="delete" title="Delete" data-toggle="tooltip"><i class="material-icons">&#xE872;</i></a>
                                                                    </td>
                                                                </tr>--%>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                    <!---->
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-white" data-dismiss="modal">Fechar</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!---->
                                    <div class="modal inmodal" id="cursosModal" tabindex="-1" role="dialog" aria-hidden="true">
                                        <div class="modal-dialog">
                                        <div class="modal-content animated bounceInRight">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                                                    <i class="fa fa-laptop modal-icon"></i>
                                                    <h4 class="modal-title">Cursos Adicionados</h4>
                                                    <small class="font-bold">Lista de cursos adicionados</small>
                                                </div>
                                                <div class="modal-body">
                                                    <!---->
                                                    <div class="table-wrapper">
                                                        <div class="table-title">
                                                            <div class="row">
                                                                <div class="col-sm-8"><h2>Cursos <b>Detalhes</b></h2></div>
                                                            </div>
                                                        </div>
                                                        <table class="table table-bordered" id="tblCursos">
                                                            <thead>
                                                                <tr>
                                                                    <th>Nome do Curso</th>
                                                                    <th>Projeto Relacionado</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                    <!---->
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-white" data-dismiss="modal">Fechar</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- modal abaixo HabilidadesExtraModal -->
                                    <div class="modal inmodal" id="HabilidadesExtraModal" tabindex="-1" role="dialog" aria-hidden="true">
                                        <div class="modal-dialog">
                                        <div class="modal-content animated bounceInRight">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                                                    <i class="fa fa-laptop modal-icon"></i>
                                                    <h4 class="modal-title">Habilidades Extras</h4>
                                                    <small class="font-bold">Lista de Habilidades extras</small>
                                                </div>
                                                <div class="modal-body">
                                                    <!---->
                                                    <div class="table-wrapper">
                                                        <div class="table-title">
                                                            <div class="row">
                                                                <div class="col-sm-8"><h2>Habilidades Extras <b>Detalhes</b></h2></div>
                                                            </div>
                                                        </div>
                                                        <table class="table table-bordered" id="tblHabilidadesExtras">
                                                            <thead>
                                                                <tr>
                                                                    <th>Nome da Habilidade Extra</th>
                                                                    <th>Projeto Relacionado</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                    <!---->
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-white" data-dismiss="modal">Fechar</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!---->
                                    <div class="modal inmodal" id="idiomasModal" tabindex="-1" role="dialog" aria-hidden="true">
                                        <div class="modal-dialog">
                                        <div class="modal-content animated bounceInRight">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                                                    <i class="fa fa-laptop modal-icon"></i>
                                                    <h4 class="modal-title">Idiomas Adicionados</h4>
                                                    <small class="font-bold">Lista de idiomas adicionadas</small>
                                                </div>
                                                <div class="modal-body">
                                                    <div class="table-wrapper">
                                                        <div class="table-title">
                                                            <div class="row">
                                                                <div class="col-sm-8"><h2>Idiomas <b>Detalhes</b></h2></div>
                                                            </div>
                                                        </div>
                                                        <table class="table table-bordered" id="tblIdiomas">
                                                            <thead>
                                                                <tr>
                                                                    <th>Idioma</th>
                                                                    <th>Nível</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-white" data-dismiss="modal">Fechar</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!---->
                                </fieldset>

                                <h1>Finish</h1>
                                <fieldset>
                                    <div class="tabs-container">
                                        <ul class="nav nav-tabs" role="tablist">
                                            <li><a class="nav-link active" data-toggle="tab" href="#tabDetalhes"> Detalhes</a></li>
                                            <li><a class="nav-link" data-toggle="tab" href="#tabTestemunho">Resumo</a></li>
                                            <li><a class="nav-link" data-toggle="tab" href="#tabSugestao">Sugestões para o trabalho da FJU</a></li>
                                        </ul>
                                        <div class="tab-content">
                                            <div role="tabpanel" id="tabDetalhes" class="tab-pane active">
                                                <div class="panel-body">
                                                    <div class="row">
                                                    <!--  -->
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Já sofreu com depressão ? </label>
                                                            <div class="row">
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger radio-inline">
                                                                        <input type="radio" id="rbJaSofreuDepressao_S" value="S" name="rbJaSofreuDepressao" >
                                                                        <label for="rbJaSofreuDepressao_S"> Sim </label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-2">
                                                                    <div class="radio radio-danger radio-inline">
                                                                        <input type="radio" id="rbJaSofreuDepressao_N" value="N" name="rbJaSofreuDepressao">
                                                                        <label for="rbJaSofreuDepressao_N"> Não </label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                        
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Por quanto tempo ? </label>
                                                            <input id="txtTempoSofreuDepressao" type="text" name="txtTempoSofreuDepressao" class="form-control"  >
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <label for="form_name">Está livre desde? </label>
                                                            <input id="txtTempoLivreDepressao" type="text" name="txtTempoLivreDepressao" class="form-control" >
                                                            <div class="help-block with-errors"></div>
                                                        </div>
                                                    </div>
                                                    <!--  -->
                                                </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!--  -->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Já sofreu com Automutilação ? </label>
                                                                <div class="row">
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbJaSofreuAutomutilacao_S" value="S" name="rbJaSofreuAutomutilacao" >
                                                                            <label for="rbJaSofreuAutomutilacao_S"> Sim </label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbJaSofreuAutomutilacao_N" value="N" name="rbJaSofreuAutomutilacao">
                                                                            <label for="rbJaSofreuAutomutilacao_N"> Não </label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Por quanto tempo ? </label>
                                                                <input id="txtTempoSofreuAutomutilacao" type="text" name="txtTempoSofreuAutomutilacao" class="form-control" >
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Está livre desde? </label>
                                                                <input id="txtTempoLivreAutomutilacao" type="text" name="txtTempoLivreAutomutilacao" class="form-control" >
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>
                                                        <!--  -->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!--  -->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Já teve algum vício ? </label>
                                                                <div class="row">
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbJaTeveVicio_S" value="S" name="rbJaTeveVicio" >
                                                                            <label for="rbJaTeveVicio_S"> Sim </label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbJaTeveVicio_N" value="N" name="rbJaTeveVicio">
                                                                            <label for="rbJaTeveVicio_N"> Não </label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Qual vício? </label>
                                                                <input id="txtNomeVicio" type="text" name="txtNomeVicio" class="form-control" >
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Por quanto tempo permaneceu viciado ? </label>
                                                                <input id="txtTempoVicio" type="text" name="txtTempoVicio" class="form-control" >
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>
                                                        <!--  -->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Está livre dos vícios há quanto tempo ? </label>
                                                                <input id="txtTempoLivreVicios" type="text" name="txtTempoLivreVicios" class="form-control" >
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Já tentou suicídio alguma vez ? </label>
                                                                <div class="row">
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbJaTentouSuicidio_S" value="S" name="rbJaTentouSuicidio" >
                                                                            <label for="rbJaTentouSuicidio_S"> Sim </label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-2">
                                                                        <div class="radio radio-danger radio-inline">
                                                                            <input type="radio" id="rbJaTentouSuicidio_N" value="N" name="rbJaTentouSuicidio">
                                                                            <label for="rbJaTentouSuicidio_N"> Não </label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Quantas vezes ? </label>
                                                                <input id="txtNumeroTentativasSuicidio" type="number" name="txtNumeroTentativasSuicidio" min="0" max="50" class="form-control" >                                                                
                                                            </div>
                                                        </div>
                                                        <!---->
                                                    </div>

                                                    <div class="clearfix"></div>

                                                    <div class="row">
                                                        <!---->
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Quando foi a tentativa ? </label>
                                                                <input id="txtQuandoTentouSuicidio" type="text" name="txtQuandoTentouSuicidio" class="form-control" >
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                <label for="form_name">Como foi a tentativa ? </label>
                                                                <input id="txtDescricaoTentativaSuicidio" type="text" name="txtDescricaoTentativaSuicidio" class="form-control" >
                                                                <div class="help-block with-errors"></div>
                                                            </div>
                                                        </div>
                                                        <!---->
                                                    </div>
                                                </div>
                                            </div>
                                            <div role="tabpanel" id="tabTestemunho" class="tab-pane">
                                                <div class="panel-body">                                                                                                                                                              
                                                        <%--<div id="txtTestemunho" class="summernote">                                                                    
                                                        </div>
                                                        <textarea id="txtTestemunho" visible="false" runat="server"></textarea> --%>
                                                    <i class="fas fa-pencil-alt prefix"></i>
                                                    <textarea id="txtTestemunho" runat="server" class="md-textarea form-control" rows="3"></textarea>
                                                    <label for="txtTestemunho">Escreva testemunho do Jovem</label>
                                                </div>
                                            </div>
                                            <div role="tabpanel" id="tabSugestao" runat="server" class="tab-pane">
                                                <div class="panel-body">
                                                    <i class="fas fa-pencil-alt prefix"></i>
                                                    <textarea id="txtSugestao" runat="server" class="md-textarea form-control" rows="3"></textarea>
                                                    <label for="txtSugestao">Escreva a sugestão do Jovem</label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>

                                <%--<h1></h1>
                                <fieldset>
                                    <div class="row">
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_name">Quem autorizou a compra? </label>
                                                <input id="txtNomeAutorizadorCompraCamisa" type="text" name="txtNomeAutorizadorCompraCamisa" class="form-control" >
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>

                                        <div class="col-sm-2">
                                            <div class="form-group">
                                                <label class="font-normal">Data da Autorização</label>
                                                <div class="input-group date">
                                                    <input type="date" name="txtDataAutorizacaoCompraCamisa" class="form-control" >
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-6">
                                            <div class="form-group">
                                                <label for="form_name">Local onde compra da camisa será realizada? </label>
                                                <div class="row">
                                                    <div class="col-4">
                                                        <div class="radio radio-danger radio-inline">
                                                            <input type="radio" id="rbOrigemCompraCamisa_S" value="S" name="rbOrigemCompraCamisa" >
                                                            <label for="rbOrigemCompraCamisa_S"> Souvenir do Tempo </label>
                                                        </div>
                                                    </div>
                                                    <div class="col-4">
                                                        <div class="radio radio-danger radio-inline">
                                                            <input type="radio" id="rbOrigemCompraCamisa_A" value="A" name="rbOrigemCompraCamisa">
                                                            <label for="rbOrigemCompraCamisa_A"> Arcacenter </label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="font-normal">Código da Autorização</label>
                                                <div class="input-group date">
                                                    <input type="text" id="txtCodigoAutorizacaoCompraCamisa" name="txtCodigoAutorizacaoCompraCamisa" class="form-control" disabled >
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </fieldset>--%>
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
        var facadeUser = new SGFJU.Domain.Model.UI.Client.Facade.UsuarioFacade();
        var HOST_NAME_APP = document.location.hostname;
        var __HOST_LOCAL = 'https://' + window.location.hostname + ':' + window.location.port + '/FotosJovens/';
        var __HOST_PRODUCAO = 'http://' + window.location.hostname + '/SGFJU2.0/FotosJovens/';
        var __URL_FOTO_ALTERACAO = '';
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
                    confirm: {
                        equalTo: "#password"
                    },
                    txtDataCasamento: {
                        date: true,
                        required: false
                    }
                }
            });

            
            $("#cboEstado").select2();
            $("#cboBloco").select2();
            $("#cboRegiao").select2();
            $("#cboIgreja").select2();

            facadeUser.ConfigurarPaginaX072470();

            PreencherFormularioParaAtualizacao();

            $('#habilidadesModal').on('shown.bs.modal', function (e) {

                $.ajax({
                    type: "GET",
                    url: "api/HabilidadesAtualizacao/TodasAdicionadasPorProjeto/9",
                    contentType: "application/json"
                }).done(function (retorno) {
                    $.each(retorno, function () {
                        var index = $("table tbody tr:last-child").index() + 1;
                        var row = '<tr>' +
                            '<td>' + this.NomeHabilidade + '</td>' +
                            '<td>' + this.NomeProjeto + '</td>' +
                            //'<td><a onclick="excluirHabilidadeProjeto(' + this.IdHabilidade + ')" class="delete" title="Delete" data-toggle="tooltip"><i class="fa-minus">&#xE872;</i></a></td>' +
                            '<td><a onclick="excluirHabilidadeProjeto(' + this.IdHabilidade + ')" class="delete dt-delete" > <span class="glyphicon glyphicon-remove glyphicon-trash" aria-hidden="true"></span></a></td>' +                            
                            '</tr>';
                        $("#tblHabilidades").append(row);
                    });
                });
            });

            $('#habilidadesModal').on('hide.bs.modal', function (e) {
                $('#habilidadesModal tr').remove();
            });

            $('#idiomasModal').on('shown.bs.modal', function () {
                $.ajax({
                    type: "GET",
                    url: "api/IdiomasAtualizacao/TodosIdiomasJaAdicionados",
                    contentType: "application/json"
                }).done(function (retorno) {
                    $.each(retorno, function () {
                        var index = $("#tblIdiomas tbody tr:last-child").index();
                        var row = '<tr>' +
                            '<td>' + this.DescricaoIdioma + '</td>' +
                            '<td>' + this.DescricaoNivel + '</td>' +
                            '<td><a onclick="excluirIdioma(' + this.CodigoIdioma + ')" class="delete dt-delete" > <span class="glyphicon glyphicon-remove glyphicon-trash" aria-hidden="true"></span></a></td>' +
                            '</tr>';
                        $("#tblIdiomas").append(row);
                    });
                });
            });

            $('#idiomasModal').on('hide.bs.modal', function (e) {
                $('#tblIdiomas tr').remove();
            });

            $(document).on("click", ".delete", function () {
                $(this).parents("tr").remove();
            });

            $('#cursosModal').on('shown.bs.modal', function (e) {
                $.ajax({
                    type: "GET",
                    url: "api/CursosAtualizacao/TodosCursosJaAdicionados",
                    contentType: "application/json"
                }).done(function (retorno) {
                    $.each(retorno, function () {
                        var index = $("#TodosCursosJaAdicionados tbody tr:last-child").index();
                        var row = '<tr>' +
                            '<td>' + this.NomeCurso + '</td>' +
                            '<td>' + this.NomeProjeto + '</td>' +
                            '<td><a onclick="excluirCurso(\'' + this.NomeCurso + '\')" class="delete dt-delete" > <span class="glyphicon glyphicon-remove glyphicon-trash" aria-hidden="true"></span></a></td>' +
                            //'<td><a onclick="excluirCurso(\'' + this.NomeCurso + '\')" class="btn btn-danger btn-xs dt-delete"><span class="glyphicon glyphicon-remove glyphicon-trash" aria-hidden="true"></span></a></td>' +
                            //'<td><div class="btn-group"><button type="button" onclick="excluirCurso(\'' + this.NomeCurso + '\')" class="btn btn-danger btn-xs dt-delete"><span class="glyphicon glyphicon-remove glyphicon-trash" aria-hidden="true"></span></button></div></td>'
                            '</tr>';
                        $("#tblCursos").append(row);
                    });
                });
            });

            $('#cursosModal').on('hide.bs.modal', function (e) {
                $('#tblCursos tr').remove();
            });

            $('#HabilidadesExtraModal').on('shown.bs.modal', function () {
                $.ajax({
                    type: "GET",
                    url: "api/HabilidadesAtualizacao/TodosHabilidadesExtrasJaAdicionados",
                    contentType: "application/json"
                }).done(function (retorno) {
                    $.each(retorno, function () {
                        var index = $("#tblHabilidadesExtras tbody tr:last-child").index();
                        var row = '<tr>' +
                            '<td>' + this.NomeHabilidade + '</td>' +
                            '<td>' + this.NomeProjeto + '</td>' +
                            '<td><a onclick="excluirHabilidadeExtraProjeto(\'' + this.NomeHabilidade + '\')" class="delete dt-delete" > <span class="glyphicon glyphicon-remove glyphicon-trash" aria-hidden="true"></span></a></td>' +
                            '</tr>';
                        $("#tblHabilidadesExtras").append(row);
                    });
                });
            });

            $('#HabilidadesExtraModal').on('hide.bs.modal', function (e) {
                $('#tblHabilidadesExtras tr').remove();
            });

            $('#fotoJovemModal').on('hide.bs.modal', function () {
                var arquivoFotoJovem = $('#FileUpload1').val()
                var file = $('#FileUpload1');
                var tamanhoDoArquivo = file[0].files[0].size;
                var TAMANHO_MAXIMO = 307200;

                console.log(':: Tamanho do arquivo -> ' + tamanhoDoArquivo);

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
                /*
                var arquivoFotoJovem = $('#FileUpload1').val()
                if (arquivoFotoJovem != '')
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
                    });*/
            });

            
            $('#VisualizaFotoJovemAlteracao').on('shown.bs.modal', function () {
                console.log('ao abrir modal '+__URL_FOTO_ALTERACAO);
                configuraFotoJovemAlteracao(__URL_FOTO_ALTERACAO);
            });
            
        });        

        function PreencherFormularioParaAtualizacao() {
            var url_ = new URL(location.href);
            var vIdJovem = url_.searchParams.get("idJovem");
            var jovemDTO = {
                IdJovem: vIdJovem
            };
            
            $.ajax({
                type: "POST",
                data: JSON.stringify(jovemDTO),
                url: "api/Jovens/ObterJovemAtualizacao",
                contentType: "application/json"
            }).done(function (jovemRetorno) {

                $('#lnkLinkVisualizarFicha').prop('href', 'VisualizaJovemE.html?idJovem=' + vIdJovem);

                $('#cboEstado').val(jovemRetorno.IgrejaAQualJovemPertence.IdEstado).trigger('change.select2');
                $('#cboEstado').prop("disabled", true);

                var dataBloco = {
                    id: jovemRetorno.IgrejaAQualJovemPertence.IdBlocoJovem,
                    text: jovemRetorno.IgrejaAQualJovemPertence.NomeBlocoJovem
                };
                var blocoOption = new Option(dataBloco.text, dataBloco.id, false, false);
                $('#cboBloco').append(blocoOption).trigger('change');
                $('#cboBloco').val(jovemRetorno.IgrejaAQualJovemPertence.IdBlocoJovem).trigger('change.select2');
                $('#cboBloco').prop("disabled", true);

                var dataRegiao = {
                    id: jovemRetorno.IgrejaAQualJovemPertence.IdRegiao,
                    text: jovemRetorno.IgrejaAQualJovemPertence.NomeRegiaoJovem
                };
                var regiaoOption = new Option(dataRegiao.text, dataRegiao.id, false, false);
                $('#cboRegiao').append(regiaoOption).trigger('change');
                $('#cboRegiao').val(jovemRetorno.IgrejaAQualJovemPertence.IdRegiao).trigger('change.select2');
                $('#cboRegiao').prop("disabled", true);

                var data = {
                    id: jovemRetorno.IgrejaAQualJovemPertence.IdIgreja,
                    text: jovemRetorno.IgrejaAQualJovemPertence.NomeIgreja
                };
                var igrejaJovemOption = new Option(data.text, data.id, false, false);
                $('#cboIgreja').append(igrejaJovemOption).trigger('change');
                $('#cboIgreja').val(jovemRetorno.IgrejaAQualJovemPertence.IdIgreja).trigger('change.select2');
                $("#cboIgreja").prop("disabled", true);

                $('#lblNomeJovemEmAlteracao').text('Dados referentes ao jovem: '+ jovemRetorno.Nome);
                $('#txtNome').val(jovemRetorno.Nome);

                $('#cboClassificacaoJovem').val(jovemRetorno.ClassificacaoJovem).trigger('change.select2');

                console.log(HOST_NAME_APP);
                if (HOST_NAME_APP.indexOf('localhost') !== -1) {
                    __URL_FOTO_ALTERACAO = __HOST_LOCAL + jovemRetorno.NomeArquivoFoto;
                    console.log(__URL_FOTO_ALTERACAO);
                }
                else {
                    if (jovemRetorno.NomeArquivoFoto == '')
                        __URL_FOTO_ALTERACAO = __HOST_PRODUCAO + 'jovemsemfoto.jpg';
                    else
                        __URL_FOTO_ALTERACAO = __HOST_PRODUCAO + jovemRetorno.NomeArquivoFoto;
                }

                ///$('#txtDataCasamento').val(jovemRetorno.DataCasamento);
                console.log('::DAta Casamentos'+ jovemRetorno.DataCasamento);

                $('#txtDataNascimento').val(jovemRetorno.DataNascimento);
                $('#txtDataNascimento').prop('disabled', true);

                $('#txtDataCasamento').val(jovemRetorno.DataCasamento);
                $('#txtDataCasamento').prop('disabled', true);

                $('#txtHiddenDataNascimento').val(jovemRetorno.DataNascimento);

                $('#txtDatanascimentoAnterior').val(jovemRetorno.DataNascimento);
                $('#txtDatanascimentoAnterior').prop('disabled', true);

                $('#txtDataPreenchimentoFormularioAnterior').val(jovemRetorno.DataPreenchimentoFormulario);
                $('#txtDataPreenchimentoFormularioAnterior').prop('disabled', true);

                $('#txtDataPreenchimentoFormulario').val(jovemRetorno.DataPreenchimentoFormulario);
                $('#txtDataPreenchimentoFormulario').prop('disabled', true);

                $('#txtHiddenDataPreenchimentoFormulario').val(jovemRetorno.DataPreenchimentoFormulario);

                /* contato */
                $('#txtWhatsapp').val(jovemRetorno.ContatoJovem.Whatsapp);
                $('#txtTelefoneFixo').val(jovemRetorno.ContatoJovem.TelefoneFixo);
                $('#txtTelefoneEmergencia').val(jovemRetorno.ContatoJovem.TelefoneEmergencia);
                $('#txtContatoEmergencia').val(jovemRetorno.ContatoJovem.NomeContatoEmergencia);
                console.log(jovemRetorno.ContatoJovem.TelefoneEmergencia);


                if (jovemRetorno.EhAltarJovem318 != '' &&
                    jovemRetorno.EhAltarJovem318 == 'S')
                    $('#chkAltarJovem318').prop('checked', true);

                $('#txtCodigoAltarJovem318').val(jovemRetorno.CodigoAltarJovem318);
                /**/
                //||CodigoAutorizacaoCompraCamisa
                /*
                $('#txtDataAutorizacaoCompraCamisa').val(jovemRetorno.DataAutorizacaoCompraCamisa);
                $('#txtDataAutorizacaoCompraCamisa').prop('disabled', true);

                $('#NomeAutorizadorCompraCamisa').val(jovemRetorno.NomeAutorizadorCompraCamisa);
                $('#NomeAutorizadorCompraCamisa').prop('disabled', true);

                $('#CodigoAutorizacaoCompraCamisa').val(jovemRetorno.CodigoAutorizacaoCompraCamisa);
                $('#CodigoAutorizacaoCompraCamisa').prop('disabled', true);

                if (jovemRetorno.OrigemCompraCamisa == 'A')
                    $('#rbOrigemCompraCamisa_A').prop('checked', true);
                else
                    $('#rbOrigemCompraCamisa_S').prop('checked', false);
                */
                /**/

                /* endereço*/
                $('#txtEndereco').val(jovemRetorno.EnderecoJovem.DescricaoEndereco);
                $('#txtBairro').val(jovemRetorno.EnderecoJovem.Bairro);
                $('#txtCidade').val(jovemRetorno.EnderecoJovem.Cidade);
                $('#cboTipoMoradia').val(jovemRetorno.EnderecoJovem.idTipoDeMoradia).trigger('change.select2');

            /* redes sociais */
                 
                $('#txtInstagram').val(jovemRetorno.RedeSocialJovem.Instagram);
                $('#txtFacebook').val(jovemRetorno.RedeSocialJovem.Facebook);
                $('#txtEmail').val(jovemRetorno.RedeSocialJovem.Email);
                $('#txtTwitter').val(jovemRetorno.RedeSocialJovem.Twitter);
                $('#txtFrequenciaAssisteUniver').val(jovemRetorno.RedeSocialJovem.FrequenciaAssisteUNIVER).trigger('change.select2');

                if (jovemRetorno.RedeSocialJovem.EhSeguidorOficialFJU == 'S')
                    $('#rbEhSeguidorOFICIALFJURadio_S').prop('checked', true);
                else
                    $('#rbEhSeguidorOFICIALFJURadio_N').prop('checked', true);    
                
                if (jovemRetorno.RedeSocialJovem.EhSeguidorYoutube == 'S')
                    $('#rbEhSeguidorFJUYouTube_S').prop('checked', true);
                else
                    $('#rbEhSeguidorFJUYouTube_N').prop('checked', true);

                if (jovemRetorno.RedeSocialJovem.EhSeguidorTelegram == 'S')
                    $('#rbSegueFJUTelegram_S').prop('checked', true);
                else
                    $('#rbSegueFJUTelegram_N').prop('checked', true);

                if (jovemRetorno.RedeSocialJovem.EhAssinanteUNIVER == 'S')
                    $('#rbAssinanteUNIVERVIDEO_S').prop('checked', true);
                else
                    $('#rbAssinanteUNIVERVIDEO_N').prop('checked', true);
                
                if (jovemRetorno.RedeSocialJovem.EhLeitorBlogBM == 'S')
                    $('#rbLeDiariamenteBlogBM_S').prop('checked', true); 
                else
                $('#rbLeDiariamenteBlogBM_N').prop('checked', true);

                if (jovemRetorno.RedeSocialJovem.EhLeitorUniversalorg == 'S')
                    $('#rbLeitorSiteUniversalOrg_S').prop('checked', true); 
                else
                    $('#rbLeitorSiteUniversalOrg_N').prop('checked', true);

                if (jovemRetorno.RedeSocialJovem.PossuiCelularComInternet == 'S')
                    $('#rbTemCelularComInternet_S').prop('checked', true); 
                else
                    $('#rbTemCelularComInternet_N').prop('checked', true);

                if (jovemRetorno.RedeSocialJovem.PossuiComputador == 'S')
                    $('#rbTemComputadorEmCasa_S').prop('checked', true);
                else
                    $('#rbTemComputadorEmCasa_N').prop('checked', true); 
                


            /* Aba complementares */
            /* informações civis */
                $('#cboTipoEstadoCivil').val(jovemRetorno.idEstadoCivilJovem).trigger('change.select2');
                $('#cboSexo').val(jovemRetorno.Sexo).trigger('chage.select2');
                $('#txtNomeconjuge').val(jovemRetorno.NomeConjuge);
                $('#txtQtdFilhos').val(jovemRetorno.QuantidadeFilhos);

                console.log(':::--->>> Será que possui filhos?!? ' + jovemRetorno.PossuiFilhos);
                if (jovemRetorno.PossuiFilhos == 's' || jovemRetorno.PossuiFilhos == 'S')
                    $('#rbPossuiFilhos_S').prop('checked', true);
                else
                    $('#rbPossuiFilhos_N').prop('checked', true);
                 
                if (jovemRetorno.ConjugeEhIURD != '') {
                    if (jovemRetorno.ConjugeEhIURD == 'S')
                        $('#rbConjugeEhIURD_S').prop('checked', true);
                    else
                        $('#rbConjugeEhIURD_N').prop('checked', true);
                }

            /* informações profissionais */
                $('#txtEmpresa').val(jovemRetorno.DadosProfissionaisJovem.NomeEmpresa);
                $('#txtProfissao').val(jovemRetorno.DadosProfissionaisJovem.Profissao);
                $('#txtInstituicaoOndeEstuda').val(jovemRetorno.DadosEducacionaisJovem.NomeInstituicaoEnsino);
                $('#escolaridade').val(jovemRetorno.DadosEducacionaisJovem.GrauEscolaridade);

                if (jovemRetorno.DadosProfissionaisJovem.TrabalhaAtualmente == 'S')
                    $('#rbTrabalha_S').prop('checked', true);
                else
                    $('#rbTrabalha_N').prop('checked', true);

                if (jovemRetorno.DadosEducacionaisJovem.EstudaAtualmente == 'S')
                    $('#rbEstuda_S').prop('checked', true);
                else
                    $('#rbEstuda_N').prop('checked', true);

                if (jovemRetorno.PossuiTituloEleitor == 'S')
                    $('#rbPossuiTituloeleitor_S').prop('checked', true);
                else
                    $('#rbPossuiTituloeleitor_N').prop('checked', true);

            /* Espiritual */
            /* aba informações espirituais */
                var mesChegadaIURD = (jovemRetorno.DadosEspirituaisJovem.MesChegadaiurd < 10) ? '0' + jovemRetorno.DadosEspirituaisJovem.MesChegadaiurd : jovemRetorno.DadosEspirituaisJovem.MesChegadaiurd;
                console.log('cheguei no mês..'+mesChegadaIURD);
                $('#txtMesAnoChegadaIURD').val(mesChegadaIURD + '/' + jovemRetorno.DadosEspirituaisJovem.AnoChegadaiurd);
                $('#txtComoConheceuIURD').val(jovemRetorno.DadosEspirituaisJovem.ComoConheceuIURD);
                $('#txtMotivoAfastamento').val(jovemRetorno.DadosEspirituaisJovem.MotivoSeAfastou);
                $('#txtMesAnoAfastou').val(jovemRetorno.DadosEspirituaisJovem.MesAnoAfastamento);
                $('#txtPorQuantoTempoSeAfastou').val(jovemRetorno.DadosEspirituaisJovem.TempoAfastamento);
                $('#txtDesdeQuandoFirme').val(jovemRetorno.DadosEspirituaisJovem.TempoEstaFirme);
                $('#txtFamiliaresIURD').val(jovemRetorno.DadosEspirituaisJovem.DescricaoFamiliaresIURD);

                if (jovemRetorno.DadosEspirituaisJovem.EhMembroIURD != '') {
                    if (jovemRetorno.DadosEspirituaisJovem.EhMembroIURD == 'S')
                        $('#rbEhMembroIURD_S').prop('checked', true);
                    else
                        $('#rbEhMembroIURD_N').prop('checked', true);
                }

                if (jovemRetorno.DadosEspirituaisJovem.JaSeAfastou != '') {
                    if (jovemRetorno.DadosEspirituaisJovem.JaSeAfastou == 'S')
                        $('#rbJaSeAfastou_S').prop('checked', true);
                    else
                        $('#rbJaSeAfastou_N').prop('checked', true);
                }

                if (jovemRetorno.DadosEspirituaisJovem.TemFamiliaresIURD != '') {
                    if (jovemRetorno.DadosEspirituaisJovem.TemFamiliaresIURD == 's')
                        $('#rbTemFamiliaresIURD_S').prop('checked', true);
                    else
                        $('#rbTemFamiliaresIURD_N').prop('checked', true);
                }

            /* aba batismo */
                $('#txtQuandoSeBatizouAguas').val(jovemRetorno.DadosEspirituaisJovem.MesAnoBatismoAguas);
                $('#txtQuandoSeBatizadoES').val(jovemRetorno.DadosEspirituaisJovem.MesAnoBatismoEspiritoSanto);
                $('#txtOndeBatismoEspiritoSanto').val(jovemRetorno.DadosEspirituaisJovem.OcasiaoBatismoEspiritoSanto);
                $('#txtComoConheceuFJU').val(jovemRetorno.DadosEspirituaisJovem.DescricaoModoChegouFJU);
                $('#txtQuandoEntrouFJU').val(jovemRetorno.DadosEspirituaisJovem.MesAnoEntradaFJU);
                $('#txtMotivoEntrouFJU').val(jovemRetorno.DadosEspirituaisJovem.MotivoEntradaFJU);

                 
                if (jovemRetorno.DadosEspirituaisJovem.EhBatizadoAguas != '') {
                    if (jovemRetorno.DadosEspirituaisJovem.EhBatizadoAguas == 'S')
                        $('#rbBatizadoAguas_S').prop('checked', true);
                    else
                        $('#rbBatizadoAguas_N').prop('checked', true);
                }

                if (jovemRetorno.DadosEspirituaisJovem.BatismoAguasIURD != '') {
                    if (jovemRetorno.DadosEspirituaisJovem.BatismoAguasIURD == 'S')
                        $('#rbBatismoAguasNaIURD_S').prop('checked', true);
                    else
                        $('#rbBatismoAguasNaIURD_N').prop('checked', true);
                }

                if (jovemRetorno.DadosEspirituaisJovem.EhBatizadoEspiritoSanto != '') {
                    if (jovemRetorno.DadosEspirituaisJovem.EhBatizadoEspiritoSanto == 'S')
                        $('#rbBatizadoEspiritoSanto_S').prop('checked', true);
                    else
                        $('#rbBatizadoEspiritoSanto_N').prop('checked', true);
                }


            /* aba complemento */
                $('#txtNomeGrupoMulheresUniversal').val(jovemRetorno.NomeGrupoMulheresIURD);
                $('#cboFrequenciaLeituraBiblia').val(jovemRetorno.DadosEspirituaisJovem.idFrequenciaLeituraBiblia).trigger('change.select2');
                 
                if (jovemRetorno.DadosEspirituaisJovem.PossuiBiblia != '') {
                    if (jovemRetorno.DadosEspirituaisJovem.PossuiBiblia == 'S')
                        $('#rbTemBiblia_S').prop('checked', true);
                    else
                        $('#rbTemBiblia_N').prop('checked', true);
                }

                if (jovemRetorno.DadosEspirituaisJovem.PossuiBibliaNoCelular != '') {
                    if (jovemRetorno.DadosEspirituaisJovem.PossuiBibliaNoCelular == 'S')
                        $('#rbTemBibliaNoCelular_S').prop('checked', true);
                    else
                        $('#rbTemBibliaNoCelular_N').prop('checked', true);
                }

                if (jovemRetorno.DadosEspirituaisJovem.LeuTodaBiblia != '') {
                    if (jovemRetorno.DadosEspirituaisJovem.LeuTodaBiblia == 'S')
                        $('#rbJaLeuBibliaToda_S').prop('checked', true);
                    else
                        $('#rbJaLeuBibliaToda_N').prop('checked', true);
                }
                 
                if (jovemRetorno.PertenceGrupoMulheresIURD != '') {
                    if (jovemRetorno.PertenceGrupoMulheresIURD == 'S')
                        $('#rbFazParteGrupoMulheresUniversal_S').prop('checked', true);
                    else
                        $('#rbFazParteGrupoMulheresUniversal_N').prop('checked', true);
                }


            /* Situação */
            /* aba IURD */
                $('#txtAnosEhObreiro').val(jovemRetorno.SituacaoJovemIURDFJU.AnosObreiro);
                $('#txtMesesEhObreiro').val(jovemRetorno.SituacaoJovemIURDFJU.MesesObreiro);
                $('#txtAnosEhColaborador').val(jovemRetorno.SituacaoJovemIURDFJU.AnosColaborador);
                $('#txtMesesEhColaborador').val(jovemRetorno.SituacaoJovemIURDFJU.MesesColaborador);
                $('#txtAnosInicioCPO').val(jovemRetorno.SituacaoJovemIURDFJU.MesAnoInicioCPO.split('#')[1]);
                $('#txtMesesInicioCPO').val(jovemRetorno.SituacaoJovemIURDFJU.MesAnoInicioCPO.split('#')[0]);
                $('#txtMotivoSaidaObreiro').val(jovemRetorno.SituacaoJovemIURDFJU.MotivoSaiuObreiro);
                $('#txtMotivoSaidaPastorEsposa').val(jovemRetorno.SituacaoJovemIURDFJU.MotivoSaidaPastor);

                console.log('É lider de tribo? ' + jovemRetorno.SituacaoJovemIURDFJU.EhLiderTribo);
                
                if (jovemRetorno.SituacaoJovemIURDFJU.EhObreiro != '' &&
                    jovemRetorno.SituacaoJovemIURDFJU.EhObreiro == 'S')
                    $('#chkEhObreiro').prop('checked', true);

                if (jovemRetorno.SituacaoJovemIURDFJU.EhColaborador != '' &&
                    jovemRetorno.SituacaoJovemIURDFJU.EhColaborador == 'S')
                    $('#chkEhColaborador').prop('checked', true);

                if (jovemRetorno.SituacaoJovemIURDFJU.EstaCursandoCPO != '' &&
                    jovemRetorno.SituacaoJovemIURDFJU.EstaCursandoCPO == 'S')
                    $('#chkCursandoCPO').prop('checked', true);

                if (jovemRetorno.SituacaoJovemIURDFJU.FoiObreiro != '') {
                    if (jovemRetorno.SituacaoJovemIURDFJU.FoiObreiro == 'S')
                        $('#rbJaFoiObreiroAntes_S').prop('checked', true);
                    else
                        $('#rbJaFoiObreiroAntes_N').prop('checked', true);
                }

                if (jovemRetorno.SituacaoJovemIURDFJU.FoiPastor != '') {
                    if (jovemRetorno.SituacaoJovemIURDFJU.FoiPastor == 'S')
                        $('#rbJaFoiPastoEsposaAntes_S').prop('checked', true);
                    else
                        $('#rbJaFoiPastoEsposaAntes_N').prop('checked', true);
                }

            /* aba FJU */
                $('#txtAnosInicioCoordenacaoFJU').val(jovemRetorno.SituacaoJovemIURDFJU.AnosCoordenandoFJU);
                $('#txtMesesInicioCoordenacaoFJU').val(jovemRetorno.SituacaoJovemIURDFJU.MesesCoordenandoFJU);
                
                $('#cboTribo').val(jovemRetorno.SituacaoJovemIURDFJU.idTriboQueLidera).trigger('change.select2');
                $('#txtAnosInicioCoordenacaoTribo').val(jovemRetorno.SituacaoJovemIURDFJU.AnosCoordenandoTribo);
                $('#txtMesesInicioCoordenacaoTribo').val(jovemRetorno.SituacaoJovemIURDFJU.MesesCoordenandoTribo);

                $('#cboProjetoFJU').val(jovemRetorno.SituacaoJovemIURDFJU.idProjetoQueCoordena).trigger('change.select2');
                $('#txtMesesInicioCoordenacaoProjeto').val(jovemRetorno.SituacaoJovemIURDFJU.MesesCoordenandoProjeto);
                $('#txtAnosInicioCoordenacaoProjeto').val(jovemRetorno.SituacaoJovemIURDFJU.AnosCoordenandoProjeto);
                                
                $('#txtMotivoDesejaSErObreiro').val(jovemRetorno.SituacaoJovemIURDFJU.MotivoDesejaSerObreiro);
                 
                if (jovemRetorno.SituacaoJovemIURDFJU.EhPertencenteFJU != '' &&
                    (jovemRetorno.SituacaoJovemIURDFJU.EhPertencenteFJU == 'S' ||
                     jovemRetorno.SituacaoJovemIURDFJU.EhPertencenteFJU == 's' ) )
                    $('#chkMembroFJU').prop('checked', true);

                if (jovemRetorno.SituacaoJovemIURDFJU.EhCoordenadorFJU != '' &&
                    (jovemRetorno.SituacaoJovemIURDFJU.EhCoordenadorFJU == 'S' ||
                     jovemRetorno.SituacaoJovemIURDFJU.EhCoordenadorFJU == 's') )
                    $('#chkEhCoordenadorFJU').prop('checked', true);

                if (jovemRetorno.SituacaoJovemIURDFJU.EhLiderTribo != '' &&
                    jovemRetorno.SituacaoJovemIURDFJU.EhLiderTribo == 'S')
                    $('#chkLiderTribo').prop('checked', true);

                if (jovemRetorno.SituacaoJovemIURDFJU.EhLiderProjeto != '' &&
                    (jovemRetorno.SituacaoJovemIURDFJU.EhLiderProjeto == 'S' || 
                     jovemRetorno.SituacaoJovemIURDFJU.EhLiderProjeto == 's'))
                    $('#chkLiderProjeto').prop('checked', true);

                if (jovemRetorno.SituacaoJovemIURDFJU.DesejaSerObreiro != '') {
                    if (jovemRetorno.SituacaoJovemIURDFJU.DesejaSerObreiro == 'S')
                        $('#rbDesejaSerObreiro_S').prop('checked', true);
                    else
                        $('#rbDesejaSerObreiro_N').prop('checked', true);
                }

                if (jovemRetorno.SituacaoJovemIURDFJU.DesejaFazerObraNoAltar != '') {
                    if (jovemRetorno.SituacaoJovemIURDFJU.DesejaFazerObraNoAltar == 'S')
                        $('#rbDesejaFazerObraAltar_S').prop('checked', true);
                    else
                        $('#rbDesejaFazerObraAltar_N').prop('checked', true);
                }

                if (jovemRetorno.SituacaoJovemIURDFJU.PertenceAltarJovem != '') {
                    if (jovemRetorno.SituacaoJovemIURDFJU.PertenceAltarJovem == 'S') 
                        $('#rbEstaNoAltarJovem_S').prop('checked', true);
                    else
                        $('#rbEstaNoAltarJovem_N').prop('checked', true);
                } 

            /* aba Intellimen */
                $('#txtNumeroDesafioIntellimen').val(jovemRetorno.SituacaoJovemIURDFJU.DesafioAtual);
                $('#txtNomeParceiroIntellimen').val(jovemRetorno.SituacaoJovemIURDFJU.NomeParceiroIntellimen);
                $('#txtTelefoneParceiroIntellimen').val(jovemRetorno.SituacaoJovemIURDFJU.TelefoneParceiroIntellimen); 
                 
                if (jovemRetorno.SituacaoJovemIURDFJU.PertenceIntellimen != '') {
                    if (jovemRetorno.SituacaoJovemIURDFJU.PertenceIntellimen == 'S')
                        $('#rbFazParteIntellimen_S').prop('checked', true);
                    else
                        $('#rbFazParteIntellimen_N').prop('checked', true);
                }

                if (jovemRetorno.SituacaoJovemIURDFJU.DesafiosConcluidos != '') {
                    if (jovemRetorno.SituacaoJovemIURDFJU.DesafiosConcluidos == 'S')
                        $('#rbCompletouDesafios_S').prop('checked', true);
                    else
                        $('#rbCompletouDesafios_N').prop('checked', true);
                }

            /* Projetos */

                if (jovemRetorno.ProjetosAosQuaisJovemEstaLigado.length > 0) {
                    $('#txtAnosProjeto').val(jovemRetorno.ProjetosAosQuaisJovemEstaLigado[0].AnosProjeto);
                    $('#txtMesesProjeto').val(jovemRetorno.ProjetosAosQuaisJovemEstaLigado[0].MesesProjeto);
                    $('#cboProjetoAnterior').val(jovemRetorno.ProjetosAosQuaisJovemEstaLigado[0].idProjetoAnterior).trigger('change.select2');

                    $('#cboProjetoJovemPertence').val(jovemRetorno.ProjetosAosQuaisJovemEstaLigado[0].idProjeto).trigger('change.select2');
                    
                    if (jovemRetorno.ProjetosAosQuaisJovemEstaLigado[0].PertenceuOutroProjeto != '') {
                        if (jovemRetorno.ProjetosAosQuaisJovemEstaLigado[0].PertenceuOutroProjeto == 'S')
                            $('#rbJaEsteveEmOutroProjeto_S').prop('checked', true);
                        else
                            $('#rbJaEsteveEmOutroProjeto_N').prop('checked', true);
                    }
                }
                

                $('#cboCamisasFJU').val(jovemRetorno.SituacaoJovemIURDFJU.NomeCamisaFJU).trigger('change.select2');
                $('#cboTamanhoCamisaFJU').val(jovemRetorno.SituacaoJovemIURDFJU.TamanhoCamisa).trigger('change.select2');

                if (jovemRetorno.SituacaoJovemIURDFJU.PossuiCamisaProjeto != '') {
                    if (jovemRetorno.SituacaoJovemIURDFJU.PossuiCamisaProjeto != 'S')
                        $('#rbTemCamisaFJU_S').prop('checked', true);
                    else
                        $('#rbTemCamisaFJU_N').prop('checked', true);
                }

            /* Habilidades e idiomas */
            /* aba Cultura */
            /* aba Esporte */
            /* aba Midia */
            /* aba Universitários */

                 rbModalidadeNivelSuperior_S | rbModalidadeNivelSuperior_N 
                if (jovemRetorno.DadosEducacionaisJovem.DesejaCursarNivelSuperior != '') {
                    if (jovemRetorno.DadosEducacionaisJovem.DesejaCursarNivelSuperior == 'S')
                        $('#rbDesejaCursarNivelSuperior_S').prop('checked', true);
                    else
                        $('#rbDesejaCursarNivelSuperior_N').prop('checked', true);
                }
                $('#NomeCursoSuperiorDesejaCursar').val(jovemRetorno.DadosEducacionaisJovem.txtNomeCursoDesejaCursar);

                if (jovemRetorno.DadosEducacionaisJovem.PossuiNivelSuperior != '') {
                    if (jovemRetorno.DadosEducacionaisJovem.PossuiNivelSuperior == 'S')
                        $('#rbJaSeFormou_S').prop('checked', true);
                    else
                        $('#rbJaSeFormou_N').prop('checked', true);
                }

                var ID_PRESENCIAL = 0;
                if (jovemRetorno.DadosEducacionaisJovem.idModalidadeCursadaEnsinoSuperior == ID_PRESENCIAL)
                    $('#rbModalidadeNivelSuperior_S').prop('checked', true);
                else
                    $('#rbModalidadeNivelSuperior_N').prop('checked', true);

                $('#txtNomeCursoFaculdadeJovem').val(jovemRetorno.DadosEducacionaisJovem.NomeCursoSuperior);                
                $('#txtPeriodoCursando').val(jovemRetorno.DadosEducacionaisJovem.PeriodoAtualNivelFaculdade);
                $('#txtPrevisaoFormatura').val(jovemRetorno.DadosEducacionaisJovem.PrevisaoConclusaoCurso);

            /* aba Cursos Adicionais */
            /* aba Idiomas */

            /* finish( testemunho e sugestão ) */
            /* Aba Detalhes */
                if (jovemRetorno.TestemunhoJovem.SofreuComDepressao != '') {
                    if (jovemRetorno.TestemunhoJovem.SofreuComDepressao == 'S')
                        $('#rbJaSofreuDepressao_S').prop('checked', true);
                    else
                        $('#rbJaSofreuDepressao_N').prop('checked', true);
                };

                if (jovemRetorno.TestemunhoJovem.SofreuAutomutilacao != '') {
                    if (jovemRetorno.TestemunhoJovem.SofreuAutomutilacao == 'S')
                        $('#rbJaSofreuAutomutilacao_S').prop('checked', true);
                    else
                        $('#rbJaSofreuAutomutilacao_N').prop('checked', true);
                };

                if (jovemRetorno.TestemunhoJovem.SofreuVicio != '') {
                    if (jovemRetorno.TestemunhoJovem.SofreuVicio == 'S')
                        $('#rbJaTeveVicio_S').prop('checked', true);
                    else
                        $('#rbJaTeveVicio_N').prop('checked', true);
                };

                if (jovemRetorno.TestemunhoJovem.TentouSuicidio != '') {
                    if (jovemRetorno.TestemunhoJovem.TentouSuicidio == 'S')
                        $('#rbJaTentouSuicidio_S').prop('checked', true);
                    else
                        $('#rbJaTentouSuicidio_N').prop('checked', true);
                };

                
                $('#txtTempoSofreuDepressao').val(jovemRetorno.TestemunhoJovem.TempoSofreuDepressao);
                $('#txtTempoLivreDepressao').val(jovemRetorno.TestemunhoJovem.TempoLivreDepressao);

                $('#txtTempoSofreuAutomutilacao').val(jovemRetorno.TestemunhoJovem.TempoSofreuAutomutilacao);
                $('#txtTempoLivreAutomutilacao').val(jovemRetorno.TestemunhoJovem.TempoLivreAutomutilacao);

                $('#txtNomeVicio').val(jovemRetorno.TestemunhoJovem.DescricaoVicio);
                $('#txtTempoVicio').val(jovemRetorno.TestemunhoJovem.TempoVicio);
                $('#txtTempoLivreVicios').val(jovemRetorno.TestemunhoJovem.TempoLivreVicios);

                $('#TempoLivreAutomutilacao').val(jovemRetorno.TestemunhoJovem.TempoLivreAutomutilacao);
                $('#txtNumeroTentativasSuicidio').val(jovemRetorno.TestemunhoJovem.NumeroTentativasSuicidio);
                $('#txtQuandoTentouSuicidio').val(jovemRetorno.TestemunhoJovem.MesAnoTentativaSuicidio);
                $('#txtDescricaoTentativaSuicidio').val(jovemRetorno.TestemunhoJovem.DescricaoTentativaSuicidio);
                
                    
                 /* aba Resumo */
                    $('#txtTestemunho').val(jovemRetorno.TestemunhoJovem.TextoTestemunho);

            /* Aba sugestão */ 
                $('#txtSugestao').val(jovemRetorno.TextoSugestao);


                var reunioesAssistidas     = jovemRetorno.ReunioesFJUAssistidasPeloJovem;
                var idReuniaoEncontroJovem = $('#chkEncontroJovem').val();
                var idReuniaoAlgoAMais     = $('#chkReuniaoAlgoAMais').val();
                var idReuniaoAltarJovem    = $('#chkReuniaoaltarJovem').val();
                var idReuniaoProjeto       = $('#chkReuniaoProjeto').val();
                
                for (var i = 0; i < reunioesAssistidas.length; i++) {
                    if (idReuniaoEncontroJovem == reunioesAssistidas[i].idReuniao)
                        $('#chkEncontroJovem').prop('checked', true);
                    
                    if (idReuniaoAlgoAMais == reunioesAssistidas[i].idReuniao)
                        $('#chkReuniaoAlgoAMais').prop('checked', true);

                    if (idReuniaoAltarJovem == reunioesAssistidas[i].idReuniao)
                        $('#chkReuniaoaltarJovem').prop('checked', true);

                    if (idReuniaoProjeto == reunioesAssistidas[i].idReuniao)
                        $('#chkReuniaoProjeto').prop('checked', true);
                }


                
                console.log('quantidade de filhos '+ jovemRetorno.QuantidadeFilhos);
                
                var livrosLidos = jovemRetorno.LivrosLidosPeloJovem;
                for (var i = 0; i < livrosLidos.length; i++) {
                    //console.log(livrosLidos[i].idLivro);
                    var checkLivroSelecionar = $("input:checkbox[value=" + livrosLidos[i].idLivro + "]");
                    checkLivroSelecionar.prop('checked', true);
                    console.log(checkLivroSelecionar.prop('value'));
                }

                $("input:checkbox").each(function (i, el) {
                    if ($(this).attr('name').substring('chkLivro')) {
                        var checkLivro = $(this);   
                    }
                });

            });
        }

        function AdicionarIdioma(TIPO_IDIOMA) {
            var codigoIdiomaParametro;
            var descricaoIdiomaParametro;
            var codigoNivelParametro;
            var descricaoNivelParamtro;
            var EhIdiomaExtraParametro = false;

            if (TIPO_IDIOMA == 'JaCadastrado') {
                codigoIdiomaParametro    =  $('#cboIdiomas option:selected').val();
                descricaoIdiomaParametro = $('#cboIdiomas option:selected').text();
                codigoNivelParametro     = $('#cboNivelIdioma option:selected').val();
                descricaoNivelParamtro   = $('#cboNivelIdioma option:selected').text();
            }
            else if (TIPO_IDIOMA == 'Extra') {
                codigoIdiomaParametro = 0;
                descricaoIdiomaParametro = $('#txtNomeIdiomaExtra').val();
                codigoNivelParametro = $('#cboNivelIdiomaExtra option:selected').val();
                descricaoNivelParamtro = $('#cboNivelIdiomaExtra option:selected').text();
                EhIdiomaExtraParametro = true;
            }

            var idiomaNivelDTO = {
                CodigoIdioma: codigoIdiomaParametro,
                DescricaoIdioma: descricaoIdiomaParametro,
                CodigoNivel: codigoNivelParametro,
                DescricaoNivel: descricaoNivelParamtro,
                EhIdiomaExtra: EhIdiomaExtraParametro
            };

            if (TIPO_IDIOMA == 'JaCadastrado') {
                if ((codigoIdiomaParametro == undefined || codigoIdiomaParametro == 0) ||
                    (codigoNivelParametro   == undefined || codigoNivelParametro  == '')) {
                    alert('Selecione o idioma a ser adicionado !');
                    return false;
                }
            }
            else if (TIPO_IDIOMA == 'Extra') {
                if ((descricaoIdiomaParametro == undefined || descricaoIdiomaParametro == '') ||
                    (codigoNivelParametro == undefined || codigoNivelParametro == '')) {
                    alert('Para adicionar um idioma extra os campos: Nome do idioma e nível precisam ser preenchidos !');
                    return false;
                }
            }

            $.ajax({
                type: "POST",
                data: JSON.stringify(idiomaNivelDTO),
                url: "api/IdiomasAtualizacao/AdicionarIdioma",
                contentType: "application/json"
            }).done(function (res) {
                if (res.IdiomaJaAdicionado == true)
                    exibeMensagem(res.MensagemRespostaRequisicao, 'Mensagem informativa', 'erro');
                else
                    exibeMensagem(res.MensagemRespostaRequisicao, 'Mensagem informativa', 'info');
            });
        }

        function AdicionarCursoRelacionadoProjeto() {
            var cursoDTO = {
                IdProjetoRelacionado: $('#cboProjetoAssociadoCurso option:selected').val(),
                NomeProjeto: $('#cboProjetoAssociadoCurso option:selected').text(),
                NomeCurso: $('#txtNomeCursoHabilidadeAdicional').val()
            };

            if ((cursoDTO.IdProjetoRelacionado == undefined || cursoDTO.IdProjetoRelacionado == 0) ||
                (cursoDTO.NomeCurso == undefined || cursoDTO.NomeCurso == '')) {
                alert('Digite o curso a ser adicionado !');
                return false;
            }

            $.ajax({
                type: "POST",
                data: JSON.stringify(cursoDTO),
                url: "api/CursosAtualizacao",
                contentType: "application/json"
            }).done(function (res) {
                exibeMensagem('Curso adicionado com sucesso!!!', 'Mensagem informativa', 'info');
            });
        }

        //valoes abaxo de prod
        var ID_ESPORTE = 12;
        var ID_CULTURA = 18;
        var ID_MIDIA = 16;
        var ID_DP_FOTOGRAFIA = 10;
        var ID_DP_JORNALISMO = 11;
        var ID_DP_MARKETING = 12;
        var ID_DP_AUDIOVISUAL = 13;
        var ID_DP_DESIGNGRAFICO = 14;
        var ID_DEPARTAMENTO_ARTES_MARCIAIS = 15;
        //var ID_ESPORTE = 3;
        //var ID_CULTURA = 9;
        //var ID_MIDIA = 7;
        //var ID_DP_FOTOGRAFIA = 8;
        //var ID_DP_JORNALISMO = 9;
        //var ID_DP_MARKETING = 10;
        //var ID_DP_AUDIOVISUAL = 11;
        //var ID_DP_DESIGNGRAFICO = 12;
        function AdicionarHabilidadeProjetoCulturaDanca(tipoHabilidade) {
            var idNivelParametro;
            var idProjetoParametro;
            var nomeProjetoParametro;
            var idHabilidadeParametro;
            var nomeHabilidadeParametro;
            var idDepartamentoParametro = 0;
            var EhHabilidadeExtraParametro = false;

            if (tipoHabilidade == 'BANDA') {
                idHabilidadeParametro = $('#cboHabilidadesBANDA option:selected').val();
                idNivelParametro = $('#cboNivelHabilidadeBANDA option:selected').val();
                nomeHabilidadeParametro = $('#cboHabilidadesBANDA option:selected').text();
                idProjetoParametro = ID_CULTURA;//em produção é 18
                nomeProjetoParametro = 'Cultura';
            }
            else if (tipoHabilidade == 'DANCA') {
                idHabilidadeParametro = $('#cboHabilidadesDanca option:selected').val();
                idNivelParametro = $('#cboNivelHabilidadeDanca option:selected').val();
                nomeHabilidadeParametro = $('#cboHabilidadesDanca option:selected').text();
                idProjetoParametro = ID_CULTURA;//em produção é 18
                nomeProjetoParametro = 'Cultura';
            }
            else if (tipoHabilidade == 'ESPORTE') {                
                var ehArtesMarcial = false;
                var nomeHabilidadeEsporte = $('#cboHabilidadesESPORTE option:selected').text();
                nomeHabilidadeParametro = nomeHabilidadeEsporte;
                idHabilidadeParametro = $('#cboHabilidadesESPORTE option:selected').val();
                idNivelParametro = $('#cboNivelHabilidadesESPORTE option:selected').val();
                idProjetoParametro = ID_ESPORTE;//ver valor em produção
                nomeProjetoParametro = 'Esporte';
                if (nomeHabilidadeEsporte == 'Jiu-Jitsu' ||
                    nomeHabilidadeEsporte == 'Muay-Thai' ||
                    nomeHabilidadeEsporte == 'Boxe' ||
                    nomeHabilidadeEsporte == 'Capoeira' ||
                    nomeHabilidadeEsporte == 'Taekwondo') {
                    ehArtesMarcial = true;
                    idDepartamentoParametro = ID_DEPARTAMENTO_ARTES_MARCIAIS;
                }
            }
            else if (tipoHabilidade == 'MIDIA') {
                nomeHabilidadeParametro = $('#cboHabilidadesMIDIA option:selected').text();
                idHabilidadeParametro = $('#cboHabilidadesMIDIA option:selected').val();
                idNivelParametro = $('#cboNivelHabilidadeMIDIA option:selected').val();
                idProjetoParametro = ID_MIDIA;
                nomeProjetoParametro = 'Mídia';

                if (nomeHabilidadeParametro == 'Fotográfia')
                    idDepartamentoParametro = ID_DP_FOTOGRAFIA;
                if (nomeHabilidadeParametro == 'Jornalismo')
                    idDepartamentoParametro = ID_DP_JORNALISMO;
                if (nomeHabilidadeParametro == 'Marketing')
                    idDepartamentoParametro = ID_DP_MARKETING;
                if (nomeHabilidadeParametro == 'Audio Visual')
                    idDepartamentoParametro == ID_DP_AUDIOVISUAL;
                if (nomeHabilidadeParametro == 'Design Gráfico')
                    idDepartamentoParametro = ID_DP_DESIGNGRAFICO;
            }
            else if ('EXTRA') {
                nomeHabilidadeParametro = $('#txtNomeHabilidadeExtra').val();
                idProjetoParametro = $('#cboProjetoAssociadoHabilidadeExtra option:selected').val();
                nomeProjetoParametro = $('#cboProjetoAssociadoHabilidadeExtra option:selected').text();
                idNivelParametro = $('#cboNivelHabilidadeExtra option:selected').val();
                EhHabilidadeExtraParametro = true;
            }

            if (EhHabilidadeExtraParametro == false) {
                if ((idHabilidadeParametro == undefined || idHabilidadeParametro == 0) ||
                    (idNivelParametro == undefined || idNivelParametro == '')) {
                    alert('Selecione habilidade a ser adicionada !');
                    return false;
                }
            }
            else {
                if ((idProjetoParametro      == undefined || idProjetoParametro      == 0 ) ||
                    (nomeHabilidadeParametro == undefined || nomeHabilidadeParametro == '') ||
                    (idNivelParametro        == undefined || idNivelParametro        == '')) {
                    alert('Para adicionar uma Habilidade extra, os Campos: Nome, Projero e Nível precisam ser preenchidos !');
                    return false;
                }
            }            

            var habilidadeNivelDTO = {
                IdProjeto: idProjetoParametro,//em produção é 18
                NomeProjeto: nomeProjetoParametro,
                IdDepartamento: idDepartamentoParametro,
                NomeDepartamento: "",
                IdHabilidade: idHabilidadeParametro,
                NomeHabilidade: nomeHabilidadeParametro,
                EhHabilidadeExtra: EhHabilidadeExtraParametro,
                IdNivel: idNivelParametro
            };
            //alert(habilidadeNivelDTO.EhHabilidadeExtra);
            $.ajax({
                type: "post",
                data: JSON.stringify(habilidadeNivelDTO),
                url: "api/HabilidadesAtualizacao/AdicionarHabilidade",
                contentType: "application/json"
            }).done(function (res) {
                //alert( res.MensagemRespostaRequisicao );
                if (res.HabilidadeJaAdicionada == true)
                    exibeMensagem(res.MensagemRespostaRequisicao, 'Mensagem informativa', 'erro');
                else
                    exibeMensagem(res.MensagemRespostaRequisicao, 'Mensagem informativa', 'info');
            });
        }

        function excluirHabilidadeProjeto(idHabilidade) {         
            $.ajax({
                type: "GET",
                url: "api/HabilidadesAtualizacao/RemoverHabilidade/" + idHabilidade,
                contentType: "application/json"
            }).done(function (resposta) {
                if (resposta.HabilidadeExcluidaComSucesso)
                    alert('Habilidade Excluida com sucesso! ');
            });
        }

        function excluirHabilidadeExtraProjeto(nomeHabilidadeExtra) {
            $.ajax({
                type: "GET",
                url: "api/HabilidadesAtualizacao/RemoverHabilidadeExtra/" + nomeHabilidadeExtra,
                contentType: "application/json"
            }).done(function (resposta) {
                if (resposta.HabilidadeExcluidaComSucesso)
                    alert('Habilidade Excluida com sucesso! ');
            });
        }

        function excluirIdioma(idIdioma) {
            $.ajax({
                type: "GET",
                url: "api/IdiomasAtualizacao/RemoveIdioma/" + idIdioma,
                contentType: "application/json"
            }).done(function (resposta) {
                if (resposta.IdiomaExcluidoComSucesso)
                    alert('Idioma Excluido com sucesso! ');
            });
        }

        function excluirCurso(nomeCurso) {            
            $.ajax({
                type: "GET",
                url: "api/CursosAtualizacao/RemoveCurso/" + nomeCurso,
                contentType: "application/json"
            }).done(function (resposta) {
                if (resposta.CursoExcluidoComSucesso)
                    alert('Curso Excluido com sucesso! ');
            });
        }

        function preencherComboBlocos(idEstado) {
            $.ajax({
                type: "GET",
                url: "api/blocos/ObterPorEstado/"+idEstado,
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

        function preencherComboIgrejas(idRegiao) {
            $.ajax({
                type: "GET",
                url: "api/Igrejas/ObterPorRegiao/" + idRegiao,
                contentType: "application/json"
            }).done(function (retorno) {
                $.each(retorno, function () {
                    $("#cboIgreja").append($("<option     />").val(this.IdIgreja).text(this.NomeIgreja));
                });
                $('#ibox1').children('.ibox-content').toggleClass('sk-loading');//#spinner
            });
        }

        function ConfigurarPaginaX072470() {
            $.ajax({
                type: "GET",
                url: "api/Usuarios/X072470/",
                contentType: "application/json"
            }).done(function (retorno) {
                $("#lblNomeUsuario").html(retorno.NomeUsuario);
                $('#lblPerfilUsuario').html(retorno.NomePerfil + '<b class="caret"></b>');
                $('#imgUserConn').attr('height', '48px');
                $('#imgUserConn').attr('width', '48px');
                $('#imgUserConn').attr('src', retorno.PathImagemUsuario);
            });
        }

        function mensagemConfirmacaoCadastro() {
            var msgConfirmacaoCadastro = "Realizada Atualização com sucesso";
            //swal({
            //    title: "Jovem Atualizado com sucesso !",
            //    text: msgConfirmacaoCadastro,
            //    type: "success"
            //});
            setTimeout(function () {
                swal({
                    title: "Jovem Atualizado",
                    text: msgConfirmacaoCadastro,
                    type: "success"
                }, function () {
                        window.location = "ConsultaGeralParametros.html";
                });
            }, 1000);
        }

        function mensagemErroInadequadoSistema() {
            var msgErro = "Sistema se comportou de forma inadequada!";
            //swal({
            //    title: "Jovem Atualizado com sucesso !",
            //    text: msgConfirmacaoCadastro,
            //    type: "success"
            //});
            swal({
                    title: "Instabilidade no Sistema",
                    text: msgErro,
                    type: "error"
                });
        }

        function exibeMensagem(mensagem, tituloMensage, tipoMensagem) {
            setTimeout(function () {
                toastr.options = {
                    closeButton: true,
                    progressBar: true,
                    positionClass: "toast-top-center",
                    showMethod: 'slideDown',
                    timeOut: 4000
                };
                if(tipoMensagem == 'info')
                    toastr.info(mensagem, tituloMensage);
                else if (tipoMensagem == 'erro')
                    toastr.error(mensagem, tituloMensage);
            }, 1300);
        }

        function atualizaDataNascimento() {
            var novaDataNascimento = new Date($('#txtNovaDataNascimento').val());
            var dataFormatada = novaDataNascimento.toLocaleDateString('pt-BR', { timeZone: 'UTC' });
            $('#txtDataNascimento').val(dataFormatada);
            $('#txtHiddenDataNascimento').val(dataFormatada);
            console.log('valor do hidden data nascimento - ' + $('#txtHiddenDataNascimento').val());

            //-----------------------------------------------------------------------------
            var jovemParametro = { DataNascimento: dataFormatada };
            $.ajax({
                type: "POST",
                data: JSON.stringify(jovemParametro),
                url: "api/Jovens/ArmazenaDataAlterada/",
                contentType: "application/json"
            }).done(function (retorno) {
            });
            //-----------------------------------------------------------------------------

            swal({
                title: "Alteração",
                text: 'Data de nascimento alterada com sucesso !!!',
                type: "success"
            });
            $('#alteraDataNascimento').modal('hide');
        }

        function atualizaDataPreenchimentoFormulario() {
            var novaDataPreenchimentoFormulario = new Date($('#txtNovaDataPreenchimentoFormulario').val());
            var dataFormatada = novaDataPreenchimentoFormulario.toLocaleDateString('pt-BR', { timeZone: 'UTC' });            
            $('#txtDataPreenchimentoFormulario').val(dataFormatada);
            $('#txtHiddenDataPreenchimentoFormulario').val(dataFormatada);
            console.log(':: Data preenchimento Hidden|atualiza - ' + $('#txtHiddenDataPreenchimentoFormulario').val());
            
            //-----------------------------------------------------------------------------
            var jovemParametro = { DataPreenchimentoFormulario: dataFormatada };
            $.ajax({
                type: "POST",
                data: JSON.stringify(jovemParametro),
                url: "api/Jovens/ArmazenaDataPreenchimentoAlterada/",
                contentType: "application/json"
            }).done(function (retorno) {
            });
            //-----------------------------------------------------------------------------

            swal({
                title: "Alteração",
                text: 'Data de preenchimento do formulário alterada com sucesso !!!',
                type: "success"
            });
            $('#alteraDataPreenchimentoFormulario').modal('hide');
        }

        function configuraFotoJovemAlteracao(urlFoto) {
            
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
        //|txtDataCasamentoAnterior|
        function atualizaDataCasamento() {
            var novaDataCasamento = new Date($('#txtNovaDataCasamento').val());
            var dataFormatada = novaDataCasamento.toLocaleDateString('pt-BR', { timeZone: 'UTC' });
            $('#txtDataCasamento').val(dataFormatada);
            //$('#txtHiddenDataPreenchimentoFormulario').val(dataFormatada);
            console.log(':: Data de casamento - ' + $('#txtNovaDataCasamento').val());

            //-----------------------------------------------------------------------------
            var jovemParametro = { DataCasamento: dataFormatada };
            $.ajax({
                type: "POST",
                data: JSON.stringify(jovemParametro),
                url: "api/Jovens/ArmazenaDataCasamentoAlterada/",
                contentType: "application/json"
            }).done(function (retorno) {
            });
            //-----------------------------------------------------------------------------

            swal({
                title: "Alteração",
                text: 'Data de Casamento alterada com sucesso !!!',
                type: "success"
            });
            $('#alteraDataCasamento').modal('hide');
        }
        
    </script>
</body>
</html>
