using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ImportFlex.Account;
using ImportFlex.Controllers;
using ImportFlex.Messages;
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
                CargarTraducciones();

                if (Request.Params["Id"] != null)
                    CargarProducto(int.Parse(Request.Params["Id"]));
            }
        }

        private void CargarTraducciones()
        {
            var data = new TraduccionController();
            var response = data.GetAllTraducciones();

            if (response.Success)
            {
                cbxEditarTraduccion.DataSource = response.Traducciones;
                cbxEditarTraduccion.DataBind();
            }
        }

        private void CargarCatalogos()
        {
            var data = new CatalogosController();

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

            cbxEditarTraduccion.AllowCustomText = true;
            cbxEditarTraduccion.MarkFirstMatch = true;
            cbxEditarTraduccion.Filter = RadComboBoxFilter.Contains;

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


                if (p.Producto.prodIdTraduccion.HasValue)
                {
                    var traduccioncontroller = new TraduccionController();
                    var t = traduccioncontroller.GetTraduccionPorId(p.Producto.prodIdTraduccion.Value);
                    if (t.Success)
                        tbxProductoTraduccion.Text = t.Traduccion.tradTraduccion;
                    
                }

                tbxDescripcion.ToolTip = tbxDescripcion.Text;
            }
        }

        protected void btnGuardar_OnClick(object sender, EventArgs e)
        {
            var data = new ProductoController();
            producto = Request.Params["ID"] != null ? data.GetProductoById(Convert.ToInt32(Request.Params["ID"])).Producto : new imf_productos_prod();

            producto.prodDescripcionRSI = tbxDescripcion.Text;
            //p.prodTraduccion = cbTraduccion.SelectedValue;
            producto.prodMarca = tbxMarca.Text;
            producto.prodModelo = tbxModelo.Text;
            producto.prodSubModelo = tbxSubModelo.Text;
            producto.prodNumeroParte = tbxNumeroParte.Text;
            producto.prodIdPaisOrigen = int.Parse(cbPais.SelectedValue);
            producto.prodFraccionArancelaria = tbxFraccion.Text;
            producto.prodPeso = string.IsNullOrEmpty(tbxPeso.Text) ? 0 : Convert.ToDecimal(tbxPeso.Text);
            producto.prodPiezasPorBulto = string.IsNullOrEmpty(tbxPiezasXBulto.Text) ? 0 : Convert.ToDecimal(tbxPiezasXBulto.Text);
            producto.prodStatus = checkStatus.Checked;
            producto.prodIdUltimaUMC = Convert.ToInt32(cbUMC.SelectedValue);
            producto.prodIdUltimaUMF = Convert.ToInt32(cbUMF.SelectedValue);

            var response = new ProductoResponse();

            if (Request.Params["ID"] == null && Session["idTraduccion"] != null)
            {
                producto.prodIdTraduccion = Convert.ToInt32(Session["idTraduccion"].ToString());
                Session["idTraduccion"] = null;
            }


            response = Request.Params["ID"] != null ? data.UpdateProducto(producto) : data.InsertProducto(producto);

            if (response.Success)
                Response.Redirect($"~/Views/Productos/Detalle.aspx?ID={response.Producto.prodIdProducto}");
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertSuccess",
                    $"alert('Ha ocurrido un error al agregar el producto. {response.Message}');", true);

        }

        protected void btnGuardarTraduccion_OnClick(object sender, EventArgs e)
        {
            ActualizarTraduccion(Convert.ToInt32(cbxEditarTraduccion.SelectedValue));
        }

        protected void btnCrearTraduccion_OnClick(object sender, EventArgs e)
        {
            var data = new TraduccionController();
            var usrController = new UsuarioController();
            var usr = usrController.GetUsuarioById(Sesiones.UsuarioID.Value).Usuario;

            var response = data.InsertTraduccion(new imf_traducciones_trad
            {
                tradFechaRegistro = DateTime.Now,
                tradIdUsuarioRegistro = usr.usrIdUsuario,
                tradTraduccion = tbxNuevaTraduccion.Text
            });


            if (response.Success)
            {
                // ASIGNA NUEVA TRADUCCION AL PRODUCTO
                ActualizarTraduccion(response.Traduccion.tradIdTraduccion);
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertSuccess",
                    $"alert('Ha ocurrido un error. {response.Message}');", true);
        }

        private void ActualizarTraduccion(int _idTraduccion)
        {
            var data = new ProductoController();
            if (Request.Params["ID"] != null)
            {
                var response = data.GetProductoById(Convert.ToInt32(Request.Params["ID"]));

                if (response.Success)
                {
                    var p = response.Producto;

                    p.prodIdTraduccion = _idTraduccion;
                    data.UpdateProducto(p);


                    CargarProducto(p.prodIdProducto);
                }
            }
            else
            {
                Session["idTraduccion"] = _idTraduccion;
                tbxProductoTraduccion.Text = cbxEditarTraduccion.Text;
            }
        }
    }
}