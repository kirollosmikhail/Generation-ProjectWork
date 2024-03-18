using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    static int _idPrenotazione;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GrigliaPrenotazioni();
            //ListaSedi();
            //ListaMedici();
            ListaSediPopup();
        }

    }

    protected void ListaSediPopup()
    {
        CONNESSIONE co = new CONNESSIONE();
        co.Select("SEDI_SelectDDL");
        ddlNuovaPrenotazione.DataSource = co.dt;
        ddlNuovaPrenotazione.DataTextField = "IndirizzoSede";
        ddlNuovaPrenotazione.DataValueField = "idSede";
        ddlNuovaPrenotazione.DataBind();
        ddlNuovaPrenotazione.Items.Insert(0, new ListItem() { Text = "Seleziona Sede", Value = "" });
    }


    protected void GrigliaPrenotazioni()
    {
        CONNESSIONE co = new CONNESSIONE();
        co.AddParametro("@idPaziente", int.Parse(Session["idPaziente"].ToString()));
        co.AddParametro("@Pagato", false);
        co.Select("PAZIENTE_GridView_PrenotazioniPagateSiNo");
        GrigliaPrenotazione.DataSource = co.dt;
        GrigliaPrenotazione.DataBind();
    }
    protected void GrigliaPrenotazione_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrigliaPrenotazione.PageIndex = e.NewPageIndex;
        GrigliaPrenotazioni();
    }


    //Metodi per nuova prenotazione

    #region Nuova prenotazione
    //Apro popUp nuova prenotazione
    protected void btnPre_Click(object sender, EventArgs e)
    {
        PopupPre.Visible = true;
    }

    //chiudo popup nuova prenotazione
    protected void btnAnnullaIns_Click(object sender, EventArgs e)
    {
        PopupPre.Visible = false;
    }

    //Inserisco la nuova prenotazione
    protected void btnConfermaIns_Click(object sender, EventArgs e)
    {
        if (ddlNuovaPrenotazione.SelectedValue is null || ddlNuovaPrenotazione.SelectedValue == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Errore", "alert('Scegliere la sede');", true);
            return;
        }

        TARIFFARIO tr = new TARIFFARIO();
        tr.idTariffario = 13;
        tr.SelectId();

        PRENOTAZIONI pe = new PRENOTAZIONI();
        pe.idSede = int.Parse(ddlNuovaPrenotazione.SelectedValue.ToString());
        pe.idPaziente = int.Parse(Session["idPaziente"].ToString());
        pe.Data = DateTime.Now;
        pe.Pagato = false;
        pe.idTariffario = tr.idTariffario;
        pe.Prezzo = tr.Prezzo;
        pe.Inserisci();
        RegistraOperazione("Inserita nuova prenotazione", "Prenotazioni Paziente");
        PopupPre.Visible = false;
        PopupInfo.Visible = true;
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Avviso", "alert('Prenotazione conclusa');", true);
        //GrigliaPrenotazioni();
    }
    protected void btnChiudi_Click(object sender, EventArgs e)
    {
        PopupInfo.Visible = false;
        GrigliaPrenotazioni();
    }


    #endregion

    //metodi per popup pagamento

    #region Pagamento

    //Controllo se la prenotazione è pagato o no e rendo il pulsante visibile di conseguenza
    protected void GrigliaPrenotazione_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string nominativoSanitario = DataBinder.Eval(e.Row.DataItem, "NominativoSanitario") as string;

            Button btnDownload = e.Row.FindControl("btnDownload") as Button;

            if (string.IsNullOrEmpty(nominativoSanitario))
            {

                if (btnDownload != null)
                {
                    btnDownload.Visible = false;
                }
            }
        }
    }

    //Clicco sul pulsante paga e rendo visibile popup
    protected void GrigliaPrenotazione_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Paga")
        {

            int rowIndex = int.Parse(e.CommandArgument.ToString());
            int val = (int)this.GrigliaPrenotazione.DataKeys[rowIndex]["idPrenotazione"];

            string primaryKeyValue = GrigliaPrenotazione.DataKeys[rowIndex].Values["idPrenotazione"].ToString();

            int primaryKey;
            int.TryParse(primaryKeyValue, out primaryKey);
            _idPrenotazione = primaryKey;
            PopupPaga.Visible = true;

        }
    }

    //chiudo popup pagamento
    protected void btnAnnullaPaga_Click(object sender, EventArgs e)
    {
        PopupPaga.Visible = false;
    }

    //confermo il pagamento e lo rendo true nel DB
    protected void btnConfermaPaga_Click(object sender, EventArgs e)
    {

        PRENOTAZIONI pe = new PRENOTAZIONI();
        pe.idPrenotazione = _idPrenotazione;
        //pe.idPrenotazione = int.Parse(GrigliaPrenotazione.SelectedValue.ToString());
        pe.SelectId();
        pe.Pagato = true;
        pe.DataPagamento = DateTime.Now;
        pe.Modifica();
        RegistraOperazione("Effettuato pagamento", "Prenotazioni Paziente");
        PopupPaga.Visible = false;
        PopupPagamentoEseguito.Visible = true;
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Avviso", "alert('Pagamento avvenuto con successo');", true);
        //GrigliaPrenotazioni();
    }
    protected void btnChiudiPopupPagamento_Click(object sender, EventArgs e)
    {
        PopupPagamentoEseguito.Visible = false;
        GrigliaPrenotazioni();
    }

    #endregion

    //meotodo registra operazioni
    protected void RegistraOperazione(string strOperazione, string strProgramma)
    {
        Log_Operazioni l = new Log_Operazioni();
        l.Operazione = strOperazione;
        l.Programma = strProgramma;
        l.UserMail = Session["USR"].ToString();
        l.DataLog = DateTime.Now;
        l.LogOperazioni_Inserisci();
    }

    //extra filtri eliminati dopo ultima review, da cancellare

    //protected void ListaMedici()
    //{
    //    CONNESSIONE co = new CONNESSIONE();
    //    co.Select("SANITARI_SelectDDL");
    //    ddlMedico.DataSource = co.dt;
    //    ddlMedico.DataTextField = "NominativoSanitario";
    //    ddlMedico.DataValueField = "idSanitario";
    //    ddlMedico.DataBind();
    //    ddlMedico.Items.Insert(0, new ListItem() { Text = "Seleziona Medico", Value = "" });
    //}


    //filtri eliminati
    //protected void GrigliaPrenotazioneFiltro()
    //{
    //    CONNESSIONE co = new CONNESSIONE();

    //    if (ddlMedico.SelectedValue.ToString() != "")
    //    {
    //        co.AddParametro("@idSanitario", int.Parse(ddlMedico.SelectedValue.ToString()));
    //    }
    //    else
    //    {
    //        co.AddParametro("@idSanitario");
    //    }
    //    if (ddlSede.SelectedValue.ToString() != "")
    //    {
    //        co.AddParametro("@idSede", int.Parse(ddlSede.SelectedValue.ToString()));
    //    }
    //    else
    //    {
    //        co.AddParametro("@idSede");
    //    }
    //    //if (txtData.Text != "")
    //    //{
    //    //    co.AddParametro("@DataPrestazione", DateTime.Parse(txtData.Text));
    //    //}
    //    //else
    //    //{
    //    co.AddParametro("@DataPrestazione");
    //    //}
    //    co.AddParametro("@idPaziente", int.Parse(Session["idPaziente"].ToString()));
    //    co.AddParametro("@Pagato", false);
    //    co.Select("PrenotazioniAttiveFiglia_v_PRENOTAZIONI_SelectFiltri");
    //    GrigliaPrenotazione.DataSource = co.dt;
    //    GrigliaPrenotazione.DataBind();
    //}

    //protected void ddlMedico_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    GrigliaPrenotazioneFiltro();
    //}

    //protected void ddlSede_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    GrigliaPrenotazioneFiltro();
    //}

    //protected void txtData_TextChanged(object sender, EventArgs e)
    //{
    //    GrigliaPrenotazioneFiltro();
    //}
    //protected void ListaSedi()
    //{
    //    CONNESSIONE co = new CONNESSIONE();
    //    co.Select("SEDI_SelectDDL");
    //    ddlSede.DataSource = co.dt;
    //    ddlSede.DataTextField = "IndirizzoSede";
    //    ddlSede.DataValueField = "idSede";
    //    ddlSede.DataBind();
    //    ddlSede.Items.Insert(0, new ListItem() { Text = "Seleziona Sede", Value = "" });
    //}


    //


}