<%@ Page Language="C#" AutoEventWireup="true" CodeFile="evento_deportivo.aspx.cs" Inherits="vistas_forms_evento_deportivo" MasterPageFile="~/vistas/forms/FormMasterPage.master"%>

<asp:Content runat="server" ID="Even_dep" ContentPlaceHolderID="MainContent">
    <form id="Event_Dep" runat="server">
    <div>
    <h3 class="h3-forms">Solicitud de Evento Deportivo</h3>
        <br />
        <asp:Label ID="lAlumno" runat="server" Text="Alumno: "></asp:Label><asp:TextBox ID="txtAlumno" runat="server" Enabled="false"></asp:TextBox> <br /> <br />

         <asp:Label ID="lTipo" runat="server" Text="Tipo Evento: "></asp:Label><asp:DropDownList ID="Tipo_Evento" runat="server" DataSourceID="TipoEventoDS" DataTextField="tipo_evento" DataValueField="cod_tipo_evento_dep" ></asp:DropDownList> 
        
        <asp:SqlDataSource ID="TipoEventoDS" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT [cod_tipo_evento_dep], [tipo_evento] FROM [tipo_evento_dep]"></asp:SqlDataSource>
        
        <br /> <br />

         <asp:Label ID="lDesc" runat="server" Text="Motivo: "></asp:Label><asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" MaxLength="50"></asp:TextBox> <asp:Label ID="error1" runat="server" Text="" ForeColor="Red"></asp:Label><br /> <br />

        <asp:Label ID="lEstatus" runat="server" Text="Estato de la Solicitud: "></asp:Label><asp:DropDownList ID="dSolicitud" runat="server" Enabled="false" DataSourceID="SolicitudDS" DataTextField="estatus" DataValueField="codigo" ></asp:DropDownList> 
        <asp:SqlDataSource ID="SolicitudDS" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT cod_estatus codigo, estatus estatus FROM estatus_solicitud where cod_estatus =1;"></asp:SqlDataSource>
        <br /> <br />
         <asp:Label ID="Mensaje" runat="server" Text="" Font-Size="20px"></asp:Label><br />
            <br />
            <asp:Button ID="enviar" runat="server" Text="Enviar" OnClick="enviarBtn_click" CssClass="button" />
    </div>
    </form>
</asp:Content>
