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
            ddlSediCitta();
            RiempiTxt();
        }
        RiempiLiteral();
    }

    //CARICO LA GRIGLIA DI VISUALIZZAZIONE
    protected void CaricaGriglia()
    {
        CONNESSIONE c = new CONNESSIONE();
        if (ddlTipologia.SelectedValue == "")
        {
            c.AddParametro("@Tipo");
        }
        else
        {
            c.AddParametro("@Tipo", ddlTipologia.SelectedValue.ToString());
        }
        if (ddlSede.SelectedValue == "" || ddlSede.SelectedValue == "NA")
        {
            c.AddParametro("@idSede");
        }
        else
        {
            c.AddParametro("@idSede", ddlSede.SelectedValue.ToString());
        }
        if (ddlPagato.SelectedValue == "")
        {
            c.AddParametro("@Pagato");
        }
        else
        {
            c.AddParametro("@Pagato", bool.Parse(ddlPagato.SelectedValue.ToString()));
        }
        c.Select("Rendicontazione_Filtri");
        grigliaRendicontazione.DataSource = c.dt;
        grigliaRendicontazione.AllowPaging = true;
        grigliaRendicontazione.PageSize = 10;
        grigliaRendicontazione.DataBind();
    }

    //PAGING DELLA TABELLA
    protected void grigliaRendicontazione_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grigliaRendicontazione.PageIndex = e.NewPageIndex;
        CaricaGriglia(); // Rileggi i dati per la nuova pagina
    }

    //RIEMPIE LA DDL CON I NOMI DELLE CITTA' DELLE SEDI
    protected void ddlSediCitta()
    {
        SEDI s = new SEDI();
        ddlSede.DataSource = s.Select(); ;
        ddlSede.DataTextField = "Citta"; ;
        ddlSede.DataValueField = "idSede";
        ddlSede.DataBind();
        ddlSede.Items.Insert(0, new ListItem() { Text = "--Seleziona Città--", Value = "NA" });
        ddlSede.SelectedIndex = 0;
    }

    protected void Filtro(object sender, EventArgs e)
    {
        CaricaGriglia();
    }

    protected void RiempiTxt()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.Select("Rendicontazione_Pagato");
        decimal p = decimal.Parse(c.dt.Rows[0]["Ricavo"].ToString());
        lblPagato.Text = p.ToString() + "€";
        CONNESSIONE c1 = new CONNESSIONE();
        c1.Select("Rendicontazione_NonPagato");
        decimal np = decimal.Parse(c1.dt.Rows[0]["Ricavo"].ToString());
        lblNonPagato.Text = np.ToString() + "€";
    }

    //SOSTITUISCE LA LETTERA SINGOLA CON LA SCRITTA INTERA
    protected void grigliaRendicontazione_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[3].Text == "M")
            {
                e.Row.Cells[3].Text = "Visita Medica";
            }
            if (e.Row.Cells[3].Text == "A")
            {
                e.Row.Cells[3].Text = "Analisi";
            }
            if (e.Row.Cells[3].Text == "R")
            {
                e.Row.Cells[3].Text = "Radiografia";
            }

            if (DataBinder.Eval(e.Row.DataItem, "Ricavo") != DBNull.Value)
            {
                decimal nDec = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Ricavo"));
                e.Row.Cells[6].Text = nDec.ToString("p0");
            }

            if (DataBinder.Eval(e.Row.DataItem, "Prezzo") != DBNull.Value)
            {
                decimal prezzo = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Prezzo"));
                e.Row.Cells[7].Text = prezzo.ToString() + "€";
            }

            if (e.Row.Cells[8].Text == "True")
            {
                e.Row.Cells[8].Text = "✅";
            }
            if (e.Row.Cells[8].Text == "False")
            {
                e.Row.Cells[8].Text = "❌";
            }
        }
    }



    protected void btnGrafici_Click(object sender, EventArgs e)
    {
        apri.Visible = true;
    }

    protected void RiempiLiteral()
    {
        CONNESSIONE c = new CONNESSIONE();
        Literal1.Text = "";
        c.Select("RicaviVisiteMedico");
        foreach (DataRow row in c.dt.Rows)
        {
            Literal1.Text += "<div>" +
                    "<div>" +
                        "<label>" +
                            row["NominativoSanitario"].ToString() + ": " +
                        "</label>" +
                        "<label>" +
                            row["RicavoMedico"].ToString() + "€" +
                        "</label>" +
                    "</div>" +
                 "</div>";
        }
    }

    protected void btnChiudi_Click(object sender, EventArgs e)
    {
        apri.Visible = false;
    }
}