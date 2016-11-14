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
                                <telerik:RadComboBox ID="cbProducto" RenderMode="Lightweight" EmptyMessage="No. Parte" DataValueField="prodIdProducto" DataTextField="prodNumeroParte" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="cbProducto_OnSelectedIndexChanged"></telerik:RadComboBox>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="col-lg-4 col-md-12 col-xs-12">
                                <span class="text-formulario">Descripción</span>
                            </div>
                            <div class="col-lg-8 col-md-12 col-xs-12">
                                <telerik:RadTextBox ID="tbxProductoDescripcion" Skin="Bootstrap" ReadOnly="True" runat="server" Width="100%"></telerik:RadTextBox>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="col-lg-4 col-md-12 col-xs-12">
                                <span class="text-formulario">Traducción</span>
                            </div>
                            <div class="col-lg-8 col-md-12 col-xs-12">
                                <telerik:RadTextBox ID="tbxProductoTraduccion" ReadOnly="True" runat="server" Visible="True" Skin="Bootstrap" Width="100%"></telerik:RadTextBox>
                                <telerik:RadComboBox ID="cbTraduccion" runat="server" Visible="False" Skin="Bootstrap" Width="100%"></telerik:RadComboBox>
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
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="col-lg-4 col-md-12 col-xs-12">
                                <span class="text-formulario">Modelo</span>
                            </div>
                            <div class="col-lg-8 col-md-12 col-xs-12">
                                <telerik:RadTextBox ID="tbxModelo" ReadOnly="False" runat="server" Skin="Bootstrap" Width="100%"></telerik:RadTextBox>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="col-lg-4 col-md-12 col-xs-12">
                                <telerik:RadLabel ID="lblSerieCantidad" runat="server" CssClass="text-formulario" Text="No.Serie"></telerik:RadLabel>
                            </div>
                            <div class="col-lg-8 col-md-12 col-xs-12">
                                <telerik:RadTextBox ID="tbxNumeroSerie" runat="server" MaxLength="50" Skin="Bootstrap" Width="100%"></telerik:RadTextBox>
                                <telerik:RadNumericTextBox ID="tbxCantidad" Type="Number" MaxLength="8" ShowSpinButtons="False" runat="server" Skin="Bootstrap" Width="100%" Visible="False"></telerik:RadNumericTextBox>
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
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="col-lg-4 col-md-12 col-xs-12">
                                <span class="text-formulario">Unidad Factura</span>
                            </div>
                            <div class="col-lg-8 col-md-12 col-xs-12">
                                <telerik:RadComboBox ID="cbUMF" RenderMode="Lightweight" DataValueField="umfId" DataTextField="umfDescripcion" runat="server" Skin="Bootstrap" Width="100%"></telerik:RadComboBox>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="col-lg-4 col-md-12 col-xs-12">
                                <span class="text-formulario">Origen</span>
                            </div>
                            <div class="col-lg-8 col-md-12 col-xs-12">
                                <telerik:RadComboBox ID="cbPaisOrigen" RenderMode="Lightweight" DataValueField="paiIdPais" DataTextField="paiDescripcion" runat="server" Skin="Bootstrap" Width="100%"></telerik:RadComboBox>
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
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="col-lg-4 col-md-12 col-xs-12">
                                <span class="text-formulario">Fracción</span>
                            </div>
                            <div class="col-lg-8 col-md-12 col-xs-12">
                                <telerik:RadTextBox ID="tbxFraccion" runat="server" MaxLength="50" Skin="Bootstrap" Width="100%"></telerik:RadTextBox>
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
                            <telerik:GridBoundColumn HeaderText="Traducción" UniqueName="ProductoTraduccion" DataField="imf_productos_prod.prodTraduccion"></telerik:GridBoundColumn>
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

        <div class="row" style="margin-top: 20px">
            <div class="col-lg-10 col-md-10 col-xs-10"></div>
            <div class="col-lg-2 col-md-2 col-xs-2">
                <asp:Button ID="btnIrImportacion" runat="server" CssClass="btn btn-block btn-default" Text="Ir a Pedimento" Width="100%" OnClick="btnIrImportacion_OnClick" />
            </div>
        </div>
    </div>

    <telerik:RadCodeBlock runat="server">
        <script>
            function ValidarControles() {
                var cbProducto = $find('<%=cbProducto.ClientID%>');
                var txtNumeroSerie = $find('<%=tbxNumeroSerie.ClientID%>');

                if (txtNumeroSerie.val() != '') {
                    alert('sup');
                    return true;
                } else {
                    alert('No');
                    return false;
                }

            }
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
