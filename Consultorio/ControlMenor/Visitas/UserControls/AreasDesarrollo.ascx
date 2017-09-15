<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AreasDesarrollo.ascx.cs"
    Inherits="SIPS.ControlMenor.Visitas.UserControls.AreasDesarrollo" %>

<table>
    <tr>
        <td  style="text-align:right; padding-right:5px; font-weight:bold;">Áreas de desarrollo:</td>
        <td>
            <asp:Repeater ID="rptAreasDesarrollo" runat="server">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li><%# Eval("AreaDesarrollo") %> - Adecuado: <%# (bool)Eval("Adecuado")? "Sí" : "No" %>; Ítem: <%# Eval("Item") %></li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </td>
    </tr>
</table>