<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" MasterPageFile="~/ConsultaAmbulatoria/MasterPages/ConsultorioPerinatal.Master"
  Inherits="Consultorio.ConsultaAmbulatoria.ControlPerinatal.Evaluacion.Default" Theme="apr" %>

<%@ MasterType VirtualPath="~/ConsultaAmbulatoria/MasterPages/ConsultorioPerinatal.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <style type="text/css">
    .tab {
      width: 75%;
      border: solid 1px #6ea6d1;
    }
    .tabr {
      border: solid 1px #6ea6d1;
    }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="server">
  <p>
    <b>Evaluación Individual de la Paciente</b></p>
  <table class="tab">
    <tr style="font-weight: bold; text-align: center">
      <td>
        Items a Evaluar
      </td>
      <td>
        Resultados
      </td>
    </tr>
    <tr class="tabr">
      <td>
        Domicilio
      </td>
      <td>
        <asp:Label ID="lblDom" runat="server"></asp:Label>
      </td>
    </tr>
    <tr class="tabr">
      <td>
        Edad - Grupo Etáreo
      </td>
      <td>
        <asp:Label ID="lblEdad" runat="server"></asp:Label>
        -
        <asp:Label ID="lblGrupoE" runat="server"></asp:Label>
      </td>
    </tr>
    <tr class="tabr">
      <td>
        Primigesta
      </td>
      <td>
        <asp:Label ID="lblPrimigesta" runat="server"></asp:Label>
      </td>
    </tr>
    <tr class="tabr">
      <td>
        Captación Oportuna
      </td>
      <td>
        <asp:Label ID="lblCaptacion" runat="server"></asp:Label>
      </td>
    </tr>
    <tr class="tabr">
      <td>
        Patologías Embarazo Actual
      </td>
      <td>
        <asp:Label ID="lblPatologias" runat="server"></asp:Label>
      </td>
    </tr>
    <tr class="tabr">
      <td>
        Factores de Riesgo Psicosociales
      </td>
      <td>
        <asp:Label ID="lblFactorR" runat="server"></asp:Label>
      </td>
    </tr>
    <tr class="tabr">
      <td colspan="2">
        &nbsp;
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:GridView ID="gvControles" runat="server" AutoGenerateColumns="False" ForeColor="#333333"
          GridLines="None" Width="100%" EmptyDataText="<b>No se encontraron datos.<b>">
          <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
          <Columns>
            <asp:TemplateField HeaderText="FechaControl">
              <ItemTemplate>
                <asp:Label ID="lblFControl" runat="server" Text='<%# Bind("FechaControl") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="IMC">
              <ItemTemplate>
                <asp:Label ID="lblIMC" runat="server" Text='<%# Bind("IMC") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="E.G. Sem.">
              <ItemTemplate>
                <asp:Label ID="lblGestacional" runat="server" Text='<%# Bind("EdadGestacional") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Est.Nutric.">
              <ItemTemplate>
                <asp:Label ID="lblNutricion" runat="server" Text='<%# Bind("EstadoNutricional") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PróximaCita">
              <ItemTemplate>
                <asp:Label ID="lblProximaCita" runat="server" Text='<%# Bind("ProximaCita") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Abandono">
              <ItemTemplate>
                <asp:Label ID="lblAbandono" runat="server" Text='<%# Bind("AsisteControl") %>'></asp:Label>
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
      </td>
    </tr>
    <tr class="tabr">
      <td colspan="2">
        &nbsp;
      </td>
    </tr>
    <tr class="tabr" align="center">
      <td colspan="2" align="center">
        Cantidad de Controles a la fecha:
        <asp:Label ID="lblCantidad" runat="server"></asp:Label>
      </td>
    </tr>
  </table>
</asp:Content>
