<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AlertasControlMenor.ascx.cs" Inherits="UserControls.AlertasControlMenor" %>

<asp:Repeater runat="server" ID="rptAlertas">
    <ItemTemplate>
        <div class="ui-widget">
            <div style="padding: 10px 0.7em;" class="ui-state-error ui-corner-all">
                <p>
                    <span style="float: left; margin-right: 0.3em;" class="ui-icon ui-icon-alert"></span>
                    <strong>Alerta:</strong>
                    <asp:Label runat="server" ID="lblAlerta" Text='<%# Eval("Descripcion") %>'></asp:Label></p>
            </div>
        </div>
    </ItemTemplate>
    <SeparatorTemplate>
        <br />
    </SeparatorTemplate>
</asp:Repeater>
