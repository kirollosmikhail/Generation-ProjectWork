using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CaricaGriglia();
        }
    }

    //CARICO LA GRIGLIA DI VISUALIZZAZIONE
    protected void CaricaGriglia()
    {
        TARIFFARIO t = new TARIFFARIO();
        grigliaTariffario.DataSource = t.Select();
        grigliaTariffario.DataBind();
    }

    //PAGING DELLA TABELLA
    protected void grigliaTariffario_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grigliaTariffario.PageIndex = e.NewPageIndex;
        CaricaGriglia();
    }

    //APRE IL POPUP PER INSERIRE I NUOVI DATI
    protected void btnInserisci_Click(object sender, EventArgs e)
    {
        txtPrestazioneIns.Text = "";
        txtPrezzoIns.Text = "";
        inserisci.Visible = true;
    }

    //CHIUDE IL POPUP DI INSERIMENTO E CANCELLA I DATI SCRITTI ALL'INTERNO
    protected void btnAnnullaIns_Click(object sender, EventArgs e)
    {
        txtPrestazioneIns.Text = "";
        txtPrezzoIns.Text = "";
        inserisci.Visible = false;

       
        lblAvvisoPrestazioneIns.Visible = false;
        lblAvvisoPrezzoIns.Visible = false;
      
        txtPrestazioneIns.CssClass = "form-control ft-Medium";
        txtPrezzoIns.CssClass = "form-control ft-Medium";
    }

    //INSERISCE I NUOVI DATI NEL DB E CHIUDE IL POPUP
    protected void btnConfermaIns_Click(object sender, EventArgs e)
    {
            TARIFFARIO t = new TARIFFARIO();
        if (txtPrestazioneIns.Text != "" && txtPrezzoIns.Text != "")
        {
            t.Tipo = ddlTipologiaIns.SelectedValue.ToString();
            t.Prestazione = txtPrestazioneIns.Text.Trim();
            if (decimal.TryParse(txtPrezzoIns.Text.Trim(), out decimal _Prezzo))
            {
                t.Prezzo = _Prezzo;
            }

            inserisci.Visible = false;
            t.Inserisci();
            RegistraOperazione("Inserisci", "Tariffario");
            CaricaGriglia();
        }
        
        if (txtPrestazioneIns.Text == "")
        {
            lblAvvisoPrestazioneIns.Visible = true;
            lblAvvisoPrestazioneIns.Text = "Inserisci una Prestazione";
            txtPrestazioneIns.CssClass = "form-control ft-Medium border-danger is-invalid";
        }
        else
        {
            lblAvvisoPrestazioneIns.Visible = false;
            txtPrestazioneIns.CssClass = "form-control";
        }
        if (txtPrezzoIns.Text == "")
        {
            lblAvvisoPrezzoIns.Visible = true;
            lblAvvisoPrezzoIns.Text = "Inserisci un Prezzo";
            txtPrezzoIns.CssClass = "form-control ft-Medium border-danger is-invalid";
        }
        else
        {
            lblAvvisoPrezzoIns.Visible = false;
            txtPrezzoIns.CssClass = "form-control ft-Medium";
        }
        return;
    }
    
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Errore", "alert('Riempi tutti i campi');", true);
    

    //CHIUDE IL POPUP DI MODIFICA E CANCELLA I DATI SCRITTI ALL'INTERNO
    protected void btnAnnullaMod_Click(object sender, EventArgs e)
    {
        txtPrestazioneMod.Text = "";
        txtPrezzoMod.Text = "";
        modifica.Visible = false;

        
        lblAvvisoPrestazioneMod.Visible = false;
        lblAvvisoPrezzoMod.Visible = false;
       
        txtPrestazioneMod.CssClass = "form-control ft-Medium";
        txtPrezzoMod.CssClass = "form-control ft-Medium";
    }

    //MODIFICA I DATI NEL DB E CHIUDE IL POPUP
    protected void btnConfermaMod_Click(object sender, EventArgs e)
    {
        if (txtPrestazioneMod.Text != "" && txtPrezzoMod.Text != "")
        {
            TARIFFARIO t = new TARIFFARIO();
            t.idTariffario = int.Parse(grigliaTariffario.SelectedValue.ToString());
            t.SelectId();
            t.Tipo = ddlTipologiaMod.SelectedValue.ToString();
            t.Prestazione = txtPrestazioneMod.Text.Trim();
            if (decimal.TryParse(txtPrezzoMod.Text.Trim(), out decimal _Prezzo))
            {
                t.Prezzo = _Prezzo;
            }
            t.Modifica();
            RegistraOperazione("Modifica", "Tariffario");
            modifica.Visible = false;
            CaricaGriglia();
            return;
        }
        
        if (txtPrestazioneMod.Text == "")
        {
            lblAvvisoPrestazioneMod.Visible = true;
            lblAvvisoPrestazioneMod.Text = "Inserisci una Prestazione";
            txtPrestazioneMod.CssClass = "form-control ft-Medium border-danger is-invalid";
        }
        else
        {
            lblAvvisoPrestazioneMod.Visible = false;
            txtPrestazioneMod.CssClass = "form-control ft-Medium";
        }
        if (txtPrezzoMod.Text == "")
        {
            lblAvvisoPrezzoMod.Visible = true;
            lblAvvisoPrezzoMod.Text = "Inserisci un Prezzo";
            txtPrezzoMod.CssClass = "form-control ft-Medium border-danger is-invalid";
        }
        else
        {
            lblAvvisoPrezzoMod.Visible = false;
            txtPrezzoMod.CssClass = "form-control ft-Medium";
        }
        return;
    
    }

    //APRE IL POPUP DI MODIFICA DATI RIEMPIENDO I CAMPI CON I DATI GIA' PRESENTI NEL DB IN BASE ALLA RIGA SELEZIONATA
    protected void grigliaTariffario_SelectedIndexChanged(object sender, EventArgs e)
    {
        modifica.Visible = true;
        RiempiCampiMod();
    }

    //RECUPERA LE INFORMAZIONI DAL DB E RIEMPIE I CAMPI
    protected void RiempiCampiMod()
    {
        TARIFFARIO t = new TARIFFARIO();
        t.idTariffario = int.Parse(grigliaTariffario.SelectedValue.ToString());
        t.SelectId();
        txtPrestazioneMod.Text = t.Prestazione.ToString();
        txtPrezzoMod.Text = t.Prezzo.ToString();
        ddlTipologiaMod.SelectedValue = t.Tipo.ToString();
    }

    //SOSTITUISCE LA LETTERA SINGOLA CON LA SCRITTA INTERA
    protected void grigliaTariffario_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[0].Text == "M")
            {               
                e.Row.Cells[0].Text = "Visita Medica";
            }               
            if (e.Row.Cells[0].Text == "A")
            {               
                e.Row.Cells[0].Text = "Analisi";
            }               
            if (e.Row.Cells[0].Text == "R")
            {               
                e.Row.Cells[0].Text = "Radiografia";
            }

            if (DataBinder.Eval(e.Row.DataItem, "Prezzo") != DBNull.Value)
            {
                decimal prezzo = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Prezzo"));
                e.Row.Cells[2].Text = prezzo.ToString() + "€";
            }
        }
    }

    ///// REGISTRA OPERAZIONE /////
    protected void RegistraOperazione(string strOperazione, string strProgramma)
    {
        Log_Operazioni l = new Log_Operazioni();
        l.Operazione = strOperazione;
        l.Programma = strProgramma;
        l.UserMail = Session["USR"].ToString();
        l.DataLog = DateTime.Now;
        l.Inserisci();
    }
    ///// FINE REGISTRA OPERAZIONE /////

}