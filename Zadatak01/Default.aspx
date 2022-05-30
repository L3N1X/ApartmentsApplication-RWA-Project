<%@ Page Title="Login page" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Zadatak01.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="container py-4">
        <!-- PANEL PORUKA -->
        <asp:Panel ID="PanelIspis" CssClass="container mt-5" runat="server" Visible="False">
            <div class='alert alert-danger' role='alert'>
                <asp:Label ID="lblErrorLogin" meta:resourcekey="lblErrorLogin" runat="server" Text="Check the entered data again!"></asp:Label>
            </div>
        </asp:Panel>
        <!-- // -->

        <asp:Panel ID="PanelForma" runat="server" Visible="True">
            <!-- FORM -->
            <fieldset class="p-4">
                <legend runat="server" meta:resourcekey="legendLogin">Login</legend>
                <div class="mb-3">
                    <asp:Label ID="lblUsername" meta:resourcekey="lblUsername" class="form-label" runat="server" Text="Username"></asp:Label>
                    <asp:TextBox ID="txtUsername" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" meta:resourcekey="rfvUsername" runat="server" ControlToValidate="txtUsername" Display="Dynamic" ForeColor="Red">* Niste upisali korisničko ime</asp:RequiredFieldValidator>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblPassword" meta:resourcekey="lblPassword" class="form-label" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="txtPassword" TextMode="Password" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" meta:resourcekey="rfvPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="Red">* Niste upisali lozinku</asp:RequiredFieldValidator>
                </div>
                <asp:Button ID="btnLogin" meta:resourcekey="btnLogin" class="btn btn-primary" runat="server" Text="Submit" OnClick="btnLogin_Click" />
            </fieldset>
            <!-- // -->
        </asp:Panel>
    </div>
</asp:Content>
