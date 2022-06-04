<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Zadatak01.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="container p-3" style="height: 84vh">
        <div class="container">
            <fieldset>
                <legend>Filters</legend>
                <div style="display: flex; justify-content: space-between; align-items: flex-end">
                    <div style="width: 20%; margin: 10px">
                        <asp:Label ID="lblStatusFilter" runat="server" Text="Status:"></asp:Label>
                        <asp:DropDownList class="form-select" ID="ddlStatusFilter" runat="server" AutoPostBack="true">
                        </asp:DropDownList>

                        <asp:Label ID="lblCityFilter" runat="server" Text="City:"></asp:Label>
                        <asp:DropDownList class="form-select" ID="ddlCityFilter" AutoPostBack="true" runat="server">
                        </asp:DropDownList>

                    </div>
                    <div style="width: 20%; margin: 10px">
                        <asp:Label ID="lblSortBy"  runat="server" Text="Sort by:"></asp:Label>
                        <asp:DropDownList class="form-select" ID="ddlSortBy" AutoPostBack="true" runat="server">
                            <asp:ListItem meta:resourcekey="liPriceLH" Selected="True" Value="0">Price: low to high</asp:ListItem>
                            <asp:ListItem meta:resourcekey="liPriceHL" Value="1">Price: high to low</asp:ListItem>
                            <asp:ListItem meta:resourcekey="liRoomsLH" Value="2">Rooms: least to most</asp:ListItem>
                            <asp:ListItem meta:resourcekey="liRoomsHL" Value="3">Rooms: most to least</asp:ListItem>
                            <asp:ListItem meta:resourcekey="liSpacesLH" Value="4">Spaces: least to most</asp:ListItem>
                            <asp:ListItem meta:resourcekey="liSpacesHL" Value="5">Spaces: most to least</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </fieldset>
        </div>
        <asp:Repeater ID="rptApartments" runat="server">
            <HeaderTemplate>
                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col">Id</th>
                            <th scope="col">Name</th>
                            <th scope="col">City</th>
                            <th scope="col">Adults</th>
                            <th scope="col">Children</th>
                            <th scope="col">Rooms</th>
                            <th scope="col">Pictures</th>
                            <th scope="col">Price</th>
                            <th scope="col"></th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <th scope="row"><%#Eval(nameof(RwaApartmaniDataLayer.Models.Apartment.Id)) %></th>
                    <td><%#Eval(nameof(RwaApartmaniDataLayer.Models.Apartment.Name)) %></td>
                    <td><%#Eval(nameof(RwaApartmaniDataLayer.Models.Apartment.CityName)) %></td>
                    <td><%#Eval(nameof(RwaApartmaniDataLayer.Models.Apartment.MaxAdults)) %></td>
                    <td><%#Eval(nameof(RwaApartmaniDataLayer.Models.Apartment.MaxChildren)) %></td>
                    <td><%#Eval(nameof(RwaApartmaniDataLayer.Models.Apartment.TotalRooms)) %></td>
                    <td><%#Eval(nameof(RwaApartmaniDataLayer.Models.Apartment.PicturesCount)) %></td>
                    <td><%#Eval(nameof(RwaApartmaniDataLayer.Models.Apartment.PriceString)) %></td>
                    <td style="display: flex; justify-content: right">
                        <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" class="btn btn-outline-primary" Style="width: 100%" CommandArgument="<%#Eval(nameof(RwaApartmaniDataLayer.Models.Apartment.Id)) %>" runat="server">Open</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                    </table>
            </FooterTemplate>
        </asp:Repeater>
        <div class="container" style="display: flex; justify-content: right">
            <asp:Button ID="btnAdd" runat="server" class="btn btn-primary" Text="Add new apartment" />
        </div>
    </div>
</asp:Content>
