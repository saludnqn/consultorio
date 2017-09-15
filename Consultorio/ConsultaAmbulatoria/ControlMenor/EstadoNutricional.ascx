<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EstadoNutricional.ascx.cs"
    Inherits="Consultorio.ConsultaAmbulatoria.ControlMenor.EstadoNutricional" %>
<table class="formulario">
    <tr>
        <td>
            <fieldset class="ui-widget ui-widget-content ui-corner-all">
                <legend>Lactancia</legend>
                <asp:RadioButtonList runat="server" ID="rblLactancia" CssClass="rbList">
                </asp:RadioButtonList>
            </fieldset>
        </td>
        <td style="vertical-align:top">
            <asp:Label runat="server" ID="lblIntervencion" AssociatedControlID="ddlIntervencion"
                Text="Intervenciones:"></asp:Label>
            <asp:DropDownList runat="server" ID="ddlIntervencion" Width="350">
            </asp:DropDownList>
        </td>
    </tr>
</table>
