<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/estudiantes_mod/estudiantesMod.master" AutoEventWireup="true" CodeFile="materialDeportivo.aspx.cs" Inherits="vistas_estudiantes_mod_materialDeportivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <br />
    <h2 class="title-seccion">Material Deportivo</h2><br />
    <div class="grid">
        <asp:GridView ID="materialDep" runat="server" CellPadding="2" CellSpacing="5" Width="100%" EmptyDataText="La busqueda no arrojo resltado." AllowPaging="True" PageSize="20" AutoGenerateColumns="false" DataKeyNames="ID" OnDataBound="materialDep_DataBound" OnPageIndexChanging="materialDep_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" Visible="False" />
                <asp:TemplateField HeaderText="Articulo">
                    <ItemTemplate>
                        <asp:HiddenField ID="hiddenArticulo" runat="server" Value='<%# Eval("articulo")%>' />
                        <asp:DropDownList ID="modArticulo" runat="server" DataSourceID="ArticuloDS" DataTextField="art_deportivo" DataValueField="cod_tipo_art_deportivo"></asp:DropDownList>
                        <asp:SqlDataSource ID="ArticuloDS" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT [cod_tipo_art_deportivo], [art_deportivo] FROM [tipo_art_deportivo]"></asp:SqlDataSource>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tiempo de Prestamo (Horas)">
                    <ItemTemplate>
                        <asp:TextBox ID="TxtTiempo" runat="server" Text='<%# Eval("tiempo")%>' type="number"/>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Cantidad">
                    <ItemTemplate>
                        <asp:TextBox ID="TxtCantidad" runat="server" Text='<%# Eval("cantidad")%>' type="number"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha de Reservacion">
                    <ItemTemplate>
                        <asp:HiddenField ID="hiddenFecha" runat="server" Value='<%# Eval("fecha")%>' />
                        <asp:TextBox ID="TxtFecha" runat="server"  type="date"/>
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

