﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImportFlex.Controllers.Enums;
using ImportFlex.Messages;
using ImportFlex.Models;

namespace ImportFlex.Controllers
{
    public class FacturaDetalleController
    {
        ImportFlexEntities db = new ImportFlexEntities();

        public FacturaDetallesResponse GetFacturaDetalleByFacturaId(int IdFactura)
        {
            var response = new FacturaDetallesResponse();

            try
            {
                var fd = db.imf_facturadetalle_fde.Where(f => f.fdeIdFactura == IdFactura).ToList();

                response.lstFacturaDetalle = fd;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public FacturaDetalleResponse GetDetalleFacturaById(int id)
        {
            var response = new FacturaDetalleResponse();

            try
            {
                var fd = db.imf_facturadetalle_fde.Find(id);

                response.FacturaDetalle = fd;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;

        }

        public FacturaDetalleResponse InsertFacturaDetalle(imf_facturadetalle_fde detalle)
        {
            var response = new FacturaDetalleResponse();
            

            try
            {
                var importacionController = new ImportacionController();

                response.FacturaDetalle = db.imf_facturadetalle_fde.Add(detalle);
                db.SaveChanges();
                
                importacionController.ActualizarTotalesAdd(response.FacturaDetalle.fdeIdFactura);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public FacturaDetalleResponse DeleteFacturaDetalle(imf_facturadetalle_fde detalle)
        {
            var response = new FacturaDetalleResponse();

            try
            {
                var idFactura = detalle.fdeIdFactura;
                db.imf_facturadetalle_fde.Remove(detalle);
                db.SaveChanges();

                var importacionController = new ImportacionController();
                //importacionController.ActualizarTotalesRemove(idFactura);
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