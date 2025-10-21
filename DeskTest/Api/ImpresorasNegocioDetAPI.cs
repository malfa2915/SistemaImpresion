using Helios.Cont.Business.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


    public class ImpresorasNegocioDetAPI
    {
        public static async Task<List<ImpresorasNegocioDet>> getImpresoraNegocioDet(ImpresorasNegocio print)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(print);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(helpers.url + "api/ImpresorasNegocioDet/getImpresoraNegocioDet", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ImpresorasNegocioDet>>(jsonResult);
                return result;
            }
            else
            {
                var responseError = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Verificar los campos")),
                    ReasonPhrase = "Verificar los compos"
                };

                return null;// throw new HttpResponseException(responseError);
            }
        }

}

