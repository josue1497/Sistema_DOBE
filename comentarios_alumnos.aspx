<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="comentarios_alumnos.aspx.cs" Inherits="comentarios_alumnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
       <!--============== Agregado por Raul ==============!-->

    <header class="pad0">
        <div class="container_12 p_zero">
            <div class="header_links">
                <a href="/">Estudiante</a>
                <a href="/hmedico.aspx">Mi Historial Medico</a>
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
                                    <li><a href="javascript:abrirVentana('/vistas/forms/becas')" runat="server">Beca</a></li>
                                    <li><a href="javascript:abrirVentana('/vistas/forms/material_deportivo')" runat="server">Material Deportivo</a></li>
                                    <li><a href="javascript:abrirVentana('/vistas/forms/evento_deportivo')" runat="server">Evento Deportivo</a></li>
                                    <li><a href="javascript:abrirVentana('/vistas/forms/evento_cultural')" runat="server">Evento Cultural</a></li>
                                    <li><a href="javascript:abrirVentana('/vistas/forms/coral_banda')" runat="server">Coral o Banda</a></li>
                                    <li><a href="javascript:abrirVentana('/vistas/forms/AfiliacionEquipos')" runat="server">Afiliación a Equipos</a></li>
                                </ul>
                            </li>
                            <li>
                                <script type="text/javascript" src="js/scrip.js"></script>

                                <a href="javascript:abrirVentana('/vistas/forms/reposos')" runat="server" value="Pre-Natal">Reposos</a>
                                
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
    <div class="clear"></div>
    <br />
    <br />
    <h2 id="titleInicioSesion">Envianos tus Comentarios.</h2>
    <br />
    <form id="formLogin" runat="server">
        <asp:Label ID="Alumno" runat="server"></asp:Label><br /><br />
         <asp:Label ID="Label1" runat="server" Text="Asunto: "></asp:Label>
        <asp:TextBox ID="Asunto" runat="server" placeholder="Asunto" TextMode="SingleLine" required="true"></asp:TextBox>&nbsp;<asp:Label ID="Error1" runat="server" Text="" ForeColor="Red"></asp:Label><br><br />
        <asp:TextBox ID="Texto"  TextMode="MultiLine" placeholder="Introduzca un texto" required="true" Width="600" Height="100" MaxLength="250" runat="server"></asp:TextBox>&nbsp;<asp:Label ID="Error2" runat="server" Text="" ForeColor="Red"></asp:Label><br>
        &nbsp;<asp:Label ID="Error3" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br>
        <asp:Label ID="Mensaje" runat="server" Text="" Font-Size="20px" ForeColor="Red"></asp:Label><br />
        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="form-control acceder" OnClick="btnEnviar_Click" /><br>
        &nbsp;<asp:Label ID="Error4" runat="server" Text="" ForeColor="Red" CssClass="UserMessage"></asp:Label>
    </form>
</asp:Content>

