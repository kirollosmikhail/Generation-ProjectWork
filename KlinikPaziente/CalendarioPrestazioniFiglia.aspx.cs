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
        if (IsPostBack)
        {
            return;
        }
        CaricaCalendario();
        //GrigliaCalendario.DataSource = new DataTable();
        //GrigliaCalendario.DataBind();
    }

    //----------------------------------------------------------------------------------------------------------------
    // procedure per caricare il calendario
    //----------------------------------------------------------------------------------------------------------------
    protected void CaricaCalendario()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.AddParametro("@idPaziente", int.Parse(Session["idPaziente"].ToString()));
        c.AddParametro("@Pagato", true);
        c.Select("PAZIENTE_GridView_PrenotazioniPagateSiNo");
        GrigliaCalendario.DataSource = c.dt;
        GrigliaCalendario.AllowPaging = true;
        GrigliaCalendario.PageSize = 10;
        GrigliaCalendario.DataBind();
    }

    protected void GrigliaCalendario_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[4].Text == "M")
            {
                e.Row.Cells[4].Text = "Visita";
            }
            if (e.Row.Cells[4].Text == "R")
            {
                e.Row.Cells[4].Text = "Radiografie";
            }
            if (e.Row.Cells[4].Text == "A")
            {
                e.Row.Cells[4].Text = "Analisi";
            }

            if (DateTime.Parse(e.Row.Cells[5].Text) >= DateTime.Now)
            {
                e.Row.Cells[6].Text = "✅";
            }
            else
            {
                e.Row.Cells[6].Text = "❌";
            }
        }
    }

    //----------------------------------------------------------------------------------------------------------------
    // procedure per caricare il calendario usando la tipologia del sanitario come filtro
    //----------------------------------------------------------------------------------------------------------------
    protected void CaricaCalendarioFiltro()
    {
        CONNESSIONE c = new CONNESSIONE();
        if (ddlTipologia.SelectedValue != "0")
        {
            c.AddParametro("@TipologiaSanitario", ddlTipologia.SelectedValue.ToString());
        }
        else
        {
            c.AddParametro("@TipologiaSanitario");
        }
        c.AddParametro("@idPaziente", int.Parse(Session["idPaziente"].ToString()));
        c.AddParametro("@Pagato", true);
        c.Select("PAZIENTE_GridView_PrenotazioniPagateSiNoFiltri");
        GrigliaCalendario.DataSource = c.dt;
        GrigliaCalendario.DataBind();
    }

    //----------------------------------------------------------------------------------------------------------------
    // azione compiuta al cambio della selezione della ddl
    //----------------------------------------------------------------------------------------------------------------
    protected void ddlTipologia_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (int.Parse(ddlTipologia.SelectedIndex.ToString()) == 0)
        {
            CaricaCalendario();
        }
        else
        {
            CaricaCalendarioFiltro();
        }
    }
    //----------------------------------------------------------------------------------------------------------------
    // quanod seleziono una riga apro il popup con i dati
    //----------------------------------------------------------------------------------------------------------------
    protected void GrigliaCalendario_SelectedIndexChanged(object sender, EventArgs e)
    {
        inserisci.Visible = true;
        PRESTAZIONI pr = new PRESTAZIONI();
        pr.idPrestazione = int.Parse(GrigliaCalendario.SelectedValue.ToString());
        pr.SelectId();
        txtDataPrestazione.Text = pr.DataPrestazione.ToString();
        SANITARI sa = new SANITARI();
        sa.idSanitario = pr.idSanitario;
        sa.SelectId();
        txtSanitario.Text = sa.Titolo.ToString() + " " + sa.Cognome.ToString() + " " + sa.Nome.ToString();
        //int ParamFoto = int.Parse(sa.idSanitario.ToString());
        CaricaFoto(int.Parse(sa.idSanitario.ToString()));
        SEDI se = new SEDI();
        se.idSede = sa.idSede;
        se.SelectId();
        txtSede.Text = se.Indirizzo.ToString() + ", " + se.Citta.ToString() + " (" + se.Provincia.ToString() + ")";
    }

    /// <summary>
    /// Fall output della foto del sanitario della prestazione selezionata
    /// </summary>
    /// <param name="idSanitario">Puntatore al sanitario</param>
    protected void CaricaFoto(int idSanitario)
    {
        int val = idSanitario;
        string primaryKeyValue = idSanitario.ToString();

        int primaryKey;
        int.TryParse(primaryKeyValue, out primaryKey);

        SANITARI s = new SANITARI();
        s.idSanitario = primaryKey;
        s.SelectId();

        object alo = s.Foto;
        try
        {
            if (s.Foto != null && s.Foto.ToString() != "")
            {
                string embed = "<object data=\"{0}{1}\" type=\"image/jpeg\" style=\"width:100%;height:auto;\">";
                embed += "</object>";
                litImg.Text += string.Format(embed, ResolveUrl("GestoreImg.ashx?c="), primaryKey.ToString());
            }
        }
        catch
        {
            litImg.Text = "";
        }
    }

    //----------------------------------------------------------------------------------------------------------------
    // procedure per chiudere il popup
    //----------------------------------------------------------------------------------------------------------------
    protected void btnChiudi_Click(object sender, EventArgs e)
    {
        inserisci.Visible = false;
        litImg.Text = "";
    }

    protected void GrigliaCalendario_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrigliaCalendario.PageIndex = e.NewPageIndex;
        CaricaCalendario();
    }
}