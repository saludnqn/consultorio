<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DemandaRechazada.aspx.cs"
    Inherits="Consultorio.Informes.DemandaRechazada" MasterPageFile="~/mConsultorio.Master"   UICulture="es" Culture="es-AR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Turnos.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="../../js/jquery-ui-1.7.1.custom.css" />

    <script type="text/javascript" src="../../js/jquery.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.ui.datepicker-es.js"></script>

     <script src="../../js/jquery-1.8.2.js" type="text/javascript"></script>
     <script src="../../js/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {
            $("#<%=txtDesde.ClientID %>").datepicker({
                showOn: 'button',
                dateFormat: 'dd/mm/yy',
                buttonImage: '../../App_Themes/consultorio/images/calend1.jpg',
                buttonImageOnly: true
            });
        });

        $(function () {
            $("#<%=txtHasta.ClientID %>").datepicker({
                showOn: 'button',
                dateFormat: 'dd/mm/yy',
                buttonImage: '../../App_Themes/consultorio/images/calend1.jpg',
                buttonImageOnly: true
            });
        }); 
     
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">
    <br />
    <br />
    <br />
    <br />
    <div class="div_exterior">
        <div style="width: 1000px;">
            <table width="100%">
                <tr>
                    <td align="left" class="mytituloPagina" colspan="5">
                        Demanda Rechazada
                    </td>
                </tr>
                <tr>
                    <td align="left" class="myLabelIzquierda" colspan="5">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <!-- FILTROS !-->
                    <td align="left" class="myLabelIzquierda">
                        <b class="myLabelIzquierda">Fecha Desde: </b>
                        <asp:TextBox ID="txtDesde" runat="server" Width="70px"></asp:TextBox>
                    </td>
                    <td align="left" class="myLabelIzquierda">
                        Fecha Hasta:
                        <asp:TextBox ID="txtHasta" runat="server" Width="70px"></asp:TextBox>
                    </td>
                    <td align="left" class="myLabelIzquierda">
                        Especialidad:
                        <asp:DropDownList ID="ddlEspecialidad" runat="server">
                        </asp:DropDownList>
                        <asp:RangeValidator ID="rvServicio" ControlToValidate="ddlEspecialidad" ValidationGroup="0"
                            MinimumValue="1" MaximumValue="99999" runat="server" ErrorMessage="Seleccione"></asp:RangeValidator>
                    </td>
                    <td align="left" class="myLabelIzquierda">
                    </td>
                    <td align="right">
                        <asp:Button Width="120px" ID="btnActualizar" runat="server" Text="Actualizar vista"
                            ValidationGroup="0" CssClass="myButton" OnClick="btnActualizar_Click" />
                    </td>
                </tr>
                <tr>
                    <!-- MENSAJES DE ERROR !-->
                    <td colspan="5">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:GridView ID="gvPacientes" runat="server" AutoGenerateColumns="False" Width="100%"
                            Font-Names="Calibri" Font-Size="10pt" EmptyDataText="No se encontraron pacientes para los filtros de búsqueda ingresados."
                            OnRowDataBound="gvPacientes_RowDataBound" 
                            DataKeyNames="idDemandaRechazada" onrowcommand="gvPacientes_RowCommand" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" >
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="numeroDocumento" HeaderText="DNI" />
                                <asp:BoundField DataField="historiaClinica" HeaderText="HC" />
                                <asp:BoundField DataField="Paciente" HeaderText="Apellidos y Nombres" />
                                <asp:BoundField DataField="informacionContacto" HeaderText="Telefono" />
                                <asp:BoundField DataField="especialidad" HeaderText="Especialidad" />
                                <asp:BoundField DataField="motivo" HeaderText="Motivo" />
                                <asp:BoundField DataField="observaciones" HeaderText="Observaciones" />
                                <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                                <%--<asp:BoundField DataField="username" HeaderText="Usuario" />--%>
                                <asp:TemplateField HeaderText="Observación de LLamada">
                                    <ItemTemplate>
                                        <asp:TextBox ID="tbInsert" runat="server" Text='<%#Eval("observacionLlamada")%>'
                                            Width="150px" TextMode="MultiLine" Columns="50" Rows="2"></asp:TextBox>
                                        <asp:HiddenField runat="server" ID="hdnidDemandaRechazada" Value='<%# Eval("idDemandaRechazada") %>' />
                                        <asp:Button Text="OK" CausesValidation="false" runat="server" ID="btInsert" OnClick="btInsert_Click"  />&nbsp;
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Asignar Turno">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Asignar" Text="Asignar" CommandName="Asignar" runat="server" >                                            
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" ForeColor="White" BorderStyle="None" Font-Bold="True" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
