<%@ Page Title="" Language="C#" MasterPageFile="~/mConsultorio.Master" AutoEventWireup="true" CodeBehind="TurnosAdminBusqueda.aspx.cs" Inherits="Consultorio.Turnos.TurnosAdminBusqueda" %>

<%@ Register Assembly="MagicAjax" Namespace="MagicAjax.UI.Controls" TagPrefix="ajax" %>
<%@ Register Assembly="Subsonic" Namespace="SubSonic" TagPrefix="subsonic" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
    <link type="text/css" rel="stylesheet" href="../../js/jquery-ui-1.7.1.custom.css" />
</asp:Content >
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">  
    
  <script type="text/javascript" src="../../js/jquery.min.js"></script>
  <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>
  <script type="text/javascript" src="../../js/jquery.ui.datepicker-es.js"></script>
  <script type="text/javascript" src="../../js/Mascara.js"></script>
  <script type="text/javascript" src="../../js/ValidaFecha.js"></script>
  <script type="text/javascript">
    $(function() {
      $("#<%=txtFecha.ClientID %>").datepicker({
          showOn: 'button',
          dateFormat: 'dd/mm/yy',
        buttonImage: '../../App_Themes/default/img/calendar.png',
        buttonImageOnly: true
        
      });
    });
  </script> 
  
  <h1>
    <asp:Label ID="lblTitulo" runat="server" Text="Defina tipo de búsqueda" width="100%" CssClass="myTextoTitulo" > </asp:Label>
  </h1>
  <br /><br />
        
  <ul id="acc">  
    <li>
        <h3>Busqueda de Turnos por Paciente</h3>
        <div class="acc-section">
            <div class="acc-content">
                  <ajax:AjaxPanel runat="server" Width="100%" ID="pnlPaciente">
                      <table width="100%">
                        <tr><td></td></tr>
                        <tr class="fila">
                          <td style="vertical-align: top">
                              <div class= "left_content">
                                  <div class="services_block">
                                    <img src="../../App_Themes/consultorio/principal/images/Calendar.png" height="32px"
                                      title="" border="0" class="icon_left" width="32px" alt=""/>
                                    <div class="services_details">                                      
                                      <p>Número de Documento</p>
                                      <asp:TextBox ID="txtDNI" runat="server" CssClass="myTexto" onblur="javascript:valNumeroSinPunto(this)"></asp:TextBox>
                                      
                                      <p>Número de historia clínica</p>
                                      <asp:TextBox ID="txtHC" runat="server" CssClass="myTexto" onblur="javascript:valNumeroSinPunto(this)"></asp:TextBox>
                                      
                                      <p>Apellidos</p>
                                      <asp:TextBox ID="txtApellido" runat="server" CssClass="myTexto"></asp:TextBox>
                                      
                                      <p>Nombres</p>
                                      <asp:TextBox ID="txtNombre" runat="server" CssClass="myTexto"></asp:TextBox>
                                      
                                      <p></p>
                                      <hr class="linea"/>
                                      <p>
                                        <asp:CustomValidator ID="CustomValidator1" runat="server" 
                                          ErrorMessage="* Proporcione antes parámetro de búsqueda" 
                                          ValidationGroup="gr1" onservervalidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                                      </p>
                                    </div>
                                    <div class="left_content">
                                      <asp:Button ID="btnBuscarPaciente" runat="server" CssClass="myButtonGris" 
                                        Text="Buscar paciente" Width="144px" ValidationGroup="gr1" 
                                        onclick="btnBuscarPaciente_Click" />
                                    </div>
                                  </div>
                                  <br />
                                  <br />
                              </div> 
                          </td>
                        </tr>
                        <tr>
                          <td>
                            <br />
                            <div id="resultados" runat="server" visible="false">
                              <h2>Seleccione paciente</h2>
                              <asp:GridView ID="gvPacientes" CssClass="GridSt1" runat="server" DataKeyNames="idPaciente" 
                                AutoGenerateColumns="False"
                                
                                EmptyDataText="No se encontraron pacientes coincidentes con criterio de búsqueda" 
                                AllowPaging="True" onrowcommand="gvPacientes_RowCommand" 
                                onrowdatabound="gvPacientes_RowDataBound" PageSize="12" >     
                                  <Columns>
                                      <asp:BoundField DataField="historiaClinica" HeaderText="HC" />
                                      <asp:BoundField DataField="numeroDocumento" HeaderText="DNI" />
                                      <asp:BoundField DataField="apellido" HeaderText="Apellido" />
                                      <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                                      <asp:BoundField DataField="sexo" HeaderText="Sexo" />
                                      <asp:BoundField DataField="fechaNacimiento" DataFormatString="{0:dd/MM/yyy}" HeaderText="Fec.Nac" />
                                      <asp:TemplateField>
                                        <ItemTemplate>
                                          <asp:ImageButton ID="cmdSel" runat="server" ImageUrl="../../App_Themes/consultorio/Agenda/bntLargo.png" CommandName="cmdSel" />
                                        </ItemTemplate>                                                            
                                        <ItemStyle HorizontalAlign="Center" />
                                      </asp:TemplateField>
                                  </Columns>
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle CssClass="GridHeader" />
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#7C6F57" />
                                <RowStyle CssClass="GridRow" />
                                <AlternatingRowStyle CssClass="GridAlternateRow" />
                              </asp:GridView>
                            </div>  
                          </td>
                        </tr>
                        <tr><td></td></tr>
                    </table>
                  </ajax:AjaxPanel>
            </div>
        </div>
     </li>
    
    <li>
        <h3>Busqueda de Turnos por Parametros de Agenda</h3>
        <div class="acc-section">
            <div class="acc-content">
              <ajax:AjaxPanel runat="server" Width="100%" ID="pnlParametros">
                  <table width="100%">
                    <tr><td></td></tr>
                    <tr>
                      <td style="vertical-align: top">
                          <div class= "left_content">
                              <div class="services_block">
                                <img src="../../App_Themes/consultorio/principal/images/Calendar.png" height="32px"
                                  title="" border="0" class="icon_left" width="32px" alt=""/>
                                <div class="services_details">                         
                                  <p>Desde fecha:</p>
                                  <input id="txtFecha" type="text" runat="server" onblur="valFecha(this)" class="myTexto"
                                    onkeyup="mascara(this,'/',patron,true)" title="Ingrese la fecha de inicio" />
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ControlToValidate="txtFecha" ErrorMessage="* Dato requerido" 
                                    ValidationGroup="gr2"></asp:RequiredFieldValidator>
                                             
                                  <p>Servicio</p>
                                  <subsonic:DropDown ID="ddlServicio" runat="server" PromptText="--Seleccione--" ShowPrompt="true" 
                                    TableName="Sys_Servicio" TextField="nombre" CssClass="myList"
                                    ValidationGroup="gr2"></subsonic:DropDown>
                                  &nbsp;
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="ddlServicio" ErrorMessage="* Dato requerido" 
                                    ValidationGroup="gr2"></asp:RequiredFieldValidator>
                                  
                                  <p>Especialidad</p>
                                  <subsonic:DropDown ID="ddlEspecialidad" runat="server" 
                                    PromptText="--Seleccione--" ShowPrompt="true" 
                                    TableName="Sys_Especialidad" TextField="nombre" CssClass="myList" 
                                    ValidationGroup="gr2"></subsonic:DropDown>
                                  &nbsp;
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="ddlEspecialidad" ErrorMessage="* Dato requerido" 
                                    ValidationGroup="gr2"></asp:RequiredFieldValidator>
                                  
                                  <p>Profesional</p>
                                  <subsonic:DropDown ID="ddlProfesional" runat="server" 
                                    PromptText="--Seleccione--" ShowPrompt="true" 
                                    TableName="Sys_Profesional" TextField="ApellidoyNombre" 
                                    CssClass="myList" ></subsonic:DropDown>
                                                                   
                                  <p></p>
                                  <hr class="linea"/>
                                  <p></p>
                                </div>
                                
                                <div class="left_content" >
                                  <asp:Button ID="btnParametros" runat="server" CssClass="myButtonGris" 
                                    Text="Buscar Agendas" Width="144px" ValidationGroup="gr2" 
                                    onclick="btnParametros_Click" />
                                </div>
                              </div>
                              <br />
                              <br />
                          </div> 
                      </td>
                    </tr>
                    <tr>
                      <td >
                        <br />
                        <div id="resultadosAgenda" runat="server" visible="false">
                          <asp:GridView ID="gvAgendas" runat="server" CssClass="GridSt1" DataKeyNames="idAgendaDetalle"
                            AutoGenerateColumns="False" 
                            EmptyDataText="No se encontraron agendas coincidentes con criterio de búsqueda" 
                            onrowcommand="gvAgendas_RowCommand" onrowdatabound="gvAgendas_RowDataBound" >
                            <RowStyle CssClass="GridRow" />
                            <Columns>
                              <asp:BoundField DataField="idAgendaDetalle" HeaderText="N° Agenda" />
                              <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                              <asp:BoundField DataField="hIni" HeaderText="Hora inicio" />
                              <asp:BoundField DataField="hFin" HeaderText="Hora fin" />
                              <asp:BoundField DataField="Consultorio" HeaderText="Consultorio" />
                              <asp:BoundField DataField="Estado" HeaderText="Estado agenda"/>
                              <asp:BoundField DataField="Profesional" HeaderText="Profesional" />
                              <asp:TemplateField>
                                <ItemTemplate>
                                  <asp:ImageButton ID="cmdSel" runat="server" ImageUrl="../../App_Themes/consultorio/Agenda/bntLargo.png" CommandName="cmdSel" />
                                </ItemTemplate>                                                            
                                <ItemStyle HorizontalAlign="Center" />
                              </asp:TemplateField>
                            </Columns>
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle CssClass="GridHeader" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <RowStyle CssClass="GridRow" />
                            <AlternatingRowStyle CssClass="GridAlternateRow" />
                          </asp:GridView>
                        </div>  
                      </td>
                    </tr>
                  </table>  
              </ajax:AjaxPanel>
            </div>
        </div>
    </li>
    
    <li>
        <h3>Busqueda de Turnos por Número de Agenda</h3>
        <div class="acc-section">
            <div class="acc-content">
                <ajax:AjaxPanel runat="server" Width="100%" ID="pnlAgenda">
                  <table width="100%">
                    <tr><td></td></tr>
                    <tr class="fila">
                      <td style="vertical-align: top">
                          <div class= "left_content">
                              <div class="services_block">
                                <img src="../../App_Themes/consultorio/principal/images/Calendar.png" height="32px"
                                  title="" border="0" class="icon_left" width="32px" alt=""/>
                                <div class="services_details">
                                  <h2><a href="#" target="_parent">Indique número de Agenda</a></h2>
                                  
                                  <p>Número</p>
                                  <asp:TextBox ID="txtAgenda" runat="server" CssClass="myTexto"  onblur="javascript:valNumeroSinPunto(this)"
                                    ValidationGroup="gr3"></asp:TextBox>
                                  
                                  &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="txtAgenda" ErrorMessage="* Dato requerido" 
                                    ValidationGroup="gr3"></asp:RequiredFieldValidator>
                                  
                                  <p></p>
                                  <hr class="linea"/>
                                  <p></p>
                                </div>
                                <div class="left_content">
                                  <asp:Button ID="btnAgenda" runat="server" CssClass="myButtonGris" 
                                    Text="Buscar turnos contenidos" Width="144px" ValidationGroup="gr3" 
                                    onclick="btnAgenda_Click" />
                                </div>
                              </div>
                              <br />
                              <br />
                          </div> 
                      </td>
                    </tr>
                  </table>  
                </ajax:AjaxPanel>
            </div>
        </div>
    </li>
  </ul>
 
  <script type="text/javascript" src="../../js/scriptAcordion.js"></script>
  <script language="javascript" type="text/javascript">
    var parentAccordion = new TINY.accordion.slider("parentAccordion");
    parentAccordion.init("acc", "h3", false, 0);
  </script>
</asp:Content>
