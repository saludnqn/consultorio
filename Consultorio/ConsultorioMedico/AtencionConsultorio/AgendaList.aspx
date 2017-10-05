<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgendaList.aspx.cs" Inherits="Consultorio.AtencionConsultorio.AgendaList" MasterPageFile="~/mConsultorio.Master" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register Assembly="Subsonic" Namespace="SubSonic" TagPrefix="subsonic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Turnos.css" rel="stylesheet" type="text/css" />
  <link href="../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
  <link type="text/css" rel="stylesheet" href="../js/jquery-ui-1.7.1.custom.css" />
  <script type="text/javascript" src="../js/jquery.min.js"></script>
  <script type="text/javascript" src="../js/jquery-ui.min.js"></script>
  <script type="text/javascript" src="../js/jquery.ui.datepicker-es.js"></script>   
      
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

<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
       
              
<table width="1200px"   cellpadding="2" cellspacing="2"  >
  <tr>                    
                  <td   align="left" class="style2">
                 &nbsp;</td>
                    
                  <td class="mytituloPagina" align="left" colspan="5">
                      <a href="../Principal.aspx" class="myLink">Regresar</a>   </td>
                    
</tr>
                    
  <tr>                    
                  <td   align="left" class="style2">
                      &nbsp;</td>
                    
                  <td class="mytituloPagina" align="left" colspan="5">
                      &nbsp;</td>
                    
</tr>
                    
  <tr>                    
                  <td   align="left" class="style2">
                      &nbsp;</td>
                    
                  <td class="mytituloPagina" align="left" colspan="5">
                 Atención Consultorio Externo      <hr />
                   </td>
                    
</tr>

<tr>
                   <td align="right" class="style2"  >&nbsp;</td>
                    
                   <td align="right"  class="style8" >Efector:</td>
                    
                      <td align="left" class="style13" colspan="4">
                    <asp:DropDownList ID="ddlZona" runat="server" AutoPostBack="True" 
                              onselectedindexchanged="ddlZona_SelectedIndexChanged">
                      </asp:DropDownList>
                    <asp:DropDownList ID="ddlEfector" runat="server" AutoPostBack="True" 
                              onselectedindexchanged="ddlEfector_SelectedIndexChanged">
                      </asp:DropDownList>
                          <asp:RangeValidator ID="rvEfector" runat="server" 
                              ControlToValidate="ddlEfector" ErrorMessage="Seleccione Efector" 
                              MaximumValue="9999999" MinimumValue="1" Type="Integer" ValidationGroup="0"></asp:RangeValidator>
                    </td>
                    
                    </tr>

                    
                        <tr>
                            <td align="right" class="style2"  >
                                &nbsp;</td>
                            <td align="right"  class="style8">
                               Profesional:
                            </td>
                            <td colspan="4" align="left">
                                   <asp:DropDownList ID="ddlProfesional" runat="server"   Width="200PX">
                      </asp:DropDownList>
                                   <asp:RangeValidator ID="rvProfesional" runat="server" 
                                       ControlToValidate="ddlProfesional" ErrorMessage="Seleccione Profesional" 
                                       MaximumValue="9999999" MinimumValue="1" Type="Integer" ValidationGroup="0"></asp:RangeValidator>
                            </td>
                            
                            
                        </tr>
                    
                    
                    
                    
                    
                    <tr>
                    <td align="right" class="style2"  >&nbsp;</td>
                    
                    
                    
                    <td align="right"  class="style8" >Fecha desde:</td>
                    
                    
                    
                   <td align="left" class="style4"><asp:TextBox ID="txtDesde" runat="server"  Width="70px" ></asp:TextBox>
                    
                  </td>
                    
                    
                    
                   <td align="right" class="style5" >Fecha hasta:</td>
                    <td align="left" class="style6">
                      <asp:TextBox ID="txtHasta" runat="server" Width="70px"></asp:TextBox>
                  
               </td>
               <td class="style7">
                            <asp:Button ID="btnActualizar" runat="server" Width="150px" CssClass="myButton" 
                                    onclick="btnActualizar_Click" 
                                    Text=" BUSCAR CONSULTORIOS" ValidationGroup="0" />
               </td>
               
                      
                    </tr>
                        <tr>
                     <asp:TextBox ID="txtAgenda" runat="server" Width="100%" Visible="false" ></asp:TextBox>
                       <tr>
                            <td class="style2"> </td>
                            <td class="myLabelIzquierda" colspan="5"><hr />
                            </td>
                            </tr>
                        
                     <tr>
                     <td class="style2"   >
                         &nbsp;</td>
                     <td  class="myLabelIzquierda"  colspan="5" align="right">
                    <%--  <table>
                                                                <tr>
                                                                    <td class="myLabelLitlle">
                                                                        Referencias:
                                                                    </td>   <td class="myLabelLitlle" width="70px">
                                                                        <img src="../App_Themes/consultorio/images/verde.gif" /> Activa</td>
                                                                  
                                                                    <td class="myLabelLitlle" width="80px">
                                                                        <img src="../App_Themes/consultorio/images/amarillo.gif" />Bloqueada</td>
                                                                   <td class="myLabelLitlle" width="80px">
                                                                        <img src="../App_Themes/consultorio/images/rojo.gif" />Inactiva</td>
                                                                   
                                                                </tr>
                                                            </table>--%>
                         <asp:Label ID="lblCantidadRegistros" runat="server" ForeColor="#3366CC" 
                             Text=""></asp:Label>
                     </td>
                     </tr>
                        
                        <tr>
                            <td align="left" class="style2"  >
                                &nbsp;</td>
                            <td align="left"  colspan="5">
                                <asp:GridView ID="gvAgendas" runat="server"  AutoGenerateColumns="False" 
                              CellPadding="2" CellSpacing="2" DataKeyNames="idAgenda"
                              SelectedIndex="0" Width="100%" EmptyDataText="No se encontraron agendas para los filtros propuestos."
                           
                              ForeColor="#333333" Font-Bold="True" 
                                    BorderColor="#333333" BorderStyle="Solid" BorderWidth="1px" 
                                    Font-Names="Calibri" Font-Size="10pt" 
                                    onselectedindexchanged="gvAgendas_SelectedIndexChanged" 
                                    onrowdatabound="gvAgendas_RowDataBound" 
                                    onrowcommand="gvAgendas_RowCommand" PageSize="50" 
                                    onpageindexchanging="gvAgendas_PageIndexChanging" ShowFooter="True">
                           
                                    <PagerStyle BackColor="#CCCCCC" BorderStyle="None" />
                           
                              <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="#333333"  />
                              <Columns>
                                
                                  <%--  <asp:HyperLinkField  DataNavigateUrlFields="idAgenda" DataNavigateUrlFormatString="../Turnos/AsistenciaEdit.aspx?idAgenda={0}"
            HeaderText="Cierre" Text="Ingresar"   />--%>
                                
                                <%--  <asp:HyperLinkField DataNavigateUrlFields="idAgenda" DataNavigateUrlFormatString="~/ConsultaAmbulatoria/DiagnosticoEdit.aspx"
            HeaderText="Codificar" Text="Ingresar" />--%><asp:BoundField  DataField="Estado" HeaderText="Estado" 
                                      >
                                     <ItemStyle Width="5%" HorizontalAlign="Center" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="efector" HeaderText="Efector" >
                                   <ItemStyle Width="12%" />
                                </asp:BoundField>
                                <asp:BoundField  DataField="fecha" DataFormatString="{0:dd/MM/yyyy}"  HeaderText="Fecha">
                                    <ItemStyle Width="5%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Servicio" HeaderText="Servicio" Visible="False" >
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" >
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Profesional" HeaderText="Profesional" >
                                    <ItemStyle Width="12%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Consultorio" HeaderText="Consultorio" >
                                    <ItemStyle Width="5%" />
                                </asp:BoundField>                                
                                  <asp:BoundField DataField="hIni" HeaderText="Inicio" >
                                      <ItemStyle Width="5%" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="hFin" HeaderText="Fin" >
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                </asp:BoundField>
                                  
                                      <asp:BoundField ItemStyle-Width="20px" Visible="False"  DataField="cantidadTurnos" HeaderText="Turnos Generados" ItemStyle-BackColor="#CCCCCC" ItemStyle-ForeColor="#CC3300" ItemStyle-Font-Size="12" ItemStyle-Font-Bold="True" ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center" BackColor=LightGray Font-Bold="True" Font-Size="10pt" ForeColor="Black" Width="5%"></ItemStyle>
                                </asp:BoundField>
                                
                                     <asp:BoundField  ItemStyle-Width="20px" Visible="False"  DataField="turnosAnticipados" HeaderText="Dados Anticip." ItemStyle-BackColor="#CCCCCC" ItemStyle-ForeColor="#CC3300" ItemStyle-Font-Size="12" ItemStyle-Font-Bold="True" ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center" BackColor=LightYellow Font-Bold="True" Font-Size="10pt" ForeColor="#CC3300" 
                                        Width="5%"></ItemStyle>
                                </asp:BoundField>
                                
                                <asp:BoundField  ItemStyle-Width="20px" Visible="False"  DataField="turnosDia" HeaderText="Dados Dia" ItemStyle-BackColor="#CCCCCC" ItemStyle-ForeColor="#CC3300" ItemStyle-Font-Size="12" ItemStyle-Font-Bold="True" ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center" BackColor=LightYellow Font-Bold="True" Font-Size="10pt" ForeColor="#CC3300" 
                                        Width="5%"></ItemStyle>
                                </asp:BoundField>
                                
                               
                                
                                
                                    <asp:BoundField  ItemStyle-Width="20px" DataField="turnosDados" HeaderText="Total Turnos Dados" ItemStyle-BackColor="#CCCCCC" ItemStyle-ForeColor="#CC3300" ItemStyle-Font-Size="12" ItemStyle-Font-Bold="True" ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center" BackColor=LightYellow Font-Bold="True" Font-Size="10pt" ForeColor="#CC3300" 
                                        Width="5%"></ItemStyle>
                                </asp:BoundField>
                                
               
                                
                                   <asp:BoundField ItemStyle-Width="20px"  Visible="False"  DataField="turnosDisponibles" HeaderText="Turnos Disponibles" ItemStyle-BackColor="#CCCCCC" ItemStyle-ForeColor="#CC3300" ItemStyle-Font-Size="12" ItemStyle-Font-Bold="True" ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center" BackColor=LightCyan Font-Bold="True" Font-Size="10pt" ForeColor="#CC3300" 
                                           Width="5%"></ItemStyle>
                                </asp:BoundField>
                                   <asp:BoundField ItemStyle-Width="20px"   DataField="" HeaderText="Sobre Turnos" ItemStyle-BackColor="#CCCCCC" ItemStyle-ForeColor="#CC3300" ItemStyle-Font-Size="12" ItemStyle-Font-Bold="True" ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center" BackColor=LightYellow Font-Bold="True" Font-Size="10pt" ForeColor="#CC3300" 
                                           Width="5%"></ItemStyle>
                                </asp:BoundField>
                                
              
                                <asp:TemplateField HeaderText="Editar" Visible="False" >
                                  <ItemTemplate >
                                      <asp:LinkButton  ID="Editar" Text="Editar" CommandName="Editar" runat="server" AlternateText="Editar" />
                                  </ItemTemplate>
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                             
                             
                                <asp:TemplateField HeaderText="Planilla"  >
                                  <ItemTemplate >
                                      <asp:LinkButton  ID="Planilla" Text="Descargar" CommandName="Planilla" runat="server" AlternateText="Seleccionar" />
                                  </ItemTemplate>
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                
                                
                                <asp:TemplateField HeaderText="Turnos" Visible="False">
                                  <ItemTemplate >
                                        <asp:LinkButton  ID="Turnos" Text="Ver" CommandName="Turnos" runat="server" AlternateText="Seleccionar" />
                                  </ItemTemplate>
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Atención"  >
                                  <ItemTemplate >
                                    <asp:LinkButton  ID="Codificar" Text="Ingresar" CommandName="Codificar" runat="server" AlternateText="Seleccionar"  />
                                  </ItemTemplate>
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                
                                
                              </Columns>
                                  <EditRowStyle BackColor="#2461BF" />
                          
                              <FooterStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="#333333" 
                                        HorizontalAlign="Center" />
                            </asp:GridView></td>
                        </tr>
                    
                        <tr>
                            <td align="left" class="style2"  >
                                &nbsp;</td>
                            <td align="left"  colspan="5">
                                &nbsp;</td>
                        </tr>
                    
                    </table>
                   
           
                
                  
                 
                  
     
    

</asp:Content>
