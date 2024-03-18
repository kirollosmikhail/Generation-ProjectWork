using System;
using System.Collections.Generic;
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
        CONNESSIONE c = new CONNESSIONE();
        if (txtRicercaCodFiscale.Text == "")
        {
            c.AddParametro("@CodFiscale");
        }
        else
        {
            c.AddParametro("@CodFiscale", txtRicercaCodFiscale.Text.ToString());
        }
        if (ddlPagato.SelectedValue == "")
        {
            c.AddParametro("@Pagato");
        }
        else
        {
            c.AddParametro("@Pagato", bool.Parse(ddlPagato.SelectedValue.ToString()));
        }
        c.Select("StatoPagamenti_Filtri");
        grigliaPagamenti.DataSource = c.dt;
        grigliaPagamenti.AllowPaging = true;
        grigliaPagamenti.PageSize = 10;
        grigliaPagamenti.DataBind();
    }

    //PAGING DELLA TABELLA
    protected void grigliaPagamenti_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grigliaPagamenti.PageIndex = e.NewPageIndex;
        CaricaGriglia(); // Rileggi i dati per la nuova pagina
    }

    protected void Filtro(object sender, EventArgs e)
    {
        CaricaGriglia();
    }

    //SOSTITUISCE LA LETTERA SINGOLA CON LA SCRITTA INTERA
    protected void grigliaPagamenti_RowDataBound(object sender, GridViewRowEventArgs e)
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

            if (DataBinder.Eval(e.Row.DataItem, "Prezzo") != DBNull.Value)
            {
                decimal prezzo = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Prezzo"));
                e.Row.Cells[5].Text = prezzo.ToString() + "€";
            }

            if (e.Row.Cells[7].Text == "True")
            {               
                e.Row.Cells[7].Text = "✅";
            }               
            if (e.Row.Cells[7].Text == "False")
            {               
                e.Row.Cells[7].Text = "❌";
            }
        }
    }
}