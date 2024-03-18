using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class Default2 : System.Web.UI.Page
{
    static int id;
    static int IdPaziente;
    DateTime _data;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _data = DateTime.Now;

            lblVuota.Visible = false;
            lblVuota2.Visible = false;
            if (Session["DataSelezionata"] != null)
            {
                // Se ho salvato una data nella session, seleziona quella
                txtCalendario.Text = Session["DataSelezionata"].ToString();
            }
            else
            {
                // altrimenti imposta la data odierna 
                txtCalendario.Text = _data.ToString("yyyy-MM");
            }
            CaricaGrigliaPrestazioniAperte();
            CaricaGrigliaPrestazioniChiuse();
            riempiCheckList();
        }
    }

    protected void CaricaGrigliaPrestazioniAperte()
    {
        PRESTAZIONI p = new PRESTAZIONI();
        p.idSanitario = int.Parse(Session["idSanitario"].ToString());
        if (txtCalendario.Text.Length > 0)
        {
            p.DataPrestazione = DateTime.Parse(txtCalendario.Text);
        }
        else
        {
            p.DataPrestazione = DateTime.Now;
        }
        DataTable dt = p.PrestazioniSelectAperte();
        if (dt.Rows.Count == 0) // per controllare se c'é appuntamento o no
        {
            lblVuota.Visible = true;
            lblVuota.Text = "Nessuna prestazione aperta nella data selezionata";
        }
        else
        {
            lblVuota.Visible = false;
            Session["Tipologia"].ToString();
        }
        gridPrestazioniAperte.DataSource = dt;
        gridPrestazioniAperte.DataBind();
    }

    protected void CaricaGrigliaPrestazioniChiuse()
    {
        PRESTAZIONI p = new PRESTAZIONI();
        p.idSanitario = int.Parse(Session["idSanitario"].ToString());
        if (txtCalendario.Text.Length > 0)
        {
            p.DataChiusura = DateTime.Parse(txtCalendario.Text);
        }
        else
        {
            p.DataChiusura = DateTime.Now;
        }
        DataTable dt = p.PrestazioniSelectChiuse();
        if (dt.Rows.Count == 0) // per controllare se c'é appuntamento o no
        {
            lblVuota2.Visible = true;
            lblVuota2.Text = "Nessuna prestazione aperta nella data selezionata";
        }
        else
        {
            lblVuota2.Visible = false;
            Session["Tipologia"].ToString();
        }
        gridPrestazioniChiuse.DataSource = p.PrestazioniSelectChiuse();
        gridPrestazioniChiuse.DataBind();
    }

    protected void gridPrestazioniAperte_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["Codice"] = gridPrestazioniAperte.SelectedValue.ToString();
        id = int.Parse(gridPrestazioniAperte.SelectedValue.ToString());
        modificaPopup();
        PRESTAZIONI p = new PRESTAZIONI();
        p.idPrestazione = int.Parse(gridPrestazioniAperte.SelectedValue.ToString());
        DataTable dt = p.PrestazioniSelectPerId();
        if (dt.Rows[0]["Nome"].ToString() != "")
            txtNome.Text = txtNome2.Text = dt.Rows[0]["Nome"].ToString();
        if (dt.Rows[0]["Cognome"].ToString() != "")
            txtCognome.Text = txtCognome2.Text = dt.Rows[0]["Cognome"].ToString();
        if (dt.Rows[0]["CodFiscale"].ToString() != "")
            txtCodFiscale.Text = txtCodFiscale2.Text = dt.Rows[0]["CodFiscale"].ToString();
        if (dt.Rows[0]["DataNascita"].ToString() != "" && dt.Rows[0]["DataNascita"].ToString() != null)
            txtDataNascita.Text = txtDataNascita2.Text = DateTime.Parse(dt.Rows[0]["DataNascita"].ToString()).ToString("dd/MM/yyyy");
        txtReferto.Text = txtReferto2.Text = dt.Rows[0]["Referto"].ToString();
        txtAnamnesi.Text = txtAnamnesi2.Text = dt.Rows[0]["Anamnesi"].ToString();
    }

    protected void txtCalendario_TextChanged(object sender, EventArgs e)
    {
        Session["DataSelezionata"] = txtCalendario.Text; // salvo la data selezionata sul calendario sulla session
        CaricaGrigliaPrestazioniAperte();
        CaricaGrigliaPrestazioniChiuse();
    }



    protected void modificaPopup()
    {
        if (Session["Tipologia"].ToString() == "M")
        {
            if (inserisci.Visible == false)
            { inserisci.Visible = true; }
        }
        else
        {
            if (inserisci2.Visible == false)
            { inserisci2.Visible = true; }
        }
    }

    protected void btnAnnullaIns_Click(object sender, EventArgs e)
    {
        inserisci.Visible = false;
        divPaziente.Visible = false;
        divDdl.Visible = false;
        btnRichiedi.Text = "Richiedi controlli";
    }

    protected void btnConfermaIns_Click(object sender, EventArgs e)
    {
        inserisci.Visible = false;
        PRESTAZIONI p = new PRESTAZIONI();
        p.idPrestazione = int.Parse(gridPrestazioniAperte.SelectedValue.ToString());
        DataTable dt = p.PrestazioniSelectPerId();

        p.idSanitario = int.Parse(Session["idSanitario"].ToString());

        p.Anamnesi = txtAnamnesi.Text;
        p.Referto = txtReferto.Text;
        if (uplDocumento.HasFile)
        {
            p.DataChiusura = DateTime.Now;
            p.docPrestazione = uplDocumento.FileBytes;
        }

        p.PrestazioniModifica();
        RegistraOperazione("PrestazioniModifica", "HomeMedici");

        InserisciPrenotazioniPerCheckBoxItem();

        Response.Redirect("HomeMedici.aspx");

    }

    protected void btnAnnullaIns2_Click(object sender, EventArgs e)
    {
        inserisci2.Visible = false;
    }

    protected void btnConfermaIns2_Click(object sender, EventArgs e)
    {
        inserisci2.Visible = false;
        PRESTAZIONI p = new PRESTAZIONI();
        p.idPrestazione = int.Parse(gridPrestazioniAperte.SelectedValue.ToString());
        DataTable dt = p.PrestazioniSelectPerId();
        p.idSanitario = int.Parse(Session["idSanitario"].ToString());


        p.Anamnesi = txtAnamnesi2.Text.Trim();
        p.Referto = txtReferto2.Text;
        if (uplDocumento2.HasFile)
        {
            p.DataChiusura = DateTime.Now;
            p.docPrestazione = uplDocumento2.FileBytes;
        }
        p.PrestazioniModifica();
        RegistraOperazione("PrestazioniModifica", "HomeMedici");
        Response.Redirect("HomeMedici.aspx");
    }

    protected void btnRichiedi_Click(object sender, EventArgs e)
    {
        PRESTAZIONI p = new PRESTAZIONI();
        p.idPrestazione = id;
        DataTable dt = p.PrestazioniSelectPerId();
        txtNome.Text = dt.Rows[0]["Nome"].ToString();
        txtCognome.Text = dt.Rows[0]["Cognome"].ToString();
        txtCodFiscale.Text = dt.Rows[0]["CodFiscale"].ToString();
        txtDataNascita.Text = DateTime.Parse(dt.Rows[0]["DataNascita"].ToString()).ToString("dd/MM/yyyy");
        IdPaziente = int.Parse(dt.Rows[0]["idPaziente"].ToString());

        if (divPaziente.Visible == true)
        {
            divPaziente.Visible = false;
            btnRichiedi.Text = "Richiedi controlli";
        }
        else
        {
            divPaziente.Visible = true;
            btnRichiedi.Text = "Annulla richiesta";
        }

        if (divDdl.Visible == true)
            divDdl.Visible = false;
        else
            divDdl.Visible = true;
    }
    protected void griglia_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            Div1.Visible = true;
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            int val = (int)this.gridPrestazioniAperte.DataKeys[rowIndex]["idPrestazione"];

            string primaryKeyValue = gridPrestazioniAperte.DataKeys[rowIndex].Values["idPrestazione"].ToString();

            int primaryKey;
            int.TryParse(primaryKeyValue, out primaryKey);

            PRESTAZIONI p = new PRESTAZIONI();
            p.idPrestazione = primaryKey;
            DataTable dt = p.PrestazioniSelectPerId();
            byte[] ImgData = (byte[])dt.Rows[0]["docPrestazione"];
            string contentType = GetContentType(ImgData);


            if ("image/jpeg" == contentType)
            {
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
                    popup1.CssClass = "card text-center position-absolute start-50 top-50 translate-middle rounded Popup";
                    popupBody1.CssClass = "card-body d-flex justify-content-center flex-wrap p-0 gap-4";
                    string embed = "<object data=\"{0}{1}\" type=\"application/pdf\" style=\"width:100%;height:auto;\">";

                    embed += "</object>";
                    lit.Text += string.Format(embed, ResolveUrl("GestorePrestazioni.ashx?c="), primaryKey.ToString());
                }
                else
                {
                    popup1.CssClass = "card text-center position-absolute start-50 top-50 translate-middle rounded";
                    popupBody1.CssClass = "card-body d-flex justify-content-center flex-wrap gap-4 p-5";
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        Div1.Visible = false;
        Response.Redirect("HomeMedici.aspx");
    }
    protected void riempiCheckList()
    {
        // RIEMPIAMO LA CHECKLIST DEL NUOVO POPUP DI RICHIESTA ANALISI/RADIOGRAFIE
        TARIFFARIO t = new TARIFFARIO();
        CheckBoxList1.DataSource = t.Select();
        CheckBoxList1.DataValueField = "idTariffario";
        CheckBoxList1.DataTextField = "Prestazione";
        CheckBoxList1.DataBind();
    }
    public void InserisciPrenotazioniPerCheckBoxItem()
    {

        // per ogni item selezionato sulla checkbox, inserisce una prenotazione di analisi/radiografia per quel paziente
        TARIFFARIO t = new TARIFFARIO();
        PRENOTAZIONI p = new PRENOTAZIONI();
        SANITARI s = new SANITARI();
        foreach (ListItem item in CheckBoxList1.Items)
        {
            if (item.Selected)
            {
                p.idPaziente = IdPaziente;
                p.idTariffario = int.Parse(item.Value.ToString());
                p.idSanitario = int.Parse(Session["idSanitario"].ToString());
                p.Data = DateTime.Now;
                t.idTariffario = int.Parse(item.Value.ToString());
                t.SelectId();
                p.Prezzo = t.Prezzo;
                s.idSanitario = int.Parse(Session["idSanitario"].ToString());
                s.SelectId();
                p.idSede = s.idSede;
                p.Pagato = false;
                p.Inserisci(); //inserire data e prezzo e sede
                RegistraOperazione("InserisciPrenotazioni", "HomeMedici");
            }
        }
    }

    protected void gridPrestazioniAperte_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string idPrestazione = gridPrestazioniAperte.DataKeys[e.RowIndex]["idPrestazione"].ToString();
        PRESTAZIONI p = new PRESTAZIONI();
        p.idPrestazione = int.Parse(idPrestazione);
        DataTable dt = p.PrestazioniSelectPerId();

        Response.Redirect("CartellaPaziente.aspx?c=" + dt.Rows[0]["idPaziente"].ToString()); // alberto 
    }

    protected void gridPrestazioniAperte_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //string docPrestazione = DataBinder.Eval(e.Row.DataItem, "docPrestazione").ToString();
            //if ()
            //{
            //    return;
            //}
            //byte[] docPrestazione = (byte[])DataBinder.Eval(e.Row.DataItem, "docPrestazione");

            Button btnDownload = e.Row.FindControl("btnDownload") as Button;

            if (DataBinder.Eval(e.Row.DataItem, "docPrestazione") == DBNull.Value || (DataBinder.Eval(e.Row.DataItem, "docPrestazione") as byte[]).Length == 0)
            {
                if (btnDownload != null)
                {
                    btnDownload.Visible = false;
                }
            }
        }
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    string docPrestazione = DataBinder.Eval(e.Row.DataItem, "docPrestazione").ToString();

        //    Button btnDownload = e.Row.FindControl("btnDownload") as Button;

        //    if (string.IsNullOrEmpty(docPrestazione))
        //    {

        //        if (btnDownload != null)
        //        {
        //            btnDownload.Visible = false;
        //        }
        //    }
        //}

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (DataBinder.Eval(e.Row.DataItem, "DataNascita") != DBNull.Value)
            {
                string nDec = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "DataNascita")).ToString("d");
                e.Row.Cells[1].Text = nDec;
            }
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (DataBinder.Eval(e.Row.DataItem, "DataPrestazione") != DBNull.Value)
            {
                string nDec = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "DataPrestazione")).ToString("g");
                e.Row.Cells[4].Text = nDec;
            }
        }

    }
    protected void gridPrestazioniChiuse_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //string docPrestazione = DataBinder.Eval(e.Row.DataItem, "docPrestazione").ToString();
            //if ()
            //{
            //    return;
            //}
            //byte[] docPrestazione = (byte[])DataBinder.Eval(e.Row.DataItem, "docPrestazione");

            Button btnDownload = e.Row.FindControl("btnDownload") as Button;

            if (DataBinder.Eval(e.Row.DataItem, "docPrestazione") == DBNull.Value || (DataBinder.Eval(e.Row.DataItem, "docPrestazione") as byte[]).Length == 0)
            {
                if (btnDownload != null)
                {
                    btnDownload.Visible = false;
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (DataBinder.Eval(e.Row.DataItem, "DataNascita") != DBNull.Value)
            {
                string nDec = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "DataNascita")).ToString("d");
                e.Row.Cells[1].Text = nDec;
            }
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (DataBinder.Eval(e.Row.DataItem, "DataPrestazione") != DBNull.Value)
            {
                string nDec = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "DataPrestazione")).ToString("g");
                e.Row.Cells[4].Text = nDec;
            }
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (DataBinder.Eval(e.Row.DataItem, "DataChiusura") != DBNull.Value)
            {
                string nDec = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "DataChiusura")).ToString("g");
                e.Row.Cells[5].Text = nDec;
            }
        }
    }

    protected void Mesepiu_Click(object sender, EventArgs e)
    {
        _data = DateTime.Parse(txtCalendario.Text);
        DateTime dataSuccessiva = _data.AddMonths(1);
        txtCalendario.Text = dataSuccessiva.ToString("yyyy-MM");
        CaricaGrigliaPrestazioniAperte();
        CaricaGrigliaPrestazioniChiuse();
    }

    protected void Mesemeno_Click(object sender, EventArgs e)
    {
        _data = DateTime.Parse(txtCalendario.Text);
        DateTime dataSuccessiva = _data.AddMonths(-1);
        txtCalendario.Text = dataSuccessiva.ToString("yyyy-MM");
        CaricaGrigliaPrestazioniAperte();
        CaricaGrigliaPrestazioniChiuse();
    }

    protected void gridPrestazioniChiuse_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            Div1.Visible = true;
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            int val = (int)this.gridPrestazioniChiuse.DataKeys[rowIndex]["idPrestazione"];

            string primaryKeyValue = gridPrestazioniChiuse.DataKeys[rowIndex].Values["idPrestazione"].ToString();

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
                popup1.CssClass = "card text-center position-absolute start-50 top-50 translate-middle rounded";
                popupBody1.CssClass = "card-body d-flex justify-content-center flex-wrap p-0 gap-4";
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
                    popup1.CssClass = "card text-center position-absolute start-50 top-50 translate-middle rounded Popup";
                    popupBody1.CssClass = "card-body d-flex justify-content-center flex-wrap p-0 gap-4";
                    string embed = "<object data=\"{0}{1}\" type=\"application/pdf\" style=\"width:100%;height:auto;\">";

                    embed += "</object>";
                    lit.Text += string.Format(embed, ResolveUrl("GestorePrestazioni.ashx?c="), primaryKey.ToString());
                }
                else
                {
                    popup1.CssClass = "card text-center position-absolute start-50 top-50 translate-middle rounded";
                    popupBody1.CssClass = "card-body d-flex justify-content-center flex-wrap gap-4 p-5";
                    lit.Text = "Non è presente un PDF";
                }
        }
    }
    protected void RegistraOperazione(string strOperazione, string strProgramma)
    {
        Log_Operazioni l = new Log_Operazioni();
        l.Operazione = strOperazione;
        l.Programma = strProgramma;
        l.UserMail = Session["USR"].ToString();
        l.DataLog = DateTime.Now;
        l.Inserisci();
    }
}