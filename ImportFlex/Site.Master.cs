using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ImportFlex.Account;

namespace ImportFlex
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            var page = this.Page.Request.FilePath;
            linkCerrarSesion.Visible = page != "/Account/Login";

            if (string.IsNullOrEmpty(Sesiones.EmailUsuario) && page != "/Account/Login")
                Response.Redirect("~/Account/Login.aspx");
            else
                lblNombre.Text = string.IsNullOrEmpty(Sesiones.EmailUsuario) ? "": $"Hola {Sesiones.NombreUsuario}!";

            //if (page == "/Account/Login")
            //    divMenu.Visible = false;

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void linkCerrarSesion_OnClick(object sender, EventArgs e)
        {
            Sesiones.Clear();
            Response.Redirect("~/Account/Login.aspx");
        }
    }
}