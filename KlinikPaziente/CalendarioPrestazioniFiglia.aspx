<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePaziente.master" AutoEventWireup="true" CodeFile="CalendarioPrestazioniFiglia.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="container" class="p-5 pt-0" style="width: 100%">

        <div style="display: flex; justify-content: space-between;">
            <h1>Calendario Prestazioni</h1>
        </div>

        <%--------------------------------DDL--------------------------------%>
        <div style="margin: 1em 0;" class="d-flex justify-content-between">
            <div class="d-flex justify-content-center align-items-center">
                <asp:Panel ID="pnlDdl" runat="server" class="form-floating mb-4" Style="width: 16em;">
                    <%--aggiungere qui enabled visible ecc. e non al txtbox--%>
                    <asp:DropDownList runat="server" class="form-select" ID="ddlTipologia" aria-label="Floating label select" OnSelectedIndexChanged="ddlTipologia_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Value="0">--Seleziona Tipologia--</asp:ListItem>
                        <asp:ListItem Value="M">Visite</asp:ListItem>
                        <asp:ListItem Value="R">Radiografie</asp:ListItem>
                        <asp:ListItem Value="A">Analisi</asp:ListItem>
                    </asp:DropDownList>
                    <label for="ddlTipologia">Tipologia Sanitario</label><%--nel for si deve inserire lo stesso ID della DDL--%>
                </asp:Panel>
                <p style="margin-left: 2em;">Calendario di tutte le prestazioni passate e future</p>
            </div>
        </div>

        <%--------------------------------GridView--------------------------------%>
        <asp:GridView runat="server" CssClass="table table-bordered table-hover table-striped table-responsive" ID="GrigliaCalendario" DataKeyNames="idPrestazione"
            AutoGenerateColumns="False" OnSelectedIndexChanged="GrigliaCalendario_SelectedIndexChanged" ShowHeaderWhenEmpty="True" OnPageIndexChanging="GrigliaCalendario_PageIndexChanging"
            OnRowDataBound="GrigliaCalendario_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Image ID="imgDottore" runat="server" ImageUrl='<%# "GestoreImg.ashx?c="+ Eval("idSanitario") %>' />
                    </ItemTemplate>
                    <ControlStyle Width="50px" />
                </asp:TemplateField>
                <asp:BoundField DataField="NominativoSanitario" HeaderText="Dottore" />
                <asp:BoundField DataField="SedeCompletaSanitario" HeaderText="Sede" />
                <asp:BoundField DataField="IndirizzoSede" HeaderText="Indirizzo" />
                <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                <asp:BoundField DataField="DataPrestazione" HeaderText="Data Prestazione" DataFormatString="{0:g}" />
                <asp:BoundField HeaderText="" />
                <%-- <asp:CommandField ButtonType="Button" ShowSelectButton="True" ControlStyle-CssClass="btn btn-primary">
                    <ControlStyle CssClass="btn btn-primary"></ControlStyle>
                </asp:CommandField>--%>
            </Columns>
        </asp:GridView>

    </div>

    <%--------------------------------POPUP--------------------------------%>
    <div id="inserisci" class="myModal" visible="false" runat="server">
        <div class="card text-center position-absolute start-50 top-50 translate-middle rounded" style="min-width: 33%">

            <%--HEAD--%>
            <div class="card-header p-3">
                <h2 class="mb-0">Informazioni</h2>
            </div>
            <%--HEAD-FINE--%>

            <%--BODY--%>
            <div class="card-body d-flex justify-content-center flex-wrap p-5 gap-5">

                <%--SEZION1--%>
                <div class="d-flex flex-column gap-4">
                    <asp:Panel ID="pnlSanitario" runat="server" class="form-floating">
                        <asp:TextBox ID="txtSanitario" class="formLoginMedium form-control" runat="server" type="text" Style="resize: none; overflow: hidden; color: gray" ReadOnly="True" />
                        <label for="txtSanitario">Dottore</label>
                    </asp:Panel>
                    <asp:Panel ID="pnlSede" runat="server" class="form-floating">
                        <asp:TextBox ID="txtSede" class="formLoginMedium form-control" runat="server" type="text" Style="resize: none; overflow: hidden; color: gray" ReadOnly="True" ClientIDMode="Static" TextMode="MultiLine" />
                        <label for="txtSede">Sede</label>
                    </asp:Panel>
                    <asp:Panel ID="pnlDataPrestazione" runat="server" class="form-floating">
                        <asp:TextBox ID="txtDataPrestazione" class="formLoginMedium form-control" runat="server" type="text" Style="resize: none; overflow: hidden; color: gray" ReadOnly="True" />
                        <label for="txtDataPrestazione">Data Prestazione</label>
                    </asp:Panel>
                </div>
                <%--SECTION2--%>
                <div class="d-flex flex-column gap-5 ml-5" style="width: 8em;">
                    <asp:Literal ID="litImg" runat="server"></asp:Literal>
                </div>
            </div>
            <%--BODY-FINE--%>

            <%--FOOTER--%>
            <div class="card-footer d-flex justify-content-around p-3">
                <asp:Button ID="btnChiudi" class="btn btn-secondary" runat="server" Text="Chiudi" OnClick="btnChiudi_Click" />
                <%--per il funzionamento: protected void btnAnnullaIns_Click(object sender, EventArgs e), in Oggetti.aspx.cs--%>
            </div>
            <%--FOOTER-FINE--%>
        </div>
    </div>

</asp:Content>

