<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="turnosDisponibles.aspx.cs"
    Inherits="Consultorio.Turnos.TurnosProtegidos.turnosDisponibles" MasterPageFile="~/mConsultorio.Master"%>

<asp:Content ID="Content3" ContentPlaceHolderID="Superior" runat="server">
    <link href="../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="../js/jquery-ui-1.7.1.custom.css" />

    <script type="text/javascript" src="../js/jquery.min.js"></script>

    <script type="text/javascript" src="../js/jquery-ui.min.js"></script>

    <script type="text/javascript" src="../js/jquery.ui.datepicker-es.js"></script>

    <script type="text/javascript" src="../js/Mascara.js"></script>

    <script type="text/javascript" src="../js/ValidaFecha.js"></script>

    <style type="text/css">        
        .style1
        {
            width: 115px;
            text-align: left;
        }
        .style2
        {
            width: 80px;
        }
    .style3
    {
        width: 235px;
    }
        .style4
        {
            text-align: left;
        }
        .style5
        {
            width: 80px;
            text-align: left;
        }
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Cuerpo" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <hr class="hrTitulo" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Font-Bold="True" 
                    Text="Turnos disponibles"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <hr class="hrTitulo" />
            </td>
        </tr>
        <tr>
            <td>
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 358px" valign="top">
                            <br />
                            <table class="auto-style1" style="width: 300px;">
                                <tr>
                                    <td>
                                        <table class="auto-style1" style="width: 550px;">
                                            <tr>
                                                <td class="auto-style2">
                                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Paciente"></asp:Label>
                                                </td>
                                                <td class="auto-style2">
                                                    &nbsp;</td>
                                                <td class="auto-style2">
                                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Otros datos"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style2">
                                                                    <asp:Label ID="lblDatosPaciente" runat="server"></asp:Label>
                                                </td>
                                                <td class="auto-style2">
                                                    &nbsp;</td>
                                                <td class="auto-style2">
                                                    <asp:Label ID="lblOtrosDatos" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <hr class="hrTitulo" />
            </td>
        </tr>
        <tr align="center">
            <td align="center">
                <table align="center" style="width: 95%;">
                    <tr>
                        <td align="right">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:GridView ID="gvListaTurnosDisponiblesHeller" 
                                runat="server" AutoGenerateColumns="False"
                                CellPadding="10" DataKeyNames="idTurno" EmptyDataText="No se encontraron datos para los filtros ingresados"
                                EnableTheming="True" Font-Bold="False" Font-Names="Arial" Font-Size="13pt" ForeColor="#333333"
                                OnRowCommand="gvListaTurnosDisponiblesHeller_RowCommand" OnRowDataBound="gvListaTurnosDisponiblesHeller_RowDataBound" Width="20%" 
                                PageSize="15">
                                <RowStyle BackColor="#F7F6F3" Font-Names="Arial" Font-Size="10pt" ForeColor="#333333" />
                                <Columns>

                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="Seleccionar" runat="server" ImageUrl="~/App_Themes/turnosProtegidos/images/reporte.png"
                                                CommandName="Seleccionar" />
                                        </ItemTemplate>
                                        <ItemStyle Width="16px" HorizontalAlign="Center" Height="16px" />
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="idTurno" HeaderText="idTurno" Visible="False" />
                                    <asp:BoundField DataField="hora" HeaderText="Hora" />
                                    <asp:BoundField DataField="fecha" HeaderText="Fecha" />

                                </Columns>
                                <EmptyDataRowStyle ForeColor="Black" />
                                <FooterStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#507cd1" ForeColor="White" HorizontalAlign="Right" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#507cd1" Font-Bold="False" Font-Italic="False" Font-Names="Arial"
                                    Font-Size="10pt" ForeColor="White" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                        </td>
                    </tr>

                    <tr>
                        <td align="left">
                            <asp:GridView ID="gvListaTurnosDisponiblesDistintoHeller" 
                                runat="server" AutoGenerateColumns="False"
                                CellPadding="10" DataKeyNames="idTabla" EmptyDataText="No se encontraron datos para los filtros ingresados"
                                EnableTheming="True" Font-Bold="False" Font-Names="Arial" Font-Size="13pt" ForeColor="#333333"
                                OnRowCommand="gvListaTurnosDisponiblesDistintoHeller_RowCommand" OnRowDataBound="gvListaTurnosDisponiblesDistintoHeller_RowDataBound" Width="20%" 
                                PageSize="15">
                                <RowStyle BackColor="#F7F6F3" Font-Names="Arial" Font-Size="10pt" ForeColor="#333333" />
                                <Columns>

                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="Seleccionar" runat="server" ImageUrl="~/App_Themes/turnosProtegidos/images/reporte.png"
                                                CommandName="Seleccionar" />
                                        </ItemTemplate>
                                        <ItemStyle Width="16px" HorizontalAlign="Center" Height="16px" />
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="idTabla" HeaderText="idTabla" Visible="False" />
                                    <asp:BoundField DataField="hora" HeaderText="Hora" />
                                    <asp:BoundField DataField="fecha" HeaderText="Fecha" />

                                </Columns>
                                <EmptyDataRowStyle ForeColor="Black" />
                                <FooterStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#507cd1" ForeColor="White" HorizontalAlign="Right" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#507cd1" Font-Bold="False" Font-Italic="False" Font-Names="Arial"
                                    Font-Size="10pt" ForeColor="White" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                        </td>
                    </tr>

                </table>
            </td>
        </tr>
    </table>
</asp:Content>

