<%@ Page Title="" Language="C#" MasterPageFile="~/mConsultorio.Master" AutoEventWireup="true"
    CodeBehind="AgendaEdit.aspx.cs" Inherits="Consultorio.Agenda.AgendaEdit"
    UICulture="es" Culture="es-AR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
    <link href="../Turnos.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="../js/jquery-ui-1.7.1.custom.css" />
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../js/jquery.ui.datepicker-es.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">
    <br />
    <br />
    <ajx:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </ajx:ToolkitScriptManager>
    <div style="width: 650px; height: 300px;">
        <asp:UpdatePanel ID="updPanel" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
            <ContentTemplate>
                <!-- contenido !-->
                <div id="encabezadoagenda" runat="server">
                    <!-- titulo !-->
                    <!-- Contenido izquierdo !-->
                    <div>
                        <!-- seccion agenda !-->
                        <div>
                            <b class="labelencabezado">
                                <asp:Label ID="lblNroAgenda" Visible="false" runat="server" Text="" CssClass="labelencabezado"></asp:Label>
                            </b>&nbsp;
                            <br />
                            <table cellpadding="2" cellspacing="2">
                                <tr>
                                    <td align="left" colspan="3" class="mytituloPagina">EDICION DE AGENDA
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" class="mytituloPagina">
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="myLabelIzquierda">Fecha:
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblFecha" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="myLabelIzquierda">Estado:
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="myList"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RangeValidator ID="rq" runat="server" ControlToValidate="ddlEstado" MinimumValue="1"
                                            MaximumValue="999" ValidationGroup="gr1" ErrorMessage="(*)" Type="Integer"></asp:RangeValidator>
                                    </td>
                                </tr>

                                <tr id="motivoInactivacion" runat="server">
                                    <td align="right" class="myLabelIzquierda">
                                        <asp:Label ID="lblbMotivoInactivacionAgenda" runat="server"
                                            Text="Seleccione motivo de inactivación"></asp:Label>
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlMotivoInactivacion" runat="server" CssClass="myList">
                                        </asp:DropDownList>

                                        <asp:RangeValidator ID="rvMotivoInactivacion" runat="server" ControlToValidate="ddlMotivoInactivacion" ErrorMessage="(*)" MaximumValue="99999" MinimumValue="1" Type="Integer" ValidationGroup="gr1"></asp:RangeValidator>

                                    </td>
                                </tr>

                                <tr>
                                    <td align="right" class="myLabelIzquierda">Fecha de activacion automática:
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtActivacion" runat="server" Enabled="false" CssClass="boxcortos"
                                            ValidationGroup="gr1" OnTextChanged="txtActivacion_TextChanged"> </asp:TextBox>
                                        <asp:ImageButton ID="cmdFecha" runat="server" ImageUrl="~/App_Themes/default/img/calendar.png"
                                            AlternateText="seleccione fecha" ToolTip="Seleccione fecha" Visible="false" OnClick="cmdFecha_Click" />
                                        <ajx:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1"
                                            TargetControlID="txtActivacion" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" PopupPosition="TopRight"
                                            TodaysDateFormat="dd/MM/yyyy" DaysModeTitleFormat="dd/MM/yyyy">
                                        </ajx:CalendarExtender>
                                        <asp:RegularExpressionValidator ID="rgExp_txtActivacion" runat="server" ErrorMessage="(*) dd/mm/yyyy"
                                            ControlToValidate="txtActivacion" EnableClientScript="false" ValidationGroup="gr1"
                                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d">
                                        </asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <asp:Panel ID="pnlServicio" runat="server" Visible="true">
                                    <tr>
                                        <td align="right" class="myLabelIzquierda">Servicio:
                                        </td>
                                        <td></td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlServicio" runat="server" CssClass="myList" ValidationGroup="gr1"
                                                OnSelectedIndexChanged="ddlServicio_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RangeValidator ID="rq_ddlServicio" runat="server" ControlToValidate="ddlServicio"
                                                MinimumValue="0" MaximumValue="999" ValidationGroup="gr1" ErrorMessage="(*)"
                                                EnableClientScript="false"></asp:RangeValidator>
                                        </td>
                                    </tr>
                                </asp:Panel>
                              <%--  <tr>
                                    <td align="right" class="myLabelIzquierda">Especialidad/Prestación:
                                    </td>
                                    <td></td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="myList" ValidationGroup="gr1"
                                            OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RangeValidator ID="rq_ddlEspecialidad" runat="server" ControlToValidate="ddlEspecialidad"
                                            MinimumValue="1" MaximumValue="999999" ValidationGroup="gr1" ErrorMessage="(*)"
                                            EnableClientScript="false" Type="Integer"></asp:RangeValidator>
                                    </td>
                                </tr>--%>
                                 <tr>
                                    <td align="right" class="myLabelIzquierda">Consultorio:
                                    </td>
                                    <td></td>
                                    <td align="left">
                                        <asp:DropDownList Enabled="false" ID="ddlTipoConsultorio" runat="server" CssClass="myList"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlTipoConsultorio_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:DropDownList Enabled="false" ID="ddlConsultorio" runat="server" CssClass="myList"
                                            ValidationGroup="gr1" OnSelectedIndexChanged="ddlConsultorio_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RangeValidator ID="rq_ddlConsultorio" runat="server" ControlToValidate="ddlConsultorio"
                                            MinimumValue="0" MaximumValue="999" ValidationGroup="gr1" ErrorMessage="(*)"
                                            EnableClientScript="false"></asp:RangeValidator>
                                    </td>
                                </tr>

                                <tr><td>&nbsp;</td></tr>

                                <tr>
                                    <td align="right" class="myLabelIzquierda">Profesional: </td>
                                    <td>&nbsp; </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlProfesional" runat="server" CssClass="myList" ValidationGroup="gr1">
                                        </asp:DropDownList>
                                        <asp:RangeValidator ID="rvProfesional" runat="server" ControlToValidate="ddlProfesional" ErrorMessage="Seleccione un Profesional!" MaximumValue="9999" MinimumValue="0" Type="Integer" ValidationGroup="gr2" />
                                    </td>
                                </tr>

                                <tr>
                                    <td align="right" class="myLabelIzquierda">Especialidad/Prestación:
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlEspecialidadXProfesional" runat="server" CssClass="myList" ValidationGroup="gr1">
                                        </asp:DropDownList>
                                        <asp:RangeValidator ID="rvEspecialidadXProfesional" runat="server" ControlToValidate="ddlEspecialidadXProfesional"
                                            MinimumValue="0" MaximumValue="999" ValidationGroup="gr2" ErrorMessage="(*) "
                                            EnableClientScript="false"></asp:RangeValidator>
                                    </td>
                                </tr>
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>
                                <tr>
                                    <td align="right" class="myLabelIzquierda">Agregar:</td>
                                    <td>&nbsp;
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="imgAgregarProfesionales" ImageUrl="~/App_Themes/consultorio/Agenda/anadir-mas-verde-icono-5682-32.png" runat="server"
                                            OnClick="imgAgregarProfesionales_Click" ToolTip="Agregar Profesional" Visible="true" ValidationGroup="gr2" Width="20px" Height="20px" />
                                    </td>
                                </tr>

                             

                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td style="padding-bottom: 10px; padding-top: 10px;" align="left">
                                        <asp:GridView ID="gdvListaProfesionales" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"
                                            DataKeyNames="idAgendaProfesional" OnPageIndexChanging="gdvListaProfesionales_PageIndexChanging" OnRowCancelingEdit="gdvListaProfesionales_RowCancelingEdit"
                                            OnRowDeleting="gdvListaProfesionales_RowDeleting" OnRowEditing="gdvListaProfesionales_RowEditing" OnRowUpdating="gdvListaProfesionales_RowUpdating">
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <Columns>
                                                <asp:BoundField HeaderText="Id" DataField="idProfesional" />
                                                <asp:TemplateField HeaderText="Profesional">
                                                    <ItemTemplate>
                                                        <asp:Label ID="NombreProfesional" runat="server" Text='<%# Eval("SysProfesional.NombreCompleto")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Especialidad">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Especialidad" runat="server" Text='<%# Eval("SysEspecialidad.Nombre")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:CommandField ShowDeleteButton="true" ControlStyle-Width="20px" ControlStyle-Height="20px" DeleteImageUrl="~/App_Themes/consultorio/Agenda/boton-de-error-icono-5371-32.png" ButtonType="Image" />
                                            </Columns>
                                            <EditRowStyle BackColor="#999999" />
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                        </asp:GridView>

                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="3" class="mytituloPagina">
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnVolver" runat="server" CssClass="linkturnos"  Text="Volver" ValidationGroup="gr1" Width="80px" OnClick="btnVolver_Click" />
                                    </td>
                                    <td align="right" colspan="2">
                                        <asp:Button ID="btnGrabar" runat="server" CssClass="myButton" OnClick="btnGrabar_Click"
                                            Text="Grabar" ValidationGroup="gr1" Width="80px" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="right">
                                        <div>
                                            <!-- errores !-->
                                            <div id="divErr" runat="server" visible="false" style="height: auto; float: left; padding: 5px; border: dotted 1px Maroon; background-color: #F1E2BB;">
                                                <div style="float: left; width: 46px;">
                                                    <img id="imgErr" runat="server" alt="Error" src="../App_Themes/consultorio/Agenda/boton-de-error-icono-5371-48.png" />
                                                </div>
                                                <div>
                                                    <asp:Label ID="lblError" runat="server" class="labelerror" Text="Error" Style="font-weight: bolder; width: 100%;"></asp:Label>
                                                </div>
                                            </div>
                                            <!-- grabado !-->
                                            <div class="div_izquierdo20" style="height: auto; width: 160px; float: right;">
                                                <asp:Button ID="btnReset" Width="80px" runat="server" Text="Resetear" CssClass="myButton"
                                                    OnClick="btnReset_Click" Visible="false" Enabled="False" />
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <br />
                    <br />
                </div>
                <!-- secciones inferior !-->
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
