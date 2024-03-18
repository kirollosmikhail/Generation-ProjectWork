<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Economia.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Titolo" ContentPlaceHolderID="ContentPlaceHoldertitolo" runat="Server">
    <h1>Economia</h1>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="d-flex justify-content-around">
        <div class="d-flex justify-content-around">
        <asp:LinkButton Style="width: 4em; height: 4em; text-decoration: none; color: inherit;" ID="Mesemeno" runat="server" OnClick="Mesemeno_Click" class="d-flex justify-content-around">    <i  style="font-size: 3em; color:#3e6ea6; background-color:transparent" class="fas fa-arrow-left"></i> <!-- Aggiungi l'icona Font Awesome come testo del LinkButton --></asp:LinkButton>

        <asp:Panel ID="pnlData" runat="server" class="form-floating mb-4">
            <asp:TextBox runat="server" class="form-control" ID="CalendarioFiltro" TextMode="Month" AutoPostBack="true" OnTextChanged="CalendarioFiltro_TextChanged"></asp:TextBox>
            <label id="lblFiltra" for="CalendarioFiltro" text="Filtra per Mese: ">Filtra per Mese</label>
        </asp:Panel>

        <asp:LinkButton Style="width: 4em; height: 4em; text-decoration: none; color: inherit;" ID="Mesepiu" runat="server" OnClick="Mesepiu_Click" class="d-flex justify-content-around">    <i  style="font-size: 3em; color:#3e6ea6; background-color:transparent" class="fas fa-arrow-right"></i> <!-- Aggiungi l'icona Font Awesome come testo del LinkButton --></asp:LinkButton>
        </div>
        <asp:Panel runat="server" class="form-floating mb-4">
            <asp:TextBox runat="server" class="form-control" ID="TxtRicavi" disabled="true"></asp:TextBox>
            <label id="lblRicavi" for="TxtRicavi">Totale Ricavi</label>
        </asp:Panel>

    </div>

    <asp:GridView ID="GrigliaPrestazioni" CssClass="table table-bordered table-hover table-striped table-responsive" runat="server" DataKeyNames="IdSanitario" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="VoltaPagina" PageSize="15">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="DataPrestazione" HeaderText="Data" ReadOnly="True" SortExpression="data" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="NominativoPaziente" HeaderText="Paziente" ReadOnly="True" SortExpression="paziente" />
            <asp:BoundField DataField="Prestazione" HeaderText="Prestazione" ReadOnly="True" SortExpression="tipo_prestazione" />
            <asp:BoundField DataField="RicavoSanitario" HeaderText="Ricavi" ReadOnly="True" SortExpression="ricavi" DataFormatString="{0:C}" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>

</asp:Content>

