<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Control.ascx.cs" Inherits="SIPS.ControlMenor.Visitas.Edit.Control" %>

<script type="text/javascript">
    $(document).ready(function() {
        // Formatea la botonera.
        $('#<%= botoneraEdit.ClientID %> > input').button();
    });
</script>
<table>
    <tr>
        <td>
            <asp:Label runat="server" ID="lblProximoControl" Text="Próximo control" AssociatedControlID="dtpFecha"></asp:Label>
            <asp:TextBox runat="server" ID="dtpFecha"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label runat="server" ID="lblObservaciones" Text="Observaciones" AssociatedControlID="txtObservaciones"></asp:Label>
            <asp:TextBox runat="server" ID="txtObservaciones" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
</table>
<div id="botoneraEdit" runat="server" class="ui-widget-header ui-corner-all" style="padding: 5px 10px;
    margin-top: 10px;">
    <asp:Button runat="server" ID="btnGuardar" Text="Guardar" 
        onclick="btnGuardar_Click" />
   <%-- <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" />--%>
</div>
