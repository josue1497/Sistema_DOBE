<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registrarPersonal.aspx.cs" Inherits="registrarmedicos" MasterPageFile="~/vistas/forms/FormMasterPage.master"%>

<asp:Content runat="server" ID="MedicosContent" ContentPlaceHolderID="MainContent">
    <form id="registrarmedico" runat="server"><br /><br />
        <h2 id="titleInicioSesion">Registrar Personal</h2><br/>
    <div>
        <asp:Label ID="lPrima" runat="server" Text="Cedula: "></asp:Label>
        <asp:TextBox ID="txtCedula" runat="server" CssClass="textBox-medium" required="true"></asp:TextBox><br />
        <asp:Label ID="Label2" runat="server" Text="Contraseña: "></asp:Label>
        <asp:TextBox ID="txtPass" runat="server" CssClass="textBox-medium" TextMode="Password" required="true"></asp:TextBox><br />

        <asp:Label ID="lNombre" runat="server" Text="Nombre: "></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="textBox-medium" required="true"></asp:TextBox><br />

        <asp:Label ID="lApellido" runat="server" Text="  Apellido"></asp:Label>
        <asp:TextBox ID="txtApellido" runat="server" CssClass="textBox-medium" required="true"></asp:TextBox><br />

        <asp:Label ID="lTelefono" runat="server" Text="Telf.:"></asp:Label>
        <asp:TextBox ID="txtTelf" runat="server" CssClass="textBox-short"  placeholder="0123-456-7890"
                pattern="[0-9]{4}-[0-9]{3}-[0-9]{4}" required="true"></asp:TextBox><br />

        <asp:Label ID="lEmail" runat="server" Text="Direccion: "></asp:Label>
        <asp:TextBox ID="txtDireccion" runat="server" TextMode="MultiLine" required ="true"></asp:TextBox><br />
        
        
            <asp:Label ID="EstatusReposoLabel" runat="server" Text="Genero: "></asp:Label>
            <asp:DropDownList ID="dGenero" runat="server" DataSourceID="sexods" DataTextField="genero" DataValueField="cod_sexo"></asp:DropDownList>
        <asp:SqlDataSource ID="sexods" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT [cod_sexo], [genero] FROM [sexo]"></asp:SqlDataSource>
        <br />
        
        <asp:Label ID="Label1" runat="server" Text="Cargo: "></asp:Label>
            <asp:DropDownList ID="dCargo" runat="server" DataSourceID="cargods" DataTextField="desc_cargo" DataValueField="cod_cargo"></asp:DropDownList>
        <asp:SqlDataSource ID="cargods" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT [cod_cargo], [desc_cargo] FROM [cargo]"></asp:SqlDataSource>
        <br />
        
        
        <br />

          <asp:Label ID="Mensaje" runat="server" Text="" Font-Size="20px"></asp:Label><br /><br />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="guardarBtn_click" CssClass="button" />
    </div>
    </form>
</asp:Content>
