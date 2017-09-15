<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CurvasCrecimiento.ascx.cs"
    Inherits="SIPS.ControlMenor.UserControls.CurvasCrecimiento" %>
<%@ Register Src="../UserControls/PlotPesoEdad.ascx" TagName="PlotPesoEdad" TagPrefix="pc" %>
<%@ Register Src="../UserControls/PlotLongEstEdad.ascx" TagName="PlotLongEstEdad"
    TagPrefix="pc" %>
<%@ Register Src="../UserControls/PlotPerCefEdad.ascx" TagName="PlotPerCefEdad" TagPrefix="pc" %>
<%@ Register Src="../UserControls/PlotIMCEdad.ascx" TagName="PlotIMCEdad" TagPrefix="pc" %>

<script type="text/javascript">
    $(document).ready(function() {
        $('#tabsCurvas').tabs();
    });
</script>

<div id="tabsCurvas">
    <ul>
        <li runat="server" id="liPesoEdad"><a href='#<%= divPesoEdad.ClientID %>'>Peso<br />
            Edad</a></li>
        <li runat="server" id="liLongEstEdad"><a href='#<%= divLongEstEdad.ClientID %>'>Long/Est<br />
            Edad</a></li>
        <li runat="server" id="liPerCefEdad"><a href='#<%= divPerCefEdad.ClientID %>'>Per. cefalico<br />
            Edad</a></li>
        <li runat="server" id="liIMcEdad"><a href='#<%= divIMcEdad.ClientID %>'>IMC<br />
            Edad</a></li>
    </ul>
    <div id="divPesoEdad" runat="server">
        <pc:PlotPesoEdad ID="plotPesoEdad" runat="server" />
    </div>
    <div id="divLongEstEdad" runat="server">
        <pc:PlotLongEstEdad ID="plotLongEstEdad" runat="server" />
    </div>
    <div id="divPerCefEdad" runat="server">
        <pc:PlotPerCefEdad ID="plotPerCefEdad" runat="server" />
    </div>
    <div id="divIMcEdad" runat="server">
        <pc:PlotIMCEdad ID="plotIMCEdad" runat="server" />
    </div>
</div>
