<%@ Page Title="" Language="C#" MasterPageFile="~/ControlMenor/MasterPages/Reportes.master"
    Theme="apr" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SIPS.ControlMenor.Reportes.Visitas.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href='<%= ResolveUrl("~ControlMenor/css/ui.daterangepicker.css") %>' rel="stylesheet"
        type="text/css" />

    <script type="text/javascript">
        $().ready(function() {
            $('#<%= txtRango.ClientID %>').daterangepicker({
                doneButtonText: 'Terminado',
                dateFormat: 'dd/mm/yy',
                presets: { specificDate: 'Dia especifico', dateRange: 'Rango de fechas' },
                presetRanges: [
            { text: 'Hoy', dateStart: 'Today', dateEnd: 'Today' },
            { text: 'Ayer', dateStart: 'Yesterday', dateEnd: 'Yesterday' },
            { text: 'Este Mes', dateStart: function() { return Date.today().moveToFirstDayOfMonth(); }, dateEnd: 'Today' },
            { text: 'El Mes anterior', dateStart: function() { return (1).months().ago().moveToFirstDayOfMonth(); }, dateEnd: function() { return (-1).months().fromNow().moveToLastDayOfMonth(); } },
            { text: 'Este Año', dateStart: function() { return Date.today(); }, dateEnd: 'Today' }
            ]
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Cuerpo" runat="server">
    <asp:ScriptManagerProxy ID="smp" runat="server">
        <Scripts>
            <%--            <asp:ScriptReference Path="~/ControlMenor/js/date.js" />
            <asp:ScriptReference Path="~/ControlMenor/js/date-es-AR.js" />--%>
            <asp:ScriptReference Path="~/ControlMenor/js/daterangepicker.jQuery.js" />
        </Scripts>
    </asp:ScriptManagerProxy>
    <table class="formulario">
        <tr>
            <td>
                <asp:Label runat="server" ID="lblRango" AssociatedControlID="lblRango" Text="Fechas"></asp:Label>
                <asp:TextBox runat="server" ID="txtRango" CssClass="fixedWith"></asp:TextBox>
                <asp:Button runat="server" ID="btnFiltrar" Text="Filtrar" OnClick="btnFiltrar_Click" />
            </td>
        </tr>
    </table>
    <asp:Repeater ID="rptControles" runat="server">
        <HeaderTemplate>
            <table id="tblControles" cellpadding="0" cellspacing="0" border="0" class="display grilla">
                <thead>
                    <tr>
                        <th>
                            Fecha
                        </th>
                        <th>
                            Paciente
                        </th>
                        <th>
                            Edad
                        </th>
                        <th>
                            Peso
                        </th>
                        <th>
                            Talla
                        </th>
                        <th>
                            Perimetro cefalico
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
                    <%# Eval("Fecha","{0:yyyy-MM-dd}") %>
                    <%# Eval("Hora") %>
                </td>
                <td>
                    <%# Eval("ApellidosPaciente") %>,
                    <%# Eval("NombresPaciente") %>
                </td>
                <td>
                    <%# new SIPS.Utilidades.DateDifference(Convert.ToDateTime(Eval("FechaNacimiento")),Convert.ToDateTime(Eval("Fecha"))).ToString() %>
                </td>
                <td>
                    <%# Eval("Peso","{0} gr.") %>
                </td>
                <td>
                    <%# Eval("Talla","{0} cm.") %>
                </td>
                <td>
                    <%# Eval("PerimetroCefalico","{0} cm.") %>
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
</asp:Content>
