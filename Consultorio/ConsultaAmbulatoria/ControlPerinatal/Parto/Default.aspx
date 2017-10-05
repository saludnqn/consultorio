<%@ Page Language="C#" AutoEventWireup="true" Theme="apr" MasterPageFile="~/ConsultaAmbulatoria/MasterPages/ConsultorioPerinatal.Master" CodeBehind="Default.aspx.cs" Inherits="ConsultaAmbulatoria.ControlPerinatal.Parto.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="server">
<%-- "Grilla" con Partos --%>
    <asp:Repeater ID="rptPartos" runat="server">
        <HeaderTemplate>
            <table id="tblPartos" cellpadding="0" cellspacing="0" border="0" class="display grilla">
                <thead>
                    <tr>
                        <th>
                            Editar
                        </th>
                        <th>
                            Fecha Nacimiento
                        </th>
                        <th>
                            Lugar Parto
                        </th>
                        <th>
                        Profesional
                        </th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                   <%-- <asp:HyperLink runat="server" ID="hlEditar" NavigateUrl='<%# String.Format("Edit.aspx?idHistoriaClinicaPerinatal={0}&id={1}",Eval("idHistoriaClinicaPerinatal"),Eval("idParto")) %>'
                        Text="Editar">
                    </asp:HyperLink>--%>

                     <asp:TemplateField HeaderText="Editar">
                               <ItemTemplate>
                                   <a href="<%# String.Format("Edit.aspx?idHistoriaClinicaPerinatal={0}&id={1}",Eval("idHistoriaClinicaPerinatal"),Eval("idParto")) %>" title="Editar">
                                      
                                       <img id="imgView" alt="Editar" border="0" src="../../App_Themes/Default/images/edit.png" />
                                   </a>
                               </ItemTemplate>
                           </asp:TemplateField>

                </td>
                <td>
                    <%# Eval("FechaNacimiento", "{0:dd/MM/yyyy}") %>
                </td>
                <td>
                    <%# Eval("SysEfector.Nombre") %>
                </td>
                <td>
                    <%# Eval("SysProfesional.Apellido") + ", " + Eval("SysProfesional.Nombre")%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody> </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="server">
    <asp:Button runat="server" ID="btnNuevo" Text="Nuevo" OnClick="btnNuevo_Click" />
</asp:Content>