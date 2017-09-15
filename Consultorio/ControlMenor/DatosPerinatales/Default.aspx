<%@ Page Language="C#" MasterPageFile="~/ControlMenor/MasterPages/ControlMenor.master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SIPS.ControlMenor.DatosPerinatales.Default"
    Title="" Theme="apr" %>

<%@ MasterType VirtualPath="~/ControlMenor/MasterPages/ControlMenor.master" %>
<%@ Register Src="../../ConsultaAmbulatoria/UserControls/DiagnosticoSecundario.ascx"
    TagName="DiagnosticoSecundario" TagPrefix="uc1" %>
<%-- ¡A la cabecera! --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        /* "Prechequea" deprimido al nacer, en función de los datos APGAR */
        $(document).ready(function() {
            var chkId = $("label:contains('Deprimido al nacer')").first().attr("for");
            var apgar1Id = $("input[id$='txtAPGAR1']").first().attr("id");
            var apgar5Id = $("input[id$='txtAPGAR5']").first().attr("id");
            $("#" + apgar1Id + ", #" + apgar5Id).change(function() {
                var a1 = $("#" + apgar1Id).val();
                var a5 = $("#" + apgar5Id).val();
                if ((a1 != "" && a1 < 6) || (a5 != "" && a5 < 6)) {
                    $("#" + chkId).checkbox('check');
                } else {
                    $("#" + chkId).checkbox('uncheck');
                };
            })

        });
    </script>

    <script type="text/javascript">
        $(document).ready(function() {
            $('.tooltipeable').tooltip({
                position: "bottom center",
                offset: [10, -2],
                effect: 'fade',
                opacity: 0.7
            });
        });
    </script>

</asp:Content>
<%-- Contenido de la página --%>
<asp:Content ID="Content3" ContentPlaceHolderID="Cuerpo" runat="server">
    <asp:ScriptManagerProxy runat="server" ID="smp">
        <Scripts>
            <asp:ScriptReference Path="~/js/tooltips/jquery.tools.min.js" />
        </Scripts>
    </asp:ScriptManagerProxy>
    <fieldset class="ui-widget ui-widget-content ui-corner-all" >
        <legend>Datos al Nacer</legend>
        <table class="formulario">
            <tr>
            <td>
            <asp:Label Text="Embarazo Normal" AssociatedControlID="rblEmbarazoNormal" runat="server" />
             <asp:RadioButtonList runat="server" ID="rblEmbarazoNormal" CssClass="rbList" RepeatDirection="Horizontal">
                        <asp:ListItem Value="0">No</asp:ListItem>
                        <asp:ListItem Value="1">Si</asp:ListItem>
                    </asp:RadioButtonList>
            </td>
<td>
<asp:Label Text="Tipo de Parto" AssociatedControlID="ddlTipoParto" runat="server" />
 <asp:DropDownList runat="server" ID="ddlTipoParto" Width="145px" DataValueField="idTipoParto" DataTextField="nombre">
                        <asp:ListItem Text="Seleccione" Value=""></asp:ListItem>
                        <asp:ListItem Text="Vaginal" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Cesárea" Value="2"></asp:ListItem>
                         <asp:ListItem Text="Forceps" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Vacuum" Value="4"></asp:ListItem>
                    </asp:DropDownList>
</td>           
            <td>
            <asp:Label Text="Pesquisa Neonatal" AssociatedControlID="rblPesquiza" runat="server" />
             <asp:RadioButtonList runat="server" ID="rblPesquiza" CssClass="rbList" RepeatDirection="Horizontal">
                        <asp:ListItem Value="0">No</asp:ListItem>
                        <asp:ListItem Value="1">Si</asp:ListItem>
                    </asp:RadioButtonList>
                    </td>           
            <td>
             <asp:Label Text="Hb 12m" AssociatedControlID="cblHb" runat="server" />
             <asp:CheckBox runat="server" ID="cblHb" RepeatDirection="Horizontal">
             </asp:CheckBox>
             </td>           
            <td>
             <asp:Label Text="TA 3 años" AssociatedControlID="cbTa" runat="server" />
             <asp:CheckBox runat="server" ID="cbTa" RepeatDirection="Horizontal">
             </asp:CheckBox>
            </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Text="Peso al Nacer (gr.)" AssociatedControlID="txtPeso" runat="server" />
                    <asp:TextBox Width="145px" ID="txtPeso" runat="server" CssClass="tooltipeable" title="Solo Numeros, en gramos." />
                </td>
                <td>
                    <asp:Label Text="Longitud (cm)" AssociatedControlID="txtLongitud" runat="server" />
                    <asp:TextBox Width="145px" ID="txtLongitud" runat="server" CssClass="tooltipeable"
                        title="Solo numeros, en centimetros." />
                </td>
                <td>
                    <asp:Label Text="Perímetro cefálico (cm)" AssociatedControlID="txtPerimetroCefalico"
                        runat="server" />
                    <asp:TextBox Width="145px" ID="txtPerimetroCefalico" runat="server" CssClass="tooltipeable"
                        title="Solo numeros, en centimetros." />
                </td>
                <td>
                    <asp:Label Text="APGAR 1'" AssociatedControlID="txtAPGAR1" runat="server" />
                    <asp:TextBox Width="145px" ID="txtAPGAR1" runat="server" CssClass="tooltipeable"
                        title="Solo numeros." />
                </td>
                <td>
                    <asp:Label Text="APGAR 5'" AssociatedControlID="txtAPGAR5" runat="server" />
                    <asp:TextBox Width="145px" ID="txtAPGAR5" runat="server" CssClass="tooltipeable"
                        title="Solo numeros." />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblGemelar" Text="Gemelar" AssociatedControlID="rblGemelar" runat="server" />
                    <asp:RadioButtonList runat="server" ID="rblGemelar" CssClass="rbList"
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="0">No</asp:ListItem>
                        <asp:ListItem Value="1">Si</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:Label ID="lblNumroGesta" runat="server" Text="Nro Gesta" AssociatedControlID="txtNumeroGesta"></asp:Label>
                    <asp:TextBox runat="server" ID="txtNumeroGesta" Width="145px" CssClass="tooltipeable"
                        title="Solo numeros."></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblPesoAlAlta" Text="Peso al Alta (gr.)" AssociatedControlID="txtPesoAlAlta"
                        runat="server"></asp:Label>
                    <asp:TextBox Width="145px" ID="txtPesoAlAlta" runat="server" CssClass="tooltipeable"
                        title="Solo Numeros, en gramos."></asp:TextBox>
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset class="ui-widget ui-widget-content ui-corner-all" >
        <legend>Diagnostico NeoNatal</legend>
        <table class="formulario">
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblDiagnosticoNeonatal" Text="Diagnostico NeoNatal"
                        AssociatedControlID="ddlDiagNeoNatalTemporal"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlDiagNeoNatalTemporal" Width="145px">
                        <asp:ListItem Text="[SELECCIONE]" Value=""></asp:ListItem>
                        <asp:ListItem Text="Termino" Value="Termino"></asp:ListItem>
                        <asp:ListItem Text="PreTermino" Value="PreTermino"></asp:ListItem>
                        <asp:ListItem Text="PosTermino" Value="PosTermino"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblDiagNeoNatal" Text="Peso" AssociatedControlID="ddlDiagNeoNatalFisico"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlDiagNeoNatalFisico" Width="145px">
                        <asp:ListItem Text="[SELECCIONE]" Value=""></asp:ListItem>
                        <asp:ListItem Text="Peso Adecuado" Value="Peso Adecuado"></asp:ListItem>
                        <asp:ListItem Text="Bajo Peso" Value="Bajo Peso"></asp:ListItem>
                        <asp:ListItem Text="Peso Alto" Value="Peso Alto"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblOEARealizado" Text="OEA Realizado" AssociatedControlID="ddlOEARealizado">
                
                    </asp:Label>
                    <asp:DropDownList runat="server" ID="ddlOEARealizado" Width="145px">
                        <asp:ListItem Text="[SELECCIONE]" Value=""></asp:ListItem>
                        <asp:ListItem Text="Presente Bilateral" Value="Presente Bilateral"></asp:ListItem>
                        <asp:ListItem Text="Requiere Nueva Evaluacion" Value="Requiere Nueva Evaluacion"></asp:ListItem>
                        <asp:ListItem Text="No se realizo" Value="No se realizo"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblScreeningRealizado" Text="Screening Realizado" AssociatedControlID="rblScreeningRealizado"></asp:Label>
                    <asp:RadioButtonList runat="server" ID="rblScreeningRealizado" CssClass="rbList"
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="0">No</asp:ListItem>
                        <asp:ListItem Value="1">Si</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblScreeningNormal" Text="Screening Normal" AssociatedControlID="rblScreeningNormal"></asp:Label>
                    <asp:RadioButtonList runat="server" ID="rblScreeningNormal" CssClass="rbList" RepeatDirection="Horizontal">
                        <asp:ListItem Value="0">No</asp:ListItem>
                        <asp:ListItem Value="1">Si</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:Label runat="server" ID="lblOtrosDiagnosticos" Text="OtrosDiagnosticos" AssociatedControlID="DiagnosticoSecundario1">
                    </asp:Label>
                    <uc1:DiagnosticoSecundario ID="DiagnosticoSecundario1" runat="server"></uc1:DiagnosticoSecundario>
                </td>
            </tr>
        </table>
    </fieldset>
    <asp:Repeater ID="rptFactoresRiesgo" runat="server" OnItemDataBound="rptFactoresRiesgo_ItemDataBound">
        <HeaderTemplate>
            <fieldset class="ui-widget ui-widget-content ui-corner-all" />
                <legend>Factores de riesgo</legend>
                <table class="formulario">
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:CheckBox runat="server" ID="cbFactor" />
                    <asp:HiddenField runat="server" ID="hfIdFactor" Value='<%# Eval("idFactorRiesgo") %>' />
                </td>
                <td>
                    <asp:Label runat="server" AssociatedControlID="cbFactor" Text='<%# Eval("Nombre") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table> </fieldset>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
<%-- Botonera --%>
<asp:Content ID="Content4" ContentPlaceHolderID="Botones" runat="server">
    <asp:Button Text="Guardar" runat="server" ID="btnGuardar" OnClick="btnGuardar_Click" />
</asp:Content>
