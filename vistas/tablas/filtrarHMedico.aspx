<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/tablas/Tables.master" AutoEventWireup="true" CodeFile="filtrarHMedico.aspx.cs" Inherits="vistas_tablas_filtrarHMedico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <br />
    <div class="data-tables-query">
        <div class="data">
           
            <asp:TextBox ID="cedulaAl" runat="server" pattern="\d*"></asp:TextBox>
         
            <asp:Button ID="buscar" runat="server" Text="Buscar" OnClick="buscar_Click" />
            <br />
            <br />
            <br />
        </div>
        <div class="grid">
            <asp:GridView ID="result_HM" runat="server" CellPadding="2" CellSpacing="5" Width="100%" AllowPaging="True" PageSize="20" AutoGenerateColumns="false" DataKeyNames="ID" OnDataBound="result_HM_DataBound" OnPageIndexChanging="result_HM_PageIndexChanging" EmptyDataText="La busqueda no obtuvo resultados.">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" Visible="False" />
                    <asp:BoundField DataField="cedula" HeaderText="C.I.:" SortExpression="C.I.:" />
                    <asp:BoundField DataField="Alumno" HeaderText="Alumno" SortExpression="Alumno" />
                    <asp:BoundField DataField="carrera" HeaderText="Carrera" SortExpression="Carrera" />
                    <asp:BoundField DataField="paperas_us" HeaderText="Paperas" SortExpression="Alumno" Visible="False"/>
                    <asp:BoundField DataField="sarampion_us" HeaderText="Sarampion" SortExpression="Alumno" Visible="False"/>
                    <asp:BoundField DataField="difteria_us" HeaderText="Difteria" SortExpression="Alumno" Visible="False"/>
                    <asp:BoundField DataField="rubeola_vacuna" HeaderText="Rubeola" Visible="False"/>
                    <asp:BoundField DataField="estado_salud_padre" HeaderText="Salud Padre" SortExpression="Alumno" Visible="False"/>
                    <asp:BoundField DataField="estado_salud_madre" HeaderText="Salud Madre" SortExpression="Alumno" Visible="False"/>
                    <asp:BoundField DataField="tuberculosis_fml" HeaderText="Tuberculosis De familia" SortExpression="Alumno" Visible="False"/>
                    <asp:BoundField DataField="asma_fml" HeaderText="Asma De familia" SortExpression="Alumno" Visible="False"/>
                    <asp:BoundField DataField="diabetes_fml" HeaderText="Diabetes De familia" SortExpression="Alumno"  Visible="False"/>
                    <asp:BoundField DataField="cancer_fml" HeaderText="Cancer De familia" SortExpression="Alumno" Visible="False"/>
                    <asp:BoundField DataField="enfermedad_corazon" HeaderText="Enfermedad cardiaca De familia" Visible="False"/>
                    <asp:BoundField DataField="epilepsia_convulsiones_fml" HeaderText="Epilepcia De familia" SortExpression="Alumno" Visible="False"/>
                    <asp:BoundField DataField="tuberculosis_us" HeaderText="Tuberculosis" SortExpression="Alumno" Visible="False" />
                    <asp:BoundField DataField="apendice_us" HeaderText="Apendice" SortExpression="Alumno" Visible="False"/>
                    <asp:BoundField DataField="asma_us" HeaderText="Asma" SortExpression="Alumno" Visible="False"/>
                    <asp:BoundField DataField="hepatitis_us" HeaderText="Hepatitis" SortExpression="Alumno" Visible="False"/>
                    <asp:BoundField DataField="varicela_us" HeaderText="Varicela" SortExpression="Alumno" Visible="False"/>
                    <asp:BoundField DataField="rubeola_us" HeaderText="Rubeola" Visible="False"/>
                    <asp:BoundField DataField="otras_us" HeaderText="Otras" SortExpression="Alumno" Visible="False"/>
                    <asp:BoundField DataField="cirugias_us" HeaderText="Cirugias" SortExpression="Alumno" Visible="False"/>
                    <asp:BoundField DataField="fecha_cirugias_us" HeaderText="Fecha de la Cirugia" SortExpression="Alumno" Visible="False"/>
                    <asp:BoundField DataField="alergias_us" HeaderText="Alergias" SortExpression="Alumno"  Visible="False"/>
                    <asp:BoundField DataField="hernias_us" HeaderText="Hernias" SortExpression="Alumno" Visible="False"/>
                    <asp:BoundField DataField="otros_procedimientos_us" HeaderText="Otros" SortExpression="Alumno" Visible="False"/>
                    <asp:BoundField DataField="alcohol_us" HeaderText="Alcohol" SortExpression="Alumno" Visible="False"/>
                    <asp:BoundField DataField="tabaco_us" HeaderText="Tabaco" SortExpression="Alumno" Visible="False"/>
                    <asp:BoundField DataField="otros_habitos_us" HeaderText="Otros Habitos" SortExpression="Alumno" Visible="False"/>
                    <asp:BoundField DataField="epilepcia_us" HeaderText="Epilepcia" SortExpression="Alumno" ControlStyle-BorderWidth="5" Visible="False"/>
                    <asp:BoundField DataField="cancer_leucemia_us" HeaderText="Cancer" SortExpression="Alumno" Visible="False"/>
                    <asp:BoundField DataField="hernia_sufrido_us" HeaderText="Hernia" SortExpression="Alumno" Visible="False"/> 
                    <asp:BoundField DataField="fecha_historial" HeaderText="Fecha del Registro" SortExpression="Alumno" />     
                     <asp:TemplateField HeaderStyle-ForeColor="Black" HeaderText="">
                        <ItemTemplate>
                             <asp:HiddenField ID="idAL" runat="server" Value='<%# Eval("idAl")%>' />
                            <asp:LinkButton CssClass="buttonTable" ID="BtnVer" runat="server" Text="Ver Mas" OnClick="BtnVer_Click" ToolTip="Permite ver con mas detalles la información"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>                  
                </Columns>
                <HeaderStyle BackColor="#FF6600" />
                <RowStyle BorderStyle="Solid" BorderWidth="1px" />
            </asp:GridView>
             <br />
                <asp:Label ID="Mensaje" runat="server" Text="" Font-Size="20px"></asp:Label><br />
                <br />
        </div>
        

        <br />
    </div>
</asp:Content>

