using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data;
using System.Drawing;
public partial class hmedico : System.Web.UI.Page
{

    Conexion con;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["ID"] != null)
            {
                Nombres.Text = Session["Apellido"] + " " + Session["Nombre"];
            }
            else
            {
                Response.Redirect("princ_docente.aspx");
            }
        }
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        con = new Conexion(false);

        string inserting = "insert into dbo.motivo_visita values (" + Convert.ToInt32(Session["ID"]) + ",'" + Titulo.Text + "'," + motivo.SelectedValue + ",'" + fecha.Value + "', 'S')";

        if (con.insert(inserting))
        {
            Mensaje.ForeColor = Color.Green;
            Mensaje.Text = "Registro Guardado";
           

        }
        else
        {
            Mensaje.Text = "Error al Guardar Registro";
            Mensaje.ForeColor = Color.Red;
        }
    }

    protected void btnSalir_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
}