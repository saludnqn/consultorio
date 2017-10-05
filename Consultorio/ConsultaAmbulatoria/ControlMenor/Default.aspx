<%@ Page Title="" Language="C#" MasterPageFile="~/ConsultaAmbulatoria/MasterPages/Consultorio.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Consultorio.ConsultaAmbulatoria.ControlMenor.Default"
    Theme="apr" %>

<%@ MasterType VirtualPath="~/ConsultaAmbulatoria/MasterPages/Consultorio.master" %>
<%@ Register Src="../UserControls/ConsultaAmbulatoria.ascx" TagName="ConsultaAmbulatoria"
    TagPrefix="uc1" %>
<%@ Register Src="~/ConsultaAmbulatoria/ControlMenor/EstadoNutricional.ascx" TagName="EstadoNutricional"
    TagPrefix="CM" %>
<%@ Register Src="~/ConsultaAmbulatoria/ControlMenor/Enfermeria.ascx" TagName="Enfermeria"
    TagPrefix="CM" %>
<%@ Register Src="~/ConsultaAmbulatoria/ControlMenor/AreasDesarrollo.ascx" TagName="AreasDesarrollo"
    TagPrefix="CM" %>
<%@ Register Src="~/ConsultaAmbulatoria/ControlMenor/FactoresRiesgo.ascx" TagName="FactoresRiesgo"
    TagPrefix="CM" %>
<%@ Register Src="~/ConsultaAmbulatoria/ControlMenor/FactoresProtectores.ascx" TagName="FactoresProtectores"
    TagPrefix="CM" %>
<%@ Register Src="~/ConsultaAmbulatoria/ControlMenor/Control.ascx" TagName="Control"
    TagPrefix="CM" %>
<%@ Register Src="~/ConsultaAmbulatoria/ControlMenor/ControlOdontologico.ascx" TagName="ControlOdontologico"
    TagPrefix="CM" %>
<%@ Register Src="~/ConsultaAmbulatoria/ControlMenor/Hemoglobina.ascx" TagName="ControlHemoglobina"
    TagPrefix="CM" %>
<%@ Register src="../UserControls/AlertasControlMenor.ascx" tagname="AlertasControlMenor" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function() {
            $('#tabs').tabs();

            $('.tooltipeable').tooltip({
                position: "center right",
                offset: [0, 5],
                effect: 'fade',
                opacity: 0.7
            });

            $('#wdwAlertas').dialog({ autoOpen: false, minWidth: 800, minHeigth: 500, title: 'Alerta', modal:true });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="server">
    <asp:ScriptManagerProxy runat="server" ID="smp">
        <Scripts>
            <asp:ScriptReference Path="~/js/tooltips/jquery.tools.min.js" />
        </Scripts>
    </asp:ScriptManagerProxy>
    <div id="tabs">
        <ul>
            <li runat="server" id="liConsultorio"><a href='#<%= tabConsultorio.ClientID %>'>
                <br />
                Consultorio</a></li>
            <li runat="server" id="liEstadoNutricional"><a href='#<%= tabEstadoNutricional.ClientID %>'>
                Tipo<br />
                Alimentacion</a></li>
            <li runat="server" id="liEnfermeria"><a href='#<%= tabEnfermeria.ClientID %>'>
                <br />
                Enfermeria</a></li>
            <li runat="server" id="liAreasDesarrollo"><a href='#<%= tabAreasDesarrollo.ClientID %>'>
                Areas de<br />
                Desarrollo</a></li>
            <li runat="server" id="liFactoresRiesgo"><a href='#<%= tabFactoresRiesgo.ClientID %>'>
                Factores<br />
                de Riesgo</a></li>
            <li runat="server" id="liFactoresProtectores"><a href='#<%= tabFactoresProtectores.ClientID %>'>
                Factores<br />
                Protectores</a></li>
            <li runat="server" id="liControlOdontologico"><a href='#<%= tabControlOdontologico.ClientID %>'>
                Control<br />
                Odontologico</a> </li>
            <li runat="server" id="liControlHemoglobina"><a href='#<%= tabControlHemoglobina.ClientID %>'>
                Analisis<br />
                Hemoglobina </a></li>
            <li runat="server" id="liControl"><a href='#<%= tabControl.ClientID %>'>
                <br />
                Control</a></li>
        </ul>
        <div id="tabConsultorio" runat="server">
            <uc1:ConsultaAmbulatoria ID="ConsultaAmbulatoria1" runat="server" />
        </div>
        <div id="tabEstadoNutricional" runat="server">
            <CM:EstadoNutricional runat="server" ID="EstadoNutricional1"></CM:EstadoNutricional>
        </div>
        <div id="tabEnfermeria" runat="server">
            <CM:Enfermeria runat="server" ID="Enfermeria1"></CM:Enfermeria>
        </div>
        <div id="tabAreasDesarrollo" runat="server">
            <CM:AreasDesarrollo runat="server" ID="AreasDesarrollo1"></CM:AreasDesarrollo>
        </div>
        <div id="tabFactoresRiesgo" runat="server">
            <CM:FactoresRiesgo runat="server" ID="FactoresRiesgo1" />
        </div>
        <div id="tabFactoresProtectores" runat="server">
            <CM:FactoresProtectores runat="server" ID="FactoresProtectores1" />
        </div>
        <div id="tabControlOdontologico" runat="server">
            <CM:ControlOdontologico runat="server" ID="ControlOdontologico1" />
        </div>
        <div id="tabControlHemoglobina" runat="server">
            <CM:ControlHemoglobina runat="server" ID="ControlHemoglobina1" />
        </div>
        <div id="tabControl" runat="server">
            <CM:Control runat="server" ID="Control1" />
        </div>
    </div>
    
    <!-- Venatanas -->
    <div id="wdwAlertas">
        <uc2:AlertasControlMenor ID="AlertasControlMenor1" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="server">
    <asp:Button runat="server" ID="btnVolver" Text="Volver al Paciente" OnClick="btnVolver_Click" />
    <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" />
    <asp:Button runat="server" ID="btnGuardar" Text="Guardar Registro de Consulta" OnClick="btnGuardar_Click" />
    <asp:Button runat="server" ID="btnAlertas" Text="Alertas" OnClientClick="javascript:$('#wdwAlertas').dialog('open');return false;" />
</asp:Content>
