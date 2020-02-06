<%@ Page Language="C#" AutoEventWireup="true" CodeFile="coral_banda.aspx.cs" Inherits="vistas_forms_coral_banda" MasterPageFile="~/vistas/forms/FormMasterPage.master"%>

<asp:Content runat="server" ID="CoralbandaContent" ContentPlaceHolderID="MainContent">
    <form id="CoralBanda" runat="server">
    <div>
    <h3 class="h3-forms">Solicitud de Ingreso a La Coral o a la Banda</h3>
        <br />
        <asp:Label ID="lAlumno" runat="server" Text="Alumno: "></asp:Label><asp:TextBox ID="txtAlumno" runat="server" Enabled="false"></asp:TextBox> <br /> <br />

         <asp:Label ID="Label1" runat="server" Text="¿Coral o Banda? "></asp:Label><asp:DropDownList ID="Coral_Banda" runat="server" Enabled="true" DataSourceID="CoralBandaDS" DataTextField="tipo" DataValueField="codigo"></asp:DropDownList> 
        <asp:SqlDataSource ID="CoralBandaDS" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT cod_tipo_coral_banda codigo, coral_banda tipo FROM [tipo_coral_banda]"></asp:SqlDataSource>
        <br /> <br />

         <asp:Label ID="lMotivo" runat="server" Text="Motivo: "></asp:Label><asp:TextBox ID="txtMotivo" runat="server" TextMode="MultiLine"></asp:TextBox> <asp:Label ID="error1" runat="server" Text="" ForeColor="Red"></asp:Label><br /> <br />

        <asp:Label ID="lEstatus" runat="server" Text="Estato de la Solicitud: "></asp:Label><asp:DropDownList ID="dSolicitud" runat="server" Enabled="false" DataSourceID="SolicitudDS" DataTextField="estatus" DataValueField="codigo" ></asp:DropDownList> 
        <asp:SqlDataSource ID="SolicitudDS" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT cod_estatus codigo, estatus estatus FROM estatus_solicitud where cod_estatus =1;"></asp:SqlDataSource>
        <br /> <br />
         <asp:Label ID="Mensaje" runat="server" Text="" Font-Size="20px"></asp:Label><br />
            <br />
            <asp:Button ID="enviar" runat="server" Text="Enviar" OnClick="enviarBtn_click" CssClass="button" />
    </div>
    </form>
</asp:Content>