<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/maestras/maestras.master" AutoEventWireup="true" CodeFile="equipo_psm.aspx.cs" Inherits="vistas_maestras_equipo_psm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <h3 class="h3-forms-maestra">Disciplina Deportiva</h3>
    <asp:Label ID="label1" runat="server" Text="Ingrese el Nombre del equipo que desea registrar."></asp:Label> <br /><br />
    <asp:TextBox ID="desc_equipo" runat="server" required></asp:TextBox><br /><br />
     <asp:Label ID="label2" runat="server" Text="Disciplina: "></asp:Label> 
    <asp:DropDownList ID="list_disc" runat="server" DataSourceID="disciplinaDS" DataTextField="desc_disciplina" DataValueField="cod_disciplina"></asp:DropDownList>
     <asp:SqlDataSource ID="disciplinaDS" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT [cod_disciplina], [desc_disciplina] FROM [disciplina]"></asp:SqlDataSource>
     <br />
    <asp:Button id="button_reg" runat="server" Text="Registrar" OnClick="button_reg_Click"/>
    <asp:Label ID="Mensaje" runat="server" Text=""></asp:Label>
</asp:Content>

