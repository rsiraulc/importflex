using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ImportFlex.Controllers;
using ImportFlex.Controllers.Enums;
using ImportFlex.Models;

namespace ImportFlex.Views.Importaciones
{
    public partial class Importacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarImportaciones();
                CargarRegionOperacion();
                cbStatus.DataSource = new List<string> {"BORRADOR", "ENPROCESO", "FINALIZADA" };
                cbStatus.DataBind();
            }
        }

        private void CargarRegionOperacion()
        {
            cbRegion.DataSource = RegionPedimento.GetRegionPedimento();
            cbRegion.DataBind();

            cbTipoOPeracion.DataSource = TipoOperacion.GetTipoOperaciones();
            cbTipoOPeracion.DataBind();
        }

        private void CargarImportaciones()
        {
            var db = new ImportacionController();
            var x = db.GetAllImportaciones();
            rgImportaciones.DataSource = x.lstImportaciones;
            rgImportaciones.DataBind();
        }

        protected void btnGuardarImportacion_OnClick(object sender, EventArgs e)
        {
            ValidarImportacion();
        }

        private void RegistrarImportacion(int? parte)
        {
            var data = new ImportacionController();
            var importacion = new imf_importaciones_imp
            {
                impNumeroPedimento = tbxNumeroPedimento.Text,
                impFecha = DateTime.Now,
                impTotalArticulos = 0,
                impTotal = 0,
                impStatus = StatusImportacion.BORRADOR.ToString(),
                impClave = "AR",
                impCodigoImportador = "RME",
                impTotalFlete = 0,
                impTransporteEntradaSalida = 7,
                impTransporteArribo = 7,
                impTransporteSalidaAduana = 7,
                impRegion = cbRegion.SelectedValue,
                impTotalFacturas = 0,
                impParte = parte ?? 1,
                impTipoOperacion = int.Parse(cbTipoOPeracion.SelectedValue),
                impTipoRegistro = 501
            };

            var response = data.InsertImportacion(importacion);

            if (response.Success)
                Response.Redirect($"~/Views/Importaciones/ImportacionDetalle?ID={response.Importacion.impIdImportacion}");
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertSuccess",
                    $"alert('Ha ocurrido un error al registrar el pedimento. {response.Message}');", true);

        }

        protected void btnFiltrar_OnClick(object sender, EventArgs e)
        {
            var data = new ImportacionController();
            var lst = data.GetImportacionByFiltro(cbStatus.SelectedValue.ToString(), rdpFecha.SelectedDate);
        }

        public void ValidarImportacion()
        {
            var data = new ImportacionController();
            var existe = data.ValidarNumeroImportacion(tbxNumeroPedimento.Text);

            // SI NO HAY PEDIMENTOS CON ESE NO.
            if (existe.Importacion == null)
            {
                RegistrarImportacion(1);
            }
            // SI SI HAY
            else
            {
                radwindowImportacionDuplicada.Visible = true;
                radwindowImportacionDuplicada.VisibleOnPageLoad = true;
                lblMensaje.Text =  $"El Pedimento con el número {tbxNumeroPedimento.Text} ya fue creado, ¿Deseas crear la parte {data.GetParteImportacion(tbxNumeroPedimento.Text)} de este pedimento o crear uno nuevo?";

            }
        }

        protected void btnCrearDuplicado_OnClick(object sender, EventArgs e)
        {
            var data = new ImportacionController();
            RegistrarImportacion(data.GetParteImportacion(tbxNumeroPedimento.Text));
        }
    }
}