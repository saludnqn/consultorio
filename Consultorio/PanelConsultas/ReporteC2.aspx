<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteC2.aspx.cs" Inherits="Consultorio.PanelConsultas.ReporteC2"
    MasterPageFile="~/mConsultorio.Master"   UICulture="es" Culture="es-AR"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Subsonic" Namespace="SubSonic" TagPrefix="subsonic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Turnos.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="../js/jquery-ui-1.7.1.custom.css" />
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../js/jquery.ui.datepicker-es.js"></script>

    <script src="../js/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="../js/jquery-ui.js" type="text/javascript"></script>

    <script type="text/javascript">

        $(function () {
            $("#<%=txtDesde.ClientID %>").datepicker({
                showOn: 'button',
                dateFormat: 'dd/mm/yy',
                buttonImage: '../App_Themes/consultorio/images/calend1.jpg',
                buttonImageOnly: true
            });
        });

        $(function () {
            $("#<%=txtHasta.ClientID %>").datepicker({
                showOn: 'button',
                dateFormat: 'dd/mm/yy',
                buttonImage: '../App_Themes/consultorio/images/calend1.jpg',
                buttonImageOnly: true
            });
        }); 
     
    </script>
    <style type="text/css">
        .style7
        {
            width: 1%;
        }
        .style9
        {
            width: 36%;
        }
        .style10
        {
            width: 18%;
        }
        .style11
        {
            border-style: none;
            font-size: 10pt;
            font-family: Calibri;
            background-color: #FFFFFF;
            color: #333333;
            font-weight: bold;
            width: 71px;
        }
        .style12
        {
            width: 35%;
        }
        .auto-style1 {
            border-style: none;
            font-size: 10pt;
            font-family: Calibri;
            background-color: #FFFFFF;
            color: #333333;
            font-weight: bold;
            width: 102px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">
    <br />
    &nbsp;
    <br />
    <br />
    &nbsp;
    <br />
    <div style="width: 1000px;">
        <table width="100%">
            <tr>
                <td align="left" class="style7">
                    &nbsp;
                </td>
                <td class="myLink" align="left" colspan="2">
                    <asp:LinkButton ID="lnkRegresar" runat="server" OnClick="lnkRegresar_Click">Regresar</asp:LinkButton>
                </td>
                <td class="myLink" align="left">
                    &nbsp;
                </td>
                <td class="myLink" align="left">
                    &nbsp;
                </td>
                <td align="right" style="font-size: 10pt; font-family: Arial, Helvetica, sans-serif;
                    color: #287ED5; font-weight: normal;" class="style7">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" class="style7">
                    &nbsp;
                </td>
                <td class="mytituloPagina" align="left" colspan="2">
                    &nbsp;
                </td>
                <td class="mytituloPagina" align="left">
                    &nbsp;
                </td>
                <td class="mytituloPagina" align="left">
                    &nbsp;
                </td>
                <td align="right" style="font-size: 10pt; font-family: Arial, Helvetica, sans-serif;
                    color: #287ED5; font-weight: normal;" class="style7">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" class="style7">
                    &nbsp;
                </td>
                <td class="mytituloPagina" align="left" colspan="2">
                    REPORTE C2
                </td>
                <td class="mytituloPagina" align="left">
                    &nbsp;
                </td>
                <td class="mytituloPagina" align="left">
                    &nbsp;
                </td>
                <td align="right" style="font-size: 10pt; font-family: Arial, Helvetica, sans-serif;
                    color: #287ED5; font-weight: normal;" class="style7">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" class="style7">
                    &nbsp;
                </td>
                <td class="mytituloPagina" align="left" colspan="5">
                    <hr />
                </td>
            </tr>
            <asp:Panel ID="pnlEfector" runat="server">
                <tr>
                    <td align="right" class="style18">
                        &nbsp;
                    </td>
                    <td align="right" class="myLabelIzquierda" colspan="1">
                        Efector:
                    </td>
                    <td class="myLabelIzquierda" align="left">
                        <asp:DropDownList ID="ddlZona" runat="server" OnSelectedIndexChanged="ddlZona_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlEfector" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
            </asp:Panel>
            <tr>
                <td align="right" class="style7">
                    &nbsp;
                </td>
                <td align="right" class="auto-style1">
                    Fecha desde:
                </td>
                <td align="left" class="style12">
                    <asp:TextBox ID="txtDesde" runat="server" Width="70px"></asp:TextBox>
                </td>
                <td align="left" class="style9">
                    &nbsp;
                </td>
                <td align="left" class="style10">
                    &nbsp;
                </td>
                <td align="right" class="style7">
                </td>
            </tr>
            <tr>
                <td align="right" class="style7">
                    &nbsp;
                </td>
                <td align="right" class="auto-style1">
                    Fecha hasta:
                </td>
                <td align="left" class="style12">
                    <asp:TextBox ID="txtHasta" runat="server" Width="70px"></asp:TextBox>
                </td>
                <td align="left" class="style9">
                    &nbsp;
                </td>
                <td align="left" class="style10">
                    <asp:Button ID="btnActualizar" runat="server" Width="120px" CssClass="myButton" OnClick="btnActualizar_Click"
                        Text="VER REPORTE" />
                </td>
                <td align="right" class="style7">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" class="style7">
                    &nbsp;</td>
                <td align="right" class="auto-style1">
                    Tipo de informe:
                </td>
                <td align="left" class="style12">
                    <asp:DropDownList ID="ddlTipoDeInforme" runat="server">
                        <asp:ListItem Value="3">Consultorio</asp:ListItem>
                        <asp:ListItem Value="5">Guardia</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="left" class="style9">
                    &nbsp;</td>
                <td align="left" class="style10">
                    &nbsp;</td>
                <td align="right" class="style7">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style7">
                </td>
                <td class="myLabelIzquierda" colspan="5">
                    <hr />
                </td>
            </tr>
            <tr>
                <td align="left" class="style7">
                    &nbsp;
                </td>
                <td align="left" colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" class="style7">
                    &nbsp;
                </td>
                <td align="left" colspan="2">
                    <img src="../App_Themes/consultorio/images/pdf.jpg" />
                    <asp:LinkButton ID="lnkPdf" runat="server" CssClass="myLink" OnClick="lnkPdf_Click">Exportar a Pdf</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <img src="../App_Themes/consultorio/images/excelPeq.gif" />
                    <asp:LinkButton ID="lnkExcel" runat="server" CssClass="myLink" OnClick="lnkExcel_Click">Exportar a Excel</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" class="style7">
                    &nbsp;
                </td>
                <td align="left" colspan="5">
                    <asp:GridView ID="gvLista" runat="server" Width="100%" EmptyDataText="No se encontraron datos para los filtros de busqueda ingresados."
                        Font-Bold="True" Font-Names="Calibri" Font-Size="10pt" ShowFooter="True" CaptionAlign="Top"
                        CellPadding="2" BorderColor="#333333" BorderStyle="Solid" BorderWidth="1px" AutoGenerateColumns="False"
                        OnRowDataBound="gvLista_RowDataBound1" OnRowCommand="gvLista_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" HtmlEncode="false" />
                            <asp:BoundField DataField="Total Consultas" HeaderText="Total Consultas" />
                            <asp:BoundField DataField="<1" HeaderText="&lt;1">
                                <ItemStyle Width="25px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="1" HeaderText="1">
                                <ItemStyle Width="25px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="2 a 4" HeaderText="2 a 4">
                                <ItemStyle Width="25px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="5 a 9" HeaderText="5 a 9">
                                <ItemStyle Width="25px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="10 a 14" HeaderText="10 a 14">
                                <ItemStyle Width="25px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="15 a 24" HeaderText="15 a 24">
                                <ItemStyle Width="25px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="25 a 34" HeaderText="25 a 34">
                                <ItemStyle Width="25px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="35 a 44" HeaderText="35 a 44">
                                <ItemStyle Width="25px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="45 a 64" HeaderText="45 a 64">
                                <ItemStyle Width="25px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="65 y +" HeaderText="65 y +">
                                <ItemStyle Width="25px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Masculino" HeaderText="Masculino" />
                            <asp:BoundField DataField="Femenino" HeaderText="Femenino" />
                            <asp:BoundField DataField="Indeterminado" HeaderText="Indeterminado" />
                            <asp:TemplateField HeaderText="Pacientes">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Ver" Text="Ver" CommandName="Ver" runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                        <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                        <HeaderStyle BackColor="#336699" ForeColor="White" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" class="style7">
                    &nbsp;
                </td>
                <td align="left" colspan="5">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
