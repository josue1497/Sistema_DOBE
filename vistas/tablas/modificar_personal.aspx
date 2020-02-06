<%@ Page Language="C#" AutoEventWireup="true" CodeFile="modificar_personal.aspx.cs" Inherits="vistas_forms_modificar_usuarios" MasterPageFile="~/vistas/tablas/Tables.master" %>

<asp:Content runat="server" ID="UsuariosContent" ContentPlaceHolderID="MainContent">
    <br />
    <h2 class="title-seccion">Personal</h2>
    <br />
    <div class="data-tables-query">
        <div class="data">
            <label>Cédula:  </label>
            <asp:TextBox ID="txtCedula" runat="server"></asp:TextBox>
            <asp:Button ID="buscar" runat="server" Text="Buscar" OnClick="buscar_Click" />
            <br />
            <br />
        </div>
        <div class="grid">
            <asp:GridView ID="result_reposos" runat="server" CellPadding="2" Width="100%" GridLines="None" AllowPaging="True" PageSize="20" AutoGenerateColumns="False" DataKeyNames="ID" CellSpacing="3" OnPageIndexChanging="result_reposos_PageIndexChanging" EmptyDataText="La busqueda no obtuvo resultados." OnDataBound="result_reposos_DataBound">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" Visible="False" />
                    <asp:TemplateField HeaderText="Usuario">
                        <ItemTemplate>
                            <asp:TextBox ID="us" Text='<%# Eval("ci")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Contraseña">
                        <ItemTemplate>
                            <asp:HiddenField ID="hpass" Value='<%# Eval("pass")%>' runat="server" />
                            <asp:TextBox ID="pass" TextMode="Password" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombres">
                        <ItemTemplate>
                            <asp:TextBox ID="nombre" runat="server" Text='<%# Eval("nombre")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Apellidos">
                        <ItemTemplate>
                            <asp:TextBox ID="apellido" Text='<%# Eval("apellido")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dirección">
                        <ItemTemplate>
                            <asp:TextBox ID="direccion" TextMode="MultiLine" Text='<%# Eval("direccion")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cargo">
                        <ItemTemplate>
                            <asp:HiddenField ID="hCargo" Value='<%# Eval("cargo")%>' runat="server" />
                            <asp:DropDownList ID="dCargo" runat="server" DataSourceID="cargods" DataTextField="desc_cargo" DataValueField="cod_cargo"></asp:DropDownList>
                            <asp:SqlDataSource ID="cargods" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT [cod_cargo], [desc_cargo] FROM [cargo]"></asp:SqlDataSource>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Teléfono">
                        <ItemTemplate>
                            <asp:TextBox ID="telefono" Text='<%# Eval("telefono")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Género">
                        <ItemTemplate>
                            <asp:HiddenField ID="hgenero" Value='<%# Eval("sexo")%>' runat="server" />
                            <asp:DropDownList ID="dGenero" runat="server" DataSourceID="sexods" DataTextField="genero" DataValueField="cod_sexo"></asp:DropDownList>
                            <asp:SqlDataSource ID="sexods" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT [cod_sexo], [genero] FROM [sexo]"></asp:SqlDataSource>
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
