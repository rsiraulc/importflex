using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ImportFlex.Controllers;
using Telerik.Web.UI;

namespace ImportFlex.Views.Productos
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPaises();
                CargarProducto(int.Parse(Request.Params["Id"]));
            }
        }

        private void CargarPaises()
        {

            cbPais.AllowCustomText = true;
            cbPais.MarkFirstMatch = true;
            cbPais.Filter = RadComboBoxFilter.Contains;

            var data = new CatalogosController();
            cbPais.DataSource = data.GetAllPaises().lstPaises;
            cbPais.DataBind();
        }

        private void CargarProducto(int id)
        {
            var data = new ProductoController();
            var producto = data.GetProductoById(id);

            if(producto.Success)
            {
                lblTitulo.Text = producto.Producto.prodDescripcionRSI;

                tbxDescripcion.Text = producto.Producto.prodDescripcionRSI;
                tbxTraduccion.Text = producto.Producto.prodTraduccion;
                tbxMarca.Text = producto.Producto.prodMarca;
                tbxModelo.Text = producto.Producto.prodModelo;
                tbxSubModelo.Text = producto.Producto.prodSubModelo;
                tbxNumeroParte.Text = producto.Producto.prodNumeroParte;
                if (producto.Producto.prodIdPaisOrigen != null)
                {
                    cbPais.SelectedValue = producto.Producto.prodIdPaisOrigen.ToString();
                    cbPais.DataBind();
                }
                else
                    cbPais.SelectedIndex = -1;
            }
        }

        protected void btnGuardar_OnClick(object sender, EventArgs e)
        {
            var data = new ProductoController();
            var producto = data.GetProductoById(int.Parse(Request.Params["Id"]));
            if (producto.Success)
            {
                var p = producto.Producto;

                p.prodDescripcionRSI = tbxDescripcion.Text;
                p.prodTraduccion = tbxTraduccion.Text;
                p.prodMarca = tbxMarca.Text;
                p.prodModelo = tbxModelo.Text;
                p.prodSubModelo = tbxSubModelo.Text;
                p.prodNumeroParte = tbxNumeroParte.Text;
                p.prodIdPaisOrigen = int.Parse(cbPais.SelectedValue);
                p.prodFraccionArancelaria = tbxFraccion.Text;

                var response = data.UpdateProducto(producto.Producto);

                if(response.Success)
                    Response.Redirect("~/Views/Productos/Default.aspx");
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertSuccess",
                    $"alert('Ha ocurrido un error al agregar el producto. {response.Message}');", true);
            }
        }
    }
}