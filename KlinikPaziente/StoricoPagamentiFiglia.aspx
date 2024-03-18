<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePaziente.master" AutoEventWireup="true" CodeFile="StoricoPagamentiFiglia.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="containerStorico" class="p-5 pt-0" style="width: 100%;">

        <%--------------------------------POPUP per PDF--------------------------------%>
        <div id="PdfPopup" class="myModal" visible="false" runat="server">
            <asp:Panel CssClass="card text-center position-absolute start-50 top-50 translate-middle rounded Popup" Style="width: 80%" ID="popup" runat="server">


                <%--HEAD--%>
                <div class="card-header p-3">
                    <h2 class="mb-0">Download</h2>
                </div>
                <%--HEAD-FINE--%>
                <%--BODY--%>
                <asp:Panel ID="Panel2" CssClass="card-body d-flex justify-content-center flex-wrap p-0 gap-4" runat="server">
                    <asp:Literal ID="lit" runat="server"></asp:Literal>
                </asp:Panel>
                <%--BODY-FINE--%>
                <%--FOOTER--%>
                <div class="card-footer d-flex justify-content-around p-3">
                    <asp:Button ID="btnChiudiPdf" class="btn btn-secondary" runat="server" Text="Chiudi" OnClick="btnChiudiPdf_Click" />
                </div>
                <%--FOOTER-FINE--%>
            </asp:Panel>
        </div>

        <%-- FINE POPUP --%>


        <%-- CREDO Che questa parte si possa togliere sembra un vecchio popup --%>
        <%--   <div id="scarica" class="myModal" visible="false" runat="server">
            <asp:Panel CssClass="card text-center position-absolute start-50 top-50 translate-middle rounded Popup" ID="popup" runat="server">
                <div class="card text-center position-absolute start-50 top-50 translate-middle rounded" style="min-width: 33%">
                    <div class="card-header p-3">
                        <h2 class="mb-0">Download</h2>
                    </div>
                    <asp:Panel runat="server" CssClass="card-body d-flex justify-content-center flex-wrap p-0 gap-4" ID="popupBody">
                        <asp:Literal ID="ltldownload" runat="server"></asp:Literal>
                    </asp:Panel>
                    <div class="card-footer d-flex justify-content-around p-3">
                        <asp:Button ID="btnAnnullaIns" class="btn btn-secondary" runat="server" Text="Annulla" OnClick="btnAnnullaIns_Click" />
                    </div>
                </div>
            </asp:Panel>
        </div>--%>

        <div style="display: flex; justify-content: space-between;">
            <h1>Storico Pagamenti</h1>
        </div>
        <div style="margin: 1em 0;" class="d-flex justify-content-between">
            <div class="d-flex justify-content-center">

                <asp:Panel ID="pnlTipo" runat="server" class="form-floating">
                    <asp:DropDownList runat="server" class="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" ID="ddlTipo" aria-label="Floating label select">
                        <asp:ListItem Value="">-Seleziona tipo-</asp:ListItem>
                        <asp:ListItem Value="M">Visite</asp:ListItem>
                        <asp:ListItem Value="A">Analisi</asp:ListItem>
                        <asp:ListItem Value="R">Radiografie</asp:ListItem>
                    </asp:DropDownList>
                    <label for="ddlTipo">Tipologia</label>
                </asp:Panel>
                <asp:Panel runat="server" class="form-floating mb-4">
                    <asp:TextBox runat="server" class="form-control" ID="txtCosti" disabled="true"></asp:TextBox>
                    <label id="lblCosti" for="txtCosti">Totale spese</label>
                </asp:Panel>                            
            </div>

        </div>
        <asp:GridView ID="GrigliaStorico" runat="server" AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="idPrenotazione" CssClass="table table-bordered table-hover table-striped table-responsive"
            ShowHeaderWhenEmpty="True" OnPageIndexChanging="GrigliaStorico_PageIndexChanging" OnRowCommand="GrigliaStorico_RowCommand" OnRowDataBound="GrigliaStorico_RowDataBound">
            <Columns>
                <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                <asp:BoundField DataField="NominativoSanitario" HeaderText="Medico Curante" />
                <asp:BoundField DataField="DataPagamento" HeaderText="Data Pagamento" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="DataPagamento" HeaderText="Orario Pagamento" DataFormatString="{0:hh:mm}" />
                <asp:BoundField DataField="Prezzo" HeaderText="Prezzo" DataFormatString="{0:0.0,0 €}" />
                <asp:BoundField DataField="Prestazione" HeaderText="Prestazione" />
                <asp:TemplateField HeaderText="Fattura">
                    <ItemTemplate>
                        <asp:Button ID="btnDownload" CssClass="btn btn-primary"
                            CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="Pdf" runat="server" Text="Scarica" class="btn" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

