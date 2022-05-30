<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Zadatak01.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
        <div class="container p-4">
            <fieldset>
                <legend>User: <b runat="server" id="bUsername"></b></legend>

                <div class='mb-3'>
                    <asp:Label ID="lblFName" runat="server" Text="First name:"></asp:Label>
                    <p id="pFName" runat="server"></p>
                </div>

                <div class='mb-3'>
                     <asp:Label ID="lblLName" runat="server" Text="Last name:"></asp:Label>
                     <p id="pLName" runat="server"></p>
                </div>

                <%--<asp:Button ID="btnLogout" class='btn btn-primary' runat="server" Text="Logout" />--%>
           </fieldset>
        </div>
</asp:Content>
