using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
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
        SEDI s = new SEDI();
        grigliaSedi.DataSource = s.Select();
        grigliaSedi.AllowPaging = true;
        grigliaSedi.PageSize = 10;
        grigliaSedi.DataBind();
    }

    //PAGING DELLA TABELLA
    protected void grigliaSedi_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grigliaSedi.PageIndex = e.NewPageIndex;
        CaricaGriglia(); // Rileggi i dati per la nuova pagina
    }

    //APRE IL POPUP PER INSERIRE I NUOVI DATI
    protected void btnInserisci_Click(object sender, EventArgs e)
    {
        txtIndirizzoIns.Text = "";
        txtCAPIns.Text = "";
        txtTelefonoIns.Text = "";
        txtCittaIns.Text = "";
        txtProvinciaIns.Text = "";
        txtEmailIns.Text = "";
        inserisci.Visible = true;
    }

    //CHIUDE IL POPUP DI INSERIMENTO E CANCELLA I DATI SCRITTI ALL'INTERNO
    protected void btnAnnullaIns_Click(object sender, EventArgs e)
    {
        txtIndirizzoIns.Text = "";
        txtCAPIns.Text = "";
        txtTelefonoIns.Text = "";
        txtCittaIns.Text = "";
        txtProvinciaIns.Text = "";
        txtEmailIns.Text = "";
        inserisci.Visible = false;

        lblInsindirizzo.Visible = false;
        txtIndirizzoIns.CssClass = "form-control ft-Large";
        lblInsCAP.Visible = false;
        txtCAPIns.CssClass = "form-control ft-Small";
        lblInstelefono.Visible = false;
        txtTelefonoIns.CssClass = "form-control ft-Medium";
        lblInsprovincia.Visible = false;
        txtProvinciaIns.CssClass = "form-control ft-Small";
        lblInsemail.Visible = false;
        txtEmailIns.CssClass = "form-control ft-Large";
        lblInscitta.Visible = false;
        txtCittaIns.CssClass = "form-control ft-Medium";
    }

    //INSERISCE I NUOVI DATI NEL DB E CHIUDE IL POPUP
    protected void btnConfermaIns_Click(object sender, EventArgs e)
    {
        if (txtIndirizzoIns.Text == "" || txtCAPIns.Text == "" || txtTelefonoIns.Text == "" || txtCittaIns.Text == "" || txtProvinciaIns.Text == "" || txtEmailIns.Text == "")
        {
            //indirizzo
            if (txtIndirizzoIns.Text == "")
            {
                lblInsindirizzo.Visible = true;
                txtIndirizzoIns.CssClass = "form-control ft-Large is-invalid border-danger";
                lblInsindirizzo.Text = "Inserisci un Indirizzo";
            }
            else
            {
                lblInsindirizzo.Visible = false;
                txtIndirizzoIns.CssClass = "form-control ft-Large";
            }
            //CAP
            if (txtCAPIns.Text == "")
            {
                lblInsCAP.Visible = true;
                txtCAPIns.CssClass = "form-control ft-Small is-invalid border-danger";
                lblInsCAP.Text = "Inserisci un CAP";
            }
            else
            {
                lblInsCAP.Visible = false;
                txtCAPIns.CssClass = "form-control ft-Small";
            }
            //telefono
            if (txtTelefonoIns.Text == "")
            {
                lblInstelefono.Visible = true;
                txtTelefonoIns.CssClass = "form-control ft-Medium is-invalid border-danger";
                lblInstelefono.Text = "Inserisci un Numero di Telefono";
            }
            else
            {
                lblInstelefono.Visible = false;
                txtTelefonoIns.CssClass = "form-control ft-Medium";
            }
            //Citta
            if (txtCittaIns.Text == "")
            {
                lblInscitta.Visible = true;
                txtCittaIns.CssClass = "form-control ft-Medium is-invalid border-danger";
                lblInscitta.Text = "Inserisci una Città";
            }
            else
            {
                lblInscitta.Visible = false;
                txtCittaIns.CssClass = "form-control ft-Medium";
            }
            //provincia
            if (txtProvinciaIns.Text == "")
            {
                lblInsprovincia.Visible = true;
                txtProvinciaIns.CssClass = "form-control ft-Small is-invalid border-danger";
                lblInsprovincia.Text = "Inserisci una Provincia";
            }
            else
            {
                lblInsprovincia.Visible = false;
                txtProvinciaIns.CssClass = "form-control ft-Small";
            }
            //Email
            if (txtEmailIns.Text == "")
            {
                lblInsemail.Visible = true;
                txtEmailIns.CssClass = "form-control ft-Large is-invalid border-danger";
                lblInsemail.Text = "Inserisci un Email";
            }
            else
            {
                lblInsemail.Visible = false;
                txtEmailIns.CssClass = "form-control ft-Large";
            }
            return;
        }
        else
        {
            lblInsindirizzo.Visible = false;
            txtIndirizzoIns.CssClass = "form-control ft-Large";
            lblInsCAP.Visible = false;
            txtCAPIns.CssClass = "form-control ft-Small";
            lblInstelefono.Visible = false;
            txtTelefonoIns.CssClass = "form-control ft-Medium";
            lblInsprovincia.Visible = false;
            txtProvinciaIns.CssClass = "form-control ft-Small";
            lblInsemail.Visible = false;
            txtEmailIns.CssClass = "form-control ft-Large";
            lblInscitta.Visible = false;
            txtCittaIns.CssClass = "form-control ft-Medium";
        }
        
            SEDI s = new SEDI();
            s.Indirizzo = txtIndirizzoIns.Text;
            s.CAP = txtCAPIns.Text;
            s.Telefono = txtTelefonoIns.Text;
            s.Citta = txtCittaIns.Text;
            s.Provincia = txtProvinciaIns.Text;
            s.Email = txtEmailIns.Text;
            inserisci.Visible = false;
            s.Inserisci();
            RegistraOperazione("Inserisci", "Sedi");
            CaricaGriglia();
    }

    //CHIUDE IL POPUP DI MODIFICA E CANCELLA I DATI SCRITTI ALL'INTERNO
    protected void btnAnnullaMod_Click(object sender, EventArgs e)
    {
        txtIndirizzoMod.Text = "";
        txtCAPMod.Text = "";
        txtTelefonoMod.Text = "";
        txtCittaMod.Text = "";
        txtProvinciaMod.Text = "";
        txtEmailMod.Text = "";
        modifica.Visible = false;

        lblModindirizzo.Visible = false;
        txtIndirizzoMod.CssClass = "form-control ft-Large";
        lblModCAP.Visible = false;
        txtCAPMod.CssClass = "form-control ft-Small";
        lblModtelefono.Visible = false;
        txtTelefonoMod.CssClass = "form-control ft-Medium";
        lblModprovincia.Visible = false;
        txtProvinciaMod.CssClass = "form-control ft-Small";
        lblModemail.Visible = false;
        txtEmailMod.CssClass = "form-control ft-Large";
        lblModcitta.Visible = false;
        txtCittaMod.CssClass = "form-control ft-Medium";
    }

    //MODIFICA I DATI NEL DB E CHIUDE IL POPUP
    protected void btnConfermaMod_Click(object sender, EventArgs e)
    {
        if (txtIndirizzoMod.Text == "" || txtCAPMod.Text =="" || txtTelefonoMod.Text== "" || txtCittaMod.Text =="" || txtProvinciaMod.Text== "" || txtEmailMod.Text == "")
        {
            //indirizzo
            if (txtIndirizzoMod.Text == "")
            {
                lblModindirizzo.Visible = true;
                txtIndirizzoMod.CssClass = "form-control ft-Large is-invalid border-danger";
                lblModindirizzo.Text = "Moderisci un Indirizzo";
            }
            else
            {
                lblModindirizzo.Visible = false;
                txtIndirizzoMod.CssClass = "form-control ft-Large";
            }
            //CAP
            if (txtCAPMod.Text == "")
            {
                lblModCAP.Visible = true;
                txtCAPMod.CssClass = "form-control ft-Small is-invalid border-danger";
                lblModCAP.Text = "Moderisci un CAP";
            }
            else
            {
                lblModCAP.Visible = false;
                txtCAPMod.CssClass = "form-control ft-Small";
            }
            //telefono
            if (txtTelefonoMod.Text == "")
            {
                lblModtelefono.Visible = true;
                txtTelefonoMod.CssClass = "form-control ft-Medium is-invalid border-danger";
                lblModtelefono.Text = "Moderisci un Numero di Telefono";
            }
            else
            {
                lblModtelefono.Visible = false;
                txtTelefonoMod.CssClass = "form-control ft-Medium";
            }
            //Citta
            if (txtCittaMod.Text == "")
            {
                lblModcitta.Visible = true;
                txtCittaMod.CssClass = "form-control ft-Medium is-invalid border-danger";
                lblModcitta.Text = "Moderisci una Città";
            }
            else
            {
                lblModcitta.Visible = false;
                txtCittaMod.CssClass = "form-control ft-Medium";
            }
            //provincia
            if (txtProvinciaMod.Text == "")
            {
                lblModprovincia.Visible = true;
                txtProvinciaMod.CssClass = "form-control ft-Small is-invalid border-danger";
                lblModprovincia.Text = "Moderisci una Provincia";
            }
            else
            {
                lblModprovincia.Visible = false;
                txtProvinciaMod.CssClass = "form-control ft-Small";
            }
            //Email
            if (txtEmailMod.Text == "")
            {
                lblModemail.Visible = true;
                txtEmailMod.CssClass = "form-control ft-Large is-invalid border-danger";
                lblModemail.Text = "Moderisci un Email";
            }
            else
            {
                lblModemail.Visible = false;
                txtEmailMod.CssClass = "form-control ft-Large";
            }
            return;
        }
        else
        {
            lblModindirizzo.Visible = false;
            txtIndirizzoMod.CssClass = "form-control ft-Large";
            lblModCAP.Visible = false;
            txtCAPMod.CssClass = "form-control ft-Small";
            lblModtelefono.Visible = false;
            txtTelefonoMod.CssClass = "form-control ft-Medium";
            lblModprovincia.Visible = false;
            txtProvinciaMod.CssClass = "form-control ft-Small";
            lblModemail.Visible = false;
            txtEmailMod.CssClass = "form-control ft-Large";
            lblModcitta.Visible = false;
            txtCittaMod.CssClass = "form-control ft-Medium";
        }
        SEDI s = new SEDI();
            s.idSede = int.Parse(grigliaSedi.SelectedValue.ToString());
            s.SelectId();
            s.Indirizzo = txtIndirizzoMod.Text;
            s.CAP = txtCAPMod.Text;
            s.Telefono = txtTelefonoMod.Text;
            s.Citta = txtCittaMod.Text;
            s.Provincia = txtProvinciaMod.Text;
            s.Email = txtEmailMod.Text;
            s.Modifica();
            RegistraOperazione("Modifica","Sedi");
            modifica.Visible = false;
            CaricaGriglia();
        
    }

    //APRE IL POPUP DI MODIFICA DATI RIEMPIENDO I CAMPI CON I DATI GIA' PRESENTI NEL DB IN BASE ALLA RIGA SELEZIONATA
    protected void grigliaSedi_SelectedIndexChanged(object sender, EventArgs e)
    {
        modifica.Visible = true;
        RiempiCampiMod();
    }

    //RECUPERA LE INFORMAZIONI DAL DB E RIEMPIE I CAMPI
    protected void RiempiCampiMod()
    {
        SEDI s = new SEDI();
        s.idSede = int.Parse(grigliaSedi.SelectedValue.ToString());
        s.SelectId();
        txtIndirizzoMod.Text = s.Indirizzo.ToString();
        txtCAPMod.Text = s.CAP.ToString();
        txtTelefonoMod.Text = s.Telefono.ToString();
        txtCittaMod.Text = s.Citta.ToString();
        txtProvinciaMod.Text = s.Provincia.ToString();
        txtEmailMod.Text = s.Email.ToString();
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