<%@ Page Language="C#" AutoEventWireup="true" CodeFile="solicitud_cita_odontologo_docente.aspx.cs" Inherits="reposos" MasterPageFile="~/vistas/forms/FormMasterPage.master" %>

<asp:Content runat="server" ID="ReposoContent" ContentPlaceHolderID="MainContent">
    <form id="reposo_form" runat="server">
        <div>
            <br />
            <h3 class="h3-forms" id="title">Solicitud Cita al Odontólogo</h3>
            <br />
            <asp:Label ID="DatosPersonales" runat="server" Text="Solicitante: "></asp:Label>
            <asp:TextBox ID="NombreyApellido" runat="server" Enabled="false" CssClass="textBox-medium"></asp:TextBox><br />

            <asp:Label ID="Label1" runat="server" Text="Motivo: "></asp:Label>
            <asp:TextBox ID="motivo" runat="server" TextMode="MultiLine" required="true"></asp:TextBox><br />

            <asp:Label ID="EstatusReposoLabel" runat="server" Text="Estado: "></asp:Label>
            <asp:DropDownList ID="estatusReposo" runat="server" CssClass="textBox-short"></asp:DropDownList><br />

            <asp:Label ID="Mensaje" runat="server" Text="" Font-Size="20px"></asp:Label><br />
            <br />

            <asp:Button ID="enviar" runat="server" Text="Enviar" OnClick="enviarBtn_click" CssClass="button" />


        </div>
    </form>
</asp:Content>
