<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ResumenPaciente.ascx.cs"
    Inherits="Consultorio.UserControls.ResumenPaciente" %>
<%--
    Muestra una tabla con datos básicos del paciente que se está navegando.
    
    Utiliza clases del Framework CSS de jQueryUI para mostrar un resaltado copante.
--%>
<div id="divResumenPaciente" class="ui-widget" style="margin-bottom: 5px" runat="server">
    <div class="ui-state-highlight ui-corner-all" style="padding: 5px">
        <table id="tableencabezado" style="width: 100%; margin-bottom: 0; vertical-align:top">
            <tr>
                <td>
                     <strong>Paciente: </strong>
                    <asp:Literal runat="server" ID="ltPaciente" />
                </td>
                <td colspan="2">
                <strong>Obra Social: </strong>
                    <asp:Literal runat="server" ID="ltObraSocial" />
                    
                </td>
            </tr>
            <tr>
                <td>
                    <strong>DU: </strong>
                    <asp:Literal runat="server" ID="ltDocumentoUnico" />
                </td>
                <td>
                <strong>Fecha Nac: </strong>
                    <asp:Literal runat="server" ID="ltFechaNacimiento" />  
                </td>
                <td>
                    <strong>Sexo: </strong>
                    <asp:Literal runat="server" ID="ltSexo" /> |
                    <strong>Edad: </strong>
                    <asp:Literal runat="server" ID="ltEdad" />
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Historia Clínica en el Efector: </strong>
                    <asp:Literal runat="server" ID="ltHC" />  
                <td>
                     <asp:HyperLink ID="lkEditar" runat="server" Text="Editar Paciente"/> | 
                     <asp:HyperLink ID="lkControlmenor" runat="server" Text="Datos Iniciales" Target="_pageControlMenor"></asp:HyperLink></li>
                </td>
            </tr>
        </table>
    </div>
</div>