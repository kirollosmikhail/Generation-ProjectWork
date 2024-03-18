using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Accessi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CaricaGriglia();
    }

    protected void btnElimina_Click(object sender, EventArgs e)
    {
        if (popElimina.Visible == false)
        { popElimina.Visible = true; }
    }

    protected void btnAnnulla_Click(object sender, EventArgs e)
    {

        popElimina.Visible = false;
    }

    protected void btnConferma_Click(object sender, EventArgs e)
    {
        Log_Accessi l = new Log_Accessi();
        l.EliminaTutto();
        CaricaGriglia();
        popElimina.Visible = false;
    }

    //protected void CaricaGriglia()
    //{
    //    Log_Accessi l = new Log_Accessi();
    //    if (txtData.Text != "") l.DataLog = DateTime.Parse(txtData.Text.ToString());
    //    if (txtEmail.Text != "") l.Utente = txtEmail.Text.ToString();
    //    if (txtIP.Text != "") l.IndirizzoIP = txtIP.Text.ToString();
    //    if (ddlEsito.DataTextField == "Positivo") l.Esito = true;
    //    else if (ddlEsito.DataTextField == "Negativo") { l.Esito = false; }
    //    grigliaAccessi.DataSource = l.Select();
    //    grigliaAccessi.DataBind();
    //}

    protected void CaricaGriglia()
    {
        bool? Esito;
        string Utente;
        string IP;
        DateTime DataLog;
        CONNESSIONE co = new CONNESSIONE();
        if (ddlEsito.SelectedValue == "null")
        {
            Esito = null;
        }
        else
        {
            Esito = bool.Parse(ddlEsito.SelectedValue.ToString());
        }
        co.cmd.Parameters.AddWithValue("@Esito", Esito != null ? Esito : (object)DBNull.Value);
        if (txtIP.Text.Trim() == "") IP = null;
        else IP = txtIP.Text.Trim();
        co.cmd.Parameters.AddWithValue("@IndirizzoIP", IP != null ? IP : (object)DBNull.Value);
        if (txtEmail.Text.Trim() == "") Utente = null;
        else Utente = txtEmail.Text.Trim();
        co.cmd.Parameters.AddWithValue("@Utente", Utente != null ? Utente : (object)DBNull.Value);
        if (DateTime.TryParse(txtData.Text+":00:00", out DataLog))
        {
            co.cmd.Parameters.AddWithValue("@DataLog", DataLog != null ? DataLog : (object)DBNull.Value);
        }
        else { co.cmd.Parameters.AddWithValue("@DataLog", (object)DBNull.Value); }

        co.Select("Log_Accessi_SelectFiltri");
        grigliaAccessi.DataSource = co.dt;
        grigliaAccessi.DataBind();
    }

    protected void grigliaAccessi_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grigliaAccessi.PageIndex = e.NewPageIndex;
        CaricaGriglia();
    }

    protected void grigliaAccessi_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[3].Text == "True")
            {               
                e.Row.Cells[3].Text = "✅";
            }               
            if (e.Row.Cells[3].Text == "False")
            {               
                e.Row.Cells[3].Text = "❌";
            }
        }
    }

}