<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BrandActivationStudio.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="text-align:center;">
        <h1>Login</h1>
        <br />
        <div id="loginMsg" runat="server"></div>
        <div class="row">
            <label>Username: </label>
            <input type="text" id="txtUsername" runat="server" /><br />
            <br />
            <label>Password: </label>
            <input type="password" id="txtPassword" runat="server" /><br />
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
        </div>
    </div>
</asp:Content>
