<%@ Page Language="C#" AutoEventWireup="true" CodeFile="delete_form.aspx.cs" Inherits="reposos" MasterPageFile="~/vistas/forms/FormMasterPage.master" %>

<asp:Content runat="server" ID="ReposoContent" ContentPlaceHolderID="MainContent">
    <form id="reposo_form" runat="server">
        <div>
            <br />
            <h3 class="h3-forms" id="title">Formulario para Eliminar Elementos</h3>
            <br />

            <asp:Label ID="EstatusReposoLabel" runat="server" Text="Estado: "></asp:Label>
            <asp:DropDownList ID="elementos" runat="server" CssClass="textBox-short">
                <asp:ListItem ID="DropDownList1" runat="server" Value="Filtrar"></asp:ListItem>
                <asp:ListItem ID="ListItem1" runat="server" Value="1" Text="Cargo"></asp:ListItem>
                <asp:ListItem ID="ListItem2" runat="server" Value="2" Text="Disciplina"></asp:ListItem>
                <asp:ListItem ID="ListItem3" runat="server" Value="3" Text="Equipos del PSM"></asp:ListItem>
                <asp:ListItem ID="ListItem4" runat="server" Value="4" Text="Instrumentos de Radio"></asp:ListItem>
                <asp:ListItem ID="ListItem5" runat="server" Value="5" Text="Tipo de articulos Deportivos"></asp:ListItem>
                <asp:ListItem ID="ListItem6" runat="server" Value="6" Text="Tipos de Beca"></asp:ListItem>
                <asp:ListItem ID="ListItem7" runat="server" Value="7" Text="Coral y Banda"></asp:ListItem>
                <asp:ListItem ID="ListItem8" runat="server" Value="8" Text="Tipo de Evento Cultural"></asp:ListItem>
                <asp:ListItem ID="ListItem9" runat="server" Value="9" Text="Tipo de Evento Deportivo"></asp:ListItem>
                <asp:ListItem ID="ListItem10" runat="server" Value="10" Text="Tipo de Reposo"></asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="buscar" runat="server" Text="Filtrar" OnClick="buscar_Click" CssClass="button" />
            <br />
            <br />

            <div class="grid">
                <asp:GridView ID="result" runat="server" CellPadding="2" CellSpacing="5" Width="80%" AllowPaging="True" PageSize="20" AutoGenerateColumns="false" DataKeyNames="ID" OnDataBound="result_DataBound" OnPageIndexChanging="result_PageIndexChanging" EmptyDataText="La busqueda no obtuvo resultados.">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                        <asp:TemplateField HeaderText="Indicaciones">
                            <ItemTemplate>
                                <asp:TextBox ID="txtIndicaciones" runat="server" Text='<%# Eval("value")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-ForeColor="Black" HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton CssClass="buttonTable" ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" ToolTip="Permite Editar el registro actual"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle ForeColor="Black"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-ForeColor="Black" HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton CssClass="buttonTable" ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" ToolTip="Permite eliminar el registro actual"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle ForeColor="Black"></HeaderStyle>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle BackColor="#FF6600" BorderColor="Black" />
                    <RowStyle BorderStyle="Solid" BorderWidth="2px" />
                </asp:GridView>
                <br />
                <br />
            </div>

            <asp:Label ID="Mensaje" runat="server" Text="" Font-Size="20px"></asp:Label><br />
            <br />




        </div>
    </form>
</asp:Content>
