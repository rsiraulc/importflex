﻿using System;
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
                var fac = db.imf_facturas_fac.Add(factura);
                db.SaveChanges();

                response.Factura = fac;
                response.Success = true;
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