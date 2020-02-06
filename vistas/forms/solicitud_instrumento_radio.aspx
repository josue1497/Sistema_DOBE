<%@ Page Language="C#" AutoEventWireup="true" CodeFile="solicitud_instrumento_radio.aspx.cs" Inherits="reposos" MasterPageFile="~/vistas/forms/FormMasterPage.master" %>

<asp:Content runat="server" ID="ReposoContent" ContentPlaceHolderID="MainContent">
    <form id="reposo_form" runat="server">
        <div>
            <br />
            <h3 class="h3-forms" id="title">Solicitud Instrumento Radio</h3>
            <br />
            <asp:Label ID="DatosPersonales" runat="server" Text="Estudiante: "></asp:Label>
            <asp:TextBox ID="NombreyApellido" runat="server" Enabled="false" CssClass="textBox-medium"></asp:TextBox><br />

            <asp:Label ID="Label5" runat="server" Text="Instrumento: "></asp:Label>
            <asp:DropDownList ID="instrumento_id" runat="server" CssClass="textBox-short" DataSourceID="InstrupemtoDS" DataTextField="instrumento_radio" DataValueField="cod_instrumento_radio"></asp:DropDownList>
            <asp:SqlDataSource ID="InstrupemtoDS" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT [cod_instrumento_radio], [instrumento_radio] FROM [instrumento_radio]"></asp:SqlDataSource>
            <br />
            
            <asp:Label ID="Label1" runat="server" Text="Motivo: "></asp:Label>
            <asp:TextBox ID="motivo" runat="server" TextMode="MultiLine" required="true"></asp:TextBox><br />

            <asp:Label ID="Label2" runat="server" Text="Fecha del Uso: "></asp:Label>
            <input id="fecha_uso" type="date" runat="server" required/><br />
                        
            <asp:Label ID="EstatusReposoLabel" runat="server" Text="Estado: "></asp:Label>
            <asp:DropDownList ID="estatusReposo" runat="server" CssClass="textBox-short"></asp:DropDownList><br />

            <asp:Label ID="Mensaje" runat="server" Text="" Font-Size="20px"></asp:Label><br />
            <br />

            <asp:Button ID="enviar" runat="server" Text="Enviar" OnClick="enviarBtn_click" CssClass="button" />


        </div>
    </form>
</asp:Content>
