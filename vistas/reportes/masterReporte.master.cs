using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class reportes_masterReporte : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void inicioLink_Click(object sender, EventArgs e)
    {
        switch (Session["Cargo"].ToString()) {
            case "Secretaria":
                Response.Redirect("../../princ_secretaria.aspx");
                break;
            case "Jefe Dobe":
                Response.Redirect("../../princ_Dobe.aspx");
                break;
            case "Administrador":
                Response.Redirect("../../princ_admin.aspx");
                break;
        }
    }
}
