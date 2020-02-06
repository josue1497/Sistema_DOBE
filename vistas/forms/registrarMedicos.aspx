<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registrarMedicos.aspx.cs" Inherits="registrarmedicos" MasterPageFile="~/vistas/forms/FormMasterPage.master"%>

<asp:Content runat="server" ID="MedicosContent" ContentPlaceHolderID="MainContent">
    <form id="registrarmedico" runat="server">
        <h2 id="titleInicioSesion">Registrar Médico</h2><br>
    <div>
        <asp:Label ID="lPrima" runat="server" Text="N° Prima: "></asp:Label>
        <asp:TextBox ID="txtPrima" runat="server" CssClass="textBox-medium"></asp:TextBox>
         <asp:Label ID="Error5" runat="server" Text="" ForeColor="Red"></asp:Label><br />

        <asp:Label ID="lNombre" runat="server" Text="Nombre: "></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="textBox-medium"></asp:TextBox>
         <asp:Label ID="error1" runat="server" Text="" ForeColor="Red"></asp:Label><br />

        <asp:Label ID="lApellido" runat="server" Text="  Apellido"></asp:Label>
        <asp:TextBox ID="txtApellido" runat="server" CssClass="textBox-medium"></asp:TextBox>
         <asp:Label ID="error2" runat="server" Text="" ForeColor="Red"></asp:Label><br />

        <asp:Label ID="lTelefono" runat="server" Text="Telf.:"></asp:Label>
        <asp:TextBox ID="txtTelf" runat="server" CssClass="textBox-short"></asp:TextBox>
         <asp:Label ID="error3" runat="server" Text="" ForeColor="Red"></asp:Label><br />

        <asp:Label ID="lEmail" runat="server" Text="Email: "></asp:Label>
        <asp:TextBox ID="textEmail" runat="server" CssClass="textBox-short"></asp:TextBox>
         <asp:Label ID="error4" runat="server" Text="" ForeColor="Red"></asp:Label><br /><br />

          <asp:Label ID="Mensaje" runat="server" Text="" Font-Size="20px"></asp:Label><br /><br />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Medico" OnClick="guardarBtn_click" CssClass="button" />
    </div>
    </form>
</asp:Content>
