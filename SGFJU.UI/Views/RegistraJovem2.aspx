<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistraJovem2.aspx.cs" Inherits="SGFJU.UI.Views.RegistraJovem2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/mail.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../Styles/newMail.css" />

    <style type="text/css">
        html .RadGrid .rgMasterTable {
            height: auto;
        }

        .subject {
            position: relative;
        }


    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FolderContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadNavigation runat="server" Skin="Vista" OnClientNodeClicked="nodeClicked" CssClass="secondaryMenu">
        <Nodes>
            <telerik:NavigationNode Text="Novo Jovem" SpriteCssClass="icon icon-Send" NavigateUrl="RegistraJovem.aspx" ></telerik:NavigationNode>
            <%--<telerik:NavigationNode Text="Insert">
                <Nodes>
                    <telerik:NavigationNode Text="Files as attachments"></telerik:NavigationNode>
                    <telerik:NavigationNode Text="Picture Inline"></telerik:NavigationNode>
                </Nodes>
            </telerik:NavigationNode>
            <telerik:NavigationNode Text="Save"></telerik:NavigationNode>
            <telerik:NavigationNode Text="Priority">
                <Nodes>
                    <telerik:NavigationNode Text="High Priority"></telerik:NavigationNode>
                    <telerik:NavigationNode Text="Low Priority"></telerik:NavigationNode>
                </Nodes>
            </telerik:NavigationNode>--%>
            <telerik:NavigationNode Text="Cancelar" NavigateUrl="default.aspx"></telerik:NavigationNode>
        </Nodes>
    </telerik:RadNavigation>
    <div class="scroller">


        <div class="gridWrapper">

            <telerik:RadGrid runat="server" 
                             ID="grdTodosJovens" 
                             GridLines="None" 
                             AutoGenerateColumns="false" 
                             Height="100%"
                             EnableViewState="false" 
                             AllowMultiRowSelection="false" 
                             AllowSorting="true" 
                             ShowGroupPanel="true" 
                             AllowFilteringByColumn="false">
                <GroupingSettings ShowUnGroupButton="true"></GroupingSettings>
                <ClientSettings AllowDragToGroup="true" 
                                EnableRowHoverStyle="true" 
                                AllowKeyboardNavigation="false">
                    <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                    <Selecting AllowRowSelect="true" />
                </ClientSettings>
                <MasterTableView>                    
                    <Columns>
                        <telerik:GridBoundColumn DataField="Nome" UniqueName="Nome" HeaderText="Nome do Jovem" HeaderStyle-Width="200px" />
                        <telerik:GridBoundColumn DataField="IgrejaAQualJovemPertence.NomeIgreja" UniqueName="IgrejaAQualJovemPertence.NomeIgreja" HeaderText="Igreja" ItemStyle-CssClass="subject" />
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>

        </div>

    </div>
</asp:Content>
