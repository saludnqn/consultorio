<%@ Page Title="" Language="C#" MasterPageFile="~/ControlMenor/MasterPages/ControlMenor.master"
    AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="SIPS.ControlMenor.Intervenciones.Edit" theme="apr"%>
<%@ MasterType VirtualPath="~/ControlMenor/MasterPages/ControlMenor.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cuerpo" runat="server">
    <table class="formulario">
        <tr>
            <td>
                <asp:Label runat="server" ID="lFecha" Text="Fecha" AssociatedControlID="txtFecha"></asp:Label><br />
                <asp:TextBox runat="server" ID="txtFecha" CssClass="fixedWidth"></asp:TextBox>
            </td>
            <td>
                <asp:Label runat="server" ID="lProfesional" Text="Profesional" AssociatedControlID="ddlProfesional"></asp:Label><br />
                <asp:DropDownList runat="server" ID="ddlProfesional" CssClass="fixedWidth"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" ID="lEspecialidad" Text="Especialidad" AssociatedControlID="ddlEspecialidad"></asp:Label><br />
                <asp:DropDownList runat="server" ID="ddlEspecialidad" CssClass="fixedWidth">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label runat="server" ID="lActividad" Text="Actividad" AssociatedControlID="ddlActividad"></asp:Label><br />
                <asp:DropDownList runat="server" ID="ddlActividad" CssClass="fixedWidth">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label runat="server" ID="lObservacion" Text="Observaciones" AssociatedControlID="txtObservacion"></asp:Label><br />
                <asp:TextBox runat="server" ID="txtObservacion" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Botones" runat="server">
    <asp:Button runat="server" ID="btnGuardar" Text="Guardar" onclick="btnGuardar_Click" />
   <input type="button" value="Volver" onclick="history.go(-1)">
</asp:Content>
