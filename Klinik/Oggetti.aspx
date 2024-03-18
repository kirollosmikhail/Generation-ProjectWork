<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Oggetti.aspx.cs" Inherits="Oggetti" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%--TITOLI/PRINCIPALE--%>
    <h1>Pagina </h1>

    <br />

    <%--SECONDARY--%>
    <h2>Benvenuto alla pagina.</h2>

    <br />

    <%--BOTTONE--%>
    <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Button" />

    <br />
    <br />

    <%--DDL--%>
    <asp:Panel ID="Panel2" runat="server" class="form-floating mb-4">
        <%--aggiungere qui enabled visible ecc. e non al txtbox--%>
        <asp:DropDownList runat="server" class="form-select" ID="floatingSelect" aria-label="Floating label select">
        </asp:DropDownList>
        <label for="floatingSelect">DDL</label><%--nel for si deve inserire lo stesso ID della DDL--%>
    </asp:Panel>
    <%------%>

    <br />

    <%--Textbox--%>
    <asp:Panel ID="Panel1" runat="server" class="form-floating mb-4">
        <%--aggiungere qui enabled visible ecc. e non al txtbox--%>
        <asp:TextBox runat="server" type="email" class="form-control" ID="floatingInputValue" placeholder="."></asp:TextBox>
        <%--non togliere il placeholder--%>
        <label for="floatingInputValue">Input with value</label>
        <%--nel for si deve inserire lo stesso ID della txtbox--%>
    </asp:Panel>
    <%------%>

    <br />

    <%--GridView--%>
    <asp:GridView runat="server" CssClass="table table-bordered table-hover table-striped table-responsive" ID="GridView1"></asp:GridView>

    <br />


    <%--BOTTONE POPUP--%>
    <asp:Button ID="btnInserisci" class="btn btn-primary" runat="server" Text="POPUP" OnClick="btnInserisci_Click" />
    <%--per il funzionamento: protected void btnInserisci_Click(object sender, EventArgs e), in Oggetti.aspx.cs--%>

    <%--POPUP--%>
    <div id="inserisci" class="myModal" visible="false" runat="server">
        <div class="card text-center position-absolute start-50 top-50 translate-middle rounded" style="min-width: 33%">

            <%--HEAD--%>
            <div class="card-header p-3">


                <h2 class="mb-0">POPUP</h2>
            </div>
            <%--HEAD-FINE--%>

            <%--BODY--%>
            <div class="card-body d-flex justify-content-center flex-wrap p-5 gap-4">

                <%--SEZION1--%>
                <div class="d-flex flex-column gap-4">
                    <div class="form-floating ">
                        <asp:DropDownList ID="ddlTipologiaIns" class="form-select" aria-label="Floating label select" runat="server">
                            <asp:ListItem Text="Medico" Value="M"></asp:ListItem>
                            <asp:ListItem Text="Analisi" Value="A"></asp:ListItem>
                            <asp:ListItem Text="Radiografie" Value="R"></asp:ListItem>
                        </asp:DropDownList>
                        <label for="ddlTipologiaIns" runat="server">Tipologia</label>
                    </div>
                    <div class="form-floating">
                        <asp:TextBox ID="txtPrestazioneIns" class="form-control" runat="server" type="text" placeholder="Prestazione" />
                        <label for="txtPrestazioneIns">Prestazione</label>
                    </div>
                    <div class="form-floating">
                        <asp:TextBox ID="txtPrezzoIns" class="form-control" runat="server" type="text" placeholder="Prezzo" />
                        <label for="txtPrezzoIns">Prezzo</label>
                    </div>
                </div>
                <%--SEZION2--%>
                <div class="d-flex flex-column gap-4">
                    <div class="form-floating ">
                        <asp:DropDownList ID="ddlTipologiaInsn" class="form-select" aria-label="Floating label select" runat="server">
                            <asp:ListItem Text="Medico" Value="M"></asp:ListItem>
                            <asp:ListItem Text="Analisi" Value="A"></asp:ListItem>
                            <asp:ListItem Text="Radiografie" Value="R"></asp:ListItem>
                        </asp:DropDownList>
                        <label for="ddlTipologiaIns" runat="server">Tipologia</label>
                    </div>
                    <div class="form-floating">
                        <asp:TextBox ID="txtPrestazioneInsn" class="form-control" runat="server" type="text" placeholder="Prestazione" />
                        <label for="txtPrestazioneIns">Prestazione</label>
                    </div>
                    <div class="form-floating">
                        <asp:TextBox ID="txtPrezzoInsn" class="form-control" runat="server" type="text" placeholder="Prezzo" />
                        <label for="txtPrezzoIns">Prezzo</label>
                    </div>
                </div>
            </div>
            <%--BODY-FINE--%>

            <%--FOOTER--%>
            <div class="card-footer d-flex justify-content-around p-3">
                <asp:Button ID="btnAnnullaIns" class="btn btn-secondary" runat="server" Text="Annulla" OnClick="btnAnnullaIns_Click" />
                 <%--per il funzionamento: protected void btnAnnullaIns_Click(object sender, EventArgs e), in Oggetti.aspx.cs--%>
                <asp:Button ID="btnConfermaIns" class="btn btn-primary" runat="server" Text="Inserisci" OnClick="btnConfermaIns_Click" />
                 <%--per il funzionamento: protected void btnConfermaIns_Click(object sender, EventArgs e), in Oggetti.aspx.cs--%>
            </div>
            <%--FOOTER-FINE--%>
        </div>
    </div>

</asp:Content>

