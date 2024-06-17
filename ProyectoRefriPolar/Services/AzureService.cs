using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRefriPolar.Services
{
    class AzureService
    {
        public string url(string ruta)
        {
            string cadenaConexion = "DefaultEndpointsProtocol=https;AccountName=colmor;AccountKey=v/17+tVL8TZtvRbSY9E85a3B2Sw0H2oPNyMtwXXkXy9IlU4Mhzd6bnDMiHsOpBYLr200HaQ5Je6a+AStoQextQ==;EndpointSuffix=core.windows.net";
            string nombreContenedorBlobs = "2dam";

            var clienteBlobService = new BlobServiceClient(cadenaConexion);
            var clienteContenedor = clienteBlobService.GetBlobContainerClient(nombreContenedorBlobs);


            var clienteBlobImagen = clienteContenedor.GetBlobClient(ruta);
            string urlImagen = clienteBlobImagen.Uri.AbsoluteUri;
            return urlImagen;
        }
        public string guarda(string url)
        {
            string cadenaConexion = "DefaultEndpointsProtocol=https;AccountName=colmor;AccountKey=v/17+tVL8TZtvRbSY9E85a3B2Sw0H2oPNyMtwXXkXy9IlU4Mhzd6bnDMiHsOpBYLr200HaQ5Je6a+AStoQextQ==;EndpointSuffix=core.windows.net";
            string nombreContenedorBlobs = "2dam";
            string rutaImagen = url;

            var clienteBlobService = new BlobServiceClient(cadenaConexion);
            var clienteContenedor = clienteBlobService.GetBlobContainerClient(nombreContenedorBlobs);
            string urlImagen;
            if (!rutaImagen.StartsWith("https://colmor.blob.core.windows.net"))
            {
                Stream streamImagen = File.OpenRead(rutaImagen);
                string nombreImagen = Path.GetFileName(rutaImagen);

                var clienteBlobImagen = clienteContenedor.GetBlobClient(nombreImagen);

                if (!clienteBlobImagen.Exists())
                {
                    clienteContenedor.UploadBlob(nombreImagen, streamImagen);
                }

                urlImagen = clienteBlobImagen.Uri.AbsoluteUri;
            } else
            {
                urlImagen = rutaImagen;
            }
            
            return urlImagen;

        }
    }
}
