<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DiagCIE10.ascx.cs" Inherits="ConsultaAmbulatoria.UserControls.DiagCIE10" %>
<asp:ScriptManagerProxy ID="smp" runat="server">
    <Services>
        <asp:ServiceReference Path="~/ConsultaAmbulatoria/Services/cie10.aspx" />
    </Services>
</asp:ScriptManagerProxy>

<script type="text/javascript">
    $(function() {
   
        $('#<%= txtAutocie10.ClientID %>').autocomplete({ source: '<%= ResolveUrl("~/ConsultaAmbulatoria/Services/cie10.aspx")%>', minlenght: 3,
            focus: function(event, ui) {
                $("#<%= txtAutocie10.ClientID %>").val(ui.item.nombre);
                return false;
            },
            select: function(event, ui) {
                if (ui.item.id != -666) {
                    $("#<%= txtAutocie10.ClientID %>").val(ui.item.nombre);
                    $('#<%= lblNombre.ClientID %>').text(ui.item.nombre);
                    $('#<%= lblCodigo.ClientID %>').text("(" + ui.item.codigo + ")");
                    $('#<%= lblCapitulo.ClientID %>').text(ui.item.capitulo);
                    $("#<%= idCie10.ClientID %>").text(ui.item.id);
                    $('#hlAgregar').fadeIn();
                }
                return false;
            }
        }).data("autocomplete")._renderItem = function(ul, item) {
            return $("<li></li>")
				.data("item.autocomplete", item)
				.append("<a><strong>" + item.nombre + "</strong> (" + item.codigo + ")<br>" + item.capitulo + "</a>")
				.appendTo(ul);
        };

        $('#hlAgregar').button();
    });

    function AgregarElemento() {
        var id = $('#<%= idCie10.ClientID %>').text();
        var codigo = $('#<%= lblCodigo.ClientID %>').text();
        var nombre = $('#<%= lblNombre.ClientID %>').text();
        var hl = '<a href=javascript:Eliminar(' + id + ')>Eliminar</a>';
        var checked = '';
        if ($('#<%= idDiagnosticosSecundarios.ClientID %>').val() == '') {
            checked = 'checked';
        }
        var rb = '<input type="radio" name="DiagCIE10" value=' + id + ' ' + checked + '/>';
        $('#tbCodigos tr:last').after('<tr id=' + id + '><td>' + codigo + '</td><td>' + nombre + '</td><td>' + rb + '</td><td>' + hl + '</td></tr>');
        $('#Seleccion').fadeIn();
        $('#hlAgregar').hide();
        //Agrego los diagnosticos al campo
        if ($('#<%= idDiagnosticosSecundarios.ClientID %>').val() == '') {
            $('#<%= idDiagnosticosSecundarios.ClientID %>').val($('#<%= idCie10.ClientID %>').text());
        } else {
            $('#<%= idDiagnosticosSecundarios.ClientID %>').val($('#<%= idDiagnosticosSecundarios.ClientID %>').val() + ',' + $('#<%= idCie10.ClientID %>').text());
        }
    };

    function Eliminar(id) {
        $('#' + id).remove();
        var ids = $('#<%= idDiagnosticosSecundarios.ClientID %>').val().split(',');
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
        $('#<%= idDiagnosticosSecundarios.ClientID %>').val(newids);
        if (newids == "") {
            $('#Seleccion').fadeOut();
        }
    }
</script>

<div id="acContainer">
    <asp:TextBox runat="server" ID="txtAutocie10" Columns="45"></asp:TextBox>
    <div id="acResult">
        <asp:HiddenField ID="idCie10" runat="server" />
        <asp:Label runat="server" ID="lblNombre" Text="Ingrese nombre."></asp:Label>
        <asp:Label runat="server" ID="lblCodigo" Text=""></asp:Label><br />
        <asp:Label runat="server" ID="lblCapitulo" Text=""></asp:Label>   
                  
    </div>
    <a href="javascript:AgregarElemento();" id="hlAgregar" style="float: right; display: none;">Agregar</a>
    
</div>
<div id="Seleccion" style="display: none">
    <asp:HiddenField ID="idDiagnosticosSecundarios" runat="server" />
    <table id="tbCodigos">
        <tr>
            <td>
                Codigo  
            </td>
            <td>
                Nombre
            </td>
            <td>
                Principal
            </td>
            <td>
            </td>
        </tr>
    </table>
</div>
