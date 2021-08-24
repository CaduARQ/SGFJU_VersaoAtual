<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlteraCoordenador.aspx.cs" Inherits="SGFJU.Domain.UI.AlteraCoordenador" %>

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
                    <li class="active">
                        <a href="RegistraJovem.aspx"><i class="fa fa-th-large"></i> <span class="nav-label">Voluntários</span> <span class="fa arrow"></span></a>
                        <ul class="nav nav-second-level">                            
                        </ul>
                    </li>
                    <li>
                        <a href="#"><i class="fa fa-bar-chart-o"></i> <span class="nav-label">Relatórios</span><span class="fa arrow"></span></a>
                        <ul class="nav nav-second-level collapse">                            
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
                        <a id="lnkDashboard"><i class="fa fa-pie-chart"></i> <span class="nav-label">Dashboard</span>  </a>
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
                    <%--<input type="text" placeholder="Pesquise por palavra-chave..." class="form-control" name="top-search" id="top-search">--%>
                </div>
            </form>
        </div>
            

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
                                Alteração de Coordenadores da Força Jovem Universal
                            </h2>
                            <p>
                                Preencha com atenção.
                            </p>

                            <form id="form" action="AlteraCoordenador.aspx" method="post" runat="server" class="wizard-big">
                                <h1>Pessoal</h1>
                                <fieldset>
                                    <h2>Informações Pessoais</h2>
                                    
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
                                                    <option value="56">[BLOCO DE TESTE]</option>
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

                                    <!-- Primeiro separador -->
                                    <div class="clearfix"></div>

                                    <div class="row">                                        
                                        

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="text-success font-bold" for="form_name">Igreja *</label><br />
                                                <select required id="cboIgreja" name="cboIgreja" class="form-control">
                                                    <option></option>
                                                </select>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                        <div class="form-group">
                                                <label class="text-success font-bold" for="form_name">Nome *</label>
                                                <input id="txtNome" type="text" name="txtNome" class="form-control" required="required" data-error="name is required.">
                                                <div class="help-block with-errors"></div>
                                            </div>
                                        </div>

                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label for="form_name">Data de Nascimento</label>
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

                                    <!-- Separador entre a segunda e terceira linha de controles do formulário -->
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
                                                <span class="input-group-btn">
                                                    <button class="btn btn-success" 
                                                            id="btnVisualizaFotoJovemAlterar" 
                                                            type="button" 
                                                            data-toggle="modal" 
                                                            data-tt="tooltip" 
                                                            title="Foto já cadastrada do coordenador" 
                                                            data-target="#VisualizaFotoJovemAlteracao">
                                                        <i class="fa fa-photo"></i>
                                                    </button>
                                                </span>
                                            </div>
                                        </div>

                                    </div>

                                    <!-- modal fora da tab para testar se é enxergada gglobalmente -->
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
                                    <!-- Foto para visualizar foto do jovem -->
                                    <div class="modal inmodal" id="VisualizaFotoJovemAlteracao" tabindex="-1" role="dialog" aria-hidden="true">
                                        <div class="modal-dialog">
                                        <div class="modal-content animated bounceInRight">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                                                    <i class="fa fa-photo modal-icon"></i>
                                                    <h4 class="modal-title">Foto Cadastrada</h4>
                                                    <small class="font-bold">Foto do Coordenador</small>
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
                                                    <button type="button" class="btn btn-white" data-dismiss="modal">Fechar</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- end -->
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
                                                        <input type="number" id="txtMesesTotalCoodenadorFJU" name="txtMesesTotalCoodenadorFJU" min="0" max="12" class="form-control">
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
                                                        <input type="number" id="txtMesesCoodenandoFJUIgrejaAtual" name="txtMesesCoodenandoFJUIgrejaAtual" min="0" max="12" class="form-control">
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
                                                <label class="text-success font-bold" for="form_name">Data que Assumiu FJU</label>
                                                <div class="input-group">
                                                  <input type="text" class="form-control" id="txtDataAssumiuFJU" name="txtDataAssumiuFJU" >
                                                  <input type="hidden" id="Hidden1" runat="server" />
                                                  <span class="input-group-btn">
                                                    <button class="btn btn-danger" type="button" data-toggle="modal" data-target="#alteraDataAssumiuFJU">
                                                        <i class="fa fa-calendar"></i>
                                                    </button>
                                                  </span>
                                                </div>
                                            </div>
                                        </div>

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

                                    </div>

                                    <!---->
                                    <div class="modal inmodal" id="alteraDataAssumiuFJU" tabindex="-1" role="dialog" aria-hidden="true">
                                        <div class="modal-dialog">
                                        <div class="modal-content animated bounceInRight">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                                                    <i class="fa fa-calendar-check-o modal-icon"></i>
                                                    <h4 class="modal-title">Alterar Data que Assumiu a FJU</h4>
                                                    <small class="font-bold">Digite abaixo a Data que Assumiu a FJU corrigida</small>
                                                </div>
                                                <div class="modal-body">
                                                    <!---->
                                                    
                                                        <div class="form-group"><label>Data de Nascimento Anterior</label> <input id="txtDataAssumiuFJUAnterior" type="text" class="form-control"></div>
                                                        <div class="form-group"><label>Nova Data de Nascimento</label> <input id="txtNovaDataAssumiuFJU" type="date" class="form-control"></div>
                                                        <div>
                                                            <button class="btn btn-sm btn-primary float-right m-t-n-xs" type="button" onclick="atualizaDataAssumiuFJU()"><strong>Atualizar Data</strong></button>
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

                                    <div class="clearfix"></div>

                                    <div class="row">

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
        <div class="small-chat-box fadeInRight animated">

            <div class="heading" draggable="true">
                <small class="chat-date float-right">
                    02.19.2015
                </small>
                Small chat
            </div>

            <div class="content">

                <div class="left">
                    <div class="author-name">
                        Monica Jackson <small class="chat-date">
                        10:02 am
                    </small>
                    </div>
                    <div class="chat-message active">
                        Lorem Ipsum is simply dummy text input.
                    </div>

                </div>
                <div class="right">
                    <div class="author-name">
                        Mick Smith
                        <small class="chat-date">
                            11:24 am
                        </small>
                    </div>
                    <div class="chat-message">
                        Lorem Ipsum is simpl.
                    </div>
                </div>
                <div class="left">
                    <div class="author-name">
                        Alice Novak
                        <small class="chat-date">
                            08:45 pm
                        </small>
                    </div>
                    <div class="chat-message active">
                        Check this stock char.
                    </div>
                </div>
                <div class="right">
                    <div class="author-name">
                        Anna Lamson
                        <small class="chat-date">
                            11:24 am
                        </small>
                    </div>
                    <div class="chat-message">
                        The standard chunk of Lorem Ipsum
                    </div>
                </div>
                <div class="left">
                    <div class="author-name">
                        Mick Lane
                        <small class="chat-date">
                            08:45 pm
                        </small>
                    </div>
                    <div class="chat-message active">
                        I belive that. Lorem Ipsum is simply dummy text.
                    </div>
                </div>


            </div>
            <div class="form-chat">
                <div class="input-group input-group-sm">
                    <input type="text" class="form-control">
                    <span class="input-group-btn"> <button
                        class="btn btn-primary" type="button">Send
                </button> </span></div>
            </div>

        </div>
        <div id="small-chat">

            <span class="badge badge-warning float-right">5</span>
            <a class="open-small-chat" href="">
                <i class="fa fa-comments"></i>

            </a>
        </div>
        <div id="right-sidebar" class="animated">
            <div class="sidebar-container">

                <ul class="nav nav-tabs navs-3">
                    <li>
                        <a class="nav-link active" data-toggle="tab" href="#tab-1"> Notes </a>
                    </li>
                    <li>
                        <a class="nav-link" data-toggle="tab" href="#tab-2"> Projects </a>
                    </li>
                    <li>
                        <a class="nav-link" data-toggle="tab" href="#tab-3"> <i class="fa fa-gear"></i> </a>
                    </li>
                </ul>

                <div class="tab-content">


                    <div id="tab-1" class="tab-pane active">

                        <div class="sidebar-title">
                            <h3> <i class="fa fa-comments-o"></i> Latest Notes</h3>
                            <small><i class="fa fa-tim"></i> You have 10 new message.</small>
                        </div>

                        <div>

                            <div class="sidebar-message">
                                <a href="#">
                                    <div class="float-left text-center">
                                        <img alt="image" class="rounded-circle message-avatar" src="img/a1.jpg">

                                        <div class="m-t-xs">
                                            <i class="fa fa-star text-warning"></i>
                                            <i class="fa fa-star text-warning"></i>
                                        </div>
                                    </div>
                                    <div class="media-body">

                                        There are many variations of passages of Lorem Ipsum available.
                                        <br>
                                        <small class="text-muted">Today 4:21 pm</small>
                                    </div>
                                </a>
                            </div>
                            <div class="sidebar-message">
                                <a href="#">
                                    <div class="float-left text-center">
                                        <img alt="image" class="rounded-circle message-avatar" src="img/a2.jpg">
                                    </div>
                                    <div class="media-body">
                                        The point of using Lorem Ipsum is that it has a more-or-less normal.
                                        <br>
                                        <small class="text-muted">Yesterday 2:45 pm</small>
                                    </div>
                                </a>
                            </div>
                            <div class="sidebar-message">
                                <a href="#">
                                    <div class="float-left text-center">
                                        <img alt="image" class="rounded-circle message-avatar" src="img/a3.jpg">

                                        <div class="m-t-xs">
                                            <i class="fa fa-star text-warning"></i>
                                            <i class="fa fa-star text-warning"></i>
                                            <i class="fa fa-star text-warning"></i>
                                        </div>
                                    </div>
                                    <div class="media-body">
                                        Mevolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).
                                        <br>
                                        <small class="text-muted">Yesterday 1:10 pm</small>
                                    </div>
                                </a>
                            </div>
                            <div class="sidebar-message">
                                <a href="#">
                                    <div class="float-left text-center">
                                        <img alt="image" class="rounded-circle message-avatar" src="img/a4.jpg">
                                    </div>

                                    <div class="media-body">
                                        Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the
                                        <br>
                                        <small class="text-muted">Monday 8:37 pm</small>
                                    </div>
                                </a>
                            </div>
                            <div class="sidebar-message">
                                <a href="#">
                                    <div class="float-left text-center">
                                        <img alt="image" class="rounded-circle message-avatar" src="img/a8.jpg">
                                    </div>
                                    <div class="media-body">

                                        All the Lorem Ipsum generators on the Internet tend to repeat.
                                        <br>
                                        <small class="text-muted">Today 4:21 pm</small>
                                    </div>
                                </a>
                            </div>
                            <div class="sidebar-message">
                                <a href="#">
                                    <div class="float-left text-center">
                                        <img alt="image" class="rounded-circle message-avatar" src="img/a7.jpg">
                                    </div>
                                    <div class="media-body">
                                        Renaissance. The first line of Lorem Ipsum, "Lorem ipsum dolor sit amet..", comes from a line in section 1.10.32.
                                        <br>
                                        <small class="text-muted">Yesterday 2:45 pm</small>
                                    </div>
                                </a>
                            </div>
                            <div class="sidebar-message">
                                <a href="#">
                                    <div class="float-left text-center">
                                        <img alt="image" class="rounded-circle message-avatar" src="img/a3.jpg">

                                        <div class="m-t-xs">
                                            <i class="fa fa-star text-warning"></i>
                                            <i class="fa fa-star text-warning"></i>
                                            <i class="fa fa-star text-warning"></i>
                                        </div>
                                    </div>
                                    <div class="media-body">
                                        The standard chunk of Lorem Ipsum used since the 1500s is reproduced below.
                                        <br>
                                        <small class="text-muted">Yesterday 1:10 pm</small>
                                    </div>
                                </a>
                            </div>
                            <div class="sidebar-message">
                                <a href="#">
                                    <div class="float-left text-center">
                                        <img alt="image" class="rounded-circle message-avatar" src="img/a4.jpg">
                                    </div>
                                    <div class="media-body">
                                        Uncover many web sites still in their infancy. Various versions have.
                                        <br>
                                        <small class="text-muted">Monday 8:37 pm</small>
                                    </div>
                                </a>
                            </div>
                        </div>

                    </div>

                    <div id="tab-2" class="tab-pane">

                        <div class="sidebar-title">
                            <h3> <i class="fa fa-cube"></i> Latest projects</h3>
                            <small><i class="fa fa-tim"></i> You have 14 projects. 10 not completed.</small>
                        </div>

                        <ul class="sidebar-list">
                            <li>
                                <a href="#">
                                    <div class="small float-right m-t-xs">9 hours ago</div>
                                    <h4>Business valuation</h4>
                                    It is a long established fact that a reader will be distracted.

                                    <div class="small">Completion with: 22%</div>
                                    <div class="progress progress-mini">
                                        <div style="width: 22%;" class="progress-bar progress-bar-warning"></div>
                                    </div>
                                    <div class="small text-muted m-t-xs">Project end: 4:00 pm - 12.06.2014</div>
                                </a>
                            </li>
                            <li>
                                <a href="#">
                                    <div class="small float-right m-t-xs">9 hours ago</div>
                                    <h4>Contract with Company </h4>
                                    Many desktop publishing packages and web page editors.

                                    <div class="small">Completion with: 48%</div>
                                    <div class="progress progress-mini">
                                        <div style="width: 48%;" class="progress-bar"></div>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="#">
                                    <div class="small float-right m-t-xs">9 hours ago</div>
                                    <h4>Meeting</h4>
                                    By the readable content of a page when looking at its layout.

                                    <div class="small">Completion with: 14%</div>
                                    <div class="progress progress-mini">
                                        <div style="width: 14%;" class="progress-bar progress-bar-info"></div>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="#">
                                    <span class="label label-primary float-right">NEW</span>
                                    <h4>The generated</h4>
                                    There are many variations of passages of Lorem Ipsum available.
                                    <div class="small">Completion with: 22%</div>
                                    <div class="small text-muted m-t-xs">Project end: 4:00 pm - 12.06.2014</div>
                                </a>
                            </li>
                            <li>
                                <a href="#">
                                    <div class="small float-right m-t-xs">9 hours ago</div>
                                    <h4>Business valuation</h4>
                                    It is a long established fact that a reader will be distracted.

                                    <div class="small">Completion with: 22%</div>
                                    <div class="progress progress-mini">
                                        <div style="width: 22%;" class="progress-bar progress-bar-warning"></div>
                                    </div>
                                    <div class="small text-muted m-t-xs">Project end: 4:00 pm - 12.06.2014</div>
                                </a>
                            </li>
                            <li>
                                <a href="#">
                                    <div class="small float-right m-t-xs">9 hours ago</div>
                                    <h4>Contract with Company </h4>
                                    Many desktop publishing packages and web page editors.

                                    <div class="small">Completion with: 48%</div>
                                    <div class="progress progress-mini">
                                        <div style="width: 48%;" class="progress-bar"></div>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="#">
                                    <div class="small float-right m-t-xs">9 hours ago</div>
                                    <h4>Meeting</h4>
                                    By the readable content of a page when looking at its layout.

                                    <div class="small">Completion with: 14%</div>
                                    <div class="progress progress-mini">
                                        <div style="width: 14%;" class="progress-bar progress-bar-info"></div>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="#">
                                    <span class="label label-primary float-right">NEW</span>
                                    <h4>The generated</h4>
                                    <!--<div class="small float-right m-t-xs">9 hours ago</div>-->
                                    There are many variations of passages of Lorem Ipsum available.
                                    <div class="small">Completion with: 22%</div>
                                    <div class="small text-muted m-t-xs">Project end: 4:00 pm - 12.06.2014</div>
                                </a>
                            </li>

                        </ul>

                    </div>

                    <div id="tab-3" class="tab-pane">

                        <div class="sidebar-title">
                            <h3><i class="fa fa-gears"></i> Settings</h3>
                            <small><i class="fa fa-tim"></i> You have 14 projects. 10 not completed.</small>
                        </div>

                        <div class="setings-item">
                    <span>
                        Show notifications
                    </span>
                            <div class="switch">
                                <div class="onoffswitch">
                                    <input type="checkbox" name="collapsemenu" class="onoffswitch-checkbox" id="example">
                                    <label class="onoffswitch-label" for="example">
                                        <span class="onoffswitch-inner"></span>
                                        <span class="onoffswitch-switch"></span>
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="setings-item">
                    <span>
                        Disable Chat
                    </span>
                            <div class="switch">
                                <div class="onoffswitch">
                                    <input type="checkbox" name="collapsemenu" checked class="onoffswitch-checkbox" id="example2">
                                    <label class="onoffswitch-label" for="example2">
                                        <span class="onoffswitch-inner"></span>
                                        <span class="onoffswitch-switch"></span>
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="setings-item">
                    <span>
                        Enable history
                    </span>
                            <div class="switch">
                                <div class="onoffswitch">
                                    <input type="checkbox" name="collapsemenu" class="onoffswitch-checkbox" id="example3">
                                    <label class="onoffswitch-label" for="example3">
                                        <span class="onoffswitch-inner"></span>
                                        <span class="onoffswitch-switch"></span>
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="setings-item">
                    <span>
                        Show charts
                    </span>
                            <div class="switch">
                                <div class="onoffswitch">
                                    <input type="checkbox" name="collapsemenu" class="onoffswitch-checkbox" id="example4">
                                    <label class="onoffswitch-label" for="example4">
                                        <span class="onoffswitch-inner"></span>
                                        <span class="onoffswitch-switch"></span>
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="setings-item">
                    <span>
                        Offline users
                    </span>
                            <div class="switch">
                                <div class="onoffswitch">
                                    <input type="checkbox" checked name="collapsemenu" class="onoffswitch-checkbox" id="example5">
                                    <label class="onoffswitch-label" for="example5">
                                        <span class="onoffswitch-inner"></span>
                                        <span class="onoffswitch-switch"></span>
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="setings-item">
                    <span>
                        Global search
                    </span>
                            <div class="switch">
                                <div class="onoffswitch">
                                    <input type="checkbox" checked name="collapsemenu" class="onoffswitch-checkbox" id="example6">
                                    <label class="onoffswitch-label" for="example6">
                                        <span class="onoffswitch-inner"></span>
                                        <span class="onoffswitch-switch"></span>
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="setings-item">
                    <span>
                        Update everyday
                    </span>
                            <div class="switch">
                                <div class="onoffswitch">
                                    <input type="checkbox" name="collapsemenu" class="onoffswitch-checkbox" id="example7">
                                    <label class="onoffswitch-label" for="example7">
                                        <span class="onoffswitch-inner"></span>
                                        <span class="onoffswitch-switch"></span>
                                    </label>
                                </div>
                            </div>
                        </div>
                        
                        <div class="sidebar-content">
                            <h4>Settings</h4>
                            <div class="small">
                                I belive that. Lorem Ipsum is simply dummy text of the printing and typesetting industry.
                                And typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.
                                Over the years, sometimes by accident, sometimes on purpose (injected humour and the like).
                            </div>
                        </div>

                    </div>
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
            $("#cboTipoEstadoCivil").select2();

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

            facadeUser.ConfigurarPaginaX072470();

            configComboEstado();

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

            ExecutaActionX072477();

            PreencherFormularioAtualizacao();

            $('#VisualizaFotoJovemAlteracao').on('shown.bs.modal', function () {
                console.log('ao abrir modal ' + __URL_FOTO_ALTERACAO);
                configuraFotoJovemAlteracao(__URL_FOTO_ALTERACAO);
            });

        });

        function PreencherFormularioAtualizacao() {
            var url_ = new URL(location.href);
            var vIdCoordenadorFJU = url_.searchParams.get("idCoordenador");
            var coordenadorParametroDTO = {
                IdCoordenadorFJU: vIdCoordenadorFJU
            };
            console.log(vIdCoordenadorFJU);
            $.ajax({
                type: "POST",
                data: JSON.stringify(coordenadorParametroDTO),
                url: "api/Coordenadores/ObterCoordenadorAtualizacao",
                contentType: "application/json"
            }).done(function (retornoCoordenador) {

                $('#cboEstado').val(retornoCoordenador.IdEstado).trigger('change.select2');
                $('#cboEstado').prop("disabled", true);

                var dataBloco = {
                    id: retornoCoordenador.IdBlocoJovem,
                    text: retornoCoordenador.NomeBlocoJovem
                };
                var blocoOption = new Option(dataBloco.text, dataBloco.id, false, false);
                $('#cboBloco').append(blocoOption).trigger('change');
                $('#cboBloco').val(retornoCoordenador.IdBlocoJovem).trigger('change.select2');
                $('#cboBloco').prop("disabled", true);

                var dataRegiao = {
                    id: retornoCoordenador.IdRegiao,
                    text: retornoCoordenador.NomeRegiaoJovem
                };
                var regiaoOption = new Option(dataRegiao.text, dataRegiao.id, false, false);
                $('#cboRegiao').append(regiaoOption).trigger('change');
                $('#cboRegiao').val(retornoCoordenador.IdRegiao).trigger('change.select2');
                $('#cboRegiao').prop("disabled", true);

                var data = {
                    id: retornoCoordenador.IdIgreja,
                    text: retornoCoordenador.NomeIgreja
                };
                var igrejaJovemOption = new Option(data.text, data.id, false, false);
                $('#cboIgreja').append(igrejaJovemOption).trigger('change');
                $('#cboIgreja').val(retornoCoordenador.IdIgreja).trigger('change.select2');
                $("#cboIgreja").prop("disabled", true);

                $('#cboTipoEstadoCivil').val(retornoCoordenador.IdEstadoCivil).trigger('change.select2');

                if (retornoCoordenador.IdEstadoCivil == 7) {
                    $('#btnInfoSentimental').show();
                }
                else {
                    $('#btnInfoSentimental').hide();
                }

                console.log(HOST_NAME_APP);
                if (HOST_NAME_APP.indexOf('localhost') !== -1) {
                    __URL_FOTO_ALTERACAO = __HOST_LOCAL + retornoCoordenador.NomeArquivoFoto;
                    console.log(__URL_FOTO_ALTERACAO);
                }
                else {
                    if (retornoCoordenador.NomeArquivoFoto == '')
                        __URL_FOTO_ALTERACAO = __HOST_PRODUCAO + 'jovemsemfoto.jpg';
                    else
                        __URL_FOTO_ALTERACAO = __HOST_PRODUCAO + retornoCoordenador.NomeArquivoFoto;
                }

                $('#txtNome').val(retornoCoordenador.NomeCoordenador);

                $('#txtDataNascimento').val(retornoCoordenador.DataNascimento);
                $('#txtDataNascimento').prop('disabled', true);

                $('#txtDatanascimentoAnterior').val(retornoCoordenador.DataNascimento);
                $('#txtDatanascimentoAnterior').prop('disabled', true);
                 
                $('#txtNomeconjuge').val(retornoCoordenador.NomeConjuge);

                $('#txtQtdFilhos').val(retornoCoordenador.QuantidadeFilhos);

                $('#txtNomePretendente').val(retornoCoordenador.NomePretendente);

                $('#txtQuandoLevantadoObreiro').val(retornoCoordenador.MesAnoFoiLevantadoObreiro);
                console.log('mes e ano levantado obreiro -> '+retornoCoordenador.MesAnoFoiLevantadoObreiro);

                $('#txtMotivoSaidaPastorEsposa').val(retornoCoordenador.MotivoSaidaPastor);

                $('#txtMesAnoSaiuObra').val(retornoCoordenador.MesAnoSaiuObra);

                $('#txtAnosTotalCoodenadorFJU').val(retornoCoordenador.TotalAnosCoordenandoFJU);

                $('#txtMesesTotalCoodenadorFJU').val(retornoCoordenador.TotalMesesCoordenandoFJU);

                $('#txtAnosCoodenandoFJUIgrejaAtual').val(retornoCoordenador.AnosCoordenandoIgrejaAtualFJU);

                $('#txtMesesCoodenandoFJUIgrejaAtual').val(retornoCoordenador.MesesCoordenandoIgrejaAtualFJU);

                $('#txtQtdJovensAtual').val(retornoCoordenador.QuantidadeJovensEncontroAtual);

                $('#txtQtdJovensAnterior').val(retornoCoordenador.QuantidadeJovensEncontroAnterior);

                $('#txtDataAssumiuFJU').val(retornoCoordenador.DataEntradaCoordenador);
                $('#txtDataAssumiuFJU').prop('disabled', true);

                $('#txtDataAssumiuFJUAnterior').val(retornoCoordenador.DataEntradaCoordenador);
                $('#txtDataAssumiuFJUAnterior').prop('disabled', true);
                

                $('#txtMesAnoEntrevistaEstadual').val(retornoCoordenador.MesAnoEntrevistaEstadual);

                $('#txtNomeEstadualEntrevistou').val(retornoCoordenador.NomeEstadualEntrevistou);
                 
                if (retornoCoordenador.NomeTipoCoordenador != '') {
                    if (retornoCoordenador.NomeTipoCoordenador == 'Pastor')
                        $('#rbObreiroPastor_S').prop('checked', true);
                    else
                        $('#rbObreiroPastor_N').prop('checked', true);
                };

                if (retornoCoordenador.ConjugeEhObreiro != '') {
                    if (retornoCoordenador.ConjugeEhObreiro == 'S')
                        $('#rbConjugeEhObreiro_S').prop('checked', true);
                    else
                        $('#rbConjugeEhObreiro_N').prop('checked', true);
                };

                if (retornoCoordenador.PossuiFilhos != '') {
                    if (retornoCoordenador.PossuiFilhos == 'S')
                        $('#rbPossuiFilhos_S').prop('checked', true);
                    else
                        $('#rbPossuiFilhos_N').prop('checked', true);
                };

                if (retornoCoordenador.NamoraAtualmente != '') {
                    if (retornoCoordenador.NamoraAtualmente == 'S')
                        $('#rbNamorandoAtualmente_S').prop('checked', true);
                    else
                        $('#rbNamorandoAtualmente_N').prop('checked', true);
                };

                if (retornoCoordenador.GostaDeAlguem != '') {
                    if (retornoCoordenador.GostaDeAlguem == 'S')
                        $('#rbGostandoDeAlguem_S').prop('checked', true);
                    else
                        $('#rbGostandoDeAlguem_N').prop('checked', true);
                };

                if (retornoCoordenador.DesejaFazerObraNoAltar != '') {
                    if (retornoCoordenador.DesejaFazerObraNoAltar == 'S')
                        $('#rbDesejaFazerObraAltar_S').prop('checked', true);
                    else
                        $('#rbDesejaFazerObraAltar_N').prop('checked', true);
                };

                if (retornoCoordenador.FoiPastor != '') {
                    if (retornoCoordenador.FoiPastor == 'S')
                        $('#rbJaFoiPastoEsposaAntes_S').prop('checked', true);
                    else
                        $('#rbJaFoiPastoEsposaAntes_N').prop('checked', true);
                };

                if (retornoCoordenador.FoiEntrevistadoEstadualFJU != '') {
                    if (retornoCoordenador.FoiEntrevistadoEstadualFJU == 'S')
                        $('#rbEntrevistadoEstadualFJU_S').prop('checked', true);
                    else
                        $('#rbEntrevistadoEstadualFJU_N').prop('checked', true);
                };

            });
        }

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
                url: "api/Coordenadores/ArmazenaDataAlterada/",
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

        function atualizaDataAssumiuFJU() {
            var novaDataAssumiuFJU = new Date($('#txtNovaDataAssumiuFJU').val());
            var dataFormatada = novaDataAssumiuFJU.toLocaleDateString('pt-BR', { timeZone: 'UTC' });
            $('#txtDataAssumiuFJU').val(dataFormatada);

            //-----------------------------------------------------------------------------
            var jovemParametro = { DataEntradaCoordenador: dataFormatada };
            $.ajax({
                type: "POST",
                data: JSON.stringify(jovemParametro),
                url: "api/Coordenadores/ArmazenaDataAssumiurFJUAlterada/",
                contentType: "application/json"
            }).done(function (retorno) {
            });
            //-----------------------------------------------------------------------------

            swal({
                title: "Alteração",
                text: 'Data que assumiu FJU alterada com sucesso !!!',
                type: "success"
            });
            $('#alteraDataAssumiuFJU').modal('hide');
        }

        function mensagemConfirmacaoAtualizacao() {
            var msgConfirmacaoCadastro = "Realizada Atualização com sucesso";
            setTimeout(function () {
                swal({
                    title: "Coordenador Atualizado!",
                    text: msgConfirmacaoCadastro,
                    type: "success"
                }, function () {
                        window.location = "GerenciaCoordenadoresEstado.html";
                });
            }, 1000);
        }

        function mensagemErroInadequadoSistema() {
            var msgErro = "Sistema se comportou de forma inadequada!";
            swal({
                title: "Instabilidade no Sistema",
                text: msgErro,
                type: "error"
            });
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
        
    </script>
</body>
</html>
