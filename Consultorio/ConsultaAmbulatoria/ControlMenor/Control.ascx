<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Control.ascx.cs" Inherits="Consultorio.ConsultaAmbulatoria.ControlMenor.Control" %>
<table class="formulario">
    <tr>
        <td>
            <asp:Label runat="server" ID="lblFechaProximoControl" AssociatedControlID="txtFechaProximoControl"
                Text="Proximo Control:"></asp:Label>
            <asp:TextBox runat="server" ID="txtFechaProximoControl"></asp:TextBox>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label runat="server" ID="lblObservacion" AssociatedControlID="txtObservacion"
                Text="Observacion:"></asp:Label>
            <asp:TextBox runat="server" ID="txtObservacion" TextMode="MultiLine" Rows="5" Width="100%"></asp:TextBox>
        </td>
    </tr>
</table>
