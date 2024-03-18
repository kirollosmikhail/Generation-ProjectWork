<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Rendicontazione.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHoldertitolo" runat="Server">
    <h1>Rendicontazione</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- INIZIO RICERCA RENDICONTAZIONE --%>
    <div class="d-flex flex-row flex-wrap justify-content-around mb-4 align-items-baseline">
        <div class="d-flex flex-column">
            <div class="d-flex gap-4 mb-4">
                <%--justify-content-center flex-wrap --%>
                <asp:Panel ID="Panel2" runat="server" class="form-floating">
                    <asp:DropDownList runat="server" class="form-select" ID="ddlTipologia" AutoPostBack="true" aria-label="Floating label select" OnSelectedIndexChanged="Filtro">
                        <asp:ListItem Text="--Seleziona Tipo Visita--" Value=""></asp:ListItem>
                        <asp:ListItem Text="Visita Medica" Value="M"></asp:ListItem>
                        <asp:ListItem Text="Analisi" Value="A"></asp:ListItem>
                        <asp:ListItem Text="Radiografia" Value="R"></asp:ListItem>
                    </asp:DropDownList>
                    <label for="ddlTipologia">Tipologia di visita</label>
                </asp:Panel>
                <asp:Panel ID="Panel3" runat="server" class="form-floating" Style="margin: 0 1em;">
                    <asp:DropDownList runat="server" class="form-select" ID="ddlSede" AutoPostBack="true" aria-label="Floating label select" OnSelectedIndexChanged="Filtro"></asp:DropDownList>
                    <label for="ddlSede">Città</label>
                </asp:Panel>
                <asp:Panel ID="Panel4" runat="server" class="form-floating" Style="margin-right: 1em;">
                    <asp:DropDownList runat="server" class="form-select" ID="ddlPagato" AutoPostBack="true" aria-label="Floating label select" OnSelectedIndexChanged="Filtro">
                        <asp:ListItem Text="--Seleziona Stato Pagamento--" Value=""></asp:ListItem>
                        <asp:ListItem Text="Pagato - ✅" Value="true"></asp:ListItem>
                        <asp:ListItem Text="Non Pagato - ❌" Value="false"></asp:ListItem>
                    </asp:DropDownList>
                    <label for="ddlPagato">Stato Pagamento</label>
                </asp:Panel>
            </div>
            <div class="d-flex justify-content-center">
                <asp:Button ID="btnGrafici" runat="server" class="btn btn-primary" Text="Grafici" OnClick="btnGrafici_Click" />
            </div>
        </div>
        <div style="width: 15em;" class="d-flex justify-content-center">
            <column class="col-3 col-lg-3 d-flex" style="width: 15em;">
                <card class="card shadow my-4 pt-3 d-flex align-items-center">
                    <div class="card-body" style="text-align: center;">
                        <h5 class="card-title" style="color: green;"><strong>Pagato</strong></h5>
                        <p class="card-text">
                            <asp:Label ID="lblPagato" runat="server" Text=""></asp:Label>
                        </p>
                        <hr />
                        <h5 class="card-title" style="color: darkred;"><strong>Non Pagato</strong></h5>
                        <p class="card-text">
                            <asp:Label ID="lblNonPagato" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                </card>
            </column>
        </div>
    </div>

    <%-- FINE RICERCA RENDICONTAZIONE  --%>

    <%--INIZIO POPUP GRAFICI--%>
    <div id="apri" class="myModal" visible="false" runat="server">
        <div class="card text-center position-absolute start-50 top-50 translate-middle rounded" style="min-width: 33%; max-height: 75vh">

            <%--HEAD--%>
            <div class="card-header p-3">
                <h2 class="mb-0">Grafici</h2>
            </div>
            <%--FINE HEAD--%>

            <div class="card-body d-flex justify-content-center flex-wrap p-2 gap-1 overflow-auto">
                <div class="d-flex flex-column">

                    <div class="d-flex gap-4">
                        <div>
                            <asp:Chart ID="MediciChart" runat="server" DataSourceID="SqlDataSource1">
                                <Titles>
                                    <asp:Title Text="Conteggio numero visite Medici">
                                    </asp:Title>
                                </Titles>
                                <Series>
                                    <asp:Series Name="ConteggiVisiteMedici" Legend="Legend1" XValueMember="NominativoSanitario" YValueMembers="Column1" ChartType="Pie"></asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                </ChartAreas>
                                <Legends>
                                    <asp:Legend Name="Legend1" Title="Medici" Docking="Right"></asp:Legend>
                                </Legends>
                            </asp:Chart>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:klinikConnectionString %>" ProviderName="<%$ ConnectionStrings:klinikConnectionString.ProviderName %>" SelectCommand="select
COUNT(idPrestazione),
NominativoSanitario
from v_PRENOTAZIONI
Group by NominativoSanitario"></asp:SqlDataSource>
                        </div>
                        <div>
                            <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource2">
                                <Titles>
                                    <asp:Title Text="Guadagni di Klinik da visite effettuate dai Medici">
                                    </asp:Title>
                                </Titles>
                                <Series>
                                    <asp:Series Name="Guadagni" Legend="Legend2" XValueMember="NominativoSanitario" YValueMembers="Column1"></asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                </ChartAreas>
                                <Legends>
                                    <asp:Legend Name="Legend2" Title="Medici"></asp:Legend>
                                </Legends>
                            </asp:Chart>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:klinikConnectionString2 %>" ProviderName="<%$ ConnectionStrings:klinikConnectionString2.ProviderName %>" SelectCommand="select
SUM(Prezzo),
NominativoSanitario
from v_PRENOTAZIONI
Group by NominativoSanitario"></asp:SqlDataSource>
                        </div>
                    </div>
                    <div>
                        <h2>Ricavi di ogni medico</h2>
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
            <%--FOOTER--%>
            <div class="card-footer d-flex justify-content-around p-3">
                <asp:Button ID="btnChiudi" class="btn btn-primary" runat="server" Text="Chiudi" OnClick="btnChiudi_Click" />
            </div>
            <%--FOOTER-FINE--%>
        </div>
    </div>
    <%--FINE POPUP GRAFICI--%>

    <%-- INIZIO GRIGLIA --%>
    <asp:GridView ID="grigliaRendicontazione" runat="server" CssClass="table table-bordered table-hover table-striped table-responsive" AutoGenerateColumns="False" DataKeyNames="idPrenotazione" OnPageIndexChanging="grigliaRendicontazione_PageIndexChanging" OnRowDataBound="grigliaRendicontazione_RowDataBound" HeaderStyle-HorizontalAlign="Center">
        <Columns>
            <asp:BoundField DataField="DataPagamento" HeaderText="Data Pagamento" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
            <asp:BoundField DataField="CittaSede" HeaderText="Sede Città"></asp:BoundField>
            <asp:BoundField DataField="NominativoSanitario" HeaderText="Medico"></asp:BoundField>
            <asp:BoundField DataField="Tipo" HeaderText="Tipologia"></asp:BoundField>
            <asp:BoundField DataField="Prestazione" HeaderText="Prestazione"></asp:BoundField>
            <asp:BoundField DataField="DataPrestazione" HeaderText="Data Prestazione" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
            <asp:BoundField DataField="Ricavo" HeaderText="Ricavo Medico" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
            <asp:BoundField DataField="Prezzo" HeaderText="Prezzo" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
            <asp:BoundField DataField="Pagato" HeaderText="Stato Pagamento" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <%-- FINE GRIGLIA --%>
</asp:Content>

