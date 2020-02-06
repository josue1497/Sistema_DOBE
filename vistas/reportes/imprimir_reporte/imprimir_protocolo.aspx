<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/vistas/reportes/imprimir_reporte/imprimirMaster.master" CodeFile="imprimir_protocolo.aspx.cs" Inherits="vistas_reportes_imprimir_reporte_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="container_12">
        <div id="app" v-cloack>
            <hr />
            <br />
            <h2 class="title-seccion">Reporte Solicitudes Protocolo - Periodo <%Response.Write(Session["periodo"]);%></h2>
            <br />
            <hr />
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
                    all_data: [ <%Response.Write(Session["json"]);%>],
                },
            });
        </script>

        <script src="../../../highcharts/js/localhighcharts.js"></script>
        <script src="../../../highcharts/js/localexporting.js"></script>


    </div>
    <br />
</asp:Content>

