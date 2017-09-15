<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Profesional.ascx.cs" Inherits="UserControls.Profesional" %>

<script language="javascript" type="text/javascript">
    $(function() {
        $('#<%= txtAutoProf.ClientID %>').autocomplete({ source: '<%= ResolveUrl("~/Services/Profesional.ashx") %>', minlenght: 3,
            focus: function (event, ui) {
            $("#<%= txtAutoProf.ClientID %>").val(ui.item.nombreCompleto);
                return false;
            },
            select: function (event, ui) {
                if (ui.item.id != -1) {
                    $("#<%= txtAutoProf.ClientID %>").val(ui.item.nombreCompleto);
                    $('#<%= lblNombreCompleto.ClientID %>').text(ui.item.nombreCompleto);
                    $("#<%= idProf.ClientID %>").val(ui.item.id);
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
				.append("<a><strong>" + item.nombreCompleto + "</a></strong>")
				.appendTo(ul);
        };

        $('#hlLimpiarP').button({ icons: { primary: "ui-icon-cancel" }, text: false });
    });

    function LimpiarPrincipalP() {
        $("#<%= txtAutoProf.ClientID %>").val('');
        $('#<%= lblNombreCompleto.ClientID %>').text('Ingrese nombre o apellido del Profesional.');
        $("#<%= idProf.ClientID %>").val('');

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
        var id = (isNaN(document.getElementById('<%=idProf.ClientID%>').value) ? -1 : document.getElementById('<%=idProf.ClientID%>').value);
        if (id == "") id = -1;

        if ((boolRequerido.value == "true") & (id >= 0)) {
            args.IsValid = true;
        }
    }

</script>
<table class="autoCompleter">
    <tr>
        <td>
            <asp:TextBox runat="server" ID="txtAutoProf" Columns="85" ToolTip="Ingresar el Profesional"></asp:TextBox>
        </td>
        <td align="left">
            <a href="javascript:LimpiarPrincipalP();" id="hlLimpiarP" style="float: left;" title="Eliminar Item actual">
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
                <asp:HiddenField ID="idProf" runat="server" />
                <asp:HiddenField ID="boolRequerido" runat="server" />
                <asp:Label runat="server" ID="lblNombreCompleto" Text="Ingrese nombre o apellido del Profesional."></asp:Label>
            </div>
            <div align="center">
                <asp:Label ID="lblMensajeError" runat="server" Text="Debe seleccionar el Profesional"
                    Style="color: #FF0000; font-size: 0.94em; visibility: collapse;"></asp:Label>
            </div>
        </td>
        <td>
        </td>
    </tr>
</table>
