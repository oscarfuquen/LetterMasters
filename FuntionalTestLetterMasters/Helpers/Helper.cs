using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FuntionalTestLetterMasters.Model;
using LetterMasters.Models;
using Newtonsoft.Json;

namespace FuntionalTestLetterMasters.Helpers
{
    public static class Helper
    {
        public static async Task<T> getRequest <T>(string UrlRequest, string token)
        {
            using (var httpClient = new HttpClient())
            {
                var settings = ConfigurationHelper.GetConfig();
                if (!string.IsNullOrEmpty(token))
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                }

                var responseAsync = await httpClient.GetAsync(new Uri($"{settings["BaseAPI"]}{UrlRequest}"));

                if (responseAsync.StatusCode == HttpStatusCode.Unauthorized){
                    return (T)Convert.ChangeType(401, typeof(T));
                }

                var response = await responseAsync.Content.ReadAsStringAsync();
                return (T)Convert.ChangeType(JsonConvert.DeserializeObject<Word>(response), typeof(T));
            }
        }

        public static string postRequest(string UrlRequest)
        {
            var userModel = new UserRegisterAuthenticate
            {
                user = "Test",
                password = "TestPassword"
            };
            var data = JsonConvert.SerializeObject(userModel);
            using (var httpClient = new HttpClient())
            {
                var settings = ConfigurationHelper.GetConfig();

                var response = Task.Run(() => httpClient.PostAsync(new Uri($"{settings["BaseAPI"]}{UrlRequest}"), new StringContent(data, Encoding.UTF8, "application/json"))).Result;
                var content = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
                var userAuthenticate = JsonConvert.DeserializeObject<UserAuthenticate>(content);
                return userAuthenticate.token;
            }
        }
    }
}
