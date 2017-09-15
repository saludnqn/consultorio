<%@ Page Title="" Language="C#" MasterPageFile="~/ControlMenor/MasterPages/ControlMenor.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SIPS.ControlMenor.VisitasDomiciliarias.Default" Theme="apr"%>

<%-- Contenido principal --%>
<asp:Content ID="Content1" ContentPlaceHolderID="Cuerpo" runat="server">
    
    <%-- "Grilla" con las visitas domiciliarias --%>
    <asp:Repeater ID="rptVisitas" runat="server">
      <HeaderTemplate>
        <table id="tblVisitas" cellpadding="0" cellspacing="0" border="0" class="display grilla">
          <thead>
            <tr>
                <th></th>
                <th>Fecha</th>
                <th>Personal</th>
                <th>Motivo</th>
                <th>Observaciones</th>
            </tr>
          </thead>
          <tbody>
      </HeaderTemplate>
      <ItemTemplate>
        <tr>
          <td>
            <asp:HyperLink runat="server" ID="hlEditar" NavigateUrl='<%# String.Format("Edit.aspx?idPaciente={0}&id={1}",Eval("idPaciente"),Eval("idVisitaDomiciliaria")) %>' Text="Editar"></asp:HyperLink>
          </td>
          <td><%# Eval("Fecha", "{0:dd/MM/yyyy}") %></td>
          <td><%# Eval("Personal") %></td>
          <td><asp:Literal runat="server" ID="lEspecialidad" Text='<%# Eval("AprMotivoVisitaDomiciliarium.Nombre") %>'></asp:Literal></td>
          <td><%# Eval("Observacion") %></td>
        </tr>
      </ItemTemplate>
      <FooterTemplate>
        </tbody>
        </table>
      </FooterTemplate>
    </asp:Repeater>

</asp:Content>

<%-- Botonera --%>
<asp:Content ID="Content2" ContentPlaceHolderID="Botones" runat="server">
    <asp:Button runat="server" ID="btnNuevo" Text="Nuevo" OnClick="btnNuevo_Click" />
</asp:Content>
