<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Enfermeria.ascx.cs" Inherits="Consultorio.ConsultaAmbulatoria.ControlMenor.Enfermeria" %>

<script type="text/javascript">
    $(document).ready(function() {
        $('#<%= txtPeso.ClientID %>').blur(calculaICM);
        $('#<%= txtTalla.ClientID %>').blur(calculaICM);
    });
    function calculaICM() {
        var peso = $('#<%= txtPeso.ClientID %>').val();
        var talla = $('#<%= txtTalla.ClientID %>').val();
        if ((peso.length > 0) && !isNaN(peso) && (talla.length > 0) && !isNaN(talla)) {
            $('#<%= imgLoading.ClientID %>').show();
            //Busco el estado nutricional
            $.ajax({
                type: "GET",
                data: ({ idPaciente: $('#<%= hfPaciente.ClientID %>').val(), peso: peso, talla: talla }),
                url: '<%= ResolveUrl("~/ConsultaAmbulatoria/services/estnut.aspx") %>',
                context: document.body,
                complete: function(result) {
                    var estadonutricional = JSON.parse(result.responseText);
                    if (estadonutricional.idEstadoNutricional > 0) {
                        $('#<%= ddlEstadoNutricional.ClientID %>').selectmenu('value', estadonutricional.idEstadoNutricional);
                        $('#<%= ddlTallaEdad.ClientID %>').selectmenu('value', estadonutricional.idTalla);
                        var Imc2 = parseFloat(estadonutricional.IMC);
                        $('#<%= lblIMC.ClientID %>').text(Imc2.toPrecision(4));
                        //$('#<%= lblIMC.ClientID %>').text(estadonutricional.IMC);
                    } else {
                        $('#<%= lblIMC.ClientID %>').text(estadonutricional.nombre);
                    }
                    $('#<%= imgLoading.ClientID %>').hide();
                }
            });
        } else {
            $('#<%= lblIMC.ClientID %>').text('Ingrese talla y peso.');
        }
    };
</script>

<asp:HiddenField runat="server" ID="hfHabilitarIMC" Value="0" />
<asp:HiddenField runat="server" ID="hfPaciente" Value="0" />
<table class="formulario">
 <tr>
    <td>
    <asp:Label runat="server" ID="lblFecha" AssociatedControlID="txtFecha" Text="Fecha de Control:"></asp:Label>
     <asp:TextBox runat="server" ID="txtFecha" CssClass="tooltipeable" title="Ingresar la fecha del Control de Enfermería"></asp:TextBox>
    </td>
    <td>
    &nbsp;
    </td>
    </tr>
    <tr>
        <td style="width: 50%;">
            <asp:Label runat="server" ID="lblPeso" AssociatedControlID="txtPeso" Text="Peso (en Kg.):"></asp:Label>
            <asp:TextBox runat="server" ID="txtPeso" CssClass="tooltipeable" title="Ingresar el Peso en Kg. Ej.: 3.840"></asp:TextBox>
        </td>
        <td style="width: 50%;">
            <asp:Label runat="server" ID="lblEstadoNutricional" Text="Estado Nutricional" AssociatedControlID="ddlEstadoNutricional"></asp:Label>
            <asp:DropDownList runat="server" ID="ddlEstadoNutricional">
            </asp:DropDownList>
            <asp:Image runat="server" ID="imgLoading" ImageUrl="~/images/loading.gif" CssClass="loadingImage" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label runat="server" ID="lblTalla" AssociatedControlID="txtTalla" Text="Talla (en Metros):"></asp:Label>
            <asp:TextBox runat="server" ID="txtTalla" CssClass="tooltipeable" title="Ingresar la Talla en metros. Ej. 0.950"></asp:TextBox>
        </td>
        <td>
            IMC:<strong>
                <asp:Label runat="server" ID="lblIMC" Text="--" CssClass="tooltipeable" title="Cálculo automático a partir de los 2 años de edad."></asp:Label></strong>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label runat="server" ID="lblPerimetroCefalico" AssociatedControlID="txtPerimetroCefalico"
                Text="Perimetro Cefálico (en centímetros):"></asp:Label>
            <asp:TextBox runat="server" ID="txtPerimetroCefalico" CssClass="tooltipeable" title="Ingrese valor en centímetros: Ej. 54,00"></asp:TextBox><asp:RangeValidator
                ID="rvperimetrocefalico" runat="server" ErrorMessage="El perímetro no puede ser menor al valor anterior"
                MaximumValue="60" MinimumValue="30" ControlToValidate="txtPerimetroCefalico">*</asp:RangeValidator>
        </td>
        <td>
            <asp:Label runat="server" ID="lblTallaEdad" Text="Talla para la edad" AssociatedControlID="ddlTallaEdad"></asp:Label>
            <asp:DropDownList runat="server" ID="ddlTallaEdad">
            </asp:DropDownList>
        </td>
    </tr>
        <tr>
        <td>
     <asp:Label runat="server" ID="lblTA" AssociatedControlID="txtTA" Text="Tensión Arterial"></asp:Label>
     <asp:TextBox runat="server" ID="txtTA" CssClass="tooltipeable" title="Ingresar TA. Requerido para mayores de 3 años."></asp:TextBox> 
    </td>   
    <td>
     &nbsp;
    </td>
    </tr>
    <tr>
    <td colspan="2"><p />
    <hr style="background-color: #87b6d9" />
    </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label runat="server" ID="lblObservaciones" AssociatedControlID="txtObservaciones"
                Text="Observaciones del Control de Enfermería:"></asp:Label>
            <asp:TextBox runat="server" ID="txtObservaciones" TextMode="MultiLine" Rows="3" title="Ingrese las observaciones del caso."></asp:TextBox>
        </td>
    </tr>
    <tr align="center"> 
    <td>
    </td>
    <td align="center">
            <asp:Label runat="server" ID="lblEnfermeria" AssociatedControlID="ddlProfesional"
                Text="Profesional que realizó la consulta:"></asp:Label>
            <asp:DropDownList runat="server" ID="ddlProfesional">
            </asp:DropDownList>
    </td>
    </tr>
</table>
