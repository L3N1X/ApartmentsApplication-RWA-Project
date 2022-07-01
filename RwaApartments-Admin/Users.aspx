<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Zadatak01.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
   <div class="container mt-5">
       <div class="row mb-3">
           <div class="col-sm text-center">
               <h5 style="text-align:center">Username</h5>
           </div>
           <div class="col-sm text-center">
              <h5 style="text-align:center">E-mail</h5>
           </div>
           <div class="col-sm text-center">
               <h5 style="text-align:center">Phone</h5>
           </div>
           <div class="col-sm text-center">
              <h5 style="text-align:center">Address</h5>
           </div>
       </div>
       <div class="container" style="max-height:70vh; overflow-y:scroll">
           <asp:Repeater ID="rptUsers" runat="server">
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
                        <th scope="row" class="col-sm text-center">
                            <%#Eval(nameof(RwaApartmaniDataLayer.Models.User.UserName)) %>
                        </th>
                        <td id="count" class="col-sm text-center"" style="text-align: left">
                            <asp:Label ID="lblEmail" runat="server" Style="font-size: 1.1rem" Text="<%#Eval(nameof(RwaApartmaniDataLayer.Models.User.Email)) %>"></asp:Label>
                        </td>
                        <td class="col-sm text-center"" style="text-align: left">
                            <asp:Label ID="Label1" runat="server" Style="font-size: 1.1rem" Text="<%#Eval(nameof(RwaApartmaniDataLayer.Models.User.PhoneNumber)) %>"></asp:Label>
                        </td>
                        <td class="col-sm text-center"" style="text-align: left">
                            <asp:Label ID="Label2" runat="server" Style="font-size: 1.1rem" Text="<%#Eval(nameof(RwaApartmaniDataLayer.Models.User.Address)) %>"></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
       </div>
       
   </div>
</asp:Content>
