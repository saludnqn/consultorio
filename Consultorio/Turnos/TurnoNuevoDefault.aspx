<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TurnoNuevoDefault.aspx.cs"
    Inherits="Consultorio.Turnos.TurnoNuevoDefault" MasterPageFile="~/mConsultorio.Master"   UICulture="es" Culture="es-AR"%>

<%@ Register Assembly="Subsonic" Namespace="SubSonic" TagPrefix="subsonic" %>
<%@ Register Assembly="MagicAjax" Namespace="MagicAjax.UI.Controls" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
    <link href="../Turnos.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="../js/jquery-ui-1.7.1.custom.css" />
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript">
        function callServersideMethod(valueToSend) {
            __doPostBack('callServersideMethod', valueToSend);
        }

   
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">
    <br />
    <asp:Panel ID="Panel2" runat="server" DefaultButton="btnBuscar">
       <%-- <ajax:AjaxPanel ID="panel1" runat="server">--%>
            <table width="900px">
                <tr>
                    <td colspan="3" class="mytituloPagina" align="left">
                       Búsqueda de Pacientes<hr />
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="3" class="myLabelRojo">
                        Identificación del Paciente
                    </td>
                </tr>
                <tr>
                    <td class="myLabelIzquierda" align="left">
                        Documento:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtDni" runat="server" MaxLength="8" CssClass="boxcortos" ToolTip="Solo números"
                            TabIndex="1"></asp:TextBox>
                        <asp:CompareValidator ID="cvNDocumento" runat="server" ErrorMessage="Solo numeros"
                            ControlToValidate="txtDni" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                    </td>
                    <%--<td class="myLabelIzquierda" align="left">
                    Historia Clínica:
          <asp:TextBox ID="txtHistoriaClinicaBusqueda" CssClass="boxcorty" runat="server" TabIndex="2"></asp:TextBox>
                </td>--%>
                </tr>
                <%--<tr>
                <td class="myLabelIzquierda" align="left">
                    Fecha de Nac.:
                </td>
                <td align="left">
                    <asp:TextBox ID="txtFecNacBusqueda" runat="server" CssClass="boxcortos" onblur="javascript:formatearFecha(this)"
                        TabIndex="3"></asp:TextBox>
                </td>
            </tr>--%>
                <tr>
                    <td class="myLabelIzquierda" align="left">
                        Apellido:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtApellidoBusqueda" Width="200px" runat="server" TabIndex="4"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="myLabelIzquierda" align="left">
                        Nombre:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtNombreBusqueda" Width="200px" runat="server" TabIndex="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <h2>
                            Datos de la Madre/Tutor</h2>
                    </td>
                </tr>
                <tr>
                    <td class="myLabelIzquierda" align="left">
                        Apellido (Soltera):
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtApellidoMadreBusqueda" runat="server" TabIndex="6"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="myLabelIzquierda" align="left">
                        Nombre:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtNombreMadreBusqueda" runat="server" TabIndex="7"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="myLabelIzquierda" align="left">
                        DNI Madre:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtDniMadre" runat="server"></asp:TextBox>
                        <%-- <input id="txtDniMadre" type="text" runat="server" class="myTexto" onblur="valNumero(this)" tabindex="11" />--%>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtDniMadre"
                            ErrorMessage="Debe ingresar solo numeros" Operator="DataTypeCheck" Type="Integer"
                            ValueToCompare="0">Debe ingresar solo números</asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                        <hr />
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        <div>
                            <asp:Button CssClass="myButton" ID="btnBuscar" Width="100px" runat="server" Text="Buscar"
                                OnClick="btnBuscar_Click" TabIndex="8" /><br />
                        </div>
                    </td>
                    <td align="right">
                        <div>
                            <asp:Button CssClass="myButtonRojo" ID="btnNuevo" runat="server" Width="100px" Text="Nuevo Paciente"
                                OnClick="btnNuevo_Click" ToolTip="Ingresar un nuevo Paciente" TabIndex="9" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <div>
                            <asp:Image ID="imgReferencia" runat="server" ImageUrl="~/App_Themes/default/img/ref.png" /><br />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="left">
                        <asp:Label ID="lblMensajeBusqueda" runat="server" CssClass="myLabelRojo" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <div class="myLabelIzquierda">
                <asp:GridView ID="gvPacientes" runat="server" GridLines="Vertical" CellPadding="4"
                    AutoGenerateColumns="False" OnSorting="gridView_Sorting" Font-Names="Calibri"
                    Font-Size="10pt" AllowPaging="True" OnPageIndexChanging="gvPacientes_PageIndexChangind"
                    EmptyDataText="<b>No se encontraron datos.</b>" OnRowDataBound="gvPacientes_RowDataBound"
                    Width="900px" PageSize="20" DataKeyNames="idPaciente"
                    OnRowCommand="gvPacientes_RowCommand" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black" >
            
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="idPaciente" DataNavigateUrlFormatString="~/Paciente/PacienteEdit.aspx?id={0}&amp;llamada=Consultorio" HeaderText="Ver" Text="Editar" />
                        <%-- <asp:BoundField DataField="historiaClinica" HeaderText="HC" />--%>
                        <asp:BoundField DataField="numeroDocumento" HeaderText="Nro Doc" />
                        <asp:BoundField DataField="historiaClinica" HeaderText="HC" />
                        <asp:BoundField DataField="apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="sexo" HeaderText="Sexo" />
                        <asp:BoundField DataField="fechaNacimiento" DataFormatString="{0:dd/MM/yyy}" HeaderText="Fec.Nac" />
                        <asp:BoundField DataField="localidad" HeaderText="Localidad" />
                        <asp:BoundField DataField="barrio" HeaderText="Barrio" />
                        <%--<asp:HyperLinkField DataNavigateUrlFields="idPaciente" DataNavigateUrlFormatString="../Parentesco/ParentescoList.aspx?id={0}" HeaderText="Parentesco" Text="Parentesco" />
                <asp:BoundField DataField="estado" HeaderText="Estado" />
                <asp:BoundField DataField="motivo" HeaderText="Motivo" />--%>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkTurno" runat="server">Asignar</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Height="20px" HorizontalAlign="Center" Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Turno 2do. Nivel">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkTurnoInterconsulta" runat="server">Asignar</asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Height="20px" HorizontalAlign="Center" Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Turno ECOGRAFIAS">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkTurnoCentroSalud" runat="server">Asignar</asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Height="20px" HorizontalAlign="Center" Width="80px" />
                        </asp:TemplateField>
                        <%--<asp:HyperLinkField DataNavigateUrlFields="idPaciente" DataNavigateUrlFormatString="TurnoNuevo.aspx?idPaciente={0}" HeaderText="Turno" Text="Ingresar" />
            <asp:HyperLinkField DataNavigateUrlFields="idPaciente" DataNavigateUrlFormatString="TurnoNuevo.aspx?idPaciente={0}&Interconsulta=0" HeaderText="Turno Interconsulta" Text="Ingresar"  />--%>
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                    <SortedAscendingHeaderStyle BackColor="#848384" />
                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                    <SortedDescendingHeaderStyle BackColor="#575357" />
                  
                </asp:GridView>
                <br />
                <%--    <h2><asp:Label ID="lblTitulo" runat="server"></asp:Label></h2>--%>
                <%--   <div style="overflow: auto; width: 100%; scrollbars: Both">
        <asp:GridView ID="gvPersonas" runat="server"  CssClass="mGrid" GridLines="None" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="false" EmptyDataText="No se encontraron datos."
          PageSize="10" Visible=false AllowPaging="True" OnPageIndexChanging="gvPersonas_PageIndexChangind">
          <Columns>
            <asp:BoundField DataField="tipoDocumento" HeaderText="Tipo" />
            <asp:BoundField DataField="Documento" HeaderText="Número" />
            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="ObraSocial" HeaderText="Obra Social" />
          </Columns>
        </asp:GridView>
        <br />
        <h2><asp:Label ID="lblTitulo2" runat="server"></asp:Label></h2>
        <div style="width: 100%">
          <asp:GridView Visible=false ID="gvPadronPaciente" runat="server" AutoGenerateColumns="False" EmptyDataText="No se encontraron datos."
            AllowPaging="True" OnPageIndexChanging="gvPadronPaciente_PageIndexChanging" CellPadding="4"
            ForeColor="#333333" GridLines="None" Width="99%">
            <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
            <Columns>
              <asp:BoundField DataField="numeroDocumento" HeaderText="Documento" />
              <asp:BoundField DataField="apellido" HeaderText="Apellido" />
              <asp:BoundField DataField="nombre" HeaderText="Nombre" />
              <asp:BoundField DataField="FecNac" HeaderText="Fecha Nac." />
            </Columns>
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
          </asp:GridView>
        </div>
      </div>--%>
            </div>
        <%--</ajax:AjaxPanel>--%>
    </asp:Panel>
</asp:Content>
