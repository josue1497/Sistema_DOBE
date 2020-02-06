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
        string query = "select count(b.cod_sexo) cant, c.genero des from dbo.reposo a "+
  "inner join dbo.personal_administrativo b on(a.idAl = b.cod_personal_Administrativo) "+
 " inner join dbo.sexo c on(c.cod_sexo = b.cod_sexo) "+
  " group by c.cod_sexo, c.genero; ";

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
        Session.Add("titulo", "Reporte Clasifica los Reposos del personal por su género");
    }
}