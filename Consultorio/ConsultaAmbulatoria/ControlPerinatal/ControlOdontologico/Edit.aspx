<%@ Page Title="" Language="C#" MasterPageFile="~/ConsultaAmbulatoria/MasterPages/ConsultorioPerinatal.Master"
    Theme="apr" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Consultorio.ConsultaAmbulatoria.ControlPerinatal.ControlOdontologico.Edit" %>
<%@ MasterType VirtualPath="~/ConsultaAmbulatoria/MasterPages/ConsultorioPerinatal.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function() {
            // Formatea y desoculta la botonera en caso de necesitarse.
            if ($('#botonera').children().size() > 0) {
                $('#botonera > input').button();
                $('#botonera > a').button();
                $('#botonera').show();
            }
            // Busca y formatea las grillas que haya.
            $('.grilla').dataTable({
                "bJQueryUI": true,
                "oLanguage": {
                    "sSearch": "Buscar:",
                    "sLengthMenu": "Mostrar _MENU_ ítems por página",
                    "sZeroRecords": "No se encontró nada",
                    "sInfo": "Mostrando _START_ a _END_ de _TOTAL_ ítems",
                    "sInfoEmpty": "Mostrando 0 a 0 de 0 ítems",
                    "sInfoFiltered": "(filtrado de _MAX_ ítems totales)"
                },
                "iDisplayLength": 10,
                "aaSorting": [[1, "asc"]],
                "aoColumnDefs": [
			            { "bSortable": false, "aTargets": [0] }
		            ]
            });
            // Formatea las cajas de texto
            $('input[type=text]').addClass("ui-widget-content ui-corner-all");
            $('textarea').addClass("ui-widget-content ui-corner-all");
            // Formatea los selects (sólo los chicos, para que no exploten)
            //$('select').filter(function(index) { return ($(this).children().size() < 50); }).selectmenu();
            // Agrega los datepickers (todo campo de texto que incluya "Fecha" en el nombre).
            $.datepicker.setDefaults($.datepicker.regional["es"]);
            $('input[type=text][name*=Fecha]').datepicker({
                showOn: "button",
                buttonText: "<span class='glyphicon glyphicon-calendar'></span>",
                dateFormat: "dd/mm/yy"
            });
            // Formatea botones de los datepickers
            $('button.ui-datepicker-trigger').button({
                //icons: { primary: "ui-icon-calendar" },
                text: false
            });
            // Formatea radiobuttons
            $('input[type=radio]').checkbox();
            // Formatea checkboxes
            $('input[type=checkbox]').checkbox();
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="server">
    <table class="formulario">
        <tr>
            <td>
                <asp:Label runat="server" ID="lFecha" Text="Fecha" AssociatedControlID="txtFecha"></asp:Label>
                <asp:TextBox runat="server" ID="txtFecha" CssClass="datepicker22 form-control" Width="150" style="float:left;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label runat="server" ID="lMotivo" Text="Motivo" AssociatedControlID="txtMotivo"></asp:Label><br />
                <asp:TextBox runat="server" ID="txtMotivo" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label runat="server" ID="lDescripcion" Text="Descripcion" AssociatedControlID="txtDescripcion"></asp:Label><br />
                <asp:TextBox runat="server" ID="txtDescripcion" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label runat="server" ID="lProfesional" Text="Profesional Control Odontológico" AssociatedControlID="ddlProfesional"></asp:Label>
                <asp:DropDownList runat="server" ID="ddlProfesional" DataTextField="NombreCompleto" DataValueField="idProfesional" CssClass="form-control">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="server">
    <asp:Button runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" />
    <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" />
</asp:Content>
