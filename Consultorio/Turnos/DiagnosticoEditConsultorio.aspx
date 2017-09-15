<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiagnosticoEditConsultorio.aspx.cs"
    Inherits="Consultorio.Turnos.DiagnosticoEditConsultorio" MasterPageFile="~/mConsultorio.Master" UICulture="es" Culture="es-AR" %>

<%@ Register Src="~/ConsultaAmbulatoria/UserControls/DiagnosticoPrincipal.ascx" TagName="DiagnosticoP"
    TagPrefix="uc1" %>
<%@ Register Src="~/ConsultaAmbulatoria/UserControls/DiagnosticoSecundario.ascx"
    TagName="DiagnosticoSecundario" TagPrefix="uc2" %>
<%@ Register Src="../../UserControls/ConsultorioPaciente.ascx" TagName="ConsultorioPaciente" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Turnos.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="../../js/jquery-ui-1.7.1.custom.css" />
    <link href="../Resources/jquery-ui-1.8.20.css" rel="stylesheet" type="text/css" />
    <script src="../Resources/jQuery-ui-1.8.18.min.js" type="text/javascript"></script>
    <script src="../Resources/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../Laboratorio/script/ValidaFecha.js"></script>
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

        function abririmagenRCVG()
        {
            window.open("../../App_Themes/consultorio/images/Guía-de-Bolsillo-RCVG.jpg", "_blank", "toolbar=yes, scrollbars=yes, resizable=yes, top=200, left=200, width=600, height=600");
            
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">
    
    <br />
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
            <td align="left" colspan="3">
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
                <asp:Button ID="btnImprimirConsultorioCompleto" runat="server" Width="150px" Height="20px"
                    Text="Imprimir Atención Consultorio" OnClick="btnImprimirConsultorioCompleto_Click" />
            </td>

            <td align="left" style="vertical-align: top;">
                <asp:Panel ID="pnlHola" runat="server" Visible="true" Width="800px">
                    <div class="myLabelRojoGde">
                        Seleccione el paciente a ingresar los diagnosticos
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlDiagnostico" Visible="false" runat="server">
                    <table align="left" width="800px">
                        <caption>
                            <input id="HfidPaciente" type="hidden" runat="server" />
                            <input id="HfDNI" type="hidden" runat="server" />
                            <tr>
                                <td>
                                    <asp:Label ID="lblPaciente" runat="server" CssClass="myLabelRojoMediano"
                                        Text="Label"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblFechaNacimiento" runat="server" CssClass="myLabelIzquierda"
                                        Text="Label"></asp:Label>
                                    <asp:Label ID="lblIdTurno" runat="server" CssClass="myLabelTitulo" Text="Label"
                                        Visible="False"></asp:Label>
                                    <asp:Label ID="lblIdConsulta" runat="server" CssClass="myLabelTitulo"
                                        Text="Label" Visible="False"> </asp:Label>
                                    <br />

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
                                </td>
                            </tr>
                        </caption>
        </tr>
        <tr>
            <td id="contenedorSaludMental" runat="server" style="width: 90%;">
                <div id="tabs">
                    <asp:Panel ID="pnlAtencion" runat="server">
                        <ul>
                            <li><a href="#tab1">Atención Actual</a></li>
                            <li><a href="#tab2">Historial</a></li>
                            <%--    <li><a runat="server" href="#tabInterconsulta">Interconsulta</a></li>--%>
                        </ul>
                    </asp:Panel>
                    <div id="tab1" style="width: 800px">
                        <table>
                            <tr>
                                <td style="vertical-align: top">


                                    <table style="width: 650px">
                                        <tr>
                                            <td id="tdEquipo" runat="server" colspan="2">
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
                                            <td id="tdMotivoConsulta" runat="server" colspan="2">
                                                <fieldset class="ui-widget ui-widget-content ui-corner-all" style="padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                                                    <legend>Motivo de Consulta
                                                    </legend>

                                                    <asp:TextBox ID="txtMotivoConsulta" runat="server" Height="60px" TextMode="MultiLine" Width="600px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvMotivoConsulta" runat="server" ControlToValidate="txtMotivoConsulta" Enabled="False" ErrorMessage="Ingrese un motivo de consulta" ValidationGroup="0"></asp:RequiredFieldValidator>
                                                </fieldset>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="tdDatosControl" runat="server" colspan="2">
                                                <fieldset class="ui-widget ui-widget-content ui-corner-all" style="padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                                                    <legend><b>Datos del Control</b></legend>
                                                    <table style="width: 100%; height: 46px;">
                                                        <tr>
                                                            <td dir="rtl" style="width: 60px">:Peso</td>
                                                            <td colspan="4">
                                                                <%-- <asp:TextBox ID="txtPeso" runat="server" Width="70px" ValidationGroup="RangeValidator6"></asp:TextBox>--%>
                                                                <input id="txtPeso" runat="server" type="text" maxlength="6" style="width: 70px"
                                                                    onblur="valNumero(this)" tabindex="0" class="myTexto" title="Ingrese el peso" />
                                                                Kgrs</td>
                                                            <td dir="rtl" style="width: 109px; clip: rect(auto, auto, auto, auto);">:Talla</td>
                                                            <td style="width: 67px">
                                                                <%--<asp:TextBox ID="txtTalla" runat="server" Width="70px"></asp:TextBox>--%>
                                                                <input id="txtTalla" runat="server" type="text" maxlength="6" style="width: 70px"
                                                                    onblur="valNumero(this)" tabindex="0" class="myTexto" title="Ingrese la talla" />
                                                            </td>
                                                            <td style="width: 15px; font-size: xx-small;">mts</td>
                                                            <td dir="rtl" style="width: 37px">:IMC</td>
                                                            <td style="width: 70px">
                                                                <%--<asp:TextBox ID="txtImc" runat="server" Width="70px"></asp:TextBox>--%>
                                                                <input id="txtImc" runat="server" type="text" maxlength="6" style="width: 70px"
                                                                    onblur="valNumero(this)" tabindex="0" class="myTexto" title="Ingrese el IMC" />
                                                            </td>
                                                            <td style="font-size: xx-small; width: 10px;">
                                                                <input id="btnIMC" type="button" value="IMC" onclick="Operacion();" />
                                                                <%--      <asp:Button ID="btnICM" runat="server" onclientclick="Operacion(); " Text="IMC" 
                                                                        BorderColor="Silver" Width="32px" BackColor="#99CCFF" ForeColor="Blue" />--%>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 60px; height: 22px;">TAS/TAD:</td>
                                                            <td style="width: 72px; height: 22px;">
                                                                <%--<asp:TextBox ID="txtTAS" runat="server" Width="70px"></asp:TextBox>--%>
                                                                <input id="txtTAS" runat="server" type="text" maxlength="6" style="width: 70px"
                                                                    onblur="valNumero(this)" tabindex="0" class="myTexto" title="Ingrese TAS" />
                                                            </td>
                                                            <td dir="ltr" style="width: 20px; height: 22px;">/</td>
                                                            <td style="width: 68px; height: 22px;">
                                                                <%--<asp:TextBox ID="txtTAD" runat="server" Width="70px"></asp:TextBox>--%>
                                                                <input id="txtTAD" runat="server" type="text" maxlength="6" style="width: 70px"
                                                                    onblur="valNumero(this)" tabindex="0" class="myTexto" title="Ingrese TAD" />
                                                            </td>
                                                            <td style="width: 30px; font-size: xx-small; height: 22px;">Mm/Hg</td>
                                                            <td id="PC" style="width: 119px; height: 22px;">&nbsp;&nbsp;&nbsp;<asp:Label ID="lblPC" runat="server" Text="Perímetro Cefálico (cm.):"></asp:Label>
                                                                <%--&nbsp;&nbsp;&nbsp;&nbsp;Perímetro Cefálico:--%>
                                                            </td>
                                                            <td style="width: 67px; height: 22px;">
                                                                <%--<asp:TextBox ID="txtPerimetro" runat="server" Width="70px"></asp:TextBox>--%>
                                                                <input id="txtPerimetro" runat="server" type="text" maxlength="6" style="width: 70px"
                                                                    onblur="valNumero(this)" tabindex="0" class="myTexto" title="Ingrese dato" />
                                                            </td>
                                                            <td style="width: 15px; font-size: xx-small; height: 22px;">&nbsp;</td>
                                                            <td dir="rtl" style="width: 37px; height: 22px;">
                                                                <asp:Label ID="lblRCVG" runat="server" Text="(%):RCVG"></asp:Label>  <img src="../../App_Themes/consultorio/images/zoom.png" onclick="abririmagenRCVG()" title="Ver Tabla"/>
                                                            </td>
                                                            <td style="height: 22px;" colspan="2">
                                                                <%--<asp:TextBox ID="txtRCVG" runat="server" Width="70px"></asp:TextBox>--%>
                                                                <asp:DropDownList ID="ddlRCVG" runat="server" Width="150px">
                                                                    <asp:ListItem Selected="True" Value="-1">Seleccione</asp:ListItem>
                                                                    <asp:ListItem Value="1">&lt;10%</asp:ListItem>
                                                                    <asp:ListItem Value="2">10% - &lt;20%</asp:ListItem>
                                                                    <asp:ListItem Value="3">20% - &lt;30%</asp:ListItem>
                                                                    <asp:ListItem Value="4">30% - &lt;40%</asp:ListItem>
                                                                    <asp:ListItem Value="5">&gt;40%</asp:ListItem>
                                                                </asp:DropDownList>
                                                              
                                                                <%--      <input id="txtRCVG" runat="server" type="text" maxlength="6" style="width: 70px"
                                                                    onblur="valNumero(this)" tabindex="0" class="myTexto" title="Ingrese RCVG" />--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
                                                </fieldset>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <fieldset class="ui-widget ui-widget-content ui-corner-all" style="padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                                                    <legend><b>Diagnóstico Principal</b></legend>
                                                    <uc1:DiagnosticoP ID="DiagnosticoPrincipal1" runat="server" />
                                                    <asp:DropDownList ID="ddlPrimerConsulta" runat="server" Width="160px">
                                                        <asp:ListItem Selected="True" Text="--Seleccione--" Value="-1"></asp:ListItem>
                                                        <asp:ListItem Text="Primera Vez" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Ulterior" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="No informado" Value="0"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:CustomValidator ID="cvDiagnostico" runat="server" ErrorMessage=""
                                                        OnServerValidate="cvDiagnostico_ServerValidate" ValidationGroup="0"></asp:CustomValidator>
                                                    <asp:RangeValidator ID="RangeValidator1" runat="server"
                                                        ControlToValidate="ddlPrimerConsulta"
                                                        ErrorMessage="Debe seleccionar la notificación" MaximumValue="10"
                                                        MinimumValue="0" Type="Integer" ValidationGroup="0"></asp:RangeValidator>
                                                </fieldset>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="tdDiagnosticoSecundario" runat="server" colspan="2">
                                                <fieldset class="ui-widget ui-widget-content ui-corner-all" style="padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                                                    <legend>Diagnóstico/s Secundario/s</legend>
                                                    <uc2:DiagnosticoSecundario ID="DiagnosticoSecundario1" runat="server" />
                                                </fieldset>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="tdVacio_1" runat="server" colspan="2">&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="nivelDeAbordaje" runat="server" colspan="2">
                                                <fieldset class="ui-widget ui-widget-content ui-corner-all" style="padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                                                    <legend><b>Nivel de Abordaje</b></legend>
                                                    <asp:DropDownList ID="ddlNivelDeAbordaje" runat="server" Width="160px">
                                                    </asp:DropDownList>
                                                    <asp:RangeValidator ID="rvNivelAbordaje" runat="server"
                                                        ControlToValidate="ddlNivelDeAbordaje"
                                                        ErrorMessage="Debe seleccionar nivel de abordaje" MaximumValue="10"
                                                        MinimumValue="1" Type="Integer" ValidationGroup="0" Enabled="False"></asp:RangeValidator>
                                                </fieldset>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="tdVacio_2" runat="server" colspan="2">&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="tipoPrestacion" runat="server" colspan="2">
                                                <fieldset class="ui-widget ui-widget-content ui-corner-all" style="padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                                                    <legend><b>Tipo de Prestación</b></legend>
                                                    <asp:DropDownList ID="ddlTipoPrestacion" runat="server" Width="160px">
                                                    </asp:DropDownList>
                                                    <asp:RangeValidator ID="rvTipoPrestacion" runat="server"
                                                        ControlToValidate="ddlTipoPrestacion"
                                                        ErrorMessage="Debe seleccionar tipo de prestación" MaximumValue="10"
                                                        MinimumValue="1" Type="Integer" ValidationGroup="0" Enabled="False"></asp:RangeValidator>
                                                </fieldset>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="tdVacio_3" runat="server" colspan="2">&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="tiempoInsumido" runat="server" colspan="2">
                                                <fieldset class="ui-widget ui-widget-content ui-corner-all" style="padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                                                    <legend><b>Tiempo Insumido</b></legend>
                                                    <asp:DropDownList ID="ddlTiempoInsumido" runat="server" Width="160px">
                                                    </asp:DropDownList>
                                                    <asp:RangeValidator ID="rvTiempoInsumido" runat="server"
                                                        ControlToValidate="ddlTiempoInsumido"
                                                        ErrorMessage="Debe seleccionar tiempo insumido" MaximumValue="10"
                                                        MinimumValue="1" Type="Integer" ValidationGroup="0" Enabled="False"></asp:RangeValidator>
                                                </fieldset>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="tdVacio_4" runat="server" colspan="2">&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="demanda" runat="server" colspan="2">
                                                <fieldset class="ui-widget ui-widget-content ui-corner-all" style="padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                                                    <legend><b>Demanda - EIO</b></legend>
                                                    <asp:DropDownList ID="ddlDemanda" runat="server" Width="160px">
                                                    </asp:DropDownList>
                                                    <asp:RangeValidator ID="rvDemanda" runat="server"
                                                        ControlToValidate="ddlDemanda" ErrorMessage="Debe seleccionar demanda EIO"
                                                        MaximumValue="10" MinimumValue="1" Type="Integer" ValidationGroup="0" Enabled="False"></asp:RangeValidator>
                                                </fieldset>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="tdVacio_5" runat="server" colspan="2">&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="recursoHumano" runat="server" colspan="2">
                                                <fieldset class="ui-widget ui-widget-content ui-corner-all" style="padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                                                    <legend><b>Recurso Humano Interviniente</b></legend>
                                                    <asp:TextBox ID="txtRHInterviniente" MaxLength="20" runat="server"></asp:TextBox>
                                                </fieldset>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="tdVacio_6" runat="server" colspan="2">&nbsp;
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="2">&nbsp
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">

                                                <fieldset class="ui-widget ui-widget-content ui-corner-all" style="padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                                                    <legend><b>Informe de Atención</b> </legend>
                                                    <asp:TextBox ID="txtInformeConsulta" runat="server" Height="100px" TextMode="MultiLine"
                                                        Width="600px"></asp:TextBox>
                                                </fieldset>
                                            </td>
                                        </tr>

                                        <%-- <asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="txtPeso" ErrorMessage="Ingrese un numero entero en el Peso " Type="Double"></asp:RangeValidator>
                     <asp:RangeValidator ID="RangeValidator7" runat="server" ControlToValidate="txtTAS" ErrorMessage="Ingrese un numero entero en TAS" Type="Double"></asp:RangeValidator>
                     <asp:RangeValidator ID="RangeValidator8" runat="server" ControlToValidate="txtRCVG" ErrorMessage="Ingrese un numero entero en RCVG" Type="Double"></asp:RangeValidator>--%>
                                        <asp:RegularExpressionValidator ID="REpeso" runat="server" ControlToValidate="txtPeso" ValidationExpression="^[0-9]{1,3}(\.[0-9]{0,2})?$" ErrorMessage="Ingrese un valor PESO valido" />
                                        <asp:RegularExpressionValidator ID="REtalla" runat="server" ControlToValidate="txtTalla" ValidationExpression="^[0-9]{1,1}(\.[0-9]{0,2})?$" ErrorMessage="Ingrese un valor TALLA valida" />
                                        <asp:RegularExpressionValidator ID="REtas" runat="server" ControlToValidate="txtTAS" ValidationExpression="^[0-9]{1,3}([0-9])?$" ErrorMessage="Ingrese numero entero en el campo TAS" />
                                        <asp:RegularExpressionValidator ID="REtad" runat="server" ControlToValidate="txtTAD" ValidationExpression="^[0-9]{1,3}(\.[0-9]{0,2})?$" ErrorMessage="Ingrese un valor TAD valido" />
                                        <asp:RegularExpressionValidator ID="REpc" runat="server" ControlToValidate="txtPerimetro" ValidationExpression="^[0-9]{1,3}(\.[0-9]{0,2})?$" ErrorMessage="Ingrese un valor PERIMETRO valido" />
                                        <%--<asp:RegularExpressionValidator ID="RErcvg"  runat="server" ControlToValidate="txtRCVG"  ValidationExpression="^[0-9]{1,3}([0-9])?$" ErrorMessage="Ingrese numero entero en el campo RCVG" /> --%>
                                        <asp:RegularExpressionValidator ID="REImc" runat="server" ControlToValidate="txtImc" ValidationExpression="^[0-9]{1,3}(\.[0-9]{0,2})?$" ErrorMessage="Solo numero con punto en el campo IMG" />
                                        <tr>
                                            <td align="left" colspan="2">
                                                <%--  <asp:LinkButton ID="lnkInterconsulta" Visible="false"  runat="server">Solicitar Interconsulta</asp:LinkButton>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:ImageButton ID="imgImprimir" runat="server" Width="20px" Height="20px"
                                                    ImageUrl="~/App_Themes/consultorio/images/imprimir.jpg"
                                                    OnClick="imgImprimir_Click" ToolTip="Imprimir Consulta" />
                                            </td>
                                            <td align="right">
                                                <asp:Button ID="btnGuardar" runat="server" CssClass="myButton"
                                                    OnClick="btnGuardar_Click" Text="Guardar" ValidationGroup="0" Width="150px" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td></td>
                                <td style="vertical-align: top">
                                    <%--   <asp:Button ID="BtnVerInter" runat="server" BackColor="#99CCFF" 
                                                        BorderColor="#CCCCCC" ForeColor="White" 
                                                        OnClientClick="VerInterconsulta(); return false;" Text="Ver Interconsultas" Width="123px" />
                                                    <asp:Button ID="BtnNvaInter" runat="server" BackColor="#99CCFF" 
                                                        BorderColor="#CCCCCC" ForeColor="White" 
                                                        OnClientClick="NuevaInterconsulta(); return false;" Text="Nueva Interconsulta" Width="123px" />
                                                    <asp:Button ID="BtnLabo" runat="server" BackColor="#99CCFF" 
                                                        BorderColor="#CCCCCC" ForeColor="White"
                                                        OnClientClick="Laboratorio(); return false;" Text="Ver Laboratorios" Width="123px" />
                                                         <asp:Button ID="BtnLaboLocal" runat="server" BackColor="#99CCFF" 
                                                        BorderColor="#CCCCCC" ForeColor="White"
                                                        OnClientClick="LaboratorioLocal(); return false;" Text="Ver Laboratorios" Width="123px" />
                                                    <asp:Button ID="BtnEventos" runat="server" BackColor="#99CCFF" 
                                                        BorderColor="#CCCCCC" ForeColor="White"
                                                        OnClientClick="Eventos(); return false;" Text="Eventos" Width="123px" />
                                                    <asp:Button ID="BtnControl" runat="server" BackColor="#99CCFF" 
                                                        BorderColor="#CCCCCC" ForeColor="White" 
                                                        OnClientClick="ControlPerinatal(); return false;" Text="Control Perinatal" 
                                                        Width="123px" />--%>
                                    <uc3:ConsultorioPaciente ID="ConsultorioPaciente1" runat="server" />
                                </td>
                            </tr>
                        </table>


                    </div>


                    <div id="tab2" style="width: 900px; height: 550px;">
                        <div style="width: 900px; height: 350pt; overflow: scroll; overflow-x: hidden; border: 1px solid #CCCCCC;">
                            <asp:DataList ID="dtHistorial" runat="server" CellPadding="4" OnItemDataBound="dtHistorial_ItemDataBound"
                                ForeColor="#333333" DataKeyField="idAgenda">
                                <AlternatingItemStyle BackColor="White" />
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <ItemStyle BackColor="#E3EAEB" />
                                <ItemTemplate>
                                    <table width="850px">

                                        <tr>
                                            <td class="mylabel">Fecha:&nbsp <b><%# DataBinder.Eval(Container.DataItem, "Fecha")%></b></td>
                                            <td align="right" class="mylabel">Efector:&nbsp <b><%# DataBinder.Eval(Container.DataItem, "Efector")%></b></td>
                                            <%--<td class="mylabel">&nbsp;&nbsp  Profesional:&nbsp<b><%# DataBinder.Eval(Container.DataItem, "Profesional")%></b></td>--%>
                                            <td>&nbsp;&nbsp  Profesional:&nbsp
                                                <%--<asp:ListBox ID="lstProfesionales" runat="server" CssClass="clase"></asp:ListBox>--%>

                                                <asp:DataList ID="lstProfesionales" runat="server">
                                                    <ItemTemplate>
                                                        <%--<li style="background-color: AliceBlue">--%>
                                                        <asp:HyperLink ID="hlProductName" runat="server" Text="<%#Container.DataItem %>" />
                                                        <%--</li>--%>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="mylabel" colspan="3">Diagnostico:&nbsp<b><%# DataBinder.Eval(Container.DataItem, "Diagnostico")%></b></td>
                                        </tr>
                                        <tr>
                                            <td class="mylabel" colspan="3">Informe </td>
                                        </tr>
                                        <tr>
                                            <td class="mylabel" colspan="3">
                                                <b><%# DataBinder.Eval(Container.DataItem, "Informe")%></b></td>
                                        </tr>

                                    </table>
                                    <hr />
                                </ItemTemplate>

                                <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />

                            </asp:DataList>
                            <br />

                        </div>
                        <asp:ImageButton ID="imgImprimirHistorial" runat="server" Width="20px" Height="20px"
                            ImageUrl="~/App_Themes/consultorio/images/imprimir.jpg"
                            OnClick="imgImprimirHistorial_Click" ToolTip="Imprimir Historial" />
                    </div>

                </div>
            </td>
        </tr>
        <tr>
            <td align="left"></td>
        </tr>
    </table>
    </asp:Panel> </td> </tr> </table>
    
    <script language="javascript" type="text/javascript">
        var IdPaciente = $("#<%= HfidPaciente.ClientID %>").val();
        var dni = $("#<%= HfDNI.ClientID %>").val();

        function ControlPerinatal() {


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
            $('<iframe src="../../ConsultaAmbulatoria/ControlPerinatal/Control/Default.aspx?idPaciente=' + IdPaciente + '" />').dialog({
                title: 'Control Perinatal',
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


        function Laboratorio() {


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
            $('<iframe src="../../Laboratorio/Resultados/ProtocoloList.aspx?id=' + dni + '" />').dialog({
                title: 'Laboratorios',
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

        function LaboratorioLocal() {


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


            $('<iframe src="../laboratorio/Resultados/Procesa.aspx?idServicio=0&ModoCarga=LP&Operacion=HC&Parametros=P.idPaciente=' + IdPaciente + '"&idArea=0&idHojaTrabajo=0&validado=1&modo=Normal&Tipo=PacienteValidado" />').dialog({
                title: 'Laboratorios',
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

        function VerInterconsulta() {

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
            $('<iframe src="../../Interconsultas1/ListadoDeInterconsultas.aspx?IdPaciente=' + IdPaciente + '" />').dialog({
                title: 'Ver Interconsultas',
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

        function NuevaInterconsulta() {

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
            $('<iframe src="../../Interconsultas1/InterconsultasEdit.aspx?IdPaciente=' + IdPaciente + '&idInterconsulta=0" />').dialog({
                title: 'Nueva Interconsulta',
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


        function Eventos() {
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
            $('<iframe src="http://www.saludnqn.gob.ar/Eventos/Consultas.aspx?Id=' + dni + '" />').dialog({
                title: 'Eventos del Paciente',
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




        function Operacion() {

            var peso = $("#<%=txtPeso.ClientID%>").val();
            var talla = $("#<%=txtTalla.ClientID%>").val();
            var resul = peso / (talla * talla)
            document.getElementById('<%= Page.Master.FindControl("cuerpo").FindControl("txtImc").ClientID %>').value = resul.toFixed(2);
        }



    </script>
</asp:Content>
