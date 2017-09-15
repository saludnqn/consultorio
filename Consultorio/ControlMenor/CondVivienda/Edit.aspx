<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" MasterPageFile="~/ControlMenor/MasterPages/ControlMenor.master" Inherits="SIPS.ControlMenor.CondVivienda.Edit" Theme="apr" %>

<%-- Contenido principal --%>
<asp:Content ID="Content1" ContentPlaceHolderID="Cuerpo" runat="server">
    
    <%-- "Grilla" con las intervenciones --%>
    <asp:Repeater ID="rptIntervenciones" runat="server">
      <HeaderTemplate>
        <table id="tblIntervenciones" cellpadding="0" cellspacing="0" border="0" class="display grilla">
          <thead>
            <tr>
                <th></th>
                <th>Fecha</th>
                <th>Profesional</th>
                <th>Especialidad</th>
                <th>Actividad</th>
                <th>Observaciones</th>
            </tr>
          </thead>
          <tbody>
      </HeaderTemplate>
      <ItemTemplate>
        <tr>
          <td>
            <asp:HyperLink runat="server" ID="hlEditar" NavigateUrl='<%# String.Format("Edit.aspx?idPaciente={0}&id={1}",Eval("idPaciente"),Eval("idIntervencionProfesional")) %>' Text="Editar">
            </asp:HyperLink>
          </td>
          <td><%# Eval("Fecha", "{0:dd/MM/yyyy}") %></td>
          <td><%# Eval("Profesional") %></td>
          <td><%# Eval("SysEspecialidad.Nombre") %></td>
          <td><%# Eval("AprActividad.Nombre") %></td>
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

