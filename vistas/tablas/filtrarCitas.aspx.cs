﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class vistas_tablas_filtrarSolicitudes : System.Web.UI.Page
{
    const string CITA_PSICOLOGO = " select  DISTINCT(c.Cedula) cedula, a.cod_solicitud_cita_psicologo ID, c.Fullnombre alumno, c.DireccionHabitacion direccion,  " +
        " c.Email email, e.carrera carrera, a.motivo motivo, a.comentario_secretaria observacion, a.cod_estatus cod  " +
         " from dbo.solicitud_cita_psicologo a inner join dbo.estatus_solicitud b on (a.cod_estatus=b.cod_estatus)  " +
        " inner join PRDPSMVAL.dbo.Alumnos c on (a.idAl=c.IdAl) INNER join PRDPSMVAL.dbo.Cargas_Academicas d on (d.IdAl=c.IdAl) " +
        " INNER join PRDPSMVAL.dbo.Pensum e on (d.Icc=e.ICC) ";

    const string CITA_ODONTOLOGO = " select  DISTINCT(c.Cedula) cedula, a.cod_solicitud_cita_odontologo ID, c.Fullnombre alumno, c.DireccionHabitacion direccion,  " +
        " c.Email email, e.carrera carrera, a.motivo motivo, a.comentario_secretaria observacion, a.cod_estatus cod  " +
         " from dbo.solicitud_cita_odontologo a inner join dbo.estatus_solicitud b on (a.cod_estatus=b.cod_estatus)  " +
        " inner join PRDPSMVAL.dbo.Alumnos c on (a.idAl=c.IdAl) INNER join PRDPSMVAL.dbo.Cargas_Academicas d on (d.IdAl=c.IdAl) " +
        " INNER join PRDPSMVAL.dbo.Pensum e on (d.Icc=e.ICC) ";



    string consulta;
    string update;
    string campo;
    Conexion con;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Cargo"] != null)
            {
                consulta = "select cod_estatus codigo, estatus as estatus from estatus_solicitud";
            }

            con = new Conexion(false);
            DataSet result = con.buscar(consulta);
            estatus.DataSource = result;
            estatus.DataTextField = result.Tables[0].Columns["estatus"].ToString();
            estatus.DataValueField = result.Tables[0].Columns["codigo"].ToString();
            estatus.DataBind();
        }
    }

    protected void BtnEditar_Click(object sender, EventArgs e)
    {
        LinkButton BtnEditar = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnEditar.NamingContainer;
        DropDownList control = result_reposos.Rows[row.RowIndex].FindControl("modSolicitud") as DropDownList;
        TextBox indicaciones = result_reposos.Rows[row.RowIndex].FindControl("txtIndicaciones") as TextBox;

        int id = Convert.ToInt32(this.result_reposos.DataKeys[row.RowIndex].Value);
        update = setupdate(SolicitudAFiltrar.SelectedIndex);
        campo = setCampo(SolicitudAFiltrar.SelectedIndex);
        con = new Conexion(false);
        if ("".Equals(indicaciones.Text))
        {
            Mensaje.Text = "Indique Mas información para la cita del Estudiante.";
        }
        else
        {
            if (Session["Cargo"].ToString().Equals("Secretaria") && control.SelectedValue.Equals("2"))
            {
                string query = "update " + update + "  set cod_estatus =" + control.SelectedValue + ",  comentario_secretaria = '" + indicaciones.Text + "'  where " + campo + "=" + id + "";
                if (con.update(query))
                {
                    Response.Redirect("filtrarSolicitudes.aspx");
                }
            }
            else
            {
                Mensaje.Text = "Su rol no tiene autorizacion para realizar esta Accion.";
            }

            if (!Session["Cargo"].ToString().Equals("Secretaria") && !(control.SelectedValue.Equals("2") || control.SelectedValue.Equals("1")))
            {
                string query = "update " + update + "  set cod_estatus =" + control.SelectedValue + " ,  comentario_secretaria = '" + indicaciones.Text + "'  where " + campo + "=" + id + "";
                if (con.update(query))
                {
                    Response.Redirect("filtrarCitas.aspx");
                }
            }
            else
            {
                Mensaje.Text = "Su rol no tiene autorizacion para realizar esta Accion.";
            }
        }




    }

    protected void buscar_Click(object sender, EventArgs e)
    {
        string conCedula = "".Equals(cedulaEstudiante.Value) ? "" : " and c.Cedula='" + cedulaEstudiante.Value + "' ";
        string where = " where a.cod_estatus=" + estatus.SelectedValue + conCedula ;
        consulta = setQuery(SolicitudAFiltrar.SelectedIndex);
        consulta = consulta + where;
        con = new Conexion(false);
        DataTable table = con.search(consulta);
        result_reposos.DataSource = table;
        result_reposos.DataBind();
    }

    public string setQuery(int type)
    {
        string value = "";
        string a = "";
        switch (type)
        {
            case 1:
                a = "dbo.solicitud_cita_odontologo";
                value = CITA_ODONTOLOGO;
                break;
            case 2:
                a = "dbo.solicitud_cita_psicologo";
                value = CITA_PSICOLOGO;
                break;
            default:
                break;
        }
        update = a;
        return value;
    }

    public string setupdate(int type)
    {
        string a = "";
        switch (type)
        {
            case 1:
                a = "dbo.solicitud_cita_odontologo";
                break;
            case 2:
                a = "dbo.solicitud_cita_psicologo";
                break;
            default:
                break;
        }
        return a;
    }

    public string setCampo(int type)
    {
        string a = "";
        switch (type)
        {
            case 1:
                a = "cod_solicitud_cita_odontologo";
                break;
            case 2:
                a = "cod_solicitud_cita_psicologo";
                break;
            default:
                break;
        }
        return a;
    }


    protected void result_reposos_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow row in result_reposos.Rows)
        {
            DropDownList list = row.FindControl("modSolicitud") as DropDownList;
            HiddenField value = row.FindControl("hiddenStatus") as HiddenField;

            if (list != null && value != null)
            {
                list.SelectedValue = value.Value;
                if ("Secretaria".Equals(Session["Cargo"].ToString()) && ("3".Equals(value.Value) || "4".Equals(value.Value)))
                {
                    list.Enabled = false;
                }
            }
        }
    }

    protected void result_reposos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        result_reposos.PageIndex = e.NewPageIndex;
    }
}