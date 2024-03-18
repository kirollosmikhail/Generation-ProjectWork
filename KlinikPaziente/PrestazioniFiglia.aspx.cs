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

        //per mostrare la griglia anche se non ho dati, nella gridview ho messo anche ShowHeaderWhenEmpty="True"
        //GrigliaPrestazioni.DataSource = new DataTable(); GrigliaPrestazioni.DataBind();
    }

    //----------------------------------------------------------------------------------------------------------------
    // procedure per caricare la griglia senza filtri
    //----------------------------------------------------------------------------------------------------------------
    protected void CaricaGriglia()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.AddParametro("@idPaziente", int.Parse(Session["idPaziente"].ToString()));
        c.Select("PAZIENTE_GridView_PrestazioniEseguite");
        GrigliaPrestazioni.DataSource = c.dt;
        GrigliaPrestazioni.PageSize = 10; //quanti record per pagina
        //trovare modo per fare controllo se 
        GrigliaPrestazioni.DataBind();
    }

    //----------------------------------------------------------------------------------------------------------------
    // procedure per caricare la griglia con il filtro della tipologia di visita
    //----------------------------------------------------------------------------------------------------------------
    protected void CaricaGrigliaFiltro()
    {
        CONNESSIONE c = new CONNESSIONE();
        //c.AddParametro("@Tipologia", Sanitario.Tipologia);
        c.AddParametro("@idPaziente", int.Parse(Session["idPaziente"].ToString()));
        if (ddlTipologia.SelectedValue != "0")
        {
            c.AddParametro("@TipologiaSanitario", ddlTipologia.SelectedValue.ToString());
        }
        else
        {
            c.AddParametro("@TipologiaSanitario");
        }
        c.Select("PAZIENTE_GridView_PrestazioniEseguiteFiltri");
        GrigliaPrestazioni.DataSource = c.dt;
        GrigliaPrestazioni.PageSize = 10; //quanti record per pagina
        GrigliaPrestazioni.DataBind();
    }

    //----------------------------------------------------------------------------------------------------------------
    // procedure per cambiare la pagina della gridview quando ci sono molte righe
    //----------------------------------------------------------------------------------------------------------------
    protected void GrigliaPrestazioni_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrigliaPrestazioni.PageIndex = e.NewPageIndex;
        if (int.Parse(ddlTipologia.SelectedIndex.ToString()) == 0)
            CaricaGriglia();
        else
            CaricaGrigliaFiltro();
    }

    //----------------------------------------------------------------------------------------------------------------
    // Quando cambio la selezione della drop down list filtra i risultati della gridview secondo la tipologia di visita
    //----------------------------------------------------------------------------------------------------------------
    protected void ddlTipologia_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (int.Parse(ddlTipologia.SelectedIndex.ToString()) == 0)
            CaricaGriglia();
        else
            CaricaGrigliaFiltro();
    }

    //----------------------------------------------------------------------------------------------------------------
    // Procedure per aprire i popup, se si preme su Pdf apre il pdf della prestazione selezionata, se si preme informazioni apre il popup con le info complete
    //----------------------------------------------------------------------------------------------------------------
    protected void GrigliaPrestazioni_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //prendo l'idPrestazione
        int rowIndex = int.Parse(e.CommandArgument.ToString());
        int val = (int)this.GrigliaPrestazioni.DataKeys[rowIndex]["idPrestazione"];

        //faccio un select di tutta una riga da PRESTAZIONI passando l'idPrestazione
        PRESTAZIONI p = new PRESTAZIONI();
        p.idPrestazione = val;
        p.SelectId();
        byte[] Doc = p.docPrestazione;
        string Tipo = GetContentType(Doc);

        lit.Text = "";
        if (e.CommandName == "Pdf")
        {
            //rendo visibile il popup
            PdfPopup.Visible = true;

            //a secondo del tipo di file cambia il Css del popup e come apre il documento
            if (Tipo == "application/pdf")
            {
                popup.CssClass = "card text-center position-absolute start-50 top-50 translate-middle rounded Popup";
                popupBody.CssClass = "card-body d-flex justify-content-center flex-wrap p-0 gap-4";
                string embed = "<object data='{0}{1}' type='application/pdf' style='width: 100%; height: auto;'>";
                //embed += "If you are unable to view file, you can download from <a href = \"{0}{1}&download=1\">here</a>";
                //embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
                embed += "</object>";
                lit.Text += string.Format(embed, ResolveUrl("Gestore.ashx?c="), val);
            }
            else
            {
                lit.Text += "<div class='d-flex flex-column'>";
                lit.Text += "<div class='mb-5'>";
                lit.Text += "<p>Clicca l'immagine per scaricarla</p>";
                lit.Text += "</div>";
                lit.Text += "<div class='p-2'>";
                lit.Text += "<a download='Radiografia' href='Gestore.ashx?c=" + val + "' title='Radiografia'> <img alt='Radiografia' src='Gestore.ashx?c=" + val + "' style='width: 30em;'> </a>";
                lit.Text += "</div>";
                lit.Text += "</div>";
            }
        }

        if (e.CommandName == "Mostra")
        {
            InformazioniPopup.Visible = true;
            txtReferto.Text = p.Referto.ToString();
        }
    }

    //----------------------------------------------------------------------------------------------------------------
    // Procedure per chiudere il popup con il pdf
    //----------------------------------------------------------------------------------------------------------------
    protected void btnChiudiPdf_Click(object sender, EventArgs e)
    {
        popup.CssClass = "card text-center position-absolute start-50 top-50 translate-middle rounded";
        popupBody.CssClass = "card-body d-flex justify-content-center flex-wrap gap-4 p-5";
        PdfPopup.Visible = false;
    }

    //----------------------------------------------------------------------------------------------------------------
    // Procedure per chiudere il popup con le infomrazioni migliorate
    //----------------------------------------------------------------------------------------------------------------
    protected void ChiudiInfo_Click(object sender, EventArgs e)
    {
        InformazioniPopup.Visible = false;
    }

    protected void GrigliaPrestazioni_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[2].Text == "M")
            {
                e.Row.Cells[2].Text = "Visita";
            }
            if (e.Row.Cells[2].Text == "R")
            {
                e.Row.Cells[2].Text = "Radiografia";
            }
            if (e.Row.Cells[2].Text == "A")
            {
                e.Row.Cells[2].Text = "Analisi";
            }
        }
        //try
        //{
        //    //if (e.Row.Cells[5].Text.Length > 5)
        //    //{
        //    //    e.Row.Cells[5].Text = e.Row.Cells[5].Text.Substring(0, 40) + "...";
        //    //}
        //    if (e.Row.Cells[6].Text.Length > 5)
        //    {
        //        e.Row.Cells[6].Text = e.Row.Cells[6].Text.Substring(0, 40) + "...";
        //    }
        //}
        //catch
        //{
        //    Response.Write("");
        //}

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            object objTemp = GrigliaPrestazioni.DataKeys[e.Row.RowIndex].Value as object;
            if (objTemp != null)
            {
                int val = int.Parse(objTemp.ToString());

                PRESTAZIONI p = new PRESTAZIONI();
                p.idPrestazione = val;
                p.SelectId();
                byte[] Doc = p.docPrestazione;

                Button btnPdf = e.Row.FindControl("btnPdf") as Button;

                if (Doc == null || Doc.Length == 0)
                {
                    btnPdf.Visible = false;
                }
            }
        }
    }

    private string GetContentType(byte[] fileData)
    {
        if (fileData.Length > 4 && fileData[0] == 0x25 && fileData[1] == 0x50 && fileData[2] == 0x44 && fileData[3] == 0x46)
        {
            return "application/pdf";
        }
        else
        {
            return "image/jpeg";
        }
    }
}