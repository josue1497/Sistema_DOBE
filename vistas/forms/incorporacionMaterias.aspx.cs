using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class vistas_tablas_incorporacionMaterias : System.Web.UI.Page
{

    Conexion con;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnRegistrar.Enabled = false;
            string query = "SELECT distinct(D.Correo) correo,D.idDoc id, Horarios.Materia+' --- '+D.apellido1+' '+d.nombre1 as nombre" +
                " FROM Horarios INNER JOIN (SELECT idAl,Icc, IdMateria, IdTr, Seccion, Id_Opcion, Lapso, Id_Aula  From Cargas_Academicas ) CargasAca ON Horarios.Icc = CargasAca.Icc  " +
                " AND Horarios.IdTr = CargasAca.IdTr AND Horarios.Seccion = CargasAca.Seccion AND Horarios.Id_Opcion = CargasAca.Id_Opcion  " +
                " AND Horarios.Lapso = CargasAca.Lapso AND Horarios.Id_Materia = CargasAca.IdMateria  " +
                " inner join dbo.docentes D on (horarios.idDoc=D.idDoc) " +
                " WHERE CargasAca.IdAl = " + Session["idAlumno"].ToString() + " AND CargasAca.Icc = " + Session["icc"].ToString() + " AND CargasAca.Lapso = '"+ util.getLapsoActual()+"' ";
            
            con = new Conexion(true);

            DataTable data = con.search(query);

            foreach (DataRow row in data.Rows)
            {
                ListItem item = new ListItem();
                item.Value = Convert.ToInt32(row["id"]) + "";
                item.Text = Convert.ToString(row["nombre"]); ;
                listDoc.Items.Add(item);
                CheckBox check = FindControl(row["id"].ToString()) as CheckBox;
                

            }

            con = new Conexion(false);
            string consulta = "select count(id_Docente) cantidad from dbo.notificacion_reposo where idAl=" + Session["idAlumno"] + " and cod_reposo=" + Session["idReposo"] + "";
            DataSet result = con.buscar(consulta);

            if (Convert.ToInt32(result.Tables[0].Rows[0]["cantidad"]) > 0)
            {
                foreach (ListItem item in listDoc.Items)
                {
                    con = new Conexion(false);
                    DataTable value = con.search(consulta + " and id_Docente=" + item.Value);
                    item.Selected = Convert.ToInt32(value.Rows[0]["cantidad"]) > 0;
                }
            }


        }
    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {

        foreach (ListItem item in listDoc.Items)
        {
            Conexion con;
            if (item.Selected)
            {

                if (ifInsert(item.Value))
                {
                    string insert = "insert into dbo.notificacion_reposo values (" + Session["idAlumno"] + "," + item.Value + "," + Session["idReposo"] + ") ";
                    con = new Conexion(false);
                    if (con.insert(insert))
                    {
                        Mensaje.Text = "Registrado";
                    }
                    else
                    {
                        Mensaje.Text = "Algunos Item no Fueron registrados";
                    }
                }
            }
            else
            {
                if (!ifInsert(item.Value)) {
                    con = new Conexion(false);
                    con.delete(" delete from dbo.notificacion_reposo where idAl=" + Session["idAlumno"] + " and cod_reposo=" + Session["idReposo"] + " and id_Docente=" + item.Value);
                }
            }
        }
    }

    private bool ifInsert(string value)
    {
        con = new Conexion(false);
        string consulta = "select count(id_Docente) cantidad from dbo.notificacion_reposo where idAl=" + Session["idAlumno"] + " and cod_reposo=" + Session["idReposo"] + " and id_Docente=" + value;
        DataSet result = con.buscar(consulta);

        return Convert.ToInt32(result.Tables[0].Rows[0]["cantidad"]) == 0;
        
    }

    protected void listDoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (ListItem item in listDoc.Items) {
            if (item.Selected)
                btnRegistrar.Enabled = true;
            else
                btnRegistrar.Enabled = true;
        }
    }
}