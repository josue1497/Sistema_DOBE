<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/estudiantes_mod/estudiantesMod.master" AutoEventWireup="true" CodeFile="coralbanda.aspx.cs" Inherits="vistas_estudiantes_mod_coralbanda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
   
    <br />
    <h2 class="title-seccion">Coral o Banda</h2><br />
    <div class="grid">
        <asp:GridView ID="coralBanda" runat="server" CellPadding="2" CellSpacing="5" Width="100%" EmptyDataText="La busqueda no arrojo resltado." AllowPaging="True" PageSize="20" AutoGenerateColumns="false" DataKeyNames="ID" OnDataBound="coralBanda_DataBound" OnPageIndexChanging="coralBanda_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" Visible="False" />
                <asp:TemplateField HeaderText="Tipo">
                    <ItemTemplate>
                        <asp:HiddenField ID="hiddenTipo" runat="server" Value='<%# Eval("tipo")%>' />
                        <asp:DropDownList ID="modTipo" runat="server" DataSourceID="SqlDataSource1" DataTextField="coral_banda" DataValueField="cod_tipo_coral_banda"></asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT [cod_tipo_coral_banda], [coral_banda] FROM [tipo_coral_banda]"></asp:SqlDataSource>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Motivo">
                    <ItemTemplate>
                        <asp:TextBox ID="TxtMotivo" runat="server" Text='<%# Eval("motivo")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Estatus">
                    <ItemTemplate>
                        <asp:HiddenField ID="hiddenStatus" runat="server" Value='<%# Eval("estatus")%>' />
                        <asp:DropDownList ID="modSolicitud" runat="server" DataSourceID="dsEstatus" DataTextField="estatus" DataValueField="cod_estatus"></asp:DropDownList>
                        <asp:SqlDataSource ID="dsEstatus" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT [cod_estatus], [estatus] FROM [estatus_solicitud]"></asp:SqlDataSource>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="fecha" HeaderText="Fecha" SortExpression="fecha" />
                <asp:TemplateField HeaderStyle-ForeColor="Black" HeaderText="">
                    <ItemTemplate>
                        <asp:LinkButton CssClass="buttonTable" ID="BtnEditar" runat="server" Text="Actualizar" OnClick="BtnEditar_Click" ToolTip="Permite editar el registro actual" OnClientClick='return confirm("¿Desea actualizar está entrda?");'></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle ForeColor="Black"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-ForeColor="Black" HeaderText="">
                    <ItemTemplate>
                        <asp:LinkButton CssClass="buttonTable" ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click"  ValidationGroup="GroupName" OnClientClick='return confirm("¿Desea eliminar está entrda?");'></asp:LinkButton>
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

