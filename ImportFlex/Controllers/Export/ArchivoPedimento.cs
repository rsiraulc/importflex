﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using ImportFlex.Messages;
using ImportFlex.Models;
using Ionic.Zip;

namespace ImportFlex.Controllers.Export
{
    public class ArchivoPedimento : System.Web.UI.Page
    {
        public List<string> lstArchivos = new List<string>();

        public ArchivoResponse CrearArchivo(imf_importaciones_imp p) // p = pedimento, duh
        {
            var response = new ArchivoResponse();
            var catalogosController = new CatalogosController();
            var dir = Server.MapPath("~/Controllers/Archivos/");

            try
            {
                foreach (var f in p.imf_facturas_fac) //f = facturas, duh x 2
                {
                    var dia = f.facFechaFactura.Value.Day < 10
                        ? $"0{f.facFechaFactura.Value.Day}"
                        : f.facFechaFactura.Value.Day.ToString();
                    var fechaFactura = $"{f.facFechaFactura.Value.Year}{f.facFechaFactura.Value.Month}{dia}";
                    var pedimento = p.impTieneNumeroImportacion == true ? p.impNumeroPedimento : "";
                    var terminoFacturacion = f.imf_proveedores_prv.prvIncoterm ?? "";

                    var lst559 = new List<imf_facturadetalle_fde>();
                    var lst551 = new List<imf_facturadetalle_fde>();

                    // ENCABEZADO - DATOS DE PEDIMENTO
                    string texto = $"{p.impTipoRegistro}|{p.impTipoOperacion}|C1|{pedimento}|{p.impCodigoImportador}|0|0|0|0|0|0|0|7|7|7|{p.impRegion}|\r\n";

                    // DATOS DE FACTURA
                    texto += $"505|{f.facNumeroFactura}|{fechaFactura}|{terminoFacturacion}|USD|{f.facValorExtranjera}|{f.facValorUsd}|{f.imf_proveedores_prv.prvCodigo}||||||||||||||||||||||||||||||||||||\r\n";


                    // DETALLE DE FACTURA (551)
                    foreach (var df in f.imf_facturadetalle_fde)
                    {
                        var cantidadTarifa = df.imf_unidadmedidacomercial_umc.umcIdClave == 6 ? df.fdeCantidadUMC : 0;
                        var UMT = df.imf_unidadmedidacomercial_umc.umcIdClave == 6? df.imf_unidadmedidacomercial_umc.umcIdClave:0;


                        if (lst551.Any(d => d.fdeIdProducto == df.fdeIdProducto))
                            lst559.Add(df);
                        else
                        {
                            var vinculacion = f.facVinculacion == true ? "1" : "0";
                            texto += $"551|{df.imf_productos_prod.prodFraccionArancelaria}|{df.imf_productos_prod.imf_traducciones_trad.tradTraduccion}|{df.imf_productos_prod.prodNumeroParte}|{df.fdeValor}|{df.fdeCantidadUMC}|{df.imf_unidadmedidacomercial_umc.umcIdClave}|{cantidadTarifa}||{vinculacion}|1|{df.imf_productos_prod.prodMarca}|{df.imf_productos_prod.prodModelo}|{df.imf_paises_pai.paiClavePais}|USA||{df.fdeCantidadUMF}|{df.imf_unidadmedidafactura_umf.umfClave}|||||||||||||||||||||{UMT}||||{f.facNumeroFactura}||\r\n";
                            lst551.Add(df);
                        }
                    }


                    // SE AGREGAN DESCRIPCIONES COVE (559)
                    foreach (var df in lst559)
                    {
                        texto += $"559|{df.imf_productos_prod.prodMarca}|{df.imf_productos_prod.prodModelo}|{df.imf_productos_prod.prodSubModelo}|{df.fdeNumeroSerieProducto}|\r\n";
                    }


                    // LINEA FINAL DE DOCUMENTO
                    texto += "999|\r\n";


                    // NOMBRE DEL ARCHIVO NO DEBE EXCEDER 8 DIGITOS
                    var file = Path.Combine(dir, $"{f.facNumeroFactura}.txt");
                    Directory.CreateDirectory(dir);
                    File.WriteAllText(file, texto);

                    //AGREGA ARCHIVO A LA LISTA
                    lstArchivos.Add(file);
                    lst551 = null;
                    lst559 = null;
                }

                // AGRUPAR ARCHIVOS EN ZIP

                response.RutaArchivo = ExportarZip(dir, p.impNumeroPedimento, p.impParte.Value);
                response.NombreArchivo = $"Pedimento_{p.impNumeroPedimento}_{p.impParte}.zip";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        private string ExportarZip(string dir, string numeroPedimento, int parte)
        {
            dir = Path.Combine(dir, $"Pedimento_{numeroPedimento}_{parte}.zip");

            using (ZipFile zip = new ZipFile())
            {
                foreach (var file in lstArchivos)
                {
                    zip.AddFile(file, $"FacturasPedimento_{numeroPedimento}_{parte}");
                }
                zip.Save(dir);

                // ELIMINAR ARCHIVOS TXT GENERADOS PARA EVITAR QUE HAYA MUCHOS
                EliminarArchivosTxt();

                return dir;
            }
        }

        private void EliminarArchivosTxt()
        {
            foreach (var file in lstArchivos)
            {
                File.Delete(file);
            }
        }

        public void EliminarArchivo(string path)
        {
            File.Delete(path);
        }
    }
}