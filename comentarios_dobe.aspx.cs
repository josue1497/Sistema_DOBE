using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class comentarios__dobe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Conexion con = new Conexion(false);
        string query = "select A.asunto as Asunto, A.mensaje as Mensaje, B.Fullnombre Nombre from dbo.comentarios A inner join PRDPSMVAL.dbo.Alumnos B on (A.idAl=B.IdAl);";

        DataTable data =con.search(query);

        foreach (DataRow row in data.Rows) {
            contenido.Controls.Add(new LiteralControl("<hr />"));
            Label Asunto = new Label();
            Asunto.Text ="<b>Asunto:</b> "+ row["Asunto"].ToString();
            contenido.Controls.Add(Asunto);
            contenido.Controls.Add(new LiteralControl("<br />"));
            Label Mensaje = new Label();
            Mensaje.Text ="<b>Mensaje:</b> "+ row["Mensaje"].ToString();
            contenido.Controls.Add(Mensaje);
            contenido.Controls.Add(new LiteralControl("<br />"));
            Label Alumno = new Label();
            Alumno.Text ="<b>Alumno: </b>"+ row["Nombre"].ToString();
            contenido.Controls.Add(Alumno);
            contenido.Controls.Add(new LiteralControl("<br />"));
        }

    }



    protected void inicio_Click(object sender, EventArgs e)
    {
        if ("Secretaria".Equals(Session["Cargo"].ToString()))
        {
            Response.Redirect("princ_secretaria.aspx");

        }
        if ("Administrador".Equals(Session["Cargo"].ToString()))
        {
            Response.Redirect("princ_admin.aspx");

        }
        if ("Jefe Dobe".Equals(Session["Cargo"].ToString()))
        {
            Response.Redirect("princ_Dobe.aspx");

        }
    }
}