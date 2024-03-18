<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="listaSanitari.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<%--TITOLO PAGINA--%>
<asp:Content ID="Titolo" ContentPlaceHolderID="ContentPlaceHoldertitolo" runat="Server">
    <h1>Lista Sanitari</h1>
</asp:Content>

<%--PAGINA--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%--COMANDI DELLA PAGINA--%>
    <div class="d-flex flex-row justify-content-around p-2">

        <%--FILTRI--%>
        <div class="d-flex justify-content-center flex-wrap gap-4">

            <%--FILTRO NOMINATIVO--%>
            <asp:Panel ID="Panel2" runat="server" class="form-floating mb-4">
                <asp:TextBox runat="server" type="text" class="form-control" ID="txtFiltroNominativo" placeholder="." OnTextChanged="filtriMetodo" AutoPostBack="True"></asp:TextBox>
                <label for="txtFiltroNominativo">Nominativo</label>
            </asp:Panel>

            <%--FILTRO USRMAIL--%>
            <asp:Panel ID="Panel3" runat="server" class="form-floating mb-4" OnLoad="filtriMetodo">
                <asp:TextBox runat="server" type="text" class="form-control" ID="txtFiltroUsrMail" placeholder="." AutoPostBack="True" OnTextChanged="filtriMetodo"></asp:TextBox>
                <label for="txtFiltroUsrMail">Usermail</label>
            </asp:Panel>

            <%--FILTRO SEDE--%>
            <asp:Panel ID="Panel1" runat="server" class="form-floating mb-4">
                <asp:DropDownList runat="server" class="form-select" ID="ddlFiltroSede" aria-label="Floating label select" AutoPostBack="True" OnSelectedIndexChanged="filtriMetodo">
                </asp:DropDownList>
                <label for="ddlFiltroSede">Sede</label>
            </asp:Panel>

            <%--FILTRO TIPOLOGIA--%>
            <asp:Panel ID="Panel4" runat="server" class="form-floating mb-4">
                <asp:DropDownList runat="server" class="form-select" ID="ddlFiltroTipo" aria-label="Floating label select" AutoPostBack="True" OnSelectedIndexChanged="filtriMetodo">
                    <asp:ListItem Value="0" Text="--Seleziona--"></asp:ListItem>
                    <asp:ListItem Value="M" Text="Medico"></asp:ListItem>
                    <asp:ListItem Value="R" Text="Radiologo"></asp:ListItem>
                    <asp:ListItem Value="A" Text="Analista"></asp:ListItem>
                </asp:DropDownList>
                <label for="ddlFiltroTipo">Specializzazione</label>
            </asp:Panel>
        </div>

        <%--PULSANTI AZIONE--%>
        <div style="min-width: fit-content">
            <%--INSERISCI--%>
            <asp:Button ID="btnIns" runat="server" Text="Inserisci un nuovo sanitario" CssClass="btn btn-primary" OnClick="btnIns_Click" />
        </div>
    </div>

    <%--GRIGLIA DATI--%>
    <asp:GridView ID="gridSanitari" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="idSanitario" CssClass="table table-bordered table-hover table-striped table-responsive  " OnSelectedIndexChanged="gridSanitari_SelectedIndexChanged" OnPageIndexChanging="gridSanitari_PageIndexChanging" OnRowDataBound="gridSanitari_RowDataBound" HeaderStyle-HorizontalAlign="Center">
        <Columns>
            <asp:BoundField DataField="idSanitario" HeaderText="Identificativo" Visible="false" />
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="" ItemStyle-VerticalAlign="Middle">
                <ItemTemplate>
                    <asp:Image ID="imgDottore" runat="server" ImageUrl='<%# "GestoreFotoSanitari.ashx?c="+ Eval("idSanitario") %>' />
                </ItemTemplate>
                <ControlStyle Width="50px" />
            </asp:TemplateField>
            <asp:BoundField DataField="NominativoSanitario" ItemStyle-VerticalAlign="Middle" HeaderText="Nominativo" />
            <asp:BoundField DataField="Tipologia" ItemStyle-VerticalAlign="Middle" HeaderText="Specializzazione" />
            <asp:BoundField DataField="UserMail" ItemStyle-VerticalAlign="Middle" HeaderText="UserMail" />
            <asp:BoundField DataField="Citta" ItemStyle-VerticalAlign="Middle" HeaderText="Sede" />
            <asp:BoundField DataField="Ricavo" ItemStyle-VerticalAlign="Middle" HeaderText="Ricavo" ItemStyle-HorizontalAlign="Center" />
            <asp:CommandField ShowSelectButton="True" SelectText="Modifica" ControlStyle-CssClass="btn btn-primary" ButtonType="Button" ItemStyle-HorizontalAlign="Center" />
        </Columns>
    </asp:GridView>

    <%--POPUP INSERIMENTO E MODIFICA--%>
    <div id="divData" runat="server" class="myModal" visible="false">
        <div class="card text-center position-absolute start-50 top-50 translate-middle rounded" style="min-width: 33%">

            <%--TITOLO POPUP--%>
            <div id="divInsTitle" runat="server" visible="false" class="card-header p-3">
                <h2 class="mb-0">INSERISCI UN NUOVO MEMBRO DELLO STAFF</h2>
            </div>
            <div id="divModTitle" runat="server" visible="false" class="card-header p-3">
                <h2 class="mb-0">MODIFICA IL MEMBRO DELLO STAFF</h2>
            </div>

            <div class="card-body d-flex justify-content-center flex-wrap p-5 gap-4">

                <%--SEZIONE 1--%>
                <div class="d-flex flex-column d-flex align-items-center gap-2 ft-Large">

                    <%--NOME--%>
                    <div class="form-floating">
                        <asp:TextBox runat="server" type="text" class="form-control ft-Medium" ID="txtNome" placeholder="."></asp:TextBox>
                        <label for="txtNome">Nome</label>
                        <asp:Label ID="lblNome" runat="server" Text="" CssClass="text-danger"></asp:Label>
                    </div>

                    <%--EMAIL--%>
                    <div class="form-floating">
                        <asp:TextBox runat="server" type="email" class="form-control ft-Large" ID="txtUsrMail" placeholder="."></asp:TextBox>
                        <label for="txtUsrMail">Email</label>
                        <asp:Label ID="lblMail" runat="server" Text="" CssClass="text-danger"></asp:Label>
                    </div>

                    <%--TIOLO--%>
                    <div class="form-floating">
                        <asp:TextBox runat="server" type="text" class="form-control ft-Medium" ID="txtTitolo" placeholder="."></asp:TextBox>
                        <label for="txtTitolo">Titolo</label>
                        <asp:Label ID="lblTitoli" runat="server" Text="" CssClass="text-danger"></asp:Label>
                    </div>

                    <%--RICAVO--%>
                    <div class="form-floating">
                        <asp:TextBox runat="server" type="text" class="form-control ft-Medium" ID="txtRicavo" placeholder="."></asp:TextBox>
                        <label for="txtRicavo">Ricavo</label>
                        <asp:Label ID="lblRicavi" runat="server" Text="" CssClass="text-danger"></asp:Label>
                    </div>

                    <%--UPLOAD FOTO--%>
                    <div class="form-floating">
                        <asp:FileUpload ID="upldFoto" class="form-control ft-Large" runat="server" accept="image/*" multiple="false" />
                        <label for="upldFoto">Carica una foto:</label>
                        <asp:Label ID="lblFoto" runat="server" Text="" CssClass="text-danger"></asp:Label>
                    </div>
                </div>

                <%--SEZIONE 2--%>
                <div class="d-flex flex-column d-flex align-items-center gap-2 ft-Large">

                    <%--COGNOME--%>
                    <div class="form-floating">
                        <asp:TextBox runat="server" type="text" class="form-control ft-Medium" ID="txtCognome" placeholder="."></asp:TextBox>
                        <label for="txtCognome">Cognome</label>
                        <asp:Label ID="lblCognome" runat="server" Text="" CssClass="text-danger"></asp:Label>
                    </div>

                    <%--PWD--%>
                    <div id="divPwd" class="form-floating" runat="server">
                        <asp:TextBox runat="server" type="password" class="form-control ft-Medium" ID="txtPwd" placeholder="."></asp:TextBox>
                        <label runat="server" for="txtPwd">Password</label>
                        <asp:Label ID="lblPwD" runat="server" Text="" CssClass="text-danger"></asp:Label>
                    </div>

                    <%--FAKE PWD--%>
                    <div id="divFakePwd" class="form-floating" runat="server">
                        <asp:TextBox runat="server" type="password" class="form-control ft-Medium" ID="txtFakePwd" placeholder="." ReadOnly="True" Text="Password123@" Disabled></asp:TextBox>
                        <label runat="server" for="txtPwd">Password</label>
                    </div>

                    <%--DDL SPECIALIZZAZIONE--%>
                    <div class="form-floating">
                        <asp:DropDownList runat="server" class="form-select" ID="ddlTipo" aria-label="Floating label select" AutoPostBack="True">
                            <asp:ListItem Value="0" Text="--Seleziona--"></asp:ListItem>
                            <asp:ListItem Value="M" Text="Medico"></asp:ListItem>
                            <asp:ListItem Value="R" Text="Radiologo"></asp:ListItem>
                            <asp:ListItem Value="A" Text="Analista"></asp:ListItem>
                        </asp:DropDownList>
                        <label for="ddlTipo">Specializzazione</label>
                        <asp:Label ID="lblTipo" runat="server" Text="" CssClass="text-danger"></asp:Label>
                    </div>

                    <%--DDL SEDE--%>
                    <div class="form-floating">
                        <asp:DropDownList runat="server" class="form-select" ID="ddlSede" aria-label="Floating label select" AutoPostBack="True">
                            <asp:ListItem Value="0" Text="--Seleziona--"></asp:ListItem>
                        </asp:DropDownList>
                        <label for="ddlSede">Sede</label>
                        <asp:Label ID="lblSede" runat="server" Text="" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
            </div>

            <%--BOTTONI--%>
            <div class="card-footer d-flex justify-content-around p-3">

                <%--BOTTONE CHIUDI POPUP--%>
                <asp:Button ID="btnAnnulla" CssClass="btn btn-secondary" runat="server" Text="Annulla" OnClick="btnAnnulla_Click" />

                <%--BOTTONE SALVA DATI--%>
                <asp:Button ID="btnSalvaInsert" CssClass="btn btn-primary" runat="server" Visible="false" Text="Salva" OnClick="btnSalvaInsert_Click" />

                <%--BOTTONE MODIFICA DATI--%>
                <asp:Button ID="btnSalvaMod" CssClass="btn btn-primary" runat="server" Visible="false" Text="Salva" OnClick="btnSalvaMod_Click" />
            </div>
        </div>
    </div>
</asp:Content>

