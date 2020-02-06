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

    string cod_beca=null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Nombre"] != null && Session["Apellido"] != null)
            {
                txtAlumno.Text = Session["Nombre"].ToString() + " " + Session["Apellido"];
            }

           
        }

       
    }

    protected void enviar_Click(object sender, EventArgs e)
    {

        int cod_carrera = util.getCodCarreraForAlumno(Convert.ToInt32(Session["idAlumno"]));
        string cedula_al = Session["Cedula"].ToString();
        cod_beca = cod_carrera + "-" + cedula_al;
        decimal iraa = util.getPromedioLapsoAnterior(Convert.ToInt32(Session["idAlumno"]));

        loadFiles();
        string lapso = util.getLapsoActual();
        string today = DateTime.Today.ToString("yyyy-MM-dd");
        string query = new StringBuilder("insert into dbo.solicitud_beca (idAl,tipo_beca,solicitud_beca,carta_compromiso," +
            "foto_carnet,certificacion_notas,socio_economico,constancia_trabajo," +
            "defuncion, doc_residencia, acta_matrimonio, partida_nacimiento, issrl_solicitante," +
            " issrl_conyugue, pago_vivienda, cod_estatus,lapso, fecha_solicitud, cod_beca, renovada,iraa) ")
            .Append("VALUES(" + Session["idAlumno"] + "," + dTipoBeca.SelectedValue + ",'" + beca + "','" + compromiso + "','" + fotocarnet + "','" + notas + "','" + informe
            + "','" + constanciaTrabajo + "','" + constanciaDifuncion + "','" + residencia + "','" + matrimonio + "','" + partidaNacimiento
            + "','" + islrSolicitante + "','" + IslrConyugue + "','" + pagoresidencia + "',1,'"+lapso+"', '"+today+"', '"+cod_beca+"', 'N', '"+iraa.ToString()+"')").ToString();

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

    private void loadFiles()
    {


        string server = "~/files/Becas/" + Session["idAlumno"].ToString() + "/";
        string nombreArchivo;
        string ruta;
        if (!Directory.Exists(Server.MapPath(server)))
        {
            DirectoryInfo di = Directory.CreateDirectory(Server.MapPath(server));
        }
        if (doc_beca.HasFile)
        {
            nombreArchivo = doc_beca.FileName;
            ruta = server + nombreArchivo;
            doc_beca.SaveAs(Server.MapPath(ruta));
            beca = server + nombreArchivo;
        }

        if (doc_compromiso.HasFile)
        {
            nombreArchivo = doc_compromiso.FileName;
            ruta = server + nombreArchivo;
            doc_compromiso.SaveAs(Server.MapPath(ruta));
            compromiso = server + nombreArchivo;
        }

        if (doc_constanciaDifuncion.HasFile)
        {
            nombreArchivo = doc_constanciaDifuncion.FileName;
            ruta = server + nombreArchivo;
            doc_constanciaDifuncion.SaveAs(Server.MapPath(ruta));
            constanciaDifuncion = server + nombreArchivo;
        }

        if (doc_constanciaTrabajo.HasFile)
        {
            nombreArchivo = doc_constanciaTrabajo.FileName;
            ruta = server + nombreArchivo;
            doc_constanciaTrabajo.SaveAs(Server.MapPath(ruta));
            constanciaTrabajo = server + nombreArchivo;
        }

        if (doc_fotocarnet.HasFile)
        {
            nombreArchivo = doc_fotocarnet.FileName;
            ruta = server + nombreArchivo;
            doc_fotocarnet.SaveAs(Server.MapPath(ruta));
            fotocarnet = server + nombreArchivo;
        }

        if (doc_informe.HasFile)
        {
            nombreArchivo = doc_informe.FileName;
            ruta = server + nombreArchivo;
            doc_informe.SaveAs(Server.MapPath(ruta));
            informe = server + nombreArchivo;
        }

        if (doc_IslrConyugue.HasFile)
        {
            nombreArchivo = doc_IslrConyugue.FileName;
            ruta = server + nombreArchivo;
            doc_IslrConyugue.SaveAs(Server.MapPath(ruta));
            IslrConyugue = server + nombreArchivo;
        }

        if (doc_matrimonio.HasFile)
        {
            nombreArchivo = doc_matrimonio.FileName;
            ruta = server + nombreArchivo;
            doc_matrimonio.SaveAs(Server.MapPath(ruta));
            matrimonio = server + nombreArchivo;
        }

        if (doc_notas.HasFile)
        {
            nombreArchivo = doc_notas.FileName;
            ruta = server + nombreArchivo;
            doc_notas.SaveAs(Server.MapPath(ruta));
            notas = server + nombreArchivo;
        }

        if (doc_pagoresidencia.HasFile)
        {
            nombreArchivo = doc_pagoresidencia.FileName;
            ruta = server + nombreArchivo;
            doc_pagoresidencia.SaveAs(Server.MapPath(ruta));
            pagoresidencia = server + nombreArchivo;
        }

        if (doc_partidaNacimiento.HasFile)
        {
            nombreArchivo = doc_partidaNacimiento.FileName;
            ruta = server + nombreArchivo;
            doc_partidaNacimiento.SaveAs(Server.MapPath(ruta));
            partidaNacimiento = server + nombreArchivo;
        }

        if (doc_residencia.HasFile)
        {
            nombreArchivo = doc_residencia.FileName;
            ruta = server + nombreArchivo;
            doc_residencia.SaveAs(Server.MapPath(ruta));
            residencia = server + nombreArchivo;
        }
        if (doc_IstlSolicitante.HasFile)
        {
            nombreArchivo = doc_IstlSolicitante.FileName;
            ruta = server + nombreArchivo;
            doc_IstlSolicitante.SaveAs(Server.MapPath(ruta));
            islrSolicitante = server + nombreArchivo;
        }

    }
}