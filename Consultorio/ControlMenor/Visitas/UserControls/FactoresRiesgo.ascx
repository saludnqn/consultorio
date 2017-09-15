<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FactoresRiesgo.ascx.cs"
    Inherits="SIPS.ControlMenor.Visitas.UserControls.FactoresRiesgo" %>

<table>
    <tr>
        <td  style="text-align:right; padding-right:5px; font-weight:bold;">Factores de riesgo:</td>
        <td>
            <asp:Repeater ID="rptFactoresRiesgo" runat="server">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li><%# Eval("FactorRiesgo") %></li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </td>
    </tr>
</table>