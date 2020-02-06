using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class vistas_forms_modificar_usuarios : System.Web.UI.Page
{
    const string INIT_QUERY = "select U.cod_administrativo ID, u.ci, U.nombre, U.apellido, U.telefono, U.edad, S.genero, U.email, U.us, U.pass, U.tipo_us, U.estatus from dbo.usuarios U inner join dbo.sexo S on (U.cod_sexo=S.cod_sexo)";
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
        TextBox email = result_reposos.Rows[row.RowIndex].FindControl("email") as TextBox;
        TextBox usuario = result_reposos.Rows[row.RowIndex].FindControl("us") as TextBox;
        TextBox pass = result_reposos.Rows[row.RowIndex].FindControl("pass") as TextBox;
        DropDownList tipo_us=result_reposos.Rows[row.RowIndex].FindControl("tipoUsuario") as DropDownList;
        DropDownList estatusI = result_reposos.Rows[row.RowIndex].FindControl("estatus") as DropDownList;

        con = new Conexion(false);
        con.update("update dbo.usuarios set telefono = '"+telefono.Text+"' where cod_administrativo="+id+";");
        con = new Conexion(false);
        con.update("update dbo.usuarios set email = '" + email.Text + "' where cod_administrativo=" + id + ";");
        con = new Conexion(false);
        con.update("update dbo.usuarios set us = '" + usuario.Text + "' where cod_administrativo=" + id + ";");
        if (!"".Equals(pass.Text))
        {
            con = new Conexion(false);
            con.update("update dbo.usuarios set pass = '" + pass.Text + "' where cod_administrativo=" + id + ";");
        }
        con = new Conexion(false);
        con.update("update dbo.usuarios set tipo_us = '" + tipo_us.SelectedItem+ "' where cod_administrativo=" + id + ";");
        con = new Conexion(false);
        con.update("update dbo.usuarios set estatus = '" + estatusI.SelectedValue + "' where cod_administrativo=" + id + ";");

    }

    protected void buscar_Click(object sender, EventArgs e)
    {
        string where = " where U.estatus='"+estatus_usuario.SelectedItem+"' and tipo_us='"+tipo_usuario.SelectedItem+"' ";
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
        if (con.update("delete dbo.usuarios where cod_administrativo=" + id + ";"))
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

            HiddenField htipo = row.FindControl("htipous") as HiddenField;
            DropDownList tipo = row.FindControl("tipoUsuario") as DropDownList;

            if (htipo != null && tipo != null)
            {
                tipo.SelectedValue = htipo.Value;

            }

        }
    }
}