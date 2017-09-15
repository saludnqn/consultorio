<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DiagnosticoSecundario.ascx.cs"
    Inherits="ConsultaAmbulatoria.UserControls.DiagnosticoSecundario" %>

<script type="text/javascript">
    $(function() {
        var tipoBusqueda = $("#<%= rdbTipoBusqueda.ClientID %> input:checked").val(); 
        
        $('#<%= txtAutocie10.ClientID %>').autocomplete({ source: '<%= ResolveUrl("~/ConsultaAmbulatoria/services/cie10.aspx?tipoBusqueda='+tipoBusqueda+'")%>', minlenght: 3,
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
        $('#hlLimpiarDiagnosticos').button();
        /*me fijo si se cargo algun diagnostico desde el backend*/
        if ($('#<%= idDiagnosticosSecundariosConNotificacion.ClientID %>').val() != "") {
            $('#Seleccion').fadeIn();
        }
    });

    function AgregarElemento() {
        var id = $('#<%= idCie10.ClientID %>').val();
        var codigo = $('#<%= lblCodigo.ClientID %>').text();
        var nombre = $('#<%= lblNombre.ClientID %>').text();
        var notificacion = $("#<%= rdbNotificacion.ClientID %> input:checked").val(); 
        var textonotificacion = 'No Informado';
        if (notificacion == 0) textonotificacion = 'No Informado';
        if (notificacion == 1) textonotificacion = 'Primera Vez';
        if (notificacion == 2) textonotificacion = 'Ulterior';

        var hl = '<a href=javascript:Eliminar(' + id + ')>Eliminar</a>';
        $('#tbCodigos tr:last').after('<tr id=' + id + '><td>' + codigo + '</td><td>' + nombre + '</td><td>'+textonotificacion+'</td><td>' + hl + '</td></tr>');
        $('#Seleccion').fadeIn();
        $('#hlAgregar').hide();
        //Agrego los diagnosticos al campo
        if ($('#<%= idDiagnosticosSecundarios.ClientID %>').val() == '') {
            $('#<%= idDiagnosticosSecundarios.ClientID %>').val($('#<%= idCie10.ClientID %>').val() );
        } else {
            $('#<%= idDiagnosticosSecundarios.ClientID %>').val($('#<%= idDiagnosticosSecundarios.ClientID %>').val() + ',' + $('#<%= idCie10.ClientID %>').val() );
        }        
        ///
        //Agrego los diagnosticos al campo
        if ($('#<%= idDiagnosticosSecundariosConNotificacion.ClientID %>').val() == '') {
            $('#<%= idDiagnosticosSecundariosConNotificacion.ClientID %>').val($('#<%= idCie10.ClientID %>').val() + ';' + $("#<%= rdbNotificacion.ClientID %> input:checked").val());
        } else {
            $('#<%= idDiagnosticosSecundariosConNotificacion.ClientID %>').val($('#<%= idDiagnosticosSecundariosConNotificacion.ClientID %>').val() + ',' + $('#<%= idCie10.ClientID %>').val() + ';' + $("#<%= rdbNotificacion.ClientID %> input:checked").val());
        }
        ///

        
        LimpiarSecundario();
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
    

    function Eliminar(id, not) {
        //alert(id + ';' + not);
        var valor1 = id + ';' + not;
        $('#' + id).remove();
        
        
        var ids = $('#<%= idDiagnosticosSecundariosConNotificacion.ClientID %>').val().split(',');
        //alert(ids);
        var newids = "";
        for (i = 0; i < ids.length; i++) {
            var valor = ids[i]; //+ ';' + not;
            if (valor != valor1) {
                if (newids == "") {
                    newids +=valor;
                } else {
                    newids += ',' +valor;
                }
            }
        }
        //alert('newids' + newids);
        $('#<%= idDiagnosticosSecundariosConNotificacion.ClientID %>').val(newids);
        if (newids == "") {
            $('#Seleccion').fadeOut();
        }
        

    }
    function LimpiarSecundario() {
        $("#<%= txtAutocie10.ClientID %>").val('');
        $('#<%= lblNombre.ClientID %>').text('Ingrese nombre o codigo.');
        $('#<%= lblCodigo.ClientID %>').text('');
        $('#<%= lblCapitulo.ClientID %>').text('');
        $("#<%= idCie10.ClientID %>").val('');
        $("#<%= lblNotificacion.ClientID %>").text('');
        $('#hlAgregar').fadeOut();
    }
</script>

<table>
    <tr>
        <td>
            <asp:TextBox runat="server" ID="txtAutocie10" Columns="65" Width="400px"></asp:TextBox>
            <asp:RadioButtonList ID="rdbTipoBusqueda" runat="server"  RepeatDirection="Horizontal" AutoPostBack="True" Font-Names="Arial" 
                Font-Size="8pt">
                    <asp:ListItem Selected="True" Value="1">Que comience</asp:ListItem>
                    <asp:ListItem Value="2">Que contenga</asp:ListItem>
                </asp:RadioButtonList>
        </td>
        <td>
        
            </td>
       <td style="vertical-align: top">
            <asp:RadioButtonList ID="rdbNotificacion" runat="server"  RepeatDirection="Horizontal" Font-Names="Arial" 
                Font-Size="8pt">
                    <asp:ListItem Selected="True" Value="0">No informado</asp:ListItem>
                    <asp:ListItem Value="1">Primera Vez</asp:ListItem>
                <asp:ListItem Value="2">Ulterior</asp:ListItem>
                </asp:RadioButtonList>
       </td>
        <td>
            <a href="javascript:LimpiarSecundario();" id="hlLimpiarDiagnosticos" style="float: left;">
                <asp:Image runat="server" ID="imgLimpiar" ImageAlign="AbsMiddle" ImageUrl="~/Images/usercontrols/textfield_delete.png" /></a>
        </td>
        </tr>
        <tr>
        <td >
            <div id="acResult">
                <asp:HiddenField ID="idCie10" runat="server" />
                <asp:Label runat="server" ID="lblNombre" Text="Ingrese nombre o codigo."></asp:Label>
                <asp:Label runat="server" ID="lblCodigo" Text=""></asp:Label><br />
                <asp:Label runat="server" ID="lblCapitulo" Text=""></asp:Label>
                 <asp:Label runat="server" ID="lblNotificacion" Text=""></asp:Label>
            </div>
        </td>
        <td>
            <a href="javascript:AgregarElemento();" id="hlAgregar" style="float: right; display: none;">
                Agregar</a>
        </td>
    </tr>
</table>
<div id="Seleccion" style="display: none">
    <asp:HiddenField ID="idDiagnosticosSecundarios" runat="server" />
    <asp:HiddenField ID="idDiagnosticosSecundariosConNotificacion" runat="server" />
    <table id="tbCodigos" class="acResult">
        <tr>
            <td>
                <b>Codigo</b>
            </td>
            <td>
                <b>Nombre</b>
            </td>
            <td>
                <b>Notificacion</b>
            </td>
            <td>
            </td>
        </tr>
        &nbsp;<br />
        <hr />
        &nbsp;<br />
        <asp:Repeater runat="server" ID="rptDiagnosticos">
            <ItemTemplate>
                <tr id='<%# Eval("CODCIE10") %>'>
                    <td>
                        <%# Eval("SysCIE10.Codigo") %>
                    </td>
                    <td>
                        <%# Eval("SysCIE10.Nombre") %>
                    </td>                 
                    <td>
                        <%# GetNotificacion(Eval("PrimerConsulta")) %>                                                                    
                    </td>             
                    
                    <td>
                        <a style="color:red" href='javascript:Eliminar(<%# Eval("CODCIE10")%>,<%#Eval("PrimerConsulta")%> )'>Eliminar</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</div>
