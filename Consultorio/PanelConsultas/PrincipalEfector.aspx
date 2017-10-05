<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrincipalEfector.aspx.cs" Inherits="Consultorio.PanelConsultas.PrincipalEfector" MasterPageFile="~/mConsultorio.Master"   UICulture="es" Culture="es-AR"%>

<asp:Content ID="content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Turnos.css" rel="stylesheet" type="text/css" />  
  <link type="text/css" rel="stylesheet" href="../js/jquery-ui-1.7.1.custom.css" />
  <script type="text/javascript" src="../js/jquery.min.js"></script>
  <script type="text/javascript" src="../js/jquery-ui.min.js"></script>
  <script type="text/javascript" src="../js/jquery.ui.datepicker-es.js"></script>
</asp:Content>

<asp:Content ID="content2" ContentPlaceHolderID="cuerpo" runat="server">

    <br />
  <br />
<br />
   <div align="left"  style="left: 20px; top: 10px; margin-left: 20px; margin-top: 10px; width:100%" >

  <table width="700px" >
  
    <tr>
      <td class="mytituloPagina" colspan="2">
            Panel de Estadísticas</td>
    </tr>
    <tr>
      <td  colspan="2">
              &nbsp;</td>
    </tr>
    <tr>
    <td   rowspan="2"> <img src="../App_Themes/consultorio/images/indicador.gif"/>
    </td>
    <td  > <a  href= "ConsultasxEfector.aspx?tipo=Consultas"><b class="mySubTitulo">Pacientes Atendidos.</b></a>
    </td>
    </tr>
    
    
     <tr>
    <td >Cantidad de consultas por especialidad, profesional, discriminadas por grupos etáreos y por sexo.<hr />
    </td>
    </tr>
              
               
    
     <tr>
      <td  rowspan="3"><img src="../App_Themes/consultorio/images/indicador.gif"/></td>
    <td>&nbsp;</td>
    </tr>
              
    
    
     <tr>
    <td><a  href= "ReporteDiagnosticos.aspx"><b class="mySubTitulo">Motivo de Consulta/Diagnósticos.</b></a></td>
    </tr>
              
    
     <tr>
    <td>Cantidad de consultas discriminadas por motivo de consultas/diagnosticos (nomenclador Cie10)<hr /></td>
    </tr>
              
  
     <tr>
      <td class="style6" rowspan="3"><img src="../App_Themes/consultorio/images/indicador.gif"/></td>
    <td class="style5">&nbsp;</td>
    </tr>
              
    
     <tr>
    <td class="style5"><a  href= "ReporteC2.aspx"><b class="mySubTitulo">
        Reporte Diagnósticos C2.</b></a> <img src="../App_Themes/consultorio/images/new.png" /></td>
    </tr>
              
    
     <tr>
    <td class="style5">Cantidad de consultas con Diagnosticos C2.: De los diagnósticos del Cie10 se identificaron los que corresponden al C2. De estos,los que fueron notificados como Primera Vez en la carga del diagnostico en la consulta, forman parte de este reporte.    
    <hr /></td>
    </tr>
              
                 </table>
   
   </div>
</asp:Content>
