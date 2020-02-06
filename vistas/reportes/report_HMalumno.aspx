<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/reportes/masterReporte.master" AutoEventWireup="true" CodeFile="report_HMalumno.aspx.cs" Inherits="reportes_report_HMalumno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">


    <!--============== Agregado por Raul ==============!-->


    <input id="TotalAlumnos" type="hidden" value="" runat="server" name="total" />
    <input id="AlumnosRegistrados" type="hidden" value="" runat="server" name="registrado" />


    <div class="container_12">
        <br>
        <br>

        <div id="container" style="min-width: 310px; height: 400px; max-width: 600px; margin: 0 auto"></div>
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
                        text: 'Porcentaje de la población estuiantil que ha registrado su historial médico'
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

                            {
                                name: 'H.M. Registrado',
                                y: parseInt(document.getElementById('MainContent_AlumnosRegistrados').value),
                                sliced: true,
                                selected: true,
                                color: '#55DB71'
                            },
            {
                name: 'H.M. No Registrado',
                y: parseInt(document.getElementById('MainContent_TotalAlumnos').value) - parseInt(document.getElementById('MainContent_AlumnosRegistrados').value), //<?php echo $alumnos; ?>,
                color: '#60B1D6'
            }

                        ]
                    }]
                });
            });
        </script>

        <div id="app">
            <label id="label_grafico">Leyenda</label><br>

            <table border="2" class=" table table-bordered ">
                <thead class="thead-dark">
                    <th>Registrados</th>
                    <th>Total de Alumnos</th>
                </thead>
                <tr>
                    <td>
                        <input type="button" id="hm_registrado">{{registrado}}</td>
                    <td>
                        <input type="button" id="hm_noregistrado">{{no_registrado}}</td>
                </tr>
            </table>
        </div>
        <script>
            var app = new Vue({
                el: "#app",
                data: {
                    registrado: document.getElementById('MainContent_AlumnosRegistrados').value,
                    no_registrado: document.getElementById('MainContent_TotalAlumnos').value,
                },
            });
        </script>

        <script src="../../../highcharts/js/localhighcharts.js"></script>
        <script src="../../../highcharts/js/localexporting.js"></script>

        <br />
        <h4><a href="imprimir_reporte/imprimir_reportes.aspx" target="_blank" style="text-align: center; font-size: x-large;">Imprimir Reporte</a></h4>
        <hr />
        <br>
    </div>
    <br>
</asp:Content>

