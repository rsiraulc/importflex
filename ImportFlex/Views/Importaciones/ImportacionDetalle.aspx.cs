using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ImportFlex.Controllers;
using ImportFlex.Models;
using Telerik.Web.UI;

namespace ImportFlex.Views.Importaciones
{
    public partial class ImportacionDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblTitulo.Text = "Detalle de Importación No. " + Request.Params["Id"];
                CargarFacturas(int.Parse(Request.Params["Id"]));
                CargarProveedor();
                dpFechaFacturacion.SelectedDate = DateTime.Now;
            }

            cbProveedor.AllowCustomText = true;
            cbProveedor.MarkFirstMatch = true;
            cbProveedor.Filter = RadComboBoxFilter.Contains;
        }

        private void CargarProveedor()
        {
            var data = new ProveedorController();
            var response = data.GetAllProveedores();
            if (response.Success)
            {
                cbProveedor.DataSource = response.lstProveedores;
                cbProveedor.DataBind();
            }
        }

        private void CargarFacturas(int id)
        {
            var data = new FacturaController();
            var response = data.GetFacturasByIdImportacion(id);
            if (response.Success)
            {
                if (response.lstFacturas.Count == 0)
                    btnExportar.Visible = false;

                gvFactura.DataSource = response.lstFacturas;
                gvFactura.DataBind();
            }
        }

        protected void btnGuardarFactura_OnClick(object sender, EventArgs e)
        {
            var data = new FacturaController();
            var factura = new imf_facturas_fac
            {
                facIdImportacion = int.Parse(Request.Params["Id"]),
                facNumeroFactura = Convert.ToInt32(txbNumeroFactura.Text),
                facMoneda = "USD",
                facValorExtranjera = Convert.ToDecimal(tbxValorME.Text),
                facValorUsd = Convert.ToDecimal(tbxValorUSD.Text),
                facFlete = "",
                facIdProveedor = Convert.ToInt32(cbProveedor.SelectedValue),
                facTerminoFacturacion = "",
                facFechaFactura = dpFechaFacturacion.SelectedDate,
                facFechaRegistro = DateTime.Now
            };

            var response = data.InsertFactura(factura);
            if (response.Success)
            {
                Response.Redirect($"~/Views/Importaciones/FacturaDetalle?ID={response.Factura.facIdFactura}");
            }
        }
    }
}