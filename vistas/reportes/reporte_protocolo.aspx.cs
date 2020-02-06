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

    }

    protected void btnReporte_Click(object sender, EventArgs e)
    {
        string lapso = txtLapso.Value; ;
        Session.Add("periodo", lapso);
        string query = "select b.Cedula cedula, b.Fullnombre alumno, a.talla_camisa camisa,a.talla_pantalon pantalon, "+
            " a.talla_zapato zapato,a.direccion , a.telefono, a.lapso lapso  from dbo.solicitud_protocolo a inner join PRDPSMVAL.dbo.Alumnos b on "+
            " (a.idAl=b.idAl) where a.cod_estatus=3 and lapso='" + lapso + "';";

        Conexion con = new Conexion(false);
        DataTable data = con.buscar(query).Tables[0];
        string json = "";
        
        foreach (DataRow row in data.Rows)
        {
            json = json + "{" +
             "\"cedula\":\"" + row["cedula"].ToString() + "\"," +
              "\"alumno\":\"" + row["alumno"].ToString() + "\"," +
              "\"camisa\":\"" + row["camisa"].ToString() + "\"," +
              "\"pantalon\":\"" + row["pantalon"].ToString() + "\"," +
              "\"zapato\":\"" + row["zapato"].ToString() + "\"," +
              "\"direccion\":\"" + row["direccion"].ToString() + "\"," +
              "\"telefono\":\"" + row["telefono"].ToString() + "\"," +
             "\"lapso\":\"" + row["lapso"].ToString() + "\"},";
        }

        Edad.Value = json;
        Session.Add("json", Edad.Value);

    }
}