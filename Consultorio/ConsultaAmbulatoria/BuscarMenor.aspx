<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscarMenor.aspx.cs" MasterPageFile="~/ConsultaAmbulatoria/MasterPages/Consultorio.master"
    Inherits="Consultorio.ConsultaAmbulatoria.BuscarMenor" Theme="apr" %>

<%@ MasterType VirtualPath="~/ConsultaAmbulatoria/MasterPages/Consultorio.master" %>
<%@ Register Src="~/UserControls/AlertaCM.ascx" TagName="alarma" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $().ready(function() {
            $('#alarma').dialog({ autoOpen: false, minWidth: 800, minHeigth: 500, title: 'Alerta de Recaptación' });
        });
    </script>

    <script src="../js/Format.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="server">
    <div>
        <b>Buscar Menor</b>
        <div style="float: right; margin: -10px 20px 0px 0px">
            <img src="../App_Themes/Login/img/pcontrol.gif" alt="Control del Menor" />
            <a href="Ayuda.pdf" title="Ayuda" target="_blank" onclick="window.open(this.href, this.target, 'width=790,height=600,scrollbars=yes,top=100, left=100'); return false;">
                <img src="../App_Themes/Clasificacion/images/ayuda.png" border="0" alt="Manual de Ayuda" /></a>
        </div>
        <br />
        <table>
            <tr>
                <td>
                    Documento:
                </td>
                <td>
                    <asp:TextBox ID="txtDni" runat="server" MaxLength="8" Width="100px" ToolTip="Solo números"
                        TabIndex="1"></asp:TextBox>
                    <asp:CompareValidator ID="cvNDocumento" runat="server" ErrorMessage="Solo numeros enteros"
                        ControlToValidate="txtDni" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Apellido:
                </td>
                <td>
                    <asp:TextBox ID="txtApellidoBusqueda" runat="server" TabIndex="4"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Nombre:
                </td>
                <td>
                    <asp:TextBox ID="txtNombreBusqueda" runat="server" TabIndex="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Fecha de Nacimiento:
                </td>
                <td>
                    <asp:TextBox ID="txtFecNacBusqueda" runat="server" CssClass="boxcortos" onblur="javascript:formatearFecha(this)"
                        TabIndex="3"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Apellido de la Madre (Soltera):
                </td>
                <td>
                    <asp:TextBox ID="txtApellidoMadreBusqueda" runat="server" TabIndex="6"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Nombre de la Madre:
                </td>
                <td>
                    <asp:TextBox ID="txtNombreMadreBusqueda" runat="server" TabIndex="7"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <asp:Label ID="lblTitulo" runat="server" Text="" Visible="false"></asp:Label><br />
    <asp:GridView ID="gvMenor" runat="server" AutoGenerateColumns="false" ForeColor="#333333"
        GridLines="None" Width="99%" AllowPaging="true" PageSize="10" Visible="false"
        ToolTip="Tabla de Resultado de Pacientes Bajo Control.">
        <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
        <Columns>
            <asp:BoundField DataField="edad" HeaderText="Edad" />
            <asp:BoundField DataField="paciente" HeaderText="Paciente" />
            <asp:BoundField DataField="profesional" HeaderText="Profesional" />
            <asp:BoundField DataField="fechaConsulta" DataFormatString="{0:dd/MM/yyy}" HeaderText="UltimaConsulta" />
            <asp:BoundField DataField="efector" HeaderText="Efector" />
            <asp:BoundField DataField="proximoControl" DataFormatString="{0:dd/MM/yyy}" HeaderText="ProximoControl" />
            <asp:HyperLinkField DataNavigateUrlFields="idPaciente" DataNavigateUrlFormatString="~/ConsultaAmbulatoria/SeleccionTurno.aspx?idPaciente={0}"
                HeaderText="Acción" Text="Nueva Visita" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <br />
    Resultado de Pacientes
    <asp:GridView ID="gvPacientes" runat="server" AutoGenerateColumns="false" ForeColor="#333333"
        GridLines="None" Width="99%" OnSorting="gridView_Sorting" AllowPaging="true"
        OnPageIndexChanging="gvPacientes_PageIndexChangind" PageSize="10" EmptyDataText="<b>No se encontraron datos.<b>"
        OnRowDataBound="gvPacientes_RowDataBound" ToolTip="Tabla de Resultados de Niños menores de 8 años.">
        <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
        <Columns>
            <asp:BoundField DataField="numeroDocumento" HeaderText="Documento" />
            <asp:BoundField DataField="apellido" HeaderText="Apellido" />
            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="sexo" HeaderText="Sexo" />
            <asp:BoundField DataField="edad" HeaderText="Edad" />
            <asp:HyperLinkField DataNavigateUrlFields="idPaciente" DataNavigateUrlFormatString="~/Paciente/PacienteView.aspx?id={0}"
                HeaderText="VerPaciente" Text="Ver" />
            <asp:TemplateField HeaderText="Visitas">
                <ItemTemplate>
                    <asp:HyperLink ID="hlConsultas" runat="server" NavigateUrl='<%# Eval("idPaciente", "~/ConsultaAmbulatoria/SeleccionTurno.aspx?idPaciente={0}") %>'
                        Text="Visitas" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ControldelMenor">
                <ItemTemplate>
                    <asp:HyperLink ID="hlControlMenor" runat="server" NavigateUrl='<%# Eval("idPaciente", "~/ControlMenor/Default.aspx?idPaciente={0}") %>'
                        Text="Datos Iniciales" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <br />
    <div id="alarma">
        <uc1:alarma ID="AlarmaMenor" runat="server" />
    </div>
    <br />
    <div style="border: solid 2px #bde447; margin: 5px;">
        Tener en cuenta al ingreso de datos Iniciales del Control Perinatal. Los datos de
        la Madre:
        <ul>
            <li>Nivel de Instrucción</li>
            <li>Situación Laboral</li>
            <li>Profesión</li>
        </ul>
        Deberán ser ingresados en la correspondiente pestaña de Datos de la Madre.
    </div>
    <%--  <asp:HyperLink runat="server" ID="hlConsultas" NavigateUrl="~/ConsultaAmbulatoria/SeleccionTurno.aspx" Text="Visitas"></asp:HyperLink> |
    <asp:HyperLink runat=server ID="hlControlMenor" NavigateUrl="~\ControlMenor\" Text="Control del Menor"></asp:HyperLink>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="server">
    <asp:Button runat="server" ID="btnBuscar" Text="Buscar Menor" OnClick="btnBuscar_Click"
        TabIndex="2" />
    <asp:Button runat="server" ID="btnNuevo" Text="Nuevo Paciente" OnClick="btnNuevo_Click" />
    <asp:Button runat="server" ID="btnAlarma" Text="Alerta de Recaptación del Menor"
        OnClientClick="javascript:$('#alarma').dialog('open');return false;" />
</asp:Content>
