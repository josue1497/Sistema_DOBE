<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/tablas/Tables.master" AutoEventWireup="true" CodeFile="filtrarCitas_docente.aspx.cs" Inherits="vistas_tablas_filtrarSolicitudes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <br />
    <h2 class="title-seccion">Citas</h2>
    <br />
    <div class="data-tables-query">
        <div class="data">
            <label>Solicitud  </label>
            <select id="SolicitudAFiltrar" runat="server">
                <option value="0">Citas</option>
                <option value="dbo.solicitud_cita_odontologo">Cita al Odontólogo</option>
                <option value="dbo.solicitud_cita_psicologo">Cita al Psicólogo</option>
            </select>
            <label>Cedula  </label>
            <input type="text" id="cedulaEstudiante" runat="server" />
            <label>Estatus  </label>
            <asp:DropDownList ID="estatus" runat="server"></asp:DropDownList>

            <asp:Button ID="buscar" runat="server" Text="Buscar" OnClick="buscar_Click" />
            <br />
            <br />
            <br />
        </div>
        <div class="grid">
            <asp:GridView ID="result_reposos" runat="server" CellPadding="2" CellSpacing="5" Width="100%" AllowPaging="True" PageSize="20" AutoGenerateColumns="false" DataKeyNames="ID" OnDataBound="result_reposos_DataBound" OnPageIndexChanging="result_reposos_PageIndexChanging" EmptyDataText="La busqueda no obtuvo resultados.">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" Visible="False" />
                    <asp:BoundField DataField="cedula" HeaderText="C.I.:" SortExpression="Tipo" />
                    <asp:BoundField DataField="Alumno" HeaderText="Alumno" SortExpression="Alumno" />
                    <asp:BoundField DataField="email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="direccion" HeaderText="Direccion" SortExpression="Direccion" />
                    <asp:BoundField DataField="motivo" HeaderText="Motivo" SortExpression="motivo" />
                    <asp:TemplateField HeaderText="Indicaciones">
                        <ItemTemplate>
                            <asp:TextBox ID="txtIndicaciones" runat="server" TextMode="MultiLine" Text='<%# Eval("observacion")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-ForeColor="Black" HeaderText="">
                        <ItemTemplate>
                            <asp:HiddenField ID="hiddenStatus" runat="server" Value='<%# Eval("cod")%>' />
                            <asp:DropDownList ID="modSolicitud" runat="server" DataSourceID="ModSolDS" DataTextField="estatus" DataValueField="cod_estatus"></asp:DropDownList>
                            <asp:SqlDataSource ID="ModSolDS" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT [cod_estatus], [estatus] FROM [estatus_solicitud]"></asp:SqlDataSource>
                        </ItemTemplate>
                        <HeaderStyle ForeColor="Black"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-ForeColor="Black" HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="buttonTable" ID="BtnEditar" runat="server" Text="Actualizar" OnClick="BtnEditar_Click" ToolTip="Permite editar el registro actual"></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle ForeColor="Black"></HeaderStyle>
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
    </div>

</asp:Content>

