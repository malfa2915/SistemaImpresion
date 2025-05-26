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
    class EntidadAPI
    {
        public static async Task<List<entidad>> EntidadFilterText(string empresa, string tipo, string text)
        {
            var httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
            var response = await httpClient.GetStringAsync(helpers.url + "api/Customer/filter-text?empresa=" + empresa + "&tipo=" + tipo + "&text=" + text);
            return JsonConvert.DeserializeObject<List<entidad>>(response);
        }
    }
}
