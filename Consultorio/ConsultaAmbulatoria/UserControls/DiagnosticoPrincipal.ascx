<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DiagnosticoPrincipal.ascx.cs"  Inherits="ConsultaAmbulatoria.UserControls.DiagnosticoPrincipal" %>

<script type="text/javascript">
    $(function() {
           var tipoBusqueda = $("#<%= rdbTipoBusqueda.ClientID %> input:checked").val(); 
        $('#<%= txtAutocie10.ClientID %>').autocomplete({ source: '<%= ResolveUrl("~/ConsultaAmbulatoria/Services/cie10.aspx?tipoBusqueda='+tipoBusqueda+'")%>', minlenght: 3,
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
                    $("#<%= idCie10.ClientID %>").val(ui.item.id);
                }
                return false;
            }
        }).data("autocomplete")._renderItem = function(ul, item) {
            return $("<li></li>")
				.data("item.autocomplete", item)
				.append("<a><strong>" + item.nombre + "</strong> (" + item.codigo + ")<br>" + item.capitulo + "</a>")
				.appendTo(ul);
        };

        $('#hlLimpiar').button();
    });

    function LimpiarPrincipal() {
        $("#<%= txtAutocie10.ClientID %>").val('');
        $('#<%= lblNombre.ClientID %>').text('Ingrese nombre o codigo.');
        $('#<%= lblCodigo.ClientID %>').text('');
        $('#<%= lblCapitulo.ClientID %>').text('');
        $("#<%= idCie10.ClientID %>").val('');
    }
</script>

<table class="autoCompleter"> 
    <tr>
        <td>
            <asp:TextBox runat="server" ID="txtAutocie10" Columns="65" Width="400px"></asp:TextBox>
            
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
                <asp:HiddenField ID="idCie10" runat="server" />
                <asp:Label runat="server" ID="lblNombre" Text="Ingrese nombre o codigo." Font-Bold="True"></asp:Label>
                <asp:Label runat="server" ID="lblCodigo" Text=""></asp:Label><br />
                <asp:Label runat="server" ID="lblCapitulo" Text=""></asp:Label>
        
            </div>
        </td>
    </tr>
</table>
