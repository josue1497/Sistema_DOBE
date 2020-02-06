<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/vistas/reportes/imprimir_reporte/imprimirMaster.master" CodeFile="imprimir_reportes.aspx.cs" Inherits="vistas_reportes_imprimir_reporte_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="container_12">


        <div class="container_12">
            <hr />
            <br />
            <h2 class="title-seccion"><%Response.Write(Session["titulo"]);%></h2>
            <br />
            <hr />
            
            <div id="app">
                <table border="2" class=" table table-bordered ">
                    <thead class="thead-dark">
                        <th>Cargo</th>
                        <th>Cantidad</th>
                    </thead>
                    <tr v-for="data in all_data ">
                        <td>{{data.name}}</td>
                        <td>{{data.y}}</td>
                    </tr>
                </table>
            </div>

            <br />
            <hr />
            <br />
             <h3 class="title-seccion">Gráfica</h3>
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
                            text: ''
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
                            <%Response.Write(Session["graphic"]);%>
                            ]
                        }]
                    });
                });
            </script>

            <script>
                var app = new Vue({
                    el: "#app",
                    data: {
                        all_data:  <%Response.Write(Session["json"]);%>,
                    },
                });
            </script>

            <script src="../../../highcharts/js/localhighcharts.js"></script>
            <script src="../../../highcharts/js/localexporting.js"></script>

        </div>
    </div>
    <br />
</asp:Content>

