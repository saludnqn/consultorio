<%@ Page Title="" Language="C#" MasterPageFile="~/Global.Master" AutoEventWireup="true" CodeBehind="TurnosAuditoria.aspx.cs" Inherits="Consultorio.Turnos.TurnosAuditoria"  UICulture="es" Culture="es-AR"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<%@ Register Assembly="Subsonic" Namespace="SubSonic" TagPrefix="subsonic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link href="../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
  <link href="../Turnos.css" rel="stylesheet" type="text/css" />  
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">

  <ajx:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptLocalization="true" EnableScriptGlobalization="true" >
  </ajx:ToolkitScriptManager>
  
  <!-- capa externa !-->
  <div class="div_exterior" style="background-color:#FAFAFA; position:relative; ">
  
  
  </div>

</asp:Content>
