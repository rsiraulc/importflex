using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ImportFlex.Controllers;

namespace ImportFlex.Views.Productos
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductos();
            }
        }

        private void CargarProductos()
        {
            var data = new ProductoController();
            var response = data.GetAllProductos();
            if (response.Success)
            {
                gvProductos.DataSource = response.Productos;
                gvProductos.DataBind();
            }
        }

        protected void btnFiltrar_OnClick(object sender, EventArgs e)
        {
            var data = new ProductoController();
            var response = data.GetProductosByFiltro(tbxNumeroParte.Text, tbxDescripcion.Text);
            if (response.Success)
            {
                gvProductos.DataSource = response.Productos;
                gvProductos.DataBind();
            }
        }
    }
}