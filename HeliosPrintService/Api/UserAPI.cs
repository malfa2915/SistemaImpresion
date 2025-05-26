using Helios.Cont.Business.Entity;
using Helios.Seguridad.Business.Entity;
using HeliosPrintService.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


public static class UserAPI
{
    public static async Task<AutenticacionUsuario> Auth(AutenticacionUsuario autenticacionUsuario)
    {

        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(autenticacionUsuario);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.Url + "api/UserAccount/auth", content);
        //if (!response.IsSuccessStatusCode) 

        var jsonResult = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<AutenticacionUsuario>(jsonResult);
        autenticacionUsuario = result;
        return autenticacionUsuario;
        //var jsonResult = await response.Content.ReadAsStringAsync();

    }


    public static async Task<Usuario> SearchUserCode(Usuario item)
    {
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(item);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.Url + "api/User/SearchUserCode", content);
        if (response.IsSuccessStatusCode)
        {
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Usuario>(jsonResult);
            return result;
        }
        return null;
    }


    public static async Task<Usuario> GetId(Usuario item)
    {
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(item);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.Url + "api/User/id", content);
        if (response.IsSuccessStatusCode)
        {
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Usuario>(jsonResult);
            return result;
        }
        return null;
    }

    public static async Task<bool> ModifyUser(Usuario item)
    {
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(item);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.Url + "api/User/modify-user", content);
        if (response.IsSuccessStatusCode)
        {
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(jsonResult);
            return result;
        }
        return false;
    }

    public static async Task<int> SaveUserAuth(AutenticacionUsuario autenticacionUsuario)
    {

        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(autenticacionUsuario);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.Url + "api/UserAccount/saveuser-auth", content);
        if (response.IsSuccessStatusCode)
        {
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<int>(jsonResult);
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
            throw null;// new HttpResponseException(responseError);
        }




        //if (response.IsSuccessStatusCode)
        //{
        //    var jsonResult = await response.Content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<int>(jsonResult);
        //    return result;
        //}
        //return 0;

        //var jsonResult = await response.Content.ReadAsStringAsync();

    }

    public static async Task<int> SaveUserLabor(AutenticacionUsuario autenticacionUsuario)
    {

        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(autenticacionUsuario);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.Url + "api/UserAccount/save-user-labor", content);
        if (response.IsSuccessStatusCode)
        {
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<int>(jsonResult);
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
            throw null;//throw new HttpResponseException(responseError);
        }


        //if (response.IsSuccessStatusCode)
        //{
        //    var jsonResult = await response.Content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<int>(jsonResult);
        //    return result;
        //}
        //return 0;

        //var jsonResult = await response.Content.ReadAsStringAsync();

    }



    public static async Task<List<Usuario>> GetUsersSecurityAll()
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetStringAsync(helpers.Url + "api/User/all");
        return JsonConvert.DeserializeObject<List<Usuario>>(response);
    }


    public static async Task<List<Usuario>> GetUsersSecurityAll2()
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetStringAsync(helpers.Url + "api/User/all2");
        return JsonConvert.DeserializeObject<List<Usuario>>(response);
    }

    public static async Task<List<Usuario>> GetUserSelFilter(string filter)
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetStringAsync(helpers.Url + "api/User/filter-text?filter=" + filter);
        return JsonConvert.DeserializeObject<List<Usuario>>(response);
    }

    public static async Task<bool> EditProperties(Usuario item)
    {
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(item);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.Url + "api/User/edit-fileds", content);
        if (response.IsSuccessStatusCode)
        {
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(jsonResult);
            return result;
        }
        return false;
    }

    public static async Task<AutenticacionUsuario> ChangePassword(AutenticacionUsuario autenticacionUsuario)
    {

        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(autenticacionUsuario);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(helpers.Url + "api/UserAccount/change-pass", content);

        if (!response.IsSuccessStatusCode) return null;

        var jsonResult = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<AutenticacionUsuario>(jsonResult);
        return result;

    }
}