<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ConsultaAmbulatoria/MasterPages/Consultorio.master" Theme="apr"
    CodeBehind="Inicio.aspx.cs" Inherits="Consultorio.ConsultaAmbulatoria.Inicio" %>

<%@ MasterType VirtualPath="~/ConsultaAmbulatoria/MasterPages/Consultorio.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <style type="text/css">
         tr, th, td {
        padding-left: 8px;
        text-align: center;
        }
        .modal-dialog {
            width: 850px !important;
        }
        .centrar{
        text-align: center !important;
            }
        .motivocerrar{
           width: 80% !important;
           height: 60px !important;
             }
        .idHCPcss {
            width: 45px;
        }

        .btnmodal-cerrar:hover {
            background-color: #D14836 !important;
            border-color: #D14836 !important;
        }

        .btnmodal-cerrar {
            background-color: #C1CC9E !important;
            border-color: #C1CC9E !important;
        }

        .content button {
            padding: 6px !important;
        }

        .ui-widget-content a {
            text-decoration: none !important;
            margin: 2px;
        }

        #modal-Centro {
            margin-top: 20% !important;
        }

        .modal-cerrar {
            padding: 8px !important;
        }

        .btn-cerrar {
            padding: 2px !important;
            width: 80% !important;
            margin-bottom: 2px;
        }

        .modalAlerta {
            padding: 6px !important;
        }
        .modalAlerta:hover {
            background-color: #D14836 !important;
            border-color: #D14836 !important;
        }

        .navbar-nav > li input {
            background-color: #C1CC9E;
            margin-right: 4px;
        }

            .navbar-nav > li input:hover {
                background-color: #C1CC9E;
                color: #fff;
            }

        .MDalerta {
            color: #000;
        }

            .MDalerta:hover {
                color: #D14836;
            }

        .content {
            margin-bottom: 25px !important;
        }

        .btnNueva {
            float: right;
            margin-right: 1.5em;
            margin-bottom: 5px;
            margin-top: 5px;
        }

        .btnEdiPa {
            float: right;
            margin-right: 1.3em;
            margin-bottom: 5px;
            margin-top: -26px;
        }

        .panel-default {
            border-color: #ddd;
            margin-top: 1.5em;
        }

        .grid tbody tr td {
            font-size: 13px;
        }

        #ColorFondo {
            background-color: #E0E0E0 !important;
        }

        .botonColor {
            padding: 6px 12px !important;
            background-color: #C1CC9E !important;
            border-color: #C1CC9E !important;
        }

        .menuBusqueda {
            text-decoration: none;
        }

        #menuc {
            list-style: none;
            padding: 0;
            margin: 10px;
            height: auto;
        }

            #menuc li {
                position: relative;
                display: block;
                float: left;
                margin: 0;
                padding: 0;
            }

            #menuc a {
                text-decoration: none;
                margin: 3px 0px 0px 0px;
                padding: 0;
            }

        .link {
            float: left;
            margin-bottom: 28px;
        }

        .blink {
            text-decoration: underline overline;
            color: #c00000;
            text-align: center;
        }
    </style>



</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cuerpo" runat="server">
    
    <!-- Modal -->
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog">


            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">
                        <p style="color: #d14836"><b>Alertas! </b></p>
                    </h4>
                </div>
                <div class="modal-body">


                    <div class="panel panel-default">
                        <asp:UpdatePanel ID="upAlertas" runat="server" Visible="false">
                            <ContentTemplate>
                                <div style="text-align: left">
                                    <p style="color: #d14836">Pacientes que faltaron a los controles</p>
                                    <asp:GridView ID="gvPacientes" runat="server" AutoGenerateColumns="false" Width="100%" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px"
                                        CellPadding="3" Font-Names="Verdana" Font-Size="10px">
                                        <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
                                        <Columns>
                                            <asp:BoundField DataField="asiste" ItemStyle-ForeColor="#d14836" HeaderText="Estado" />
                                            <asp:BoundField DataField="dni" HeaderText="Documento" />
                                            <asp:BoundField DataField="paciente" HeaderText="Paciente" />
                                            <asp:BoundField DataField="telefono" HeaderText="Telefono" />
                                            <asp:BoundField DataField="edad" HeaderText="Edad" />
                                            <asp:BoundField DataField="fechaControl" HeaderText="Ultimo Ctrol." />
                                            <asp:BoundField DataField="proximacita" HeaderText="Fec. Cita" />
                                        </Columns>
                                        <HeaderStyle BackColor="#d14836" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#000" />
                                    </asp:GridView>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>



                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                </div>
            </div>

        </div>

    </div>

    <!-- Fin Modal -->
    <!-- Small modal -->

    <div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" id="mostrarmodal">
        <div class="modal-dialog modal-sm animated wobble" id="modal-Centro" role="document">
            <div class="modal-content">
                <p class="modal-cerrar">Esta seguro de cerrar la Historia Clinica Perinatal??</p>


                <%--<input id="txtoculto" type="text"/>--%>
                <p style="display: none;">
                   
               <asp:TextBox ID="txtoculto" runat="server" CssClass="idHCPcss" />
                </p>
                <p class="modal-cerrar">Motivo de Cierre:</p>
                <div class="centrar">   
                               
                    <asp:TextBox ID="motivoCierreHCP" runat="server" CssClass="motivocerrar"/>
                     <div id="mensajeError"> </div>
                </div>
               <%--<div id="mensajeError"> </div>--%>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger modalAlerta" data-dismiss="modal">Cancelar</button>
                    <asp:Button runat="server" OnClick="cerrarHCP" Text="Aceptar" ToolTip="Cerrar Historia Clinica Perinatal" CssClass="btn btn-danger modalAlerta btncierraHCPmodal" OnClientClick="return verifica()"/>
                </div>
            </div>
        </div>
    </div>

    <div class="panel panel-default" id="panelBusqueda" style="margin-bottom: 10px">
        <%--<div class="panel-heading">Datos Paciente</div>--%>
        <div class="form-inline">
            <div class="row">
                <div class="col-md-12">                    
                    <!-- Activa ventana modal de alertas -->
                    <button type="button" class="btn btn-warning btn-md menuBusqueda botonColor MDalerta" data-toggle="modal" data-target="#myModal">Alertas</button>
                      <asp:LinkButton ID="btnNuevo" runat="server" CssClass="btn btn-warning btn-md menuBusqueda botonColor btnNueva"
                            OnClick="btnNuevo_Click" ToolTip="Asignar Paciente"> 
                             <span> <i  class="glyphicon glyphicon-plus"> </i> Nuevo </span></asp:LinkButton>
                </div>
            </div>

        </div>
    </div>

    <%-- Resumen del paciente --%>

    <div id="MensajePacienteNoE" runat="server">
        <p style="color: red;">No se encontro ninguna historia clinica perinatal con ese numero de DNI</p>

    </div>
    <div id="DatosUsuarios" runat="server">

        <div id="divResumenPaciente" class="ui-widget" style="margin-bottom: 5px" runat="server">
            <%--<div class="ui-state-highlight ui-corner-all" style="padding: 5px">--%>
            <div class=" ui-corner-all" id="ColorFondo" style="padding: 5px">
                <table id="tableencabezado" style="width: 100%; margin-bottom: 0; vertical-align: top">
                    <tr>
                        <td>
                            <strong>Paciente: </strong>
                            <asp:Literal runat="server" ID="ltPaciente" />
                        </td>
                        <td colspan="2">
                            <strong>Obra Social: </strong>
                            <asp:Literal runat="server" ID="ltObraSocial" />

                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <strong>DU: </strong>
                            <asp:Literal runat="server" ID="ltDocumentoUnico" />

                        </td>
                        <td>
                            <strong>Fecha Nac: </strong>
                            <asp:Literal runat="server" ID="ltFechaNacimiento" />
                        </td>
                        <td>
                            <%--<asp:HyperLink ID="lkEditar" runat="server" Text="Editar Paciente" CssClass="btn btn-warning btn-md menuBusqueda botonColor btnEdiPa"> </asp:HyperLink>
                            --%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Sexo: </strong>
                            <asp:Literal runat="server" ID="ltSexo" />
                        <td>
                            <strong>Edad: </strong>
                            <asp:Literal runat="server" ID="ltEdad" />
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td>
                            <asp:HyperLink ID="lkEditar" runat="server" Text="Editar Paciente" CssClass="btn btn-warning btn-md menuBusqueda botonColor btnEdiPa"> </asp:HyperLink>

                        </td>
                    </tr>

                </table>
                <%-- <asp:HyperLink ID="lkEditar" runat="server" Text="Editar Paciente" CssClass="btn btn-warning btn-md menuBusqueda botonColor btnEdiPa"> </asp:HyperLink>
                --%>
            </div>
        </div>

        <asp:HiddenField runat="server" ID="hfPaciente" />

        <div class="panel panel-default">
            <asp:Label ID="lblTitulo" runat="server" Text="" Visible="false"></asp:Label>


          


            <br />
            <asp:GridView ID="gvEmbarazadas" runat="server" AutoGenerateColumns="false" ForeColor="#000"
                GridLines="None" Width="99%" AllowPaging="false" PageSize="10" Visible="false" OnRowDataBound="gvEmbarazadas_RowDataBound">
                <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
                <Columns>
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <asp:Image ID="imgEstado" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="activa" HeaderText="" ItemStyle-Width="1px" ItemStyle-ForeColor="White" ItemStyle-Font-Size="XX-Small" />
                    <asp:BoundField DataField="idHistoriaClinicaPerinatal" HeaderText="" ItemStyle-Width="1px" Visible="true" ItemStyle-Font-Size="0.1px" />
                    <asp:BoundField DataField="paciente" HeaderText="Paciente" Visible="false" />
                    <asp:BoundField DataField="numeroDocumento" HeaderText="Documento" Visible="false" />
                    <asp:BoundField DataField="efector" HeaderText="Efector Atención" />
                    <asp:BoundField DataField="fpp" DataFormatString="{0:dd/MM/yyy}" HeaderText="FPP" />
                    <asp:BoundField DataField="edad" HeaderText="Edad" />
                    <%--<asp:HyperLinkField DataNavigateUrlFields="idPaciente" DataNavigateUrlFormatString="~/ConsultaAmbulatoria/SeleccionTurno.aspx?idPaciente={0}"
        HeaderText="Acción" Text="Editar" />--%>

                    <asp:TemplateField HeaderText="Ver Ficha">
                        <ItemTemplate>
                            <a href="ControlPerinatal/Control/?idHistoriaClinicaPerinatal=<%# Eval("IdHistoriaClinicaPerinatal") %>" title="Editar HCP">

                                <img id="imgView" alt="Editar HCP" border="0" src="../App_Themes/Default/images/editado.png" />
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Cerrar">
                        <ItemTemplate>                            
                            <input type="button" value="Cerrar" class="btn btn-danger btn-cerrar btnmodal-cerrar btnCerrar2" data-toggle="modal" data-target=".bs-example-modal-sm"></input>
                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>
                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="black" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            <br />

        </div>


    </div>

    <script>
       // $(document).ready(function () {
        
            $(".btnCerrar2").click(function () {
                var valores = [];
                // Obtenemos todos los valores contenidos en los <td> de la fila
                // seleccionada
                $(this).parents("tr").find("td").each(function () {
                    valores.push($(this).html());
                });
                var idHCP = valores[2];
                $('#<%= txtoculto.ClientID %>').val(idHCP);                      
                
            });

        //Muestra solo la primera vez la ventana de alertas
       
       
            var variable1 = '<%= this.MostrarAlerta %>';
            if (variable1 == 'True') {
                $("#myModal").modal("show");
               <%= this.MostrarAlerta = false%>;
            }
        //});
        //verifica que no se pase el motivo de la ventana modal de Cerrar hcp en blanco
        function verifica() { 
            var campoModal = $('#<%=motivoCierreHCP.ClientID %>').val();
            if(campoModal == ""){
               
                $('#mensajeError').html('<p style="color: red;">Ingrese algun motivo de cierre</p>');
                $('#mensajeError').fadeIn(function () {
                    $('#mensajeError').fadeOut(2000);
                });
                return false;
               
            }
            else{
                return true;
            }
            }
    </script>

</asp:Content>
<asp:Content ID="content2" runat="server" ContentPlaceHolderID="Botones">
</asp:Content>
