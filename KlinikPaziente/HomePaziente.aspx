<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePaziente.aspx.cs" Inherits="HomePaziente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Home</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />

    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.10/themes/base/jquery-ui.css" type="text/css" media="all" />
    <link rel="stylesheet" href="http://static.jquery.com/ui/css/demo-docs-theme/ui.theme.css" type="text/css" media="all" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.10/jquery-ui.min.js"></script>

    <script>
        function ingresso() {
            console.log("popup");
        }

        function funzione() {
            console.log("CIAONE");
            console.log(sessionStorage.getItem("posizione"));
            if (sessionStorage.getItem("posizione") == null) {
                Tab1();
            }
            if (sessionStorage.getItem("posizione") == "1") {
                Tab1();
            }
            if (sessionStorage.getItem("posizione") == "2") {
                Tab2();
            }
            if (sessionStorage.getItem("posizione") == "3") {
                Tab3();
            }
            if (sessionStorage.getItem("posizione") == "4") {
                Tab4();
            }
            if (sessionStorage.getItem("posizione") == "5") {
                Tab5();
            }

        }


        function Tab1() {
            console.log("entro nella 1");
            $("#prenotazioni-tab-pane").load("/PrenotazioniAttive.aspx #container");
            document.getElementById("prenotazioni-tab").classList.add("active");
            document.getElementById("calendario-tab").classList.remove("active");
            document.getElementById("prestazioni-tab").classList.remove("active");
            document.getElementById("pagamenti-tab").classList.remove("active");
            document.getElementById("utente-tab").classList.remove("active");
            document.getElementById("prenotazioni-tab-pane").classList.add("show", "active");
            document.getElementById("calendario-tab-pane").classList.remove("show", "active");
            document.getElementById("prestazioni-tab-pane").classList.remove("show", "active");
            document.getElementById("pagamenti-tab-pane").classList.remove("show", "active");
            document.getElementById("utente-tab-pane").classList.remove("show", "active");
            sessionStorage.setItem("posizione", "1");
            console.log("il localStorage value posizione e': ");
            console.log(sessionStorage.getItem("posizione"));
            console.log("esco dalla 1");
        }

        function Tab2() {
            console.log("entro nella 2");
            $("#calendario-tab-pane").load("/CalendarioPrestazioni.aspx #container");
            document.getElementById("prenotazioni-tab").classList.remove("active");
            document.getElementById("calendario-tab").classList.add("active");
            document.getElementById("prestazioni-tab").classList.remove("active");
            document.getElementById("pagamenti-tab").classList.remove("active");
            document.getElementById("utente-tab").classList.remove("active");
            document.getElementById("prenotazioni-tab-pane").classList.remove("show", "active");
            document.getElementById("calendario-tab-pane").classList.add("show", "active");
            document.getElementById("prestazioni-tab-pane").classList.remove("show", "active");
            document.getElementById("pagamenti-tab-pane").classList.remove("show", "active");
            document.getElementById("utente-tab-pane").classList.remove("show", "active");
            sessionStorage.setItem("posizione", "2");
            console.log("il localStorage value posizione e': ");
            console.log(sessionStorage.getItem("posizione"));
            console.log("esco dalla 2");
        }

        function Tab3() {
            console.log("entro nella 3");
            $("#prestazioni-tab-pane").load("/Prestazioni.aspx #container");
            document.getElementById("calendario-tab").classList.remove("active");
            document.getElementById("prenotazioni-tab").classList.remove("active");
            document.getElementById("prestazioni-tab").classList.add("active");
            document.getElementById("pagamenti-tab").classList.remove("active");
            document.getElementById("utente-tab").classList.remove("active");
            document.getElementById("calendario-tab-pane").classList.remove("show", "active");
            document.getElementById("prenotazioni-tab-pane").classList.remove("show", "active");
            document.getElementById("prestazioni-tab-pane").classList.add("show", "active");
            document.getElementById("pagamenti-tab-pane").classList.remove("show", "active");
            document.getElementById("utente-tab-pane").classList.remove("show", "active");
            sessionStorage.setItem("posizione", "3");
            console.log("il localStorage value posizione e': ");
            console.log(sessionStorage.getItem("posizione"));
            console.log("esco dalla 3");
        }

        function Tab4() {
            console.log("entro nella 4");
            $("#pagamenti-tab-pane").load("/StoricoPagamenti.aspx #container");
            document.getElementById("calendario-tab").classList.remove("active");
            document.getElementById("prenotazioni-tab").classList.remove("active");
            document.getElementById("prestazioni-tab").classList.remove("active");
            document.getElementById("pagamenti-tab").classList.add("active");
            document.getElementById("utente-tab").classList.remove("active");
            document.getElementById("calendario-tab-pane").classList.remove("show", "active");
            document.getElementById("prenotazioni-tab-pane").classList.remove("show", "active");
            document.getElementById("prestazioni-tab-pane").classList.remove("show", "active");
            document.getElementById("pagamenti-tab-pane").classList.add("show", "active");
            document.getElementById("utente-tab-pane").classList.remove("show", "active");
            sessionStorage.setItem("posizione", "4");
            console.log("il localStorage value posizione e': ");
            console.log(sessionStorage.getItem("posizione"));

            console.log("esco dalla 4");
        }
        function Tab5() {
            console.log("entro nella 5");
            $("#utente-tab-pane").load("/ProvaPagina.aspx #container");
            document.getElementById("calendario-tab").classList.remove("active");
            document.getElementById("prenotazioni-tab").classList.remove("active");
            document.getElementById("prestazioni-tab").classList.remove("active");
            document.getElementById("pagamenti-tab").classList.remove("active");
            document.getElementById("utente-tab").classList.add("active");
            document.getElementById("calendario-tab-pane").classList.remove("show", "active");
            document.getElementById("prenotazioni-tab-pane").classList.remove("show", "active");
            document.getElementById("prestazioni-tab-pane").classList.remove("show", "active");
            document.getElementById("pagamenti-tab-pane").classList.remove("show", "active");
            document.getElementById("utente-tab-pane").classList.add("show", "active");
            sessionStorage.setItem("posizione", "5");
            console.log("il localStorage value posizione e': ");
            console.log(sessionStorage.getItem("posizione"));
            console.log("esco dalla 5");
        }

    </script>



</head>
<body>
    <form id="form1" runat="server">

        <%-- Navbar Superiore con logo nome e logout --%>
        <div id="navbar">
            <nav class="navbar navbar-expand-xxl bg-primary-subtle mb-md-4">
                <div class="container-fluid">
                    <a class="navbar-brand ">
                        <img src="img/logo.png" alt="Logo" class="d-inline-block align-text-top w-25" id="logo2" />
                    </a>

                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarNavDropdown">
                        <div class="ms-auto">
                            <asp:Label ID="lblNome" class="me-4" runat="server" Text="Benvenuto Nome e Cognome"></asp:Label>
                            <asp:Button ID="btnLogout" class="btn btn-primary" runat="server" Text="Logout" />
                        </div>
                    </div>
                </div>
            </nav>
        </div>

        <%-- Tab --%>
        <ul class="nav nav-tabs d-flex justify-content-center" id="myTab" role="tablist">
            <li class="nav-item" role="presentation">
                <button class="nav-link mx-3" id="prenotazioni-tab" data-bs-toggle="tab" data-bs-target="#prenotazioni-tab-pane" type="button" role="tab" aria-controls="prenotazioni-tab-pane" aria-selected="false" onclick="Tab1(); return false;">Prenotazioni</button>
            </li>
            <li class="nav-item" role="presentation">
                <button class="nav-link mx-3" id="calendario-tab" data-bs-toggle="tab" data-bs-target="#calendario-tab-pane" type="button" role="tab" aria-controls="calendario-tab-pane" aria-selected="true" onclick="Tab2(); return false;">Calendario</button>
            </li>
            <li class="nav-item" role="presentation">
                <button class="nav-link mx-3" id="prestazioni-tab" data-bs-toggle="tab" data-bs-target="#prestazioni-tab-pane" type="button" role="tab" aria-controls="prestazioni-tab-pane" aria-selected="false" onclick="Tab3(); return false;">Prestazioni</button>
            </li>
            <li class="nav-item" role="presentation">
                <button class="nav-link mx-3" id="pagamenti-tab" data-bs-toggle="tab" data-bs-target="#pagamenti-tab-pane" type="button" role="tab" aria-controls="pagamenti-tab-pane" aria-selected="false" onclick="Tab4(); return false;">Storico Pagamenti</button>
            </li>
            <li class="nav-item" role="presentation">
                <button class="nav-link mx-3" id="utente-tab" data-bs-toggle="tab" data-bs-target="#utente-tab-pane" type="button" role="tab" aria-controls="utente-tab-pane" aria-selected="false" onclick="Tab5(); return false;">Profilo Utente</button>
            </li>

        </ul>


        <div class="tab-content" id="myTabContent">


            <div class="tab-pane fade" id="prenotazioni-tab-pane" role="tabpanel" aria-labelledby="prenotazioni-tab" tabindex="0">Le prenotazioni attive, il btn crea prenotazione, il pagamento prenotazione</div>
            <div class="tab-pane fade" id="calendario-tab-pane" role="tabpanel" aria-labelledby="calendario-tab" tabindex="0">qui ci va il calendario con prestazioni future</div>
            <div class="tab-pane fade" id="prestazioni-tab-pane" role="tabpanel" aria-labelledby="prestazioni-tab" tabindex="0">qui ci vanno le prestazioni passate con possibilità di download dei file</div>
            <div class="tab-pane fade" id="pagamenti-tab-pane" role="tabpanel" aria-labelledby="pagamentiTab" tabindex="0">qualcosa con i pagamenti</div>
            <div class="tab-pane fade" id="utente-tab-pane" role="tabpanel" aria-labelledby="utente-tab" tabindex="0">pagina personale utente</div>
        </div>


        <%-- Footer --%>

        <footer class="text-center bg-body-tertiary text-muted fixed-bottom">


            <section class="">
                <div class="container text-center text-md-start mt-3">

                    <div class="row mt-3 text-center">

                        <div class="col-4 mx-auto mb-2">
                            <!-- Content -->
                            <h6 class="text-uppercase fw-bold mb-4">
                                <i class="fas fa-gem me-3"></i>KLINIK
                            </h6>
                            <p>
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor
                                incididunt ut labore et dolore magna aliqua. 
                            </p>
                        </div>
                        <%-- CONTATTI --%>

                        <div class="col-4 mx-auto mb-md-0 mb-2">

                            <h6 class="text-uppercase fw-bold mb-4">Contatti</h6>
                            <p class="mb-2">
                                <i class="fas fa-envelope me-3"></i>
                                Mail: info@example.com
                            </p>
                            <p class="mb-2">
                                <i class="fas fa-phone me-3"></i>
                                Telefono: + 01 234 567 88
                            </p>
                            <p class="mb-2">
                                <i class="fas fa-print me-3"></i>
                                Telefono: + 01 234 567 89
                            </p>
                        </div>
                        <%-- SEDI --%>

                        <div class="col-4 mx-auto mb-2">

                            <h6 class="text-uppercase fw-bold mb-4">Sedi
                            </h6>
                            <p class="mb-2">
                                Torino
                            </p>
                            <p class="mb-2">
                                Milano
                            </p>
                            <p class="mb-2">
                                Palermo
                            </p>

                        </div>
                    </div>
                </div>
            </section>
        </footer>

    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>

</body>
</html>
