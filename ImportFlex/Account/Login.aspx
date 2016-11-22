<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ImportFlex.Account.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  

    <div class="center-block">
            <div class="row">
        <div class="col-sm-12">
            <h1 style="font-size: 45px">Bienvenido a FlexImport</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-md-7">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4 >Iniciar Sesión</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="PlaceHolder1" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="Literal1" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" CssClass="col-md-2 control-label">Usuario</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="tbxUserName" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxUserName"
                                CssClass="text-danger" ErrorMessage="Campo Requerido" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" CssClass="col-md-2 control-label">Contraseña</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="tbxPassword" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxPassword" CssClass="text-danger" ErrorMessage="El campo de contraseña es requerido." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="OnClick" Text="Entrar" CssClass="btn btn-block btn-primary" />
                        </div>
                    </div>
                </div>
            </section>
        </div>

    </div>
    </div>

</asp:Content>
