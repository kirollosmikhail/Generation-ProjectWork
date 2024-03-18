<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Log_Operazioni.aspx.cs" Inherits="Operazioni" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<%--TITOLO PAGINA--%>
<asp:Content ID="Titolo" ContentPlaceHolderID="ContentPlaceHoldertitolo" runat="Server">
    <h1>Log Operazioni</h1>
</asp:Content>

<%--CONTENUTo PAGINA--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="d-flex justify-content-around mb-4">

        <div class="d-flex justify-content-center flex-wrap gap-4">
            <asp:Panel ID="Panel1" runat="server" class="form-floating">
                <asp:TextBox runat="server" class="form-control" ID="txtData" placeholder="." oninput="validaInput();return false;" AutoPostBack="true" OnTextChanged="Page_Load" ValidateRequestMode="Disabled" MaxLength="13"></asp:TextBox>
                <label for="txtData">Data (AAAA/MM/GG HH)</label>
            </asp:Panel>
                        <script>
                function validaInput() {
                    var input = document.getElementById('<%=txtData.ClientID%>');
                    var currentText = input.value;

                    var cleanedText = currentText.replace(/\D/g, '');

                    var formattedText = cleanedText.replace(/(\d{2})(\d{2})?(\d{4})?(\d{2})?/, function (match, p1, p2, p3, p4) {
                        result = p1;
                        if (p1.length >= 2) result += '/';
                        if (p2 !== undefined && p2.length >= 2) result += p2.slice(0, 2) + '/';
                        if (p3 !== undefined && p3.length >= 4) result += p3.slice(0, 4) + ' ';
                        if (p4 !== undefined && p4.length >= 2) result += p4.slice(0, 2);
                        return result;
                    });

                    input.value = formattedText;
                }
                        </script>

            <asp:Panel ID="Panel2" runat="server" class="form-floating">
                <asp:TextBox runat="server" class="form-control" ID="txtEmail" placeholder="." AutoPostBack="true" OnTextChanged="Page_Load" TextMode="Email"></asp:TextBox>
                <label for="txtEmail">Usermail</label>
            </asp:Panel>

            <asp:Panel ID="Panel3" runat="server" class="form-floating">
                <asp:TextBox runat="server" class="form-control" ID="txtProgramma" placeholder="." AutoPostBack="true" OnTextChanged="Page_Load"></asp:TextBox>
                <label for="txtProgramma">Programma</label>
            </asp:Panel>

            <asp:Panel ID="Panel4" runat="server" class="form-floating">
                <asp:TextBox runat="server" class="form-control" ID="txtOperazione" placeholder="." AutoPostBack="true" OnTextChanged="Page_Load"></asp:TextBox>
                <label for="floatingInputValue">Operazione</label>
            </asp:Panel>
        </div>

        <div style="min-width: fit-content;">
            <asp:Button ID="btnElimina" class="btn btn-danger" runat="server" Text="Elimina Storico" OnClick="btnElimina_Click" />
        </div>
    </div>

    <asp:GridView runat="server" CssClass="table table-bordered table-hover table-striped table-responsive" ID="grigliaOperazioni" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grigliaAccessi_PageIndexChanging" PageSize="15">
        <Columns>
            <asp:BoundField DataField="UserMail" HeaderText="Utente" SortExpression="UserMail"></asp:BoundField>
            <asp:BoundField DataField="DataLog" HeaderText="Data" SortExpression="DataLog"></asp:BoundField>
            <asp:BoundField DataField="Programma" HeaderText="Programma" SortExpression="Programma"></asp:BoundField>
            <asp:BoundField DataField="Operazione" HeaderText="Operazione" SortExpression="Operazione"></asp:BoundField>
        </Columns>
    </asp:GridView>

    <%--POPUP--%>
    <div id="popElimina" class="myModal" visible="false" runat="server">
        <div class="card text-center position-absolute start-50 top-50 translate-middle rounded" style="min-width: 33%">
            <%--HEAD--%>
            <div class="card-header p-3">
                <h2 class="mb-0 text-danger">Attenzione!</h2>
            </div>
            <%--HEAD-FINE--%>            <%--BODY--%>
            <div class="card-body d-flex justify-content-center flex-wrap p-5 gap-4">
                <div class="d-flex flex-column gap-4">
                    <p>Sei sicuro di voler eliminare tutto lo storico dei records relativi alle operazioni?</p>
                </div>
            </div>
            <%--BODY-FINE--%>
            <%--FOOTER--%>
            <div class="card-footer d-flex justify-content-around p-3">
                <asp:Button ID="btnAnnulla" class="btn btn-secondary" runat="server" Text="Annulla" OnClick="btnAnnulla_Click" />
                <asp:Button ID="btnConferma" class="btn btn-danger" runat="server" Text="Elimina" OnClick="btnConferma_Click" />
            </div>
            <%--FOOTER-FINE--%>
        </div>
    </div>

</asp:Content>

