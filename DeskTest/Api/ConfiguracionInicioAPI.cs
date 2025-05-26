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
    class ConfiguracionInicioAPI
    {

        public static async Task<configuracionInicio> Getconfiguration(string empresa, int IdCentro)
        {
            var httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
            var response = await httpClient.GetStringAsync(helpers.url + "api/Company/Getconfiguration?empresa=" + empresa + "&IdCentro="+ IdCentro);
            return JsonConvert.DeserializeObject<configuracionInicio>(response);
        }

    }
}
