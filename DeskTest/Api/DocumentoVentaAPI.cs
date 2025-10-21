using Helios.Cont.Business.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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


    public static async Task<bool> ConfirmPrintOrder(documentoventaAbarrotes item)
    {
        try
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(helpers.url + "api/Sale/edit-print-order", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<bool>(jsonResult);
                return result;
            }

            return false;
        }
        catch (Exception ex)
        {

            throw ex;
        }



    }

    public static async Task<bool> ConfirmPrintOrderDet(documentoventaAbarrotes item)
    {
        try
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(helpers.url + "api/Sale/edit-print-order-det", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<bool>(jsonResult);
                return result;
            }

            return false;
        }
        catch (Exception ex)
        {

            throw ex;
        }



    }

    public static async Task<bool> AnulacionPrintOrderDetItem(documentoventaAbarrotes item)
    {
        try
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(helpers.url + "api/Sale/Anu-print-order-det", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<bool>(jsonResult);
                return result;
            }

            return false;
        }
        catch (Exception ex)
        {

            throw ex;
        }



    }

    public static async Task<documentoventaAbarrotes> GetOrderIdLite(int id)
    {
        var httpClient = new HttpClient();
        //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
        var response = await httpClient.GetStringAsync(helpers.url + "api/Sale/GetOrderIdLite?id=" + id);
        return JsonConvert.DeserializeObject<documentoventaAbarrotes>(response);
    }

    public static async Task<List<documentoventaAbarrotes>> GetPreOrdersPendingPrint(documentoventaAbarrotes item)
    {
        try
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(helpers.url + "api/Sale/print-pending-order", content);
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


    public static async Task<documentoventaAbarrotes> GetOrderIdLitePrint(int id,string empresa, int IdCentro)
    {
        var httpClient = new HttpClient();
        //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
        var response = await httpClient.GetStringAsync(helpers.url + "api/Sale/GetOrderIdLitePrint?id=" + id + "&empresa=" + empresa + "&IdCentro=" + IdCentro);
        return JsonConvert.DeserializeObject<documentoventaAbarrotes>(response);
    }

    public static async Task<rePrintResponse> GetVentaPedidos(int id, string empresa, int IdCentro)
    {
        var httpClient = new HttpClient();
        //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
        var response = await httpClient.GetStringAsync(helpers.url + "api/Sale/GetVentaPedidos?id=" + id + "&empresa=" + empresa + "&IdCentro=" + IdCentro);
        return JsonConvert.DeserializeObject<rePrintResponse>(response);
    }
    public static async Task<documentoventaAbarrotes> GetVentaIDVoucher(int id, string empresa, int IdCentro)
    {
        var httpClient = new HttpClient();
        //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
        var response = await httpClient.GetStringAsync(helpers.url + "api/Sale/GetVentaIDVoucher?id=" + id + "&empresa=" + empresa + "&IdCentro=" + IdCentro);
        return JsonConvert.DeserializeObject<documentoventaAbarrotes>(response);
    }

    public static async Task<documentoventaAbarrotes> GetVentaIDLite(int id)
    {
        var httpClient = new HttpClient();
        //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
        var response = await httpClient.GetStringAsync(helpers.url + "api/Sale/GetOrderIdLite?id=" + id);
        return JsonConvert.DeserializeObject<documentoventaAbarrotes>(response);
    }
    public static async Task<documentoventaAbarrotes> NotaCreditoDetVenta(int id)
    {
        var httpClient = new HttpClient();
        //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
        var response = await httpClient.GetStringAsync(helpers.url + "api/Sale/NotaCreditoDetVenta?id=" + id);
        return JsonConvert.DeserializeObject<documentoventaAbarrotes>(response);
    }

    public static async Task<documentoventaAbarrotes> GetUbicar_NotaXID(int id)
    {
        var httpClient = new HttpClient();
        //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
        var response = await httpClient.GetStringAsync(helpers.url + "api/Sale/find-credit-note-id?id=" + id);
        return JsonConvert.DeserializeObject<documentoventaAbarrotes>(response);
    }
    public static async Task<List<documentoCajaDetalle>> GetDocumentoCajaDetalle(int id)
    {
        var httpClient = new HttpClient();
        //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
        var response = await httpClient.GetStringAsync(helpers.url + "api/Sale/GetDocumentoCajaDetalle?id=" + id);
        return JsonConvert.DeserializeObject<List<documentoCajaDetalle>>(response);
    }

    public static async Task<rePrintResponse> directPrinting(int id, string terminos, int Idestablecimiento, string empresa)
    {
        var httpClient = new HttpClient();
        //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
        var response = await httpClient.GetStringAsync(helpers.url + "api/Sale/Reprint?id=" + id + "&terminos="+ terminos + "&idEstablecimiento="+ Idestablecimiento + "&IdEmpresa=" + empresa);
        return JsonConvert.DeserializeObject<rePrintResponse>(response);
    }

    public static async Task<List<documentoventaAbarrotes>> PrintDocumentos(documentoventaAbarrotes items)
    {
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(items);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.url + "api/Sale/PrintDocumentos", content);
        if (response.IsSuccessStatusCode)
        {
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<documentoventaAbarrotes>>(jsonResult);
            return result;
        }
        else
        {
            var responseError = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(string.Format("Verificar los campos")),
                ReasonPhrase = "Verificar los compos"
            };

            return null;
        }
    }

    public static async Task<List<documentoventaAbarrotes>> PrintDocumentosXCategoria(documentoventaAbarrotes items)
    {
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(items);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.url + "api/Sale/PrintDocumentosXCategoria", content);
        if (response.IsSuccessStatusCode)
        {
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<documentoventaAbarrotes>>(jsonResult);
            return result;
        }
        else
        {
            var responseError = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(string.Format("Verificar los campos")),
                ReasonPhrase = "Verificar los compos"
            };

            return null;
        }
    }


    public static async Task<List<documentoventaAbarrotes>> PrintPromedioXmesa(documentoventaAbarrotes items)
    {
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(items);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.url + "api/Sale/SearchProdInfraestrurexMesa", content);
        if (response.IsSuccessStatusCode)
        {
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<documentoventaAbarrotes>>(jsonResult);
            return result;
        }
        else
        {
            var responseError = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(string.Format("Verificar los campos")),
                ReasonPhrase = "Verificar los compos"
            };

            return null;
        }
    }

}


