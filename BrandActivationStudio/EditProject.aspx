<%@ Page Title="Edit Project" Language="C#" AutoEventWireup="true" CodeBehind="EditProject.aspx.cs" Inherits="BrandActivationStudio.EditProject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div style="text-align:center;">
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <h2 style="text-align: center;">Edit Project</h2>
            <br />
            <div id="editmsgbox" runat="server"></div>
            <br />
            <div class="row">
                <div class="col-sm-4">
                    <label>Project Code:</label>
                </div>
                <div class="col-sm-4">
                    <input type="text" id="txtEditProjectCode" runat="server" />
                    <span>*</span>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-6">
                    <label>Project Name:</label>
                </div>
                <div class="col-sm-6">
                    <input type="text" id="txtEditProjectName" runat="server" />
                    <span>*</span>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-6">
                    <label>Project Description:</label>
                </div>
                <div class="col-sm-6">
                    <input type="text" id="txtEditProjectDescription" runat="server" />
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-6">
                    <label>Start Date:</label>
                </div>
                <div class="col-sm-6">
                    <input type="date" id="txtEditStartDate" runat="server" /><br />
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-6">
                    <label>End Date: </label>
                </div>
                <div class="col-sm-6">
                    <input type="date" id="txtEditEndDate" runat="server" /><br />
                </div>
            </div>
            <br />
            <asp:HiddenField ID="txtProjectId" runat="server" />
            <br />
            <asp:Button ID="btnEditProject" runat="server" Text="Save" CssClass="btn btn-primary" class="btn btn-primary" OnClick="btnEditProject_Click" />

        </form>
    </div>
</body>
</html>
