<%@ Page Title="" Language="C#" MasterPageFile="~/mConsultorio.Master" AutoEventWireup="true"
    CodeBehind="TablaConsultorios.aspx.cs" Inherits="Consultorio.Abm.TablaConsultorios" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<%@ Register Assembly="Subsonic" Namespace="SubSonic" TagPrefix="subsonic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Turnos.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="../../js/jquery-ui-1.7.1.custom.css" />
    <script type="text/javascript" src="../../js/jquery.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">
    <br />
    <br />
    <br />
    <br />
    <ajx:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptLocalization="true"
        EnableScriptGlobalization="true">
    </ajx:ToolkitScriptManager>
    <!-- capa externa !-->
    <div class="div_exterior" style="background-color: #FAFAFA;">
        <!-- barra izquierda !-->
        <div class="div_izquierdo20" style="height: 98%; width: 25%;">
            <asp:UpdatePanel ID="updfiltro" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                <ContentTemplate>
                    <!-- parámetros de búsqueda !-->
                    <div>
                        <div style="overflow: hidden; height: 100%;">
                            <div>
                                <b style="font-weight: bolder;">Tipos de consultorio</b>
                            </div>
                            <div id="resultadosAgenda" runat="server" visible="true" style="margin-top: 5px;
                                margin-bottom: 5px;">
                                <asp:GridView ID="gvTipos" runat="server" GridLines="Both" Font-Names="Calibri" Font-Size="10pt"
                                    AutoGenerateColumns="False" Width="95%" DataKeyNames="idTipoConsultorio" CellPadding="2"
                                    AllowPaging="True" PageSize="17" ShowHeader="true" EmptyDataText="No se encontraron tipos de consultorio"
                                    OnPageIndexChanged="gvTipos_PageIndexChanged" OnRowDataBound="gvTipos_RowDataBound"
                                    OnSelectedIndexChanged="gvTipos_SelectedIndexChanged">
                                    <PagerStyle Font-Bold="True" Font-Underline="True" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="#333333" />
                                    <PagerSettings PageButtonCount="4" LastPageText="&gt;&gt;" />
                                    <SelectedRowStyle BackColor="LightYellow" />
                                    <Columns>
                                        <asp:BoundField DataField="nombre" HeaderText="Espacio físico">
                                            <HeaderStyle HorizontalAlign="Justify" />
                                            <ItemStyle HorizontalAlign="Justify" Font-Names="Verdana, Arial" Font-Size="Smaller"
                                                ForeColor="Maroon" />
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <%--<asp:ImageButton ID="cmdSel" runat="server" CommandName="Select" AlternateText="Seleccionar" 
                          ToolTip="Seleccionar Tipo de Consultorio"  ImageUrl="~/App_Themes/consultorio/Agenda/seleccionar.png"  />--%>
                                                <asp:LinkButton ID="cmdSel" runat="server" AlternateText="seleccionar" CommandName="Select">
                                                    <asp:Image ID="image1" runat="server" ImageUrl="~/App_Themes/consultorio/Agenda/seleccionar.png"
                                                        Style="border-width: 0px;" />
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="10px" Font-Names="Verdana, Arial" Font-Size="Smaller"
                                                ForeColor="Maroon" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle />
                                </asp:GridView>
                            </div>
                            <div id="divBotones" runat="server" style="width: 100%; text-align: right;">
                                <asp:LinkButton ID="cmdNuevoTipo" runat="server" CssClass="links" OnClick="cmdNuevoTipo_Click"
                                    Style="text-decoration: underline; vertical-align: middle; cursor: pointer;"> 
                  
                  Nuevo tipo de consultorios 
                                </asp:LinkButton>
                                <br />
                                <br />
                                <asp:LinkButton ID="cmdNuevoConsultorio" runat="server" CssClass="links" OnClick="cmdNuevoConsultorio_Click"
                                    Style="text-decoration: underline; vertical-align: middle; cursor: pointer;"> 
                  
                  Nuevo consultorio 
                                </asp:LinkButton>
                                <br />
                                <br />
                                <asp:LinkButton ID="cmdRenombrar" runat="server" CssClass="links" Visible="false"
                                    Style="text-decoration: underline; vertical-align: middle; cursor: pointer;"
                                    OnClick="cmdRenombrar_Click"> 
                  
                  Cambiar el nombre
                                </asp:LinkButton>
                                <br />
                                <br />
                                <asp:LinkButton ID="cmdEliminar" runat="server" CssClass="links" Visible="false"
                                    Style="text-decoration: underline; vertical-align: middle; cursor: pointer;"
                                    OnClick="cmdEliminar_Click"> 
                  
                  Eliminar el tipo de consultorio
                                </asp:LinkButton>
                            </div>
                            <div id="divEdit" runat="server" visible="false" style="width: 90%; height: auto;
                                border: dotted 1px Gray; padding: 5px; margin: 5px 0px 5px 0px; background-color: #F1E2BB;
                                overflow: auto;">
                                <asp:Label ID="lblEdit" runat="server" Text="" Width="100%" CssClass="labeldatos"></asp:Label>
                                <asp:TextBox ID="txtEdit" runat="server" CssClass="myTexto"></asp:TextBox><br />
                                <br />
                                <div style="width: 100%; text-align: right;">
                                    <asp:Button ID="cmdGrabar" Width="100px" runat="server" Text="Grabar" CssClass="myButtonRojo"
                                        OnClick="cmdGrabar_Click" />&nbsp;
                                    <asp:Button ID="cmdCancelar" rWidth="100px" unat="server" Text="Cancelar" CssClass="myButtonRojo"
                                        OnClick="cmdCancelar_Click" />
                                </div>
                            </div>
                            <div id="divNuevoConsultorio" runat="server" visible="false" style="width: 90%; height: auto;
                                border: dotted 1px Maroon; padding: 5px; margin: 5px 0px 5px 0px; background-color: #F1E2BB;
                                overflow: auto;">
                                <asp:Label ID="Label1" runat="server" Text="Tipo de consultorios" Width="100%" CssClass="labeldatos"></asp:Label>
                                <asp:DropDownList Width="200px" ID="ddlTipoConsultorio" runat="server" CssClass="myTexto">
                                </asp:DropDownList>
                                <%--<subsonic:DropDown ID="ddlTipoCons" runat="server" TableName="CON_ConsultorioTipo" TextField="nombre" ShowPrompt="false"></subsonic:DropDown>--%>
                                <br />
                                <br />
                                <asp:Label ID="Label2" runat="server" Text="Nombre del nuevo consultorio" Width="100%"
                                    CssClass="labeldatos"></asp:Label>
                                <asp:TextBox ID="txtNuevoConsultorio" runat="server" CssClass="myTexto"></asp:TextBox><br />
                                <br />
                                <div style="width: 100%; text-align: right;">
                                    <asp:Button ID="cmdGrabarCons" runat="server" Text="Grabar" CssClass="myButtonRojo"
                                        OnClick="cmdGrabarCons_Click" Width="100px" />&nbsp;
                                    <asp:Button ID="cmdCancelarCons" runat="server" Text="Cancelar" CssClass="myButtonRojo"
                                        OnClick="cmdCancelar_Click" Width="100px" />
                                </div>
                            </div>
                            <div id="divConfirma" runat="server" visible="false" style="width: 90%; height: auto;
                                border: dotted 1px Maroon; padding: 5px; background-color: #F1E2BB;">
                                <div style="float: left; width: 46px;">
                                    <img alt="confirme" src="../../App_Themes/consultorio/Agenda/ayuda48.png" />
                                </div>
                                <div style="float: left; text-align: left; width: 250px;">
                                    <asp:Label ID="lblConfirma" runat="server" class="labelerror" Style="font-weight: bolder;"></asp:Label>
                                    <input type="hidden" id="inpConfirma" runat="server" value="" />
                                </div>
                                <div style="text-align: center; width: 100%;">
                                    <asp:Button ID="cmdSi" runat="server" Text="Si" CssClass="boxcortos" Style="text-align: center;"
                                        OnClick="cmdSi_Click" />
                                    &nbsp;
                                    <asp:Button ID="cmdNo" runat="server" Text="No" CssClass="boxcortos" Style="text-align: center;"
                                        OnClick="cmdNo_Click" />
                                </div>
                            </div>
                            <div id="divError" runat="server" visible="false" style="width: 90%; height: auto;
                                border: dotted 1px Maroon; padding: 5px; margin: 5px 0px 5px 0px; background-color: #F1E2BB;
                                overflow: auto;">
                                <div style="float: left; width: 46px;">
                                    <img alt="confirme" src="../../App_Themes/consultorio/Agenda/boton-de-error-icono-5371-48.png" />
                                </div>
                                <div style="float: left; text-align: center; width: 220px;">
                                    <asp:Label ID="lblError" runat="server" class="labelerror" Style="font-weight: bolder;
                                        width: 100%;"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <!-- columnas laterales derechas !-->
        <div class="div_derecho80" style="height: 100%; width: 74%; padding-bottom: inherit;
            vertical-align: top;">
            <!-- barra central !-->
            <asp:UpdatePanel ID="pnlResultados" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="div_izquierdo50" style="width: 49%; height: 100%; float: left; padding: 0;
                        text-align: center; background: White;">
                        <!-- listado de consultorios contenidos !-->
                        <div id="divGrilla" runat="server" style="width: 98%; height: 99%; overflow: auto;
                            margin-top: 10px; margin-bottom: 5px;">
                            <asp:GridView ID="gvConsultorios" runat="server" AutoGenerateColumns="False" CellPadding="2"
                                Width="100%" DataKeyNames="idConsultorio" ForeColor="#333333" GridLines="None"
                                EmptyDataText="El tipo de consultorios seleccionado no contiene consultorios asociados"
                                OnPageIndexChanged="gvConsultorios_PageIndexChanged" OnRowCommand="gvConsultorios_RowCommand"
                                OnRowDataBound="gvConsultorios_RowDataBound">
                                <PagerStyle Font-Bold="True" Font-Underline="True" HorizontalAlign="Center" />
                                <PagerSettings LastPageText="&gt;&gt;" PageButtonCount="4" />
                                <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="#333333" />
                                <RowStyle CssClass="grfila" Height="25px" />
                                <Columns>
                                    <asp:BoundField DataField="idConsultorio" HeaderText="ID" Visible="false">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Justify" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nombre" HeaderText="Nombre descriptivo" Visible="true">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Justify" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Activo" Visible="false" HeaderText="Activo">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Justify" />
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="cmdRenombrar" runat="server" CommandName="cmdRenombrar" AlternateText="Renombrar"
                                                ToolTip="Cambiar nombre" ImageUrl="~/App_Themes/consultorio/Agenda/editar-el-texto-icono-3973-16.png" />
                                            &nbsp;
                                            <asp:ImageButton ID="cmdActivar" runat="server" CommandName="cmdActivar" AlternateText="Activar"
                                                ToolTip="Activar consultorio" ImageUrl="~/App_Themes/consultorio/Agenda/de-alerta-de-mensaje-icono-8710-16.png" />
                                            &nbsp;
                                            <asp:ImageButton ID="cmdEliminar" runat="server" CommandName="cmdEliminar" AlternateText="Eliminar"
                                                ToolTip="Eliminar consultorio" ImageUrl="~/App_Themes/consultorio/Agenda/boton-de-error-icono-5371-16.png" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                </Columns>
                                <SelectedRowStyle CssClass="grfilaseleccionada" ForeColor="White" Height="25px" />
                                <AlternatingRowStyle CssClass="grfilaalterna" Height="25px" />
                            </asp:GridView>
                        </div>
                    </div>
                    <!-- barra lateral derecha !-->
                    <div class="div_derecho50" style="width: 48%; height: 100%; margin-right: 8px; text-align: center;">
                        <div class="encabezadoagenda" style="background: White; height: 490px; width: auto;
                            margin: 10px 0 10px 10px; padding: 5px 5px 5px 5px;">
                            <br />
                            <div id="divEditConsultorio" runat="server" visible="false" style="width: 90%; height: auto;
                                border: solid 1px Maroon; padding: 5px; margin: 5px 0px 5px 0px; background-color: #F1E2BB;
                                overflow: auto;">
                                <asp:Label ID="Label3" runat="server" Text="Indique nuevo nombre" Width="100%" CssClass="labeldatos"></asp:Label>
                                <asp:TextBox ID="txtConsultorio" runat="server" CssClass="myTexto"></asp:TextBox><br />
                                <br />
                                <div style="width: 100%; text-align: right;">
                                    <asp:Button ID="cmdGrabarConsultorio" Width="100px" runat="server" Text="Grabar"
                                        CssClass="myButtonRojo" OnClick="cmdGrabarConsultorio_Click" />&nbsp;
                                    <asp:Button ID="cmdCancelarConsultorio" Width="100px" runat="server" Text="Cancelar"
                                        CssClass="myButtonRojo" OnClick="cmdNoConsultorio_Click" />
                                </div>
                            </div>
                            <div id="divConfirmaConsultorio" runat="server" visible="false" style="width: 90%;
                                height: auto; border: solid 1px Maroon; padding: 5px; background-color: #F1E2BB;">
                                <div style="float: left; width: 46px;">
                                    <img alt="confirme" src="../../App_Themes/consultorio/Agenda/ayuda48.png" />
                                </div>
                                <div style="float: left; text-align: left; width: 250px;">
                                    <asp:Label ID="lbl" runat="server" class="labelerror" Style="font-weight: bolder;">¿Confirma eliminar el consultorio?</asp:Label>
                                    <input type="hidden" runat="server" id="inpIdConsultorio" />
                                </div>
                                <div style="text-align: center; width: 100%;">
                                    <asp:Button ID="cmdSiConsultorio" runat="server" Text="Si" CssClass="boxcortos" Style="text-align: center;"
                                        OnClick="cmdSiConsultorio_Click" />
                                    &nbsp;
                                    <asp:Button ID="cmdNoConsultorio" runat="server" Text="No" CssClass="boxcortos" Style="text-align: center;"
                                        OnClick="cmdNoConsultorio_Click" />
                                </div>
                            </div>
                            <div id="divErrorConsultorio" runat="server" visible="false" style="width: 90%; height: auto;
                                border: solid 1px Maroon; padding: 5px; margin: 5px 0px 5px 0px; background-color: #F1E2BB;
                                overflow: auto;">
                                <div style="float: left; width: 46px;">
                                    <img alt="confirme" src="../../App_Themes/consultorio/Agenda/boton-de-error-icono-5371-48.png" />
                                </div>
                                <div style="float: left; text-align: center; width: 220px;">
                                    <asp:Label ID="lblErrorConsultorio" runat="server" class="labelerror" Style="font-weight: bolder;
                                        width: 100%;"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
