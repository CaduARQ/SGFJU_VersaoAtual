<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="tempPage.aspx.cs" Inherits="SGFJU.UI.Views.tempPage" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register assembly="Telerik.Web.Design" namespace="Telerik.Web.Design" tagprefix="design" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
    <link href="../Styles/UI_App.css" rel="stylesheet" />    

    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>    
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FolderContent" runat="server">           
    <nav:FolderNavigationControl runat="server" ID="FolderNavigationControl" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    

    <style type="text/css">
        
        .txt1 {
	        font-family: Verdana, Arial, Helvetica, sans-serif;
	        font-size: 9px;
	        font-style: normal;
	        line-height: normal;
	        font-weight: bold;
	        font-variant: normal;
	        text-transform: none;
	        color: #003366;
        }
        .txt2 {

	        font-family: Verdana, Arial, Helvetica, sans-serif;
	        font-size: 9px;
	        font-style: normal;
	        line-height: normal;
	        font-weight: bold;
	        font-variant: normal;
	        text-transform: none;	
	        color: #FFFFFF;
        }
        .txt3 {


	        font-family: Verdana, Arial, Helvetica, sans-serif;
	        font-size: 9px;
	        font-style: normal;
	        line-height: normal;
	        font-weight: normal;
	        font-variant: normal;
	        text-transform: none;
	        color: #003366;
        }
        .txt4 {
            font-family: OutlookSampleApp;
	        font-size: 14px;
	        font-style: normal;
	        line-height: normal;
	        font-weight: bold;
	        font-variant: normal;
	        text-transform: none;
	        color: #003366;
        }
        .txtConfirmacao {            
	        font-family: OutlookSampleApp;
	        font-size: 16px;
	        font-style: normal;
	        line-height: normal;
	        font-weight: bold;
	        font-variant: normal;
	        text-transform: none;	
	        color: #FFFFFF;        
        }

    </style>

    <telerik:RadWindowManager ID="rwmUIApp" Skin="WebBlue" runat="server" />

        
        <telerik:RadAjaxManager runat="Server" 
                                ID="RadAjaxManager1" >
            <AjaxSettings>                            
			    
                <telerik:AjaxSetting AjaxControlID="cboEstado">
				    <UpdatedControls>					    
                        <telerik:AjaxUpdatedControl ControlID="cboBloco" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="cboRegiao" LoadingPanelID="RadAjaxLoadingPanel1" />                        
                        <telerik:AjaxUpdatedControl ControlID="cboIgreja" LoadingPanelID="RadAjaxLoadingPanel1" />   
				    </UpdatedControls>
			    </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="cboBloco">
				    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cboRegiao" LoadingPanelID="RadAjaxLoadingPanel1" />                        
                        <telerik:AjaxUpdatedControl ControlID="cboIgreja" LoadingPanelID="RadAjaxLoadingPanel1" />   
				    </UpdatedControls>
			    </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="cboRegiao">
				    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cboIgreja" LoadingPanelID="RadAjaxLoadingPanel1" />   
				    </UpdatedControls>
			    </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="btnUploadFotoJovem">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="uploadFotosJovem" LoadingPanelID="RadAjaxLoadingPanel1" />   
				    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        
        <telerik:RadAjaxLoadingPanel runat="server" ID="RadAjaxLoadingPanel1" >
	    </telerik:RadAjaxLoadingPanel>

    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" />

    <telerik:RadNavigation runat="server" ID="contactNavigation" Skin="Vista" CssClass="secondaryMenu">
        <Nodes>                        
            <telerik:NavigationNode Text="Novo Jovem" SpriteCssClass="icon icon-Send" NavigateUrl="RegistraJovem.aspx" ></telerik:NavigationNode>
            <telerik:NavigationNode CssClass="rightScndNav">                
                <NodeTemplate>                    
                    
                </NodeTemplate>
            </telerik:NavigationNode>
        </Nodes>
    </telerik:RadNavigation>    

    <div class="demo-container">

        <div class="wizardHeader">




        </div>        

    </div>

</asp:Content>
