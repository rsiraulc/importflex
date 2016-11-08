using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ImportFlex.Controllers;
using ImportFlex.Models;
using Telerik.Web.UI;

namespace ImportFlex.Views.Productos
{
    public partial class Detalle : System.Web.UI.Page
    {
        private imf_productos_prod producto;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCatalogos();
                CargarProducto(int.Parse(Request.Params["Id"]));
            }
        }

        private void CargarCatalogos()
        {
            var data = new CatalogosController();

            // CARGAR TRADUCCIONES
            cbTraduccion.DataSource = data.GetListaTraducciones();
            cbTraduccion.DataBind();

            // CARGAR PAISES
            cbPais.DataSource = data.GetAllPaises().lstPaises;
            cbPais.DataBind();

            // CARGAR UMC
            cbUMC.DataSource = data.GetAllUMC().lstUMC;
            cbUMC.DataBind();

            // CARGAR UMF
            cbUMF.DataSource = data.GetUMFEnUso().lstUMF;
            cbUMF.DataBind();

            cbPais.AllowCustomText = true;
            cbPais.MarkFirstMatch = true;
            cbPais.Filter = RadComboBoxFilter.Contains;

            cbTraduccion.AllowCustomText = true;
            cbTraduccion.MarkFirstMatch = true;
            cbTraduccion.Filter = RadComboBoxFilter.Contains;

            cbUMC.AllowCustomText = true;
            cbUMC.MarkFirstMatch = true;
            cbUMC.Filter = RadComboBoxFilter.Contains;

            cbUMF.AllowCustomText = true;
            cbUMF.MarkFirstMatch = true;
            cbUMF.Filter = RadComboBoxFilter.Contains;
        }

        private void CargarProducto(int id)
        {
            var data = new ProductoController();
            var p = data.GetProductoById(id);

            if(p.Success)
            {
                producto = p.Producto;
                lblTitulo.Text = producto.prodDescripcionRSI;

                tbxDescripcion.Text = producto.prodDescripcionRSI;
                cbTraduccion.SelectedValue = producto.prodTraduccion;
                tbxMarca.Text = producto.prodMarca;
                tbxModelo.Text = producto.prodModelo;
                tbxSubModelo.Text = producto.prodSubModelo;
                tbxNumeroParte.Text = producto.prodNumeroParte;
                checkStatus.Checked = producto.prodStatus;
                tbxCosto.Text = producto.prodUltimoCosto.ToString();
                cbUMC.SelectedValue = producto.prodIdUltimaUMC.ToString();
                cbUMF.SelectedValue = producto.prodIdUltimaUMF.ToString();

                if (producto.prodIdPaisOrigen != null)
                {
                    cbPais.SelectedValue = producto.prodIdPaisOrigen.ToString();
                    cbPais.DataBind();
                }
                else
                    cbPais.SelectedIndex = -1;

                tbxDescripcion.ToolTip = tbxDescripcion.Text;
            }
        }

        protected void btnGuardar_OnClick(object sender, EventArgs e)
        {
            var data = new ProductoController();
            var p = producto;

            p.prodDescripcionRSI = tbxDescripcion.Text;
            p.prodTraduccion = cbTraduccion.SelectedValue;
            p.prodMarca = tbxMarca.Text;
            p.prodModelo = tbxModelo.Text;
            p.prodSubModelo = tbxSubModelo.Text;
            p.prodNumeroParte = tbxNumeroParte.Text;
            p.prodIdPaisOrigen = int.Parse(cbPais.SelectedValue);
            p.prodFraccionArancelaria = tbxFraccion.Text;
            p.prodPeso = Convert.ToDecimal(tbxPeso.Text);
            p.prodPiezasPorBulto = Convert.ToDecimal(tbxPiezasXBulto.Text);
            p.prodStatus = checkStatus.Checked;
            p.prodIdUltimaUMC = Convert.ToInt32(cbUMC.SelectedValue);
            p.prodIdUltimaUMF = Convert.ToInt32(cbUMF.SelectedValue);

            var response = data.UpdateProducto(producto);

            if (response.Success)
                Response.Redirect("~/Views/Productos/Default.aspx");
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertSuccess",
                    $"alert('Ha ocurrido un error al agregar el producto. {response.Message}');", true);

        }
    }
}