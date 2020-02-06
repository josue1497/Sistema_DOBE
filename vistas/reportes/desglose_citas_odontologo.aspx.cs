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
        string query = "";

        switch (dTipo.SelectedValue) {
            case "A":
                query = "select COUNT(P.idAl) cant, A.Cedula cedula, A.Fullnombre nombre from dbo.solicitud_cita_odontologo P " +
                    "inner join PRDPSMVAL.dbo.Alumnos A on (P.idAl=A.IdAl) "+
                    "where P.periodo_academico='"+lapso+"' and P.is_docente='N' and P.is_personal='N' "+
                    "GROUP by P.idAl, A.Cedula,A.Fullnombre ";
                break;
            case "D":
                query = "select COUNT(P.idAl) cant, A.Id_Docente cedula, A.Apellido1+' '+A.Apellido2+' '+A.Nombre1+' '+A.Nombre2 nombre "+
                    "from dbo.solicitud_cita_odontologo P inner join PRDPSMVAL.dbo.Docentes A on (P.idAl=A.IdDoc) " +
                    "where P.periodo_academico='"+lapso+"' and P.is_docente='S' and P.is_personal='N' "+
                    "GROUP by P.idAl, A.Id_Docente,A.Apellido1,A.Apellido2,A.Nombre1,a.Nombre2 ";
                break;
            case "P":
                query = "select COUNT(P.idAl) cant, A.cedula cedula, A.apellidos+' '+A.nombres nombre from dbo.solicitud_cita_odontologo P  " +
                   "inner join dbo.personal_administrativo A on (P.idAl=A.cod_personal_Administrativo) " +
                   "where P.periodo_academico='" + lapso + "' and P.is_docente='N' and P.is_personal='S' " +
                   "GROUP by P.idAl, A.cedula, A.apellidos,A.nombres ";
                break;
            default:
                return;
        }
              

        Conexion con = new Conexion(false);
        DataTable data = con.buscar(query).Tables[0];
        string json = "";
        
        foreach (DataRow row in data.Rows)
        {
            json = json + "{" +
             "\"cedula\":\"" + row["cedula"].ToString() + "\"," +
              "\"nombre\":\"" + row["nombre"].ToString() + "\"," +
              "\"cant\":\"" + row["cant"].ToString() + "\"},";
        }

        Edad.Value = json;
        Session.Add("titulo", "Reporte Solicitudes Citas al Odontólogo");
        Session.Add("json", Edad.Value);

    }
}