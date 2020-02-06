using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;


public partial class vistas_forms_material_deportivo : System.Web.UI.Page
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
        if (validate())
        {
            con = new Conexion(false);
            if (con.insert("insert into dbo.s_material_deportivo values (" + Convert.ToInt32(Session["idAlumno"]) + ", " + Tipo_art_dep.SelectedValue + ","
                + " '" + txtCant.Value+ "',"+ txtTime.Value + " , " + dSolicitud.SelectedValue + ",'" + DateTime.Today.ToString("yyyy-MM-dd") + "','"+fechaReservacion.Value+"');"))
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

    private bool validate() {
        bool pass = true;

        if (txtCant.Value == "") {
            error1.Text = "Debe haber al menos un Elemento";
            pass = false;
        } else { error1.Text = ""; }

        if (txtTime.Value == "") {
            error2.Text = "Debe haber al menos un Elemento";
            pass = false;
        } else { error2.Text = ""; }

        return pass;

    }

}