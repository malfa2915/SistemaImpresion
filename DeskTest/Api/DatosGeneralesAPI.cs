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
    class DatosGeneralesAPI
    {
        public static async Task<List<datosGenerales>> GetFormats(string empresa, int unidad)
        {
            var httpClient = new HttpClient();
            var response = await httpClient
                .GetAsync(string.Format(helpers.url + "api/GeneralData?company={0}&idStore={1}",
                                            empresa, unidad));
            //if (!response.IsSuccessStatusCode) 

            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<datosGenerales>>(jsonResult);
            return result;
        }
    }
}
