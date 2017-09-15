<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PacienteProvincial.ascx.cs" Inherits="UserControls.PacienteProvincial" %>
<div>
    <asp:Panel runat="server" ID="pnlPaciente">
        <table>
            <tr align="center">
                <td colspan="4">
                    <h2>Datos Principales</h2>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="4">Estado:
                    <asp:Label ID="lblEstado" CssClass="negrita" runat="server"></asp:Label>
                    <asp:Label ID="lblIdEstado" CssClass="negrita" runat="server" Visible="false"></asp:Label>
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="3">DU:  &nbsp;
                    <asp:Label ID="lblNumeroDoc" CssClass="negrita" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp; 
                 Doc.Extranjero: &nbsp;  
                    <asp:Label ID="lblExtranjero" CssClass="negrita" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp; 
                  
                    <asp:Label ID="lblMotivoNI" CssClass="negrita" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblidMotivoNI" CssClass="negrita" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">Apellido:
                    <asp:Label ID="lblApellido" CssClass="negrita" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3">Nombre:
                    <asp:Label ID="lblNombre" CssClass="negrita" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Fec. de Nac.:
                    <asp:Label ID="lblFechaNac" CssClass="negrita" runat="server"></asp:Label>
                </td>
                <td>&nbsp;&nbsp;&nbsp; Sexo:
                       <asp:Label ID="lblidSexo" CssClass="negrita" runat="server"></asp:Label>
                    <asp:Label ID="lblSexo" CssClass="negrita" runat="server"></asp:Label>
                </td>
                <td></td>
            </tr>
            <tr>
                <td colspan="3">Nacionalidad:
                    <asp:Label ID="lblidNacionalidad" CssClass="negrita" runat="server"></asp:Label>
                    <asp:Label ID="lblNacionalidad" CssClass="negrita" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    Lugar de Nacimiento:
                    <asp:Label ID="lblidLugarNacimiento" CssClass="negrita" runat="server"></asp:Label>
                    <asp:Label ID="lblLugarNacimiento" CssClass="negrita" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">Obra Social:
                          <asp:Label ID="lblidOSocial" CssClass="negrita" runat="server"></asp:Label>
                    <asp:Label ID="lblOSocial" CssClass="negrita" runat="server" ToolTip="Obra Social al Momento del Alta del Paciente"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Teléfono Fijo:
                    <asp:Label ID="lblTFijo" CssClass="negrita" runat="server"></asp:Label>
                </td>
                <td>Celular:
                    <asp:Label ID="lblTCelular" CssClass="negrita" runat="server"></asp:Label>
                </td>
                <td>E-mail:
                    <asp:Label ID="lblEmail" CssClass="negrita" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">Observaciones:
                    <asp:Label ID="lblContacto" CssClass="negrita" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">&nbsp;</td>
            </tr>

            <tr>
                <td>Fecha Defunción:
                    <asp:Label ID="lblDefuncion" CssClass="negrita" runat="server"></asp:Label>
                </td>
                <td>
                    <%--Paciente Crónico:
                <asp:Label ID="lblCronico" CssClass="negrita" runat="server"></asp:Label>--%>
                </td>
            </tr>
            <tr align="center">
                <td colspan="4">&nbsp;</td>
            </tr>
            <tr align="center">
                <td colspan="4">
                    <h2>Datos del Domicilio</h2>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="4">Provincia:
                        <asp:Label ID="lblidProvincia" CssClass="negrita" runat="server"></asp:Label>
                    <asp:Label ID="lblProvincia" CssClass="negrita" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">Departamento:
                      <asp:Label ID="lblidDptoDomicilio" CssClass="negrita" runat="server"></asp:Label>
                    <asp:Label ID="lblDptoDomicilio" CssClass="negrita" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">Localidad: 
                    <asp:Label ID="lblidLocalidad" CssClass="negrita" runat="server"></asp:Label>
                    <asp:Label ID="lblLocalidad" CssClass="negrita" runat="server"></asp:Label>
                </td>
                <td colspan="2">Codigo Postal:
                    <asp:Label ID="lblCPostal" CssClass="negrita" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">Barrio:
                     <asp:Label ID="lblidBarrio" CssClass="negrita" runat="server"></asp:Label>
                    <asp:Label ID="lblBarrio" CssClass="negrita" runat="server"></asp:Label>
                </td>
                <td colspan="2">Otro Barrio:
                    <asp:Label ID="lblOBarrio" CssClass="negrita" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Calle:
                    <asp:Label ID="lblCalle" CssClass="negrita" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Número:
                    <asp:Label ID="lblNum" CssClass="negrita" runat="server"></asp:Label>
                    Edificio:
                    <asp:Label ID="lblEdificio" CssClass="negrita" runat="server"></asp:Label>
                </td>
                <td>Piso:
                    <asp:Label ID="lblPiso" CssClass="negrita" runat="server"></asp:Label>
                </td>
                <td>Dpto:
                    <asp:Label ID="lblDepartamento" CssClass="negrita" runat="server"></asp:Label>
                </td>
                <td>Manzana:
                    <asp:Label ID="lblManzana" CssClass="negrita" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">Referencia:
                    <asp:Label ID="lblReferencia" CssClass="negrita" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Tipo:
                    <asp:Label ID="lblUrbano" runat="server" CssClass="negrita"></asp:Label>
                </td>
                <td>&nbsp; &nbsp;
                </td>
                <td>Latitud:
                    <asp:Label ID="lblLatitud" runat="server" CssClass="negrita"></asp:Label>
                </td>
                <td>Longitud:
                    <asp:Label ID="lblLongitud" runat="server" CssClass="negrita"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">Campo:
                    <asp:Label ID="lblCampo" runat="server" CssClass="negrita"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Camino:
                    <asp:Label ID="lblCamino" runat="server" CssClass="negrita"></asp:Label>
                </td>
                <td>&nbsp; &nbsp;
                </td>
                <td>Lote:
                    <asp:Label ID="lblLote" CssClass="negrita" runat="server"></asp:Label>
                </td>
                <td>Parcela:
                    <asp:Label ID="lblParcela" runat="server" CssClass="negrita"></asp:Label>
                </td>
            </tr>
            <tr align="center">
                <td colspan="4">&nbsp;</td>
            </tr>
            <tr align="center">
                <td colspan="4">
                    <h2>Datos del Progenitor</h2>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <hr />
                </td>
            </tr>

            <tr>
                <td colspan="2">

                    <asp:Label ID="lblParentesco0" Text="Datos de la Madre" runat="server" CssClass="negrita"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblTipoDocP0" runat="server">DU</asp:Label>:&nbsp<asp:Label
                        ID="lblDocP0" runat="server" CssClass="negrita"></asp:Label>
                </td>
            </tr>

            <tr>
                <td colspan="2">Apellido:
                    <asp:Label ID="lblApellidoP0" CssClass="negrita" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">Nombre:
                    <asp:Label ID="lblNombreP0" runat="server" CssClass="negrita"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">Fecha de Nacimiento:
                    <asp:Label ID="lblFecNacP0" runat="server" CssClass="negrita"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">Nacionalidad:
                     <asp:Label ID="lblidNacionalidadP0" runat="server" CssClass="negrita"></asp:Label>
                    <asp:Label ID="lblNacionalidadP0" runat="server" CssClass="negrita"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">Lugar de Nacimiento:
                      <asp:Label ID="lblidLNacimientoP0" CssClass="negrita" runat="server"></asp:Label>
                    <asp:Label ID="lblLNacimientoP0" CssClass="negrita" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="2">

                    <asp:Label ID="lblParentesco" Text="Datos del Padre" runat="server" CssClass="negrita"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblTipoDocP" runat="server">DU</asp:Label>:&nbsp<asp:Label
                        ID="lblDocP" runat="server" CssClass="negrita"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">Apellido:
                    <asp:Label ID="lblApellidoP" CssClass="negrita" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">Nombre:
                    <asp:Label ID="lblNombreP" runat="server" CssClass="negrita"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">Fecha de Nacimiento:
                    <asp:Label ID="lblFecNacP" runat="server" CssClass="negrita"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">Nacionalidad:
                       <asp:Label ID="lblidNacionalidadP" Visible="false" runat="server" CssClass="negrita"></asp:Label>
                    <asp:Label ID="lblNacionalidadP" runat="server" CssClass="negrita"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">Lugar de Nacimiento:
                     <asp:Label ID="lblidLNacimientoP" CssClass="negrita" runat="server"></asp:Label>
                    <asp:Label ID="lblLNacimientoP" CssClass="negrita" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <hr />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlError">
        <asp:Label ID="lblError" CssClass="negrita" runat="server"></asp:Label>
    </asp:Panel>
</div>
