using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Drawing;

public partial class vistas_forms_becas : System.Web.UI.Page
{
    string ruta;
    string residencia = null;
    string partidaNacimiento = null;
    string pagoresidencia = null;
    string notas = null;
    string matrimonio = null;
    string IslrConyugue = null;
    string informe = null;
    string fotocarnet = null;
    string constanciaTrabajo = null;
    string constanciaDifuncion = null;
    string compromiso = null;
    string beca = null;
    string islrSolicitante = null;

    string cod_beca = null;

    int id_beca;

    Conexion con;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Nombre"] != null && Session["Apellido"] != null)
            {
                txtAlumno.Text = Session["Nombre"].ToString() + " " + Session["Apellido"];
            }

            string query = "select * from dbo.solicitud_beca where idAl=" + Session["idAlumno"] + " and lapso='" + util.getLapsoAnterior() + "' and cod_estatus=3;";
            con = new Conexion(false);

            if (Convert.ToInt32(con.buscar(query).Tables[0].Rows.Count) > 0)
            {
                id_beca = Convert.ToInt32(con.buscar(query).Tables[0].Rows[0]["cod_solicitud_beca"]);
                periodo_Anterior.Text = util.getLapsoAnterior();

                dTipoBeca.SelectedIndex = Convert.ToInt32(con.buscar(query).Tables[0].Rows[0]["tipo_beca"]);
                cod_beca = con.buscar(query).Tables[0].Rows[0]["cod_beca"].ToString();
                cod_ant.Text = cod_beca;
            }
            else
            {
                Mensaje.ForeColor = Color.Red;
                Mensaje.Text = "Usted no posee Beca previa aprobada, intente solicitando una beca nueva.";
                enviar.Visible = false;
            }

        }


    }

    protected void enviar_Click(object sender, EventArgs e)
    {
        string buscqueda = "select * from dbo.solicitud_beca where idAl=" + Session["idAlumno"] + " and lapso='" + util.getLapsoAnterior() + "' and cod_estatus=3;";
        con = new Conexion(false);

        DataSet data = con.buscar(buscqueda);

        if (Convert.ToInt32(data.Tables[0].Rows[0]["cod_solicitud_beca"]) > 0)
        {
            id_beca = Convert.ToInt32(data.Tables[0].Rows[0]["cod_solicitud_beca"]);

            residencia = data.Tables[0].Rows[0]["doc_residencia"].ToString();
            partidaNacimiento = data.Tables[0].Rows[0]["partida_nacimiento"].ToString();
            pagoresidencia = data.Tables[0].Rows[0]["pago_vivienda"].ToString();
            notas = data.Tables[0].Rows[0]["certificacion_notas"].ToString();
            matrimonio = data.Tables[0].Rows[0]["acta_matrimonio"].ToString();
            IslrConyugue = data.Tables[0].Rows[0]["issrl_conyugue"].ToString();
            informe = data.Tables[0].Rows[0]["socio_economico"].ToString();
            fotocarnet = data.Tables[0].Rows[0]["foto_carnet"].ToString();
            constanciaTrabajo = data.Tables[0].Rows[0]["constancia_trabajo"].ToString();
            constanciaDifuncion = data.Tables[0].Rows[0]["defuncion"].ToString();
            compromiso = data.Tables[0].Rows[0]["carta_compromiso"].ToString();
            beca = data.Tables[0].Rows[0]["solicitud_beca"].ToString();
            islrSolicitante = data.Tables[0].Rows[0]["issrl_solicitante"].ToString();


            cod_beca = data.Tables[0].Rows[0]["cod_beca"].ToString();
        }

        string lapso = util.getLapsoActual();
        string today = DateTime.Today.ToString("yyyy-MM-dd");
        string query = new StringBuilder("insert into dbo.solicitud_beca (idAl,tipo_beca,solicitud_beca,carta_compromiso," +
            "foto_carnet,certificacion_notas,socio_economico,constancia_trabajo," +
            "defuncion, doc_residencia, acta_matrimonio, partida_nacimiento, issrl_solicitante," +
            " issrl_conyugue, pago_vivienda, cod_estatus,lapso, fecha_solicitud, cod_beca, renovada) ")
            .Append("VALUES(" + Session["idAlumno"] + "," + dTipoBeca.SelectedValue + ",'" + beca + "','" + compromiso + "','" + fotocarnet + "','" + notas + "','" + informe
            + "','" + constanciaTrabajo + "','" + constanciaDifuncion + "','" + residencia + "','" + matrimonio + "','" + partidaNacimiento
            + "','" + islrSolicitante + "','" + IslrConyugue + "','" + pagoresidencia + "',1,'" + lapso + "', '" + today + "', '" + cod_beca + "', 'S')").ToString();

        con = new Conexion(false);
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
            enviar.Enabled = false;
            con.close();
        }
    }

}