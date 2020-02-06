using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.IO;
public partial class vistas_tablas_reposos : System.Web.UI.Page
{

    public string recordId;
    public string accion;
    string consulta;
    const string query = "select c.cedula cedula,a.cod_solicitud_protocolo ID, c.Fullnombre alumno, a.foto_carnet foto,  "
    + " a.talla_camisa camisa, a.talla_pantalon pantalon, a.talla_zapato zapato, a.direccion, a.telefono, "
    + " a.cod_estatus cod  from dbo.solicitud_protocolo a inner join dbo.estatus_solicitud b on "
    + " (a.cod_estatus=b.cod_estatus) inner join PRDPSMVAL.dbo.Alumnos c on (c.IdAl=a.idAl) ";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Conexion con = new Conexion(false);

            if (Session["Cargo"] != null)
            {
                consulta = "select cod_estatus codigo, estatus as estatus from estatus_solicitud";
            }
            con = new Conexion(false);
            DataSet result = con.buscar(consulta);
            estatus.DataSource = result;
            estatus.DataTextField = result.Tables[0].Columns["estatus"].ToString();
            estatus.DataValueField = result.Tables[0].Columns["codigo"].ToString();
            estatus.DataBind();
            findAll();
        }

    }

    protected void buscar_Click(object sender, EventArgs e)
    {
        if ("".Equals(txtCedula.Value))
        {
            findAll();
        }
        else
        {
            string where = " where c.cedula='" + txtCedula.Value + "' and a.cod_estatus=" + estatus.SelectedValue + ";";
            string tempconsulta = query + where;
            Conexion con = new Conexion(false);
            DataTable table = con.search(tempconsulta);

            result_reposos.DataSource = table;
            result_reposos.DataBind();
        }
    }

    protected void BtnEditar_Click(object sender, EventArgs e)
    {

        LinkButton BtnEditar = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnEditar.NamingContainer;
        DropDownList control = result_reposos.Rows[row.RowIndex].FindControl("modSolicitud") as DropDownList;
        int id = Convert.ToInt32(this.result_reposos.DataKeys[row.RowIndex].Value);
        
        Conexion con = new Conexion(false);

        if (Session["Cargo"].ToString().Equals("Secretaria") && control.SelectedValue.Equals("2"))
        {

            string query = "update dbo.solicitud_protocolo set cod_estatus =" + control.SelectedValue + " where cod_solicitud_protocolo =" + id + "";
            if (con.update(query))
            {
                Response.Redirect("filtrarProtocolo.aspx");
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "window.alert('ERROR!! Su rol no tiene autorizacion para realizar esta Accion.')", true);
        }

        if (!Session["Cargo"].ToString().Equals("Secretaria") && !(control.SelectedValue.Equals("2") || control.SelectedValue.Equals("1")))
        {

            string query = "update dbo.solicitud_protocolo set cod_estatus =" + control.SelectedValue + " where cod_solicitud_protocolo =" + id + "";
            if (con.update(query))
            {
                Response.Redirect("filtrarProtocolo.aspx");
            }

        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "window.alert('ERROR!! Su rol no tiene autorizacion para realizar esta Accion.')", true);

        }
    }

    private void findAll()
    {

        Conexion con = new Conexion(false);
        DataTable resulttable = con.search(query);

        result_reposos.DataSource = resulttable;
        result_reposos.DataBind();
    }
    
    protected void result_reposos_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow row in result_reposos.Rows)
        {
            DropDownList list = row.FindControl("modSolicitud") as DropDownList;
            HiddenField value = row.FindControl("hiddenStatus") as HiddenField;

            if (list != null && value != null)
            {
                list.SelectedValue = value.Value;
                if ("Secretaria".Equals(Session["Cargo"].ToString()) && ("3".Equals(value.Value) || "4".Equals(value.Value)))
                {
                    list.Enabled = false;
                }
            }


        }
    }

    protected void result_reposos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        result_reposos.PageIndex = e.NewPageIndex;
    }
}