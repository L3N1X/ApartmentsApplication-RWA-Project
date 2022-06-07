<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateTagControl.ascx.cs" Inherits="Zadatak01.UserControls.CreateTagControl" %>
<div class="offcanvas-header" id="popup-header">
    <%--<h4 runat="server" class="offcanvas-title" id="offcanvasTitle">Edit apartment</h4>--%>
    <asp:Label ID="lblTitle" runat="server" Text="Create new tag"></asp:Label>
</div>
<div id="offcanvas" class="offcanvas-body small d-flex justify-content-center">
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
            <asp:DropDownList ID="ddlTagType" runat="server" class="form-select"></asp:DropDownList>
        </div>

        <div class="mb-3 float-end">
            <asp:Button ID="btnCreateTag" runat="server" Text="Create new tag" class="btn btn-primary" OnClick="btnCreateTag_Click" />
            <asp:Button ID="btnClose" runat="server" Text="Close" class="btn btn-secondary" OnClick="btnClose_Click" CausesValidation="false" />
        </div>
    </div>
</div>
