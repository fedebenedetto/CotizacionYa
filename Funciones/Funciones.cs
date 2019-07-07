using RestSharp;
using System.Configuration;

namespace Funciones
{
    public static class Funciones
    {
        /// <summary>
        /// retorna la url de conexion
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string GetUrl(string source)
        {
            try
            {
                string url = ConfigurationManager.AppSettings["ApiUrl"];
                string target = ConfigurationManager.AppSettings["Target"];
                string formatResponeAndQuantity = ConfigurationManager.AppSettings["FormatResponeAndQuantity"];
                string key = ConfigurationManager.AppSettings["Key"];

                string urlFinal = url + "/" + source + "/" + target + "/" + formatResponeAndQuantity + "&" + key;
                return urlFinal;
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// retorna response para ser utilizado en model
        /// </summary>
        /// <param name="restClient"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IRestResponse RestResponse(RestClient restClient, string source)
        {
            try
            {

                var request = new RestRequest(Method.GET);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Connection", "keep-alive");
                request.AddHeader("accept-encoding", "gzip, deflate");
                request.AddHeader("cookie", "__cfduid=d1d7b2674be842ba6d04171efccaec1291562109515");
                request.AddHeader("Host", "api.cambio.today");
                request.AddHeader("Postman-Token", "f3d2517c-e0dc-419c-8127-664d956cce38,57e10075-2787-4c4e-82b9-ec8b3acd950d");
                request.AddHeader("Cache-Control", "no-cache");
                request.AddHeader("Accept", "*/*");
                request.AddHeader("User-Agent", "PostmanRuntime/7.15.0");
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                IRestResponse response = restClient.Execute(request);
                return response;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
