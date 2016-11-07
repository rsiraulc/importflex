using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ImportFlex.Controllers;

namespace ImportFlex.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tbxUserName.Text = "raul";
            tbxPassword.Text = "12345";
        }

        protected void OnClick(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var data = new UsuarioController();
                var response = data.GetUsuarioLogin(tbxUserName.Text, tbxPassword.Text);

                if (response.Success)
                {
                    HttpContext.Current.Session.Clear();
                    var u = response.Usuario;
                    var userData = $"{u.usrIdUsuario}|{u.imf_roles_rls.rlsClave}|{u.userNombre + " " + u.usrApellidoPaterno}|{u.usrEmail}";
                    HttpContext.Current.Response.SetAuthCookie(u.usrIdUsuario.ToString(), false, userData, u.userNombre);
                    Sesiones.EmailUsuario = u.usrEmail;
                    Sesiones.NombreUsuario = u.userNombre + " " + u.usrApellidoPaterno;
                    Sesiones.UsuarioID = u.usrIdUsuario;
                    Sesiones.Rol = u.imf_roles_rls.rlsClave;


                    Response.Redirect("~/Views/Importaciones/Importacion.aspx");

                }
            }
        }
    }
}