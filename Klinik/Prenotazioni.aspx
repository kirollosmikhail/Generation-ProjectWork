<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Prenotazioni.aspx.cs" Inherits="Prenotazioni" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<%--TITOLO PAGINA--%>
<asp:Content ID="Titolo" ContentPlaceHolderID="ContentPlaceHoldertitolo" runat="Server">
    <h1>Prenotazioni</h1>
</asp:Content>

<%--CONTENUTO PAGINA--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="d-flex justify-content-center mb-4">

        <asp:Panel ID="Panel2" runat="server" class="form-floating">
            <asp:TextBox runat="server" class="form-control" ID="txtNominativo" placeholder="." AutoPostBack="true" OnTextChanged="Page_Load"></asp:TextBox>
            <label for="txtNominativo">Filtro Nominativo</label>
        </asp:Panel>
    </div>

    <asp:GridView runat="server" CssClass="table table-bordered table-hover table-striped table-responsive" ID="gridPrenotazioni" AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="idPrenotazione" OnSelectedIndexChanged="gridPrenotazioni_SelectedIndexChanged">
        <columns>
            <asp:BoundField DataField="Data" HeaderText="Data Prenotazione" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>
            <asp:BoundField DataField="NominativoPaziente" HeaderText="Nominativo"></asp:BoundField>
            <asp:BoundField DataField="TelefonoPaziente" HeaderText="Telefono"></asp:BoundField>
            <asp:BoundField DataField="Email" HeaderText="UserMail"></asp:BoundField>
            <asp:BoundField DataField="Prestazione" HeaderText="Prestazione"></asp:BoundField>
            <asp:BoundField DataField="IndirizzoSedeCompleto" HeaderText="Indirizzo"></asp:BoundField>
            <asp:BoundField DataField="DataPagamento" HeaderText="Data Pagamento" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>
            <asp:BoundField DataField="Prezzo" HeaderText="Prezzo" SortExpression="."></asp:BoundField>
            <asp:BoundField DataField="Pagato" HeaderText="Pagato"></asp:BoundField>
            <asp:CommandField ShowSelectButton="True" HeaderText="Conferma" InsertText="Visualizza" ButtonType="Button" ControlStyle-CssClass="btn btn-primary"></asp:CommandField>
        </columns>
    </asp:GridView>

    <%--POPUP AGGIUNGI--%>
    <div id="popAggiungi" class="myModal" visible="false" runat="server">
        <div class="card text-center position-absolute start-50 top-50 translate-middle rounded" style="min-width: 33%">

            <%--HEAD--%>
            <div class="card-header p-3">


                <h2 class="mb-0">Aggiungi Prestazione</h2>
            </div>
            <%--HEAD-FINE--%>

            <%--BODY--%>
            <div class="card-body d-flex justify-content-center p-5 gap-4 ">

                <%--SEZION1--%>
                <div class="d-flex flex-column gap-2 ft-Large">

                    <div class="form-floating">
                        <asp:DropDownList ID="ddlSanitario" class="form-select ft-Large" aria-label="Floating label select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="riempiddlOre">
                        </asp:DropDownList>
                        <label for="ddlSanitario" runat="server">Sanitario</label>
                        <asp:Label CssClass="text-danger" ID="lblAvvSanitario" runat="server" Text=""></asp:Label>
                    </div>

                    <div class="form-floating">
                        <asp:TextBox ID="txtData" class="form-control ft-Medium" runat="server" type="date" placeholder="Prezzo" AutoPostBack="true" OnTextChanged="riempiddlOre"/>
                        <label for="txtData">Data Inizio Prestazione</label>
                        <asp:Label CssClass="text-danger" ID="lblAvvData" runat="server" Text=""></asp:Label>
                    </div>

                    <asp:Panel ID="Pora" runat="server" class="form-floating">
                        <asp:DropDownList ID="ddlora" class="form-select ft-Large" aria-label="Floating label select" runat="server">
                            <asp:ListItem Value="0">--Seleziona--</asp:ListItem>
                        </asp:DropDownList>
                        <label for="ddlora" runat="server">Orari disponibili</label>
                        <asp:Label CssClass="text-danger" ID="lblAvvOra" runat="server" Text=""></asp:Label>
                    </asp:Panel>
                </div>
            </div>


            <%--BODY-FINE--%>

            <%--FOOTER--%>
            <div class="card-footer d-flex justify-content-around p-3">
                <asp:Button ID="btnAnnullaAgg" class="btn btn-secondary" runat="server" Text="Annulla" OnClick="btnAnnullaAgg_Click" />
                <asp:Button ID="btnConfermaAgg" class="btn btn-primary" runat="server" Text="Inserisci" OnClick="btnConfermaAgg_Click" />
            </div>
            <%--FOOTER-FINE--%>
        </div>
    </div>
</asp:Content>

