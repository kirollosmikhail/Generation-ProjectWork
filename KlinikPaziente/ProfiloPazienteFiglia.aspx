<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePaziente.master" AutoEventWireup="true" CodeFile="ProfiloPazienteFiglia.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="container" style="max-width: fit-content;">
        <div class="card text-center" style="min-width: 33%">

            <%--HEAD--%>
            <div class="card-header p-3">
                <h2 class="mb-0">Dati Personali</h2>
            </div>
            <%--HEAD-FINE--%>

            <%--BODY--%>
            <div class="card-body d-flex justify-content-center flex-wrap pt-2 pb-0 p-4 gap-4">
                <div class="gap-5" style="/*max-width: 73em; */ display: flex; flex-direction: row; /*width: 118em; */ justify-content: center;">
                    <column class="" style="width: 31em;">
                        <card class="card shadow my-4 pt-3 align-self-stretch" style="margin-bottom: 4em !important;">
                            <div class="card-body" style="text-align: center;">
                                <h5 class="card-title"><strong>Contatti</strong></h5>
                                <table class="table table-borderless">
                                    <tr>
                                        <td>
                                            <div class="form-floating formLoginLarge">
                                                <asp:TextBox ID="txtRegistraEmail" class="form-control formLoginLarge" placeholder="name@example.com" runat="server" type="email" autocomplete="username" ReadOnly="true"></asp:TextBox>
                                                <label for="txtRegistraEmail">Indirizzo Email</label>
                                            </div>
                                        </td>
                                        <td>
                                            <%--<div class="form-floating formLoginMedium card-footer d-flex justify-content-around p-3">--%>
                                                <asp:Button ID="btnPW" class="btn btn-primary" placeholder="password" runat="server" type="password" Text="Modifica Password" OnClick="btnPW_Click" />
                                            <%--</div>--%>
                                        </td>
                                    </tr>
                                    <tr class="riga">
                                        <td colspan="2">
                                            <hr />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <div class="form-floating formLoginMedium">
                                                <asp:TextBox ID="txtRegistraIndirizzo" class="form-control formLoginMedium" placeholder="Indirizzo" runat="server"></asp:TextBox>
                                                <label for="txtRegistraIndirizzo">Indirizzo</label>
                                            </div>
                                        </td>


                                        <td>
                                            <div class="form-floating formLoginSmall">
                                                <asp:TextBox ID="txtRegistraCap" class="form-control formLoginSmall" placeholder="CAP" runat="server" MaxLength="5"></asp:TextBox>
                                                <label for="txtRegistraCap">CAP</label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="form-floating formLoginMedium">
                                                <asp:TextBox ID="txtRegistraCitta" class="form-control formLoginMedium" placeholder="Citta" runat="server"></asp:TextBox>
                                                <label for="txtRegistraCitta">Citta</label>
                                            </div>
                                        </td>

                                        <td>
                                            <div class="form-floating formLoginSmall">
                                                <asp:TextBox ID="txtRegistraProvincia" class="form-control formLoginSmall" placeholder="Provincia" runat="server" MaxLength="2"></asp:TextBox>
                                                <label for="txtRegistraProvincia">Provincia</label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div class="form-floating formLoginLarge">
                                                <asp:TextBox ID="txtRegistraTelefono" class="form-control formLoginLarge" placeholder="Telefono" runat="server" MaxLength="10"></asp:TextBox>
                                                <label for="txtRegistraTelefono">Telefono</label>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </card>
                    </column>
                </div>

                <div class="gap-5" style="/*max-width: 73em; */ display: flex; flex-direction: row; /*width: 118em; */ justify-content: center;">
                    <column class="" style="width: 36em;">
                        <card class="card shadow my-4 pt-3 align-self-stretch" style="margin-bottom: 4em !important;">
                            <div class="card-body" style="text-align: center;">
                                <h5 class="card-title"><strong>Dati personali</strong></h5>
                                <table class="table table-borderless">
                                    <tr>
                                        <td colspan="2">
                                            <div class="form-floating formLoginLarge">
                                                <asp:TextBox ID="txtRegistraCodFiscale" class="form-control formLoginLarge" placeholder="Codice Fiscale" runat="server" MaxLength="16"></asp:TextBox>
                                                <label for="txtRegistraCodFiscale">Codice Fiscale</label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr class="riga">
                                        <td colspan="2">
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="form-floating formLoginMedium">
                                                <asp:TextBox ID="txtRegistraCognome" class="form-control formLoginMedium" placeholder="Cognome" runat="server"></asp:TextBox>
                                                <label for="txtRegistraCognome">Cognome</label>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="form-floating formLoginMedium">
                                                <asp:TextBox ID="txtRegistraNome" class="form-control formLoginMedium" placeholder="Nome" runat="server"></asp:TextBox>
                                                <label for="txtRegistraNome">Nome</label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="panelGenere" runat="server" class="form-floating formLoginLarge">

                                                <asp:DropDownList runat="server" class="form-select" ID="ddlGenere" aria-label="Floating label select">
                                                    <asp:ListItem Text="--Genere--" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Maschio" Value="M"></asp:ListItem>
                                                    <asp:ListItem Text="Femmina" Value="F"></asp:ListItem>
                                                    <asp:ListItem Text="Preferisco non rispondere" Value="N"></asp:ListItem>
                                                </asp:DropDownList>
                                                <label for="ddlGenere">Genere</label>
                                            </asp:Panel>
                                        </td>
                                        <td>
                                            <div class="form-floating formLoginMedium">
                                                <asp:TextBox ID="txtRegistraDataDiNascita" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                                                <label for="txtRegistraDataDiNascita">DataDiNascita</label>
                                            </div>
                                        </td>
                                    </tr>
                                </table>

                            </div>
                        </card>
                    </column>
                </div>
            </div>
        </div>
        <%--BODY-FINE--%>

        <%--INIZIO POPUP--%>
        <div id="inserisci" class="myModal" visible="false" runat="server">
            <div class="card text-center position-absolute start-50 top-50 translate-middle rounded" style="min-width: 33%">

                <%--HEAD--%>
                <div class="card-header p-3">


                    <h2 class="mb-0">Cambio password</h2>
                </div>
                <%--HEAD-FINE--%>

                <%--BODY--%>
                <div class="card-body d-flex justify-content-center flex-wrap p-5 gap-4">

                    <%--NUOVA PASSWORD--%>
                    <div class="d-flex flex-column gap-4">
                        <div class="form-floating">
                            <asp:TextBox ID="txtVecchiaPWD" class="form-control" runat="server" type="password" placeholder="Vecchia password" />
                            <label for="txtVecchiaPWD">Vecchia password</label>
                        </div>
                        <div class="form-floating">
                            <asp:TextBox ID="txtNuovaPWD" class="form-control" runat="server" type="password" placeholder="Nuova password" />
                            <label for="txtNuovaPWD">Nuova passowrd</label>
                        </div>
                        <div class="form-floating">
                            <asp:TextBox ID="txtConfermaPWD" class="form-control" runat="server" type="password" placeholder="Conferma password" />
                            <label for="txtConfermaPWD">Conferma password</label>
                        </div>
                    </div>
                </div>
                <%--BODY-FINE--%>

                <%--FOOTER--%>
                <div class="card-footer d-flex justify-content-around p-3">
                    <asp:Button ID="btnAnnulla" class="btn btn-secondary" runat="server" Text="Annulla" OnClick="btnAnnullaIns_Click" />
                    <%--per il funzionamento: protected void btnAnnullaIns_Click(object sender, EventArgs e), in Oggetti.aspx.cs--%>
                    <asp:Button ID="BtnConfermaPWD" class="btn btn-primary" runat="server" Text="Salva" OnClick="BtnConfermaPWD_Click" />
                    <%--per il funzionamento: protected void btnConfermaIns_Click(object sender, EventArgs e), in Oggetti.aspx.cs--%>
                </div>
                <%--FOOTER-FINE--%>
            </div>
        </div>
        <%--FINE POPUP--%>

        <div class="card-body d-flex justify-content-center flex-wrap p-2 gap-1">

            <%--FOOTER--%>
            <div class="card-footer d-flex justify-content-around p-3">
                <%--<asp:Button ID="btnAnnullaIns" class="btn btn-secondary" runat="server" Text="Annulla" OnClick="btnAnnullaIns_Click" />--%>
                <%--per il funzionamento: protected void btnAnnullaIns_Click(object sender, EventArgs e), in Oggetti.aspx.cs--%>
                <asp:Button ID="btnSalva" class="btn btn-primary" runat="server" Text="Salva dati" OnClick="btnSalva_Click" />
                <%--per il funzionamento: protected void btnConfermaIns_Click(object sender, EventArgs e), in Oggetti.aspx.cs--%>
            </div>

            <%--FOOTER-FINE--%>
        </div>
    </div>
</asp:Content>

