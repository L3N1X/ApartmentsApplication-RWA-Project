<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="400.aspx.cs" Inherits="Zadatak01._400" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <!-- TITLE -->
    <title>Zadatak 01</title>

    <!-- BOOTSTRAP -->
    <link href="Content/bootstrap.min.css" rel="stylesheet"/>

    <!-- CUSTOM CSS -->
    <style>
        fieldset { border: 1px solid #ced4da; padding: inherit; border-radius: 4px; } 
        fieldset > legend { float: initial; width: auto; padding: revert; font-size: initial; margin: 0; }
    </style>

</head>
<body>
    <form id="form1" class="container text-center" runat="server">
        <h1>BAD REQUEST - Status code: 400</h1>
        <p>U zahtjevu nisu poslani svi parametri.</p>
    </form>
</body>
</html>