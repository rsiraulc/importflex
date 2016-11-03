using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using ImportFlex.Controllers;
using ImportFlex.Models;
using Telerik.Web.UI;

namespace ImportFlex.Views.Importaciones
{
    public partial class FacturaDetalle : System.Web.UI.Page
    {
        private List<imf_productos_prod> lstProductos = new List<imf_productos_prod>();
        public static int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = int.Parse(Request.Params["Id"]);
                CargarFactura(int.Parse(Request.Params["Id"]));
                CargarProductos();
                CargarUnidadesMedida();
                CargarDetalleFactura(int.Parse(Request.Params["Id"]));
                SetearComboBoxs();
                LimpiarControles();

            }
        }

        private void CargarFactura(int id)
        {
            var data = new FacturaController();
            var response = data.GetFacturaById(id);

            if (response.Success)
            {
                lblTitulo.Text = $"Factura {response.Factura.imf_proveedores_prv.prvCodigo} No. {response.Factura.facNumeroFactura}";
            }
        }

        private void SetearComboBoxs()
        {
            cbProducto.AllowCustomText = true;
            cbProducto.MarkFirstMatch = true;
            cbProducto.Filter = RadComboBoxFilter.Contains;

            cbUMC.AllowCustomText = true;
            cbUMC.MarkFirstMatch = true;
            cbUMC.Filter = RadComboBoxFilter.Contains;
        }

        private void LimpiarControles()
        {
            cbUMC.SelectedIndex = -1;
            cbProducto.SelectedIndex = -1;
            tbxNumeroSerie.Text = "";
            tbxValor.Text = "0";
            tbxFraccion.Text = "";

        }

        private void CargarUnidadesMedida()
        {
            var data = new CatalogosController();
            var response = data.GetAllUMC();
            if (response.Success)
            {
                cbUMC.DataSource = response.lstUMC;
                cbUMC.DataBind();
            }
        }

        private void CargarProductos()
        {
            var data = new ProductoController();
            var response = data.GetAllProductos();

            if (response.Success)
            {
                lstProductos = response.Productos;
                cbProducto.DataSource = response.Productos;
                cbProducto.DataBind();
            }
        }

        private void CargarDetalleFactura(int id)
        {
            var data = new FacturaDetalleController();
            var response = data.GetFacturaDetalleByFacturaId(id);
            if (response.Success)
            {
                
                gvDetalleFactura.DataSource = response.lstFacturaDetalle;
                gvDetalleFactura.DataBind();
            }
        }

        protected void btnAgregarProducto_OnClick(object sender, EventArgs e)
        {
            var fd = new FacturaDetalleController();
            var detalle = new imf_facturadetalle_fde
            {
                fdeIdFactura = int.Parse(Request.Params["Id"]),
                fdeCantidadUMC = 1,
                fdeIdUMC = Convert.ToInt32(cbUMC.SelectedValue),
                fdeIdProducto = Convert.ToInt32(cbProducto.SelectedValue),
                fdeNumeroSerieProducto = tbxNumeroSerie.Text,
                fdeValor = Convert.ToDecimal(tbxValor.Text),
                fdeFecha = DateTime.Now
            };

            var response = fd.InsertFacturaDetalle(detalle);
            if (response.Success)
            {
                Response.Redirect($"~/Views/Importaciones/FacturaDetalle?ID={response.FacturaDetalle.fdeIdFactura}");
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertSuccess",
                    $"alert('Ha ocurrido un error al agregar el producto. {response.Message}');", true);
        }

        protected void btnIrImportacion_OnClick(object sender, EventArgs e)
        {
            var data = new FacturaController();
            var response = data.GetFacturaById(int.Parse(Request.Params["Id"]));

            Response.Redirect($"~/Views/Importaciones/ImportacionDetalle?ID={response.Factura.facIdImportacion}");
        }

        protected void gvDetalleFactura_OnItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "eliminar")
            {
                var data = new FacturaDetalleController();
                var response = data.GetDetalleFacturaById(int.Parse(e.CommandArgument.ToString()));

                if (response.Success)
                {
                    if (data.DeleteFacturaDetalle(response.FacturaDetalle).Success)
                        Response.Redirect($"~/Views/Importaciones/FacturaDetalle?ID={response.FacturaDetalle.fdeIdFactura}");

                }
            }
        }

        protected void cbProducto_OnSelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (e.Value == "") return;
            var id = int.Parse(e.Value);
            var data = new ProductoController();

            var response = data.GetProductoById(id);
            if (response.Success)
            {
                tbxProductoDescripcion.Text = response.Producto.prodDescripcionRSI;
                tbxProductoTraduccion.Text = response.Producto.prodTraduccion;
                tbxMarca.Text = response.Producto.prodMarca;
                tbxModelo.Text = response.Producto.prodModelo;

                cbUMC.Focus();
            }
        }
    }
}