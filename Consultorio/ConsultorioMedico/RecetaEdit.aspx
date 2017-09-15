<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecetaEdit.aspx.cs" Inherits="Consultorio.ConsultorioMedico.RecetaEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 34px;
        }
        .style2
        {
            width: 1154px;
        }
        .style4
        {
            width: 834px;
        }
        .style5
        {
            width: 1259px;
        }
        .style6
        {
            width: 283px;
        }
        .style7
        {
            width: 315px;
        }
        .style8
        {
            width: 90px;
        }
        .style9
        {
            width: 260px;
        }
        .style10
        {
            width: 158px;
        }
        .style11
        {
            width: 79px;
        }
        .style12
        {
            width: 169px;
        }
        #TextArea1
        {
            height: 58px;
            width: 305px;
        }
        #Text1
        {
            height: 62px;
            width: 322px;
        }
        #Button1
        {
            width: 73px;
            height: 44px;
        }
        #Guardar
        {
            height: 43px;
            width: 103px;
        }
    </style>
</head>
<body style="width: 1270px; height: 1px">
    <form id="form1" runat="server">
    <div style="position: absolute">
    <table cellpadding="2" cellspacing="2" class="style5" border="1">
                                <tr>
                                    <td align="CENTER" colspan="10" class="mytituloPagina" bgcolor="#99CCFF">
                                        <br />
                                          <br />
                                        FORMULARIO DE RECETA
                                        <br />
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="10" class="mytituloPagina">
                                        <hr style="width: 1251px; margin-left: 0px; height: -58px; margin-top: 3px;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="style6" bgcolor="#99CCFF">
                                        Fecha:
                                    </td>

                                    <td align="left" class="style7">
                                        <asp:Label ID="lblFecha" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td align="right" class="style8" bgcolor="#99CCFF">
                                        Codigo de CAPS:
                                    </td>
                                    <td class="style9" align="left">
                                      <asp:TextBox ID="txtFechaDesde" Width="150px" runat="server"></asp:TextBox>
                                    </td>
                                    <td align="right" class="style10" bgcolor="#99CCFF">
                                        ANULADA:
                                    </td>
                                    <td class="style11" align="left">
                                      <asp:TextBox ID="TextBox1" Width="20px" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                   <tr>
                                    <td align="right" class="style6" bgcolor="#99CCFF">
                                        Apellido:
                                    </td>

                                    <td class="style7" align="left">
                                      <asp:TextBox ID="TextBox4" Width="250px" runat="server"></asp:TextBox>
                                    </td>
                                    <td align="right" class="style8" bgcolor="#99CCFF">
                                        Nombre:
                                    </td>
                                    <td class="style9" align="left">
                                      <asp:TextBox ID="TextBox2" Width="252px" runat="server"></asp:TextBox>
                                    </td>
                                  
                                </tr>
                                  <tr>
                                    <td align="right" class="style6" bgcolor="#99CCFF">
                                        Tipo y DNI:
                                    </td>

                                    <td class="style7" align="left">
                                      <asp:TextBox ID="TextBox3" Width="100px" runat="server"></asp:TextBox>
                                    </td>
                                    <td align="right" class="style8" bgcolor="#99CCFF" colspan="1">
                                        Fecha de Nacimiento:
                                    </td>
                                    <td class="style9" align="left">
                                      <asp:TextBox ID="TextBox5" Width="100px" runat="server"></asp:TextBox>
                                    </td>
                                  <td align="right" class="style10" bgcolor="#99CCFF">
                                        Sexo:
                                    </td>
                                    <td class="style11" align="left">
                                      <asp:TextBox ID="TextBox6" Width="20px" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                 <td align="right" class="style6">
                                        Medicacion prescripta:
                                    </td>

                                    <td align="left" class="style7">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td bgcolor="#99CCFF">
                                                    &nbsp;
                                                 </td>
                                                <td bgcolor="#99CCFF">
                                                    Medicacion prescripta
                                                </td>
                                                 <td bgcolor="#99CCFF">
                                                    &nbsp;
                                                </td>
                                                <td class="style1" bgcolor="#99CCFF">
                                                    Unidades</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                   001
                                                </td>
                                                <td>
                                                    Acido Valproico 
                                                </td>
                                                <td>
                                                    Jarabe 250 mg/5 ml
                                                </td>
                                                <td class="style1">
                                                &nbsp;
                                                </td>
                                                
                                            </tr>
                                            <tr>
                                                <td bgcolor="#99CCFF">
                                                    002</td>
                                                <td bgcolor="#99CCFF">
                                                    Amiodarona </td>
                                                <td bgcolor="#99CCFF">
                                                    Comprimido 200 mg</td>
                                                <td bgcolor="#99CCFF" class="style1">
                                                &nbsp;
                                                </td>
                                              
                                            </tr>
                                            <tr>
                                                <td>
                                                   003
                                                </td>
                                                <td>
                                                    Amoxicilina
                                                </td>
                                                <td>
                                                    Susp. oral 500 mg /5 ml
                                                </td>
                                                <td class="style1">
                                                &nbsp;
                                                </td>
                     
                                            </tr>
                                            <tr>
                                                 <td bgcolor="#99CCFF">
                                                   004
                                                </td>
                                                <td bgcolor="#99CCFF">
                                                    Amoxicilina
                                                </td>
                                                <td bgcolor="#99CCFF">
                                                    Comprimido 500 mg
                                                </td>
                                                <td class="style1" bgcolor="#99CCFF">
                                                &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                       
                                    </td>
                                </tr>
                                  <tr>
                                  <td class="style6">
                                  <table style="width:224%;">
                                            <tr>
                                                <td class="style2" bgcolor="#99CCFF">
                                                    Diagnóstico</td>
                                                <td class="style12" bgcolor="#99CCFF">
                                                    CEPS-AP</td>
                                                <td class="style4" bgcolor="#99CCFF">
                                                    CIE-10</td>
                                            </tr>
                                            <tr>
                                                <td class="style2" bgcolor="#EBEBEB">
                                                    &nbsp;</td>
                                                <td class="style12" bgcolor="#EBEBEB">
                                                    &nbsp;</td>
                                                <td class="style4" bgcolor="#EBEBEB">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style2" bgcolor="#EBEBEB">
                                                    &nbsp;</td>
                                                <td class="style12" bgcolor="#EBEBEB">
                                                    &nbsp;</td>
                                                <td class="style4" bgcolor="#EBEBEB">
                                                    &nbsp;</td>
                                            </tr>

                                        </table>
                                    <td>
                                     <td align="right" class="style8" bgcolor="#99CCFF">
                                        Firma y Sello del Médico:
                                    </td>
                                    <td class="style9" align="left">
                                      
                                        <input id="Text1" type="text" /></td>
                                     </td> 
                                                 
                                                <td>
                                                    <input id="Guardar" type="button" value="Guardar" 
                                                        style="color: #000000; font-weight: bold; background-color: #99CCFF" /></td>
                                                                                                           
                                   </tr>
                           
                            </table>
    </div>
    </form>
</body>
</html>
