<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgendaNew.aspx.cs" Inherits="Consultorio.Agenda.AgendaNew"
    MasterPageFile="~/mConsultorio.Master" UICulture="es" Culture="es-AR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<%@ Register Assembly="Subsonic" Namespace="SubSonic" TagPrefix="subsonic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
    <link href="../Turnos.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="../js/jquery-ui-1.7.1.custom.css" />
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../js/jquery.ui.datepicker-es.js"></script>
    <script type="text/javascript" src="../js/Mascara.js"></script>
    <script type="text/javascript" src="../js/ValidaFecha.js"></script>
    <script type='text/javascript'>

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">
    <br />
    <br />
    <br />
    <br />
    <ajx:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </ajx:ToolkitScriptManager>
    <div class="mytituloPagina">
        &nbsp;&nbsp; Nueva Agenda
    </div>
    <div style="height: 750px; float: left; width: 330px;">
        <table class="myLabelRojo" width="1100px">
            <tr>
                <td colspan="3">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <br />
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="updfiltro" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
            <ContentTemplate>
                <!-- barra izquierda !-->
                <div style="height: 100%;">
                    <!-- encabezado !-->
                    <!-- filtros !-->
                    <div id="Div1" runat="server" visible="true">
                        <asp:Panel ID="pnlFiltro" runat="server">
                            <table>
                                <asp:Panel ID="pnlServicio" runat="server" Visible="true">
                                    <tr>
                                        <td align="center" class="myLabelIzquierda">Servicio
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlServicio" runat="server" Width="95%" ValidationGroup="gr1">
                                            </asp:DropDownList>
                                            <asp:RangeValidator ID="rngv_ddlServicio" runat="server" ControlToValidate="ddlServicio"
                                                EnableClientScript="false" Display="None" ErrorMessage="- debe seleccionar un servicio"
                                                MinimumValue="1" MaximumValue="10000" ValidationGroup="gr1" Type="Integer"></asp:RangeValidator>
                                        </td>
                                    </tr>
                                </asp:Panel>
                              <%--  <tr>
                                    <td align="center" class="myLabelIzquierda">Especialidad/Prestación
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td>
                                       <%-- <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="myList" Width="95%"
                                            ValidationGroup="gr1" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:RangeValidator ID="rngv_ddlEspecialidad" runat="server" ControlToValidate="ddlEspecialidad"
                                            ErrorMessage="Debe seleccionar una especialidad" MinimumValue="1" MaximumValue="10000"
                                            ValidationGroup="gr2" Type="Integer"></asp:RangeValidator>--%>
                                    </td>
                                </tr>
                                   <tr runat="server" id="trEspecialidadXProfesional" visible="true">
                                    <td align="center" class="myLabelIzquierda">Especialidad del Profesional
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlEspecialidadXProfesional" runat="server" CssClass="myList" Width="95%"
                                            ValidationGroup="gr1" Visible="false">
                                        </asp:DropDownList>
                                         <asp:RangeValidator ID="rvEspecialidadXProfesional" runat="server" ControlToValidate="ddlEspecialidadXProfesional"
                                            ErrorMessage="Seleccione una Especialidad!" MaximumValue="999999"
                                            MinimumValue="0" Type="Integer" ValidationGroup="gr1"></asp:RangeValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" class="myLabelIzquierda">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="center" class="myLabelIzquierda">Profesional </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlProfesional" runat="server" CssClass="myList" Width="95%"
                                            ValidationGroup="gr1" OnSelectedIndexChanged="ddlProfesional_SelectedIndexChanged"
                                            AutoPostBack="True" CausesValidation="True">
                                        </asp:DropDownList>
                                        <asp:RangeValidator ID="rvclass" runat="server" ControlToValidate="ddlProfesional"
                                            ErrorMessage="Seleccione un Profesional!" MaximumValue="999999999"
                                            MinimumValue="0" Type="Integer" ValidationGroup="gr1"></asp:RangeValidator>
                                        

                                        <asp:CheckBox runat="server" ID="chkSinProfesional" Style="text-align: left;" Text="Sin especificar"
                                            Width="95%" AutoPostBack="true" visible="false"
                                            OnCheckedChanged="chkSinProfesional_CheckedChanged" />
                                        <asp:RangeValidator ID="rngv_ddlProfesional" runat="server" ControlToValidate="ddlProfesional"
                                            ErrorMessage="Debe seleccionar un profesional" MinimumValue="1" MaximumValue="10000"
                                            Type="Integer" Enabled="False" ValidationGroup="gr1"></asp:RangeValidator>
                                    </td>
                                </tr>

                             
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="imgAgregarProfesionales" ImageUrl="~/App_Themes/consultorio/Agenda/anadir-mas-verde-icono-5682-32.png" runat="server"
                                            OnClick="imgAgregarProfesionales_Click" ToolTip="Agregar Profesional" Visible="false" ValidationGroup="gr1" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp</td>
                                </tr>
                                <tr>
                                    <td style="padding-bottom: 10px">
                                        <asp:GridView ID="gdvListaDeProfesionales" Width="100%" runat="server" AutoGenerateColumns="False"
                                            CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="gdvListaDeProfesionales_RowDeleting">
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <Columns>
                                                <asp:BoundField HeaderText="Id" DataField="idProfesional" Visible="true" />
                                                <asp:BoundField HeaderText="Profesional" DataField="Profesional" />
                                                <asp:BoundField HeaderText="Especialidad" DataField="Especialidad" HeaderStyle-HorizontalAlign="Left" />
                                                <asp:CommandField ShowDeleteButton="True" ButtonType="Image"
                                                    DeleteImageUrl="~/App_Themes/consultorio/Agenda/boton-de-error-icono-5371-32.png"
                                                    ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" ControlStyle-Width="20px" HeaderText="Eliminar" />
                                            </Columns>
                                            <EditRowStyle BackColor="#999999" />
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                        </asp:GridView>
                                    </td>
                                </tr>

                                <tr>
                                    <td align="center" class="myLabelIzquierda">Tipo de Consultorio
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" class="myLabelIzquierda">
                                        <asp:DropDownList ID="ddlTipoConsultorio" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" class="myLabelIzquierda">Fecha de la Agenda
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Calendar ID="cldTurno" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66"
                                            BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                                            ForeColor="#663399" Height="200px" ShowGridLines="True" ToolTip="Seleccione la fecha para la cual desea crear una agenda"
                                            Width="220px" OnSelectionChanged="cldTurno_SelectionChanged">
                                            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                            <SelectorStyle BackColor="#FFCC66" />
                                            <TodayDayStyle BackColor="#CCCCCC" />
                                            <OtherMonthDayStyle ForeColor="#CC9966" />
                                            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                        </asp:Calendar>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="divErrFiltro" runat="server" visible="false" style="align: left; width: 80%; height: auto; padding: 5px; border: dotted 1px Maroon; background-color: #F1E2BB;">
                                            <asp:CustomValidator ID="cValidator_gr1" runat="server" ErrorMessage="" ValidationGroup="gr1"
                                                EnableClientScript="false" Display="None"></asp:CustomValidator>
                                            <asp:ValidationSummary ID="VS_gr1" runat="server" HeaderText="Errores encontrados:"
                                                DisplayMode="List" ShowSummary="true" ValidationGroup="gr1" EnableClientScript="false" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <!-- validacion izquierda !-->
                        </asp:Panel>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <!-- panel central dividido en dos columnas !-->
    <div style="width: 60%; height: 500px; overflow: scroll;">
        <asp:UpdatePanel ID="pnlGrilla" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
            <ContentTemplate>
                <div>
                    <!-- encabezado panel central !-->
                    <div style="overflow: hidden;" align="left">
                        <br />
                        &nbsp;
                        <br />
                        <b class="myLabelIzquierda">Seleccione consultorio</b>&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnActualizar" runat="server" Text="Mostrar Consultorios" CssClass="myButton"
                            OnClick="btnActualizar_Click" Width="150px" />
                    </div>
                    <br />
                    <!-- columna izquierda del panel central !-->
                    <div style="height: 100%; width: 40%; float: left;">
                        <!-- lista de consultorios seleccionables !-->
                        <div id="divLista" runat="server" style="border: 1px solid #B3C6EC; overflow: auto; height: 400px; width: 100%;">
                            <asp:DataList ID="dtlConsultorios" runat="server" CellPadding="4" ForeColor="#333333"
                                RepeatColumns="1" ItemStyle-HorizontalAlign="Center" Width="100%" HorizontalAlign="Center"
                                RepeatDirection="horizontal" OnItemDataBound="dtlConsultorios_ItemDataBound"
                                OnSelectedIndexChanged="dtlConsultorios_SelectedIndexChanged">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <ItemStyle HorizontalAlign="Center" />
                                <SelectedItemStyle />
                                <HeaderStyle />
                                <ItemTemplate>
                                    <div>
                                        <!-- imagebutton para seleccion !-->
                                        <div>
                                            <div style="float: left; padding-top: 5px; padding-left: 5px;">
                                                <b style="padding: 5px 0 2px; color: #688AE6; font-size: 14px; font-weight: bolder; vertical-align: top; text-align: left;">Consultorio:<%# DataBinder.Eval(Container.DataItem, "nombre") %></b></div>
                                            <div style="float: right; padding-top: 5px; padding-right: 5px;">
                                                <asp:LinkButton ID="lnkConsultorio" runat="server" PostBackUrl="#" ToolTip="click para seleccionar consultorio"
                                                    CommandName="Select"> 
                            <img src="../App_Themes/consultorio/Agenda/seleccionar.png" 
                              alt="Click para seleccionar consultorio" style="border:none;text-align:right;"/> 
                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                        <!-- Informacion sobre ocupación del consultorio !-->
                                        <div style="width: 95%; height: 100%; float: left; padding: 0px 0px	0px 0px">
                                            <div style="background-color: Transparent; padding-right: 0px; width: 100%;">
                                                <div style="width: 35%; height: 100%; float: left; padding: 0px 0px	0px 0px; width: 32px; height: 35px; margin-left: 5px; margin-right: 10px;">
                                                    <asp:Image ID="imgLibre" runat="server" ImageUrl="~/App_Themes/consultorio/Agenda/check_verde.png"
                                                        AlternateText="Consultorio libre" ToolTip="Consultorio libre" />
                                                </div>
                                                <div style="height: auto; background: Tranparent; text-align: left; padding-top: 5px;">
                                                    <asp:Label ID="lblEstado" runat="server"></asp:Label>
                                                </div>
                                                <!-- agregar link para mostrar gráficamente la ocupación !-->
                                                <div style="width: 100%; height: auto; text-align: center; overflow: auto;">
                                                    <asp:BulletedList ID="lstOcupa" runat="server" Visible="false" BulletStyle="Disc"
                                                        DisplayMode="HyperLink">
                                                    </asp:BulletedList>
                                                </div>
                                                <hr />
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                    </div>
                    <!-- columna derecha de panel central !-->
                    <div class="" style="height: 400px; width: 55%; float: right; border: 1px solid #B3C6EC; overflow: auto;">
                        <ajx:Accordion ID="Acordeon" runat="server" HeaderCssClass="AcordeonEncabezado" ContentCssClass="AcordeonContenido"
                            HeaderSelectedCssClass="AcordeonSeleccionado" FadeTransitions="True" TransitionDuration="100"
                            FramesPerSecond="10">
                            <Panes>
                                <ajx:AccordionPane ID="acordionParametros" runat="server" Enabled="false">
                                    <Header>
                                        &nbsp;&nbsp;&nbsp;&nbsp;Parametros para consultorio:
                                        <asp:Label ID="lblSeleccion" runat="server"></asp:Label></Header>
                                    <Content>
                                        <div>
                                            <div style="width: 100%; text-align: center;">
                                                <input type="hidden" runat="server" id="inpFecha" />
                                            </div>
                                            <div style="width: auto; border: solid 1px Gray; background-color: White; padding-left: 5px; padding-right: 5px; margin-bottom: 3px;">
                                                <table style="text-align: left;">
                                                    <tr style="height: 25px">
                                                        <td class="myLabelIzquierda">Inicio:
                                                        </td>
                                                        <td>
                                                            <input id="txtHoraDesde" runat="server" type="text" maxlength="5" style="width: 40px"
                                                                onblur="valHora(this)" onkeyup="mascara(this,':',patron,true)" tabindex="7" class="myTexto"
                                                                title="Ingrese la hora de inicio de turnos" />
                                                        </td>
                                                        <td class="myLabelIzquierda">Fin:
                                                        </td>
                                                        <td>
                                                            <input id="txtHoraHasta" runat="server" type="text" maxlength="5" style="width: 40px"
                                                                onblur="valHora(this)" onkeyup="mascara(this,':',patron,true)" tabindex="7" class="myTexto"
                                                                title="Ingrese la hora de fin de turnos" />
                                                        </td>
                                                        <td class="myLabelIzquierda">Duración:
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlDuracion" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" class="myLabelIzquierda">Citar por Bloque
                                                        </td>
                                                        <td colspan="3">
                                                            <asp:DropDownList ID="ddlBloque" runat="server" CssClass="myList">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" class="myLabelIzquierda">Estado de Agenda:
                                                        </td>
                                                        <td colspan="3">
                                                            <asp:DropDownList ID="ddlEstado" runat="server" CssClass="myList" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged"
                                                                AutoPostBack="true">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <!-- fila para activacion automática !-->
                                                        <td id="filaActivacion" runat="server" colspan="6" align="center" visible="false">
                                                            <div id="divActivacion" runat="server" style="width: 95%; height: 100%; border: dotted 1px Maroon; padding: 5px; background-color: #F1E2BB;">
                                                                <asp:CheckBox ID="chkActivacion" runat="server" Text="Activación automática" AutoPostBack="true"
                                                                    OnCheckedChanged="chkActivacion_CheckedChanged" />
                                                                <br />
                                                                <asp:TextBox ID="txtFechaActivacion" runat="server" Enabled="false" Visible="false"
                                                                    CssClass="boxcortos" Style="position: relative; top: -6px;" ValidationGroup="gr2"></asp:TextBox>
                                                                <asp:ImageButton ID="btnFechaActivacion" runat="server" Enabled="false" Visible="false"
                                                                    ImageUrl="~/App_Themes/default/img/calendar.png" Style="position: relative; top: -3px;" />&nbsp;&nbsp;
                                                                <ajx:CalendarExtender ID="calExttxtFechaActivacion" runat="server" Enabled="True"
                                                                    Animated="true" TargetControlID="txtFechaActivacion" CssClass="cal_Theme1" DaysModeTitleFormat="dd/MM/yyyy"
                                                                    TodaysDateFormat="dd/MM/yyyy" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" PopupButtonID="btnFechaActivacion">
                                                                </ajx:CalendarExtender>
                                                                <asp:TextBox ID="txtHoraActivacion" runat="server" Enabled="false" Visible="false"
                                                                    Text="0" ValidationGroup="gr2"></asp:TextBox>
                                                                <ajx:NumericUpDownExtender ID="nUpDownEx_txtHoraActivacion" runat="server" TargetControlID="txtHoraActivacion"
                                                                    Minimum="0" Maximum="23" Width="50" Enabled="false">
                                                                </ajx:NumericUpDownExtender>
                                                                <asp:RangeValidator ID="rngv_txtHoraActivacion" runat="server" ControlToValidate="txtHoraActivacion"
                                                                    EnableClientScript="false" Display="None" ErrorMessage="- error en dígitos de la hora de activación"
                                                                    MinimumValue="0" MaximumValue="23" ValidationGroup="gr2" Type="Integer"></asp:RangeValidator>
                                                                <asp:TextBox ID="txtMinutosActivacion" runat="server" Text="0" ValidationGroup="gr2"
                                                                    Enabled="false" Visible="false"></asp:TextBox>
                                                                <ajx:NumericUpDownExtender ID="nUpDownEx_txtMinutosActivacion" runat="server" TargetControlID="txtMinutosActivacion"
                                                                    Minimum="0" Maximum="59" Width="50" Enabled="false">
                                                                </ajx:NumericUpDownExtender>
                                                                <asp:RangeValidator ID="rngv_txtMinutosActivacion" runat="server" ControlToValidate="txtMinutosActivacion"
                                                                    EnableClientScript="false" Display="None" ErrorMessage="- error en dígitos de minutos de la hora de activación"
                                                                    MinimumValue="0" MaximumValue="59" ValidationGroup="gr2" Type="Integer"></asp:RangeValidator>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <!-- fila para activacion automática !-->
                                                        <td id="filaValidacion" runat="server" colspan="6" align="center" visible="false">
                                                            <div id="divErr" runat="server" style="width: 350px; height: 100%;">
                                                                <div style="float: left; text-align: left;">
                                                                    <asp:RangeValidator ID="rngv_ddlDuracion" runat="server" ControlToValidate="ddlDuracion"
                                                                        ErrorMessage="Seleccione duración del turno" MinimumValue="0" MaximumValue="60"
                                                                        ValidationGroup="gr2" Type="Integer"></asp:RangeValidator>
                                                                    <asp:CustomValidator ID="cValidator_gr2" runat="server" ControlToValidate="ddlEstado"
                                                                        ErrorMessage="" ValidationGroup="gr2" EnableClientScript="false" Display="None"></asp:CustomValidator>
                                                                    <asp:ValidationSummary ID="VST" runat="server" HeaderText="Errores encontrados:"
                                                                        ShowSummary="true" ValidationGroup="gr2" />
                                                                </div>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:Button CssClass="myButton" Width="80px" ID="btnAgregar" runat="server" Text="Agregar"
                                                    ValidationGroup="gr2" OnClick="btnAgregar_Click" />
                                            </div>
                                        </div>
                                    </Content>
                                </ajx:AccordionPane>
                                <ajx:AccordionPane ID="acordionGrilla" runat="server" Enabled="true">
                                    <Header>
                                        &nbsp;&nbsp;&nbsp;&nbsp;Agendas a grabar</Header>
                                    <Content>
                                        <div style="width: auto; height: 330px; border: solid 1px Maroon; background-color: White; padding-left: 5px; padding-right: 5px;">
                                            <div id="divProgramacion" runat="server" style="width: 100%; height: 86%; overflow: auto; background: White; clear: both; margin-top: 10px; margin-bottom: 5px;">
                                                <asp:GridView ID="gvProgramacion" runat="server" AutoGenerateColumns="False" DataKeyNames="idConsultorio"
                                                    GridLines="Both" Font-Names="Calibri" Font-Size="10pt" ForeColor="#333333" CellPadding="4"
                                                    EmptyDataText="Seleccione un consultorio dentro de un rango horario disponible"
                                                    OnSelectedIndexChanged="gvProgramacion_SelectedIndexChanged">
                                                    <PagerStyle Font-Underline="True" HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White" />
                                                    <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="#333333" />
                                                    <Columns>
                                                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" Visible="true" DataFormatString="{0:dd/MM/yyyy}">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Consultorio" HeaderText="Consultorio" Visible="true">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="hIni" HeaderText="Hora inicio" Visible="true">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="hFin" HeaderText="Hora fin" Visible="true">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Duracion" HeaderText="Duracion" Visible="true">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="true" />
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Image ID="imgEstadoOK" runat="server" ImageUrl="~/App_Themes/consultorio/Agenda/check_verde16.png"
                                                                    ToolTip="validación correcta" Visible="false" Style="vertical-align: super;" />
                                                                <asp:Image ID="imgEstadoErr" runat="server" ImageUrl="~/App_Themes/consultorio/Agenda/turnoeliminado.png"
                                                                    ToolTip="errores en validación" Visible="false" Style="vertical-align: super;" />
                                                                &nbsp;
                                                                <asp:ImageButton ID="cmdQuitar" runat="server" CommandName="Select" AlternateText="Quitar fila"
                                                                    ImageUrl="~/App_Themes/consultorio/Agenda/cerrar-icono-3898-16.png" Width="20px" Height="20px" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EditRowStyle BackColor="#2461BF" />
                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                </asp:GridView>
                                                <div style="text-align: left;">
                                                    <asp:ValidationSummary ID="VSGuardar" runat="server" HeaderText="Errores encontrados:"
                                                        ShowSummary="true" ValidationGroup="gr3" />
                                                    <asp:CustomValidator ID="cValidator_gr3" runat="server" ErrorMessage="" ValidationGroup="gr3"
                                                        EnableClientScript="false" Display="None"></asp:CustomValidator>
                                                </div>
                                            </div>
                                            <asp:Button ID="btnGrabar" runat="server" Width="80px" Text="Grabar" ValidationGroup="gr3"
                                                CssClass="myButton" OnClick="btnGrabar_Click" />
                                        </div>
                                    </Content>
                                </ajx:AccordionPane>
                            </Panes>
                        </ajx:Accordion>
                    </div>
                </div>
                <asp:Button ID="btnShowMsg" runat="server" Text="btnPopup" Visible="false" />
                <ajx:ModalPopupExtender ID="mPopupMsg" runat="server" PopupControlID="msgBox" TargetControlID="btnShowMsg"
                    OkControlID="btnMsgAceptar">
                </ajx:ModalPopupExtender>
                <div id="msgBox" runat="server" class="modalPanelFijo" style="height: auto; width: auto; display: none;">
                    <div id="Div2" class="div_encabezado" runat="server" style="background: White;">
                        <asp:Label ID="lblPopup" runat="server" CssClass="labeldatos" Width="100%" Style="height: auto;"></asp:Label>
                        <br />
                        <input id="btnMsgAceptar" type="button" value="Aceptar" />
                        <input id="btnMsgCancelar" type="button" value="Cancelar" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>



