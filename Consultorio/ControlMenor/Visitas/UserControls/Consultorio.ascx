<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Consultorio.ascx.cs" 
    Inherits="SIPS.ControlMenor.Visitas.UserControls.Consultorio" %>
<table>
<tr>
    <td style="text-align:right; padding-right:5px; font-weight:bold;">Fecha:</td> <td><asp:Literal ID="ltFechaConsulta" runat="server" /></td>
</tr>
<tr>
<td  style="text-align:right; padding-right:5px; font-weight:bold;">Hora:</td><td><asp:Literal ID="ltHoraConsulta" runat="server" /></td>
</tr>
<tr>
<td  style="text-align:right; padding-right:5px; font-weight:bold;">Médico:</td><td><asp:Literal ID="ltMedico" runat="server" /></td>
</tr>
<tr>
<td  style="text-align:right; padding-right:5px; font-weight:bold;">Especialidad:</td><td><asp:Literal ID="ltEspecialidad" runat="server" /></td>
</tr>
<tr>
<td  style="text-align:right; padding-right:5px; font-weight:bold;">Motivo:</td><td><asp:Literal ID="ltMotivo" runat="server" /></td>
</tr>
<tr>
<td  style="text-align:right; padding-right:5px; font-weight:bold;">Informe:</td><td><asp:Literal ID="ltInforme" runat="server" /></td>
</tr>
<tr>
<td  style="text-align:right; padding-right:5px; font-weight:bold;">Diagnóstico principal:</td><td><asp:Literal ID="ltDiagnosticoPrincipal" runat="server" /></td>
</tr>
<tr>
<td  style="text-align:right; padding-right:5px; font-weight:bold;">Diagnósticos secundarios:</td>
<td>
<asp:Repeater ID="rptDiagnosticosSecundarios" runat="server">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li><%# Eval("Nombre") %></li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
</td>
</tr>
<tr>
<td  style="text-align:right; padding-right:5px; font-weight:bold;">Medicamentos:</td>
<td>
<asp:Repeater ID="rptMedicamentos" runat="server">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li><%# Eval("Nombre") %></li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
</td>
</tr>
</table>



