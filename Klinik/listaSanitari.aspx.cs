using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;

public partial class Default2 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // GRIGLIA SelectAll
            caricaGrid();

            // DDL Select
            caricaDDL();
        }
    }

    /// <summary>
    /// EVENTO per far funzionare il paging
    /// </summary>
    protected void gridSanitari_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridSanitari.PageIndex = e.NewPageIndex;
        caricaGrid();
    }

    /// <summary>
    /// METODO per caricare la griglia
    /// </summary>
    protected void caricaGrid()
    {
        SANITARI s = new SANITARI();
        gridSanitari.DataSource = s.Select();
        gridSanitari.DataBind();
    }

    /// <summary>
    /// METODO per caricare tutte le DDL della pag
    /// </summary>
    protected void caricaDDL()
    {
        SEDI se = new SEDI();
        // FILTRI
        ddlFiltroSede.DataSource = se.Select();
        ddlFiltroSede.DataValueField = "idSede";
        ddlFiltroSede.DataTextField = "Citta";
        ddlFiltroSede.DataBind();
        ddlFiltroSede.Items.Insert(0, new ListItem { Value = "--Seleziona--" });

        ddlFiltroTipo.SelectedValue = "0";

        // SELETTORI PER INS E MODIF
        ddlSede.DataSource = se.Select();
        ddlSede.DataValueField = "idSede";
        ddlSede.DataTextField = "Citta";
        ddlSede.DataBind();

        ddlTipo.SelectedValue = "0";
    }

    /// <summary>
    /// METODO filtro
    /// </summary>
    protected void filtriMetodo(object sender, EventArgs e)
    {
        CONNESSIONE c = new CONNESSIONE();

        //PARAMETRI FILTRO
        if (ddlFiltroSede.SelectedIndex != 0) { c.AddParametro("@idSede", int.Parse(ddlFiltroSede.SelectedValue)); }
        else { c.AddParametro("@idSede"); }

        if (ddlFiltroTipo.SelectedIndex != 0) { c.AddParametro("@Tipologia", ddlFiltroTipo.SelectedValue); }
        else { c.AddParametro("@Tipologia"); }

        if (txtFiltroNominativo.Text != string.Empty) { c.AddParametro("@NominativoSanitario", txtFiltroNominativo.Text); }
        else { c.AddParametro("@NominativoSanitario"); }

        if (txtFiltroUsrMail.Text != string.Empty) { c.AddParametro("@UserMail", txtFiltroUsrMail.Text); }
        else { c.AddParametro("@UserMail"); }

        c.Select("SANITARI_SelectFiltri");

        gridSanitari.DataSource = c.dt;
        gridSanitari.DataBind();
    }

    /// <summary>
    /// METODO per popup di inserimento dati
    /// </summary>
    protected void btnIns_Click(object sender, EventArgs e)
    {
        //Apre popup INS, mostra campo PWD e svuota gli altri
        txtUsrMail.Text = string.Empty;
        txtCognome.Text = string.Empty;
        txtNome.Text = string.Empty;
        txtTitolo.Text = string.Empty;
        txtRicavo.Text = string.Empty;
        ddlTipo.SelectedValue = "0";
        ddlSede.SelectedIndex = 0;
        divData.Visible = true;
        divPwd.Attributes["style"] = "";
        divFakePwd.Attributes["style"] = "display: none";
        divInsTitle.Visible = true;
        btnSalvaInsert.Visible = true;
    }

    /// <summary>
    /// METODO per button inserimento salvataggio dati
    /// </summary>
    protected void btnSalvaInsert_Click(object sender, EventArgs e)
    {
        if (checkData("inserisci"))
        {
            SANITARI s = new SANITARI();
            s.Cognome = txtCognome.Text.Trim();
            s.Nome = txtNome.Text.Trim();
            s.UserMail = txtUsrMail.Text.Trim();
            s.Password = txtPwd.Text.Trim();
            s.Ricavo = decimal.Parse(txtRicavo.Text);
            s.Titolo = txtTitolo.Text.Trim();
            s.Tipologia = ddlTipo.SelectedValue;
            s.idSede = int.Parse(ddlSede.SelectedValue);
            s.Foto = upldFoto.FileBytes;
            s.Inserisci();
            RegistraOperazione("Inserimento personale sanitario, " + s.Nome + " " + s.Cognome, "Lista Sanitari");
        }
        else { return; }

        divData.Visible = false;
        divPwd.Attributes["style"] = "display: none";
        divInsTitle.Visible = false;
        btnSalvaInsert.Visible = false;

        caricaGrid();
    }

    /// <summary>
    /// METODO per button modifica salvataggio dati
    /// </summary>
    protected void btnSalvaMod_Click(object sender, EventArgs e)
    {
        if (checkData("modifica"))
        {
            SANITARI s = new SANITARI();
            s.idSanitario = int.Parse(gridSanitari.SelectedValue.ToString());
            s.SelectId(); // per campi inalterati
            s.idSede = int.Parse(ddlSede.SelectedValue);
            s.Tipologia = ddlTipo.SelectedValue;
            s.UserMail = txtUsrMail.Text.Trim();
            s.Ricavo = decimal.Parse(txtRicavo.Text);
            s.Titolo = txtTitolo.Text.Trim();
            s.Cognome = txtCognome.Text.Trim();
            s.Nome = txtNome.Text.Trim();
            if (upldFoto.HasFiles)
            {
                s.Foto = upldFoto.FileBytes;
            }
            s.Modifica();
            RegistraOperazione("Modifica personale sanitario, " + s.Nome + " " + s.Cognome, "Lista Sanitari");
        }

        divData.Visible = false;
        divModTitle.Visible = false;
        btnSalvaMod.Visible = false;

        caricaGrid();
    }

    /// <summary>
    /// METODO per button chiusura popup
    /// </summary>
    protected void btnAnnulla_Click(object sender, EventArgs e)
    {
        //Svuota i campi
        txtUsrMail.Text = string.Empty;
        txtCognome.Text = string.Empty;
        txtNome.Text = string.Empty;
        txtTitolo.Text = string.Empty;
        txtPwd.Text = string.Empty;
        txtRicavo.Text = string.Empty;
        ddlTipo.SelectedValue = "0";
        ddlSede.SelectedIndex = 0;

        //Svuota le label d'errore
        lblCognome.Visible = false;
        txtCognome.CssClass = "form-control ft-Medium";
        lblNome.Visible = false;
        txtNome.CssClass = "form-control ft-Medium";
        lblMail.Visible = false;
        txtUsrMail.CssClass = "form-control ft-Large";
        lblPwD.Visible = false;
        txtPwd.CssClass = "form-control ft-Medium";
        lblRicavi.Visible = false;
        txtRicavo.CssClass = "form-control ft-Medium";
        lblTitoli.Visible = false;
        txtTitolo.CssClass = "form-control ft-Medium";
        lblFoto.Visible = false;
        upldFoto.CssClass = "form-control ft-Large";
        lblSede.Visible = false;
        ddlSede.CssClass = "form-select";
        lblTipo.Visible = false;
        ddlTipo.CssClass = "form-select";

        //Nasconde i popup e campo PWD
        divData.Visible = false;
        divPwd.Attributes["style"] = "display: none";
        divFakePwd.Attributes["style"] = "display: none";
        divInsTitle.Visible = false;
        divModTitle.Visible = false;
        btnSalvaInsert.Visible = false;
        btnSalvaMod.Visible = false;

        //Ricarica la griglia
        caricaGrid();
    }

    /// <summary>
    /// METODO controllo compilazione
    /// </summary>
    /// <param name="tipo">PUNTATORE al tipo di popup</param>
    /// <returns>Produce un errore in caso di errori</returns>
    protected bool checkData(string tipo)
    {
        if (txtCognome.Text.Trim() == string.Empty ||
           txtNome.Text.Trim() == string.Empty ||
           txtTitolo.Text.Trim() == string.Empty ||
           (txtUsrMail.Text.Trim() == string.Empty || !IsValidEmail(txtUsrMail.Text.Trim())) ||
           (tipo == "inserisci" && txtPwd.Text.Trim() == string.Empty || !Regex.Match(txtPwd.Text.Trim(), "^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$").Success) ||
           txtRicavo.Text.Trim() == string.Empty ||
           ddlTipo.SelectedValue == "0" ||
           int.Parse(ddlSede.SelectedValue) == 0 ||
           (tipo == "inserisci" && !upldFoto.HasFiles))
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('COMPILA TUTTI I CAMPI')", true);

            //COGNOME
            if (txtCognome.Text.Trim() == string.Empty)
            {
                lblCognome.Visible = true;
                txtCognome.CssClass = "form-control ft-Medium is-invalid border-danger";
                lblCognome.Text = "Inserisci un cognome.";
            }
            else
            {
                lblCognome.Visible = false;
                txtCognome.CssClass = "form-control ft-Medium";
            }

            //NOME
            if (txtNome.Text.Trim() == string.Empty)
            {
                lblNome.Visible = true;
                txtNome.CssClass = "form-control ft-Medium is-invalid border-danger";
                lblNome.Text = "Inserisci un nome.";
            }
            else
            {
                lblNome.Visible = false;
                txtNome.CssClass = "form-control ft-Medium";
            }

            //EMAIL
            if (txtUsrMail.Text.Trim() == string.Empty || !IsValidEmail(txtUsrMail.Text.Trim()))
            {
                lblMail.Visible = true;
                txtUsrMail.CssClass = "form-control ft-Large is-invalid border-danger";
                lblMail.Text = "Inserisci una email valida.";
            }
            else
            {
                lblMail.Visible = false;
                txtUsrMail.CssClass = "form-control ft-Large";
            }

            //PWD
            if (tipo == "inserisci" && txtPwd.Text.Trim() == string.Empty || !Regex.Match(txtPwd.Text.Trim(), "^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$").Success)
            {
                lblPwD.Visible = true;
                txtPwd.CssClass = "form-control ft-Medium is-invalid border-danger";
                lblPwD.Text = "La password deve essere lunga 8 caratteri e avere un carattere minuscolo, uno maiuscolo e un numero.";
            }
            else
            {
                lblPwD.Visible = false;
                txtPwd.CssClass = "form-control ft-Medium";
            }

            //RICAVO
            if (txtRicavo.Text.Trim() == string.Empty)
            {
                lblRicavi.Visible = true;
                txtRicavo.CssClass = "form-control ft-Medium is-invalid border-danger";
                lblRicavi.Text = "Inserisci un ricavo.";
            }
            else
            {
                lblRicavi.Visible = false;
                txtRicavo.CssClass = "form-control ft-Medium";
            }

            //TITOLO
            if (txtTitolo.Text.Trim() == string.Empty)
            {
                lblTitoli.Visible = true;
                txtTitolo.CssClass = "form-control ft-Medium is-invalid border-danger";
                lblTitoli.Text = "Inserisci un titolo.";
            }
            else
            {
                lblTitoli.Visible = false;
                txtTitolo.CssClass = "form-control ft-Medium";
            }

            //FOTO
            if (!upldFoto.HasFile && tipo == "inserisci")
            {
                lblFoto.Visible = true;
                upldFoto.CssClass = "form-control ft-Large is-invalid border-danger";
                lblFoto.Text = "Inserisci una foto.";
            }
            else
            {
                lblFoto.Visible = false;
                upldFoto.CssClass = "form-control ft-Large";
            }

            //SEDE
            if (int.Parse(ddlSede.SelectedValue) == 0)
            {
                lblSede.Visible = true;
                ddlSede.CssClass = "form-select is-invalid border-danger";
                lblSede.Text = "Seleziona una sede.";
            }
            else
            {
                lblSede.Visible = false;
                ddlSede.CssClass = "form-select";
            }

            //TIPO
            if (ddlTipo.SelectedValue == "0")
            {
                lblTipo.Visible = true;
                ddlTipo.CssClass = "form-select ft-Medium is-invalid border-danger";
                lblTipo.Text = "Seleziona un tipo.";
            }
            else
            {
                lblTipo.Visible = false;
                ddlTipo.CssClass = "form-select";
            }

            return false;
        }
        else
        {
            lblCognome.Visible = false;
            txtCognome.CssClass = "form-control ft-Medium";
            lblNome.Visible = false;
            txtNome.CssClass = "form-control ft-Medium";
            lblMail.Visible = false;
            txtUsrMail.CssClass = "form-control ft-Large";
            lblPwD.Visible = false;
            txtPwd.CssClass = "form-control ft-Medium";
            lblRicavi.Visible = false;
            txtRicavo.CssClass = "form-control ft-Medium";
            lblTitoli.Visible = false;
            txtTitolo.CssClass = "form-control ft-Medium";
            lblFoto.Visible = false;
            upldFoto.CssClass = "form-control ft-Large";
            lblSede.Visible = false;
            ddlSede.CssClass = "form-select";
            lblTipo.Visible = false;
            ddlTipo.CssClass = "form-select";
        }

        //if (!upldFoto.HasFile && tipo == "inserimento")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('COMPILA TUTTI I CAMPI')", true);
        //    return false;
        //}

        //Controllo formato email
        //if (!IsValidEmail(txtUsrMail.Text.Trim()))
        //{
        //    lblMail.Visible = true;
        //    txtUsrMail.CssClass = "form-control ft-Large is-invalid border-danger";
        //    lblMail.Text = "Inserisci una email valida.";
        //    return false;
        //}

        //Controllo formato password
        //if (tipo == "inserisci" && !Regex.Match(txtPwd.Text.Trim(), "^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$").Success)
        //{
        //    lblPwD.Visible = true;
        //    txtPwd.CssClass = "form-control ft-Medium is-invalid border-danger";
        //    lblPwD.Text = "La password deve essere lunga 8 caratteri e avere un carattere minuscolo, uno maiuscolo e un numero.";
        //    return false;
        //}
        return true;
    }

    /// <summary>
    /// METODO per verificare il corretto formato delle mail
    /// </summary>
    /// <param name="email">Email da validare</param>
    /// <returns>Se è falso, il metodo di verifica darà errore</returns>
    bool IsValidEmail(string email)
    {
        if (string.IsNullOrEmpty(Path.GetExtension(email)))
        {
            return false;
        }
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// EVENTO di output dei dati per il div di modifica
    /// </summary>
    protected void gridSanitari_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Apre popup MOD e nasconde campo PWD
        divPwd.Attributes["style"] = "display: none";
        divFakePwd.Attributes["style"] = "";
        divData.Visible = true;
        divModTitle.Visible = true;
        btnSalvaMod.Visible = true;

        SANITARI s = new SANITARI();
        s.idSanitario = int.Parse(gridSanitari.SelectedValue.ToString());
        s.SelectId();

        txtCognome.Text = s.Cognome;
        txtNome.Text = s.Nome;
        txtUsrMail.Text = s.UserMail;
        txtRicavo.Text = s.Ricavo.ToString();
        txtTitolo.Text = s.Titolo;
        ddlTipo.SelectedValue = s.Tipologia;
        ddlSede.SelectedValue = s.idSede.ToString();
    }

    /// <summary>
    /// METODO per esplicitare il valore della tipologia e convertire il ricavo in percentuale
    /// </summary>
    protected void gridSanitari_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[3].Text == "M")
            {
                e.Row.Cells[3].Text = "Medico";
            }
            if (e.Row.Cells[3].Text == "A")
            {
                e.Row.Cells[3].Text = "Analista";
            }
            if (e.Row.Cells[3].Text == "R")
            {
                e.Row.Cells[3].Text = "Radiologo";
            }
            if (DataBinder.Eval(e.Row.DataItem, "Ricavo") != DBNull.Value)
            {
                decimal nDec = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Ricavo"));
                e.Row.Cells[6].Text = nDec.ToString("p0");
            }
        }
    }

    /// <summary>
    /// LOG per operazioni
    /// </summary>
    /// <param name="strOperazione">Nome operazione</param>
    /// <param name="strProgramma">Nome programma</param>
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