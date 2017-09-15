<%@ Page Title="" Language="C#" MasterPageFile="~/ControlMenor/MasterPages/ControlMenor.master"
    Theme="apr" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="SIPS.ControlMenor.CalendarioVacunacion.Edit" %>

<%@ MasterType VirtualPath="~/ControlMenor/MasterPages/ControlMenor.master" %>
<%@ Register Src="../UserControls/Medicamento.ascx" TagName="Medicamento" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="server">
    <table width="98%">
        <tr>
            <td>
                <asp:Label runat="server" ID="lFechaAplicacion" Text="Fecha Aplicacion" AssociatedControlID="txtFechaAplicacion"></asp:Label><br />
                <asp:TextBox runat="server" ID="txtFechaAplicacion" CssClass="fixedWidth"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" ID="lVacuna" Text="Vacuna"></asp:Label><br />
                <uc1:Medicamento ID="Medicamento1" runat="server" />
            </td>
            <td>
                <asp:Label runat="server" ID="lblDosis" Text="Seleccionar la Dosis"></asp:Label><br />
                <asp:DropDownList ID="ddlDosis" runat="server" DataValueField="idNumeroDosis" DataTextField="Nombre"
                    ToolTip="Seleccione la Dosis">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" ID="lObservacion" Text="Observaciones" AssociatedControlID="txtObservacion"></asp:Label><br />
                <asp:TextBox runat="server" ID="txtObservacion" TextMode="MultiLine" Rows="3" ToolTip="Ingresar la observación del Caso" Width="70%"></asp:TextBox>
            </td>
             <td>
             <asp:Label runat="server" ID="lblBaja" Text="Eliminar Vacuna Actual" AssociatedControlID="ckbBaja"></asp:Label><br />
                <asp:CheckBox ID="ckbBaja" runat="server" Text="" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="server">
    <asp:Button runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" />
    <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" />
</asp:Content>
