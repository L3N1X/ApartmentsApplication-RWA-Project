<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Zadatak01.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="container p-4">
        <div class="row">
            <div class="col-sm-6">
                <div class="form-group">
                    <fieldset class="p-4">
                    <legend>List of users</legend>
                        <asp:ListBox runat="server"
                            ID="lbUsers"
                            CssClass="form-control"
                            AutoPostBack="true" OnSelectedIndexChanged="lbUsers_SelectedIndexChanged" />
                    </fieldset>
                </div>
            </div>
            <div class="col-sm-6">
                <fieldset class="p-4">
                    <legend>Edit User</legend>
                    <asp:Label ID="lblResult" runat="server" CssClass="alert alert-danger d-block w-100"></asp:Label>
                    <div class="mb-3">
                        <asp:Label ID="lblFname" for="txtFname" class="form-label" runat="server" Text="First name"></asp:Label>
                        <asp:TextBox ID="txtFname" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFname" Display="Dynamic" ForeColor="Red">* Niste upisali ime</asp:RequiredFieldValidator>
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="lblLname" for="txtLname" class="form-label" runat="server" Text="Last name"></asp:Label>
                        <asp:TextBox ID="txtLname" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLname" Display="Dynamic" ForeColor="Red">* Niste upisali prezime</asp:RequiredFieldValidator>
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="lblUsername" meta:resourcekey="lblUsername" class="form-label" runat="server" Text="Username"></asp:Label>
                        <asp:TextBox ID="txtUsername" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUsername" Display="Dynamic" ForeColor="Red">* Niste upisali korisničko ime</asp:RequiredFieldValidator>
                    </div>
                    <asp:Button ID="updateUser" class="btn btn-primary" runat="server" Text="Update" OnClick="updateUser_Click" />
                </fieldset>
            </div>
        </div>

    </div>
</asp:Content>
