using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Drawing;

public partial class vistas_forms_becas : System.Web.UI.Page
{

    const string QUERY_BECAS = "select cod_solicitud_beca ID, a.cod_beca cod_beca,a.iraa, D.cedula CI, D.Fullnombre alumno, b.tipo_beca tipo, " +
        " solicitud_beca documento,carta_compromiso compromiso, " +
        " foto_carnet foto,certificacion_notas notas,socio_economico economico ,constancia_trabajo trabajo,  " +
        " defuncion defuncion,doc_residencia residencia, acta_matrimonio matrimonio,  " +
        " partida_nacimiento nacimiento ,issrl_solicitante isrlSol, issrl_conyugue isrlCon ,pago_vivienda vivienda," +
        " C.estatus estatus, A.cod_estatus cod, A.comentarios observacion from dbo.solicitud_beca A " +
        " inner join dbo.tipo_beca B on (a.tipo_beca=b.cod_tipo_beca) " +
        " inner join dbo.estatus_solicitud C on (C.cod_estatus=A.cod_estatus) " +
        " inner join PRDPSMVAL.dbo.Alumnos D on (A.idAl=D.IdAl) ";

    const string ORDER_BY = " order by a.fecha_solicitud DESC";
    string consulta;
    string update;
    string campo;
    Conexion con;
    protected void Page_Load(object sender, EventArgs e)
    {
        Mensaje.Text = "";
        if (!IsPostBack)
        {
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

            con = new Conexion(false);
            DataTable data = con.search(QUERY_BECAS + ORDER_BY);
            result_reposos.DataSource = data;
            result_reposos.DataBind();
        }
    }



    protected void buscar_Click(object sender, EventArgs e)
    {
        string cedula = "".Equals(txtCedula.Text) ? "" : " and D.cedula='" + txtCedula.Text + "'";
        string where = " where a.tipo_beca=" + dTipoBeca.SelectedValue + " and  a.cod_estatus=" + estatus.SelectedValue + " ";
        string query = QUERY_BECAS + where + cedula + ORDER_BY;

        Conexion con = new Conexion(false);
        DataTable table = con.search(query);

        result_reposos.DataSource = table;
        result_reposos.DataBind();
        cedula = "";
    }

    protected void BtnEditar_Click(object sender, EventArgs e)
    {
        LinkButton BtnEditar = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnEditar.NamingContainer;
        DropDownList control = result_reposos.Rows[row.RowIndex].FindControl("modSolicitud") as DropDownList;
        int id = Convert.ToInt32(this.result_reposos.DataKeys[row.RowIndex].Value);
        TextBox txtComentarios = row.FindControl("txtComentarios") as TextBox;

        if (!"".Equals(txtComentarios.Text))
        {
            con = new Conexion(false);



            if (Session["Cargo"].ToString().Equals("Secretaria") && control.SelectedValue.Equals("2"))
            {
                string query = "update dbo.solicitud_beca  set cod_estatus =" + control.SelectedValue + ", comentarios = '" + txtComentarios.Text + "' where cod_solicitud_beca =" + id + "";
                if (con.update(query))
                {
                    Response.Redirect("becas.aspx");
                }
            }
            else if (!Session["Cargo"].ToString().Equals("Secretaria") && !(control.SelectedValue.Equals("2") || control.SelectedValue.Equals("1")))
            {
                string query = "update dbo.solicitud_beca  set cod_estatus =" + control.SelectedValue + ", comentarios = '" + txtComentarios.Text + "' where cod_solicitud_beca =" + id + "";
                if (con.update(query))
                {
                    Response.Redirect("becas.aspx");
                }
            }
            else
            {
                Mensaje.Text = "Su rol no tiene autorizacion para realizar esta Accion.";
            }
        }
        else { Mensaje.Text = "Añada un Mensaje para Continuar."; }

    }

    protected void result_reposos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        result_reposos.PageIndex = e.NewPageIndex;
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

    protected void BtnVerDocumentos_Click(object sender, EventArgs e)
    {
        LinkButton BtnVer = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnVer.NamingContainer;

        HiddenField hCodBeca = row.FindControl("cod_beca_h") as HiddenField;
        Session.Add("cod_beca_h", hCodBeca.Value);

        HyperLink rsolicitud = row.FindControl("Documento") as HyperLink;
        Session.Add("solicitud_beca", rsolicitud.NavigateUrl);

        HyperLink rCC = row.FindControl("compromiso") as HyperLink;
        Session.Add("carta_compromiso", rCC.NavigateUrl);

        HyperLink rFC = row.FindControl("foto") as HyperLink;
        Session.Add("foto_carnet", rFC.NavigateUrl);

        HyperLink rCN = row.FindControl("notas") as HyperLink;
        Session.Add("certificacion_notas", rCN.NavigateUrl);

        HyperLink rSE = row.FindControl("economico") as HyperLink;
        Session.Add("socio_economico", rSE.NavigateUrl);

        HyperLink rCT = row.FindControl("trabajo") as HyperLink;
        Session.Add("constancia_trabajo", rCT.NavigateUrl);

        HyperLink rD = row.FindControl("defuncion") as HyperLink;
        Session.Add("defuncion", rD.NavigateUrl);

        HyperLink rDR = row.FindControl("residencia") as HyperLink;
        Session.Add("doc_residencia", rDR.NavigateUrl);

        HyperLink rAM = row.FindControl("matrimonio") as HyperLink;
        Session.Add("acta_matrimonio", rAM.NavigateUrl);

        HyperLink rPN = row.FindControl("nacimiento") as HyperLink;
        Session.Add("partida_nacimiento", rPN.NavigateUrl);

        HyperLink rIssrlS = row.FindControl("isrlSol") as HyperLink;
        Session.Add("issrl_solicitante", rIssrlS.NavigateUrl);

        HyperLink rissrlC = row.FindControl("isrlCon") as HyperLink;
        Session.Add("issrl_conyugue", rissrlC.NavigateUrl);

        HyperLink rPV = row.FindControl("vivienda") as HyperLink;
        Session.Add("pago_vivienda", rPV.NavigateUrl);

        Response.Redirect("../forms/vista_documentos.aspx");
    }
}