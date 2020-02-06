<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/tablas/Tables.master" AutoEventWireup="true" CodeFile="filtrarProtocolo.aspx.cs" Inherits="vistas_tablas_reposos" %>

<asp:Content ID="reposos_Tables" ContentPlaceHolderID="MainContent" runat="Server">
    <br />
    
    <h2 class="title-seccion">Solicitud de Afiliación al Protocolo</h2><br />
    <div class="data-tables-query">
        <div class="data">
           
            <label>Cédula:  </label>
            <input type="text" id="txtCedula" runat="server" />
            
            <label>Estatus  </label>
            <asp:DropDownList ID="estatus" runat="server"></asp:DropDownList>

            <asp:Button ID="buscar" runat="server" Text="Buscar" OnClick="buscar_Click" />
            <br />
            <br />
        </div>
        <div class="grid">
            <asp:GridView ID="result_reposos" runat="server" CellPadding="2" CellSpacing="3" Width="100%" GridLines="None" AllowPaging="True" PageSize="20" AutoGenerateColumns="False" DataKeyNames="ID" OnDataBound="result_reposos_DataBound" OnPageIndexChanging="result_reposos_PageIndexChanging" EmptyDataText="La busqueda no obtuvo resultados.">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" Visible="False" />
                     <asp:BoundField DataField="cedula" HeaderText="C.I.:" SortExpression="C.I.:" />
                    <asp:BoundField DataField="Alumno" HeaderText="Alumno" SortExpression="Alumno" />
                    <asp:TemplateField HeaderText="Foto Carnet">
                        <ItemTemplate>
                            <asp:HyperLink ID="foto" NavigateUrl='<%# Bind( "foto") %>' Text="Ver Aquí" runat="server" Target="_blank" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="camisa" HeaderText="Talla Camisa" SortExpression="Camisa" />
                    <asp:BoundField DataField="pantalon" HeaderText="Talla Pantalon" SortExpression="Talla Pantalon" />
                    <asp:BoundField DataField="zapato" HeaderText="Talla Zapatos" SortExpression="Talla Zapatos" />
                    <asp:BoundField DataField="direccion" HeaderText="Dirección" SortExpression="Direccion" />
                    <asp:BoundField DataField="telefono" HeaderText="Teléfono" SortExpression="Telefono" />
                    <asp:TemplateField HeaderText="Estatus">
                        <ItemTemplate>
                            <asp:DropDownList ID="modSolicitud" runat="server" DataSourceID="ModSolDS" DataTextField="estatus" DataValueField="cod_estatus"></asp:DropDownList>
                            <asp:SqlDataSource ID="ModSolDS" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT [cod_estatus], [estatus] FROM [estatus_solicitud]"></asp:SqlDataSource>
                            <asp:HiddenField ID="hiddenStatus" runat="server" Value='<%# Eval("cod")%>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="buttonTable" ID="BtnEditar" runat="server" Text="Actualizar" OnClick="BtnEditar_Click" ToolTip="Permite editar el registro actual"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle BackColor="#FF6600" BorderColor="Black" />
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

