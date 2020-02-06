<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/reportes/masterReporte.master" AutoEventWireup="true" CodeFile="reportEdad.aspx.cs" Inherits="reportes_reportEdad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">


    <input id="Edad" type="hidden" value="" runat="server" name="total" />
    <input id="graphic" type="hidden" value="" runat="server" name="total" />



    <div class="container_12">
        <br />
        <br />
        <div id="container" style="min-width: 310px; height: 400px; max-width: 600px; margin: 0 auto"></div>


        <br>
        <script src="../highcharts/js/localjquery.min.js" type="text/javascript"></script>
        <style type="text/css">
            $ {
                demo .css;
            }
        </style>
        <script type="text/javascript">
            $(function () {

                // Radialize the colors
                Highcharts.getOptions().colors = Highcharts.map(Highcharts.getOptions().colors, function (color) {
                    return {
                        radialGradient: {
                            cx: 0.5,
                            cy: 0.3,
                            r: 0.7
                        },
                        stops: [
                            [0, color],
                            [1, Highcharts.Color(color).brighten(-0.3).get('rgb')] // darken
                        ]
                    };
                });

                // Build the chart
                $('#container').highcharts({
                    chart: {
                        plotBackgroundColor: null,
                        plotBorderWidth: null,
                        plotShadow: false,
                        type: 'pie'
                    },
                    title: {
                        text: 'Porcentaje de la población estuiantil que ha solicitado reposos por Edad'
                    },
                    tooltip: {
                        pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                    },
                    plotOptions: {
                        pie: {
                            allowPointSelect: true,
                            cursor: 'pointer',
                            dataLabels: {
                                enabled: true,
                                format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                                style: {
                                    //Color de la letra
                                    color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                                },
                                connectorColor: 'black'
                            }
                        }
                    },
                    series: [{
                        name: 'Porcentajes',
                        data: [
                            <%Response.Write(graphic.Value);%>
                        ]
                    }]
                });
            });
        </script>

        <div id="app">
            <table border="2" class=" table table-bordered ">
                <thead class="thead-dark">
                    <th>Edad</th>
                    <th>Cantidad</th>
                </thead>
                <tr v-for="data in all_data ">
                    <td>{{data.name}}</td>
                    <td>{{data.y}}</td>
                </tr>
            </table>
        </div>
        <script>
            var app = new Vue({
                el: "#app",
                data: {
                    all_data:  <%Response.Write(Edad.Value);%>,
                },
            });
        </script>

        <script src="../../../highcharts/js/localhighcharts.js"></script>
        <script src="../../../highcharts/js/localexporting.js"></script>
        <br />
        <h4><a href="imprimir_reporte/imprimir_reportes.aspx" target="_blank" style="text-align: center; font-size: x-large;">Imprimir Reporte</a></h4>
        <hr />


    </div>
    <br>
</asp:Content>

