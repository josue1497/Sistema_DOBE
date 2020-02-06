using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class vistas_estudiantes_mod_beca : System.Web.UI.Page
{
    const string QUERY = " select cod_solicitud_beca ID, tipo_beca tipo, solicitud_beca solicitud, " +
        " carta_compromiso CC, foto_carnet FC, certificacion_notas CN, socio_economico SE, " +
        " constancia_trabajo CT,defuncion D, doc_residencia DR,acta_matrimonio AM, partida_nacimiento PN, " +
        " issrl_solicitante issrlS, issrl_conyugue issrlC, pago_vivienda PV, cod_Estatus estatus, comentarios, lapso , cod_beca " +
        " from dbo.solicitud_beca where ";
    string where = "";
    Conexion con;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            where = " idAl=" + Session["idAlumno"];
            con = new Conexion(false);
            DataTable result = con.search(QUERY + where);

            beca.DataSource = result;
            beca.DataBind();
        }
    }

    protected void beca_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow row in beca.Rows)
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

            LinkButton eliminar = row.FindControl("btnEliminar") as LinkButton;
            LinkButton editar = row.FindControl("BtnEditar") as LinkButton;
            FileUpload solicitud = row.FindControl("dSolicitud") as FileUpload;
            FileUpload CC = row.FindControl("dCC") as FileUpload;
            FileUpload FC = row.FindControl("dFC") as FileUpload;
            FileUpload CN = row.FindControl("dCN") as FileUpload;
            FileUpload SE = row.FindControl("dSE") as FileUpload;
            FileUpload CT = row.FindControl("dCT") as FileUpload;
            FileUpload D = row.FindControl("dD") as FileUpload;
            FileUpload DR = row.FindControl("dDR") as FileUpload;
            FileUpload AM = row.FindControl("dAM") as FileUpload;
            FileUpload PN = row.FindControl("dPN") as FileUpload;
            FileUpload IssrlS = row.FindControl("dissrlS") as FileUpload;
            FileUpload issrlC = row.FindControl("dissrlC") as FileUpload;
            FileUpload PV = row.FindControl("dPV") as FileUpload;

            if (!"1".Equals(hEstatus.Value))
            {
                solicitud.Enabled = false;
                CC.Enabled = false;
                FC.Enabled = false;
                CN.Enabled = false;
                SE.Enabled = false;
                CT.Enabled = false;
                D.Enabled = false;
                DR.Enabled = false;
                AM.Enabled = false;
                PN.Enabled = false;
                IssrlS.Enabled = false;
                issrlC.Enabled = false;
                PV.Enabled = false;

                solicitud.Enabled = false;
                tipo.Enabled = false;
                estatus.Enabled = false;
                editar.Enabled = false;
                eliminar.Enabled = false;

            }

        }
    }

    protected void beca_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        beca.PageIndex = e.NewPageIndex;
    }

    protected void BtnEditar_Click(object sender, EventArgs e)
    {
        LinkButton BtnEditar = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnEditar.NamingContainer;
        int id = Convert.ToInt32(this.beca.DataKeys[row.RowIndex].Value);
        FileUpload solicitud = row.FindControl("dSolicitud") as FileUpload;
        HyperLink rsolicitud = row.FindControl("solicitud") as HyperLink;

        FileUpload CC = row.FindControl("dCC") as FileUpload;
        HyperLink rCC = row.FindControl("hCC") as HyperLink;

        FileUpload FC = row.FindControl("dFC") as FileUpload;
        HyperLink rFC = row.FindControl("hFC") as HyperLink;

        FileUpload CN = row.FindControl("dCN") as FileUpload;
        HyperLink rCN = row.FindControl("hCN") as HyperLink;

        FileUpload SE = row.FindControl("dSE") as FileUpload;
        HyperLink rSE = row.FindControl("hSE") as HyperLink;

        FileUpload CT = row.FindControl("dCT") as FileUpload;
        HyperLink rCT = row.FindControl("hCT") as HyperLink;

        FileUpload D = row.FindControl("dD") as FileUpload;
        HyperLink rD = row.FindControl("hD") as HyperLink;

        FileUpload DR = row.FindControl("dDR") as FileUpload;
        HyperLink rDR = row.FindControl("hDR") as HyperLink;

        FileUpload AM = row.FindControl("dAM") as FileUpload;
        HyperLink rAM = row.FindControl("hAM") as HyperLink;

        FileUpload PN = row.FindControl("dPN") as FileUpload;
        HyperLink rPN = row.FindControl("hPN") as HyperLink;

        FileUpload IssrlS = row.FindControl("dissrlS") as FileUpload;
        HyperLink rIssrlS = row.FindControl("hissrlS") as HyperLink;

        FileUpload issrlC = row.FindControl("dissrlC") as FileUpload;
        HyperLink rissrlC = row.FindControl("hissrlC") as HyperLink;

        FileUpload PV = row.FindControl("dPV") as FileUpload;
        HyperLink rPV = row.FindControl("hPV") as HyperLink;


        string server = "~/files/Becas/" + Session["idAlumno"].ToString() + "/";

        bool error = true;

        if (solicitud.HasFile)
        {
            con = new Conexion(false);
            error = con.update("update dbo.solicitud_beca set  solicitud_beca = '" + loadFile(server, rsolicitud, solicitud) + "' where cod_solicitud_beca=" + id);
            if (!error)
            {
                Mensaje.Text = "Ha ocurrido un Error";
                return;
            }
        }
        if (CC.HasFile)
        {
            con = new Conexion(false);
            error = con.update("update dbo.solicitud_beca set  carta_compromiso = '" + loadFile(server, rCC, CC) + "' where cod_solicitud_beca=" + id);
            if (!error)
            {
                Mensaje.Text = "Ha ocurrido un Error";
                return;
            }
        }
        if (FC.HasFile)
        {
            con = new Conexion(false);
            error = con.update("update dbo.solicitud_beca set  foto_carnet = '" + loadFile(server, rFC, FC) + "' where cod_solicitud_beca=" + id);
            if (!error)
            {
                Mensaje.Text = "Ha ocurrido un Error";
                return;
            }
        }
        if (CN.HasFile)
        {
            con = new Conexion(false);
            error = con.update("update dbo.solicitud_beca set  carta_compromiso = '" + loadFile(server, rCN, CN) + "' where cod_solicitud_beca=" + id);
            if (!error)
            {
                Mensaje.Text = "Ha ocurrido un Error";
                return;
            }
        }
        if (SE.HasFile)
        {
            con = new Conexion(false);
            error = con.update("update dbo.solicitud_beca set  carta_compromiso = '" + loadFile(server, rSE, SE) + "' where cod_solicitud_beca=" + id);
            if (!error)
            {
                Mensaje.Text = "Ha ocurrido un Error";
                return;
            }
        }
        if (CT.HasFile)
        {
            con = new Conexion(false);
            error = con.update("update dbo.solicitud_beca set  carta_compromiso = '" + loadFile(server, rCT, CT) + "' where cod_solicitud_beca=" + id);
            if (!error)
            {
                Mensaje.Text = "Ha ocurrido un Error";
                return;
            }
        }
        if (D.HasFile)
        {
            con = new Conexion(false);
            error = con.update("update dbo.solicitud_beca set  carta_compromiso = '" + loadFile(server, rD, D) + "' where cod_solicitud_beca=" + id);
            {
                Mensaje.Text = "Ha ocurrido un Error";
                return;
            }
        }
        if (DR.HasFile)
        {
            con = new Conexion(false);
            error = con.update("update dbo.solicitud_beca set  carta_compromiso = '" + loadFile(server, rDR, DR) + "' where cod_solicitud_beca=" + id);
            if (!error)
            {
                Mensaje.Text = "Ha ocurrido un Error";
                return;
            }
        }
        if (AM.HasFile)
        {
            con = new Conexion(false);
            error = con.update("update dbo.solicitud_beca set  carta_compromiso = '" + loadFile(server, rAM, AM) + "' where cod_solicitud_beca=" + id);
            if (!error)
            {
                Mensaje.Text = "Ha ocurrido un Error";
                return;
            }
        }
        if (PN.HasFile)
        {
            con = new Conexion(false);
            error = con.update("update dbo.solicitud_beca set  carta_compromiso = '" + loadFile(server, rPN, PN) + "' where cod_solicitud_beca=" + id);
            if (!error)
            {
                Mensaje.Text = "Ha ocurrido un Error";
                return;
            }
        }
        if (IssrlS.HasFile)
        {
            con = new Conexion(false);
            error = con.update("update dbo.solicitud_beca set  carta_compromiso = '" + loadFile(server, rIssrlS, IssrlS) + "' where cod_solicitud_beca=" + id);
            if (!error)
            {
                Mensaje.Text = "Ha ocurrido un Error";
                return;
            }
        }
        if (issrlC.HasFile)
        {
            con = new Conexion(false);
            error = con.update("update dbo.solicitud_beca set  carta_compromiso = '" + loadFile(server, rissrlC, issrlC) + "' where cod_solicitud_beca=" + id);
            if (!error)
            {
                Mensaje.Text = "Ha ocurrido un Error";
                return;
            }
        }
        if (PV.HasFile)
        {
            con = new Conexion(false);
            error = con.update("update dbo.solicitud_beca set  carta_compromiso = '" + loadFile(server, rPV, PV) + "' where cod_solicitud_beca=" + id);
            if (!error)
            {
                Mensaje.Text = "Ha ocurrido un Error";
                return;
            }
        }

        DropDownList tipo = row.FindControl("modArticulo") as DropDownList;
        HiddenField hTipo = row.FindControl("hiddenArticulo") as HiddenField;

        if (!tipo.SelectedValue.Equals(hTipo.Value))
        {
            con = new Conexion(false);
            error = con.update("update dbo.solicitud_beca set  tipo_beca = " + tipo.SelectedValue + " where cod_solicitud_beca=" + id);
            if (!error)
            {
                Mensaje.Text = "Ha ocurrido un Error";
                return;
            }
        }


        if (error)
        {
            Mensaje.Text = "Exitoso";
        }
    }

    private string loadFile(string ruta, HyperLink file1, FileUpload file2)
    {
        string result = "";
        string archivo = file2.FileName;
        if (Directory.Exists(Server.MapPath(ruta)))
        {
            result = ruta + archivo;
            file2.SaveAs(Server.MapPath(result));
            if (!"".Equals(file1.NavigateUrl))
                File.Delete(Server.MapPath(file1.NavigateUrl));
        }

        return result;
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {

        LinkButton BtnEditar = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnEditar.NamingContainer;
        int id = Convert.ToInt32(this.beca.DataKeys[row.RowIndex].Value);
        string server = "~/files/Becas/" + Session["idAlumno"].ToString() + "/";
        string delete = "delete from dbo.solicitud_beca where cod_solicitud_beca=" + id;

        con = new Conexion(false);

        if (con.delete(delete))
        {
            Directory.Delete(Server.MapPath(server), true);
            Mensaje.Text = "Exitoso";
            Response.Redirect("beca.aspx");
        }
        else { Mensaje.Text = "Error al Procesar"; }

    }

    protected void btnVer_Click(object sender, EventArgs e)
    {

        LinkButton BtnEditar = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnEditar.NamingContainer;
        int id = Convert.ToInt32(this.beca.DataKeys[row.RowIndex].Value);

      
        HiddenField hCodBeca = row.FindControl("cod_beca_h") as HiddenField;
        Session.Add("id_beca", id);
        Session.Add("cod_beca_h", hCodBeca.Value);

        HyperLink rsolicitud = row.FindControl("solicitud") as HyperLink;
       
        HyperLink rCC = row.FindControl("hCC") as HyperLink;

        HyperLink rFC = row.FindControl("hFC") as HyperLink;

        HyperLink rCN = row.FindControl("hCN") as HyperLink;

        HyperLink rSE = row.FindControl("hSE") as HyperLink;

        HyperLink rCT = row.FindControl("hCT") as HyperLink;

        HyperLink rD = row.FindControl("hD") as HyperLink;

        HyperLink rDR = row.FindControl("hDR") as HyperLink;

        HyperLink rAM = row.FindControl("hAM") as HyperLink;

        HyperLink rPN = row.FindControl("hPN") as HyperLink;

        HyperLink rIssrlS = row.FindControl("hissrlS") as HyperLink;

        HyperLink rissrlC = row.FindControl("hissrlC") as HyperLink;

        HyperLink rPV = row.FindControl("hPV") as HyperLink;

        Session.Add("solicitud_beca", rsolicitud.NavigateUrl);

        Session.Add("carta_compromiso", rCC.NavigateUrl);

        Session.Add("foto_carnet", rFC.NavigateUrl);

        Session.Add("certificacion_notas", rCN.NavigateUrl);

        Session.Add("socio_economico", rSE.NavigateUrl);

        Session.Add("constancia_trabajo", rCT.NavigateUrl);

        Session.Add("defuncion", rD.NavigateUrl);

        Session.Add("doc_residencia", rDR.NavigateUrl);

        Session.Add("acta_matrimonio", rAM.NavigateUrl);

        Session.Add("partida_nacimiento", rPN.NavigateUrl);

        Session.Add("issrl_solicitante", rIssrlS.NavigateUrl);

        Session.Add("issrl_conyugue", rissrlC.NavigateUrl);

        Session.Add("pago_vivienda", rPV.NavigateUrl);


        Response.Redirect("../forms/vista_documentos_alumnos.aspx");
    }
}