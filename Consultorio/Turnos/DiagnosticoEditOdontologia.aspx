<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiagnosticoEditOdontologia.aspx.cs"
    Inherits="Consultorio.Turnos.DiagnosticoEditOdontologia" MasterPageFile="~/mConsultorio.Master" UICulture="es" Culture="es-AR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<%@ Register Src="~/ConsultaAmbulatoria/UserControls/PrestacionOdontologia.ascx" TagName="OdontologiaP"
    TagPrefix="uc1" %>

<%@ Register Src="../../UserControls/ConsultorioPaciente.ascx" TagName="ConsultorioPaciente" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Turnos.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="../../js/jquery-ui-1.7.1.custom.css" />
    <%--    <li><a runat="server" href="#tabInterconsulta">Interconsulta</a></li>--%>
    <script type="text/javascript" src='<%= ResolveUrl("../../ControlMenor/js/jquery-1.5.1.min.js") %>'></script>
    <script type="text/javascript" src='<%= ResolveUrl("../../ControlMenor/js/jquery-ui-1.8.9.custom.min.js") %>'></script>
    <script type="text/javascript" src='<%= ResolveUrl("../../ControlMenor/js/jquery.dataTables.min.js") %>'></script>
    <script type="text/javascript" src='<%= ResolveUrl("../../ControlMenor/js/jquery.ui.selectmenu.js") %>'></script>
    <script type="text/javascript" src='<%= ResolveUrl("../../ControlMenor/js/ui.checkbox.js") %>'></script>
    <script type="text/javascript" src='<%= ResolveUrl("../../ControlMenor/js/json2.js") %>'></script>
    <%--    <li><a runat="server" href="#tabInterconsulta">Interconsulta</a></li>--%>
    <link href='<%= ResolveUrl("../../ControlMenor/css/redmond/jquery.ui.all.css") %>'
        rel="stylesheet" type="text/css" />
    <link href='<%= ResolveUrl("../../ControlMenor/css/datatable.css") %>' rel="stylesheet"
        type="text/css" />
    <link href='<%= ResolveUrl("../../ControlMenor/css/jquery.ui.selectmenu.css") %>'
        rel="stylesheet" type="text/css" />
    <link href='<%= ResolveUrl("../../ControlMenor/css/ui.checkbox.css") %>' rel="stylesheet"
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

    <ajx:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </ajx:ToolkitScriptManager>
    <table>
        <tr>
            <td align="left" colspan="3">
                <asp:LinkButton ID="lnkRegresar" runat="server" OnClick="lnkRegresar_Click">Regresar</asp:LinkButton>

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
            <td align="left" colspan="3">
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
                    Text="Imprimir Atención Consultorio" OnClick="btnImprimirConsultorio_Click" Visible="False" />
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
                        Seleccione el paciente
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlDiagnostico" Visible="false" runat="server">
                    <table align="left" width="800px">
                        <tr>
                            <td>
                                <input id="HfidPaciente" type="hidden" runat="server" />
                                <input id="HfDNI" type="hidden" runat="server" />
                                <asp:Label CssClass="myLabelRojoMediano" ID="lblPaciente" runat="server" Text="Label"></asp:Label><br />
                                <asp:Label CssClass="myLabelIzquierda" ID="lblFechaNacimiento" runat="server" Text="Label"></asp:Label>
                                <asp:Label CssClass="myLabelTitulo" ID="lblIdTurno" runat="server" Text="Label" Visible="False"></asp:Label>
                                <asp:Label CssClass="myLabelTitulo" ID="lblIdConsulta" runat="server" Text="Label"
                                    Visible="False">
                                </asp:Label>


                            </td>
                        </tr>

                        <tr>
                            <td id="contenedorSaludMental" runat="server" style="width: 900px;">
                                <div id="tabs">
                                    <asp:Panel runat="server" ID="pnlAtencion">
                                        <ul>
                                            <li><a href="#tab1">Atención Actual</a></li>

                                            <li><a href="#tab2">Historial</a></li>
                                            <li><a href="#tab3">Historial Odontologia</a></li>
                                        </ul>
                                    </asp:Panel>
                                    <div id="tab1" style="width: 800px">
                                        <table style="width: 800px">
                                            <tr>
                                                <td style="width: 600px">
                                                    <table style="width: 600px">
                                                        <tr>
                                                            <td align="rigth" style="vertical-align: top;">

                                                                <uc2:ConsultorioPaciente ID="ConsultorioPaciente1" runat="server" />

                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <fieldset class="ui-widget ui-widget-content ui-corner-all" style="padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                                                                    <legend><b>Programa</b> </legend>

                                                                    <asp:RadioButtonList ID="rdbPrograma" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table">
                                                                    </asp:RadioButtonList>

                                                                    <asp:RequiredFieldValidator ID="rfvPrograma" runat="server" ControlToValidate="rdbPrograma" ErrorMessage="Seleccione un programa" ValidationGroup="0"></asp:RequiredFieldValidator>
                                                                </fieldset>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <fieldset class="ui-widget ui-widget-content ui-corner-all" style="padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                                                                    <legend><b>Condición</b>                                                        </legend>

                                                                    <asp:DropDownList ID="ddlNotificacion" runat="server">
                                                                        <asp:ListItem Selected="True" Value="-1">Seleccione</asp:ListItem>
                                                                        <asp:ListItem Value="1">Primera Vez</asp:ListItem>
                                                                        <asp:ListItem Value="2">Ulterior</asp:ListItem>
                                                                        <asp:ListItem Value="0">No informado</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RangeValidator ID="rvCondicion" runat="server" ControlToValidate="ddlNotificacion" ErrorMessage="Seleccione condicion" MaximumValue="5" MinimumValue="0" Type="Integer" ValidationGroup="0"></asp:RangeValidator>
                                                                </fieldset>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <fieldset class="ui-widget ui-widget-content ui-corner-all" style="padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                                                                    <legend><b>Prestaciones</b></legend>
                                                                    <uc1:OdontologiaP ID="PrestacionP1" runat="server" />

                                                                    <asp:CustomValidator ID="cvCodigoPrestacion" runat="server" ErrorMessage="Seleccione una prestación" OnServerValidate="cvCodigoPrestacion_ServerValidate" TabIndex="1" ValidationGroup="1"></asp:CustomValidator>

                                                                    <br />
                                                                    <asp:UpdatePanel ID="pnlGrilla" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                                                                        <ContentTemplate>

                                                                            <table style="width: 100%">
                                                                                <tr>
                                                                                    <td colspan="11">
                                                                                        <hr />
                                                                                        <br />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>Pieza Dental:</td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtDiente" runat="server" TabIndex="1" Width="40px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>&nbsp;</td>
                                                                                    <td style="width: 39px">&nbsp; Cara:</td>
                                                                                    <td>&nbsp;</td>
                                                                                    <td>&nbsp;</td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="chkCaraO" runat="server" TabIndex="2" Text="O" />
                                                                                        <asp:CheckBox ID="chkCaraV" runat="server" TabIndex="3" Text="V" />
                                                                                        <asp:CheckBox ID="chkCaraL" runat="server" TabIndex="4" Text="L" />
                                                                                        <asp:CheckBox ID="chkCaraP" runat="server" TabIndex="5" Text="P" />
                                                                                        <asp:CheckBox ID="chkCaraM" runat="server" TabIndex="6" Text="M" />
                                                                                        <asp:CheckBox ID="chkCaraD" runat="server" TabIndex="7" Text="D" />
                                                                                    </td>
                                                                                    <td>Cantidad:<asp:RequiredFieldValidator ID="rfvCantidad" runat="server" ControlToValidate="txtCantidad" ErrorMessage="Ingrese cantidad" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtCantidad" runat="server" TabIndex="8" Width="20px">1</asp:TextBox>
                                                                                    </td>
                                                                                    <td>&nbsp;</td>
                                                                                    <td>
                                                                                        <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" TabIndex="9" Text="Agregar" ValidationGroup="1" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="11">

                                                                                        <asp:CustomValidator ID="cvDiente" runat="server" ErrorMessage="Numero de pieza dental inválido" OnServerValidate="cvDiente_ServerValidate1" ValidationGroup="1" ControlToValidate="txtDiente"></asp:CustomValidator>
                                                                                        <br />
                                                                                        <asp:CustomValidator ID="cvDiente0" runat="server" ErrorMessage="Debe ingresar un numero de pieza dental" OnServerValidate="cvDiente0_ServerValidate" ValidationGroup="1" ControlToValidate="txtDiente" ValidateEmptyText="True"></asp:CustomValidator>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="11">
                                                                                        <hr />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="11">
                                                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="idNomenclador" Width="100%" CellPadding="4" ForeColor="#333333" EmptyDataText="No hay prestaciones registradas" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                                            <Columns>
                                                                                                <asp:BoundField DataField="codigo" HeaderText="Codigo">
                                                                                                    <ItemStyle Height="10%" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="descripcion" HeaderText="Descripcion">
                                                                                                    <ItemStyle Height="40%" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="diente" HeaderText="Pieza">
                                                                                                    <ItemStyle Height="10%" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="cara" HeaderText="Cara">
                                                                                                    <ItemStyle Height="10%" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="cantidad" HeaderText="Cantidad">
                                                                                                    <ItemStyle Height="10%" />
                                                                                                </asp:BoundField>
                                                                                                <asp:TemplateField>
                                                                                                    <ItemTemplate>

                                                                                                        <asp:ImageButton ID="cmdQuitar" Height="20px" Width="20px" runat="server" CommandName="Select" AlternateText="Quitar fila"
                                                                                                            ImageUrl="~/App_Themes/consultorio/Agenda/cerrar-icono-3898-16.png" />
                                                                                                    </ItemTemplate>
                                                                                                    <ItemStyle HorizontalAlign="Right" Height="10%" />
                                                                                                </asp:TemplateField>
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
                                                                                        <asp:CustomValidator ID="cvPrestacion" runat="server" ErrorMessage="Agregue prestaciones a la lista" ValidationGroup="0" OnServerValidate="cvPrestacion_ServerValidate"></asp:CustomValidator>
                                                                                        <br />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </fieldset>
                                                            </td>
                                                        </tr>


                                                        <tr>
                                                            <td>&nbsp
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <fieldset class="ui-widget ui-widget-content ui-corner-all" style="padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                                                                    <legend><b>Informe de atención</b>                                                        </legend>
                                                                    <asp:TextBox ID="txtInformeConsulta" runat="server" Height="100px" TextMode="MultiLine"
                                                                        Width="750px"></asp:TextBox>
                                                                </fieldset>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td>&nbsp;</td>
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
                                                </td>
                                                <td style="width: 200px">&nbsp;</td>
                                            </tr>
                                        </table>

                                    </div>
                                    <div id="tab2" style="width: 780px; height: 550px;">
                                        <div style="width: 770px; height: 350pt; overflow: scroll; overflow-x: hidden; border: 1px solid #CCCCCC;">
                                            <asp:GridView AutoGenerateColumns="false" ID="gvHistorial" runat="server" ForeColor="#333333"
                                                EmptyDataText="No se encontraron datos del historial del paciente" BorderColor="#333333"
                                                BorderStyle="Solid" BorderWidth="1px" Font-Names="Calibri" Font-Size="11pt" Width="750px"
                                                CellPadding="2" CellSpacing="2">
                                                <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="#333333" />
                                                <Columns>
                                                    <%--   <asp:BoundField DataField="Dia" HeaderText="" />--%>
                                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                                    <asp:BoundField DataField="Hora" HeaderText="Hora" />
                                                    <asp:BoundField DataField="Efector" HeaderText="Efector" />
                                                    <asp:BoundField DataField="Profesional" HeaderText="Profesional" />
                                                    <asp:BoundField DataField="Diagnostico" HeaderText="Diagnóstico" />
                                                    <asp:BoundField DataField="TipoDiag" HeaderText="Tipo Diag." />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <asp:ImageButton ID="imgImprimirHistorial" runat="server" Width="20px" Height="20px"
                                            ImageUrl="~/App_Themes/consultorio/images/imprimir.jpg"
                                            OnClick="imgImprimirHistorial_Click" ToolTip="Imprimir Historial" />

                                    </div>
                                    <div id="tab3" style="width: 780px; height: 100%;">

                                        <asp:DataList ID="dlHistorialOdontologia" OnItemDataBound="dlHistorialOdontologia_ItemDataBound" RepeatColumns="1" RepeatDirection="Horizontal" runat="server"
                                            RepeatLayout="Table" CellPadding="2" CellSpacing="2">

                                            <ItemTemplate>
                                                <table style="width: 100%; height: 100%; border: dashed 2px #04AFEF; background-color: #EBEBEB; margin-bottom: 10px;">
                                                    <tr>
                                                        <td>
                                                            <b><u><span class="name">
                                                                <%# Eval("Efector") %></span></u></b>
                                                        </td>
                                                    </tr>
                                                    <tr style="padding-bottom: 10px;">
                                                        <td style="padding: 5px 5px 5px 5px;">                                                            
                                                            <b>Fecha: </b><span><%# Eval("Fecha") %></span>&nbsp
                                                            <b>Profesional: </b><span><%# Eval("Profesional") %></span><br />
                                                            <b>Programa: </b><span><%# Eval("Programa") %></span>
                                                            <asp:Label ID="idTurno" runat="server" Text='<%# Eval("idTurno") %>' Visible="false" /><br />
                                                            <b>Informe: </b><span><%# Eval("informe") %></span><br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView AutoGenerateColumns="False" runat="server" ID="gvHistorialOdontologia" ForeColor="#333333"
                                                                EmptyDataText="No se encontraron datos del historial del paciente" Font-Names="Calibri" Font-Size="11pt" Width="750px"
                                                                CellPadding="4" GridLines="Horizontal">
                                                                <EditRowStyle BackColor="#2461BF" />
                                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                <AlternatingRowStyle BackColor="White" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                                                                    <asp:BoundField DataField="Prestacion" HeaderText="Prestacion" />
                                                                    <asp:BoundField DataField="PiezaDental" HeaderText="PiezaDental" />
                                                                    <asp:BoundField DataField="Cara" HeaderText="Cara" />
                                                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                                                </Columns>
                                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                                <RowStyle BackColor="#EFF3FB" />
                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>

                                            </ItemTemplate>



                                        </asp:DataList>



                                        <%--<div style="width: 770px; height: 350pt; overflow: scroll; overflow-x: hidden; border: 1px solid #CCCCCC;">
                                            <asp:GridView AutoGenerateColumns="False" ID="gvHistorialOdontologia" runat="server" ForeColor="#333333"
                                                EmptyDataText="No se encontraron datos del historial del paciente" Font-Names="Calibri" Font-Size="11pt" Width="750px"
                                                CellPadding="4" GridLines="None">
                                                <EditRowStyle BackColor="#2461BF" />
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha"  />
                                                    <asp:BoundField DataField="Efector" HeaderText="Efector" />
                                                    <asp:BoundField DataField="Profesional" HeaderText="Profesional" />
                                                    <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                                                    <asp:BoundField DataField="Prestacion" HeaderText="Prestacion" />
                                                    <asp:BoundField DataField="PiezaDental" HeaderText="PiezaDental" />
                                                    <asp:BoundField DataField="Cara" HeaderText="Cara" />
                                                </Columns>
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#EFF3FB" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                            </asp:GridView>
                                        </div> --%>

                                        <asp:ImageButton ID="imgImprimirHistorialOdontologia" runat="server" Width="20px" Height="20px"
                                            ImageUrl="~/App_Themes/consultorio/images/imprimir.jpg"
                                            OnClick="imgImprimirHistorialOdontologia_Click" ToolTip="Imprimir Historial" />

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
                </asp:Panel>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">


        function PreguntoEliminar() {
            if (confirm('¿Está seguro de eliminar el registro?'))
                return true;
            else
                return false;
        }




    </script>
</asp:Content>
