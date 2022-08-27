// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Net;
using System.IO;   
using System.Text.Json;

namespace Problema4
{
    class Program
    {
        public static void Main(string[] args)
        {
            var ListaDeProvincias = ObtenerProvincias();

            try
            {
                foreach (var Provincia in ListaDeProvincias)
                {
                    Console.WriteLine(Provincia.nombre + " ID:" + Provincia.id);
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Error de referencia a nulo");
            }

        }
        private static List<Provincia> ObtenerProvincias()
        {
            var url = $"https://apis.datos.gob.ar/georef/api/provincias?campos=id,nombre";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using(WebResponse response = request.GetResponse()){
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            Root Root = JsonSerializer.Deserialize<Root>(responseBody);
                            return Root.provincias;
                        }
                    }
                }
            }
            catch (WebException)
            {
                Console.WriteLine("El servidor al cual se intento acceder retorno error");
                return null;
            }
        }
    }
    
}