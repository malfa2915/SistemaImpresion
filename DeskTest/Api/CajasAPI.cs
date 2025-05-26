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
     class CajasAPI
    {
        public static async Task<List<cajaUsuario>> GetUsers(string empresa, int unidad)
        {


            var httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
            var response = await httpClient.GetStringAsync(helpers.url + "api/UserBox?empresa=" + empresa + "&unidad=" + unidad);
            return JsonConvert.DeserializeObject<List<cajaUsuario>>(response);

        }

        public static async Task<List<documentoCaja>> GetKardexReport(documentoCaja item)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(helpers.url + "api/DocumentFinance/GetKardexReport", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<documentoCaja>>(jsonResult);
                return result;
            }

            return null;
        }

        public static async Task<cajaUsuario> ReportCierre(cajaUsuario item)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(helpers.url + "api/UserBox/ReportCierre", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<cajaUsuario>(jsonResult);
                return result;
            }

            return null;
        }
    }
}
