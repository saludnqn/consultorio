<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mostrarTurnoPaciente.aspx.cs"
    Inherits="Consultorio.Turnos.TurnosProtegidos.mostrarTurnoPaciente" MasterPageFile="~/mConsultorio.Master"%>

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
                    Text="Turno" Font-Size="Medium"></asp:Label>
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
                            <table class="auto-style1" style="width: 200px;">
                                <tr>
                                    <td>
                                        <table class="auto-style1" style="width: 550px;">
                                            <tr>
                                                <td class="auto-style2" colspan="3">
                                                                    <asp:Panel ID="Panel1" runat="server" BorderWidth="5px">
                                                                        <table style="width:100%;">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblDatosPaciente" runat="server" Font-Size="Medium"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblTurnoOtrosDatos" runat="server" Font-Size="Medium"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style2">
                                                                    &nbsp;</td>
                                                <td class="auto-style2">
                                                    &nbsp;</td>
                                                <td class="auto-style2">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style2">
                                                                    <asp:Button ID="btnCerrar" runat="server" Font-Size="Medium" OnClick="btnCerrar_Click" Text="Cerrar" />
                                                </td>
                                                <td class="auto-style2">
                                                    &nbsp;</td>
                                                <td class="auto-style2">
                                                    &nbsp;</td>
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
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

