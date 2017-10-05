<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultorioPaciente.aspx.cs"
    Inherits="Consultorio.Turnos.ConsultorioPaciente" MasterPageFile="~/mConsultorio.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Turnos.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="../js/jquery-ui-1.7.1.custom.css" />
    <%--     <uc1:DiagnosticoSecundario ID="DiagnosticoPrincipal2" runat="server" />--%>
    <script type="text/javascript" src='<%= ResolveUrl("../ControlMenor/js/jquery-1.5.1.min.js") %>'></script>
    <script type="text/javascript" src='<%= ResolveUrl("../ControlMenor/js/jquery-ui-1.8.9.custom.min.js") %>'></script>
    <script type="text/javascript" src='<%= ResolveUrl("../ControlMenor/js/jquery.dataTables.min.js") %>'></script>
    <script type="text/javascript" src='<%= ResolveUrl("../ControlMenor/js/jquery.ui.selectmenu.js") %>'></script>
    <script type="text/javascript" src='<%= ResolveUrl("../ControlMenor/js/ui.checkbox.js") %>'></script>
    <script type="text/javascript" src='<%= ResolveUrl("../ControlMenor/js/json2.js") %>'></script>
    <%--   <asp:BoundField DataField="Dia" HeaderText="" />--%>
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
            <td align="left" colspan="3" class="mytituloPagina">
                CONSULTORIOS DEL PACIENTE<hr />
            </td>
        </tr>
       
      
       
        <tr>
            <td class="myLabelIzquierda" style="vertical-align: top;">
                &nbsp;</td>
            <td width="20px">
                <asp:Panel ID="pnlDiagnostico" Visible="false" runat="server">
                    <table align="left" width="800px">
                        <tr>
                            <td>
                                <asp:Label CssClass="myLabelRojoMediano" ID="lblPaciente" runat="server" Text="Label"></asp:Label><br />
                                <asp:Label CssClass="myLabelIzquierda" ID="lblFechaNacimiento" runat="server" Text="Label"></asp:Label>
                                <asp:Label CssClass="myLabelTitulo" ID="lblIdPaciente" runat="server" Text="Label" Visible="False"></asp:Label>
                                <asp:Label CssClass="myLabelTitulo" ID="lblIdConsulta" runat="server" Text="Label" Visible="False"></asp:Label>
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td runat="server" style="width: 90%;">
                      
                                        <div style="width: 820px; height: 350pt; overflow: scroll; overflow-x: hidden; border: 1px solid #CCCCCC;">
                                            <asp:GridView ID="gvHistorial" runat="server" AutoGenerateColumns="false" 
                                                BorderColor="#333333" BorderStyle="Solid" BorderWidth="1px" CellPadding="2" 
                                                CellSpacing="2" 
                                                EmptyDataText="No se encontraron datos del historial del paciente" 
                                                Font-Names="Calibri" Font-Size="11pt" ForeColor="#333333" Width="800px">
                                                <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="#333333" />
                                                <Columns>
                                               
                                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                                    <asp:BoundField DataField="Hora" HeaderText="Hora" />
                                                    <asp:BoundField DataField="Efector" HeaderText="Efector" />
                                                    <asp:BoundField DataField="Profesional" HeaderText="Profesional" />
                                                    <asp:BoundField DataField="Diagnostico" HeaderText="Diagnóstico" />
                                                    <asp:BoundField DataField="TipoDiag" HeaderText="Tipo Diag." />
                                                   <%--    <asp:TemplateField>
                                                                                            <ItemTemplate>
                                                                                           <asp:CheckBox ID="Select" runat="server" CommandName="Select"/>
                                                                                             
                                                                                                
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>--%>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Button ID="btnImprimir" runat="server" onclick="btnImprimir_Click" 
                                    Text="Ver Reporte Completo" />
                            </td>
                        </tr>
                    </table>
    </asp:Panel> 
            </td>
            <td align="left" style="vertical-align: top;">
                &nbsp;</td> </tr> </table>
</asp:Content>
