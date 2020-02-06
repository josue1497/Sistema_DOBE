using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.IO;
public partial class vistas_tablas_reposos : System.Web.UI.Page
{

    public string recordId;
    public string accion;
    string consulta;
    const string query = "select rep.cod_reposo as 'ID',rep.idAl as idAl, al.Fullnombre as Alumno, reposo as Documento , med.nombre_medico+' '+med.apellido_medico as Medico,rep.desc_patologia patologia, t_rep.tipo_reposo as Tipo,  est.estatus as Estatus, rep.cod_estatus cod from dbo.reposo rep "
    + " inner join dbo.medico med on(med.prima_medico = rep.prima_medico) "
    + " inner join dbo.tipo_reposo t_rep on(t_rep.cod_tipo_reposo = rep.cod_tipo_reposo) "
    + " inner join [PRDPSMVAL].dbo.Alumnos al on(rep.idAl = al.IdAl) "
    + " inner join dbo.estatus_solicitud est on (rep.cod_estatus = est.cod_estatus) where is_docente='N' and is_personal='N'  ";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Conexion con = new Conexion(false);
            DataTable table = con.buscar("select cod_tipo_reposo codigo, tipo_reposo tipo from dbo.tipo_reposo;").Tables[0];

            foreach (DataRow row in table.Rows)
            {
                tipoReposo.Items.Insert(Convert.ToInt32(row["codigo"]), Convert.ToString(row["tipo"]));
                tipoReposo.Items.FindByValue(Convert.ToString(row["tipo"])).Value = Convert.ToString(row["codigo"]);
            }

            if (Session["Cargo"] != null)
            {
                consulta = "select cod_estatus codigo, estatus as estatus from estatus_solicitud";
            }
            con = new Conexion(false);
            DataSet result = con.buscar(consulta);
            estatus.DataSource = result;
            estatus.DataTextField = result.Tables[0].Columns["estatus"].ToString();
            estatus.DataValueField = result.Tables[0].Columns["codigo"].ToString();
            estatus.DataBind();

            findAll();

        }

    }

    protected void buscar_Click(object sender, EventArgs e)
    {
        if (tipoReposo.SelectedIndex == 0)
        {
            findAll();
        }
        else
        {
            string where = " and rep.cod_tipo_reposo=" + tipoReposo.SelectedIndex + " and  rep.fecha_inicio>='" + fechaIni.Value + "' and rep.fecha_fin<='" + FechaFin.Value + "'"
                            + " and rep.cod_estatus=" + estatus.SelectedValue + ";";
            string tempconsulta = query + where;
            Conexion con = new Conexion(false);
            DataTable table = con.search(tempconsulta);

            result_reposos.DataSource = table;
            result_reposos.DataBind();
        }
    }

    protected void BtnEditar_Click(object sender, EventArgs e)
    {

        LinkButton BtnEditar = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnEditar.NamingContainer;
        DropDownList control = result_reposos.Rows[row.RowIndex].FindControl("modSolicitud") as DropDownList;
        int id = Convert.ToInt32(this.result_reposos.DataKeys[row.RowIndex].Value);
        HiddenField field = row.FindControl("idAl") as HiddenField;
        int idAl = Convert.ToInt32(field.Value);
        HiddenField value = row.FindControl("hiddenStatus") as HiddenField;
        string estatus_anterior = value.Value;

        Conexion con = new Conexion(false);

        if (Session["Cargo"].ToString().Equals("Secretaria") && control.SelectedValue.Equals("2"))
        {
           
            string query = "update dbo.reposo set cod_estatus =" + control.SelectedValue + " where cod_reposo =" + id + "";
            if (con.update(query))
            {
                Response.Redirect("reposos.aspx");
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "window.alert('ERROR!! Su rol no tiene autorizacion para realizar esta Accion.')", true);
        }

        if (!Session["Cargo"].ToString().Equals("Secretaria") && !(control.SelectedValue.Equals("2") || control.SelectedValue.Equals("1")))
        {
            if ("3".Equals(estatus_anterior) && control.SelectedValue.Equals("2"))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "window.alert('ERROR!! Operacion Invalida.')", true);
            }
            else {
            string query = "update dbo.reposo set cod_estatus =" + control.SelectedValue + " where cod_reposo =" + id + "";
            if (con.update(query))
            {
                if (control.SelectedValue.Equals("3"))
                {
                    sentEmail(idAl, id);
                }
                Response.Redirect("reposos.aspx");
                }
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "window.alert('ERROR!! Su rol no tiene autorizacion para realizar esta Accion.')", true);

        }


    }

    private void findAll()
    {

        Conexion con = new Conexion(false);
        DataTable resulttable = con.search(query);

        result_reposos.DataSource = resulttable;
        result_reposos.DataBind();
    }



    protected void result_reposos_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow row in result_reposos.Rows)
        {
            DropDownList list = row.FindControl("modSolicitud") as DropDownList;
            HiddenField value = row.FindControl("hiddenStatus") as HiddenField;

            if (list != null && value != null)
            {
                list.SelectedValue = value.Value;
                if ("Secretaria".Equals(Session["Cargo"].ToString())&&("3".Equals(value.Value) || "4".Equals(value.Value))) {
                    list.Enabled = false;
                }
            }


        }
    }

    protected void btnIncorporar_Click(object sender, EventArgs e)
    {
        LinkButton button = (LinkButton)sender;
        GridViewRow row = (GridViewRow)button.NamingContainer;

        int id = Convert.ToInt32(this.result_reposos.DataKeys[row.RowIndex].Value);
        Session.Add("idReposo", id);
        HiddenField field = row.FindControl("idAl") as HiddenField;
        int idAl = Convert.ToInt32(field.Value);
        Session.Add("idAlumno", idAl);

        int icc = getIcc(idAl);
        Session.Add("icc", icc);
        if (icc > 0)
        {
            string vtn = "window.open('../forms/incorporacionMaterias.aspx','scrollbars=yes,resizable=yes','height=400', 'width=200')";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup", vtn, true);
        }
        else { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "window.alert('ERROR!! No se puede Abrir la ventana Emergente!')", true); }
    }

    private int getIcc(int idAl)
    {

        string localquery = "select DISTINCT(icc) icc from dbo.Cargas_Academicas where idAl =" + idAl;
        Conexion con = new Conexion(true);
        DataSet localData = con.buscar(localquery);
        int revalue = 0;
        if (localData.Tables[0].Rows.Count > 0)
        {
            revalue = Convert.ToInt32(localData.Tables[0].Rows[0]["icc"]);
        }

        return revalue;
    }

    private void sentEmail(int idAl, int idReposo)
    {

        MailMessage mmsg = new MailMessage();

        string correos = "select D.Correo correo from dbo.notificacion_reposo N inner join PRDPSMVAL.dbo.Docentes D on (N.id_Docente=D.IdDoc) where idAl=" + idAl + " and cod_reposo=" + idReposo + ";";
        Conexion conexion = new Conexion(false);
        DataTable result = conexion.search(correos);

        foreach (DataRow row in result.Rows)
        {
            string value = row["correo"].ToString();
            if (!value.Equals("") && util.IsValidEmail(row["correo"].ToString())) { }
                mmsg.To.Add(new MailAddress(value));
        }
        //mmsg.To.Add(new MailAddress("josuermartinezm@gmail.com"));

        string query_reposo = "select a.Fullnombre alumno, r.desc_patologia patologia, m.nombre_medico+' '+m.apellido_medico medico, r.fecha_inicio fI, r.fecha_fin fF " +
        "from dbo.reposo r inner " +" join dbo.medico m on r.prima_medico = m.prima_medico " + " inner join PRDPSMVAL.dbo.Alumnos a on a.idal = r.idAl where r.cod_reposo="+idReposo;

        conexion = new Conexion(false);
        result = conexion.search(query_reposo);

        string alumno = result.Rows[0]["alumno"].ToString();
        string patologia = result.Rows[0]["patologia"].ToString();
        string medico = result.Rows[0]["medico"].ToString();
        string fI = Convert.ToDateTime( result.Rows[0]["fI"].ToString()).ToString("dd-MM-yyyy");
        string fF = Convert.ToDateTime( result.Rows[0]["fF"].ToString()).ToString("dd-MM-yyyy");


        mmsg.Subject = "Notificacion de Reposo";
        mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
        mmsg.Body = createEmailBody(alumno, patologia, medico, fI, fF);
        mmsg.BodyEncoding = System.Text.Encoding.UTF8;
        mmsg.IsBodyHtml = true;
        mmsg.From = new MailAddress("dobe1@psmvalencia.edu.ve");
        SmtpClient cliente = new SmtpClient();
        cliente.Credentials = new NetworkCredential("dobe1@psmvalencia.edu.ve", "Leon2018");
        cliente.Port = 587;
        cliente.EnableSsl = true;
        cliente.Host = "smtp.gmail.com"; //Para Gmail "smtp.gmail.com";
        cliente.EnableSsl = true;
        try
        {
            //Enviamos el mensaje      
            cliente.Send(mmsg);
        }
        catch (System.Net.Mail.SmtpException ex)
        {
            Mensaje.Text = "Error al Enviar Correo: " + ex.Message;
            //Aquí gestionamos los errores al intentar enviar el correo
        }
    }
    private string createEmailBody(string nombreAlumno, string patologia, string medico, string fechaI, string fechaF)
    {
        string body = string.Empty;
        //using streamreader for reading my htmltemplate  
        using (StreamReader reader = new StreamReader(Server.MapPath("~/mail/mailTemplate.html")))
        {
            body = reader.ReadToEnd();
        }

        body = body.Replace("{Nombre_Alumno}", nombreAlumno); //replacing the required things  
        body = body.Replace("{patologia}", patologia);
        body = body.Replace("{medico}", medico);
        body = body.Replace("{fecha_inicial}", fechaI);
        body = body.Replace("{fecha_final}", fechaF);

        return body;

    }

    protected void result_reposos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        result_reposos.PageIndex = e.NewPageIndex;
    }
}