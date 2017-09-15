<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FactoresRiesgo.ascx.cs"
    Inherits="Consultorio.ConsultaAmbulatoria.ControlMenor.FactoresRiesgo" %>
<fieldset class="ui-widget ui-widget-content ui-corner-all">
    <legend>Factores de Riesgo</legend>
    <table class="formulario">
        <asp:Repeater runat="server" ID="rptFactoresRiesgo">
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:CheckBox runat="server" ID="cbFactor" />
                    </td>
                    <td>
                        <asp:HiddenField runat="server" ID="hfFactorRiesgoId" Value='<%# Eval("idFactorRiesgo") %>' />
                        <asp:Label runat="server" ID="lblFactorRiesgo" Text='<%# Eval("Nombre") %>' AssociatedControlID="cbFactor"></asp:Label>
                    </td>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <td>
                    <asp:CheckBox runat="server" ID="cbFactor" />
                </td>
                <td>
                    <asp:HiddenField runat="server" ID="hfFactorRiesgoId" Value='<%# Eval("idFactorRiesgo") %>' />
                    <asp:Label runat="server" ID="lblFactorRiesgo" Text='<%# Eval("Nombre") %>' AssociatedControlID="cbFactor"></asp:Label>
                </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:Repeater>
    </table>
</fieldset>
