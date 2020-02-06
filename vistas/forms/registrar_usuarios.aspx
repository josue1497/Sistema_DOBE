<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registrar_usuarios.aspx.cs" Inherits="vistas_forms_registrar_usuarios" MasterPageFile="~/vistas/forms/FormMasterPage.master" %>

<asp:Content runat="server" ID="UsuariosContent" ContentPlaceHolderID="MainContent">
    <form id="form1" runat="server">
        <div class="contenido"><br />
            <h3 class="h3-forms">Gestión De Usuario</h3>
            <br />
            <asp:Label ID="Label1" runat="server" Text="CI.: "></asp:Label><asp:TextBox ID="txtCI" runat="server" required="true"></asp:TextBox><br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Nombres: "></asp:Label><asp:TextBox ID="txtNombre" runat="server" required="true"></asp:TextBox><br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Apellidos: "></asp:Label><asp:TextBox ID="txtApellido" runat="server" required="true"></asp:TextBox><br />
            <br />
             <asp:Label ID="Label12" runat="server" Text="Edad: "></asp:Label><asp:TextBox ID="txtEdad" runat="server" required="true"></asp:TextBox><br />
            <br />
             <asp:Label ID="Label11" runat="server" Text="Género: "></asp:Label><asp:DropDownList ID="sexo" runat="server">
                <asp:ListItem Value="1">Masculino</asp:ListItem>
                <asp:ListItem Value="2">Femenino</asp:ListItem>
            </asp:DropDownList><br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Correo Electrónico: "></asp:Label><input type="email" id="txtEmail" runat="server" required /><br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Teléfono: "></asp:Label><input type="tel" runat="server" id="txtTelf" required placeholder="0123-456-7890"
                pattern="[0-9]{4}-[0-9]{3}-[0-9]{4}" /><br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Usuario: "></asp:Label><asp:TextBox ID="txtUs" runat="server" required="true"></asp:TextBox><br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="Contraseña: "></asp:Label><asp:TextBox ID="txtPass" runat="server" TextMode="Password" required="true"></asp:TextBox><br />
            <br />
            <asp:Label ID="Label8" runat="server" Text="Confirme Contraseña: "></asp:Label><asp:TextBox ID="txtPassConfirm" runat="server" TextMode="Password" required="true"></asp:TextBox><asp:Label ID="Error1" runat="server" Text="" ForeColor="Red"></asp:Label><br />
            <br />
            <br />
            <asp:Label ID="Label9" runat="server" Text="TIpo Usuario: "></asp:Label><asp:DropDownList ID="rol" runat="server" >
                <asp:ListItem Value="0" Text="Rol"></asp:ListItem>
                <asp:ListItem Value="1" Text="Administrador"></asp:ListItem>
                <asp:ListItem Value="2" Text="Jefe Dobe"></asp:ListItem>
                <asp:ListItem Value="3" Text="Secretaria"></asp:ListItem>
            </asp:DropDownList>
            &nbsp;<asp:Label ID="Error3" runat="server" Text="" ForeColor="Red"></asp:Label><br />
            <br />
            <asp:Label ID="Label10" runat="server" Text="Estatus: " Visible="false"></asp:Label><asp:TextBox ID="txtEstatus" Visible="false" runat="server"></asp:TextBox><br />
            <br />
            <br />
            <asp:Label ID="Mensaje" runat="server" Text="" Font-Size="20px"></asp:Label><br />
            <br />
            <asp:Button ID="enviar" runat="server" Text="Registrar Usuario" OnClick="enviar_Click" />
        </div>
    </form>
</asp:Content>
