<%@ Page Title="" Language="C#" MasterPageFile="~/ConsultaAmbulatoria/MasterPages/Consultorio.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Consultorio.ConsultaAmbulatoria.Default"
    Theme="apr" %>

<%@ MasterType VirtualPath="~/ConsultaAmbulatoria/MasterPages/Consultorio.master" %>

<%@ Register Src="~/ConsultaAmbulatoria/UserControls/ConsultaAmbulatoria.ascx" TagName="ConsultaAmbulatoria"
    TagPrefix="uc1" %>
    
<%@ Register Src="~/ConsultaAmbulatoria/UserControls/Consultas.ascx" TagName="Consultas"
    TagPrefix="uc2" %>   
    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
      $(document).ready(function() {
        // fix for postbacks to show panels
      var selectedTabIndex = $("#<%= selectedtab.ClientID %>").attr('value');
        $('#tabs').tabs({
          // add show tab hook to save currently shown tab.
          show: function() {
            var newIndex = $('#tabs').tabs('option', 'selected');
            $("#<%= selectedtab.ClientID %>").val(newIndex);
          },
          // make sure the correct tab is selected.
          selected: selectedTabIndex
        });
      });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="server">
 <%--   <asp:ScriptManagerProxy runat="server" ID="smp">
        <Scripts>
            <asp:ScriptReference Path="~/js/tooltips/jquery.tools.min.js" />
        </Scripts>
    </asp:ScriptManagerProxy>--%>
    <input type="hidden" value="0" id="selectedtab" name="selectedtab" enableviewstate="true" runat="server" />
    <div id="tabs">
        <ul>
            <li runat="server" id="liConsultorio"><a href="#tabConsultorio">Consultorio</a></li>
            <li runat="server" id="liConsultas"><a href="#tabConsultas">Consultas</a></li>
        </ul>
        <div id="tabConsultorio">
            <uc1:ConsultaAmbulatoria ID="ConsultaAmbulatoria1" runat="server" ></uc1:ConsultaAmbulatoria>
        </div>
        <div id="tabConsultas">
            <uc2:Consultas ID="Consultas" runat="server" ></uc2:Consultas>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="server">
    <asp:Button runat="server" ID="btnVolver" Text="Volver al Paciente" OnClick="btnVolver_Click" />
    <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" />
    <asp:Button runat="server" ID="btnGuardar" Text="Guardar Registro de Consulta" OnClick="btnGuardar_Click" />
</asp:Content>
