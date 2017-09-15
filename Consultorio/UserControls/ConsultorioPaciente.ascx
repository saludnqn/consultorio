<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConsultorioPaciente.ascx.cs" Inherits="UserControls.ConsultorioPaciente" %>
<table><tr>
<td style="vertical-align: top">
    <input id="HfidPaciente" type="hidden" runat="server" />
    <input id="HfDNI" type="hidden" runat="server" />
    <input id="HfidEfector" type="hidden" runat="server" />
     <input id="HfidTurno" type="hidden" runat="server" />

      <asp:Button ID="BtnDiagnosticosPaciente" runat="server" 
                                                        OnClientClick="VerDiagnosticos(); return false;" Text="Diagnósticos" Width="123px" />
        <asp:Button ID="BtnDatosControl" runat="server" 
                                                        OnClientClick="VerDatosControl(); return false;" Text="Historial D. Control" Width="123px" />
  
     </td>
    </tr>
    
    <tr>
<td style="vertical-align: top">
    &nbsp;</td>
    </tr>

    <tr>
<td style="vertical-align: top">
                                                    <asp:Button ID="BtnVerInter" runat="server" BackColor="#99CCFF" 
                                                        BorderColor="#CCCCCC" ForeColor="White" 
                                                        OnClientClick="VerInterconsulta(); return false;" Text="Ver Interconsultas" Width="123px" />
                                                    <asp:Button ID="BtnNvaInter" runat="server" BackColor="#99CCFF" 
                                                        BorderColor="#CCCCCC" ForeColor="White" 
                                                        OnClientClick="NuevaInterconsulta(); return false;" Text="Nueva Interconsulta" Width="123px" />
                                                    <asp:Button ID="BtnLabo" runat="server" BackColor="#99CCFF" 
                                                        BorderColor="#CCCCCC" ForeColor="White"
                                                        OnClientClick="Laboratorio(); return false;" Text="Ver Laboratorios" Width="123px" />

                                                         <asp:Button ID="BtnLaboHospital" runat="server" BackColor="#99CCFF" 
                                                        BorderColor="#CCCCCC" ForeColor="White" Visible="false"
                                                        OnClientClick="LaboratorioHospital(); return false;" Text="Ver Laboratorios" Width="123px" />
                                                    <asp:Button ID="BtnEventos" runat="server" BackColor="#99CCFF" 
                                                        BorderColor="#CCCCCC" ForeColor="White"
                                                        OnClientClick="Eventos(); return false;" Text="Eventos" Width="123px" />
     <asp:Button ID="BtnEventosHospital" runat="server" BackColor="#99CCFF" Visible="false"
                                                        BorderColor="#CCCCCC" ForeColor="White"
                                                        OnClientClick="EventosHospital(); return false;" Text="Eventos" Width="123px" />
                                                    <asp:Button ID="BtnControl" runat="server" BackColor="#99CCFF" 
                                                        BorderColor="#CCCCCC" ForeColor="White" 
                                                        OnClientClick="ControlPerinatal(); return false;" Text="Control Perinatal" 
                                                        Width="123px" />
  
                                                    <asp:Button ID="BtnNuevoVGI" runat="server" BackColor="#99CCFF" 
                                                        BorderColor="#CCCCCC" ForeColor="White"  Visible="false"
                                                        OnClientClick="NuevoVGI(); return false;" Text="Nueva VGI" Width="123px" />
  
                                                    <asp:Button ID="BtnAntecedentesFamiliares" runat="server" BackColor="#99CCFF" 
                                                        BorderColor="#CCCCCC" ForeColor="White"  Visible="true"
                                                        OnClientClick="AntecedentesFliares(); return false;" Text="Ant. Fliares" Width="123px" />
    </td>
    </tr>
    
    <tr>
<td style="vertical-align: top">
    &nbsp;</td>
    </tr>

<tr>
<td style="vertical-align: top">
    <asp:Panel ID="pnlPrestaciones" runat="server" >
        <fieldset  class="ui-widget ui-widget-content ui-corner-all" style="padding-top: 10px;
                                                        padding-bottom: 10px; padding-left: 10px; ">
                                                        <legend><b>Pedido Prestaciones</b></legend>
                 <asp:Button ID="BtnPedidoPAP" runat="server" BackColor="#CC3300" 
                                                        BorderColor="#CCCCCC" ForeColor="White" 
                                                        OnClientClick="PedidoPAPHPV(); return false;" Text=" PAP/HPV" Width="123px" Visible="False" />
                                                        <br />
            <br />

                 <asp:Button ID="BtnMamas" runat="server" BackColor="#CC3300" 
                                                        BorderColor="#CCCCCC" ForeColor="White" 
                                                        OnClientClick="PedidoMamas(); return false;" Text="Mamografia" Width="123px" Visible="False" />

        </fieldset>
         </asp:Panel>                                           
                                               
    </td>
    </tr>
    
<tr>
<td style="vertical-align: top">
                                               
    </td>
    </tr>

</table> 

 <script language="javascript" type="text/javascript">
     var IdPaciente = $("#<%= HfidPaciente.ClientID %>").val();
     var dni = $("#<%= HfDNI.ClientID %>").val();
     var IdEfector = $("#<%= HfidEfector.ClientID %>").val();
     var IdTurno = $("#<%= HfidTurno.ClientID %>").val();

     function ControlPerinatal() {


         var dom = document.domain;
         var domArray = dom.split('.');
         for (var i = domArray.length - 1; i >= 0; i--) {
             try {
                 var dom = '';
                 for (var j = domArray.length - 1; j >= i; j--) {
                     dom = (j == domArray.length - 1) ? (domArray[j]) : domArray[j] + '.' + dom;
                 }
                 document.domain = dom;
                 break;
             } catch (E) {
             }
         }


         var $this = $(this);
         $('<iframe src="../../ConsultaAmbulatoria/ControlPerinatal/Control/Default.aspx?idPaciente=' + IdPaciente + '" />').dialog({
             title: 'Control Perinatal',
             autoOpen: true,
             width: 1000,
             height: 800,
             modal: true,
             resizable: false,
             autoResize: true,
             overlay: {
                 opacity: 0.5,
                 background: "black"
             }
         }).width(1000);
     }


     function Laboratorio() {


         var dom = document.domain;
         var domArray = dom.split('.');
         for (var i = domArray.length - 1; i >= 0; i--) {
             try {
                 var dom = '';
                 for (var j = domArray.length - 1; j >= i; j--) {
                     dom = (j == domArray.length - 1) ? (domArray[j]) : domArray[j] + '.' + dom;
                 }
                 document.domain = dom;
                 break;
             } catch (E) {
             }
         }


         var $this = $(this);
         $('<iframe src="../../Laboratorio/Resultados/ProtocoloList.aspx?id=' + dni + '" />').dialog({
             title: 'Laboratorios',
             autoOpen: true,
             width: 1000,
             height: 800,
             modal: true,
             resizable: false,
             autoResize: true,
             overlay: {
                 opacity: 0.5,
                 background: "black"
             }
         }).width(1000);
     }
    
     function AntecedentesFliares() {


         var dom = document.domain;
         var domArray = dom.split('.');
         for (var i = domArray.length - 1; i >= 0; i--) {
             try {
                 var dom = '';
                 for (var j = domArray.length - 1; j >= i; j--) {
                     dom = (j == domArray.length - 1) ? (domArray[j]) : domArray[j] + '.' + dom;
                 }
                 document.domain = dom;
                 break;
             } catch (E) {
             }
         }


         var $this = $(this);
         $('<iframe src="../../Paciente/Antecedente/AntecedentesFamiliares.aspx?idPaciente=' + IdPaciente + '" />').dialog({
             title: 'Antecedentes Familiares',
             autoOpen: true,
             width: 800,
             height: 700,
             modal: true,
             resizable: false,
             autoResize: true,
             overlay: {
                 opacity: 0.5,
                 background: "black"
             }
         }).width(1000);
     }

     function LaboratorioHospital() {


         var dom = document.domain;
         var domArray = dom.split('.');
         for (var i = domArray.length - 1; i >= 0; i--) {
             try {
                 var dom = '';
                 for (var j = domArray.length - 1; j >= i; j--) {
                     dom = (j == domArray.length - 1) ? (domArray[j]) : domArray[j] + '.' + dom;
                 }
                 document.domain = dom;
                 break;
             } catch (E) {
             }
         }


         var $this = $(this);


         $('<iframe src="../../../laboratorio/Resultados/Procesa.aspx?idServicio=0&ModoCarga=LP&Operacion=HC&Parametros=P.idPaciente=' + IdPaciente + '&idArea=0&idHojaTrabajo=0&validado=1&modo=Normal&Tipo=PacienteValidado" />').dialog({
             title: 'Laboratorios',
             autoOpen: true,
             width: 1090,
             height: 800,
             modal: true,
             resizable: false,
             autoResize: true,
             overlay: {
                 opacity: 0.5,
                 background: "black"
             }
         }).width(1100);
     }

     function VerInterconsulta() {

         var dom = document.domain;
         var domArray = dom.split('.');
         for (var i = domArray.length - 1; i >= 0; i--) {
             try {
                 var dom = '';
                 for (var j = domArray.length - 1; j >= i; j--) {
                     dom = (j == domArray.length - 1) ? (domArray[j]) : domArray[j] + '.' + dom;
                 }
                 document.domain = dom;
                 break;
             } catch (E) {
             }
         }


         var $this = $(this);
         $('<iframe src="../../Interconsultas1/ListadoDeInterconsultas.aspx?IdPaciente=' + IdPaciente + '" />').dialog({
             title: 'Ver Interconsultas',
             autoOpen: true,
             width: 1000,
             height: 800,
             modal: true,
             resizable: false,
             autoResize: true,
             overlay: {
                 opacity: 0.5,
                 background: "black"
             }
         }).width(1000);
     }

     function NuevaInterconsulta() {

         var dom = document.domain;
         var domArray = dom.split('.');
         for (var i = domArray.length - 1; i >= 0; i--) {
             try {
                 var dom = '';
                 for (var j = domArray.length - 1; j >= i; j--) {
                     dom = (j == domArray.length - 1) ? (domArray[j]) : domArray[j] + '.' + dom;
                 }
                 document.domain = dom;
                 break;
             } catch (E) {
             }
         }


         var $this = $(this);
         $('<iframe src="../../Interconsultas1/InterconsultasEdit.aspx?IdPaciente=' + IdPaciente + '&idInterconsulta=0" />').dialog({
             title: 'Nueva Interconsulta',
             autoOpen: true,
             width: 1000,
             height: 800,
             modal: true,
             resizable: false,
             autoResize: true,
             overlay: {
                 opacity: 0.5,
                 background: "black"
             }
         }).width(1000);
     }


     function Eventos() {
         var dom = document.domain;
         var domArray = dom.split('.');
         for (var i = domArray.length - 1; i >= 0; i--) {
             try {
                 var dom = '';
                 for (var j = domArray.length - 1; j >= i; j--) {
                     dom = (j == domArray.length - 1) ? (domArray[j]) : domArray[j] + '.' + dom;
                 }
                 document.domain = dom;
                 break;
             } catch (E) {
             }
         }


         var $this = $(this);
         $('<iframe src="http://www.saludnqn.gob.ar/Eventos/Consultas.aspx?Id=' + dni + '" />').dialog({
             title: 'Eventos del Paciente',
             autoOpen: true,
             width: 1000,
             height: 800,
             modal: true,
             resizable: false,
             autoResize: true,
             overlay: {
                 opacity: 0.5,
                 background: "black"
             }
         }).width(1000);
     }

     function EventosHospital() {
         var dom = document.domain;
         var domArray = dom.split('.');
         for (var i = domArray.length - 1; i >= 0; i--) {
             try {
                 var dom = '';
                 for (var j = domArray.length - 1; j >= i; j--) {
                     dom = (j == domArray.length - 1) ? (domArray[j]) : domArray[j] + '.' + dom;
                 }
                 document.domain = dom;
                 break;
             } catch (E) {
             }
         }


         var $this = $(this);
         $('<iframe src="../../../Eventos/Consultas.aspx?Id=' + dni + '" />').dialog({
             title: 'Eventos del Paciente',
             autoOpen: true,
             width: 1000,
             height: 800,
             modal: true,
             resizable: false,
             autoResize: true,
             overlay: {
                 opacity: 0.5,
                 background: "black"
             }
         }).width(1000);
     }

  
     function PedidoPAPHPV() {
         var dom = document.domain;
         var domArray = dom.split('.');
         for (var i = domArray.length - 1; i >= 0; i--) {
             try {
                 var dom = '';
                 for (var j = domArray.length - 1; j >= i; j--) {
                     dom = (j == domArray.length - 1) ? (domArray[j]) : domArray[j] + '.' + dom;
                 }
                 document.domain = dom;
                 break;
             } catch (E) {
             }
         }


         var $this = $(this);
       
         $('<iframe src= "../../..//Tamizaje/Default.aspx?dni=' + dni + '&idEfector=' + IdEfector + '" />').dialog({
             title: 'Pedido PAP y HPV',
             autoOpen: true,
             width: 1000,
             height: 800,
             modal: true,
             resizable: false,
             autoResize: true,
             overlay: {
                 opacity: 0.5,
                 background: "black"
             }
         }).width(1000);
     }


     function PedidoMamas() {
         var dom = document.domain;
         var domArray = dom.split('.');
         for (var i = domArray.length - 1; i >= 0; i--) {
             try {
                 var dom = '';
                 for (var j = domArray.length - 1; j >= i; j--) {
                     dom = (j == domArray.length - 1) ? (domArray[j]) : domArray[j] + '.' + dom;
                 }
                 document.domain = dom;
                 break;
             } catch (E) {
             }
         }


         var $this = $(this);

         $('<iframe src= "../../../Mamas/Default.aspx?dni=' + dni + '" />').dialog({
             title: 'Pedido PAP y HPV',
             autoOpen: true,
             width: 1000,
             height: 800,
             modal: true,
             resizable: false,
             autoResize: true,
             overlay: {
                 opacity: 0.5,
                 background: "black"
             }
         }).width(1000);
     }


     function VerDatosControl() {

         var dom = document.domain;
         var domArray = dom.split('.');
         for (var i = domArray.length - 1; i >= 0; i--) {
             try {
                 var dom = '';
                 for (var j = domArray.length - 1; j >= i; j--) {
                     dom = (j == domArray.length - 1) ? (domArray[j]) : domArray[j] + '.' + dom;
                 }
                 document.domain = dom;
                 break;
             } catch (E) {
             }
         }


         var $this = $(this);
         $('<iframe src="../ConsultorioMedico/DatosControl.aspx?IdPaciente=' + IdPaciente + '" />').dialog({
             title: 'Historial Datos Control',
             autoOpen: true,
             width: 700,
             height: 300,
             modal: true,
             resizable: false,
             autoResize: true,
             overlay: {
                 opacity: 0.5,
                 background: "black"
             }
         }).width(720);
     }

     function VerDiagnosticos() {

         var dom = document.domain;
         var domArray = dom.split('.');
         for (var i = domArray.length - 1; i >= 0; i--) {
             try {
                 var dom = '';
                 for (var j = domArray.length - 1; j >= i; j--) {
                     dom = (j == domArray.length - 1) ? (domArray[j]) : domArray[j] + '.' + dom;
                 }
                 document.domain = dom;
                 break;
             } catch (E) {
             }
         }


         var $this = $(this);
         $('<iframe src="../ConsultorioMedico/TopDiagnosticos.aspx?IdPaciente=' + IdPaciente + '" />').dialog({
             title: 'Diagnosticos del Paciente',
             autoOpen: true,
             width: 650,
             height: 300,
             modal: true,
             resizable: false,
             autoResize: true,
             overlay: {
                 opacity: 0.5,
                 background: "black"
             }
         }).width(650);
     }

     function NuevoVGI() {

         var dom = document.domain;
         var domArray = dom.split('.');
         for (var i = domArray.length - 1; i >= 0; i--) {
             try {
                 var dom = '';
                 for (var j = domArray.length - 1; j >= i; j--) {
                     dom = (j == domArray.length - 1) ? (domArray[j]) : domArray[j] + '.' + dom;
                 }
                 document.domain = dom;
                 break;
             } catch (E) {
             }
         }

         var $this = $(this);
         $('<iframe src="../../../VGI/vgiedit.aspx?IdPaciente=' + IdPaciente + '&idTurno=' + IdTurno + '" />').dialog({
             title: 'Nueva Valoración Geriátrica Integral',
             autoOpen: true,
             width: 800,
             height: 600,
             modal: true,
             resizable: false,
             autoResize: true,
             overlay: {
                 opacity: 0.5,
                 background: "black"
             }
         }).width(790);
     }
</script>