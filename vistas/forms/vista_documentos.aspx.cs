using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class vistas_forms_coral_banda : System.Web.UI.Page
{

    Conexion con;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            solicitud_beca.NavigateUrl = Session["solicitud_beca"].ToString();
            carta_compromiso.NavigateUrl= Session["carta_compromiso"].ToString();

            foto_carnet.NavigateUrl = Session["foto_carnet"].ToString();
            certificacion_notas.NavigateUrl = Session["certificacion_notas"].ToString();

            socio_economico.NavigateUrl = Session["socio_economico"].ToString();
            constancia_trabajo.NavigateUrl = Session["constancia_trabajo"].ToString();

            defuncion.NavigateUrl = Session["defuncion"].ToString();
            doc_residencia.NavigateUrl = Session["doc_residencia"].ToString();

            acta_matrimonio.NavigateUrl = Session["acta_matrimonio"].ToString();
            partida_nacimiento.NavigateUrl = Session["partida_nacimiento"].ToString();

            isrl_solicitante.NavigateUrl = Session["issrl_solicitante"].ToString();
            isrl_conyugue.NavigateUrl = Session["issrl_conyugue"].ToString();

            pago_vivienda.NavigateUrl = Session["pago_vivienda"].ToString();
        }

    }



    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("../tablas/becas.aspx");
    }
}