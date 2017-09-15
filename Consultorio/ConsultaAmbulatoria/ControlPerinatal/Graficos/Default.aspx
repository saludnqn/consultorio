<%@ Page Title="" Language="C#" MasterPageFile="~/ConsultaAmbulatoria/MasterPages/ConsultorioPerinatal.Master"  Theme="apr"
AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ConsultaAmbulatoria.ControlPerinatal.Graficos.Default" %>
<%@ Register Assembly="NPlot" Namespace="NPlot.Web" TagPrefix="NPlot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="server">
<NPlot:PlotSurface2D ID="plotSurface" runat="server" Width="880px" Height="440px" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="server">
</asp:Content>
