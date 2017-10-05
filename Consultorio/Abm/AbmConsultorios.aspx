<%@ Page Title="" Language="C#" MasterPageFile="~/mConsultorio.Master" AutoEventWireup="true" CodeBehind="AbmConsultorios.aspx.cs" Inherits="Consultorio.Abm.AbmConsultorios" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<%@ Register Assembly="Subsonic" Namespace="SubSonic" TagPrefix="subsonic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link href="../Turnos.css" rel="stylesheet" type="text/css" /><link type="text/css" rel="stylesheet" href="../js/jquery-ui-1.7.1.custom.css" />
  <script type="text/javascript" src="../js/jquery.min.js"></script>
  <script type="text/javascript" src="../js/jquery-ui.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">
<br />
  
  <br />
  <br />
  <br />
  <ajx:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptLocalization="true" EnableScriptGlobalization="true" >
  </ajx:ToolkitScriptManager>
  
  <!-- capa externa !-->
  <div class="div_exterior">    
    <asp:Panel ID="pnlDerecho" runat="server" CssClass="encabezadoagenda" style="width:70%; height:100%; padding:0; background:#FAFAFA;">
      <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>
          <!-- encabezado !-->
          <div class="encabezadoagenda" >
            <div style="float:left; padding-top:5px; padding-left:5px;">
              <b style="padding: 5px 0 2px; color:#DCE4F9; font-size:large; font-weight:bolder; vertical-align:top; text-align:left;">
              Tipos de Consultorios</b> &nbsp;
              <asp:DropDownList ID="ddlTipoConsultorio" runat="server" AutoPostBack="true" 
                onselectedindexchanged="ddlTipoConsultorio_SelectedIndexChanged"></asp:DropDownList>
              &nbsp;&nbsp;
              <asp:Button ID="cmdEliminar" runat="server" Text="Eliminar" ToolTip="Eliminar el tipo de consultorio seleccionado" />
              <asp:Button ID="cmdRenombrar" runat="server" Text="Renombrar" ToolTip="Cambiar el nombre del tipo de consultorio seleccionado"/>
              <asp:Button ID="cmdNuevoTipo" runat="server" Text="Nuevo tipo" ToolTip="Crear nuevo tipo de consultorios" onclick="cmdNuevoTipo_Click" />              
              <asp:Button ID="cmdNuevo" runat="server" Text="Nuevo consultorio" ToolTip="Crear nuevo consultorio para el tipo seleccionado" />  
              &nbsp;
            </div>
          </div>
          <!-- columna izquierda !-->
          <div class="encabezadoagenda" > 
            <!-- listado de consultorios contenidos !-->
            <div id ="divGrilla" runat="server" style="width:95%; height:85%; overflow:auto; margin-top:10px; margin-bottom:5px;">
              <asp:GridView ID="gvConsultorios" runat="server" AutoGenerateColumns="False" 
                CellPadding="20" CssClass="grid" style="padding-top:5px;padding-bottom:5px;"
                DataKeyNames="idConsultorio" ForeColor="#333333" GridLines="None"
                EmptyDataText="El tipo de consultorios seleccionado no contiene consultorios asociados" 
                EmptyDataRowStyle-CssClass="grillabarraHeader" >
                <PagerStyle Font-Bold="True" Font-Underline="True" HorizontalAlign="Center" />
                <PagerSettings LastPageText="&gt;&gt;" PageButtonCount="4" />
                <HeaderStyle CssClass="grillabarraHeader" />
                <RowStyle CssClass="grfila" />
                <Columns>
                  <asp:BoundField DataField="idConsultorio" HeaderText="ID" Visible="true">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Justify" />
                  </asp:BoundField>
                  <asp:BoundField DataField="nombre" HeaderText="Nombre descriptivo" Visible="true">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Justify" />
                  </asp:BoundField>
                  <asp:BoundField DataField="Activo" HeaderText="Activo" Visible="true">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Justify" />
                  </asp:BoundField>
                  <asp:TemplateField >
                    <ItemTemplate>
                      <asp:ImageButton ID="cmdRenombrar" runat="server" CommandName="cmdRenombrar" AlternateText="Renombrar" ToolTip="Cambiar nombre" ImageUrl="~/App_Themes/consultorio/Agenda/editar-el-texto-icono-3973-32.png" />
                      &nbsp;
                      <asp:ImageButton ID="cmdActivar" runat="server" CommandName="cmdActivar" AlternateText="Activar/desactivar" ToolTip="Activar/desactivar consultorio" ImageUrl="~/App_Themes/consultorio/Agenda/alerta32.png" />
                      &nbsp;
                      <asp:ImageButton ID="cmdEliminar" runat="server" CommandName="cmdEliminar" AlternateText="Eliminar" ToolTip="Eliminar consultorio" ImageUrl="~/App_Themes/consultorio/Agenda/boton-de-error-icono-5371-32.png" />
                    </ItemTemplate>                                                            
                    <ItemStyle HorizontalAlign="Right" />
                  </asp:TemplateField>                
                </Columns>
                <SelectedRowStyle CssClass="grfilaseleccionada" ForeColor="White"/>
                <AlternatingRowStyle CssClass="grfilaalterna" />
              </asp:GridView>
            </div>
          </div>
                   
          <div>
            <asp:Button ID="btnShowMsg" runat="server" Text="btnPopup" visible="false"/>
            <ajx:ModalPopupExtender ID="mPopupMsg" runat="server" PopupControlID="msgBox" TargetControlID="btnShowMsg"
              OkControlID="btnMsgAceptar" CancelControlID="btnMsgCancelar" BackgroundCssClass="modalPanelFijo" >
            </ajx:ModalPopupExtender>
            
            <div id="msgBox" runat="server" class="modalPanelFijo" style="height:auto; width:auto; visibility:hidden;" >
              <div id="Div1" class="div_encabezado" runat="server" style="background: White;">
                <asp:Label ID="lblPopup" runat="server" CssClass="labeldatos" Width="100%" Style="height: auto;"></asp:Label>
                <br />
                <input id="btnMsgAceptar" type="button" value="Aceptar" />
                <input id="btnMsgCancelar" type="button" value="Cancelar" />
              </div>
            </div>
          
          </div>
          
        </ContentTemplate>
      </asp:UpdatePanel>
    </asp:Panel>
  </div>
</asp:Content>