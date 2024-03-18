<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePaziente.master" AutoEventWireup="true" CodeFile="PrestazioniFiglia.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="container" class="p-5 pt-0" style="width: 100%;">

        <%--roba presa da CALENDARIO_TEST--%>
        <div>
            <div style="display: flex; justify-content: space-between;">
                <h1>Prestazioni Terminate</h1>
            </div>

            <div class="d-flex align-items-center mt-2">
                <asp:Panel ID="Panel2" runat="server" class="form-floating mb-4" Style="width: 16em;">
                    <%--aggiungere qui enabled visible ecc. e non al txtbox--%>
                    <asp:DropDownList runat="server" class="form-select" ID="ddlTipologia" aria-label="Floating label select" OnSelectedIndexChanged="ddlTipologia_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Value="0">--Seleziona Tipologia--</asp:ListItem>
                        <asp:ListItem Value="M">Visite</asp:ListItem>
                        <asp:ListItem Value="R">Radiografie</asp:ListItem>
                        <asp:ListItem Value="A">Analisi</asp:ListItem>
                    </asp:DropDownList>
                    <label for="ddltipo">Tipologia</label><%--nel for si deve inserire lo stesso ID della DDL--%>
                </asp:Panel>
                <div style="margin-left: 2em;">
                    <asp:Label ID="lblSpiegazione" runat="server" Text="">Visualizza tutte le Prestazioni concluse</asp:Label>
                </div>
            </div>

            <asp:GridView runat="server" CssClass="table table-bordered table-hover table-striped table-responsive Grid" ID="GrigliaPrestazioni"
                AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GrigliaPrestazioni_PageIndexChanging" ShowHeaderWhenEmpty="True"
                OnRowCommand="GrigliaPrestazioni_RowCommand" DataKeyNames="idPrestazione" OnRowDataBound="GrigliaPrestazioni_RowDataBound">
                <Columns>
                    <%--<asp:BoundField DataField="TipologiaSanitario" HeaderText="Tipologia" />--%>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Image ID="imgDottore" runat="server" ImageUrl='<%# "GestoreImg.ashx?c="+ Eval("idSanitario") %>' />
                        </ItemTemplate>
                        <ControlStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="NominativoSanitario" HeaderText="Dottore" />
                    <asp:BoundField DataField="TipologiaSanitario" HeaderText="Tipologia" />
                    <asp:BoundField DataField="Prestazione" HeaderText="Prestazione" />
                    <asp:BoundField DataField="DataPrestazione" HeaderText="Data Prestazione" DataFormatString="{0:g}" />
                    <asp:BoundField DataField="DataChiusura" HeaderText="Data Chiusura" DataFormatString="{0:g}" />
                    <asp:BoundField DataField="Anamnesi" HeaderText="Anamnesi" ItemStyle-CssClass="Shorter" />
                    <%--<asp:BoundField DataField="Referto" HeaderText="Referto" ItemStyle-CssClass="Shorter" />--%>
                    <asp:TemplateField HeaderText="Referto">
                        <ItemTemplate>
                            <asp:Button ID="btnInfo"
                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                CommandName="Mostra" runat="server" Text="Referto" ControlStyle-CssClass="btn btn-primary" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Scarica Documento">
                        <ItemTemplate>
                            <asp:Button ID="btnPdf"
                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                CommandName="Pdf" runat="server" Text="Documento" ControlStyle-CssClass="btn btn-primary" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <%--------------------------------POPUP per PDF/Immagini--------------------------------%>
        <div id="PdfPopup" class="myModal" visible="false" runat="server">
            <asp:Panel CssClass="card text-center position-absolute start-50 top-50 translate-middle rounded" ID="popup" runat="server">


                <%--HEAD--%>
                <div class="card-header p-3">
                    <h2 class="mb-0">Referto</h2>
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

        <%--------------------------------POPUP per visualizzazione migliore delle informazioni--------------------------------%>
        <div id="InformazioniPopup" class="myModal" visible="false" runat="server">
            <asp:Panel ID="pnlInfoPopup" runat="server" CssClass="card text-center position-absolute start-50 top-50 translate-middle rounded" Style="min-width: 33%; min-height: 50%;">
                <%--HEAD--%>
                <div class="card-header p-3">
                    <h2 class="mb-0">Informazioni</h2>
                </div>
                <%--HEAD-FINE--%>

                <%--BODY--%>
                <div class="card-body d-flex flex-column">


                    <asp:Panel ID="pnlReferto" runat="server" class="form-floating my-auto">
                        <asp:TextBox ID="txtReferto" class="form-control fs-3 my-auto" runat="server" type="text" Style="resize: none; overflow: hidden; color: gray; width: 100%!important; min-height: 10rem!important;" TextMode="MultiLine" ReadOnly="True" ClientIDMode="Static" />
                        <label for="txtReferto">Referto</label>
                    </asp:Panel>

                </div>
                <%--BODY-FINE--%>

                <%--FOOTER--%>
                <div class="card-footer d-flex justify-content-around p-3">
                    <asp:Button ID="ChiudiInfo" class="btn btn-secondary" runat="server" Text="Chiudi" OnClick="ChiudiInfo_Click" />
                </div>
                <%--FOOTER-FINE--%>
            </asp:Panel>
        </div>

    </div>

</asp:Content>
