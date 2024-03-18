using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Prenotazioni : System.Web.UI.Page
{
    static int idPrenotazione;
    protected void Page_Load(object sender, EventArgs e)
    {

        riempigriglia();



    }

    protected void riempigriglia()
    {
        string Nominativo;
        CONNESSIONE co = new CONNESSIONE();

        co.cmd.Parameters.AddWithValue("@Pagato", false);

        if (txtNominativo.Text.Trim() == "") Nominativo = null;
        else Nominativo = txtNominativo.Text.Trim();

        co.cmd.Parameters.AddWithValue("@Nominativo", Nominativo != null ? Nominativo : (object)DBNull.Value);

        co.Select("Prenotazioni_select_join");
        gridPrenotazioni.DataSource = co.dt;
        gridPrenotazioni.DataBind();
    }


    protected void riempiddlSanitario()
    {
        CONNESSIONE co = new CONNESSIONE();
        co.cmd.Parameters.AddWithValue("@idPrenotazione", idPrenotazione);
        co.Select("SANITARI_FiltroMediciSedeDdl");
        ddlSanitario.DataSource = co.dt;
        ddlSanitario.DataTextField = "NominativoSanitario";
        ddlSanitario.DataValueField = "idSanitario";
        ddlSanitario.DataBind();
        ddlSanitario.Items.Insert(0, new ListItem { Value = "--Seleziona--" });
    }

    protected void riempiddlOre(object sender, EventArgs e)
    {
        CONNESSIONE co = new CONNESSIONE();
        ddlora.Attributes.Remove("disabled");
        //if (ddlSanitario.SelectedValue == "--Seleziona--" || txtData.Text == "")
        //{
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "Errore", "alert('Compila tutti i campi');", true);
        //    return;
        //}
        ddlora.Items.Clear();
        ddlora.Items.Insert(0, new ListItem { Text = "--Seleziona--", Value="0"});
  
        if (txtData.Text == "")
        {
            ddlora.Items[0].Text = "--Nessun orario disponibile--";
            ddlora.Items[0].Value = "0";
            ddlora.Attributes.Add("disabled", "disabled");
            return;
        }
        DateTime data = DateTime.Parse(txtData.Text);

        if ((data.DayOfWeek == DayOfWeek.Saturday) || (data.DayOfWeek == DayOfWeek.Sunday))
        {
            ddlora.Items[0].Text = "--Nessun orario disponibile--";
            ddlora.Items[0].Value = "0";
            ddlora.Attributes.Add("disabled", "disabled");
            return;
        }
        if (ddlSanitario.SelectedValue == "--Seleziona--")
        {
            ddlora.Items[0].Text = "--Nessun orario disponibile--";
            ddlora.Items[0].Value = "0";
            ddlora.Attributes.Add("disabled", "disabled");
            return;
        }

        int? idSanitario = int.Parse(ddlSanitario.SelectedValue);

        co.cmd.Parameters.AddWithValue("@idSanitario", idSanitario != null ? idSanitario : (object)DBNull.Value);
        co.cmd.Parameters.AddWithValue("@DataPrestazione", data != null ? data : (object)DBNull.Value);
        co.Select("PRESTAZIONI_DateDisponibili");
        DataTable dt = co.dt;

        for (int i = 9; i <= 18; i++)
        {
            bool x = false;
            foreach (DataRow dr in dt.Rows)
            {
                if (int.Parse(dr["OraPrestazione"].ToString()) == i)
                {
                    x = true; break;
                }
            }
            if (!x)
            {
                ddlora.Items.Add(new ListItem { Text = i + ":00", Value = i.ToString() });
            }
        }
        if (ddlora.Items.Count == 1)
        {
            ddlora.Items[0].Text = "--Nessun orario disponibile--";
            ddlora.Items[0].Value = "0";
            ddlora.Attributes.Add("disabled", "disabled");
        }
    }

    //POPUP
    protected void btnAnnullaAgg_Click(object sender, EventArgs e)
    {

        popAggiungi.Visible = false;
        ddlSanitario.SelectedValue = "--Seleziona--";
        txtData.Text = "";
        lblAvvSanitario.Visible = false;
        lblAvvData.Visible = false;
        lblAvvOra.Visible = false;
        ddlSanitario.CssClass = "form-select ft-Large";
        txtData.CssClass = "form-control ft-Medium";
        ddlora.CssClass = "form-select ft-Large";
    }

    protected void btnConfermaAgg_Click(object sender, EventArgs e)
    {
        PRESTAZIONI p = new PRESTAZIONI();
        if (ddlSanitario.SelectedValue == "--Seleziona--" || txtData.Text == "" || ddlora.SelectedValue == "0")
        {
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Errore", "alert('Compila tutti i campi');", true);
            if (ddlSanitario.SelectedValue == "--Seleziona--")
            {
                lblAvvSanitario.Visible = true;
                ddlSanitario.CssClass = "form-select ft-Large is-invalid border-danger";
                lblAvvSanitario.Text = "Seleziona un Sanitario";
            }
            else
            {
                lblAvvSanitario.Visible = false;
                ddlSanitario.CssClass = "form-select ft-Large";
            }
            if (txtData.Text == "")
            {
                lblAvvData.Visible = true;
                txtData.CssClass = "form-control ft-Medium is-invalid border-danger";
                lblAvvData.Text = "Seleziona una Data";
            }
            else
            {
                lblAvvData.Visible = false;
                txtData.CssClass = "form-control ft-Medium";
            }
            if (ddlora.SelectedValue == "0")
            {
                lblAvvOra.Visible = true;
                ddlora.CssClass = "form-select ft-Large is-invalid border-danger";
                lblAvvOra.Text = "Seleziona un Orario";
            }
            else
            {
                lblAvvOra.Visible = false;
                ddlora.CssClass = "form-select ft-Large";

            }
            return;
        }
        else
        {
            lblAvvSanitario.Visible = false;
            lblAvvData.Visible = false;
            lblAvvOra.Visible = false;
            ddlSanitario.CssClass = "form-select ft-Large";
            txtData.CssClass = "form-control ft-Medium";
            ddlora.CssClass = "form-select ft-Large";
        }
        p.idSanitario = int.Parse(ddlSanitario.SelectedValue);
        string data = DateTime.Parse(txtData.Text).ToString("yyyy-MM-dd");
        string ora = ddlora.SelectedValue + ":00:00";
        DateTime dataora = DateTime.Parse(data + " " + ora);
        p.DataPrestazione = dataora;
        p.Inserisci(idPrenotazione, int.Parse(Session["idPersonale"].ToString()));
        riempigriglia();
        popAggiungi.Visible = false;
        ddlSanitario.SelectedValue = "--Seleziona--";
        txtData.Text = "";
    }

    protected void gridPrenotazioni_SelectedIndexChanged(object sender, EventArgs e)
    {
        idPrenotazione = int.Parse(gridPrenotazioni.SelectedValue.ToString());
        riempiddlSanitario();
        if (popAggiungi.Visible == false)
        { popAggiungi.Visible = true; }
    }
}