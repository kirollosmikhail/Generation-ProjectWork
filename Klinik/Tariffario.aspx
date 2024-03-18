<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Tariffario.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<%--TITOLO PAGINA--%>
<asp:Content ID="Titolo" ContentPlaceHolderID="ContentPlaceHoldertitolo" runat="Server">
    <h1>Tariffario</h1>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%--INIZIO INSERISCI POPUP--%>
    <div id="inserisci" class="myModal" visible="false" runat="server">
        <div class="card text-center position-absolute start-50 top-50 translate-middle rounded" style="min-width: 33%">

            <%--HEAD--%>
            <div class="card-header p-3">
                <h2 class="mb-0">Inserisci voce tariffario</h2>
            </div>
            <%--FINE HEAD--%>

            <div class="card-body d-flex justify-content-center p-5 gap-4">
                <div class="d-flex flex-column gap-2 ft-Large">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlTipologiaIns" class="form-select" aria-label="Floating label select" runat="server">
                            <asp:ListItem Text="Visita Medica" Value="M"></asp:ListItem>
                            <asp:ListItem Text="Analisi" Value="A"></asp:ListItem>
                            <asp:ListItem Text="Radiografia" Value="R"></asp:ListItem>
                        </asp:DropDownList>
                        <label for="ddlTipologiaIns" runat="server">Tipologia</label>
                        
                    </div>
                    <div class="form-floating">
                        <asp:TextBox ID="txtPrestazioneIns" class="form-control ft-Medium" runat="server" type="text" placeholder="Prestazione" />
                        <label for="txtPrestazioneIns">Prestazione</label>
                        <asp:Label ID="lblAvvisoPrestazioneIns" CssClass="text-danger" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-floating">
                        <asp:TextBox ID="txtPrezzoIns" class="form-control ft-Medium" runat="server" type="text" placeholder="Prezzo" />
                        <label for="txtPrezzoIns">Prezzo</label>
                        <asp:Label ID="lblAvvisoPrezzoIns" CssClass="text-danger" runat="server" Text=""></asp:Label>
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
                <h2 class="mb-0">Modifica voce tariffario</h2>
            </div>
            <%--FINE HEAD--%>

            <div class="card-body d-flex justify-content-center flex-wrap p-5 gap-4">
                <div class="d-flex flex-column gap-2 ft-Large">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlTipologiaMod" class="form-select ft-Medium" aria-label="Floating label select" runat="server">
                            <asp:ListItem Text="Visita Medica" Value="M"></asp:ListItem>
                            <asp:ListItem Text="Analisi" Value="A"></asp:ListItem>
                            <asp:ListItem Text="Radiografia" Value="R"></asp:ListItem>
                        </asp:DropDownList>
                        <label for="ddlTipologiaMod" runat="server">Tipologia</label>
                        
                    </div>
                    <div class="form-floating">
                        <asp:TextBox ID="txtPrestazioneMod" class="form-control ft-Medium" runat="server" type="text" placeholder="Prestazione" />
                        <label for="txtPrestazioneMod">Prestazione</label>
                        <asp:Label ID="lblAvvisoPrestazioneMod" CssClass="text-danger" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-floating">
                        <asp:TextBox ID="txtPrezzoMod" class="form-control ft-Medium" runat="server" type="text" placeholder="Prezzo" />
                        <label for="txtPrezzoMod">Prezzo</label>
                        <asp:Label ID="lblAvvisoPrezzoMod" CssClass="text-danger" runat="server" Text=""></asp:Label>
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
        <asp:Button ID="btnInserisci" class="btn btn-primary" runat="server" Text="Inserisci Voce Tariffario" OnClick="btnInserisci_Click" />
    </div>

    <%--INIZIO GRIGLIA TARIFFARIO--%>
    <div>
        <asp:GridView ID="grigliaTariffario" AllowPaging="true" runat="server" CssClass="table table-bordered table-hover table-striped table-responsive" AutoGenerateColumns="False" DataKeyNames="idTariffario" OnSelectedIndexChanged="grigliaTariffario_SelectedIndexChanged" OnPageIndexChanging="grigliaTariffario_PageIndexChanging" OnRowDataBound="grigliaTariffario_RowDataBound" HeaderStyle-HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="Tipo" HeaderText="Tipologia"></asp:BoundField>
                <asp:BoundField DataField="Prestazione" HeaderText="Prestazione"></asp:BoundField>
                <asp:BoundField DataField="Prezzo" HeaderText="Prezzo" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                <asp:CommandField SelectText="Modifica" ShowSelectButton="True" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" ItemStyle-HorizontalAlign="Center"></asp:CommandField>
            </Columns>
        </asp:GridView>
    </div>
    <%--FINE GRIGLIA TARIFFARIO--%>
</asp:Content>

