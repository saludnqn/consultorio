<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiagnosticoEdit.aspx.cs"
    Inherits="Consultorio.Turnos.DiagnosticoEdit" MasterPageFile="~/mConsultorio.Master" UICulture="es" Culture="es-AR" %>

<%@ Register Src="~/ConsultaAmbulatoria/UserControls/DiagnosticoPrincipal.ascx" TagName="DiagnosticoP"
    TagPrefix="uc1" %>
<%@ Register Src="~/ConsultaAmbulatoria/UserControls/DiagnosticoSecundario.ascx"
    TagName="DiagnosticoSecundario" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Turnos.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="../js/jquery-ui-1.7.1.custom.css" />
    <%--    <li><a runat="server" href="#tabInterconsulta">Interconsulta</a></li>--%>
    <script type="text/javascript" src='<%= ResolveUrl("../ControlMenor/js/jquery-1.5.1.min.js") %>'></script>
    <script type="text/javascript" src='<%= ResolveUrl("../ControlMenor/js/jquery-ui-1.8.9.custom.min.js") %>'></script>
    <script type="text/javascript" src='<%= ResolveUrl("../ControlMenor/js/jquery.dataTables.min.js") %>'></script>
    <script type="text/javascript" src='<%= ResolveUrl("../ControlMenor/js/jquery.ui.selectmenu.js") %>'></script>
    <script type="text/javascript" src='<%= ResolveUrl("../ControlMenor/js/ui.checkbox.js") %>'></script>
    <script type="text/javascript" src='<%= ResolveUrl("../ControlMenor/js/json2.js") %>'></script>
    <%--    <li><a runat="server" href="#tabInterconsulta">Interconsulta</a></li>--%>
    <link href='<%= ResolveUrl("../ControlMenor/css/redmond/jquery.ui.all.css") %>'
        rel="stylesheet" type="text/css" />
    <link href='<%= ResolveUrl("../ControlMenor/css/datatable.css") %>' rel="stylesheet"
        type="text/css" />
    <link href='<%= ResolveUrl("../ControlMenor/css/jquery.ui.selectmenu.css") %>'
        rel="stylesheet" type="text/css" />
    <link href='<%= ResolveUrl("../ControlMenor/css/ui.checkbox.css") %>' rel="stylesheet"
        type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            // Formatea y desoculta la botonera en caso de necesitarse.
            if ($('#botonera').children().size() > 0) {
                $('#botonera > input').button();
                $('#botonera').show();
            }
            // Busca y formatea las grillas que haya.
            $('.grilla').dataTable({
                "bJQueryUI": true,
                "oLanguage": {
                    "sSearch": "Buscar:",
                    "sLengthMenu": "Mostrar _MENU_ ítems por página",
                    "sZeroRecords": "No se encontró nada",
                    "sInfo": "Mostrando _START_ a _END_ de _TOTAL_ ítems",
                    "sInfoEmpty": "Mostrando 0 a 0 de 0 ítems",
                    "sInfoFiltered": "(filtrado de _MAX_ ítems totales)"
                },
                "iDisplayLength": 10,
                "aaSorting": [[1, "asc"]],
                "aoColumnDefs": [
			            { "bSortable": false, "aTargets": [0] }
                ]
            });
            // Formatea las cajas de texto
            $('input[type=text]').addClass("ui-widget-content ui-corner-all");
            $('textarea').addClass("ui-widget-content ui-corner-all");
            // Formatea los selects (sólo los chicos, para que no exploten)
            $('select').filter(function (index) { return ($(this).children().size() < 50); }).selectmenu();
            // Agrega los datepickers (todo campo de texto que incluya "Fecha" en el nombre).
            $.datepicker.setDefaults($.datepicker.regional["es"]);
            $('input[type=text][name*=Fecha]').datepicker({
                showOn: "button",
                buttonText: "Elija",
                dateFormat: "dd/mm/yy"
            });
            // Formatea botones de los datepickers
            $('button.ui-datepicker-trigger').button({
                icons: { primary: "ui-icon-calendar" },
                text: false
            });
            // Formatea radiobuttons
            $('input[type=radio][name^=ui]').checkbox();
            // Formatea checkboxes
            $('input[type=checkbox]').checkbox();
        });
    </script>
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
                },
                // make sure the correct tab is selected.
                // selected: selectedTabIndex
            });
        });




    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">
    <br />

    <table>
        <tr>
            <td align="left" colspan="3">
                <asp:LinkButton ID="lnkRegresar" runat="server" OnClick="lnkRegresar_Click">Regresar</asp:LinkButton>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3" class="mytituloPagina">DIAGNOSTICOS<hr />
            </td>
        </tr>
        <input type="hidden" value="0" id="selectedtab" name="selectedtab" enableviewstate="true"
            runat="server" />
        <tr>
            <td align="left" colspan="3" style="width: 80px">
                <asp:ListView ID="lstProfesionales" runat="server">
                    <ItemTemplate>
                        <asp:Label Text="<%#Container.DataItem %>" CssClass="myLabelTitulo" runat="server" />
                    </ItemTemplate>
                </asp:ListView>
                <hr />
                <asp:Label CssClass="myLabelTitulo" ID="lblTituloAgenda" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3">
                <asp:Label CssClass="myLabelIzquierda" ID="lblFechaAgenda" runat="server" Text=""></asp:Label>
                &nbsp;<asp:Label CssClass="myLabelIzquierda" ID="lblHoraAgenda" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3">
                <asp:Button ID="btnImprimirConsultorio" runat="server"
                    Text="Imprimir Atención Consultorio" OnClick="btnImprimirConsultorio_Click" />
                <br />
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3" class="mytituloPagina">
                <hr />
            </td>
        </tr>
        <tr>
            <td class="myLabelIzquierda" style="vertical-align: top;">
                <div style="border: 1px solid #C0C0C0; background-color: #EBEBEB; height: 400px; width: 320px; overflow: scroll">
                    <asp:GridView ID="gvTurnos" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        GridLines="Both" DataKeyNames="idTurno" ForeColor="#333333" Width="100%" Font-Names="Calibri"
                        Font-Size="10pt" OnSelectedIndexChanged="gvTurnos_SelectedIndexChanged" OnRowDataBound="gvTurnos_RowDataBound">
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
                            <asp:BoundField DataField="DNI" HeaderText="DNI" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="HC" HeaderText="HC" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Paciente" Visible="true" HeaderText="Paciente">
                                <ItemStyle HorizontalAlign="Left" Width="80%" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton Height="20px" Width="20px" CommandName="Select" ID="cmdSelTurno" runat="server" AlternateText="seleccionar"
                                        ImageUrl="~/App_Themes/consultorio/Agenda/seleccionar.png" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" Width="100px" />
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </div>
                <br />
                <br />
            </td>
            <td width="20px"></td>
            <td align="left" style="vertical-align: top;">
                <asp:Panel ID="pnlHola" runat="server" Visible="true" Width="800px">
                    <div class="myLabelRojoGde">
                        Seleccione el paciente a ingresar los diagnosticos
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlDiagnostico" Visible="false" runat="server">
                    <table align="left" width="800px">
                        <tr>
                            <td>

                                <asp:Label CssClass="myLabelRojoMediano" ID="lblPaciente" runat="server" Text="Label"></asp:Label><br />
                                <asp:Label CssClass="myLabelIzquierda" ID="lblFechaNacimiento" runat="server" Text="Label"></asp:Label>
                                <asp:Label CssClass="myLabelTitulo" ID="lblIdTurno" runat="server" Text="Label" Visible="False"></asp:Label>
                                <asp:Label CssClass="myLabelTitulo" ID="lblIdConsulta" runat="server" Text="Label"
                                    Visible="False">
                                </asp:Label>


                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblPacienteAcompaniante" runat="server" CssClass="myLabelRojoMediano" Text="Label" Visible="false"></asp:Label>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:Button ID="btnVolverPacientePrincipal" runat="server" Text="Volver Paciente Principal" Visible="False" OnClick="btnVolverPacientePrincipal_Click" CausesValidation="False" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button ID="btnAgregarAcompañante" runat="server" OnClick="btnAgregarAcompañante_Click1" Text="Agregar Acompañante" Visible="False" />
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:GridView ID="gvTurnosAcompaniante" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="idTurno" Font-Names="Calibri" Font-Size="10pt" ForeColor="Black" OnRowCommand="gvTurnosAcompaniante_RowCommand" OnRowDataBound="gvTurnosAcompaniante_RowDataBound" OnSelectedIndexChanged="gvTurnosAcompaniante_SelectedIndexChanged" Width="100%" BackColor="White" BorderColor="#333333" BorderStyle="Solid" BorderWidth="1px">
                                                <PagerStyle BackColor="White" Font-Underline="True" ForeColor="Black" HorizontalAlign="Right" />
                                                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Image ID="imgTurno0" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Hora" HeaderText=" Hora" Visible="false">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="cmdEliminarTurno0" runat="server" AlternateText="eliminar" CommandName="Eliminar"
                                                                ImageUrl="~/App_Themes/consultorio/Agenda/eliminar.png"
                                                                OnClientClick="return PreguntoEliminar();" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="DNI" HeaderText="DNI" Visible="true">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Paciente" HeaderText="Acompañante terapéutico" Visible="true">
                                                        <ItemStyle HorizontalAlign="Left" Width="60%" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Sexo" HeaderText="Sexo" Visible="true">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="fechaNacimiento" HeaderText="Fecha Nacimiento" Visible="true">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Consulta" HeaderText="Consulta" Visible="true">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField>

                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="cmdSelTurno0" Text="Diagnóstico" CommandName="Select" runat="server" AlternateText="Diagnosticar" />

                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" Width="100px" />
                                                    </asp:TemplateField>

                                                </Columns>
                                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                                <RowStyle BorderColor="#333333" BorderStyle="Solid" />
                                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                <SortedDescendingHeaderStyle BackColor="#242121" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>

                                <br />




                            </td>
                        </tr>
                        <tr>
                            <td id="contenedorSaludMental" runat="server" style="width: 900px;">
                                <div id="tabs">
                                    <asp:Panel runat="server" ID="pnlAtencion">
                                        <ul>
                                            <li><a href="#tab1">Atención Actual</a></li>

                                            <li><a href="#tab2">Historial</a></li>
                                            <%--    <li><a runat="server" href="#tabInterconsulta">Interconsulta</a></li>--%>
                                        </ul>
                                    </asp:Panel>
                                    <div id="tab1" style="width: 780px">
                                        <table style="width: 750px">
                                            <tr>
                                                <td id="tdEquipo" runat="server">
                                                    <b>Equipo Utilizado:
                                                    <br />
                                                    <asp:DropDownList ID="ddlEquipo" runat="server" Width="250px" DataTextField="nombre" DataValueField="idEquipo"></asp:DropDownList>
                                                <br />
                                                <asp:Label ID="lblFaltaEquipo" runat="server" Font-Size="Small" ForeColor="#F75325"></asp:Label>
                                                <br />
                                                <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="tdMotivoConsulta" runat="server">
                                                    <fieldset class="ui-widget ui-widget-content ui-corner-all" style="padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                                                        <legend><b>Motivo de Consulta</b>
                                                        </legend>

                                                        <asp:TextBox ID="txtMotivoConsulta" runat="server" Height="60px" TextMode="MultiLine" Width="650px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvMotivoConsulta" runat="server" ControlToValidate="txtMotivoConsulta" Enabled="False" ErrorMessage="Ingrese un motivo de consulta" ValidationGroup="0"></asp:RequiredFieldValidator>
                                                    </fieldset>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <fieldset class="ui-widget ui-widget-content ui-corner-all" style="padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                                                        <legend><b>Diagnóstico Principal</b></legend>
                                                        <uc1:DiagnosticoP ID="DiagnosticoPrincipal1" runat="server" />
                                                        <asp:DropDownList runat="server" ID="ddlPrimerConsulta" Width="160px">
                                                            <asp:ListItem Text="--Seleccione--" Value="-1" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Primera Vez" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Ulterior" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="No informado" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:CustomValidator ID="cvDiagnostico" runat="server" ErrorMessage="" ValidationGroup="0"
                                                            OnServerValidate="cvDiagnostico_ServerValidate"></asp:CustomValidator>
                                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Debe seleccionar la notificación"
                                                            ControlToValidate="ddlPrimerConsulta" MaximumValue="10" MinimumValue="0" Type="Integer"
                                                            ValidationGroup="0"></asp:RangeValidator>
                                                    </fieldset>
                                                </td>
                                            </tr>


                                            <tr>
                                                <td id="tdDiagnosticoSecundario" runat="server">
                                                    <fieldset class="ui-widget ui-widget-content ui-corner-all" style="padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                                                        <legend>Diagnóstico/s Secundario/s</legend>
                                                        <uc2:DiagnosticoSecundario ID="DiagnosticoSecundario1" runat="server" />
                                                    </fieldset>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="tdVacio_1" runat="server">&nbsp
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="nivelDeAbordaje" runat="server">
                                                    <fieldset class="ui-widget ui-widget-content ui-corner-all" style="padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                                                        <legend>Nivel de Abordaje</legend>
                                                        <asp:DropDownList runat="server" ID="ddlNivelDeAbordaje" Width="160px">
                                                        </asp:DropDownList>
                                                        <asp:RangeValidator ID="rvNivelAbordaje" runat="server" ErrorMessage="Debe seleccionar nivel de abordaje"
                                                            ControlToValidate="ddlNivelDeAbordaje" MaximumValue="10" MinimumValue="1" Type="Integer"
                                                            ValidationGroup="0" Enabled="False"></asp:RangeValidator>
                                                    </fieldset>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="tdVacio_2" runat="server">&nbsp
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="tipoPrestacion" runat="server">
                                                    <fieldset class="ui-widget ui-widget-content ui-corner-all" style="padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                                                        <legend>Tipo de Prestación</legend>
                                                        <asp:DropDownList runat="server" ID="ddlTipoPrestacion" Width="160px">
                                                        </asp:DropDownList>
                                                        <asp:RangeValidator ID="rvTipoPrestacion" runat="server" ErrorMessage="Debe seleccionar tipo de prestación"
                                                            ControlToValidate="ddlTipoPrestacion" MaximumValue="10" MinimumValue="1" Type="Integer"
                                                            ValidationGroup="0" Enabled="False"></asp:RangeValidator>
                                                    </fieldset>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="tdVacio_3" runat="server">&nbsp
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="tiempoInsumido" runat="server">
                                                    <fieldset class="ui-widget ui-widget-content ui-corner-all" style="padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                                                        <legend>Tiempo Insumido</legend>
                                                        <asp:DropDownList runat="server" ID="ddlTiempoInsumido" Width="160px">
                                                        </asp:DropDownList>
                                                        <asp:RangeValidator ID="rvTiempoInsumido" runat="server" ErrorMessage="Debe seleccionar el tiempo insumido"
                                                            ControlToValidate="ddlTiempoInsumido" MaximumValue="10" MinimumValue="1" Type="Integer"
                                                            ValidationGroup="0" Enabled="False"></asp:RangeValidator>
                                                    </fieldset>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="tdVacio_4" runat="server">&nbsp
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="demanda" runat="server">
                                                    <fieldset class="ui-widget ui-widget-content ui-corner-all" style="padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                                                        <legend>Demanda - EIO</legend>
                                                        <asp:DropDownList runat="server" ID="ddlDemanda" Width="160px">
                                                        </asp:DropDownList>
                                                        <asp:RangeValidator ID="rvDemanda" runat="server" ErrorMessage="Debe seleccionar la demanda EIO"
                                                            ControlToValidate="ddlDemanda" MaximumValue="10" MinimumValue="1" Type="Integer"
                                                            ValidationGroup="0" Enabled="False"></asp:RangeValidator>
                                                    </fieldset>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="tdVacio_5" runat="server">&nbsp
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="recursoHumano" runat="server">
                                                    <fieldset class="ui-widget ui-widget-content ui-corner-all" style="padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                                                        <legend>Recurso Humano Interviniente</legend>
                                                        <asp:TextBox ID="txtRHInterviniente" MaxLength="20" runat="server"></asp:TextBox>
                                                    </fieldset>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="tdVacio_6" runat="server">&nbsp
                                                </td>
                                            </tr>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp
                            </td>
                        </tr>

                        <tr>
                            <td align="left">
                                <fieldset class="ui-widget ui-widget-content ui-corner-all" style="padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                                    <legend><b>Informe de Atención</b></legend>
                                    <asp:TextBox ID="txtInformeConsulta" runat="server" Height="100px" TextMode="MultiLine"
                                        Width="650px"></asp:TextBox>
                                </fieldset>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Button ID="btnGuardar" runat="server" CssClass="myButton" OnClick="btnGuardar_Click"
                                    Text="Guardar" ValidationGroup="0" Width="150px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">&nbsp;
                            </td>
                        </tr>
                    </table>
                    </div>
                    <div id="tab2" style="width: 780px; height: 550px;">
                        <div style="width: 770px; height: 350pt; overflow: scroll; overflow-x: hidden; border: 1px solid #CCCCCC;">
                            <asp:GridView AutoGenerateColumns="false" ID="gvHistorial" runat="server" ForeColor="#333333"
                                EmptyDataText="No se encontraron datos del historial del paciente" BorderColor="#333333"
                                BorderStyle="Solid" BorderWidth="1px" Font-Names="Calibri" Font-Size="11pt" Width="750px"
                                CellPadding="2" CellSpacing="2" OnRowDataBound="gvHistorial_RowDataBound" DataKeyNames="idAgenda">
                                <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                    <asp:BoundField DataField="Hora" HeaderText="Hora" />
                                    <asp:BoundField DataField="Efector" HeaderText="Efector" />
                                    <asp:TemplateField HeaderText="Profesionales" ItemStyle-Width="30%">
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
                                    <asp:BoundField DataField="Diagnostico" HeaderText="Diagnóstico" />
                                    <asp:BoundField DataField="TipoDiag" HeaderText="Tipo Diag." />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
            </td>
        </tr>
        <tr>
            <td align="left">
                <%--<asp:Panel ID="pnlModulos" runat="server" Visible="false">
    
    <table style="width: 100%;">
    <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:LinkButton ID="lnkControlEmbarazo" runat="server">Control de Embarazo</asp:LinkButton>   &nbsp;
                </td>
                <td align="left">
                    <asp:LinkButton ID="lnkControlMenor" runat="server">Control del Menor</asp:LinkButton>  &nbsp;
                </td>
                 <td align="left">
                    <asp:LinkButton ID="lnkClasificacion" runat="server">Clasificación</asp:LinkButton>  &nbsp;
                </td>
                <td align="left">
                    <asp:LinkButton ID="lnkLaboratorio" runat="server">Laboratorio</asp:LinkButton>  &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
            
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
   </asp:Panel>--%>
            </td>
        </tr>
    </table>
    </asp:Panel> </td> </tr> </table>

      <script language="javascript" type="text/javascript">


          function PreguntoEliminar() {
              if (confirm('¿Está seguro de eliminar el registro?'))
                  return true;
              else
                  return false;
          }

          var IdTurno = $("#<%= lblIdTurno.ClientID %>").val();
          function PacienteCompania() {


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
              $('<iframe src="TurnoNuevoDefault.aspx?Desde=DiagnosticoEdit.aspx&idTurnoAcompaniante=' + IdTurno + '" />').dialog({
                  title: 'Nuevo Acompañante',
                  autoOpen: true,
                  width: 1000,
                  height: 800,
                  modal: true,
                  resizable: false,
                  autoResize: true,
                  overlay: {
                      opacity: 0.5,
                      background: "black"
                  }
              }).width(1000);
          }


      </script>
</asp:Content>
