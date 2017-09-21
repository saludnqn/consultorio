<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Consultorio.Principal" MasterPageFile="~/mConsultorio.Master" %>

<asp:Content ID="content1" ContentPlaceHolderID="head" runat="server">
    <link href="Turnos.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="../js/jquery-ui-1.7.1.custom.css" />
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../js/jquery.ui.datepicker-es.js"></script>

</asp:Content>

<asp:Content ID="content2" ContentPlaceHolderID="cuerpo" runat="server">



    <br />
    <br />
    <br />

    <h3>
        <img src="./App_Themes/consultorio/images/information.png" />
        08/09/2015. Se ha actualizado el sistema con la opción de crear agendas mutidisciplinarias.</h3>
    <table>
        <tr>
            <td>

                <asp:Panel ID="pnlPrincipal" runat="server" Visible="false">
                    <div style="left: 20px; top: 10px; margin-left: 20px; margin-top: 10px; font-weight: bold;">
                        <br />
                        <br />
                        <br />

                <tr>
                    <td style="vertical-align: top; width: 400px">
                        <asp:GridView ID="gvEspecialidad" runat="server" AutoGenerateColumns="False"
                            BorderColor="#666666" BorderStyle="None" BorderWidth="1px" CellPadding="4"
                            CellSpacing="2" Font-Names="Arial" Font-Size="10pt" ForeColor="#333333"
                            GridLines="None" Width="350px">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundField DataField="nombre" HeaderText="Especialidades del Efector" />
                            </Columns>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#666666" Font-Bold="True" ForeColor="White"
                                HorizontalAlign="Left" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                    </td>
                    <td></td>
                    <td style="vertical-align: top" width="400px">
                        <asp:GridView ID="gvPrestaciones" runat="server" AutoGenerateColumns="False"
                            CellPadding="4" CellSpacing="2" Font-Names="Arial" Font-Size="10pt"
                            ForeColor="#333333" GridLines="None" Width="350px">
                            <RowStyle BackColor="#F0F0F0" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundField DataField="nombre" HeaderText="Prestaciones del Efector" />
                            </Columns>
                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                            <HeaderStyle BackColor="#993300" Font-Bold="True" ForeColor="White"
                                HorizontalAlign="Left" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </td>
                    <td style="vertical-align: top">&nbsp;</td>
                </tr>
        <tr>
            <td colspan="3">
                <br />
                <br />
            </td>
        </tr>
    </table>





    <br />
    <br />





    </div>
        </asp:Panel>
      </td>
   
      <td style="vertical-align: top">

          <asp:Panel ID="pnlIndicadores" runat="server" Visible="false" Width="900px">

              <div align="left"
                  style="left: 20px; top: 10px; margin-left: 20px; margin-top: 10px; width: 100%">

                  <table width="600px" style="vertical-align: top">

                      <tr>
                          <td class="myLabelTitulo" colspan="2">Bienvenido al Panel de Información del Sistema de Agendas y Turnos</td>
                      </tr>
                      <tr>
                          <td colspan="2">&nbsp;</td>
                      </tr>
                      <tr>
                          <td rowspan="3">
                              <img src="./App_Themes/consultorio/images/indicador.gif" /></td>
                          <td>
                              <a href="PanelConsultas/AgendaList.aspx"><b class="mySubTitulo">Agendas y Disponibilidad de Turnos.</b></a></td>
                      </tr>
                      <tr>
                          <td>Cantidad de agendas abiertas y disponibilidad de turnos por efector.</td>
                      </tr>


                      <tr>
                          <td></td>
                      </tr>
                      <tr>
                          <td rowspan="3">
                              <img src="./App_Themes/consultorio/images/indicador.gif" /></td>
                          <td>&nbsp;</td>
                      </tr>
                      <tr>
                          <td><a href="PanelConsultas/ConsultasxEfector.aspx"><b class="mySubTitulo">Pacientes Atendidos.</b></a>
                          </td>
                      </tr>
                      <tr>
                          <td>Cantidad de consultas realizadas por efector (turnos con asistencia), discriminadas por efector, grupos etáreos y por sexo.</td>
                      </tr>


                      <tr>
                          <td class="style6">&nbsp;</td>
                          <td class="style5">&nbsp;</td>
                      </tr>


                      <tr>
                          <td rowspan="3">
                              <img src="./App_Themes/consultorio/images/indicador.gif" /></td>
                          <td>
                              <a href="PanelConsultas/ReporteDiagnosticos.aspx"><b class="mySubTitulo">Motivo de Consulta/Diagnósticos.</b></a>
                          </td>
                      </tr>



                      <tr>
                          <td>Informe de Cantidad de Diagnósticos CIE10, por efector, grupos etáreos y por sexo.</td>
                      </tr>


                      <tr>
                          <td></td>
                      </tr>

                      <tr>
                          <td class="style6">&nbsp;</td>
                          <td class="style5"></td>
                      </tr>


                  </table>

              </div>




          </asp:Panel>

          <br />
          <br />

          <br />
          <br />

          <div align="left" style="left: 50px; width: 300px;">
              <b>Documentación de Interés
                <hr width="650" align="left" />
              </b>
              <br />

              <img src="./App_Themes/consultorio/images/pdf.jpg" />
              <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">MANUAL DE USUARIO</asp:LinkButton>&nbsp;&nbsp;<b class="myLabelIzquierda"></b>
              <br />

              <img src="./App_Themes/consultorio/images/pdf.jpg" />
              <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Informe Técnico de la Consultoría - Diciembre 2011</asp:LinkButton>
              <br />
              <img src="./App_Themes/consultorio/images/pdf.jpg" />
              <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Proceso de Solicitud y Entrega de Turnos para la Atención Ambulatoria</asp:LinkButton>
              <br />
              <img src="./App_Themes/consultorio/images/pdf.jpg" />
              <asp:LinkButton ID="LinkButton1" runat="server"
                  OnClick="LinkButton1_Click">Notificación de Uso del Sistema</asp:LinkButton>
              <br />
              <br />
              <img src="./App_Themes/consultorio/images/pdf.jpg" />
              <asp:LinkButton ID="lnkPlanillaConsultaAmbulatoria" runat="server" OnClick="lnkPlanillaConsultaAmbulatoria_Click">Modelo Planilla Consulta Ambulatoria</asp:LinkButton>
              <br />
              <img src="./App_Themes/consultorio/images/pdf.jpg" />
              <asp:LinkButton ID="lnkPlanillaSaludMental" runat="server" OnClick="lnkPlanillaSaludMental_Click">Modelo Planilla Salud Mental</asp:LinkButton>
              <br />
              <img src="./App_Themes/consultorio/images/pdf.jpg" />
              <asp:LinkButton ID="lnkPlanillaOdontologia" runat="server" OnClick="lnkPlanillaOdontologia_Click">Modelo Planilla Odontología</asp:LinkButton>
              <br />

          </div>
      </td>
      <td style="vertical-align: top"></td>
      <td style="vertical-align: top"></td>
    </tr>
    <tr>
        <td width="350" colspan="2"></td>
        <td width="350">&nbsp;</td>
        <td width="350">&nbsp;</td>
        <td style="vertical-align: top">&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td style="vertical-align: top">&nbsp;</td>
    </tr>
    </table>

</asp:Content>
