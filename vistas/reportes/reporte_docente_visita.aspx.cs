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
        
        string query = "select COUNT(a.idDoc)cant, b.Nombre1+' '+b.Nombre2+' '+b.Apellido1+' '+b.Apellido2 sujeto,"+
            " c.desc_razon_visita visita from dbo.motivo_visita a inner "+
            " join PRDPSMVAL.dbo.Docentes b on (a.idDoc = b.IdDoc) inner join "+
            " dbo.razon_visita c on (a.cod_razon_visita = c.cod_razon_visita) "+
            " GROUP by a.idDoc, b.Nombre1,b.Nombre2,b.Apellido1,b.Apellido2, c.desc_razon_visita; ";

        Conexion con = new Conexion(false);
        DataTable data = con.buscar(query).Tables[0];
        string json = "";
        
        foreach (DataRow row in data.Rows)
        {
            json = json + "{" +
             "\"sujeto\":\"" + row["sujeto"].ToString() + "\"," +
              "\"visita\":\"" + row["visita"].ToString() + "\"," +
             "\"cant\":\"" + row["cant"].ToString() + "\"},";
        }

        Edad.Value = json;
        Session.Add("json", Edad.Value);

    }

    protected void btnReporte_Click(object sender, EventArgs e)
    {
        string lapso = txtLapso.Value; ;
        string query = "select COUNT(a.idDoc)cant, b.Nombre1+' '+b.Nombre2+' '+b.Apellido1+' '+b.Apellido2 sujeto," +
           " c.desc_razon_visita visita from dbo.motivo_visita a inner " +
           " join PRDPSMVAL.dbo.Docentes b on (a.idDoc = b.IdDoc) inner join " +
           " dbo.razon_visita c on (a.cod_razon_visita = c.cod_razon_visita) " +
           "  where b.Id_Docente="+lapso+" GROUP by a.idDoc, b.Nombre1,b.Nombre2,b.Apellido1,b.Apellido2, c.desc_razon_visita; ";

        Conexion con = new Conexion(false);
        DataTable data = con.buscar(query).Tables[0];
        string json = "";

        foreach (DataRow row in data.Rows)
        {
            json = json + "{" +
             "\"sujeto\":\"" + row["sujeto"].ToString() + "\"," +
              "\"visita\":\"" + row["visita"].ToString() + "\"," +
             "\"cant\":\"" + row["cant"].ToString() + "\"},";
        }

        Edad.Value = json;
        Session.Add("json", Edad.Value);


    }

}