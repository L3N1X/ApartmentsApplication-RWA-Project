<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TagDeleteControl.ascx.cs" Inherits="Zadatak01.UserControls.TagDeleteControl" %>
<div id="offcanvas" class="offcanvas-body small d-flex justify-content-center">
    <div class="container">
        <div class="container">
            <div class="mt-4">
                <h5 style="text-align: center">
                    <asp:Label ID="lblTitle" runat="server" Text="Are you sure you want to delete ?"></asp:Label>
                </h5>
            </div>
            <div class="mb-3">
                <asp:Panel ID="pnlButtons" runat="server">
                    <div class="d-flex justify-content-center">
                        <asp:Button ID="btnNo" OnClick="btnNo_Click" class="btn btn-dark" Style="margin-top:2rem; margin-right:.5rem; width:20%" runat="server" Text="No" />
                        <asp:Button ID="btnYes" OnClick="btnYes_Click" class="btn btn-outline-dark" Style="margin-top:2rem; margin-left:.5rem; width:20%" runat="server" Text="Yes" />
                    </div> 
                </asp:Panel>
            </div>
        </div>
    </div>
</div>