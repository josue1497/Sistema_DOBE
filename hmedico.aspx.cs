using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data;
public partial class hmedico : System.Web.UI.Page
{
    bool exist;
    int id;
    string _paperas_us;
    string _sarampion_us;
    string _difteria_us;
    string _rubeola_vacuna;
    string _estado_salud_padre;
    string _estado_salud_madre;
    bool _tuberculosis_fml;
    bool _asma_fml;
    bool _diabetes_fml;
    bool _cancer_fml;
    bool _enfermadad_corazon;
    bool _epilepsia_convulsiones_fml;
    bool _varicela_us;
    bool _tuberculosis_us;
    bool _apendice_us;
    bool _hepatitis_us;
    bool _asma_us;
    bool _rubeola_us;
    string _otros_us;
    string _cirugias_us;
    string _fecha_cirugias_us;
    string _alergias_us;
    string _hernias_us;
    string _otro_procedimiento_us;
    string _alcohol_us;
    string _tabaco_us;
    string _otros_habitos_us;
    bool _epilepsia_us;
    string _otros_sufrido_us;
    bool _hernia_sufrido_us;
    bool _cancer_leucemia_us;

    Conexion con;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Conexion busqueda = new Conexion(false);

            Conexion count = new Conexion(false);
            DataSet ResultCount = count.buscar("select count(idAl) as value from historial_medico where idAl = " + Session["idAlumno"].ToString() + "");

            int resultado = Convert.ToInt32(ResultCount.Tables[0].Rows[0]["value"]);
            exist = resultado > 0;



            if (exist)
            {
                DataSet registro = busqueda.buscar("select * from historial_medico where idAl=" + Session["idAlumno"].ToString() + "");
                id = Convert.ToInt32(registro.Tables[0].Rows[0]["cod_historial_medico"]);
                _paperas_us = !isNULL(registro.Tables[0].Rows[0]["paperas_us"].ToString()) ? Convert.ToDateTime(registro.Tables[0].Rows[0]["paperas_us"].ToString()).ToString("yyyy-MM-dd") : "";
                _sarampion_us = !isNULL(registro.Tables[0].Rows[0]["sarampion_us"].ToString()) ? Convert.ToDateTime(registro.Tables[0].Rows[0]["sarampion_us"].ToString()).ToString("yyyy-MM-dd") : "";
                _difteria_us = !isNULL(registro.Tables[0].Rows[0]["difteria_us"].ToString()) ? Convert.ToDateTime(registro.Tables[0].Rows[0]["difteria_us"].ToString()).ToString("yyyy-MM-dd") : "";
                _rubeola_vacuna = !isNULL(registro.Tables[0].Rows[0]["rubeola_vacuna"].ToString()) ? Convert.ToDateTime(registro.Tables[0].Rows[0]["rubeola_vacuna"].ToString()).ToString("yyyy-MM-dd") : "";
                _estado_salud_padre = registro.Tables[0].Rows[0]["estado_salud_padre"].ToString();
                _estado_salud_madre = registro.Tables[0].Rows[0]["estado_salud_madre"].ToString();
                _tuberculosis_fml = registro.Tables[0].Rows[0]["tuberculosis_fml"].ToString().Equals("SI");
                _asma_fml = registro.Tables[0].Rows[0]["asma_fml"].ToString().Equals("SI");
                _diabetes_fml = registro.Tables[0].Rows[0]["diabetes_fml"].ToString().Equals("SI");
                _cancer_fml = registro.Tables[0].Rows[0]["cancer_fml"].ToString().Equals("SI");
                _enfermadad_corazon = registro.Tables[0].Rows[0]["enfermedad_corazon"].ToString().Equals("SI");
                _epilepsia_convulsiones_fml = registro.Tables[0].Rows[0]["epilepsia_convulsiones_fml"].ToString().Equals("SI");
                _varicela_us = registro.Tables[0].Rows[0]["varicela_us"].ToString().Equals("SI");
                _tuberculosis_us = registro.Tables[0].Rows[0]["tuberculosis_us"].ToString().Equals("SI");
                _apendice_us = registro.Tables[0].Rows[0]["apendice_us"].ToString().Equals("SI");
                _hepatitis_us = registro.Tables[0].Rows[0]["hepatitis_us"].ToString().Equals("SI");
                _asma_us = registro.Tables[0].Rows[0]["asma_us"].ToString().Equals("SI");
                _rubeola_us = registro.Tables[0].Rows[0]["rubeola_us"].ToString().Equals("SI");
                _otros_us = registro.Tables[0].Rows[0]["otras_us"].ToString();
                _cirugias_us = registro.Tables[0].Rows[0]["cirugias_us"].ToString();
                _fecha_cirugias_us = !isNULL(registro.Tables[0].Rows[0]["fecha_cirugias_us"].ToString()) ? Convert.ToDateTime(registro.Tables[0].Rows[0]["fecha_cirugias_us"].ToString()).ToString("yyyy-MM-dd") : "";
                _alergias_us = registro.Tables[0].Rows[0]["alergias_us"].ToString();
                _hernias_us = registro.Tables[0].Rows[0]["hernias_us"].ToString();
                _otro_procedimiento_us = registro.Tables[0].Rows[0]["otros_procedimientos_us"].ToString();
                _alcohol_us = registro.Tables[0].Rows[0]["alcohol_us"].ToString();
                _tabaco_us = registro.Tables[0].Rows[0]["tabaco_us"].ToString();
                _otros_habitos_us = registro.Tables[0].Rows[0]["otros_habitos_us"].ToString();
                _epilepsia_us = registro.Tables[0].Rows[0]["epilepcia_us"].ToString().Equals("SI");
                _otros_sufrido_us = registro.Tables[0].Rows[0]["otros_sufridos_us"].ToString();
                _hernia_sufrido_us = registro.Tables[0].Rows[0]["hernia_sufrido_us"].ToString().Equals("SI");
                _cancer_leucemia_us = registro.Tables[0].Rows[0]["cancer_leucemia_us"].ToString().Equals("SI");

                paperas_us.Value = _paperas_us;
                sarampion_us.Value = _sarampion_us;
                difteria_us.Value = _difteria_us;
                rubeola_vacuna.Value = _rubeola_vacuna;
                estado_salud_padre.Value = _estado_salud_padre;
                estado_salud_madre.Value = _estado_salud_madre;
                tuberculosis_fml.Checked = _tuberculosis_fml;
                asma_fml.Checked = _asma_fml;
                diabetes_fml.Checked = _diabetes_fml;
                cancer_fml.Checked = _cancer_fml;
                enfermadad_corazon.Checked = _enfermadad_corazon;
                epilepsia_convulsiones_fml.Checked = _epilepsia_convulsiones_fml;
                varicela_us.Checked = _varicela_us;
                tuberculosis_us.Checked = _tuberculosis_us;
                apendice_us.Checked = _apendice_us;
                hepatitis_us.Checked = _hepatitis_us;
                asma_us.Checked = _asma_us;
                rubeola_us.Checked = _rubeola_us;
                otros_us.Value = _otros_us;
                cirugias_us.Value = _cirugias_us;
                fecha_cirugias_us.Value = _fecha_cirugias_us;
                alergias_us.Value = _alergias_us;
                hernias_us.Value = _hernias_us;
                otro_procedimiento_us.Value = _otro_procedimiento_us;
                alcohol_us.Value = _alcohol_us;
                tabaco_us.Value = _tabaco_us;
                otros_habitos_us.Value = _otros_habitos_us;
                epilepsia_us.Checked = _epilepsia_us;
                otros_sufrido_us.Value = _otros_sufrido_us;
                hernia_sufrido_us.Checked = _hernia_sufrido_us;
                cancer_leucemia_us.Checked = _cancer_leucemia_us;

                if (Session["mostrar_boton"] != null && Convert.ToBoolean(Session["mostrar_boton"])) {
                    btnGuardar.Visible = false;
                } 
            }
        }

    }



    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        Conexion busqueda = new Conexion(false);

        Conexion count = new Conexion(false);

        DataSet ResultCount = count.buscar("select count(idAl) as value, cod_historial_medico id from historial_medico where idAl = " + Session["idAlumno"].ToString() + " GROUP by idAl, cod_historial_medico");
        if (ResultCount.Tables[0].Rows.Count > 0)
        {
            int resultado = Convert.ToInt32(ResultCount.Tables[0].Rows[0]["value"]);
            exist = resultado > 0;
            id = Convert.ToInt32(ResultCount.Tables[0].Rows[0]["id"]);
        }

        if (!exist)
        {
            StringBuilder builder = new StringBuilder("insert into historial_medico (")
                .Append(Session["idAlumno"] != null ? "idAl" + "," : "")
                .Append(paperas_us.Value != "" ? "paperas_us," : "")
                .Append(sarampion_us.Value != "" ? "sarampion_us," : "")
                .Append(difteria_us.Value != "" ? "difteria_us," : "")
                .Append(rubeola_vacuna.Value != "" ? "rubeola_vacuna," : "")
                .Append(estado_salud_padre.Value != "" ? "estado_salud_padre," : "")
                .Append(estado_salud_madre.Value != "" ? "estado_salud_madre," : "")
                .Append(tuberculosis_fml.Checked ? "tuberculosis_fml," : "")
                .Append(asma_fml.Checked ? "asma_fml," : "")
                .Append(diabetes_fml.Checked ? "diabetes_fml," : "")
                .Append(cancer_fml.Checked ? "cancer_fml," : "")
                .Append(enfermadad_corazon.Checked ? "enfermedad_corazon," : "")
                .Append(epilepsia_convulsiones_fml.Checked ? "epilepsia_convulsiones_fml," : "")
                .Append(tuberculosis_us.Checked ? "tuberculosis_us," : "")
                .Append(apendice_us.Checked ? "apendice_us," : "")
                .Append(asma_us.Checked ? "asma_us," : "")
                .Append(hepatitis_us.Checked ? "hepatitis_us," : "")
                .Append(varicela_us.Checked ? "varicela_us," : "")
                .Append(rubeola_us.Checked ? "rubeola_us," : "")
                .Append(otros_us.Value != "" ? "otras_us," : "")
                .Append(cirugias_us.Value != "" ? "cirugias_us," : "")
                .Append(fecha_cirugias_us.Value != "" ? "fecha_cirugias_us," : "")
                .Append(alergias_us.Value != "" ? "alergias_us," : "")
                .Append(hernias_us.Value != "" ? "hernias_us," : "")
                .Append(otro_procedimiento_us.Value != "" ? "otros_procedimientos_us," : "")
                .Append(alcohol_us.Value != "" ? "alcohol_us," : "")
                .Append(tabaco_us.Value != "" ? "tabaco_us," : "")
                .Append(otros_habitos_us.Value != "" ? "otros_habitos_us," : "")
                .Append(epilepsia_us.Checked ? "epilepcia_us," : "")
                .Append(cancer_leucemia_us.Checked ? " cancer_leucemia_us," : "")
                .Append(hernia_sufrido_us.Checked ? " hernia_sufrido_us," : "")
                .Append(otros_sufrido_us.Value != "" ? "otros_sufridos_us," : "")
                .Append("fecha_historial").Append(") values (")

                .Append(Session["idAlumno"] != null ? Session["idAlumno"].ToString() + "," : "")
                .Append(paperas_us.Value != "" ? "'" + paperas_us.Value + "'," : "")
                .Append(sarampion_us.Value != "" ? "'" + sarampion_us.Value + "'," : "")
                .Append(difteria_us.Value != "" ? "'" + difteria_us.Value + "'," : "")
                .Append(rubeola_vacuna.Value != "" ? "'" + rubeola_vacuna.Value + "'," : "")
                .Append(estado_salud_padre.Value != "" ? "'" + estado_salud_padre.Value + "'," : "")
                .Append(estado_salud_madre.Value != "" ? "'" + estado_salud_madre.Value + "'," : "")
                .Append(tuberculosis_fml.Checked ? "'" + tuberculosis_fml.Value + "'," : "")
                .Append(asma_fml.Checked ? "'" + asma_fml.Value + "'," : "")
                .Append(diabetes_fml.Checked ? "'" + diabetes_fml.Value + "'," : "")
                .Append(cancer_fml.Checked ? "'" + cancer_fml.Value + "'," : "")
                .Append(enfermadad_corazon.Checked ? "'" + enfermadad_corazon.Value + "'," : "")
                .Append(epilepsia_convulsiones_fml.Checked ? "'" + epilepsia_convulsiones_fml.Value + "'," : "")
                .Append(tuberculosis_us.Checked ? "'" + tuberculosis_us.Value + "'," : "")
                .Append(apendice_us.Checked ? "'" + apendice_us.Value + "'," : "")
                .Append(asma_us.Checked ? "'" + asma_us.Value + "'," : "")
                .Append(hepatitis_us.Checked ? "'" + hepatitis_us.Value + "'," : "")
                .Append(varicela_us.Checked ? "'" + varicela_us.Value + "'," : "")
                .Append(rubeola_us.Checked ? "'" + rubeola_us.Value + "'," : "")
                .Append(otros_us.Value != "" ? "'" + otros_us.Value + "'," : "")
                .Append(cirugias_us.Value != "" ? "'" + cirugias_us.Value + "'," : "")
                .Append(fecha_cirugias_us.Value != "" ? "'" + fecha_cirugias_us.Value + "'," : "")
                .Append(alergias_us.Value != "" ? "'" + alergias_us.Value + "'," : "")
                .Append(hernias_us.Value != "" ? "'" + hernias_us.Value + "'," : "")
                .Append(otro_procedimiento_us.Value != "" ? "'" + otro_procedimiento_us.Value + "'," : "")
                .Append(alcohol_us.Value != "" ? "'" + alcohol_us.Value + "'," : "")
                .Append(tabaco_us.Value != "" ? "'" + tabaco_us.Value + "'," : "")
                .Append(otros_habitos_us.Value != "" ? "'" + otros_habitos_us.Value + "'," : "")
                .Append(epilepsia_us.Checked ? "'" + epilepsia_us.Value + "'," : "")
                .Append(cancer_leucemia_us.Checked ? "'" + cancer_leucemia_us.Value + "'," : "")
                .Append(hernia_sufrido_us.Checked ? "'" + hernia_sufrido_us.Value + "'," : "")
                .Append(otros_sufrido_us.Value != "" ? "'" + otros_sufrido_us.Value + "'," : "")
                .Append("'" + DateTime.Today.Date.ToString("yyyy-MM-dd")).Append("');");
            ;



            string sql = builder.ToString();
            con = new Conexion(false);
            if (con.insert(sql))
            {
                Response.Redirect("/princEstudiante.aspx");
            }
            else
            {
                Mensaje.Text = "Error al Guardar Registro1";
            }
        }
        else
        {
            bool error = true;
            string value;

            if (!isNULL(paperas_us.Value))
            {
                con = new Conexion(false);
                error = con.update("update dbo.historial_medico set paperas_us ='" + paperas_us.Value + "' where cod_historial_medico =" + id);
            }
            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            if (!isNULL(sarampion_us.Value))
            {
                con = new Conexion(false);
                error = con.update("update dbo.historial_medico set sarampion_us ='" + sarampion_us.Value + "' where cod_historial_medico =" + id);
            }
            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            if (!isNULL(difteria_us.Value))
            {
                con = new Conexion(false);
                error = con.update("update dbo.historial_medico set difteria_us ='" + difteria_us.Value + "' where cod_historial_medico =" + id);

            }
            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            if (!isNULL(rubeola_vacuna.Value))
            {
                con = new Conexion(false);
                error = con.update("update dbo.historial_medico set rubeola_vacuna ='" + rubeola_vacuna.Value + "' where cod_historial_medico =" + id);

            }
            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            if (!isNULL(estado_salud_padre.Value))
            {
                con = new Conexion(false);
                error = con.update("update dbo.historial_medico set estado_salud_padre ='" + estado_salud_padre.Value + "' where cod_historial_medico =" + id);

            }
            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            if (!isNULL(estado_salud_madre.Value))
            {
                con = new Conexion(false);
                error = con.update("update dbo.historial_medico set estado_salud_madre ='" + estado_salud_madre.Value + "' where cod_historial_medico =" + id);

            }
            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            value = tuberculosis_fml.Checked ? tuberculosis_fml.Value : "NO";
            con = new Conexion(false);
            error = con.update("update dbo.historial_medico set tuberculosis_fml ='" + value + "' where cod_historial_medico =" + id);


            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }


            value = asma_fml.Checked ? "SI" : "NO";
            con = new Conexion(false);
            error = con.update("update dbo.historial_medico set asma_fml ='" + value + "' where cod_historial_medico =" + id);

            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            value = diabetes_fml.Checked ? "SI" : "NO";
            con = new Conexion(false);
            error = con.update("update dbo.historial_medico set diabetes_fml ='" + value + "' where cod_historial_medico =" + id);

            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            value = cancer_fml.Checked ? "SI" : "NO";
            con = new Conexion(false);
            error = con.update("update dbo.historial_medico set cancer_fml ='" + value + "' where cod_historial_medico =" + id);

            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            value = enfermadad_corazon.Checked ? "SI" : "NO";
            con = new Conexion(false);
            error = con.update("update dbo.historial_medico set enfermedad_corazon ='" + value + "' where cod_historial_medico =" + id);

            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            value = epilepsia_convulsiones_fml.Checked ? "SI" : "NO";
            con = new Conexion(false);
            error = con.update("update dbo.historial_medico set epilepsia_convulsiones_fml ='" + value + "' where cod_historial_medico =" + id);

            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            value = tuberculosis_us.Checked ? "SI" : "NO";
            con = new Conexion(false);
            error = con.update("update dbo.historial_medico set tuberculosis_us ='" + value + "' where cod_historial_medico =" + id);

            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            value = apendice_us.Checked ? "SI" : "NO";
            con = new Conexion(false);
            error = con.update("update dbo.historial_medico set apendice_us ='" + value + "' where cod_historial_medico =" + id);

            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            value = asma_us.Checked ? "SI" : "NO";
            con = new Conexion(false);
            error = con.update("update dbo.historial_medico set asma_us ='" + value + "' where cod_historial_medico =" + id);

            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            value = hepatitis_us.Checked ? "SI" : "NO";
            con = new Conexion(false);
            error = con.update("update dbo.historial_medico set hepatitis_us ='" + value + "' where cod_historial_medico =" + id);

            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            value = varicela_us.Checked ? "SI" : "NO";
            con = new Conexion(false);
            error = con.update("update dbo.historial_medico set varicela_us ='" + value + "' where cod_historial_medico =" + id);

            if (!error)
            {
                con = new Conexion(false);
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            value = rubeola_us.Checked ? "SI" : "NO";
            con = new Conexion(false);
            error = con.update("update dbo.historial_medico set rubeola_us ='" + value + "' where cod_historial_medico =" + id);

            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            if (!isNULL(otros_us.Value))
            {
                con = new Conexion(false);
                error = con.update("update dbo.historial_medico set otras_us =" + otros_us.Value + "where cod_historial_medico =" + id);

            }
            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            if (!isNULL(cirugias_us.Value))
            {
                con = new Conexion(false);
                error = con.update("update dbo.historial_medico set cirugias_us ='" + cirugias_us.Value + "' where cod_historial_medico =" + id);

            }
            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            if (!isNULL(fecha_cirugias_us.Value))
            {
                con = new Conexion(false);
                error = con.update("update dbo.historial_medico set fecha_cirugias_us ='" + fecha_cirugias_us.Value + "' where cod_historial_medico =" + id);

            }
            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            if (!isNULL(alergias_us.Value))
            {
                con = new Conexion(false);
                error = con.update("update dbo.historial_medico set alergias_us ='" + alergias_us.Value + "' where cod_historial_medico =" + id);

            }
            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            if (!isNULL(hernias_us.Value))
            {
                con = new Conexion(false);
                error = con.update("update dbo.historial_medico set hernias_us ='" + hernias_us.Value + "' where cod_historial_medico =" + id);

            }
            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            if (!isNULL(otro_procedimiento_us.Value))
            {
                con = new Conexion(false);
                error = con.update("update dbo.historial_medico set otros_procedimientos_us ='" + otro_procedimiento_us.Value + "' where cod_historial_medico =" + id);
            }
            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            if (!isNULL(alcohol_us.Value))
            {
                con = new Conexion(false);
                error = con.update("update dbo.historial_medico set alcohol_us ='" + alcohol_us.Value + "' where cod_historial_medico =" + id);

            }
            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            if (!isNULL(tabaco_us.Value))
            {
                con = new Conexion(false);
                error = con.update("update dbo.historial_medico set tabaco_us ='" + tabaco_us.Value + "'where cod_historial_medico =" + id);

            }
            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            value = hernia_sufrido_us.Checked ? "SI" : "NO";
            con = new Conexion(false);
            error = con.update("update dbo.historial_medico set hernia_sufrido_us ='" + hernia_sufrido_us.Value + "' where cod_historial_medico =" + id);

            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            if (!isNULL(otros_habitos_us.Value))
            {
                con = new Conexion(false);
                error = con.update("update dbo.historial_medico set otros_habitos_us ='" + otros_habitos_us.Value + "' where cod_historial_medico =" + id);

            }
            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            value = epilepsia_us.Checked ? "SI" : "NO";
            con = new Conexion(false);
            error = con.update("update dbo.historial_medico set epilepcia_us ='" + value + "' where cod_historial_medico =" + id);

            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            value = cancer_leucemia_us.Checked ? "SI" : "NO";
            con = new Conexion(false);
            error = con.update("update dbo.historial_medico set cancer_leucemia_us ='" + cancer_leucemia_us.Value + "' where cod_historial_medico =" + id);

            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }

            if (!isNULL(otros_sufrido_us.Value))
            {
                con = new Conexion(false);
                error = con.update("update dbo.historial_medico set otros_sufridos_us ='" + otros_sufrido_us.Value + "' where cod_historial_medico =" + id);
            }
            if (!error)
            {
                Mensaje.Text = "Error al Guardar Registro";
                return;
            }


            if (error)
            {
                Response.Redirect("/princEstudiante.aspx");
            }

        }

    }

    private bool isNULL(string value)
    {
        return "".Equals(value);
    }

}