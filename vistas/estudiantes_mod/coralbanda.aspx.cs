using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class vistas_estudiantes_mod_coralbanda : System.Web.UI.Page
{
    const string QUERY = "select cod_solicitud_coral_banda ID, cod_tipo_coral_banda tipo,motivo, cod_estatus estatus, fecha_solicitud fecha from dbo.solicitud_coral_banda where ";
    string where;
    Conexion con;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            where = " idAl=" + Session["idAlumno"];
            con = new Conexion(false);
            DataTable result = con.search(QUERY + where);

            coralBanda.DataSource = result;
            coralBanda.DataBind();
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        LinkButton BtnEditar = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnEditar.NamingContainer;
        int id = Convert.ToInt32(this.coralBanda.DataKeys[row.RowIndex].Value);

        string delete = "delete from dbo.solicitud_coral_banda where cod_solicitud_coral_banda=" + id;

        con = new Conexion(false);

        if (con.delete(delete))
        {
            Mensaje.Text = "Exitoso";
            Response.Redirect("coralbanda.aspx");
        }
        else { Mensaje.Text = "Error al Procesar"; }
    }

    protected void BtnEditar_Click(object sender, EventArgs e)
    {
        LinkButton BtnEditar = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnEditar.NamingContainer;
        int id = Convert.ToInt32(this.coralBanda.DataKeys[row.RowIndex].Value);
        TextBox motivo = coralBanda.Rows[row.RowIndex].FindControl("TxtMotivo") as TextBox;
        DropDownList tipo = coralBanda.Rows[row.RowIndex].FindControl("modTipo") as DropDownList;

        string update = "update dbo.solicitud_coral_banda set cod_tipo_coral_banda=" + tipo.SelectedValue + ", motivo='" + motivo.Text + "' where cod_solicitud_coral_banda=" + id;

        con = new Conexion(false);

        if (con.update(update))
        {
            Mensaje.Text = "Exitoso";
            Response.Redirect("coralbanda.aspx");
        }
        else { Mensaje.Text = "Error al Procesar"; }
    }

    protected void coralBanda_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow row in coralBanda.Rows)
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
            LinkButton eliminar = row.FindControl("btnEliminar") as LinkButton;
            LinkButton editar = row.FindControl("BtnEditar") as LinkButton;
            TextBox motivo = row.FindControl("TxtMotivo") as TextBox;
            estatus.Enabled = false;
            if (!"1".Equals(hEstatus.Value))
            {
                tipo.Enabled = false;
                motivo.Enabled = false;
                estatus.Enabled = false;
                editar.Enabled = false;
                eliminar.Enabled = false;

            }

        }
    }

    protected void coralBanda_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        coralBanda.PageIndex = e.NewPageIndex;
    }
}