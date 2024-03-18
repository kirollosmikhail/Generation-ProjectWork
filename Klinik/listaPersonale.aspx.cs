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
        CaricaGrigliaFiltro();
    }


    protected void btnIns_Click(object sender, EventArgs e)
    {
        if (inserisci.Visible == false)
        { inserisci.Visible = true; }
    }

    protected void btnAnnullaIns_Click(object sender, EventArgs e)
    {
        inserisci.Visible = false;

        lblAvvisoUsrMail.Visible = false;
        lblAvvisoPwd.Visible = false;
        lblAvvisoCognome.Visible = false;
        lblAvvisoNome.Visible = false;
        lblAvvisoTipologia.Visible = false;

        txtUsrMail.CssClass = "form-control ft-Large";
        txtPwd.CssClass = "form-control ft-Medium";
        txtCognome.CssClass = "form-control ft-Medium";
        txtNome.CssClass = "form-control ft-Medium";
        ddlAggTipo.CssClass = "form-select ft-Medium";
    }

    protected void btnConfermaIns_Click(object sender, EventArgs e)
    {
        PERSONALE p = new PERSONALE();
        p.Tipologia = ddlAggTipo.SelectedValue;
        p.UserMail = txtUsrMail.Text.Trim();
        p.Password = txtPwd.Text.Trim();
        p.Cognome = txtCognome.Text.Trim();
        p.Nome = txtNome.Text.Trim();
        if (txtUsrMail.Text == "" || txtPwd.Text == "" || txtCognome.Text == "" || txtNome.Text == "" || ddlAggTipo.SelectedValue == "")
        {
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Errore", "alert('Riempi i campi!');", true);
            if (txtUsrMail.Text == "")
            {
                lblAvvisoUsrMail.Visible = true;
                lblAvvisoUsrMail.Text = "Inserisci una Email";
                txtUsrMail.CssClass = "form-control ft-Large border-danger is-invalid";
            }
            else
            {
                lblAvvisoUsrMail.Visible = false;
                txtUsrMail.CssClass = "form-control ft-Medium";
            }
            if (txtPwd.Text == "")
            {
                lblAvvisoPwd.Visible = true;
                lblAvvisoPwd.Text = "Inserisci una Password";
                txtPwd.CssClass = "form-control ft-Medium border-danger is-invalid";
            }
            else
            {
                lblAvvisoPwd.Visible = false;
                txtPwd.CssClass = "form-control ft-Medium";
            }
            if (txtCognome.Text == "")
            {
                lblAvvisoCognome.Visible = true;
                lblAvvisoCognome.Text = "Inserisci un Cognome";
                txtCognome.CssClass = "form-control ft-Medium border-danger is-invalid";
            }
            else
            {
                lblAvvisoCognome.Visible = false;
                txtCognome.CssClass = "form-control ft-Medium";
            }
            if (txtNome.Text == "")
            {
                lblAvvisoNome.Visible = true;
                lblAvvisoNome.Text = "Inserisci un Nome";
                txtNome.CssClass = "form-control ft-Medium border-danger is-invalid";
            }
            else
            {
                lblAvvisoNome.Visible = false;
                txtNome.CssClass = "form-control ft-Medium";
            }
            if (ddlAggTipo.SelectedValue == "--Seleziona--")
            {
                lblAvvisoTipologia.Visible = true;
                lblAvvisoTipologia.Text = "Seleziona una Tipologia";
                ddlAggTipo.CssClass = "form-select ft-Medium border-danger is-invalid";
            }
            else
            {
                lblAvvisoTipologia.Visible = false;
                ddlAggTipo.CssClass = "form-select ft-Medium";
            }
            return;
        }
        else
        {
            lblAvvisoUsrMail.Visible = false;
            lblAvvisoPwd.Visible = false;
            lblAvvisoCognome.Visible = false;
            lblAvvisoNome.Visible = false;
            lblAvvisoTipologia.Visible = false;

            txtUsrMail.CssClass = "form-control ft-Large";
            txtPwd.CssClass = "form-control ft-Medium";
            txtCognome.CssClass = "form-control ft-Medium";
            txtNome.CssClass = "form-control ft-Medium";
            ddlAggTipo.CssClass = "form-select ft-Medium";
        }

        if (ddlAggTipo.SelectedValue == "Amministrazione")
        {
            p.Tipologia = "Amministrazione";
        }

        if (ddlAggTipo.SelectedValue == "Contabilità")
        {
            p.Tipologia = "Contabilità";
        }

        if (ddlAggTipo.SelectedValue == "Segreteria")
        {
            p.Tipologia = "Segreteria";
        }


        CONNESSIONE c = new CONNESSIONE();

        c.AddParametro("@UserMail", txtUsrMail.Text);
        c.Select("PERSONALE_UserMailEsistente");
        if (c.dt.Rows.Count != 0)
        {
            lblAvvisoUsrMail.Visible = true;
            lblAvvisoUsrMail.Text = "Email già Esistente";
            txtUsrMail.CssClass = "form-control ft-Medium border-danger is-invalid";
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Errore", "alert('Mail già esistente!');", true);
            return;
        }
        else
        {
            lblAvvisoUsrMail.Visible = false;
            txtUsrMail.CssClass = "form-control ft-Large";

            p.Inserisci();
            Response.Redirect("listaPersonale.aspx");
            inserisci.Visible = false;
        }
    }



    protected void btnMod_Click(object sender, EventArgs e)
    {

    }

    protected void btnAnnullaMod_Click(object sender, EventArgs e)
    {

        Modifica.Visible = false;


        lblAvvisoCognomeMod.Visible = false;
        lblAvvisoNomeMod.Visible = false;
        lblAvvisoTipologiaMod.Visible = false;

        txtCognomeMod.CssClass = "form-control ft-Medium";
        txtNomeMod.CssClass = "form-control ft-Medium";
        ddlModTipologia.CssClass = "form-select ft-Medium";
    }

    protected void btnConfermaMod_Click(object sender, EventArgs e)
    {
        PERSONALE p = new PERSONALE();
        p.idPersonale = int.Parse(gridPersonale.SelectedValue.ToString());
        p.SelectId();
        p.Cognome = txtCognomeMod.Text.Trim();
        p.Nome = txtNomeMod.Text.Trim();


        if (txtCognomeMod.Text == "" || txtNomeMod.Text == "" || ddlModTipologia.SelectedValue == "--Seleziona--")
        {
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Errore", "alert('Riempi i campi!');", true);

            if (txtCognomeMod.Text == "")
            {
                lblAvvisoCognomeMod.Visible = true;
                lblAvvisoCognomeMod.Text = "Inserisci un Cognome";
                txtCognomeMod.CssClass = "form-control ft-Medium border-danger is-invalid";
            }
            else
            {
                lblAvvisoCognome.Visible = false;
                txtCognome.CssClass = "form-control ft-Medium";
            }
            if (txtNomeMod.Text == "")
            {
                lblAvvisoNomeMod.Visible = true;
                lblAvvisoNomeMod.Text = "Inserisci un Nome";
                txtNomeMod.CssClass = "form-control ft-Medium border-danger is-invalid";
            }
            else
            {
                lblAvvisoNomeMod.Visible = false;
                txtNomeMod.CssClass = "form-control ft-Medium";
            }
            if (ddlModTipologia.SelectedValue == "--Seleziona--")
            {
                lblAvvisoTipologiaMod.Visible = true;
                lblAvvisoTipologiaMod.Text = "Seleziona una Tipologia";
                ddlModTipologia.CssClass = "form-select ft-Medium border-danger is-invalid";
            }
            else
            {
                lblAvvisoTipologia.Visible = false;
                ddlModTipologia.CssClass = "form-select ft-Medium";
            }
            return;
        }
        else
        {
            lblAvvisoCognomeMod.Visible = false;
            lblAvvisoNomeMod.Visible = false;
            lblAvvisoTipologiaMod.Visible = false;

            txtCognomeMod.CssClass = "form-control ft-Medium";
            txtNomeMod.CssClass = "form-control ft-Medium";
            ddlModTipologia.CssClass = "form-select ft-Medium";

            p.Tipologia = ddlModTipologia.SelectedValue;
            if (ddlModTipologia.SelectedValue == "A")
            {
                p.Tipologia = "Amministrazione";
            }

            if (ddlModTipologia.SelectedValue == "C")
            {
                p.Tipologia = "Contabilita";
            }

            if (ddlModTipologia.SelectedValue == "S")
            {
                p.Tipologia = "Segreteria";
            }

            p.Modifica();

            Modifica.Visible = false;

            Response.Redirect("listaPersonale.aspx");

        }

    }

    protected void CaricaFiltri()
    {
        PERSONALE p = new PERSONALE();
        ddlFiltroTipologia.DataSource = p.Select();
        ddlFiltroTipologia.DataTextField = "Tipologia";
        ddlFiltroTipologia.DataValueField = "Tipologia";
        ddlFiltroTipologia.DataBind();
        ddlFiltroTipologia.Items.Insert(0, new ListItem { Value = "--Seleziona--" });



    }

    protected void gridPersonale_SelectedIndexChanged(object sender, EventArgs e)
    {
        Modifica.Visible = true;
        PERSONALE p = new PERSONALE();
        string id = gridPersonale.SelectedValue.ToString();
        p.idPersonale = int.Parse(id);
        p.SelectId();

        txtCognomeMod.Text = p.Cognome;
        txtNomeMod.Text = p.Nome;
        ddlModTipologia.SelectedValue = p.Tipologia;
    }

    protected void CaricaGrigliaFiltro()
    {
        CONNESSIONE c = new CONNESSIONE();

        if (ddlFiltroTipologia.SelectedValue != "--Seleziona--")
        {
            c.AddParametro("@Tipologia", ddlFiltroTipologia.SelectedValue);
        }
        else
        {
            c.AddParametro("@Tipologia");
        }
        if (txtFiltroUsrMail.Text != "")
        {
            c.AddParametro("@UserMail", txtFiltroUsrMail.Text.Trim());
        }
        else
        {
            c.AddParametro("@UserMail");
        }
        if (txtFiltroNominativoPersonale.Text != "")
        {
            c.AddParametro("@NominativoPersonale", txtFiltroNominativoPersonale.Text.Trim());
        }
        else
        {
            c.AddParametro("@NominativoPersonale");
        }
        c.Select("PERSONALE_SelectFiltri");

        gridPersonale.DataSource = c.dt;
        gridPersonale.DataBind();
    }



    protected void gridPersonale_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridPersonale.PageIndex = e.NewPageIndex;
        CaricaGrigliaFiltro();

    }
}