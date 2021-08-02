<%@ Page Title="Project List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectList.aspx.cs" Inherits="BrandActivationStudio.ProjectList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/Brand_Style.css" rel="stylesheet" />
    <h1 style="text-align: center;">Project List</h1>
    <br />
    <asp:Button ID="btnNewProject" runat="server" Text="Add New" CssClass="btn btn-primary" />
    <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="btnNewProject"
        CancelControlID="btnCloseNew" BackgroundCssClass="Background">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" Style="display: none">
        <iframe style="width: 420px; height: 520px;" id="irm1" src="AddProject.aspx" runat="server"></iframe>
        <br />
        <asp:Button ID="btnCloseNew" runat="server" Text="Close" CssClass="btn btn-primary" />
    </asp:Panel>

    <asp:Button Text="Export List" OnClick="ExportCSV" runat="server" CssClass="btn btn-primary" />

<%--    <asp:Button ID="btnEditProject" runat="server" Text="Edit Project" CssClass="btn btn-primary" />
    <cc2:ModalPopupExtender ID="editpopup" runat="server" PopupControlID="Panl1" TargetControlID="btnEditProject"
        CancelControlID="btnCloseEdit" BackgroundCssClass="Background">
    </cc2:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="Popup" align="center" Style="display: none">
        <iframe style="width: 420px; height: 520px;" id="Iframe1" src="EditProject.aspx" runat="server"></iframe>
        <br />
        <asp:Button ID="btnCloseEdit" runat="server" Text="Close" CssClass="btn btn-primary" />
    </asp:Panel>--%>

    <br />
    <br />
    <div class="row" runat="server" id="divProjects"></div>
</asp:Content>
