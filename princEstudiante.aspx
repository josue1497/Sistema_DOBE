<%@ Page Title="Pagina Principal Estudiantes" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="princEstudiante.aspx.cs" Inherits="princEstudiante" %>

<%@ PreviousPageType VirtualPath="~/login.aspx" %>
<asp:Content ID="PrincEstudiante" ContentPlaceHolderID="MainContent" runat="Server">

    <!--============== Agregado por Raul ==============!-->

    <header class="pad0">
        <div class="container_12 p_zero">
            <div class="header_links">
                <a href="/">Estudiante</a>
                <a href="/hmedico.aspx">Mi Historial Médico</a>
                <div class="slogan"></div>
            </div>

            <div class="clear"></div>

            <div class="header_bot">
                <div class="menu_block">
                    <nav>
                        <ul class="sf-menu">
                            <li class="current"><a href="princEstudiante.aspx">Inicio</a></li>
                            <li>
                                <a href="#.html">Generar Solicitudes</a>
                                <ul>
                                    <li><a href="#')" runat="server">Beca</a>
                                        <ul>
                                            <li><a href="javascript:abrirVentana('/vistas/forms/becas')" runat="server">Beca</a></li>
                                            <li><a href="javascript:abrirVentana('/vistas/forms/renovacion_becas')" runat="server">Renovacion Beca</a></li>
                                        </ul>
                                    </li>
                                    <li><a href="javascript:abrirVentana('/vistas/forms/material_deportivo')" runat="server">Material Deportivo</a></li>
                                    <li><a href="javascript:abrirVentana('/vistas/forms/evento_deportivo')" runat="server">Evento Deportivo</a></li>
                                    <li><a href="javascript:abrirVentana('/vistas/forms/evento_cultural')" runat="server">Evento Cultural</a></li>
                                    <li><a href="javascript:abrirVentana('/vistas/forms/coral_banda')" runat="server">Coral o Banda</a></li>
                                    <li><a href="javascript:abrirVentana('/vistas/forms/AfiliacionEquipos')" runat="server">Afiliación a Equipos</a></li>
                                    <li><a href="javascript:abrirVentana('/vistas/forms/solicitud_protocolo')" runat="server">Protocolo</a></li>
                                    <li><a href="javascript:abrirVentana('/vistas/forms/solicitud_instrumento_radio')" runat="server">Instrumento Radio</a></li>
                                     <li><a href="javascript:abrirVentana('/vistas/forms/solicitud_cita_odontologo')" runat="server">Cita Odontólogo</a></li>
                                     <li><a href="javascript:abrirVentana('/vistas/forms/solicitud_cita_psiologo')" runat="server">Cita Psicólogo</a></li>
                                </ul>
                            </li>
                            <li>
                                <script type="text/javascript" src="js/scrip.js"></script>

                                <a href="javascript:abrirVentana('/vistas/forms/reposos')" runat="server" value="Pre-Natal">Reposos</a>
                                
                            </li>
                            <li>
                                <a href="#.html">Mis Solicitudes</a>
                                <ul>
                                   <li><a href="vistas/estudiantes_mod/reposo.aspx" runat="server">Reposos</a></li>
                                    <li><a href="vistas/estudiantes_mod/beca.aspx" runat="server">Beca</a></li>
                                    <li><a href="vistas/estudiantes_mod/materialDeportivo.aspx" runat="server">Material Deportivo</a></li>
                                    <li><a href="vistas/estudiantes_mod/eventoDeportivo.aspx" runat="server">Evento Deportivo</a></li>
                                    <li><a href="vistas/estudiantes_mod/eventoCultural.aspx" runat="server">Evento Cultural</a></li>
                                    <li><a href="vistas/estudiantes_mod/coralbanda.aspx" runat="server">Coral o Banda</a></li>
                                    <li><a href="vistas/estudiantes_mod/afiliacionEquipo.aspx" runat="server">Afiliación a Equipos</a></li>
                                    <li><a href="vistas/estudiantes_mod/protocolo.aspx" runat="server">Protocolo</a></li>
                                    <li><a href="vistas/estudiantes_mod/instrumento_radio.aspx" runat="server">Instrumentos de Radio</a></li>
                                    <li><a href="vistas/estudiantes_mod/cita_odontologo.aspx" runat="server">Cita al Odontólogo</a></li>
                                    <li><a href="vistas/estudiantes_mod/cita_psicologo.aspx" runat="server">Cita al Psicólogo</a></li>
                                </ul>
                            </li>
                            <li>
                                <a href="comentarios_alumnos.aspx" class="menu">Cont&aacute;ctanos</a>
                            </li>

                            <li>
                                <a href="/login.aspx" class="menu">Cerrar Sesión</a>
                            </li>
                        </ul>
                    </nav>
                    <div class="clear"></div>
                </div>

                <div class="clear"></div>
            </div>
            <div class="clear"></div>
        </div>
        <div class="container_12">
            <div class="grid_12">
                <div class="slider_wrapper">
                    <div class="" id="camera_wrap">
                        <div data-src="images/slide.jpg">
                            <div class="caption"></div>
                        </div>
                        <div data-src="images/slide1.jpg">
                            <div class="caption"></div>
                        </div>
                        <div data-src="images/slide2.jpg">
                            <div class="caption"></div>
                        </div>
                        <div data-src="images/slide3.jpg">
                            <div class="caption"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </header>

    <!--==============================content================================-->

    <div class="container_12">
        <br>
        <h2 id="titleInicioSesion">Principal Estudiante</h2>
        <br>

        <table id="datos_estudiante">
            <tr>
                <td>
                    <label class="label">Nombre: &nbsp;
                        <asp:Label runat="server" ID="nombre" Text=""></asp:Label>
                    </label>
                </td>
                <td>
                    <label class="label">Apellido: &nbsp;
                        <asp:Label runat="server" ID="apellido" Text=""></asp:Label></label></td>
                <td>
                    <label class="label">Cedula: &nbsp;
                        <asp:Label runat="server" ID="cedula" Text=""></asp:Label></label></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <label class="label">Email: &nbsp; 
                        <asp:Label runat="server" ID="email" Text=""></asp:Label></label></td>
                <td>
                    <label class="label">Escuela: &nbsp;
                        <asp:Label runat="server" ID="escuela" Text=""></asp:Label>
                    </label>
                </td>
            </tr>
        </table>
        <br>
        <br>
        <br>
    </div>
    <br>

    <!--==============================content================================-->
</asp:Content>

