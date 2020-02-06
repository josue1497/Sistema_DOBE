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
        if (validate()) {
            Conexion con = new Conexion(false);
            if (con.insert("insert into medico values('"+ txtPrima.Text + "','"+txtNombre.Text+ "','" + txtApellido.Text + "','" + txtTelf.Text + "','" + textEmail.Text + "');"))
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

    private bool validate() {
        bool pass = true;
        if (txtPrima.Text == "")
        {
            error2.Text = "Ingrese Una prima Valida vinvulada a su Medico";
            pass = false;
        }
        if (txtApellido.Text == "") {
            error2.Text = "Ingrese El apellido de su Medico";
            pass = false;
        }
        if (txtNombre.Text == "")
        {
            error1.Text = "Ingrese El Nombre de su Medico";
            pass = false;

        }
        if (txtTelf.Text == "")
        {
            error3.Text = "Ingrese El Telf de su Medico";
            pass = false;
        }
        if (textEmail.Text == "")
        {
            error4.Text = "Ingrese El Email de su Medico";
            pass = false;
        }

        return pass;
    }
}