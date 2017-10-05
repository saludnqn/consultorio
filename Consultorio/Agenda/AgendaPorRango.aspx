<%@ Page Title="" Language="C#" MasterPageFile="~/mConsultorio.Master" AutoEventWireup="true" CodeBehind="AgendaPorRango.aspx.cs" Inherits="Consultorio.Agenda.AgendaPorRango" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Subsonic" Namespace="SubSonic" TagPrefix="subsonic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="../js/jquery-ui-1.7.1.custom.css" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">  
  
    <script type="text/javascript" src="../js/jquery.min.js"></script>
  <script type="text/javascript" src="../js/jquery-ui.min.js"></script>
  <script type="text/javascript" src="../js/jquery.ui.datepicker-es.js"></script>
  <script type="text/javascript" src="../js/Mascara.js"></script>
  <script type="text/javascript" src="../js/ValidaFecha.js"></script>
  <script type="text/javascript">
    $(function() {
      $("#<%=txtFinicio.ClientID %>").datepicker({
          showOn: 'button',
          dateFormat: 'dd/mm/yy',
        buttonImage: '../App_Themes/default/img/calendar.png',
        buttonImageOnly: true

      });
    });
    
    $(function() {
      $("#<%=txtFfin.ClientID %>").datepicker({
          showOn: 'button',
          dateFormat: 'dd/mm/yy',
        buttonImage: '../App_Themes/default/img/calendar.png',
        buttonImageOnly: true
        
      });
    });
  </script>  
  
  <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
  </asp:ToolkitScriptManager> 
    
  <asp:Accordion ID="Acordeon" runat="server" HeaderCssClass="AcordeonEncabezado" ContentCssClass="AcordeonContenido" 
    FadeTransitions="True" TransitionDuration="100" FramesPerSecond="10">
    <Panes>
      <asp:AccordionPane ID="acordionParametros" runat="server" >
        <Header>Parametros de búsqueda</Header>        
        <Content>
          <div id="divbusqueda" runat="server" visible="true">
            <table width="100%" class="myTabla">
              <tr><td></td></tr>
              <tr class="fila">
                <td align="left" >
                    <div class= "left_content">
                        <div class="services_block">
                          <div class="services_details">                                      
                            <table class="myTabla">
                              <tr>  
                                <td align="left" >
                                  <p><img src="../App_Themes/consultorio/Agenda/cubo.png" style="width: 16px; height: 16px" alt ="" />
                                  Servicio</p>
                                  <subsonic:DropDown ID="ddlServicio" runat="server" TableName="Sys_Servicio" TextField="nombre" ShowPrompt="true" 
                                     ValidationGroup="gr1" PromptText="--Seleccione--" PromptValue="0" CssClass="myList"></subsonic:DropDown>
                                </td>
                                <td align="left" >
                                  <p><img src="../App_Themes/Consultorio/Agenda/grupo.png" style="width: 16px; height: 16px" alt =""/>
                                  Especialidad</p>
                                  <subsonic:DropDown ID="ddlEspecialidad" runat="server" TableName="Sys_Especialidad" TextField="nombre" ShowPrompt="true" 
                                     ValidationGroup="gr1" PromptText="--Seleccione--" PromptValue="0" CssClass="myList"></subsonic:DropDown> 
                                </td>
                              </tr>
                              <tr>
                                <td align="left" >
                                  <p><img src="../App_Themes/Consultorio/Agenda/personacorazon.png" style="width: 16px; height: 16px" alt =""/>
                                  Profesional</p>
                                  <subsonic:DropDown ID="ddlProfesional" runat="server" TableName="Sys_Profesional" TextField="NombreCompleto" ShowPrompt="true" 
                                     ValidationGroup="gr1" PromptText="--Seleccione--" PromptValue="0" CssClass="myList"></subsonic:DropDown>
                                </td>
                                <td align="left" >
                                  <p><img src="../App_Themes/Consultorio/Agenda/casa.png" style="width: 16px; height: 16px" alt =""/>
                                  Tipo de consultorios</p>
                                  <subsonic:DropDown ID="ddlTipoConsultorio" runat="server" TableName="Con_ConsultorioTipo" TextField="Nombre" ShowPrompt="true" 
                                     ValidationGroup="gr1" PromptText="--Seleccione--" PromptValue="0" CssClass="myList"></subsonic:DropDown>
                                </td>
                              </tr>
                              <tr>
                                <td align="left" >
                                  <p>Desde</p>
                                  <input id="txtFinicio" type="text" runat="server" onblur="valFecha(this)" onkeyup="mascara(this,'/',patron,true)" title="Ingrese la fecha de inicio"/>
                                </td>
                                <td align="left" >
                                  <p>Hasta</p>
                                   <input id="txtFfin" type="text" runat="server" onblur="valFecha(this)" onkeyup="mascara(this,'/',patron,true)" title="Ingrese la fecha de fin" />
                                </td>
                              </tr>
                            </table>
                            <p></p>
                            <hr class="linea"/>
                            <p>
                              <asp:CustomValidator ID="CustomValidator1" runat="server" 
                                ErrorMessage="* Proporcione antes parámetro de búsqueda" 
                                ValidationGroup="gr1" onservervalidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                            </p>
                          </div>
                          <div class="left_content">
                            <asp:Button ID="btnActualizar" runat="server" CssClass="myButtonGris" 
                              Text="Actualizar calendario" Width="144px" ValidationGroup="gr1" 
                              onclick="btnActualizar_Click" />
                          </div>
                        </div>
                        <br />
                        <br />
                    </div> 
                </td>
              </tr>
              <tr><td></td></tr>
          </table>
          </div>
        </Content>
      </asp:AccordionPane>
      
      <asp:AccordionPane ID="acordionCalendario" runat="server">
        <Header>Calendario</Header>
        <Content>
          <div id="divcalendario" runat="server" visible="false">
            <div id="divinfo" runat="server" visible="false">
              <h1 class="mytituloRelleno">Paquete de agendas grabado correctamente</h1>
            </div>
            <table width="100%">
            <tr class="fila">
              <td align="left" >
                <h3>Sel. rápida<h3>
                <asp:CheckBoxList ID="ChkBList1" runat="server" RepeatDirection="Vertical" AutoPostBack="true" 
                  CssClass="myList" onselectedindexchanged="ChkBList1_SelectedIndexChanged">
                  <asp:ListItem Value="0"> Todos</asp:ListItem>
                  <asp:ListItem Value="1"> Lunes</asp:ListItem>
                  <asp:ListItem Value="2"> Martes</asp:ListItem>
                  <asp:ListItem Value="3"> Miércoles</asp:ListItem>
                  <asp:ListItem Value="4"> Jueves</asp:ListItem>
                  <asp:ListItem Value="5"> Viernes</asp:ListItem>
                  <asp:ListItem Value="6"> Sábado</asp:ListItem>
                  <asp:ListItem Value="7"> Domingo</asp:ListItem>
                </asp:CheckBoxList>
              </td>
              <td align="left" >
                <asp:GridView ID="gvAgendas" CssClass="GridSt1" runat="server" 
                  AutoGenerateColumns="False" Width="100%" DataKeyNames="idAgenda, idConsultorio,idAgendaEstado"
                  EmptyDataText="No se encontraron agendas coincidentes con criterio especificado" 
                  onrowdatabound="gvAgendas_RowDataBound" onrowcommand="gvAgendas_RowCommand"
                  onrowupdating="gvAgendas_RowUpdating" ForeColor="#333333" 
                  GridLines="None"  >
                  <RowStyle BackColor="#E3EAEB" />
                  <Columns>
                    <asp:TemplateField>
                      <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                      </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}"/>
                    <asp:BoundField DataField="hIni" HeaderText="H. Inicio" >
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="hFin" HeaderText="H. Fin" >
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Duracion" HeaderText="Duración" >
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Consultorio" HeaderText="Consul." >
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Bloques" HeaderText="Cit. bloque" >
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="MaxSbts" HeaderText="Max. sbts." >
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Reservados" HeaderText="Reservados" >
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Estado" HeaderText="Estado" >
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Detalles">
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdDetalles" runat="server" CommandName="cmdDetalles" AlternateText="Ver detalles" 
                         ToolTip="Ver detalles de la agenda" ImageUrl="../App_Themes/Consultorio/Agenda/buscar.png" />
                      </ItemTemplate>                                                            
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Duplicar">
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdDuplicar" runat="server" CommandName="cmdDuplicar" AlternateText="Duplicar fecha" 
                          ToolTip="Insertar nuevo registro para la fecha seleccionada" ImageUrl="../App_Themes/Consultorio/Agenda/duplicar.png" />
                      </ItemTemplate>                                                            
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Eliminar">
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdEliminar" runat="server" CommandName="cmdEliminar" AlternateText="Eliminar" ToolTip="Eliminar agenda"
                         OnClientClick="return PreguntoEliminar();" ImageUrl="../App_Themes/Consultorio/Agenda/eliminar.png" />
                      </ItemTemplate>                                                            
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                  </Columns>
                  <HeaderStyle CssClass="GridHeader" />
                  <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                  <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
              </td>
            </tr>
            <tr>
              <td colspan="2" align="right">
                <asp:Button ID="btnEditar" runat="server" CssClass="myButtonGris" Text="Editar opciones" Width="144px" onclick="btnEditar_Click" />
              </td>
            </tr>
          </table>
          </div>
        </Content>
      </asp:AccordionPane>
      
      <asp:AccordionPane ID="acordionOpciones" runat="server">
        <Header>Opciones para fechas seleccionadas</Header>
        <Content>
          <div class="cuardocentrado" >
            <div id="dvencabezado">
              <br />
              <h1 class="mytituloRelleno">Indique hora de inicio y de fin e ingrese duración en minutos para establecer cantidad de turnos</h1>
              <br />
            </div>
            
            <div id="dvcontroles" runat="server" visible="false">
              <table>
                <tr>
                  <td align="left" >
                    <p>Hora de inicio</p>
                    <input id="txtHini" type="text" maxlength="5" runat="server" onblur="javascript:valHora(this);CalcularCantidadTurnos()" 
                      onkeyup="mascara(this,':',patron,true)" title="Ingrese un formato de hora válido" validationgroup="gr3" class="myTexto"/>
                  </td>
                  <td align="left" >
                    <p>Hora de fin</p>
                    <input id="txtHfin" type="text" maxlength="5" runat="server" onblur="javascript:valHora(this);CalcularCantidadTurnos()" 
                      onkeyup="mascara(this,':',patron,true)" title="Ingrese un formato de hora válido" validationgroup="gr3" class="myTexto"/>
                  </td>
                  <td align="left" >
                    <p>Duracion mins.</p>
                    <input id="txtDurac" type="text" runat="server" value="0" validationgroup="gr3"
                      onblur="javascript:valNumeroSinPunto(this);CalcularCantidadTurnos()" class="myTexto" />
                  </td>
                </tr>
                <tr>
                  <td align="left" >
                    <p>Cantidad</p>
                    <input id="txtCantidad" type="text" runat="server" readonly="readonly" value="0" disabled="disabled" validationgroup="gr3" class="myTexto"/>
                  </td>
                  <td align="left" >
                    <p>Cant. por bloques</p>
                    <input id="txtBloque" type="text" runat="server" value ="1" onblur="javascript:valNumeroSinPunto(this)" align="middle" 
                      validationgroup="gr3" class="myTexto"/>
                  </td>
                  <td align="left" >
                    <p>Max. reservados</p>
                    <input id="txtReservados" type="text" runat="server" value ="0" onblur="javascript:valNumeroSinPunto(this)" validationgroup="gr3" class="myTexto"/>
                  </td>     
                </tr>
                <tr>
                  <td align="left" >
                    <p>Max. sobreturnos</p>
                    <input id="txtMaxSbts" type="text" runat="server" value ="0" onblur="javascript:valNumeroSinPunto(this)" validationgroup="gr3" class="myTexto"/>
                  </td>
                  <td align="left" >
                    <p>Consultorio</p>
                    <asp:DropDownList ID="ddlCons" runat="server" ValidationGroup="gr3" CssClass="myList"></asp:DropDownList>
                  </td>
                  <td align="left" >
                    <p>Estado</p>
                    <asp:DropDownList ID="ddlEstadoAgenda" runat="server" ValidationGroup="gr3" CssClass="myList"></asp:DropDownList>
                  </td>
                  <td>
                    
                  </td>
              </tr>
              </table>
            </div>
            
            <div id="validacion">
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtHini" 
                ErrorMessage="* Hora de inicio requerida" ValidationGroup="gr3"></asp:RequiredFieldValidator>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHfin" 
                ErrorMessage="* Hora de fin requerida" ValidationGroup="gr3"></asp:RequiredFieldValidator>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDurac" 
                ErrorMessage="* Duración en minutos requerida" ValidationGroup="gr3"></asp:RequiredFieldValidator>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBloque" 
                ErrorMessage="* Cantidad de pacientes por bloque requerida (deje 1 por defecto)" ValidationGroup="gr3"></asp:RequiredFieldValidator>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtReservados" 
                ErrorMessage="* Cantidad de turnos reservados requerida (deje 0 por defecto)" ValidationGroup="gr3"></asp:RequiredFieldValidator>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMaxSbts" 
                ErrorMessage="* Cantidad máxima de sobreturnos requerida (deje 0 por defecto)" ValidationGroup="gr3"></asp:RequiredFieldValidator>
              <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="* Proporcione antes parámetros de agendas" 
                ValidationGroup="gr3" onservervalidate="CustomValidator3_ServerValidate" ></asp:CustomValidator>
            </div>
            
            <div id="botones">
              <asp:Button ID="btnGrabar" runat="server" Text="Grabar calendario" Width="144px" 
                ValidationGroup="gr3" onclick="btnGrabar_Click" CssClass="myButtonGris" /> &nbsp;
              <asp:Button ID="btnCancelar" runat="server" CssClass="myButtonGris" Text="Cancelar" Width="144px" onclick="btnCancelar_Click" />
            </div>
          </div>
        </Content>
      </asp:AccordionPane>
    </Panes>
  </asp:Accordion>
  
  
  <asp:Panel id="pnlDetalles" runat="server" Visible="false">
    <div id="divdetalles" class="modalPanel">
      <div id="detallesEncabezado">
        <h1 class="mytituloTabla">Detalles de agenda seleccionada</h1>
        <br /><br />
        <div class= "left_content">
          <div class="services_block">
            <div class="services_details">                                      
              <table class="myTabla" width="100%">
                <tr>  
                  <td align="left" >
                    <img src="../App_Themes/consultorio/Agenda/cubo.png" style="width: 16px; height: 16px" alt ="" />
                    Servicio<asp:Label ID="lblServicio" runat="server" Text="" CssClass="myLabelDerechaGde" ></asp:Label>
                  </td>
                </tr>
                <tr>
                  <td align="left" >
                    <img src="../App_Themes/Consultorio/Agenda/grupo.png" style="width: 16px; height: 16px" alt =""/>
                    Especialidad<asp:Label ID="lblEspecialidad" runat="server" Text="" CssClass="myLabelDerechaGde"></asp:Label>
                  </td>
                </tr>
                <tr>
                  <td align="left" >
                    <img src="../App_Themes/Consultorio/Agenda/personacorazon.png" style="width: 16px; height: 16px" alt =""/>
                    Profesional<asp:Label ID="lblProfesional" runat="server" Text="" CssClass="myLabelDerechaGde"></asp:Label>
                  </td>
                </tr>
                <tr>
                  <td align="left" >
                    <img src="../App_Themes/Consultorio/Agenda/casa.png" style="width: 16px; height: 16px" alt =""/>
                    Tipo de consultorios<asp:Label ID="lblTipoConsultorio" runat="server" Text="" CssClass="myLabelDerechaGde"></asp:Label>
                  </td>
                </tr>
              </table>
              <br />
              <br />
            </div>
          </div>
        </div> 
        <hr class="linea"/>
        <br />
      </div>
      
      <div id="detallesturnos">
        <input id="btnEditarTurnos" type="button" value="Editar Turnos" />
        <input id="btnCancelarTurnos" type="button" value="Regresar" />
      </div>
      
      <div id="detallesbotones">
        
      </div>
    </div>
  </asp:Panel>
  
  <script language="javascript" type="text/javascript">    
    function PreguntoEliminar() {
      if (confirm('¿Confirma eliminar la agenda seleccionada?'))
        return true;
      else
        return false;
    }

    function parseDate(input) {
      var parts = input.match(/(\d+)/g);
      return new Date(parts[0], parts[1] - 1, parts[2], parts[3], parts[4]);
    }

    function CalcularCantidadTurnos() {
      try {
        var hIni = document.getElementById('<%=Page.Master.FindControl("ContentPlaceHolderConsultorio").FindControl("Acordeon").FindControl("txtHini").ClientID %>').value;
        var hFin = document.getElementById('<%=Page.Master.FindControl("ContentPlaceHolderConsultorio").FindControl("Acordeon").FindControl("txtHfin").ClientID %>').value;
        var duracion = document.getElementById('<%=Page.Master.FindControl("ContentPlaceHolderConsultorio").FindControl("Acordeon").FindControl("txtDurac").ClientID %>').value;
        if (duracion != '') {
          if (IsNumericSinPunto(duracion)) {
            if (hIni != '') {
              if (hFin != '') {
                var diff = parseDate("1900-01-01 " + hFin) - parseDate("1900-01-01 " + hIni);
                diff = ((diff / 600) / 6000) * 60;
                var cantidadturnos = Math.floor(diff / duracion);
                document.getElementById('<%=Page.Master.FindControl("ContentPlaceHolderConsultorio").FindControl("Acordeon").FindControl("txtCantidad").ClientID %>').value = cantidadturnos;
              }
            }
          }
        }
      } catch(Error) { }
    }
  </script>
</asp:Content>
