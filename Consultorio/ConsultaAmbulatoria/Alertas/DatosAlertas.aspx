<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatosAlertas.aspx.cs" Inherits="ConsultaAmbulatoria.Alertas.DatosAlertas"  %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>Alertas Existentes en el Control Perinatal</title>
</head>
<body>
<form runat="server">
    <div style="text-align:center">
    <p style="color:#d5542c"><b>Listado de Alertas en la Historia Clínica Perinatal</b></p><br />
    <asp:GridView ID="gvSIP" runat="server" AutoGenerateColumns="false" Width="100%" BorderColor="#d5542c" BorderStyle="Solid" BorderWidth="1px" 
   CellPadding="3" Font-Names="Verdana" Font-Size="9pt">
        <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
        <Columns>
            <asp:BoundField DataField="idPaciente" ItemStyle-ForeColor="Red" HeaderText="idPaciente" />
            <asp:BoundField DataField="dni" HeaderText="Dni" />
            <asp:BoundField DataField="Edad" HeaderText="Edad" />
        </Columns>
       <HeaderStyle BackColor="#d5542c" ForeColor="White" />
    </asp:GridView>
</div>
<br />
<a style="color: #d5542c" href="javascript:close()">[X]-Cerrar Ventana</a>
</form>
</body>
</html>