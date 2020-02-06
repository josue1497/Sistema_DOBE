using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class registrarmedicos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }


    protected void guardarBtn_click(object sender, EventArgs e)
    {
        
            Conexion con = new Conexion(false);
            if (con.insert("insert into dbo.personal_administrativo values('" + txtCedula.Text + "','"+txtNombre.Text+ "','" + txtApellido.Text + "','" + txtTelf.Text + "','" + txtDireccion.Text + "',"+
                ""+dGenero.SelectedValue+","+dCargo.SelectedValue+",'"+ txtPass.Text + "');"))
            {
                Mensaje.ForeColor = Color.Green;
                Mensaje.Text = "Registro Guardado";
            }
            else {
                Mensaje.ForeColor = Color.Red;
                Mensaje.Text = "Error al Guardar Registro";
            }
        
    }

 
}