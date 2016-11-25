<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ImportFlex.Views.Productos.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-12" style="margin-top: 20px;">
        <div class="row">
            <div class="col-sm-10">
                <h2>Productos</h2>
            </div>
            <div class="col-sm-2">
                <asp:Button runat="server" ID="btnNuevoProducto" Style="margin: 20px;" OnClientClick="OpenWindow();return false;" CssClass="btn btn-block btn-primary btn-md" Text="Nuevo Producto" />
            </div>
        </div>
        <asp:UpdatePanel ID="panelFiltroProducto" UpdateMode="Conditional" runat="server">
            <ContentTemplate>
                <div class="row" style="padding: 5px 0px 5px 0px">
                    <div class="well">
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="col-lg-4 col-md-12 col-xs-12">
                                        <span class="text-formulario">No. Parte</span>
                                    </div>
                                    <div class="col-lg-8 col-md-12 col-xs-12">
                                        <telerik:RadTextBox ID="tbxNumeroParte" runat="server" Skin="Bootstrap" Width="100%"></telerik:RadTextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="col-lg-4 col-md-12 col-xs-12">
                                        <span class="text-formulario">Descripción</span>
                                    </div>
                                    <div class="col-lg-8 col-md-12 col-xs-12">
                                        <telerik:RadTextBox ID="tbxDescripcion" runat="server" Skin="Bootstrap" Width="100%"></telerik:RadTextBox>
                                    </div>
                                </div>
                                <div class="col-sm-2"></div>
                                <div class="col-sm-2">
                                    <asp:Button ID="btnFiltrar" runat="server" CssClass="btn btn-block btn-default" Text="Filtrar" OnClick="btnFiltrar_OnClick" Width="100%" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <telerik:RadGrid ID="gvProductos" runat="server" Width="100%" Skin="Bootstrap" AllowPaging="False" AutoGenerateColumns="False">
                        <PagerStyle Mode="NextPrevAndNumeric" Position="Bottom" PageSizeControlType="RadComboBox"></PagerStyle>
                        <MasterTableView DataKeyNames="prodIdProducto">
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="No. Parte" UniqueName="NumeroParte" DataField="prodNumeroParte"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Descripción" UniqueName="Descripcion" DataField="prodDescripcionRSI"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Traducción" UniqueName="Traduccion" DataField="prodTraduccion"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Marca" UniqueName="Marca" DataField="prodMarca"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Modelo" UniqueName="Modelo" DataField="prodModelo"></telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn UniqueName="Detalle">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ToolTip="Ver Detalle" ID="imgBtnDetalle" Width="32px" ImageUrl="~/Images/iconDetails.png"
                                            PostBackUrl='<%# ResolveUrl("~/Views/Productos/Detalle?ID="+Eval("prodIdProducto")) %>' />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>
