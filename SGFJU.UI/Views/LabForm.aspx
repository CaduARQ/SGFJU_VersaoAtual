<%@ Page Title="" Language="C#" MasterPageFile="~/UI_App.Master" AutoEventWireup="true" CodeBehind="LabForm.aspx.cs" Inherits="SGFJU.UI.Views.LabForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/LabForm.css" rel="stylesheet" /> 
    <link href="../Styles/UI_App.css" rel="stylesheet" /> 
    

    <link rel="icon" type="image/png" sizes="14x14" href="../Images/favicon-16x16.png">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>


    <%--<telerik:RadWizard RenderMode="Lightweight" ID="RadWizard1" Width="100%" runat="server">
            <WizardSteps>
                

                <telerik:RadWizardStep Title="Passo da vitória"
                                       ID="rwsvitoria" 
                                       runat="server" 
                                       StepType="Step"
                    Height="520px" 
                               Culture="pt-BR"
                                       CausesValidation="true"
                                       ValidationGroup="firstValidationGroup">

                    <form class="form-horizontal">
                <fieldset>

                <!-- Formulário Informações Pessoais -->
                <legend>Informações Pessoais</legend>

                <!-- Nome input-->
                <div class="form-group">
                    <label class="col-md-4 control-label" for="nomeCompleto">Nome</label>  
                    <div class="col-md-8">
                        <input id="nomeCompleto" name="nomeCompleto" type="text" placeholder="Nome Completo" class="form-control input-md" required="">
                        <span class="help-block">Insira seu nome Completo sem abreviaturas</span>  
                    </div>
                </div>

                <!-- Gênero input Radios -->
                <div class="form-group">
                    <label class="col-md-4 control-label" for="sexo">Gênero</label>
                    <div class="col-md-4">
                        <div class="radio">
                            <label for="sexo-0">
                            <input type="radio" name="sexo" id="sexo-0" value="0">
                            Masculino
                            </label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                        <div class="radio">
                            <label for="sexo-1">
                            <input type="radio" name="sexo" id="sexo" value="1">
                            Feminino
                            </label>
                	    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    </div>
                </div>

<!-- Aniversário input-->
<div class="form-group">
  <label class="col-md-4 control-label" for="dthNascimento">Data de Nascimento</label>  
  <div class="col-md-5">
  <input id="dthNascimento" name="dthNascimento" type="text" placeholder="Data de Nascimento" class="form-control input-md" required="">
  <span class="help-block">Insira a data do seu nascimento</span>  
  </div>
</div>

<!-- Logradouro input-->
<div class="form-group">
  <label class="col-md-4 control-label" for="logradouro">Endereço</label>  
  <div class="col-md-6">
  <input id="logradouro" name="logradouro" type="text" placeholder="Endereço" class="form-control input-md">
  <span class="help-block">Insira somente o Logradouro</span>  
  </div>
</div>

<!-- Número input-->
<div class="form-group">
  <label class="col-md-4 control-label" for="numero">Número</label>  
  <div class="col-md-4">
  <input id="numero" name="numero" type="text" placeholder="Número" class="form-control input-md">
  <span class="help-block">Insira o número do domicílio</span>  
  </div>
</div>

<!-- Bairro input-->
<div class="form-group">
  <label class="col-md-4 control-label" for="bairro">Bairro</label>  
  <div class="col-md-6">
  <input id="bairro" name="bairro" type="text" placeholder="Bairro / Distrito" class="form-control input-md">
  <span class="help-block">Insira o Bairro ou Distrito do domicílio</span>  
  </div>
</div>

<!-- Complemento input-->
<div class="form-group">
  <label class="col-md-4 control-label" for="complemento">Complemento</label>  
  <div class="col-md-8">
  <input id="complemento" name="complemento" type="text" placeholder="Complemento" class="form-control input-md">
  <span class="help-block">Insira informações adicionais ao endereço</span>  
  </div>
</div>

<!-- Search CEP input-->
<div class="form-group">
  <label class="col-md-4 control-label" for="cep">CEP</label>
  <div class="col-md-4">
    <input id="cep" name="cep" type="search" placeholder="CEP / ZIPCODE" class="form-control input-md">
    <p class="help-block">Insira o código de postagem do domicílio</p>
  </div>
</div>
</fieldset>
</form>

                </telerik:RadWizardStep>

                <telerik:RadWizardStep Title="Passo da vitória"
                                       ID="rwsvitoria2" 
                                       runat="server" 
                                       StepType="Step"                    
                                       CausesValidation="true"
                                       ValidationGroup="firstValidationGroup">

                    <form class="form-horizontal">
                        <fieldset>

                        <!-- Formulário Informações Pessoais -->
                        <legend>Informações Pessoais</legend>

                            <!-- Nome input-->
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="nomeCompleto">Nome</label>  
                                <div class="col-md-8">
                                    <input id="nomeCompleto" name="nomeCompleto" type="text" placeholder="Nome Completo" class="form-control input-md" required="">
                                    <span class="help-block">Insira seu nome Completo sem abreviaturas</span>  
                                </div>
                            </div>

                            <!-- Gênero input Radios -->
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="sexo">Gênero</label>
                                <div class="col-md-4">
                                    <div class="radio">
                                        <label for="sexo-0">
                                        <input type="radio" name="sexo" id="sexo-0" value="0">
                                        Masculino
                                        </label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                    <div class="radio">
                                        <label for="sexo-1">
                                        <input type="radio" name="sexo" id="sexo" value="1">
                                        Feminino
                                        </label>
                	                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                </div>
                            </div>

                            <!-- Aniversário input-->
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="dthNascimento">Data de Nascimento</label>  
                                <div class="col-md-5">
                                <input id="dthNascimento" name="dthNascimento" type="text" placeholder="Data de Nascimento" class="form-control input-md" required="">
                                <span class="help-block">Insira a data do seu nascimento</span>  
                                </div>
                            </div>

                            <!-- Logradouro input-->
                            <div class="form-group">
                              <label class="col-md-4 control-label" for="logradouro">Endereço</label>  
                              <div class="col-md-6">
                              <input id="logradouro" name="logradouro" type="text" placeholder="Endereço" class="form-control input-md">
                              <span class="help-block">Insira somente o Logradouro</span>  
                              </div>
                            </div>


                        </fieldset>
                    </form>

                </telerik:RadWizardStep>

                <telerik:RadWizardStep Title="Passo seguinte"
                                       ID="rwsvitoria3" 
                                       runat="server" 
                                       StepType="Step"                    
                                       CausesValidation="true"
                                       ValidationGroup="firstValidationGroup">

                    <form class="form-horizontal">

                        <fieldset>

                            <legend>Informaçaões de Redes sociais e Endereço</legend>


                            <!-- Nome input-->
                            <div class="form-group">

                                <label class="col-md-4 control-label" for="nomeCompleto">Endereço</label>  

                                <div class="col-md-8">
                                    <input id="nomeCompleto" name="nomeCompleto" type="text" placeholder="Endereço ex: Rua da Vitória, 13" class="form-control input-md" required="">
                                    <span class="help-block">Insira seu nome Completo sem abreviaturas</span>  
                                </div>

                            </div>

                            <!-- Número input-->
                            <div class="form-group">

                              <label class="col-md-4 control-label" for="numero">Número</label>  

                              <div class="col-md-4">
                                  <input id="numero" name="numero" type="text" placeholder="Número" class="form-control input-md">
                                  <span class="help-block">Insira o número do domicílio</span>  
                              </div>

                            </div>

                            <!-- campo do formulário -->
                            <div class="form-group">

                              <label class="col-md-4 control-label" for="numero">Número</label>  

                              <div class="col-md-4">
                                  <input id="numero2" name="numero2" type="text" placeholder="Número 2" class="form-control input-md">
                                  <%--<telerik:RadTextBox ID="txtCidade" EmptyMessage="Preencha a cidade" CssClass="form-control input-md" runat="server" />--%>
                                  <span class="help-block">Insira o número do domicílio</span>  
                              </div>

                            </div>

                            <!-- campo do formulário -->
                            <div class="form-group">

                              <label class="col-md-4 control-label" for="numero">Número</label>  

                              <div class="col-md-4">
                                  <input id="numero3" name="numero3" type="text" placeholder="Número 3" class="form-control input-md">
                                  <%--<telerik:RadTextBox ID="txtCidade" EmptyMessage="Preencha a cidade" CssClass="form-control input-md" runat="server" />--%>
                                  <span class="help-block">Insira o número do domicílio</span>  
                              </div>

                            </div>

                            <!-- campo do formulário teste -->
                            <div class="input">
                                <input class="text-lower" name="username" type="text" autocomplete="off" placeholder="Usuário">                
                                <span class="help-block">Insira o número da vitória</span>  
                            </div>

                        </fieldset>

                    </form>

                </telerik:RadWizardStep>

                <telerik:RadWizardStep Title="Etapa teste 2 colunas"
                                       ID="rwsvitoria4" 
                                       runat="server" 
                                       StepType="Step"                    
                                       CausesValidation="true"
                                       ValidationGroup="firstValidationGroup">

                    <div class="container">


	                    <div class="row">

    	                    <form role="form">

                                <legend>Informaçaões de Redes sociais e Endereço</legend>

                                <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                    <label for="exampleInputEmail1">Email address</label>
                                    <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Enter email">
                                    <%--<telerik:RadTextBox ID="txtCidade" EmptyMessage="Preencha a cidade" CssClass="form-control" runat="server" />--%>
                                    <span class="help-block">Insira seu e-mail corretamente</span>  
                                </div>

                                <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                    <label for="exampleInputEmail1">Name</label>
                                    <input type="text" class="form-control" id="exampleInputEmail1" placeholder="Enter Name">
                                </div>

                                <div class="clearfix"></div>

                                <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                    <label for="exampleInputPassword1">Password</label>
                                    <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">
                                </div>

                                <div class="form-group col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                    <label for="exampleInputPassword1">Confirm Password</label>
                                    <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Confirm Password">
                                </div>

                                <div class="clearfix"></div>

                                <div class="form-group col-xs-10 col-sm-10 col-md-4 col-lg-4">
                                    <label for="exampleInputFile">File input</label>
                                    <input type="file" id="exampleInputFile">
                                    <p class="help-block">Example block-level help text here.</p>
                                </div>

                                <div class="col-xs-10 col-sm-10 col-md-4 col-lg-4">
                                    <label>
                                        <input type="radio"> Check me out<input type="radio"> Check me out<input type="radio"> Check me out
                                    </label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                </div>
                                <div class="clearfix"></div>
                                <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                    <button type="submit" class="btn btn-default">Submit</button>
                                </div>
                          </form>

                            <div class="clearfix">

                            </div>

                            <br />
                            <br />
	                    </div>


                    </div>

                </telerik:RadWizardStep>

                <telerik:RadWizardStep Title="Etapa teste 3 colunas"
                                       ID="rwsvitoria5" 
                                       runat="server" 
                                       StepType="Step"                    
                                       CausesValidation="true"
                                       ValidationGroup="firstValidationGroup">

                    <div class="container-fluid bg-light py-3">

                        <form id="contact-form" method="post" role="form">

                            <div class="messages"></div>

                            <div class="controls">

                                <div class="row">

                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label for="form_name">Name *</label>
                                            <input id="form_name" type="text" name="surname" class="form-control" placeholder="Please enter your name *" required="required" data-error="name is required.">
                                            <div class="help-block with-errors"></div>
                                        </div>
                                    </div>

                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label for="form_email">Email *</label>
                                            <input id="form_email" type="email" name="email" class="form-control" placeholder="Please enter your email *" required="required" data-error="Valid email is required.">
                                            <div class="help-block with-errors"></div>
                                        </div>
                                    </div>

                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label for="form_phone">Phone</label>
                                            <input id="form_phone" type="tel" name="phone" class="form-control" placeholder="Please enter your phone number">
                                            <div class="help-block with-errors"></div>
                                        </div>
                                    </div>

                                </div>

                            </div>

                            <!-- teste begin -->
                            <div class="clearfix"></div>

                            <div class="row">

                                <div class="col-sm-4">
                                        <div class="form-group">
                                            <label for="form_name">Name *</label>
                                            <input id="form_name" type="text" name="surname" class="form-control" placeholder="Please enter your name *" required="required" data-error="name is required.">
                                            <div class="help-block with-errors"></div>
                                        </div>
                                    </div>

                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label for="form_email">Email *</label>
                                            <input id="form_email" type="email" name="email" class="form-control" placeholder="Please enter your email *" required="required" data-error="Valid email is required.">
                                            <div class="help-block with-errors"></div>
                                        </div>
                                    </div>

                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label for="form_phone">Phone</label>
                                            <input id="form_phone" type="tel" name="phone" class="form-control" placeholder="Please enter your phone number">
                                            <div class="help-block with-errors"></div>
                                        </div>
                                    </div>

                            </div>

                            <!-- end teste- -->
                            <div class="clearfix"></div>

                            <div class="row">

                                <div class="col-sm-4">
                                        <div class="form-group">
                                            <label for="form_name">Name *</label>
                                            <input id="form_name" type="text" name="surname" class="form-control" placeholder="Please enter your name *" required="required" data-error="name is required.">
                                            <div class="help-block with-errors"></div>
                                        </div>
                                    </div>

                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label for="form_email">Email *</label>
                                            <input id="form_email" type="email" name="email" class="form-control" placeholder="Please enter your email *" required="required" data-error="Valid email is required.">
                                            <div class="help-block with-errors"></div>
                                        </div>
                                    </div>

                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label for="form_phone">Phone</label>
                                            <input id="form_phone" type="tel" name="phone" class="form-control" placeholder="Please enter your phone number">
                                            <div class="help-block with-errors"></div>
                                        </div>
                                    </div>

                            </div>

                            <div class="clearfix"></div>

                            <div class="row">

                                <div class="col-sm-4">
                                        <div class="form-group">
                                            <label for="form_name">Name *</label>
                                            <input id="form_name" type="text" name="surname" class="form-control" placeholder="Please enter your name *" required="required" data-error="name is required.">
                                            <div class="help-block with-errors"></div>
                                        </div>
                                    </div>

                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label for="form_email">Email *</label>
                                            <input id="form_email" type="email" name="email" class="form-control" placeholder="Please enter your email *" required="required" data-error="Valid email is required.">
                                            <div class="help-block with-errors"></div>
                                        </div>
                                    </div>

                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label for="form_phone">Phone</label>
                                            <input id="form_phone" type="tel" name="phone" class="form-control" placeholder="Please enter your phone number">
                                            <div class="help-block with-errors"></div>
                                        </div>
                                    </div>

                            </div>

                            <div class="clearfix"></div>


                            <div class="row">

                                <div class="col-md-12">

                                    <div class="form-group">
                                        <label for="form_message">Message *</label>
                                        <textarea id="form_message" name="message" class="form-control" placeholder="Message for me *" rows="4" required="required" data-error="send a message."></textarea>
                                        <div class="help-block with-errors"></div>
                                    </div>

                                </div>

                                <div class="col-md-12">
                                    <input type="submit" class="btn btn-warning btn-send" value="Send message">
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <p class="text-muted"><strong>*</strong> These fields are required.</p>
                                </div>
                            </div>

                        </form>

                    </div>


                </telerik:RadWizardStep>

            </WizardSteps>
        </telerik:RadWizard>--%>


</asp:Content>
