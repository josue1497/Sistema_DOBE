<%@ Page Language="C#" AutoEventWireup="true" CodeFile="incorporacionMaterias.aspx.cs" Inherits="vistas_tablas_incorporacionMaterias" MasterPageFile="~/vistas/forms/FormMasterPage.master" %>
<asp:Content runat="server" ID="comooS" ContentPlaceHolderID="MainContent">
    <form id="form1" runat="server">
        <h3 class="h3-forms">Incorporar Materias</h3>
    <div>
    <asp:PlaceHolder ID="docentes" runat="server">
        <asp:CheckBoxList ID="listDoc" runat="server" OnSelectedIndexChanged="listDoc_SelectedIndexChanged" AutoPostBack="true">
        </asp:CheckBoxList>
    </asp:PlaceHolder>
        <br />
            <asp:Label ID="Mensaje" runat="server" Text="" Font-Size="20px"></asp:Label><br />
            <br />
        <asp:Button id="btnRegistrar" runat="server" Text="Incorporar" OnClick="btnRegistrar_Click"/>
    </div>
    </form>

</asp:Content>