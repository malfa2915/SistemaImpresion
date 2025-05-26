using Helios.Cont.Business.Entity;
using HeliosPrintService.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HeliosPrintService.Api
{
    public static class DocumentoVentaAPI
    {
        //public static async Task<List<documentoventaAbarrotes>> PendingPrints(int locationId)
        //{
        //    var httpClient = new HttpClient();
        //    var response = await httpClient
        //        .GetAsync(helpers.Url + $"CustomerAttendanceRecord/RegisterDay?locationId={locationId}&date={date.ToString("u")}");


        //    var jsonResult = await response.Content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<List<documentoventaAbarrotes>>(jsonResult);
        //    return result;
        //}


        public static async Task<List<documentoventaAbarrotes>> GetPreOrdersPendingPrint(documentoventaAbarrotes item)
        {
           // try
           // {
                var httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.PostAsync("https://localhost:44357/" + "api/Sale/print-pending-order", content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<documentoventaAbarrotes>>(jsonResult);
                    return result;
                }
                else
                {
                    var mensaje = response.ReasonPhrase;
                    var responseError = new HttpResponseMessage(HttpStatusCode.ExpectationFailed)
                    {
                        // Content = new StringContent(string.Format(mensaje)),
                        ReasonPhrase = mensaje
                    };
                    throw new HttpResponseException(responseError);
                }

               // return null;
           // }
            //catch (Exception ex)
            //{

            //    throw ex.Message;
            //}

        }
    }
}
