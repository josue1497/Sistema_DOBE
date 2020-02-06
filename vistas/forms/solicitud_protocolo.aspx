<%@ Page Language="C#" AutoEventWireup="true" CodeFile="solicitud_protocolo.aspx.cs" Inherits="reposos" MasterPageFile="~/vistas/forms/FormMasterPage.master" %>

<asp:Content runat="server" ID="ReposoContent" ContentPlaceHolderID="MainContent">
    <form id="reposo_form" runat="server">
        <div>
            <br />
            <h3 class="h3-forms" id="title">Solicitud Protocolo</h3>
            <br />
            <asp:Label ID="DatosPersonales" runat="server" Text="Estudiante: "></asp:Label>
            <asp:TextBox ID="NombreyApellido" runat="server" Enabled="false" CssClass="textBox-medium"></asp:TextBox><br />

            <asp:Label ID="ReposoDoc" runat="server" Text="Foto Carnet: "></asp:Label>
            <asp:FileUpload ID="fotoCarnet" runat="server" accept="image/jpeg,image/png" required="true" />
            <br />

            <asp:Label ID="Label1" runat="server" Text="Talla Camisa: "></asp:Label>
            <asp:TextBox ID="tallaCamisa" runat="server" CssClass="textBox-short" required="true"></asp:TextBox><br />

            <asp:Label ID="Label2" runat="server" Text="Talla Pantalon: "></asp:Label>
            <asp:TextBox ID="tallaPantalon" runat="server" CssClass="textBox-short" required="true"></asp:TextBox><br />

            <asp:Label ID="Label3" runat="server" Text="Talla Zapatos: "></asp:Label>
            <asp:TextBox ID="tallaZapatos" runat="server" CssClass="textBox-short" required="true"></asp:TextBox><br />

            <asp:Label ID="periodoLabel" runat="server" Text="Telefono: "></asp:Label>
            <asp:TextBox ID="telefono" runat="server" CssClass="textBox-short" placeholder="0123-456-7890"
                pattern="[0-9]{4}-[0-9]{3}-[0-9]{4}" required="true"></asp:TextBox><br />

            <asp:Label ID="Label4" runat="server" Text="Dirección: "></asp:Label> 
            <asp:TextBox ID="direccion" runat="server"  required="true" TextMode="MultiLine"></asp:TextBox><br />

            <br />

            <asp:Label ID="EstatusReposoLabel" runat="server" Text="Estado: "></asp:Label>
            <asp:DropDownList ID="estatusReposo" runat="server" CssClass="textBox-short"></asp:DropDownList><br />

            <asp:Label ID="Mensaje" runat="server" Text="" Font-Size="20px"></asp:Label><br />
            <br />

            <asp:Button ID="enviar" runat="server" Text="Enviar" OnClick="enviarBtn_click" CssClass="button" />


        </div>
    </form>
</asp:Content>
