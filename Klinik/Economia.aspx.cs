using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;


public partial class Default2 : System.Web.UI.Page
{
	/// <summary>
	/// inserisce i dati delle prestazioni chiuse e le filtra per giorno nella griglia 
	/// </summary>
	/// 
	
	DateTime _data;
	protected void GrigliaPrestazioniEconomia()
	{
		CONNESSIONE co = new CONNESSIONE();

		co.AddParametro("@idSanitario", int.Parse(Session["idSanitario"].ToString()));
		if (DateTime.TryParse(CalendarioFiltro.Text, out DateTime dataparsificata))
		{
			co.AddParametro("@DataPrestazione", dataparsificata);
		}
		else
		{
			co.AddParametro("@DataPrestazione");
		}
		co.Select("SANITARI_PrestazioniChiuse");



		GrigliaPrestazioni.DataSource = co.dt;
		GrigliaPrestazioni.DataBind();

		if(IsPostBack)
		{
			if (co.dt.Rows.Count == 0)
			{
				//NessunDato.Visible = true;
				Page.ClientScript.RegisterStartupScript(this.GetType(), "Errore", "alert('Nessun Dato Trovato'); window.location.href = 'Economia.aspx'", true);
			}
		}
		
	}

	/// <summary>
	/// inserisce nella textbox dei ricavi la somma degli stessi e li filtra anche per giorno
	/// </summary>
	protected void PrestazioniRicavi()
	{
		CONNESSIONE co = new CONNESSIONE();

		co.AddParametro("@idSanitario", int.Parse(Session["idSanitario"].ToString()));
		if (DateTime.TryParse(CalendarioFiltro.Text, out DateTime dataparsificata))
		{
			co.AddParametro("@DataPrestazione", dataparsificata);
		}
		else
		{
			co.AddParametro("@DataPrestazione");
		}
		co.Select("SANITARI_TotaliRicavi");

		string ricavi = decimal.Parse(co.dt.Rows[0]["TotaleRicavo"].ToString()).ToString("C2", CultureInfo.GetCultureInfo("it-IT"));

		//correggere se necessario il nome del campo della tabella in RicavoSanitario
		TxtRicavi.Text = ricavi;
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (IsPostBack) { return; }
		GrigliaPrestazioniEconomia();
		PrestazioniRicavi();					
		CalendarioFiltro.Text = DateTime.Now.ToString("yyyy-MM");
		
	}

	protected void VoltaPagina(object sender, GridViewPageEventArgs e)
	{
		GrigliaPrestazioni.PageIndex = e.NewPageIndex;
		Page_Load(sender, e);
	}


	protected void CalendarioFiltro_TextChanged(object sender, EventArgs e)
	{
		//NessunDato.Visible = false;
		GrigliaPrestazioniEconomia();
		PrestazioniRicavi();
		
	}

	//per andare avanti di un mese
	protected void Mesepiu_Click(object sender, EventArgs e)
	{
		_data = DateTime.Parse(CalendarioFiltro.Text);
		DateTime dataSuccessiva = _data.AddMonths(1);
		CalendarioFiltro.Text = dataSuccessiva.ToString("yyyy-MM");

	}

	//per andare indietro di un mese
	protected void Mesemeno_Click(object sender, EventArgs e)
	{
		_data = DateTime.Parse(CalendarioFiltro.Text);
		DateTime dataSuccessiva = _data.AddMonths(-1);
		CalendarioFiltro.Text = dataSuccessiva.ToString("yyyy-MM");

	}
}