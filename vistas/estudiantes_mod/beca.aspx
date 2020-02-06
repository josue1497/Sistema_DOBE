<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/estudiantes_mod/estudiantesMod.master" AutoEventWireup="true" CodeFile="beca.aspx.cs" Inherits="vistas_estudiantes_mod_beca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <br />
    <h2 class="title-seccion">Becas Solicitadas</h2>
    <br />

    <style>
        .contenedorgrid {
            width: 100%;
            overflow-x: scroll;
        }

        .grid-beca {
            margin: 0 !important;
        }

        .gridFile {
            visibility: hidden;
            width: 0;
            position: relative;
        }

            .gridFile::before {
                content: 'Cambiar Imagen';
                display: inline-block;
                border: 1px solid #000;
                border-radius: 3px;
                padding: 0px 4px;
                outline: none;
                white-space: nowrap;
                cursor: pointer;
                font-weight: 700;
                font-size: 10pt;
                visibility: visible;
                position: absolute;
                margin: 2px;
                background: white;
                color: black;
            }

            .gridFile:hover::before {
                content: 'Cambiar Imagen';
                display: inline-block;
                border: 2px solid #000;
                border-radius: 3px;
                padding: 0px 4px;
                outline: none;
                white-space: nowrap;
                cursor: pointer;
                font-weight: 700;
                font-size: 10pt;
                visibility: visible;
                position: absolute;
                margin: 2px;
                background: #a2a0a0;
                transition: 0.5s;
                color: black;
            }

            .gridFile:disabled::before {
                content: 'Cambiar Imagen';
                display: inline-block;
                border: 2px solid lightgray;
                border-radius: 3px;
                padding: 0px 4px;
                outline: none;
                white-space: nowrap;
                cursor: pointer;
                font-weight: 700;
                font-size: 10pt;
                visibility: visible;
                position: absolute;
                margin: 2px;
                background: lightgray;
                transition: 0.5s;
                color: white;
            }

            .gridFile:active::before {
                background: -webkit-linear-gradient(top, #e3e3e3, #f9f9f9);
            }
    </style>
    <div class="contenedorgrid">
        <div class="grid grid-beca">
            <asp:GridView ID="beca" runat="server" CellPadding="2" CellSpacing="5" Width="100%" EmptyDataText="La busqueda no arrojo resltado." AllowPaging="True" PageSize="20" AutoGenerateColumns="false" DataKeyNames="ID" OnDataBound="beca_DataBound" OnPageIndexChanging="beca_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" Visible="False" />
                    <asp:BoundField DataField="cod_beca" HeaderText="Codigo" ReadOnly="True" SortExpression="Codigo" />
                    <asp:BoundField DataField="lapso" HeaderText="Lapso" ReadOnly="True" SortExpression="Lapso" />
                    <asp:TemplateField HeaderText="Tipo Beca">
                        <ItemTemplate>
                            <asp:HiddenField ID="hiddenArticulo" runat="server" Value='<%# Eval("tipo")%>' />
                            <asp:DropDownList ID="modArticulo" runat="server" DataSourceID="BecaDS" DataTextField="tipo_beca" DataValueField="cod_tipo_beca"></asp:DropDownList>
                            <asp:SqlDataSource ID="BecaDS" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT [cod_tipo_beca], [tipo_beca] FROM [tipo_beca]"></asp:SqlDataSource>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Solicitud" ControlStyle-Width="10em" FooterStyle-HorizontalAlign="Center" Visible="false">
                        <ItemTemplate>
                            <asp:HyperLink ID="solicitud" NavigateUrl='<%# Bind( "solicitud") %>' Text="Ver" runat="server" Target="_blank" />
                            <asp:FileUpload ID="dSolicitud" runat="server" CssClass="gridFile" />
                        </ItemTemplate>

                        <ControlStyle Width="10em"></ControlStyle>

                        <FooterStyle HorizontalAlign="Center"></FooterStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Carta de Compromiso" ControlStyle-Width="10em" Visible="false">
                        <ItemTemplate>
                            <asp:HyperLink ID="hCC" NavigateUrl='<%# Bind( "CC") %>' Text="Ver" runat="server" Target="_blank" />
                            <asp:FileUpload ID="dCC" runat="server" CssClass="gridFile" />
                        </ItemTemplate>

                        <ControlStyle Width="10em"></ControlStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Foto Carnet" ControlStyle-Width="10em" Visible="false">
                        <ItemTemplate>
                            <asp:HyperLink ID="hFC" NavigateUrl='<%# Bind( "FC") %>' Text="Ver" runat="server" Target="_blank" />
                            <asp:FileUpload ID="dFC" runat="server" CssClass="gridFile" />
                        </ItemTemplate>

                        <ControlStyle Width="10em"></ControlStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Notas Certificadas" ControlStyle-Width="10em" Visible="false">
                        <ItemTemplate>
                            <asp:HyperLink ID="hCN" NavigateUrl='<%# Bind( "CN") %>' Text="Ver" runat="server" Target="_blank" />
                            <asp:FileUpload ID="dCN" runat="server" CssClass="gridFile" />
                        </ItemTemplate>

                        <ControlStyle Width="10em"></ControlStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Situacion Socio Economica" ControlStyle-Width="10em" Visible="false">
                        <ItemTemplate>
                            <asp:HyperLink ID="hSE" NavigateUrl='<%# Bind( "SE") %>' Text="Ver" runat="server" Target="_blank" />
                            <asp:FileUpload ID="dSE" runat="server" CssClass="gridFile" />
                        </ItemTemplate>

                        <ControlStyle Width="10em"></ControlStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Constancia de Trabajo" ControlStyle-Width="10em" Visible="false">
                        <ItemTemplate>
                            <asp:HyperLink ID="hCT" NavigateUrl='<%# Bind( "CT") %>' Text="Ver" runat="server" Target="_blank" />
                            <asp:FileUpload ID="dCT" runat="server" CssClass="gridFile" />
                        </ItemTemplate>

                        <ControlStyle Width="10em"></ControlStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Acta de Defuncion Padres" ControlStyle-Width="10em" Visible="false">
                        <ItemTemplate>
                            <asp:HyperLink ID="hD" NavigateUrl='<%# Bind( "D") %>' Text="Ver" runat="server" Target="_blank" />
                            <asp:FileUpload ID="dD" runat="server" CssClass="gridFile" />
                        </ItemTemplate>

                        <ControlStyle Width="10em"></ControlStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Residencia" ControlStyle-Width="10em" Visible="false">
                        <ItemTemplate>
                            <asp:HyperLink ID="hDR" NavigateUrl='<%# Bind( "DR") %>' Text="Ver" runat="server" Target="_blank" />
                            <asp:FileUpload ID="dDR" runat="server" CssClass="gridFile" />
                        </ItemTemplate>

                        <ControlStyle Width="10em"></ControlStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Acta de Matrimonio" ControlStyle-Width="10em" Visible="false">
                        <ItemTemplate>
                            <asp:HyperLink ID="hAM" NavigateUrl='<%# Bind( "AM") %>' Text="Ver" runat="server" Target="_blank" />
                            <asp:FileUpload ID="dAM" runat="server" CssClass="gridFile" />
                        </ItemTemplate>

                        <ControlStyle Width="10em"></ControlStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Partida de Nacimiento" ControlStyle-Width="10em" Visible="false">
                        <ItemTemplate>
                            <asp:HyperLink ID="hPN" NavigateUrl='<%# Bind( "PN") %>' Text="Ver" runat="server" Target="_blank" />
                            <asp:FileUpload ID="dPN" runat="server" CssClass="gridFile" />
                        </ItemTemplate>

                        <ControlStyle Width="10em"></ControlStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="I.S.R.L Solicitante" ControlStyle-Width="10em" Visible="false">
                        <ItemTemplate>
                            <asp:HyperLink ID="hissrlS" NavigateUrl='<%# Bind( "issrlS") %>' Text="Ver" runat="server" Target="_blank" />
                            <asp:FileUpload ID="dissrlS" runat="server" CssClass="gridFile" />
                        </ItemTemplate>

                        <ControlStyle Width="10em"></ControlStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="I.S.R.L Conyugue" ControlStyle-Width="10em" Visible="false">
                        <ItemTemplate>
                            <asp:HyperLink ID="hissrlC" NavigateUrl='<%# Bind( "issrlC") %>' Text="Ver" runat="server" Target="_blank" />
                            <asp:FileUpload ID="dissrlC" runat="server" CssClass="gridFile" />
                        </ItemTemplate>

                        <ControlStyle Width="10em"></ControlStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Pago de Vivienda" ControlStyle-Width="10em" Visible="false">
                        <ItemTemplate>
                            <asp:HyperLink ID="hPV" NavigateUrl='<%# Bind( "PV") %>' Text="Ver" runat="server" Target="_blank" />
                            <asp:FileUpload ID="dPV" runat="server" CssClass="gridFile" />
                        </ItemTemplate>

                        <ControlStyle Width="10em"></ControlStyle>
                    </asp:TemplateField>

                    <asp:BoundField DataField="comentarios" HeaderText="Comentarios Secretaria" ReadOnly="True" SortExpression="Comentarios Secretaria" />
                    <asp:TemplateField HeaderText="Estatus">
                        <ItemTemplate>
                             <asp:HiddenField ID="cod_beca_h" runat="server" Value='<%# Eval("cod_beca")%>' />
                            <asp:HiddenField ID="hiddenStatus" runat="server" Value='<%# Eval("estatus")%>' />
                            <asp:DropDownList ID="modSolicitud" runat="server" DataSourceID="dsEstatus" DataTextField="estatus" DataValueField="cod_estatus"></asp:DropDownList>
                            <asp:SqlDataSource ID="dsEstatus" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT [cod_estatus], [estatus] FROM [estatus_solicitud]"></asp:SqlDataSource>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-ForeColor="Black" HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="buttonTable" ID="btnVer" runat="server" Text="Ver Más" OnClick="btnVer_Click" ToolTip="Permite editar el registro actual"></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle ForeColor="Black"></HeaderStyle>
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
    </div>
</asp:Content>

