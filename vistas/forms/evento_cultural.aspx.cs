using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class vistas_forms_evento_cultural : System.Web.UI.Page
{

    Conexion con;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Nombre"] != null && Session["Apellido"] != null && Session["accion"] == null && Session["ReposoID"] == null)
            {
                txtAlumno.Text = Session["Nombre"].ToString() + " " + Session["Apellido"];
            }
        }

    }

    protected void enviarBtn_click(object sender, EventArgs e)
    {
        if (validate()) {
            con = new Conexion(false);
            if (con.insert("insert into dbo.solicitud_evento_cult values (" + Convert.ToInt32(Session["idAlumno"]) + ", " + Tipo_Evento.SelectedValue + ","
                + " '" + txtDescripcion.Text + "', " + dSolicitud.SelectedValue + ",'" + DateTime.Today.ToString("yyyy-MM-dd") + "');"))
            {
                Mensaje.ForeColor = Color.Green;
                Mensaje.Text = "Registro Guardado";
                con.close();
            }
            else
            {
                Mensaje.ForeColor = Color.Red;
                Mensaje.Text = "Error al Guardar Registro";
                con.close();
            }
        }

    }

    private bool validate()
    {
        bool pass = true;

        if (txtDescripcion.Text == "" || txtDescripcion.Text == null)
        {
            error1.Text = "Debe Describir el Evento";
            pass = false;
        }
        else { error1.Text = ""; }

        return pass;
    }
}