using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class vistas_forms_AfiliacionEquipos : System.Web.UI.Page
{
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

    protected void enviar_Click(object sender, EventArgs e)
    {
        if (validate())
        {
            Conexion con = new Conexion(false);
            if (con.insert("insert into dbo.solicitud_afiliacion values (" + Convert.ToInt32(Session["idAlumno"]) + ", " + equipo.SelectedValue + ","
                + " '" + txtMotivo.Text + "', " + dSolicitud.SelectedValue + ",'" + DateTime.Today.ToString("yyyy-MM-dd") + "');"))
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

        if (txtMotivo.Text == "" || txtMotivo.Text == null)
        {
            error1.Text = "Debe Destacar un Motivo";
            pass = false;
        }
        else { error1.Text = ""; }

        return pass;
    }
}