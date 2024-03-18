<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePaziente.master" AutoEventWireup="true" CodeFile="PrenotazioniAttiveFiglia.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="containerPrenotazioni" class="p-5 pt-0" style="width: 100%;">

        <%-- PopUp prenota una visita --%>
        <div id="PopupPre" class="myModal" visible="false" runat="server">
            <div class="card text-center position-absolute start-50 top-50 translate-middle rounded" style="min-width: 33%">
                <div class="card-header p-3">
                    <h2 class="mb-0">Nuova Prenotazione</h2>
                </div>
                <div class="card-body d-flex justify-content-center flex-wrap p-5 gap-4">
                    <div class="d-flex flex-column gap-4">
                        <h4>Seleziona la sede desiderata</h4>
                        <div class="form-floating ">
                            <asp:DropDownList runat="server" class="form-select" AutoPostBack="True" ID="ddlNuovaPrenotazione" aria-label="Floating label select">
                            </asp:DropDownList>
                            <label for="ddlNuovaPrenotazione">Sede</label><%--nel for si deve inserire lo stesso ID della DDL--%>
                        </div>
                    </div>
                </div>
                <div class="card-footer d-flex justify-content-around p-3">
                    <asp:Button ID="btnAnnullaIns" class="btn btn-secondary" runat="server" Text="Annulla" OnClick="btnAnnullaIns_Click" />
                    <asp:Button ID="btnConfermaIns" class="btn btn-primary" runat="server" Text="Prenotati" OnClick="btnConfermaIns_Click" />
                </div>
            </div>
        </div>

        <%-- PopUp Pagamento --%>
        <div id="PopupPaga" class="myModal" visible="false" runat="server">
            <div class="card text-center position-absolute start-50 top-50 translate-middle rounded" style="min-width: 33%">
                <div class="card-header p-3">
                    <h2 class="mb-0">Conferma Pagamento?</h2>
                </div>
                <div class="card-body d-flex justify-content-center flex-wrap p-5 gap-4">
                    <div class="d-flex flex-column gap-4">
                        <div class="form-floating ">
                            <img src="img/PayPal.svg.png" style="width: 50%;"/>
                        </div>
                    </div>
                </div>
                <div class="card-footer d-flex justify-content-around p-3">
                    <asp:Button ID="btnAnnullaPaga" class="btn btn-secondary" runat="server" Text="Annulla" OnClick="btnAnnullaPaga_Click" />
                    <asp:Button ID="btnConfermaPaga" class="btn btn-primary" runat="server" Text="Paga con Paypal" OnClick="btnConfermaPaga_Click" />
                </div>
            </div>
        </div>
        <%-- FINE popup --%>

        <%-- Popup prenotazione andata a buon fine --%>
        <div id="PopupInfo" class="myModal" visible="false" runat="server">
            <div class="card text-center position-absolute start-50 top-50 translate-middle rounded" style="min-width: 33%">
                <div class="card-header p-3">
                    <h2 class="mb-0">Prenotazione richiesta con successo</h2>
                </div>
                <div class="card-body">
                    <div class="d-flex flex-column gap-4">
                        <div class="form-floating ">
                            <p>
                                La Sua richiesta di prenotazione per una visita è andata a buon fine.<br />
                                La nostra Segreteria ha preso in carico la Sua richiesta e provvederà il prima possibile
                                a fornirLe una data e un medico per la Sua visita.<br />
                                Dopo che Le verrà inviata una mail di avviso, dovrà entrare nel sito e pagare la prenotazione
                                per confermarla.<br />
                                La aspettiamo e le auguriamo buona giornata<br />
                                Il team Klinik
                            </p>
                        </div>
                    </div>
                </div>
                <div class="card-footer d-flex justify-content-around p-3">
                    <asp:Button ID="btnChiudi" class="btn btn-secondary" runat="server" Text="Chiudi" OnClick="btnChiudi_Click" />
                </div>
            </div>
        </div>


        <%-- Fine popup --%>

        <%-- Popup pagamento eseguito --%>
        <div id="PopupPagamentoEseguito" class="myModal" visible="false" runat="server">
            <div class="card text-center position-absolute start-50 top-50 translate-middle rounded" style="min-width: 33%">
                <div class="card-header p-3">
                    <h2 class="mb-0">Pagamento eseguito con successo</h2>
                </div>
                <div class="card-body">
                    <div class="d-flex flex-column gap-4">
                        <div class="form-floating ">
                            <h5>
                               Il tuo pagamento è andato a buon fine
                            </h5>
                        </div>
                    </div>
                </div>
                <div class="card-footer d-flex justify-content-around p-3">
                    <asp:Button ID="btnChiudiPopupPagamento" class="btn btn-secondary" runat="server" Text="Chiudi" OnClick="btnChiudiPopupPagamento_Click" />
                </div>
            </div>
        </div>


        <%-- Fine popup --%>


        <div style="display: flex; justify-content: space-between;">
            <h1>Prenotazioni Attive</h1>
        </div>

        <%-- Descrizione pagina --%>
        <div style="margin: 1em 0;" class="d-flex justify-content-between">
            <div class="d-flex justify-content-center">
                <p>Lista di tutte le nuove prenotazioni ancora da confermare o ancora da pagare</p>
            </div>
            <div>
                <asp:Button ID="btnPre" runat="server" Text="Nuova Prenotazione" class="btn btn-primary btn-lg" OnClick="btnPre_Click" />
            </div>
        </div>

        <asp:GridView ID="GrigliaPrenotazione" runat="server" AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="idPrenotazione" CssClass="table table-bordered table-hover table-striped table-responsive"
            OnPageIndexChanging="GrigliaPrenotazione_PageIndexChanging" ShowHeaderWhenEmpty="True" OnRowCommand="GrigliaPrenotazione_RowCommand" OnRowDataBound="GrigliaPrenotazione_RowDataBound">
            <Columns>
                <asp:BoundField DataField="Data" HeaderText="Data Prenotazione" DataFormatString="{0:g}" />
                <asp:BoundField DataField="IndirizzoSede" HeaderText="Sede" />
                <asp:BoundField DataField="Prestazione" HeaderText="Prestazione" />
                <asp:BoundField DataField="DataPrestazione" HeaderText="Data Prestazione" DataFormatString="{0:g}" />
                <asp:BoundField DataField="NominativoSanitario" HeaderText="Medico" />
                <asp:BoundField DataField="Prezzo" HeaderText="Prezzo" DataFormatString="{0:0.0,0 €}" />
                <asp:TemplateField HeaderText="Pagamenti">
                    <ItemTemplate>
                        <asp:Button ID="btnDownload"
                            CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="Paga" runat="server" Text="Paga" ControlStyle-CssClass="btn btn-primary" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>

