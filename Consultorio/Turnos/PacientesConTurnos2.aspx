<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PacientesConTurnos2.aspx.cs" Inherits="Consultorio.Turnos.PacientesConTurnos2" MasterPageFile="~/mConsultorio.Master"   UICulture="es" Culture="es-AR"%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajx" %>
<%@ Register Assembly="Subsonic" Namespace="SubSonic" TagPrefix="subsonic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
    
  <link href="../Turnos.css" rel="stylesheet" type="text/css" />
  
    <link type="text/css" rel="stylesheet" href="../js/jquery-ui-1.7.1.custom.css" />
  <script type="text/javascript" src="../js/jquery.min.js"></script>
  <script type="text/javascript" src="../js/jquery-ui.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">

    
 <ajx:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
    EnableScriptLocalization="true">
  </ajx:toolkitscriptmanager>

  <div class="div_exterior" >      
            
            
        <div style="width:1150px;  ">  
                  
          <table width="100%" >            
            <tr>
                <td align="left" class="mytituloPagina" colspan="3">
          Movimientos HHCC de Pacientes con Turno</td>              
                <td align="right" class="myLabelRojo" colspan="5">
                <img src="../App_Themes/consultorio/images/new.png" />Descargar Archivo Completo HHCC<br />
                    <asp:LinkButton ID="lnkDescargarArchivoHC" runat="server" 
                        onclick="lnkDescargarArchivoHC_Click">Formato Pdf</asp:LinkButton>  &nbsp;  
                    <asp:LinkButton ID="lnlDescargarArchivoHCExcel" runat="server" onclick="lnlDescargarArchivoHCExcel_Click" 
                        >Formato Excel</asp:LinkButton> </td>
              
            </tr>
            
            <tr>
                <td align="left" class="myLabelIzquierda" colspan="8">
                  <hr /></td>
              
            </tr>
            
            <tr>
              <!-- FILTROS !--><td align="left" class="myLabelIzquierda">
                  <b class="labeldatos">Fecha: </b>    
                    <ajx:CalendarExtender ID="CalendarExtender1" runat="server" 
                        CssClass="cal_Theme1" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" 
                        TargetControlID="txtFecha" TodaysDateFormat="dd/MM/yyyy">
                    </ajx:CalendarExtender>
                  
                 

              </td>
              
                <td align="left" class="myLabelIzquierda">
                <asp:TextBox ID="txtFecha" runat="server" CssClass="myTexto" Width="80px"></asp:TextBox>
                    <asp:ImageButton ID="cmdFecha" runat="server" AlternateText="seleccione fecha" 
                        ImageUrl="~/App_Themes/default/img/calendar.png" OnClick="cmdFecha_Click" 
                        ToolTip="Seleccione fecha" Width="20px" />
              </td>
              <td align="left" class="myLabelIzquierda" colspan="2">
                   Paciente:</td>
               <td align="left" class="myLabelIzquierda">
                &nbsp;<asp:DropDownList ID="ddlTipoPaciente" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoPaciente_SelectedIndexChanged">
                       <asp:ListItem Value="-1">Todos</asp:ListItem>
                       <asp:ListItem Value="1">Con HC</asp:ListItem>
                       <asp:ListItem Value="0">Sin HC (hoja d)</asp:ListItem>
                    <asp:ListItem Value="2">Con Movimiento</asp:ListItem>
                    <asp:ListItem Value="3" Selected="True">Pendiente</asp:ListItem>
                   </asp:DropDownList>
              </td>
              
              
              
              
              
               <td align="left" class="myLabelIzquierda">
                   <%--Mov. HHCC:--%>

               </td>
              
              
              
              
              
               <td align="left" class="myLabelIzquierda">
                 <%--  <asp:DropDownList ID="ddlMovimiento" runat="server">
                       <asp:ListItem Value="-1">Todos</asp:ListItem>
                       <asp:ListItem Value="1">Con HC</asp:ListItem>
                       <asp:ListItem Value="0">Sin HC (hoja d)</asp:ListItem>
                   </asp:DropDownList>--%>
                </td>
              
              
              
              
              
              <td align="right" rowspan="2">
                <asp:Button Width="120px" ID="btnActualizar" runat="server" Text=" Actualizar vista" CssClass="myButton" onclick="btnActualizar_Click"
               />
              </td>
            </tr>
            
            <tr>
                <td align="left" class="myLabelIzquierda">
                Tipo de Agenda:
                                 
                 

              </td>
              
                <td align="left" class="myLabelIzquierda">
               <asp:DropDownList ID="ddlTipoTurno" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlTipoTurno_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="0">Todas</asp:ListItem>
                                    <asp:ListItem>Médica</asp:ListItem>
                                    <asp:ListItem>Prestaciones</asp:ListItem>
                                </asp:DropDownList>  
              </td>
              <td align="left" class="myLabelIzquierda" colspan="2">
                Especialidad:
               </td>
               <td align="left" class="myLabelIzquierda">
               <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="myTexto" ></asp:DropDownList>
              </td>
              
              
              
              
              
               <td align="left" class="myLabelIzquierda">
                Profesional:</td>
              
              
              
              
              
               <td align="left" class="myLabelIzquierda">
              <asp:DropDownList ID="ddlProfesional" runat="server" CssClass="myTexto" ></asp:DropDownList>
              </td>
              
              
            </tr>
            <tr>
              <!-- MENSAJES DE ERROR !-->
              <td colspan="8">
              <hr />
              </td>
            </tr>
            <tr>
              <td align="left" colspan="8">
                <img src="../App_Themes/consultorio/images/pdf.jpg" />
                  <asp:LinkButton ID="lnkExportarPdf" CssClass="myLink" runat="server" 
                      onclick="lnkExportarPdf_Click">Exportar Pdf</asp:LinkButton>
                </td>
            </tr>
            <tr>
              <td colspan="8">
      <asp:UpdatePanel runat="server" ID="TimedPanel" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="UpdateTimer" EventName="Tick" />
                </Triggers>
                <ContentTemplate>
                        
                    <asp:Timer runat="server" ID="UpdateTimer" Interval="3000" OnTick="UpdateTimer_Tick" />
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#CC3300"></asp:Label>      
                    
                  <asp:GridView ID="gvPacientes" runat="server" AutoGenerateColumns="False" 
                      Width="100%" Font-Names="Calibri" Font-Size="10pt" DataKeyNames="IdTurno"
                      EmptyDataText="No se encontraron pacientes para los filtros de búsqueda ingresados." OnRowDataBound="gvPacientes_RowDataBound" OnRowCommand="gvPacientes_RowCommand" OnSelectedIndexChanged="gvPacientes_SelectedIndexChanged" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black">
                      <AlternatingRowStyle BackColor="White" />
                      <Columns>
                             <asp:TemplateField HeaderText="Sel." >
                                                        <ItemTemplate>
                                                         <asp:CheckBox  ID="seleccionar" AutoPostBack="true" runat="server" 
                        OnCheckedChanged="CheckBox1_CheckedChanged1" ToolTip="Marcar si sale del archivo"   />
                                                     </ItemTemplate>
                                                     <ItemStyle Width="5%" 
                                                            HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                          <asp:BoundField DataField="sale"                           HeaderText="Archivo" />
                          <asp:BoundField DataField="DNI"                           HeaderText="DNI" />
                          <asp:BoundField DataField="HC" HeaderText="HC" >
                             <ItemStyle Font-Bold="True" />
                             </asp:BoundField>
                          <asp:BoundField DataField="Medico" HeaderText="Profesional" >
                             <ItemStyle HorizontalAlign="Left" />
                             </asp:BoundField>
                          <asp:BoundField DataField="Hora" HeaderText="Hora Turno" />
                          <asp:BoundField DataField="Paciente" HeaderText="Apellidos y Nombres" >
                             <ItemStyle HorizontalAlign="Left" />
                             </asp:BoundField>
                          <asp:BoundField DataField="sexo" HeaderText="Sexo" />
                          <asp:BoundField DataField="fechaNacimiento" HeaderText="Fecha Nac." />
                          <asp:BoundField DataField="informacionContacto" HeaderText="Datos Adicionales" />
                          <asp:BoundField DataField="domicilio" HeaderText="Domicilio" />
                          
                          <asp:BoundField DataField="Especialidad" HeaderText="Especialidad  Prestación" />
                          <asp:BoundField DataField="consultorio"  HeaderText="Consultorio" />
                               <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <asp:LinkButton ID="Editar" Text="Editar" CommandName="Editar" runat="server" AlternateText="Editar" />
                            </ItemTemplate>
                            <ItemStyle ForeColor="Blue" Width="5%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                          <%--<asp:BoundField DataField="IdTurno"  HeaderText="IdTurno" />
                          <asp:TemplateField HeaderText="Planilla">
                            <ItemTemplate>
                                <asp:LinkButton ID="Planilla" Text="Descargar" CommandName="Planilla" runat="server" 
                                    AlternateText="Seleccionar" />
                            </ItemTemplate>
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:TemplateField>--%>
                      </Columns>
                      <FooterStyle BackColor="#CCCC99" />
                      <HeaderStyle BackColor="#6B696B" ForeColor="White" BorderStyle="None" Font-Bold="True" />
                      <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                      <RowStyle BorderStyle="Solid" BorderWidth="1px" BackColor="#F7F7DE"/>
                      <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                      <SortedAscendingCellStyle BackColor="#FBFBF2" />
                      <SortedAscendingHeaderStyle BackColor="#848384" />
                      <SortedDescendingCellStyle BackColor="#EAEAD3" />
                      <SortedDescendingHeaderStyle BackColor="#575357" />
                  </asp:GridView>

          </ContentTemplate>
            </asp:UpdatePanel>
                    
              
              
              </td>
            </tr>
          </table>
           
        </div> 
             
        
  </div> 
</asp:Content>
