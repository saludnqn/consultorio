<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FactoresProtectores.ascx.cs"
    Inherits="Consultorio.ConsultaAmbulatoria.ControlMenor.FactoresProtectores" %>
<fieldset class="ui-widget ui-widget-content ui-corner-all">
    <legend>Factores Protectores</legend>
    <table class="formulario">
        <asp:Repeater runat="server" ID="rptFactoresProtectores">
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:CheckBox runat="server" ID="cbFactorProtector" />
                    </td>
                    <td>
                        <asp:HiddenField runat="server" ID="hfFactorProtectorId" Value='<%# Eval("idFactorProtector") %>' />
                        <asp:Label runat="server" ID="lblFactorProtector" Text='<%# Eval("Nombre") %>' AssociatedControlID="cbFactorProtector"></asp:Label>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</fieldset>
