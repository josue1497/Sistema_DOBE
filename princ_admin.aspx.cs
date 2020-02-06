using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class princ_admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Nombre"] == null)
        {
            Response.Redirect("/login.aspx");
        }
        if (Session["Nombre"] != null)
        {
            nombre.Text = Session["Nombre"].ToString();
        }
        if (Session["Apellido"] != null)
        {
            apellido.Text = Session["Apellido"].ToString();
        }
        if (Session["Cedula"] != null)
        {
            cedula.Text = Session["Cedula"].ToString();
        }
        if (Session["Email"] != null)
        {
            email.Text = Session["Email"].ToString();

        }
        if (Session["Telefono"] != null)
        {
            telefono.Text = Session["Telefono"].ToString();

        }
        if (Session["Cargo"] != null)
        {
            cargo.Text = Session["Cargo"].ToString();

        }


    }
}