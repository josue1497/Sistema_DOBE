<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/forms/FormMasterPage.master" AutoEventWireup="true" CodeFile="AfiliacionEquipos.aspx.cs" Inherits="vistas_forms_AfiliacionEquipos" %>

<asp:Content ID="EquiposDeportivos" ContentPlaceHolderID="MainContent" Runat="Server">
     <form id="CoralBanda" runat="server">
    <div>
    <h3 class="h3-forms">Solicitud de Ingreso a un Equipo dentro del PSM</h3>
        <br />
        <asp:Label ID="lAlumno" runat="server" Text="Alumno: "></asp:Label><asp:TextBox ID="txtAlumno" runat="server" Enabled="false"></asp:TextBox> <br /> <br />

         <asp:Label ID="Label1" runat="server" Text="Equipos Disponibles: "></asp:Label><asp:DropDownList ID="equipo" runat="server" DataSourceID="EquipoDS" DataTextField="desc_equipo" DataValueField="cod_equipo" ></asp:DropDownList> 
         <asp:SqlDataSource ID="EquipoDS" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT [cod_equipo], [desc_equipo] FROM [equipo_psm]"></asp:SqlDataSource>
         <br /> <br />

         <asp:Label ID="lMotivo" runat="server" Text="Motivo: "></asp:Label><asp:TextBox ID="txtMotivo" runat="server" TextMode="MultiLine"></asp:TextBox> <asp:Label ID="error1" runat="server" Text="" ForeColor="Red"></asp:Label><br /> <br />

        <asp:Label ID="lEstatus" runat="server" Text="Estato de la Solicitud: "></asp:Label><asp:DropDownList ID="dSolicitud" runat="server" Enabled="false" DataSourceID="SolicitudDS" DataTextField="estatus" DataValueField="codigo" ></asp:DropDownList> 
        <asp:SqlDataSource ID="SolicitudDS" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT cod_estatus codigo, estatus estatus FROM estatus_solicitud where cod_estatus =1;"></asp:SqlDataSource>
        <br /> <br />
         <asp:Label ID="Mensaje" runat="server" Text="" Font-Size="20px"></asp:Label><br />
            <br />
            <asp:Button ID="enviar" runat="server" Text="Enviar" OnClick="enviar_Click" CssClass="button" />
    </div>
    </form>
</asp:Content>

