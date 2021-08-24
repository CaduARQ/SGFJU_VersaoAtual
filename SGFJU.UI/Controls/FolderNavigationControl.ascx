<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FolderNavigationControl.ascx.cs" Inherits="SGFJU.UI.Controls.FolderNavigationControl" %>



<telerik:RadTreeView runat="server" 
                     ID="rtvFolders" 
                     EnableDragAndDrop="true" 
                     EnableDragAndDropBetweenNodes="true" 
                     ShowLineImages="false">
    <%--<ContextMenus>
        <telerik:RadTreeViewContextMenu>
            <Items>
                <telerik:RadMenuItem Text="Estados" NavigateUrl="#"></telerik:RadMenuItem>
                <telerik:RadMenuItem Text="Blocos" NavigateUrl="../Views/RegistraBloco.aspx"></telerik:RadMenuItem>
                <telerik:RadMenuItem Text="Regiões" NavigateUrl="#"></telerik:RadMenuItem>
                <telerik:RadMenuItem Text="Igrejas" NavigateUrl="#"></telerik:RadMenuItem>
            </Items>
        </telerik:RadTreeViewContextMenu>
    </ContextMenus>--%>
    <Nodes>
        <telerik:RadTreeNode runat="server" Text="Estado" ></telerik:RadTreeNode>
        <telerik:RadTreeNode runat="server" Text="Bloco" NavigateUrl="../Views/RegistraBlocos.aspx"></telerik:RadTreeNode>
        <telerik:RadTreeNode runat="server" Text="Regiões" NavigateUrl="~/Views/RegistraRegiao.aspx"></telerik:RadTreeNode>
        <telerik:RadTreeNode runat="server" Text="Igrejas"  NavigateUrl="~/Views/RegistraIgrejas.aspx"></telerik:RadTreeNode>
    </Nodes>
</telerik:RadTreeView>

<div id="newFolderContainer">
    
</div>
<%--<div class="btn-new-node">Estados</div>
<div class="btn-new-node">Bloco</div>
<div class="btn-new-node">Regiões</div>
<div class="btn-new-node">Igrejas</div>--%>
