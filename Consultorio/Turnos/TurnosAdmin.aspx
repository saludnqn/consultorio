<%@ Page Title="" Language="C#" MasterPageFile="~/mConsultorio.Master" AutoEventWireup="true"
    CodeBehind="TurnosAdmin.aspx.cs" Inherits="Consultorio.Turnos.TurnosAdmin"
    UICulture="es" Culture="es-AR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<%@ Register Assembly="Subsonic" Namespace="SubSonic" TagPrefix="subsonic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
    <link href="../Turnos.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="../../js/jquery-ui-1.7.1.custom.css" />
    <script type="text/javascript" src="../../js/jquery.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>
    <script type="text/javascript">
        function callServersideMethod(valueToSend) {
            __doPostBack('callServersideMethod', valueToSend);
        }

        function valHora(oTxt) {
            var bOk = true;
            if (oTxt.value != "") {
                var nHs = parseInt(oTxt.value.substr(0, 2), 10);
                var nMin = parseInt(oTxt.value.substr(3, 2), 10);
                bOk = bOk && (nHs <= 23) && (nMin <= 59) && (oTxt.value.length == 5);
                if (!bOk) {
                    alert("Hora inválida (Formato hh:mm)");
                    oTxt.value = "";
                    oTxt.focus();
                }
            }
        }
    </script>
    <style type="text/css">
        .grid {
            margin-right: 0px;
        }

        .style1 {
            height: 19px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">

    <ajx:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptLocalization="true"
        EnableScriptGlobalization="true">
    </ajx:ToolkitScriptManager>
    <asp:UpdatePanel ID="updfiltro" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="1000px">
                <tr>
                    <td align="left" colspan="2" class="mytituloPagina">Administración de Turnos
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table width="100%">
                            <asp:Panel ID="pnlServicio" runat="server" Visible="true">
                                <tr>
                                    <td class="myLabelIzquierda" align="right">Servicio:
                                    </td>
                                    <td colspan="6" align="left">
                                        <asp:DropDownList Width="200px" ID="ddlServicio" runat="server" CssClass="myTexto">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <tr>
                                <td class="myLabelIzquierda" align="right">Especialidad/Prestación:
                                </td>
                                <td colspan="3" align="left">
                                    <asp:DropDownList ID="ddlTipoTurno" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoTurno_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">Todas</asp:ListItem>
                                        <asp:ListItem>Especialidad</asp:ListItem>
                                        <asp:ListItem>Prestaciones</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList Width="200px" ID="ddlEspecialidad" runat="server" CssClass="myTexto">
                                    </asp:DropDownList>
                                </td>
                                <td class="myLabelIzquierda" align="right">Profesional:
                                </td>
                                <td align="left">
                                    <asp:DropDownList Width="200px" ID="ddlProfesional" runat="server" CssClass="myTexto">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="myLabelIzquierda" align="right">Tipo de Consultorio:
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlTipoConsultorio" runat="server" CssClass="myTexto">
                                    </asp:DropDownList>
                                </td>
                                <td class="myLabelIzquierda" align="left">Fecha desde:
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDesde" runat="server" CssClass="myTexto" Width="80px" EnableViewState="false"></asp:TextBox>
                                    <ajx:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDesde"
                                        CssClass="cal_Theme1" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy"
                                        PopupPosition="BottomRight">
                                    </ajx:CalendarExtender>
                                </td>
                                <td class="myLabelIzquierda" align="left">Fecha hasta:
                                </td>
                                <td align="left" colspan="1">
                                    <asp:TextBox ID="txtHasta" runat="server" CssClass="myTexto" Width="80px" EnableViewState="false"></asp:TextBox>
                                    <ajx:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtHasta"
                                        CssClass="cal_Theme1" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy"
                                        PopupPosition="BottomRight">
                                    </ajx:CalendarExtender>
                                </td>
                                <td rowspan="2" style="padding-top: 10px;">
                                    <asp:Button ID="btnActualizar" Width="120px" runat="server" Text="Buscar Agendas"
                                        CssClass="myButton" OnClick="btnActualizar_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; width: 350px; float: left;">
                        <div id="resultadosAgenda" class="myLabelIzquierda" style="vertical-align: top; width: 350px; float: left;"
                            runat="server" visible="true">
                            <div class="myLabelRojo" style="height: 40px;" align="center">
                                Agendas Encontradas
                            </div>
                            <asp:GridView ID="gvAgendas" runat="server" GridLines="Both" AutoGenerateColumns="False"
                                DataKeyNames="idAgenda" AllowPaging="false" PageSize="20" EmptyDataText="No se encontraron agendas ABIERTAS coincidentes con el criterio de búsqueda"
                                Font-Names="Calibri" Font-Size="10pt" OnSelectedIndexChanged="gvAgendas_SelectedIndexChanged"
                                OnRowDataBound="gvAgendas_RowDataBound" OnPageIndexChanging="gvAgendas_PageIndexChanging"
                                Width="100%">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}">
                                        <HeaderStyle HorizontalAlign="Justify" />
                                        <ItemStyle HorizontalAlign="Justify" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Profesionales" ItemStyle-Width="150">
                                        <ItemTemplate>
                                            <asp:ListView ID="lsvProfesional" runat="server">
                                                <ItemTemplate>
                                                    <asp:Label Text="<%#Container.DataItem %>" runat="server" />
                                                </ItemTemplate>
                                                <ItemSeparatorTemplate>
                                                    <br />
                                                </ItemSeparatorTemplate>
                                            </asp:ListView>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="hIni" HeaderText="Inicio">
                                        <HeaderStyle HorizontalAlign="Justify" />
                                        <ItemStyle HorizontalAlign="Justify" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="hFin" HeaderText="Fin">
                                        <HeaderStyle HorizontalAlign="Justify" />
                                        <ItemStyle HorizontalAlign="Justify" />
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>                                            
                                            <asp:LinkButton ID="cmdSel" runat="server" AlternateText="seleccionar" CommandName="Select">
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/consultorio/Agenda/seleccionar.png"
                                                    Style="border-width: 0px;" />
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="10px" />
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="#333333" />
                                <EditRowStyle BackColor="#2461BF" />
                            </asp:GridView>
                        </div>
                    </td>
                    <td style="vertical-align: top; width: 600px; float: left;">
                        <asp:UpdatePanel ID="pnlResultados" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                            <ContentTemplate>
                                <!-- Barra derecha !-->
                                <div style="width: 400px; float: left;">
                                    <div style="height: 40px;">
                                        <asp:Label CssClass="myLabelRojo" ID="lblTituloAgenda" runat="server" Text=""></asp:Label><br />
                                        <asp:Label CssClass="myLabelIzquierda" ID="lblDiaAgenda" runat="server" Text=""></asp:Label>
                                        &nbsp;
                                        <asp:Label CssClass="myLabelIzquierda" ID="lblFechaAgenda" runat="server" Text=""></asp:Label>
                                        &nbsp;
                                        <asp:Label CssClass="myLabelIzquierda" ID="lblHoraAgenda" runat="server" Text=""></asp:Label>
                                        <br />
                                    </div>
                                    <!-- Grilla de seleccion de turnos !-->
                                    <div id="divscroll" class="myLabelIzquierda" style="width: 400px;">
                                        <asp:GridView ID="gvTurnos" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                            GridLines="Both" Width="100%" DataKeyNames="idTurno" ForeColor="#333333" OnRowDataBound="gvTurnos_RowDataBound"
                                            OnSelectedIndexChanged="gvTurnos_SelectedIndexChanged" Font-Names="Calibri" Font-Size="10pt">
                                            <PagerStyle Font-Underline="True" BackColor="#2461BF" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <RowStyle BackColor="#EFF3FB" />
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
                                                    <HeaderStyle HorizontalAlign="Justify" />
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
                                                    <ItemStyle HorizontalAlign="Left" Width="45%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="usuario" HeaderText="Asig. por">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="15%" />
                                                </asp:BoundField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>                                                        
                                                        <asp:LinkButton ID="cmdSelTurno" runat="server" AlternateText="seleccionar" CommandName="Select">
                                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/consultorio/Agenda/seleccionar.png"
                                                                Style="border-width: 0px;" />
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                        </asp:GridView>
                                    </div>
                                </div>
                                <!-- barra izquierda !-->
                                <div style="height: 100%; float: right; width: 180px;">
                                    <div>
                                        <br />
                                        <asp:Panel ID="pnlInfo" Visible="false" runat="server" Style="background: White; border: solid 1px Gray; height: 420px; width: 215px; padding: 5px 5px 5px 5px;">
                                            <!-- Información sobre turno seleccionado !-->
                                            <div id="divInfoTurnos">
                                                <!-- Dia, Agenda y hora seleccionada !-->
                                                <div id="Calendario" runat="server" class="div_izquierdo20">
                                                    <!-- calendario !-->
                                                    <div style="width: 100%; padding-left: 5px;">
                                                        <span id="cal" runat="server" class='<%# "cal m" + Convert.ToDateTime(lblFechaAgenda.Text).Month.ToString()
                                                    + " d" + Convert.ToDateTime(lblFechaAgenda.Text).Day.ToString()%>'><span class="m">
                                                        <%# Convert.ToDateTime(lblFechaAgenda.Text).Month.ToString()%></span> <span class="d">
                                                            <%# Convert.ToDateTime(lblFechaAgenda.Text).Day.ToString()%></span> </span>
                                                    </div>                                                    
                                                    <div style="width: 100%; padding-left: 10px;">
                                                        <asp:Label ID="lblInfoHora" runat="server" Text="<%# gvTurnos.SelectedRow.Cells[2].Text %>"
                                                            Font-Size="Large" Font-Bold="true"></asp:Label>
                                                    </div>
                                                </div>
                                                <!-- Informacion del turno !-->
                                                <div id="divInfoPaciente" runat="server">
                                                    <asp:HyperLink ID="lnkPaciente" runat="server" CssClass="myLink">
                                                        <asp:Image ID="imgInfoPaciente" runat="server" AlternateText="paciente" /><br />
                                                        <asp:Label ID="lblInfoPaciente" runat="server" Style="vertical-align: super; margin: 10px; text-align: center"></asp:Label><br />
                                                        <asp:Label ID="lblInfoDni" runat="server" Style="vertical-align: super; margin: 10px; text-align: center"></asp:Label><asp:Label ID="lblInfoOS" runat="server" Style="vertical-align: super; margin: 10px; text-align: center"></asp:Label>
                                                    </asp:HyperLink>
                                                </div>
                                                <br />
                                                <div style="text-align: left; width: 100%; background: White; vertical-align: bottom;">
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="left" style="padding: 5px;">
                                                                <!-- info sin asistencia !-->
                                                                <div id="divAsistenciaNo" runat="server" visible="true">
                                                                    <asp:Label ID="lblNoAsistencia" runat="server" Text="Sin asistencia" CssClass="labelencabezado"></asp:Label>
                                                                    <br />
                                                                    <br />
                                                                    <div style="text-align: left;">
                                                                        <asp:LinkButton ID="lnkAsistenciaNo" runat="server" CssClass="myLink" Style="text-decoration: underline; vertical-align: middle; cursor: pointer"
                                                                            OnClick="lnkAsistenciaNo_Click"> Indicar asistencia </asp:LinkButton>
                                                                        <br />
                                                                        <%-- <asp:LinkButton ID="lnkImprimir" runat="server" CssClass="links"
                                style="text-decoration:underline;vertical-align:middle;cursor:pointer"
                                onclick="lnkImprimir_Click"> <img alt="" src="../../App_Themes/consultorio/images/impreso.jpg"style="vertical-align:middle;border:none;" /> Impirmir comprobante </asp:LinkButton>--%>
                                                                    </div>
                                                                </div>
                                                                <!-- info con asistencia !-->
                                                                <div id="divAsistenciaSi" runat="server" visible="false">
                                                                    <asp:Label ID="lblAsistencia" runat="server" Text="Asistencia dd/mm hh:ss" CssClass="labelencabezado"></asp:Label>
                                                                    <br />
                                                                    <br />
                                                                    <asp:LinkButton ID="cmdBorrarAsistencia" runat="server" CssClass="links" Style="text-decoration: underline; vertical-align: middle; cursor: pointer;"
                                                                        OnClick="cmdBorrarAsistencia_Click"> <img alt="" src="../../App_Themes/consultorio/Agenda/suprime-la-ventana-icono-4582-16.png"style="vertical-align:middle;border:none;" /> borrar asistencia </asp:LinkButton><br />
                                                                    <asp:LinkButton ID="cmdEditarAsistencia" runat="server" CssClass="links" Style="text-decoration: underline; vertical-align: middle; cursor: pointer;"
                                                                        OnClick="cmdEditarAsistencia_Click"> <img alt="" src="../../App_Themes/consultorio/Agenda/oficina-icono-9743-16.png"style="vertical-align:middle;border:none;" /> editar horario de asistencia </asp:LinkButton>
                                                                </div>
                                                                <!-- edición de asistencia !-->
                                                                <div id="divAsistenciaEdit" runat="server" visible="false">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td style="margin-bottom: 45px;">Fecha:
                                                                                <asp:TextBox ID="txtFechaAsistencia" runat="server" CssClass="boxcortos" Enabled="false"></asp:TextBox>
                                                                                <asp:ImageButton ID="cmdFecha" runat="server" ImageUrl="~/App_Themes/default/img/calendar.png"
                                                                                    AlternateText="seleccione fecha" ToolTip="Seleccione fecha" />
                                                                                <asp:CustomValidator ID="cValidator_gr2" runat="server" ControlToValidate="txtFechaAsistencia"
                                                                                    ErrorMessage="(*) Fecha anterior al turno" EnableClientScript="false" Display="None"
                                                                                    ClientValidationFunction="validarFecha()"></asp:CustomValidator>
                                                                                <ajx:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFechaAsistencia"
                                                                                    CssClass="cal_Theme1" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy"
                                                                                    PopupPosition="BottomRight" PopupButtonID="cmdFecha">
                                                                                </ajx:CalendarExtender>
                                                                                &nbsp; Hora:
                                                                                <input type="text" id="txtHoraAsistencia" runat="server" class="boxcortos" onblur="valHora(this)" />
                                                                                <asp:RequiredFieldValidator ID="rqfvHoraAsistencia" runat="server" ErrorMessage="(*)"
                                                                                    ControlToValidate="txtHoraAsistencia"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" align="right">
                                                                                <br />
                                                                                <br />
                                                                                <asp:Button ID="cmdGrabarAsistencia" Width="100px" runat="server" Text="Grabar" CssClass="myButton"
                                                                                    OnClick="cmdGrabarAsistencia_Click" />
                                                                                &nbsp;
                                                                                <asp:Button ID="cmdCancelarAsistencia" Width="100px" runat="server" Text="Cancelar"
                                                                                    CssClass="myButton" OnClick="cmdCancelarAsistencia_Click" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="padding: 5px;">
                                                            <tr>
                                                                <td align="left" style="padding: 5px;">
                                                                    <asp:LinkButton ID="cmdNuevoTurno" runat="server" CssClass="myLink" OnClick="cmdNuevoTurno_Click"
                                                                        Style="text-decoration: underline; vertical-align: middle; cursor: pointer;">
                       Nuevo turno </asp:LinkButton>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                        <tr>
                                                            <td align="left" style="padding: 5px;">
                                                                <asp:LinkButton ID="cmdNuevoAcompanianteTerapeutico" runat="server" CssClass="myLink" Style="text-decoration: underline; vertical-align: middle; cursor: pointer;" OnClick="cmdNuevoAcompanianteTerapeutico_Click">
                       Agregar Acompañante</asp:LinkButton>
                                                                <br />
                                                                <asp:Label ID="lblCantidadAcompaniantes" Visible="false" runat="server" Text="Label" CssClass="myLabelRojo"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="padding: 5px;">
                                                                <asp:LinkButton ID="cmdRecitar" runat="server" CssClass="myLink" OnClick="cmdRecitar_Click"
                                                                    Style="text-decoration: underline; vertical-align: middle; cursor: pointer;">
                       Reasignar Turno</asp:LinkButton>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="padding: 5px;">
                                                                <asp:LinkButton ID="cmdLiberar" runat="server" CssClass="myLink" OnClick="cmdLiberar_Click"
                                                                    Style="text-decoration: underline; vertical-align: middle; cursor: pointer;">
                       Liberar turno </asp:LinkButton>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="padding: 5px;">
                                                                <asp:LinkButton ID="cmdSuspender" runat="server" CssClass="myLink" OnClick="cmdSuspender_Click"
                                                                    Style="text-decoration: underline; vertical-align: middle; cursor: pointer;">
                        Liberar y eliminar horario </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="padding: 5px;">
                                                                <asp:LinkButton ID="cmdBloquear" runat="server" CssClass="myLink" Text="Bloquear"
                                                                    OnClick="cmdBloquear_Click" Style="text-decoration: underline; vertical-align: middle; cursor: pointer;" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblMotivoBloqueo" runat="server" Text="" Visible="false" Font-Bold="true"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr align="left" style="padding: 5px;">
                                                            <td id="motivoDeBloqueo" runat="server" class="style1">
                                                                <asp:DropDownList ID="ddlMotivoDeBloqueo" runat="server" AutoPostBack="true">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <%--<tr>
                                                                    <td>
                                                                        <asp:RequiredFieldValidator ID="rfvMotivoDeBloqueo" runat="server" ErrorMessage="Seleccione un Motivo."
                                                                            ControlToValidate="ddlMotivoDeBloqueo" InitialValue="--Todos--" />
                                                                    </td>
                                                                </tr>--%>
                                                        <tr>
                                                            <td align="left">
                                                                <div id="divConfirma" runat="server" visible="false" style="width: 200px; height: 100px; border: dotted 1px Maroon; overflow: auto; background-color: #F1E2BB;">
                                                                    <div style="float: left; text-align: left;">
                                                                        <asp:Label ID="lblConfirma" runat="server" class="labelerror" Style="font-weight: bolder;"></asp:Label>
                                                                        <input type="hidden" id="inpConfirma" runat="server" value="" />
                                                                    </div>
                                                                    <div style="text-align: center; width: 100%;">
                                                                        <asp:Button ID="cmdSi" runat="server" Text="Si" CssClass="boxcortos" OnClick="cmdSi_Click"
                                                                            Style="text-align: center;" />
                                                                        &nbsp;
                                                                        <asp:Button ID="cmdNo" runat="server" Text="No" CssClass="boxcortos" Style="text-align: center;"
                                                                            OnClick="cmdNo_Click" />
                                                                    </div>
                                                                </div>
                                                                <div id="divError" runat="server" visible="false" style="width: 180px; height: 80px; border: dotted 1px Maroon; background-color: #F1E2BB; overflow: auto;">
                                                                    <div style="float: left; text-align: left;">
                                                                        <b class="labelerror" style="font-weight: bolder;">Ya ha sido confirmada la asistencia
                                                                            para el turno seleccionado. Imposible continuar</b>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!-- capa externa !-->
    <div>
        <!-- barra izquierda !-->
        <div id="divbusquedaagenda" runat="server">
            <div id="divMsg" runat="server" visible="false">
                <asp:Label ID="lblMsg" runat="server" Text="" CssClass="labelerror" Style="font-weight: bolder;"></asp:Label>
            </div>
            <!-- grilla para cargar turno de agenda seleccionada !-->
            <!-- Mensajes de validacion !-->
            <div id="divErrAgenda" class="identincorrecta" runat="server" visible="false">
                <asp:Label ID="lblErrAgenda" runat="server" Text="" CssClass="labelerror"></asp:Label>
            </div>
        </div>
        <!-- columnas laterales derechas !-->
        <div>
            <%--   <asp:LinkButton Visible="false"  ID="lnkImprimir" CssClass="myLink" runat="server" onclick="LinkButton1_Click">Imprimir
        Planilla</asp:LinkButton>--%>
        </div>
    </div>

    <script language="javascript" type="text/javascript">

        function PacienteCompania(IdTurno) {

            var dom = document.domain;
            var domArray = dom.split('.');
            for (var i = domArray.length - 1; i >= 0; i--) {
                try {
                    var dom = '';
                    for (var j = domArray.length - 1; j >= i; j--) {
                        dom = (j == domArray.length - 1) ? (domArray[j]) : domArray[j] + '.' + dom;
                    }
                    document.domain = dom;
                    break;
                } catch (E) {
                }
            }

            var $this = $(this);
            $('<iframe src="ATerapeuticoList.aspx?idTurno=' + IdTurno + '" />').dialog({
                title: 'Acompañante Terapeutico Asignados',
                autoOpen: true,
                width: 650,
                height: 300,
                modal: true,
                resizable: false,
                autoResize: true,
                overlay: {
                    opacity: 0.5,
                    background: "black"
                }
            }).width(700);
        }
    </script>
</asp:Content>