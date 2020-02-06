using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class vistas_forms_registrar_usuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void enviar_Click(object sender, EventArgs e)
    {
        if (validate()) {
            string query = "insert into dbo.usuarios VALUES('"+txtNombre.Text+"','"+txtApellido.Text+"', "+Convert.ToInt32(txtCI.Text)+
                ", '"+txtTelf.Value+ "', " + Convert.ToInt32(txtEdad.Text) + ", " + Convert.ToInt32(sexo.SelectedValue) + ",'"+txtEmail.Value+
                "','" + txtUs.Text +"', '"+txtPass.Text+"','"+rol.SelectedItem+"', 'Habilitado', '"+DateTime.Today.ToString("yyyy-MM-dd")+"');";

            Conexion con = new Conexion(false);

            if (con.insert(query))
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

        if (!txtPass.Text.Equals(txtPassConfirm.Text)) {
            Error1.Text = "Contraseñas Suministradas No Coinciden";
            pass = false;
        }
        if (rol.SelectedIndex == 0) {
            Error3.Text = "Debe Seleccionar un Rol";
            pass = false;
        }

        return pass;
    }
}