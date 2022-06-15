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

        <div class="container pt-5" style="display: flex; justify-content: center; align-items: center" id="popup_login">
            <asp:Panel ID="PanelForma" runat="server" Visible="True" Style="width: 500px">
                <!-- FORM -->
                <div class="container p-4">
                    <div class="container mb-3" style="display:flex; justify-content:center; align-items:center">
                        <asp:Image ID="imgLogo" runat="server" ImageUrl="~/Images/apartment.png" Style="width:150px; height:150px"/>
                    </div>
                    <div class="mb-4">
                        <h3 style="text-align:center">
                            <asp:Label ID="lblTitle" runat="server" Text="RWA Apartments"></asp:Label>
                        </h3>
                    </div>
                    <div class="mb-3">
                        <%--<asp:Label ID="lblUsername" class="form-label" runat="server" Text="E-mail"></asp:Label>--%>
                        <asp:TextBox ID="txtUsername" class="form-control" runat="server" style="text-align:center" placeholder="Enter your e-mail address" TextMode="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" Display="Dynamic" ForeColor="Red">* Please specify e-mail address</asp:RequiredFieldValidator>
                    </div>
                    <div class="mb-5">
                        <%--<asp:Label ID="lblPassword" meta:resourcekey="lblPassword" class="form-label" runat="server" Text="Password"></asp:Label>--%>
                        <asp:TextBox ID="txtPassword" TextMode="Password" class="form-control" runat="server" placeholder="Enter your password" style="text-align:center"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="Red">* Please specify e-mail password</asp:RequiredFieldValidator>
                    </div>
                    <div>
                        <asp:Button ID="btnLogin" class="btn btn-success" runat="server" Text="Login" OnClick="btnLogin_Click" Style="width: 100%" />
                    </div>
                </div>

                <!-- // -->
            </asp:Panel>
        </div>
    </div>
</asp:Content>
