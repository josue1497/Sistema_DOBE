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
    const string QUERY = "select cod_solicitud_protocolo id, foto_carnet documento, talla_camisa camisa,  " +
        " talla_pantalon pantalon, talla_zapato zapato, telefono, direccion, cod_estatus estatus from dbo.solicitud_protocolo where ";
    string where;
    Conexion con;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            where = " idAl=" + Session["idAlumno"];
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
            DropDownList estatus = row.FindControl("modSolicitud") as DropDownList;
            HiddenField hEstatus = row.FindControl("hiddenStatus") as HiddenField;

            if (estatus != null && hEstatus != null)
            {
                estatus.SelectedValue = hEstatus.Value;
            }
            estatus.Enabled = false;

         

            LinkButton eliminar = row.FindControl("btnEliminar") as LinkButton;
            LinkButton editar = row.FindControl("BtnEditar") as LinkButton;
            TextBox camisa = row.FindControl("txtCamisa") as TextBox;
            TextBox pantalon = row.FindControl("txtPantalon") as TextBox;
            TextBox zapato = row.FindControl("txtZapato") as TextBox;
            TextBox telefono = row.FindControl("txtTelefono") as TextBox;
            TextBox direccion = row.FindControl("txtDireccion") as TextBox;
            FileUpload fileR = row.FindControl("FileReposo") as FileUpload;

            if (!"1".Equals(hEstatus.Value))
            {
                fileR.Enabled = false;
                camisa.Enabled = false;
                pantalon.Enabled = false;
                zapato.Enabled = false;
                direccion.Enabled = false;
                telefono.Enabled = false;
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

        string delete = "delete from dbo.solicitud_protocolo where cod_solicitud_protocolo=" + id;

        con = new Conexion(false);

        if (con.delete(delete))
        {
            File.Delete(Server.MapPath(filePath));
            Mensaje.Text = "Exitoso";
            Response.Redirect("protocolo.aspx");
        }
        else { Mensaje.Text = "Error al Procesar"; }
    }

    protected void BtnEditar_Click(object sender, EventArgs e)
    {

        LinkButton BtnEditar = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnEditar.NamingContainer;
        int id = Convert.ToInt32(this.reposo.DataKeys[row.RowIndex].Value);

        TextBox camisa = row.FindControl("txtCamisa") as TextBox;
        TextBox pantalon = row.FindControl("txtPantalon") as TextBox;
        TextBox zapato = row.FindControl("txtZapato") as TextBox;
        TextBox telefono = row.FindControl("txtTelefono") as TextBox;
        TextBox direccion = row.FindControl("txtDireccion") as TextBox;


        string update = "update dbo.solicitud_protocolo set  talla_camisa='" + camisa.Text+ "' , talla_pantalon='" + pantalon.Text +"' ,"+
            " talla_zapato='" + zapato.Text + "' , telefono='" + telefono.Text + "' , direccion='" + direccion.Text + "'   where cod_solicitud_protocolo=" + id+"";

        con = new Conexion(false);
        bool pass = con.update(update);
        bool pass2=true;
       

        FileUpload file = row.FindControl("FileReposo") as FileUpload;
        HiddenField image = row.FindControl("hiddenReposo") as HiddenField;
        string filePath=image.Value;

        if (file.HasFile) {
            string nombreArchivo = file.FileName;
            string server = "~/files/Protocolo/" + Session["idAlumno"] + "/";
            if (!Directory.Exists(Server.MapPath(server)))
            {
                DirectoryInfo di = Directory.CreateDirectory(Server.MapPath(server));
            }
            string ruta = server + nombreArchivo;
            file.SaveAs(Server.MapPath(ruta));

            File.Delete(Server.MapPath(filePath));
            update = "update dbo.solicitud_protocolo set foto_carnet='" + ruta+ "' where cod_solicitud_protocolo=" + id+"";
            con = new Conexion(false);
            pass2 = con.update(update);
        }

        if (pass && pass2)
        {
            Mensaje.Text = "Exitoso";
            Response.Redirect("protocolo.aspx");
        }
        else { Mensaje.Text = "Error al Procesar"; }
    }
}