<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="ImportFlex.Views.Productos.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="margin-top: 20px;">
        <div class="col-sm-12">
            <telerik:RadLabel ID="lblTitulo" CssClass="h2" runat="server"></telerik:RadLabel>
        </div>
    </div>
    <div class="well" style="padding: 5px 0px 5px 0px">
        <div class="row" style="margin-top: 20px;">
            <div class="col-sm-4">
                <div class="col-lg-4 col-md-12 col-xs-12">
                    <span class="text-formulario">Descripción</span>
                </div>
                <div class="col-lg-8 col-md-12 col-xs-12">
                    <telerik:RadTextBox ID="tbxDescripcion" Skin="Bootstrap" runat="server" Width="100%"></telerik:RadTextBox>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="col-lg-4 col-md-12 col-xs-12">
                    <span class="text-formulario">Traducción</span>
                </div>
                <div class="col-lg-8 col-md-12 col-xs-12">
                    <telerik:RadComboBox ID="cbTraduccion" runat="server" Skin="Bootstrap" Width="100%"></telerik:RadComboBox>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="col-lg-4 col-md-12 col-xs-12">
                    <span class="text-formulario">No. Parte</span>
                </div>
                <div class="col-lg-8 col-md-12 col-xs-12">
                    <telerik:RadTextBox ID="tbxNumeroParte" runat="server" Skin="Bootstrap" Width="100%"></telerik:RadTextBox>
                </div>
            </div>
        </div>

        <div class="row" style="margin-top: 20px;">
            <div class="col-sm-4">
                <div class="col-lg-4 col-md-12 col-xs-12">
                    <span class="text-formulario">Marca</span>
                </div>
                <div class="col-lg-8 col-md-12 col-xs-12">
                    <telerik:RadTextBox ID="tbxMarca" Skin="Bootstrap" runat="server" Width="100%"></telerik:RadTextBox>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="col-lg-4 col-md-12 col-xs-12">
                    <span class="text-formulario">Modelo</span>
                </div>
                <div class="col-lg-8 col-md-12 col-xs-12">
                    <telerik:RadTextBox ID="tbxModelo" Skin="Bootstrap" runat="server" Width="100%"></telerik:RadTextBox>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="col-lg-4 col-md-12 col-xs-12">
                    <span class="text-formulario">SubModelo</span>
                </div>
                <div class="col-lg-8 col-md-12 col-xs-12">
                    <telerik:RadTextBox ID="tbxSubModelo" runat="server" Skin="Bootstrap" Width="100%"></telerik:RadTextBox>
                </div>
            </div>
        </div>
        <div class="row" style="margin-top: 20px;">
            <div class="col-sm-4">
                <div class="col-lg-4 col-md-12 col-xs-12">
                    <span class="text-formulario">Fracci&oacute;n Arancelaria</span>
                </div>
                <div class="col-lg-8 col-md-12 col-xs-12">
                    <telerik:RadTextBox ID="tbxFraccion" Skin="Bootstrap" runat="server" Width="100%"></telerik:RadTextBox>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="col-lg-4 col-md-12 col-xs-12">
                    <span class="text-formulario">País Origen</span>
                </div>
                <div class="col-lg-8 col-md-12 col-xs-12">
                    <telerik:RadComboBox ID="cbPais" DataValueField="paiIdPais" DataTextField="paiDescripcion" runat="server" Skin="Bootstrap" Width="100%"></telerik:RadComboBox>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="col-lg-4 col-md-12 col-xs-12">
                    <span class="text-formulario">Activo</span>                  
                </div>
                <div class="col-lg-8 col-md-12 col-xs-12">
                    <telerik:RadCheckBox ID="checkStatus" Skin="Bootstrap" AutoPostBack="False" runat="server" Text=""></telerik:RadCheckBox>
                </div>
            </div>
        </div>
        <div class="row" style="margin-top: 20px;">
            <div class="col-sm-4">
                <div class="col-lg-4 col-md-12 col-xs-12">
                    <span class="text-formulario">Peso Kgs</span>
                </div>
                <div class="col-lg-8 col-md-12 col-xs-12">
                    <telerik:RadNumericTextBox ID="tbxPeso" Type="Number" runat="server" MaxLength="8" Skin="Bootstrap" Width="100%"></telerik:RadNumericTextBox>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="col-lg-4 col-md-12 col-xs-12">
                    <span class="text-formulario">Piezas X Bulto</span>
                </div>
                <div class="col-lg-8 col-md-12 col-xs-12">
                    <telerik:RadNumericTextBox ID="tbxPiezasXBulto" Type="Number" MaxLength="6" runat="server" Skin="Bootstrap" Width="100%"></telerik:RadNumericTextBox>
                </div>
            </div>
                        <div class="col-sm-4">
                <div class="col-lg-4 col-md-12 col-xs-12">
                    <span class="text-formulario">Ultimo Costo</span>
                </div>
                <div class="col-lg-8 col-md-12 col-xs-12">
                    <telerik:RadNumericTextBox ID="tbxCosto" ReadOnly="True" Type="Currency" runat="server" Skin="Bootstrap" Width="100%"></telerik:RadNumericTextBox>
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
            <div class="col-lg-2 col-md-2 col-xs-2"></div>
            <div class="col-lg-2 col-md-2 col-xs-2">
                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-block btn-primary" Text="Guardar" OnClick="btnGuardar_OnClick" Width="100%" />
                </div>
        </div>
    </div>
</asp:Content>
