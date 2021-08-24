<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmRegistraRegioesSemMaster.aspx.cs" Inherits="SGFJU.UI.Views.frmRegistraRegioesSemMaster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    
    <telerik:RadAjaxManager runat="Server" 
                            ID="RadAjaxManager1" >
        <AjaxSettings>                            			    
            <telerik:AjaxSetting AjaxControlID="cboEstado">
				<UpdatedControls>					    
                    <telerik:AjaxUpdatedControl ControlID="cboBloco" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdTodasRegioes" LoadingPanelID="RadAjaxLoadingPanel1" />
				</UpdatedControls>
			</telerik:AjaxSetting>        
            <telerik:AjaxSetting AjaxControlID="grdTodasRegioes">
				<UpdatedControls>					    
                    <telerik:AjaxUpdatedControl ControlID="cboEstado" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="cboBloco" LoadingPanelID="RadAjaxLoadingPanel1" />
				</UpdatedControls>
			</telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>

    <telerik:RadAjaxLoadingPanel runat="server" ID="RadAjaxLoadingPanel1" >
	    </telerik:RadAjaxLoadingPanel>

    <telerik:RadWindowManager ID="rwmUIApp" Skin="WebBlue" runat="server" />

    <form class="form-horizontal">

        <legend>Informações sobre Nova Região </legend>

        <div class="form-group">
            <label class="col-md-4 control-label" for="nomeRegiao">Nome Da nova Região</label>  
            <div class="col-md-8">
                <input id="nomeRegiao" name="nomeRegiao" type="text" placeholder="Nome da Região" class="form-control input-md" required="">
                <span class="help-block">Insira o nome da Região</span>  
            </div>
        </div>

        <div class="form-group">
            <label class="col-md-4 control-label" for="nomeRegiao">Estado</label>  
            <div class="col-md-8">
                <telerik:RadComboBox ID="cboEstado" 
                                    runat="server" 
                                    AutoPostBack="true" 
                                    Height="100px" 
                                    OnSelectedIndexChanged="cboEstado_SelectedIndexChanged"
                                    Skin="Bootstrap" 
                                    Width="280px" />
                <span class="help-block">Selecione o estado, logo em seguida bloco à qual região pertence</span>  
            </div>
        </div>

        <div class="form-group">
            <label class="col-md-4 control-label" for="nomeRegiao">Bloco</label>  
            <br />
            <div class="col-md-8">
                <telerik:RadComboBox ID="cboBloco" 
                                     runat="server" 
                                     AutoPostBack="true" 
                                     Height="100px" 
                                     Skin="Bootstrap" 
                                     Width="280px"></telerik:RadComboBox>
                <span class="help-block">Selecione o bloco, à qual região pertence</span>  
            </div>
        </div>

        <div class="form-group">            
            <div class="col-md-8">
                <telerik:RadButton ID="btnCadastraRegiao" runat="server" Skin="Bootstrap" Text="Cadastrar Região" />
                <%--<span class="help-block">Selecione o bloco, à qual região pertence</span>  --%>
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-8">
                <telerik:RadGrid runat="server" 
                                ID="grdTodasRegioes" 
                                AutoGenerateColumns="False" 
                                Height="300px"
                                Skin="Bootstrap"
                                EnableViewState="False" 
                                AllowPaging="True" Culture="pt-BR" OnPageIndexChanged="grdTodasRegioes_PageIndexChanged" PageSize="7"               >
                <GroupingSettings ShowUnGroupButton="true"></GroupingSettings>
                    <ExportSettings>
                        <Pdf PageWidth="">
                        </Pdf>
                    </ExportSettings>
                <ClientSettings 
                                EnableRowHoverStyle="true" 
                                AllowKeyboardNavigation="false">
                    <Scrolling AllowScroll="false" UseStaticHeaders="true" />
                    <Selecting AllowRowSelect="true" />
                </ClientSettings>                                                      
                <MasterTableView>
                    <Columns>
                        <telerik:GridBoundColumn DataField="BlocoRegiao.NomeBloco" UniqueName="Nome" HeaderText="Bloco" HeaderStyle-Width="200px" >
                            <HeaderStyle Width="200px"></HeaderStyle>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NomeRegiao" UniqueName="NomeRegiao" HeaderText="Nome da Região" ItemStyle-CssClass="subject" >
                            <ItemStyle CssClass="subject"></ItemStyle>
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
            </div>
        </div>

    </form>
</body>
</html>
