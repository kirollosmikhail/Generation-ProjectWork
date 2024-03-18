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
            RiempiCampi();
        }
    }

    //----------------pulsante per salvare i dati------------------
    protected void btnSalva_Click(object sender, EventArgs e)
    {
        CRITTOGRAFIA cr = new CRITTOGRAFIA();
        Accessi.AccessiSoapClient w = new Accessi.AccessiSoapClient();
        DataTable dt = w.PazientiSelectId(int.Parse(Session["idPaziente"].ToString()));
        string PWD = dt.Rows[0]["Password"].ToString();
        w.PazientiModifica(int.Parse(Session["idPaziente"].ToString()), txtRegistraEmail.Text, PWD,
            txtRegistraDataDiNascita.Text, txtRegistraCognome.Text, txtRegistraNome.Text, ddlGenere.SelectedValue,
            txtRegistraCodFiscale.Text, txtRegistraIndirizzo.Text, txtRegistraCap.Text,
            txtRegistraCitta.Text, txtRegistraProvincia.Text, txtRegistraTelefono.Text);
        RegistraOperazione("Salvati nuovi dati utente", "Profilo Paziente");

        Page.ClientScript.RegisterStartupScript(this.GetType(), "Avviso", "alert('Modifica andata a buon fine');", true);
    }

    protected void btnPW_Click(object sender, EventArgs e)
    {
        txtVecchiaPWD.Text = "";
        txtNuovaPWD.Text = "";
        txtConfermaPWD.Text = "";
        if (inserisci.Visible == false)
        { inserisci.Visible = true; }
    }

    protected void RiempiCampi()
    {
        Accessi.AccessiSoapClient w = new Accessi.AccessiSoapClient();
        DataTable dt = w.PazientiSelectId(int.Parse(Session["idPaziente"].ToString()));


        CRITTOGRAFIA cr = new CRITTOGRAFIA();
        txtRegistraEmail.Text = dt.Rows[0]["UserMail"].ToString();
        txtRegistraCognome.Text = dt.Rows[0]["Cognome"].ToString();
        txtRegistraNome.Text = dt.Rows[0]["Nome"].ToString();
        ddlGenere.SelectedValue = dt.Rows[0]["Genere"].ToString();
        txtRegistraDataDiNascita.Text = dt.Rows[0]["DataNascita"].ToString();
        txtRegistraCodFiscale.Text = dt.Rows[0]["CodFiscale"].ToString();
        txtRegistraIndirizzo.Text = dt.Rows[0]["Indirizzo"].ToString();
        txtRegistraCap.Text = dt.Rows[0]["CAP"].ToString();
        txtRegistraCitta.Text = dt.Rows[0]["Citta"].ToString();
        txtRegistraProvincia.Text = dt.Rows[0]["Provincia"].ToString();
        txtRegistraTelefono.Text = dt.Rows[0]["Telefono"].ToString();
    }

    protected void btnAnnullaIns_Click(object sender, EventArgs e)
    {

        inserisci.Visible = false;
    }

    protected void BtnConfermaPWD_Click(object sender, EventArgs e)
    {
        if (txtNuovaPWD.Text != txtConfermaPWD.Text)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Avviso", "alert('Le password non corrispondono');", true);
            return;
        }

        CRITTOGRAFIA cr = new CRITTOGRAFIA();
        Accessi.AccessiSoapClient w = new Accessi.AccessiSoapClient();
        DataTable dt = w.PazientiSelectId(int.Parse(Session["idPaziente"].ToString()));
        string mail = dt.Rows[0]["UserMail"].ToString();

        if (cr.Crypta(txtVecchiaPWD.Text) != dt.Rows[0]["Password"].ToString())
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Avviso", "alert('La vecchia password non esiste');", true);
            return;
        }
        RegistraOperazione("Modificata password", "Profilo Paziente");

        w.ModificaPassword(mail, cr.Crypta(txtVecchiaPWD.Text), cr.Crypta(txtNuovaPWD.Text));
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Avviso", "alert('Nuova password salvata');", true);
        inserisci.Visible = false;
    }

    protected void RegistraOperazione(string strOperazione, string strProgramma)
    {
        Log_Operazioni l = new Log_Operazioni();
        l.Operazione = strOperazione;
        l.Programma = strProgramma;
        l.UserMail = Session["USR"].ToString();
        l.DataLog = DateTime.Now;
        l.LogOperazioni_Inserisci();
    }

}