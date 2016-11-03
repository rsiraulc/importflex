﻿using System;
using System.IO;
using System.Text;
using System.Web.UI;
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
                lblTitulo.Text = "Facturas del Pedimento No." + response.Importacion.impNumeroPedimento;
                if (response.Importacion.impParte > 1)
                    lblTitulo.Text += $" Parte {response.Importacion.impParte}";

                // MANEJO DE VISUALIZACION DE BOTONES
                switch (response.Importacion.impStatus)
                {
                    case "BORRADOR":
                        btnExportar.Visible = false;
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
                facNotas = tbxNotas.Text
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

        protected void btnExportar_OnClick(object sender, EventArgs e)
        {
            var data = new ImportacionController();
            //data.UpdateImportacionStatus(int.Parse(Request.Params["Id"]), StatusImportacion.EXPORTADO);

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
                    //Response.AddHeader("Content-Length", respuesta.RutaArchivo.Length.ToString());
                    Response.ContentType = "application/zip";
                    Response.Flush();
                    Response.TransmitFile(respuesta.RutaArchivo);
                    Response.End();

                }
            }
        }

        protected void btnFinalizarPedimento_OnClick(object sender, EventArgs e)
        {
            //var data = new ImportacionController();
            //data.UpdateImportacionStatus(int.Parse(Request.Params["Id"]), StatusImportacion.FINALIZADO);
        }
    }
}