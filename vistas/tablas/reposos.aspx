<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/tablas/Tables.master" AutoEventWireup="true" CodeFile="reposos.aspx.cs" Inherits="vistas_tablas_reposos" %>

<asp:Content ID="reposos_Tables" ContentPlaceHolderID="MainContent" runat="Server">
    <br />
    
    <h2 class="title-seccion">Reposos Solicitados</h2><br />
    <div class="data-tables-query">
        <div class="data">
            <label>Tipo de Reposo  </label>
            <select id="tipoReposo" runat="server">
                <option value=""></option>
            </select>
            <label>Fecha Inicial  </label>
            <input type="date" id="fechaIni" runat="server" />
            <label>Fecha Fin  </label>
            <input type="date" id="FechaFin" runat="server" />
            <label>Estatus  </label>
            <asp:DropDownList ID="estatus" runat="server"></asp:DropDownList>

            <asp:Button ID="buscar" runat="server" Text="Buscar" OnClick="buscar_Click" />
            <br />
            <br />
            <br />
        </div>
        <div class="grid">
            <asp:GridView ID="result_reposos" runat="server" CellPadding="2" CellSpacing="3" Width="100%" GridLines="None" AllowPaging="True" PageSize="20" AutoGenerateColumns="False" DataKeyNames="ID" OnDataBound="result_reposos_DataBound" OnPageIndexChanging="result_reposos_PageIndexChanging" EmptyDataText="La busqueda no obtuvo resultados.">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" Visible="False" />
                    <asp:BoundField DataField="idAl" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" Visible="False" />
                    <asp:BoundField DataField="Alumno" HeaderText="Alumno" SortExpression="Alumno" />
                    <asp:TemplateField HeaderText="Documento">
                        <ItemTemplate>
                            <asp:HyperLink ID="Documento" NavigateUrl='<%# Bind( "Documento") %>' Text="Abrir en una Nueva Ventana" runat="server" Target="_blank" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Medico" HeaderText="Médico" SortExpression="Medico" />
                    <asp:BoundField DataField="patologia" HeaderText="Patología" SortExpression="Patologia" />
                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
                    <asp:TemplateField HeaderText="Estatus">
                        <ItemTemplate>
                            <asp:DropDownList ID="modSolicitud" runat="server" DataSourceID="ModSolDS" DataTextField="estatus" DataValueField="cod_estatus"></asp:DropDownList>
                            <asp:SqlDataSource ID="ModSolDS" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT [cod_estatus], [estatus] FROM [estatus_solicitud]"></asp:SqlDataSource>
                            <asp:HiddenField ID="hiddenStatus" runat="server" Value='<%# Eval("cod")%>'/>
                            <asp:HiddenField ID="idAl" runat="server" Value='<%# Eval("idAl")%>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="buttonTable" ID="btnIncorporar" runat="server" Text="Incorporar" OnClick="btnIncorporar_Click" ToolTip="Permite editar el registro actual"></asp:LinkButton>
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
        <script>changeCurrent('linkReposos');</script>
        <br />
    </div>




</asp:Content>

