<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteDiagnosticos.aspx.cs" Inherits="Consultorio.PanelConsultas.ReporteDiagnosticos" MasterPageFile="~/mConsultorio.Master"   UICulture="es" Culture="es-AR"%>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register Assembly="Subsonic" Namespace="SubSonic" TagPrefix="subsonic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Turnos.css" rel="stylesheet" type="text/css" />
  <link href="../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
  <link type="text/css" rel="stylesheet" href="../js/jquery-ui-1.7.1.custom.css" />
  <script type="text/javascript" src="../js/jquery.min.js"></script>
  <script type="text/javascript" src="../js/jquery-ui.min.js"></script>
  <script type="text/javascript" src="../js/jquery.ui.datepicker-es.js"></script>   
  
  <script src="../js/jquery-1.8.2.js" type="text/javascript"></script>
  <script src="../js/jquery-ui.js" type="text/javascript"></script>

  <script type="text/javascript">       

	$(function() {
		$("#<%=txtDesde.ClientID %>").datepicker({
		    showOn: 'button',
		    dateFormat: 'dd/mm/yy',
			buttonImage: '../App_Themes/consultorio/images/calend1.jpg',
			buttonImageOnly: true
		});
	});

	$(function() {
		$("#<%=txtHasta.ClientID %>").datepicker({
		    showOn: 'button',
		    dateFormat: 'dd/mm/yy',
			buttonImage: '../App_Themes/consultorio/images/calend1.jpg',
			buttonImageOnly: true
		});
	}); 
     
  </script>      
  
   
  
    
  
   
  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">
    <br />  &nbsp;    <br />

 <br />  &nbsp;    <br />

     <div class="div_exterior" >    
   
        <div style="width:1000px;  ">  
        
<table   width="100%">
  <tr>                    
                  <td  align="left" class="style18">
                      &nbsp;</td>
                    
                  <td class="myLink" align="left" colspan="3">
                      <asp:LinkButton ID="lnkRegresar" runat="server" onclick="lnkRegresar_Click" >Regresar</asp:LinkButton>
                   </td>
                    
                  <td align="right" colspan="3" style="font-size: 10pt;	font-family: Arial, Helvetica, sans-serif; 
	color: #287ED5;
	font-weight: normal;">
                      &nbsp;</td>
                    
</tr>
                    
  <tr>                    
                  <td  align="left" class="style18">
                      &nbsp;</td>
                    
                  <td class="mytituloPagina" align="left" colspan="3">
                      &nbsp;</td>
                    
                  <td align="right" colspan="3" style="font-size: 10pt;	font-family: Arial, Helvetica, sans-serif; 
	color: #287ED5;
	font-weight: normal;">
                      &nbsp;</td>
                    
</tr>
                    
  <tr>                    
                  <td  align="left" class="style18">
                      &nbsp;</td>
                    
                  <td class="mytituloPagina" align="left" colspan="3">
                   Reporte por Diagnósticos</asp:Label>   
                   </td>
                    
                  <td align="right" colspan="3" style="font-size: 10pt;	font-family: Arial, Helvetica, sans-serif; 
	color: #287ED5;
	font-weight: normal;">
                      &nbsp;</td>
                    
</tr>
                    
  <tr>                    
                  <td  align="left" class="style18">
                      &nbsp;</td>
                    
                  <td class="mytituloPagina" align="left" colspan="6">
                      <hr/></td>
                    
</tr>
                  <asp:Panel ID="pnlServicio" runat="server" Visible=true>
                      <tr>
                    
                    <td align="right" class="style2" >
                        &nbsp;</td>
                    
                    
                    <td align="right" class="myLabelIzquierda" >
                Servicio:
                    </td>
                    
                    
                    <td  align="left" colspan="5">
                 <asp:DropDownList ID="ddlServicios" runat="server" >
                                </asp:DropDownList>
                    </td>
 
                    </tr>
                    </asp:Panel>  
                    
                          <asp:Panel ID="pnlEfector" runat="server" Visible=false>
                     <tr>
                           
                            <td align="right" class="style18">
                                &nbsp;</td>
                           
                            <td align="right" class="myLabelIzquierda">
                               Efector:</td>
                            <td align="left" colspan="5" >
                         <asp:DropDownList ID="ddlZona" runat="server" AutoPostBack="True"     onselectedindexchanged="ddlZona_SelectedIndexChanged">
                      </asp:DropDownList>
                    <asp:DropDownList ID="ddlEfector" runat="server">
                      </asp:DropDownList>
                            </td>
                      
                        </tr>
                    </asp:Panel>
                    
                        <tr>
                           
                            <td align="right" class="style18">
                                &nbsp;</td>
                           
                            <td align="right" class="myLabelIzquierda">
                                Especialidad/Prestación:</td>
                            <td align="left" class="style24" >
                         <asp:DropDownList ID="ddlTipoTurno" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlTipoTurno_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="0">Todas</asp:ListItem>
                                    <asp:ListItem>Especialidad</asp:ListItem>
                                    <asp:ListItem>Prestaciones</asp:ListItem>
                                </asp:DropDownList>
                             <asp:DropDownList ID="ddlEspecialidad" runat="server" Width="200PX">
                      </asp:DropDownList>
                            </td>
                            <asp:Panel ID="pnlFiltroProfesional" runat=server Visible=true> 
                                    
                             
                             <td align="right" class="myLabelIzquierda" colspan="2">
                                Profesional:</td>
                                 <td align="left" >  <asp:DropDownList ID="ddlProfesional" runat="server"   Width="200PX">
                                        </asp:DropDownList>   </td>
                                        </asp:Panel>
                        </tr>
                    
                    
                    <tr>
                    <td align="right" class="style18">&nbsp;</td>
                    
                    
                    
                    <td align="right" class="myLabelIzquierda">Fecha desde:</td>
                    
                    
                    
                   <td align="left" class="style24"><asp:TextBox ID="txtDesde" runat="server"  Width="70px" ></asp:TextBox>
                    
                  </td>
                    
                    
                    
                   <td align="right" class="myLabelIzquierda" colspan="2" >Fecha hasta:</td>
                    <td align="left" class="style6">
                      <asp:TextBox ID="txtHasta" runat="server" Width="70px"></asp:TextBox>
                  
               </td>
               
                      
                      <td align="right" class="style7">   
                     </td>
                    </tr>
                    
                  
                    <tr>
                    <td align="right" class="style18">&nbsp;</td>
                    
                    
                    
                    <td align="right" class="myLabelIzquierda">Tipo de Diagnóstico: 
                            </td>
                    
                    
                    
                   <td align="left" class="style24">
                            
                            
                              <asp:DropDownList runat="server" ID="ddlTipoDiagnostico" >
                                  <asp:ListItem Selected="True" Value="-1">Todos</asp:ListItem>
                                  <asp:ListItem Value="1">Principal</asp:ListItem>
                                  <asp:ListItem Value="0">Secundario</asp:ListItem>
                                </asp:DropDownList>
                  
                  </td>
                    
                    
                    
                   <td align="right" class="myLabelIzquierda" colspan="2" >&nbsp;</td>
                    <td align="left" class="style6">
                            
                              &nbsp;</td>
               
                      
                      <td align="right" class="style7">   
                          &nbsp;</td>
                    </tr>
                    
                  
                      <tr>
                      
                      <td align="right" class="style18">&nbsp;</td>
                            
                      <td align="right" class="myLabelIzquierda" colspan="1"></td>
                            
                            <td class="style25" align="left">
                            
                        <%--        <asp:DropDownList ID="ddlNotificacion" runat="server">
                                    <asp:ListItem Selected="True" Value="-1">Todos</asp:ListItem>
                                    <asp:ListItem Value="1">Primera Vez</asp:ListItem>
                                    <asp:ListItem Value="2">Ulterior</asp:ListItem>
                                    <asp:ListItem Value="3">C2</asp:ListItem>                                     
                                    <asp:ListItem Value="0">No informado</asp:ListItem>
                                </asp:DropDownList>--%>
                            
                                </td>
                            
                            <td class="style10" align="left">
                            
                            
                                &nbsp;</td>
                            
                            <td class="myLabelIzquierda" colspan="2" align="left">
                            
                            
                               </td></td>
                            
                            <td class="style11" colspan="1">
                            <asp:Button ID="btnActualizar" runat="server" Width="120px" CssClass="myButton" 
                                    onclick="btnActualizar_Click" 
                                    Text="VER REPORTE" />
                            </td>
                            </tr>
                        
                       <tr>
                            <td class="style18">
                            </td>
                            <td class="myLabelIzquierda" colspan="6"><hr />
                            </td>
                            </tr>
                        
                  
                        
                        <tr>
                            <td align="left" class="style22">
                                &nbsp;</td>
                            <td align="left"  colspan="6">
                            <div style="width: 100%; height: 800px; overflow: scroll">
                                <asp:GridView ID="gvLista" runat="server" 
                              Width="100%" 
                                    
                                    
                                    
                                    
                                    EmptyDataText="No se encontraron datos para los filtros de busqueda ingresados." Font-Bold="True" 
                                    Font-Names="Calibri" Font-Size="10pt" ShowFooter="True" 
                                    onrowdatabound="gvLista_RowDataBound" Caption="Grupos Etáreos" 
                                    CaptionAlign="Top" CellPadding="2" BorderColor="#333333" 
                                    BorderStyle="Solid" BorderWidth="1px">
                                    <FooterStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="Black" />
                                    <RowStyle BorderColor="#333333" BorderStyle="Solid" BorderWidth="1px" />
                                    <HeaderStyle BackColor="#CCCCCC" />
                              
                           
                          
                            </asp:GridView>
                            </div></td>
                        </tr>
                    
                  
                        
                        <tr>
                            <td align="left" class="style22">
                                &nbsp;</td>
                            <td align="left"  colspan="3">
                                 <img src="../App_Themes/consultorio/images/pdf.jpg" /> 
                                <asp:LinkButton ID="lnkPdf" runat="server" CssClass="myLink" 
                                    onclick="lnkPdf_Click">Exportar a Pdf</asp:LinkButton>
                                <br />
                               <img src="../App_Themes/consultorio/images/excelPeq.gif" /> 
                                <asp:LinkButton ID="lnkExcel" runat="server" CssClass="myLink" 
                                    onclick="lnkExcel_Click">Exportar a Excel</asp:LinkButton></td>
                            <td align="right"  colspan="3">
                            <asp:Panel ID="pnlReporteDetallado" runat="server" Visible="false">
                               <b class="myLabelRojo">Reporte Detallado por Paciente</b>
                                <br />
                                <asp:ImageButton ID="imgDetalladoPdf" runat="server" 
                                    ImageUrl="../App_Themes/consultorio/images/pdf.jpg" 
                                    onclick="imgDetalladoPdf_Click" />
                               
                                <asp:LinkButton ID="lnkPdf0" runat="server" CssClass="myLink" 
                                    onclick="lnkPdf0_Click">Descargar formato Pdf</asp:LinkButton>
                                <br />
                                <asp:ImageButton ID="imgDetalladoExcel" runat="server" 
                                    ImageUrl="../App_Themes/consultorio/images/excelPeq.gif" 
                                    onclick="imgDetalladoExcel_Click" />
                               
                                <asp:LinkButton ID="lnkExcel0" runat="server" CssClass="myLink" 
                                    onclick="lnkExcel0_Click">Descargar formato Excel</asp:LinkButton>
                                    </asp:Panel>
                            </td>
                        </tr>
                    
                  
                        
                        <tr>
                            <td align="left" class="style22">
                                &nbsp;</td>
                            <td align="left"  colspan="6">
                              </td>
                        </tr>
                    
                    </table>
                   </div>
                   
                   </div>
           
                
                  
                 
                  
     
    

</asp:Content>
