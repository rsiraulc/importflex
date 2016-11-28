<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="ImportFlex.Views.Proveedores.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="margin-top: 20px;">
        <div class="col-sm-12">
            <telerik:RadLabel ID="lblTitulo" CssClass="h2" runat="server" Text="Proveedor"></telerik:RadLabel>
        </div>
    </div>
    <div class="well" style="padding: 7px 20px 20px 15px">
        <div class="row" style="margin-top: 20px;">
            <div class="col-sm-4">
                <div class="col-lg-4 col-md-12 col-xs-12">
                    <span class="text-formulario">Código</span>
                </div>
                <div class="col-lg-8 col-md-12 col-xs-12">
                    <telerik:RadTextBox ID="tbxCodigo" Skin="Bootstrap" runat="server" Width="100%"></telerik:RadTextBox>
                </div>
            </div>
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
                    <span class="text-formulario">Tax ID</span>
                </div>
                <div class="col-lg-8 col-md-12 col-xs-12">
                    <telerik:RadTextBox ID="tbxTax" runat="server" Skin="Bootstrap" Width="100%"></telerik:RadTextBox>
                </div>
            </div>
        </div>
        <div class="row" style="margin-top: 20px">
            <div class="col-sm-4">
                <div class="col-lg-4 col-md-12 col-xs-12">
                    <span class="text-formulario">Incoterm</span>
                </div>
                <div class="col-lg-8 col-md-12 col-xs-12">
                    <telerik:RadComboBox ID="cbxIncoterm" runat="server" Skin="Bootstrap" Width="100%"></telerik:RadComboBox>
                </div>
            </div>
        </div>
        <div class="row" style="margin-top: 20px;">
            <div class="col-sm-10"></div>
            <div class="col-lg-2 col-md-2 col-xs-2">
                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-block btn-primary" Text="Guardar" OnClick="btnGuardar_OnClick" Width="100%" />
            </div>
        </div>
    </div>
</asp:Content>
