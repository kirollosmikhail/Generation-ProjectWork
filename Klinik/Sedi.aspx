<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sedi.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHoldertitolo" runat="Server">
    <h1>Sedi Klinik nel Mondo</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%--INIZIO INSERISCI POPUP--%>
    <div id="inserisci" class="myModal" visible="false" runat="server">
        <div class="card text-center position-absolute start-50 top-50 translate-middle rounded" style="min-width: 33%">

            <%--HEAD--%>
            <div class="card-header p-3">
                <h2 class="mb-0">Inserisci nuova sede</h2>
            </div>
            <%--FINE HEAD--%>

            <div class="card-body d-flex justify-content-center flex-wrap p-5 gap-4">
                <div class="d-flex flex-column gap-2 ft-Large">
                    <div class="form-floating">
                        <asp:TextBox ID="txtIndirizzoIns" class="form-control ft-Medium" runat="server" type="text" placeholder="" />
                        <label for="txtIndirizzoIns">Indirizzo</label>
                        <asp:Label CssClass="text-danger" ID="lblInsindirizzo" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-floating">
                        <asp:TextBox ID="txtCAPIns" class="form-control ft-Small" runat="server" type="text" placeholder="" />
                        <label for="txtCAPIns">CAP</label>
                        <asp:Label CssClass="text-danger" ID="lblInsCAP" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-floating">
                        <asp:TextBox ID="txtTelefonoIns" class="form-control ft-Medium" runat="server" type="text" placeholder="" />
                        <label for="txtTelefonoIns">Telefono</label>
                        <asp:Label CssClass="text-danger" ID="lblInstelefono" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="d-flex flex-column gap-2 ft-Large">
                    <div class="form-floating">
                        <asp:TextBox ID="txtCittaIns" class="form-control ft-Medium" runat="server" type="text" placeholder="" />
                        <label for="txtCittaIns">Città</label>
                        <asp:Label CssClass="text-danger" ID="lblInscitta" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-floating">
                        <asp:TextBox ID="txtProvinciaIns" class="form-control ft-Small" runat="server" type="text" placeholder="" />
                        <label for="txtProvinciaIns">Provincia</label>
                        <asp:Label CssClass="text-danger" ID="lblInsprovincia" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-floating">
                        <asp:TextBox ID="txtEmailIns" class="form-control ft-Large" runat="server" type="text" placeholder="" />
                        <label for="txtEmailIns">Email</label>
                        <asp:Label CssClass="text-danger" ID="lblInsemail" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>

            <%--FOOTER--%>
            <div class="card-footer d-flex justify-content-around p-3">
                <asp:Button ID="btnAnnullaIns" class="btn btn-secondary" runat="server" Text="Annulla" OnClick="btnAnnullaIns_Click" />
                <asp:Button ID="btnConfermaIns" class="btn btn-primary" runat="server" Text="Inserisci" OnClick="btnConfermaIns_Click" />
            </div>
            <%--FOOTER-FINE--%>
        </div>
    </div>
    <%--FINE INSERISCI POPUP--%>

    <%--INIZIO MODIFICA POPUP--%>
    <div id="modifica" class="myModal" visible="false" runat="server">
        <div class="card text-center position-absolute start-50 top-50 translate-middle rounded" style="min-width: 33%">

            <%--HEAD--%>
            <div class="card-header p-3">
                <h2 class="mb-0">Modifica sede</h2>
            </div>
            <%--FINE HEAD--%>

            <div class="card-body d-flex justify-content-center flex-wrap p-5 gap-4">
                <div class="d-flex flex-column gap-2 ft-Large">
                    <div class="form-floating">
                        <asp:TextBox ID="txtIndirizzoMod" class="form-control ft-Medium" runat="server" type="text" placeholder="" />
                        <label for="txtIndirizzoMod">Indirizzo</label>
                        <asp:Label CssClass="text-danger" ID="lblModindirizzo" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-floating">
                        <asp:TextBox ID="txtCAPMod" class="form-control ft-Small" runat="server" type="text" placeholder="" />
                        <label for="txtCAPMod">CAP</label>
                        <asp:Label CssClass="text-danger" ID="lblModCAP" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-floating">
                        <asp:TextBox ID="txtTelefonoMod" class="form-control ft-Medium" runat="server" type="text" placeholder="" />
                        <label for="txtTelefonoMod">Telefono</label>
                        <asp:Label CssClass="text-danger" ID="lblModtelefono" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="d-flex flex-column gap-2 ft-Large">
                    <div class="form-floating">
                        <asp:TextBox ID="txtCittaMod" class="form-control ft-Medium" runat="server" type="text" placeholder="" />
                        <label for="txtCittaMod">Città</label>
                        <asp:Label CssClass="text-danger" ID="lblModcitta" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-floating">
                        <asp:TextBox ID="txtProvinciaMod" class="form-control ft-Small" runat="server" type="text" placeholder="" />
                        <label for="txtProvinciaMod">Provincia</label>
                        <asp:Label CssClass="text-danger" ID="lblModprovincia" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-floating">
                        <asp:TextBox ID="txtEmailMod" class="form-control ft-Large" runat="server" type="text" placeholder="" />
                        <label for="txtEmailMod">Email</label>
                        <asp:Label CssClass="text-danger" ID="lblModemail" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>

            <%--FOOTER--%>
            <div class="card-footer d-flex justify-content-around p-3">
                <asp:Button ID="btnAnnullaMod" class="btn btn-secondary" runat="server" Text="Annulla" OnClick="btnAnnullaMod_Click" />
                <asp:Button ID="btnConfermaMod" class="btn btn-primary" runat="server" Text="Modifica" OnClick="btnConfermaMod_Click" />
            </div>
            <%--FOOTER-FINE--%>
        </div>
    </div>
    <%--FINE MODIFICA POPUP--%>

    <div class="d-flex justify-content-center mb-4">
        <asp:Button ID="btnInserisci" class="btn btn-primary" runat="server" Text="Inserisci Nuova Sede" OnClick="btnInserisci_Click" />
    </div>

    <%--INIZIO GRIGLIA SEDE--%>
    <div>
        <asp:GridView ID="grigliaSedi" runat="server" CssClass="table table-bordered table-hover table-striped table-responsive" AutoGenerateColumns="False" DataKeyNames="idSede" OnSelectedIndexChanged="grigliaSedi_SelectedIndexChanged" OnPageIndexChanging="grigliaSedi_PageIndexChanging" HeaderStyle-HorizontalAlign="Center">
            <columns>
                <asp:BoundField DataField="Indirizzo" HeaderText="Indirizzo"></asp:BoundField>
                <asp:BoundField DataField="Citta" HeaderText="Città"></asp:BoundField>
                <asp:BoundField DataField="Provincia" HeaderText="Provincia" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                <asp:BoundField DataField="CAP" HeaderText="CAP" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                <asp:BoundField DataField="Email" HeaderText="Email"></asp:BoundField>
                <asp:CommandField SelectText="Modifica" ShowSelectButton="True" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" ItemStyle-HorizontalAlign="Center"></asp:CommandField>
            </columns>
        </asp:GridView>
    </div>
    <%--FINE GRIGLIA SEDE--%>
</asp:Content>

