<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="listaPersonale.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHoldertitolo" runat="Server">
    <h1>Lista Personale</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="d-flex justify-content-around mb-4">
        <div class="d-flex justify-content-center gap-4 flex-wrap">

           



            <asp:Panel ID="Panel1" runat="server" class="form-floating">
                <asp:DropDownList runat="server" class="form-select" ID="ddlFiltroTipologia" AutoPostBack="true" OnSelectedIndexChanged="Page_Load" aria-label="Floating label select">
                    <asp:ListItem>--Seleziona--</asp:ListItem>
                    <asp:ListItem class="border rounded" Value="A">Amministrazione</asp:ListItem>
                    <asp:ListItem class="border rounded" Value="C">Contabilità</asp:ListItem>
                    <asp:ListItem class="border rounded" Value="S">Segreteria</asp:ListItem>

                </asp:DropDownList>
                <label for="ddlFiltroTipologia">Tipologia</label>
            </asp:Panel>

            <asp:Panel ID="Panel3" runat="server" class="form-floating">
                <asp:TextBox runat="server" class="form-control ft-Medium" OnTextChanged="Page_Load" placeholder="Mail" AutoPostBack="true" ID="txtFiltroUsrMail">
                </asp:TextBox>
                <label for="txtFiltroUsrMail">Mail</label>
            </asp:Panel>


             <asp:Panel ID="Panel4" runat="server" class="form-floating">
     <asp:TextBox runat="server" class="form-control ft-Medium" OnTextChanged="Page_Load" placeholder="Nominativo" AutoPostBack="true" ID="txtFiltroNominativoPersonale">
     </asp:TextBox>
     <label for="txtFiltroNominativoPersonale">Nominativo</label>
 </asp:Panel>


        </div>

        <div style="min-width: fit-content;">

            <asp:Button ID="btnIns" runat="server" Text="Aggiungi personale" CssClass="btn btn-primary" OnClick="btnIns_Click" />

        </div>
    </div>
    <asp:GridView ID="gridPersonale" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="idPersonale" CssClass="table table-bordered table-hover table-striped table-responsive" OnSelectedIndexChanged="gridPersonale_SelectedIndexChanged" OnPageIndexChanging="gridPersonale_PageIndexChanging">
        <columns>
            <asp:BoundField DataField="idPersonale" HeaderText="Identificativo" Visible="false" />
            <asp:BoundField DataField="Tipologia" HeaderText="Tipologia" />
            <asp:BoundField DataField="UserMail" HeaderText="Mail" />
            <asp:BoundField DataField="NominativoPersonale" HeaderText="Nominativo" />

            <%-- <asp:BoundField DataField="Cognome" HeaderText="Cognome" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" />--%>

            <asp:CommandField ShowSelectButton="True" SelectText="Modifica" ControlStyle-CssClass="btn btn-primary" />
        </columns>
    </asp:GridView>


    <%--INSERISCI MEMBRO--%>



    <%--POPUP--%>
    <div id="inserisci" class="myModal" visible="false" runat="server">
        <div class="card text-center position-absolute start-50 top-50 translate-middle rounded" style="min-width: 33%">

            <%--HEAD--%>
            <div class="card-header p-3">


                <h2 class="mb-0">AGGIUNGI PERSONALE</h2>
            </div>
            <%--HEAD-FINE--%>

            <%--BODY--%>
            <div class=" d-flex justify-content-center p-5 gap-4 pb-0">

                <%--DDL RUOLO--%>
                <div class="form-floating ">
                    <asp:DropDownList runat="server" class="form-select" ID="ddlAggTipo" aria-label="Floating label select">
                        <asp:ListItem>--Seleziona--</asp:ListItem>
                        <asp:ListItem class="border rounded" Value="A">Amministrazione</asp:ListItem>
                        <asp:ListItem class="border rounded" Value="C">Contabilità</asp:ListItem>
                        <asp:ListItem class="border rounded" Value="S">Segreteria</asp:ListItem>
                    </asp:DropDownList>
                    <label for="ddlTipo">Scegliere tipologia:</label>
                    <asp:Label CssClass="text-danger" ID="lblAvvisoTipologia" runat="server" Text=""></asp:Label>
                </div>

            </div>



            <div class="card-body d-flex justify-content-center p-5 gap-4">


                <%--SEZION1--%>
                <div class="ft-Large  d-flex flex-column gap-2 ft-Large">



                    <%--EMAIL--%>
                    <div class="form-floating">
                        <asp:TextBox runat="server" type="email" class="ft-Large form-control" ID="txtUsrMail" placeholder="Inserire una email:"></asp:TextBox>
                        <label for="txtUsrMail">Inserire una email:</label>
                        <asp:Label CssClass="text-danger" ID="lblAvvisoUsrMail" runat="server" Text=""></asp:Label>
                    </div>

                    <%--PWD--%>
                    <div class="form-floating">
                        <asp:TextBox runat="server" type="password" class="ft-Medium form-control" ID="txtPwd" placeholder="Inserire una password:"></asp:TextBox>
                        <label for="txtPwd">Inserire una password:</label>
                        <asp:Label CssClass="text-danger" ID="lblAvvisoPwd" runat="server" Text=""></asp:Label>
                    </div>


                </div>
                <%--SEZION2--%>
                <div class="ft-Large  d-flex flex-column gap-2 ft-Large">
                    <%--COGNOME--%>
                    <div class="form-floating ">
                        <asp:TextBox runat="server" type="text" class="ft-Medium form-control" ID="txtCognome" placeholder="Inserire il cognome:"></asp:TextBox>
                        <label for="txtCognome">Inserire il cognome:</label>
                        <asp:Label CssClass="text-danger" ID="lblAvvisoCognome" runat="server" Text=""></asp:Label>
                    </div>

                    <%--NOME--%>
                    <div class="form-floating ">
                        <asp:TextBox runat="server" type="text" class="ft-Medium form-control" ID="txtNome" placeholder="Inserire il nome:"></asp:TextBox>
                        <label for="txtNome">Inserire il nome:</label>
                        <asp:Label CssClass="text-danger" ID="lblAvvisoNome" runat="server" Text=""></asp:Label>
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




    <%--POPUP--%>
    <div id="Modifica" class="myModal" visible="false" runat="server">
        <div class="card text-center position-absolute start-50 top-50 translate-middle rounded" style="min-width: 33%">

            <%--HEAD--%>
            <div class="card-header p-3">
                <h2 class="mb-0">MODIFICA PERSONALE</h2>
            </div>
            <%--HEAD-FINE--%>

            <%--BODY--%>
            <div class="card-body d-flex justify-content-center flex-wrap p-5 gap-4">

                <%--SEZION1--%>
                <div class="d-flex flex-column gap-2 ft-Large">

                    <%--DDL RUOLO--%>
                    <div class="form-floating ">
                        <asp:DropDownList runat="server" class="form-select ft-Medium" ID="ddlModTipologia" aria-label="Floating label select">
                            <asp:ListItem>--Seleziona--</asp:ListItem>
                            <asp:ListItem class="border rounded" Value="A">Amministrazione</asp:ListItem>
                            <asp:ListItem class="border rounded" Value="C">Contabilità</asp:ListItem>
                            <asp:ListItem class="border rounded" Value="S">Segreteria</asp:ListItem>
                        </asp:DropDownList>
                        <label for="ddlModTipologia">Modifica tipologia:</label>
                        <asp:Label CssClass="text-danger" ID="lblAvvisoTipologiaMod" runat="server" Text=""></asp:Label>
                    </div>



                </div>
                <%--SEZION2--%>
                <div class="d-flex flex-column gap-4">
                    <%--COGNOME--%>
                    <div class="form-floating ">
                        <asp:TextBox runat="server" type="text" class="form-control ft-Medium" ID="txtCognomeMod" placeholder="Inserire il cognome:"></asp:TextBox>
                        <label for="txtCognomeMod">Modifica il cognome:</label>
                        <asp:Label CssClass="text-danger" ID="lblAvvisoCognomeMod" runat="server" Text=""></asp:Label>
                    </div>

                    <%--NOME--%>
                    <div class="form-floating ">
                        <asp:TextBox runat="server" type="text" class="form-control ft-Medium" ID="txtNomeMod" placeholder="Inserire il nome:"></asp:TextBox>
                        <label for="txtNomeMod">Modifica il nome:</label>
                        <asp:Label CssClass="text-danger" ID="lblAvvisoNomeMod" runat="server" Text=""></asp:Label>
                    </div>




                </div>
            </div>
            <%--BODY-FINE--%>

            <%--FOOTER--%>
            <div class="card-footer d-flex justify-content-around p-3">
                <asp:Button ID="btnAnnullaMod" class="btn btn-secondary" runat="server" Text="Annulla" OnClick="btnAnnullaMod_Click" />
                <%--per il funzionamento: protected void btnAnnullaIns_Click(object sender, EventArgs e), in Oggetti.aspx.cs--%>
                <asp:Button ID="btnConfermaMod" class="btn btn-primary" runat="server" Text="Modifica" OnClick="btnConfermaMod_Click" />
                <%--per il funzionamento: protected void btnConfermaIns_Click(object sender, EventArgs e), in Oggetti.aspx.cs--%>
            </div>
            <%--FOOTER-FINE--%>
        </div>
    </div>

</asp:Content>
