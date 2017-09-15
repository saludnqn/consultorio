    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" MasterPageFile="~/ControlMenor/MasterPages/PanelControl.master"
    Theme="apr" Inherits="ConsultaAmbulatoria.ControlPerinatal.PanelControl.Default"
    Title="Control Perinatal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .ui-state-default a, .ui-state-default a:link, .ui-state-default a:visited {
            color: #000 !important;
            text-decoration: none;
        }

        .ui-state-default, .ui-widget-content .ui-state-default, .ui-widget-header .ui-state-default {
            border: 1px solid #C1CC9E !important;
            background: #fff !important;
            font-weight: bold;
            color: #000 !important;
        }
        .ui-state-active a, .ui-state-active a:link, .ui-state-active a:visited {
            color: #000 !important;
            text-decoration: none;
        }
        .ui-state-default, .ui-widget-content .ui-state-default, .ui-widget-header .ui-state-default {
            border: 1px solid #C1CC9E !important;
            background-image: none !important;
            font-weight: bold;
            color: #000 !important;
                    }

        .ui-widget-header {
            background-image: none !important;
            background-color:#C1CC9E !important;
            border-color: #C1CC9E !important;
             }
        .tab {
            width: 80%;
            border: solid 1px #C1CC9E;
        }

        .tabr {
            width: auto;
            padding: 5px 0px 5px 0px;
            border: solid 1px #C1CC9E;
        }

        .contentBox {
            background: white;
            width: 100%;
            height: auto;
            overflow: auto;
        }

        .btn-image {
            width: 44px;
        }
        .ui-widget-content {
            font-size: 13px !important;
            z-index: 99 !important;
        }
        .floder{
            float:right;
        }
         .fechasdv{
        margin-top: 15px;
        }
            .botonColor {
            padding: 6px 12px !important;
            background-color: #C1CC9E !important;
            border-color: #A7AE93 !important;
            color: #000 !important;
        }
            .botonColor:hover {
            padding: 6px 12px !important;
            background-color: #C1CC9E !important;
            border-color: #C1CC9E !important;
            color: #ffffff !important;
        }
    </style>
    <script>
    $(document).ready(function () {
            $('.datepicker22').datepicker({
                format: "dd/mm/yyyy"
            });

        });
        </script>


    <script type="text/javascript">
        $(document).ready(function () {
            $('#tabs').tabs();

            $('.tooltipeable').tooltip({
                position: "center right",
                offset: [0, 5],
                effect: 'fade',
                opacity: 0.7
            });

            $('#wdwAlertas').dialog({ autoOpen: false, minWidth: 800, minHeigth: 500, title: 'Alerta', modal: true });
        });
    </script>

    <script src="../../../js/Format.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="server">
    <asp:ScriptManagerProxy runat="server" ID="smp">
        <Scripts>
            <asp:ScriptReference Path="~/js/tooltips/jquery.tools.min.js" />
        </Scripts>
    </asp:ScriptManagerProxy>
    <b>Consultas de Pacientes ingresadas al Control</b><br />
    <div>
        <b>Seleccione el Establecimiento</b><asp:DropDownList runat="server" ID="ddlEfector"
            DataValueField="idEfector" DataTextField="nombre"  OnSelectedIndexChanged="ddlEfector_SelectedIndexChanged" CssClass="form-control" >
        </asp:DropDownList>

        <div class="col-md-4 fechasdv">

            <%--onblur="javascript:formatearFecha(this)"--%>

        <b>Fecha de Inicio:</b><asp:TextBox ID="txtFInicio" 
            ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975" runat="server" CssClass="floder datepicker22 form-control" Width="150"></asp:TextBox>
        </div>
        <div class="col-md-4 fechasdv">
            <b>Fecha de Fin: </b>
        <asp:TextBox ID="txtFFin" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
            runat="server" CssClass="floder datepicker22 form-control" Width="150"></asp:TextBox>
      </div>
        <asp:Button runat="server" ID="btnFiltrar" Text="Buscar" ToolTip="Buscar datos según filtros seleccionados"
            OnClick="btnBuscar_Click" CssClass="btn btn-danger botonColor"/>
        <asp:ImageButton ID="IBExel" CssClass="btn-image" OnClick="IBExel_Click" ImageUrl="~/App_Themes/Clasificacion/images/excel2016.png"
            runat="server" TabIndex="10" ToolTip="Exporta la Información de Consultas a Excel" />
    </div>
    <div id="tabs"> <!-- Maneja el JS -->

       <ul class="nav nav-tabs">
            <li runat="server" id="liConsulta"><a href='#<%= tabConsulta.ClientID %>'>Consultas </a></li>
            <li runat="server" id="liEvaluacion"><a href='#<%= tabEvaluacion.ClientID %>'>Evaluación </a></li>
        </ul>



        <div id="tabConsulta" runat="server">
            <br />
            <div style="width: 100%; height: auto; overflow: auto;">
                <asp:GridView ID="gvPacientes" runat="server" AutoGenerateColumns="false" ForeColor="#333333"
                    Width="100%" OnSorting="gridView_Sorting" AllowPaging="true" OnPageIndexChanging="gvPacientes_PageIndexChangind"
                    PageSize="10" EmptyDataText="<b>No se encontraron datos.<b>" Font-Size="8pt">
                    <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
                    <Columns>
                        <asp:BoundField DataField="paciente" HeaderText="Paciente" />
                        <asp:BoundField DataField="dni" HeaderText="Documento" />
                        <asp:BoundField DataField="telefono" HeaderText="Telefono" />
                        <asp:BoundField DataField="embarazoplaneado" HeaderText="E.Planeado" />
                        <asp:BoundField DataField="anticonceptivo" HeaderText="Anticonceptivo" />
                        <asp:BoundField DataField="FUM" DataFormatString="{0:dd/MM/yyy}" HeaderText="FUM" />
                        <asp:BoundField DataField="FPP" DataFormatString="{0:dd/MM/yyy}" HeaderText="FPP" />
                        <asp:BoundField DataField="primeriza" HeaderText="Primeriza" />
                        <asp:BoundField DataField="FechaCreacion" DataFormatString="{0:dd/MM/yyy}" HeaderText="F.Ingreso" />
                    </Columns>
                    <FooterStyle BackColor="#C1CC9E" ForeColor="White" Font-Bold="True" />
                    <PagerStyle BackColor="#C1CC9E" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#C1CC9E" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#C1CC9E" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#C1CC9E" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </div>
            <br />
            Cantidad de Registros:
            <asp:Label ID="lblCantidad" runat="server" Text=""></asp:Label>
        </div>
        <div id="tabEvaluacion" runat="server">
            <br />
            Consolidado Embarazadas bajo control<br />
            <br />
            <table class="tab table table-bordered">
                <%--<tr class="tabr">
                    <td>Evaluación
                    </td>
                    <td>Primera Vez<br />
                        Ulterior
                    </td>
                    <td>
                        <asp:Label ID="lblPrimeraVez" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblUlterior" runat="server" Text=""></asp:Label>
                    </td>
                </tr>--%>
                <tr class="tabr">
                    <td>Edad
                    </td>
                    <td><= 19
                        <br />
                        20-40
                        <br />
                        >40
                        <br />
                        Sin Dato
                    </td>
                    <td>
                        <asp:Label ID="lblMenor20" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lbl2040" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblMayor40" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblSinDatoEdad" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="tabr">
                    <td>Captación Oportuna
                        <br />
                        (Menor 13 semanas)
                    </td>
                    <td>Si
                        <br />
                        No
                        <br />
                        Sin Dato
                    </td>
                    <td>
                        <asp:Label ID="lblCaptacionSi" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblCaptacionNo" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblCaptacionSinDato" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="tabr">
                    <td>Patología en Embarazo Actual
                    </td>
                    <td>Si
                        <br />
                        No
                    </td>
                    <td>
                        <asp:Label ID="lblPatologiaSi" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblPatologiaNo" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblPatologiaSinDato" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr class="tabr">
                    <td>Factor Riesgo Psicosocial</td>
                    <td>Si
                        <br />
                        No                   
                    </td>
                    <td>
                        <asp:Label ID="lblFactorSi" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblFactorNo" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblFactorSinDato" runat="server" Text=""></asp:Label></td>
                </tr>
               <%-- <tr class="tabr">
                    <td>Actividades Grupales Educativas</td>
                    <td>Si
                        <br />
                        No
                    </td>
                    <td>
                        <asp:Label ID="lblActividadesSi" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblActividadesNo" runat="server" Text=""></asp:Label>
                    </td>
                </tr>--%>
                <tr>
                    <td>Número de Controles</td>
                    <td>Adecuados
                        <br />
                        Inadecuados
                    </td>
                    <td>
                        <asp:Label ID="lblAdecuados" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblInadecuados" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
               <%-- <tr class="tabr">
                    <td>Score de Riesgo de Bajo Peso al Nacer</td>
                    <td>Puntaje 0
                        <br />
                        1-3
                        <br />
                        4-5
                        <br />
                        6 y mas
                        <br />
                        Sin Dato
                    </td>
                    <td>
                        <asp:Label ID="lblScore0" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblScore13" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblScore44" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblScore6" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblScoreSinDato" runat="server" Text=""></asp:Label>
                    </td>
                </tr>--%>
               <%-- <tr class="tabr">
                    <td>Nutrición</td>
                    <td>Bajo peso
                        <br />
                        Peso normal
                        <br />
                        Sobre peso
                        <br />
                        Obesidad
                    </td>
                    <td>
                        <asp:Label ID="lblBajoPeso" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblPesoNormal" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblSobrePeso" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblObesidad" runat="server" Text=""></asp:Label>
                    </td>
                </tr>--%>
               <%-- <tr class="tabr">
                    <td>Abandono</td>
                    <td>Si
                        <br />
                        No
                    </td>
                    <td>
                        <asp:Label ID="lblAbandonoSi" runat="server" Text=""></asp:Label>*<br />
                        <asp:Label ID="lblAbandonoNo" runat="server" Text=""></asp:Label>
                    </td>
                </tr>--%>
            </table>
            <%--<asp:Label ID="lblReferencia" runat="server" Text="* Se consideran Abandonos aquellos casos en que la fecha actual supera los 10 días a la fecha del Próximo Control o cita."></asp:Label>--%>
        </div>

    </div>
</asp:Content>
