<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/vistas/reportes/imprimir_reporte/imprimirMaster.master" CodeFile="imprimir_becas.aspx.cs" Inherits="vistas_reportes_imprimir_reporte_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="container_12">
        <div id="app" v-cloack>
            <hr />
            <br />
            <h2 class="title-seccion">Reporte Becados - Período <%Response.Write(Session["periodo"]);%></h2>
            <br />
            <hr />
            <h4>Renovaciones</h4>

            <table border="2" class=" table table-bordered ">
                <thead class="thead-dark">
                    <th>#</th>
                    <th>Nombre y Apellido</th>
                    <th>Código</th>
                    <th>Tipo de Beca</th>
                    <th>I.R.A.A <%Response.Write(Session["periodo"]);%></th>
                    <th>Observaciones</th>
                    <th>Desición <%Response.Write(Session["periodo"]);%></th>
                </thead>
                <tr v-for="data in beca_renovadas ">
                    <td>{{data.id}}</td>
                    <td>{{data.alumno}}</td>
                    <td>{{data.cod_beca}}</td>
                    <td>{{data.tipo}}</td>
                    <td>{{data.iraa}}</td>
                    <td>{{data.observaciones}}</td>
                    <td>{{data.desicion}}</td>
                </tr>
            </table>
            <br />

            <h4>Dirección Nacional</h4>

            <table border="2" class=" table table-bordered ">
                <thead class="thead-dark">
                    <th>#</th>
                    <th>Nombre y Apellido</th>
                    <th>Código</th>
                    <th>Tipo de Beca</th>
                    <th>I.R.A.A <%Response.Write(Session["periodo"]);%></th>
                    <th>Observaciones</th>
                    <th>Desición <%Response.Write(Session["periodo"]);%></th>
                </thead>
                <tr v-for="data in direccion_nacional ">
                    <td>{{data.id}}</td>
                    <td>{{data.alumno}}</td>
                    <td>{{data.cod_beca}}</td>
                    <td>{{data.tipo}}</td>
                    <td>{{data.iraa}}</td>
                    <td>{{data.observaciones}}</td>
                    <td>{{data.desicion}}</td>
                </tr>
            </table>
            <br />

            <h4>Solicitudes</h4>

            <table border="2" class=" table table-bordered ">
                <thead class="thead-dark">
                    <th>#</th>
                    <th>Nombre y Apellido</th>
                    <th>Código</th>
                    <th>I.R.A.A <%Response.Write(Session["periodo"]);%></th>
                    <th>Observaciones</th>
                    <th>Desición <%Response.Write(Session["periodo"]);%></th>
                </thead>
                <tr v-for="data in solicitadas ">
                    <td>{{data.id}}</td>
                    <td>{{data.alumno}}</td>
                    <td>{{data.cod_beca}}</td>
                    <td>{{data.iraa}}</td>
                    <td>{{data.observaciones}}</td>
                    <td>{{data.desicion}}</td>
                </tr>
            </table>
            <br />

            <h4>Relación <%Response.Write(Session["periodo"]);%></h4>

            <table border="2" class=" table table-bordered ">
                <tr class="thead-dark">
                    <th>Tipo Beca</th>
                    <th>Cantidad Solicitadas</th>
                </tr>
                <tr class="thead-light">
                    <th colspan="2">Renovacion</th>
                </tr>
                <tr v-for="data in relacion ">
                    <td>{{data.tipo_beca}}</td>
                    <td>{{data.cant}}</td>
                </tr>
            </table>
            <br />

        </div>
        <script>
            var app = new Vue({
                el: "#app",
                data: {
                    beca_renovadas: [<%Response.Write(Session["beca_renovadas"]);%>],
                    direccion_nacional: [<%Response.Write(Session["direccion_nacional"]);%>],
                    solicitadas: [ <%Response.Write(Session["solicitadas"]);%>],
                    relacion: [<%Response.Write(Session["relacion"]);%>],
                },
            });
        </script>

        <script src="../../../highcharts/js/localhighcharts.js"></script>
        <script src="../../../highcharts/js/localexporting.js"></script>


    </div>
    <br />
</asp:Content>

