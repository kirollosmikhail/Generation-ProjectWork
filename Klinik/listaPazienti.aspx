<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="listaPazienti.aspx.cs" Inherits="Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        function allowOnlyLetters(event) {
            var charCode = (event.which) ? event.which : event.keyCode;
            if ((charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && charCode !== 32) {
                event.preventDefault();
            }
        }

        function allowOnlyNumbers(event) {
            var charCode = (event.which) ? event.which : event.keyCode;
            if (charCode < 48 || charCode > 57) {
                event.preventDefault();
            }
        }
    </script>

</asp:Content>
<%--TITOLO PAGINA--%>
<asp:Content ID="Titolo" ContentPlaceHolderID="ContentPlaceHoldertitolo" runat="Server">
    <h1>Lista Pazienti</h1>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="d-flex justify-content-around mb-4">

        <div class="d-flex justify-content-center flex-wrap gap-4">
            <asp:Panel ID="Panel2" runat="server" class="form-floating">
                <asp:TextBox runat="server" class="form-control" OnTextChanged="Page_Load" AutoPostBack="true" ID="txtFiltroNominativo" placeholder="Nominativo"> 
                </asp:TextBox>
                <label for="txtFiltroNominativo">Nominativo</label>
            </asp:Panel>

            <asp:Panel ID="Panel3" runat="server" class="form-floating">
                <asp:TextBox runat="server" class="form-control" OnTextChanged="Page_Load" AutoPostBack="true" ID="txtFiltroUsrMail" placeholder="Usermail"> 
                </asp:TextBox>
                <label for="txtFiltroUsrMail">Usermail</label>
            </asp:Panel>

            <asp:Panel ID="Panel1" runat="server" class="form-floating">
                <asp:TextBox runat="server" class="form-control" OnTextChanged="Page_Load" AutoPostBack="true" ID="txtFiltroCodFiscale" placeholder="Codice Fiscale"> 
                </asp:TextBox>
                <label for="txtFiltroCodFiscale">Codice Fiscale</label>
            </asp:Panel>

        </div>

        <div style="min-width: fit-content;">

            <%--BOTTONE POPUP--%>
        </div>
    </div>

    <%--GRIGLIA DATI--%>

    <asp:GridView  ID="gridPazienti" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="idPaziente" CssClass="table table-bordered table-hover table-striped table-responsive" OnPageIndexChanging="gridPazienti_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="idPaziente" HeaderText="Identificativo" Visible="false" />
            <asp:BoundField DataField="NominativoPaziente" HeaderText="Nominativo" />
            <asp:BoundField DataField="UserMail" HeaderText="E-Mail Paziente" />
            <asp:BoundField DataField="Genere" HeaderText="Genere" />
            <asp:BoundField DataField="DataNascita" DataFormatString="{0:d}" HeaderText="Data di nascita" />
            <asp:BoundField DataField="CodFiscale" HeaderText="Codice Fiscale" />
            <asp:BoundField DataField="IndirizzoPaziente" HeaderText="Indirizzo (Indirizzo, CAP, Città e Provincia)" />
            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
        </Columns>
    </asp:GridView>
</asp:Content>

