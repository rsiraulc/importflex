using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImportFlex.Messages;
using ImportFlex.Models;

namespace ImportFlex.Controllers
{
    public class ProveedorController
    {
        private ImportFlexEntities db = new ImportFlexEntities();

        public ProveedoresResponse GetAllProveedores()
        {
            var response = new ProveedoresResponse();
            try
            {
                response.lstProveedores = db.imf_proveedores_prv.ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public ProveedorResponse GetProveedorById(int id)
        {
            var response = new ProveedorResponse();

            try
            {
                response.Proveedor = db.imf_proveedores_prv.Find(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public ProveedoresResponse GetProveedoresByFiltro(string filtro)
        {
            var response = new ProveedoresResponse();

            try
            {
                response.lstProveedores = db.imf_proveedores_prv.Where(p => (p.prvCodigo.Contains(filtro) || p.prvDescripcion.Contains(filtro))).ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public ProveedorResponse InsertProveedor(imf_proveedores_prv proveedor)
        {
            var response = new ProveedorResponse();

            try
            {
                var prov = db.imf_proveedores_prv.Add(proveedor);
                db.SaveChanges();

                response.Proveedor = prov;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public ProveedorResponse DeleteProveedor(imf_proveedores_prv proveedor)
        {
            var response = new ProveedorResponse();

            try
            {
                db.imf_proveedores_prv.Remove(proveedor);
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

        public ProveedorResponse UpdateProveedor(imf_proveedores_prv proveedor)
        {
            var response = new ProveedorResponse();

            try
            {
                var prov = GetProveedorById(proveedor.prvIdProveedor);
                if (prov.Proveedor != null)
                {
                    db.Entry(prov.Proveedor).CurrentValues.SetValues(proveedor);
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
    }
}