<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/vistas/reportes/imprimir_reporte/imprimirMaster.master" CodeFile="imprimir_visita_personal.aspx.cs" Inherits="vistas_reportes_imprimir_reporte_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="container_12">
        <div id="app" v-cloack>
            <hr />
            <br />
            <h2 class="title-seccion">Reporte Visitas del Personal al Departamento</h2>
            <br />
            <hr />
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
                    all_data: [ <%Response.Write(Session["json"]);%>],
                },
            });
        </script>

        <script src="../../../highcharts/js/localhighcharts.js"></script>
        <script src="../../../highcharts/js/localexporting.js"></script>


    </div>
    <br />
</asp:Content>

