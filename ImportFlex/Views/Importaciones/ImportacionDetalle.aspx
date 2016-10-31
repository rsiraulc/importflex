<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImportacionDetalle.aspx.cs" Inherits="ImportFlex.Views.Importaciones.ImportacionDetalle" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2016.2.504.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-12" style="margin-top: 20px;">
        <div class="row" style="margin-bottom: 20px;">
            <div class="col-sm-12">
                <telerik:RadLabel ID="lblTitulo" CssClass="h2" runat="server"></telerik:RadLabel>
            </div>
            <div class="col-sm-3">
                <asp:Button ID="btnNuevaFactura" OnClientClick="OpenWindow();return false;" CssClass="btn btn-block btn-primary btn-md" Style="margin-top: 20px;" runat="server" Text="Registrar Factura" />
            </div>
            <div class="col-sm-6"></div>
            <div class="col-sm-3">
                <asp:Button ID="btnExportar" CssClass="btn btn-block btn-primary btn-md" Style="margin-top: 20px;" runat="server" Text="Exportar Formatos" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <telerik:RadGrid ID="gvFactura" runat="server" Width="100%" AutoGenerateColumns="False">
                    <MasterTableView DataKeyNames="facIdFactura">
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="ID" UniqueName="ID" DataField="facIdFactura"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="No. Factura" UniqueName="NoFactura" DataField="facNumeroFactura"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Proveedor" UniqueName="ProveedorNombre" DataField="imf_proveedores_prv.prvCodigo"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Fecha Facturación" UniqueName="fechaFacturacion" DataField="facFechaFactura"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Fecha Registro" UniqueName="fechaRegistro" DataField="facFechaRegistro"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Valor USD" UniqueName="ValorUSD" DataField="facValorUsd"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Valor ME" UniqueName="ValorME" DataField="facValorExtranjera"></telerik:GridBoundColumn>
                            <%--<telerik:GridBoundColumn HeaderText="Flete" UniqueName="Flete" DataField="facFlete"></telerik:GridBoundColumn>--%>
                            <%--<telerik:GridBoundColumn HeaderText="Código Importador" UniqueName="CodigoImportador" DataField="imf_importaciones_imp.impCodigoImportador"></telerik:GridBoundColumn>--%>
                            <telerik:GridTemplateColumn UniqueName="Detalle">
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ToolTip="Ver Detalle" ID="imgBtnDetalle" Width="32px" ImageUrl="~/Images/iconDetails.png" PostBackUrl='<%# ResolveUrl("~/Views/Importaciones/FacturaDetalle?ID="+Eval("facIdFactura")) %>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </div>
        </div>
    </div>


    <!-- MODAL PARA AGREGAR FACTURAS  -->
    <telerik:RadWindowManager runat="server" ID="radWindowManager" DestroyOnClose="True" EnableShadow="True" Title="Nueva Factura">
        <Windows>
            <telerik:RadWindow ID="radWindowNuevaFactura" Style="z-index: 2001;" AutoSize="True" MinWidth="800px" MaxHeight="450px" Width="850" MinHeight="250px" AutoSizeBehaviors="Width, Default" DestroyOnClose="True" Modal="True" Animation="Fade" runat="server" Behaviors="Close">
                <ContentTemplate>
                    <div class="container" id="divTipoUnidad" style="width: 800px; z-index: 5002">
                        <div class="row" style="margin-top: 20px;">
                            <div class="col-sm-12">
                                <h3>Agregar Nueva Factura</h3>
                            </div>
                        </div>
                        <!-- FILA 1 -->
                        <div class="row" style="margin-top: 20px">
                            <div class="col-sm-4">
                                <div class="col-lg-4 col-md-12 col-xs-12">
                                    <span class="text-formulario">Proveedor</span>
                                </div>
                                <div class="col-lg-8 col-md-12 col-xs-12">
                                    <telerik:RadComboBox ID="cbProveedor" RenderMode="Lightweight" DataValueField="prvIdProveedor" DataTextField="prvCodigo" runat="server" Width="100%"></telerik:RadComboBox>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="col-lg-4 col-md-12 col-xs-12">
                                    <span class="text-formulario">No. Factura</span>
                                </div>
                                <div class="col-lg-8 col-md-12 col-xs-12">
                                    <telerik:RadTextBox ID="txbNumeroFactura" runat="server" Width="100%"></telerik:RadTextBox>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="col-lg-4 col-md-12 col-xs-12">
                                    <span class="text-formulario">Fecha</span>
                                </div>
                                <div class="col-lg-8 col-md-12 col-xs-12">
                                    <telerik:RadDatePicker ID="dpFechaFacturacion" runat="server" Width="100%"></telerik:RadDatePicker>
                                </div>
                            </div>
                        </div>

                        <!-- FILA 2 -->
                        <div class="row" style="margin-top: 10px">
                            <div class="col-sm-4">
                                <div class="col-lg-4 col-md-12 col-xs-12">
                                    <span class="text-formulario">Valor USD</span>
                                </div>
                                <div class="col-lg-8 col-md-12 col-xs-12">
                                    <telerik:RadNumericTextBox ID="tbxValorUSD" NumberFormat-DecimalDigits="2" Type="Currency" runat="server" ShowSpinButtons="False" Width="100%"></telerik:RadNumericTextBox>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="col-lg-4 col-md-12 col-xs-12">
                                    <span class="text-formulario">Valor ME</span>
                                </div>
                                <div class="col-lg-8 col-md-12 col-xs-12">
                                    <telerik:RadNumericTextBox ID="tbxValorME" NumberFormat-DecimalDigits="2" Type="Currency" runat="server" ShowSpinButtons="False" Width="100%"></telerik:RadNumericTextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 15px">
                            <div class="col-lg-4 col-md-4 col-xs-4 ">
                                <asp:Button runat="server" CssClass="btn btn-block btn-danger" Text="Cancelar" OnClientClick="CloseWindow();return false;" ID="btnCloseWindowNuevaVenta" />
                            </div>
                            <div class="col-lg-4 col-md-4 col-xs-4"></div>
                            <div class="col-lg-4 col-md-4 col-xs-4">
                                <asp:Button runat="server" CssClass="btn btn-block btn-primary" Text="Guardar" OnClick="btnGuardarFactura_OnClick" ID="btnRegistrarFactura" />
                            </div>
                        </div>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>

    <telerik:RadCodeBlock runat="server">
        <script>
            function OpenWindow() {
                window.radopen("Nueva Factura", "radWindowNuevaFactura");
            }
            function CloseWindow() {
                var window = $find('<%=radWindowNuevaFactura.ClientID%>');
                window.close();
                return false;
            }
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
