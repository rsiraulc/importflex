using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImportFlex.Messages;
using ImportFlex.Models;

namespace ImportFlex.Controllers
{
    public class FacturaController
    {
        ImportFlexEntities db = new ImportFlexEntities();

        public FacturasResponse GetAllFacturas()
        {
            var response = new FacturasResponse();

            try
            {
                response.lstFacturas = db.imf_facturas_fac.ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public FacturasResponse GetFacturasByIdImportacion(int idImportacion)
        {
            var response = new FacturasResponse();

            try
            {
                response.lstFacturas = db.imf_facturas_fac.Where(f => f.facIdImportacion == idImportacion).ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public FacturaResponse GetFacturaById(int id)
        {
            var response = new FacturaResponse();
            try
            {
                response.Factura = db.imf_facturas_fac.Find(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public FacturaResponse InsertFactura(imf_facturas_fac factura)
        {
            var response = new FacturaResponse();

            try
            {
                var validacion = ValidarFactura(factura);
                if (validacion.Success)
                {

                    var fac = db.imf_facturas_fac.Add(factura);
                    db.SaveChanges();

                    var imp = new ImportacionController();
                    imp.ActualizarTotalFacturas(factura.facIdFactura);

                    response.Factura = fac;
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.Message = validacion.Message;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        private ResponseBase ValidarFactura(imf_facturas_fac factura)
        {
            var response = new ResponseBase();
            response.Success = true;
            var importacion = db.imf_importaciones_imp.Find(factura.facIdImportacion);
            var lstImportaciones =
                db.imf_importaciones_imp.Where(p => p.impNumeroPedimento == importacion.impNumeroPedimento);

            try
            {
                foreach (var imp in lstImportaciones)
                {
                    if (response.Success)
                    {
                        foreach (var f in imp.imf_facturas_fac)
                        {
                            if (factura.facNumeroFactura == f.facNumeroFactura &&
                                factura.facIdProveedor == f.facIdProveedor)
                            {
                                response.Success = false;
                                response.Message =
                                    $"Ya existe esta factura en el Pedimento No. {imp.impNumeroPedimento} Parte {imp.impParte}.";
                                break;
                            }
                            else
                                response.Success = true;
                        }
                    }
                    else
                        break;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public FacturaResponse DeleteFactura(imf_facturas_fac factura)
        {
            var response = new FacturaResponse();

            try
            {
                db.imf_facturas_fac.Remove(factura);
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

        public FacturaResponse UpdateFactura(imf_facturas_fac factura)
        {
            var response = new FacturaResponse();

            try
            {
                var fact = GetFacturaById(factura.facIdFactura);
                if (fact.Factura != null)
                {
                    db.Entry(fact.Factura).CurrentValues.SetValues(factura);
                    db.SaveChanges();

                    response.Factura = factura;
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
    }
}