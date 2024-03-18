using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		lblUtente.Text = Session["USR"].ToString();


		if (Session["Tipologia"].ToString() == "A" && Session["Ruolo"].ToString() == "Sanitari") 
		{ 
			pnlAnalisti.Visible = true; CaricaFoto(); 
		}
		else if (Session["Tipologia"].ToString() == "A" && Session["Ruolo"].ToString() == "Amministrazione") 
		{ 
			pnlAdmin.Visible = true;
		}
		else if (Session["Tipologia"].ToString() == "C") { pnlEconomia.Visible = true; }
		else if (Session["Tipologia"].ToString() == "S") { pnlPersonale.Visible = true; }
		else if (Session["Tipologia"].ToString() == "M") { pnlMedici.Visible = true; CaricaFoto(); }
		else if (Session["Tipologia"].ToString() == "R") { pnlAnalisti.Visible = true; CaricaFoto(); }
		else { Response.Redirect("Login.aspx"); }
	}


	protected void CaricaFoto()
	{
		int sessione = int.Parse(Session["idSanitario"].ToString());
		FotoProfilo.Text = "";
		FotoProfilo.Text += "<img src = 'GestoreFotoSanitari.ashx?c=" + sessione + "' style='width:80px; border-radius: 50%; margin-left: 10px;'>";
	}
}
