<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="seleccionarInterconsulta.aspx.cs"
    Inherits="Consultorio.Turnos.TurnosProtegidos.seleccionarInterconsulta" MasterPageFile="~/mConsultorio.Master" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Superior" runat="server">
    <link href="../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="../js/jquery-ui-1.7.1.custom.css" />

    <script type="text/javascript" src="../js/jquery.min.js"></script>

    <script type="text/javascript" src="../js/jquery-ui.min.js"></script>

    <script type="text/javascript" src="../js/jquery.ui.datepicker-es.js"></script>

    <script type="text/javascript" src="../js/Mascara.js"></script>

    <script type="text/javascript" src="../js/ValidaFecha.js"></script>

    <style type="text/css">
        .style1 {
            width: 115px;
            text-align: left;
        }

        .style2 {
            width: 80px;
        }

        .style3 {
            width: 235px;
        }

        .style4 {
            text-align: left;
        }

        .style5 {
            width: 80px;
            text-align: left;
        }

        .auto-style1 {
            width: 207%;
        }

        .auto-style4 {
            height: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Cuerpo" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <hr class="hrTitulo" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Font-Bold="True"
                    Text="Seleccionar interconsulta"></asp:Label>
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
                            <table class="auto-style1">
                                <tr>
                                    <td class="auto-style4">
                                        <asp:Label ID="lblDatosPaciente" runat="server"></asp:Label>
                                    </td>
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
        <tr align="left">
            <td align="left">
                <table align="center" style="width: 95%;">
                    <tr>
                        <td align="left">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvListaInterconsultasDelPaciente" runat="server" AllowPaging="True"
                                AutoGenerateColumns="False" CellPadding="5" DataKeyNames="idInterconsulta"
                                EmptyDataText="No se encontraron datos para los filtros ingresados"
                                EnableTheming="True" Font-Bold="False" Font-Names="Arial" Font-Size="13pt"
                                ForeColor="#333333" OnPageIndexChanging="gvListaInterconsultasDelPaciente_PageIndexChanging"
                                OnRowCommand="gvListaInterconsultasDelPaciente_RowCommand"
                                OnRowDataBound="gvListaInterconsultasDelPaciente_RowDataBound" Width="60%">
                                <RowStyle BackColor="#F7F6F3" Font-Names="Arial" Font-Size="10pt"
                                    ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="idInterconsulta" HeaderText="idInterconsulta" Visible="False">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="seleccionarInterconsulta" runat="server" ImageUrl="~/App_Themes/turnosProtegidos/images/seleccionar.png"
                                                CommandName="seleccionarInterconsulta" />
                                        </ItemTemplate>
                                        <ItemStyle Width="16px" HorizontalAlign="Center" Height="16px" />
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="idInterconsulta" HeaderText="idInterconsulta" Visible="False" />
                                    <asp:BoundField DataField="idPaciente" HeaderText="idPaciente" Visible="False" />
                                    <asp:BoundField DataField="fechaSolicitud" HeaderText="Fecha de solicitud" />
                                    <asp:BoundField DataField="medicosDestinatarios" HeaderText="Médicos destinatarios" Visible="True" />

                                </Columns>
                                <FooterStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#507cd1" ForeColor="White" HorizontalAlign="Right" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#507cd1" Font-Bold="False" Font-Italic="False"
                                    Font-Names="Arial" Font-Size="10pt" ForeColor="White" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    </table>
            </td>
        </tr>
    </table>
</asp:Content>




