<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Consultas.ascx.cs" Inherits="ConsultaAmbulatoria.UserControls.Consultas" %>
<fieldset class="ui-widget ui-widget-content ui-corner-all">
<table class="formulario">
  <tr>
    <td>
      Fecha Inicio: <asp:TextBox runat="server" ID="txtFechaI" Columns="12"></asp:TextBox> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      Fecha de Fin: <asp:TextBox runat="server" ID="txtFechaF" Columns="12"></asp:TextBox>
    </td>
  </tr>
  <tr><td>&nbsp;</td>
  </tr>
  <tr>
    <td>
      Especialidad:
      <asp:DropDownList ID="ddlEspecialidad" runat="server" ToolTip="Seleccione la Especialidad" AutoPostBack="false" >
      </asp:DropDownList>
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Tipo de Profesional:
      <asp:DropDownList ID="ddlTipoProfesional" runat="server" ToolTip="Seleccione el Tipo de Profesional a consultar" 
        onselectedindexchanged="ddlTipoProfesional_SelectedIndexChanged" AutoPostBack="true">
      </asp:DropDownList>
    </td>
  </tr>
  <tr><td>&nbsp;</td>
  </tr>
  <tr>
    <td>
      <asp:GridView ID="gvConsultas" runat="server" AutoGenerateColumns="false" ForeColor="#333333"
        GridLines="None" Width="99%" AllowPaging="true" PageSize="10" EmptyDataText="<b>No se encontraron datos.<b>">
        <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
        <Columns>
          <asp:BoundField DataField="fecha" DataFormatString="{0:dd/MM/yyy}" HeaderText="Fecha Consulta" />
          <asp:BoundField DataField="paciente" HeaderText="Paciente" />
          <asp:BoundField DataField="numerodocumento" HeaderText="Documento" />
          <asp:BoundField DataField="nombreCompleto" HeaderText="Profesional" />
          <asp:HyperLinkField DataNavigateUrlFields="idConsulta" DataNavigateUrlFormatString="~/ConsultaAmbulatoria/Default.aspx?idConsulta={0}"
            HeaderText="Ver" Text="Ver" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
      </asp:GridView><br />
    </td>
  </tr>
</table>
</fieldset>
