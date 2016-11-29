<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FacturaDetalle.aspx.cs" Inherits="ImportFlex.Views.Importaciones.FacturaDetalle" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2016.2.504.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-12" style="margin-top: 20px;">
        <div class="row">
            <div class="col-sm-12">
                <telerik:RadLabel ID="lblTitulo" CssClass="h2" runat="server"></telerik:RadLabel>
            </div>
        </div>

        <asp:UpdatePanel ID="updateProducto" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="well" id="divAddProducto" runat="server">
                    <div class="row">
                        <div class="col-sm-4">
                            <div class="col-lg-4 col-md-12 col-xs-12">
                                <span class="text-formulario">Producto</span>
                            </div>
                            <div class="col-lg-8 col-md-12 col-xs-12">
                                <telerik:RadComboBox ID="cbProducto" RenderMode="Lightweight" EmptyMessage="No. Parte" DataValueField="prodIdProducto" DataTextField="prodNumeroParte" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="cbProducto_OnSelectedIndexChanged" CausesValidation="False"></telerik:RadComboBox>

                                <asp:RequiredFieldValidator runat="server" ControlToValidate="cbProducto"
                                    CssClass="text-danger" ErrorMessage="Campo Requerido" />
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="col-lg-4 col-md-12 col-xs-12">
                                <span class="text-formulario">Descripción</span>
                            </div>
                            <div class="col-lg-8 col-md-12 col-xs-12">
                                <telerik:RadTextBox ID="tbxProductoDescripcion" Skin="Bootstrap" ReadOnly="True" runat="server" Width="100%"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxProductoDescripcion"
                                    CssClass="text-danger" ErrorMessage="Campo Requerido" />
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="col-lg-4 col-md-12 col-xs-12">
                                <span class="text-formulario">Traducción</span>
                            </div>
                            <div class="col-lg-8 col-md-12 col-xs-12">
                                <div class="input-group">
                                    <telerik:RadTextBox ID="tbxProductoTraduccion" ReadOnly="True" runat="server" Visible="True" Skin="Bootstrap" CssClass="form-control" Width="100%"></telerik:RadTextBox>
                                    <span class="input-group-btn">
                                        <button onclick="OpenWindow();" class="btn btn-primary" style="width: 100%"><span class="glyphicon glyphicon-pencil"></span></button>
                                    </span>
                                </div>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxProductoTraduccion"
                                    CssClass="text-danger" ErrorMessage="Campo Requerido" />

                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 20px;">
                        <div class="col-sm-4">
                            <div class="col-lg-4 col-md-12 col-xs-12">
                                <span class="text-formulario">Marca</span>
                            </div>
                            <div class="col-lg-8 col-md-12 col-xs-12">
                                <telerik:RadTextBox ID="tbxMarca" Skin="Bootstrap" ReadOnly="False" runat="server" Width="100%"></telerik:RadTextBox>
                                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="tbxMarca" CssClass="text-danger" ErrorMessage="Campo Requerido" />--%>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="col-lg-4 col-md-12 col-xs-12">
                                <span class="text-formulario">Modelo</span>
                            </div>
                            <div class="col-lg-8 col-md-12 col-xs-12">
                                <telerik:RadTextBox ID="tbxModelo" ReadOnly="False" runat="server" Skin="Bootstrap" Width="100%"></telerik:RadTextBox>

                              <%--  <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxModelo" CssClass="text-danger" ErrorMessage="Campo Requerido" />--%>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="col-lg-4 col-md-12 col-xs-12">
                                <telerik:RadLabel ID="lblSerieCantidad" runat="server" CssClass="text-formulario" Text="No.Serie"></telerik:RadLabel>
                            </div>
                            <div class="col-lg-8 col-md-12 col-xs-12">
                                <telerik:RadTextBox ID="tbxNumeroSerie" runat="server" MaxLength="50" Skin="Bootstrap" Width="100%"></telerik:RadTextBox>
                                <telerik:RadNumericTextBox ID="tbxCantidad" Type="Number" MaxLength="8" ShowSpinButtons="False" runat="server" Skin="Bootstrap" Width="100%" Visible="False"></telerik:RadNumericTextBox>
                                
                                <asp:RequiredFieldValidator ID="rfvCantidad_NoSerie" runat="server" CssClass="text-danger" ControlToValidate="tbxNumeroSerie" ErrorMessage="Campo Requerido" />

                            </div>
                        </div>

                    </div>
                    <div class="row" style="margin-top: 20px;">
                        <div class="col-sm-4">
                            <div class="col-lg-4 col-md-12 col-xs-12">
                                <span class="text-formulario">Unidad Aduana</span>
                            </div>
                            <div class="col-lg-8 col-md-12 col-xs-12">
                                <telerik:RadComboBox ID="cbUMC" RenderMode="Lightweight" DataValueField="umcIdClave" DataTextField="umcDescripcion" runat="server" Skin="Bootstrap" Width="100%"></telerik:RadComboBox>

                                <asp:RequiredFieldValidator runat="server" ControlToValidate="cbUMC"
                                    CssClass="text-danger" ErrorMessage="Campo Requerido" />
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="col-lg-4 col-md-12 col-xs-12">
                                <span class="text-formulario">Unidad Factura</span>
                            </div>
                            <div class="col-lg-8 col-md-12 col-xs-12">
                                <telerik:RadComboBox ID="cbUMF" RenderMode="Lightweight" DataValueField="umfId" DataTextField="umfDescripcion" runat="server" Skin="Bootstrap" Width="100%"></telerik:RadComboBox>

                                <asp:RequiredFieldValidator runat="server" ControlToValidate="cbUMF"
                                    CssClass="text-danger" ErrorMessage="Campo Requerido" />
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="col-lg-4 col-md-12 col-xs-12">
                                <span class="text-formulario">Origen</span>
                            </div>
                            <div class="col-lg-8 col-md-12 col-xs-12">
                                <telerik:RadComboBox ID="cbPaisOrigen" RenderMode="Lightweight" DataValueField="paiIdPais" DataTextField="paiDescripcion" runat="server" Skin="Bootstrap" Width="100%"></telerik:RadComboBox>

                                <asp:RequiredFieldValidator runat="server" ControlToValidate="cbPaisOrigen"
                                    CssClass="text-danger" ErrorMessage="Campo Requerido" />
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 20px;">
                        <div class="col-sm-4">
                            <div class="col-lg-4 col-md-12 col-xs-12">
                                <span class="text-formulario">Valor USD</span>
                            </div>
                            <div class="col-lg-8 col-md-12 col-xs-12">
                                <telerik:RadNumericTextBox ID="tbxValor" NumberFormat-DecimalDigits="2" Type="Currency" runat="server" ShowSpinButtons="False" Skin="Bootstrap" Width="100%"></telerik:RadNumericTextBox>

                                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxValor"
                                    CssClass="text-danger" ErrorMessage="Campo Requerido" />
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="col-lg-4 col-md-12 col-xs-12">
                                <span class="text-formulario">Fracción</span>
                            </div>
                            <div class="col-lg-8 col-md-12 col-xs-12">
                                <telerik:RadTextBox ID="tbxFraccion" runat="server" MaxLength="50" Skin="Bootstrap" Width="100%"></telerik:RadTextBox>

                                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxFraccion"
                                    CssClass="text-danger" ErrorMessage="Campo Requerido" />
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-12 col-xs-12">
                            <telerik:RadCheckBox ID="chkAgregarMismoProducto" runat="server" AutoPostBack="False" Text="Agregar mismo producto" Skin="Bootstrap"></telerik:RadCheckBox>
                        </div>
                        <div class="col-lg-2 col-md-12 col-xs-12">
                            <asp:Button ID="btnAgregarProducto" runat="server" CssClass="btn btn-block btn-primary" Text="Agregar" OnClientClick="ValidarControles" OnClick="btnAgregarProducto_OnClick" Width="100%" />
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <div class="row">
            <div class="col-sm-12">
                <telerik:RadGrid ID="gvDetalleFactura" runat="server" Width="100%" AutoGenerateColumns="False" Skin="Bootstrap" OnItemCommand="gvDetalleFactura_OnItemCommand">
                    <MasterTableView DataKeyNames="fdeIdDetalleFactura">
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="Id" Visible="False" UniqueName="Id" DataField="fdeIdDetalleFactura"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Cantidad" UniqueName="CantidadUMC" DataField="fdeCantidadUMC"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Unidad de Medida" UniqueName="UMC" DataField="imf_unidadmedidacomercial_umc.umcDescripcion"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="No. Parte" UniqueName="NumeroParte" DataField="imf_productos_prod.prodNumeroParte"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Producto" UniqueName="ProductoDescripcion" DataField="imf_productos_prod.prodDescripcionRSI"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Traducción" UniqueName="ProductoTraduccion" DataField="imf_productos_prod.imf_traducciones_trad.tradTraduccion"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Marca" UniqueName="ProductoMarca" DataField="imf_productos_prod.prodMarca"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Modelo" UniqueName="ProductoMarca" DataField="imf_productos_prod.prodModelo"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="No.Serie" UniqueName="ProductoNumeroSerie" DataField="fdeNumeroSerieProducto"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Importe" UniqueName="Valor" DataField="fdeValor" DataFormatString="{0:C}"></telerik:GridBoundColumn>

                            <telerik:GridTemplateColumn UniqueName="Detalle">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgBtnDelete" runat="server" Width="32px" OnClientClick='<%#string.Format("return confirm(\"¿Estas seguro de eliminar el articulo: {0} de la factura?\");",Eval("imf_productos_prod.prodDescripcionRSI"))%>' CommandArgument='<%#Eval("fdeIdDetalleFactura")%>' CommandName="eliminar" ImageUrl="~/Images/Remove.png" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </div>
        </div>
        <div class="row" style="margin-top: 20px;">
            <div class="col-sm-3">
                <telerik:RadLabel ID="lblTotalArticulos" CssClass="h4" runat="server"></telerik:RadLabel>
            </div>
            <div class="col-sm-6"></div>
            <div class="col-sm-3" style="text-align: right;">
                <telerik:RadLabel ID="lblValorTotal" CssClass="h3" runat="server"></telerik:RadLabel>
            </div>
        </div>

        <div class="row" style="margin-top: 20px">
            <div class="col-lg-10 col-md-10 col-xs-10"></div>
            <div class="col-lg-2 col-md-2 col-xs-2">
                <asp:Button ID="btnIrImportacion" runat="server" CssClass="btn btn-block btn-default" Text="Ir a Pedimento" Width="100%" OnClick="btnIrImportacion_OnClick" CausesValidation="False" />
            </div>
        </div>
    </div>


    <!-- MODAL PARA ASIGNAR TRADUCCION -->
    <telerik:RadWindowManager runat="server" ID="radWindowTraduccion" DestroyOnClose="True" Skin="Bootstrap" EnableShadow="True" Title="ImportFlex">
        <Windows>
            <telerik:RadWindow ID="radWindowTraducciones" Style="z-index: 2001;" AutoSize="True" MinWidth="400px" MaxHeight="350px" Width="400" MinHeight="300px" AutoSizeBehaviors="Width, Default" DestroyOnClose="True" Modal="True" Animation="Fade" runat="server" Behaviors="Close">
                <ContentTemplate>
                    <div class="container" style="width: 700px; z-index: 5002">
                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-xs-12">
                                <h3>Traducción </h3>
                            </div>
                        </div>

                        <div class="row" id="divEditar" style="margin-top: 10px">
                            <div class="col-sm-4">
                                <span>Selecciona una Traducción</span>
                            </div>
                            <div class="col-sm-6">
                                <telerik:RadComboBox ID="cbxEditarTraduccion" DataTextField="tradTraduccion" DataValueField="tradIdTraduccion" runat="server" Skin="Bootstrap" Width="100%"></telerik:RadComboBox>
                            </div>
                        </div>
                        <div class="row" id="divNuevo" style="margin-top: 10px; display: none;">
                            <div class="col-sm-4">
                                <span>Traducción</span>
                            </div>
                            <div class="col-sm-8">
                                <telerik:RadTextBox ID="tbxNuevaTraduccion" runat="server" Skin="Bootstrap" Width="100%"></telerik:RadTextBox>
                            </div>
                        </div>

                        <div class="row" style="margin-top: 20px; margin-bottom: 10px;">
                            <div class="col-lg-4 col-md-4 col-xs-4 ">
                                <asp:Button runat="server" CssClass="btn btn-block btn-danger" Text="Cancelar" OnClientClick="CloseWindow();return false;" ID="btnCancelar" />
                            </div>
                            <div class="col-lg-4 col-md-4 col-xs-4">
                                <div id="divbtnNuevo" style="display: block;">
                                    <asp:Button runat="server" CssClass="btn btn-block btn-success" Text="Nueva" ID="btnNuevaTraduccion" OnClientClick="OpenNuevaTraduccion(); return false;" />
                                </div>
                                <div id="divbtnEditar" style="display: none;">
                                    <asp:Button runat="server" CssClass="btn btn-block btn-success" Text="Seleccionar" ID="btnSeleccionarTraduccion" OnClientClick="OpenSeleccionTraduccion(); return false;" />
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4 col-xs-4">
                                <div id="divBtnGuardar" style="display: block;">
                                    <asp:Button runat="server" CssClass="btn btn-block btn-primary" Text="Guardar" ID="btnGuardar" OnClick="btnGuardar_OnClick" CausesValidation="False" />
                                </div>
                                <div id="divBtnCrear" style="display: none;">
                                    <asp:Button runat="server" CssClass="btn btn-block btn-primary" Text="Guardar" ID="btnCrear" OnClick="btnCrear_OnClick" CausesValidation="False" />
                                </div>
                            </div>
                        </div>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>


    <telerik:RadCodeBlock runat="server">
        <script>

            function OpenWindow() {
                window.radopen("Seleccionar Traduccion", "radWindowTraducciones");
            }
            function CloseWindow() {
                var window = $find('<%=radWindowTraducciones.ClientID%>');
                window.close();
                return false;
            }

            function OpenNuevaTraduccion() {
                document.getElementById("divNuevo").style.display = 'block';
                document.getElementById("divbtnNuevo").style.display = 'none';
                document.getElementById("divBtnCrear").style.display = 'block';


                document.getElementById("divBtnGuardar").style.display = 'none';
                document.getElementById("divEditar").style.display = 'none';
                document.getElementById("divbtnEditar").style.display = 'block';
            }

            function OpenSeleccionTraduccion() {
                document.getElementById("divbtnNuevo").style.display = 'block';
                document.getElementById("divNuevo").style.display = 'none';
                document.getElementById("divBtnCrear").style.display = 'none';

                document.getElementById("divBtnGuardar").style.display = 'block';
                document.getElementById("divEditar").style.display = 'block';
                document.getElementById("divbtnEditar").style.display = 'none';

            }
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
