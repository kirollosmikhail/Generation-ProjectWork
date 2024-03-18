<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HomeMedici.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<%--TITOLO PAGINA--%>
<asp:Content ID="Titolo" ContentPlaceHolderID="ContentPlaceHoldertitolo" runat="Server">
    <h1>Riepilogo Appuntamenti</h1>
</asp:Content>

<%--CONTENUTo PAGINA--%>
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




    <%--------------------------------------------------------------POPUP MEDICI----------------------------------------------------------------------------------------%>

    <%--POPUP MEDICI--%>
    <div id="inserisci" class="myModal" visible="false" runat="server">
        <div class="card text-center position-absolute start-50 top-50 translate-middle rounded" style="min-width: 33%">

            <%--HEAD--%>
            <div class="card-header p-3">


                <h2 class="mb-0">MODIFICA PRESTAZIONE</h2>
            </div>
            <%--HEAD-FINE--%>

            <%--BODY--%>
            <div class="card-body d-flex justify-content-center flex-wrap p-5 gap-4">

                <%--SEZION1--%>
                <div class="d-flex flex-column gap-4">
                    <div class="form-floating ">
                        <asp:TextBox ID="txtNome" runat="server" placeholder="Nome" class="form-control" disabled></asp:TextBox>
                        <label for="txtNome" runat="server">Nome</label>
                    </div>
                    <div class="form-floating">
                        <asp:TextBox ID="txtCodFiscale" runat="server" placeholder="Cod. Fiscale" class="form-control" disabled></asp:TextBox>
                        <label for="txtCodFiscale">Codice Fiscale</label>
                    </div>
                    <div class="form-floating">
                        <asp:TextBox ID="txtAnamnesi" runat="server" placeholder="Anamnesi" class="form-control" TextMode="MultiLine" MaxLength="150"></asp:TextBox>
                        <label for="txtAnamnesi">Anamnesi</label>
                    </div>
                    <div class="form-floating">
                        <asp:FileUpload ID="uplDocumento" class="form-control ft-Large" runat="server" />
                        <label for="uplDocumento">Seleziona documento</label>
                    </div>
                    <div></div>
                    <%--INSERISCI NOME--%>
                    <div class="form-floating" id="divPaziente" runat="server" visible="false">
                        <div class="container">
                            <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
                        </div>
                    </div>
                </div>
                <%--SEZION2--%>
                <div class="d-flex flex-column gap-4">
                    <div class="form-floating ">
                        <asp:TextBox ID="txtCognome" runat="server" placeholder="Cognome" class="form-control" disabled></asp:TextBox>
                        <label for="txtCognome">Cognome</label>
                    </div>
                    <div class="form-floating">
                        <asp:TextBox ID="txtDataNascita" class="form-control" runat="server" type="text" disabled placeholder="DataNascita" />
                        <label for="txtDataNascita">Data di nascita</label>
                    </div>
                    <div class="form-floating">
                        <asp:TextBox ID="txtReferto" class="form-control" runat="server" type="text" placeholder="Referto" MaxLength="150" TextMode="MultiLine" />
                        <label for="txtReferto">Referto</label>
                    </div>
                    <div class="form-floating">
                        <%--<label for="btnRichiedi">Richiedi ulteriori accertamenti</label>--%>
                        <asp:Button ID="btnRichiedi" CssClass="btn btn-primary" runat="server" Text="Richiedi controlli" OnClick="btnRichiedi_Click" />
                    </div>
                    <div id="divDdl" runat="server" visible="false">
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

    <%--END POPUP--%>

    <%--------------------------------------------------------------POPUP RADIOLOGI E ANALISTI-------------------------------------------------------------------------------------%>

    <%--POPUP RADIOLOGI E ANALISTI--%>
    <div id="inserisci2" class="myModal" visible="false" runat="server">
        <div class="card text-center position-absolute start-50 top-50 translate-middle rounded" style="min-width: 33%">

            <%--HEAD--%>
            <div class="card-header p-3">


                <h2 class="mb-0">MODIFICA PRESTAZIONE</h2>
            </div>
            <%--HEAD-FINE--%>

            <%--BODY--%>
            <div class="card-body d-flex justify-content-center flex-wrap p-5 gap-4">

                <%--SEZION1--%>
                <div class="d-flex flex-column gap-4">
                    <div class="form-floating ">
                        <asp:TextBox ID="txtNome2" runat="server" placeholder="Nome" class="form-control" disabled></asp:TextBox>
                        <label for="txtNome2" runat="server">Nome</label>
                    </div>
                    <div class="form-floating">
                        <asp:TextBox ID="txtCodFiscale2" runat="server" placeholder="Cod. Fiscale" class="form-control" disabled></asp:TextBox>
                        <label for="txtCodFiscale2">Codice Fiscale</label>
                    </div>
                    <div class="form-floating">
                        <asp:TextBox ID="txtReferto2" class="form-control" runat="server" type="text" placeholder="Referto" MaxLength="150" TextMode="MultiLine" />
                        <label for="txtReferto2">Referto</label>
                    </div>
                    <div class="form-floating">
                        <asp:TextBox ID="txtAnamnesi2" runat="server" placeholder="Anamnesi" class="form-control" MaxLength="150" TextMode="MultiLine"></asp:TextBox>
                        <label for="txtAnamnesi2">Anamnesi</label>
                    </div>

                </div>
                <%--SEZION2--%>
                <div class="d-flex flex-column gap-4">
                    <div class="form-floating ">
                        <asp:TextBox ID="txtCognome2" runat="server" placeholder="Cognome" class="form-control" disabled></asp:TextBox>
                        <label for="txtCognome2">Cognome</label>
                    </div>
                    <div class="form-floating">
                        <asp:TextBox ID="txtDataNascita2" class="form-control" runat="server" type="text" disabled placeholder="DataNascita" />
                        <label for="txtDataNascita2">Data di nascita</label>
                    </div>
                    <div class="form-floating">
                        <asp:FileUpload ID="uplDocumento2" class="form-control ft-Large" runat="server" />
                        <label for="uplDocumento2">Seleziona documento</label>
                    </div>
                </div>
            </div>

            <%--BODY-FINE--%>

            <%--FOOTER--%>
            <div class="card-footer d-flex justify-content-around p-3">
                <asp:Button ID="btnAnnullaIns2" class="btn btn-secondary" runat="server" Text="Annulla" OnClick="btnAnnullaIns2_Click" />
                <%--per il funzionamento: protected void btnAnnullaIns_Click(object sender, EventArgs e), in Oggetti.aspx.cs--%>
                <asp:Button ID="btnConfermaIns2" class="btn btn-primary" runat="server" Text="Inserisci" OnClick="btnConfermaIns2_Click" />
                <%--per il funzionamento: protected void btnConfermaIns_Click(object sender, EventArgs e), in Oggetti.aspx.cs--%>
            </div>
            <%--FOOTER-FINE--%>
        </div>
    </div>

    <%--END POPUP--%>

    <%------------------------------------------------------------------------------------------------------------------------------------------------------%>

    <%-----------------------------------------------CALENDARIO PER FILTRO GRIGLIA------------------------------------------------------------------------%>
    <%--<div class="d-flex justify-content-around">--%>
    <%--Textbox--%>
    <%-- <asp:Panel ID="Panel1" runat="server" class="form-floating mb-4">--%>
    <%--aggiungere qui enabled visible ecc. e non al txtbox--%>
    <%--<asp:TextBox ID="txtCalendario" runat="server" Class="form-control" AutoPostBack="true" TextMode="Date" OnTextChanged="txtCalendario_TextChanged"></asp:TextBox>--%>
    <%--non togliere il placeholder--%>
    <%--<label for="txtCalendario">Data</label>--%>
    <%--nel for si deve inserire lo stesso ID della txtbox--%>
    <%--</asp:Panel>--%>
    <%------%>
    <%--</div>--%>
    <div class="d-flex justify-content-center">
        <asp:LinkButton Style="width: 4em; height: 4em; text-decoration: none; color: inherit;" ID="Mesemeno" runat="server" OnClick="Mesemeno_Click" CssClass="d-flex justify-content-center flex-wrap align-items-center ">
    <i  style="font-size: 3em; color:#3e6ea6; background-color:transparent" class="fas fa-arrow-left"></i> <!-- Aggiungi l'icona Font Awesome come testo del LinkButton -->
</asp:LinkButton>
        <asp:Panel ID="Panel1" runat="server" class="form-floating mb-4">
            <asp:TextBox runat="server" type="email" class="form-control" ID="txtCalendario" TextMode="Month" placeholder="." AutoPostBack="True" OnTextChanged="txtCalendario_TextChanged"></asp:TextBox>
            <label for="txtCalendario">Mese</label>
        </asp:Panel>
        <asp:LinkButton Style="width: 4em; height: 4em; text-decoration: none; color: inherit;" ID="Mesepiu" runat="server" OnClick="Mesepiu_Click" CssClass="d-flex justify-content-center flex-wrap align-items-center ">
    <i  style="font-size: 3em; color:#3e6ea6; background-color:transparent" class="fas fa-arrow-right"></i> <!-- Aggiungi l'icona Font Awesome come testo del LinkButton -->
</asp:LinkButton>
    </div>
    <%------------------------------------------------------------------------------------------------------------------------------------------------------%>

    <%-----------------------------------------------GRIGLIA PRESTAZIONI APERTE------------------------------------------------------------------------%>
    <div>
        <h2 class="text-center mb-4">Prestazioni aperte</h2>
        <div class="d-flex justify-content-center">
            <asp:Label ID="lblVuota" CssClass="display-5" runat="server" Text=""></asp:Label>
        </div>
        <asp:GridView ID="gridPrestazioniAperte" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-striped table-responsive" OnRowDeleting="gridPrestazioniAperte_RowDeleting" DataKeyNames="idPrestazione" OnRowDataBound="gridPrestazioniAperte_RowDataBound" OnSelectedIndexChanged="gridPrestazioniAperte_SelectedIndexChanged" OnRowCommand="griglia_RowCommand">
            <Columns>
                <asp:BoundField DataField="Nome Paziente" HeaderText="Paziente" />
                <asp:BoundField DataField="DataNascita" HeaderText="Data di nascita" />
                <asp:BoundField DataField="CodFiscale" HeaderText="Codice Fiscale" />
                <asp:BoundField DataField="Nome Medico" HeaderText="Medico" />
                <asp:BoundField DataField="DataPrestazione" HeaderText="Data Prestazione" />
                <asp:BoundField DataField="Anamnesi" HeaderText="Anamnesi" />
                <asp:BoundField DataField="Referto" HeaderText="Referto" />
                <asp:TemplateField HeaderText="Download Doc">
                    <ItemTemplate>
                        <asp:Button ID="btnDownload" CssClass="btn btn-primary"
                            CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="Download" runat="server" Text="Download" class="btn" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ControlStyle-CssClass="btn btn-primary" ButtonType="Button" ShowSelectButton="True" SelectText="Modifica" />
                <asp:CommandField ControlStyle-CssClass="btn btn-primary" ButtonType="Button" SelectText="Cartella clinica" ShowDeleteButton="True" DeleteText="Cartella clinica" EditText="Cartella clinica" />
            </Columns>
        </asp:GridView>
    </div>
    <%------------------------------------------------------------------------------------------------------------------------------------------------------%>


    <%--  modifica kiro --%>
    <%--POPUP--%>
    <div id="Div1" class="myModal" data-bs-backdrop="static" visible="false" runat="server">
        <asp:Panel CssClass="card text-center position-absolute start-50 top-50 translate-middle rounded" ID="popup1" runat="server">

            <%--HEAD--%>
            <div class="card-header p-3">
                <h2 class="mb-0">Download</h2>
            </div>
            <%--HEAD-FINE--%>
            <%--BODY--%>
            <asp:Panel ID="popupBody1" CssClass="card-body d-flex justify-content-center flex-wrap p-0 gap-4" runat="server">
                <asp:Literal ID="lit" runat="server"></asp:Literal>
            </asp:Panel>
            <%--BODY-FINE--%>
            <%--FOOTER--%>
            <div class="card-footer d-flex justify-content-around p-3">
                <asp:Button ID="Button1" class="btn btn-secondary" runat="server" Text="Chiudi" OnClick="Button1_Click" />
            </div>
            <%--FOOTER-FINE--%>
        </asp:Panel>
    </div>
    <%--  end modifica kiro --%>


    <%-----------------------------------------------GRIGLIA PRESTAZIONI CHIUSE------------------------------------------------------------------------%>

    <div class="mb-4">
        <h2 class="text-center mb-4 mt-4">Prestazioni chiuse</h2>
        <div class="d-flex justify-content-center">
            <asp:Label ID="lblVuota2" CssClass="display-5" runat="server" Text=""></asp:Label>
        </div>
        <asp:GridView ID="gridPrestazioniChiuse" runat="server" AutoGenerateColumns="False" DataKeyNames="idPrestazione" CssClass="table table-bordered table-hover table-striped table-responsive" OnRowDataBound="gridPrestazioniChiuse_RowDataBound" OnRowCommand="gridPrestazioniChiuse_RowCommand" >
            <Columns>
                <asp:BoundField DataField="Nome Paziente" HeaderText="Paziente" />
                <asp:BoundField DataField="DataNascita" HeaderText="Data di nascita" />
                <asp:BoundField DataField="CodFiscale" HeaderText="Codice Fiscale" />
                <asp:BoundField DataField="Nome Medico" HeaderText="Medico" />
                <asp:BoundField DataField="DataPrestazione" HeaderText="Data Prestazione" />
                <asp:BoundField DataField="DataChiusura" HeaderText="Chiusura Prestazione" />
                <asp:BoundField DataField="Anamnesi" HeaderText="Anamnesi" />
                <asp:BoundField DataField="Referto" HeaderText="Referto" />
                <asp:TemplateField HeaderText="Download Doc">
                    <ItemTemplate>
                        <asp:Button ID="btnDownload" CssClass="btn btn-primary"
                            CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                            CommandName="Download" runat="server" Text="Download" class="btn" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>



