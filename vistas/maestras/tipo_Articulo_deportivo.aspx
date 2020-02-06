<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/maestras/maestras.master" AutoEventWireup="true" CodeFile="tipo_Articulo_deportivo.aspx.cs" Inherits="vistas_maestras_tipo_Articulo_deportivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <h3 class="h3-forms-maestra">Artículos Deportivos</h3>
    <asp:Label ID="label1" runat="server" Text="Ingrese el Nombre del Artículo que desea registrar."></asp:Label> <br /><br />
    <asp:TextBox ID="desc_articulo" runat="server" required></asp:TextBox><br /><br />
    <asp:Button id="button_reg" runat="server" Text="Registrar" OnClick="button_reg_Click"/>
    <asp:Label ID="Mensaje" runat="server" Text=""></asp:Label>
</asp:Content>

