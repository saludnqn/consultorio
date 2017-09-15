<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consultas.aspx.cs" Inherits="Consultorio.ConsultaAmbulatoria.Consultas"
    MasterPageFile="~/ConsultaAmbulatoria/MasterPages/Consultorio.master" Theme="apr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .tab
        {
            width: 60%;
            border: solid 1px #6ea6d1;
        }
        .tabr
        {
            border: solid 1px #6ea6d1;
        }
        .contentBox
        {
            background: white;
            width: 100%;
            height: auto;
            overflow: auto;
        }
        .btn
        {
            margin-bottom: -10px;
            border: none;
        }
    </style>

    <script type="text/javascript">
    $(document).ready(function() {
      $('#<%= tabs.ClientID %>').tabs();
    });
    </script>

    <script src="../../../js/Format.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="server">
    CONSULTAS EXISTENTES
     <hr style="background-color: #87b6d9" />
    <div>
        Establecimiento:
       <asp:DropDownList runat="server" ID="ddlEfector"
            DataValueField="idEfector" DataTextField="nombre" AutoPostBack="true" OnSelectedIndexChanged="ddlEfector_SelectedIndexChanged" TabIndex="1" ToolTip="Seleccione el Efector o Establecimiento">
        </asp:DropDownList>
        <br /><br />
        Fecha de Inicio:
        <asp:TextBox ID="txtFInicio" onblur="javascript:formatearFecha(this)" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
            runat="server" Width="100px" TabIndex="2"></asp:TextBox>
        &nbsp;&nbsp;&nbsp; Fecha de Fin:
        <asp:TextBox ID="txtFFin" onblur="javascript:formatearFecha(this)" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
            runat="server" Width="100px" TabIndex="3"></asp:TextBox>
    <br /><br />
        Tipo de Profesional:
        <asp:DropDownList runat="server" ID="ddlTipoProfesional" DataValueField="idTipoProfesional"
            DataTextField="nombre" AutoPostBack="false" ToolTip="Seleccione el Tipo de Profesional que realizó la consulta" TabIndex="4">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;
        <asp:Button runat="server" ID="btnFiltrar" Text="Buscar" ToolTip="Buscar datos según filtros seleccionados"
            OnClick="btnBuscar_Click" TabIndex="5" /><asp:ImageButton ID="IBExel" CssClass="btn" OnClick="IBExel_Click"
                ImageUrl="~/App_Themes/Clasificacion/images/exell2.png" runat="server" TabIndex="6"
                ToolTip="Exporta la Información en Pantalla a Excel" />
             </div>   
    <div id="tabs" runat="server">
        <ul>
            <li id="li6meses"><a href="#div6meses">Consultas </a></li>
        </ul>
        <div id="div6meses">
            <br />
            <div class="contentBox">
                <asp:GridView ID="gvConsultas" runat="server" AutoGenerateColumns="false" ForeColor="#333333"
                    Width="100%" OnSorting="gridView_Sorting" AllowPaging="true" OnPageIndexChanging="gvConsultas_PageIndexChangind"
                    PageSize="10" EmptyDataText="<b>No se encontraron datos.<b>" Font-Size="8pt">
                    <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
                    <Columns>
                        <asp:BoundField DataField="efector" HeaderText="Efector" />
                        <asp:BoundField DataField="especialidad" HeaderText="Especialidad" />
                        <asp:BoundField DataField="profesional" HeaderText="Profesional" />
                        <asp:BoundField DataField="tipoProfesional" HeaderText="TipoProfesional" />
                        <asp:BoundField DataField="numeroDocumento" HeaderText="Documento" />
                        <asp:BoundField DataField="paciente" HeaderText="Paciente" />
                        <asp:BoundField DataField="edad" HeaderText="Edad" />
                        <asp:BoundField DataField="codigo" HeaderText="Código" />
                        <asp:BoundField DataField="diagnostico" HeaderText="Diagnóstico" />
                        <asp:BoundField DataField="FechaConsulta" DataFormatString="{0:dd/MM/yyy}" HeaderText="FechaConsulta" />
                        <asp:BoundField DataField="FechaRegistro" DataFormatString="{0:dd/MM/yyy}" HeaderText="FechaRegistro" />
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </div>
            <br />
        Cantidad de Registros:
        <asp:Label ID="lblCantidad" runat="server" Text=""></asp:Label>
                </div>
    </div>
</asp:Content>
