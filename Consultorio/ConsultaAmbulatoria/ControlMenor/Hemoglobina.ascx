<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Hemoglobina.ascx.cs"
    Inherits="Consultorio.ConsultaAmbulatoria.ControlMenor.Hemoglobina" %>
<table class="formulario">
    <tr>
        <td>
            <asp:Label runat="server" ID="lblResultado" Text="Resultado" AssociatedControlID="txtResultado"></asp:Label>
            <asp:TextBox runat="server" ID="txtResultado" CssClass="fixedWith"></asp:TextBox>
        </td>
    </tr>
</table>
