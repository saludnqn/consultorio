<%@ Page Language="C#" MasterPageFile="~/ControlMenor/MasterPages/ControlMenor.master"
    AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="SIPS.ControlMenor.Visitas.View"
    Theme="apr" %>

<%@ Register Src="~/ControlMenor/Visitas/UserControls/Consultorio.ascx" TagName="Consultorio"
    TagPrefix="uc" %>
<%@ Register Src="~/ControlMenor/Visitas/UserControls/Control.ascx" TagName="Control"
    TagPrefix="uc" %>
<%@ Register Src="~/ControlMenor/Visitas/UserControls/Enfermeria.ascx" TagName="Enfermeria"
    TagPrefix="uc" %>
<%@ Register Src="~/ControlMenor/Visitas/UserControls/EstadoNutricional.ascx" TagName="EstadoNutricional"
    TagPrefix="uc" %>
<%@ Register Src="~/ControlMenor/Visitas/UserControls/AreasDesarrollo.ascx" TagName="AreasDesarrollo"
    TagPrefix="uc" %>
<%@ Register Src="~/ControlMenor/Visitas/UserControls/FactoresRiesgo.ascx" TagName="FactoresRiesgo"
    TagPrefix="uc" %>
<%@ Register Src="~/ControlMenor/Visitas/UserControls/FactoresProtectores.ascx" TagName="FactoresProtectores"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function() {
            $('#tabs').tabs().addClass('ui-tabs-vertical ui-helper-clearfix');
            $("#tabs li").removeClass('ui-corner-top').addClass('ui-corner-left');
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="server">
    <div id="tabs">
        <ul>
            <li><a href="#tabConsultorio">
                <br />
                Consultorio</a></li>
            <% if (idControl != 0)
               { %>
            <li><a href="#tabEstadoNutricional">Tipo<br />
                Alimentacion</a></li>
            <li><a href="#tabEnfermeria">
                <br />
                Enfermeria</a></li>
            <li><a href="#tabAreasDesarrollo">Areas de<br />
                Desarrollo</a></li>
            <li><a href="#tabFactoresRiesgo">Factores<br />
                de Riesgo</a></li>
            <li><a href="#tabFactoresProtectores">Factores<br />
                Protectores</a></li>
            <li><a href="#tabControl">
                <br />
                Control</a></li>
            <% } %>
        </ul>
        <div id="tabConsultorio">
            <uc:Consultorio runat="server" />
        </div>
        <% if (idControl != 0)
           { %>
        <div id="tabEstadoNutricional">
            <uc:EstadoNutricional runat="server" />
        </div>
        <div id="tabEnfermeria">
            <uc:Enfermeria runat="server" />
        </div>
        <div id="tabAreasDesarrollo">
            <uc:AreasDesarrollo runat="server" />
        </div>
        <div id="tabFactoresRiesgo">
            <uc:FactoresRiesgo runat="server" />
        </div>
        <div id="tabFactoresProtectores">
            <uc:FactoresProtectores runat="server" />
        </div>
        <div id="tabControl">
            <uc:Control ID="Control1" runat="server" />
        </div>
        <% } %>
    </div>
</asp:Content>
<%-- Botonera --%>
<asp:Content ID="Content4" ContentPlaceHolderID="Botones" runat="server">
    <asp:Button Text="Volver al listado" runat="server" ID="btnVolver" OnClick="btnVolver_Click" />
</asp:Content>
