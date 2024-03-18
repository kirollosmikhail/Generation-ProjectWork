using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class Default2 : System.Web.UI.Page
{
    //variabile per segnare il mese attualmente scritto nel calendario
    DateTime _data;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) { return; }
        _data = DateTime.Now;
        txtMese.Text = _data.ToString("yyyy-MM") ;
        CaricaGriglia();
    }
    // carica gli appuntamenti in base al dottore che si è loggato
    protected void CaricaGriglia()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.AddParametro("@idSanitario", int.Parse(Session["idSanitario"].ToString())); 
        if (txtMese.Text == "")
        {
            c.AddParametro("@DataPrestazione");
            c.Select("SANITARI_PrestazioniAperte");
            GrigliaCalendario.DataSource = c.dt;
            GrigliaCalendario.DataBind();
            return;
        }
        c.AddParametro("@DataPrestazione", DateTime.Parse(txtMese.Text));
        c.Select("SANITARI_PrestazioniAperte");
        GrigliaCalendario.DataSource = c.dt;
        GrigliaCalendario.DataBind();
        return;

    }



    protected void GrigliaPrestazioni_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GrigliaPrestazioni_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrigliaCalendario.PageIndex = e.NewPageIndex;
        CaricaGriglia();
    }



    protected void txtMese_TextChanged(object sender, EventArgs e)
    {
        CaricaGriglia();
    }



    //per andare avanti di un mese
    protected void Mesepiu_Click(object sender, EventArgs e)
    {
        _data = DateTime.Parse(txtMese.Text);   
            DateTime dataSuccessiva = _data.AddMonths(1);
            txtMese.Text = dataSuccessiva.ToString("yyyy-MM");

    }

    //per andare indietro di un mese
    protected void Mesemeno_Click(object sender, EventArgs e)
    {
                _data = DateTime.Parse(txtMese.Text);   
            DateTime dataSuccessiva = _data.AddMonths(-1);
            txtMese.Text = dataSuccessiva.ToString("yyyy-MM");

    }
}