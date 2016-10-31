using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImportFlex.Messages.Catalogos;
using ImportFlex.Models;

namespace ImportFlex.Controllers
{
    public class CatalogosController
    {
        ImportFlexEntities db = new ImportFlexEntities();

        #region Pais

        public PaisesResponse GetAllPaises()
        {
            var response = new PaisesResponse();

            try
            {
                response.lstPaises = db.imf_paises_pai.ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public PaisResponse GetPaisById(int id)
        {
            var response = new PaisResponse();

            try
            {
                response.Pais = db.imf_paises_pai.Find(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        #endregion

        #region UMC (Unidad de Medida Comercial)

        public UMCsResponse GetAllUMC()
        {
            var response = new UMCsResponse();

            try
            {
                response.lstUMC = db.imf_unidadmedidacomercial_umc.ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public UMCResponse GetUMCById(int id)
        {
            var response = new UMCResponse();

            try
            {
                response.UMC = db.imf_unidadmedidacomercial_umc.Find(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        #endregion

        #region UMF (Unidad de Medida Factura)

        public UMFsResponse GetAllUMF()
        {
            var response = new UMFsResponse();

            try
            {
                response.lstUMF = db.imf_unidadmedidafactura_umf.ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public UMFResponse GetUMFById(int id)
        {
            var response = new UMFResponse();

            try
            {
                response.UMF = db.imf_unidadmedidafactura_umf.Find(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        #endregion
    }
}