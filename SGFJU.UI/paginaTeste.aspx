<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="paginaTeste.aspx.cs" Inherits="SGFJU.UI.teste" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
    <link href="Styles/UI_App.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FolderContent" runat="server">
    <a href="notes.aspx">teste</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadNavigation runat="server" ID="contactNavigation" Skin="BlackMetroTouch" CssClass="secondaryMenu">
        <Nodes>
            
            <telerik:NavigationNode Text="Reply">
                <Nodes>
                    <telerik:NavigationNode Text="Reply"></telerik:NavigationNode>
                    <telerik:NavigationNode Text="Reply All"></telerik:NavigationNode>
                    <telerik:NavigationNode Text="Forward"></telerik:NavigationNode>
                </Nodes>
            </telerik:NavigationNode>
            <telerik:NavigationNode Text="Delete"></telerik:NavigationNode>
            <telerik:NavigationNode Text="Move">
                <Nodes>
                    <telerik:NavigationNode Text="Inbox"></telerik:NavigationNode>
                    <telerik:NavigationNode Text="Junk"></telerik:NavigationNode>
                    <telerik:NavigationNode Text="Drafts"></telerik:NavigationNode>
                    <telerik:NavigationNode Text="Deleted"></telerik:NavigationNode>
                </Nodes>
            </telerik:NavigationNode>
            <telerik:NavigationNode Text="Junk">
                <Nodes>
                    <telerik:NavigationNode Text="Report Spam"></telerik:NavigationNode>
                </Nodes>
            </telerik:NavigationNode>
            <telerik:NavigationNode Text="More">
                <Nodes>
                    <telerik:NavigationNode Text="Mark as read"></telerik:NavigationNode>
                    <telerik:NavigationNode Text="Mark as unread"></telerik:NavigationNode>
                    <telerik:NavigationNode Text="Print"></telerik:NavigationNode>
                </Nodes>
            </telerik:NavigationNode>
            <telerik:NavigationNode CssClass="rightScndNav">
                <NodeTemplate>                    
                    <telerik:RadSearchBox runat="server" Skin="BlackMetroTouch" Width="340px" DropDownSettings-Height="300px" ID="mainSearch"
                        CssClass="hidden" ShowLoadingIcon="false">
                    </telerik:RadSearchBox>
                    <span class="button searchBtn"><span class="icon icon-Search"></span></span>
                </NodeTemplate>
            </telerik:NavigationNode>
        </Nodes>
    </telerik:RadNavigation>

    

    <script type="text/javascript">
        var grid = null;
        var masterTableView = null;

        initialize = function () {           
           function changeView(e) {
               var command = $(e.currentTarget).attr("data-command-name");
               var $section = $(".section");

               if (command === "right") {
                   this.hideColumnsInGrid(false);

               } else if (command === "bottom") {
                   this.hideColumnsInGrid(true);
               }
               else {
                   return;
               }

               $section.attr("class", "section");
               $section.addClass(command);
               grid.repaint();
          
           };
    </script>
</asp:Content>
