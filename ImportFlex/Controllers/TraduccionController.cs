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

        public TraduccionesResponse TraeAllTraducciones()
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
    }
}