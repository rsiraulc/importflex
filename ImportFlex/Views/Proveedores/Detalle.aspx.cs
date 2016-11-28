using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ImportFlex.Controllers;
using ImportFlex.Models;

namespace ImportFlex.Views.Proveedores
{
    public partial class Detalle : System.Web.UI.Page
    {
        private imf_proveedores_prv proveedor;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarIncoterms();
                if (Request.Params["ID"] != null)
                    CargarProveedor(int.Parse(Request.Params["ID"]));
                

            }
        }

        private void CargarIncoterms()
        {
            cbxIncoterm.DataSource = new List<string> { "EXW", "FCA", "FAS", "FOB", "CFR", "CIF", "CPT", "CIP", "DAT", "DAP", "DDP" };
            cbxIncoterm.DataBind();
        }

        private void CargarProveedor(int id)
        {
            var data = new ProveedorController();
            var response = data.GetProveedorById(id);

            if (response.Success)
            {
                lblTitulo.Text = response.Proveedor.prvDescripcion;
                tbxCodigo.Text = response.Proveedor.prvCodigo;
                tbxDescripcion.Text = response.Proveedor.prvDescripcion;
                tbxTax.Text = response.Proveedor.prvIdTax;

                cbxIncoterm.SelectedValue = response.Proveedor.prvIncoterm ?? "DAP";
                cbxIncoterm.DataBind();

                proveedor = response.Proveedor;
            }
        }

        protected void btnGuardar_OnClick(object sender, EventArgs e)
        {
            var data = new ProveedorController();

            if (Request.Params["ID"] == null)
                proveedor = new imf_proveedores_prv();
            else
            {
                var _response = data.GetProveedorById(Convert.ToInt32(Request.Params["ID"]));
                if (_response.Success)
                    proveedor = _response.Proveedor;
            }

            proveedor.prvCodigo = tbxCodigo.Text;
            proveedor.prvDescripcion = tbxDescripcion.Text;
            proveedor.prvIdTax = tbxTax.Text;
            proveedor.prvIncoterm = cbxIncoterm.SelectedValue;

            if (Request.Params["ID"] != null)
            {
                var response = data.UpdateProveedor(proveedor);
                if (response.Success)
                    Response.Redirect($"~/Views/Proveedores/Default");
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertSuccess",
                       $"alert('Ha ocurrido un error. {response.Message}');", true);
            }
            else
            {
                var response = data.InsertProveedor(proveedor);
                if (response.Success)
                    Response.Redirect($"~/Views/Proveedores/Detalle.aspx?ID={response.Proveedor.prvIdProveedor}");
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertSuccess",
                      $"alert('Ha ocurrido un error. {response.Message}');", true);
            }
        }
    }
}