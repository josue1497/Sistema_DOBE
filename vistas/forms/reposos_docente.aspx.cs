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


                medicoList.SelectedIndex = -1;


                periodo.Text = util.getLapsoActual();

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
            con.guardar("insert into reposo values (@alumno,@codigoReposo,@fechaini,@fechafin,@documento,@medico,@periodo, @estatus,@patologia,@personal,@docente);");

            con.Comando.Parameters.Add("@alumno", SqlDbType.Int).Value = Session["ID"];
            con.Comando.Parameters.Add("@codigoReposo", SqlDbType.Int).Value = TipoReposo.SelectedValue;
            con.Comando.Parameters.Add("@fechaini", SqlDbType.Date).Value = fechaInicio.Value;
            con.Comando.Parameters.Add("@fechafin", SqlDbType.Date).Value = fechaFin.Value;
            con.Comando.Parameters.Add("@documento", SqlDbType.VarChar).Value = filePath;
            con.Comando.Parameters.Add("@medico", SqlDbType.VarChar).Value = medicoList.SelectedValue;
            con.Comando.Parameters.Add("@periodo", SqlDbType.VarChar).Value = periodo.Text;
            con.Comando.Parameters.Add("@estatus", SqlDbType.VarChar).Value = estatusReposo.Text;
            con.Comando.Parameters.Add("@patologia", SqlDbType.VarChar).Value = patologia.Text;
            con.Comando.Parameters.Add("@personal", SqlDbType.VarChar).Value = "N";
            con.Comando.Parameters.Add("@docente", SqlDbType.VarChar).Value = "S";


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
        if (fechaInicio.Value == "")
        {
            error1.Text = "Seleccione una facha del Calendario.";
            pass = false;
        }
        else { error1.Text = ""; }
        if (fechaFin.Value == "")
        {
            error2.Text = "Seleccione una facha del Calendario.";
            pass = false;
        }
        else { error2.Text = ""; }
        if (!reposoFile.HasFile)
        {
            error3.Text = "Seleccione un documento que respalde su Solicitud.";
            pass = false;
        }
        else
        {
            error3.Text = "";
            string nombreArchivo = reposoFile.FileName;
            string server = "~/files/Reposos/";
            if (!Directory.Exists(Server.MapPath(server)))
            {
                DirectoryInfo di = Directory.CreateDirectory(Server.MapPath(server));
            }
            string ruta = server + nombreArchivo;
            reposoFile.SaveAs(Server.MapPath(ruta));
            filePath = server + nombreArchivo;
        }

        return pass;
    }
}