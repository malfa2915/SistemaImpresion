using Helios.Cont.Business.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DeskTest.Api
{
    class DocumentoVentaDetAPI
    {

        public static async Task<List<documentoventaAbarrotesDet>> updateEstadoImpresion(List<documentoventaAbarrotesDet> item)
        {
            try
            {
                var httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(helpers.url + "api/SaleDetail/updateEstadoImpresion", content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<documentoventaAbarrotesDet>>(jsonResult);
                    return result;
                }

                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }

    }
}
