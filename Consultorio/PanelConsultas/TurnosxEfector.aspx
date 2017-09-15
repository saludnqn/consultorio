<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TurnosxEfector.aspx.cs" Inherits="Consultorio.PanelConsultas.TurnosxEfector" MasterPageFile="~/mConsultorio.Master"   UICulture="es" Culture="es-AR"%>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register Assembly="Subsonic" Namespace="SubSonic" TagPrefix="subsonic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Turnos.css" rel="stylesheet" type="text/css" />
  <link href="../../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
  <link type="text/css" rel="stylesheet" href="../../js/jquery-ui-1.7.1.custom.css" />
  <script type="text/javascript" src="../../js/jquery.min.js"></script>
  <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>
  <script type="text/javascript" src="../../js/jquery.ui.datepicker-es.js"></script>   
  
  <script src="../../js/jquery-1.8.2.js" type="text/javascript"></script>
  <script src="../../js/jquery-ui.js" type="text/javascript"></script>
  <script type="text/javascript">       

	$(function() {
		$("#<%=txtDesde.ClientID %>").datepicker({
		    showOn: 'button',
		    dateFormat: 'dd/mm/yy',
			buttonImage: '../../App_Themes/consultorio/images/calend1.jpg',
			buttonImageOnly: true
		});
	});

	$(function() {
		$("#<%=txtHasta.ClientID %>").datepicker({
		    showOn: 'button',
		    dateFormat: 'dd/mm/yy',
			buttonImage: '../../App_Themes/consultorio/images/calend1.jpg',
			buttonImageOnly: true
		});
	}); 
     
  </script>      
  
  
    
  
  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">
    <br />

<br />

<br />
 

              <div id="divfiltro" runat="server" visible="true"  >
              
<table   >
  <tr>                    
                  <td class="style2" align="left">
                      &nbsp;</td>
                    
                  <td class="mytituloPagina" align="right" colspan="2">
                      Indicador de Turnos</td>
                    
                  <td class="style3" align="right">
                      <asp:LinkButton ID="lnkRegresar" runat="server" onclick="lnkRegresar_Click" >Regresar</asp:LinkButton>
                   </td>
                    
</tr>
                    
                      <tr>
                    
                    <td align="right" class="style2" >
                        &nbsp;</td>
                    
                    
                    <td align="right"  colspan="3" >
                       <hr /></td>
                    
                    
                    </tr>
                        
                      <tr>
                    
                    <td align="right" class="style2" >
                        &nbsp;</td>
                    
                    
                    <td align="right" class="myLabelIzquierda" >
                Servicio:
                    </td>
                    
                    
                    <td  align="left" class="style10" colspan="2">
                 <asp:DropDownList ID="ddlServicios" runat="server" Width="400px" >
                                </asp:DropDownList>
                    </td>
 
                    
                    </tr>
                        
                        <tr>
                           
                            <td align="right" class="style2">
                                &nbsp;</td>
                           
                            <td align="right" class="myLabelIzquierda">
                                Tipo de Agenda:</td>
                            <td align="left" class="style10" colspan="2" >
                             <asp:DropDownList ID="ddlTipoTurno" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlTipoTurno_SelectedIndexChanged">
                                    <asp:ListItem Selected="True">Médica</asp:ListItem>
                                    <asp:ListItem>Prestaciones</asp:ListItem>
                                </asp:DropDownList>
                             
                            </td>
                        </tr>
                    
                    
                        <tr>
                           
                            <td align="right" class="style2">
                                &nbsp;</td>
                           
                            <td align="right" class="myLabelIzquierda">
                                Especialidad:</td>
                            <td align="left" class="style10" colspan="2" >
                                <asp:DropDownList ID="ddlEspecialidad" runat="server" >
                      </asp:DropDownList>
                             
                            </td>
                        </tr>
                    
                    
                  <%--  <tr>
                   <td align="right" class="myLabelIzquierda">Profesional:</td>
                    
                      <td align="left" colspan="2">
                    <asp:DropDownList ID="ddlProfesional" runat="server"   Width="200PX">
                      </asp:DropDownList>
                    </td>
                    
                  
                      <td align="left">
                          &nbsp;</td>
                    
                  
                    </tr>--%>
                    
                    
                    <tr>
                    <td align="right" class="style2">&nbsp;</td>
                    
                    
                    
                    <td align="right" class="myLabelIzquierda">Fecha desde:</td>
                    
                    
                    
                   <td align="left" class="style10" colspan="2"><asp:TextBox ID="txtDesde" runat="server"  Width="70px" ></asp:TextBox>
                    
                  </td>
                    
                    
                    
                    </tr>
                    
                    
                    <tr>
                    <td align="right" class="style2">&nbsp;</td>
                    
                    
                    
                    <td align="right" class="myLabelIzquierda">Fecha hasta:</td>
                    
                    
                    
                   <td align="left" class="style10" colspan="2">
                      <asp:TextBox ID="txtHasta" runat="server" Width="70px"></asp:TextBox>
                  
                  </td>
                    
                    
                    
                    </tr>
                     <%-- <tr>
                      
                      <td align="right" class="myLabelIzquierda" colspan="1" style="vertical-align: top">
                          Efector:</td>
                            
                            <td class="myLabelIzquierda" colspan="2" align="left">
                            
                            
                                <asp:CheckBoxList ID="chlstEfector" runat="server" Visible="False">
                                </asp:CheckBoxList>
                            </td>
                            
                            <td class="myLabelIzquierda" align="left">
                            
                            
                                &nbsp;</td>
                            
                            </tr>--%>
                                          
                    
                    <tr>
                    <td align="right" class="style2">&nbsp;</td>
                    
                    
                    
                    <td align="right" class="myLabelIzquierda" colspan="3">
                            <asp:Button ID="btnActualizar" runat="server" Width="120px" CssClass="myButton" 
                                    onclick="btnActualizar_Click" 
                                    Text="Actualizar Vista" />
                            </td>
                    
                    
                    
                    </tr>
                      <tr>
                      
                      <td align="right" class="style2">
                            </td>
                            
                      <td align="right" class="myLabelIzquierda" colspan="3">
                            <hr /></td>
                            
                            <td class="style2" align="left">
                            
                            
                                </td>
                            
                            </tr>
                        <tr>
                     <asp:TextBox ID="txtAgenda" runat="server" Width="100%" Visible="false" ></asp:TextBox>
                        <tr>
                            <td class="style2">
                                &nbsp;</td>
                            <td class="myLabelIzquierda" colspan="3">
                                <asp:GridView ID="gvLista" runat="server" 
                              Width="600px" 
                                    EmptyDataText="No se encontraron datos para los filtros propuestos." Font-Bold="True" 
                                    Font-Names="Calibri" Font-Size="10pt" AutoGenerateColumns="False">
                           
                                    <Columns>
                                        <asp:BoundField DataField="Efector" HeaderText="Efector" >
                                         
                                            <ItemStyle Width="40%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Turnos Generados" HeaderText="Turnos Generados">
                                         
                                            <ItemStyle Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Turnos Dados" HeaderText="Turnos Dados">
                                          
                                            <ItemStyle Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Turnos Disponibles" HeaderText="Turnos Disponibles">
                                          
                                            <ItemStyle Font-Bold="True" Font-Size="11pt" Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SobreTurnos" HeaderText="SobreTurnos">
                                           
                                            <ItemStyle Width="15%" />
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle BackColor="#999999" />
                              
                           
                          
                            </asp:GridView>
                            </td>
                        </tr>
                        
                  
                        
                        <tr>
                            <td align="left" class="style5">
                                &nbsp;</td>
                            <td align="left"  colspan="3">
                                &nbsp;</td>
                        </tr>
                    
                    </table>
                   
           
                  
                  </div>
                
                  
                 
                  
     
    

</asp:Content>

