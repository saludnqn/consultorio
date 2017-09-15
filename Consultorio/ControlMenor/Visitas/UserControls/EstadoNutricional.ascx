<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EstadoNutricional.ascx.cs"
    Inherits="SIC.ControlMenor.Visitas.UserControls.EstadoNutricional" %>
    
<table>
    <tr>
        <td style="text-align:right; padding-right:5px; font-weight:bold;">Lactancia:</td>
        <td><asp:Literal ID="ltTipoLactancia" runat="server" /></td>
    </tr>
    <tr>
        <td  style="text-align:right; padding-right:5px; font-weight:bold;">Intervención:</td>
        <td><asp:Literal ID="ltIntervencion" runat="server" /></td>
    </tr>
</table>
