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
        string query = "select COUNT(d.cod_cargo) cant, d.desc_cargo des from dbo.motivo_visita a inner join dbo.personal_administrativo b on(a.idDoc = b.cod_personal_Administrativo) inner join dbo.cargo d on(d.cod_cargo = b.cod_cargo) where a.is_personal = 'S' GROUP by d.cod_cargo, d.desc_cargo; ";

        string query2 = "select COUNT(mt.IdDoc) cant, 'Docente' des from PRDPSMVAL.dbo.Docentes doc inner join dbo.motivo_visita mt on (mt.idDoc=doc.IdDoc) where mt.is_personal='N';";

        Conexion con = new Conexion(false);
        DataTable data = con.buscar(query).Tables[0];
        con = new Conexion(false);
        DataTable data2 = con.buscar(query2).Tables[0];
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

        foreach (DataRow row in data2.Rows)
        {
            graphicsData = graphicsData + "{" +
             "name:'" + row["des"].ToString() + " '," +
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

        foreach (DataRow row in data2.Rows)
        {
            json = json + "{" +
             "\"name\":\"" + row["des"].ToString() + " \"," +
              "\"y\":" + Convert.ToInt32(row["cant"].ToString()) + "," +
               "\"sliced\": true," +
               "\"selected\": true },";
        }

        

        Edad.Value = json += "]";
        graphic.Value = graphicsData;

        Session.Add("json", Edad.Value);
        Session.Add("graphic", graphic.Value);
        Session.Add("titulo", "Reporte Visitas del personal al Departamento");
    }
}