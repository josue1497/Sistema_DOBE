<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/maestras/maestras.master" AutoEventWireup="true" CodeFile="tipo_beca.aspx.cs" Inherits="vistas_maestras_tipo_beca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <h3 class="h3-forms-maestra">Tipos de Becas</h3>
    <asp:Label ID="label1" runat="server" Text="Ingrese el Tipo de Beca que desea registrar."></asp:Label> <br /><br />
    <asp:TextBox ID="desc_beca" runat="server" required></asp:TextBox><br /><br />
    <asp:Button id="button_reg" runat="server" Text="Registrar" OnClick="button_reg_Click"/>
    <asp:Label ID="Mensaje" runat="server" Text=""></asp:Label>
</asp:Content>

