using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.IO;

using System.Data.SqlClient;
using System.Configuration;

public partial class reposos : System.Web.UI.Page
{

    Conexion con;
    DataSet results;
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }





    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        LinkButton BtnEditar = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnEditar.NamingContainer;
        int id = Convert.ToInt32(this.result.DataKeys[row.RowIndex].Value);

        string query = "";

        switch (elementos.SelectedValue)
        {
            case "1":
                query = "delete from dbo.cargo where cod_cargo="+id;
                break;
            case "2":
                query = "delete from dbo.disciplina where cod_disciplina=" + id;
                break;
            case "3":
                query = "delete from dbo.equipo_psm where cod_equipo=" + id;
                break;
            case "4":
                query = "delete from dbo.instrumento_radio where cod_instrumento_radio=" + id;
                break;
            case "5":
                query = "delete from dbo.tipo_art_deportivo where cod_tipo_art_deportivo=" + id;
                break;
            case "6":
                query = "delete from dbo.tipo_beca where cod_tipo_beca=" + id;
                break;
            case "7":
                query = "delete from dbo.tipo_coral_banda where cod_tipo_coral_banda=" + id;
                break;
            case "8":
                query = "delete from dbo.tipo_evento_cult where cod_tipo_evento_cult=" + id;
                break;
            case "9":
                query = "delete from dbo.tipo_evento_dep where cod_tipo_evento_dep=" + id;
                break;
            case "10":
                query = "delete from dbo.tipo_reposo where cod_tipo_reposo=" + id;
                break;
            default:
                break;
        }

        con = new Conexion(false);

        if (con.delete(query))
        {
            Mensaje.Text = "Exitoso";
        }
        else { Mensaje.Text = "Error al Procesar, este elemento esta siendo usado por algun registro dentro de nuestro sistema."; }
    }

    protected void buscar_Click(object sender, EventArgs e)
    {
        string query = "";
        Mensaje.Text ="";

        switch (elementos.SelectedValue) {
            case "1":
                query = "select cod_cargo ID, desc_cargo value from dbo.cargo;";
                break;
            case "2":
                query = "select cod_disciplina ID, desc_disciplina value from dbo.disciplina;";
                break;
            case "3":
                query = "select cod_equipo ID, desc_equipo value from dbo.equipo_psm;";
                break;
            case "4":
                query = "select cod_instrumento_radio ID, instrumento_radio value from dbo.instrumento_radio;";
                break;
            case "5":
                query = "select cod_tipo_art_deportivo ID, art_deportivo value from dbo.tipo_art_deportivo;";
                break;
            case "6":
                query = "select cod_tipo_beca ID, tipo_beca value from dbo.tipo_beca;";
                break;
            case "7":
                query = "select cod_tipo_coral_banda ID, coral_banda value from dbo.tipo_coral_banda;";
                break;
            case "8":
                query = "select cod_tipo_evento_cult ID, tipo_evento value from dbo.tipo_evento_cult;";
                break;
            case "9":
                query = "select cod_tipo_evento_dep ID, tipo_evento value from dbo.tipo_evento_dep;";
                break;
            case "10":
                query = "select cod_tipo_reposo ID, tipo_reposo value from dbo.tipo_reposo;";
                break;
            default:
                Mensaje.Text = "Seleccione una opción valida para filtrar.";
                break;
        }

        Conexion con = new Conexion(false);

        results = con.buscar(query);

        result.DataSource = results;
        result.DataBind();
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {

        LinkButton BtnEditar = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnEditar.NamingContainer;
        int id = Convert.ToInt32(this.result.DataKeys[row.RowIndex].Value);
        TextBox value = result.Rows[row.RowIndex].FindControl("txtIndicaciones") as TextBox;
        string query = "";

        switch (elementos.SelectedValue)
        {
            case "1":
                query = "update dbo.cargo set  desc_cargo  = '" + value.Text + "' where cod_cargo=" + id + ";";
                break;
            case "2":
                query = "update dbo.disciplina set desc_disciplina ='" + value.Text + "' where cod_disciplina=" + id + ";";
                break;
            case "3":
                query = "update dbo.equipo_psm set desc_equipo='" + value.Text + "' where cod_equipo=" + id + ";";
                break;
            case "4":
                query = "update dbo.instrumento_radio set instrumento_radio='" + value.Text + "' where cod_instrumento_radio=" + id + ";";
                break;
            case "5":
                query = "update dbo.tipo_art_deportivo set art_deportivo='" + value.Text + "' where cod_tipo_art_deportivo=" + id + ";";
                break;
            case "6":
                query = "update dbo.tipo_beca set tipo_beca='" + value.Text + "' where cod_tipo_beca=" + id + ";";
                break;
            case "7":
                query = "update dbo.tipo_coral_banda set coral_banda='" + value.Text + "' where cod_tipo_coral_banda=" + id + ";";
                break;
            case "8":
                query = "update dbo.tipo_evento_cult set tipo_evento='" + value.Text + "' where cod_tipo_evento_cult=" + id + ";";
                break;
            case "9":
                query = "update dbo.tipo_evento_dep set tipo_evento='" + value.Text + "' where cod_tipo_evento_dep=" + id + ";";
                break;
            case "10":
                query = "update dbo.tipo_reposo set tipo_reposo='" + value.Text + "' where  cod_tipo_reposo=" + id + ";";
                break;
            default:             
                break;
        }
        con = new Conexion(false);

        if (con.update(query))
        {
            Mensaje.Text = "Exitoso";
        }
        else { Mensaje.Text = "Error al Procesar, este elemento esta siendo usado por algun registro dentro de nuestro sistema."; }
    }

    protected void result_DataBound(object sender, EventArgs e)
    {

    }

    protected void result_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        result.PageIndex = e.NewPageIndex;
    }
}