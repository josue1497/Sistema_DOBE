<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reposos.aspx.cs" Inherits="reposos" MasterPageFile="~/vistas/forms/FormMasterPage.master" %>

<asp:Content runat="server" ID="ReposoContent" ContentPlaceHolderID="MainContent">
    <form id="reposo_form" runat="server">
        <div>
            <br />
            <h3 class="h3-forms" id="title">Solicitud de Reposo</h3>
            <br />
            <asp:Label ID="DatosPersonales" runat="server" Text="Estudiante: "></asp:Label>
            <asp:TextBox ID="NombreyApellido" runat="server" Enabled="false" CssClass="textBox-medium"></asp:TextBox><br />

            <asp:Label ID="FechaInicioLabel" runat="server" Text="Fecha Inicio del Reposo: "></asp:Label>
            <input type="date" name="fechaInicio" id="fechaInicio" runat="server" />
            <asp:Label ID="error1" runat="server" Text="" ForeColor="Red"></asp:Label><br />

            <asp:Label ID="FechaFinLabel" runat="server" Text="Fecha Final del Reposo: "></asp:Label>
            <input type="date" name="fechaFin" id="fechaFin" runat="server" />
            <asp:Label ID="error2" runat="server" Text="" ForeColor="Red"></asp:Label><br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Patología: "></asp:Label>
            <asp:TextBox ID="patologia" runat="server" CssClass="textBox-short" required></asp:TextBox><br />

            <asp:Label ID="ReposoDoc" runat="server" Text="Reposo: "></asp:Label>
            <asp:FileUpload ID="reposoFile" runat="server" accept="image/jpeg,image/png,application/pdf,application/vnd.ms-excel" />
            <asp:Label ID="error3" runat="server" Text="" ForeColor="Red"></asp:Label>
            <br />

            <asp:Label ID="MedicoLabel" runat="server" Text="Doctor: "></asp:Label>
            <asp:DropDownList ID="medicoList" runat="server" DataSourceID="medico" DataTextField="nombre" DataValueField="prima">
                <asp:ListItem Value="0" Text="Medico"></asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="medico" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="select prima_medico as prima ,nombre_medico+' '+apellido_medico as nombre from medico;"></asp:SqlDataSource>
            <a href="javascript:window.open('registrarMedicos.aspx','','width=400,height=600')" style="color: green;">Añadir Medico</a>
            <asp:Label ID="error4" runat="server" Text="" ForeColor="Red"></asp:Label>
            <br />

            <asp:Label ID="periodoLabel" runat="server" Text="Periodo Academico: "></asp:Label>
            <asp:TextBox ID="periodo" runat="server" Enabled="false" CssClass="textBox-short"></asp:TextBox><br />

            <asp:Label ID="TipoReposoLabel" runat="server" Text="Tipo de Reposo: "></asp:Label>
            <asp:DropDownList ID="TipoReposo" runat="server" DataSourceID="tipo_reposo" DataTextField="tipo_reposo" DataValueField="cod_tipo_reposo">
                <asp:ListItem Value="0">Tipo Reposo</asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="tipo_reposo" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT [cod_tipo_reposo], [tipo_reposo] FROM [tipo_reposo]"></asp:SqlDataSource>
            <br />

            <asp:Label ID="EstatusReposoLabel" runat="server" Text="Estado: "></asp:Label>
            <asp:DropDownList ID="estatusReposo" runat="server" CssClass="textBox-short"></asp:DropDownList><br />

            <asp:Label ID="Mensaje" runat="server" Text="" Font-Size="20px"></asp:Label><br />
            <br />

            <asp:Button ID="enviar" runat="server" Text="Enviar" OnClick="enviarBtn_click" CssClass="button" />


        </div>
    </form>
</asp:Content>
