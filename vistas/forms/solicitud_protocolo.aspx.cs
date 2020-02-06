using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.IO;

using System.Data.SqlClient;
using System.Configuration;

public partial class reposos : System.Web.UI.Page
{
    string filePath = "";
    Conexion con;
    DataSet result;
    string consulta;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           if (Session["Nombre"] != null && Session["Apellido"] != null)
            {
                NombreyApellido.Text = Session["Nombre"].ToString() + " " + Session["Apellido"];

                con = new Conexion(false);
                result = con.buscar("select cod_estatus codigo, estatus as estatus from estatus_solicitud where cod_estatus=1");
                estatusReposo.DataSource = result;
                estatusReposo.DataTextField = result.Tables[0].Columns["estatus"].ToString();
                estatusReposo.DataValueField = result.Tables[0].Columns["codigo"].ToString();
                estatusReposo.DataBind();
            }
        }
    }

    protected void enviarBtn_click(object sender, EventArgs e)
    {
        if (validate())
        {
           
            Conexion con = new Conexion(false);
            con.guardar("insert into dbo.solicitud_protocolo values (@alumno,@fotocarnet,@talla_camisa,@talla_pantalon,@talla_zapato,@telefono,@direccion, @estatus,@lapso);");

            con.Comando.Parameters.Add("@alumno", SqlDbType.Int).Value = Session["idAlumno"];
            con.Comando.Parameters.Add("@fotocarnet", SqlDbType.VarChar).Value = filePath;
            con.Comando.Parameters.Add("@talla_camisa", SqlDbType.VarChar).Value = tallaCamisa.Text;
            con.Comando.Parameters.Add("@talla_pantalon", SqlDbType.VarChar).Value = tallaPantalon.Text;
            con.Comando.Parameters.Add("@talla_zapato", SqlDbType.VarChar).Value = tallaZapatos.Text;
            con.Comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = telefono.Text;
            con.Comando.Parameters.Add("@direccion", SqlDbType.VarChar).Value = direccion.Text;
            con.Comando.Parameters.Add("@estatus", SqlDbType.Int).Value = Convert.ToInt32(estatusReposo.SelectedValue);
            con.Comando.Parameters.Add("@lapso", SqlDbType.VarChar).Value = util.getLapsoActual();


            if (con.Comando.ExecuteNonQuery() > 0)
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
       
        if (fotoCarnet.HasFile)
        {
            
            string nombreArchivo = fotoCarnet.FileName;
            string server = "~/files/Protocolo/"+ Session["idAlumno"] + "/";
            if (!Directory.Exists(Server.MapPath(server)))
            {
                DirectoryInfo di = Directory.CreateDirectory(Server.MapPath(server));
            }
            string ruta = server + nombreArchivo;
            fotoCarnet.SaveAs(Server.MapPath(ruta));
            filePath = server + nombreArchivo;
        }

        return pass;
    }
}