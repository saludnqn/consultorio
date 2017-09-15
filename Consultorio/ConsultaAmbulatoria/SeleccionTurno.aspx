<%@ Page Title="" Language="C#" MasterPageFile="~/ConsultaAmbulatoria/MasterPages/Consultorio.master"
    AutoEventWireup="true" CodeBehind="SeleccionTurno.aspx.cs" Inherits="Consultorio.ConsultaAmbulatoria.SeleccionTurno"
    Theme="apr" %>

<%@ MasterType VirtualPath="~/ConsultaAmbulatoria/MasterPages/Consultorio.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
                "aaSorting": [[1, "desc"]],
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
        });
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Cuerpo" runat="server">
    <asp:ScriptManagerProxy runat="server" ID="smp">
        <Scripts>
            <asp:ScriptReference Path="~/js/tooltips/jquery.tools.min.js" />
        </Scripts>
    </asp:ScriptManagerProxy>
    <table class="formulario">
        <tr>
            <td>
                <fieldset class="ui-widget ui-widget-content ui-corner-all">
                    <legend>Tipo de Consulta</legend>
                    <table class="formulario">
                        <tr>
                            <asp:Repeater runat="server" ID="rptControles" OnItemCommand="rptControles_ItemCommand">
                              <%--  <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Button runat="server" ID="lbTipoConsulta" CommandArgument='<%# Eval("Url") %>'
                                                CommandName="RealizarConsulta" Text="Seleccionar" Enabled='<%# Eval("Enabled") %>'
                                                CssClass='<%# Eval("CssClass") %>'></asp:Button>
                                            <asp:Literal runat="server" ID="ltTipoConsulta" Text='<%# Eval("Texto") %>'></asp:Literal>
                                        </td>
                                </ItemTemplate>
                                <AlternatingItemTemplate>--%>
                                <ItemTemplate>
                                    <td style="width: 20px">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:Button runat="server" ID="lbTipoConsulta" CommandArgument='<%# Eval("Url") %>'
                                            CommandName="RealizarConsulta" Text="Seleccionar" Enabled='<%# Eval("Enabled") %>'
                                            CssClass='<%# Eval("CssClass") %>'></asp:Button>
                                        <asp:Literal runat="server" ID="ltTipoConsulta" Text='<%# Eval("Texto") %>'></asp:Literal>
                                    </td>
                                    </tr>
                                    </ItemTemplate>
                               <%-- </AlternatingItemTemplate>--%>
                            </asp:Repeater>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
<%--    <table class="formulario">
        <tr>
            <td>
                <div style="text-align: center">
                    <fieldset class="ui-widget ui-widget-content ui-corner-all">
                        <legend>Consulta de Enfermería</legend>
                        <br />
                        <asp:HyperLink ID="hlEnfermeria" runat="server" Visible="false">Control de Enfermería</asp:HyperLink>
                    </fieldset>
                </div>
            </td>
        </tr>
    </table>
    <table class="formulario">
        <tr>
            <td>
                <fieldset class="ui-widget ui-widget-content ui-corner-all">
                    <legend>Últimos Controles de Enfermería</legend>
                    <asp:Repeater ID="rptEnfermeria" runat="server">
                        <HeaderTemplate>
                            <table id="tblControlesE" cellpadding="0" cellspacing="0" border="0" class="display grillaConFecha">
                                <thead>
                                    <tr>
                                        <th>
                                            Control
                                        </th>
                                        <th>
                                            Peso
                                        </th>
                                        <th>
                                            Talla
                                        </th>
                                        <th>
                                            P. Cefálico
                                        </th>
                                        <th>
                                            E. Nutricional
                                        </th>
                                        <th>
                                            Efector
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# Eval("FechaControl") %>
                                </td>
                                <td>
                                    <%# string.Concat(Eval("Peso"), " Kg") %>
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
                                    <%# Eval("Efector") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody> </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </fieldset>
            </td>
        </tr>
    </table>--%>
    <table class="formulario">
        <tr>
            <td>
                <fieldset class="ui-widget ui-widget-content ui-corner-all">
                    <legend>Últimas Visitas en Consultorio</legend>
                    <asp:Repeater ID="rptVisitas" runat="server" OnItemDataBound="rptVisitas_ItemDataBound">
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
                                        <%-- <th>
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
                                        </th>--%>
                                        <th>
                                            Profesional
                                        </th>
                                        <th>
                                            Efector
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HyperLink runat="server" ID="hlVer" NavigateUrl='<%# String.Format("View.aspx?idPaciente={0}&idControl={1}&idConsulta={2}",Eval("idPaciente"),Eval("idControlNiñoSano"),Eval("idConsulta")) %>'
                                        Text="Ver">
                                    </asp:HyperLink>
                                    <asp:HyperLink runat="server" ID="hlEditar" NavigateUrl="" Text="Editar">
                                    </asp:HyperLink>
                                </td>
                                <td>
                                    <%# Eval("Fecha", "{0:yyyy-MM-dd}") %>
                                    <%-- <%# Eval("Hora") %>--%>
                                </td>
                                <td title="<%# Eval("NombreDiagnostico") %>" class="tootipeable">
                                    <%# Eval("CodigoCIE10") %>
                                </td>
                                <%-- <td>
                                    <%# Eval("Peso").ToString().Length > 0 ? Eval("Peso") + " grs." : ""%>
                                </td>
                                <td>
                                    <%# Eval("Talla") %>
                                </td>
                                <td>
                                    <%# Eval("PerimetroCefalico") %>
                                </td>
                                <td>
                                    <%# Eval("EstadoNutricional") %>
                                </td>
                                <td>
                                    <%# Eval("TipoLactancia") %>
                                </td>--%>
                                <td>
                                    <%# Eval("ApellidosProfesional") %>,
                                    <%# Eval("NombresProfesional") %>
                                </td>
                                <td>
                                    <%# Eval("Efector") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody> </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </fieldset>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content runat="server" ID="btn" ContentPlaceHolderID="Botones">
    <asp:Button runat="server" ID="btnVolver" Text="Volver al Paciente" OnClick="btnVolver_Click" />
    <input type="button" value="Volver" onclick="history.go(-1)" />
</asp:Content>
