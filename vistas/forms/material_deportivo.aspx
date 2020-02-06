<%@ Page Language="C#" AutoEventWireup="true" CodeFile="material_deportivo.aspx.cs" Inherits="vistas_forms_material_deportivo" MasterPageFile="~/vistas/forms/FormMasterPage.master" %>

<asp:Content runat="server" ID="MaterialDepContent" ContentPlaceHolderID="MainContent">
    <form id="Material_Dep" runat="server">
        <div>
            <h3 class="h3-forms">Solicitud de Material Deportivo</h3>
            <br />
            <asp:Label ID="lAlumno" runat="server" Text="Alumno: "></asp:Label><asp:TextBox ID="txtAlumno" runat="server" Enabled="false"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="lTipo" runat="server" Text="Material Deportivo: "></asp:Label><asp:DropDownList ID="Tipo_art_dep" runat="server" DataSourceID="ArtDepDS" DataTextField="art_deportivo" DataValueField="cod_tipo_art_deportivo"></asp:DropDownList>

            <asp:SqlDataSource ID="ArtDepDS" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT [cod_tipo_art_deportivo], [art_deportivo] FROM [tipo_art_deportivo]"></asp:SqlDataSource>

            <br />
            <br />
            <asp:Label ID="cant" runat="server" Text="Cantidad: "></asp:Label><input type="number" id="txtCant" min="1" max="99" runat="server" />
            <asp:Label ID="error1" runat="server" Text="" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lDesc" runat="server" Text="Tiempo de Prestamo: "></asp:Label><input runat="server" type="number" min="1" max="12" id="txtTime" /><asp:Label ID="h" runat="server" Text="  Horas "></asp:Label>
            <asp:Label ID="error2" runat="server" Text="" ForeColor="Red"></asp:Label><br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Fecha de Reservacion: "></asp:Label><input runat="server" type="date" id="fechaReservacion" />
            <asp:Label ID="error4" runat="server" Text="" ForeColor="Red"></asp:Label><br />
            <br />

            <asp:Label ID="lEstatus" runat="server" Text="Estato de la Solicitud: "></asp:Label><asp:DropDownList ID="dSolicitud" runat="server" Enabled="false" DataSourceID="SolicitudDS" DataTextField="estatus" DataValueField="codigo"></asp:DropDownList>
            <asp:SqlDataSource ID="SolicitudDS" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT cod_estatus codigo, estatus estatus FROM estatus_solicitud where cod_estatus =1;"></asp:SqlDataSource>
            <br />
            <br />
            <asp:Label ID="Mensaje" runat="server" Text="" Font-Size="20px"></asp:Label><br />
            <br />
            <asp:Button ID="enviar" runat="server" Text="Enviar" OnClick="enviarBtn_click" CssClass="button" />
        </div>
    </form>
</asp:Content>
