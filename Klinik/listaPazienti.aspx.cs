using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.CodeDom;

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CaricaGrigliaFiltri();
    }
    
    protected void CaricaGrigliaFiltri()
    {
        CONNESSIONE con = new CONNESSIONE();


        if (txtFiltroUsrMail.Text != "")
        {
            con.AddParametro("@UserMail", txtFiltroUsrMail.Text.Trim());
        }
        else
        {
            con.AddParametro("@UserMail");
        }
        if (txtFiltroCodFiscale.Text != "")
        {
            con.AddParametro("@CodFiscale", txtFiltroCodFiscale.Text.Trim());
        }
        else
        {
            con.AddParametro("@CodFiscale");
        }
        if (txtFiltroNominativo.Text != "")
        {
            con.AddParametro("@NominativoPaziente", txtFiltroNominativo.Text.Trim());
        }
        else
        {
            con.AddParametro("@NominativoPaziente");
        }
        con.Select("PAZIENTI_SelectFiltri");

        gridPazienti.DataSource = con.dt;
        gridPazienti.DataBind();
    }


    protected void gridPazienti_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridPazienti.PageIndex = e.NewPageIndex;
        CaricaGrigliaFiltri();
    }
}

