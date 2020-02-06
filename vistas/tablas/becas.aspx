<%@ Page Language="C#" AutoEventWireup="true" CodeFile="becas.aspx.cs" Inherits="vistas_forms_becas" MasterPageFile="~/vistas/tablas/Tables.master" %>

<asp:Content runat="server" ID="BecasContent" ContentPlaceHolderID="MainContent">
    <br />
    <h2 class="title-seccion">Becas Solicitadas</h2><br />
    <div class="data-tables-query">
        <div class="data">
            <label>Tipo de Beca:  </label>
            <asp:DropDownList ID="dTipoBeca" runat="server" DataSourceID="tipoBecaDS" DataTextField="tipo_beca" DataValueField="cod_tipo_beca"></asp:DropDownList>
            <asp:SqlDataSource ID="tipoBecaDS" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT [cod_tipo_beca], [tipo_beca] FROM [tipo_beca]"></asp:SqlDataSource>
            <label>Estatus:  </label>
            <asp:DropDownList ID="estatus" runat="server"></asp:DropDownList>

             <label>Cedula:  </label>
            <asp:TextBox ID="txtCedula" runat="server"></asp:TextBox>

            <asp:Button ID="buscar" runat="server" Text="Buscar" OnClick="buscar_Click" />
            <br />
            <br />
            <br />
        </div>
        <div class="grid">
            <asp:GridView ID="result_reposos" runat="server" CellPadding="2" CellSpacing="3" Width="100%" AllowPaging="True" PageSize="20" AutoGenerateColumns="false" DataKeyNames="ID" OnPageIndexChanging="result_reposos_PageIndexChanging" OnDataBound="result_reposos_DataBound" EmptyDataText="La busqueda no obtuvo resultados." >
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" Visible="False" />
                    <asp:BoundField DataField="cod_beca" HeaderText="Codigo" SortExpression="Codigo" />
                    <asp:BoundField DataField="CI" HeaderText="C.I.:" SortExpression="C.I.:" />
                    <asp:BoundField DataField="Alumno" HeaderText="Alumno" SortExpression="Alumno" />
                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
                    <asp:BoundField DataField="iraa" HeaderText="I.R.A.A.:" SortExpression="I.R.A.A.:" />
                     <asp:TemplateField HeaderText="Solicitud" Visible="False">
                            <ItemTemplate>
                                <asp:HyperLink ID="Documento" NavigateUrl='<%# Bind( "Documento") %>' Text="Click Aqui." runat="server" Target="_blank"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Carta Compromiso" Visible="False">
                            <ItemTemplate>
                                <asp:HyperLink ID="compromiso" NavigateUrl='<%# Bind( "compromiso") %>' Text="Click Aqui." runat="server" Target="_blank"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Foto Carnet" Visible="False">
                            <ItemTemplate>
                                <asp:HyperLink ID="foto" NavigateUrl='<%# Bind( "foto") %>' Text="Click Aqui." runat="server" Target="_blank"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Notas" Visible="False">
                            <ItemTemplate>
                                <asp:HyperLink ID="notas" NavigateUrl='<%# Bind( "notas") %>' Text="Click Aqui." runat="server" Target="_blank"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Socio-Economico" Visible="False">
                            <ItemTemplate>
                                <asp:HyperLink ID="economico" NavigateUrl='<%# Bind( "economico") %>' Text="Click Aqui." runat="server" Target="_blank"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Constancia Trabajo" Visible="False">
                            <ItemTemplate>
                                <asp:HyperLink ID="trabajo" NavigateUrl='<%# Bind( "trabajo") %>' Text="Click Aqui." runat="server" Target="_blank"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                     <asp:TemplateField HeaderText="Constancia Defuncion Padre/Madre" Visible="False">
                            <ItemTemplate>
                                <asp:HyperLink ID="defuncion" NavigateUrl='<%# Bind( "defuncion") %>' Text="Click Aqui." runat="server" Target="_blank"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                     <asp:TemplateField HeaderText="Residencia" Visible="False">
                            <ItemTemplate>
                                <asp:HyperLink ID="residencia" NavigateUrl='<%# Bind( "residencia") %>' Text="Click Aqui." runat="server" Target="_blank"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                     <asp:TemplateField HeaderText="Acta Matrimonio" Visible="False">
                            <ItemTemplate>
                                <asp:HyperLink ID="matrimonio" NavigateUrl='<%# Bind( "matrimonio") %>' Text="Click Aqui." runat="server" Target="_blank"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                     <asp:TemplateField HeaderText="Partida Nacimiento Hijo" Visible="False">
                            <ItemTemplate>
                                <asp:HyperLink ID="nacimiento" NavigateUrl='<%# Bind( "nacimiento") %>' Text="Click Aqui." runat="server" Target="_blank"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                     <asp:TemplateField HeaderText="I.S.R.L" Visible="False">
                            <ItemTemplate>
                                <asp:HyperLink ID="isrlSol" NavigateUrl='<%# Bind( "isrlSol") %>' Text="Click Aqui." runat="server" Target="_blank"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                     <asp:TemplateField HeaderText="I.S.L.R Conyugue" Visible="False">
                            <ItemTemplate>
                                <asp:HyperLink ID="isrlCon" NavigateUrl='<%# Bind( "isrlCon") %>' Text="Click Aqui." runat="server" Target="_blank"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vivienda" Visible="False">
                            <ItemTemplate>
                                <asp:HyperLink ID="vivienda" NavigateUrl='<%# Bind( "vivienda") %>' Text="Click Aqui." runat="server" Target="_blank"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Comentarios">
                        <ItemTemplate>
                            <asp:TextBox ID="txtComentarios" runat="server" TextMode="MultiLine" Text='<%# Eval("observacion")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estatus">
                        <ItemTemplate>
                             <asp:HiddenField ID="cod_beca_h" runat="server" Value='<%# Eval("cod_beca")%>' />
                             <asp:HiddenField ID="hiddenStatus" runat="server" Value='<%# Eval("cod")%>'/>
                            <asp:DropDownList ID="modSolicitud" runat="server" DataSourceID="ModSolDS" DataTextField="estatus" DataValueField="cod_estatus"></asp:DropDownList>
                            <asp:SqlDataSource ID="ModSolDS" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT [cod_estatus], [estatus] FROM [estatus_solicitud]"></asp:SqlDataSource>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-ForeColor="Black" HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="buttonTable" ID="BtnVerDocumentos" runat="server" Text="Ver Documentos" OnClick="BtnVerDocumentos_Click" ToolTip="Permite ver documentos cargados al registro actual"></asp:LinkButton>
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
                <HeaderStyle BackColor="#FF6600" />
                <RowStyle BorderStyle="Solid" BorderWidth="2px" />
            </asp:GridView>
            <br />
            <asp:Label ID="Mensaje" runat="server" Text="" Font-Size="20px"></asp:Label><br />
            <br />
        </div>


        <br />
        <script>
            changeCurrent('linkBeca');
        </script>
    </div>

</asp:Content>
