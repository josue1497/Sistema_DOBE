<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/reportes/masterReporte.master" AutoEventWireup="true" CodeFile="reporte_personal_visita.aspx.cs" Inherits="reportes_reportEdad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">


    



    <div class="container_12">
        <div id="app" v-cloak>

            <br />
            <br />
            <h2 class="title-seccion">Reporte Visitas del Personal al Departamento</h2>
            <br />
            <br />
            <label for="lapso">Cedula</label>
            <input id="txtLapso" type="text" name="lapso" runat="server" required />
            <input id="Edad" type="hidden" value="" runat="server" name="total" />
            <asp:Button ID="btnReporte" runat="server" OnClick="btnReporte_Click" Text="Generar Reporte" /><br /><br />

        <table border="2" class=" table table-bordered ">
            <thead class="thead-dark">
                <th>Nombre y Apellido</th>
                <th>Cargo</th>
                <th>Razon de la visita</th>
                <th>Cantidad de Visitas</th>
            </thead>
            <tr v-for="data in all_data ">
                <td>{{data.sujeto}}</td>
                <td>{{data.cargo}}</td>
                <td>{{data.visita}}</td>
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

        
     <h4><a href="imprimir_reporte/imprimir_visita_personal.aspx" target="_blank" style="text-align:center; font-size:x-large;">Imprimir Reporte</a></h4><hr />
    </div>
    <br> 
</asp:Content>

