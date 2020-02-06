using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class login : System.Web.UI.Page
{
    bool login_pass = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Clear();
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (usuario.Text == "")
        {
            Error1.Text = "Debe Ingresar un nombre de Usuario";
        }
        if (password.Text == "")
        {
            Error2.Text = "Debe Ingresar un su contraseña";
        }

        if (rol.SelectedValue == "0")
        {
            Error3.Text = "Seleccione su Rol";
        }


        if (rol.SelectedValue != "0" && usuario.Text != "" && password.Text != "")
        {
            Console.Write("Preparando Conexion");
            Conexion con = null;
            DataSet result = null;
            string query = "";
            string clave = "";

            switch (rol.SelectedValue)
            {
                case "4":
                    con = new Conexion(true);
                    try
                    {
                        result = con.buscar("select  Alumnos.Cedula,Alumnos.Clave clave,(Alumnos.Nombre1+' '+Alumnos.Nombre2) as nombre,(Apellido1+' '+Apellido2)as apellido,Alumnos.Cedula cedula, Alumnos.Email email, Alumnos.IdAl ID,Pensum.carrera carrera, Pensum.ICC as icc "
                            + " from Alumnos inner join Alumnos_Carreras on (alumnos.IdAl = Alumnos_Carreras.IdAl) "
                            + " inner join Pensum on(Pensum.CodCarrera = Alumnos_Carreras.IdCar)"
                            + " where Cedula=" + int.Parse(usuario.Text) + ";");
                        if (result != null && result.Tables[0].Rows.Count > 0)
                            clave = result.Tables[0].Rows[0]["clave"].ToString();
                    }
                    catch (Exception e1)
                    {
                        Console.Write(e1.Message);
                        Mensaje.Text = "Error al Iniciar Sesion - Usuario Invalido";
                    }
                    break;
                case "1": case "2": case "3":
                    con = new Conexion(false);
                   query = "select cod_administrativo ID,us,pass clave,nombre,apellido,ci cedula,email,telefono,tipo_us cargo from dbo.usuarios where dbo.usuarios.us='" + usuario.Text + "'  and tipo_us='" + rol.SelectedItem.Text + "' and estatus='Habilitado';";
                    result = con.buscar(query);
                    if (result != null && result.Tables[0].Rows.Count > 0)
                        clave = result.Tables[0].Rows[0]["clave"].ToString();
                    break;
                case "5":
                    con = new Conexion(true);
                    query = "select IdDoc ID,Id_Docente cedula, Clave clave, Nombre1+' '+Nombre2 nombre, Apellido1+' '+Apellido2 apellido, 'Docente' cargo, Correo email, Telefonos telefono from dbo.Docentes  where Id_Docente=" + Convert.ToInt32(usuario.Text)+" and Activo=1";
                    result = con.buscar(query);
                    if (result != null && result.Tables[0].Rows.Count > 0)
                    {
                        string aux = "";
                        aux = result.Tables[0].Rows[0]["clave"].ToString();
                        clave = aux.Substring(0, 6);
                    }
                    break;
                case "6":
                    con = new Conexion(false);
                    query = "select cod_personal_Administrativo ID, cedula, clave, nombres nombre, apellidos apellido, b.desc_cargo cargo, telefono, direccion email from dbo.personal_administrativo a "+
                        " INNER join dbo.cargo b on (a.cod_cargo=b.cod_cargo)  where a.cedula='" +usuario.Text+"'";
                    result = con.buscar(query);
                    if (result != null && result.Tables[0].Rows.Count >0)
                        clave = result.Tables[0].Rows[0]["clave"].ToString();
                    break;
                default:
                    break;
            }

            
            try
            {
                if (result != null && result.Tables[0].Rows[0]["ID"] != null)
                {

                    login_pass = passValid(clave, password.Text);

                    if (rol.SelectedValue == "4")
                    {
                        Session.Add("idAlumno", result.Tables[0].Rows[0]["ID"].ToString());
                        Session.Add("Escuela", result.Tables[0].Rows[0]["carrera"].ToString());
                        Session.Add("ICC", result.Tables[0].Rows[0]["icc"].ToString());
                    }

                    if (rol.SelectedValue != "4")
                    {
                        Session.Add("Telefono", result.Tables[0].Rows[0]["telefono"].ToString());
                        Session.Add("Cargo", result.Tables[0].Rows[0]["cargo"].ToString());
                    }

                    Session.Add("ID", result.Tables[0].Rows[0]["ID"].ToString());
                    Session.Add("Nombre", result.Tables[0].Rows[0]["nombre"].ToString() != null ? result.Tables[0].Rows[0]["nombre"].ToString() : "");
                    Session.Add("Apellido", result.Tables[0].Rows[0]["apellido"].ToString() != null ? result.Tables[0].Rows[0]["apellido"].ToString() : "");
                    Session.Add("Cedula", result.Tables[0].Rows[0]["cedula"].ToString() != null ? result.Tables[0].Rows[0]["cedula"].ToString() : "");
                    Session.Add("Email", result.Tables[0].Rows[0]["email"].ToString() != null ? result.Tables[0].Rows[0]["email"].ToString() : "");
                    Session.Timeout = 60;
                }

                if (login_pass)
                {
                    Mensaje.Text = "";
                    redirectNextPage(rol.SelectedValue);
                }
                else
                {
                    Error2.Text = "Contraseña de Usuario no Valida";
                }
            }
            catch (Exception e2)
            {
                Mensaje.Text = "Usuario No encontrado.";
            }



        }
    }

    private bool passValid(string truePass, string thisPass)
    {
        return truePass.Equals(thisPass);
    }

    private void redirectNextPage(string userRole)
    {
        switch (userRole)
        {
            case "4":
                Response.Redirect("/princEstudiante.aspx");
                break;
            case "3":
                Response.Redirect("/princ_secretaria.aspx");
                break;
            case "2":
                Response.Redirect("/princ_Dobe.aspx");
                break;
            case "1":
                Response.Redirect("/princ_admin.aspx");
                break;
            case "5":
                Response.Redirect("/princ_docente.aspx");
                break;
            case "6":
                Response.Redirect("/princ_personal.aspx");
                break;
            default:
                return;
        }
    }



}