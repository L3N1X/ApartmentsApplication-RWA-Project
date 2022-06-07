<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditApartmentControl.ascx.cs" Inherits="Zadatak01.UserControls.EditApartmentControl" %>
<div class="offcanvas-header" id="popup-header">
    <%--<h4 runat="server" class="offcanvas-title" id="offcanvasTitle">Edit apartment</h4>--%>
    <asp:Label ID="lblTitle" runat="server" Text="Create new apartment"></asp:Label>
</div>
<div id="offcanvas" class="offcanvas-body small d-flex justify-content-center">
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
                <fieldset>
                    <legend>Tags</legend>
                    <div class="mb-3" id="tagsContainer">
                        <asp:CheckBoxList ID="cblTags" runat="server" CssClass="form-check"></asp:CheckBoxList>
                    </div>
                </fieldset>
            </div>
            <div class="container">
                <div class="row">
                    <div class="col-sm">
                        <div class="mb-3">
                            <asp:Label ID="Label9" runat="server" Text="City"></asp:Label>
                            <asp:DropDownList class="form-select" ID="ddlCity" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm">
                        <div class="mb-3">
                            <asp:Label ID="Label10" runat="server" Text="Apartment owner"></asp:Label>
                            <asp:DropDownList class="form-select" ID="ddlApartmentOwner" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm">
                        <div class="mb-3">
                            <asp:Label ID="Label11" runat="server" Text="Current status"></asp:Label>
                            <asp:DropDownList class="form-select" ID="ddlStatus" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="mb-3 float-end">
            <asp:Panel ID="pnlUpdate" runat="server" Visible="false">
                <asp:Button ID="btnUpdate" class="btn btn-warning" runat="server" OnClick="btnUpdate_Click" Text="Update" />
                <asp:Button ID="btnClose2" class="btn btn-secondary" OnClick="btnClose_Click" runat="server" CausesValidation="false" Text="Close" />
            </asp:Panel>
            <asp:Panel ID="pnlCreate" runat="server" Visible="true">
                <asp:Button ID="btnCreate" runat="server" class="btn btn-primary" OnClick="btnCreate_Click" Text="Create new apartment" />
                <asp:Button ID="btnClose1" class="btn btn-secondary" OnClick="btnClose_Click" runat="server" CausesValidation="false" Text="Close" />
            </asp:Panel>

        </div>
    </div>
</div>
