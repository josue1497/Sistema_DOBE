<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="princ_personal.aspx.cs" Inherits="princ_Dobe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
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
                    <li class="current"><a href="princ_personal.aspx">Inicio</a></li>
                    <li><a href="javascript:abrirVentana('/vistas/forms/reposos_personal')">Reposos</a></li>
                    <li><a href="javascript:abrirVentana('/vistas/forms/solicitud_cita_odontologo_personal')" runat="server">Cita Odontólogo</a></li>
                    <li><a href="javascript:abrirVentana('/vistas/forms/solicitud_cita_psiologo_personal')" runat="server">Cita Psicólogo</a></li>
                    <li>
                        <a href="#">Mis Solicitudes</a>
                        <ul>
                            <li><a href="vistas/mod_personal/reposo_personal.aspx">Reposos</a></li>
                            <li><a href="vistas/mod_personal/cita_odontologo.aspx">Citas al Odontólogo</a></li>
                            <li><a href="vistas/mod_personal/cita_psicologo.aspx">Citas al Psicólogo</a></li>
                        </ul>
                    </li>
                    <li>
                        <a href="vistas/mod_personal/visita_docente.aspx">Registrar Visita</a>
                    </li>
                    <li>
                        <a href="login.aspx" class="menu">Cerrar Sesión</a>
                    </li>
                </ul>
            </nav>
            <div class="clear"></div>
        </div>

        <div class="clear"></div>
    </div>
    <div class="clear"></div>

    <!--==============================content================================-->
    <!--============== Agregado por Raul ==============!-->
    <div class="container_12">
        <br>
        <h2 id="titleInicioSesion">Principal Personal</h2>
        <table id="datos_dobe">
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
                        Dirección: &nbsp; 
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
        <br>

        <br>
    </div>
    <!--============== Agregado por Raul ==============!-->
    <!--==============================content================================-->


</asp:Content>

