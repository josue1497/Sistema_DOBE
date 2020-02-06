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
    const string query = "select rep.cod_reposo as 'ID',rep.idAl as idAl, al.nombres+' '+al.apellidos as Alumno, reposo as Documento , med.nombre_medico+' '+med.apellido_medico as Medico,rep.desc_patologia patologia, t_rep.tipo_reposo as Tipo,  est.estatus as Estatus, rep.cod_estatus cod from dbo.reposo rep "
    + " inner join dbo.medico med on(med.prima_medico = rep.prima_medico) "
    + " inner join dbo.tipo_reposo t_rep on(t_rep.cod_tipo_reposo = rep.cod_tipo_reposo) "
    + " inner join dbo.personal_administrativo al on (rep.idAl = al.cod_personal_Administrativo) "
    + " inner join dbo.estatus_solicitud est on (rep.cod_estatus = est.cod_estatus)  where is_docente='N' and is_personal='S' ";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Conexion con = new Conexion(false);
            DataTable table = con.buscar("select cod_tipo_reposo codigo, tipo_reposo tipo from dbo.tipo_reposo;").Tables[0];

            foreach (DataRow row in table.Rows)
            {
                tipoReposo.Items.Insert(Convert.ToInt32(row["codigo"]), Convert.ToString(row["tipo"]));
                tipoReposo.Items.FindByValue(Convert.ToString(row["tipo"])).Value = Convert.ToString(row["codigo"]);
            }

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
        if (tipoReposo.SelectedIndex == 0)
        {
            findAll();
        }
        else
        {
            string where = " and rep.cod_tipo_reposo=" + tipoReposo.SelectedIndex + " and rep.fecha_inicio>='" + fechaIni.Value + "' and rep.fecha_fin<='" + FechaFin.Value + "'"
                            + " and rep.cod_estatus=" + estatus.SelectedValue + ";";
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
        HiddenField field = row.FindControl("idAl") as HiddenField;
        int idAl = Convert.ToInt32(field.Value);
        HiddenField value = row.FindControl("hiddenStatus") as HiddenField;
        string estatus_anterior = value.Value;

        Conexion con = new Conexion(false);

        if (Session["Cargo"].ToString().Equals("Secretaria") && control.SelectedValue.Equals("2"))
        {

            string query = "update dbo.reposo set cod_estatus =" + control.SelectedValue + " where cod_reposo =" + id + "";
            if (con.update(query))
            {
                Response.Redirect("reposos_personal.aspx");
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "window.alert('ERROR!! Su rol no tiene autorizacion para realizar esta Accion.')", true);
        }

        if (!Session["Cargo"].ToString().Equals("Secretaria") && !(control.SelectedValue.Equals("2") || control.SelectedValue.Equals("1")))
        {
            if ("3".Equals(estatus_anterior) && control.SelectedValue.Equals("2"))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "window.alert('ERROR!! Operacion Invalida.')", true);
            }
            else
            {
                string query = "update dbo.reposo set cod_estatus =" + control.SelectedValue + " where cod_reposo =" + id + "";
                if (con.update(query))
                {
                    Response.Redirect("reposos_personal.aspx");
                }
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