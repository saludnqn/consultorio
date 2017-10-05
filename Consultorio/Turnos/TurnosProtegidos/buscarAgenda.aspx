<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="buscarAgenda.aspx.cs"
    Inherits="Consultorio.Turnos.TurnosProtegidos.buscarAgenda" MasterPageFile="~/mConsultorio.Master"%>

<asp:Content ID="Content3" ContentPlaceHolderID="Superior" runat="server">
    <link href="../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="../../js/jquery-ui-1.7.1.custom.css" />

    <script type="text/javascript" src="../../js/jquery.min.js"></script>

    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>

    <script type="text/javascript" src="../../js/jquery.ui.datepicker-es.js"></script>

    <script type="text/javascript" src="../../js/Mascara.js"></script>

    <script type="text/javascript" src="../../js/ValidaFecha.js"></script>

    <script type="text/javascript">

        $(function () {
            $("#<%=txtFechaInicio.ClientID %>").datepicker({
                showOn: 'button',
                buttonImage: '../../App_Themes/turnosProtegidos/images/calendario.jpg',
                buttonImageOnly: true
            });
        });

        $(function () {
            $("#<%=txtFechaFin.ClientID %>").datepicker({
                showOn: 'button',
                buttonImage: '../../App_Themes/turnosProtegidos/images/calendario.jpg',
                buttonImageOnly: true
            });
        });

    </script>

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
        .auto-style4 {
            height: 18px;
            width: 210px;
        }
        .auto-style6 {
            height: 18px;
        }
        .auto-style9 {
            width: 358px;
        }
        .auto-style10 {
            height: 14px;
        }
        .auto-style12 {
            height: 14px;
            width: 97px;
        }
        .auto-style13 {
        }
        .auto-style14 {
            width: 93px;
        }
        .auto-style15 {
            width: 108px;
        }
        .auto-style17 {
            width: 97px;
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
                    Text="Buscar agenda"></asp:Label>
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
                                    <td class="auto-style9">
                                        <table>
                                            <tr>
                                                <td class="auto-style6">
                                                    <asp:Label ID="Label11" runat="server" Text="1. Seleccionar efector"></asp:Label>
                                                </td>
                                                <td class="auto-style4">
                                                    <asp:Panel ID="pnlSeleccionarEfector" runat="server">
                                                        <table class="auto-style1">
                                                            <tr>
                                                                <td class="auto-style6">
                                                                    <asp:DropDownList ID="ddlEfectorHabilitado" runat="server" AutoPostBack="True" DataTextField="nombre" DataValueField="idEfector" OnSelectedIndexChanged="ddlEfectorHabilitado_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style6">
                                                    <asp:Label ID="Label8" runat="server" Text="Paciente"></asp:Label>
                                                </td>
                                                <td class="auto-style4">
                                                    <asp:Panel ID="pnlSeleccionarPaciente" runat="server">
                                                        <table class="auto-style1">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblDatosPaciente" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style6">
                                                    &nbsp;</td>
                                                <td class="auto-style4">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style6">
                                                    <asp:Label ID="lblSeleccionarFiltros" runat="server" Text="2. Seleccionar filtros"></asp:Label>
                                                </td>
                                                <td class="auto-style4">
                                                    <asp:Panel ID="pnlFiltros" runat="server">
                                                        <table class="auto-style1">
                                                            <tr>
                                                                <td class="auto-style17">
                                                                    <asp:Label ID="Label6" runat="server" Text="Especialidad (*)"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlEspecialidad" runat="server" AutoPostBack="True" DataTextField="especialidad" DataValueField="id_especialidad" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style12"></td>
                                                                <td class="auto-style10">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style17">
                                                                    <asp:Label ID="Label7" runat="server" Text="Profesional (*)"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlProfesional" runat="server" AutoPostBack="True" DataTextField="ape" DataValueField="cod">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style17">&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style13" colspan="2">
                                                                    <asp:Panel ID="pnlFechas" runat="server">
                                                                        <table style="width:70%;">
                                                                            <tr>
                                                                                <td class="auto-style14">
                                                                                    <asp:Label ID="Label1" runat="server" Text="Fecha Inicio (*)"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style15">
                                                                                    <input id="txtFechaInicio" runat="server" maxlength="10" onblur="valFecha(this)" onkeyup="mascara(this,'/',patron,true)" tabindex="9" type="text" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style14">
                                                                                    <asp:Label ID="lblFechaFin" runat="server" Text="Fecha Fin (*)"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style15">
                                                                                    <input id="txtFechaFin" runat="server" maxlength="10" onblur="valFecha(this)" onkeyup="mascara(this,'/',patron,true)" tabindex="9" type="text" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </asp:Panel>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style6">
                                                    &nbsp;</td>
                                                <td class="auto-style4">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style6">
                                                    <asp:Label ID="lblConsultar" runat="server" Text="3. Consultar"></asp:Label>
                                                </td>
                                                <td class="auto-style4">
                                                    <asp:Panel ID="pnlVerAgendas" runat="server">
                                                        <asp:ImageButton ID="ibVerDatos" runat="server" ImageUrl="../../App_Themes/turnosProtegidos/images/verAgendas.png" OnClick="ibVerDatos_Click" />
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style9">&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 358px" valign="top">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 358px" valign="top">
                                                        <asp:HyperLink ID="hlCargarDatosPaciente" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="#CC3300">Mensaje</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 358px" valign="top">
                            &nbsp;</td>
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
                            <asp:GridView ID="gvListaAgendas" 
                                runat="server" AutoGenerateColumns="False"
                                CellPadding="10" DataKeyNames="idagenda" EmptyDataText="No se encontraron datos para los filtros ingresados"
                                EnableTheming="True" Font-Bold="False" Font-Names="Arial" Font-Size="13pt" ForeColor="#333333" Width="60%" OnRowDataBound="gvListaAgendas_RowDataBound">
                                <RowStyle BackColor="#F7F6F3" Font-Names="Arial" Font-Size="10pt" ForeColor="#333333" />
                                <Columns>

                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" ID="hlVer" ImageUrl="~/App_Themes/turnosProtegidos/images/reporte.png"
                                            NavigateUrl='<%# "../TurnosProtegidos/verificarAsignacionAgenda.aspx?idAgenda="+ Eval("idagenda") + "&idEspecialidad=" + Eval("idEspecialidad") + "&idInterconsulta=" + Request.QueryString["idInterconsulta"] + "&consultorio=" + Eval("consultorio")%>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="idagenda" HeaderText="idagenda" Visible="False" />
                                    <asp:BoundField DataField="cp" HeaderText="Codigo de profesioanl" Visible="False" />
                                    <asp:BoundField DataField="profesional" HeaderText="Profesional" />
                                    <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                                    <asp:BoundField DataField="consultorio" HeaderText="Consultorio" />
                                    <asp:BoundField DataField="rango" HeaderText="Rango" />
                                    <asp:BoundField DataField="hi" HeaderText="Hora de inicio" />
                                    <asp:BoundField DataField="hf" HeaderText="Hora de finalizacion" />
                                    <asp:BoundField DataField="idespecialidad" HeaderText="idespecialidad" Visible="False" />
                                    <asp:BoundField DataField="especialidad" HeaderText="Especialidad" />

                                </Columns>
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
