<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/mod_docente/estudiantesMod.master" AutoEventWireup="true" CodeFile="visita_docente.aspx.cs" Inherits="hmedico" %>

<asp:Content ID="HMedico" ContentPlaceHolderID="MainContent" runat="Server">
    
   
    <!--==============================content================================-->

    <div class="container_12">
        <br>
        <br>
        <h2 id="titleInicioSesion">Visitas al Departamento D.O.B.E</h2>
        <br>
        <div class="container_8">

            <label for="nombre">Nombres y Apellidos:  </label>
            <asp:TextBox ID="Nombres" name="mombre" CssClass=" form-control " runat="server" Enabled="false" Width="500" required></asp:TextBox>&nbsp;<br><br>
            <label for="titulo">Título:  </label>
            <asp:TextBox ID="Titulo" CssClass="form-control " name="titulo" Width="500" placeholder="Titulo para Identificarla Visita" runat="server" required></asp:TextBox>&nbsp;<br><br>
            <label for="motivo">Motivo de la visita:  </label>
            <asp:DropDownList ID="motivo" runat="server" CssClass="form-control " DataSourceID="motivoDS" DataTextField="desc_razon_visita" DataValueField="cod_razon_visita"></asp:DropDownList>
            <asp:SqlDataSource ID="motivoDS" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT [cod_razon_visita], [desc_razon_visita] FROM [razon_visita]"></asp:SqlDataSource>
            <br />
            <p>Si su motivo no se refleja en el listado, puede registrar uno haciendo click <a href="javascript:abrirVentana('../maestras/razon_visita')">aquí</a></p>
            <br />
            <label for="fecha">Fecha de la Visita:  </label>
            <input type="date" id="fecha" name="fecha" runat="server" />
            <br><br>
            <asp:Label ID="Mensaje" runat="server" Text="" Font-Size="20px" ForeColor="Red"></asp:Label><br />
            <asp:Button ID="btnEnviar" runat="server" Text="Registrar" CssClass="form-control acceder" OnClick="btnEnviar_Click" />

            &nbsp;<asp:Label ID="Error4" runat="server" Text="" ForeColor="Red" CssClass="UserMessage"></asp:Label>

        </div>

    </div>
    <script>
        changeCurrent('visitaLink');
    </script>
</asp:Content>

