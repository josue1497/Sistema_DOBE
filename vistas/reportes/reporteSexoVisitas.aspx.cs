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
       
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        string query = dTipo.SelectedValue.Equals("D")?
            "select COUNT(D.Sexo) cant, case when d.Sexo=0 then 'Masculino' else 'Femenino' end  as des "
          + "from PRDPSMVAL.dbo.Docentes D inner join dbo.motivo_visita V on (V.idDoc=D.IdDoc) GROUP by D.Sexo "
                   : "select COUNT(P.cod_sexo) cant, S.genero des from dbo.motivo_visita V "+
                   " inner join dbo.personal_administrativo P on (P.cod_personal_Administrativo=V.idDoc) "+
                   "inner join dbo.sexo S on (S.cod_sexo=P.cod_sexo) GROUP by P.cod_sexo,S.genero";

        Conexion con = new Conexion(false);
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


        Sexo.Value = json += "]";
        graphic.Value = graphicsData;

        Session.Add("json", Sexo.Value);
        Session.Add("graphic", graphic.Value);
        Session.Add("titulo", "Reposo a Estudiantes según su Genero");
    }
}