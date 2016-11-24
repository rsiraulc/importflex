<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="ImportFlex.Views.Traducciones.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="margin-top: 20px;">
        <div class="col-sm-12">
            <telerik:RadLabel ID="lblTitulo" CssClass="h3" runat="server"></telerik:RadLabel>
        </div>
    </div>    
    <div class="well" style="margin-top: 20px; padding: 10px 20px 23px 10px">
        <div class="row" style="margin-top: 20px;">
            <div class="col-sm-12">
                <div class="col-lg-2 col-md-12 col-xs-12">
                    <span class="text-formulario">Traducción</span>
                </div>
                <div class="col-lg-8 col-md-12 col-xs-12">
                    <telerik:RadTextBox ID="tbxTraduccion" Skin="Bootstrap" runat="server" Width="150%"></telerik:RadTextBox>
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
