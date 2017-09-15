<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuControlMenor.ascx.cs" Inherits="SIPS.ControlMenor.UserControls.MenuControlMenor" %>

<%--
    Devuelve una "UL" con los enlaces al subsistema "Control del Menor".
    
    Utiliza clases del Framework CSS de jQueryUI, para mostrar unas pestañas copantes.
--%>

<ul class="ui-tabs-nav ui-helper-reset ui-helper-clearfix ui-widget-header ui-corner-all" id="tabGroup" runat="server">
    <li id="tabDatosMadre" runat="server" class="ui-state-default ui-corner-top">
        <asp:HyperLink runat="server" ID="hlDatosMadre" Text="Datos<br />Madre" NavigateUrl=""></asp:HyperLink>
    </li>
        <li id="tabCondicionesVivienda" runat="server" class="ui-state-default ui-corner-top">
        <asp:HyperLink runat="server" ID="hlCondicionesVivienda" Text="Condiciones<br />Vivienda" NavigateUrl=""></asp:HyperLink>
    </li>
    <li id="tabDatosPerinatales" runat="server" class="ui-state-default ui-corner-top">
        <asp:HyperLink runat="server" ID="hlDatosPerinatales" Text="Datos<br />perinatales" NavigateUrl=""></asp:HyperLink>
    </li>
    <li id="tabControles" runat="server" class="ui-state-default ui-corner-top">
        <asp:HyperLink runat="server" ID="hlControles" Text="Visitas<br />de Salud" NavigateUrl=""></asp:HyperLink>
    </li>
    <li id="tabCalendarioVacunacion" runat="server" class="ui-state-default ui-corner-top">
        <asp:HyperLink runat="server" ID="hlCalendarioVacunacion" Text="Calendario<br />de vacunación" NavigateUrl=""></asp:HyperLink>
    </li>
    <li id="tabResumenProblemas" runat="server" class="ui-state-default ui-corner-top">
        <asp:HyperLink runat="server" ID="hlResumenProblemas" Text="Resumen<br />de Problemas" NavigateUrl=""></asp:HyperLink>
    </li>
    <li id="tabVisitasDomiciliarias" runat="server" class="ui-state-default ui-corner-top">
        <asp:HyperLink runat="server" ID="hlVisitasDomiliarias" Text="Visitas<br />Domiciliarias" NavigateUrl=""></asp:HyperLink>
    </li>
    <li id="tabIntervenciones" runat="server" class="ui-state-default ui-corner-top">
        <asp:HyperLink runat="server" ID="hlIntervenciones" Text="<br />Intervenciones" NavigateUrl=""></asp:HyperLink>
    </li>
</ul>
