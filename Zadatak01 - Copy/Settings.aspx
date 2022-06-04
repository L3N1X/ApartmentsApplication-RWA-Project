<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="Zadatak01.Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <%--<div class='container p-4'>
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
</div>--%>s
    <div class='container-sm p-5' style="width:50%">
        <fieldset runat="server" id="fieldset">  
            <legend runat="server" meta:resourcekey="legendSettings">Settings</legend>
            <%--<table class="table" id="tblTags" runat="server">

            </table>--%>
            <asp:Repeater ID="rptTags" runat="server" OnItemDataBound="rptTags_ItemDataBound">
            <HeaderTemplate>
                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col" style="text-align:left">Tag</th>
                            <th scope="col" style="text-align:left">Times used</th>
                            <th scope="col"></th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <th scope="row" style="text-align:left"><%#Eval(nameof(RwaApartmaniDataLayer.Models.TagCount.Name)) %></th>
                    <td id="count" style="text-align:left">
                        <asp:Label ID="lblCount" runat="server" Text="<%#Eval(nameof(RwaApartmaniDataLayer.Models.TagCount.Count)) %>"></asp:Label>
                    </td>
                    <td style="display: flex; justify-content: right; height:100%">
                        <asp:LinkButton ID="btnDelete" class="btn btn-outline-danger" OnClick="btnDelete_Click" Style="width: 100%" CommandArgument="<%#Eval(nameof(RwaApartmaniDataLayer.Models.TagCount.Id)) %>" runat="server">Delete</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                    </table>
            </FooterTemplate>
        </asp:Repeater>
        </fieldset>
</div>
</asp:Content>
