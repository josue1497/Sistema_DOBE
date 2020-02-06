using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class reportes_report_HMalumno : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Conexion con = new Conexion(true);
        DataSet result = con.buscar("SELECT COUNT(idAl) as Alumnos from alumnos;");

        string numeroAlumnos = result.Tables[0].Rows[0]["Alumnos"].ToString();

        TotalAlumnos.Value = numeroAlumnos;

        con = new Conexion(false);
        result = con.buscar("select COUNT(idAl) as HM from historial_medico;");

        string registrados = result.Tables[0].Rows[0]["HM"].ToString();

        AlumnosRegistrados.Value = registrados;

        
        Session.Add("graphic", AlumnosRegistrados.Value);
        Session.Add("titulo", "Reporte gráfica el porcentaje de Estudiantes con Historial Medico Cargado");
    }
}