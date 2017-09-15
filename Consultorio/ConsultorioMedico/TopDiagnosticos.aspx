<%@ Page Language="C#" AutoEventWireup="true" Title="Ranking de Diagnosticos del Paciente" CodeBehind="TopDiagnosticos.aspx.cs" Inherits="Consultorio.ConsultorioMedico.TopDiagnosticos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Ranking de Diagnosticos del Paciente</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <p><b>Top 10 Diagnósticos del Paciente</b></p>
                <asp:GridView ID="gvDiagnosticos" AutoGenerateColumns="true" runat="server" ForeColor="#333333" BorderColor="#333333"
                    BorderStyle="Solid" BorderWidth="1px" Font-Names="Calibri" Font-Size="11pt" Width="500px"
                    CellPadding="2" CellSpacing="2" EmptyDataText="No hay datos del diagnosticos registrados">
                    <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
            </div>
          
        </div>
    </form>
</body>
</html>
