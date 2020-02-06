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
        string query = "SELECT TOP 10 COUNT(a.cod_razon_visita) cant, a.desc_razon_visita des "+
            " FROM dbo.razon_visita a INNER join dbo.motivo_visita b on (a.cod_razon_visita=b.cod_razon_visita) "+
            " where b.is_personal='S' GROUP by a.cod_razon_visita, a.desc_razon_visita ";

        Conexion con = new Conexion(false);
        DataTable data = con.buscar(query).Tables[0];
        string graphicsData = "";
        String json = "[";

        

        foreach (DataRow row in data.Rows)
        {
            graphicsData = graphicsData + "{" +
             "name:'" + row["des"].ToString() + "'," +
              "y:" + Convert.ToInt32(row["cant"].ToString()) + "," +
               "sliced: true," +
               "selected: true },";
        }


        foreach (DataRow row in data.Rows)
        {
            json = json + "{" +
             "\"name\":\"" + row["des"].ToString() + "\"," +
              "\"y\":" + Convert.ToInt32(row["cant"].ToString()) + "," +
               "\"sliced\": true," +
               "\"selected\": true },";
        }

        Edad.Value = json+="]";
        graphic.Value = graphicsData;

        Session.Add("json", Edad.Value);
        Session.Add("graphic", graphic.Value);
        Session.Add("titulo", "Reporte Visitas del personal al Departamento");
    }
}