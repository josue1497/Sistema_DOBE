<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vista_documentos.aspx.cs" Inherits="vistas_forms_coral_banda" MasterPageFile="~/vistas/forms/FormMasterPage.master" %>

<asp:Content runat="server" ID="CoralbandaContent" ContentPlaceHolderID="MainContent">

    <div>
        <h3 class="h3-forms">Documentos la beca <%=Session["cod_beca_h"]%> </h3>
        <br />
        <form id="documents" runat="server">
            <table>
                <tr>
                    <td>
                        <label>Documento de Solicitud: </label>
                        <br />
                        <asp:HyperLink ID="solicitud_beca" runat="server" Target="_blank">Ver</asp:HyperLink>
                    </td>
                    <td>
                        <label>Carta de Compromiso: </label>
                        <br />
                        <asp:HyperLink ID="carta_compromiso" runat="server" Target="_blank">Ver</asp:HyperLink>

                    </td>
                    <td>
                        <label>Foto Carnet: </label>
                        <br />
                        <asp:HyperLink ID="foto_carnet" runat="server" Target="_blank">Ver</asp:HyperLink>

                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Certificacion de Notas: </label>
                        <br />
                        <asp:HyperLink ID="certificacion_notas" runat="server" Target="_blank">Ver</asp:HyperLink>

                    </td>
                    <td>
                        <label>Informe Socio-Economico: </label>
                        <br />
                        <asp:HyperLink ID="socio_economico" runat="server" Target="_blank">Ver</asp:HyperLink>

                    </td>
                    <td>
                        <label>Constrancia de Trabajo: </label>
                        <br />
                        <asp:HyperLink ID="constancia_trabajo" runat="server" Target="_blank">Ver</asp:HyperLink>

                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Acta de Defincion de los Padres: </label>
                        <br />
                        <asp:HyperLink ID="defuncion" runat="server" Target="_blank">Ver</asp:HyperLink>

                    </td>
                    <td>
                        <label>Acta de Residencia: </label>
                        <br />
                        <asp:HyperLink ID="doc_residencia" runat="server" Target="_blank">Ver</asp:HyperLink>

                    </td>
                    <td>
                        <label>Acta de Matrimonio: </label>
                        <br />
                        <asp:HyperLink ID="acta_matrimonio" runat="server" Target="_blank">Ver</asp:HyperLink>

                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Partida de Nacimiento del Hijo: </label>
                        <br />
                        <asp:HyperLink ID="partida_nacimiento" runat="server" Target="_blank">Ver</asp:HyperLink>
                    </td>
                    <td>
                        <label>Declaracion de I.S.L.R.: </label>
                        <br />
                        <asp:HyperLink ID="isrl_solicitante" runat="server" Target="_blank">Ver</asp:HyperLink>
                    </td>
                    <td>
                        <label>Declaracion de I.S.L.R. del Conyuge: </label>
                        <br />
                        <asp:HyperLink ID="isrl_conyugue" runat="server" Target="_blank">Ver</asp:HyperLink>

                    </td>
                    <td>
                        <label>Documento de Pago de Vivienda </label>
                        <br />
                        <asp:HyperLink ID="pago_vivienda" runat="server" Target="_blank">Ver</asp:HyperLink>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnVolver" runat="server" OnClick="btnVolver_Click" Text="Volver a la pagina anterior"/>
        </form>
    </div>
</asp:Content>
