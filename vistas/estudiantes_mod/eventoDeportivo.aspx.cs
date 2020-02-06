using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class vistas_estudiantes_mod_eventoDeportivo : System.Web.UI.Page
{
    const string QUERY = "select A.cod_solicitud_evento_dep ID, A.descripcion_evento_dep descripcion, a.cod_tipo_evento_dep tipo, A.fecha_solicitud fecha, a.cod_estatus estatus from dbo.solicitud_evento_dep A where  ";
    string where;
    Conexion con;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            where = " idAl=" + Session["idAlumno"];
            con = new Conexion(false);
            DataTable result = con.search(QUERY + where);

            eventoDep.DataSource = result;
            eventoDep.DataBind();
        }
    }

    protected void eventoDep_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow row in eventoDep.Rows)
        {
            DropDownList tipo = row.FindControl("modTipo") as DropDownList;
            HiddenField hTipo = row.FindControl("hiddenTipo") as HiddenField;

            if (tipo != null && hTipo != null)
            {
                tipo.SelectedValue = hTipo.Value;
            }

            DropDownList estatus = row.FindControl("modSolicitud") as DropDownList;
            HiddenField hEstatus = row.FindControl("hiddenStatus") as HiddenField;

            if (estatus != null && hEstatus != null)
            {
                estatus.SelectedValue = hEstatus.Value;
               
            }
            estatus.Enabled = false;

            LinkButton eliminar = row.FindControl("btnEliminar") as LinkButton;
            LinkButton editar = row.FindControl("BtnEditar") as LinkButton;
            TextBox desc = row.FindControl("TxtDescripcion") as TextBox;

            if (!"1".Equals(hEstatus.Value))
            {


                desc.Enabled = false;
                tipo.Enabled = false;
                estatus.Enabled = false;
                editar.Enabled = false;
                eliminar.Enabled = false;

            }
        }
    }

    protected void eventoDep_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        eventoDep.PageIndex = e.NewPageIndex;
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        LinkButton BtnEditar = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnEditar.NamingContainer;
        int id = Convert.ToInt32(this.eventoDep.DataKeys[row.RowIndex].Value);

        string delete = "delete from dbo.solicitud_evento_dep where cod_solicitud_evento_dep=" + id;

        con = new Conexion(false);

        if (con.delete(delete))
        {
            Mensaje.Text = "Exitoso";
            Response.Redirect("eventoDeportivo.aspx");
        }
        else { Mensaje.Text = "Error al Procesar"; }
    }

    protected void BtnEditar_Click(object sender, EventArgs e)
    {
        LinkButton BtnEditar = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnEditar.NamingContainer;
        int id = Convert.ToInt32(this.eventoDep.DataKeys[row.RowIndex].Value);
        TextBox motivo = eventoDep.Rows[row.RowIndex].FindControl("TxtDescripcion") as TextBox;
        DropDownList tipo = eventoDep.Rows[row.RowIndex].FindControl("modTipo") as DropDownList;

        string update = "update dbo.solicitud_evento_dep set cod_tipo_evento_dep=" + tipo.SelectedValue + ", descripcion_evento_dep='" + motivo.Text + "' where cod_solicitud_evento_dep=" + id;

        con = new Conexion(false);

        if (con.update(update))
        {
            Mensaje.Text = "Exitoso";
            Response.Redirect("eventoDeportivo.aspx");
        }
        else { Mensaje.Text = "Error al Procesar"; }
    }
}