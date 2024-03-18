using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPagePaziente : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblNome.Text = "Benvenuto " + Session["USR"];
        }
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session["idPaziente"] = "";
        Response.Redirect("Login.aspx");
    }
}
