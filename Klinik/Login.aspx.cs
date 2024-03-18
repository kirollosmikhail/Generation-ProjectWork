using ASP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    // VARIABILI SESSION UTILIZZABILI
    // Session["idPersonale"]
    // Session["idSanitario"]
    // Session["Tipologia"]
    // Session["USR"]

    // PER REGISTRARE LOGIN
    protected void RegistraAccesso(bool esito) // PASSARE COME ESITO true o false, esempio subito sotto
    {
        Log_Accessi l = new Log_Accessi();
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                l.IndirizzoIP = ip.ToString();
            }
        }
        l.Utente = txtUSR.Text.ToString();
        l.DataLog = DateTime.Now;
        l.Esito = esito;
        l.Inserisci();
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) { Session.Clear(); }       			
	}

    protected void btnAccedi_Click(object sender, EventArgs e)
    {
        if (Session["Ruolo"].ToString() == "Amministrazione")
        {
            PERSONALE p = new PERSONALE();
            p.UserMail = txtUSR.Text.ToString();
            p.Password = txtPWD.Text.ToString();
            DataTable dt = new DataTable();
            dt = p.Login();
            if (dt.Rows.Count != 0)
            {
                RegistraAccesso(true); // ESEMPIO true
                Session["idPersonale"] = dt.Rows[0]["idPersonale"].ToString();
                Session["Tipologia"] = dt.Rows[0]["Tipologia"].ToString();
                Session["USR"] = txtUSR.Text.ToString();
                if (Session["Tipologia"].ToString() == "A") { Response.Redirect("Log_Accessi.aspx"); }
                else if (Session["Tipologia"].ToString() == "C") { Response.Redirect("Rendicontazione.aspx"); }
                else if (Session["Tipologia"].ToString() == "S") { Response.Redirect("Prenotazioni.aspx"); }

            }
            else
            {
                RegistraAccesso(false); // ESEMPIO false
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Login();", true);
                lblErroreLogin.Text = "Credenziali di accesso errate";
            }
        }


        if (Session["Ruolo"].ToString() == "Sanitari")
        {
            SANITARI s = new SANITARI();
            s.UserMail = txtUSR.Text.ToString();
            s.Password = txtPWD.Text.ToString();
            DataTable dt = new DataTable();
            dt = s.Login();
            if (dt.Rows.Count != 0)
            {
                RegistraAccesso(true);
                Session["idSanitario"] = dt.Rows[0]["idSanitario"].ToString();
                Session["Tipologia"] = dt.Rows[0]["Tipologia"].ToString();
                Session["USR"] = txtUSR.Text.ToString();
                if (Session["Tipologia"].ToString() == "M") { Response.Redirect("Calendario.aspx"); }
                else if (Session["Tipologia"].ToString() == "R") { Response.Redirect("Calendario.aspx"); }
                else if (Session["Tipologia"].ToString() == "A") { Response.Redirect("Calendario.aspx"); }

            }
            else
            {
                RegistraAccesso(false);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Login();", true);
                lblErroreLogin.Text = "Credenziali di accesso errate";
            }
        }


    }


    protected void btnRecuperaPWD_Click(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Errore", "alert('E stata inviata una mail alla tua casella di posta con la tua password');", true);


    }

    protected void btnAmministrazione_Click(object sender, EventArgs e)
    {
        Session["Ruolo"] = "Amministrazione";
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Login();", true);
    }

    protected void btnSanitari_Click(object sender, EventArgs e)
    {
        Session["Ruolo"] = "Sanitari";
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Login();", true);
    }

}