using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Operazioni : System.Web.UI.Page
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

        Log_Operazioni l = new Log_Operazioni();
        l.EliminaTutto();
        CaricaGriglia();
        popElimina.Visible = false;
    }

    protected void CaricaGriglia()
    {
        string Operazione;
        string Usermail;
        string Programma;
        DateTime DataLog;
        CONNESSIONE co = new CONNESSIONE();
        if (txtOperazione.Text.Trim() == "") Operazione = null;
        else Operazione = txtOperazione.Text.Trim();
        co.cmd.Parameters.AddWithValue("@Operazione", Operazione != null ? Operazione : (object)DBNull.Value);
        if (txtProgramma.Text.Trim() == "") Programma = null;
        else Programma = txtProgramma.Text.Trim();
        co.cmd.Parameters.AddWithValue("@Programma", Programma != null ? Programma : (object)DBNull.Value);
        if (txtEmail.Text.Trim() == "") Usermail = null;
        else Usermail = txtEmail.Text.Trim();
        co.cmd.Parameters.AddWithValue("@Usermail", Usermail != null ? Usermail : (object)DBNull.Value);
        if (DateTime.TryParse(txtData.Text + ":00:00", out DataLog))
        {
            co.cmd.Parameters.AddWithValue("@DataLog", DataLog != null ? DataLog : (object)DBNull.Value);
        }
        else { co.cmd.Parameters.AddWithValue("@DataLog", (object)DBNull.Value); }

        co.Select("Log_Operazioni_SelectFiltri");
        grigliaOperazioni.DataSource = co.dt;
        grigliaOperazioni.DataBind();
    }

    //protected void RegistraOperazione(string strOperazione, string strProgramma)
    //{
    //    Log_Operazioni l = new Log_Operazioni();
    //    l.Operazione = strOperazione;
    //    l.Programma = strProgramma;
    //    l.UserMail = Session["USR"].ToString();
    //    l.DataLog = DateTime.Now;
    //    l.Inserisci();
    //}

    protected void grigliaAccessi_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grigliaOperazioni.PageIndex = e.NewPageIndex;
        CaricaGriglia();
    }
}
