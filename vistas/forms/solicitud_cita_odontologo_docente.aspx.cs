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

    Conexion con;
    DataSet result;
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
        Conexion con = new Conexion(false);
        con.guardar("insert into dbo.solicitud_cita_odontologo (idAl, motivo, cod_estatus, is_docente, is_personal,periodo_academico) values (@alumno,@motivo,@estatus,@docente, @personal,@lapso);");

        con.Comando.Parameters.Add("@alumno", SqlDbType.Int).Value = Session["ID"];
        con.Comando.Parameters.Add("@motivo", SqlDbType.VarChar).Value = motivo.Text;
        con.Comando.Parameters.Add("@estatus", SqlDbType.Int).Value = Convert.ToInt32(estatusReposo.SelectedValue);
        con.Comando.Parameters.Add("@docente", SqlDbType.VarChar).Value = "S";
        con.Comando.Parameters.Add("@personal", SqlDbType.VarChar).Value = "N";
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