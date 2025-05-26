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
    class DocumentoCompraAPI
    {
        public static async Task<documentocompra> PrintCompra(int id)
        {
            var httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
            var response = await httpClient.GetStringAsync(helpers.url + "api/DocumentoCompra?id=" + id);
            return JsonConvert.DeserializeObject<documentocompra>(response);
        }
    }
}
