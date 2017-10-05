<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsistenciaEdit.aspx.cs"
    Inherits="Consultorio.Turnos.AsistenciaEdit" MasterPageFile="~/mConsultorio.Master"   UICulture="es" Culture="es-AR"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
    <link href="../Turnos.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="../js/jquery-ui-1.7.1.custom.css" />
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/jquery-ui.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">
    <br />
    <br />
    <br />
    <br />
    <table width="800px">
        <tr>
            <td align="left" class="mytituloPagina" colspan="2">
                Cierre de agenda<hr />
            </td>
        </tr>
        <tr>
            <td class="mytextoCursiva" align="left" colspan="2">
                El cierre de agenda no permitirá agregar pacientes nuevos ni modificar los turnos
                existentes. Mas de tres agendas abiertas por profesional no permitirá crear nuevas
                agendas a dicho profesional.
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label CssClass="myLabelTitulo" ID="lblTituloAgenda" runat="server" Text=""></asp:Label>
            </td>
            <td align="right">
                <asp:Label CssClass="myLabelRojoGde" ID="lblCerrada" runat="server" Visible="false"
                    Text="CERRADA"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label CssClass="myLabelIzquierda" ID="lblFechaAgenda" runat="server" Text=""></asp:Label>
                &nbsp;<asp:Label CssClass="myLabelIzquierda" ID="lblHoraAgenda" runat="server" Text=""></asp:Label>
            </td>
            <td align="right">
                <asp:LinkButton ID="lnkMarcar" CssClass="myLink" runat="server" OnClick="lnkMarcar_Click">Marcar Todos</asp:LinkButton>&nbsp;&nbsp;
                <asp:LinkButton ID="lnkDesMarcar" CssClass="myLink" runat="server" OnClick="lnkDesMarcar_Click">Desmarcar Todos</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top;" colspan="2">
                <asp:GridView ID="gvTurnos" runat="server" AutoGenerateColumns="False" CellPadding="6"
                    Width="100%" DataKeyNames="idTurno" ForeColor="#333333" OnRowDataBound="gvTurnos_RowDataBound"
                     Font-Names="Calibri" Font-Size="10pt"
                    EmptyDataText="La agenda seleccionada no tiene turnos generados." CellSpacing="4"
                    BorderColor="#666666" BorderStyle="Solid" BorderWidth="2px" CssClass="myLabelIzquierda">
                    <PagerStyle Font-Underline="True" HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" Height="30px" />
                    <EmptyDataRowStyle ForeColor="#CC3300" />
                    <Columns>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:Image ID="imgTurno" runat="server" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField Visible="false" DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}"
                            HeaderText="Fecha">
                            <HeaderStyle HorizontalAlign="Justify" />
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Hora" HeaderText="Hora">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DNI" HeaderText="DNI">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HC" HeaderText="HC">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Paciente" HeaderText="Paciente">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Justify" Width="55%" />
                        </asp:BoundField>
                        <%-- <asp:TemplateField>
                    <ItemTemplate>
                      <asp:ImageButton ID="cmdSelTurno" runat="server" AlternateText="seleccionar" 
                        CommandName="Select" 
                        ImageUrl="~/App_Themes/consultorio/Agenda/seleccionar.png" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                  </asp:TemplateField>--%>
                        <asp:BoundField DataField="usuario" HeaderText="Asig. por">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Width="15%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Asistencia">
                            <ItemTemplate>
                                <asp:CheckBox Font-Bold="true" ID="CheckBox1" runat="server" EnableViewState="true" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Consulta" HeaderText="Con Diagnostico" />
                    </Columns>
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
            <td align="right">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                <a href="javascript:history.back()">Regresar</a>
            </td>
            <td align="right">
                <asp:Button ID="btnGuardarAsistencia" runat="server" CssClass="myButton" OnClick="btnGuardarAsistencia_Click"
                    Text="Guardar y Cerrar Agenda" Width="160px" />
            </td>
        </tr>
    </table>
    <!-- capa externa !-->
</asp:Content>
