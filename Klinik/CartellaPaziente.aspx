<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CartellaPaziente.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Titolo" ContentPlaceHolderID="ContentPlaceHoldertitolo" runat="Server">
    <h1>Cartelle Pazienti</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        /*h1 {
            color: #305580;*/ /* Colore del testo */
            /*font-size: 32px;
            font-weight: bold;
            margin-bottom: 10px;
        }

        h2 {
            color: #305580;*/ /* Colore del testo */
            /*font-size: 24px;
            font-weight: normal;
            margin-top: 0;
        }

        th {
            background-color: #3e6ea6 !important;
            color: white !important;
        }

        .btn {
            height: 58px;
        }*/

        .Popup {
            min-width: 70%;
            min-height: 95%;
        }

        .container {
            border: 2px solid #ccc;
            width: 500px;
            height: 100px;
            overflow-y: scroll;
        }
    </style>
    <div>


        <%--le varie txt e ddl per tuti i pazienti e le loro generalità--%>
        <div class="d-flex justify-content-center flex-wrap gap-4 mb-4">
            <asp:Panel ID="Panel2" runat="server" class="form-floating mb-4">
                <asp:DropDownList ID="ddlPazienti" aria-label="Floating label select" class="form-select" runat="server" DataTextField="NomePaziente" DataValueField="idPaziente" OnSelectedIndexChanged="ddlPazienti_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                <label for="ddlPazienti">Pazienti</label>
            </asp:Panel>
            <asp:Panel ID="Panel3" runat="server" class="form-floating mb-4">
                <asp:TextBox runat="server" type="email" class="form-control" ID="txtGenere" placeholder="." disabled></asp:TextBox>
                <label for="txtGenere">Genere</label>
            </asp:Panel>
            <asp:Panel ID="Panel4" runat="server" class="form-floating mb-4">
                <asp:TextBox runat="server" type="email" class="form-control" ID="txtDataNascita" placeholder="." disabled></asp:TextBox>
                <label for="txtDataNascita">Data di nascita</label>
            </asp:Panel>
            <asp:Panel ID="Panel5" runat="server" class="form-floating mb-4">
                <asp:TextBox runat="server" type="email" class="form-control" ID="txtTelefono" placeholder="." disabled></asp:TextBox>
                <label for="txtTelefono">Numero di telefono</label>
            </asp:Panel>
        </div>
        <%--griglia della cartella clinica del paziente selezioanto nella "ddlPazienti"--%>
        <asp:GridView ID="grigliaCartelle" runat="server" AutoGenerateColumns="False" DataKeyNames="idPrestazione" CellPadding="4" CssClass="table table-bordered table-hover table-striped table-responsive" GridLines="None" OnRowDataBound="grigliaCartelle_RowDataBound" OnRowCommand="grigliaCartelle_RowCommand">
            <Columns>
                <asp:BoundField DataField="DataPrestazione" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="Prestazione" HeaderText="Prestazione" />
                <asp:BoundField DataField="Anamnesi" HeaderText="Anamnesi" />
                <asp:TemplateField HeaderText="Referto">
                    <ItemTemplate>
                        <asp:Button ID="btnDownload" CssClass="btn btn-primary"
                            CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="Download" runat="server" Text="Download" class="btn" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <%--popup per il pdf--%>
        <div id="PdfPopup" class="myModal" visible="false" runat="server">

            <asp:Panel CssClass="card text-center position-absolute start-50 top-50 translate-middle rounded" ID="popup" runat="server">


                <%--HEAD--%>
                <div class="card-header p-3">
                    <h2 class="mb-0">Download</h2>
                </div>
                <%--HEAD-FINE--%>
                <%--BODY--%>
                <asp:Panel ID="popupBody" CssClass="card-body d-flex justify-content-center flex-wrap p-0 gap-4" runat="server">
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


    </div>
</asp:Content>

