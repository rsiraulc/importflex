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

        public UMFsResponse GetUMFEnUso()
        {
            var response = new UMFsResponse();

            try
            {
                response.lstUMF = db.imf_unidadmedidafactura_umf.Where(u => u.umfEnUso.Value).ToList();
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

        #region Traducciones
        public List<string> GetListaTraducciones()
        {
            return new List<string>
            {
                "- CINTA DE IMPRESION TERMICA PARA ETIQUETAS POR PIEZA ROLLO",
                "- CINTA DE IMPRESION TERMICA PARA CREDENCIALES POR PIEZA",
                "- ETIQUETAS DE PAPEL CON ADHESIVO NO IMPRESAS EN PAQUETE",
                "- ETIQUETAS DE PAPEL CON ADHESIVO IMPRESAS EN PAQUETE",
                "- ETIQUETA DE PAPEL CON ADHESIVO SIN IMPRESION POR ROLLO",
                "- ETIQUETA DE PAPEL CON ADHESIVO CON IMPRESION POR ROLLO",
                "- ETIQUETA DE CARTONCILLO SIN IMPRIMIR EN ROLLO",
                "- ETIQUETAS DE PLASTICO CON ADHESIVO NO IMPRESA EN ROLLO",
                "- ETIQUETA DE PAPEL CON ADHESIVO SIN IMPRESION POR CAJA",
                "- ETIQUETA DE PAPEL CON ADHESIVO SIN IMPRESION POR MILLAR",
                "- ROLLO DE PAPEL AUTOADHESIVO CONTINUO PARA HACER ETIQUETAS",
                "- TROQUEL FLEXIBLE DE METAL PARA MAQUINA TROQUELADORA DE ETIQUETAS DE PAPEL",
                "- NUCLEO DE CARTON",
                "- CABEZA DE IMPRESION TERMICA CON ACCESORIOS PARA IMPRESORA DE ETIQUETAS",
                "- RODILLO CON ACCESORIOS, REFACCION PARA IMPRESORA DE ETIQUETA",
                "- REFACCION, BANDA DE TRANSMISION PARA IMPRESORA DE ETIQUETAS",
                "- JUEGO DE PALANCA BAR PARA IMPRESORA TERMICA",
                "- JUEGO DE REFACCIONES PARA PANTALLA DE IMPRESORA PARA ETIQUETAS",
                "- REFACCION PARA IMPRESORA DE ETIQUETAS - PARTIDA1",
                "- REBOBINADOR, REFACCION PARA IMPRESORA DE ETIQUETAS",
                "- JUEGO DE EJE, REFACCION PARA IMPRESORA DE ETIQUETAS",
                "- SENSOR CON ACCESORIOS, REFACCION PARA IMPRESORA DE ETIQUETAS",
                "- SENSOR DE CINTA, REFACCION PARA IMPRESORA DE ETIQUETAS",
                "- JUEGO REBOBINADOR CON ACCESORIOS, REFACCION PARA IMPRESORA DE ETIQUETAS",
                "- Rondanas de plástico para rodillo / ",
                "- Cuchillas cortantes /Hojas cortantes para impresora de etiquetas/ ",
                "- ACEITE DE SILICON SINTETICO",
                "- BANDA DE PLASTICO, REFACCION PARA IMPRESORA DE ETIQUETAS",
                "- ATENUADOR DE INTENSIDAD PARA LAMPARA INFERIOR A 3 KW",
                "- CONTROLADOR DE VELOCIDAD PARA MOTOR ELECTRICO",
                "- BANDA DE HULE DENTADA CPM REFUERZO TEXTIL, REFACCION PARA IMPRESORA DE ETIQUETAS",
                "- JUEGO DE ENGRANAJE CON ACCESORIOS, REFACCION PARA IMPRESORA DE ETIQUETAS",
                "- TARJETA DE CIRCUITO MODULAR PARA IMPRESORA DE ETIQUETAS",
                "- JUEGO DE BANDAS DE PLASTICO CON REFUERZO TEXTIL, CON ACCESORIOS",
                "- JUEGO DE RODILLOS PARA REBOBINADO DE ETIQUETAS,",
                "- MOTOR ELECTRICO DE POTENCIA INFERIOR A 37.5 W DE CORRIENTE CONTINUA",
                "- SEGURO ALDABA PARA GABINETE DE IMPRESORA DE ETIQUETA",
                "- PAQUETE DE TARJETAS PVC BLANCAS PARA CREDENCIAL CON 500 UNIDADES CAJA",
                "- CORREA RESISTENTE CON CLIPS METALICO, ACCESORIO PARA IMPRESORA DE ETIQUETAS",
                "- TARJETAS PARA LIMPIEZA DE IMPRESORAS CAJA",
                "- ETIQUETAS DE ACTIVACION POR PROXIMIDAD",
                "- FUNDA PROTECTORA DE PLASTICO PARA LECTOR MOVIL",
                "- CARTUCHO DE TINTA PARA IMPRESORA DE ETIQUETAS",
                "- PROGRAMA PARA COMPUTADORA EN DISCO COMPACTO",
                "- PULSERAS O BANDAS DE IDENTIFICACION ( INCLUYE : CARTUCHO CON PULSERAS Y SEGUROS DE PLASTICO ) EN CAJAS",
                "- SEGURO DE PLASTICO PARA PULSERA EN PAQUETE, PARTIDA1",
                "- COTONETES PARA LIMPIEZA DE IMRPESORAS",
                "- IMPRESORA DE TRANSFERENCIA TERMICA PARA ETIQUETAS CON ACCESORIOS",
                "- REBOBINADOR ELECTRICO PARA ETIQUETAS",
                "- IMPRESORA DE TRANSFERENCIA DIRECTA PARA ETIQUETAS",
                "- COMPUTADORA PORTATIL CON LECTOR OPTICO, INCLUYE ACCESORIOS",
                "- BATERIA RECARABLE DE LITIO",
                "- BASE DE CARGA PARA LECTOR OPTICO CON ACCESORIOS",
                "- LECTOR OPTICO DE CODIGO DE BARRAS CON ACCESORIOS",
                "- IMPRESORA TERMICA PARA CREDENCIALES CON ACCESORIOS",
                "- FUENTE DE PODER",
                "- LECTOR OPTICO CON BASE Y ACCESORIOS",
                "- DISPENSADORA ELECTRICA PARA ETIQUETAS CON ACCESORIOS",
                "- ANTENA EXTERNA INALAMBRICA CON ACCESORIOS"
            };
        }
        #endregion
    }
}