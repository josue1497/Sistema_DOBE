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


        Session.Add("periodo", txtLapso.Value);

        string renovada = "select a.cod_solicitud_beca id,b.Fullnombre alumno, a.cod_beca,  d.tipo_beca tipo, " +
            "a.iraa iraa, a.comentarios observaciones, '   ' desicion  from dbo.solicitud_beca a inner join PRDPSMVAL.dbo.Alumnos b on (a.idAl=b.IdAl) " +
        " inner join dbo.estatus_solicitud c on(a.cod_estatus = c.cod_estatus) " +
        " inner join dbo.tipo_beca d on(a.tipo_beca = d.cod_tipo_beca) " +
        "where a.lapso = '" + txtLapso.Value + "' and renovada = 'S'; ";

        string direccion_nacional = "select a.cod_solicitud_beca id,b.Fullnombre alumno, a.cod_beca,  d.tipo_beca tipo, " +
            "a.iraa iraa, a.comentarios observaciones, '   ' desicion  from dbo.solicitud_beca a inner join PRDPSMVAL.dbo.Alumnos b on (a.idAl=b.IdAl) " +
        " inner join dbo.estatus_solicitud c on(a.cod_estatus = c.cod_estatus) " +
        "inner join dbo.tipo_beca d on(a.tipo_beca = d.cod_tipo_beca) " +
        "where a.lapso = '" + txtLapso.Value + "' and d.cod_tipo_beca=1; ";

        string solicitudes = "select a.cod_solicitud_beca id,b.Fullnombre alumno, a.cod_beca, " +
            "a.iraa iraa, a.comentarios observaciones, '   ' desicion  from dbo.solicitud_beca a inner join PRDPSMVAL.dbo.Alumnos b on (a.idAl=b.IdAl) " +
        " inner join dbo.estatus_solicitud c on(a.cod_estatus = c.cod_estatus) " +
        "inner join dbo.tipo_beca d on(a.tipo_beca = d.cod_tipo_beca) " +
        "where a.lapso = '" + txtLapso.Value + "' ";

        string becas = " select COUNT(d.cod_tipo_beca) cant, d.tipo_beca from dbo.solicitud_beca a " +
            " inner join PRDPSMVAL.dbo.Alumnos b on(a.idAl = b.IdAl) " +
            " inner join dbo.estatus_solicitud c on(a.cod_estatus = c.cod_estatus) " +
            " inner join dbo.tipo_beca d on(a.tipo_beca = d.cod_tipo_beca) " +
            "where a.lapso = '" + txtLapso.Value + "' GROUP by d.cod_tipo_beca, d.tipo_beca;";

        Conexion con = new Conexion(false);
        DataTable data_renovada = con.buscar(renovada).Tables[0];

        con = new Conexion(false);
        DataTable data_direccion = con.buscar(direccion_nacional).Tables[0];

        con = new Conexion(false);
        DataTable data_solicitudes = con.buscar(solicitudes).Tables[0];

        con = new Conexion(false);
        DataTable data_becas = con.buscar(becas).Tables[0];



        String json = "";

        foreach (DataRow row in data_renovada.Rows)
        {
            json = json + "{" +
             "\"id\":\"" + row["id"].ToString() + " \"," +
              "\"alumno\":\"" + row["alumno"].ToString() + "\"," +
              "\"cod_beca\":\"" + row["cod_beca"].ToString() + "\"," +
              "\"tipo\":\"" + row["tipo"].ToString() + "\"," +
              "\"iraa\":\"" + row["iraa"].ToString() + "\"," +
              "\"observaciones\":\"" + row["observaciones"].ToString() + "\"," +
               "\"desicion\":\"" + row["desicion"].ToString() + "\"},";
        }
        renovacion.Value = json;
        Session.Add("beca_renovadas", json);


        json = "";

        foreach (DataRow row in data_direccion.Rows)
        {
            json = json + "{" +
             "\"id\":\"" + row["id"].ToString() + " \"," +
              "\"alumno\":\"" + row["alumno"].ToString() + "\"," +
              "\"cod_beca\":\"" + row["cod_beca"].ToString() + "\"," +
              "\"tipo\":\"" + row["tipo"].ToString() + "\"," +
              "\"iraa\":\"" + row["iraa"].ToString() + "\"," +
              "\"observaciones\":\"" + row["observaciones"].ToString() + "\"," +
               "\"desicion\":\"" + row["desicion"].ToString() + "\"},";
        }
        direccion.Value = json;
        Session.Add("beca_direccion", json );

        json = "";

        foreach (DataRow row in data_solicitudes.Rows)
        {
            json = json + "{" +
             "\"id\":\"" + row["id"].ToString() + " \"," +
              "\"alumno\":\"" + row["alumno"].ToString() + "\"," +
              "\"cod_beca\":\"" + row["cod_beca"].ToString() + "\"," +
              "\"iraa\":\"" + row["iraa"].ToString() + "\"," +
              "\"observaciones\":\"" + row["observaciones"].ToString() + "\"," +
               "\"desicion\":\"" + row["desicion"].ToString() + "\"},";
        }
        solicitada.Value = json;
        Session.Add("solicitadas", json);

        json = "";

        foreach (DataRow row in data_becas.Rows)
        {
            json = json + "{" +
             "\"cant\":\"" + row["cant"].ToString() + " \"," +
              "\"tipo_beca\":\"" + row["tipo_beca"].ToString() + "\"},";
        }
        becas_todas.Value = json ;
        Session.Add("relacion", json );
    }
}