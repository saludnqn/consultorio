<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Consultorio.ConsultaAmbulatoria.ControlPerinatal.Parto.Edit" MasterPageFile="~/ConsultaAmbulatoria/MasterPages/ConsultorioPerinatal.Master" Theme="apr" %>

<%@ MasterType VirtualPath="~/ConsultaAmbulatoria/MasterPages/ConsultorioPerinatal.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
       /*.content select{
            display:block !important;
        }*/


    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            // Formatea y desoculta la botonera en caso de necesitarse.
            if ($('#botonera').children().size() > 0) {
                $('#botonera > input').button();
                $('#botonera > a').button();
                $('#botonera').show();
            }
             //Busca y formatea las grillas que haya.
            $('.grilla').dataTable({
                "bJQueryUI": true,
                "oLanguage": {
                    "sSearch": "Buscar:",
                    "sLengthMenu": "Mostrar _MENU_ ítems por página",
                    "sZeroRecords": "No se encontró nada",
                    "sInfo": "Mostrando _START_ a _END_ de _TOTAL_ ítems",
                    "sInfoEmpty": "Mostrando 0 a 0 de 0 ítems",
                    "sInfoFiltered": "(filtrado de _MAX_ ítems totales)"
                },
                "iDisplayLength": 10,
                "aaSorting": [[1, "asc"]],
                "aoColumnDefs": [
			            { "bSortable": false, "aTargets": [0] }
                ]
            });
            // Formatea las cajas de texto
            $('input[type=text]').addClass("ui-widget-content ui-corner-all");
            $('textarea').addClass("ui-widget-content ui-corner-all");
            // Formatea los selects (sólo los chicos, para que no exploten)
            //$('select').filter(function (index) { return ($(this).children().size() < 50); }).selectmenu();
            // Agrega los datepickers (todo campo de texto que incluya "Fecha" en el nombre).
            $.datepicker.setDefaults($.datepicker.regional["es"]);
            $('input[type=text][name*=Fecha]').datepicker({
                showOn: "button",
                buttonText: "<span class='glyphicon glyphicon-calendar'></span>",
                dateFormat: "dd/mm/yy"
            });
            // Formatea botones de los datepickers
            $('button.ui-datepicker-trigger').button({
                //icons: { primary: "ui-icon-calendar" },
                text: false
            });
            // Formatea radiobuttons
            $('input[type=radio]').checkbox();
            // Formatea checkboxes
            $('input[type=checkbox]').checkbox();
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="server">
    <div class="container">
        <div class="row">
            <h3>Datos Provisorios del Parto</h3>
        <div class="col-md-5">
            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label runat="server" ID="lblFecha" Text="Parto:" AssociatedControlID="ckbParto" CssClass="col-sm-6 control-label"></asp:Label>
                    <asp:CheckBox ID="ckbParto" runat="server" ToolTip="Se produjo el Parto?" />
                </div>

                <div class="form-group">
            <label class="col-sm-6 control-label">Fecha de Nacimiento:</label>
                    <asp:TextBox ID="txtFechaNacimientoParto" runat="server" CssClass="datepicker22 form-control" Width="150" style="float:left;"></asp:TextBox>
            </div>
                <div class="form-group">
            <label class="col-sm-6 control-label">Terminación:</label>
                    <asp:DropDownList ID="ddlTerminacionParto" runat="server" Width="150" DataTextField="nombre" DataValueField="idTerminacionParto" ToolTip="Debe ingresar el Tipo de Terminación" CssClass="form-control"></asp:DropDownList>
             </div>
             <div class="form-group">
             <label class="col-sm-6 control-label">Peso al Nacer:</label>
                 <asp:TextBox ID="txtPesoAlNacer" runat="server" type="number" min="200" max="12000" required="true" Text="" Width="150" ToolTip="Ingrese numeros enteros" CssClass="form-control"></asp:TextBox>
           </div>
                
            <h3>Puerperio</h3>
             <div class="form-group">
            <label class="col-sm-6 control-label">Fecha de 1er Control:</label>
                 <asp:TextBox ID="txtFecha1Control" runat="server" CssClass="datepicker22 form-control" Width="150" style="float:left;"></asp:TextBox>
            </div>
                <div class="form-group">
            <label class="col-sm-6 control-label">Fecha de 2do Control:</label>
                    <asp:TextBox ID="txtFecha2Control" runat="server" CssClass="datepicker22 form-control" Width="150" style="float:left;"></asp:TextBox>
            </div>
               
            </div><!--Div de la clase del fomulario -->
             </div>


            <div class="col-md-5">
                <div class="form-horizontal">
                <div class="form-group">
            <asp:Label runat="server" ID="lblAlumbramiento" Text="Manejo Alumbramiento:" AssociatedControlID="ckbAlumbramiento" CssClass="col-sm-6 control-label"></asp:Label>
            <asp:CheckBox ID="ckbAlumbramiento" runat="server" Checked="false" ToolTip="Manejo Activo del Alumbramiento?" TextAlign="Left" />
                </div>
                    <div class="form-group">
            <label class="col-sm-6 control-label">Lugar de Nacimiento:</label>
            <asp:DropDownList ID="ddlLugarNacimientoParto" runat="server" DataTextField="nombre" DataValueField="idEfector" Width="400" CssClass="form-control"></asp:DropDownList>
                </div>
                    <div class="form-group">
            <label class="col-sm-6 control-label">Edad Gestacional: </label>
            <asp:TextBox ID="txtEdadGestacional" runat="server" Text="" Width="80px" CssClass="form-control" Style="float:left;"></asp:TextBox>
                 </div>
                    <div class="form-group">
                  <label class="col-sm-6 control-label">APGAR 1':</label>
                        <asp:TextBox ID="txtApgar1" runat="server" Text="0" Width="40px" MaxLength="2" ToolTip="Solo números enteros" CssClass="form-control" Style="float:left;"></asp:TextBox><b style="float:left; padding-top: 7px; margin-left: 8px;
                    margin-right: 8px;">5':</b> 
                        <asp:TextBox ID="txtApgar5" runat="server" Text="0" Width="40px" MaxLength="2" ToolTip="Solo números enteros" CssClass="form-control" Style="float:left;"></asp:TextBox> 
                        </div>
                     <div style="height:16px; width: 100%;"></div>
                    <div class="form-group">
                <label class="">Control:</label>
                         <asp:TextBox ID="txtPrimerControl" runat="server" Width="70%" CssClass="form-control" Style="margin-top: -25px;"></asp:TextBox>
                </div>
                    <div class="form-group">
               <label class=""> Control: </label>
                        <asp:TextBox ID="txtSegundoControl" runat="server" Width="70%" CssClass="form-control" Style="margin-top: -25px;"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-md-8">
            <label class="control-label" style="margin-left: 104px;">Observaciones:</label>
                    <asp:TextBox ID="txtObservacionPuerperio" runat="server" TextMode="MultiLine" Width="70%" style="float: right; margin-bottom: 15px;" CssClass="form-control"></asp:TextBox>
            </div>
              <div class="col-md-6">
                
              <asp:Label runat="server" ID="lblProfesional" Text="Profesional: " AssociatedControlID="ddlProfesional" CssClass="control-label" style="margin-left: 128px;"></asp:Label>
                <asp:DropDownList runat="server" ID="ddlProfesional" Width="250" DataTextField="NombreCompleto" DataValueField="idProfesional" style="margin-left: 11px; float:right; margin-right: 76px;" CssClass="form-control">
                </asp:DropDownList>
                
                </div>
                    
          </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="server">
    <input type="button" value="Cancelar" onclick="history.go(-1)" />
    <asp:Button runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" ToolTip="Guardar datos del Parto" />
</asp:Content>
