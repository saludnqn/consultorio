<%@ Page Title="" Language="C#" MasterPageFile="~/ControlMenor/MasterPages/ControlMenor.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SIPS.ControlMenor.ResProblemas.Default" theme="apr"%>

<%-- Contenido principal --%>
<asp:Content ID="Content1" ContentPlaceHolderID="Cuerpo" runat="server">
    
    <%-- "Grilla" con los problemas --%>
    <asp:Repeater ID="rptProblemas" runat="server">
      <HeaderTemplate>
        <table id="tblProblemas" cellpadding="0" cellspacing="0" border="0" class="display grilla">
          <thead>
            <tr>
                <th></th>
                <th>Fecha</th>
                <th>Descripción</th>
                <th>Intervención</th>
                <th>CODCIE10</th>
            </tr>
          </thead>
          <tbody>
      </HeaderTemplate>
      <ItemTemplate>
        <tr>
          <td>
            <asp:HyperLink runat="server" ID="hlEditar" NavigateUrl='<%# String.Format("Edit.aspx?idPaciente={0}&id={1}",Eval("idPaciente"),Eval("idProblemaMenor")) %>' Text="Editar">
            </asp:HyperLink>
          </td>
          <td><%# Eval("Fecha", "{0:dd/MM/yyyy}") %></td>
          <td><%# Eval("Descripcion") %></td>
          <td><%# Eval("Intervencion") %></td>
          <td><asp:Literal runat="server" ID="lEspecialidad" Text='<%# Eval("SysCIE10.Codigo") %>'></asp:Literal></td>
        </tr>
      </ItemTemplate>
      <FooterTemplate>
        </tbody>
        </table>
      </FooterTemplate>
    </asp:Repeater>

    <%--<asp:GridView runat="server" ID="gvProblemas">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink runat="server" ID="hlEditar" NavigateUrl='<%# String.Format("Edit.aspx?idPaciente={0}&id={1}",Eval("idPaciente"),Eval("idProblemaMenor")) %>'
                        Text="Editar"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Fecha" DataField="Fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField HeaderText="Intervencion" DataField="Intervencion" />
            <asp:TemplateField HeaderText="CODCIE10">
                <ItemTemplate>
                    <asp:Literal runat="server" ID="lEspecialidad" Text='<%# Eval("SysCIE10.Codigo") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>--%>
</asp:Content>

<%-- Botonera --%>
<asp:Content ID="Content2" ContentPlaceHolderID="Botones" runat="server">
    <asp:Button runat="server" ID="btnNuevo" Text="Nuevo" OnClick="btnNuevo_Click" />
</asp:Content>
