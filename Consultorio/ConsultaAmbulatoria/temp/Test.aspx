<%@ Page Title="" Language="C#" MasterPageFile="~/ConsultaAmbulatoria/MasterPages/Consultorio.master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="ConsultaAmbulatoria.temp.Test" %>
<%@ Register src="../UserControls/DiagCIE10.ascx" tagname="DiagCIE10" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="server">
    <uc1:DiagCIE10 ID="DiagCIE101" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="server">
</asp:Content>
