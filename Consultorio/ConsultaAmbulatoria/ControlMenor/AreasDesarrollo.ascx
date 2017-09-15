<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AreasDesarrollo.ascx.cs"
    Inherits="Consultorio.ConsultaAmbulatoria.ControlMenor.AreasDesarrollo" %>
<fieldset class="ui-widget ui-widget-content ui-corner-all">
    <legend>Desarrollo por Areas</legend>
    <table class="formulario">
        <thead>
            <td>
                Se observan dificultades en:
            </td>
            <td>
                Si
            </td>
            <td>
                No
            </td>
            <td>
                Item
            </td>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="rptAreaDesarrollo">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:HiddenField runat="server" ID="hfAreaDesarrolloID" Value='<%# Eval("idAreaDesarrollo") %>' />
                            <%# Eval("Nombre") %>
                        </td>
                        <td>
                            <asp:RadioButton runat="server" ID="cbAreaDesarrolloSi" GroupName='<%# Eval("idAreaDesarrollo") %>' />
                        </td>
                        <td>
                            <asp:RadioButton runat="server" ID="cbAreaDesarrolloNo" GroupName='<%# Eval("idAreaDesarrollo") %>' />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtAreaDesarrolloItem" Columns="8" CssClass="tooltipeable"
                                title="Solo Numeros"></asp:TextBox>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</fieldset>
