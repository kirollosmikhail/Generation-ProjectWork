<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

     <link rel="icon" type="image/x-icon" href="/img/icona1.png" />

    <link href="css/PazientiStile.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />

    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.10/themes/base/jquery-ui.css" type="text/css" media="all" />
    <link rel="stylesheet" href="http://static.jquery.com/ui/css/demo-docs-theme/ui.theme.css" type="text/css" media="all" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.10/jquery-ui.min.js"></script>

    <%-- Faccio comparire campi del recupera password, scompare login --%>
    <script>
        function PopupRecuperaPWD() {
            $(function () {
                document.getElementById("panelLogin").classList.add("hidden");
                document.getElementById("panelRecuperaPWD").classList.remove("hidden");
                document.getElementById("panelRegistra").classList.add("hidden");
                document.getElementById("panelBtnAccedi").classList.add("hidden");
                document.getElementById("panelBtnRecuperaPWD").classList.remove("hidden");
                document.getElementById("panelBtnRegistra").classList.add("hidden");
                document.getElementById("panelLinkReset").classList.add("hidden");
                document.getElementById("panelLinkSignup").classList.add("hidden");
                document.getElementById("panelLinkLogin").classList.remove("hidden");
                document.getElementById("txtMail").setAttribute("required", "true");
                document.getElementById("txtUSR").removeAttribute("required", "true");
                document.getElementById("txtPWD").removeAttribute("required", "true");
                document.getElementById("txtRegistraMail").removeAttribute("required", "true");
                document.getElementById("txtRegistraPWD").removeAttribute("required", "true");
                document.getElementById("txtRegistraConfermaPWD").removeAttribute("required", "true");
            });
        }
    </script>

    <%-- Faccio comparire i campi del login, scompare recupera pwd --%>
    <script>
        function Login() {
            $(function () {
                document.getElementById("panelLogin").classList.remove("hidden");
                document.getElementById("panelRecuperaPWD").classList.add("hidden");
                document.getElementById("panelRegistra").classList.add("hidden");
                document.getElementById("panelBtnAccedi").classList.remove("hidden");
                document.getElementById("panelBtnRecuperaPWD").classList.add("hidden");
                document.getElementById("panelBtnRegistra").classList.add("hidden");
                document.getElementById("panelLinkReset").classList.remove("hidden");
                document.getElementById("panelLinkSignup").classList.remove("hidden");
                document.getElementById("panelLinkLogin").classList.add("hidden");
                document.getElementById("txtMail").removeAttribute("required", "true");
                document.getElementById("txtUSR").setAttribute("required", "true");
                document.getElementById("txtPWD").setAttribute("required", "true");
                document.getElementById("txtRegistraMail").removeAttribute("required", "true");
                document.getElementById("txtRegistraPWD").removeAttribute("required", "true");
                document.getElementById("txtRegistraConfermaPWD").removeAttribute("required", "true");
            });
        }
    </script>

    <%-- Apertura inserimentoPaziente --%>
    <script>
        function Registra() {

            document.getElementById("panelLogin").classList.add("hidden");
            document.getElementById("panelRecuperaPWD").classList.add("hidden");
            document.getElementById("panelRegistra").classList.remove("hidden");
            document.getElementById("panelBtnAccedi").classList.add("hidden");
            document.getElementById("panelBtnRecuperaPWD").classList.add("hidden");
            document.getElementById("panelBtnRegistra").classList.remove("hidden");
            document.getElementById("panelLinkReset").classList.add("hidden");
            document.getElementById("panelLinkSignup").classList.add("hidden");
            document.getElementById("panelLinkLogin").classList.remove("hidden");
            document.getElementById("txtMail").removeAttribute("required", "true");
            document.getElementById("txtUSR").removeAttribute("required", "true");
            document.getElementById("txtPWD").removeAttribute("required", "true");
            document.getElementById("txtRegistraMail").setAttribute("required", "true");
            document.getElementById("txtRegistraPWD").setAttribute("required", "true");
            document.getElementById("txtRegistraConfermaPWD").setAttribute("required", "true");
        }
    </script>
</head>


<body style="background: linear-gradient(to left top, #305580 0%, #ffffff 100%); background-repeat: no-repeat; height: 100vh;">
    <form id="form1" runat="server" class="d-flex align-items-center justify-content-center h-100">

        <div class="mt-5 card px-3 py-5 rounded-4" style="background-color: #305580;">
            <div class="mb-5 card-image-top text-center">
                <img src="img/Logo.png" class="w-50" />
            </div>

            <%-- Panel LOGIN --%>
            <asp:Panel ID="panelLogin" runat="server" Visible="true" class="form-floating mb-4">
                <div class="form-floating mb-3 mx-auto loginInput">
                    <asp:TextBox ID="txtUSR" class="form-control" placeholder="name@example.com" type="email" required="true" runat="server"></asp:TextBox>
                    <label for="floatingInput">Email address</label>
                </div>
                <div class="form-floating mx-auto loginInput">
                    <asp:TextBox ID="txtPWD" class="form-control" placeholder="Password" runat="server" required="true" type="password"></asp:TextBox>
                    <label for="floatingPassword">Password</label>
                </div>
            </asp:Panel>

            <%-- Panel Recupera Password --%>
            <asp:Panel ID="panelRecuperaPWD" runat="server" class="form-floating mb-4 hidden">
                <div class="form-floating mb-3 mx-auto loginInput">
                    <asp:TextBox ID="txtMail" class="form-control" placeholder="name@example.com" runat="server" type="email"></asp:TextBox>
                    <label for="floatingInput">Email address</label>
                </div>
            </asp:Panel>


            <%-- Panel Registrazione Utente --%>
            <asp:Panel ID="panelRegistra" runat="server" class="form-floating mb-4 hidden">
                <div class="form-floating mb-3 mx-auto loginInput">
                    <asp:TextBox ID="txtRegistraMail" class="form-control" placeholder="name@example.com" runat="server" type="email"></asp:TextBox>
                    <label for="txtRegistraMail">Email address</label>
                </div>
                <div class="form-floating mb-3 mx-auto loginInput">
                    <asp:TextBox ID="txtRegistraPWD" class="form-control" placeholder="password" runat="server" type="password"></asp:TextBox>
                    <label for="txtRegistraPWD">Password</label>
                </div>
                <div class="form-floating mb-3 mx-auto loginInput">
                    <asp:TextBox ID="txtRegistraConfermaPWD" class="form-control" placeholder="password" runat="server" type="password"></asp:TextBox>
                    <label for="txtRegistraConfermaPWD">Conferma Password</label>
                </div>

            </asp:Panel>

            <%-- Label Errore generico --%>
            <asp:Panel ID="Panel1" runat="server" class="form-floating mb-4 text-center">
                <asp:Label ID="lblErroreLogin" runat="server" Text="" CssClass="text-white text-center" Visible="true"></asp:Label>
            </asp:Panel>

            <div class="text-center mt-3 mb-4">
                <%-- Bottone Accesso Login --%>
                <asp:Panel ID="panelBtnAccedi" runat="server" class="form-floating mb-4">
                    <asp:Button ID="btnAccedi" runat="server" Text="Accedi" class="btn btn-primary btn-lg" OnClick="btnAccedi_Click" />
                </asp:Panel>
                <%-- Bottone Recupera Password --%>
                <asp:Panel ID="panelBtnRecuperaPWD" runat="server" class="form-floating mb-4 hidden">
                    <asp:Button ID="btnRecuperaPWD" runat="server" Text="Recupera Password" class="btn btn-primary btn-lg" OnClick="btnRecuperaPWD_Click" />
                </asp:Panel>

                <%-- Bottone Registrati --%>
                <asp:Panel ID="panelBtnRegistra" runat="server" class="form-floating mb-4 hidden">
                    <asp:Button ID="btnRegistra" runat="server" Text="Registrati" class="btn btn-primary btn-lg" OnClick="btnRegistra_Click" />
                </asp:Panel>
            </div>

            <%-- Link registrazione e recupero password --%>
            <div class="row text-center">
                <div class="col mb-3">
                    <asp:Panel ID="panelLinkSignup" runat="server" class="form-floating mb-4">
                        <asp:LinkButton ID="linkSignup" runat="server" CssClass="text-white" OnClientClick="Registra(); return false;">Registrati</asp:LinkButton>
                    </asp:Panel>
                </div>

                <div class="col mb-3">
                    <asp:Panel ID="panelLinkReset" runat="server" class="form-floating mb-4">
                        <asp:LinkButton ID="linkReset" runat="server" CssClass="text-white" OnClientClick="PopupRecuperaPWD(); return false;">Password dimenticata?</asp:LinkButton>
                    </asp:Panel>
                </div>

                <asp:Panel ID="panelLinkLogin" runat="server" class="form-floating mb-4 hidden">
                    <asp:LinkButton ID="LinkLogin" runat="server" CssClass="text-white" OnClientClick="Login(); return false;">Torna a Login</asp:LinkButton>
                </asp:Panel>
            </div>
        </div>
    </form>
</body>
</html>
