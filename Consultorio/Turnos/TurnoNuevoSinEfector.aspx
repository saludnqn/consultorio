<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TurnoNuevoSinEfector.aspx.cs" Inherits="Consultorio.Turnos.TurnoNuevoSinEfector"
    MasterPageFile="~/mConsultorio.Master"   UICulture="es" Culture="es-AR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Subsonic" Namespace="SubSonic" TagPrefix="subsonic" %>
<%@ Register Src="~/UserControls/ObrasSociales.ascx" TagName="OSociales" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
    <link href="../Turnos.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="../../js/jquery-ui-1.7.1.custom.css" />
    <script type="text/javascript" src="../../js/jquery.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.ui.datepicker-es.js"></script>
    <script type="text/javascript" src="../../js/Mascara.js"></script>
    <script type="text/javascript" src="../../js/ValidaFecha.js"></script>
    <script type="text/javascript" src="../../js/tooltips/jquery.tools.min.js"></script>
    <script type="text/javascript" src='<%= ResolveUrl("~/ControlMenor/js/jquery-1.5.1.min.js") %>'></script>
    <script type="text/javascript" src='<%= ResolveUrl("~/ControlMenor/js/jquery-ui-1.8.9.custom.min.js") %>'></script>
    <script type="text/javascript" src='<%= ResolveUrl("~/ControlMenor/js/json2.js") %>'></script>
    <link href='<%= ResolveUrl("~/ControlMenor/css/redmond/jquery.ui.all.css") %>' rel="stylesheet"
        type="text/css" />
    <script type="text/javascript">
        function callServersideMethod(valueToSend) {
            __doPostBack('callServersideMethod', valueToSend);
        }

        $(document).ready(function () {
            // fix for postbacks to show panels

            $('#tabs').tabs({
                // add show tab hook to save currently shown tab.
                show: function () {
                    var newIndex = $('#tabs').tabs('option', 'selected');
                    $("#<%= selectedtab.ClientID %>").val(newIndex);
                }
                // make sure the correct tab is selected.
                // selected: selectedTabIndex
            });
        });




    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">
    <br />
    &nbsp;
    
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <input type="hidden" value="0" id="selectedtab" name="selectedtab" enableviewstate="true"
        runat="server" />
    <table width="1000px;">
        <tr>
            <td align="left" colspan="2" class="mytituloPagina">
                <br />
                <asp:Label ID="lblTitulo" runat="server" Text="Label"></asp:Label>
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                <table width="800px">
                    <tr>
                        <td class="myLabelTitulo" align="left" colspan="5">
                            <asp:Label ID="lblPaciente" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td width="70px">
                            &nbsp;
                        </td>
                        <td width="70px" class="myLabelIzquierda" align="left">
                            &nbsp;
                        </td>
                        <td width="70px">
                            &nbsp;
                        </td>
                        <td width="70px" class="myLabelIzquierda" align="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="myLabelIzquierda" width="200px" align="left">
                            Nro. DNI:
                        </td>
                        <td align="left" width="70px">
                            <asp:Label ID="lblDni" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td class="myLabelIzquierda" width="70px" align="left">
                            &nbsp;
                        </td>
                        <td align="myLabelIzquierda" width="70px">
                            HC:
                        </td>
                        <td class="myLabelIzquierda" align="left">
                            <asp:TextBox ID="txtHistoriaClinica" runat="server" Width="60px"></asp:TextBox>
                            <asp:Button ID="btnGuardarHC" runat="server" Text="Guardar HC" OnClick="btnGuardarHC_Click"
                                Width="70px" />
                        </td>
                        <td colspan="4">
                            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <%-- <tr>
                       <td  class="myLabelIzquierda" width="200px" align="left">Fecha Nac.</td>
                       <td align="left" width="70px"> <asp:Label ID="lblFechaNacimiento" runat="server" Text="Label"></asp:Label></td>
                       <td class="myLabelIzquierda" width="70px" align="left">   &nbsp;</td>
                       <td class="myLabelIzquierda" align="left" width="70px">Edad:</td>
                       <td class="myLabelIzquierda" align="left" > 
                           <asp:Label ID="lblEdad" runat="server" Text="Label"></asp:Label></td>
                       <td width="70px">&nbsp;</td>
                       <td width="70px" class="myLabelIzquierda" align="left"> &nbsp;</td>
                       <td width="70px">&nbsp;</td>
                       <td width="70px" class="myLabelIzquierda" align="left"> &nbsp;</td>
                       </tr>--%>
                    <tr>
                        <td class="myLabelIzquierda" width="200px" align="left" style="vertical-align: top">
                            Obra Social:&nbsp;
                        </td>
                        <td class="myLabelIzquierda" align="left" colspan="4">
                            <uc1:OSociales ID="OSociales" runat="server" TabIndex="8" ValidationGroup="0" Requerido="true" />
                        </td>
                        <td width="70px">
                            &nbsp;
                        </td>
                        <td width="70px" class="myLabelIzquierda" align="left">
                            &nbsp;
                        </td>
                        <td width="70px">
                            &nbsp;
                        </td>
                        <td width="70px" class="myLabelIzquierda" align="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="myLabelTitulo" width="200px" align="left" colspan="5">
                            <img src="../../App_Themes/consultorio/Agenda/alerta.png" runat="server" id="imgAsistencia" />
                            <asp:Label ID="lblInasistencia" CssClass="myLabelRojo" runat="server" Text="Label"> </asp:Label>
                        </td>
                        <td width="70px">
                            &nbsp;
                        </td>
                        <td width="70px" class="myLabelIzquierda" align="left">
                            &nbsp;
                        </td>
                        <td width="70px">
                            &nbsp;
                        </td>
                        <td width="70px" class="myLabelIzquierda" align="left">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <%--<tr>
                    <td class="myLabelIzquierda"  align="left" colspan="2" >
                     
                     
                        
                        
                    
                      
                        </td>
            

                </tr>--%>
        <%-- <tr>
                    <td align="left" colspan="2" >
           
                        </td>
            

                </tr>   --%>
        <tr>
            <td style="vertical-align: top; width: 100%;">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="tabs" style="width: 100%; height: 700px;">
                            <ul>
                                <li><a href="#tab3">Asignacion</a></li>
                                <li><a href="#tab1">Turnos Dados</a></li>
                                <li><a href="#tab2">Historial</a></li>
                                <li><a href="#tab4">Demanda Rechazada</a></li>
                            </ul>
                            <div id="tab1" style="width: 95%; height: 500px; overflow: auto; left: -20px;">
                                <h1 class="myLabelIzquierda">
                                    Turnos dados a partir de hoy</h1>
                                <asp:DataList ID="gvTurnosPaciente" runat="server" CellPadding="4" ForeColor="#333333"
                                    RepeatColumns="1" ItemStyle-HorizontalAlign="Center" Width="90%" HorizontalAlign="Left"
                                    RepeatDirection="Horizontal" ShowFooter="False" ShowHeader="False" CaptionAlign="Left">
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <li><b>
                                                        <%# DataBinder.Eval(Container.DataItem, "Dia") %>&nbsp;&nbsp;
                                                        <%# DataBinder.Eval(Container.DataItem, "Fecha") %>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "Hora") %>&nbsp;hs.</b></li>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Efector: <b>
                                                        <%# DataBinder.Eval(Container.DataItem, "Efector") %></b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Especialidad:<b>
                                                        <%# DataBinder.Eval(Container.DataItem, "Especialidad") %></b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Profesional: <b>
                                                        <%# DataBinder.Eval(Container.DataItem, "Profesional") %></b>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </ItemTemplate>
                                </asp:DataList>
                            </div>
                            <div id="tab2" style="width: 90%; height: 500px; overflow: auto;">
                                <h1 class="myLabelIzquierda">
                                    Turnos anteriores al día de hoy</h1>
                                <asp:DataList ID="gvHistorial" runat="server" CellPadding="4" ForeColor="#333333"
                                    RepeatColumns="1" ItemStyle-HorizontalAlign="Center" Width="90%" HorizontalAlign="Left"
                                    RepeatDirection="Horizontal" ShowFooter="False" ShowHeader="False" EmptyDataText="No se encontraron datos del historial del paciente"
                                    CaptionAlign="Left" OnItemDataBound="gvHistorial_ItemDataBound">
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <li><b>
                                                        <asp:Label ID="lblAsistencia" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Asistencia")%>'></asp:Label>
                                                        <%# DataBinder.Eval(Container.DataItem, "Dia") %>&nbsp;&nbsp;
                                                        <%# DataBinder.Eval(Container.DataItem, "Fecha") %>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "Hora") %>&nbsp;hs.
                                                        <br />
                                                        Asistencia :&nbsp;
                                                        <asp:Image ID="imgAsistencia" runat="server" ImageUrl="~/App_Themes/default/images/transparente.jpg" />
                                                    </b></li>
                                                </td>
                                            </tr>
                                            <tr>
                                            <tr>
                                                <td>
                                                    Efector:<b>
                                                        <%# DataBinder.Eval(Container.DataItem, "Efector") %></b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Especialidad:<b>
                                                        <%# DataBinder.Eval(Container.DataItem, "Especialidad") %></b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Profesional:<b>
                                                        <%# DataBinder.Eval(Container.DataItem, "Profesional") %></b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Tipo de Diagnóstico:<b>
                                                        <%# DataBinder.Eval(Container.DataItem, "TipoDiag")%></b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Diagnóstico:<b>
                                                        <%# DataBinder.Eval(Container.DataItem, "Diagnostico")%></b>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </ItemTemplate>
                                </asp:DataList>
                            </div>
                            <div id="tab3" style="width: 100%;">
                                <asp:UpdatePanel ID="updturnos" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table style="width: 95%">
                                            <tr>
                                                <td style="vertical-align: top">
                                                    <asp:Panel ID="pnlinferior" runat="server" CssClass="modalPanel">
                                                        <div id="divfiltro" runat="server" visible="true" style="width: 100%">
                                                            <asp:UpdatePanel ID="updfiltro" runat="server">
                                                                <ContentTemplate>
                                                                    <table style="width: 100%">
                                                                        <tr>
                                                                            <asp:Panel ID="pnlServicio" runat="server" Visible="true">
                                                                                <td align="right" class="myLabelIzquierda">
                                                                                    Servicio:
                                                                                </td>
                                                                                <td colspan="3" align="left">
                                                                                    <asp:DropDownList ID="ddlServicio" runat="server">
                                                                                    </asp:DropDownList>
                                                                                    <%--                           &nbsp;
                            <asp:LinkButton ID="btnGrabarRechazo" CssClass="myLink" OnClick="btnGrabarRechazo_Click" runat="server">Registrar Demanda Rechazada</asp:LinkButton>--%>
                                                                                </td>
                                                                            </asp:Panel>
                                                                            <td colspan="2" align="left" class="myLabelIzquierda">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right" class="myLabelIzquierda">
                                                                                Especialidad:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="ddlEspecialidad" Width="200px" runat="server">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td class="myLabelIzquierda" align="right">
                                                                                Profesional:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="ddlProfesional" Width="200px" runat="server">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right" class="myLabelIzquierda">
                                                                                Desde:
                                                                            </td>
                                                                            <td class="myLabelIzquierda" align="left">
                                                                                <asp:TextBox ID="txtFechaDesde" Width="80px" runat="server"></asp:TextBox>
                                                                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="cal_Theme1"
                                                                                    FirstDayOfWeek="Monday" TargetControlID="txtFechaDesde" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy">
                                                                                </asp:CalendarExtender>
                                                                            </td>
                                                                            <td align="right" class="myLabelIzquierda">
                                                                                Hasta:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:TextBox ID="txtFechaHasta" Width="80px" runat="server"></asp:TextBox>
                                                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1"
                                                                                    FirstDayOfWeek="Monday" TargetControlID="txtFechaHasta" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy">
                                                                                </asp:CalendarExtender>
                                                                                &nbsp; &nbsp;
                                                                                <asp:CheckBox CssClass="myLabelIzquierda" ID="chkFiltro" runat="server" Text="Solo turnos libres"
                                                                                    Checked="true" />
                                                                            </td>
                                                                            <td align="left" colspan="2">
                                                                                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar Vista" CssClass="myButton"
                                                                                    OnClick="btnActualizar_Click" Width="140px" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="celdaagendas" class="modalPanel" style="vertical-align: top; width: 100%;
                                                    height: 500px;">
                                                    <table>
                                                        <tr>
                                                            <td style="vertical-align: top;">
                                                                <asp:UpdatePanel ID="updfechas" runat="server">
                                                                    <ContentTemplate>
                                                                        <div id="divfechaserr" class="identincorrecta" runat="server" visible="false">
                                                                            <asp:Label ID="lblFechasErr" runat="server" Text="No se encontraron agendas" CssClass="labelerror"></asp:Label>
                                                                        </div>
                                                                        <div id="divfechas" runat="server" visible="false">
                                                                            <div id="divfechasok" style="height: 50px;" runat="server" visible="false">
                                                                                <br />
                                                                                <div id="datosagenda" align="center">
                                                                                    <h1 class="myLabelRojo">
                                                                                        Fechas disponibles: &nbsp;
                                                                                        <asp:DropDownList ID="ddlFechas" runat="server" OnSelectedIndexChanged="ddlFechas_SelectedIndexChanged"
                                                                                            AutoPostBack="True">
                                                                                        </asp:DropDownList>
                                                                                    </h1>
                                                                                    <br />
                                                                                    &nbsp;&nbsp;
                                                                                    <br />
                                                                                </div>
                                                                            </div>
                                                                            <div id="div1" style="height: 400px; width: 350px; overflow: auto;">
                                                                                <asp:GridView ID="gvFechas" runat="server" AllowPaging="False" AutoGenerateColumns="False"
                                                                                    CellPadding="4" GridLines="Both" DataKeyNames="idAgenda" SelectedIndex="0" Width="100%"
                                                                                    EmptyDataText="No se encontraron agendas para los filtros propuestos." OnRowCommand="gvFechas_RowCommand"
                                                                                    OnRowDataBound="gvFechas_RowDataBound" OnSelectedIndexChanged="gvFechas_SelectedIndexChanged"
                                                                                    ForeColor="#333333" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                                                                    Font-Names="Calibri" Font-Size="10pt">
                                                                                    <PagerStyle Font-Underline="True" HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White" />
                                                                                    <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="#333333" />
                                                                                    <Columns>
                                                                                        <%-- <asp:BoundField  DataField="idAgenda" HeaderText="Nro.">
                                </asp:BoundField>--%>
                                                                                        <asp:BoundField DataField="Efector" HeaderText="Efector"></asp:BoundField>
                                                                                        <asp:BoundField DataField="Profesional" HeaderText="Profesional"></asp:BoundField>                                                                                        
                                                                                        <asp:BoundField DataField="Consultorio" HeaderText="Cons."></asp:BoundField>
                                                                                        <%-- <asp:BoundField DataField="maximoSobreturnos" HeaderText="S.Turno" >
                                </asp:BoundField>--%>
                                                                                        <asp:TemplateField>
                                                                                            <ItemTemplate>
                                                                                                <%--<asp:ImageButton ID="Select" CommandName="Select" runat="server" AlternateText="Seleccionar"
                                                                                                    ImageUrl="~/App_Themes/consultorio/Agenda/seleccionar.png" />--%>
                                                                                                <asp:LinkButton ID="Select" runat="server" AlternateText="seleccionar" CommandName="Select">
                                                                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/consultorio/Agenda/seleccionar.png"
                                                                                                        Style="border-width: 0px;" />
                                                                                                </asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <EditRowStyle BackColor="#2461BF" />
                                                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </div>
                                                                        <div id="divinfo" runat="server" class="left_content" style="width: auto" visible="true">
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                            <td>
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td style="vertical-align: top; height: 500px;">
                                                                <asp:UpdatePanel ID="updgrilla" runat="server" Visible="true">
                                                                    <ContentTemplate>
                                                                        <div>
                                                                            <div id="divgrillaerr" class="identincorrecta" runat="server" visible="false">
                                                                                <asp:Label ID="lblGrillaErr" runat="server" Text="No se encontraron turnos según criterio especificado"
                                                                                    CssClass="labelerror"></asp:Label>
                                                                            </div>
                                                                            <div id="divgrilla" runat="server" visible="false">
                                                                                <div id="divgrillaok" runat="server" visible="false">
                                                                                    <asp:Label CssClass="myLabelRojo" ID="lblGrillaOk" runat="server" Text="" Font-Size="10"></asp:Label>
                                                                                    <br />
                                                                                    <asp:Label CssClass="myLabelIzquierda" ID="lblGrillaOk1" runat="server" Text=""></asp:Label>
                                                                                    <table cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td>
                                                                                                Total Turnos:
                                                                                                <asp:Label CssClass="myLabelIzquierda" ID="lblTotalTurnosEspecialidad" runat="server"
                                                                                                    Text=""></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                Turnos Dia:
                                                                                                <asp:Label CssClass="myLabelIzquierda" ID="lblTurnosDiaEspecialidad" runat="server"
                                                                                                    Text=""></asp:Label>
                                                                                                (
                                                                                                <asp:Label CssClass="myLabelRojo" ID="lblTurnosDiaEspecialidad1" runat="server" Text=""></asp:Label>
                                                                                                )
                                                                                            </td>
                                                                                            <td>
                                                                                                Turnos Anticipados:
                                                                                                <asp:Label CssClass="myLabelIzquierda" ID="lblTurnosAnticipadosEspecialidad" runat="server"
                                                                                                    Text="">  
                                                                                                </asp:Label>
                                                                                                (
                                                                                                <asp:Label CssClass="myLabelRojo" ID="lblTurnosAnticipadosEspecialidad1" runat="server"
                                                                                                    Text=""></asp:Label>
                                                                                                )
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </div>
                                                                            <div id="divscroll" style="width: 600px; border: 1px ridge #C0C0C0; height: 380px;
                                                                                overflow: auto; float: left">
                                                                                <asp:GridView ID="gvTurnos" CssClass="myLabelIzquierda" runat="server" AutoGenerateColumns="False"
                                                                                    CellPadding="4" GridLines="Both" DataKeyNames="idTurno" ForeColor="#333333" Width="100%"
                                                                                    OnRowDataBound="gvTurnos_RowDataBound" OnSelectedIndexChanged="gvTurnos_SelectedIndexChanged"
                                                                                    Font-Names="Calibri" Font-Size="10pt">
                                                                                    <PagerStyle Font-Underline="True" HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White" />
                                                                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                                    <RowStyle BackColor="#EFF3FB" />
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="">
                                                                                            <ItemTemplate>
                                                                                                <asp:Image ID="imgTurno" runat="server" />
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="Hora" HeaderText=" Hora" Visible="true">
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="DNI" HeaderText="DNI" Visible="true">
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="HC" HeaderText="HC" Visible="true">
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="Paciente" Visible="true" HeaderText="Paciente">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="45%" />
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="usuario" HeaderText="Asig. por">
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle Width="15%" />
                                                                                        </asp:BoundField>
                                                                                        <asp:TemplateField>
                                                                                            <ItemTemplate>
                                                                                                <%-- <asp:ImageButton CommandName="Select" ID="cmdSelTurno" runat="server" AlternateText="seleccionar"
                                                                                                    ImageUrl="~/App_Themes/consultorio/Agenda/seleccionar.png" />--%>
                                                                                                <asp:LinkButton ID="cmdSelTurno" runat="server" AlternateText="seleccionar" CommandName="Select">
                                                                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/consultorio/Agenda/seleccionar.png"
                                                                                                        Style="border-width: 0px;" />
                                                                                                </asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Right" Width="100px" />
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <EditRowStyle BackColor="#2461BF" />
                                                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                    <ContentTemplate>
                                                                        <div id="divgrabado" runat="server" visible="true">
                                                                            <table width="400px;">
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <div id="divturnoseleccionado" runat="server" style="vertical-align: top;" visible="false">
                                                                                            <asp:Label ID="lblHora" runat="server" CssClass="myLabelRojoGde" Font-Bold="True"></asp:Label>
                                                                                            <asp:HiddenField ID="hdnHora" runat="server" />
                                                                                            <br />
                                                                                            <asp:RequiredFieldValidator ID="rfvTipoTurno" runat="server" ControlToValidate="rdbTipoTurno"
                                                                                                ErrorMessage="Seleccione tipo de turno" ValidationGroup="0"></asp:RequiredFieldValidator>
                                                                                            <asp:RadioButtonList ID="rdbTipoTurno" runat="server" RepeatDirection="Horizontal">
                                                                                                <asp:ListItem Value="0">Turno del Día</asp:ListItem>
                                                                                                <asp:ListItem Value="1">Turno Anticipado</asp:ListItem>
                                                                                            </asp:RadioButtonList>
                                                                                        </div>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Button ID="btnGrabar" runat="server" CssClass="myButton" OnClick="btnGrabar_Click"
                                                                                            Text="Grabar" ValidationGroup="0" Visible="false" Width="120px" />
                                                                                        <br />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                        <div id="divcomprobante" runat="server" visible="false">
                                                                            <div id="divcomprobantecontenido" runat="server">
                                                                                <table style="width: 400px; border: thin solid #CCCCCC;">
                                                                                    <tr>
                                                                                        <td style="text-align: left; width: 33%;">
                                                                                            <input type="hidden" runat="server" id="nroTurno" />
                                                                                            <asp:Label ID="lblComprobante" runat="server" Text="" Visible="false" CssClass="myLabelRojo"></asp:Label>
                                                                                            <asp:Label ID="lblComprobanteFecha" runat="server" Text="" CssClass="myLabelRojo"></asp:Label>
                                                                                        </td>
                                                                                        <td style="text-align: left; width: 33%;">
                                                                                            <asp:Label ID="lblComprobanteConsultorio" runat="server" Text="" CssClass="myLabelRojo"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" style="text-align: left; width: 33%;">
                                                                                            <asp:Label ID="lblComprobanteProfesional" runat="server" Text="" CssClass="myLabelRojo"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="text-align: left; width: 50%;">
                                                                                            <asp:Label ID="lblComprobanteBloque" runat="server" Text="" CssClass="myLabelRojoGde"></asp:Label>
                                                                                        </td>
                                                                                        <td style="text-align: left; width: 50%;">
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <br />
                                                                                <asp:Button ID="btnContinuar" runat="server" Text="Continuar" CssClass="myButtonRojo"
                                                                                    Width="120px" OnClick="btnContinuar_Click" />
                                                                                <asp:Button ID="btnTerminar" runat="server" Text="Terminar" CssClass="myButtonRojo"
                                                                                    Width="120px" OnClick="btnTerminar_Click" />
                                                                            </div>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div id="tab4">
                                <%--  <div id="divConfirma" runat="server" visible="false" style="width:500px; height:80px; border:solid 1px Gray; padding:0px; overflow:auto;">
                           
                            <div style="text-align:center;width:100%;">
                              <asp:Label ID="lblConfirma" Text="¿Está seguro de registrar una demanda rechazada para este Paciente?" runat="server" style="font-weight:bolder;"></asp:Label>
                              <input type="hidden" id="inpConfirma" runat="server" value="" />
                            </div>
                            <div style="text-align:center;width:100%;">
                              <asp:Button ID="cmdSi" runat="server" Text="Si" CssClass="boxcortos" 
                                 onclick="cmdSi_Click" style="text-align:center;" /> &nbsp;
                              <asp:Button ID="cmdNo" runat="server" Text="No" CssClass="boxcortos" 
                                style="text-align:center;" onclick="cmdNo_Click"/>
                            </div>
                          </div>
                       <div id="divError" runat="server" visible="false" style="width:300px; height:25px; border:solid 1px Gray;  background-color:#F1E2BB; overflow:auto;">
                           
                            <div style="float:left; text-align:left; width:300px;">
                              <b class="labelerror" style="font-weight:bolder;">Debe seleccionar un servicio</b>
                            </div>
                          </div>--%>
                                <table style="width: 100%;" align="left">
                                    <tr>
                                        <td class="mytituloPagina" colspan="3">
                                            Nuevo registro de demanda rechazada &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="myLabelIzquierda" align="left" style="vertical-align: top">
                                            Especialidad:
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlEspecialidadDR" runat="server">
                                            </asp:DropDownList>
                                            <asp:RangeValidator ID="rvEspecialidadDR" runat="server" ControlToValidate="ddlEspecialidadDR"
                                                ErrorMessage="*" MaximumValue="999999" MinimumValue="1" Type="Integer" ValidationGroup="DR"></asp:RangeValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="myLabelIzquierda" align="left" style="vertical-align: top">
                                            Motivo:
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlMotivoRechazo" runat="server">
                                            </asp:DropDownList>
                                            <asp:RangeValidator ID="rvMotivoRechazo" runat="server" ControlToValidate="ddlMotivoRechazo"
                                                ErrorMessage="*" MaximumValue="999999" MinimumValue="1" Type="Integer" ValidationGroup="DR"></asp:RangeValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="myLabelIzquierda" align="left" style="vertical-align: top">
                                            Observaciones:
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtObservacionesDR" runat="server" Width="400px" TextMode="MultiLine"
                                                Rows="3"></asp:TextBox>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="2">
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnDemandaRechazada" CssClass="myButtonRojo" runat="server" Text="Registrar Demanda Rechazada"
                                                Width="220px" OnClick="btnDemandaRechazada_Click" ValidationGroup="DR" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" align="right">
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" align="left">
                                            <br />
                                            <a class="mytituloPagina">Registros de demandas no satisfechas para el paciente</a>
                                            <br />
                                            <asp:GridView ID="gvDemandaRechazada" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                CellPadding="4" GridLines="Both" SelectedIndex="0" Width="100%" EmptyDataText="No se encontraron registros de demanda rechazada para el paciente"
                                                ForeColor="#333333" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                                Font-Names="Calibri" Font-Size="10pt">
                                                <PagerStyle Font-Underline="True" HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White" />
                                                <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="#333333" />
                                                <Columns>
                                                    <asp:BoundField DataField="fecha" HeaderText="Fecha"></asp:BoundField>
                                                    <asp:BoundField DataField="efector" HeaderText="Efector"></asp:BoundField>
                                                    <asp:BoundField DataField="especialidad" HeaderText="Especialidad"></asp:BoundField>
                                                    <asp:BoundField DataField="motivo" HeaderText="Motivo"></asp:BoundField>
                                                    <asp:BoundField DataField="observaciones" HeaderText="Observaciones"></asp:BoundField>
                                                    <asp:BoundField DataField="usuario" HeaderText="Usuario"></asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
