using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImportFlex.Controllers.Enums;
using ImportFlex.Messages;
using ImportFlex.Models;
using Microsoft.Ajax.Utilities;

namespace ImportFlex.Controllers
{
    public class FechaFiltro
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
    }

    public class ImportacionController
    {
        private ImportFlexEntities db = new ImportFlexEntities();

        public ImportacionesResponse GetAllImportaciones()
        {
            var response = new ImportacionesResponse();

            try
            {
                response.lstImportaciones = db.imf_importaciones_imp.ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public ImportacionResponse GetImportacionById(int id)
        {
            var response = new ImportacionResponse();

            try
            {
                response.Importacion = db.imf_importaciones_imp.Find(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public ImportacionResponse GetImportacionByIdFactura(int idFactura)
        {
            var response = new ImportacionResponse();
            var facturaController = new FacturaController();

            try
            {
                var factura = facturaController.GetFacturaById(idFactura);
                if (factura.Success)
                {
                    var imp = GetImportacionById(factura.Factura.facIdImportacion);
                    if (imp.Success)
                    {
                        response.Importacion = imp.Importacion;
                        response.Success = true;
                    }
                    else
                        response.Success = false;
                }
                else
                    response.Success = false;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public ImportacionesResponse GetImportacionByFiltro(string status, FechaFiltro fechas)
        {
            var response = new ImportacionesResponse();

            try
            {
                if (status == "TODOS")
                    status = null;

                if (!status.IsNullOrWhiteSpace() && fechas != null)
                {
                    response.lstImportaciones =
                        db.imf_importaciones_imp.Where(
                            p =>
                                (p.impFecha >= fechas.FechaInicio && p.impFecha < fechas.FechaFinal) &&
                                status == p.impStatus).ToList();
                    response.Success = true;
                }
                else if (!status.IsNullOrWhiteSpace() && fechas == null)
                {
                    response.lstImportaciones = db.imf_importaciones_imp.Where(p => p.impStatus == status).ToList();
                    response.Success = true;
                }
                else if (status.IsNullOrWhiteSpace() && fechas != null)
                {
                    response.lstImportaciones =
                        db.imf_importaciones_imp.Where(
                            p => p.impFecha >= fechas.FechaInicio && p.impFecha < fechas.FechaFinal).ToList();
                    response.Success = true;
                }
                else
                {
                    response.lstImportaciones = db.imf_importaciones_imp.ToList();
                    response.Success = true;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public ImportacionResponse InsertImportacion(imf_importaciones_imp importacion)
        {
            var response = new ImportacionResponse();

            try
            {
                var imp = db.imf_importaciones_imp.Add(importacion);
                db.SaveChanges();

                response.Importacion = imp;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public ImportacionResponse DeleteImportacion(imf_importaciones_imp importacion)
        {
            var response = new ImportacionResponse();

            try
            {
                db.imf_importaciones_imp.Remove(importacion);
                db.SaveChanges();

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public ImportacionResponse UpdateImportacion(imf_importaciones_imp importacion)
        {
            var response = new ImportacionResponse();

            try
            {
                var imp = GetImportacionById(importacion.impIdImportacion);
                if (imp.Importacion != null)
                {
                    db.Entry(imp.Importacion).CurrentValues.SetValues(importacion);
                    db.SaveChanges();

                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Este registro no existe";
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public void UpdateImportacionStatus(int idImportacion, StatusImportacion status, int idUsuario)
        {
            var response = GetImportacionById(idImportacion);

            if (response.Success)
            {
                response.Importacion.impStatus = status.ToString();

                switch (status)
                {
                    case StatusImportacion.EXPORTADO:
                        response.Importacion.impIdUsuarioExporto = idUsuario;
                        response.Importacion.impFechaUltimaExportacion = DateTime.Now;
                        break;

                    case StatusImportacion.FINALIZADO:
                        response.Importacion.impIdUsuarioFinalizo = idUsuario;
                        response.Importacion.impFechaFinalizacion = DateTime.Now;
                        break;
                }

                db.SaveChanges();
            }
        }

        public void ActualizarTotalesAdd(int idFactura)
        {

            var response = GetImportacionByIdFactura(idFactura);
            if (response.Success)
            {
                var importacion = response.Importacion;
                importacion.impTotalArticulos = 0;
                importacion.impTotal = 0;
                foreach (var f in importacion.imf_facturas_fac)
                {
                    var factura = importacion.imf_facturas_fac.FirstOrDefault(fac => fac.facIdFactura == idFactura);
                    factura.facValorUsd = 0;
                    factura.facValorExtranjera = 0;

                    foreach (var d in f.imf_facturadetalle_fde)
                    {
                        importacion.impTotalArticulos += Convert.ToInt32(d.fdeCantidadUMC);
                        importacion.impTotal += d.fdeValor;
                        factura.facValorExtranjera += d.fdeValor;
                        factura.facValorUsd += d.fdeValor;
                    }
                }
                db.SaveChanges();
            }
        }

        public void ActualizarTotalFacturas(int idFactura)
        {
            var response = GetImportacionByIdFactura(idFactura);
            if (response.Success)
            {
                if (response.Importacion.impTotalFacturas == 0)
                    response.Importacion.impStatus = StatusImportacion.ENPROCESO.ToString();

                response.Importacion.impTotalFacturas++;
                db.SaveChanges();
            }
        }

        public void ActualizarTotalesRemove(int idFactura)
        {

            var response = GetImportacionByIdFactura(idFactura);
            if (response.Success)
            {
                var importacion = response.Importacion;
                importacion.impTotalArticulos = 0;
                importacion.impTotal = 0;
                foreach (var f in importacion.imf_facturas_fac)
                {
                    foreach (var d in f.imf_facturadetalle_fde)
                    {

                        importacion.impTotalArticulos--;
                        importacion.impTotal -= d.fdeValor;
                    }
                }
                db.SaveChanges();
            }
        }

        public ImportacionResponse ValidarNumeroImportacion(string numeropedimento)
        {
            var response = new ImportacionResponse();

            try
            {
                var imp =
                    db.imf_importaciones_imp.FirstOrDefault(p => p.impNumeroPedimento == numeropedimento);

                if (imp != null)
                {
                    response.Importacion = imp;
                    response.Success = true;
                    response.Message =
                        $"Ya hay un pedimento con este número, ¿deseas registrar la parte {GetParteImportacion(imp.impNumeroPedimento)}?";
                }
                else
                {
                    response.Success = true;
                    response.Message = "No hay importaciones previas";
                    response.Importacion = null;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public int GetParteImportacion(string numeroPedimento)
        {
            try
            {
                var imp = db.imf_importaciones_imp.Where(p => p.impNumeroPedimento == numeroPedimento).ToList();

                var max = from x in imp
                    where x.impNumeroPedimento == numeroPedimento
                    orderby x.impParte descending
                    select x.impParte;

                return max.First().Value + 1;
            }
            catch (Exception ex)
            {

                return 1;
            }
        }

        public ResponseBase UpdateNumeroPedimento(imf_importaciones_imp importacion, string numeroPedimentoNuevo, int idUsuario)
        {

            var response = new ResponseBase();

            try
            {
                // SE HACE EL UPDATE DE VALORES EN ESTE PEDIMENTO Y EN LAS PARTES QUE TENGAN EL MISMO NUMERO DE PEDIMENTO
                var partes = db.imf_importaciones_imp.Where(p => p.impNumeroPedimento == importacion.impNumeroPedimento);

                foreach (var parte in partes)
                {
                    parte.impNumeroPedimento = numeroPedimentoNuevo;
                    parte.impFechaUpdateNumeroPedimento = DateTime.Now;
                    parte.impIdUsuarioUpdateNumeroPedimento = idUsuario;
                    parte.impTieneNumeroImportacion = true;
                }

                db.SaveChanges();
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}