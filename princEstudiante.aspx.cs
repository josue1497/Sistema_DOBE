using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class princEstudiante : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Conexion con = new Conexion(false);
        DataSet result = con.buscar("select count(cod_historial_medico) as a from historial_medico where idAl=" + Session["idAlumno"].ToString()+";");
        string a = result.Tables[0].Rows[0][0].ToString();
        if (!(int.Parse(a)>0)) {
            Response.Redirect("hmedico.aspx");
        }else { 


        if (Session["Nombre"] == null)
        {
            Response.Redirect("/login.aspx");
        }
        if (Session["Nombre"]!=null) {
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
        if (Session["Escuela"] != null)
        {
            escuela.Text = Session["Escuela"].ToString();

        }
        }


    }
}