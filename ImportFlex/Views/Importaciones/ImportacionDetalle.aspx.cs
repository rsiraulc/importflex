using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;
using ImportFlex.Account;
using ImportFlex.Controllers;
using ImportFlex.Controllers.Enums;
using ImportFlex.Controllers.Export;
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
                CargarImportacion(int.Parse(Request.Params["Id"]));
                CargarFacturas(int.Parse(Request.Params["Id"]));
                CargarProveedor();
                dpFechaFacturacion.SelectedDate = DateTime.Now;
            }

            cbProveedor.AllowCustomText = true;
            cbProveedor.MarkFirstMatch = true;
            cbProveedor.Filter = RadComboBoxFilter.Contains;
        }

        private void CargarImportacion(int id)
        {
            var data = new ImportacionController();
            var response = data.GetImportacionById(id);

            if (response.Success)
            {
                lblTitulo.Text = "Facturas del Pedimento " + response.Importacion.impNumeroPedimento;
                if (response.Importacion.impParte > 1)
                    lblTitulo.Text += $" Parte {response.Importacion.impParte}";

                btnUpdateNumeroPedimento.Visible = !response.Importacion.impTieneNumeroImportacion ?? true;
                btnMenuDescargar.Visible = response.Importacion.imf_facturas_fac.Any();

                // MANEJO DE VISUALIZACION DE BOTONES
                switch (response.Importacion.impStatus)
                {
                    case "BORRADOR":
                        //btnExportar.Visible = false;
                        break;
                    case "EXPORTADO":
                        btnFinalizarPedimento.Visible = true;
                        break;
                    case "FINALIZADO":
                        btnFinalizarPedimento.Visible = false;
                        btnNuevaFactura.Visible = false;
                        break;
                }
            }
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
                //if (response.lstFacturas.Count == 0)
                //    Visible = false;

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
                facNumeroFactura = txbNumeroFactura.Text,
                facMoneda = "USD",                
                facValorUsd = Convert.ToDecimal(tbxValorUSD.Text),
                facValorExtranjera = Convert.ToDecimal(tbxValorUSD.Text),
                facFlete = Convert.ToDecimal(txbFlete.Text),
                facIdProveedor = Convert.ToInt32(cbProveedor.SelectedValue),
                facTerminoFacturacion = "",
                facFechaFactura = dpFechaFacturacion.SelectedDate,
                facFechaRegistro = DateTime.Now,
                facNumeroEntrada = tbxEntrada.Text,
                facNotas = tbxNotas.Text,
                facIdUsuarioRegistro = Sesiones.UsuarioID.Value
            };

            var response = data.InsertFactura(factura);
            if (response.Success)
            {
                Response.Redirect($"~/Views/Importaciones/FacturaDetalle?ID={response.Factura.facIdFactura}");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertSuccess", $"alert('{response.Message}');", true);
            }
        }

        
        protected void btnFinalizarPedimento_OnClick(object sender, EventArgs e)
        {
            var data = new ImportacionController();
            data.UpdateImportacionStatus(int.Parse(Request.Params["Id"]), StatusImportacion.FINALIZADO, Sesiones.UsuarioID.Value);

            Response.Redirect("~/Views/Importaciones/ImportacionDetalle.aspx?ID=" + int.Parse(Request.Params["Id"]));
        }

        protected void lnkDescargarFormatos_OnClick(object sender, EventArgs e)
        {
            var data = new ImportacionController();
            data.UpdateImportacionStatus(int.Parse(Request.Params["Id"]), StatusImportacion.EXPORTADO, Sesiones.UsuarioID.Value);

            var response = data.GetImportacionById(int.Parse(Request.Params["Id"]));
            if (response.Success)
            {
                var archivo = new ArchivoPedimento();
                var respuesta = archivo.CrearArchivo(response.Importacion);

                if (respuesta.Success)
                {
                    Response.Clear();
                    Response.ClearHeaders();
                    Response.ClearContent();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + respuesta.NombreArchivo);
                    Response.ContentType = "application/zip";
                    Response.Flush();
                    Response.TransmitFile(respuesta.RutaArchivo);
                    Response.End();

                }

                // ELIMINA ARCHIVO DEL SERVIDOR
                archivo.EliminarArchivo(respuesta.RutaArchivo);
            }
        }

        protected void lnkDescargarHT_OnClick(object sender, EventArgs e)
        {
            var data = new ImportacionController();
            var response = data.GetImportacionById(int.Parse(Request.Params["Id"]));

            if (response.Success)
            {
                var ht = new HojaTraduccion();
                var respuesta = ht.CrearHojaTraduccion(response.Importacion);
                if (respuesta.Success)
                {
                    Response.Clear();
                    Response.ClearHeaders();
                    Response.ClearContent();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + respuesta.NombreArchivo);
                    Response.ContentType = "application/pdf";
                    Response.Flush();
                    Response.TransmitFile(respuesta.RutaArchivo);
                    Response.End();
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertSuccess", $"alert('{response.Message}');", true);
                

                // ELIMINA ARCHIVO DEL SERVIDOR
                ht.EliminarArchivo(respuesta.RutaArchivo);
            }
        }

        protected void btnUpdateNumeroPedimento_OnClick(object sender, EventArgs e)
        {
            var data = new ImportacionController();
            var response = data.GetImportacionById(int.Parse(Request.Params["Id"]));

            if (response.Success)
            {
                var update = data.UpdateNumeroPedimento(response.Importacion, tbxNumeroPedimento.Text, Sesiones.UsuarioID.Value);

                if (update.Success)
                    Response.Redirect("~/Views/Importaciones/ImportacionDetalle.aspx?ID=" + response.Importacion.impIdImportacion);
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertSuccess",
                        $"alert('{update.Message}');", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertSuccess", $"alert('{response.Message}');", true);
        }
    }
}