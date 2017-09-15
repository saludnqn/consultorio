<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrestacionOdontologia.ascx.cs"  Inherits="ConsultaAmbulatoria.UserControls.PrestacionOdontologia" %>

<script type="text/javascript">
    $(function() {
           var tipoBusqueda = $("#<%= rdbTipoBusqueda.ClientID %> input:checked").val(); 
        $('#<%= txtAutoOdonto.ClientID %>').autocomplete({ source: '<%= ResolveUrl("~/ConsultaAmbulatoria/Services/odonto.aspx?tipoBusqueda='+tipoBusqueda+'")%>', minlenght: 3,
            focus: function(event, ui) {
                $("#<%= txtAutoOdonto.ClientID %>").val(ui.item.descripcion);
                return false;
            },
            select: function(event, ui) {
                if (ui.item.id != -666) {
                    $("#<%= txtAutoOdonto.ClientID %>").val(ui.item.descripcion);
                    $('#<%= lblNombre.ClientID %>').text(ui.item.descripcion);
                    $('#<%= lblCodigo.ClientID %>').text("(" + ui.item.codigo + ")");
                    $('#<%= lblClasificacion.ClientID %>').text(ui.item.clasificacion);
                    $("#<%= idNomenclador.ClientID %>").val(ui.item.id);
                }
                return false;
            }
        }).data("autocomplete")._renderItem = function(ul, item) {
            return $("<li></li>")
				.data("item.autocomplete", item)
				.append("<a><strong>" + item.descripcion + "</strong> (" + item.codigo + ")<br>" + item.clasificacion + "</a>")
				.appendTo(ul);
        };

        $('#hlLimpiar').button();
    });

    function LimpiarPrincipal() {
        $("#<%= txtAutoOdonto.ClientID %>").val('');
        $('#<%= lblNombre.ClientID %>').text('Ingrese nombre o codigo.');
        $('#<%= lblCodigo.ClientID %>').text('');
        $('#<%= lblClasificacion.ClientID %>').text('');
        $("#<%= idNomenclador.ClientID %>").val('');
    }
</script>

<table class="autoCompleter"> 
    <tr>
        <td>
            <asp:TextBox runat="server" ID="txtAutoOdonto" Columns="65"></asp:TextBox>
            
        </td>
        <td><asp:RadioButtonList ID="rdbTipoBusqueda" runat="server" 
                    RepeatDirection="Horizontal" AutoPostBack="True" Font-Names="Arial" 
                Font-Size="8pt">
                    <asp:ListItem Selected="True" Value="1">Que comience</asp:ListItem>
                    <asp:ListItem Value="2">Que contenga</asp:ListItem>
                </asp:RadioButtonList> </td>
        <td align="left">
            <a href="javascript:LimpiarPrincipal();" id="hlLimpiar" style="float: left;">
                <asp:Image ToolTip="Borrar" runat="server" ID="imgLimpiar" ImageAlign="AbsMiddle" ImageUrl="~/Images/usercontrols/textfield_delete.png" AlternateText="Borrar valor" /></a>
        </td>
        </tr>
      <tr>  
        <td colspan="2">
            <div id="acResult">
                <asp:HiddenField ID="idNomenclador" runat="server" />
                <asp:Label runat="server" ID="lblNombre" Text="Ingrese nombre o codigo." Font-Italic="true"></asp:Label>
                <asp:Label runat="server" ID="lblCodigo" Text=""></asp:Label><br />
                <asp:Label runat="server" ID="lblClasificacion" Text=""></asp:Label>
        
            </div>
        </td>
    </tr>
</table>
