<%@ Page Language="C#" AutoEventWireup="true" CodeFile="modificar_usuarios.aspx.cs" Inherits="vistas_forms_modificar_usuarios" MasterPageFile="~/vistas/tablas/Tables.master" %>

<asp:Content runat="server" ID="UsuariosContent" ContentPlaceHolderID="MainContent">
    <br />
    <h2 class="title-seccion">Usuarios</h2><br />
    <div class="data-tables-query">
        <div class="data">
            <label>Tipo de Usuario  </label>
             <asp:DropDownList ID="tipo_usuario" runat="server" DataSourceID="tipoDS" DataTextField="tipo_us" DataValueField="tipo_us"></asp:DropDownList>
            <asp:SqlDataSource ID="tipoDS" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="select DISTINCT(tipo_us) from dbo.usuarios;"></asp:SqlDataSource>
            <label>Estatus  </label>
            <asp:DropDownList ID="estatus_usuario" runat="server" DataSourceID="estatusDS" DataTextField="estatus" DataValueField="estatus"></asp:DropDownList>
            <asp:SqlDataSource ID="estatusDS" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="select DISTINCT(estatus) from dbo.usuarios;"></asp:SqlDataSource>
            <asp:Button ID="buscar" runat="server" Text="Buscar" OnClick="buscar_Click" />
            <br />
            <br />
            <br />
        </div>
        <div class="grid">
            <asp:GridView ID="result_reposos" runat="server" CellPadding="2" Width="100%" GridLines="None" AllowPaging="True" PageSize="20" AutoGenerateColumns="False" DataKeyNames="ID" CellSpacing="3" OnPageIndexChanging="result_reposos_PageIndexChanging" EmptyDataText="La busqueda no obtuvo resultados." OnDataBound="result_reposos_DataBound">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" Visible="False" />
                    <asp:BoundField DataField="ci" HeaderText="CI.:" SortExpression="CI.:" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="Nombre" />
                    <asp:BoundField DataField="apellido" HeaderText="Apellido" SortExpression="Apellido" />
                    <asp:TemplateField HeaderText="Teléfono">
                        <ItemTemplate>
                            <asp:TextBox ID="telefono" Text='<%# Eval("telefono")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="edad" HeaderText="Edad" SortExpression="Edad" />
                    <asp:BoundField DataField="genero" HeaderText="Género" SortExpression="Genero" />
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:TextBox ID="email" Text='<%# Eval("email")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Usuario">
                        <ItemTemplate>
                            <asp:TextBox ID="us" Text='<%# Eval("us")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Contraseña">
                        <ItemTemplate>
                            <asp:HiddenField ID="hpass" Value='<%# Eval("pass")%>' runat="server" />
                            <asp:TextBox ID="pass" TextMode="Password" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tipo Usuario">
                        <ItemTemplate>
                             <asp:HiddenField ID="htipous" Value='<%# Eval("tipo_us")%>' runat="server" />
                            <asp:DropDownList ID="tipoUsuario" runat="server" DataSourceID="TipoUsDS" DataTextField="tipo_us" DataValueField="tipo_us" ></asp:DropDownList>
                            <asp:SqlDataSource ID="TipoUsDS" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="select DISTINCT(tipo_us) from dbo.usuarios;"></asp:SqlDataSource>
                            </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Estatus">
                        <ItemTemplate>
                            <asp:DropDownList ID="estatus" runat="server" DataSourceID="EstatusDS" DataTextField="estatus" DataValueField="estatus"></asp:DropDownList>
                            <asp:SqlDataSource ID="EstatusDS" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="select DISTINCT(estatus) from dbo.usuarios;"></asp:SqlDataSource>
                            </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="buttonTable" ID="BtnEditar" runat="server" Text="Editar  " OnClick="BtnEditar_Click" ToolTip="Permite editar el registro actual"></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle ForeColor="Black"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="buttonTable" ID="BtnEliminar" runat="server" Text="  Eliminar" OnClick="BtnEliminar_Click" ToolTip="Permite editar el registro actual"></asp:LinkButton>
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

        <br />
    </div>

</asp:Content>
