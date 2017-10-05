<%@ Page Language="C#" AutoEventWireup="true" Title="Consultorio Médico" CodeBehind="Default.aspx.cs" MasterPageFile="~/mConsultorio.Master" Inherits="Consultorio.ConsultorioMedico.Default" %>

<%@ Register Src="~/ConsultaAmbulatoria/UserControls/DiagnosticoPrincipal.ascx" TagName="DiagnosticoP" TagPrefix="uc1" %>
<%@ Register Src="~/ConsultaAmbulatoria/UserControls/DiagnosticoSecundario.ascx" TagName="DiagnosticoSecundario" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Turnos.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="../js/jquery-ui-1.7.1.custom.css" />

    <script type="text/javascript" src='<%= ResolveUrl("../ControlMenor/js/jquery-1.8.18.min.js") %>'></script>
    <script type="text/javascript" src='<%= ResolveUrl("../ControlMenor/js/jquery-ui-1.8.9.custom.min.js") %>'></script>
    <script type="text/javascript" src='<%= ResolveUrl("../ControlMenor/js/jquery.dataTables.min.js") %>'></script>
    <script type="text/javascript" src='<%= ResolveUrl("../ControlMenor/js/jquery.ui.selectmenu.js") %>'></script>
    <script type="text/javascript" src='<%= ResolveUrl("../ControlMenor/js/ui.checkbox.js") %>'></script>
    <script type="text/javascript" src='<%= ResolveUrl("../ControlMenor/js/json2.js") %>'></script>
    <link href='<%= ResolveUrl("../ControlMenor/css/redmond/jquery.ui.all.css") %>' rel="stylesheet" type="text/css" />

    <link href='<%= ResolveUrl("../ControlMenor/css/redmond/jquery.ui.all.css") %>' rel="stylesheet" type="text/css" />   
    <link href='<%= ResolveUrl("../ControlMenor/css/datatable.css") %>' rel="stylesheet" type="text/css" />
    <link href='<%= ResolveUrl("../ControlMenor/css/jquery.ui.selectmenu.css") %>' rel="stylesheet" type="text/css" />
    <link href='<%= ResolveUrl("../ControlMenor/css/ui.checkbox.css") %>' rel="stylesheet" type="text/css" />

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
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">
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
        <td>
            <input type="hidden" value="0" id="selectedtab" name="selectedtab" enableviewstate="true"
                runat="server" />
        </td>
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
                                    <asp:ImageButton CommandName="Select" ID="cmdSelTurno" runat="server" AlternateText="seleccionar"
                                        ImageUrl="~/App_Themes/consultorio/Agenda/seleccionar.png" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" Width="100px" />
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </div>
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
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td id="contenedorSaludMental" runat="server" style="width: 90%;">
                                <div id="tabs">
                                    <asp:Panel runat="server" ID="pnlAtencion">
                                        <ul>
                                            <li><a href="#tab1">Atención Actual</a></li>
                                            <li><a href="#tab2">Historial</a></li>
                                            <%--    <li><a runat="server" href="#tabInterconsulta">Interconsulta</a></li>--%>
                                        </ul>
                                    </asp:Panel>
                                    <div id="tab1" style="width: 900px">
                                        <table style="width: 895px">
                                            <tr>
                                                <td>
                                                    <div style="border: solid 1px #a6c9e2; padding-top: 5px; padding-bottom: 5px;">
                                                        Peso:
                                                        <asp:TextBox ID="txtPeso" runat="server" Width="50px"></asp:TextBox>
                                                        &nbsp;&nbsp;&nbsp;
                                                    Talla:
                                                        <asp:TextBox ID="txtTalla" runat="server" Width="50px"></asp:TextBox>
                                                        &nbsp;&nbsp;&nbsp;
                                                    IMC:
                                                        <asp:TextBox ID="txtImc" runat="server" Width="50px"></asp:TextBox>
                                                        &nbsp;&nbsp;&nbsp;
                                                    <br />
                                                        TA/TD:
                                                        <asp:TextBox ID="txtTa" runat="server" Width="40px"></asp:TextBox>/<asp:TextBox ID="txtTd" runat="server" Width="40px"></asp:TextBox>
                                                        &nbsp;&nbsp;&nbsp;
                                                    Perímero Cefálico:
                                                        <asp:TextBox ID="txtPerimetro" runat="server"></asp:TextBox>
                                                        &nbsp;&nbsp;&nbsp;
                                                    <br />
                                                        Otros Datos:
                                                        <asp:TextBox ID="txtOtros" runat="server" Width="50%"></asp:TextBox>
                                                        <br />
                                                    </div>
                                                </td>
                                                <td>
                                                    <div style="border: solid 1px #a6c9e2; padding-top: 5px; padding-bottom: 5px;">
                                                        <asp:HyperLink ID="hlControlPerinatal" runat="server" ToolTip="Ingreso al Control Perinatal" Visible="false">Ctrol. Perinatal</asp:HyperLink><br /> 
                                                        <asp:HyperLink ID="hlEventos" runat="server" ToolTip="Consulta Eventos del Paciente">Eventos Paciente</asp:HyperLink><br />
                                                        <asp:HyperLink ID="hlReceta" runat="server" ToolTip="Formulario de Recetas">Receta</asp:HyperLink>
                                                        <asp:Button ID="Button3" runat="server"  OnClick="btnInterconsulta_Click" Text="Ver Interconsultas"  Width="150px" />
                                                        <asp:Button ID="Button2" runat="server"  OnClick="btnLabo_Click" Text="Ver Laboratorios"  Width="150px" />
                                                        <asp:HyperLink ID="hlInterconsultas" Visible="false" runat="server" ToolTip="Ingreso a Interconsultas">Interconsultas</asp:HyperLink><br />
                                                        <asp:HyperLink ID="hlLaboratorios" Visible="false" runat="server" ToolTip="Consulta de Resultados de Laboratorio">Laboratorios</asp:HyperLink><br />
                                                      
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <fieldset class="ui-widget ui-widget-content ui-corner-all" style="padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                                                        <legend>Diagnóstico Principal</legend>
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
                                                <td id="tdVacio_1" runat="server">&nbsp
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="nivelDeAbordaje" runat="server">
                                                    <fieldset class="ui-widget ui-widget-content ui-corner-all" style="padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                                                        <legend>Nivel de Abordaje</legend>
                                                        <asp:DropDownList runat="server" ID="ddlNivelDeAbordaje" Width="160px">
                                                        </asp:DropDownList>
                                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="" ValidationGroup="0"
                                                            OnServerValidate="cvDiagnostico_ServerValidate"></asp:CustomValidator>
                                                        <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Debe seleccionar la notificación"
                                                            ControlToValidate="ddlNivelDeAbordaje" MaximumValue="10" MinimumValue="0" Type="Integer"
                                                            ValidationGroup="0"></asp:RangeValidator>
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
                                                        <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="" ValidationGroup="0"
                                                            OnServerValidate="cvDiagnostico_ServerValidate"></asp:CustomValidator>
                                                        <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="Debe seleccionar la notificación"
                                                            ControlToValidate="ddlTipoPrestacion" MaximumValue="10" MinimumValue="0" Type="Integer"
                                                            ValidationGroup="0"></asp:RangeValidator>
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
                                                        <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="" ValidationGroup="0"
                                                            OnServerValidate="cvDiagnostico_ServerValidate"></asp:CustomValidator>
                                                        <asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="Debe seleccionar la notificación"
                                                            ControlToValidate="ddlTiempoInsumido" MaximumValue="10" MinimumValue="0" Type="Integer"
                                                            ValidationGroup="0"></asp:RangeValidator>
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
                                                        <asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="" ValidationGroup="0"
                                                            OnServerValidate="cvDiagnostico_ServerValidate"></asp:CustomValidator>
                                                        <asp:RangeValidator ID="RangeValidator5" runat="server" ErrorMessage="Debe seleccionar la notificación"
                                                            ControlToValidate="ddlDemanda" MaximumValue="10" MinimumValue="0" Type="Integer"
                                                            ValidationGroup="0"></asp:RangeValidator>
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
                                                        <asp:TextBox ID="txtRHInterviniente" runat="server"></asp:TextBox>
                                                    </fieldset>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="tdVacio_6" runat="server">&nbsp
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <fieldset class="ui-widget ui-widget-content ui-corner-all" style="padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                                                        <legend>Diagnóstico/s Secundario/s</legend>
                                                        <uc2:DiagnosticoSecundario ID="DiagnosticoSecundario1" runat="server" />
                                                    </fieldset>
                                                </td>
                                            </tr>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp
                            </td>
                        </tr>
                        <tr>
                            <td align="left">Informe de Atención
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:TextBox ID="txtInformeConsulta" runat="server" Height="140px" TextMode="MultiLine"
                                    Width="750px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <%--  <asp:LinkButton ID="lnkInterconsulta" Visible="false"  runat="server">Solicitar Interconsulta</asp:LinkButton>--%>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Button ID="Button1" runat="server" CssClass="myButton" OnClick="btnGuardar_Click"
                                    Text="Guardar" ValidationGroup="0" Width="150px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">&nbsp;
                            </td>
                        </tr>
                    </table>
                    </div>
                    <div id="tab2" style="width: 900px; height: auto;">
                        <div style="width: auto; height: auto; overflow: scroll; overflow-x: hidden; border: 1px solid #CCCCCC;">
                            <asp:GridView AutoGenerateColumns="false" ID="gvHistorial" runat="server" ForeColor="#333333"
                                EmptyDataText="No se encontraron datos del historial del paciente" BorderColor="#333333"
                                BorderStyle="Solid" BorderWidth="1px" Font-Names="Calibri" Font-Size="11pt" Width="800px"
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
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td align="left"></td>
        </tr>
    </table>
    </asp:Panel> </td> </tr> </table>
</asp:Content>
