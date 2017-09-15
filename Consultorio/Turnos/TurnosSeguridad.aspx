<%@ Page Language="C#" MasterPageFile="~/mConsultorio.Master" AutoEventWireup="true" CodeBehind="TurnosSeguridad.aspx.cs" Inherits="Consultorio.Turnos.TurnosSeguridad" Title="Página sin título" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<%@ Register Assembly="Subsonic" Namespace="SubSonic" TagPrefix="subsonic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link href="../../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
    
  <link href="../Turnos.css" rel="stylesheet" type="text/css" />
  
    <link type="text/css" rel="stylesheet" href="../../js/jquery-ui-1.7.1.custom.css" />
  <script type="text/javascript" src="../../js/jquery.min.js"></script>
  <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">
  <ajx:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptLocalization="true" EnableScriptGlobalization="true" >
  </ajx:ToolkitScriptManager>
  
  <!-- capa externa !-->
  <div class="div_exterior" style="background-color:#FAFAFA; padding-bottom:0px;position:relative; ">
    <!-- barra derecha !-->
    <div class="div_derecho50" style="height:100%; width:49%; background:Silver;" >
      <asp:UpdatePanel ID="updfiltro" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>
          <asp:Panel ID="pnlIzquierdo" runat="server">
          
          
          </asp:Panel>    
        </ContentTemplate>
      </asp:UpdatePanel>
    </div>
    <!-- barra izquierda !-->
    <div class="div_derecho50" style="height:100%; width:49%; background:Navy;" >
      <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>
          <asp:Panel ID="pnlDerecho" runat="server">
          
          
          </asp:Panel>    
        </ContentTemplate>
      </asp:UpdatePanel>
    </div>
  </div>
</asp:Content>

