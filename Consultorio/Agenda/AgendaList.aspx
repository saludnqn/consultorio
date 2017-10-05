<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgendaList.aspx.cs" Inherits="Consultorio.Agenda.AgendaList"
    MasterPageFile="~/mConsultorio.Master" UICulture="es" Culture="es-AR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Subsonic" Namespace="SubSonic" TagPrefix="subsonic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Turnos.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="../js/jquery-ui-1.7.1.custom.css" />
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script src="../js/jquery.ui.datepicker-es.js" type="text/javascript"></script>
    <script src="../js/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="../js/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {
            $("#<%=txtDesde.ClientID %>").datepicker({
                showOn: 'button',
                dateFormat: 'dd/mm/yy',
                buttonImage: '../App_Themes/consultorio/images/calend1.jpg',
                buttonImageOnly: true
            });
        });

        $(function () {
            $("#<%=txtHasta.ClientID %>").datepicker({
                showOn: 'button',
                dateFormat: 'dd/mm/yy',
                buttonImage: '../App_Themes/consultorio/images/calend1.jpg',
                buttonImageOnly: true
            });
        });

    </script>
    <style type="text/css">
        .style1 {
            width: 1200px;
        }

        .style2 {
            width: 11px;
        }

        .style4 {
            width: 12px;
        }

        .style7 {
            width: 144px;
        }

        .style8 {
            width: 223px;
        }

        .style9 {
            border-style: none;
            font-size: 10pt;
            font-family: Calibri;
            background-color: #FFFFFF;
            color: #333333;
            font-weight: bold;
            width: 223px;
        }

        .style10 {
            border-style: none;
            font-size: 10pt;
            font-family: Calibri;
            background-color: #FFFFFF;
            color: #333333;
            font-weight: bold;
            width: 11px;
        }

        .style11 {
            border-style: none;
            font-size: 10pt;
            font-family: Calibri;
            background-color: #FFFFFF;
            color: #333333;
            font-weight: bold;
            width: 132px;
        }

        .style13 {
            width: 200px;
        }

        .style14 {
            border-style: none;
            font-size: 10pt;
            font-family: Calibri;
            background-color: #FFFFFF;
            color: #333333;
            font-weight: bold;
            width: 448px;
        }
        .auto-style1 {
            width: 536px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">
    <br />
    <table width="1200px">
        <tr>
            <td class="style2" align="left">&nbsp;
            </td>
            <td class="mytituloPagina" align="left" colspan="6">Lista de Agendas
                <hr />
            </td>
        </tr>
        <asp:Panel ID="pnlServicio" runat="server" Visible="true">
            <tr>
                <td align="right" class="style2">&nbsp;
                </td>
                <td align="right" class="myLabelIzquierda">Servicio:
                </td>
                <td align="left" colspan="5">
                    <asp:DropDownList ID="ddlServicios" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
        </asp:Panel>
        <tr>
            <td align="right" class="style2">&nbsp;
            </td>
            <td align="right" class="style11">Especialidad/Prestación:
            </td>
            <td colspan="4" align="left">
                <asp:DropDownList ID="ddlTipoTurno" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoTurno_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="0">Todas</asp:ListItem>
                    <asp:ListItem>Especialidad</asp:ListItem>
                    <asp:ListItem>Prestaciones</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlEspecialidad" runat="server" Width="200PX">
                </asp:DropDownList>
            </td>
            <td class="style4"></td>
        </tr>
        <tr>
            <td align="right" class="style2">&nbsp;
            </td>
            <td align="right" class="style11">Profesional:
            </td>
            <td align="left" class="auto-style1">
                <asp:DropDownList ID="ddlProfesional" runat="server" Width="200PX">
                </asp:DropDownList>
            </td>
            <td align="right" class="style14" colspan="2">Tipo de consultorio:
            </td>
            <td align="left" class="style7">
                <asp:DropDownList ID="ddlTipoCons" runat="server">
                </asp:DropDownList>
            </td>
            <td class="style8"></td>
        </tr>
        <tr>
            <td align="right" class="style2">&nbsp;
            </td>
            <td align="right" class="style11">Fecha desde:
            </td>
            <td align="left" class="auto-style1">
                <asp:TextBox ID="txtDesde" runat="server" Width="70px"></asp:TextBox>
            </td>
            <td align="right" class="style14" colspan="2">Fecha hasta:
            </td>
            <td align="left" class="style7">
                <asp:TextBox ID="txtHasta" runat="server" Width="70px"></asp:TextBox>
              
            </td>
        </tr>
        <tr>
            <td align="right" class="style2">&nbsp;
            </td>
            <td align="right" class="style11" colspan="1">Estado:
            </td>
            <td class="myLabelIzquierda" colspan="2" align="left">
                <asp:DropDownList runat="server" ID="ddlEstado">
                </asp:DropDownList>
            </td>
            <td class="myLabelIzquierda" colspan="2">
                  &nbsp;</td>
            <td class="style9" colspan="1">
                <asp:Button ID="btnActualizar" runat="server" Width="125px" CssClass="myButton" OnClick="btnActualizar_Click"
                    Text=" BUSCAR AGENDAS " />
            </td>
        </tr>
        <tr>
            <td align="right" class="style2">&nbsp;</td>
            <td align="right" class="style11" colspan="1">&nbsp;</td>
            <td class="myLabelIzquierda" colspan="2" align="left">
                &nbsp;</td>
            <td class="myLabelIzquierda" colspan="2">
                  &nbsp;</td>
            <td colspan="1">
                  <asp:CheckBox ID="chkRecordarFiltro" runat="server" Text="Recordar filtros búsqueda" CssClass="myLabelIzquierda" />
            </td>
        </tr>
        <tr>
            <asp:TextBox ID="txtAgenda" runat="server" Width="100%" Visible="false"></asp:TextBox>
        <tr>
            <td class="style2">&nbsp;
            </td>
            <td class="myLabelIzquierda" colspan="6">
                <hr />
            </td>
        </tr>
        <tr>
            <td align="left" class="style2"></td>
            <td align="left" class="myLabelIzquierda" colspan="2">

                <asp:Button ID="btnNuevaAgenda" runat="server" Width="120px" CssClass="myButtonRojo"
                    Text="NUEVA AGENDA" PostBackUrl="AgendaNew.aspx" />

                &nbsp;

                <asp:Button ID="BtnOtrasActividades" runat="server" Width="220px" CssClass="myButtonRojo"
                    Text="AGENDA OTRAS ACTIVIDADES" OnClick="BtnOtrasActividades_Click" />
            
            </td>            
            <td class="myLabelIzquierda" align="right" colspan="2"></td>
        </tr>
        <tr>
            <td class="style2">&nbsp;
            </td>
            <td class="myLabelIzquierda" colspan="6">
                <asp:Label runat="server" ID="lblAgendaSinProfesionales" Style="color: Red;" Text="No es posible crear nuevas agendas debido a que existen agendas del día sin profesional asignado. Asigne el profesional para poder continuar."></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="style10">&nbsp;
            </td>
            <td align="left" colspan="6">
                <asp:GridView ID="gvAgendas" runat="server" AutoGenerateColumns="False" CellPadding="2"
                    CellSpacing="2" DataKeyNames="idAgenda,idProfesional" SelectedIndex="0" Width="100%"
                    EmptyDataText="No se encontraron agendas para los filtros propuestos." ForeColor="#333333"
                    Font-Bold="True" BorderColor="#333333" BorderStyle="Solid" BorderWidth="1px"
                    Font-Names="Calibri" Font-Size="10pt" OnSelectedIndexChanged="gvAgendas_SelectedIndexChanged"
                    OnRowDataBound="gvAgendas_RowDataBound" OnRowCommand="gvAgendas_RowCommand" AllowPaging="True"
                    PageSize="25" OnPageIndexChanging="gvAgendas_PageIndexChanging" EnableModelValidation="True">
                    <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="#333333" />
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField DataField="Estado" HeaderText="Estado">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="fecha" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha">
                            <ItemStyle Width="5%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Servicio" HeaderText="Servicio" Visible="false">
                            <ItemStyle Width="10%" />
                        </asp:BoundField>
                         <asp:TemplateField HeaderText="Especialidad" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:ListView ID="lsvEspecialidad" runat="server">
                                    <ItemTemplate>
                                        <asp:Label Text="<%#Container.DataItem %>" runat="server" />
                                    </ItemTemplate>
                                    <ItemSeparatorTemplate>
                                        <br />
                                    </ItemSeparatorTemplate>
                                </asp:ListView>
                            </ItemTemplate>
                        </asp:TemplateField>

                      <%--  <asp:BoundField DataField="Especialidad" HeaderText="Especialidad">
                            <ItemStyle Width="15%" />
                        </asp:BoundField>--%>
                        <asp:BoundField DataField="idProfesional" HeaderText="idProfesional" ReadOnly="True"
                            Visible="False" />

                        <asp:TemplateField HeaderText="Profesionales" ItemStyle-Width="150">
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

                        <asp:BoundField DataField="Consultorio" HeaderText="Consultorio">
                            <ItemStyle Width="5%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="hIni" HeaderText="Inicio">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="hFin" HeaderText="Fin">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField ItemStyle-Width="20px" DataField="cantidadTurnos" HeaderText="Total Turnos"
                            ItemStyle-BackColor="#CCCCCC" ItemStyle-ForeColor="#CC3300" ItemStyle-Font-Size="12"
                            ItemStyle-Font-Bold="True" ItemStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center" BackColor="#CCCCCC" Font-Bold="True" Font-Size="10pt"
                                ForeColor="Black" Width="5%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField ItemStyle-Width="20px" DataField="turnosDados" HeaderText="Turnos Dados"
                            ItemStyle-BackColor="#CCCCCC" ItemStyle-ForeColor="#CC3300" ItemStyle-Font-Size="12"
                            ItemStyle-Font-Bold="True" ItemStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center" BackColor="#CCCCCC" Font-Bold="True" Font-Size="10pt"
                                ForeColor="#CC3300" Width="5%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField ItemStyle-Width="20px" DataField="turnosDisponibles" HeaderText="Turnos Disponibles"
                            ItemStyle-BackColor="#CCCCCC" ItemStyle-ForeColor="#CC3300" ItemStyle-Font-Size="12"
                            ItemStyle-Font-Bold="True" ItemStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center" BackColor="#CCCCCC" Font-Bold="True" Font-Size="10pt"
                                ForeColor="#CC3300" Width="5%"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <asp:LinkButton ID="Editar" Text="Editar" CommandName="Editar" runat="server" AlternateText="Editar" />
                            </ItemTemplate>
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Planilla">
                            <ItemTemplate>
                                <asp:LinkButton ID="Planilla" Text="Descargar" CommandName="Planilla" runat="server"
                                    AlternateText="Seleccionar" />
                            </ItemTemplate>
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cierre">
                            <ItemTemplate>
                                <asp:LinkButton ID="Cierre" Text="Ingresar" CommandName="Cierre" runat="server" AlternateText="Seleccionar" />
                            </ItemTemplate>
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <%--  <asp:HyperLinkField  DataNavigateUrlFields="idAgenda" DataNavigateUrlFormatString="../Turnos/AsistenciaEdit.aspx?idAgenda={0}"
            HeaderText="Cierre" Text="Ingresar"   />--%>
                        <asp:TemplateField HeaderText="Diagnóstico">
                            <ItemTemplate>
                                <asp:LinkButton ID="Codificar" Text="Ingresar" CommandName="Codificar" runat="server"
                                    AlternateText="Seleccionar" />
                            </ItemTemplate>
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <%--  <asp:HyperLinkField DataNavigateUrlFields="idAgenda" DataNavigateUrlFormatString="~/ConsultaAmbulatoria/DiagnosticoEdit.aspx"
            HeaderText="Codificar" Text="Ingresar" />--%>
                        <asp:TemplateField HeaderText="Consultorio Médico">
                            <ItemTemplate>
                                <asp:LinkButton ID="ConMedico" Text="Ingresar" CommandName="ConMedico" runat="server"
                                    AlternateText="Seleccionar" />
                            </ItemTemplate>
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle Height="20px" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
