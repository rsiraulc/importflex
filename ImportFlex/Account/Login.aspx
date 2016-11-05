<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ImportFlex.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h1>Login.</h1>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="tbxUserName" CssClass="col-md-3 control-label">Usuario</asp:Label>
                        <div class="col-md-9">
                            <asp:TextBox runat="server" ID="tbxUserName" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxUserName"
                                CssClass="text-danger" ErrorMessage="The user name field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="tbxPassword" CssClass="col-md-3 control-label">Contraseña</asp:Label>
                        <div class="col-md-9">
                            <asp:TextBox runat="server" ID="tbxPassword" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxPassword" CssClass="text-danger" ErrorMessage="El campo de contraseña es requerido." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="OnClick" Text="Log in" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
                
            </section>
        </div>
    </div>
</asp:Content>
