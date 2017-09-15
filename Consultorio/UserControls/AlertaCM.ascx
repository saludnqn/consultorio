<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AlertaCM.ascx.cs" Inherits="UserControls.AlertaCM" %>

<asp:Repeater runat="server" ID="rptAlertas">
    <ItemTemplate>
        <div class="ui-widget">
            <div style="padding: 10px 0.7em;" class="ui-state-error ui-corner-all">
                <p>
                    <span style="float: left; margin-right: 0.3em;" class="ui-icon ui-icon-alert"></span>
                    <strong>Estado:</strong>
                    <asp:Label runat="server" ID="lblAsiste" Text='<%# Eval("Asiste") %>'></asp:Label>-
                    <strong>DNI:</strong><asp:Label runat="server" ID="lblDoc" Text='<%# Eval("numeroDocumento") %>'></asp:Label>-
                    <strong>Nombre:</strong><asp:Label runat="server" ID="lblPaciente" Text='<%# Eval("Paciente") %>'></asp:Label>-
                    <strong>UltimoControl:</strong><asp:Label runat="server" ID="lblFechaUltimoControl" Text='<%# Eval("FechaUltimoControl") %>'></asp:Label>-
                    <strong>Edad:</strong><asp:Label runat="server" ID="lblEdad" Text='<%# Eval("Edad") %>'></asp:Label>
                    <strong>FechaProximoControl:</strong><asp:Label runat="server" ID="lblFechaPC" Text='<%# Eval("FechaProximoControl") %>'></asp:Label>-
                   </p>
            </div>
        </div>
    </ItemTemplate>
    <SeparatorTemplate>
<br />
    </SeparatorTemplate>
</asp:Repeater>