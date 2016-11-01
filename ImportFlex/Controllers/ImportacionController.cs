using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImportFlex.Controllers.Enums;
using ImportFlex.Messages;
using ImportFlex.Models;

namespace ImportFlex.Controllers
{
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

        public ImportacionesResponse GetImportacionByFiltro(string status, DateTime? fecha)
        {
            var response = new ImportacionesResponse();

            try
            {
                if (status != "" && fecha != null)
                {
                    response.lstImportaciones =
                        db.imf_importaciones_imp.Where(im => (im.impFecha == fecha.Value) && (im.impStatus == status))
                            .ToList();
                    response.Success = true;
                }
                else if (status != "" && fecha == null)
                {
                    response.lstImportaciones = db.imf_importaciones_imp.Where(im => im.impStatus == status).ToList();
                    response.Success = true;
                }
                else
                {
                    response.lstImportaciones =
                        db.imf_importaciones_imp.Where(im => im.impFecha == fecha.Value).ToList();
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

        public void UpdateImportacionStatus(int idImportacion, StatusImportacion status)
        {
            var response = GetImportacionById(idImportacion);

            if (response.Success)
            {
                response.Importacion.impStatus = status.ToString();
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
                    foreach (var d in f.imf_facturadetalle_fde)
                    {
                        importacion.impTotalArticulos += Convert.ToInt32(d.fdeCantidadUMC);
                        importacion.impTotal += d.fdeValor;
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
                        importacion.impTotalArticulos -= Convert.ToInt32(d.fdeCantidadUMC);
                        importacion.impTotal -= d.fdeValor;
                    }
                }
                db.SaveChanges();
            }
        }

        public ImportacionResponse ValidarNumeroImportacion(imf_importaciones_imp importacion)
        {
            var response = new ImportacionResponse();

            try
            {
                var imp =
                    db.imf_importaciones_imp.FirstOrDefault(p => p.impNumeroPedimento == importacion.impNumeroPedimento);

                if (imp != null)
                {
                    response.Importacion = imp;
                    response.Success = true;
                    response.Message =
                        $"Ya hay un pedimento con este número, ¿deseas registrar la parte {response.Importacion.impParte + 1}?";
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
    }
}