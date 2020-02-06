using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class vistas_forms_modificar_usuarios : System.Web.UI.Page
{
    const string INIT_QUERY = "select cod_personal_Administrativo ID, cedula ci, clave pass, nombres nombre, apellidos apellido,cod_cargo cargo, telefono, direccion direccion, cod_sexo sexo from dbo.personal_administrativo ";
    Conexion con;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            con = new Conexion(false);
            DataTable set = con.search(INIT_QUERY);
            result_reposos.DataSource = set;
            result_reposos.DataBind();
        }
    }

    protected void BtnEditar_Click(object sender, EventArgs e)
    {
        LinkButton BtnEditar = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnEditar.NamingContainer;
        
        int id = Convert.ToInt32(this.result_reposos.DataKeys[row.RowIndex].Value);

        TextBox telefono = result_reposos.Rows[row.RowIndex].FindControl("telefono") as TextBox;
        TextBox direccion = result_reposos.Rows[row.RowIndex].FindControl("direccion") as TextBox;
        TextBox usuario = result_reposos.Rows[row.RowIndex].FindControl("us") as TextBox;
        TextBox pass = result_reposos.Rows[row.RowIndex].FindControl("pass") as TextBox;
        TextBox nombre = result_reposos.Rows[row.RowIndex].FindControl("nombre") as TextBox;
        TextBox apellido = result_reposos.Rows[row.RowIndex].FindControl("apellido") as TextBox;
        DropDownList tipo = row.FindControl("dCargo") as DropDownList;

        DropDownList dgenero = row.FindControl("dGenero") as DropDownList;

        con = new Conexion(false);

        string chain = "update dbo.personal_administrativo set telefono = '" + telefono.Text + "',cedula='" + usuario.Text + "',nombres='" + nombre.Text + "'," +
            "apellidos='" + apellido.Text + "', clave='" + pass.Text + "', direccion='" + direccion.Text + "', cod_sexo=" + dgenero.SelectedValue + ", cod_cargo=" + tipo.SelectedValue + " " +
            "where cod_personal_Administrativo=" + id + ";";

        if (con.update(chain))
        {
            Mensaje.Text = "Actualización Exitosa";
        }
        else
        {
            Mensaje.Text = "Ha ocurrido un error.";
        }
    }

    protected void buscar_Click(object sender, EventArgs e)
    {
        string where = " where cedula='" + txtCedula.Text+"'";
        string tempQuery = INIT_QUERY + where;
        con = new Conexion(false);
        DataTable result = con.search(tempQuery);

        result_reposos.DataSource = result;
        result_reposos.DataBind();

    }



    protected void BtnEliminar_Click(object sender, EventArgs e)
    {
        LinkButton BtnEditar = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnEditar.NamingContainer;

        int id = Convert.ToInt32(this.result_reposos.DataKeys[row.RowIndex].Value);

        con = new Conexion(false);
        if (con.update("delete dbo.personal_administrativo where cod_personal_Administrativo=" + id + ";"))
        {
            Mensaje.Text = "Usuario Eliminado Con exito";
        }
        else {
            Mensaje.Text = "Ha ocurrido un error.";
        }

    }

    protected void result_reposos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        result_reposos.PageIndex = e.NewPageIndex;
    }

    protected void result_reposos_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow row in result_reposos.Rows)
        {
            TextBox list = row.FindControl("pass") as TextBox;
            HiddenField value = row.FindControl("hpass") as HiddenField;

            if (list != null && value != null)
            {
                list.Text = value.Value;
                
            }

            HiddenField htipo = row.FindControl("hCargo") as HiddenField;
            DropDownList tipo = row.FindControl("dCargo") as DropDownList;

            if (htipo != null && tipo != null)
            {
                tipo.SelectedValue = htipo.Value;

            }

            HiddenField hgenero = row.FindControl("hgenero") as HiddenField;
            DropDownList dgenero = row.FindControl("dGenero") as DropDownList;
            
            if (hgenero != null && dgenero != null)
            {
                dgenero.SelectedValue = hgenero.Value;

            }

        }
    }
}