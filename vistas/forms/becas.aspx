<%@ Page Language="C#" AutoEventWireup="true" CodeFile="becas.aspx.cs" Inherits="vistas_forms_becas" MasterPageFile="~/vistas/forms/FormMasterPage.master" %>

<asp:Content runat="server" ID="BecasContent" ContentPlaceHolderID="MainContent">
    <form id="Becas_Form" runat="server">
        <div>
            <h3 class="h3-forms">Solicitud de Becas</h3>

            <asp:Label ID="lAlumno" runat="server" Text="Alumno: "></asp:Label><asp:TextBox ID="txtAlumno" runat="server" Enabled="false"></asp:TextBox><br />


            <asp:Label ID="lTipoBeca" runat="server" Text="Tipo Beca: " />
            <asp:DropDownList ID="dTipoBeca" runat="server" DataSourceID="TIpoBecaDS" DataTextField="tipo_beca" DataValueField="cod_tipo_beca"></asp:DropDownList>
            <asp:SqlDataSource ID="TIpoBecaDS" runat="server" ConnectionString="<%$ ConnectionStrings:SISTEMA_DOBEConnectionString %>" SelectCommand="SELECT [cod_tipo_beca], [tipo_beca] FROM [tipo_beca]"></asp:SqlDataSource>
            <br />

            <asp:Label ID="lBecaDocumento" runat="server" Text="Solicitud de Beca: "></asp:Label><asp:FileUpload ID="doc_beca" runat="server" required="true" /><br />
            <br />
            <asp:Label ID="lCartaCompromiso" runat="server" Text="  Carta de Compromiso: "></asp:Label>
            <asp:FileUpload ID="doc_compromiso" runat="server" required="true" /><br />
            <br />

            <asp:Label ID="lcarnet" runat="server" Text="Foto Carnet: "></asp:Label><asp:FileUpload ID="doc_fotocarnet" runat="server" required="true" accept="image/*" />

            <asp:Label ID="Label1" runat="server" Text="Certificacion de Notas: "></asp:Label><asp:FileUpload ID="doc_notas" runat="server" required="true" /><br />
            <br />

            <asp:Label ID="Label3" runat="server" Text="Informe Socio-Economico: "></asp:Label><asp:FileUpload ID="doc_informe" runat="server" required="true" /><br />
            <asp:Label ID="Label2" runat="server" Text="Constancia de Trabajo: "></asp:Label><asp:FileUpload ID="doc_constanciaTrabajo" runat="server" required="true" /><br />
            <br />

            <asp:Label ID="Label4" runat="server" Text="Constancia de Defunción (Si Aplica): "></asp:Label><asp:FileUpload ID="doc_constanciaDifuncion" runat="server" /><br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Documento de Resiendia: "></asp:Label><asp:FileUpload ID="doc_residencia" runat="server" required="true" /><br />
            <br />
            <asp:Label ID="Label10" runat="server" Text="Si es Casado: "></asp:Label><br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Acta de Matrimonio (Si Aplica): "></asp:Label>
            <asp:FileUpload ID="doc_matrimonio" runat="server" /><br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="Partida de Nacimiento de los Hijos: "></asp:Label><asp:FileUpload ID="doc_partidaNacimiento" runat="server" /><br />
            <br />
            <asp:Label ID="Label11" runat="server" Text="Declaracion I.S.L.R Solicitante: "></asp:Label><asp:FileUpload ID="doc_IstlSolicitante" runat="server" /><br />
            <br />
            <asp:Label ID="Label8" runat="server" Text="Declaracion I.S.L.R Conyugue: "></asp:Label><asp:FileUpload ID="doc_IslrConyugue" runat="server" /><br />
            <br />
            <asp:Label ID="Label9" runat="server" Text="Constancia de Pago residencia: "></asp:Label><asp:FileUpload ID="doc_pagoresidencia" runat="server" /><br />
            <br />
            <br />
            <asp:Label ID="Mensaje" runat="server" Text="" Font-Size="20px"></asp:Label><br />
            <br />
            <asp:Button ID="enviar" runat="server" Text="Enviar" OnClick="enviar_Click" />

        </div>
    </form>
</asp:Content>
