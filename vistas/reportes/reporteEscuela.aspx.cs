using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class reportes_reporteEscuela : System.Web.UI.Page
{ 
    protected void Page_Load(object sender, EventArgs e)
    {

        string query = "select COUNT(p.CodCarrera) as cant, p.carrera as des from dbo.Alumnos_Carreras a "
+" INNER JOIN dbo.Pensum p on(a.IdPem = p.ICC) "
+" where a.IdAl in (select distinct(SISTEMA_DOBE.dbo.reposo.idAl) from SISTEMA_DOBE.dbo.reposo) "
+" group by(p.carrera)";

        Conexion con = new Conexion(true);
        DataTable data = con.buscar(query).Tables[0];
        string graphicsData = "";
       String json="[";

        foreach (DataRow row in data.Rows) {
            json = json + "{" +
               "\"name\":\"" + row["des"].ToString() + "\"," +
                "\"y\":" + Convert.ToInt32(row["cant"].ToString()) + "," +
                 "\"sliced\": true," +
                 "\"selected\": true },";
        }
        foreach (DataRow row in data.Rows)
        {
            graphicsData = graphicsData + "{" +
             "name:'" + row["des"].ToString() + "'," +
              "y:+" + Convert.ToInt32(row["cant"].ToString()) + "," +
               "sliced: true," +
               "selected: true },";
        }

        graphics.Value = graphicsData;
        Carreras.Value = json+="]";

        Session.Add("json", Carreras.Value);
        Session.Add("graphic", graphics.Value);

        Session.Add("titulo", "Reporte Solicitudes de Reposo según la Especialidad");
    }

}