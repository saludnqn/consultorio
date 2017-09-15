<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Efector.ascx.cs" Inherits="UserControls.Efector" %>

<script language="javascript" type="text/javascript">
    $(function() {
        $('#<%= txtAutoEf.ClientID %>').autocomplete({ source: '<%= ResolveUrl("~/Services/Efector.ashx") %>', minlenght: 3,
            focus: function (event, ui) {
            $("#<%= txtAutoEf.ClientID %>").val(ui.item.nombre);
                return false;
            },
            select: function (event, ui) {
                if (ui.item.id != -1) {
                    $("#<%= txtAutoEf.ClientID %>").val(ui.item.nombre);
                    $('#<%= lblNombre.ClientID %>').text(ui.item.nombre);
                    $("#<%= idEfector.ClientID %>").val(ui.item.id);
                    ActivarRequerido(false);
                }
                else {
                    ActivarRequerido(true);
                    return false;
                }
            }
        }).data("autocomplete")._renderItem = function (ul, item) {
            return $("<li></li>")
				.data("item.autocomplete", item)
				.append("<a><strong>" + item.nombre + "</a></strong>")
				.appendTo(ul);
        };

        $('#hlLimpiarE').button({ icons: { primary: "ui-icon-cancel" }, text: false });
    });

    function LimpiarPrincipalE() {
        $("#<%= txtAutoEf.ClientID %>").val('');
        $('#<%= lblNombre.ClientID %>').text('Ingrese nombre del efector');
        $("#<%= idEfector.ClientID %>").val('');

        ActivarRequerido(true);
    }
</script>
<script type="text/javascript">

    function ActivarRequerido(Activa) {
        var boolRequerido = document.getElementById('<%=boolRequerido.ClientID%>');
        if (boolRequerido.value == "true") {

            mensaje = document.getElementById('<%=lblMensajeError.ClientID%>');
            mensaje.style.visibility = (Activa == true ? "visible" : "collapse");
        }

    }

    function validar(sender, args) {
        args.IsValid = false;
        var boolRequerido = document.getElementById('<%=boolRequerido.ClientID%>');
        var id = (isNaN(document.getElementById('<%=idEfector.ClientID%>').value) ? -1 : document.getElementById('<%=idEfector.ClientID%>').value);
        if (id == "") id = -1;

        if ((boolRequerido.value == "true") & (id >= 0)) {
            args.IsValid = true;
        }
    }

</script>
<table class="autoCompleter">
    <tr>
        <td>
            <asp:TextBox runat="server" ID="txtAutoEf" Columns="85" ToolTip="Ingresar el Efector"></asp:TextBox>
        </td>
        <td align="left">
            <a href="javascript:LimpiarPrincipalE();" id="hlLimpiarE" style="float: left;" title="Eliminar Item actual">
                <asp:Image ToolTip="Eliminar" runat="server" ID="imgLimpiar" ImageAlign="AbsMiddle"
                    ImageUrl="~/Images/usercontrols/textfield_delete.png" AlternateText="Borrar valor" /></a>
        </td>
        <td>
            <asp:CustomValidator ID="cvValidar" runat="server" ErrorMessage="*" Text="*" Display="Dynamic"
                ClientValidationFunction="validar">*</asp:CustomValidator>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <div id="acResult">
                <asp:HiddenField ID="idEfector" runat="server" />
                <asp:HiddenField ID="boolRequerido" runat="server" />
                <asp:Label runat="server" ID="lblNombre" Text="Ingrese nombre del Efector"></asp:Label>
            </div>
            <div align="center">
                <asp:Label ID="lblMensajeError" runat="server" Text="Debe seleccionar el Efector"
                    Style="color: #FF0000; font-size: 0.94em; visibility: collapse;"></asp:Label>
            </div>
        </td>
        <td>
        </td>
    </tr>
</table>