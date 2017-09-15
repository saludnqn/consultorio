<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ConsultaAmbulatoria/MasterPages/ConsultorioPerinatal.Master" CodeBehind="Default.aspx.cs" Inherits="ConsultaAmbulatoria.ControlPerinatal.AlturaUterina.Default" Theme="apr" %>

<%@ Register Assembly="NPlot" Namespace="NPlot.Web" TagPrefix="NPlot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="server">
<asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label><br />
<NPlot:PlotSurface2D ID="plotSurface" runat="server" Width="880px" Height="440px" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="server">
</asp:Content>