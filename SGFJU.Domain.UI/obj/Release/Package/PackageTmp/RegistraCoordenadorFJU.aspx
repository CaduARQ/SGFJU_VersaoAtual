<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistraCoordenadorFJU.aspx.cs" Inherits="SGFJU.Domain.UI.RegistraCoordenadorFJU" %>

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
    
    <link href="css/plugins/dataTables/datatables.min.css" rel="stylesheet">
    <!--abaixo css que permite seleção-->
    <link href="css/plugins/dataTables/Select-1.3.1/select.dataTables.min.css" rel="stylesheet">

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
                <div class="row  border-bottom white-bg dashboard-header">

                    <div class="col-lg-12">
                        <div class="row text-left">

                            <div class="col">

                                <!-- Aqui entra a tab-->
                                <div class="ibox" id="ibox1">
                        <div class="ibox-title">
                            <a href="GerenciaCoordenadoresEstado.html" id="lnkLinkAlteracao" class="text-danger font-bold">
                                <span class="glyphicon glyphicon-search" aria-hidden="true"></span><span class="glyphicon glyphicon-user" aria-hidden="true"></span> 
                                Todos os Coordenadores                                
                            </a>
                            <div class="ibox-tools">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                                <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                                    <i class="fa fa-wrench"></i>
                                </a>
                                <ul class="dropdown-menu dropdown-user">
                                    <li><a href="#" class="dropdown-item">Config option 1</a>
                                    </li>
                                    <li><a href="#" class="dropdown-item">Config option 2</a>
                                    </li>
                                </ul>
                                <a class="close-link">
                                    <i class="fa fa-times"></i>
                                </a>
                            </div>
                        </div>
                        <div class="ibox-content">
                            <h2 class="text-success font-bold">
                                Cadastro de Coordenadores da Força Jovem Universal
                                <span class="glyphicon glyphicon-user" aria-hidden="true"></span>
                            </h2>
                            <p>
                                Preencha com atenção.
                            </p>

                            <form id="form" action="RegistraCoordenadorFJU.aspx" method="post" runat="server" class="wizard-big">
                                <h1>Igreja</h1>
                                <fieldset>
                                    <h2>Informações referentes à Igreja</h2>
                                    
                                    <hr class="hr-line-solid" />

                                    <div class="row">                                        

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
                                                <select id="cboBloco" class="select2_demo_4 form-control">
                                                    <option></option>
                                                </select>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_phone">Região *</label><br />
                                                <select id="cboRegiao" class="select2_demo_5 form-control">
                                                    <option></option>                                                    
                                                </select>
                                            </div>
                                        </div>

                                    </div>

                                    <!--  -->
                                    <div class="clearfix"></div>
                                    <!--  -->
                                    
                                    <!--  -->


                                    <div class="row">                                        
                                        

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_name">Igreja *</label><br />
                                                <select required id="cboIgreja" name="cboIgreja" class="form-control">
                                                    <option></option>
                                                </select>
                                            </div>
                                        </div>

                                        <div class="col-sm-8">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_name">Nome</label>
                                                <div class="input-group">
                                                  <input type="text" class="form-control" id="txtNome" name="txtNome" >
                                                  <%--<span class="input-group-btn">
                                                    <button class="btn btn-success" type="button" data-toggle="modal" data-target="#modalObreirosIgrejaSelecionada">
                                                        <i class="fa fa-search"></i><i class="fa fa-user"></i>
                                                    </button>
                                                  </span>--%>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    
                                    <div class="clearfix"></div>

                                    <div class="row">
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_name">Tipo de Coordenador</label>
                                                <div class="row">
                                                    <div class="col-4">
                                                        <div class="radio radio-danger radio-inline">
                                                            <input type="radio" id="rbObreiroPastor_S" value="P" name="rbObreiroPastor" >
                                                            <label for="rbObreiroPastor_S"> Pastor </label>
                                                        </div>
                                                    </div>
                                                    <div class="col-4">
                                                        <div class="radio radio-danger radio-inline">
                                                            <input type="radio" id="rbObreiroPastor_N" value="O" name="rbObreiroPastor">
                                                            <label for="rbObreiroPastor_N"> Obreiro </label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    
                                    <div class="clearfix"></div>

                                    <div class="row">                                        
                                        
                                        <div class="col-sm-6">
                                            <div class="form-group">
                                                <button class="btn btn-danger dim btn-outline" onclick="InformarIgrejaSemcoordenador()" type="button" style="width: 350px;">Igreja Não possui FJU</button>
                                            </div>                                            
                                        </div>

                                        <div class="col-sm-2">
                                            <div class="form-group">
                                                <button id="btnPesquisaObreirosIgrejaSelecionada" class="btn btn-success dim btn-outline" data-toggle="modal" data-target="#modalObreirosIgrejaSelecionada" type="button" style="width: 350px;">
                                                    <i class="fa fa-search"></i><i class="fa fa-user"></i> Pesquisar Obreiros da igreja selecionada
                                                </button>
                                            </div>                                            
                                        </div>

                                        

                                    </div>

                                    <div class="clearfix"></div>

                                    <div class="row">

                                        <div class="col-sm-6">
                                            <div class="form-group">
                                                <%--<button class="btn btn-danger dim btn-outline" onclick="InformarIgrejaSemcoordenador()" type="button" style="width: 350px;">Igreja Não possui FJU</button>--%>
                                            </div>                                            
                                        </div>

                                        <div class="col-sm-2">
                                            <div class="form-group">
                                                <button id="btnCancelaAssociacao" class="btn btn-warning dim btn-outline" type="button" onclick="cancelaAssociacaoCoordenadorObreiro()" style="width: 350px;">
                                                    <i class="fa fa-trash"></i>&nbsp;<i class="fa fa-user"></i> Cancelar
                                                </button>
                                            </div>                                            
                                        </div>

                                    </div>

                                    <div class="clearfix"></div>

                                    <!---->
                                    <div class="modal inmodal" id="modalObreirosIgrejaSelecionada" tabindex="-1" role="dialog" aria-hidden="true">
                                        <div class="modal-dialog modal-lg">
                                            <div class="modal-content animated bounceInRight">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                                                    <i class="fa fa-user-circle modal-icon"></i>
                                                    <h4 class="modal-title">Seleção de coordenador</h4>
                                                    <div class="form-group"><h3>Igreja</h3> <h4 id="lblIgrejaSelecionada" class="bg-success"></h4></div>
                                                </div>
                                                <div class="modal-body">
                                                    <!-- aqui entra tabela com jovens já acompanhados pelo obreiro -->
                                                    <table id="tblObreirosIgrejaSelecionadaSelecionada" class="table table-striped table-hover">
                                                        <thead>
                                                            <tr>
                                                                <th>IdJovem</th>
                                                                <th>Foto</th>
                                                                <th>Nome</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                        </tbody>
                                                    </table>
                                                    <!---->
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" onclick="SelecionaCoordenador()" class="btn btn-success btn-outline" data-dismiss="modal">Selecionar Obreiro</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- obreiros da igreja selecionada -->

                                    <!---->
                                    
                                </fieldset>

                                <h1>Dados Pessoais</h1>
                                <fieldset>
                                    <h2>Dados Pessoais</h2>

                                    <hr class="hr-line-solid" />

                                    <div class="row">

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_name">Data de Nascimento</label>
                                                <div class="input-group">
                                                  <input type="text" id="txtDataNascimento" name="txtDataNascimento" >
                                                  <span class="input-group-btn">
                                                    <button class="btn btn-danger" type="button" data-toggle="modal" data-target="#inserirDataNascimento">
                                                        <i class="fa fa-calendar"></i>
                                                    </button>
                                                  </span>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_name">Estado civil *</label>
                                                <select required id="cboTipoEstadoCivil" name="cboTipoEstadoCivil" class="select2_demo_11 form-control">
                                                    <option></option>
                                                    <option value="6">Casado(a)</option>
                                                    <option value="7">Solteiro(a)</option>
                                                    <option value="8">Divorciado(a)</option>
                                                    <option value="9">Viúvo(a)</option>
                                                    <option value="10">Morando Junto</option>
                                                </select>
                                                <span class="input-group-btn">
                                                    <button class="btn btn-danger" id="btnInfoSentimental" type="button" data-toggle="modal" data-target="#adicionaDadosSentimentais">
                                                        <i class="fa fa-address-book"></i>
                                                    </button>
                                                </span>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_email">Nome do cônjuge </label>
                                                <input id="txtNomeconjuge" type="text" name="txtNomeconjuge" class="form-control"   >
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="clearfix"></div>

                                    <div class="row">

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_name">Cônjuge é obreiro?</label>
                                                <div class="row">
                                                    <div class="col-4">
                                                        <div class="radio radio-danger radio-inline">
                                                            <input type="radio" id="rbConjugeEhObreiro_S" value="S" name="rbConjugeEhObreiro" >
                                                            <label for="rbConjugeEhObreiro_S"> Sim </label>
                                                        </div>
                                                    </div>
                                                    <div class="col-4">
                                                        <div class="radio radio-danger radio-inline">
                                                            <input type="radio" id="rbConjugeEhObreiro_N" value="N" name="rbConjugeEhObreiro">
                                                            <label for="rbConjugeEhObreiro_N"> Não </label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_email">Possui filhos ?</label>
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
                                                <label class="text-success font-bold" for="form_phone">Quantos ?</label>
                                                <input class="form-control" name="txtQtdFilhos" type="number" value="0" id="txtQtdFilhos" min="0" max="30" >
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="clearfix"></div>

                                    <div class="row">
                                        
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_email">Inserir Foto *</label>
                                                <br />
                                                <button id="btnAdicionarFoto" data-toggle="modal" data-target="#fotoJovemModal" class="btn btn-danger " type="button"><i class="fa fa-search"></i>&nbsp;Adicionar foto</button>
                                            </div>
                                        </div>

                                    </div>

                                    <!---->
                                    <div class="modal inmodal" id="fotoJovemModal" tabindex="-1" role="dialog" aria-hidden="true">
                                        <div class="modal-dialog">
                                        <div class="modal-content animated bounceInRight">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                                                    <i class="fa fa-laptop modal-icon"></i>
                                                    <h4 class="modal-title">Selecione a foto do Coordenador</h4>
                                                    <small class="font-bold">foto do perfil do Coordenador</small>
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
                                    <div class="modal inmodal" id="inserirDataNascimento" tabindex="-1" role="dialog" aria-hidden="true">
                                        <div class="modal-dialog">
                                        <div class="modal-content animated bounceInRight">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                                                    <i class="fa fa-calendar-check-o modal-icon"></i>
                                                    <h4 class="modal-title">Inserir Data de Nascimento</h4>
                                                    <small class="font-bold">Digite abaixo a Data de Nascimento</small>
                                                </div>
                                                <div class="modal-body">
                                                    <!---->
                                                    
                                                        <div class="form-group"><label>Data de Nascimento</label> <input id="txtNovaDataNascimento" type="date" class="form-control"></div>
                                                        <div>
                                                            <button class="btn btn-sm btn-primary float-right m-t-n-xs" type="button" onclick="setaDataNascimentoCoordenador()"><strong>Inserir Data</strong></button>
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
                                    <div class="modal inmodal" id="adicionaDadosSentimentais" tabindex="-1" role="dialog" aria-hidden="true">
                                        <div class="modal-dialog">
                                        <div class="modal-content animated bounceInRight">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                                                    <i class="fa fa-laptop modal-icon"></i>
                                                    <h4 class="modal-title">Dados do Coordenador</h4>
                                                    <small class="font-bold">Vida sentimental do Coordenador</small>
                                                </div>
                                                <div class="modal-body">
                                                    
                                                    <div class="form-group">
                                                        <label class="text-success font-bold" for="form_name">Esta namorando? </label>
                                                        <div class="row">
                                                            <div class="col-2">
                                                                <div class="radio radio-danger radio-inline">
                                                                    <input type="radio" id="rbNamorandoAtualmente_S" value="S" name="rbNamorandoAtualmente" >
                                                                    <label for="rbNamorandoAtualmente_S"> Sim </label>
                                                                </div>
                                                            </div>
                                                            <div class="col-2">
                                                                <div class="radio radio-danger radio-inline">
                                                                    <input type="radio" id="rbNamorandoAtualmente_N" value="N" name="rbNamorandoAtualmente">
                                                                    <label for="rbNamorandoAtualmente_N"> Não </label>
                                                                </div>
                                                            </div>
                                                        </div>              
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="text-success font-bold" for="form_name">Gosta de alguém? </label>
                                                        <div class="row">
                                                            <div class="col-2">
                                                                <div class="radio radio-danger radio-inline">
                                                                    <input type="radio" id="rbGostandoDeAlguem_S" value="S" name="rbGostandoDeAlguem" >
                                                                    <label for="rbGostandoDeAlguem_S"> Sim </label>
                                                                </div>
                                                            </div>
                                                            <div class="col-2">
                                                                <div class="radio radio-danger radio-inline">
                                                                    <input type="radio" id="rbGostandoDeAlguem_N" value="N" name="rbGostandoDeAlguem">
                                                                    <label for="rbGostandoDeAlguem_N"> Não </label>
                                                                </div>
                                                            </div>
                                                        </div>              
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Nome da pessoa</label>
                                                        <input id="txtNomePretendente" name="txtNomePretendente" type="text" placeholder="Digite o nome da pessoa" class="form-control">
                                                    </div>
                                                    <div>
                                                        <button class="btn btn-sm btn-success float-right m-t-n-xs" 
                                                                type="button" 
                                                                onclick="RegistraInformacaoSentimental()">
                                                            <strong>Salvar informações</strong>
                                                        </button>
                                                    </div>                                                    
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-success btn-outline" data-dismiss="modal">Fechar</button>                                                    
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!---->
                                </fieldset>

                                <h1>Espirituais</h1>
                                <fieldset>
                                    <h2>Informações espirituais</h2>

                                    <hr class="hr-line-solid" />
                                    
                                    <div class="row">


                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_phone">Levantado quando  (Mês/Ano) ?</label>                                                            
                                                <input type="text" id="txtQuandoLevantadoObreiro" name="txtQuandoLevantadoObreiro" class="form-control" data-mask="99/9999" >
                                                    <span class="form-text">MM/AAAA </span>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_name">Deseja fazer a obra no altar ? </label>
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
                                                <label class="text-success font-bold" for="form_name">Já foi Pastor/Esposa antes ? </label>
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

                                        
                                    </div>

                                    <div class="clearfix"></div>

                                    <div class="row">

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_name">Se sim, saiu porque ? </label>
                                                <input id="txtMotivoSaidaPastorEsposa" type="text" name="txtMotivoSaidaPastorEsposa" class="form-control" >
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_phone">Saiu quando (Mês/Ano)?</label>                                                            
                                                <input type="text" id="txtMesAnoSaiuObra" name="txtMesAnoSaiuObra" class="form-control" data-mask="99/9999" >
                                                    <span class="form-text">MM/AAAA </span>
                                            </div>
                                        </div>
                                        
                                    </div>
                                    
                                </fieldset>

                                <%--<h1>Dados da FJU</h1>
                                <fieldset>                                    
                                </fieldset>--%>

                                <h1>Finish</h1>
                                <fieldset>
                                    <h2>Dados da FJU</h2>

                                    <hr class="hr-line-solid" />
                                    
                                    <div class="row">


                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_phone">Tempo de Coordenador da FJU (Ano/Meses) ?</label>                                                            
                                                <div class="row">                                                                
                                                    <div class="col-4">
                                                        <input type="number" id="txtAnosTotalCoodenadorFJU" name="txtAnosTotalCoodenadorFJU" min="1" max="40" class="form-control">
                                                    </div>
                                                    <div class="col-4">
                                                        <input type="number" id="txtMesesTotalCoodenadorFJU" name="txtMesesTotalCoodenadorFJU" min="1" max="12" class="form-control">
                                                    </div>                                                                
                                                </div>
                                            </div>
                                        </div>
                                        
                                        <div class="col-sm-4">
                                          <div class="form-group">
                                                <label class="text-success font-bold" for="form_phone">Tempo de Coordenador na igreja atual (Ano/Meses) ?</label>                                                            
                                                <div class="row">                                                                
                                                    <div class="col-4">
                                                        <input type="number" id="txtAnosCoodenandoFJUIgrejaAtual" name="txtAnosCoodenandoFJUIgrejaAtual" min="1" max="40" class="form-control">
                                                    </div>
                                                    <div class="col-4">
                                                        <input type="number" id="txtMesesCoodenandoFJUIgrejaAtual" name="txtMesesCoodenandoFJUIgrejaAtual" min="1" max="12" class="form-control">
                                                    </div>                                                                
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_phone">Quantos Jovens quando assumiu FJU?</label>
                                                <input class="form-control" name="txtQtdJovensAnterior" type="number" value="0" id="txtQtdJovensAnterior" min="1" required>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="clearfix"></div>

                                    <div class="row">

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_phone">Quantos Jovens atual?</label>
                                                <input class="form-control" name="txtQtdJovensAtual" type="number" value="0" id="txtQtdJovensAtual" min="1" required>
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>
                                        
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" class="font-normal">Data Assumiu FJU</label>
                                                <div class="input-group date">
                                                    <input type="date" name="txtDataAssumiuFJU" class="form-control" required >
                                                </div>
                                            </div>
                                        </div>

                                        

                                    </div>

                                    <div class="clearfix"></div>

                                    <div class="row">

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_name">Já foi entrevistado pelo Estadual(FJU)?</label>
                                                <div class="row">
                                                    <div class="col-2">
                                                        <div class="radio radio-danger  radio-inline">
                                                            <input type="radio" name="rbEntrevistadoEstadualFJU" id="rbEntrevistadoEstadualFJU_S" value="S">
                                                            <label for="rbEntrevistadoEstadualFJU_S">
                                                                Sim
                                                            </label>
                                                        </div>
                                                    </div>
                                                    <div class="col-2">
                                                        <div class="radio radio-danger  radio-inline">
                                                            <input type="radio" name="rbEntrevistadoEstadualFJU" id="rbEntrevistadoEstadualFJU_N" value="N" >
                                                            <label for="rbEntrevistadoEstadualFJU_N">
                                                                Não
                                                            </label>
                                                        </div>
                                                    </div>
                                                </div>                                                            
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_phone">Entrevistado quando (Mês/Ano)?</label>                                                            
                                                <input type="text" id="txtMesAnoEntrevistaEstadual" name="txtMesAnoEntrevistaEstadual" class="form-control" data-mask="99/9999" >
                                                    <span class="form-text">MM/AAAA </span>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_name">Nome Estadual</label>
                                                <input type="text" id="txtNomeEstadualEntrevistou" name="txtNomeEstadualEntrevistou" class="form-control" />
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

    <script src="js/plugins/dataTables/datatables.min.js"></script>
    <script src="js/plugins/dataTables/dataTables.bootstrap4.min.js"></script>

    <!--abaixo biblioteca que permite multipla seleção de registros-->
    <script src="js/plugins/dataTables/Select-1.3.1/dataTables.select.min.js"></script>

    <!-- SGFJU Scripts -->
    <script src="js/SGFJU.Domain.UI.Client.js"></script>
    <script src="js/SGFJU.Domain.UI.Client.Facade.js"></script>
    <script src="js/SGFJU.Domain.UI.PageSetup.js"></script>

    <script>
        //--------
        var facadeUser = new SGFJU.Domain.Model.UI.Client.Facade.UsuarioFacade();
        var ID_SOLTEIRO = 7;
        var __OBREIRO_SELECIONADO
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
                    txtDataNascimento: {
                        date: true
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

            $('#btnInfoSentimental').hide();

            $('.select2_demo_11').on('select2:select', function (e) {                

                if (ID_SOLTEIRO == $(this).val()) {
                    $('#btnInfoSentimental').show();
                }
                else {
                    $('#btnInfoSentimental').hide();
                    limpaControlesInformacaoSentimental();
                }
            })

            $('.select2_demo_3').on('select2:select', function (e) {
                $('#ibox1').children('.ibox-content').toggleClass('sk-loading');//sk-loading                
                var data = e.params.data;
                preencherComboBlocos(data.id); 
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

            $('#cboIgreja').on('select2:select', function (e) {

                var data = e.params.data;
                verificaSeExisteCoordenador(data.id);
            });

            facadeUser.ConfigurarPaginaX072470();

            configComboEstado();

            configuraEstadoInicial();

            $('#fotoJovemModal').on('hide.bs.modal', function () {
                var arquivoFotoJovem = $('#FileUpload1').val()
                if(arquivoFotoJovem != '')
                    swal({
                        title: "Foto do Coordenador",
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

            $('#modalObreirosIgrejaSelecionada').on('show.bs.modal', function () {
                var idIgreja = $('#cboIgreja').val();
                preencheGridObreirosIgrejaSelecionada(idIgreja);
            });

            $('#modalObreirosIgrejaSelecionada').on('hide.bs.modal', function () {
                
            });

            $('input[name=rbObreiroPastor]').change(function () {
                var valorDaRadio = $(this).val();

                if (valorDaRadio == "P") {
                    cancelaAssociacaoCoordenadorObreiro();
                    configuraPerfilPastor();
                }
                else {
                    cancelaAssociacaoCoordenadorObreiro();
                    configuraPerfilObreiro();
                }
            });

            ExecutaActionX072477();

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
            var msgConfirmacaoCadastro = "Realizado com sucesso cadastro do coordenador ";
            swal({
                title: "Coordenador Cadastrado com sucesso !",
                text: msgConfirmacaoCadastro,
                type: "success"
            });
        }

        function RegistraInformacaoSentimental() {
            swal({
                title: "Informações sentimentais",
                text: 'Informações registradas com sucesso !!!',
                type: "success"
            });
            $('#adicionaDadosSentimentais').modal('hide');
        }

        function limpaControlesInformacaoSentimental() {
            $('input[name=rbNamorandoAtualmente]').prop('checked', false);
            $('input[name=rbGostandoDeAlguem]').prop('checked', false);
            $('#txtNomePretendente').val('');
        }

        function verificaSeExisteCoordenador(pIdIgreja) {
            var igrejaCoordenadorDTO = {
                IdIgreja: pIdIgreja
            };
            $.ajax({
                type: "POST",
                data: JSON.stringify(igrejaCoordenadorDTO),
                url: "api/Coordenadores/IgrejaPossuiCoordenador/",
                contentType: "application/json"
            }).done(function (retorno) {
                if (!retorno.RequisicaoBemSucedida) {
                    swal({
                        title: "Validação",
                        text: retorno.MensagemRespostaRequisicao,
                        type: "warning"
                    });
                    $('#cboIgreja').val($('#cboIgreja option:first-child').val()).trigger('change');
                }
            });
        }

        function preencheGridObreirosIgrejaSelecionada(pIdIgreja) {
            var igrejaDTO = {
                IdEstado: $('#cboEstado').val(),
                IdIgreja: pIdIgreja
            };

            console.log(igrejaDTO);

            $.ajax({
                type: "POST",
                data: JSON.stringify(igrejaDTO),
                url: 'api/igrejas/ObterObreirosPorIgreja/',
                contentType: "application/json"
            }).done(function (obreirosIgrejaSelecionada) {
                $('#tblObreirosIgrejaSelecionadaSelecionada').DataTable({
                    data: obreirosIgrejaSelecionada,
                    pageLength: 3,
                    destroy: true,
                    dom: 'Bfrtip',
                    buttons: [
                    ],
                    columns: [
                        { data: 'Id' },
                        { data: 'Nome' },
                        {
                            data: 'NomeArquivoFotoFormatado',
                            render: function (data, type, row) {
                                return "<img src=" + row.NomeArquivoFotoFormatado + " class='rounded-circle img-sm'  />";
                            }
                        }
                    ],
                    select: {
                        style: 'single'
                    },
                    columnDefs: [
                        {
                            targets: [0],
                            visible: false,
                            searchable: false
                        }
                    ]
                });
            });
        }

        function SelecionaCoordenador() {
            var table = $('#tblObreirosIgrejaSelecionadaSelecionada').DataTable();
            var __OBREIRO_SELECIONADO = table.rows({ selected: true }).data()[0];
            var aaaa = table.rows({ selected: true }).data()[0];
            console.log(aaaa.Id);

            if (__OBREIRO_SELECIONADO == undefined) {
                swal({
                    title: "Validação",
                    text: 'Selecione o obreiro coordenador',
                    type: "warning"
                });
                return;
            }

            var jovemDTO = {
                Id: __OBREIRO_SELECIONADO.Id
            };
            
            $.ajax({
                type: "POST",
                data: JSON.stringify(jovemDTO),
                url: 'api/igrejas/ObterObreiroSessaoPorId/',
                contentType: "application/json"
            }).done(function (dadosObreiroSelecionado) {

                //console.log(JSON.stringify(dadosObreiroSelecionado));

                $('#txtNome').val(dadosObreiroSelecionado.Nome);
                $('#txtNome').prop('readonly', 'readonly');

                $('#txtDataNascimento').val(dadosObreiroSelecionado.DataNascimento);
                $('#txtDataNascimento').prop('disabled', true);

                if (dadosObreiroSelecionado.IdEstadoCivil == 6) {                    
                }

                $('#cboTipoEstadoCivil').val(dadosObreiroSelecionado.idEstadoCivilJovem).trigger('change.select2');
                $('#cboTipoEstadoCivil').prop('disabled', true);

                $('#txtNomeconjuge').val(dadosObreiroSelecionado.NomeConjuge);
                $('#txtNomeconjuge').prop('disabled', true);
                
                if (dadosObreiroSelecionado.PossuiFilhos != '') {
                    if (dadosObreiroSelecionado.PossuiFilhos == 'S' ||
                        dadosObreiroSelecionado.PossuiFilhos == 's')
                        $('#rbPossuiFilhos_S').prop('checked', true);
                    else
                        $('#rbPossuiFilhos_N').prop('checked', true);
                };                
                $('input[name=rbPossuiFilhos]').prop('disabled', true);

                $('#txtQtdFilhos').val(dadosObreiroSelecionado.QuantidadeFilhos);
                $('#txtQtdFilhos').prop('disabled', true);

                if (dadosObreiroSelecionado.ConjugeEhObreiro != '') {
                    if (dadosObreiroSelecionado.ConjugeEhObreiro == 'S' ||
                        dadosObreiroSelecionado.ConjugeEhObreiro == 's')
                        $('#rbConjugeEhObreiro_S').prop('checked', true);
                    else
                        $('#rbConjugeEhObreiro_N').prop('checked', true);
                };
                $('input[name=rbConjugeEhObreiro]').prop('disabled', true);

                if (dadosObreiroSelecionado.SituacaoJovemIURDFJU.DesejaFazerObraNoAltar != '') {
                    if (dadosObreiroSelecionado.SituacaoJovemIURDFJU.DesejaFazerObraNoAltar == 'S' ||
                        dadosObreiroSelecionado.SituacaoJovemIURDFJU.DesejaFazerObraNoAltar == 's')
                        $('#rbDesejaFazerObraAltar_S').prop('checked', true);
                    else
                        $('#rbDesejaFazerObraAltar_N').prop('checked', true);
                };
                $('input[name=rbDesejaFazerObraAltar]').prop('disabled', true);

                if (dadosObreiroSelecionado.SituacaoJovemIURDFJU.FoiPastor != '') {
                    if (dadosObreiroSelecionado.SituacaoJovemIURDFJU.FoiPastor == 'S' ||
                        dadosObreiroSelecionado.SituacaoJovemIURDFJU.FoiPastor == 's')
                        $('#rbJaFoiPastoEsposaAntes_S').prop('checked', true);
                    else
                        $('#rbJaFoiPastoEsposaAntes_N').prop('checked', true);
                };
                $('input[name=rbJaFoiPastoEsposaAntes]').prop('disabled', true);

                $('#txtQuandoLevantadoObreiro').val(dadosObreiroSelecionado.MesAnoFoiLevantadoObreiro);                

                $('#txtMotivoSaidaPastorEsposa').val(dadosObreiroSelecionado.SituacaoJovemIURDFJU.MotivoSaidaPastor);
                $('#txtMotivoSaidaPastorEsposa').prop('disabled', true);

                $('#txtMesAnoSaiuObra').val(dadosObreiroSelecionado.SituacaoJovemIURDFJU.MesAnoSaiuObra);
                
            });
        }

        function InformarIgrejaSemcoordenador() {
            var nomeIgreja = $('#cboIgreja option:selected').select().text();
            var vIdIgreja = $('#cboIgreja').val();

            if (vIdIgreja == '') {
                swal({
                    title: "Validação",
                    text: 'Selecione a igreja',
                    type: "warning"
                });
                return;
            }

            var igrejaDTO = {
                IdIgreja: vIdIgreja
            };

            swal({
                title: "Deseja realmente informar que igreja " + nomeIgreja + " não possui coordenador?",
                text: "confirmarção",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Sim, Desejo informar!",
                closeOnConfirm: false
            }, function (isConfirm) {
                if (isConfirm) {
                    $.ajax({
                        type: "POST",
                        data: JSON.stringify(igrejaDTO),
                        url: "api/Coordenadores/InformarIgrejaSemCoordenador",
                        contentType: "application/json"
                    }).done(function (respostaExclusao) {
                        swal({
                            title: "Confirmação",
                            text: 'Confirmado que a igreja' + nomeIgreja + 'ñão possui coordenador',
                            type: "warning"
                        }, function () {
                                location.href = 'GerenciaCoordenadoresEstado.html';
                        });
                    });
                }
            });
        }        

        function abraModalSelecionar() {
            var idIgreja = $('#cboIgreja').val();

            if (idIgreja != '') {
                $('#modalObreirosIgrejaSelecionada').show();
            }
            else {
                swal({
                    title: "Validação",
                    text: "É necessário selecionar igreja!",
                    imageUrl: 'img/delete.jpg'
                });
                return;
            }
        }

        function setaDataNascimentoCoordenador() {
            var dataNascimento = new Date($('#txtNovaDataNascimento').val());
            var dataNascimentoFormatada = dataNascimento.toLocaleDateString('pt-BR', { timeZone: 'UTC' });

            $('#txtDataNascimento').val(dataNascimentoFormatada);

            swal({
                title: "Confirmação",
                text: "Data de nascimento salva com sucesso!",
                type: "success"
            });

            $('#inserirDataNascimento').modal('hide');
        }

        function cancelaAssociacaoCoordenadorObreiro() {
            $('#txtNome').prop('readonly', 'readonly');
            $('#txtNome').val('');

            $('#cboBloco').val($('#cboBloco option:first-child').val()).trigger('change');

            $('#cboRegiao').empty().trigger('change');
            $('#cboIgreja').empty().trigger('change');

            $('#txtDataNascimento').val('');

            $('#cboTipoEstadoCivil').prop('disabled', false);
            $('#cboTipoEstadoCivil').val($('#cboTipoEstadoCivil option:first-child').val()).trigger('change');

            $('#txtNomeconjuge').prop('disabled', false);
            $('#txtNomeconjuge').val('');

            $('input[name=rbPossuiFilhos]').prop('disabled', false);
            $('input[name=rbPossuiFilhos]').prop('checked', false);

            $('#txtQtdFilhos').prop('disabled', false);
            $('#txtQtdFilhos').val('0');

            $('input[name=rbConjugeEhObreiro]').prop('disabled', false);
            $('input[name=rbConjugeEhObreiro]').prop('checked', false);

            $('input[name=rbDesejaFazerObraAltar]').prop('disabled', false);
            $('input[name=rbDesejaFazerObraAltar]').prop('checked', false);

            $('input[name=rbJaFoiPastoEsposaAntes]').prop('disabled', false);
            $('input[name=rbJaFoiPastoEsposaAntes]').prop('checked', false);

            $('#txtQuandoLevantadoObreiro').prop('disabled', false);
            $('#txtQuandoLevantadoObreiro').val('');

            $('#txtMotivoSaidaPastorEsposa').prop('disabled', false);
            $('#txtMotivoSaidaPastorEsposa').val('');
        }

        function configuraEstadoInicial() {
            $('#txtNome').prop('readonly', 'readonly');

            $('#cboRegiao').empty().trigger('change');
            $('#cboIgreja').empty().trigger('change');

            $('#cboTipoEstadoCivil').prop('disabled', false);

            $('#txtNomeconjuge').prop('disabled', false);

            $('input[name=rbPossuiFilhos]').prop('disabled', false);

            $('#txtQtdFilhos').prop('disabled', false);

            $('input[name=rbConjugeEhObreiro]').prop('disabled', false);

            $('input[name=rbDesejaFazerObraAltar]').prop('disabled', false);

            $('input[name=rbJaFoiPastoEsposaAntes]').prop('disabled', false);

            $('#txtQuandoLevantadoObreiro').prop('disabled', false);

            $('#txtMotivoSaidaPastorEsposa').prop('disabled', false);
        }

        function configuraPerfilPastor() {
            $('#txtNome').attr('readonly', false);
            $('input[name=rbConjugeEhObreiro]').prop('disabled', true);
            $('input[name=rbDesejaFazerObraAltar]').prop('disabled', true);
            $('#btnPesquisaObreirosIgrejaSelecionada').attr('disabled', true);
            $('#btnCancelaAssociacao').attr('disabled', true);
        }

        function configuraPerfilObreiro() {
            $('#txtNome').attr('readonly', true);
            $('input[name=rbConjugeEhObreiro]').prop('disabled', false);
            $('input[name=rbDesejaFazerObraAltar]').prop('disabled', false);
            $('#btnPesquisaObreirosIgrejaSelecionada').attr('disabled', false);
            $('#btnCancelaAssociacao').attr('disabled', false);
        }
        
    </script>
</body>
</html>
