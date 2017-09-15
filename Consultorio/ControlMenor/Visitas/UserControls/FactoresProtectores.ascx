<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FactoresProtectores.ascx.cs"
    Inherits="SIPS.ControlMenor.Visitas.UserControls.FactoresProtectores" %>

<table>
    <tr>
        <td  style="text-align:right; padding-right:5px; font-weight:bold;">Factores protectores:</td>
        <td>
            <asp:Repeater ID="rptFactoresProtectores" runat="server">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li><%# Eval("FactorProtector") %></li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </td>
    </tr>
</table>