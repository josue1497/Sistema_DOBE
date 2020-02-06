using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class vistas_estudiantes_mod_materialDeportivo : System.Web.UI.Page
{
    const string QUERY = "select cod_s_material_deportivo ID, cod_tipo_art_deportivo articulo, cantidad,tiempo_prestamo tiempo, cod_estatus estatus, cast(fecha_reservacion as date) fecha from dbo.s_material_deportivo where ";
    string where;
    Conexion con;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            where = " idAl=" + Session["idAlumno"];
            con = new Conexion(false);
            DataTable result = con.search(QUERY + where);

            materialDep.DataSource = result;
            materialDep.DataBind();
        }
    }

    protected void materialDep_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow row in materialDep.Rows)
        {
            DropDownList tipo = row.FindControl("modArticulo") as DropDownList;
            HiddenField hTipo = row.FindControl("hiddenArticulo") as HiddenField;

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

            TextBox date = row.FindControl("TxtFecha") as TextBox;
            HiddenField hDate = row.FindControl("hiddenFecha") as HiddenField;

            if (date != null && hDate != null)
            {
                date.Text =Convert.ToDateTime(hDate.Value).ToString("yyyy-MM-dd");
            }

            LinkButton eliminar = row.FindControl("btnEliminar") as LinkButton;
            LinkButton editar = row.FindControl("BtnEditar") as LinkButton;
            TextBox tiempo = row.FindControl("TxtTiempo") as TextBox;
            TextBox cantidad = row.FindControl("TxtCantidad") as TextBox;
            TextBox fecha = row.FindControl("TxtFecha") as TextBox;

            if (!"1".Equals(hEstatus.Value))
            {
                cantidad.Enabled = false;
                fecha.Enabled = false;
                tiempo.Enabled = false;
                tipo.Enabled = false;
                estatus.Enabled = false;
                editar.Enabled = false;
                eliminar.Enabled = false;

            }
        }
    }

    protected void materialDep_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        materialDep.PageIndex = e.NewPageIndex;
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        LinkButton BtnEditar = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnEditar.NamingContainer;
        int id = Convert.ToInt32(this.materialDep.DataKeys[row.RowIndex].Value);

        string delete = "delete from dbo.s_material_deportivo where cod_s_material_deportivo=" + id;

        con = new Conexion(false);

        if (con.delete(delete))
        {
            Mensaje.Text = "Exitoso";
            Response.Redirect("materialDeportivo.aspx");
        }
        else { Mensaje.Text = "Error al Procesar"; }
    }

    protected void BtnEditar_Click(object sender, EventArgs e)
    {
        LinkButton BtnEditar = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnEditar.NamingContainer;

        int id = Convert.ToInt32(this.materialDep.DataKeys[row.RowIndex].Value);
        TextBox cantidad = materialDep.Rows[row.RowIndex].FindControl("TxtCantidad") as TextBox;
        TextBox tiempo = materialDep.Rows[row.RowIndex].FindControl("TxtTiempo") as TextBox;
        TextBox fecha = materialDep.Rows[row.RowIndex].FindControl("TxtFecha") as TextBox;
        DropDownList tipo = materialDep.Rows[row.RowIndex].FindControl("modArticulo") as DropDownList;

        string update = "update dbo.s_material_deportivo set cod_tipo_art_deportivo=" + tipo.SelectedValue + ", cantidad='" + cantidad.Text + "', tiempo_prestamo="+tiempo.Text+ ", fecha_reservacion='"+Convert.ToDateTime(fecha.Text).ToString("yyyy-MM-dd")+"' where cod_s_material_deportivo=" + id;

        con = new Conexion(false);

        if (con.update(update))
        {
            Mensaje.Text = "Exitoso";
            Response.Redirect("materialDeportivo.aspx");
        }
        else { Mensaje.Text = "Error al Procesar"; }
    }
}