<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TurnosView.aspx.cs" Inherits="Consultorio.PanelConsultas.TurnosView" MasterPageFile="~/mConsultorio.Master"   UICulture="es" Culture="es-AR"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
  <link href="../Turnos.css" rel="stylesheet" type="text/css" />     
  <link type="text/css" rel="stylesheet" href="../../js/jquery-ui-1.7.1.custom.css" />
  <script type="text/javascript" src="../../js/jquery.min.js"></script>
  <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>


 
    <style type="text/css">
        .style3
        {
            width: 22px;
        }
        .style6
        {
            width: 55px;
        }
        .style7
        {
            width: 54%;
        }
    </style>


 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">

  <br />
  <br />

         <table width="800px">
          <tr>
            <td align="left"  class="mytituloPagina" colspan="2"> 
                Turnos<hr />
            </td>
            
            </tr>
           <tr>
            <td align="left"> 
              <asp:Label CssClass="myLabelTitulo" ID="lblTituloAgenda" runat="server" Text=""></asp:Label></td>
            
            <td align="right"> 
                            <asp:Label CssClass="myLabelRojoGde" ID="lblCerrada" runat="server" Visible="false" Text="CERRADA"></asp:Label></td>
            
            </tr>
           <tr>
            <td align="left"> 
              <asp:Label CssClass="myLabelIzquierda" ID="lblFechaAgenda" runat="server" Text=""></asp:Label> 
                          &nbsp;<asp:Label CssClass="myLabelIzquierda" ID="lblHoraAgenda" runat="server" Text=""></asp:Label></td>
            
            <td align="right"> 
                            &nbsp;&nbsp; 
                             </td>
            
            </tr>
           <tr>
            <td colspan="2"> 
                <hr /></td>
            
            </tr>
         <tr>
            
            
           <td style="vertical-align:top;" colspan="2">
            
            
         
       
   
                  
           
             <asp:GridView ID="gvTurnos" runat="server" AutoGenerateColumns="False" 
                                CellPadding="4"  Width="100%"
                          DataKeyNames="idTurno" ForeColor="#333333" CssClass="myLabelIzquierda"
                OnRowDataBound="gvTurnos_RowDataBound" 
                OnSelectedIndexChanged="gvTurnos_SelectedIndexChanged" 
                   Font-Names="Calibri" Font-Size="10pt" 
                   EmptyDataText="No hay turnos en la agenda seleccionada">
                 <PagerStyle Font-Underline="True" HorizontalAlign="Center" BackColor="#2461BF" 
                                  ForeColor="White" />
                          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"  />
                          <RowStyle BackColor="White"  />
                 <EmptyDataRowStyle ForeColor="#CC3300" />
                <Columns>
                  <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                      <asp:Image ID="imgTurno" runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                  
                  <asp:BoundField  DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" 
                    HeaderText="Fecha">
                    <HeaderStyle HorizontalAlign="Justify" />
                 <ItemStyle HorizontalAlign="Center" Width="10%" />
                  </asp:BoundField>
                  
                  
                  <asp:BoundField DataField="Hora" HeaderText="Hora" >
                    <HeaderStyle HorizontalAlign="Center" />
                 <ItemStyle HorizontalAlign="Center" Width="10%" />
                  </asp:BoundField>
                  <asp:BoundField DataField="DNI" HeaderText="DNI">
                    <HeaderStyle HorizontalAlign="Center" />
          <ItemStyle HorizontalAlign="Center" Width="15%" />
                  </asp:BoundField>
                  <asp:BoundField DataField="HC" HeaderText="HC">
                    <HeaderStyle HorizontalAlign="Center" />
                 <ItemStyle HorizontalAlign="Center" Width="10%" />
                  </asp:BoundField>
                  <asp:BoundField DataField="Paciente" HeaderText="Paciente">
                    <HeaderStyle HorizontalAlign="Center" />
                  <ItemStyle HorizontalAlign="Justify" Width="55%" />
                  </asp:BoundField>
                 <%-- <asp:TemplateField>
                    <ItemTemplate>
                      <asp:ImageButton ID="cmdSelTurno" runat="server" AlternateText="seleccionar" 
                        CommandName="Select" 
                        ImageUrl="~/App_Themes/consultorio/Agenda/seleccionar.png" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                  </asp:TemplateField>--%>
                  
                      <asp:BoundField DataField="usuario" HeaderText="Asig. por">
                    <HeaderStyle HorizontalAlign="Center" />
                  <ItemStyle  Width="15%" />                  
                  
                  </asp:BoundField>
                  
                   <asp:TemplateField HeaderText="Asistencia" Visible="False">
                                                                       <ItemTemplate>
                                                                           <asp:CheckBox Font-Bold=true ID="CheckBox1" runat="server" EnableViewState="true" />
                                                                           
                                                                           
                                                                       </ItemTemplate>
                                                                       <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                   </asp:TemplateField>
                </Columns>
              
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              
                  <EditRowStyle BackColor="#2461BF" />
              
              
              </asp:GridView>
     
                 
        
      
            </td>
         </tr>
          <tr>
            <td colspan="2"> 
                <hr /></td>
            
            </tr>
         <tr>
         <td>
             <table class="myLabelIzquierda"  align="left" border="0" 
                 cellpadding="0" cellspacing="0" style="border: 1px solid #000000">
                 <tr>
                     <td colspan="2" align="left" bgcolor="#CCCCCC">
                         Referencias</td>
                     <td align="center" bgcolor="#CCCCCC">
                         Cantidad</td>
                 </tr>
                 <tr>
                     <td class="style3">
                         <div style="background-color: #FFFFCC; width: 20px; height: 14px; border-style: solid; border-width: 1px">
                         </div>
                     </td>
                     <td class="style6" align="left">
                         Asistió</td>
                     <td class="style7" align="center">
                         <asp:Label ID="lblCantidadAsistencia" runat="server" Text="Label"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td class="style3">
                         <div style="background-color: #C0C0C0; width: 20px; height: 14px; border-style: solid; border-width: 1px">
                         </div>
                     </td>
                     <td class="style6" align="left">
                         No Asistió</td>
                     <td class="style7" align="center">
                         <asp:Label ID="lblCantidadInasistencia" runat="server" Text="Label"></asp:Label>
                     </td>
                 </tr>
             </table>
                            </td>
         <td   align="right"> 
             <a href="javascript:history.back()">Regresar</a></td>
         </tr>
         </table>    
      
      
      
      
  <!-- capa externa !-->
  
</asp:Content>
