using Helios.Cont.Business.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;



public class ImpresorasNegocioAPI
{

    public static async Task<List<ImpresorasNegocio>> GetListaImpresoraALL(ImpresorasNegocio print)
    {
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(print);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.url + "api/ImpresoraNegocio/GetImpresoraAll", content);
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

            return null;// throw new HttpResponseException(responseError);
        }
    }

    public static async Task<List<ImpresorasNegocio>> GetListaImpresoraPreCuenta(ImpresorasNegocio print)
    {
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(print);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.url + "api/ImpresoraNegocio/GetListaImpresoraPreCuenta", content);
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

            return null;// throw new HttpResponseException(responseError);
        }
    }

    public static async Task<List<ImpresorasNegocio>> GetListaImpresoraNegocioXEstablec(ImpresorasNegocio print)
    {
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(print);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.url + "api/ImpresoraNegocio/GetListaImpresoraNegocioXEstablec", content);
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

            return null;// throw new HttpResponseException(responseError);
        }
    }

    public static async Task<ImpresorasNegocio> SaveImpresoraNegocio(ImpresorasNegocio print)
    {
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(print);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.url + "api/ImpresoraNegocio/SaveImpresoraNegocio", content);
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
            return null;// throw new HttpResponseException(responseError);
        }
    }

    public static async Task<ImpresorasNegocio> GetEliminarPreCuenta(ImpresorasNegocio print)
    {
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(print);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.url + "api/ImpresoraNegocio/GetEliminarPreCuenta", content);
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
            return null;//throw new HttpResponseException(responseError);
        }
    }

    public static async Task<datosGenerales> SaveImpresoraFormato(datosGenerales print)
    {
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(print);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.url + "api/ImpresoraNegocio/SaveImpresoraFormato", content);
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
            return null;// throw new HttpResponseException(responseError);
        }
    }

    public static async Task<datosGenerales> GetEliminarFormatoPrint(datosGenerales print)
    {
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(print);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.url + "api/ImpresoraNegocio/GetEliminarFormatoPrint", content);
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
            return null;// throw new HttpResponseException(responseError);
        }
    }

    public static async Task<datosGenerales> FormatosImpresionEdit(datosGenerales print)
    {
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(print);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.url + "api/ImpresoraNegocio/ProductComposicionEdit", content);
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

            return null;//throw new HttpResponseException(responseError);
        }
    }


    public static async Task<datosGenerales> EditImpresoraFormato(datosGenerales print)
    {
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(print);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.url + "api/ImpresoraNegocio/EditImpresoraFormato", content);
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
            return null;// throw new HttpResponseException(responseError);
        }
    }

    public static async Task<List<detalleItemsImpresoras>> getListImpresorasXCodigoDetalle(List<int> print)
    {
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(print);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.url + "api/ImpresoraNegocio/getListImpresorasXCodigoDetalle", content);
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

            return null;// throw new HttpResponseException(responseError);
        }
    }


    public static async Task<List<detalleItemsImpresoras>> getListImpresorasXIdImpresora(List<int> print)
    {
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(print);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.url + "api/ImpresoraNegocio/getListImpresorasXIdImpresora", content);
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

            return null;// throw new HttpResponseException(responseError);
        }
    }

    public static async Task<ImpresorasNegocio> GetINServicio(Boolean print,string empresa, int IdCentro)
    {
        var httpClient = new HttpClient();
        //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
        var response = await httpClient.GetStringAsync(helpers.url + "api/ImpresoraNegocio/GetINServicio?print=" + print  + "&empresa=" + empresa + "&IdCentro=" + IdCentro);
        return JsonConvert.DeserializeObject<ImpresorasNegocio>(response);
    }


    public static async Task<List<detalleItemsImpresoras>> GetDetalleImpresoras()
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetStringAsync(helpers.url + "api/ImpresoraNegocio/GetDetalleImpresoras");
        return JsonConvert.DeserializeObject<List<detalleItemsImpresoras>>(response);
    }
}

