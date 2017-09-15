<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PacientesConTurnos.aspx.cs" Inherits="Consultorio.Turnos.PacientesConTurnos" MasterPageFile="~/mConsultorio.Master"   UICulture="es" Culture="es-AR"%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajx" %>
<%@ Register Assembly="Subsonic" Namespace="SubSonic" TagPrefix="subsonic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
    
  <link href="../Turnos.css" rel="stylesheet" type="text/css" />
  
    <link type="text/css" rel="stylesheet" href="../../js/jquery-ui-1.7.1.custom.css" />
  <script type="text/javascript" src="../../js/jquery.min.js"></script>
  <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">
    <br />
  

 <ajx:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
    EnableScriptLocalization="true">
  </ajx:toolkitscriptmanager>

  <div class="div_exterior" >    
   
        <div style="width:1150px;  ">  
                  
          <table width="100%" >         
            
            <tr>
                <td align="left" class="mytituloPagina" colspan="3">
          Pacientes con Turno </td>
              
                <td align="right" class="myLabelRojo" colspan="3">
             
                    <asp:LinkButton ID="lnkDescargarArchivoHC" Visible="false" runat="server" 
                        onclick="lnkDescargarArchivoHC_Click">Formato Pdf</asp:LinkButton>  &nbsp;  
                    <asp:LinkButton ID="lnlDescargarArchivoHCExcel" Visible="false" runat="server" onclick="lnlDescargarArchivoHCExcel_Click" 
                        >Formato Excel</asp:LinkButton> </td>
              
            </tr>
            
            <tr>
                <td align="left" class="myLabelIzquierda" colspan="6">
                  <hr /></td>
              
            </tr>
            
            <tr>
              <!-- FILTROS !--><td align="left" class="myLabelIzquierda">
                  <b class="labeldatos">Fecha: </b>    
                <asp:TextBox ID="txtFecha" runat="server" CssClass="myTexto" Width="80px"></asp:TextBox>
                    <asp:ImageButton ID="cmdFecha" runat="server" AlternateText="seleccione fecha" 
                        ImageUrl="~/App_Themes/default/img/calendar.png" OnClick="cmdFecha_Click" 
                        ToolTip="Seleccione fecha" Width="20px" />
                    <ajx:CalendarExtender ID="CalendarExtender1" runat="server" 
                        CssClass="cal_Theme1" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" 
                        TargetControlID="txtFecha" TodaysDateFormat="dd/MM/yyyy">
                    </ajx:CalendarExtender>
                  
                 

              </td>
              
                <td align="left" class="myLabelIzquierda">
                Tipo de Agenda:
               <asp:DropDownList ID="ddlTipoTurno" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlTipoTurno_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="0">Todas</asp:ListItem>
                                    <asp:ListItem>Médica</asp:ListItem>
                                    <asp:ListItem>Prestaciones</asp:ListItem>
                                </asp:DropDownList>  
              </td>
              <td align="left" class="myLabelIzquierda" colspan="2">
                Especialidad:
               <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="myTexto" ></asp:DropDownList>
              </td>
               <td align="left" class="myLabelIzquierda">
                Profesional:
              <asp:DropDownList ID="ddlProfesional" runat="server" CssClass="myTexto" ></asp:DropDownList>
              </td>
              
              
              
              
              
              <td align="right">
                <asp:Button Width="120px" ID="btnActualizar" runat="server" Text=" Actualizar vista" CssClass="myButton" onclick="btnActualizar_Click"
               />
              </td>
            </tr>
            <tr>
              <!-- MENSAJES DE ERROR !-->
              <td colspan="6">
              <hr />
              </td>
            </tr>
            <tr>
              <td align="left" colspan="6">
                <img src="../../App_Themes/consultorio/images/pdf.jpg" />
                  <asp:LinkButton ID="lnkExportarPdf" CssClass="myLink" runat="server" 
                      onclick="lnkExportarPdf_Click">Exportar Pdf</asp:LinkButton>
                </td>
            </tr>
            <tr>
              <td colspan="6">                
                  <asp:GridView ID="gvPacientes" runat="server" AutoGenerateColumns="False" 
                      Width="100%" Font-Names="Calibri" Font-Size="10pt" 
                      EmptyDataText="No se encontraron pacientes para los filtros de búsqueda ingresados." BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                      <AlternatingRowStyle BackColor="White" />
                      <Columns>
                          <asp:BoundField DataField="DNI" HeaderText="DNI" />
                          <asp:BoundField DataField="HC" HeaderText="HC" />
                          <asp:BoundField DataField="Paciente" HeaderText="Apellidos y Nombres" />
                          <asp:BoundField DataField="sexo" HeaderText="Sexo" />
                          <asp:BoundField DataField="fechaNacimiento" HeaderText="Fecha Nac." />
                          <asp:BoundField DataField="telefono" HeaderText="Telefono" />
                          <asp:BoundField DataField="domicilio" HeaderText="Domicilio" />
                          <asp:BoundField DataField="Medico" HeaderText="Profesional" />
                          <asp:BoundField DataField="Especialidad" HeaderText="Especialidad/Prestación" />
                          <asp:BoundField DataField="consultorio"  HeaderText="Consultorio" />
                      </Columns>
                      <FooterStyle BackColor="#CCCC99" />
                      <HeaderStyle BackColor="#6B696B" ForeColor="White" BorderStyle="None" Font-Bold="True" />
                      <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                      <RowStyle BackColor="#F7F7DE" BorderStyle="Solid" BorderWidth="1px" />
                      <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                      <SortedAscendingCellStyle BackColor="#FBFBF2" />
                      <SortedAscendingHeaderStyle BackColor="#848384" />
                      <SortedDescendingCellStyle BackColor="#EAEAD3" />
                      <SortedDescendingHeaderStyle BackColor="#575357" />
                  </asp:GridView>
                
              </td>
            </tr>
          </table>
          
        </div> 
        
        
  </div> 
</asp:Content>
