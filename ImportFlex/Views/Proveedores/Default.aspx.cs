using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ImportFlex.Controllers;

namespace ImportFlex.Views.Proveedores
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProveedores();
            }
        }

        private void CargarProveedores()
        {
            var data = new ProveedorController();
            var response = data.GetAllProveedores();

            if (response.Success)
            {
                gvProveedores.DataSource = response.lstProveedores;
                gvProveedores.DataBind();
            }
        }

        protected void btnFiltrar_OnClick_(object sender, EventArgs e)
        {
            var data = new ProveedorController();
            var response = data.GetProveedoresByFiltro(tbxCodigoDescripcion.Text);

            if (response.Success)
            {
                gvProveedores.DataSource = response.lstProveedores;
                gvProveedores.DataBind();
            }
        }

        protected void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Proveedores/Detalle.aspx");
        }
    }
}