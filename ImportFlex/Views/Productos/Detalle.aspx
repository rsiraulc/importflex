<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="ImportFlex.Views.Productos.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="margin-top: 20px;">
        <div class="col-sm-12">
            <telerik:RadLabel ID="lblTitulo" CssClass="h2" runat="server"></telerik:RadLabel>
        </div>
    </div>
    <div class="well" style="padding: 8px 20px 22px 15px">
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
                    <div class="input-group">
                        <telerik:RadTextBox ID="tbxProductoTraduccion" ReadOnly="True" runat="server" Visible="True" Skin="Bootstrap" CssClass="form-control" Width="100%"></telerik:RadTextBox>
                        <span class="input-group-btn">
                            <button onclick="OpenWindow(); return false;" class="btn btn-primary" style="width: 100%"><span class="glyphicon glyphicon-pencil"></span></button>
                        </span>
                    </div>
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
                                    <asp:Button runat="server" CssClass="btn btn-block btn-primary" Text="Guardar" ID="btnGuardarTraduccion" OnClick="btnGuardarTraduccion_OnClick" CausesValidation="False" />
                                </div>
                                <div id="divBtnCrear" style="display: none;">
                                    <asp:Button runat="server" CssClass="btn btn-block btn-primary" Text="Guardar" ID="btnCrearTraduccion" OnClick="btnCrearTraduccion_OnClick" CausesValidation="False" />
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
