<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlOdontologico.ascx.cs"
    Inherits="Consultorio.ConsultaAmbulatoria.ControlMenor.ControlOdontologico" %>
<table class="formulario">
    <tr>
        <td>
            <asp:Label runat="server" ID="lblProfesional" Text="Profesional" AssociatedControlID="ddlProfesional"></asp:Label>
            <asp:DropDownList runat="server" ID="ddlProfesional" CssClass="fixedWidth">
            </asp:DropDownList>
        </td>
        <td>
            <asp:Label runat="server" ID="lblDiagnostico" Text="Diagnostico" AssociatedControlID="ddlDiagnostico"></asp:Label>
            <asp:DropDownList runat="server" ID="ddlDiagnostico" CssClass="fixedWidth">
            </asp:DropDownList>
        </td>
        <tr>
            <td colspan="2">
                <asp:Label runat="server" ID="lblObservacion" Text="Observacion" AssociatedControlID="txtObservacion">
                    <asp:TextBox runat="server" ID="txtObservacion" TextMode="MultiLine" Rows="5"></asp:TextBox>
                </asp:Label>
            </td>
        </tr>
    </tr>
</table>
