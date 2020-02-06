<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="login" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="header_links">
        <a href="https://mail.psm.edu.ve/owa" target="blank">Correo Institucional</a>
        <a href="http://www.psm.edu.ve/sawebvalencia" target="_blank" onclick="window.open(this.href, this.target, 'width=1000,height=700,scrollbars'); return false;">Mi PSM en Línea</a><br>
        <br>
        <div class="slogan"></div>
    </div>
    <div class="clear"></div>
    <div class="header_bot">
        <div class="menu_block">
            <nav>
                <ul class="sf-menu">
                    <li class="current"><a href="index.html">Inicio</a></li>
                    <li><a href="paginas/nosotros/nosotros.html">Nosotros</a></li>
                    <li>
                        <a href="#.html">Oferta Acad&eacute;mica</a>
                        <ul>
                            <li><a href="#.html">Carreras</a>
                                <ul>
                                    <li>
                                        <a href="paginas/carreras/arquitectura.html">Arquitectura
                                        </a>
                                    </li>
                                    <li><a href="#.html">Ingeniería</a>
                                        <ul>

                                            <li>
                                                <a href="paginas/carreras/civil.html">Civil
                                                </a>
                                            </li>
                                            <li>
                                                <a href="paginas/carreras/electrica.html">El&eacute;ctrica
                                                </a>
                                            </li>
                                            <li>
                                                <a href="paginas/carreras/electronica.html">Electr&oacute;nica
                                                </a>
                                            </li>
                                            <li>
                                                <a href="paginas/carreras/industrial.html">Industrial
                                                </a>
                                            </li>
                                            <li>
                                                <a href="paginas/carreras/mantenimiento.html">Mantenimiento Mec&aacute;nico
                                                </a>
                                            </li>
                                            <li>
                                                <a href="paginas/carreras/sistemas.html">Sistemas
                                                </a>
                                            </li>
                                            <li>
                                                <a href="paginas/carreras/diseno.html">Dise&ntilde;o Industrial
                                                </a>
                                            </li>
                                        </ul>
                                    </li>
                                </ul>
                            </li>
                            <li><a href="paginas/cursos/cursos.html">Cursos</a></li>
                        </ul>
                    </li>
                    <li><a href="#">Procesos Institucionales</a>
                        <ul>
                            <li><a href="paginas/inscripciones.html">Nuevo Ingreso</a>
                            <li><a href="paginas/inscripciones2.html">Equivalencias</a></li>
                            <li><a href="paginas/traslados.html">Traslados</a></li>
                            <li><a href="paginas/cambioEspecialidad.html">Cambio de Carrera</a></li>
                            <li><a href="paginas/emisionDocumentos.html">Constancias</a></li>
                            <li><a href="paginas/departamentos/servComunitario.html">Servicio Comunitario</a></li>
                        </ul>
                    </li>
                    <li><a href="http://www.psm.edu.ve/sawebvalencia" target="_blank" onclick="window.open(this.href, this.target, 'width=1000,height=700,scrollbars'); return false;">Consulta tus Notas</a></li>

                    <li><a href="paginas/contacto.html" class="menu">Cont&aacute;ctanos</a>
                    </li>
                </ul>
            </nav>
            <div class="clear"></div>
        </div>

        <div class="clear"></div>
        <div class="clear"></div>
    </div>



    <br />
    <br />
    <h2 id="titleInicioSesion">Inicio de Sesión</h2>
    <br />
    <form id="formLogin" runat="server">
        <asp:TextBox ID="usuario" CssClass=" form-control usuario" runat="server" placeholder="Usuario" TextMode="SingleLine"></asp:TextBox>&nbsp;<asp:Label ID="Error1" runat="server" Text="" ForeColor="Red"></asp:Label><br>
        <asp:TextBox ID="password" CssClass="form-control password" TextMode="Password" placeholder="Contraseña" runat="server"></asp:TextBox>&nbsp;<asp:Label ID="Error2" runat="server" Text="" ForeColor="Red"></asp:Label><br>
        <asp:DropDownList ID="rol" runat="server" CssClass="rol">
            <asp:ListItem Value="0" Text="Rol"></asp:ListItem>
            <asp:ListItem Value="1" Text="Administrador"></asp:ListItem>
            <asp:ListItem Value="2" Text="Jefe Dobe"></asp:ListItem>
            <asp:ListItem Value="3" Text="Secretaria"></asp:ListItem>
            <asp:ListItem Value="4" Text="Estudiante"></asp:ListItem>
            <asp:ListItem Value="5" Text="Docente"></asp:ListItem>
            <asp:ListItem Value="6" Text="Personal"></asp:ListItem>
        </asp:DropDownList>
        &nbsp;<asp:Label ID="Error3" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br>
        <asp:Label ID="Mensaje" runat="server" Text="" Font-Size="20px" ForeColor="Red"></asp:Label><br />
        <asp:Button ID="btnLogin" runat="server" Text="Acceder" CssClass="form-control acceder" OnClick="btnLogin_Click" /><br>
        &nbsp;<asp:Label ID="Error4" runat="server" Text="" ForeColor="Red" CssClass="UserMessage"></asp:Label>
    </form>

</asp:Content>

