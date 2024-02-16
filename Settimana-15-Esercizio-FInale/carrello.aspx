<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="carrello.aspx.cs" Inherits="Settimana_15_Esercizio_FInale.carrello" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <webopt:BundleReference runat="server" Path="~/Content/css" />
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar bg-danger py-4 border-opacity-75 mb-5">
            <div class="container d-flex align-items-center">
                <a class="navbar-brand text-warning bg-dark border border-2 border-warning rounded-pill px-3 py-2" href="default.aspx">
                    <img src="https://cdn.pixabay.com/photo/2013/07/13/10/21/rubiks-cube-157058_1280.png" alt="logo" height="40" />
                    Lele's Cubes
                </a>
                <a class="nav-link ms-auto" href="default.aspx">Home</a>
                <a class="nav-link ms-3" href="carrello.aspx">Carrello</a>
            </div>
        </nav>
        <p class="display-6 container">Il tuo carrello:</p>
        <div id="contenitore" runat="server">
        </div>
    </form>
</body>
</html>
