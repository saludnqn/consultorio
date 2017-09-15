<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ConsultaAmbulatoria/MasterPages/ConsultorioPerinatal.master" CodeBehind="EditarControl.aspx.cs" Inherits="Consultorio.ConsultaAmbulatoria.ControlPerinatal.Control.EditarControl" Theme="apr" %>

<%@ MasterType VirtualPath="~/ConsultaAmbulatoria/MasterPages/ConsultorioPerinatal.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" type="text/css" href="../css/cperinatal.css" />
    <link rel="Stylesheet" type="text/css" href="../css/cperinatalextra.css" />
    <link rel="Stylesheet" type="text/css" href="../css/cperinataldetalles.css" />
    <link rel="Stylesheet" type="text/css" href="../css/alertBox.css" />  
    <%--<script type="text/javascript" src="../js/date.js"></script>
    <script type="text/javascript" src="../js/date-es-AR.js"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="server">
<%-- <div class="alertBox">
        <div class="ui-state-highlight ui-corner-all" style="padding: 5px; min-width: 180px;">
            <div class="ui-state-error ui-corner-all alertBoxTitle" style="padding: 5px; width: 95%;">
                Alertas</div>
            <ul id="ulAlert">
            </ul>
        </div>
    </div>--%>
  <asp:HiddenField runat="server" ID="hfPrimerControl" />
    <div id="divControl">
      <div id="sipDetallesContainer">
       <div class="sipDetalles">
                <asp:TextBox runat="server" ID="txtDetalleFecha" CssClass="txtDetalleFecha txtDetalle datepicker22"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetalleEdadGestacional" CssClass="txtDetalleEdadGestacional txtDetalle"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetallePeso" CssClass="validate[custom[number],min[40],max[200]] txtDetallePeso txtDetalle" ToolTip="Ingrese un valor con Coma decimal"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetallePresionArterialSistolica" CssClass="validate[custom[number],min[0],max[200]] txtDetallePresionArterialSistolica txtDetalle"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetallePresionArterialDistolica" CssClass="validate[custom[number],min[0],max[130]] txtDetallePresionArterialDistolica txtDetalle"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetalleAlturaUterina" CssClass="validate[custom[number],min[0],max[44]] txtDetalleAlturaUterina txtDetalle"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetallePresentacion" CssClass="txtDetallePresentacion txtDetalle"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetalleFrecuenciaCardiacaFetal" CssClass="validate[custom[number],min[0],max[200]] txtDetalleFrecuenciaCardiacaFetal txtDetalle"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetalleMovimientosFetales" CssClass="txtDetalleMovimientosFetales txtDetalle"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetalleProteinuria" CssClass="txtDetalleProteinuria txtDetalle"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetalleAlarmaExamenesTratamientos" CssClass="txtDetalleAlarmaExamenesTratamientos txtDetalle"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetallesInicialesTecnico" CssClass="txtDetalleInicialesTecnico txtDetalle"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetalleProximaCita" CssClass="txtDetalleProximaCita txtDetalle datepicker22"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetalleIMC" CssClass="txtDetalleIMC txtDetalle" ToolTip="Ingrese un valor con Coma decimal"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetalleObservaciones" CssClass="txtDetalleObservaciones txtDetalle"></asp:TextBox>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="server">
    <asp:Button runat="server" ID="btnEliminar" Text="Eliminar el Control" OnClick="btnEliminar_Click"
        ToolTip="Eliminar el control actual"  CssClass="btn btn-md"/>
    &nbsp;&nbsp;&nbsp;
    <asp:Button runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click"
        ToolTip="Guardar Control." CssClass="btn btn-md"/>
    &nbsp;&nbsp;&nbsp;
    <input type="button" value="Cerrar Ventana actual" onclick="window.close()" Class="btn btn-md"/>
</asp:Content>

