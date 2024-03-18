using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) { return; }
        CaricaDdlPazienti();
        var querystring = Request.QueryString["c"];
        if (querystring != null)
            ddlPazienti.SelectedValue = Request.QueryString["c"].ToString();
        AggiornaDatiPaziente();
        CaricaGrigliaPazienti();
    }
    //caricamneto della ddl con un valore nullo alla posizione 0
    protected void CaricaDdlPazienti()
    {
        PAZIENTI p = new PAZIENTI();
        ddlPazienti.DataSource = p.Select();
        ddlPazienti.DataTextField = "NominativoPaziente";
        ddlPazienti.DataValueField = "idPaziente";
        ddlPazienti.DataBind();
        ddlPazienti.Items.Insert(0, new ListItem("--Seleziona Paziente--", "0"));

    }
    //carica la griglia in base al paziente selezionato nella ddl
    protected void CaricaGrigliaPazienti()
    {
        CONNESSIONE ca = new CONNESSIONE();
        ca.AddParametro("@idPaziente", ddlPazienti.SelectedValue);
        ca.Select("PAZIENTE_GridView_PrestazioniEseguite");
        grigliaCartelle.DataSource = ca.dt;
        grigliaCartelle.DataBind();
    }


    protected void ddlPazienti_SelectedIndexChanged(object sender, EventArgs e)
    {
        AggiornaDatiPaziente();

    }
    //carica la griglia e le txtbox ogni volta che viene selezionato un paziente diverso con i suoi dati
    protected void AggiornaDatiPaziente()
    {

        if (ddlPazienti.SelectedIndex == 0)
        {
            txtDataNascita.Text = "";
            txtGenere.Text = "";
            txtTelefono.Text = "";
            CaricaGrigliaPazienti();
            return;
        }

        PAZIENTI p = new PAZIENTI();
        p.idPaziente = int.Parse(ddlPazienti.SelectedValue.ToString());
        p.SelectId();

        txtDataNascita.Text = p.DataNascita?.ToString("yyyy-MM-dd");
        txtGenere.Text = p.Genere.ToString();
        txtTelefono.Text = p.Telefono.ToString();

        CaricaGrigliaPazienti();
    }


    //comando per aprire il pdf
    protected void grigliaCartelle_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            PdfPopup.Visible = true;
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            int val = (int)this.grigliaCartelle.DataKeys[rowIndex]["idPrestazione"];

            string primaryKeyValue = grigliaCartelle.DataKeys[rowIndex].Values["idPrestazione"].ToString();

            int primaryKey;
            int.TryParse(primaryKeyValue, out primaryKey);

            PRESTAZIONI p = new PRESTAZIONI();
            p.idPrestazione = primaryKey;
            DataTable dt = p.PrestazioniSelectPerId();

            byte[] ImgData = (byte[])dt.Rows[0]["docPrestazione"];
            string contentType = GetContentType(ImgData);
            lit.Text = "";
            

            if ("image/jpeg" == contentType)
            {
                popup.CssClass = "card text-center position-absolute start-50 top-50 translate-middle rounded";
                popupBody.CssClass = "card-body d-flex justify-content-center flex-wrap p-0 gap-4";
                lit.Text += "<div class='d-flex flex-column'>";
                lit.Text += "<div class='mb-5'>";
                lit.Text += "</div>";
                lit.Text += "<div>";
                lit.Text += "<a download='Radiografia' href='GestorePrestazioni.ashx?c=" + primaryKey + "' title='Radiografia'> <img alt='Radiografia' src='GestorePrestazioni.ashx?c=" + primaryKey + "' style='width: 30em;'> </a>";
                lit.Text += "</div>";
                lit.Text += "</div>";
            }

            object alo = dt.Rows[0]["docPrestazione"].ToString();
            if ("application/pdf" == contentType)
                if (dt.Rows[0]["docPrestazione"].ToString() != null && dt.Rows[0]["docPrestazione"].ToString() != "")
                {
                    popup.CssClass = "card text-center position-absolute start-50 top-50 translate-middle rounded Popup";
                    popupBody.CssClass = "card-body d-flex justify-content-center flex-wrap p-0 gap-4";
                    string embed = "<object data=\"{0}{1}\" type=\"application/pdf\" style=\"width:100%;height:auto;\">";

                    embed += "</object>";
                    lit.Text += string.Format(embed, ResolveUrl("GestorePrestazioni.ashx?c="), primaryKey.ToString());
                }
                else
                {
                    popup.CssClass = "card text-center position-absolute start-50 top-50 translate-middle rounded";
                    popupBody.CssClass = "card-body d-flex justify-content-center flex-wrap gap-4 p-5";
                    lit.Text = "Non è presente un PDF";
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


    protected void btnChiudiPdf_Click(object sender, EventArgs e)
    {
        PdfPopup.Visible = false;
        //Response.Redirect("CartellaPaziente.aspx");

    }

    protected void grigliaCartelle_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Button btnDownload = e.Row.FindControl("btnPdf") as Button;

            if (DataBinder.Eval(e.Row.DataItem, "docPrestazione") == DBNull.Value || (DataBinder.Eval(e.Row.DataItem, "docPrestazione") as byte[]).Length == 0)
            {
                if (btnDownload != null)
                {
                    btnDownload.Visible = false;
                }
            }
        }
    }
}









