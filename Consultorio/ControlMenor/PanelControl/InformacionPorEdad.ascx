<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InformacionPorEdad.ascx.cs"
    Inherits="SIPS.ControlMenor.PanelControl.InformacionPorEdad" %>
<asp:ScriptManagerProxy runat="server" ID="smp">
    <Scripts>
        <asp:ScriptReference Path="https://www.google.com/jsapi" />
    </Scripts>
</asp:ScriptManagerProxy>

<script type="text/javascript">
    google.load("visualization", "1", { packages: ["corechart"] });
    google.setOnLoadCallback(drawChart);
    function drawChart() {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Estado Nutricional');
        data.addColumn('number', 'Personas');
        data.addRows(5);
        data.setValue(0, 0, 'Emaciacion');
        data.setValue(0, 1, 3);
        data.setValue(1, 0, 'Riesgo Nutricional');
        data.setValue(1, 1, 5);
        data.setValue(2, 0, 'Normal');
        data.setValue(2, 1, 34);
        data.setValue(3, 0, 'Sobrepeso');
        data.setValue(3, 1, 10);
        data.setValue(4, 0, 'Obesidad');
        data.setValue(4, 1, 1);

        var chart = new google.visualization.PieChart(document.getElementById('<%= chart_div.ClientID %>'));
        chart.draw(data, { width: 820, height: 300, title: 'Estados Nutricionales' });
    }
</script>

<h4>
    <asp:Label runat="server" ID="lblTitulo"></asp:Label></h4>
<fieldset class="ui-widget ui-widget-content ui-corner-all" style="width: 44%; display: inline;">
    <legend>Niños Bajo Programa</legend>
    <asp:Label runat="server" ID="lblNiñosBajoPrograma"></asp:Label>
</fieldset>
<fieldset runat="server" id="fsEdadPromedio" visible="false" class="ui-widget ui-widget-content ui-corner-all"
    style="width: 44%; display: inline;">
    <legend>Edad Promedio Primer Consulta</legend>
    <asp:Label runat="server" ID="lblEdadPromedioPrimerConsulta"></asp:Label>
</fieldset>
<fieldset runat="server" id="fsPorcentajePrimerVisita" visible="false" class="ui-widget ui-widget-content ui-corner-all"
    style="width: 44%; display: inline;">
    <legend>Niños con primer visita<br />
        antes de los 15 dias</legend>
    <asp:Label runat="server" ID="lblPorcentajePrimerVisita"></asp:Label>
</fieldset>
<fieldset class="ui-widget ui-widget-content ui-corner-all" style="width: 44%; display: inline;">
    <legend>Numero de Visitas Por Niño</legend>
    <asp:Label runat="server" ID="lblNumeroVisitas"></asp:Label>
</fieldset>
<fieldset class="ui-widget ui-widget-content ui-corner-all">
    <legend>"Estado Nutricional</legend>Grafico Estado Nutricional
    <div runat="server" id="chart_div">
    </div>
</fieldset>
