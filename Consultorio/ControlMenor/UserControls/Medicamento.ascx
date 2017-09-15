<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Medicamento.ascx.cs"
    Inherits="SIPS.ControlMenor.UserControls.Medicamento" %>

<script type="text/javascript">
    $(document).ready(function() {
        $('#<%= txtAutomed.ClientID %>').autocomplete({ source: '<%= ResolveUrl("~/ConsultaAmbulatoria/services/med.aspx") %>', minlenght: 3,
            focus: function(event, ui) {
                $("#<%= txtAutomed.ClientID %>").val(ui.item.nombre);
                return false;
            },
            select: function(event, ui) {
                if (ui.item.id != -666) {
                    $("#<%= txtAutomed.ClientID %>").val(ui.item.nombre);
                    $('#<%= lblDescripcion.ClientID %>').text(ui.item.nombre);
                    $('#<%= lblRubro.ClientID %>').text(ui.item.rubro);
                    $("#<%= idMedicamento.ClientID %>").val(ui.item.id);
                }
                return false;
            }
        }).data("autocomplete")._renderItem = function(ul, item) {
            return $("<li></li>")
				.data("item.autocomplete", item)
				.append("<a><strong>" + item.nombre + "</strong><br>" + item.rubro + "</a>")
				.appendTo(ul);


        };

        $('#hlLimpiar').button();
    });

    function LimpiarMedicamento() {
        $("#<%= txtAutomed.ClientID %>").val('');
        $('#<%= lblDescripcion.ClientID %>').text('Ingrese nombre o codigo.');
        $('#<%= lblRubro.ClientID %>').text('');
        $("#<%= idMedicamento.ClientID %>").val('');
    };
</script>

<table class="autoCompleter">
    <tr>
        <td>
            <asp:TextBox runat="server" ID="txtAutomed" Columns="45"></asp:TextBox>
        </td>
        <td>
            <a href="javascript:LimpiarMedicamento();" id="hlLimpiar" style="float: left;">
                <asp:Image runat="server" ID="imgLimpiar" ImageAlign="AbsMiddle" ImageUrl="~/Images/usercontrols/textfield_delete.png"
                    AlternateText="Borrar valor" /></a>
        </td>
        <td>
            <div id="acResult">
                <asp:HiddenField ID="idMedicamento" runat="server" />
                <asp:Label runat="server" ID="lblDescripcion" Text="Ingrese nombre."></asp:Label><br />
                <asp:Label runat="server" ID="lblRubro" Text=""></asp:Label>
            </div>
        </td>
    </tr>
</table>
