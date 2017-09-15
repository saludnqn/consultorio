<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Consultorio.ConsultaAmbulatoria.ControlPerinatal.Score.Default"
  MasterPageFile="~/ConsultaAmbulatoria/MasterPages/ConsultorioPerinatal.Master"
  Theme="apr" %>

<%@ MasterType VirtualPath="~/ConsultaAmbulatoria/MasterPages/ConsultorioPerinatal.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
.tab {
 width: 75%;
 border: solid 1px #6ea6d1;
}
.tabr{
border: solid 1px #6ea6d1;
}
.tabtot{
border: solid 1px #6ea6d1;
font-weight:bold;
text-align: right;
}

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="server">
  <b>Variables que determinan un Score de Riesgo de Bajo Peso al Nacer</b><br /><br />
  Seleccione una Fecha de Control: <asp:DropDownList ID="ddlFecha" 
    runat="server" ToolTip="Fechas de control disponible" AutoPostBack="true" 
    onselectedindexchanged="ddlFecha_SelectedIndexChanged"></asp:DropDownList><br /><br />
  <table class="tab">
    <tr style="font-weight:bold; border: solid 1px #6ea6d1;">
      <td style="width: 28%;">
       Variable/Puntos
      </td>
      <td style="width: 15%">
        <b>1</b>
      </td>
      <td style="width: 12%">
        <b>2</b>
      </td>
      <td style="width: 12%">
        <b>3</b>
      </td>
      <td style="width: 6%">
        <b>Total</b>
      </td>
    </tr>
    <tr class="tabr">
      <td>
        Edad Materna
      </td>
      <td>
        <asp:Label ID="lblA1" runat="server" Visible="False"> 17 a 19 o &gt;= 40</asp:Label>
      </td>
      <td>
        <asp:Label ID="lblA2" runat="server" Visible="False"> Menor de 17 anios </asp:Label>
      </td>
      <td>
        &nbsp;
      </td>
      <td>
        <asp:Label ID="lblA4" runat="server"></asp:Label>
      </td>
    </tr>
    <tr class="tabr">
      <td>
        Estado Civil
      </td>
      <td>
        <asp:Label ID="lblB1" runat="server" Visible="False">Soltera</asp:Label>
      </td>
      <td>
      &nbsp;
      </td>
      <td>
      &nbsp;
      </td>
      <td>
        <asp:Label ID="lblB4" runat="server"></asp:Label>
      </td>
    </tr>
    <tr class="tabr">
      <td>
        Antecedentes del BPN
      </td>
      <td>&nbsp;
      </td>
      <td>
        <asp:Label ID="lblC2" runat="server" Visible="False">Antec de un previo BPN</asp:Label>
      </td>
      <td>&nbsp;
      </td>
      <td>
        <asp:Label ID="lblC4" runat="server"></asp:Label>
      </td>
    </tr>
    <tr class="tabr">
      <td>
        Hábito de Fumar
      </td>
      <td>
        <asp:Label ID="lblD1" runat="server" Visible="false">Fumadora</asp:Label>
      </td>
      <td>&nbsp;
      </td>
      <td>&nbsp;
      </td>
      <td>
        <asp:Label ID="lblD4" runat="server"></asp:Label>
      </td>
    </tr>
    <tr>
      <td>
        IMC(Peso Anterior): <asp:Label ID="lblIMCPA" runat="server" ></asp:Label>
      </td>
      <td>
        <asp:Label ID="lblE1" runat="server" Visible="false">IMC &lt; 20</asp:Label>
      </td>
      <td>&nbsp;
      </td>
      <td>&nbsp;
      </td>
      <td>
        <asp:Label ID="lblE4" runat="server"></asp:Label>
      </td>
    </tr>
    <tr class="tabr">
      <td>
        Intervalo Intergenes
      </td>
      <td>
        <asp:Label ID="lblF1" runat="server" Visible="false">&lt; 18 meses</asp:Label>
      </td>
      <td>&nbsp;
      </td>
      <td>&nbsp;
      </td>
      <td>
        <asp:Label ID="lblF4" runat="server"></asp:Label>
      </td>
    </tr>
    <tr class="tabr">
      <td>
        Oportunidad de la Primera Visita
      </td>
      <td>&nbsp;
      </td>
      <td>
        <asp:Label ID="lblG2" runat="server" Visible="false">16 a 24 sem</asp:Label>
      </td>
      <td>
        <asp:Label ID="lblG3" runat="server" Visible="false">mayor 24 sem</asp:Label>
      </td>
      <td>
        <asp:Label ID="lblG4" runat="server"></asp:Label>
      </td>
    </tr>
    <tr class="tabr">
      <td>
        Pre-Eclampsia ó Eclampsia
      </td>
      <td>&nbsp;
      </td>
      <td>
        <asp:Label ID="lblH2" runat="server" Visible="false" >Si</asp:Label>
      </td>
      <td>&nbsp;
      </td>
      <td>
        <asp:Label ID="lblH4" runat="server"></asp:Label>
      </td>
    </tr>
    <tr class="tabr">
      <td>
        Sangre o Roturas de Membranas
      </td>
      <td>&nbsp;
      </td>
      <td>&nbsp;
      </td>
      <td>
        <asp:Label ID="lblI3" runat="server" Visible="false">Si</asp:Label>
      </td>
      <td>
        <asp:Label ID="lblI4" runat="server"></asp:Label>
      </td>
    </tr>
   <tr class="tabtot">
      <td colspan="4" align="right">
      <b>Puntuación:</b> &nbsp;&nbsp;&nbsp;
      </td>
      <td>
<asp:Label ID="lblTotal" runat="server"></asp:Label>
      </td>
    </tr>
  </table><br />
  Puntuación Obtenida a la Fecha Control seleccionada: <asp:Label ID="lblFecha" runat="server"></asp:Label><br />
  IMC a la Fecha Control: <asp:Label ID="lblIMCC" runat="server"></asp:Label>
  <div style="float: right; margin: -214px 50px; position:relative">
  Valores de Referencia<br />
  <table style="border: solid 1px #6ea6d1">
  <tr style="border: solid 1px #6ea6d1; font-weight:bold">
  <td style="border: solid 1px #6ea6d1">
  Puntos
  </td>
  <td style="border: solid 1px #6ea6d1">
  Score de Riesgo
  </td>
  </tr>
  <tr style="border: solid 1px #6ea6d1;">
  <td style="border: solid 1px #6ea6d1">
  0
  </td>
  <td style="border: solid 1px #6ea6d1">
  Sin Riesgo
  </td>
  </tr>
  <tr style="border: solid 1px #6ea6d1; background-color: Yellow">
  <td style="border: solid 1px #6ea6d1">
  1 a 3
  </td>
  <td style="border: solid 1px #6ea6d1">
  Bajo
  </td>
  </tr>
  <tr style="border: solid 1px #6ea6d1; background-color: #ffa500">
  <td style="border: solid 1px #6ea6d1">
  4 a 5 
  </td>
  <td style="border: solid 1px #6ea6d1">
  Moderado
  </td>
  </tr>
  <tr style="border: solid 1px #6ea6d1; background-color: Red; font-weight:bold">
  <td style="border: solid 1px #6ea6d1">
  >= 6
  </td>
  <td style="border: solid 1px #6ea6d1">
  Alto
  </td>
  </tr>  
  </table>
  </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="server">
</asp:Content>
