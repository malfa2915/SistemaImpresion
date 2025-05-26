using Helios.Cont.Business.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;


public class ImpresorasNegocioAPI
{

    public static async Task<List<ImpresorasNegocio>> GetListaImpresoraALL(ImpresorasNegocio print)
    {
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(print);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.Url + "api/ImpresoraNegocio/GetImpresoraAll", content);
        if (response.IsSuccessStatusCode)
        {
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ImpresorasNegocio>>(jsonResult);
            return result;
        }
        else
        {
            var responseError = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(string.Format("Verificar los campos")),
                ReasonPhrase = "Verificar los compos"
            };

            throw new HttpResponseException(responseError);
        }
    }

    public static async Task<List<ImpresorasNegocio>> GetListaImpresoraNegocioXEstablec(ImpresorasNegocio print)
    {
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(print);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.Url + "api/ImpresoraNegocio/GetListaImpresoraNegocioXEstablec", content);
        if (response.IsSuccessStatusCode)
        {
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ImpresorasNegocio>>(jsonResult);
            return result;
        }
        else
        {
            var responseError = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(string.Format("Verificar los campos")),
                ReasonPhrase = "Verificar los compos"
            };

            throw new HttpResponseException(responseError);
        }
    }

    public static async Task<ImpresorasNegocio> SaveImpresoraNegocio(ImpresorasNegocio print)
    {
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(print);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.Url + "api/ImpresoraNegocio/SaveImpresoraNegocio", content);
        if (response.IsSuccessStatusCode)
        {
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ImpresorasNegocio>(jsonResult);
            return result;
        }
        else
        {
            var responseError = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(string.Format("Verificar")),
                ReasonPhrase = "Verificar"
            };
            throw new HttpResponseException(responseError);
        }
    }

    public static async Task<ImpresorasNegocio> GetEliminarPreCuenta(ImpresorasNegocio print)
    {
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(print);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.Url + "api/ImpresoraNegocio/GetEliminarPreCuenta", content);
        if (response.IsSuccessStatusCode)
        {
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ImpresorasNegocio>(jsonResult);
            return result;
        }
        else
        {
            var responseError = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(string.Format("Verificar")),
                ReasonPhrase = "Verificar"
            };
            throw new HttpResponseException(responseError);
        }
    }

    public static async Task<datosGenerales> SaveImpresoraFormato(datosGenerales print)
    {
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(print);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.Url + "api/ImpresoraNegocio/SaveImpresoraFormato", content);
        if (response.IsSuccessStatusCode)
        {
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<datosGenerales>(jsonResult);
            return result;
        }
        else
        {
            var responseError = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(string.Format("Verificar")),
                ReasonPhrase = "Verificar"
            };
            throw new HttpResponseException(responseError);
        }
    }

    public static async Task<datosGenerales> GetEliminarFormatoPrint(datosGenerales print)
    {
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(print);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.Url + "api/ImpresoraNegocio/GetEliminarFormatoPrint", content);
        if (response.IsSuccessStatusCode)
        {
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<datosGenerales>(jsonResult);
            return result;
        }
        else
        {
            var responseError = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(string.Format("Verificar")),
                ReasonPhrase = "Verificar"
            };
            throw new HttpResponseException(responseError);
        }
    }

    public static async Task<datosGenerales> FormatosImpresionEdit(datosGenerales print)
    {
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(print);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.Url + "api/ImpresoraNegocio/ProductComposicionEdit", content);
        if (response.IsSuccessStatusCode)
        {
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<datosGenerales>(jsonResult);
            return result;
        }
        else
        {
            var responseError = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(string.Format("Verificar los campos")),
                ReasonPhrase = "Verificar los compos"
            };

            throw new HttpResponseException(responseError);
        }
    }


    public static async Task<datosGenerales> EditImpresoraFormato(datosGenerales print)
    {
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(print);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.Url + "api/ImpresoraNegocio/EditImpresoraFormato", content);
        if (response.IsSuccessStatusCode)
        {
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<datosGenerales>(jsonResult);
            return result;
        }
        else
        {
            var responseError = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(string.Format("Verificar")),
                ReasonPhrase = "Verificar"
            };
            throw new HttpResponseException(responseError);
        }
    }

    public static async Task<List<detalleItemsImpresoras>> getListImpresorasXCodigoDetalle(List<int> print)
    {
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(print);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.Url + "api/ImpresoraNegocio/getListImpresorasXCodigoDetalle", content);
        if (response.IsSuccessStatusCode)
        {
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<detalleItemsImpresoras>>(jsonResult);
            return result;
        }
        else
        {
            var responseError = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(string.Format("Verificar los campos")),
                ReasonPhrase = "Verificar los compos"
            };

            throw new HttpResponseException(responseError);
        }
    }


}

