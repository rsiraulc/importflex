using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImportFlex.Messages;
using ImportFlex.Models;

namespace ImportFlex.Controllers
{
    public class TraduccionController
    {
        private ImportFlexEntities db = new ImportFlexEntities();

        public TraduccionesResponse GetAllTraducciones()
        {
            var response = new TraduccionesResponse();
            try
            {
                response.Traducciones = db.imf_traducciones_trad.ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public TraduccionResponse GetTraduccionPorId(int id)
        {
            var response = new TraduccionResponse();

            try
            {
                response.Traduccion = db.imf_traducciones_trad.Find(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public TraduccionResponse InsertTraduccion(imf_traducciones_trad traduccion)
        {
            var response = new TraduccionResponse();

            try
            {
                var _traduccion = db.imf_traducciones_trad.Add(traduccion);
                db.SaveChanges();

                response.Traduccion = _traduccion;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public ResponseBase DeleteTraduccion(int id)
        {
            var response = new ResponseBase();

            try
            {
                var traduccion = GetTraduccionPorId(id);
                db.imf_traducciones_trad.Remove(traduccion.Traduccion);

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public TraduccionResponse UpdateTraduccion(int id)
        {
            var response = new TraduccionResponse();

            try
            {
                var traduccion = GetTraduccionPorId(id).Traduccion;

                var _trad = GetTraduccionPorId(traduccion.tradIdTraduccion);
                if (_trad.Traduccion != null)
                {
                    db.Entry(_trad.Traduccion).CurrentValues.SetValues(traduccion);
                    db.SaveChanges();

                    response.Success = true;
                    response.Traduccion = traduccion;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

    }
}