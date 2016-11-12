using System;
using System.Linq;
using ImportFlex.Messages;
using ImportFlex.Models;
using Microsoft.Ajax.Utilities;

namespace ImportFlex.Controllers
{
    public class ProductoController
    {
        private ImportFlexEntities db = new ImportFlexEntities();

        public ProductosResponse GetAllProductos()
        {
            var response = new ProductosResponse();
            try
            {
                response.Productos = db.imf_productos_prod.ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public ProductosResponse GetProductosActivos()
        {
            var response = new ProductosResponse();

            try
            {
                response.Productos = db.imf_productos_prod.Where(p => p.prodStatus.Value == true).ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public ProductoResponse GetProductoById(int id)
        {
            var response = new ProductoResponse();
            try
            {
                response.Producto = db.imf_productos_prod.Find(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public ProductosResponse GetProductosByFiltro(string noParte, string descripcion)
        {
            var response = new ProductosResponse();

            try
            {
                // VIENEN LOS DOS CAMPOS
                if (!noParte.IsNullOrWhiteSpace() && !descripcion.IsNullOrWhiteSpace())
                {
                    response.Productos =
                        db.imf_productos_prod.Where(
                                p => p.prodNumeroParte.Contains(noParte) && p.prodDescripcionRSI.Contains(descripcion))
                            .ToList();
                    response.Success = true;
                }// SOLO VIENE NUMERO PARTE
                else if (!noParte.IsNullOrWhiteSpace() && descripcion.IsNullOrWhiteSpace())
                {
                    response.Productos = db.imf_productos_prod.Where(p => p.prodNumeroParte.Contains(noParte)).ToList();
                    response.Success = true;
                } // SOLO VIENE DESCRIPCION
                else if (noParte.IsNullOrWhiteSpace() && !descripcion.IsNullOrWhiteSpace())
                {
                    response.Productos =
                        db.imf_productos_prod.Where(p => p.prodDescripcionRSI.Contains(descripcion)).ToList();
                    response.Success = true;
                } // SI NO VIENE NINGUNO MANDA TODOS ALV
                else
                {
                    response.Productos = db.imf_productos_prod.ToList();
                    response.Success = true;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public ProductoResponse InsertProducto(imf_productos_prod producto)
        {
            var response = new ProductoResponse();

            try
            {
                var prod = db.imf_productos_prod.Add(producto);
                db.SaveChanges();

                response.Producto = prod;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public ResponseBase DeleteProduct(imf_productos_prod producto)
        {
            var response = new ResponseBase();
            try
            {
                db.imf_productos_prod.Remove(producto);
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

        public ProductoResponse UpdateProducto(imf_productos_prod producto)
        {
            var response = new ProductoResponse();

            try
            {
                var prod = GetProductoById(producto.prodIdProducto);
                if (prod.Producto != null)
                {
                    db.Entry(prod.Producto).CurrentValues.SetValues(producto);
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