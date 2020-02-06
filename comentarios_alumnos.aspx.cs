using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class comentarios_alumnos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Alumno.Text = Session["Nombre"] + " " + Session["Apellido"];
    }
    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        string Insert = "insert into dbo.comentarios values ('"+Texto.Text+"',"+Session["idAlumno"]+",'"+Asunto.Text+"');";
        Conexion con = new Conexion(false);

        if (con.insert(Insert))
        {
            Mensaje.Text = "Mensaje Enviado";
            Mensaje.ForeColor = Color.Green;
        }
        else {
            Mensaje.Text = "Error al Enviar Mensaje.";
            Mensaje.ForeColor = Color.Red;
        }
    }
}