<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ConsultaAmbulatoria.ControlPerinatal.Alerta.Default"
    MasterPageFile="~/ConsultaAmbulatoria/MasterPages/ConsultorioPerinatal.Master"
    Theme="apr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="server">
    <div>
            <p><b>Listado de Alertas en la Historia Clínica actual</b></p>
        <asp:GridView ID="gvAlertas" runat="server" AutoGenerateColumns="false" ForeColor="#C1CC9E"
          Width="80%" EmptyDataText="<b>No se encontraron datos.<b>" Font-Names="Verdana" Font-Size="9pt" BorderStyle="Solid" BorderColor="#5D7B9D" BorderWidth="1px">
          <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
        <Columns>
        <asp:BoundField DataField="Alertas" HeaderText="Alertas" />
        </Columns>
          <PagerStyle BackColor="#C1CC9E" ForeColor="White" HorizontalAlign="Center" />
          <SelectedRowStyle BackColor="#C1CC9E" Font-Bold="True" ForeColor="#333333" />
          <HeaderStyle BackColor="#C1CC9E" Font-Bold="True" ForeColor="White" Font-Size="10pt" />
          <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
    </div>
</asp:Content>
