<%@ Page Language="C#" AutoEventWireup="true" CodeFile="renovacion_becas.aspx.cs" Inherits="vistas_forms_becas" MasterPageFile="~/vistas/forms/FormMasterPage.master" %>

<asp:Content runat="server" ID="BecasContent" ContentPlaceHolderID="MainContent">
    <form id="Becas_Form" runat="server">
        <div>
            <h3 class="h3-forms">Solicitud de Becas</h3>
            <br />
            <asp:Label ID="lAlumno" runat="server" Text="Alumno: "></asp:Label><asp:TextBox ID="txtAlumno" runat="server" Enabled="false"></asp:TextBox><br /><br />
            <asp:Label ID="lTipoBeca" runat="server" Text="Tipo Beca: " />
            <asp:DropDownList ID="dTipoBeca" runat="server" DataSourceID="TIpoBecaDS" DataTextField="tipo_beca" DataValueField="cod_tipo_beca" Enabled="false"></asp:DropDownList>
            <asp:SqlDataSource ID="TIpoBecaDS" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT [cod_tipo_beca], [tipo_beca] FROM [tipo_beca]"></asp:SqlDataSource>
            <br /><br />
            <asp:Label ID="Label1" runat="server" Text="Beca Período Anterior: " /><asp:TextBox ID="periodo_Anterior" runat="server" Enabled="false"></asp:TextBox><br /><br />
            <asp:Label ID="Label2" runat="server" Text="Código Beca Anterior: " /><asp:TextBox ID="cod_ant" runat="server" Enabled="false"></asp:TextBox><br /><br />
            <asp:Label ID="Mensaje" runat="server" Text="" Font-Size="20px"></asp:Label><br /><br />
            <br />
            <asp:Button ID="enviar" runat="server" Text="Renovar" OnClick="enviar_Click" />

        </div>
    </form>
</asp:Content>
