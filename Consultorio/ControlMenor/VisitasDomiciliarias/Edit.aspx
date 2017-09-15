<%@ Page Title="" Language="C#" MasterPageFile="~/ControlMenor/MasterPages/ControlMenor.master"
    AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="SIPS.ControlMenor.VisitasDomiciliarias.Edit"
    Theme = "apr" %>

<%@ MasterType VirtualPath="~/ControlMenor/MasterPages/ControlMenor.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cuerpo" runat="server">
    <table class="formulario">
        <tr>
            <td>
                <asp:Label runat="server" ID="lFecha" Text="Fecha" AssociatedControlID="txtFecha"></asp:Label><br />
                <asp:TextBox runat="server" ID="txtFecha"></asp:TextBox>
            </td>
            <td>
                <asp:Label runat="server" ID="lPersonal" Text="Personal" AssociatedControlID="ddlPersonal"></asp:Label><br />
                <asp:DropDownList runat="server" ID="ddlPersonal" CssClass="fixedWidth"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" ID="lMotivoVisita" Text="Motivo de la visita" AssociatedControlID="ddlMotivoVisita"></asp:Label><br />
                <asp:DropDownList runat="server" ID="ddlMotivoVisita" CssClass="fixedWidth">
                </asp:DropDownList>
            </td>
            <td>
                
            </td>
        </tr>
        <tr>
            <td colspan="2">
            <asp:Label runat="server" ID="lOtroMotivo" Text="Otros Motivos" AssociatedControlID="txtOtroMotivo"></asp:Label><br />
                <asp:TextBox runat="server" ID="txtOtroMotivo" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label runat="server" ID="lObservacion" Text="Observaciones" AssociatedControlID="txtObservacion"></asp:Label><br />
                <asp:TextBox runat="server" ID="txtObservacion" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Botones" runat="server">
    <asp:Button runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" />
    <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" />
</asp:Content>
