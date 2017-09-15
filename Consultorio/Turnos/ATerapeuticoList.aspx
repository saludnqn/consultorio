<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ATerapeuticoList.aspx.cs" Inherits="Consultorio.Turnos.ATerapeuticoList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Acompañantes Terapéuticos</title>
</head>
<body>
    <form id="form1" runat="server">
     <div  style="width: 600px; height: 400px;  ">
             <table>
                                    <tr>                                       
                                        <td style="text-align: left">
                                            <asp:Label ID="lblPaciente" runat="server" CssClass="myLabelRojoMediano" Text="Label" Font-Bold="True" Font-Size="12pt" ></asp:Label>
                                        </td>
                                         <td>&nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>                                       
                                        <td>
                                            &nbsp;</td>
                                         <td>&nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
<asp:GridView ID="gvTurnosAcompaniante" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="idTurno" Font-Names="Calibri" Font-Size="10pt" ForeColor="Black" OnRowCommand="gvTurnosAcompaniante_RowCommand" OnRowDataBound="gvTurnosAcompaniante_RowDataBound" Width="600px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" GridLines="None">
                                      <FooterStyle BackColor="#CCCC99" />
                                      <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                      <PagerStyle BackColor="#F7F7DE" Font-Underline="True" ForeColor="Black" HorizontalAlign="Right" />
                                      <AlternatingRowStyle BackColor="White" />
                                      <Columns>
                                          <asp:TemplateField HeaderText="">
                                              <ItemTemplate>
                                                  <asp:Image ID="imgTurno0" runat="server" />
                                              </ItemTemplate>
                                              <ItemStyle HorizontalAlign="Center" />
                                          </asp:TemplateField>
                                          <asp:BoundField DataField="Hora" HeaderText=" Hora" Visible="false">
                                          <HeaderStyle HorizontalAlign="Center" />
                                          <ItemStyle HorizontalAlign="Center" Width="10%" />
                                          </asp:BoundField>
                                             <asp:TemplateField>
                                              <ItemTemplate>
                                                  <asp:ImageButton ID="cmdEliminarTurno0" runat="server" AlternateText="eliminar" CommandName="Eliminar"
                                                       ImageUrl="~/App_Themes/consultorio/Agenda/eliminar.png" 
                                                       OnClientClick="return PreguntoEliminar();" 
                                                      />
                                              </ItemTemplate>
                                              <ItemStyle HorizontalAlign="Right" Width="100px" />
                                          </asp:TemplateField>
                                          <asp:BoundField DataField="DNI" HeaderText="DNI" Visible="true">
                                          <HeaderStyle HorizontalAlign="Center" />
                                          <ItemStyle HorizontalAlign="Center" Width="15%" />
                                          </asp:BoundField>

                                           <asp:BoundField DataField="Paciente" HeaderText="Acompañante terapéutico" Visible="true">
                                          <ItemStyle HorizontalAlign="Left" Width="60%" />
                                          </asp:BoundField>

                                          <asp:BoundField DataField="Sexo" HeaderText="Sexo" Visible="true">
                                          <HeaderStyle HorizontalAlign="Center" />
                                          <ItemStyle HorizontalAlign="Center" Width="5%" />
                                          </asp:BoundField>
                                          <asp:BoundField DataField="fechaNacimiento" HeaderText="Fecha Nacimiento" Visible="true">
                                          <HeaderStyle HorizontalAlign="Center" />
                                          <ItemStyle HorizontalAlign="Center" Width="20%" />
                                          </asp:BoundField>
                                            <asp:BoundField DataField="Consulta" HeaderText="Consulta" Visible="true">
                                          <HeaderStyle HorizontalAlign="Center" />
                                          <ItemStyle HorizontalAlign="Center" Width="5%" />
                                          </asp:BoundField>
                                          
                                      </Columns>
                                      <RowStyle BorderStyle="None" />
                                      <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                      <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                      <SortedAscendingHeaderStyle BackColor="#848384" />
                                      <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                      <SortedDescendingHeaderStyle BackColor="#575357" />
                                  </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
    
    </div>
    
      <script language="javascript" type="text/javascript">


          function PreguntoEliminar() {
              if (confirm('¿Está seguro de eliminar el registro?'))
                  return true;
              else
                  return false;
          }

       </script>
</form>

</body>
</html>
