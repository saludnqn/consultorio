<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlPerinatal.aspx.cs" Inherits="ConsultaAmbulatoria.Alertas.ControlPerinatal"  %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>Alertas Existentes en el Control Perinatal</title>
</head>
<body>
<form runat="server">
    <div style="text-align:center">
    <p style="color:#d5542c"><b>Listado de Pacientes que faltaron a los controles</b></p><br />
    <asp:GridView ID="gvPacientes" runat="server" AutoGenerateColumns="false" Width="100%" BorderColor="#d5542c" BorderStyle="Solid" BorderWidth="1px" 
   CellPadding="3" Font-Names="Verdana" Font-Size="9pt">
        <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
        <Columns>
            <asp:BoundField DataField="asiste" ItemStyle-ForeColor="Red" HeaderText="Estado" />
            <asp:BoundField DataField="dni" HeaderText="Documento" />
            <asp:BoundField DataField="paciente" HeaderText="Paciente" />
            <asp:BoundField DataField="telefono" HeaderText="Telefono" />
            <asp:BoundField DataField="edad" HeaderText="Edad" />
            <asp:BoundField DataField="fechaControl" HeaderText="Ultimo Ctrol." />
            <asp:BoundField DataField="proximacita" HeaderText="Fec. Cita" />
        </Columns>
        <HeaderStyle BackColor="#d5542c" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
</div>
<br />
<a style="color: #d5542c" href="javascript:close()">[X]-Cerrar Ventana</a>
</form>
</body>
</html>