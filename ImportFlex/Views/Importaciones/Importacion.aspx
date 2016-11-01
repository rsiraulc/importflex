<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Importacion.aspx.cs" Inherits="ImportFlex.Views.Importaciones.Importacion" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-12" style="margin-top: 20px;">
        <div class="row">
            <div class="col-sm-10">
                <telerik:RadLabel ID="lblTitulo" CssClass="h2" runat="server" Text="Pedimentos"></telerik:RadLabel>
            </div>
            <div class="col-sm-2">
                <asp:Button runat="server" ID="btnNuevaImportacion" Style="margin: 20px;" OnClientClick="OpenWindow();return false;" CssClass="btn btn-block btn-primary btn-md" Text="Nuevo Pedimento" />
            </div>
        </div>
        <div class="row" style="padding: 5px 0px 5px 0px">
            <div class="well">
                <div class="col-sm-12">
                    <div class="row">
                        <div class="col-sm-5">
                            <label class="col-sm-4 control-label">Fecha</label>
                            <div class="col-sm-8">
                                <telerik:RadDatePicker ID="rdpFecha" runat="server" Skin="Bootstrap" Width="100%"></telerik:RadDatePicker>
                            </div>
                        </div>
                        <div class="col-sm-5">
                            <label class="col-sm-4 control-label">Status</label>
                            <div class="col-sm-8">
                                <telerik:RadComboBox ID="cbStatus" runat="server" Skin="Bootstrap" Width="100%"></telerik:RadComboBox>
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <asp:Button ID="btnFiltrar" runat="server" CssClass="btn btn-block btn-default" Text="Filtrar" OnClick="btnFiltrar_OnClick" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <telerik:RadGrid ID="rgImportaciones" runat="server" Width="100%" Skin="Bootstrap" AutoGenerateColumns="False">
                <MasterTableView DataKeyNames="impIdImportacion">
                    <Columns>
                        <telerik:GridBoundColumn HeaderText="Id" UniqueName="Id" DataField="impIdImportacion"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="No. Pedimento" UniqueName="NoPedimento" DataField="impNumeroPedimento"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Parte" UniqueName="Parte" DataField="impParte"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Fecha Registro" UniqueName="Fecha" DataField="impFecha"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Status" UniqueName="Status" DataField="impStatus"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Total Facturas" UniqueName="TotalFacturas" DataField="impTotalFacturas"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Total Articulos" UniqueName="TotalArticulos" DataField="impTotalArticulos"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Total" UniqueName="Total" DataField="impTotal" DataFormatString="{0:C}"></telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn UniqueName="Detalle">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ToolTip="Ver Detalle" ID="imgBtnDetalle" Width="32px" ImageUrl="~/Images/iconDetails.png"
                                    PostBackUrl='<%# ResolveUrl("~/Views/Importaciones/ImportacionDetalle?ID="+Eval("impIdImportacion")) %>' />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </div>
    </div>

    <!-- MODAL PARA CAPTURA DE NUEVA IMPORTACION -->
    <telerik:RadWindowManager runat="server" ID="radWindowManager" DestroyOnClose="True" Skin="Bootstrap" EnableShadow="True" Title="Nuevo Registro de Pedimento">
        <Windows>
            <telerik:RadWindow ID="radWindowNuevaImportacion" Style="z-index: 2001;" AutoSize="True" MinWidth="400px" MaxHeight="350px" Width="400" MinHeight="300px" AutoSizeBehaviors="Width, Default" DestroyOnClose="True" Modal="True" Animation="Fade" runat="server" Behaviors="Close">
                <ContentTemplate>
                    <div class="container" id="divTipoUnidad" style="width: 700px; z-index: 5002">
                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-xs-12">
                                <h3>Nuevo Pedimento</h3>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 10px">
                            <div class="col-sm-6">
                                <div class="col-lg-4 col-md-12 col-xs-12">
                                    <span class="text-formulario">No. de Pedimento</span>
                                </div>
                                <div class="col-lg-8 col-md-12 col-xs-12">
                                    <telerik:RadTextBox ID="tbxNumeroPedimento" runat="server" Skin="Bootstrap" Width="100%"></telerik:RadTextBox>
                                </div>
                            </div>
                            <div class="col-sm-6">

                                <div class="col-lg-4 col-md-12 col-xs-12">
                                    <span class="text-formulario">Región</span>
                                </div>
                                <div class="col-lg-8 col-md-12 col-xs-12">
                                    <telerik:RadComboBox ID="cbRegion" runat="server" DataValueField="Clave" DataTextField="Descripcion" Skin="Bootstrap" Width="100%"></telerik:RadComboBox>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 15px;">
                            <div class="col-sm-6">
                                <div class="col-lg-4 col-md-12 col-xs-12">
                                    <span class="text-formulario">Operación</span>
                                </div>
                                <div class="col-lg-8 col-md-12 col-xs-12">
                                    <telerik:RadComboBox ID="cbTipoOPeracion" runat="server" DataValueField="Clave" DataTextField="Descripcion" Skin="Bootstrap" Width="100%"></telerik:RadComboBox>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 20px; margin-bottom: 10px;">
                            <div class="col-lg-4 col-md-4 col-xs-4 ">
                                <asp:Button runat="server" CssClass="btn btn-block btn-danger" Text="Cancelar" OnClientClick="CloseWindow();return false;" ID="btnCloseWindowNuevaVenta" />
                            </div>
                            <div class="col-lg-4 col-md-4 col-xs-4"></div>
                            <div class="col-lg-4 col-md-4 col-xs-4">
                                <telerik:RadAjaxLoadingPanel ID="loadingPanel" runat="server" Skin="Default"></telerik:RadAjaxLoadingPanel>
                                <asp:Button runat="server" CssClass="btn btn-block btn-primary" Text="Guardar" OnClick="btnGuardarImportacion_OnClick" ID="btnGuardarImportacion" />

                            </div>
                        </div>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>

    <telerik:RadCodeBlock runat="server">
        <script>
            function OpenWindow() {
                window.radopen("Nueva Importación", "radWindowNuevaImportacion");
            }
            function CloseWindow() {
                var window = $find('<%=radWindowNuevaImportacion.ClientID%>');
                window.close();
                return false;
            }
        </script>
    </telerik:RadCodeBlock>

</asp:Content>
