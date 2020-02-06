using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class vistas_estudiantes_mod_eventoCultural : System.Web.UI.Page
{
    const string QUERY = "select A.cod_solicitud_evento_cult ID, A.descripcion_evento_cult descripcion, a.cod_tipo_evento_cult tipo, A.fecha_solicitud fecha, a.cod_estatus estatus from dbo.solicitud_evento_cult A where ";
    string where;
    Conexion con;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            where = " idAl=" + Session["idAlumno"];
            con = new Conexion(false);
            DataTable result = con.search(QUERY + where);

            eventoCultural.DataSource = result;
            eventoCultural.DataBind();
        }
    }

    protected void eventoCultural_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow row in eventoCultural.Rows)
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
                if (!"1".Equals(hEstatus.Value))
                {
                    LinkButton eliminar = row.FindControl("btnEliminar") as LinkButton;
                    LinkButton editar = row.FindControl("BtnEditar") as LinkButton;
                    TextBox desc = row.FindControl("TxtDescripcion") as TextBox;

                    tipo.Enabled = false;
                    desc.Enabled = false;
                    estatus.Enabled = false;
                    editar.Enabled = false;
                    eliminar.Enabled = false;

                }
            }
            estatus.Enabled = false;
        }
    }

    protected void eventoCultural_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        eventoCultural.PageIndex = e.NewPageIndex;

    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        LinkButton BtnEditar = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnEditar.NamingContainer;
        int id = Convert.ToInt32(this.eventoCultural.DataKeys[row.RowIndex].Value);
        

        string delete = "delete from dbo.solicitud_evento_cult where cod_solicitud_evento_cult=" + id;

        con = new Conexion(false);

        if (con.delete(delete))
        {
            Mensaje.Text = "Exitoso";
            Response.Redirect("eventoCultural.aspx");
        }
        else { Mensaje.Text = "Error al Procesar"; }
    }

    protected void BtnEditar_Click(object sender, EventArgs e)
    {
        LinkButton BtnEditar = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnEditar.NamingContainer;
        int id = Convert.ToInt32(this.eventoCultural.DataKeys[row.RowIndex].Value);
        TextBox motivo = eventoCultural.Rows[row.RowIndex].FindControl("TxtDescripcion") as TextBox;
        DropDownList tipo = eventoCultural.Rows[row.RowIndex].FindControl("modTipo") as DropDownList;

        string update = "update dbo.solicitud_evento_cult set cod_tipo_evento_cult=" + tipo.SelectedValue + ", descripcion_evento_cult='" + motivo.Text+"' where cod_solicitud_evento_cult="+id;

        con = new Conexion(false);

        if(con.update(update))
        {
            Mensaje.Text = "Exitoso";
            Response.Redirect("eventoCultural.aspx");
        }
        else { Mensaje.Text = "Error al Procesar"; }
    }
}