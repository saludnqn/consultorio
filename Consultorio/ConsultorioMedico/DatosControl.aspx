﻿<%@ Page Language="C#" AutoEventWireup="true" Title="Datos de Control del Paciente" CodeBehind="DatosControl.aspx.cs" Inherits="Consultorio.ConsultorioMedico.DatosControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Datos de Control del Paciente</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <p><b>Datos del Control del Paciente</b></p>
                <asp:GridView ID="gvDatos" AutoGenerateColumns="true" runat="server" ForeColor="#333333" BorderColor="#333333"
                    BorderStyle="Solid" BorderWidth="1px" Font-Names="Calibri" Font-Size="11pt" Width="650px"
                    CellPadding="2" CellSpacing="2" EmptyDataText="No hay datos del control">
                    <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
            </div>
          
        </div>
    </form>
</body>
</html>
