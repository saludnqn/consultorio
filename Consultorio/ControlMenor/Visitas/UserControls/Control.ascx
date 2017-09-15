<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Control.ascx.cs" Inherits="SIPS.ControlMenor.Visitas.UserControls.Control" %>
<%@ Register Src="../Edit/Control.ascx" TagName="Control" TagPrefix="uc1" %>

<script type="text/javascript">
    $(document).ready(function() {
        $('#<%= hlEditarControl.ClientID %>').click(function() {
            $('#<%= wdwControl.ClientID %>').dialog('open');
        });

        var dlg = $('#<%= wdwControl.ClientID %>').dialog({ autoOpen: false, modal: true, minWidth: 500, minHeigth: 500, title: 'Edicion' });
        dlg.parent().appendTo(jQuery("form:first"));
        // Formatea la botonera.
        $('#<%= botoneraEdit.ClientID %> > input').button();
    });
</script>

<div id="botoneraControl" class="ui-widget-header ui-corner-all" style="padding: 5px 10px;
    text-align: right;">
    <asp:HyperLink runat="server" ID="hlEditarControl" Text="Editar"></asp:HyperLink>
</div>
<table>
    <tr>
        <td style="text-align: right; padding-right: 5px; font-weight: bold;">
            Próximo control:
        </td>
        <td>
            <asp:Literal ID="ltFechaProximoControl" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right; padding-right: 5px; font-weight: bold;">
            Observaciones:
        </td>
        <td>
            <asp:Literal ID="ltObservaciones" runat="server" />
        </td>
    </tr>
</table>
<div runat="server" id="wdwControl">

    <script type="text/javascript">
        $(document).ready(function() {

        });
    </script>

    <table>
        <tr>
            <td>
                <asp:Label runat="server" ID="lblProximoControl" Text="Próximo control" AssociatedControlID="dtpFecha"></asp:Label><br />
                <asp:TextBox runat="server" ID="dtpFecha"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" ID="lblObservaciones" Text="Observaciones" AssociatedControlID="txtObservaciones"></asp:Label><br />
                <asp:TextBox runat="server" ID="txtObservaciones" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div id="botoneraEdit" runat="server" class="ui-widget-header ui-corner-all" style="padding: 5px 10px;
        margin-top: 10px;">
        <asp:Button runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" />
        <%-- <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" />--%>
    </div>
</div>
