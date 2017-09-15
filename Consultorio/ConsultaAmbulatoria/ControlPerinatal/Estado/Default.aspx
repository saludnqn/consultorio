<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Theme="apr" Inherits="Consultorio.ConsultaAmbulatoria.ControlPerinatal.Estado.Default" MasterPageFile="~/ConsultaAmbulatoria/MasterPages/ConsultorioPerinatal.Master" %>

<%@ MasterType VirtualPath="~/ConsultaAmbulatoria/MasterPages/ConsultorioPerinatal.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="server">
<div>
Estado Actual de la Historia Clínica Perinatal<br />
Seleccionar el Estado: <asp:RadioButtonList ID="rblEstado" runat="server">
    <asp:ListItem Value="1">Abierta</asp:ListItem>
    <asp:ListItem Value="0">Cerrada</asp:ListItem>
    </asp:RadioButtonList><br />
<hr />
Describa el Motivo por el cual se cambia el estado de la Historia Clinica Perinatal<br />
<asp:TextBox ID="txtObservaciones" runat="server" Width="95%" TextMode="MultiLine"></asp:TextBox>    <br />
<asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="server">
    <asp:Button runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" />
    <input type="button" value="Volver" onclick="history.go(-1)" />
</asp:Content>