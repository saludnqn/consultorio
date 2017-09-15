<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Enfermeria.ascx.cs"
    Inherits="SIC.ControlMenor.Visitas.UserControls.Enfermeria" %>

<table>
    <tr>
        <td style="text-align:right; padding-right:5px; font-weight:bold;">Fecha de Control:</td>
        <td><asp:Literal ID="ltFecha" runat="server" /></td>
    </tr>
    <tr>
        <td style="text-align:right; padding-right:5px; font-weight:bold;">Peso:</td>
        <td><asp:Literal ID="ltPeso" runat="server" /></td>
    </tr>
    <tr>
        <td  style="text-align:right; padding-right:5px; font-weight:bold;">Talla:</td>
        <td><asp:Literal ID="ltTalla" runat="server" /></td>
    </tr>
    <tr>
        <td  style="text-align:right; padding-right:5px; font-weight:bold;">Perímetro cefálico:</td>
        <td><asp:Literal ID="ltPerimetroCefalico" runat="server" /></td>
    </tr>
    
    <tr>
        <td style="text-align:right; padding-right:5px; font-weight:bold;">Estado Nutricinal:</td>
        <td><asp:Literal ID="ltEstadoNutricional" runat="server" /></td>
    </tr>
    
    <tr>
        <td style="text-align:right; padding-right:5px; font-weight:bold;">Talla para la edad:</td>
        <td><asp:Literal ID="ltTallaEdad" runat="server" /></td>
    </tr>
     <tr>
        <td style="text-align:right; padding-right:5px; font-weight:bold;">TA:</td>
        <td><asp:Literal ID="ltTa" runat="server" /></td>
    </tr>
    <tr>
        <td style="text-align:right; padding-right:5px; font-weight:bold;">Observaciones:</td>
        <td><asp:Literal ID="ltObservaciones" runat="server" /></td>
    </tr>
    <tr>
        <td style="text-align:right; padding-right:5px; font-weight:bold;">Profesional:</td>
        <td><asp:Literal ID="ltProfesional" runat="server" /></td>
    </tr>
</table>