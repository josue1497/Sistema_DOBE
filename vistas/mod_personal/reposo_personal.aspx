<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/mod_personal/estudiantesMod.master" AutoEventWireup="true" CodeFile="reposo_personal.aspx.cs" Inherits="vistas_estudiantes_mod_reposo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <br />
    <h2 class="title-seccion">Reposos</h2><br />
    <div class="grid">
        <asp:GridView ID="reposo" runat="server" CellPadding="2" CellSpacing="5" Width="100%" EmptyDataText="La busqueda no arrojo resltado." AllowPaging="True" PageSize="20" AutoGenerateColumns="false" DataKeyNames="ID" OnDataBound="reposo_DataBound" OnPageIndexChanging="reposo_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" Visible="False" />
                <asp:TemplateField HeaderText="Tipo Reposo">
                    <ItemTemplate>
                        <asp:HiddenField ID="hiddenArticulo" runat="server" Value='<%# Eval("tipo")%>' />
                        <asp:DropDownList ID="modArticulo" runat="server" DataSourceID="ArticuloDS" DataTextField="tipo_reposo" DataValueField="cod_tipo_reposo"></asp:DropDownList>
                        <asp:SqlDataSource ID="ArticuloDS" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT [cod_tipo_reposo], [tipo_reposo] FROM [tipo_reposo]"></asp:SqlDataSource>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Documento" ControlStyle-Width="10em">
                    <ItemTemplate>
                        <asp:HiddenField ID="hiddenReposo" runat="server" Value='<%# Eval("documento")%>' />
                        <asp:HyperLink ID="ImageReposo" NavigateUrl='<%# Bind( "documento") %>' Text="Ver" runat="server" Target="_blank" />
                        <asp:FileUpload ID="FileReposo" runat="server" />
                    </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="Médico">
                    <itemtemplate>
                          <asp:HiddenField ID="hiddenMedico" runat="server" Value='<%# Eval("medico")%>' />
                        <asp:DropDownList ID="ListMedico" runat="server" DataSourceID="MedicoDS" DataTextField="Nombre" DataValueField="prima"></asp:DropDownList>
                        <asp:SqlDataSource ID="MedicoDS" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="select prima_medico prima, nombre_medico+' '+apellido_medico as Nombre  from dbo.medico ;"></asp:SqlDataSource>
                    </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Patología">
                    <ItemTemplate>
                        <asp:TextBox ID="TxtPatologia" runat="server" Text='<%# Eval("patologia")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha de Inicio">
                    <ItemTemplate>
                        <asp:HiddenField ID="hiddenFechaInicio" runat="server" Value='<%# Eval("FI")%>' />
                        <asp:TextBox ID="TxtFechaI" runat="server" type="date" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha de Culminación">
                    <ItemTemplate>
                        <asp:HiddenField ID="hiddenFechaFin" runat="server" Value='<%# Eval("FF")%>' />
                        <asp:TextBox ID="TxtFechaF" runat="server" type="date" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Estatus">
                    <ItemTemplate>
                        <asp:HiddenField ID="hiddenStatus" runat="server" Value='<%# Eval("estatus")%>' />
                        <asp:DropDownList ID="modSolicitud" runat="server" DataSourceID="dsEstatus" DataTextField="estatus" DataValueField="cod_estatus"></asp:DropDownList>
                        <asp:SqlDataSource ID="dsEstatus" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT [cod_estatus], [estatus] FROM [estatus_solicitud]"></asp:SqlDataSource>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-ForeColor="Black" HeaderText="">
                    <ItemTemplate>
                        <asp:LinkButton CssClass="buttonTable" ID="BtnEditar" runat="server" Text="Actualizar" OnClick="BtnEditar_Click" ToolTip="Permite editar el registro actual" OnClientClick='return confirm("¿Desea actualizar está entrda?");'></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-ForeColor="Black" HeaderText="">
                    <ItemTemplate>
                        <asp:LinkButton CssClass="buttonTable" ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" ValidationGroup="GroupName" OnClientClick='return confirm("¿Desea eliminar está entrda?");'></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="#FF6600" />
            <RowStyle BorderStyle="Solid" BorderWidth="2px" />
        </asp:GridView>
        <br />
        <asp:Label ID="Mensaje" runat="server" Text="" Font-Size="20px"></asp:Label><br />
        <br />
    </div>
    <br />
</asp:Content>

