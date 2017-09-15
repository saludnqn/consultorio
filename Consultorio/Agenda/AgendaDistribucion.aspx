<%@ Page Title="" Language="C#" MasterPageFile="~/mConsultorio.Master" AutoEventWireup="true" CodeBehind="AgendaDistribucion.aspx.cs" Inherits="Consultorio.Agenda.AgendaDistribucion" UICulture="es" Culture="es-AR"%>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajx" %>
<%@ Register Assembly="Subsonic" Namespace="SubSonic" TagPrefix="subsonic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../App_Themes/consultorio/ical.css" rel="stylesheet" type="text/css" />
    
  <link href="../Turnos.css" rel="stylesheet" type="text/css" />
  
    <link type="text/css" rel="stylesheet" href="../../js/jquery-ui-1.7.1.custom.css" />
  <script type="text/javascript" src="../../js/jquery.min.js"></script>
  <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>
    <script type="text/javascript">

        function printDiv(divName) {
            var printContents = document.getElementById(divName).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">
    <br />
  
 <ajx:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
    EnableScriptLocalization="true">
  </ajx:toolkitscriptmanager>

  <div class="div_exterior" >    
    <asp:UpdatePanel ID="updfiltro" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional" >
      <ContentTemplate>
        <div style="width:100%;  ">  
          <table width="100%" >
            
            <tr>
              <td align="left"  class="mytituloPagina" colspan="5">
                 Ocupación de Consultorios</td>
            </tr>
              <tr>
                  <td align="left" colspan="5">
                   <hr /></td>
              </tr>
            <tr>
              <!-- MENSAJES DE ERROR !-->
              <td align="left" class="myLabelIzquierda">
                Tipo de consultorio: 
                  <asp:DropDownList ID="ddlTipoCons" runat="server" AutoPostBack="True" 
                      CssClass="myTexto" onselectedindexchanged="ddlTipoCons_SelectedIndexChanged">
                  </asp:DropDownList>
                  </b></b>
              </td>
                <td align="left"  class="myLabelIzquierda">
                    Fecha: 
                    <asp:TextBox ID="txtFecha" runat="server" CssClass="myTexto" Width="80px"></asp:TextBox>
                    <asp:ImageButton ID="cmdFecha" runat="server" AlternateText="seleccione fecha" Width="20px" Height="20px"
                        ImageUrl="~/App_Themes/default/img/calendar.png" OnClick="cmdFecha_Click" 
                        ToolTip="Seleccione fecha" />
                    <ajx:CalendarExtender ID="CalendarExtender1" runat="server"
                        CssClass="cal_Theme1" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" 
                        TargetControlID="txtFecha" TodaysDateFormat="dd/MM/yyyy">
                    </ajx:CalendarExtender>
                </td>
                <td  class="myLabelIzquierda">
                  Desde hora: 
                    <asp:DropDownList ID="ddlHini" runat="server" CssClass="myTexto">
                    </asp:DropDownList>
                    </b></b>
                </td>
                <td  class="myLabelIzquierda">
                    Hasta hora: 
                    <asp:DropDownList ID="ddlHfin" runat="server" CssClass="myTexto">
                    </asp:DropDownList>
                    </b></b>
                </td>
              
                <td>
                    <asp:Button ID="btnActualizar" runat="server" CssClass="myButtonRojo" 
                        onclick="btnActualizar_Click" Text=" Actualizar vista" Width="120px" />
                </td>
            </tr>
              <tr>
                  <td align="left" colspan="5">
                     <hr /></td>
              </tr>
              
               <tr>
                  <td align="left" colspan="5">
                  &nbsp; </td>
              </tr>
            <tr>
              <!-- MENSAJES DE ERROR !-->
              <td colspan="5">
                <div id="divMsg" runat="server" class="div_infoizquierdo" style="background-image:none;height:auto;" visible="false" >
                  <div class="div_izquierdo20" style="height:auto;background-color:Transparent;">
                    <asp:Image ID="imgMsg" runat="server" ImageUrl="~/App_Themes/consultorio/Agenda/boton-de-error-icono-5371-32.png" />
                  </div>
                  <div class="div_derecho80" style="height:auto;background-color:Transparent;">
                    <asp:Label ID="lblMsg" runat="server" Text="" CssClass="labelerror" style="font-weight:bolder;width:100%;"></asp:Label> 
                  </div>
                </div>
              </td>
            </tr>

                <tr>
                  <td align="left" colspan="5">                 
                      <input type="button" onclick="printDiv('printableArea')" value="Imprimir Grilla" />
                  </td>
              </tr>
          </table>
          <br />
          <div id="printableArea"  style="width:100%;height:500px;overflow:scroll;">
            <asp:Literal ID="ltrOcupacion" runat="server"></asp:Literal>
          </div>
        

        </div>        
      </ContentTemplate>  
    </asp:UpdatePanel>
  </div> 
</asp:Content>
