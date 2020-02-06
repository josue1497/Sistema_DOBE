<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="hmedico.aspx.cs" Inherits="hmedico" %>

<asp:Content ID="HMedico" ContentPlaceHolderID="MainContent" runat="Server">

    <!--===========header============-->

    <header class="pad0">
        <div class="container_12 p_zero">
            <div class="grid_12">
                <div class="top_block">
                   <div class="header_links" style="margin-top: -18%;">
                        <a href="https://mail.psm.edu.ve/owa" target="blank">Correo Institucional</a>
                        <a href="http://www.psm.edu.ve/sawebvalencia" target="_blank" onclick="window.open(this.href, this.target, 'width=1000,height=700,scrollbars'); return false;">Mi PSM en Línea</a><br>
                        
                        <div class="slogan"></div>
                    </div>
                   </div>
              
            </div>
            
        </div>
        
            

    </header>

    <!--==============================content================================-->

    <div class="container_12">
        <br>
        <br>
        <h2 id="titleInicioSesion">Historial Medico</h2>
        <br>

        <h4><b>PARTE I.:</b> Fecha de vacunas, indique la fecha en las que ha recibido cada una de las siguientes vacunas.</h4>
        <br>

        <form id="formMedico" runat="server">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <label for="paperas_us" class="label">Paperas</label>&nbsp;<input type="date" name="paperas_us" id="paperas_us" runat="server">
            &nbsp;&nbsp;&nbsp;&nbsp;

            <label for="sarampion_us" class="label">Sarampión</label>&nbsp;<input type="date" name="sarampion_us" id="sarampion_us"  runat="server">
            &nbsp;&nbsp;&nbsp;&nbsp;

            <label for="difteria_us" class="label">Difteria/Tétanos</label>&nbsp;<input type="date" name="difteria_us" id="difteria_us"  runat="server">
            <br>
            <br>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <label for="rubeola_vacuna" class="label" >Rubéola</label>&nbsp;<input type="date" name="rubeola_vacuna" id="rubeola_vacuna" runat="server">

            <br>
            <br>
            <h4><b>PARTE II.:</b> Historia clinica de la familia. Indique edad y estado de salud.</h4>
            <b id="miembro">¿ Algún miembro de su famiia a tenido ?</b><br>
            <br>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <label for="edad_padre" class="label">Padre</label>
		    <input type="text" name="estado_salud_padre" id="estado_salud_padre" placeholder="  Estado de Salud" runat="server" required>

            <label for="tuberculosis_fml" id="tuberculosis_fml_label">Tuberculosis</label>&nbsp;&nbsp;
	        <input type="checkbox" value="SI" name="tuberculosis_fml" id="tuberculosis_fml" runat="server">

            <label for="asma_fml" class="label">Asma</label>&nbsp;&nbsp;
	        <input type="checkbox" value="SI" name="asma_fml" id="asma_fml" runat="server">

            <label for="epilepsia_convulsiones_fml" class="label">Epilepsia/convulsiones</label>&nbsp;&nbsp;
	        <input type="checkbox" value="SI" name="epilepsia_convulsiones_fml" id="epilepsia_convulsiones_fml" runat="server">

            <br>
            <br>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <label for="edad_madre" class="label">Madre</label>
		    <input type="text" name="estado_salud_madre" id="estado_salud_madre" placeholder="  Estado de Salud" runat="server" required>

            <label for="diabetes_fml">Diabetes</label>&nbsp;&nbsp;
	        <input type="checkbox" value="SI" name="diabetes_fml" id="diabetes_fml" runat="server">

            <label for="cancer_fml" class="label">Cáncer</label>&nbsp;&nbsp;
	        <input type="checkbox" value="SI" name="cancer_fml" id="cancer_fml" runat="server">

            <label for="enfermadad_corazon" class="label">Enfermedades del corazon</label>&nbsp;&nbsp;
	        <input type="checkbox" value="SI" name="enfermadad_corazon" id="enfermadad_corazon" runat="server">

            <br>
            <br>
            <h4><b>PARTE III.:</b> Indique si usted ha tenido.</h4>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <label for="tuberculosis_us" class="label">Tuberculosis</label>&nbsp;&nbsp;
	<input type="checkbox" value="SI" name="tuberculosis_us" id="tuberculosis_us" runat="server">
            &nbsp;&nbsp;&nbsp;&nbsp;
            <label for="apendice_us" class="label">Apendice</label>&nbsp;&nbsp;
	<input type="checkbox" value="SI" name="apendice_us" id="apendice_us" runat="server">
            &nbsp;&nbsp;&nbsp;&nbsp;
            <label for="hepatitis_us" class="label">Hepatitis</label>&nbsp;&nbsp;
	<input type="checkbox" value="SI" name="hepatitis_us" id="hepatitis_us" runat="server">
            &nbsp;&nbsp;&nbsp;&nbsp;
            <label for="cirugias_us" class="label">Cirugías</label>&nbsp;&nbsp;
	<input type="text" name="cirugias_us" id="cirugias_us" placeholder="  Cirugías" runat="server">
            &nbsp;&nbsp;&nbsp;&nbsp;
            <label for="fecha_cirugias_us" class="label">Fecha</label>&nbsp;&nbsp;
	<input type="date" name="fecha_cirugias_us" id="fecha_cirugias_us" placeholder="  Cirugías" runat="server">

            <br>
            <br>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <label for="asma_us" class="label">Asma</label>&nbsp;&nbsp;
	<input type="checkbox" value="SI" name="asma_us" id="asma_us" runat="server">
            &nbsp;&nbsp;&nbsp;&nbsp;
            <label for="varicela_us" class="label">Varicela</label>&nbsp;&nbsp;
	<input type="checkbox" value="SI" name="varicela_us" id="varicela_us" runat="server">
            &nbsp;&nbsp;&nbsp;&nbsp;
            <label for="rubeola_us" class="label">Rubéola</label>&nbsp;&nbsp;
	<input type="checkbox" value="SI" name="rubeola_us" id="rubeola_us" runat="server">
            &nbsp;&nbsp;&nbsp;&nbsp;
            <label for="alergias_us" class="label">Alergias</label>&nbsp;&nbsp;
	<input type="text" name="alergias_us" id="alergias_us" placeholder="  Alguna Alergia" runat="server" required>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <label for="hernias_us" class="label">Hernias</label>&nbsp;
	<input type="text" name="hernias_us" id="hernias_us" placeholder="  Alguna Hernia" runat="server">

            <br>
            <br>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <label for="otros_us" class="label">Otras</label>&nbsp;&nbsp;
	<input type="text" name="otros_us" id="otros_us" placeholder="  Otra Enfermedad" runat="server">
            &nbsp;&nbsp;&nbsp;&nbsp;
            <label for="otro_procedimiento_us" class="label">Otro</label>&nbsp;
	<input type="text" name="otro_procedimiento_us" id="otro_procedimiento_us" placeholder="  Algun otro Procedimiento" runat="server">

            <br>
            <br>
            <h4><b>PARTE IV.:</b> Hábitos: (Cuánto y con qué frecuencia).</h4>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <label for="alcohol_us" class="label">Alcohol</label>&nbsp;&nbsp;
	<input type="text" name="alcohol_us" id="alcohol_us" placeholder="  Alcohol" runat="server">
            &nbsp;&nbsp;&nbsp;&nbsp;
            <label for="tabaco_us" class="label">Tabaco</label>&nbsp;
	<input type="text" name="tabaco_us" id="tabaco_us" placeholder="  Tabaco" runat="server">
            &nbsp;&nbsp;&nbsp;&nbsp;
            <label for="otros_habitos_us" class="label">Otros habitos</label>&nbsp;
	<input type="text" name="otros_habitos_us" id="otros_habitos_us" placeholder="  Algun otro habito" runat="server">

            <br>
            <br>
            <h4><b>PARTE V.:</b>Indicar si ha sufrido de:</h4>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <label for="epilepsia_us" class="label">Epilepsia</label>&nbsp;&nbsp;
	<input type="checkbox" value="SI" name="epilepsia_us" id="epilepsia_us" placeholder="  Epilepsia" runat="server">
            &nbsp;&nbsp;&nbsp;&nbsp;
            <label for="cancer_leucemia_us" class="label">Cancer/Leucemia</label>&nbsp;
	<input type="checkbox" value="SI" name="cancer_leucemia_us" id="cancer_leucemia_us" placeholder="  Cancer/Leucemia" runat="server">
            &nbsp;&nbsp;&nbsp;&nbsp;
            <label for="hernia_sufrido_us" class="label">Hernia</label>&nbsp;
	<input type="checkbox" value="SI" name="hernia_sufrido_us" id="hernia_sufrido_us" placeholder="  Cancer/Leucemia" runat="server">
            &nbsp;&nbsp;&nbsp;&nbsp;
            <label for="otros_sufrido_us" class="label">Otra Enfermedad</label>&nbsp;
	<input type="text" name="otros_sufrido_us" id="otros_sufrido_us" placeholder="  Alguna otra enfermedad" runat="server">

            <br>
            

          <asp:Label ID="Mensaje" runat="server" Text="" Font-Size="20px" ForeColor="Red"></asp:Label><br />
             
            <br>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="form-control acceder" OnClick="btnGuardar_Click"></asp:Button><br>
                      
        </form>

    </div>
</asp:Content>

