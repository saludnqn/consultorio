<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TurnoComprobante.aspx.cs" Inherits="Consultorio.Turnos.TurnoComprobante" MasterPageFile="~/mConsultorio.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Turnos.css" rel="stylesheet" type="text/css" />
    <%--  <link href="../../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />--%>
    <link type="text/css" rel="stylesheet" href="../../js/jquery-ui-1.7.1.custom.css" />
    <script type="text/javascript" src="../../js/jquery.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.ui.datepicker-es.js"></script>
    <script type="text/javascript" src="../../js/Mascara.js"></script>
    <script type="text/javascript" src="../../js/ValidaFecha.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">

    <br />
    <br />
    <br />
    <br />
    <table style="width: 500px; border: 1px double #999999;">


        <tr>
            <td class="myLabelIzquierda" style="text-align: left;" colspan="2">TURNO GENERADO<hr />

            </td>


        </tr>
        <tr>
            <td class="myLabelIzquierda" align="right">Paciente:</td>
            <td style="text-align: left;">
                <asp:Label ID="lblComprobante" runat="server" Text="" Visible="false" CssClass="myLabelRojo"></asp:Label>

                <asp:Label ID="lblPaciente" runat="server" Text="Label" CssClass="myLabelTitulo"></asp:Label>

            </td>


        </tr>
        <tr>

            <td class="myLabelIzquierda" align="right">Fecha y Hora:</td>

            <td style="text-align: left;">
                <asp:Label ID="lblComprobanteFecha" runat="server" Text="" CssClass="myLabelIzquierda"></asp:Label>
                <asp:Label ID="lblComprobanteBloque" runat="server" Text="" CssClass="myLabelIzquierda"></asp:Label>
                &nbsp;</td>
        </tr>

        <tr>
            <td class="myLabelIzquierda" align="right">Profesional:</td>
            <td align="left">
                <asp:ListView ID="lstProfesionales" runat="server">
                    <ItemTemplate>
                        <asp:Label Text="<%#Container.DataItem %>" CssClass="myLabelTitulo" runat="server" />
                    </ItemTemplate>
                </asp:ListView>
                <asp:Label ID="lblComprobanteProfesional" runat="server" Text="" CssClass="myLabelIzquierda"></asp:Label>
            </td>
        </tr>

        <tr>
            <td class="myLabelIzquierda" align="right">Especialidad:</td>
            <td align="left">
                <asp:Label ID="lblComprobanteEspecialidad" runat="server" Text="" CssClass="myLabelIzquierda"></asp:Label>

            </td>
        </tr>

        <tr>
            <td class="myLabelIzquierda" align="right">Consultorio:</td>
            <td align="left">
                <asp:Label ID="lblComprobanteConsultorio" runat="server" Text="" CssClass="myLabelIzquierda"></asp:Label>
            </td>
        </tr>

        <tr>
            <td align="right">&nbsp;</td>
            <td align="right">
                <asp:ImageButton Visible="false" ID="imgImprimir" runat="server" ToolTip="Imprimir Comprobante"
                    ImageUrl="~/App_Themes/consultorio/images/imprimir.jpg" />

            </td>
        </tr>

        <tr>

            <td colspan="2">
                <hr />
            </td>

        </tr>

        <tr>

            <td colspan="2">

                <asp:Button ID="btnContinuar" runat="server" Text="Continuar" CssClass="myButtonRojo" Width="120px"
                    OnClick="btnContinuar_Click" />
                &nbsp; &nbsp; &nbsp; &nbsp;
                            
                             <asp:Button ID="btnTerminar" runat="server" Text="Terminar" CssClass="myButtonRojo" Width="120px"
                                 OnClick="btnTerminar_Click" />


            </td>
        </tr>
    </table>


</asp:Content>
