<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StatoPagamenti.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<%--TITOLO PAGINA--%>
<asp:Content ID="Titolo" ContentPlaceHolderID="ContentPlaceHoldertitolo" runat="Server">
    <h1>Stato Pagamenti</h1>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%--INIZIO RICERCA STATO PAGAMENTI--%>
    <div class="d-flex justify-content-center flex-wrap gap-4 mb-4">
        <asp:Panel ID="Panel1" runat="server" class="form-floating">
            <asp:TextBox runat="server" type="email" class="form-control" AutoPostBack="true" ID="txtRicercaCodFiscale" placeholder="" OnTextChanged="Filtro"></asp:TextBox>
            <label for="txtRicercaCodFiscale">Codice Fiscale del paziente</label>
        </asp:Panel>
        <asp:Panel ID="Panel4" runat="server" class="form-floating mb-4" Style="margin-right: 1em;">
            <asp:DropDownList runat="server" class="form-select" ID="ddlPagato" AutoPostBack="true" aria-label="Floating label select" OnSelectedIndexChanged="Filtro">
                <asp:ListItem Text="--Seleziona Stato Pagamento--" Value=""></asp:ListItem>
                <asp:ListItem Text="Pagato - ✅" Value="true"></asp:ListItem>
                <asp:ListItem Text="Non Pagato - ❌" Value="false"></asp:ListItem>
            </asp:DropDownList>
            <label for="ddlPagato">Stato Pagamento</label>
        </asp:Panel>
    </div>
    <%--FINE RICERCA STATO PAGAMENTI--%>

    <%--INIZIO GRIGLIA STATO PAGAMENTI--%>
    <asp:GridView ID="grigliaPagamenti" runat="server" AutoGenerateColumns="false" DataKeyNames="CodFiscale" CssClass="table table-bordered table-hover table-striped table-responsive" OnPageIndexChanging="grigliaPagamenti_PageIndexChanging" OnRowDataBound="grigliaPagamenti_RowDataBound" HeaderStyle-HorizontalAlign="Center">
        <Columns>
            <asp:BoundField DataField="NominativoPaziente" HeaderText="Nominativo Paziente"></asp:BoundField>
            <asp:BoundField DataField="CodFiscale" HeaderText="Codice Fiscale Paziente"></asp:BoundField>
            <asp:BoundField DataField="NominativoSanitario" HeaderText="Medico"></asp:BoundField>
            <asp:BoundField DataField="Tipo" HeaderText="Tipologia"></asp:BoundField>
            <asp:BoundField DataField="Prestazione" HeaderText="Prestazione"></asp:BoundField>
            <asp:BoundField DataField="Prezzo" HeaderText="Prezzo" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
            <asp:BoundField DataField="DataPagamento" HeaderText="Data Pagamento" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
            <asp:BoundField DataField="Pagato" HeaderText="Stato Pagamento" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <%--FINE GRIGLIA STATO PAGAMENTO--%>
</asp:Content>

