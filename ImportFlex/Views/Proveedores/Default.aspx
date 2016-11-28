<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ImportFlex.Views.Proveedores.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-12" style="margin-top: 20px;">
        <div class="row">
            <div class="col-sm-10">
                <h2>Proveedores</h2>
            </div>
            <div class="col-sm-2">
                <asp:Button runat="server" ID="btnNuevoProveedor" Style="margin: 20px;" CssClass="btn btn-block btn-primary btn-md" Text="Nuevo Proveedor"  OnClick="btnNuevoProveedor_Click"/>
            </div>
        </div>
        <div class="row" style="padding: 5px 0px 5px 0px">
            <div class="well">
                <div class="row">
                    <div class="col-sm-2">
                        <span class="text-formulario">Código/Descripción</span>
                    </div>
                    <div class="col-sm-7">
                        <telerik:RadTextBox ID="tbxCodigoDescripcion" runat="server" Skin="Bootstrap" Width="100%"></telerik:RadTextBox>
                    </div>
                    <div class="col-sm-2">
                        <asp:Button ID="btnFiltrar" runat="server" CssClass="btn btn-block btn-default" Text="Filtrar" OnClick="btnFiltrar_OnClick_" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <telerik:RadGrid ID="gvProveedores" runat="server" Width="100%" Skin="Bootstrap" AllowPaging="False" AutoGenerateColumns="False">
                <PagerStyle Mode="NextPrevAndNumeric" Position="Bottom" PageSizeControlType="RadComboBox"></PagerStyle>
                <MasterTableView DataKeyNames="prvIdProveedor">
                    <Columns>
                        <telerik:GridBoundColumn HeaderText="Id" UniqueName="Id" DataField="prvIdProveedor" Visible="False"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Código" UniqueName="Codigo" DataField="prvCodigo"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Descripción" UniqueName="Descripcion" DataField="prvDescripcion"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Tax Id" UniqueName="IdTax" DataField="prvIdTax"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="INCOTERM" UniqueName="Incoterm" DataField="prvIncoterm"></telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn UniqueName="Detalle">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ToolTip="Ver Detalle" ID="imgBtnDetalle" Width="32px" ImageUrl="~/Images/iconDetails.png"
                                    PostBackUrl='<%# ResolveUrl("~/Views/Proveedores/Detalle?ID="+Eval("prvIdProveedor")) %>' />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </div>
    </div>
</asp:Content>
