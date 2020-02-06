using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class vistas_maestras_tipo_beca : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void button_reg_Click(object sender, EventArgs e)
    {
        Conexion con = new Conexion(false);
        if (con.insert("insert into dbo.tipo_beca values('" + desc_beca.Text.ToUpper() + "');"))
        {
            Mensaje.Text = "Registro Guardado";
            Mensaje.ForeColor = Color.Green;
            desc_beca.Text = "";
        }
        else { Mensaje.Text = "Error al Guardar"; Mensaje.ForeColor = Color.Red; }
    }
}