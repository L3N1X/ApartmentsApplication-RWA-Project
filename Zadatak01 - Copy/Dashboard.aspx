<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Zadatak01.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <%--<div class="container p-4">
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
           </fieldset>
        </div>--%>
    <div class="container p-4">
        <asp:Repeater ID="rptTags" runat="server">
            <HeaderTemplate>
                <table class="table" style="width: 100%" id="myTable">
                    <thead>
                        <tr>
                            <th scope="col">Id</th>
                            <th scope="col">Name</th>
                            <th scope="col">City</th>
                            <th scope="col">Adults</th>
                            <th scope="col">Children</th>
                            <th scope="col">Rooms</th>
                            <%--<th scope="col">Pictures</th>--%>
                            <th scope="col">Price</th>
                            <th scope="col">#</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <th scope="row"><%#Eval(nameof(RwaApartmaniDataLayer.Models.Apartment.Id)) %></th>
                    <td><%#Eval(nameof(RwaApartmaniDataLayer.Models.Apartment.Name)) %></td>
                    <td><%#Eval(nameof(RwaApartmaniDataLayer.Models.City.Name)) %></td>
                    <td><%#Eval(nameof(RwaApartmaniDataLayer.Models.Apartment.MaxAdults)) %></td>
                    <td><%#Eval(nameof(RwaApartmaniDataLayer.Models.Apartment.MaxChildren)) %></td>
                    <td><%#Eval(nameof(RwaApartmaniDataLayer.Models.Apartment.TotalRooms)) %></td>
                    <%--<td><%#Eval(nameof(RwaApartmaniDataLayer.Models.Apartment.PicturesCount)) %></td>--%>
                    <td><%#Eval(nameof(RwaApartmaniDataLayer.Models.Apartment.Price)) %></td>
                    <td>
                        <%--<asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" CommandArgument="<%#Eval(nameof(RwaApartmaniDataLayer.Models.Apartment.Id)) %>" runat="server">Open</asp:LinkButton>--%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                    </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
