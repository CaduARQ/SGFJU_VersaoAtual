<%@ Page Title="" Language="C#" MasterPageFile="~/UI_App.Master" AutoEventWireup="true" CodeBehind="teste.aspx.cs" Inherits="SGFJU.UI.teste" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <div class="demo-container">
        <div class="wizardHeader"></div>

        <telerik:RadWizard RenderMode="Lightweight" 
                           ID="RadWizard1" 
                           runat="server"  
                           Height="420px" Culture="pt-BR" Skin="WebBlue" OnFinishButtonClick="RadWizard1_FinishButtonClick" >
            <WizardSteps>

                <telerik:RadWizardStep ID="stepStart" 
                                       Title="Dados iniciais" 
                                       runat="server" 
                                       StepType="Start" 
                                       CausesValidation="true" >
                    <div id="divDadosIniciais">
                        <table border="0" cellspacing="0" cellpadding="0" id="tbl1" class="txt1">
														<tr>
															<td class="auto-style17" ><div align="right">Nome:
																</div>
															</td>
															<td class="auto-style18">
																&nbsp;&nbsp;
																<telerik:RadTextBox id="txtNome" runat="server" Width="212px" 
                                                                    ></telerik:RadTextBox></td>
                                                            
															<td class="auto-style19">
																<div align="right">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Data de Nascimento</div>
															</td>
															<td class="auto-style17">
																
                                                                </td>
															<td class="auto-style20">
																
                                                                <telerik:RadDateInput ID="txtDataBatismoEspiritoSanto" Runat="server" Skin="WebBlue" Width="110px">
                                                                </telerik:RadDateInput>
																
                                                            </td>
															<td class="auto-style21">
																
																&nbsp;</td>
															<td class="auto-style17">
																
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td class="auto-style2">
                                                                <div align="right">Estado:
																</div>
															</td>
															<td class="auto-style3">
                                                                
                                                                &nbsp;&nbsp;
                                                                
                                                                <telerik:RadDropDownList ID="cboEstado" 
                                                                    runat="server" 
                                                                    Height="16px" 
                                                                    Width="210px"
                                                                    Skin="WebBlue" 
                                                                    AutoPostBack="True">
                                                                </telerik:RadDropDownList>
                                                                
                                                            </td>
															<td class="auto-style10">
															    <div align="right">

                                                                    Bloco</div>
                                                            </td>

                                                            <td class="auto-style2">
                                                                
                                                                &nbsp;</td>

                                                            <td class="auto-style16">
                                                                
                                                                <telerik:RadDropDownList ID="cboBloco" 
                                                                                         runat="server" 
                                                                                         Height="17px" 
                                                                                         Width="210px" 
                                                                                         Skin="WebBlue" 
                                                                                         AutoPostBack="True">
                                                                </telerik:RadDropDownList>
                                                                
																</td>

                                                            <td class="auto-style14">
                                                                
                                                                &nbsp;</td>

                                                            <td class="auto-style2">
                                                                
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td class="auto-style2"><div align="right">Região:
																</div>
															</td>
															<td class="auto-style3">
                                                                &nbsp;&nbsp;
                                                                <telerik:RadDropDownList ID="cboRegiao" 
                                                                                         runat="server" 
                                                                                         Height="21px" 
                                                                                         Width="210px" 
                                                                                         Skin="WebBlue" 
                                                                                         AutoPostBack="True">
                                                                </telerik:RadDropDownList>
                                                            </td>
															<td class="auto-style10" >
															    &nbsp;
															    <div align="right">

                                                                    Igreja</div>

                                                                </td>

                                                            <td class="auto-style2">
																&nbsp;</td>

                                                            <td class="auto-style16">
                                                                <telerik:RadDropDownList ID="cboIgreja" 
                                                                                            runat="server" 
                                                                                            Width="210px" 
                                                                                            Skin="WebBlue">
                                                                </telerik:RadDropDownList>
                                                            </td>

                                                            <td class="auto-style14">
																&nbsp;</td>

                                                            <td class="auto-style2">
																
                                                                &nbsp;</td>
														</tr>
														</table>
                    </div>
                </telerik:RadWizardStep>
                <telerik:RadWizardStep ID="stepEndereçoRS" 
                                       Title="Ende. Redes Sociais" 
                                       runat="server" 
                                       StepType="Step" 
                                       CausesValidation="true" >
                    <div id="divEndeRedeSocial" class="txt1">
                        <table border="0" cellspacing="0" cellpadding="0" id="tbl1" class="auto-style11">
														<tr>
															<td background="../images/top_tit.jpg" class="txt2"><div align="right">Whatsapp:
																</div>
															</td>
															<td class="auto-style28">
																&nbsp;&nbsp;
																																
                                                                <telerik:RadTextBox ID="txtNumeroWhats" 
                                                                                    runat="server" 
                                                                                    Skin="WebBlue" 
                                                                                    InputType="Tel" >
                                                                </telerik:RadTextBox>
																<img src="../Images/logoWhats.png" border="0"  height="20px" width="20px" /></td>
                                                            
															<td background="../images/top_tit.jpg" class="txt2">
																<div align="right">Tel. Fixo
																</div>
															</td>
															<td class="auto-style30">
																
                                                                </td>
															<td class="auto-style31">
																
                                                                <telerik:RadTextBox ID="txtTelefoneFixo" 
                                                                                    runat="server" 
                                                                                    Skin="WebBlue" 
                                                                                    InputType="Tel" >
                                                                </telerik:RadTextBox>
																
                                                                </td>
															<td class="auto-style22">
																
																
															</td>
															<td class="auto-style30">
																
                                                                </td>
														</tr>
														<tr>
															<td background="../images/top_tit.jpg" class="txt2"><div align="right" class="auto-style36">Telefone de emergência:
																</div>
															</td>
															<td class="auto-style18">
																
                                                                &nbsp;&nbsp;
																
                                                                <telerik:RadTextBox ID="txtTelefoneEmergencia" 
                                                                                    runat="server" 
                                                                                    Skin="WebBlue" 
                                                                                    InputType="Tel" >
                                                                </telerik:RadTextBox>
																
                                                                </td>
															<td background="../images/top_tit.jpg" class="txt2">
																<div align="right">&nbsp;Falar com:</div>
															</td>
															<td class="auto-style20">
																
                                                                </td>
															<td class="auto-style21">
																
                                                                <telerik:RadTextBox ID="txtContatoEmergencia" 
                                                                                    runat="server" 
                                                                                    Skin="WebBlue" 
                                                                                    InputType="Tel" >
                                                                </telerik:RadTextBox>
																
                                                                </td>
															<td class="auto-style27">
																
																
															</td>
															<td class="auto-style20">
																
                                                                </td>
														</tr>														
														<tr>
															<td background="../images/top_tit.jpg" class="txt2">
                                                                <div align="right">Endereço:
																</div>
															</td>
															<td class="auto-style3">
                                                                
                                                                &nbsp;&nbsp;
                                                                
                                                                <telerik:RadTextBox ID="txtEnhdereco" 
                                                                                    runat="server" 
                                                                                    Skin="WebBlue" 
                                                                                    InputType="Tel" >
                                                                </telerik:RadTextBox>
                                                                
                                                                </td>
															<td background="../images/top_tit.jpg" class="txt2">
															    <div align="right">
                                                                    Cidade
															    </div>
                                                            </td>

                                                            <td class="auto-style2">
                                                                
                                                                &nbsp;</td>

                                                            <td class="auto-style16">
                                                                
                                                                <telerik:RadTextBox ID="txtCidade" 
                                                                                    runat="server" 
                                                                                    Skin="WebBlue" 
                                                                                    InputType="Tel" >
                                                                </telerik:RadTextBox>
																</td>

                                                            <td class="auto-style14">
                                                                
                                                                &nbsp;</td>

                                                            <td class="auto-style2">
                                                                
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td background="../images/top_tit.jpg" class="txt2">
                                                                <div align="right">&nbsp;Bairro:
																</div>
															</td>
															<td class="auto-style40">
                                                                
                                                                &nbsp;&nbsp;
                                                                
                                                                <telerik:RadTextBox ID="txtBairro" 
                                                                                    runat="server" 
                                                                                    Skin="WebBlue" 
                                                                                    InputType="Tel" >
                                                                </telerik:RadTextBox>
                                                                
                                                                </td>
															<td background="../images/top_tit.jpg" class="txt2">
															    <div align="right">
                                                                    Estado:
															    </div>&nbsp;
															    </td>
															<td class="auto-style41">
																</td>
															<td class="auto-style42">
																<telerik:RadDropDownList ID="RadDropDownList1"                                                                     
                                                                                         runat="server" 
                                                                                         Skin="WebBlue" 
                                                                                         Height="16px" Width="120px">
                                                                    <Items>
                                                                        <telerik:DropDownListItem runat="server" Text="Rio de Janeiro" Value="1"  />
                                                                        <telerik:DropDownListItem runat="server" Text="São Paulo" Value="2" />
                                                                    </Items>
                                                                </telerik:RadDropDownList>

															</td>
															<td class="auto-style43">
																</td>
															<td class="auto-style41">
																
                                                                </td>
														</tr>
														<tr>
															<td background="../images/top_tit.jpg" class="txt2">
                                                                <div align="right">Mora com quem?
																</div>
															</td>
															<td colspan="5">
															    <telerik:RadRadioButtonList ID="rbTipoMoradia" 
                                                                                                runat="server" 
                                                                                                Text="Sim" 
                                                                                                Direction="Horizontal" 
                                                                                                SelectedIndex="0" 
                                                                                                SelectedValue="0" 
                                                                                                Width="472px" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem  Text="Sozinho" Value="0" />
                                                                        <telerik:ButtonListItem Text="Família" Value="1" />
                                                                        <telerik:ButtonListItem Text="Amigo" Value="1" />
                                                                        <telerik:ButtonListItem Text="Hostel/Albergue" Value="1" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                           </td>

                                                            <td>
																
                                                                </td>
														</tr>
														<tr>
															<td height="12" class="auto-style23">&nbsp;</td>
															<td class="auto-style1">
                                                                &nbsp;&nbsp;
                                                                </td>
															<td class="auto-style9">

															    <span id="lblChurchName" />
                                                            </td>

                                                            <td>
                                                                &nbsp;</td>

                                                            <td class="auto-style15">
																&nbsp;</td>

                                                            <td class="auto-style13">
																&nbsp;</td>

                                                            <td>
																&nbsp;</td>
														</tr>
														<tr>
															<td height="12"  background="../images/top_tit.jpg" class="txt2">
															    <div align="right">

                                                                    Instagram</div>

															</td>
															<td class="auto-style1">
                                                                &nbsp;
																
                                                                &nbsp;
                                                            																
                                                                <telerik:RadTextBox ID="txtInstagram" 
                                                                                    runat="server" 
                                                                                    Skin="WebBlue" 
                                                                                    InputType="Tel" >
                                                                </telerik:RadTextBox>
																
                                                            </td>
															<td  background="../images/top_tit.jpg" class="txt2">
															    <div align="right">

                                                                    Facebook</div>

                                                            </td>

                                                            <td>
                                                                &nbsp;&nbsp; &nbsp;</td>

                                                            <td class="auto-style15">
																
                                                                <telerik:RadTextBox ID="txtFacebook" 
                                                                                    runat="server" 
                                                                                    Skin="WebBlue" 
                                                                                    InputType="Tel" >
                                                                </telerik:RadTextBox>
																
                                                                <br />
                                                            </td>

                                                            <td class="auto-style13">
                                                                &nbsp;</td>

                                                            <td>
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td height="12" background="../images/top_tit.jpg" class="txt2">
															    <div align="right">

                                                                    E-mail</div>

															</td>
															<td class="auto-style1">
																
                                                                <telerik:RadTextBox ID="txtEmail" 
                                                                                    runat="server" 
                                                                                    Skin="WebBlue" 
                                                                                    InputType="Tel" >
                                                                </telerik:RadTextBox>
																
                                                            </td>
															<td background="../images/top_tit.jpg" class="txt2">
															    <div align="right">

                                                                    Twitter</div>

                                                            </td>

                                                            <td>
                                                                &nbsp;</td>

                                                            <td class="auto-style15">
																
                                                                <telerik:RadTextBox ID="txtTwitter" 
                                                                                    runat="server" 
                                                                                    Skin="WebBlue" 
                                                                                    InputType="Tel" >
                                                                </telerik:RadTextBox>
																
                                                            </td>

                                                            <td class="auto-style13">
                                                                &nbsp;</td>

                                                            <td>
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td height="12" class="auto-style23">
															    &nbsp;</td>
															<td class="auto-style1">
                                                                &nbsp;</td>
															<td class="auto-style9">
															    &nbsp;</td>

                                                            <td>
                                                                &nbsp;</td>

                                                            <td class="auto-style15">
                                                                &nbsp;</td>

                                                            <td class="auto-style13">
                                                                &nbsp;</td>

                                                            <td>
                                                                &nbsp;</td>
														</tr>
													</table>
                    </div>
                </telerik:RadWizardStep>
                <telerik:RadWizardStep ID="stepDadosCivisProfissionais" 
                                       Title="Dados civis e profissionais" 
                                       runat="server" 
                                       StepType="Step" 
                                       CausesValidation="true" >
                    <div id="divDadosCivisProfissionais" class="txt1">
                        <table border="0" cellspacing="0" cellpadding="0" id="tbl3" class="auto-style11">
														<tr>
															<td class="txt1"><div align="right">
                                                                Estado Civil:
																</div>
															</td>
															<td colspan="6">
																&nbsp;&nbsp;<telerik:RadRadioButtonList ID="rbTipoMoradia1" 
                                                                                                runat="server" 
                                                                                                Text="Sim" 
                                                                                                Direction="Horizontal" 
                                                                                                SelectedIndex="0" 
                                                                                                SelectedValue="0" 
                                                                                                Width="472px" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Selected="True" Text="Solteiro(a)" Value="0" />
                                                                        <telerik:ButtonListItem Text="Casado(a)" Value="1" />
                                                                        <telerik:ButtonListItem Text="Divorciado(a)" Value="1" />
                                                                        <telerik:ButtonListItem Text="Viúvo(a)" Value="1" />
                                                                        <telerik:ButtonListItem Text="Morando junto" Value="1" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                           &nbsp;</td>
                                                            
														</tr>
														<tr>
															<td class="txt1"><div align="right" class="auto-style36">
                                                                Nome Cônjuge:
																</div>
															</td>
															<td class="auto-style18">
																
                                                                &nbsp;&nbsp;
																
                                                                <telerik:RadTextBox ID="txtNomeconjuge" 
                                                                                    runat="server" 
                                                                                    Skin="WebBlue" 
                                                                                    InputType="Tel" >
                                                                </telerik:RadTextBox>
																
                                                                </td>
															<td class="txt1">
																<div align="right">&nbsp;Data casamento:</div>
															</td>
															<td class="auto-style20">
																
                                                                </td>
															<td class="auto-style44">
																
                                                                <telerik:RadDateInput ID="txtDataCasamento" Runat="server" Skin="WebBlue" Width="110px">
                                                                </telerik:RadDateInput>
																
                                                                </td>
															<td class="auto-style27">
																
																
															</td>
															<td class="auto-style20">
																
                                                                </td>
														</tr>														
														<tr>
															<td class="txt1">
                                                                <div align="right">Cônjuge é da igreja?:
																</div>
															</td>
															<td class="auto-style3">
                                                                
                                                                &nbsp;&nbsp;
                                                                
                                                                <telerik:RadRadioButtonList ID="rbConjugeCasado" 
                                                                                                runat="server" 
                                                                                                Text="Sim" 
                                                                                                Direction="Horizontal" 
                                                                                                SelectedIndex="0" 
                                                                                                SelectedValue="0" 
                                                                                                Width="109px" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Selected="True" Text="Sim" Value="0" />
                                                                        <telerik:ButtonListItem Text="Não" Value="1" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                           

															</td>
															<td class="txt1">
															    <div align="right">
                                                                    Possui filhos?
															    </div>
                                                            </td>

                                                            <td class="auto-style2">
                                                                
                                                                &nbsp;</td>

                                                            <td class="auto-style45">
                                                                
                                                                <telerik:RadRadioButtonList ID="rbPossuiFilhos" 
                                                                                                runat="server" 
                                                                                                Text="Sim" 
                                                                                                Direction="Horizontal" 
                                                                                                SelectedIndex="0" 
                                                                                                SelectedValue="0" 
                                                                                                Width="109px" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Selected="True" Text="Sim" Value="0" />
                                                                        <telerik:ButtonListItem Text="Não" Value="1" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                           

																</td>

                                                            <td class="auto-style14">
                                                                
                                                                 Quantos?
                                                                 <telerik:RadTextBox ID="txtQtdFilhos" runat="server" Width="30px" />
                                                                
                                                                 </td>

                                                            <td class="auto-style2">
                                                                
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td class="txt1">
                                                                &nbsp;</td>
															<td class="auto-style3">
                                                                
                                                                &nbsp;</td>
															<td class="txt1">
															    &nbsp;</td>

                                                            <td class="auto-style2">
                                                                
                                                                &nbsp;</td>

                                                            <td class="auto-style45">
                                                                
                                                                &nbsp;</td>

                                                            <td class="auto-style14">
                                                                
                                                                 &nbsp;</td>

                                                            <td class="auto-style2">
                                                                
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td class="txt1">
                                                                <div align="right">&nbsp;Trabalha?
																</div>
															</td>
															<td class="auto-style40">
                                                                
                                                                &nbsp;&nbsp;
                                                                
                                                                <telerik:RadRadioButtonList ID="rbTrabalha" 
                                                                                                runat="server" 
                                                                                                Text="Sim" 
                                                                                                Direction="Horizontal" 
                                                                                                SelectedIndex="0" 
                                                                                                SelectedValue="0" 
                                                                                                Width="131px" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Selected="True" Text="Sim" Value="0" />
                                                                        <telerik:ButtonListItem Text="Não" Value="1" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
                                                                </td>
															<td class="txt1">
															    <div align="right">
                                                                    Estuda?
															    </div>&nbsp;
															    </td>
															<td class="auto-style41">
																</td>
															<td class="auto-style46">
																
															    <telerik:RadRadioButtonList ID="rbEstuda" 
                                                                                                runat="server" 
                                                                                                Text="Sim" 
                                                                                                Direction="Horizontal" 
                                                                                                SelectedIndex="0" 
                                                                                                SelectedValue="0" 
                                                                                                Width="131px" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Selected="True" Text="Sim" Value="0" />
                                                                        <telerik:ButtonListItem Text="Não" Value="1" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
																
															</td>
															<td class="auto-style43">
																</td>
															<td class="auto-style41">
																
                                                                </td>
														</tr>
														<tr>
															<td class="txt1">
                                                                <div align="right">Profissão
																</div>
															</td>
															<td class="auto-style40">
                                                                
															    &nbsp;&nbsp;&nbsp;&nbsp;
																
                                                                <telerik:RadTextBox ID="txtProfissao" 
                                                                                    runat="server" 
                                                                                    Skin="WebBlue" 
                                                                                    InputType="Tel" >
                                                                </telerik:RadTextBox>
																
                                                            </td>
															<td class="txt1">
															    
                                                                <div align="right">
                                                                    Grau:
                                                                </div>
															</td>
															<td class="auto-style41">
																&nbsp;</td>
															<td class="auto-style46">
																
                                                                <telerik:RadTextBox ID="txtGrau" 
                                                                                    runat="server" 
                                                                                    Skin="WebBlue" 
                                                                                    InputType="Tel" >
                                                                </telerik:RadTextBox>
																
															</td>
															<td class="auto-style43">
																&nbsp;</td>
															<td class="auto-style41">
																
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td height="12"  class="txt1">
															    <div align="right">

                                                                    Empresa</div>

															</td>
															<td class="auto-style1">
                                                                &nbsp;
																
                                                                &nbsp;
                                                            																
                                                                <telerik:RadTextBox ID="txtEmpresa" 
                                                                                    runat="server" 
                                                                                    Skin="WebBlue" 
                                                                                    InputType="Tel" >
                                                                </telerik:RadTextBox>
																
                                                            </td>
															<td class="txt1">
															    <div align="right">

                                                                    Onde estuda</div>

                                                            </td>

                                                            <td>
                                                                &nbsp;&nbsp; &nbsp;</td>

                                                            <td class="auto-style47">
																
                                                                <telerik:RadTextBox ID="txtOndeEstuda" 
                                                                                    runat="server" 
                                                                                    Skin="WebBlue" 
                                                                                    InputType="Tel" >
                                                                </telerik:RadTextBox>
																
                                                                <br />
                                                            </td>

                                                            <td class="auto-style13">
                                                                &nbsp;</td>

                                                            <td>
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td height="12"class="txt1">
															    <div align="right">

                                                                    Tem título de eleitor?</div>

															</td>
															<td class="auto-style1">
																
                                                                &nbsp;&nbsp;
                                                                
                                                                <telerik:RadRadioButtonList ID="rbPossuiTituloeleitor" 
                                                                                                runat="server" 
                                                                                                Text="Sim" 
                                                                                                Direction="Horizontal" 
                                                                                                SelectedIndex="0" 
                                                                                                SelectedValue="0" 
                                                                                                Width="131px" >
                                                                    <Items>
                                                                        <telerik:ButtonListItem Selected="True" Text="Sim" Value="0" />
                                                                        <telerik:ButtonListItem Text="Não" Value="1" />
                                                                    </Items>
                                                                </telerik:RadRadioButtonList>
                                                                
                                                                &nbsp;</td>
															<td class="txt1">
															    <div align="right">

                                                                    Grau instrução</div>

                                                            </td>

                                                            <td>
                                                                &nbsp;</td>

                                                            <td class="auto-style47">
																
                                                                <telerik:RadTextBox ID="txtGrauInstrucao" 
                                                                                    runat="server" 
                                                                                    Skin="WebBlue" 
                                                                                    InputType="Tel" >
                                                                </telerik:RadTextBox>
																
                                                            </td>

                                                            <td class="auto-style13">
                                                                &nbsp;</td>

                                                            <td>
                                                                &nbsp;</td>
														</tr>
														<tr>
															<td height="12" class="auto-style23">
															    &nbsp;</td>
															<td class="auto-style1">
                                                                &nbsp;</td>
															<td class="auto-style9">
															    &nbsp;</td>

                                                            <td>
                                                                &nbsp;</td>

                                                            <td class="auto-style47">
                                                                &nbsp;</td>

                                                            <td class="auto-style13">
                                                                &nbsp;</td>

                                                            <td>
                                                                &nbsp;</td>
														</tr>
													</table>
                    </div>
                </telerik:RadWizardStep>
                <telerik:RadWizardStep ID="stepDadosEspirituais" 
                                       Title="Dados espirituais" 
                                       runat="server" 
                                       StepType="Step" 
                                       CausesValidation="true" >
                </telerik:RadWizardStep>
                <telerik:RadWizardStep ID="stepSituacaoIURD_FJU" 
                                       Title="Situação IURD e FJU" 
                                       runat="server" 
                                       StepType="Step" 
                                       CausesValidation="true" >
                </telerik:RadWizardStep>                
                <telerik:RadWizardStep ID="stepProjetos" 
                                       Title="Projetos FJU" 
                                       runat="server" 
                                       StepType="Step" 
                                       CausesValidation="true" >
                </telerik:RadWizardStep>
                <telerik:RadWizardStep ID="stepIdiomas" 
                                       Title="Idiomas" 
                                       runat="server" 
                                       StepType="Step" 
                                       CausesValidation="true" >
                </telerik:RadWizardStep>
                <telerik:RadWizardStep ID="stepOutros" 
                                       Title="Outros" 
                                       runat="server" 
                                       StepType="Step" 
                                       CausesValidation="true" >
                </telerik:RadWizardStep>
                <telerik:RadWizardStep ID="stepTestemunho" 
                                       Title="Testemunho" 
                                       runat="server" 
                                       StepType="Step" 
                                       CausesValidation="true" >
                </telerik:RadWizardStep>
                <telerik:RadWizardStep ID="stepSugestao" 
                                       Title="Sugestão" 
                                       runat="server" 
                                       StepType="Complete" 
                                       CausesValidation="true" >
                </telerik:RadWizardStep>
            </WizardSteps>
        </telerik:RadWizard>

    </div>


</asp:Content>
