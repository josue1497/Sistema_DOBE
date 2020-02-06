using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class reportes_reporteSexo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string query = "select case when dbo.Alumnos.Sexo=0 then 'Masculino' else 'Femenino' end as des, count(dbo.Alumnos.Sexo) as cant "
                        +"from dbo.Alumnos where IdAl in (select distinct(SISTEMA_DOBE.dbo.reposo.idAl) from SISTEMA_DOBE.dbo.reposo)  "
                    +"group by(dbo.Alumnos.Sexo) ORDER by(dbo.Alumnos.Sexo)";

        Conexion con = new Conexion(true);
        DataTable data = con.buscar(query).Tables[0];
        string graphicsData = "";
        string json = "[";

        foreach (DataRow row in data.Rows)
        {
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


        Sexo.Value = json+="]";
        graphic.Value = graphicsData;

        Session.Add("json", Sexo.Value);
        Session.Add("graphic", graphic.Value);
        Session.Add("titulo", "Reposo a Estudiantes según su Genero");
    }
}