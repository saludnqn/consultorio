<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConsultaAmbulatoria.ascx.cs"
    Inherits="Consultorio.ConsultaAmbulatoria.UserControls.ConsultaAmbulatoria" %>
<%@ Register Src="~/ConsultaAmbulatoria/UserControls/DiagnosticoPrincipal.ascx" TagName="DiagnosticoPrincipal"
    TagPrefix="uc1" %>
<%@ Register Src="~/ConsultaAmbulatoria/UserControls/DiagnosticoSecundario.ascx"
    TagName="DiagnosticoSecundario" TagPrefix="uc2" %>
<%--<%@ Register Src="~/ConsultaAmbulatoria/UserControls/Medicamento.ascx" TagName="Medicamento"
    TagPrefix="uc4" %>--%>
<table class="formulario">
    <tr>
        <td>
            <asp:Label runat="server" ID="lblFecha" AssociatedControlID="txtFechaConsulta" Text="Fecha:"></asp:Label>
            <asp:TextBox runat="server" ID="txtFechaConsulta" Columns="12"></asp:TextBox>
        </td>
        <td>
            <asp:Label runat="server" ID="lblHora" AssociatedControlID="txtHoraConsulta" Text="Hora:"></asp:Label><asp:TextBox
                runat="server" ID="txtHoraConsulta" Columns="12"></asp:TextBox>
        </td>
        <td>
            <asp:Label runat="server" ID="lblMedico" AssociatedControlID="ddlMedico" Text="Medico:"></asp:Label>
            <asp:DropDownList runat="server" ID="ddlMedico" >
            </asp:DropDownList>
        </td>
        <td>
            <asp:Label runat="server" ID="lblEspecialidad" AssociatedControlID="ddlEspecialidad"
                Text="Especialidad:"></asp:Label>
            <asp:DropDownList runat="server" ID="ddlEspecialidad">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
    <td colspan="4">&nbsp;
    </td>
    </tr>
    <tr>
    <td colspan="2" runat="server" id="trPrimerConsulta" visible="false">
        <asp:Label runat="server" ID="lblPrimerConsulta" Text="Es Primer Consulta?" AssociatedControlID="ddlPrimerConsulta"></asp:Label><asp:DropDownList runat="server" ID="ddlPrimerConsulta" Width="120px">
                <asp:ListItem Text="Seleccionar" Value="" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Sin Especificar" Value="0"></asp:ListItem>
                <asp:ListItem Text="NO" Value="1"></asp:ListItem>
                <asp:ListItem Text="SI" Value="2"></asp:ListItem>                
            </asp:DropDownList>
    </td>
    <td colspan="2">
    <asp:Label runat="server" ID="lblTPrestacion" AssociatedControlID="ddlTPrestacion" Text="Tipo Prestación:"></asp:Label>
            <asp:DropDownList runat="server" ID="ddlTPrestacion" DataValueField="idTipoPrestacion" DataTextField="nombre">
            </asp:DropDownList>
    </td>
    </tr>
</table>
<br />
<table class="formulario">
    <tr>
        <td>
            <fieldset class="ui-widget ui-widget-content ui-corner-all">
                <legend>Diagnostico Principal</legend>
                <uc1:DiagnosticoPrincipal ID="DiagnosticoPrincipal1" runat="server" />
            </fieldset>
        </td>
    </tr>
    <tr>
        <td>
            <fieldset class="ui-widget ui-widget-content ui-corner-all">
                <legend>Diagnostico/s Secundario/s</legend>
                <uc2:DiagnosticoSecundario ID="DiagnosticoSecundario1" runat="server" />
            </fieldset>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label runat="server" ID="lblMotivo" AssociatedControlID="txtMotivo" Text="Motivo:"></asp:Label>
            <asp:TextBox runat="server" ID="txtMotivo" TextMode="MultiLine" Width="100%" Rows="3"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label runat="server" ID="lblInforme" AssociatedControlID="txtInforme" Text="Informe:"></asp:Label>
            <asp:TextBox runat="server" ID="txtInforme" TextMode="MultiLine" Width="100%" Rows="5"></asp:TextBox>
        </td>
    </tr>
    
<%--    <tr>
        <td>
            <fieldset class="ui-widget ui-widget-content ui-corner-all">
                <legend>Medicamentos</legend>
                <uc4:Medicamento ID="Medicamento1" runat="server" />
            </fieldset>
        </td>
    </tr>--%>
</table>
