using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class vistas_estudiantes_mod_reposo : System.Web.UI.Page
{
    const string QUERY = "select cod_reposo ID, cod_tipo_reposo tipo, reposo documento, prima_medico medico, desc_patologia patologia,fecha_inicio FI, fecha_fin FF,cod_estatus estatus from dbo.reposo where ";
    string where;
    Conexion con;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            where = " idAl=" + Session["ID"];
            con = new Conexion(false);
            DataTable result = con.search(QUERY + where);

            reposo.DataSource = result;
            reposo.DataBind();
        }
    }


    protected void reposo_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow row in reposo.Rows)
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

            TextBox date = row.FindControl("TxtFechaI") as TextBox;
            HiddenField hDate = row.FindControl("hiddenFechaInicio") as HiddenField;

            if (date != null && hDate != null)
            {
                date.Text = Convert.ToDateTime(hDate.Value).ToString("yyyy-MM-dd");
            }

            TextBox dateF = row.FindControl("TxtFechaF") as TextBox;
            HiddenField hDateF = row.FindControl("hiddenFechaFin") as HiddenField;

            if (dateF != null && hDateF != null)
            {
                dateF.Text = Convert.ToDateTime(hDateF.Value).ToString("yyyy-MM-dd");
            }

            DropDownList medico = row.FindControl("ListMedico") as DropDownList;
            HiddenField hMedico = row.FindControl("hiddenMedico") as HiddenField;

            if (medico != null && hMedico != null)
            {
                medico.SelectedValue = hMedico.Value;
            }

            LinkButton eliminar = row.FindControl("btnEliminar") as LinkButton;
            LinkButton editar = row.FindControl("BtnEditar") as LinkButton;
            TextBox patologia = row.FindControl("TxtPatologia") as TextBox;
            FileUpload fileR = row.FindControl("FileReposo") as FileUpload;

            if (!"1".Equals(hEstatus.Value))
            {
                fileR.Enabled = false;
                patologia.Enabled = false;
                tipo.Enabled = false;
                medico.Enabled = false;
                date.Enabled = false;
                dateF.Enabled = false;
                estatus.Enabled = false;
                editar.Enabled = false;
                eliminar.Enabled = false;

            }

        }

    }

    protected void reposo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        reposo.PageIndex = e.NewPageIndex;
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        LinkButton BtnEditar = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnEditar.NamingContainer;
        int id = Convert.ToInt32(this.reposo.DataKeys[row.RowIndex].Value);
        HyperLink image = row.FindControl("ImageReposo") as HyperLink;
        string filePath = image.NavigateUrl;

        string delete = "delete from dbo.reposo where cod_reposo=" + id;

        con = new Conexion(false);

        if (con.delete(delete))
        {
            File.Delete(Server.MapPath(filePath));
            Mensaje.Text = "Exitoso";
            Response.Redirect("reposo_personal.aspx");
        }
        else { Mensaje.Text = "Error al Procesar"; }
    }

    protected void BtnEditar_Click(object sender, EventArgs e)
    {

        LinkButton BtnEditar = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnEditar.NamingContainer;
        int id = Convert.ToInt32(this.reposo.DataKeys[row.RowIndex].Value);

        DropDownList tipo = row.FindControl("modArticulo") as DropDownList;
        TextBox date = row.FindControl("TxtFechaI") as TextBox;
        TextBox dateF = row.FindControl("TxtFechaF") as TextBox;
        TextBox patologia = row.FindControl("TxtPatologia") as TextBox;
        DropDownList medico = row.FindControl("ListMedico") as DropDownList;

        string update = "update dbo.reposo set cod_tipo_reposo="+tipo.SelectedValue+", prima_medico="+medico.SelectedValue+",desc_patologia='"+patologia.Text+"' , fecha_inicio='"+ Convert.ToDateTime(date.Text).ToString("yyyy-MM-dd") + "', fecha_fin='"+ Convert.ToDateTime(dateF.Text).ToString("yyyy-MM-dd") + "' where cod_reposo="+id+"";

        con = new Conexion(false);
        bool pass = con.update(update);
        bool pass2=true;
       

        FileUpload file = row.FindControl("FileReposo") as FileUpload;
        HiddenField image = row.FindControl("hiddenReposo") as HiddenField;
        string filePath=image.Value;

        if (file.HasFile) {
            string nombreArchivo = file.FileName;
            string server = "~/files/Reposos/";
            if (!Directory.Exists(Server.MapPath(server)))
            {
                DirectoryInfo di = Directory.CreateDirectory(Server.MapPath(server));
            }
            string ruta = server + nombreArchivo;
            file.SaveAs(Server.MapPath(ruta));

            File.Delete(Server.MapPath(filePath));
            update = "update dbo.reposo set reposo='"+ruta+"' where cod_reposo="+id+"";
            con = new Conexion(false);
            pass2 = con.update(update);
        }

        if (pass && pass2)
        {
            Mensaje.Text = "Exitoso";
            Response.Redirect("reposo_personal.aspx");
        }
        else { Mensaje.Text = "Error al Procesar"; }
    }
}