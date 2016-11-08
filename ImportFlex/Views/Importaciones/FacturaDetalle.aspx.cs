﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using ImportFlex.Account;
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
                CargarCatalogos();
                CargarDetalleFactura(int.Parse(Request.Params["Id"]));
                CargarTraducciones();
                SetearComboBoxs();
                LimpiarControles();

            }
        }

        #region Cargar Configuraciones
        private void CargarTraducciones()
        {
            var data = new CatalogosController();
            cbTraduccion.DataSource = data.GetListaTraducciones();
            cbTraduccion.DataBind();
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


            cbTraduccion.AllowCustomText = true;
            cbTraduccion.MarkFirstMatch = true;
            cbTraduccion.Filter = RadComboBoxFilter.Contains;


            cbUMF.AllowCustomText = true;
            cbUMF.MarkFirstMatch = true;
            cbUMF.Filter = RadComboBoxFilter.Contains;

            cbPaisOrigen.AllowCustomText = true;
            cbPaisOrigen.MarkFirstMatch = true;
            cbPaisOrigen.Filter = RadComboBoxFilter.Contains;

        }

        private void LimpiarControles()
        {
            cbUMC.SelectedIndex = -1;
            cbProducto.SelectedIndex = -1;
            cbPaisOrigen.SelectedIndex = -1;
            cbUMF.SelectedIndex = -1;
            tbxNumeroSerie.Text = "";
            tbxValor.Text = "0";
            tbxFraccion.Text = "";

        }

        private void CargarCatalogos()
        {
            var data = new CatalogosController();
            var umc = data.GetAllUMC();
            if (umc.Success)
            {
                cbUMC.DataSource = umc.lstUMC;
                cbUMC.DataBind();
            }

            var umf = data.GetUMFEnUso();
            if (umf.Success)
            {
                cbUMF.DataSource = umf.lstUMF;
                cbUMF.DataBind();
            }

            var paises = data.GetAllPaises();
            if (paises.Success)
            {
                cbPaisOrigen.DataSource = paises.lstPaises;
                cbPaisOrigen.DataBind();
            }
        }

        private void CargarProductos()
        {
            var data = new ProductoController();
            var response = data.GetProductosActivos();

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

#endregion

        protected void btnAgregarProducto_OnClick(object sender, EventArgs e)
        {
            var fd = new FacturaDetalleController();
            decimal cantidad = 0;
            string NoSerie = "";

            if (tbxNumeroSerie.Visible)
            {
                cantidad = 1;
                NoSerie = tbxNumeroSerie.Text;
            }
            else
            {
                cantidad = Convert.ToDecimal(tbxCantidad.Text);
                NoSerie = "NA";
            }


            var detalle = new imf_facturadetalle_fde
            {
                fdeIdFactura = int.Parse(Request.Params["Id"]),
                fdeCantidadUMC = cantidad,
                fdeIdUMC = Convert.ToInt32(cbUMC.SelectedValue),
                fdeIdProducto = Convert.ToInt32(cbProducto.SelectedValue),
                fdeNumeroSerieProducto = NoSerie,
                fdeValor = Convert.ToDecimal(tbxValor.Text),
                fdeFecha = DateTime.Now,
                fdeCantidadUMF = cantidad,
                fdeIdUMF = Convert.ToInt16(cbUMF.SelectedValue),
                //VER QUE SHOW
                fdeVinculacion = "0",
                fdeMetodoValoracion = "0",
                fdeIdPaisVendedorComprador = 72,
                fdIdPaisOrigenDestino = Convert.ToInt16(cbPaisOrigen.SelectedValue),
                fdeIdUsuarioRegistro = Sesiones.UsuarioID.Value
            };

            var response = fd.InsertFacturaDetalle(detalle);
            if (response.Success)
            {
                //OPCION PROVISIONAL PARA LLENADO DE DATOS DE PRODUCTO
                ActualizarProducto();

                Response.Redirect($"~/Views/Importaciones/FacturaDetalle?ID={response.FacturaDetalle.fdeIdFactura}");
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertSuccess",
                    $"alert('Ha ocurrido un error al agregar el producto. {response.Message}');", true);
        }

        private void ActualizarProducto()
        {
            var data = new ProductoController();
            var response = data.GetProductoById(Convert.ToInt32(cbProducto.SelectedValue));
            if (response.Success)
            {
                var p = response.Producto;
                p.prodTraduccion = cbTraduccion.SelectedValue.Replace("- ", "");
                p.prodMarca = tbxMarca.Text;
                p.prodModelo = tbxModelo.Text;
                p.prodFraccionArancelaria = tbxFraccion.Text;
                p.prodUltimoCosto = Convert.ToDecimal(tbxValor.Text);
                p.prodIdUltimaUMC = Convert.ToInt16(cbUMC.SelectedValue);
                p.prodIdUltimaUMF = Convert.ToInt16(cbUMF.SelectedValue);
                p.prodIdPaisOrigen = Convert.ToInt16(cbPaisOrigen.SelectedValue);
                data.UpdateProducto(p);
            }
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
            CargarDatosProducto(id);
        }

        private void CargarDatosProducto(int id)
        {
            
            var data = new ProductoController();

            var response = data.GetProductoById(id);
            if (response.Success)
            {
                tbxProductoDescripcion.Text = response.Producto.prodDescripcionRSI;
                tbxMarca.Text = response.Producto.prodMarca;
                tbxModelo.Text = response.Producto.prodModelo;
                tbxValor.Text = response.Producto.prodUltimoCosto.HasValue ? response.Producto.prodUltimoCosto.Value.ToString() : "0";
                cbUMC.SelectedIndex = response.Producto.prodIdUltimaUMC == null ? 0 : response.Producto.prodIdUltimaUMC.Value - 1;
                cbUMF.SelectedValue = response.Producto.prodIdUltimaUMF.ToString() ?? "1";
                cbUMC.DataBind();
                cbUMF.DataBind();

                cbPaisOrigen.SelectedIndex = response.Producto.prodIdPaisOrigen.Value - 1;
                cbPaisOrigen.DataBind();

                tbxFraccion.Text = response.Producto.prodFraccionArancelaria;

                if (response.Producto.prodTraduccion != "")
                {
                    cbTraduccion.Visible = false;
                    tbxProductoTraduccion.Visible = true;
                    tbxProductoTraduccion.Text = response.Producto.prodTraduccion;
                }
                else
                {
                    cbTraduccion.Visible = true;
                    tbxProductoTraduccion.Visible = false;
                }

                //VALIDA SI REQUIERE NUMERO DE SERIE O QUE INGRESE CANTIDAD
                if (response.Producto.prodRequiereNoSerie)
                {
                    tbxNumeroSerie.Visible = true;
                    tbxCantidad.Visible = false;
                    lblSerieCantidad.Text = "No. Serie";
                }
                else
                {
                    tbxNumeroSerie.Visible = false;
                    tbxCantidad.Visible = true;
                    lblSerieCantidad.Text = "Cantidad";
                }


                tbxProductoDescripcion.ToolTip = tbxProductoDescripcion.Text;
                tbxProductoTraduccion.ToolTip = tbxProductoTraduccion.Text;
            }
        }
    }
}