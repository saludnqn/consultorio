<%@ Page Title="" Language="C#" MasterPageFile="~/ControlMenor/MasterPages/PanelControl.master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SIPS.ControlMenor.PanelControl.Default"
    EnableTheming="true" Theme="apr" %>

<%@ Register Src="InformacionPorEdad.ascx" TagName="InformacionPorEdad" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function() {
        $('#<%= tabs.ClientID %>').tabs();

        $('#fsFiltro > input').button()
        });
    </script>
    <script src="../../../js/Format.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="server">
    <fieldset id="fsFiltro" class="ui-widget ui-widget-content ui-corner-all">
        <legend>Filtro</legend>
        <asp:DropDownList runat="server" ID="ddlEfector">
        </asp:DropDownList>
        <br /><br />
        <b>Fecha de Inicio:</b><asp:TextBox ID="txtFInicio" onblur="javascript:formatearFecha(this)"
            ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp; <b>Fecha de Fin: </b>
        <asp:TextBox ID="txtFFin" onblur="javascript:formatearFecha(this)" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
            runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;    
        <asp:Button runat="server" ID="btnFiltrar" Text="Filtrar" OnClick="btnFiltrar_Click" />
    </fieldset>
    <div id="tabs" runat="server">
        <ul>
            <li id="li6meses"><a href="#div6meses">
                <br />
                6 meses </a></li>
            <li id="li12meses"><a href="#div12meses">
                <br />
                12 Meses</a></li>
            <li id="li2anios"><a href="#div2anios">
                <br />
                2 años</a></li>
            <li id="li3anios"><a href="#div3anios">
                <br />
                3 años</a></li>
            <li id="li4anios"><a href="#div4anios">
                <br />
                4 años</a></li>
            <li id="li5anios"><a href="#div5anios">
                <br />
                5 años</a></li>
            <li id="li6anios"><a href="#div6anios">
                <br />
                6 años</a></li>
        </ul>
        <div id="div6meses">
            <uc1:InformacionPorEdad ID="InformacionPorEdad6meses" runat="server" edadCorte="corte6meses" />
        </div>
        <div id="div12meses">
            <uc1:InformacionPorEdad ID="InformacionPorEdad12meses" runat="server" edadCorte="corte12meses" />
        </div>
        <div id="div2anios">
            <uc1:InformacionPorEdad ID="InformacionPorEdad2anios" runat="server" edadCorte="corte2años" />
        </div>
        <div id="div3anios">
            <uc1:InformacionPorEdad ID="InformacionPorEdad3anios" runat="server" edadCorte="corte3años" />
        </div>
        <div id="div4anios">
            <uc1:InformacionPorEdad ID="InformacionPorEdad4anios" runat="server" edadCorte="corte4años" />
        </div>
        <div id="div5anios">
            <uc1:InformacionPorEdad ID="InformacionPorEdad5anios" runat="server" edadCorte="corte5años" />
        </div>
        <div id="div6anios">
            <uc1:InformacionPorEdad ID="InformacionPorEdad6anios" runat="server" edadCorte="corte6años" />
        </div>
    </div>
</asp:Content>
