﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class vistas_maestras_equipo_psm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void button_reg_Click(object sender, EventArgs e)
    {
        Conexion con = new Conexion(false);
        if (con.insert("insert into dbo.equipo_psm values('" + desc_equipo.Text.ToUpper() + "', "+list_disc.SelectedValue+");"))
        {
            Mensaje.Text = "Registro Guardado";
            Mensaje.ForeColor = Color.Green;
            desc_equipo.Text = "";
        }
        else { Mensaje.Text = "Error al Guardar"; Mensaje.ForeColor = Color.Red; }
    }
}