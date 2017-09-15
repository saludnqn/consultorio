<%@ Page Language="C#" MasterPageFile="~/ControlMenor/MasterPages/ControlMenor.master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SIPS.ControlMenor.CalendarioVacunacion.Default"
    Title="" Theme="apr" %>

<%@ Register Src="../../UserControls/CalendarioVacunacion.ascx" TagName="CalendarioVacunacion" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $().ready(function() {
            $('#calendario').dialog({ autoOpen: false, minWidth: 800, minHeigth: 500, title: 'Calendario de Vacunacion' });
        });
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Cuerpo" runat="server">
    <%-- "Grilla" con las intervenciones --%>
    <asp:Repeater ID="rptVacunaciones" runat="server">
        <HeaderTemplate>
            <table id="tblVacunaciones" cellpadding="0" cellspacing="0" border="0" class="display grilla">
                <thead>
                    <tr>
                        <th>
                        </th>
                        <th>
                            Fecha Aplicación
                        </th>
                        <th>
                            Edad Aplicación
                        </th>
                        <th>
                            Vacuna
                        </th>
                        <th>
                            Dosis
                        </th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:HyperLink runat="server" ID="hlEditar" NavigateUrl='<%# String.Format("Edit.aspx?idPaciente={0}&id={1}",Eval("idPaciente"),Eval("idAplicacionVacuna")) %>'
                        Text="Editar">
                    </asp:HyperLink>
                </td>
                <td>
                    <%# Eval("FechaAplicacion") %>
                </td>
                <td>
                    <%# Eval("EdadAplicacion") %>
                </td>
                <td>
                    <%--<%# Eval("SysMedicamento.Nombre") %>--%>
                    <%# Eval("NombreVacuna") %>
                </td>
              <%--  <td>
                    <%# Eval("Estado") %>
                </td>--%>
                  <td>
                    <%# Eval("Dosis") %>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody> </table>
        </FooterTemplate>
    </asp:Repeater>
    <div id="calendario">
        <uc1:CalendarioVacunacion ID="CalendarioVacunacion1" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Botones" runat="server">
    <asp:Button runat="server" ID="btnNuevo" Text="Nuevo" OnClick="btnNuevo_Click" />
    <asp:Button runat="server" ID="btnCalendario" Text="Calendario de Vacunas" OnClientClick="javascript:$('#calendario').dialog('open');return false;" />
</asp:Content>
