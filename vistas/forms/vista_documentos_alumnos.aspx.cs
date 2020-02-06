using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.IO;

public partial class vistas_forms_coral_banda : System.Web.UI.Page
{

    Conexion con;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            solicitud_beca.NavigateUrl = Session["solicitud_beca"].ToString();
            carta_compromiso.NavigateUrl = Session["carta_compromiso"].ToString();

            foto_carnet.NavigateUrl = Session["foto_carnet"].ToString();
            certificacion_notas.NavigateUrl = Session["certificacion_notas"].ToString();

            socio_economico.NavigateUrl = Session["socio_economico"].ToString();
            constancia_trabajo.NavigateUrl = Session["constancia_trabajo"].ToString();

            defuncion.NavigateUrl = Session["defuncion"].ToString();
            doc_residencia.NavigateUrl = Session["doc_residencia"].ToString();

            acta_matrimonio.NavigateUrl = Session["acta_matrimonio"].ToString();
            partida_nacimiento.NavigateUrl = Session["partida_nacimiento"].ToString();

            isrl_solicitante.NavigateUrl = Session["issrl_solicitante"].ToString();
            isrl_conyugue.NavigateUrl = Session["issrl_conyugue"].ToString();

            pago_vivienda.NavigateUrl = Session["pago_vivienda"].ToString();
        }

    }



    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("../estudiantes_mod/beca.aspx");
    }

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        string server = "~/files/Becas/" + Session["idAlumno"].ToString() + "/";

        int id = Convert.ToInt32(Session["id_beca"]);
        bool error = true;

        if (fsolicitud_beca.HasFile)
        {
            con = new Conexion(false);
            error = con.update("update dbo.solicitud_beca set  solicitud_beca = '" + loadFile(server, solicitud_beca, fsolicitud_beca) + "' where cod_solicitud_beca=" + id);
            if (!error)
            {
                Mensaje.ForeColor = Color.Red;
                Mensaje.Text = "Ha ocurrido un Error";
                return;
            }
        }
        if (fcarta_compromiso.HasFile)
        {
            con = new Conexion(false);
            error = con.update("update dbo.solicitud_beca set  carta_compromiso = '" + loadFile(server, carta_compromiso, fcarta_compromiso) + "' where cod_solicitud_beca=" + id);
            if (!error)
            {
                Mensaje.ForeColor = Color.Red;
                Mensaje.Text = "Ha ocurrido un Error";
                return;
            }
        }
        if (ffoto_carnet.HasFile)
        {
            con = new Conexion(false);
            error = con.update("update dbo.solicitud_beca set  foto_carnet = '" + loadFile(server, foto_carnet, ffoto_carnet) + "' where cod_solicitud_beca=" + id);
            if (!error)
            {
                Mensaje.ForeColor = Color.Red;
                Mensaje.Text = "Ha ocurrido un Error";
                return;
            }
        }
        if (fcertificacion_notas.HasFile)
        {
            con = new Conexion(false);
            error = con.update("update dbo.solicitud_beca set  certificacion_notas = '" + loadFile(server, certificacion_notas, fcertificacion_notas) + "' where cod_solicitud_beca=" + id);
            if (!error)
            {
                Mensaje.ForeColor = Color.Red;
                Mensaje.Text = "Ha ocurrido un Error";
                return;
            }
        }
        if (fsocio_economico.HasFile)
        {
            con = new Conexion(false);
            error = con.update("update dbo.solicitud_beca set  socio_economico = '" + loadFile(server, socio_economico, fsocio_economico) + "' where cod_solicitud_beca=" + id);
            if (!error)
            {
                Mensaje.ForeColor = Color.Red;
                Mensaje.Text = "Ha ocurrido un Error";
                return;
            }
        }
        if (fconstancia_trabajo.HasFile)
        {
            con = new Conexion(false);
            error = con.update("update dbo.solicitud_beca set  constancia_trabajo = '" + loadFile(server, constancia_trabajo, fconstancia_trabajo) + "' where cod_solicitud_beca=" + id);
            if (!error)
            {
                Mensaje.ForeColor = Color.Red;
                Mensaje.Text = "Ha ocurrido un Error";
                return;
            }
        }
        if (fdefuncion.HasFile)
        {
            con = new Conexion(false);
            error = con.update("update dbo.solicitud_beca set  defuncion = '" + loadFile(server, defuncion, fdefuncion) + "' where cod_solicitud_beca=" + id);
            {
                Mensaje.ForeColor = Color.Red;
                Mensaje.Text = "Ha ocurrido un Error";
                return;
            }
        }
        if (fdoc_residencia.HasFile)
        {
            con = new Conexion(false);
            error = con.update("update dbo.solicitud_beca set  doc_residencia = '" + loadFile(server, doc_residencia, fdoc_residencia) + "' where cod_solicitud_beca=" + id);
            if (!error)
            {
                Mensaje.ForeColor = Color.Red;
                Mensaje.Text = "Ha ocurrido un Error";
                return;
            }
        }
        if (facta_matrimonio.HasFile)
        {
            con = new Conexion(false);
            error = con.update("update dbo.solicitud_beca set  acta_matrimonio = '" + loadFile(server, acta_matrimonio, facta_matrimonio) + "' where cod_solicitud_beca=" + id);
            if (!error)
            {
                Mensaje.ForeColor = Color.Red;
                Mensaje.Text = "Ha ocurrido un Error";
                return;
            }
        }
        if (fpago_vivienda.HasFile)
        {
            con = new Conexion(false);
            error = con.update("update dbo.solicitud_beca set  pago_vivienda = '" + loadFile(server, pago_vivienda, fpago_vivienda) + "' where cod_solicitud_beca=" + id);
            if (!error)
            {
                Mensaje.ForeColor = Color.Red;
                Mensaje.Text = "Ha ocurrido un Error";
                return;
            }
        }
        if (fisrl_solicitante.HasFile)
        {
            con = new Conexion(false);
            error = con.update("update dbo.solicitud_beca set  issrl_solicitante = '" + loadFile(server, isrl_solicitante, fisrl_solicitante) + "' where cod_solicitud_beca=" + id);
            if (!error)
            {
                Mensaje.ForeColor = Color.Red;
                Mensaje.Text = "Ha ocurrido un Error";
                return;
            }
        }
        if (fisrl_conyugue.HasFile)
        {
            con = new Conexion(false);
            error = con.update("update dbo.solicitud_beca set  issrl_conyugue = '" + loadFile(server, isrl_conyugue, fisrl_conyugue) + "' where cod_solicitud_beca=" + id);
            if (!error)
            {
                Mensaje.ForeColor = Color.Red;
                Mensaje.ForeColor = Color.Red;
                Mensaje.Text = "Ha ocurrido un Error";
                return;
            }
        }
        if (fpago_vivienda.HasFile)
        {
            con = new Conexion(false);
            error = con.update("update dbo.solicitud_beca set  pago_vivienda = '" + loadFile(server, pago_vivienda, fpago_vivienda) + "' where cod_solicitud_beca=" + id);
            if (!error)
            {
                Mensaje.ForeColor = Color.Red;
                Mensaje.Text = "Ha ocurrido un Error";
                return;
            }
        }


        if (error)
        {
            Mensaje.ForeColor = Color.Green;
            Mensaje.Text = "Actualización Exitosa";
            Response.Redirect("../estudiantes_mod/beca.aspx");
        }
    }

    private string loadFile(string ruta, HyperLink file1, FileUpload file2)
    {
        string result = "";
        string archivo = file2.FileName;
        if (Directory.Exists(Server.MapPath(ruta)))
        {
            result = ruta + archivo;
            file2.SaveAs(Server.MapPath(result));
            if (!"".Equals(file1.NavigateUrl))
                File.Delete(Server.MapPath(file1.NavigateUrl));
        }

        return result;
    }
}