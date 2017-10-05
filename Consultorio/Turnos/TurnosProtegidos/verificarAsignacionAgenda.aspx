<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="verificarAsignacionAgenda.aspx.cs"
    Inherits="Consultorio.Turnos.TurnosProtegidos.verificarAsignacionAgenda"  MasterPageFile="~/mConsultorio.Master"%>

<asp:Content ID="Content3" ContentPlaceHolderID="Superior" runat="server">
    <link href="../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="../../js/jquery-ui-1.7.1.custom.css" />

    <script type="text/javascript" src="../../js/jquery.min.js"></script>

    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>

    <script type="text/javascript" src="../../js/jquery.ui.datepicker-es.js"></script>

    <script type="text/javascript" src="../../js/Mascara.js"></script>

    <script type="text/javascript" src="../../js/ValidaFecha.js"></script>

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
            width: 358px;
            height: 14px;
        }
        .auto-style2 {
            width: 358px;
            height: 42px;
        }
        .auto-style3 {
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
                <hr class="hrTitulo" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Font-Bold="True" 
                    Text="Mensaje para el usuario"></asp:Label>
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
                        <td valign="top" class="auto-style2">
                            <br />
                            <table style="width:197%;">
                                <tr>
                                    <td class="auto-style3">
                                        <asp:Label ID="lblMensajeAlUsuario" runat="server">El paciente ya tiene un turno en esta agenda !</asp:Label>
                                        </br></br>
                                        <input type="button" value="Otra agenda" onclick="history.go(-1)"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="auto-style1">
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
                        <td align="right" class="auto-style3">
                            </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

