using Helios.Cont.Business.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DeskTest.Api
{
    public static class PrintQueueAPI
    {

        public static async Task<List<PrintQueue>> GetAll()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(helpers.url + "api/PrintQueue");
            return JsonConvert.DeserializeObject<List<PrintQueue>>(response);
        }

        public static async Task<List<PrintQueue>> GetAllV2()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(helpers.url + "api/PrintQueue/GetAllV2");
            return JsonConvert.DeserializeObject<List<PrintQueue>>(response);
        }
        public static async Task<List<PrintQueue>> GetAllVEstEmp(string empresa, int IdCentro)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(helpers.url + "api/PrintQueue/GetAllVEstEmp?empresa=" + empresa + "&idcentro=" + IdCentro);
            return JsonConvert.DeserializeObject<List<PrintQueue>>(response);
        }
        public static async Task<List<PrintQueue>> GetAllVEstEmpHostnameIP(string empresa, int IdCentro, string Hostname, string IP)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(helpers.url + "api/PrintQueue/GetAllVEstEmpHostnameIP?empresa=" + empresa + "&idcentro=" + IdCentro + "&Hostname=" + Hostname + "&IP=" + IP);
            return JsonConvert.DeserializeObject<List<PrintQueue>>(response);
        }
        public static async Task<bool> DeleteV2(int id, string empresa, int IdCentro)
        {

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(id);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(helpers.url + "api/PrintQueue/DeletePrintQueuev2?id=" + id + "&empresa=" + empresa + "&IdCentro=" + IdCentro, content);
            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<bool>(jsonResult);
                return result;
            }

            return false;



            //var httpClient = new HttpClient();
            ////httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
            //var response = await httpClient.GetStringAsync(helpers.Url + "api/PrintQueue/DeletePrintQueuev2?id=" + id);
            //return JsonConvert.DeserializeObject<bool>(response);
        }

        public static async Task<bool> Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(helpers.url);
                var response = await client.DeleteAsync("api/PrintQueue/" + id);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public static async Task<bool> Save(PrintQueue item)
        {

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(helpers.url + "api/PrintQueue", content);

            if (response.IsSuccessStatusCode)
            {
                //var jsonResult = await response.Content.ReadAsStringAsync();
                //var result = JsonConvert.DeserializeObject<bool>(jsonResult);
                return true;
            }
            else
            {
                var mensaje = response.ReasonPhrase;
                var responseError = new HttpResponseMessage(HttpStatusCode.ExpectationFailed)
                {
                    // Content = new StringContent(string.Format(mensaje)),
                    ReasonPhrase = mensaje
                };

                return false;
            }


            //var jsonResult = await response.Content.ReadAsStringAsync();

        }
    }
}
