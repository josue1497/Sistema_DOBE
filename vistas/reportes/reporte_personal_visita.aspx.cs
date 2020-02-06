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
        
        string query = "select  b.nombres+' '+b.apellidos sujeto,c.desc_cargo cargo, "+
            " d.desc_razon_visita visita, COUNT(b.cod_personal_Administrativo) cant from dbo.motivo_visita a "+
            " inner join dbo.personal_administrativo b on(a.idDoc = b.cod_personal_Administrativo) "+
            " inner join dbo.cargo c on(b.cod_cargo = c.cod_cargo) "+
            " inner join dbo.razon_visita d on(d.cod_razon_visita = a.cod_razon_visita) "+
            "GROUP by b.cod_personal_Administrativo, b.nombres, b.apellidos, d.desc_razon_visita, c.desc_cargo";

        Conexion con = new Conexion(false);
        DataTable data = con.buscar(query).Tables[0];
        String json = "";
        
        foreach (DataRow row in data.Rows)
        {
            json = json + "{" +
             "\"sujeto\":\"" + row["sujeto"].ToString() + "\"," +
              "\"cargo\":\"" + row["cargo"].ToString() + "\"," +
              "\"visita\":\"" + row["visita"].ToString() + "\"," +
             "\"cant\":\"" + row["cant"].ToString() + "\"},";
        }

        Edad.Value = json;
        Session.Add("json", Edad.Value);

    }

    protected void btnReporte_Click(object sender, EventArgs e)
    {
        string lapso = txtLapso.Value; ;
        string query = "select  b.nombres+' '+b.apellidos sujeto,c.desc_cargo cargo, " +
            " d.desc_razon_visita visita, COUNT(b.cod_personal_Administrativo) cant from dbo.motivo_visita a " +
            " inner join dbo.personal_administrativo b on(a.idDoc = b.cod_personal_Administrativo) " +
            " inner join dbo.cargo c on(b.cod_cargo = c.cod_cargo) " +
            " inner join dbo.razon_visita d on(d.cod_razon_visita = a.cod_razon_visita) where b.cedula='"+lapso+"' " +
            "GROUP by b.cod_personal_Administrativo, b.nombres, b.apellidos, d.desc_razon_visita, c.desc_cargo";

        Conexion con = new Conexion(false);
        DataTable data = con.buscar(query).Tables[0];
        String json = "";
        
        foreach (DataRow row in data.Rows)
        {
            json = json + "{" +
             "\"sujeto\":\"" + row["sujeto"].ToString() + "\"," +
              "\"cargo\":\"" + row["cargo"].ToString() + "\"," +
              "\"visita\":\"" + row["visita"].ToString() + "\"," +
             "\"cant\":\"" + row["cant"].ToString() + "\"},";
        }

        Edad.Value = json;
        Session.Add("json", Edad.Value);

    }

}