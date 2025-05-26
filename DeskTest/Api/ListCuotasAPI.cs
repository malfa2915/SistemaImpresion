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
    class ListCuotasAPI
    {
        public static async Task<List<Cronograma>> GetListarCuotasDocumento(int id)
        {
            var httpClient = new HttpClient();
            var response = await httpClient
                .GetAsync(string.Format(helpers.url + "api/Schedule?id={0}",
                                            id));
            //if (!response.IsSuccessStatusCode) 

            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Cronograma>>(jsonResult);
            return result;
        }
    }
}
