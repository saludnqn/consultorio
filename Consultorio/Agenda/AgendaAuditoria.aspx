<%@ Page Title="" Language="C#" MasterPageFile="~/mConsultorio.Master" AutoEventWireup="true" CodeBehind="AgendaAuditoria.aspx.cs" Inherits="Consultorio.Agenda.AgendaAuditoria" UICulture="es" Culture="es-AR"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<%@ Register Assembly="Subsonic" Namespace="SubSonic" TagPrefix="subsonic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">

    <ajx:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
    EnableScriptLocalization="true">
  </ajx:ToolkitScriptManager>
  
  <div class="div_exterior">
    <div class="div_izquierdo20" style="width:25%; background:#DCE4F9; position:relative; padding-top:0;">
      <asp:UpdatePanel ID="updfiltro" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional" >
        <ContentTemplate>
          <div class="AcordeonContenido" style="overflow:hidden; height:99%;">
            <div class="AcordeonEncabezado" style="background-image:none; margin:0px;">
                <b style="font-weight:bolder;">Filtro de Búsqueda</b>
            </div>
            
            <div id="divfiltro" runat="server" visible="true" class="AcordeonContenido" >
              <asp:Panel ID="pnlFiltro" runat="server" >
                <div>
                  <div class="div_izquierdo50" style="text-align:right; width:45%;"><b class="titulito">N° Agenda:<b></div>
                  <div class="div_derecho50">
                    <asp:TextBox ID="txtAgenda" runat="server" CssClass="myTexto" Width="100%" ></asp:TextBox>
                  </div><br /><br />
                  <div class="div_izquierdo50" style="text-align:right; width:45%;"><b class="titulito">Servicio:<b></div>
                  <div class="div_derecho50"><asp:DropDownList ID="ddlServicios" runat="server" CssClass="myTexto" Width="100%">
                    </asp:DropDownList></div><br /><br /> 
                  <div class="div_izquierdo50" style="text-align:right; width:45%;"><b class="titulito">Especialidad:</b></div>
                  <div class="div_derecho50"><asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="myTexto" Width="100%">
                    </asp:DropDownList></div><br /><br />
                  <div class="div_izquierdo50" style="text-align:right; width:45%;"><b class="titulito">Tipo de consultorio:</b></div>
                  <div class="div_derecho50"><asp:DropDownList ID="ddlTipoCons" runat="server" CssClass="myTexto" Width="100%">
                    </asp:DropDownList></div><br /><br />
                  <div class="div_izquierdo50" style="text-align:right; width:45%;"><b class="titulito">Profesional:</b></div>
                  <div class="div_derecho50"><asp:DropDownList ID="ddlProfesional" runat="server" CssClass="myTexto" Width="100%">
                    </asp:DropDownList></div><br /><br />
                  <div class="div_izquierdo50" style="text-align:right; width:45%;"><b class="titulito">Agendas desde:</b></div>
                  <div class="div_derecho50"><asp:TextBox ID="txtDesde" runat="server" CssClass="myTexto" Width="100%">
                  </asp:TextBox>
                  <ajx:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDesde" CssClass="cal_Theme1" 
                    FirstDayOfWeek="Monday" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy" PopupPosition="BottomRight" >
                  </ajx:CalendarExtender></div><br /><br />
                  <div class="div_izquierdo50" style="text-align:right; width:45%;"><b class="titulito">Agendas hasta:</b></div>
                  <div class="div_derecho50" style="position:relative;">
                    <asp:TextBox ID="txtHasta" runat="server" CssClass="myTexto" Width="100%"></asp:TextBox>
                  </div>
                  <ajx:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtHasta"  CssClass="cal_Theme1"
                    FirstDayOfWeek="Monday" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy" PopupPosition="BottomRight" ></ajx:CalendarExtender>
                  <br /><br />
                </div>
                <div style="width:100%;">
                  <asp:Button ID="btnActualizar" runat="server" Text=" Buscar agendas" CssClass="myButtonRojo"
                    style="float:right; margin-right:5px; width:130px; background-image: url('../App_Themes/consultorio/Agenda/turnorecitado.png'); background-repeat: no-repeat" />
                </div>
                <br /><br />
                <div style="width:100%;">
                  <asp:HyperLink ID="lnkNuevaAgenda" runat="server" CssClass="myLink" style="float:right; margin-right:5px;" 
                    NavigateUrl="~/Consultorio/Agenda/AgendaPorEspacio.aspx" ToolTip="Click para generar nuevas agendas">
                    <img src="../App_Themes/consultorio/Agenda/reiniciar.png" alt="" style="vertical-align:middle;border:none;" />
                    Nueva Agenda</asp:HyperLink>
                </div>
                
                <br /><br />
                
                <div id="divMsg" runat="server" class="div_infoizquierdo" style="background-image:none; height:150px;" visible="false" >
                  <asp:Label ID="lblMsg" runat="server" Text="" CssClass="labelerror" style="font-weight:bolder;"></asp:Label> 
                </div>      
              </asp:Panel>      
            </div>
          </div>
        </ContentTemplate>
      </asp:UpdatePanel>
    </div>
    
    <div id="divderecho" class="div_derecho80" style="height:100%; width:75%; position:relative;">
      <asp:UpdatePanel ID="updLista" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate> 
          
          <asp:Button ID="btnPopup" runat="server" Text="btnPopup" style="display:none;" />
          <ajx:ModalPopupExtender ID="mPopup" runat="server" TargetControlID="btnPopup" 
            OkControlID="btnCerrarPopup" PopupControlID="divPopup">
          </ajx:ModalPopupExtender>                 
            
          <div id="divLista" runat="server" class="div_contenido" style="border:solid 3px Silver; width:99%;">
            <asp:DataList ID="dtAgendas" runat="server" CellPadding="4" ForeColor="#333333" 
                RepeatColumns="1" ItemStyle-HorizontalAlign="Left" width="98%" >
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <ItemTemplate>
                    <div id="encabezadoagenda" class="div_encabezado" runat="server" style="background:#DCE4F9;">
                      <div id="Div1" class="div_encabezado" runat="server" style="background:White;">
                        <div class="div_izquierdo50" style="width:49%; ">
                          <div class="div_izquierdo20" style="position:relative;">
                            <span id="cal" runat="server" class='<%# "cal m" + Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "fecha")).Month.ToString() 
                                                          + " d" + Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "fecha")).Day.ToString()%>'>
                              <span class="m"><%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "fecha")).Month %></span>
                              <span class="d"><%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "fecha")).Day.ToString()%></span>
                            </span>
                            <div style="width:100%;">
                              <asp:HyperLink ID="lnkEditAgenda" runat="server" CssClass="myLittleLink" style="float:left;margin-top:10px;"
                                NavigateUrl='<%# "AgendaEdit.aspx?idAgenda=" + DataBinder.Eval(Container.DataItem, "idAgenda")%>'>
                                <img alt="" src="../App_Themes/consultorio/Agenda/oficina-icono-9743-16.png" 
                                style="vertical-align:bottom;border:none; " />edición
                              </asp:HyperLink>
                              <asp:LinkButton ID="lnkTurnos" runat="server" CommandName="cmdTurnos"
                                style="text-decoration:underline; float:left;margin-top:10px;" > 
                                <asp:ImageButton ID="CmdTurnos" runat="server" ImageUrl="~/App_Themes/consultorio/Agenda/buscar2.png"
                                 style="vertical-align:bottom ;" CommandName="cmdTurnos"/>turnos
                              </asp:LinkButton> 
                              <asp:LinkButton ID="lnkAuditoria" runat="server" CommandName="cmdAuditoria" 
                                style="text-decoration:underline;float:left;margin-top:10px;"> 
                                <asp:ImageButton ID="cmdAuditoria" runat="server" ImageUrl="~/App_Themes/consultorio/Agenda/cubo.png"
                                  style="vertical-align:bottom;" CommandName="cmdAuditoria"/>auditoría
                              </asp:LinkButton>
                            </div>
                            <div class="div_izquierdo20" style="position:relative;margin-top:10px;">
                              <asp:Image ID="imgBloqueada" runat="server" AlternateText="agenda bloqueada" ToolTip="agenda bloqueada"
                                ImageUrl="../App_Themes/consultorio/Agenda/candado32.png" />
                            </div>
                          </div>
                          <div class="div_derecho80" style="background-color:Transparent;height:175px;padding-top:5px;">
                            <div style="width:100%; float:left;position:relative;">
                              <b class="labelencabezado" >
                                Agenda N° <%# DataBinder.Eval(Container.DataItem, "idAgenda") %></b><br />
                            </div>
                            <ul style="list-style-position: outside; list-style-type:square;left:-10px;position:relative; " >
                              <li>
                                <b class="labeldatos">Fecha: 
                                <%# ' ' + DalSic.Rutinas.getNombreDia(Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "fecha"))) %>
                                <%# DataBinder.Eval(Container.DataItem, "fecha").ToString().Substring(0,10) %></b>
                              </li>
                              <li>
                                <b class="labeldatos">Profesional: 
                                <%# DataBinder.Eval(Container.DataItem, "profesional") %></b>
                              </li>
                              <li>
                                <b class="labeldatos">Especialidad: 
                                <%# DataBinder.Eval(Container.DataItem, "especialidad") %></b>
                              </li>
                              <li>
                                <b class="labeldatos">Servicio: 
                                <%# DataBinder.Eval(Container.DataItem, "servicio") %></b>
                              </li>
                              <li>
                                <b class="labeldatos">Tipo de consultorio: 
                                <%# DataBinder.Eval(Container.DataItem, "tipoConsultorio") %> </b>
                              </li>
                              <li>
                                <b class="labeldatos">Consultorio:
                                <%# DataBinder.Eval(Container.DataItem, "consultorio") %></b>
                              </li>
                              <li>
                                <b class="labeldatos">Estado:
                                <%# DataBinder.Eval(Container.DataItem, "Estado") %></b>
                              </li>
                              <li id="lstBloqueo" runat="server" visible="true">
                                <b class="labeldatos">Activacion: </b> &nbsp;
                                <asp:Label ID="lblBloqueo" runat="server" Text="01/01/1900" CssClass="labeldatos"></asp:Label>
                              </li>
                            </ul>
                          </div>
                        </div>
                        
                        <div class="div_derechoInfo" style="background-color:#F1E2BB; width:49%;">
                          <div style="width:100%; text-align:left; height:inherit;">
                            <h2 style="padding: 10px 0 8px 10px;">Parametros de grabado de agenda n° <%# DataBinder.Eval(Container.DataItem, "idAgenda") %></h2>
                            <ul class="titulito" style="list-style-position: outside; list-style-type:disc;">
                              <li style="padding-bottom:5px; font-weight:bold;">
                                hora de inicio del consultorio:
                                <b class="labeldatos">
                                <%# DataBinder.Eval(Container.DataItem, "hIni") %> hs.</b>
                              </li>
                              <li style="padding-bottom:5px; font-weight:bold;">
                                hora de cierre del consultorio:
                                <b class="labeldatos">
                                <%# DataBinder.Eval(Container.DataItem, "hFin") %> hs.</b>
                              </li>
                              <li style="padding-bottom:5px; font-weight:bold;">
                                duracion del turno expresado en minutos:
                                <b class="labeldatos">
                                <%# DataBinder.Eval(Container.DataItem, "duracion") %> mins.</b>
                              </li>                            
                              <li style="padding-bottom:5px; font-weight:bold;">
                                máxima cantidad permitida de sobreturnos:
                                <b class="labeldatos">
                                <%# DataBinder.Eval(Container.DataItem, "MaxSbts")%></b>
                              </li>
                              <li style="padding-bottom:5px; font-weight:bold;">
                                máxima cantidad permitida de turnos reservados:
                                <b class="labeldatos">
                                <%# DataBinder.Eval(Container.DataItem, "reservados")%></b>
                              </li>
                              <li style="padding-bottom:5px; font-weight:bold;">
                                cantidad de turnos para interconsulta:  
                                <b class="labeldatos">
                                <%# DataBinder.Eval(Container.DataItem, "cantidadInterconsulta")%></b>
                              </li>
                              <li style="padding-bottom:5px; font-weight:bold;">
                                cantidad de pacientes a citar por bloque:
                                <b class="labeldatos">
                                <%# DataBinder.Eval(Container.DataItem, "Bloques")%></b>
                              </li>
                            </ul>
                          </div>
                        </div>
                      </div>
                    </div>
                </ItemTemplate> 
              </asp:DataList>         
          </div>
          
          <div id="divPopup" runat="server" style="display:none; width:430px; background-color:Silver; height:auto; border:solid 1px">
            <div class="div_encabezado">
              <h3>Turnos contenidos en agenda n°</h3>
            </div>
            <br />
            <div style="width:380px; height:350px; overflow:auto; background-color:White;">
              <asp:GridView ID="gvTurnos" runat="server" EmptyDataText="La agenda no contiene turnos programados"
                AutoGenerateColumns="False" CellPadding="4" CssClass="grid" 
                DataKeyNames="idTurno" ForeColor="#333333" GridLines="None"
                ShowFooter="True" Width="95%" >
                <PagerStyle Font-Bold="True" Font-Underline="True" HorizontalAlign="Center" />
                <PagerSettings LastPageText="&gt;&gt;" PageButtonCount="4" />
                <HeaderStyle CssClass="grillabarraHeader" ForeColor="Navy" />
                <RowStyle CssClass="grfila" />
                <Columns>
                  <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                      <asp:Image ID="imgTurno" runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                  <asp:BoundField DataField="Hora" HeaderText=" Hora" Visible="true">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                  </asp:BoundField>
                  <asp:BoundField DataField="DNI" HeaderText="DNI" Visible="true">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                  </asp:BoundField>
                  <asp:BoundField DataField="HC" HeaderText="HC" Visible="true">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                  </asp:BoundField>
                  <asp:BoundField DataField="Paciente" Visible="true" HeaderText="Paciente" />               
                </Columns>
                <SelectedRowStyle CssClass="grfilaseleccionada" />
                <AlternatingRowStyle CssClass="grfilaalterna" />
              </asp:GridView>
              <br />
            </div>
            
            <br />
            
            <div style="width:100%; text-align:center;">
              <div class="div_izquierdo50">
                <asp:HyperLink ID="lnkAdminTurnos" runat="server" NavigateUrl="#">administracion de turnos</asp:HyperLink>
              </div>
              <div class="div_derecho50">
                <asp:Button ID="btnCerrarPopup" runat="server" Text="Cerrar" CssClass="myButtonRojo" />
              </div>
            </div>
          </div>
        </ContentTemplate> 
      </asp:UpdatePanel>   
    </div>
  </div>
</asp:Content>
