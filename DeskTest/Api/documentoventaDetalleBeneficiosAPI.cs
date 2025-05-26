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
    class documentoventaDetalleBeneficiosAPI
    {
        public static async Task<printProductComercial> PrintDirectProducto(int idDoc)
        {
            var httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
            var response = await httpClient.GetStringAsync(helpers.url + "api/documentoventaDetalleBeneficios/PrintDirectProducto?IdDoc=" + idDoc);
            return JsonConvert.DeserializeObject<printProductComercial>(response);
        }
    }
}
