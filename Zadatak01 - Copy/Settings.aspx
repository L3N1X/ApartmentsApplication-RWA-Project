<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="Zadatak01.Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class='container-sm p-5' style="width: max(50%, 700px)">

        <fieldset>
            <legend runat="server">New tag</legend>
            <div class="container">
                <div class="mb-3">
                    <asp:Label ID="lblTagName" runat="server" Text="Tag name"></asp:Label>
                    <asp:TextBox ID="txtTagName" runat="server" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="txtNameValidator" runat="server" ControlToValidate="txtTagName" Display="Dynamic" ForeColor="Red" ErrorMessage="Tag name can't be empty"></asp:RequiredFieldValidator>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblTagNameEng" runat="server" Text="Tag name (English)"></asp:Label>
                    <asp:TextBox ID="txtTagNameEng" runat="server" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="txtNameEngValidator" runat="server" ControlToValidate="txtTagNameEng" Display="Dynamic" ForeColor="Red" ErrorMessage="Tag name can't be empty"></asp:RequiredFieldValidator>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblTagType" runat="server" Text="Select tag type"></asp:Label>
                    <asp:DropDownList ID="ddlTagType" runat="server" AutoPostBack="true" class="form-select"></asp:DropDownList>
                </div>

                <asp:Button ID="btnCreateTag" runat="server" Text="Create new tag" class="btn btn-primary" Style="width: 100%;" OnClick="btnCreateTag_Click" />
            </div>
        </fieldset>

        <fieldset runat="server" id="fieldset">
            <legend runat="server" meta:resourcekey="legendSettings">Settings</legend>
            <div class="container" style="height:30vh; overflow-y:scroll;">
                <asp:Repeater ID="rptTags" runat="server" OnItemDataBound="rptTags_ItemDataBound">
                    <HeaderTemplate>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th scope="col" style="text-align: left">Tag</th>
                                    <th scope="col" style="text-align: left">Times used</th>
                                    <th scope="col"></th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <th scope="row" style="text-align: left"><%#Eval(nameof(RwaApartmaniDataLayer.Models.TagCount.Name)) %></th>
                            <td id="count" style="text-align: left">
                                <asp:Label ID="lblCount" runat="server" Style="font-size: 1.1rem" Text="<%#Eval(nameof(RwaApartmaniDataLayer.Models.TagCount.Count)) %>"></asp:Label>
                            </td>
                            <td style="display: flex; justify-content: right; height: 100%">
                                <asp:LinkButton ID="btnDelete" class="btn btn-outline-danger" OnClick="btnDelete_Click" Style="width: 100%" CommandArgument="<%#Eval(nameof(RwaApartmaniDataLayer.Models.TagCount.Id)) %>" runat="server" CausesValidation="false">Delete</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                    </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </fieldset>
    </div>
</asp:Content>
