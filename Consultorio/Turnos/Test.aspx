<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="Consultorio.Turnos.Test" %>

<%@ Register Src="~/Configuracion/ConsultaAmbulatoria/UserControls/DiagnosticoPrincipal.ascx" TagName="DiagnosticoPrincipal"
    TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        
        
<%--Usar par probar controles--%>
    <title></title>
</head>
<body>
        <script type="text/javascript" src='<%= ResolveUrl("../../ControlMenor/js/jquery-1.5.1.min.js") %>'></script>
        <script type="text/javascript" src='<%= ResolveUrl("../../ControlMenor/js/jquery-ui-1.8.9.custom.min.js") %>'></script>
    <form id="form1" runat="server">
    <div>
    
        <uc1:DiagnosticoPrincipal ID="DiagnosticoPrincipal1" runat="server" />

    </div>
    </form>
</body>
</html>
