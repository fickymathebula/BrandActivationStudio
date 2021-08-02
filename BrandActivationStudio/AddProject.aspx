<%@ Page Title="Add Project" Language="C#" AutoEventWireup="true" CodeBehind="AddProject.aspx.cs" Inherits="BrandActivationStudio.AddProject" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">

        function ValidateAdd() {

            var projectcode = document.getElementById("txtProjectCode");
            var projectname = document.getElementById("txtProjectName");

            var errormsg = "";

            if (projectcode == "") {
                errormsg += "The field Project Code id Required.";
            }

            if (projectname == "") {
                errormsg += "The field Project Name id Required.";
            }

            if (errormsg == "") {
                document.getElementById("addmsgbox").innerHTML = ""; // Clear the error message if there are no errors             
            } else {
                // Show error message here
                document.getElementById("addmsgbox").innerHTML = errormsg;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <h2 style="text-align: center;">Add New Project</h2>
        <br />
        <div id="addmsgbox" runat="server"></div>
        <br />
        <div class="row">
            <div class="col-sm-4">
                <label>Project Code:</label>
            </div>
            <div class="col-sm-4">
                <input type="text" id="txtProjectCode" runat="server" /> <span> *</span>
            </div>
        </div>
        <br />
         <div class="row">
            <div class="col-sm-4">
                <label>Project Name:</label>
            </div>
            <div class="col-sm-4">
                <input type="text" id="txtProjectName" runat="server" /> <span> *</span>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-6">
                <label>Project Description:</label>
            </div>
            <div class="col-sm-6">
                <input type="text" id="txtProjectDescription" runat="server" /> 
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-6">
                <label>Start Date:</label>
            </div>
            <div class="col-sm-6">
                <input type="date" id="txtStartDate" runat="server" /><br />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-6">
                <label>End Date: </label>
            </div>
            <div class="col-sm-6">
                <input type="date" id="txtEndDate" runat="server" /><br />
            </div>
        </div>
        <br />
        <br />
        <asp:Button ID="btnAddProject" runat="server" Text="Submit" OnClick="btnAddProject_Click" CssClass="btn btn-info" OnClientClick="ValidateAdd();"/>

    </form>
</body>
</html>
