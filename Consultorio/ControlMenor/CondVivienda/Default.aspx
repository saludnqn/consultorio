<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SIPS.ControlMenor.CondVivienda.Default"
    MasterPageFile="~/ControlMenor/MasterPages/ControlMenor.master" Theme="apr" %>
    
<%@ MasterType VirtualPath="~/ControlMenor/MasterPages/ControlMenor.master" %>
<%-- Scripts y estilos en la cabecera --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%-- Contenido principal --%>
<asp:Content ID="Content3" ContentPlaceHolderID="Cuerpo" runat="server">
    <asp:ScriptManagerProxy runat="server" ID="smp">
        <Scripts>
            <asp:ScriptReference Path="~/js/tooltips/jquery.tools.min.js" />
        </Scripts>
    </asp:ScriptManagerProxy>
    <fieldset class="ui-widget ui-widget-content ui-corner-all">
        <legend>Condiciones de Vivienda</legend>
        <table class="formulario">
            <tr>
                <td>
                    Piso:
                    <asp:CheckBox ID="cblPisoT" runat="server" CssClass="rbList" Text="Tierra" />
                    <asp:CheckBox ID="cblPisoM" runat="server" CssClass="rbList" Text="Material" />
                </td>
                <td colspan="2">
                    Basura:
                    <asp:CheckBox ID="cblBasuraR" runat="server" CssClass="rbList" Text="Recolección" />
                    <asp:CheckBox ID="cblBasuraE" runat="server" CssClass="rbList" Text="Entierran" />
                    <asp:CheckBox ID="cblBasuraQ" runat="server" CssClass="rbList" Text="Queman" />
                    <asp:CheckBox ID="cblBasuraO" runat="server" CssClass="rbList" Text="Otra" />
                </td>
            </tr>
            <tr>
                <td colspan="3"><hr style="background-color: #87b6d9" />
                    Fuente de Combustión en el Hogar:
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cblRenglon1GN" runat="server" CssClass="rbList" Text="Gas Natural" />
                    <asp:CheckBox ID="cblRenglon1Ga" runat="server" CssClass="rbList" Text="Garrafa" />
                    <asp:CheckBox ID="cblRenglon1L" runat="server" CssClass="rbList" Text="Leña/Carbón" />
                </td>
                <td colspan="2">
                    <asp:CheckBox ID="cblRenglon2K" runat="server" CssClass="rbList" Text="Kerosén" />
                    <asp:CheckBox ID="cblRenglon2E" runat="server" CssClass="rbList" Text="Electricidad" />
                    <asp:CheckBox ID="cblRenglon2O" runat="server" CssClass="rbList" Text="Otro" />
                </td>
            </tr>
            <tr>
            <td colspan="3">
            <hr style="background-color: #87b6d9" />
            </td>
            </tr>
            <tr>
                <td>
                    Hogar:
                </td>
                <td>
                    Agua
                </td>
                <td>
                    Excretas
                </td>
            </tr>
            <tr>
                <td>
                <ul><li>
                    Conectado a la Red</li>
                    <li>No Conetado a la Red</li>
                    <li>Fuera del Hogar</li>
                 </ul>
                </td>
                <td>
                <div style=" width: 20px">
                    <asp:CheckBox ID="cblHogar0" runat="server" CssClass="rbList" />
                    <asp:CheckBox ID="cblHogar1" runat="server" CssClass="rbList" />
                    <asp:CheckBox ID="cblHogar2" runat="server" CssClass="rbList" />
                 </div>   
                </td>
                <td>
                    <div style="float: left; width: 20px">
                        <asp:CheckBox ID="cblHogar10" runat="server" CssClass="rbList" />
                        <asp:CheckBox ID="cblHogar11" runat="server" CssClass="rbList" />
                        <asp:CheckBox ID="cblHogar12" runat="server" CssClass="rbList" />
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="3"><hr style="background-color: #87b6d9" />
                    Presencia de Contaminantes:
                </td>
            </tr> 
            <tr>
                <td colspan="3">
                    <asp:CheckBox ID="cblContaminantesH" runat="server" CssClass="rbList" Text="Humo" />
                    <asp:CheckBox ID="cblContaminantesB" runat="server" CssClass="rbList" Text="Basurales" />
                    <asp:CheckBox ID="cblContaminantesA" runat="server" CssClass="rbList" Text="Agroquímicos" />
                    <asp:CheckBox ID="cblContaminantesV" runat="server" CssClass="rbList" Text="Vectores" />
                    <asp:CheckBox ID="cblContaminantesT" runat="server" CssClass="rbList" Text="Terrenos Inundados" />
                    <asp:CheckBox ID="cblContaminantesP" runat="server" CssClass="rbList" Text="Petroquímicos" />
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Botones" runat="server">
    <asp:Button runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" />
    <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" />
</asp:Content>
