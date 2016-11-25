<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImportacionDetalle.aspx.cs" Inherits="ImportFlex.Views.Importaciones.ImportacionDetalle" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2016.2.504.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-12" style="margin-top: 20px;">
        <div class="row" style="margin-bottom: 20px;">
            <div class="col-sm-12">
                <telerik:RadLabel ID="lblTitulo" CssClass="h2" runat="server" Skin="Bootstrap"></telerik:RadLabel>
            </div>
            <div class="col-sm-12">
                <telerik:RadLabel ID="lblDatosImportacion" runat="server"></telerik:RadLabel>
            </div>
            <div class="col-sm-3">
                <asp:Button ID="btnNuevaFactura" OnClientClick="OpenWindow(0);return false;" CssClass="btn btn-block btn-success btn-md" Style="margin-top: 20px;" runat="server" Text="Agregar Factura" />
            </div>
            <div class="col-sm-3">
                <asp:Button ID="btnFinalizarPedimento" CssClass="btn btn-block btn-success btn-md" Style="margin-top: 20px;" runat="server" Text="Cerrar Pedimento" OnClick="btnFinalizarPedimento_OnClick" Visible="False" />
            </div>
            <div class="col-sm-3">
                <asp:Button ID="btnUpdateNumeroPedimento" CssClass="btn btn-block btn-primary btn-md" Style="margin-top: 20px;" runat="server" Text="Actualizar Num. Pedimento" OnClientClick="OpenWindow(1);return false;" Visible="True" />
            </div>
            <div class="col-sm-3">
                <div class="btn-group" style="width: 100%">
                    <button type="button" id="btnMenuDescargar" runat="server" class="btn btn-block btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" style="width: 100%; margin-top: 20px;">
                        Descargar <span class="caret"></span>
                    </button>
                    <ul class="dropdown-menu" style="width: 100%">
                        <li>
                            <asp:LinkButton ID="lnkDescargarFormatos" runat="server" OnClick="lnkDescargarFormatos_OnClick" Width="100%">Formatos Aduana (.zip)</asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnkDescargarHT" runat="server" OnClick="lnkDescargarHT_OnClick" Width="100%">Hoja Traducción (.pdf)</asp:LinkButton></li>
                    </ul>
                </div>
                <%--<asp:Button ID="btnExportar" CssClass="btn btn-block btn-primary btn-md" Style="margin-top: 20px;" runat="server" Text="Descargar Formatos" OnClick="btnExportar_OnClick" />--%>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <telerik:RadGrid ID="gvFactura" runat="server" Width="100%" AutoGenerateColumns="False" Skin="Bootstrap">
                    <MasterTableView DataKeyNames="facIdFactura">
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="ID" UniqueName="ID" DataField="facIdFactura"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="No. Factura" UniqueName="NoFactura" DataField="facNumeroFactura"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="No. Entrada" UniqueName="NoEntrada" DataField="facNumeroEntrada"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Proveedor" UniqueName="ProveedorNombre" DataField="imf_proveedores_prv.prvCodigo"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Proveedor" UniqueName="ProveedorNombre" DataField="imf_proveedores_prv.prvCodigo"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Fecha Factura" UniqueName="fechaFacturacion" DataField="facFechaFactura"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Valor USD" UniqueName="ValorUSD" DataField="facValorUsd" DataFormatString="{0:C}"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Flete" UniqueName="Flete" DataField="facFlete" DataFormatString="{0:C}"></telerik:GridBoundColumn>
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
        <div class="row" style="margin-top: 20px;">
            <div class="col-sm-3">
                <telerik:RadLabel ID="lblTotalFacturas" CssClass="h4" runat="server"></telerik:RadLabel>
            </div>
            <div class="col-sm-6"></div>
            <div class="col-sm-3" style="text-align: right;">
                <telerik:RadLabel ID="lblValorTotal" CssClass="h3" runat="server"></telerik:RadLabel>
            </div>
        </div>
    </div>


    <!-- MODAL PARA AGREGAR FACTURAS  -->
    <telerik:RadWindowManager runat="server" ID="radWindowManager" DestroyOnClose="True" EnableShadow="True" Skin="Bootstrap" Title="ImportFlex">
        <Windows>
            <telerik:RadWindow ID="radWindowNuevaFactura" Style="z-index: 2001;" AutoSize="True" MinWidth="800px" MaxHeight="450px" Width="850" MinHeight="250px" AutoSizeBehaviors="Width, Default" DestroyOnClose="True" Modal="True" Animation="Fade" runat="server" Behaviors="Close">
                <ContentTemplate>
                    <div class="container" id="divTipoUnidad" style="width: 800px; z-index: 5002">
                        <div class="row">
                            <div class="col-sm-12">
                                <h3>Agregar Nueva Factura</h3>
                            </div>
                        </div>
                        <!-- FILA 1 -->
                        <div class="row" style="margin-top: 20px">
                            <div class="col-sm-6">
                                <div class="col-lg-4 col-md-12 col-xs-12">
                                    <span class="text-formulario">Proveedor</span>
                                </div>
                                <div class="col-lg-8 col-md-12 col-xs-12">
                                    <telerik:RadComboBox ID="cbProveedor" RenderMode="Lightweight" DataValueField="prvIdProveedor" DataTextField="prvCodigo" runat="server" Width="100%" Skin="Bootstrap"></telerik:RadComboBox>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="col-lg-4 col-md-12 col-xs-12">
                                    <span class="text-formulario">No. Factura</span>
                                </div>
                                <div class="col-lg-8 col-md-12 col-xs-12">
                                    <telerik:RadTextBox ID="txbNumeroFactura" runat="server" Skin="Bootstrap" MaxLength="15" Width="100%"></telerik:RadTextBox>
                                </div>
                            </div>
                        </div>

                        <!-- FILA 2 -->
                        <div class="row" style="margin-top: 10px">
                            <div class="col-sm-6">
                                <div class="col-lg-4 col-md-12 col-xs-12">
                                    <span class="text-formulario">Fecha</span>
                                </div>
                                <div class="col-lg-8 col-md-12 col-xs-12">
                                    <telerik:RadDatePicker ID="dpFechaFacturacion" runat="server" Skin="Bootstrap" Width="100%"></telerik:RadDatePicker>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="col-lg-4 col-md-12 col-xs-12">
                                    <span class="text-formulario">No. Entrada</span>
                                </div>
                                <div class="col-lg-8 col-md-12 col-xs-12">
                                    <telerik:RadTextBox ID="tbxEntrada" runat="server" Skin="Bootstrap" Width="100%"></telerik:RadTextBox>
                                </div>
                            </div>
                        </div>

                        <!-- FILA 3 -->
                        <div class="row" style="margin-top: 10px;">
                            <div class="col-sm-6">
                                <div class="col-lg-4 col-md-12 col-xs-12">
                                    <span class="text-formulario">Flete</span>
                                </div>
                                <div class="col-lg-8 col-md-12 col-xs-12">
                                    <telerik:RadNumericTextBox ID="txbFlete" NumberFormat-DecimalDigits="2" Type="Currency" runat="server" ShowSpinButtons="False" Skin="Bootstrap" Width="100%"></telerik:RadNumericTextBox>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="col-lg-4 col-md-12 col-xs-12">
                                    <span class="text-formulario">Vinculación</span>
                                </div>
                                <div class="col-lg-8 col-md-12 col-xs-12">
                                    <telerik:RadCheckBox ID="chkVinculacion" runat="server" Text="" Skin="Bootstrap" AutoPostBack="False"></telerik:RadCheckBox>
                                </div>
                            </div>

                        </div>

                        <!-- FILA 4 -->
                        <div class="row" style="margin-top: 10px;">

                            <div class="col-sm-12">
                                <div class="col-lg-2 col-md-12 col-xs-12">
                                    <span class="text-formulario">Notas</span>
                                </div>
                                <div class="col-lg-10 col-md-12 col-xs-12" style="padding-left: 10px;">
                                    <telerik:RadTextBox ID="tbxNotas" EmptyMessage="Notas (Opcional)" MaxLength="200" Height="45px" runat="server" Skin="Bootstrap" Width="100%"></telerik:RadTextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row" style="margin-top: 20px; margin-bottom: 10px;">
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
            <telerik:RadWindow ID="radWindowActualizarNP" Style="z-index: 2001;" AutoSize="True" MinWidth="800px" MaxHeight="450px" Width="850" MinHeight="250px" AutoSizeBehaviors="Width, Default" DestroyOnClose="True" Modal="True" Animation="Fade" runat="server" Behaviors="Close">
                <ContentTemplate>
                    <div class="container" style="width: 700px; z-index: 5002">
                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-xs-12">
                                <h3>Actualizar Número de Pedimento</h3>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 10px">
                            <div class="col-lg-6 col-md-12 col-xs-12">
                                <span class="text-formulario">Nuevo Número de Pedimento</span>
                            </div>
                            <div class="col-lg-6 col-md-12 col-xs-12">
                                <telerik:RadTextBox ID="tbxNumeroPedimento" runat="server" MaxLength="15" Skin="Bootstrap" Width="100%"></telerik:RadTextBox>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 20px; margin-bottom: 10px;">
                            <div class="col-lg-4 col-md-4 col-xs-4 ">
                                <asp:Button runat="server" CssClass="btn btn-block btn-danger" Text="Cancelar" OnClientClick="CloseWindowNP();return false;" ID="Button1" />
                            </div>
                            <div class="col-lg-4 col-md-4 col-xs-4"></div>
                            <div class="col-lg-4 col-md-4 col-xs-4">
                                <asp:Button ID="btnUpdateNumeroPedimentoModal" runat="server" CssClass="btn btn-block btn-primary" Text="Actualizar" OnClick="btnUpdateNumeroPedimento_OnClick" />
                            </div>
                        </div>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>


    <!-- MODAL PARA ACTUALIZAR NUMERO DE PEDIMENTO -->
    <telerik:RadWindowManager runat="server" ID="radWindowManagerNP" DestroyOnClose="True" EnableShadow="True" Skin="Bootstrap" Title="ImportFlex">
        <Windows>
        </Windows>
    </telerik:RadWindowManager>

    <telerik:RadCodeBlock runat="server">
        <script>
            function OpenWindow(x) {
                if (x == 0)
                    window.radopen("Nueva Factura", "radWindowNuevaFactura");
                else
                    window.radopen("radWindowActualizarNP", "radWindowActualizarNP");
            }
            function CloseWindow() {
                var window = $find('<%=radWindowNuevaFactura.ClientID%>');
                window.close();
                return false;
            }

            function CloseWindowNP() {
                var window = $find('<%=radWindowActualizarNP.ClientID%>');
                window.close();
                return false;
            }
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
