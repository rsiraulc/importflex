using System;
using System.Linq;
using ImportFlex.Messages;
using ImportFlex.Models;

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