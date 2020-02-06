<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/reportes/masterReporte.master" AutoEventWireup="true" CodeFile="desglose_citas_psicologo.aspx.cs" Inherits="reportes_reportEdad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">






    <div class="container_12">
        <div id="app" v-cloak>

            <br />
            <br />
            <h2 class="title-seccion">Reporte Solicitudes Citas al Psicólogo</h2>
            <br />

            <label for="lapso">Período Académico</label>
            <input id="txtLapso" type="text" name="lapso" runat="server" required />
            <label for="tipo">Personal: </label>
            <asp:DropDownList ID="dTipo" name="lapso" runat="server">
                <asp:ListItem Value="A" Text="Estudiantes"></asp:ListItem>
                <asp:ListItem Value="D" Text="Docentes"></asp:ListItem>
                <asp:ListItem Value="P" Text="Personal Administrativo"></asp:ListItem>
            </asp:DropDownList>
            <input id="Edad" type="hidden" value="" runat="server" name="total" />
            <asp:Button ID="btnReporte" runat="server" OnClick="btnReporte_Click" Text="Generar Reporte" /><br />
            <br />

            <table border="2" class=" table table-bordered ">
                <thead class="thead-dark">
                    <th>Cedula</th>
                    <th>Apellidos y Nombres</th>
                    <th>Cantidad de Visitas</th>
                </thead>
                <tr v-for="data in all_data ">
                    <td>{{data.cedula}}</td>
                    <td>{{data.nombre}}</td>
                    <td>{{data.cant}}</td>
                </tr>
            </table>
        </div>
        <script>
            var app = new Vue({
                el: "#app",
                data: {
                    all_data: [ <%Response.Write(Edad.Value);%>],
                },
            });
        </script>

        <script src="../../../highcharts/js/localhighcharts.js"></script>
        <script src="../../../highcharts/js/localexporting.js"></script>


        <h4><a href="imprimir_reporte/imprimir_desglose.aspx" target="_blank" style="text-align: center; font-size: x-large;">Imprimir Reporte</a></h4>
        <hr />
    </div>
    <br>
</asp:Content>

