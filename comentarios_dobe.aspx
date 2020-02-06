<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="comentarios_dobe.aspx.cs" Inherits="comentarios__dobe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <form id="com" runat="server">
        <header class="pad0">
            <div class="container_12 p_zero">
                <div class="grid_12">

                    <div class="header_links" style="margin-top: -18%;">
                        <a href="#"></a>
                        <a href="#">Comentarios</a><br>
                        <br>
                        <div class="slogan"></div>
                    </div>
                </div>
            </div>
            <div class="clear"></div>

            <div class="header_bot">
                <div class="menu_block">
                    <nav>
                        <ul class="sf-menu">
                            <li class="current">
                                <asp:LinkButton ID="inicio" runat="server" OnClick="inicio_Click">Inicio</asp:LinkButton></li>
                            <li>
                                <a href="/login.aspx" class="menu">Cerrar Sesión</a>
                            </li>
                        </ul>
                    </nav>
                </div>
            </div>
            <div class="clear"></div>
        </header>
       <asp:PlaceHolder ID="contenido" runat="server">

       </asp:PlaceHolder>
    </form>
</asp:Content>

