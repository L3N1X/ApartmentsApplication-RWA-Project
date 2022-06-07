<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Zadatak01.Dashboard" %>

<%@ Register Src="~/UserControls/EditApartmentControl.ascx" TagPrefix="uc" TagName="EditApartmentControl" %>
<%@ Register Src="~/UserControls/ApartmentDeleteControl.ascx" TagPrefix="uc" TagName="ApartmentDeleteControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="container p-3">
        <div class="container">
            <div class="container">
                <div class="row">
                    <div class="col-sm">
                        <div class="mb-3">
                            <asp:Label ID="lblStatusFilter" runat="server" Text="Status:" class="font-weight-bold"></asp:Label>
                            <asp:DropDownList class="form-select" ID="ddlStatusFilter" runat="server" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm">
                        <div class="mb-3">
                            <asp:Label ID="lblCityFilter" runat="server" Text="City:" class="font-weight-bold"></asp:Label>
                            <asp:DropDownList class="form-select" ID="ddlCityFilter" AutoPostBack="true" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm">
                        <div class="mb-3">
                            <asp:Label ID="lblSortBy" runat="server" Text="Sort by:" class="font-weight-bold"></asp:Label>
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
                </div>
            </div>
            <div class="container" style="overflow-x: scroll">
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
                                <asp:LinkButton ID="btnDelete" OnClick="btnDelete_Click" Style="margin-right:10px" class="btn btn-outline-danger" runat="server" CommandArgument="<%#Eval(nameof(RwaApartmaniDataLayer.Models.Apartment.Id)) %>" CausesValidation="false">Delete</asp:LinkButton>
                                <asp:LinkButton ID="btnSelect" OnClick="btnSelect_Click" class="btn btn-outline-dark" Style="width:50%" CommandArgument="<%#Eval(nameof(RwaApartmaniDataLayer.Models.Apartment.Id)) %>" runat="server" CausesValidation="false">Open</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                    </table>
                    </FooterTemplate>
                </asp:Repeater>
                 <div class="mb-3 float-end">
                <asp:Button ID="btnCreate" OnClick="btnCreate_Click" runat="server" class="btn btn-outline-primary" Text="Create new Apartment" />
            </div>
            </div>
           
        </div>
    </div>
    <!-- Modal Edit/Create apartment form-->
    <asp:Panel ID="pnlApartment" runat="server">
        <div class="container animate__animated animate__slideInDown" id="popup">
            <uc:EditApartmentControl runat="server" ID="EditApartmentControl" />
        </div>
    </asp:Panel>
    <%--Modal confirm dialog--%>
    <asp:Panel ID="pnlConfirm" runat="server">
        <div class="container animate__animated animate__slideInDown" id="popup_confirm">
            <uc:ApartmentDeleteControl runat="server" ID="ApartmentDeleteControl" />
        </div>
    </asp:Panel>
</asp:Content>
