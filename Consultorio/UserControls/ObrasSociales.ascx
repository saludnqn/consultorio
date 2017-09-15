<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ObrasSociales.ascx.cs"
    Inherits="UserControls.ObrasSociales" %>
<script language="javascript" type="text/javascript">
    $(function () {

        $('#<%= txtAutoOs.ClientID %>').autocomplete({ source: '<%= ResolveUrl("~/Services/ObraSocial.aspx") %>', minlenght: 3,
            focus: function (event, ui) {
                $("#<%= txtAutoOs.ClientID %>").val(ui.item.nombre);
                return false;
            },
            select: function (event, ui) {
                if (ui.item.id != -1) {
                    $("#<%= txtAutoOs.ClientID %>").val(ui.item.nombre);
                    $('#<%= lblNombre.ClientID %>').text(ui.item.nombre);
                    $('#<%= lblSigla.ClientID %>').text("(" + ui.item.sigla + ")");
                    $('#<%= lblCodigoNacion.ClientID %>').text(ui.item.codigoNacion);
                    $("#<%= idOS.ClientID %>").val(ui.item.id);
                    $("#<%= codigoOS.ClientID %>").val(ui.item.id);
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
				.append("<a><strong>" + item.nombre + "</strong> (" + item.sigla + ") &nbsp; [" + item.codigoNacion + "]</a>")
				.appendTo(ul);
        };

        $('#hlLimpiar').button();
    });

    function LimpiarPrincipal() {
        $("#<%= txtAutoOs.ClientID %>").val('');
        $('#<%= lblNombre.ClientID %>').text('Ingrese nombre, código o sigla de la Obra Social.');
        $('#<%= lblSigla.ClientID %>').text('');
        $('#<%= lblCodigoNacion.ClientID %>').text('');
        $("#<%= idOS.ClientID %>").val('');
        $("#<%= codigoOS.ClientID %>").val('-1');

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
        var id = (isNaN(document.getElementById('<%=codigoOS.ClientID%>').value) ? -1 : document.getElementById('<%=codigoOS.ClientID%>').value);
        if (id == "") id = -1;

        if ((boolRequerido.value == "true") & (id >= 0)) {
            args.IsValid = true;
        }
    }

</script>
<table class="autoCompleter">
    <tr>
        <td>
            <asp:TextBox runat="server" ID="txtAutoOs" Columns="85" ToolTip="Ingresar la Obra Social" CssClass="form-control"></asp:TextBox>
        </td>
        <td align="left">
            <a href="javascript:LimpiarPrincipal();" id="hlLimpiar" style="float: left;" title="Eliminar Item actual">
                <asp:Image ToolTip="Eliminar" runat="server" ID="imgLimpiar" ImageAlign="AbsMiddle"
                    ImageUrl="~/Images/usercontrols/textfield_delete.png" AlternateText="Borrar valor" /></a>
        </td>
        <td>
            <asp:CustomValidator ID="cvValidar" runat="server" ErrorMessage="*" Text="*" Display="Dynamic"
                ClientValidationFunction="validar" CssClass="btn btn-info">*</asp:CustomValidator>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <div id="acResult">
                <asp:HiddenField ID="idOS" runat="server" />
                <asp:HiddenField ID="boolRequerido" runat="server" />
                <asp:HiddenField ID="codigoOS" runat="server"/>
                <asp:Label runat="server" ID="lblNombre" Text="Ingrese nombre, código o sigla de la Obra Social."></asp:Label>
                &nbsp;
                <asp:Label runat="server" ID="lblSigla" Text=""></asp:Label>
                &nbsp;<asp:Label runat="server" ID="lblCodigoNacion" Text=""></asp:Label>
            </div>
            <div align="center">
                <asp:Label ID="lblMensajeError" runat="server" Text="Debe seleccionar una Obra Social"
                    Style="color: #FF0000; font-size: 0.94em; visibility: collapse;"></asp:Label>
            </div>
        </td>
        <td>
        </td>
    </tr>
</table>
