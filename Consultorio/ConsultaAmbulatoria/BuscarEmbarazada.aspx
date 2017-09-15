<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscarEmbarazada.aspx.cs" MasterPageFile="~/ConsultaAmbulatoria/MasterPages/Consultorio.master"
     Inherits="Consultorio.ConsultaAmbulatoria.BuscarEmbarazada" Theme="apr" %>

<%@ MasterType VirtualPath="~/ConsultaAmbulatoria/MasterPages/Consultorio.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="server">
    <div>
      <b>Buscar Paciente</b>
        <div style="float: right; margin: -10px 60px 0px 0px">
            <img src="../App_Themes/Login/img/ctrolEmbarazo.gif" alt="Control Perinatal" />
            <a href="ControlPerinatal/css/HistoriaClinicaPerinatal.pdf" title="Descargar PDF Planilla de Control Perinatal"
                target="_blank" style="border: solid 2px green; padding-top: 0px">
                <img src="ControlPerinatal/css/hcppdf.png" alt="Descargar Planilla PDF: Frente y Dorso"
                    border="0" /></a>
      </div>
    <br />
    <div class="row">
        <div class="col-lg-6">
            <div class="input-group">
            <span class="input-group-btn">
        <button class="btn btn-default" type="button">Buscar</button>
      </span>
       <asp:TextBox ID="txtDni" runat="server" MaxLength="8" Width="100px" ToolTip="Solo números"
            TabIndex="1" CssClass="form-control"></asp:TextBox>
          <asp:CompareValidator ID="cvNDocumento" runat="server" ErrorMessage="Solo numeros enteros"
            ControlToValidate="txtDni" Operator="DataTypeCheck" Type="Integer" ></asp:CompareValidator> 
    </div>
  </div>
          
        



  </div>
  <asp:Label ID="lblTitulo" runat="server" Text="" Visible="false"></asp:Label><br />
  <asp:GridView ID="gvEmbarazadas" runat="server" AutoGenerateColumns="false" ForeColor="#333333"
        GridLines="None" Width="99%" AllowPaging="true" PageSize="10" Visible="false">
     <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
    <Columns>
      <asp:BoundField DataField="paciente" HeaderText="Paciente" />
      <asp:BoundField DataField="numeroDocumento" HeaderText="Documento" />
      <asp:BoundField DataField="edad" HeaderText="Edad" />
      <asp:BoundField DataField="fechaIngreso" DataFormatString="{0:dd/MM/yyy}" HeaderText="Fec.HCP" />
      <asp:BoundField DataField="efector" HeaderText="Efector Atención" />
      <asp:HyperLinkField DataNavigateUrlFields="idPaciente" DataNavigateUrlFormatString="~/ConsultaAmbulatoria/SeleccionTurno.aspx?idPaciente={0}"
        HeaderText="Acción" Text="Control" />
    </Columns>
    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
  </asp:GridView>
  <br />
  Resultado de Pacientes
  <asp:GridView ID="gvPacientes" runat="server" AutoGenerateColumns="false" ForeColor="#333333"
        GridLines="None" Width="99%" OnSorting="gridView_Sorting" AllowPaging="true" OnPageIndexChanging="gvPacientes_PageIndexChangind"
    PageSize="10" EmptyDataText="<b>No se encontraron datos.<b>">
     <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
    <Columns>
      <asp:BoundField DataField="apellido" HeaderText="Apellido" />
      <asp:BoundField DataField="nombre" HeaderText="Nombre" />
          <asp:BoundField DataField="numeroDocumento" HeaderText="Documento" />
      <asp:BoundField DataField="sexo" HeaderText="Sexo" />
      <asp:BoundField DataField="fechaNacimiento" DataFormatString="{0:dd/MM/yyy}" HeaderText="Fec.Nac" />
      <asp:HyperLinkField DataNavigateUrlFields="idPaciente" DataNavigateUrlFormatString="~/Paciente/PacienteView.aspx?id={0}"
        HeaderText="Ver" Text="Ver" />
      <asp:HyperLinkField DataNavigateUrlFields="idPaciente" DataNavigateUrlFormatString="~/Paciente/PacienteEdit.aspx?id={0}"
        HeaderText="Editar" Text="Editar" />
      <asp:HyperLinkField DataNavigateUrlFields="idPaciente" DataNavigateUrlFormatString="~/ConsultaAmbulatoria/SeleccionTurno.aspx?idPaciente={0}"
        HeaderText="Acción" Text="Control" />
    </Columns>
    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
  </asp:GridView>
  <br />
    <div id="pnHistoriaAnterior" runat="server" visible="false">
        <asp:Label ID="lblHistoriaAnterior" runat="server" Text="Historia Clinica Perinatal Anterior"></asp:Label><br />
        <asp:GridView ID="gvHistoriaAnterior" runat="server" AutoGenerateColumns="False"
            ForeColor="#333333" GridLines="None" Width="99%" PageSize="3" 
              CellPadding="4">
            <RowStyle BackColor="#E3EAEB" />
            <Columns>
                <asp:BoundField DataField="apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="edad" HeaderText="Edad" />
                <asp:BoundField DataField="FPP" DataFormatString="{0:dd/MM/yyy}" HeaderText="FP.Parto" />
                <asp:TemplateField HeaderText="Efector Control">
                    <ItemTemplate>
                        <asp:Label ID="lblEfector" runat="server" Text='<%# Eval("SysEfector.Nombre") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("Activa").ToString() == "True" ? Eval("Activa") : "HCP Cerrada" %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CreatedOn" DataFormatString="{0:dd/MM/yyy}" HeaderText="F.Creación" />
                <asp:BoundField DataField="observaciones" HeaderText="Observaciones" />
                <asp:HyperLinkField DataNavigateUrlFields="idPaciente" DataNavigateUrlFormatString="~/ConsultaAmbulatoria/ControlPerinatal/Control/?idPaciente={0}"
                    HeaderText="Acción" Text="Ver Control" />
            </Columns>
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </div>
    <br />
  <div style="border: solid 2px green; margin: 5px;">
  Actualización del Control del Embarazo - 30/09/2014
  <ul>
  <li>-Posibilidad de ingresar el efector o lugar del Traslado Intrauterino si correspondiese.</li>
  <li>-Nueva pestaña que permite el ingreso del Parto/Aborto.</li>
  <li>-Captación Oportuna cambia a las 14 semanas. Datos necesario para Plan Sumar.</li>
  <li>-Nuevos datos: detección de Diabetes y/o Anemia en el embarazo actual.</li>
  </ul>
  </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Botones" runat="server">
    <asp:Button runat="server" ID="btnBuscar" Text="Buscar" OnClick="btnBuscar_Click" TabIndex="2" />
  <asp:Button runat="server" ID="btnNuevo" Text="Nuevo Paciente" OnClick="btnNuevo_Click" />
</asp:Content>
