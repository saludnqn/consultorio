<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TurnosPorPaciente.aspx.cs" Inherits="Consultorio.Turnos.TurnosPorPaciente" MasterPageFile="~/mConsultorio.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<%@ Register Assembly="Subsonic" Namespace="SubSonic" TagPrefix="subsonic" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
  <link href="../Turnos.css" rel="stylesheet" type="text/css" />     <link type="text/css" rel="stylesheet" href="../js/jquery-ui-1.7.1.custom.css" />
  <script type="text/javascript" src="../js/jquery.min.js"></script>
  <script type="text/javascript" src="../js/jquery-ui.min.js"></script>

  <script type="text/javascript">
    function valHora(oTxt) {
      var bOk = true;
      if (oTxt.value != "") {
        var nHs = parseInt(oTxt.value.substr(0, 2), 10);
        var nMin = parseInt(oTxt.value.substr(3, 2), 10);
        bOk = bOk && (nHs <= 23) && (nMin <= 59) && (oTxt.value.length == 5);
        if (!bOk) {
          alert("Hora inválida (Formato hh:mm)");
          oTxt.value = "";
          oTxt.focus();
        }
      }
    }   
  </script>
    <style type="text/css">
        .grid
        {
            margin-right: 0px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">

  <br />
  <br /> <br />
  <br /> 
   <div align="left" class="mytituloPagina">
 ADMINISTRACION DE TURNOS POR PACIENTE
  <hr />

  </div>

  <ajx:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptLocalization="true" EnableScriptGlobalization="true" >
  </ajx:ToolkitScriptManager>
  
             
  
  <!-- capa externa !-->
  <div class="div_exterior" >
     <!-- barra izquierda !-->
    <div  style="width:300px;
      height:100%;
      float:left;
      padding: 0px 0px	0px 0px;" >
      <asp:UpdatePanel ID="updfiltro" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>
          
          <!-- acordion con parámetros de búsqueda !-->
          <div style="height:100%; ">
          
                          
             
                        <div id="divbusquedapacientes" runat="server" style="width:99%; height:99%;" >
                          <!-- parámetros de búsqueda por pacientes !-->
                          <table width="100%">
                            <tr>
                              <td class="myLabelIzquierda" >Dni:</td>
                              <td align="left" >
                                <asp:TextBox ID="txtDNI" runat="server" CssClass="myTexto" Width="100px" EnableViewState="False"></asp:TextBox>
                              </td>
                            </tr>
                          
                            <tr>
                              <td class="myLabelIzquierda" >Apellidos:</td>
                              <td align="left" >
                                <asp:TextBox ID="txtApellido" runat="server" CssClass="myTexto" Width="99%" EnableViewState="False"></asp:TextBox> 
                              </td>
                            </tr>
                            <tr>
                              <td class="myLabelIzquierda" >Nombres:</td>
                              <td align="left" >
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="myTexto" Width="98%" EnableViewState="False"></asp:TextBox> 
                              </td>
                            </tr>
                            
                               <tr>
                   <td class="myLabelIzquierda">Turnos desde:</td>                    
                    <td align="left">  
                       <asp:TextBox ID="txtFechaDesde" runat="server" Width="60px" ></asp:TextBox>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/App_Themes/default/img/calendar.png"
                                      AlternateText="seleccione fecha" ToolTip="Seleccione fecha" />
                                    
                                    <ajx:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaDesde" CssClass="cal_Theme1"
                                      FirstDayOfWeek="Monday" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy" PopupPosition="BottomRight" PopupButtonID="cmdFecha"></ajx:CalendarExtender>  
                      </td>
                    </tr>
                            
                            <tr>
                              <td colspan="2" style="padding-top:10px;">
                                <asp:Button ID="btnBuscarPaciente" Width="120px" runat="server" Text="Buscar paciente" CssClass="myButton" OnClick="btnBuscarPaciente_Click"
                                   />                                
                              </td>
                            </tr>
                          </table>
                          <br />
                          <!-- grilla para cargar turnos de paciente !-->
                          <div id="resultadosPacientes" runat="server" visible="true" >
                            <asp:GridView ID="gvPacientes" runat="server" GridLines="Both"  Font-Names="Calibri" Font-Size="10pt" ForeColor="#333333"  
                              AutoGenerateColumns="False" Width="95%" DataKeyNames="idPaciente" 
                              ShowHeader="true" CellPadding="2"  AllowPaging="True" PageSize="13"
                              EmptyDataText="No se encontraron pacientes registrados coincidentes con el critério de búsqueda"
                              OnPageIndexChanging="gvPacientes_PageIndexChanging" OnRowDataBound="gvPacientes_RowDataBound" 
                              OnSelectedIndexChanged="gvPacientes_SelectedIndexChanged" >
                              <PagerStyle Font-Bold="True" Font-Underline="True" HorizontalAlign="Center" />
                              <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"  />
                          <RowStyle BackColor="#EFF3FB"  />
                              <PagerSettings PageButtonCount="4" LastPageText="&gt;&gt;" />
                             
                              <SelectedRowStyle/>
                              <Columns>
                               
                                <asp:BoundField DataField="numeroDocumento" HeaderText="DNI">
                                 
                                </asp:BoundField>
                                <asp:BoundField DataField="apellido" HeaderText="Apellido">
                                 
                                </asp:BoundField>
                                <asp:BoundField DataField="nombre" HeaderText="Nombre">
                                 
                                </asp:BoundField>
                                
                                 <asp:TemplateField>
                                  <ItemTemplate>
                                    <asp:ImageButton ID="cmdSel" runat="server" CommandName="cmdDetalles" AlternateText="Seleccionar" 
                                      ToolTip="Seleccionar paciente" ImageUrl="~/App_Themes/consultorio/Agenda/seleccionar.png" />
                                  </ItemTemplate> 
                                  <ItemStyle HorizontalAlign="Left" Width="10px" />
                                </asp:TemplateField>
                              </Columns>
                              <AlternatingRowStyle />
                              <FooterStyle />
                            </asp:GridView>  
                          </div>
                          <!-- mensajes de validación para el usuario !-->
                          <div id="divErr" class="identincorrecta"  runat="server" visible="false">
                            <asp:Label ID="lblMsgErr" runat="server" Text="" CssClass="labelerror"></asp:Label> 
                          </div>
                        </div>
               
                  
             
          </div>
        </ContentTemplate>
      </asp:UpdatePanel>
    </div>
    <!-- columnas laterales derechas !-->
    <div style="border: 1px solid #C0C0C0;	width: 600px;		overflow: auto; vertical-align:top; ">   
  
      <asp:UpdatePanel ID="pnlResultados" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>
          <!-- Barra derecha !-->
          <div style="width:400px;      float:left;
      vertical-align:middle;
      /*padding: -20px 0px 0px 0px;*/
     /* position:relative;*/
      text-align:left;  ">          
            <!-- Grilla de seleccion de turnos !-->
            <div id="divscroll" style=" height:100%; overflow:auto; text-align:center;">
                <div style=" height:50px; overflow:auto; text-align:left;">
               <asp:Label CssClass="myLabelTitulo" ID="lblPaciente" runat="server" Text=""></asp:Label>&nbsp;<br />
              <asp:Label CssClass="myLabelIzquierda" ID="lblDni" runat="server" Text=""></asp:Label>  &nbsp; 
                          <asp:Label CssClass="myLabelIzquierda" ID="lblHC" runat="server" Text=""></asp:Label>
                          </div>
                         
              <asp:GridView ID="gvTurnos" GridLines="Both" 
                runat="server" AutoGenerateColumns="False" CellPadding="4" 
                DataKeyNames="idTurno" Font-Names="Calibri" Font-Size="10pt"
                 OnRowDataBound="gvTurnos_RowDataBound" 
                OnSelectedIndexChanged="gvTurnos_SelectedIndexChanged" 
                    Width="95%">
                  <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"  />
                <Columns>
                  <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                      <asp:Image ID="imgTurno" runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                  <asp:BoundField DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" 
                    HeaderText="Fecha">
                    <HeaderStyle HorizontalAlign="Justify" />
                    <ItemStyle HorizontalAlign="Justify" />
                  </asp:BoundField>
                  <asp:BoundField DataField="Hora" HeaderText="Hora">
                    <HeaderStyle HorizontalAlign="Justify" />
                    <ItemStyle HorizontalAlign="Justify" />
                  </asp:BoundField>
                <%--  <asp:BoundField DataField="DNI" HeaderText="DNI">
                    <HeaderStyle HorizontalAlign="Justify" />
                    <ItemStyle HorizontalAlign="Justify" />
                  </asp:BoundField>
                  <asp:BoundField DataField="HC" HeaderText="HC">
                    <HeaderStyle HorizontalAlign="Justify" />
                    <ItemStyle HorizontalAlign="Justify" />
                  </asp:BoundField>--%>
                  <asp:BoundField DataField="Profesional" HeaderText="Profesional">
                 
                  </asp:BoundField>
                  <asp:BoundField DataField="Especialidad" HeaderText="Especialidad">
                 
                  </asp:BoundField>
                  <asp:TemplateField>
                    <ItemTemplate>
                      <asp:ImageButton ID="cmdSelTurno" runat="server" AlternateText="seleccionar" 
                        CommandName="Select" 
                        ImageUrl="~/App_Themes/consultorio/Agenda/seleccionar.png" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                  </asp:TemplateField>
                </Columns>
              
            
               
              
              </asp:GridView>
            </div>
          </div>
          <!-- barra izquierda !-->
          <div  style="width:200px; float:left; vertical-align:middle; text-align:left; ">
          <br />
            <div class="encabezadoagenda" style="background:White; border:solid 1px;  height:400px; width:auto; padding: 5px 5px 5px 5px;">
              <asp:Panel ID="pnlInfo" Visible="false" runat="server" >
                <!-- Información sobre turno seleccionado !-->
                <div id="divInfoTurnos"  >
                  <!-- Dia, Agenda y hora seleccionada !-->
                  <div id="Calendario" runat="server" class="div_izquierdo20" >                    
                    <!-- calendario !-->
                    <div style="width:100%; padding-left:5px;">
                      <span id="cal" runat="server" class='<%# "cal m" + Convert.ToDateTime(gvTurnos.SelectedRow.Cells[1].Text).Month.ToString() 
                                                    + " d" + Convert.ToDateTime(gvTurnos.SelectedRow.Cells[1].Text).Day.ToString()%>'>
                        <span class="m"><%# Convert.ToDateTime(gvTurnos.SelectedRow.Cells[1].Text).Month.ToString() %></span>
                        <span class="d"><%# Convert.ToDateTime(gvTurnos.SelectedRow.Cells[1].Text).Day.ToString()%></span>
                      </span>
                    </div>
                    <div style="width:100%; padding-left:10px;">
                      <asp:LinkButton ID="lnkInfoAgenda" runat="server" Font-Size="Smaller"  Font-Bold="true"></asp:LinkButton>
                    </div>
                    <div style="width:100%; padding-left:10px;">
                      <asp:Label ID="lblInfoHora" runat="server" Text="<%# gvTurnos.SelectedRow.Cells[2].Text %>" 
                        Font-Size="Large"  Font-Bold="true"></asp:Label>
                    </div>
                  </div>
                  <!-- Informacion del turno !-->
                  <div id="divInfoPaciente" runat=server >
                    <asp:HyperLink ID="lnkPaciente" runat="server" > <asp:Image ID="imgInfoPaciente" runat="server" AlternateText="paciente"  /><br /><asp:Label ID="lblInfoPaciente" runat="server" style="vertical-align:super;margin:10px;"></asp:Label><br /><asp:Label ID="lblInfoDni" runat="server" ></asp:Label></asp:HyperLink>  
                  </div>
                  <br />
                  <div style="text-align:left; width:100%; background:White; vertical-align:bottom;">
                    <table width="100%">
                      
                      <tr>
                        <td align="center"  style="padding:5px;">
                          <!-- info sin asistencia !-->
                          <div id="divAsistenciaNo" runat="server" visible="true">
                            <asp:Label ID="lblNoAsistencia" runat="server" Text="Sin asistencia" CssClass="labelencabezado"></asp:Label>
                            <br />
                            <br />
                            <div style="text-align:right;">
                              <asp:LinkButton ID="lnkAsistenciaNo" runat="server" CssClass="links" 
                                style="text-decoration:underline;vertical-align:middle;cursor:pointer" 
                                onclick="lnkAsistenciaNo_Click"> <img alt="" src="../App_Themes/consultorio/Agenda/check_verde16.png"style="vertical-align:middle;border:none;"/> Indicar asistencia </asp:LinkButton>
                              <br />
                             <%-- <asp:LinkButton ID="lnkImprimir" runat="server" CssClass="links" 
                                style="text-decoration:underline;vertical-align:middle;cursor:pointer" 
                                onclick="lnkImprimir_Click"> <img alt="" src="../App_Themes/consultorio/images/impreso.jpg"style="vertical-align:middle;border:none;"/> Impirmir comprobante </asp:LinkButton>--%>
                            </div>
                          </div>
                          <!-- info con asistencia !-->
                          <div id="divAsistenciaSi" runat="server" visible="false">
                            <asp:Label ID="lblAsistencia" runat="server" Text="Asistencia dd/mm hh:ss" CssClass="labelencabezado"></asp:Label>
                            <br />
                            <br />
                            <asp:LinkButton ID="cmdBorrarAsistencia" runat="server" CssClass="links" 
                              style="text-decoration:underline;vertical-align:middle;cursor:pointer;" 
                              onclick="cmdBorrarAsistencia_Click"> <img alt="" src="../App_Themes/consultorio/Agenda/suprime-la-ventana-icono-4582-16.png"style="vertical-align:middle;border:none;"/> borrar asistencia </asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="cmdEditarAsistencia" runat="server" CssClass="links" 
                              style="text-decoration:underline;vertical-align:middle;cursor:pointer;" 
                              onclick="cmdEditarAsistencia_Click"> <img alt="" src="../App_Themes/consultorio/Agenda/oficina-icono-9743-16.png"style="vertical-align:middle;border:none;"/> editar horario de asistencia </asp:LinkButton>
                          </div>
                          <!-- edición de asistencia !-->
                          <div id="divAsistenciaEdit" runat="server" visible="false">
                            <table width="100%">
                                <tr>
                                  <td style="margin-bottom:45px;">
                                    Fecha: <asp:TextBox ID="txtFechaAsistencia" runat="server" CssClass="boxcortos" Enabled="false"></asp:TextBox>
                                    <asp:ImageButton ID="cmdFecha" runat="server" ImageUrl="~/App_Themes/default/img/calendar.png"
                                      AlternateText="seleccione fecha" ToolTip="Seleccione fecha" />
                                    <asp:CustomValidator ID="cValidator_gr2" runat="server" ControlToValidate="txtFechaAsistencia" ErrorMessage="(*) Fecha anterior al turno" 
                                     EnableClientScript="false" Display="None" ClientValidationFunction="validarFecha()"></asp:CustomValidator>
                                    <ajx:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFechaAsistencia" CssClass="cal_Theme1"
                                      FirstDayOfWeek="Monday" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy" PopupPosition="BottomRight" PopupButtonID="cmdFecha"></ajx:CalendarExtender>  
                                    &nbsp;
                                    Hora: <input type="text" ID="txtHoraAsistencia" runat="server" class="boxcortos" onblur="valHora(this)"/>
                                    <asp:RequiredFieldValidator ID="rqfvHoraAsistencia" runat="server" ErrorMessage="(*)" ControlToValidate="txtHoraAsistencia"></asp:RequiredFieldValidator>
                                  </td>
                                </tr>
                                <tr>
                                  <td colspan="2" align="right">
                                    <br /><br />
                                    <asp:Button ID="cmdGrabarAsistencia" Width="100px" runat="server" Text="Grabar" CssClass="myButton" onclick="cmdGrabarAsistencia_Click" 
                                      />
                                    &nbsp;
                                    <asp:Button ID="cmdCancelarAsistencia" Width="100px" runat="server" Text="Cancelar" CssClass="myButton" onclick="cmdCancelarAsistencia_Click"
                                      />
                                  </td>
                                </tr>
                              </table>
                          </div>
                        </td>
                      </tr>
                   
                    <%--  <tr>  
                        <td align="right" style="padding:5px;">
                        <%--  <asp:LinkButton ID="cmdAuditoria" runat="server" CssClass="links" onclick="cmdAuditoria_Click"
                            style="text-decoration:underline;vertical-align:middle;cursor:pointer;" > 
                          <img alt="" src="../App_Themes/consultorio/Agenda/encontrar-busqueda-zoom-icono-6513-16.png"
                            style="vertical-align:middle;border:none;"/>Auditoría </asp:LinkButton>
                          <br />
                        </td>
                      </tr>--%>
                      <tr>  
                        <td align="right" style="padding:5px;">
                          <asp:LinkButton ID="cmdRecitar" runat="server" CssClass="links" onclick="cmdRecitar_Click"
                            style="text-decoration:underline;vertical-align:middle;cursor:pointer;" > 
                       Recitar</asp:LinkButton>
                          <br />
                        </td>
                      </tr>
                      <tr>
                        <td align="right" style="padding:5px;">
                          <asp:LinkButton ID="cmdLiberar" runat="server" CssClass="links" onclick="cmdLiberar_Click"
                            style="text-decoration:underline;vertical-align:middle;cursor:pointer;"> 
                       Liberar turno </asp:LinkButton>
                          <br />
                        </td>
                      </tr>
                      <tr>
                        <td align="right" style="padding:5px;">
                          <asp:LinkButton ID="cmdSuspender" runat="server" CssClass="links" onclick="cmdSuspender_Click"
                            style="text-decoration:underline;vertical-align:middle;cursor:pointer;">
                        Liberar y eliminar horario </asp:LinkButton>
                        </td>
                      </tr>
                      
                      
                       <tr>
                        <td align="right" style="padding:5px;">
                          <asp:LinkButton ID="cmdBloquear" runat="server" CssClass="links" Text="Bloquear" onclick="cmdBloquear_Click"
                            style="text-decoration:underline;vertical-align:middle;cursor:pointer;"/>
                      
                        </td>
                      </tr>
                      
                      
                      <tr>
                        <td align="center" >
                          <div id="divConfirma" runat="server" visible="false" style="width:180px; height:100px; border:dotted 1px Maroon; overflow:auto; background-color:#F1E2BB;">
                           
                            <div style="float:left; text-align:left; ">
                              <asp:Label ID="lblConfirma" runat="server" class="labelerror" style="font-weight:bolder;"></asp:Label>
                              <input type="hidden" id="inpConfirma" runat="server" value="" />
                            </div>
                            <div style="text-align:center;width:100%;">
                              <asp:Button ID="cmdSi" runat="server" Text="Si" CssClass="boxcortos" 
                                 onclick="cmdSi_Click" style="text-align:center;" /> &nbsp;
                              <asp:Button ID="cmdNo" runat="server" Text="No" CssClass="boxcortos" 
                                style="text-align:center;" onclick="cmdNo_Click"/>
                            </div>
                          </div>
                          
                          <div id="divError" runat="server" visible="false" style="width:180px; height:80px; border:dotted 1px Maroon;  background-color:#F1E2BB; overflow:auto;">
                           
                            <div style="float:left; text-align:left; ">
                              <b class="labelerror" style="font-weight:bolder;">Ya ha sido confirmada la asistencia para el turno seleccionado. Imposible continuar</b>
                            </div>
                          </div>
                        </td>
                      </tr>
                    </table>
                  </div>                  
                </div>
              </asp:Panel> 
              
             
            </div>                 
          </div>
        </ContentTemplate>
      </asp:UpdatePanel>
    </div>  
    
  </div>
</asp:Content>


