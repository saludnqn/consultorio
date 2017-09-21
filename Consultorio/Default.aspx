<%@ Page Title="" Language="C#" MasterPageFile="~/mConsultorio.Master" Inherits="Consultorio.Default" AutoEventWireup="true" CodeBehind="Default.aspx.cs"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cuerpo" runat="server">
    <div style="text-align: left; width: 80%">
        <a href="https://www.saludnqn.gob.ar/Sips" visible="false" target="_blank" runat="server" id="btnSips">Acceso al SIPS (Sistema Integrado Provincial de Salud) </a>
        <link href="App_Themes/Metro/css/metro-bootstrap.min.css" rel="stylesheet" />
    </div>

    <div id="modulos">

        <asp:ListView runat="server" GroupItemCount="6" ID="lvModulos" EnableTheming="True"
            ItemPlaceholderID="menuItem">
            <LayoutTemplate>
                <asp:PlaceHolder runat="server" ID="groupPlaceHolder" />
            </LayoutTemplate>


            <GroupTemplate>
                <div style="clear: both; width: 95%; text-align: center;">
                    <asp:PlaceHolder runat="server" ID="menuItem" />
                </div>
            </GroupTemplate>
            <ItemTemplate>
                <div class="col-md-3">
                    <div class="thumbnail tile tile-wide tile-<%# Eval("colorMetro")%>">
                        <a  href='<%# Page.ResolveUrl(Eval("urlPage").ToString()) %>' class="fa-links">

                            <h1>
                                <%# Eval("description")%>
                            </h1>

                            <img src='<%# Page.ResolveUrl(Eval("image").ToString()) %>' alt='<%# Eval("description")%>'">
                            
                        </a>
                    </div>
                </div>
            </ItemTemplate>
            <ItemSeparatorTemplate>
                <div class="menuItem">
                </div>
            </ItemSeparatorTemplate>
            <GroupSeparatorTemplate>
            </GroupSeparatorTemplate>
            <EmptyDataTemplate>
            </EmptyDataTemplate>
        </asp:ListView>
    </div>

    <!--  pagina que procese con el ticket de usuario la redireccion al sips-->
</asp:Content>
