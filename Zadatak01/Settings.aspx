<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="Zadatak01.Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class='container p-4'>
        <fieldset>
            <legend runat="server" meta:resourcekey="legendSettings">Settings</legend>
            <div class="mb-3">
                <asp:Label ID="lblTheme" meta:resourcekey="lblTheme" class="form-label" runat="server" Text="Theme:"></asp:Label>
                <asp:DropDownList ID="ddlTheme" class="form-select" AutoPostBack="True" runat="server" OnSelectedIndexChanged="ddlTheme_SelectedIndexChanged">
                    <asp:ListItem meta:resourcekey="liDefault" Selected="True" Value="0">- Select -</asp:ListItem>
                    <asp:ListItem meta:resourcekey="liWhite" Value="WhiteTheme">White</asp:ListItem>
                    <asp:ListItem meta:resourcekey="liDark" Value="DarkTheme">Black</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblLang" meta:resourcekey="lblLang" class="form-label" runat="server" Text="Language:"></asp:Label>
                <asp:DropDownList ID="ddlLang" class="form-select" AutoPostBack="True" runat="server" OnSelectedIndexChanged="ddlLang_SelectedIndexChanged">
                    <asp:ListItem meta:resourcekey="liDefault" Selected="True" Value="0">- Select -</asp:ListItem>
                    <asp:ListItem meta:resourcekey="liEng" Value="en">English</asp:ListItem>
                    <asp:ListItem meta:resourcekey="liCro" Value="hr">Croatian</asp:ListItem>
                </asp:DropDownList>
            </div>
        </fieldset>
</div>
</asp:Content>
