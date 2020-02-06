<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="princ_admin.aspx.cs" Inherits="princ_admin" %>

<asp:Content ID="princ_admin" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="header_links">
        <a href="#"></a>
        <a href="comentarios_dobe.aspx">Comentarios</a><br>
        <br>
        <div class="slogan"></div>
    </div>
    <div class="clear"></div>

    <div class="header_bot">
        <div class="menu_block">
            <nav>
                <ul class="sf-menu">
                    <li class=" current"><a href="/princ_admin.aspx">Inicio</a></li>
                    <li><a href="#">Solicitudes</a>
                        <ul>
                            <li><a href="/vistas/tablas/filtrarSolicitudes.aspx">Generales</a></li>
                            <li><a href="#">Citas</a>
                                <ul>
                                    <li><a href="/vistas/tablas/filtrarCitas.aspx">Citas Estudiantes</a></li>
                                    <li><a href="/vistas/tablas/filtrarCitas_docente.aspx">Citas Docentes</a></li>
                                    <li><a href="/vistas/tablas/filtrarCitas_personal.aspx">Citas Personal</a></li>
                                </ul>
                            </li>
                            <li><a href="/vistas/tablas/filtrarProtocolo.aspx">Protocolo</a></li>
                        </ul>
                    </li>
                    <li>
                        <a href="/vistas/tablas/becas.aspx">Becas</a>
                    </li>
                    <li>
                        <a href="#">Reposos</a>
                        <ul>
                            <li><a href="/vistas/tablas/reposos.aspx">Estudiantes</a></li>
                            <li><a href="/vistas/tablas/reposos_docente.aspx">Docentes</a></li>
                            <li><a href="/vistas/tablas/reposos_personal.aspx">Personal</a></li>
                        </ul>
                    </li>
                    <li>
                        <a href="#">Reportes</a>
                        <ul>
                            <li><a href="#">Reposos</a>
                                <ul>
                                    <li><a href="#">Estudiantes</a>
                                        <ul>
                                            <li><a href="vistas/reportes/reportEdad.aspx">Edad</a></li>
                                            <li><a href="vistas/reportes/reporteEscuela.aspx">Escuela</a></li>
                                            <li><a href="vistas/reportes/reporteSexo.aspx">Género</a></li>
                                        </ul>
                                    </li>
                                    <li><a href="#">Nomina</a>
                                        <ul>
                                            <li><a href="vistas/reportes/cantidad_visitas_personal.aspx">Tipo de Nómina</a>
                                            </li>
                                            <li><a href="vistas/reportes/genero_personal.aspx">Genero</a></li>
                                        </ul>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <a href="#">Visitas a D.O.B.E</a>
                                <ul>
                                    <li><a href="#">Top 10 Razones</a>
                                        <ul>
                                            <li><a href="vistas/reportes/visitas_docente.aspx">Docentes</a></li>
                                            <li><a href="vistas/reportes/visitas_personal.aspx">Personal</a></li>
                                        </ul>
                                    </li>
                                    <li><a href="#">Listado</a>
                                        <ul>
                                            <li><a href="vistas/reportes/reporte_docente_visita.aspx">Docentes</a></li>
                                            <li><a href="vistas/reportes/reporte_personal_visita.aspx">Personal</a></li>
                                        </ul>
                                    </li>
                                    <li><a href="vistas/reportes/reporteSexoVisitas.aspx">Género</a></li>
                                </ul>
                            </li>
                            <li><a href="#">Citas</a>
                                <ul>
                                    <li><a href="vistas/reportes/desglose_citas_psicologo.aspx">Psicólogo</a></li>
                                    <li><a href="vistas/reportes/desglose_citas_odontologo.aspx">Odontólogo</a></li>
                                </ul>
                            </li>
                            <li>
                                <a href="vistas/reportes/becados.aspx">Becados</a>
                            </li>
                            <li>
                                <a href="vistas/reportes/reporte_protocolo.aspx">Protocolo</a>
                            </li>
                            <li><a href="vistas/reportes/report_HMalumno.aspx">H.M. Estudiante</a></li>
                        </ul>
                    </li>
                    <li>
                        <a href="#" class="menu">Usuarios</a>
                        <ul>
                            <script type="text/javascript" src="js/scrip.js"></script>
                            <li><a href="javascript:abrirVentana('/vistas/forms/registrar_usuarios')" runat="server">Crear</a></li>
                            <li><a href="/vistas/tablas/modificar_usuarios.aspx" runat="server">Modificar</a></li>
                        </ul>
                    </li>
                    <li>
                        <a href="#">Gestion</a>
                        <ul>
                            <li class="current"><a href="javascript:abrirVentana('/vistas/forms/delete_form')" runat="server">Gestion de Elementos</a></li>
                            <li><a href="javascript:abrirVentana('/vistas/maestras/tipo_Articulo_deportivo')" runat="server">Articulos Deportivos</a></li>
                            <li><a href="javascript:abrirVentana('/vistas/maestras/cargo')" runat="server">Cargo</a></li>
                            <li><a href="javascript:abrirVentana('/vistas/maestras/disciplina')" runat="server">Disciplina</a></li>
                            <li><a href="javascript:abrirVentana('/vistas/maestras/equipo_psm')" runat="server">Equipo PSM</a></li>
                            <li><a href="javascript:abrirVentana('/vistas/maestras/tipo_evento_cultural')" runat="server">Evento Cultural</a></li>
                            <li><a href="javascript:abrirVentana('/vistas/maestras/tipo_Evento_deportivo')" runat="server">Evento Deportivo</a></li>
                            <li><a href="javascript:abrirVentana('/vistas/maestras/instrumento_radio')" runat="server">Instrumento Radio</a></li>
                            <li><a href="javascript:abrirVentana('/vistas/maestras/tipo_beca')" runat="server">Tipos de Becas</a></li>
                            <li><a href="javascript:abrirVentana('/vistas/maestras/tipo_reposo')" runat="server">Tipos de Reposos</a></li>
                        </ul>
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

    <div class="container_12">

        <br>
        <h2 id="titleInicioSesion">Principal Administrador</h2>
        <br>

        <table id="datos_estudiante">
            <tr>
                <td>
                    <label class="label">
                        Nombre: &nbsp;
                        <asp:Label runat="server" ID="nombre" Text=""></asp:Label>
                    </label>
                </td>
                <td>
                    <label class="label">
                        Apellido: &nbsp;
                        <asp:Label runat="server" ID="apellido" Text=""></asp:Label></label></td>
                <td>
                    <label class="label">
                        Cedula: &nbsp;
                        <asp:Label runat="server" ID="cedula" Text=""></asp:Label></label></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <label class="label">
                        Email: &nbsp; 
                        <asp:Label runat="server" ID="email" Text=""></asp:Label></label></td>
                <td>
                    <label class="label">
                        Telefono: &nbsp;
                        <asp:Label runat="server" ID="telefono" Text=""></asp:Label></label></td>
                <td>
                    <label class="label">
                        Cargo: &nbsp;
                        <asp:Label runat="server" ID="cargo" Text=""></asp:Label></label></td>
            </tr>
        </table>
        <br>
        <br>
    </div>
    <br />


</asp:Content>

