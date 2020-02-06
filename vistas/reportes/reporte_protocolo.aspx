<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/reportes/masterReporte.master" AutoEventWireup="true" CodeFile="reporte_protocolo.aspx.cs" Inherits="reportes_reportEdad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">


    



    <div class="container_12">
        <div id="app" v-cloak>

            <br />
            <br />
            <h2 class="title-seccion">Reporte Solicitudes Protocolo</h2>
            <br />

            <label for="lapso">Período Académico</label>
            <input id="txtLapso" type="text" name="lapso" runat="server" required />
            <input id="Edad" type="hidden" value="" runat="server" name="total" />
            <asp:Button ID="btnReporte" runat="server" OnClick="btnReporte_Click" Text="Generar Reporte" /><br /><br />

        <table border="2" class=" table table-bordered ">
            <thead class="thead-dark">
                <th>Cedula</th>
                <th>Nombre Alumno</th>
                <th>Talla Camisa</th>
                <th>Talla Pantalon</th>
                <th>Talla Zapatos</th>
                <th>Dirección</th>
                <th>Telefono</th>
                <th>Lapso</th>
            </thead>
            <tr v-for="data in all_data ">
                <td>{{data.cedula}}</td>
                <td>{{data.alumno}}</td>
                <td>{{data.camisa}}</td>
                <td>{{data.pantalon}}</td>
                <td>{{data.zapato}}</td>
                <td>{{data.direccion}}</td>
                <td>{{data.telefono}}</td>
                <td>{{data.lapso}}</td>
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

        
     <h4><a href="imprimir_reporte/imprimir_protocolo.aspx" target="_blank" style="text-align:center; font-size:x-large;">Imprimir Reporte</a></h4><hr />
    </div>
    <br> 
</asp:Content>

