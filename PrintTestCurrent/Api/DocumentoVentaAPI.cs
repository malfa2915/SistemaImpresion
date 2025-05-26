using Helios.Cont.Business.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


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
        try
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(helpers.Url + "api/Sale/print-pending-order", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<documentoventaAbarrotes>>(jsonResult);
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


