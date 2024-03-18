using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //accesso all'applicativo
    protected void btnAccedi_Click(object sender, EventArgs e)
    {
        CRITTOGRAFIA cr = new CRITTOGRAFIA();
        Accessi.AccessiSoapClient w = new Accessi.AccessiSoapClient();
        if (w.Login(txtUSR.Text.Trim(), cr.Crypta(txtPWD.Text)) != 0)
        {
            Session["idPaziente"] = w.Login(txtUSR.Text.Trim(), cr.Crypta(txtPWD.Text));
            Session["USR"] = txtUSR.Text;

            //Aggiungo log accesso positivo
            RegistraAccessi(true);
            Response.Redirect("PrenotazioniAttiveFiglia.aspx");
        }
        else
        {
            //Aggiungo log accesso negativo
            RegistraAccessi(false);
            lblErroreLogin.Visible = true;
            lblErroreLogin.Text = "Utente o password errati";
        }
    }

    //invio mail a utente con pwd dentro

    protected void btnRecuperaPWD_Click(object sender, EventArgs e)
    {
        CRITTOGRAFIA cr = new CRITTOGRAFIA();
        Accessi.AccessiSoapClient w = new Accessi.AccessiSoapClient();
        string pwdDaInviare = cr.Decrypta(w.RecuperaPassword(txtMail.Text.Trim()));

        try
        {
            SmtpClient mySmtpClient = new SmtpClient(" smtp.libero.it");

            // set smtp-client with basicAuthentication
            mySmtpClient.UseDefaultCredentials = false;
            System.Net.NetworkCredential basicAuthenticationInfo = new
               System.Net.NetworkCredential("gendoita12@libero.it", "Classedoita.12");
            mySmtpClient.Credentials = basicAuthenticationInfo;

            // add from,to mailaddresses
            MailAddress from = new MailAddress("gendoita12@libero.it", "ClasseDoIta");
            MailAddress to = new MailAddress(txtMail.Text, txtMail.Text);
            MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

            // add ReplyTo
            //MailAddress replyTo = new MailAddress("reply@example.com");
            //myMail.ReplyToList.Add(replyTo);

            // set subject and encoding
            myMail.Subject = "recupero password account klinik";

            // set body-message and encoding
            myMail.Body = "<b>Test Mail di prova per il corso <br>" +
                "Ciao " + txtMail.Text + " la tua password e': " + pwdDaInviare + " </b><br>using <b>HTML</b>.";
            // text or html
            myMail.IsBodyHtml = true;

            mySmtpClient.Port = 587;
            mySmtpClient.EnableSsl = true;
            mySmtpClient.Send(myMail);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Errore", "alert('E stata inviata una mail alla tua casella di posta con la tua password');", true);
        }

        catch (SmtpException ex)
        {
            throw new ApplicationException
              ("SmtpException has occured: " + ex.Message);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //registrazione nuovo utente
    protected void btnRegistra_Click(object sender, EventArgs e)
    {
        CRITTOGRAFIA cr = new CRITTOGRAFIA();
        Accessi.AccessiSoapClient w = new Accessi.AccessiSoapClient();
        if (txtRegistraPWD.Text != txtRegistraConfermaPWD.Text)
        {
            lblErroreLogin.Visible = true;
            lblErroreLogin.Text = "Le password non corrispondono";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Registra();", true);
            return;
        }
        if (w.MailEsistente(txtRegistraMail.Text) != "")
        {
            lblErroreLogin.Visible = true;
            lblErroreLogin.Text = "La mail inserita è già esistente";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Registra();", true);
            return;
        }
        w.Registra(txtRegistraMail.Text, cr.Crypta(txtRegistraPWD.Text), "", "", "", "", "", "", "", "", "", "");
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Errore", "alert('Nuovo utente inserito');", true);
    }

    //funzione per inserire l'accesso sul log
    protected void RegistraAccessi(bool esito)
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


}