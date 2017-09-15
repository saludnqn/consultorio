<%@ Page Title="" Language="C#" MasterPageFile="~/ControlMenor/MasterPages/ControlMenor.master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="SIPS.ControlMenor.ResProblemas.Edit"  theme="apr"%>
<%@ MasterType VirtualPath="~/ControlMenor/MasterPages/ControlMenor.master"%>
<%@ Register src="../../ConsultaAmbulatoria/UserControls/DiagnosticoPrincipal.ascx" tagname="DiagnosticoPrincipal" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cuerpo" runat="server">
    <table class="formulario">
<tr>
            <td>
                <asp:Label runat="server" ID="lFecha" Text="Fecha" AssociatedControlID="txtFecha"></asp:Label><br />
                <asp:TextBox runat="server" ID="txtFecha" CssClass="FixedWidth"></asp:TextBox>
            </td>
            <td>
               
            </td>
        </tr>
        <tr>
        <td colspan="2">
        <asp:Label runat="server" ID="IDiagnosticoPrincipal1" Text="Diagnóstico" AssociatedControlID="DiagnosticoPrincipal1"></asp:Label><br />
            <uc1:DiagnosticoPrincipal ID="DiagnosticoPrincipal1" runat="server" ></uc1:DiagnosticoPrincipal>
        </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label runat="server" ID="lDescripcion" Text="Descripcion" AssociatedControlID="txtDescripcion"></asp:Label><br />
                <asp:TextBox runat="server" ID="txtDescripcion" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </td>
        </tr>
    <tr>
            <td colspan="2">
                <asp:Label runat="server" ID="lIntervencion" Text="Diseño de Intervencion" AssociatedControlID="txtIntervencion"></asp:Label><br />
                <asp:TextBox runat="server" ID="txtIntervencion" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Botones" runat="server">
    <asp:Button runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" />
    <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" />
</asp:Content>
