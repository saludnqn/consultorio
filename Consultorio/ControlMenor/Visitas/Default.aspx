<%@ Page Title="" Language="C#" MasterPageFile="~/ControlMenor/MasterPages/ControlMenor.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SIPS.ControlMenor.Visitas.Default"
    Theme="apr" %>

<%@ Register src="../UserControls/CurvasCrecimiento.ascx" tagname="CurvasCrecimiento" tagprefix="cc" %>

<%-- A la cabecera --%>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <%-- Tooltips! --%>

    <script type="text/javascript">
        $(document).ready(function() {
            $('.grillaConFecha').dataTable({
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

            $('.tootipeable').tooltip({
                position: "bottom center",
                offset: [10, -2],
                effect: 'fade',
                opacity: 0.7
            });

            $('#curvas').dialog({ autoOpen: false, minWidth: 910, minHeigth: 500, title: 'Curvas de Crecimiento' });
        });
    </script>

</asp:Content>
<%-- Contenido principal --%>
<asp:Content ID="Content1" ContentPlaceHolderID="Cuerpo" runat="server">
    <asp:ScriptManagerProxy runat="server" ID="smp">
        <Scripts>
            <asp:ScriptReference Path="~/js/tooltips/jquery.tools.min.js" />
        </Scripts>
    </asp:ScriptManagerProxy>
    <%-- "Grilla" con los controles --%>
    <asp:Repeater ID="rptControles" runat="server">
        <HeaderTemplate>
            <table id="tblControles" cellpadding="0" cellspacing="0" border="0" class="display grillaConFecha">
                <thead>
                    <tr>
                        <th>
                        </th>
                        <th>
                            Fecha
                        </th>
                        <th>
                            Diagnóstico
                        </th>
                        <th>
                            Peso
                        </th>
                        <th>
                            Talla
                        </th>
                        <th>
                            Perímetro cefálico
                        </th>
                        <th>
                            Estado Nutricional
                        </th>
                        <th>
                            Lactancia
                        </th>
                        <th>
                            Profesional
                        </th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                <asp:HyperLink runat="server" ID="hlEditar" NavigateUrl='<%# String.Format("View.aspx?idPaciente={0}&idControl={1}&idConsulta={2}",Eval("idPaciente"),Eval("idControlNiñoSano"),Eval("idConsulta")) %>'
                        Text="Ver">
                    </asp:HyperLink>
                    <asp:HyperLink runat="server" ID="HyperLink1" NavigateUrl="" Text="Editar">
                    </asp:HyperLink> 
                </td>
                <td>
                    <%# Eval("Fecha", "{0:yyyy-MM-dd}") %>
                    <%# Eval("Hora") %>
                </td>
                <td title="<%# Eval("NombreDiagnostico") %>">
                    <%# Eval("CodigoCIE10") %>
                </td>
                <td>
                   <%# string.Concat(Eval("Peso"), " Kg") %>
                   <%-- <%# Eval("Peso").ToString().Length > 0 ? Eval("Peso") + " Kg." : ""%>--%>
                </td>
                <td>
                    <%# string.Concat(Eval("Talla"), " m") %>
                </td>
                <td>
                    <%# string.Concat(Eval("PerimetroCefalico"), " cm") %>
                </td>
                <td>
                    <%# Eval("EstadoNutricional") %>
                </td>
                <td>
                    <%# Eval("TipoLactancia") %>
                </td>
                <td>
                    <%# Eval("ApellidosProfesional") %>,
                    <%# Eval("NombresProfesional") %>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody> </table>
        </FooterTemplate>
    </asp:Repeater>
    <div id="curvas">
        <cc:CurvasCrecimiento ID="CurvasCrecimiento1" runat="server" />
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="Botones" runat="server">
    <asp:Button ID="btnCurvas" Text="Curvas" runat="server" />
    <asp:Button ID="btnNuevo" Text="Nueva Visita" runat="server" OnClick="btnNuevo_Click" />
    <asp:Button runat="server" ID="btnCurvasCrecimiento" Text="Curvas Crecimiento" OnClientClick="javascript:$('#curvas').dialog('open');return false;" />
</asp:Content>
