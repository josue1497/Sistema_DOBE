using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class reportes_reportEdad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string query = "select cast(datediff(dd,FechaNacimiento,GETDATE()) / 365.25 as int) as edad, "
+ " count(cast(datediff(dd, FechaNacimiento, GETDATE()) / 365.25 as int)) as cant from dbo.Alumnos a "
  + " where a.IdAl in (select distinct(SISTEMA_DOBE.dbo.reposo.idAl) from SISTEMA_DOBE.dbo.reposo where is_docente='N' and is_personal='N') "
+ " GROUP by((cast(datediff(dd, FechaNacimiento, GETDATE()) / 365.25 as int))); ";

        Conexion con = new Conexion(true);
        DataTable data = con.buscar(query).Tables[0];
        string graphicsData = "";
        String json = "[";

        

        foreach (DataRow row in data.Rows)
        {
            graphicsData = graphicsData + "{" +
             "name:'" + row["edad"].ToString() + " años'," +
              "y:" + Convert.ToInt32(row["cant"].ToString()) + "," +
               "sliced: true," +
               "selected: true },";
        }


        foreach (DataRow row in data.Rows)
        {
            json = json + "{" +
             "\"name\":\"" + row["edad"].ToString() + " años\"," +
              "\"y\":" + Convert.ToInt32(row["cant"].ToString()) + "," +
               "\"sliced\": true," +
               "\"selected\": true },";
        }

        Edad.Value = json+="]";
        graphic.Value = graphicsData;

        Session.Add("json", Edad.Value);
        Session.Add("graphic", graphic.Value);

        Session.Add("titulo", "Reporte Clasifica los Reposos por Edad del Solicitante");
    }
}