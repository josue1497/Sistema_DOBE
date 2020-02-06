<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/reportes/masterReporte.master" AutoEventWireup="true" CodeFile="becados.aspx.cs" Inherits="reportes_reportEdad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="container_12">
        <div id="app" v-cloack>
            <br />
            <br />
            <h2 class="title-seccion">Reporte Becados</h2>
            <br />

            <label for="lapso">Período Académico</label>
            <input id="txtLapso" type="text" name="lapso" runat="server" required/>

            <input id="renovacion" type="hidden" runat="server" value="" />
            <input id="direccion" type="hidden" runat="server" value="" />
            <input id="solicitada" type="hidden" runat="server" value="" />
            <input id="becas_todas" type="hidden" runat="server" value="" />

            <asp:Button ID="btnReporte" runat="server" OnClick="btnReporte_Click" Text="Generar Reporte" />
            <br />
            <br>
            <h4>Renovaciones</h4>

            <table border="2" class=" table table-bordered ">
                <thead class="thead-dark">
                    <th>#</th>
                    <th>Nombre y Apellido</th>
                    <th>Código</th>
                    <th>Tipo de Beca</th>
                    <th>I.R.A.A {{ periodo }}</th>
                    <th>Observaciones</th>
                    <th>Desición {{periodo}}</th>
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
            <br />

            <h4>Dirección Nacional</h4>

            <table border="2" class=" table table-bordered ">
                <thead class="thead-dark">
                    <th>#</th>
                    <th>Nombre y Apellido</th>
                    <th>Código</th>
                    <th>Tipo de Beca</th>
                    <th>I.R.A.A {{ periodo }}</th>
                    <th>Observaciones</th>
                    <th>Desición {{ periodo }}</th>
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
            <br />

            <h4>Solicitudes</h4>

            <table border="2" class=" table table-bordered ">
                <thead class="thead-dark">
                    <th>#</th>
                    <th>Nombre y Apellido</th>
                    <th>Código</th>
                    <th>I.R.A.A {{ periodo }}</th>
                    <th>Observaciones</th>
                    <th>Desición {{ periodo }}</th>
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
            <br />

            <h4>Relación {{message}}</h4>

            <table border="2" class=" table table-bordered ">
                <thead class="thead-dark">
                    <th>Tipo Beca</th>
                    <th>Cantidad Solicitadas</th>
                </thead>
                <tr class="thead-dark">
                    <th colspan="2">Renovacion</th>
                </tr>
                <tr v-for="data in relacion ">
                    <td>{{data.tipo_beca}}</td>
                    <td>{{data.cant}}</td>
                </tr>
            </table>
            <br />
            <br />

        </div>
        <script>
            var app = new Vue({
                el: "#app",
                data: {
                    beca_renovadas:  [<%Response.Write(renovacion.Value);%>],
                    direccion_nacional:  [<%Response.Write(direccion.Value);%>],
                    solicitadas: [ <%Response.Write(solicitada.Value);%>],
                    relacion:  [<%Response.Write(becas_todas.Value);%>],
                    periodo: ''
                },
            });
        </script>

        <script src="../../../highcharts/js/localhighcharts.js"></script>
        <script src="../../../highcharts/js/localexporting.js"></script>

        <h4><a href="imprimir_reporte/imprimir_becas.aspx" target="_blank" style="text-align:center; font-size:x-large;">Imprimir Reporte</a></h4><hr />
    </div>
    <br> 
</asp:Content>

