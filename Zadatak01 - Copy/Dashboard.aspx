<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Zadatak01.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
        Launch demo modal
    </button>

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
            <%--<fieldset>
                <legend>Apartments</legend>--%>
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
                                    <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" class="btn btn-outline-dark" Style="width: 100%" CommandArgument="<%#Eval(nameof(RwaApartmaniDataLayer.Models.Apartment.Id)) %>" runat="server" CausesValidation="false">Select</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                    </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            <%--</fieldset>--%>
        </div>
    </div>

    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title fw-bold" id="exampleModalLabel">
                        <asp:Label ID="lblModalTitle" runat="server" Text="Update apartment"></asp:Label>
                    </h5>
                    <button type="button" class="close" data-bs-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container">
                        <div class="row">

                            <div class="col-sm">
                                <div class="mb-3">
                                    <asp:Label ID="Label1" runat="server" Text="Apartment name (Croatian)"></asp:Label>
                                    <asp:TextBox ID="txtApartmentName" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="txtNameValidator" runat="server" ControlToValidate="txtApartmentName" Display="Dynamic" ForeColor="Red" ErrorMessage="Apartment name can't be empty"></asp:RequiredFieldValidator>
                                </div>

                                <div class="mb-3">
                                    <asp:Label ID="Label2" runat="server" Text="Apartment name (English)"></asp:Label>
                                    <asp:TextBox ID="txtApartmentNameEng" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtApartmentNameEng" Display="Dynamic" ForeColor="Red" ErrorMessage="Apartment name can't be empty"></asp:RequiredFieldValidator>
                                </div>

                                <div class="mb-3">
                                    <asp:Label ID="Label3" runat="server" Text="Price per night (Euro €)"></asp:Label>
                                    <asp:TextBox ID="txtPrice" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPrice" Display="Dynamic" ForeColor="Red" ErrorMessage="Price can't be empty"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Only numeric values are alowed" ControlToValidate="txtPrice" ValidationExpression="\d+" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>

                                <div class="mb-3">
                                    <asp:Label ID="Label4" runat="server" Text="Total rooms"></asp:Label>
                                    <asp:TextBox ID="txtTotalRooms" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTotalRooms" Display="Dynamic" ForeColor="Red" ErrorMessage="Total rooms can't be empty"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Only numeric values are alowed" ControlToValidate="txtTotalRooms" ValidationExpression="\d+" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="col-sm">
                                <div class="mb-3">
                                    <asp:Label ID="Label5" runat="server" Text="Max number of adults"></asp:Label>
                                    <asp:TextBox ID="txtAdults" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAdults" Display="Dynamic" ForeColor="Red" ErrorMessage="Max number of adults can't be empty"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Only numeric values are alowed" ControlToValidate="txtAdults" ValidationExpression="\d+" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>

                                <div class="mb-3">
                                    <asp:Label ID="Label6" runat="server" Text="Max number of children"></asp:Label>
                                    <asp:TextBox ID="txtChildren" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtChildren" Display="Dynamic" ForeColor="Red" ErrorMessage="Max number of children can't be empty"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Only numeric values are alowed" ControlToValidate="txtChildren" ValidationExpression="\d+" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>

                                <div class="mb-3">
                                    <asp:Label ID="Label7" runat="server" Text="Distance from beach (m)"></asp:Label>
                                    <asp:TextBox ID="txtBeach" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtBeach" Display="Dynamic" ForeColor="Red" ErrorMessage="Beach distance can't be empty"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Only numeric values are alowed" ControlToValidate="txtBeach" ValidationExpression="\d+" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>

                                <div class="mb-3">
                                    <asp:Label ID="Label8" runat="server" Text="Address"></asp:Label>
                                    <asp:TextBox ID="txtAddress" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtAddress" Display="Dynamic" ForeColor="Red" ErrorMessage="Address can't be empty"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-sm">
                                <div class="mb-3">
                                    <asp:Label ID="Label10" runat="server" Text="Tags"></asp:Label>
                                </div>
                                <div class="mb-3" id="tagsContainer">
                                    <asp:CheckBoxList ID="cblTags" runat="server" CssClass="form-check"></asp:CheckBoxList>
                                </div>
                            </div>

                            <div class="mb-3">
                                <asp:Label ID="Label9" runat="server" Text="City"></asp:Label>
                                <asp:DropDownList class="form-select" ID="ddlCity" AutoPostBack="true" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <asp:Button ID="btnUpdateOrCreateApartment" runat="server" Text="Update" CssClass="btn btn-primary" />
                    <%--<button type="button" class="btn btn-primary">Update apartment</button>--%>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
