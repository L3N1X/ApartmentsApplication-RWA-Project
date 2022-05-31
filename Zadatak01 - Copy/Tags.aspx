<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Tags.aspx.cs" Inherits="Zadatak01.Tags" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <asp:Repeater ID="rptTags" runat="server">
                    <HeaderTemplate>
                        <table class="table" style="width:100%" id="myTable">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Name</th>
                                    <th scope="col">Created at</th>
                                    <th scope="col"></th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <th scope="row"><%#Eval(nameof(rwaLib.Models.Tags.Id)) %></th>
                            <td><%#Eval(nameof(rwaLib.Models.Tags.Name)) %></td>
                            <td><%#Eval(nameof(rwaLib.Models.Tags.CreatedAt)) %></td>
                            <td>
                                <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" CommandArgument="<%#Eval(nameof(rwaLib.Models.Tags.Id)) %>" runat="server">Odaberi</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                    </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div class="col-md-6">
                <asp:GridView ID="gwApartments" AutoGenerateColumns="false" CssClass="table" runat="server">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Apartments name"/>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
