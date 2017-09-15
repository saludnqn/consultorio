<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscarPaciente.aspx.cs" MasterPageFile="~/ConsultaAmbulatoria/MasterPages/Consultorio.master" Inherits="Consultorio.ConsultaAmbulatoria.BuscarPaciente" Theme="apr" %>
<%@ MasterType VirtualPath="~/ConsultaAmbulatoria/MasterPages/Consultorio.master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="server">
    <style>
        tr, th, td {
        padding-left: 8px;
        text-align: center;
        }

        .modal-dialog {
            width: 850px !important;
        }
        .center1{
            text-align:center;
        }
        .btn22{
            padding: 2px 12px !important;
        }
        .btn-color{
            background-color:#C1CC9E !important;
            margin: 2px;
            text-decoration: none;
        }
        .btn-color:hover{
            background-color:#A0B367 !important;
            color:#fff !important;
        }
        .form-control {
             display: inline !important;
                     }

        /*.ui-tabs .ui-tabs-panel {
                           
             height: 340px !important;
                                }*/
        .bordes {
                           
              padding-bottom: 20px;
                }
        .grid tbody tr td {
            font-size: 12px;
        }
    </style>

    <div class="row">

        <!-- Modal -->
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog">


            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">
                        <p style="color: #d14836"><b>Alertas! </b></p>
                    </h4>
                </div>
                <div class="modal-body">


                    <div class="panel panel-default">
                        <asp:UpdatePanel ID="upAlertas" runat="server" Visible="false">
                            <ContentTemplate>
                                <div style="text-align: left">
                                    <p style="color: #d14836">Pacientes que faltaron a los controles</p>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px"
                                        CellPadding="3" Font-Names="Verdana" Font-Size="10px">
                                        <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
                                        <Columns>
                                            <asp:BoundField DataField="asiste" ItemStyle-ForeColor="#d14836" HeaderText="Estado" />
                                            <asp:BoundField DataField="dni" HeaderText="Documento" />
                                            <asp:BoundField DataField="paciente" HeaderText="Paciente" />
                                            <asp:BoundField DataField="telefono" HeaderText="Telefono" />
                                            <asp:BoundField DataField="edad" HeaderText="Edad" />
                                            <asp:BoundField DataField="fechaControl" HeaderText="Ultimo Ctrol." />
                                            <asp:BoundField DataField="proximacita" HeaderText="Fec. Cita" />
                                        </Columns>
                                        <HeaderStyle BackColor="#d14836" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#000" />
                                    </asp:GridView>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>



                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                </div>
            </div>

        </div>

    </div>

    <!-- Fin Modal -->
       
         <div class="bordes">
      <h3>Buscar Paciente</h3>
       </div>
        <div class="col-md">
        <div class="col-md-4">
         <label>  Documento:
          <asp:TextBox ID="txtDni" runat="server" MaxLength="8" width="250px" ToolTip="Solo números"
            TabIndex="1" CssClass="form-control"></asp:TextBox>
             <br />
        
          </label>
            </div>
         <div class="bordes col-md-4">
       <label> 
           Apellido:
          <asp:TextBox ID="txtApellidoBusqueda" runat="server" TabIndex="4" width="250px" CssClass="form-control validador11"></asp:TextBox>
       </label>
        </div>
            
         <div class="bordes col-md-4">
       <label> 
           Nombre:
        <asp:TextBox ID="txtNombreBusqueda" runat="server" TabIndex="5" width="250px" CssClass="form-control"></asp:TextBox>

            </label>
        </div>
              <div class="bordes col-md-12 center1">
            <asp:Button runat="server" ID="Button1" Text="Buscar Paciente" OnClick="btnBuscar_Click" TabIndex="2" CssClass="btn btn-color" OnClientClick="return verifica()"/>
            <asp:Button runat="server" ID="Button2" Text="Nuevo Paciente" OnClick="btnNuevo_Click" CssClass="btn btn-color" />
                  <div id="mensajeError"></div>
            </div>
             <div class="col-md-12 center1">
            <!-- Activa ventana modal de alertas -->
                    <button type="button" class="btn btn-color btn-lg btn22" data-toggle="modal" data-target="#myModal">Alertas</button>

        </div>
            </div>
        
  </div>
  <div class="row">
  <asp:GridView ID="gvPacientes" runat="server" AutoGenerateColumns="false"  ForeColor="#333333"
        GridLines="None" Width="99%"  OnSorting="gridView_Sorting" AllowPaging="true" OnPageIndexChanging="gvPacientes_PageIndexChangind"
    PageSize="10" EmptyDataText="<b>No se encontraron datos.<b>">
     <RowStyle ForeColor="#333333" BackColor="white" />
    <Columns>
      <asp:BoundField DataField="numeroDocumento" HeaderText="Documento" />
      <asp:BoundField DataField="apellido" HeaderText="Apellido" />
      <asp:BoundField DataField="nombre" HeaderText="Nombre" />
      <%--<asp:BoundField DataField="sexo" HeaderText="Sexo" />--%>
      <asp:BoundField DataField="fechaNacimiento" DataFormatString="{0:dd/MM/yyy}" HeaderText="Fec.Nac" />
      <%--<asp:BoundField DataField="estado" HeaderText="Estado" />
      <asp:BoundField DataField="motivo" HeaderText="Motivo" />--%>
      <asp:HyperLinkField DataNavigateUrlFields="idPaciente" DataNavigateUrlFormatString="~/Paciente/PacienteView.aspx?id={0}"
        HeaderText="Datos Paciente" Text="Ver" ControlStyle-CssClass="btn btn-color btn22"/>
     <%-- <asp:HyperLinkField DataNavigateUrlFields="idPaciente" DataNavigateUrlFormatString="~/Paciente/PacienteEdit.aspx?id={0}"
        HeaderText="Editar" Text="Editar" ControlStyle-CssClass="btn btn-color btn22" />--%>
      <asp:HyperLinkField DataNavigateUrlFields="idPaciente" DataNavigateUrlFormatString="~/ConsultaAmbulatoria/Inicio.aspx?idPaciente={0}"
        HeaderText="Ingresar HCP" Text="Ver" ControlStyle-CssClass="btn btn-color btn22" />
    </Columns>
    <FooterStyle BackColor="white" ForeColor="black" Font-Bold="True" />
        <PagerStyle BackColor="#E0E0E0" ForeColor="black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="black" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
  </asp:GridView>
  </div>
    <script>
        //verifica que al menos un campo este lleno y que el dni sea un numero..
        function verifica() {   
            var apellido = $('#<%= txtApellidoBusqueda.ClientID %>').val();
            var nombre = $('#<%= txtNombreBusqueda.ClientID %>').val();
            var dni = $('#<%= txtDni.ClientID %>').val();

            if((apellido == "") && (nombre == "") && (dni == "")){
                $('#mensajeError').html('<p style="color: red;">Ingrese algun dato de busqueda</p>');
                $('#mensajeError').fadeIn(function(){
                    $('#mensajeError').fadeOut(2000);
                });
                return false;
            }
            else {
                if (dni.length > 0) {
                    if (isNaN(dni) == false) {
                        return true;
                    }
                    else{
                        $('#mensajeError').html('<p style="color: red;">Ingrese solo numeros</p>');
                        $('#mensajeError').fadeIn(function () {
                            $('#mensajeError').fadeOut(2000);
                        });
                        return false;
                    }
                }

                return true;
            }
            
        }
            
        
    </script>
    <script>

        //Muestra solo la primera vez la ventana de alertas


        var variable1 = '<%= this.MostrarAlerta %>';
        if (variable1 == 'True') {
            $("#myModal").modal("show");
            <%= this.MostrarAlerta = false%>;
        }
        //});


    </script>
</asp:Content>





