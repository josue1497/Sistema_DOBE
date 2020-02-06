using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class vistas_tablas_filtrarHMedico : System.Web.UI.Page
{

    const string QUERY = "select  DISTINCT(A.Cedula) cedula, PE.carrera, h.cod_historial_medico ID,H.idAl idAl,  a.Fullnombre Alumno, h.paperas_us,h.sarampion_us,h.difteria_us,h.rubeola_vacuna,h.estado_salud_padre,h.estado_salud_madre,h.tuberculosis_fml, " +
        " h.asma_fml,h.diabetes_fml,h.cancer_fml,h.diabetes_fml,h.enfermedad_corazon,h.epilepsia_convulsiones_fml, " +
        " h.tuberculosis_us,h.apendice_us,h.asma_us,h.hepatitis_us,h.varicela_us,h.rubeola_us,h.otras_us,h.cirugias_us, " +
        " h.fecha_cirugias_us,h.alergias_us,h.hernias_us,h.otros_procedimientos_us,h.alcohol_us,h.tabaco_us, " +
        " h.otros_habitos_us,h.epilepcia_us,h.cancer_leucemia_us,h.hernia_sufrido_us,h.fecha_historial " +
        " from dbo.historial_medico H inner join PRDPSMVAL.dbo.Alumnos A on (H.idAl = A.IdAl) " +
        " left join PRDPSMVAL.dbo.San CA on (CA.IdAl=A.IdAl) " +
        " left join PRDPSMVAL.dbo.San1 CB on (CB.IdAl=A.IdAl) " +
        " left join PRDPSMVAL.dbo.San2 CC on (CC.IdAl=A.IdAl) "+
        " LEFT join PRDPSMVAL.dbo.Pensum PE on (PE.ICC in (CA.icc,CB.icc, CC.icc)) ";

    Conexion con;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            con = new Conexion(false);
            DataTable result = con.search(QUERY);
            result_HM.DataSource = result;
            result_HM.DataBind();
        }
    }

    protected void buscar_Click(object sender, EventArgs e)
    {
        string where = " where A.cedula=" + cedulaAl.Text;

        con = new Conexion(false);
        DataTable value = con.search(QUERY + where);
        result_HM.DataSource = value;
        result_HM.DataBind();

    }

    protected void result_HM_DataBound(object sender, EventArgs e)
    {

    }

    protected void result_HM_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        result_HM.PageIndex = e.NewPageIndex;
    }

    protected void BtnVer_Click(object sender, EventArgs e)
    {
        LinkButton BtnEditar = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnEditar.NamingContainer;
        int id = Convert.ToInt32(this.result_HM.DataKeys[row.RowIndex].Value);

        HiddenField idAl = row.FindControl("idAL") as HiddenField;
        Session.Add("idAlumno", idAl.Value);
        Session.Add("mostrar_boton", true);
        Response.Redirect("../../hmedico.aspx");
    }
}