<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Medicamento.ascx.cs"
    Inherits="ConsultaAmbulatoria.UserControls.Medicamento" %>

<script type="text/javascript">
    $(document).ready(function() {
        $('#hlAgregarMedicamento').button();

        $('#<%= txtAutomed.ClientID %>').autocomplete({ source: '<%= ResolveUrl("~/ConsultaAmbulatoria/services/med.aspx") %>', minlenght: 3,
            focus: function(event, ui) {
                /*$("#project").val(ui.item.nombre);*/
                return false;
            },
            select: function(event, ui) {
                if (ui.item.id != -666) {
                    $('#hlAgregarMedicamento').show();
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
    });

    function AgregarMedicamento() {
        var id = $('#<%= idMedicamento.ClientID %>').val();
        var nombre = $('#<%= lblDescripcion.ClientID %>').text();
        var rubro = $('#<%= lblRubro.ClientID %>').text();
        var hl = '<a href=javascript:EliminarMedicamento(' + id + ')>Eliminar</a>';
        $('#tbCodigosMedicamento tr:last').after('<tr id=' + id + '><td>' + nombre + '</td><td>' + rubro + '</td><td>' + hl + '</td></tr>');
        $('#SeleccionMedicamento').fadeIn();
        //Agrego los medicamentos al campo
        if ($('#<%= idMedicamentos.ClientID %>').val() == '') {
            $('#<%= idMedicamentos.ClientID %>').val($('#<%= idMedicamento.ClientID %>').val());
        } else {
            $('#<%= idMedicamentos.ClientID %>').val($('#<%= idMedicamentos.ClientID %>').val() + ',' + $('#<%= idMedicamento.ClientID %>').val());
        };
        $('#hlAgregarMedicamento').hide();
    };

    function EliminarMedicamento(id) {
        $('#' + id).remove();
        //Elimino el id del listado
        var ids = $('#<%= idMedicamentos.ClientID %>').val().split(',');
        var newids = "";
        for (i = 0; i < ids.length; i++) {
            if (ids[i] != id) {
                if (newids == "") {
                    newids += ids[i];
                } else {
                    newids += ',' + ids[i];
                }
            }
        }
        $('#<%= idMedicamentos.ClientID %>').val(newids);
        if (newids == "") {
            $('#SeleccionMedicamento').fadeOut();
        }
    };
</script>

<div id="acContainer">
    <asp:TextBox runat="server" ID="txtAutomed" Columns="45"></asp:TextBox>
    <div id="acResult">
        <asp:HiddenField ID="idMedicamento" runat="server" />
        <asp:Label runat="server" ID="lblDescripcion" Text="Ingrese nombre."></asp:Label><br />
        <asp:Label runat="server" ID="lblRubro" Text=""></asp:Label>
    </div>
</div>
<a href="javascript:AgregarMedicamento();" id="hlAgregarMedicamento" style="float: right;
    display: none;">Agregar</a>
<div id="SeleccionMedicamento" style="display: none">
    <asp:HiddenField ID="idMedicamentos" runat="server" />
    <table id="tbCodigosMedicamento" class="acResult">
        <tr>
            <td>
                Nombre
            </td>
            <td>
                Rubro
            </td>
            <td>
            </td>
        </tr>
    </table>
</div>
