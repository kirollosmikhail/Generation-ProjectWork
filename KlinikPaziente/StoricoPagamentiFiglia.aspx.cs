using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
        GrigliaStorici();
        Costi();
        //ListaTipi();

    }

    //Riempimento griglia
    protected void GrigliaStorici()
    {
        CONNESSIONE co = new CONNESSIONE();
        co.AddParametro("@idPaziente", int.Parse(Session["idPaziente"].ToString()));
        co.AddParametro("@Pagato", true);
        co.Select("PAZIENTE_GridView_PrenotazioniPagateSiNo");
        GrigliaStorico.DataSource = co.dt;
        GrigliaStorico.DataBind();
    }

    //modifica celle m/r/a con visite/radiografie/analisi
    protected void GrigliaStorico_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Cells[0].Text == "M")
        {
            e.Row.Cells[0].Text = "Visita";
        }
        if (e.Row.Cells[0].Text == "A")
        {
            e.Row.Cells[0].Text = "Analisi";
        }
        if (e.Row.Cells[0].Text == "R")
        {
            e.Row.Cells[0].Text = "Radiografia";
        }
    }


    //filtro sulla griglia
    protected void GrigliaStoriciFiltro()
    {
        CONNESSIONE co = new CONNESSIONE();

        if (ddlTipo.SelectedValue.ToString() != "")
        {
            co.AddParametro("@Tipo", ddlTipo.SelectedValue.ToString());
        }
        else
        {
            GrigliaStorici();
            return;
            //co.AddParametro("@Tipo");
        }

        co.AddParametro("@idPaziente", int.Parse(Session["idPaziente"].ToString()));
        co.AddParametro("@Pagato", true);
        co.Select("StoricoPagamenti_v_PRENOTAZIONI_SelectFiltri");
        GrigliaStorico.DataSource = co.dt;
        GrigliaStorico.DataBind();
    }

    //modifica della ddl
    protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        GrigliaStoriciFiltro();
    }

    //Metodi per pdf fattura
    protected void GrigliaStorico_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Pdf")
        {

            //rendo visibile il popup
            PdfPopup.Visible = true;
            popup.CssClass = "card text-center position-absolute start-50 top-50 translate-middle rounded Popup";
            //popupBody.CssClass = "card-body d-flex justify-content-center flex-wrap p-0 gap-4";

            int rowIndex = int.Parse(e.CommandArgument.ToString());
            int val = (int)this.GrigliaStorico.DataKeys[rowIndex]["idPrenotazione"];

            PRENOTAZIONI p = new PRENOTAZIONI();
            p.idPrenotazione = val;
            p.SelectId();
            byte[] Doc = p.docFattura;

            lit.Text = "";
            if (Doc != null && Doc.Length > 0)
            {
                string embed = "<object data=\"{0}{1}\" type=\"application/pdf\" style=\"width:100%;height:auto;\">";
                //            embed += "If you are unable to view file, you can download from <a href = \"{0}{1}&download=1\">here</a>";
                //            embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
                embed += "</object>";
                lit.Text += string.Format(embed, ResolveUrl("GestorePrenotazioni.ashx?c="), val);
            }
            else
            {
                popup.CssClass = "card text-center position-absolute start-50 top-50 translate-middle rounded";
                //popupBody.CssClass = "card-body d-flex justify-content-center flex-wrap gap-4 p-5";
                lit.Text += "Non sono presenti file aggiuntivi";
            }


        }
    }
    protected void btnChiudiPdf_Click(object sender, EventArgs e)
    {
        PdfPopup.Visible = false;
    }


    protected void GrigliaStorico_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrigliaStorico.PageIndex = e.NewPageIndex;
        GrigliaStorici();
    }

    protected void Costi()
    {
        CONNESSIONE co = new CONNESSIONE();
        co.AddParametro("@idPaziente", int.Parse(Session["idPaziente"].ToString()));
        int id = int.Parse(Session["idPaziente"].ToString());
        co.AddParametro("@Pagato", true);
        co.Select("PAZIENTI_SommaCosti");
        string ricavi = "";
        if (co.dt.Rows.Count > 0)
        {
            ricavi = decimal.Parse(co.dt.Rows[0]["Costi"].ToString()).ToString("C2", CultureInfo.GetCultureInfo("it-IT"));

        }
        else
        {
            ricavi = "0";
        }
        txtCosti.Text = ricavi;
    }

    //secondo me da eliminare

    //string ricavi = decimal.Parse(co.dt.Rows[0]["TotaleRicavo"].ToString()).ToString("C2", CultureInfo.GetCultureInfo("it-IT"));

    //correggere se necessario il nome del campo della tabella in RicavoSanitario
    //TxtRicavi.Text = ricavi;

    protected void ListaTipi()
    {
        CONNESSIONE co = new CONNESSIONE();
        co.Select("TARIFFARIO_Select");
        ddlTipo.DataSource = co.dt;
        ddlTipo.DataTextField = "Tipo";
        ddlTipo.DataValueField = "idTariffario";
        ddlTipo.DataBind();
        ddlTipo.Items.Insert(0, new ListItem() { Text = "Seleziona Tipo", Value = "" });
    }
    protected void txtPagamento_TextChanged(object sender, EventArgs e)
    {
        GrigliaStoriciFiltro();
    }

    //protected void btnAnnullaIns_Click(object sender, EventArgs e)
    //{
    //    scarica.Visible = false;
    //}
}