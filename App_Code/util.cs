using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;

/// <summary>
/// Descripción breve de util
/// </summary>
public class util
{
    public static Conexion con_ext = new Conexion(false);
    public static Conexion con_int = new Conexion(true);

    public static string getLapsoActual()
    {
        if (con_int.buscar("select lapso from dbo.lapsos where activo=1;").Tables.Count > 0)
            return con_int.buscar("select lapso from dbo.lapsos where activo=1;").Tables[0].Rows[0][0].ToString();
        else
            return "";
    }

    public static string getLapsoAnterior()
    {
        if (con_int.buscar("select lapsoAnt from dbo.Sys_Conf;").Tables.Count > 0)
            return con_int.buscar("select lapsoAnt from dbo.Sys_Conf;").Tables[0].Rows[0][0].ToString();
        else
            return "";
    }

    public static int promedioAlumnoSan1(int idAlumno)
    {


        string q1 = "select case when AVG(calificacion) Is null then 0 else AVG(calificacion) end as promedio from dbo.san1  where idAl=";

        con_int = new Conexion(true);
        int value1 = Convert.ToInt32(con_int.buscar(q1 + idAlumno).Tables[0].Rows[0][0]);

        if (value1 > 0)
            return value1;

        return 0;
    }

    public static int promedioAlumnoSan2(int idAlumno)
    {

        string q2 = "select case when AVG(calificacion) Is null then 0 else AVG(calificacion) end as promedio from dbo.san2  where idAl=";


        con_int = new Conexion(true);
        int value2 = Convert.ToInt32(con_int.buscar(q2 + idAlumno).Tables[0].Rows[0][0]);
        if (value2 > 0)
            return value2;
        return 0;
    }

    public static bool calificaBeca(int idAl)
    {
        return promedioAlumnoSan1(idAl) >= 16 || promedioAlumnoSan2(idAl) >= 16;
    }



    public static bool IsValidEmail(string email)
    {
        String expresion;
        expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        if (Regex.IsMatch(email, expresion))
        {
            if (Regex.Replace(email, expresion, String.Empty).Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public static int getCodCarreraForAlumno(int idAl) {

        string query = " select  DISTINCT(e.CodCarrera) as carrera from "+
            " PRDPSMVAL.dbo.Alumnos c INNER join PRDPSMVAL.dbo.Cargas_Academicas d on (d.IdAl=c.IdAl) "+
            " INNER join PRDPSMVAL.dbo.Pensum e on (d.Icc=e.ICC) where c.idAl="+idAl+" ";
                
        int value2 = Convert.ToInt32(con_int.buscar(query).Tables[0].Rows[0][0]);
        if (value2 > 0)
            return value2;
        return 0;
    }

    public static decimal getPromedioLapsoAnterior(int id) {
        string query = "select case when aVG(calificacion*1.0) Is null then 0 else aVG(calificacion*1.0) end as promedio "+
            " from dbo.san1 where IdAl="+id+";";

        decimal result = Decimal.Round(Convert.ToDecimal(promedioAlumnoSan1(id)),2);
        if (result > 0)
            return result;
        return 0;
    }

}