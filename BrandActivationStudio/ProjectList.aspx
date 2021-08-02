<%@ Page Title="Project List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectList.aspx.cs" Inherits="BrandActivationStudio.ProjectList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/Brand_Style.css" rel="stylesheet" />
    <script type="text/javascript">

        function OpenEditModal() {            
            document.getElementById("btnProjectDelete").click();
        }

        function OpenDeleteModal() {      
            document.getElementById("btnProjectEdit").click();            
        }       

    </script>
    <h1 style="text-align: center;">Project List</h1>
    <br />

    <%--This pop-up is for creating new project--%>
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

    <%--This modal is for edit screen--%>
    <%--<asp:Button ID="btnProjectEdit" runat="server" Text="Edit Project" CssClass="hidden" />--%>
   <%-- <cc2:modalpopupextender id="ModalPopupExtender2" runat="server" popupcontrolid="editpan" targetcontrolid="btnProjectEdit"
        cancelcontrolid="btnCloseDelete" backgroundcssclass="Background">
    </cc2:modalpopupextender>
    <asp:Panel ID="editpan" runat="server" CssClass="Popup" align="center" Style="display: none">
        <iframe style="width: 420px; height: 520px;" id="Iframe2" src="EditProject.aspx" runat="server"></iframe>
        <br />
        <asp:Button ID="btnCloseEdit" runat="server" Text="Close" CssClass="btn btn-primary" />
    </asp:Panel>--%>


    <%--This modal is for the delete screen--%>
    <%--<asp:Button ID="btnProjectDelete" runat="server" Text="Delete" CssClass="hidden"  />--%>
   <%-- <cc3:modalpopupextender id="ModalPopupExtender1" runat="server" popupcontrolid="deletepan" targetcontrolid="btnProjectDelete"
        cancelcontrolid="btnCloseDelete" backgroundcssclass="Background">
    </cc3:modalpopupextender>
    <asp:Panel ID="deletepan" runat="server" CssClass="Popup" align="center" Style="display: none">
        <iframe style="width: 420px; height: 520px;" id="Iframe1" src="DeleteProject.aspx" runat="server"></iframe>
        <br />
        <asp:Button ID="btnCloseDelete" runat="server" Text="Close" CssClass="btn btn-primary" />
    </asp:Panel>--%>
    <br />
    <br />
    <div class="row" runat="server" id="divProjects"></div>
</asp:Content>
