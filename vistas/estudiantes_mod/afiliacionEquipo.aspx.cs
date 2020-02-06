using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class vistas_estudiantes_mod_afiliacionEquipo : System.Web.UI.Page
{
    const string QUERY = "select A.cod_solicitud_afiliacion ID, A.cod_equipo equipo ,A.motivo motivo, A.cod_estatus estatus, A.fecha_solicitud fecha from dbo.solicitud_afiliacion A where ";
    string where;
    Conexion con;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            where = " idAl=" + Session["idAlumno"];
            con = new Conexion(false);
            DataTable result = con.search(QUERY + where);

            afiliacion.DataSource = result;
            afiliacion.DataBind();
        }
    }

    protected void afiliacion_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow row in afiliacion.Rows)
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
            TextBox desc = row.FindControl("TxtDescripcion") as TextBox;
            LinkButton eliminar = row.FindControl("btnEliminar") as LinkButton;
            LinkButton editar = row.FindControl("BtnEditar") as LinkButton;

            if (!"1".Equals(hEstatus.Value))
            {
                tipo.Enabled = false;
                desc.Enabled = false;
                estatus.Enabled = false;
                editar.Enabled = false;
                eliminar.Enabled = false;

            }
        }
    }

    protected void afiliacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        afiliacion.PageIndex = e.NewPageIndex;
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        LinkButton BtnEditar = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnEditar.NamingContainer;
        int id = Convert.ToInt32(this.afiliacion.DataKeys[row.RowIndex].Value);

        string delete = "delete from dbo.solicitud_afiliacion where cod_solicitud_afiliacion=" + id;

        con = new Conexion(false);

        if (con.delete(delete))
        {
            Mensaje.Text = "Exitoso";
            Response.Redirect("afiliacionEquipo.aspx");
        }
        else { Mensaje.Text = "Error al Procesar"; }
    }

    protected void BtnEditar_Click(object sender, EventArgs e)
    {
        LinkButton BtnEditar = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnEditar.NamingContainer;
        int id = Convert.ToInt32(this.afiliacion.DataKeys[row.RowIndex].Value);
        TextBox motivo = afiliacion.Rows[row.RowIndex].FindControl("TxtDescripcion") as TextBox;
        DropDownList tipo = afiliacion.Rows[row.RowIndex].FindControl("modTipo") as DropDownList;

        string update = "update dbo.solicitud_afiliacion set cod_equipo=" + tipo.SelectedValue + ", motivo='" + motivo.Text + "' where cod_solicitud_afiliacion=" + id;

        con = new Conexion(false);

        if (con.update(update))
        {
            Mensaje.Text = "Exitoso";
            Response.Redirect("eventoCultural.aspx");
        }
        else { Mensaje.Text = "Error al Procesar"; }
    }
}