﻿<%@ Page Title="Delete Project" Language="C#" AutoEventWireup="true" CodeBehind="DeleteProject.aspx.cs" Inherits="BrandActivationStudio.DeleteProject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div style="text-align:center;">
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <h2 style="text-align: center;">Delete Project</h2>
            <br />
            <h4 style="text-align: center;">Are you sure you want to delete this project?</h4>
            <br />
            <asp:HiddenField ID="txtProjectId" runat="server" />
            <br />
            <asp:Button ID="btnDeleteProject" runat="server" Text="Delete" OnClick="btnDeleteProject_Click" />
        </form>
    </div>
</body>
</html>
