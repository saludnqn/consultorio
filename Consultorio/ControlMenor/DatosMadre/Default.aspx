<%@ Page Language="C#" MasterPageFile="~/ControlMenor/MasterPages/ControlMenor.master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SIPS.ControlMenor.DatosMadre.Default"
    Title="" Theme="apr" %>

<%@ Register Assembly="Subsonic" Namespace="SubSonic" TagPrefix="subsonic" %>
<%@ MasterType VirtualPath="~/ControlMenor/MasterPages/ControlMenor.master" %>
<%-- Scripts y estilos en la cabecera --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%-- Contenido principal --%>
<asp:Content ID="Content3" ContentPlaceHolderID="Cuerpo" runat="server">
    <fieldset class="ui-widget ui-widget-content ui-corner-all" id="setDatosPersonales" runat="server">
        <legend>Datos personales</legend>
        <table style="width: 100%; margin-bottom: 0;">
            <tr>
                <td style="width: 50%">
                    <strong>Documento: </strong>
                    <asp:Literal ID="ltDocumento" runat="server" />
                </td>
                <td>
                    <strong>Apellidos, nombres: </strong>
                    <asp:Literal ID="ltNombre" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Fecha de nacimiento: </strong>
                    <asp:Literal ID="ltFechaNacimiento" runat="server" />
                </td>
                <td>
                    <strong>Edad: </strong>
                    <asp:Literal ID="ltEdad" runat="server" />
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset class="ui-widget ui-widget-content ui-corner-all" id="setDatosComplementarios"
        runat="server">
        <legend>Datos complementarios</legend>
        <table style="width: 100%; margin-bottom: 0;">
            <tr>
                <td style="width: 50%">
                <br />
                    <strong>Nacionalidad: </strong>
                    <asp:Literal ID="ltNacionalidad" runat="server" />
                </td>
                <td>
                    <strong>Lugar de nacimiento: </strong>
                    <asp:Literal ID="ltLugarNacimiento" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Nivel instrucción: </strong>
                    <%--<asp:Literal ID="ltInstruccion" runat="server" />--%>
                    <subsonic:DropDown ID="ddlNivelInstruccion" runat="server" Width="200px" PromptText="Seleccionar >>"
                        ShowPrompt="true" TableName="Sys_NivelInstruccion" TextField="nombre">
                    </subsonic:DropDown>
                </td>
                <td>
                    <strong>Situación laboral: </strong>
                    <%--<asp:Literal ID="ltSituacionLaboral" runat="server" />--%>
                    <subsonic:DropDown ID="ddlSituacionLaboral" runat="server" Width="150px" PromptText="Seleccionar >>"
                        ShowPrompt="true" TableName="Sys_SituacionLaboral" TextField="nombre">
                    </subsonic:DropDown>
                </td>
            </tr>
            <tr>
                <td><br />
                    <strong>Profesión: </strong>
                    <%--<asp:Literal ID="ltProfesion" runat="server" />--%>
                    <subsonic:DropDown ID="ddlProfesion" runat="server" OrderField="nombre" Width="220px" PromptText="Seleccionar >>"
                        ShowPrompt="true" TableName="Sys_Profesion" TextField="nombre">
                    </subsonic:DropDown>
                </td>
                <td>
                    <strong>Domicilio: </strong>
                    <asp:Literal ID="ltDomicilio" runat="server" />
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset class="ui-widget ui-widget-content ui-corner-all" id="setOtrosDatos" runat="server">
        <legend>Otros Datos</legend>
        <table style="width: 100%; margin-bottom: 0;">
            <tr>
                <td style="width: 50%">
                    <strong>Trabaja?: </strong>
                    <asp:RadioButtonList runat="server" ID="rblTrabaja" RepeatDirection="Horizontal">
                        <asp:ListItem Value="0">No</asp:ListItem>
                        <asp:ListItem Value="1">Si</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <strong>Cantidad de Horas Diarias: </strong>
                    <asp:TextBox ID="txtHoras" runat="server" Width="50px" />
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Recibe Asistencia Económica: </strong>
                    <asp:RadioButtonList runat="server" ID="rblAsistencia" RepeatDirection="Horizontal">
                        <asp:ListItem Value="0">No</asp:ListItem>
                        <asp:ListItem Value="1">Si</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:Button ID="btnGuardar" Text="GuardarDatos" OnClick="btnGuardar_Click" runat="server" />
                </td>
            </tr>
        </table>
    </fieldset>
    </fieldset></asp:Content>
<%-- Botonera --%>
<asp:Content ID="Content4" ContentPlaceHolderID="Botones" runat="server">
    <asp:Button ID="btnEditar" Text="Editar..." OnClick="btnEditar_Click" runat="server" />
</asp:Content>
