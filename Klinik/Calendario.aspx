<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Calendario.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Titolo" ContentPlaceHolderID="ContentPlaceHoldertitolo" runat="Server">
    <h1>Calendario</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="d-flex justify-content-center">
        <%--frecia per andare indietro di un mese--%>
                        <asp:LinkButton style="width:4em ;height:4em ;text-decoration: none; color: inherit;" ID="Mesemeno" runat="server"  OnClick="Mesemeno_Click" CssClass="d-flex justify-content-center flex-wrap align-items-center ">    <i  style="font-size: 3em; color:#3e6ea6; background-color:transparent" class="fas fa-arrow-left"></i> <!-- Aggiungi l'icona Font Awesome come testo del LinkButton --></asp:LinkButton>
        <%--txt dei mesi e anni--%>
        <asp:Panel ID="Panel1" runat="server" class="form-floating mb-4">
        <asp:TextBox runat="server" type="email" class="form-control" ID="txtMese" TextMode="Month" placeholder="." AutoPostBack="True" OnTextChanged="txtMese_TextChanged"></asp:TextBox>
        <label for="txtMese">Mese</label>
    </asp:Panel>
        <%--frecia per avanzare di un mese--%>
            <asp:LinkButton style="width:4em ;height:4em ;text-decoration: none; color: inherit;" ID="Mesepiu" runat="server"  OnClick="Mesepiu_Click" CssClass="d-flex justify-content-center flex-wrap align-items-center ">    <i  style="font-size: 3em; color:#3e6ea6; background-color:transparent" class="fas fa-arrow-right"></i> <!-- Aggiungi l'icona Font Awesome come testo del LinkButton --></asp:LinkButton>
    </div>
    <%--griglia appuntamenti con i pazienti--%>
    <div>
        <asp:GridView ID="GrigliaCalendario" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-bordered table-hover table-striped table-responsive" GridLines="None"
            AllowPaging="True" OnSelectedIndexChanged="GrigliaPrestazioni_SelectedIndexChanged" OnPageIndexChanging="GrigliaPrestazioni_PageIndexChanging">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="NominativoPaziente" HeaderText="Paziente" />
                <asp:BoundField DataField="TelefonoPaziente" HeaderText="Telefono" />
                <asp:BoundField DataField="DataPrestazione" HeaderText="Data"  DataFormatString="{0:dd/MM/yyyy}"/>
                <asp:BoundField DataField="DataPrestazione" HeaderText="Ora" DataFormatString="{0:HH:mm}"/>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

