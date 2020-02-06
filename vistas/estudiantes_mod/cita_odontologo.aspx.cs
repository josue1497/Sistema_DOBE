using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class vistas_estudiantes_mod_afiliacionEquipo : System.Web.UI.Page
{
    const string QUERY = "select cod_solicitud_cita_odontologo ID, motivo, " +
        " comentario_secretaria obs, cod_estatus estatus from dbo.solicitud_cita_odontologo  where ";
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
           
            DropDownList estatus = row.FindControl("modSolicitud") as DropDownList;
            HiddenField hEstatus = row.FindControl("hiddenStatus") as HiddenField;

            if (estatus != null && hEstatus != null)
            {
                estatus.SelectedValue = hEstatus.Value;
            }
            estatus.Enabled = false;

            TextBox date = row.FindControl("TxtFecha") as TextBox;
            HiddenField hDate = row.FindControl("hiddenFecha") as HiddenField;

            if (date != null && hDate != null)
            {
                date.Text =hDate.Value;
            }

            TextBox desc = row.FindControl("TxtDescripcion") as TextBox;
            LinkButton eliminar = row.FindControl("btnEliminar") as LinkButton;
            LinkButton editar = row.FindControl("BtnEditar") as LinkButton;

            if (!"1".Equals(hEstatus.Value))
            {
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

        string delete = "delete from dbo.solicitud_cita_odontologo where cod_solicitud_cita_odontologo=" + id;

        con = new Conexion(false);

        if (con.delete(delete))
        {
            Mensaje.Text = "Exitoso";
            Response.Redirect("cita_odontologo.aspx");
        }
        else { Mensaje.Text = "Error al Procesar"; }
    }

    protected void BtnEditar_Click(object sender, EventArgs e)
    {
        LinkButton BtnEditar = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnEditar.NamingContainer;
        int id = Convert.ToInt32(this.afiliacion.DataKeys[row.RowIndex].Value);
        TextBox motivo = afiliacion.Rows[row.RowIndex].FindControl("TxtDescripcion") as TextBox;
       
        TextBox fecha = afiliacion.Rows[row.RowIndex].FindControl("TxtFecha") as TextBox;

        string update = "update dbo.solicitud_cita_odontologo set  motivo='" + motivo.Text + "' where cod_solicitud_cita_odontologo=" + id;

        con = new Conexion(false);

        if (con.update(update))
        {
            Mensaje.Text = "Exitoso";
            Response.Redirect("cita_odontologo.aspx");
        }
        else { Mensaje.Text = "Error al Procesar"; }
    }
}