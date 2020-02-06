<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/estudiantes_mod/estudiantesMod.master" AutoEventWireup="true" CodeFile="protocolo.aspx.cs" Inherits="vistas_estudiantes_mod_reposo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <br />
    <h2 class="title-seccion">Protocolo</h2>
    <br />
    <div class="grid">
        <asp:GridView ID="reposo" runat="server" CellPadding="2" CellSpacing="5" Width="100%" EmptyDataText="La busqueda no arrojo resltado." AllowPaging="True" PageSize="20" AutoGenerateColumns="false" DataKeyNames="ID" OnDataBound="reposo_DataBound" OnPageIndexChanging="reposo_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" Visible="False" />
                <asp:TemplateField HeaderText="Foto Carnet" ControlStyle-Width="10em">
                    <ItemTemplate>
                        <asp:HiddenField ID="hiddenReposo" runat="server" Value='<%# Eval("documento")%>' />
                        <asp:HyperLink ID="ImageReposo" NavigateUrl='<%# Bind( "documento") %>' Text="Ver" runat="server" Target="_blank" />
                        <asp:FileUpload ID="FileReposo" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Talla Camisa">
                    <ItemTemplate>
                        <asp:TextBox ID="txtCamisa" runat="server" Text='<%# Eval("camisa")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Talla Pantalon">
                    <ItemTemplate>
                        <asp:TextBox ID="txtPantalon" runat="server" Text='<%# Eval("pantalon")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Talla Zapato">
                    <ItemTemplate>
                        <asp:TextBox ID="txtZapato" runat="server" Text='<%# Eval("zapato")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Telefono">
                    <ItemTemplate>
                        <asp:TextBox ID="txtTelefono" runat="server" Text='<%# Eval("telefono")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Direccion">
                    <ItemTemplate>
                        <asp:TextBox ID="txtDireccion" runat="server" Text='<%# Eval("direccion")%>' />
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

