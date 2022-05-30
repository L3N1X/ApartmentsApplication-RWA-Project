<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RegistrationControl.ascx.cs" Inherits="Zadatak01.App_UserControls.RegistrationControl" %>

<!-- FORM -->
<asp:Panel ID="PanelForma" runat="server" Visible="True">
    <fieldset class="p-4">
        <legend runat="server" meta:resourcekey="legendRegistration">Registration</legend>
        <div class="mb-3">
            <asp:Label ID="lblFname" for="txtFname" class="form-label" meta:resourcekey="lblFname" runat="server" Text="First name"></asp:Label>
            <asp:TextBox ID="txtFname" class="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" meta:resourcekey="rfvFname" ControlToValidate="txtFname" Display="Dynamic" ForeColor="Red">* Niste upisali ime</asp:RequiredFieldValidator>
        </div>
        <div class="mb-3">
            <asp:Label ID="lblLname" for="txtLname" class="form-label" meta:resourcekey="lblLname" runat="server" Text="Last name"></asp:Label>
            <asp:TextBox ID="txtLname" class="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" meta:resourcekey="rfvLname" ControlToValidate="txtLname" Display="Dynamic" ForeColor="Red">* Niste upisali prezime</asp:RequiredFieldValidator>
        </div>
        <div class="mb-3">
            <asp:Label ID="lblCity" for="ddlCity" class="form-label" meta:resourcekey="lblDdlCity" runat="server" Text="City"></asp:Label>
            <asp:DropDownList ID="ddlCity" class="form-select" runat="server"></asp:DropDownList>
        </div>
        <div class="mb-3">
            <asp:Label ID="lblUsername" for="txtUsername" class="form-label" meta:resourcekey="lblUsername" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="txtUsername" class="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                ControlToValidate="txtUsername" Display="Dynamic" meta:resourcekey="rfvUsername" ForeColor="Red">* Niste upisali korisničko ime</asp:RequiredFieldValidator>
            <asp:CustomValidator
                ID="CustomValidator1"
                ClientValidationFunction="Username_Validation"
                runat="server"
                ControlToValidate="txtUsername"
                Display="Dynamic"
                ForeColor="Red"
                meta:resourcekey="rfvBannedUsername"
                OnServerValidate="Username_ServerValidate">* Zabranjeno korisničko ime</asp:CustomValidator>
            <asp:CustomValidator 
                ID="CustomValidator2" 
                runat="server" 
                ControlToValidate="txtUsername"
                Display="Dynamic"
                ForeColor="Red"
                ClientValidationFunction="CheckUser_Validation"
                OnServerValidate="CheckUser_ServerValidate">* Već postoji korisnik s upisanim korisničkim imenom</asp:CustomValidator>


        </div>
        <div class="mb-3">
            <asp:Label ID="lblPassword" for="txtPassword" class="form-label" meta:resourcekey="lblPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="txtPassword" class="form-control" TextMode="Password" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" meta:resourcekey="rfvPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="Red">* Niste upisali lozinku</asp:RequiredFieldValidator>
        </div>
        <div class="mb-3">
            <asp:Label ID="lblConfirmPassword" for="txtConfirmPassword" class="form-label" meta:resourcekey="lblConfirmPassword" runat="server" Text="Confirm Password"></asp:Label>
            <asp:TextBox ID="txtConfirmPassword" class="form-control" TextMode="Password" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" meta:resourcekey="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" Display="Dynamic" ForeColor="Red">* Niste upisali potvrdu lozinku</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator3" runat="server"
                ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword"
                meta:resourcekey="rfvComparePassword"
                Display="Dynamic"
                ForeColor="Red">* Lozinke u oba polja moraju odgovarati</asp:CompareValidator>
        </div>

        <asp:Button ID="btnPosalji" runat="server" class="btn btn-warning" meta:resourcekey="btnSend" Text="Submit" OnClick="btnPosalji_Click" />

    </fieldset>
</asp:Panel>
<!-- // -->

<!-- PANEL PORUKA -->
<asp:Panel ID="PanelIspis" CssClass="container mt-5" runat="server" Visible="False">
    <div class='alert alert-success' role='alert'>
        <asp:Label ID="lblSuccessLogin" meta:resourcekey="lblSuccessLogin" runat="server" Text="Registration successful."></asp:Label>
    </div>
</asp:Panel>
<!-- // -->

<!-- USERNAME VALIDATION -->
<script type="text/javascript">
    function Username_Validation(sender, args) {
        if (args.Value.toLowerCase() == "admin") {
            args.IsValid = false;
        } else {
            args.IsValid = true;
        }
    }
</script>

<!-- USER CHECK VALIDATION -->
<script type="text/javascript">
    function CheckUser_Validation(sender, args) {
        const listOfUsers = JSON.parse('<%= Newtonsoft.Json.JsonConvert.SerializeObject(((rwaLib.Dal.IRepo)Application["database"]).LoadUsers()) %>');
        console.log(listOfUsers);

        if (listOfUsers.some(u => u.Username == args.Value)) {
            args.IsValid = false;
        } else {
            args.IsValid = true;
        }
    }
</script>
