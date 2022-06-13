<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="Zadatak01.Settings" %>

<%@ Register Src="~/UserControls/CreateTagControl.ascx" TagPrefix="uc1" TagName="CreateTagControl" %>
<%@ Register Src="~/UserControls/TagDeleteControl.ascx" TagPrefix="uc1" TagName="TagDeleteControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class='container-sm p-5'>
        <div class="container">
            <div class="mb-3">
                <div class="row">
                    <div class="col-sm">
                        <h5 style="text-align: center">
                            Tag
                        </h5>
                    </div>
                    <div class="col-sm">
                        <h5 style="text-align: center">
                            Times used
                        </h5>
                    </div>
                    <div class="col-sm">
                        <h5 style="text-align: center">
                            Delete
                        </h5>
                    </div>
                </div>
            </div>
            <div class="container" style="height: 64vh; overflow-y: scroll;">
            <asp:Repeater ID="rptTags" runat="server" OnItemDataBound="rptTags_ItemDataBound">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <%--<th scope="col" style="text-align: left">Tag</th>
                                <th scope="col" style="text-align: left">Times used</th>
                                <th scope="col"></th>--%>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="row">
                        <th scope="row" class="col-sm text-center"" style="text-align: left"><%#Eval(nameof(RwaApartmaniDataLayer.Models.TagCount.NameEng)) %></th>
                        <td id="count" class="col-sm text-center"" style="text-align: left">
                            <asp:Label ID="lblCount" runat="server" Style="font-size: 1.1rem" Text="<%#Eval(nameof(RwaApartmaniDataLayer.Models.TagCount.Count)) %>"></asp:Label>
                        </td>
                        <td class="col-sm text-center" style=" height: 100%">
                            <asp:LinkButton ID="btnDelete" class="btn btn-outline-danger" OnClick="btnDelete_Click" Style="width: 50%" CommandArgument="<%#Eval(nameof(RwaApartmaniDataLayer.Models.TagCount.Id)) %>" runat="server" CausesValidation="false">Delete</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="container">
            <div class="mt-3">
                <asp:Button ID="btnCreateTag" runat="server" Text="Create new tag" class="btn btn-outline-primary" Style="width: 100%;" OnClick="btnCreateTag_Click" />
            </div>
        </div>
        </div>
    </div>
    <asp:Panel ID="pnlCreateTag" runat="server">
        <div class="container animate__animated animate__slideInDown" id="popup_create_tag">
            <uc1:CreateTagControl runat="server" id="CreateTagControl" />
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlConfirm" runat="server">
        <div class="container animate__animated animate__slideInDown" id="popup_confirm">
            <uc1:TagDeleteControl runat="server" ID="TagDeleteControl" />
        </div>
    </asp:Panel>
</asp:Content>
