using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class vistas_tablas_filtrarSolicitudes : System.Web.UI.Page
{
    const string AFILIACION_EQUIPO = " select A.cod_solicitud_afiliacion ID ,D.Fullnombre Alumno,  B.desc_equipo tipo , a.motivo motivo, " +
        " ' ' as cantidad, C.estatus estatus,' ' fechaReservacion,A.fecha_solicitud fecha, A.cod_estatus as cod from dbo.solicitud_afiliacion a  " +
         " INNER join dbo.equipo_psm B on (a.cod_equipo=b.cod_equipo) " +
        " inner join dbo.estatus_solicitud C on(c.cod_estatus= a.cod_estatus) " +
        " inner join[PRDPSMVAL].dbo.Alumnos D on(a.idAl= D.IdAl)   ";
    
    const string CORAL_BANDA = " select A.cod_solicitud_coral_banda ID ,D.Fullnombre Alumno,  B.coral_banda tipo , a.motivo motivo, " +
        " 'No Aplica' as cantidad, C.estatus estatus,'No Aplica' fechaReservacion,A.fecha_solicitud fecha, A.cod_estatus as cod from dbo.solicitud_coral_banda a  " +
         " inner join dbo.tipo_coral_banda B on(a.cod_tipo_coral_banda=b.cod_tipo_coral_banda) " +
        " inner join dbo.estatus_solicitud C on(c.cod_estatus= a.cod_estatus) " +
        " inner join[PRDPSMVAL].dbo.Alumnos D on(a.idAl= D.IdAl)   ";


    const string EVENTO_DEPORTIVO = "select A.cod_solicitud_evento_dep ID ,D.Fullnombre Alumno,  B.tipo_evento tipo , a.descripcion_evento_dep motivo, " +
"'No Aplica' as cantidad ,C.estatus estatus,'No Aplica' fechaReservacion, A.fecha_solicitud fecha, A.cod_estatus as cod from dbo.solicitud_evento_dep a " +
" inner join dbo.tipo_evento_dep B on(a.cod_tipo_evento_dep= b.cod_tipo_evento_dep) " +
"inner join dbo.estatus_solicitud C on(c.cod_estatus= a.cod_estatus) " +
"inner join[PRDPSMVAL].dbo.Alumnos D on(a.idAl= D.IdAl) ";

    const string ARTICULO_DEPORTIVO = "select A.cod_s_material_deportivo ID ,D.Fullnombre Alumno,  B.art_deportivo tipo , " +
"CAST(a.tiempo_prestamo as VARCHAR)+' horas' as motivo,a.cantidad cantidad, " +
"C.estatus estatus, A.fecha_solicitud fechaReservacion, A.fecha_solicitud fecha, A.cod_estatus as cod from dbo.s_material_deportivo a " +
"inner join dbo.tipo_art_deportivo B on(a.cod_tipo_art_deportivo= b.cod_tipo_art_deportivo) " +
"inner join dbo.estatus_solicitud C on(c.cod_estatus= a.cod_estatus)" +
"inner join[PRDPSMVAL].dbo.Alumnos D on(a.idAl= D.IdAl) ";

    const string EVENTO_CULTURAL = "select A.cod_solicitud_evento_cult ID ,D.Fullnombre Alumno,  B.tipo_evento tipo , a.descripcion_evento_cult motivo, " +
"'No Aplica' as cantidad, C.estatus estatus,'No Aplica' fechaReservacion, A.fecha_solicitud fecha, A.cod_estatus as cod from dbo.solicitud_evento_cult a " +
 "inner join dbo.tipo_evento_cult B on(a.cod_tipo_evento_cult= b.cod_tipo_evento_cult) " +
"inner join dbo.estatus_solicitud C on(c.cod_estatus= a.cod_estatus) " +
"inner join[PRDPSMVAL].dbo.Alumnos D on(a.idAl= D.IdAl) ";

    const string INSTRUMENTO_RADIO = "select a.cod_solicitud_instrumento_radio ID, d.Fullnombre Alumno, b.instrumento_radio tipo, a.motivo motivo, " +
"'no aplica' as cantidad, c.estatus estatus, a.fecha_uso fechaReservacion, A.fecha_solicitud fecha , a.cod_estatus as cod  from dbo.solicitud_instrumento_radio a  " +
 "inner join dbo.instrumento_radio b on (a.cod_instrumento_radio=b.cod_instrumento_radio) " +
"inner join dbo.estatus_solicitud c on (a.cod_estatus=c.cod_estatus) inner join PRDPSMVAL.dbo.Alumnos d on (a.idAl=d.IdAl) ";

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
        int id = Convert.ToInt32(this.result_reposos.DataKeys[row.RowIndex].Value);
        update = setupdate(SolicitudAFiltrar.SelectedIndex);
        campo = setCampo(SolicitudAFiltrar.SelectedIndex);
        con = new Conexion(false);

        if (Session["Cargo"].ToString().Equals("Secretaria") && control.SelectedValue.Equals("2"))
        {
            string query = "update " + update + "  set cod_estatus =" + control.SelectedValue + " where " + campo + "=" + id + "";
            if (con.update(query))
            {
                Response.Redirect("filtrarSolicitudes.aspx");
            }
        }
        else {
            Mensaje.Text = "Su rol no tiene autorizacion para realizar esta Accion.";
        }

        if (!Session["Cargo"].ToString().Equals("Secretaria") && !(control.SelectedValue.Equals("2")|| control.SelectedValue.Equals("1")))
        {
            string query = "update " + update + "  set cod_estatus =" + control.SelectedValue + " where " + campo + "=" + id + "";
            if (con.update(query))
            {
                Response.Redirect("filtrarSolicitudes.aspx");
            }
        }
        else
        {
            Mensaje.Text = "Su rol no tiene autorizacion para realizar esta Accion.";
        }





    }

    protected void buscar_Click(object sender, EventArgs e)
    {
        string where = " where a.cod_estatus=" + estatus.SelectedValue + " and a.fecha_solicitud BETWEEN '" + fechaIni.Value + "' and '" + FechaFin.Value + "' ";
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
                a = "dbo.solicitud_coral_banda";
                value = CORAL_BANDA;
                break;
            case 3:
                a = "dbo.solicitud_evento_dep";
                value = EVENTO_DEPORTIVO;
                break;
            case 2:
                a = "dbo.s_material_deportivo";
                value = ARTICULO_DEPORTIVO;
                break;
            case 4:
                a = "dbo.solicitud_evento_cult";
                value = EVENTO_CULTURAL;
                break;
            case 5:
                a = "dbo.solicitud_afiliacion";
                value = AFILIACION_EQUIPO;
                break;
            case 6:
                a = "dbo.solicitud_instrumento_radio";
                value = INSTRUMENTO_RADIO;
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
                a = "dbo.solicitud_coral_banda";
                break;
            case 3:
                a = "dbo.solicitud_evento_dep";
                break;
            case 2:
                a = "dbo.s_material_deportivo";
                break;
            case 4:
                a = "dbo.solicitud_evento_cult";
                break;
            case 5:
                a = "dbo.solicitud_afiliacion";
                break;
            case 6:
                a = "dbo.solicitud_instrumento_radio";
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
                a = " cod_solicitud_coral_banda ";
                break;
            case 3:
                a = " cod_solicitud_evento_dep ";
                break;
            case 2:
                a = " cod_s_material_deportivo ";
                break;
            case 4:
                a = " cod_solicitud_evento_cult ";
                break;
            case 5:
                a = " cod_solicitud_afiliacion ";
                break;
            case 6:
                a = "cod_solicitud_instrumento_radio";
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