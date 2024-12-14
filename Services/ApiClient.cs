using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace PruebaCSF_FrontEnd.Services
{
    public class ApiClient
    {
        private readonly HttpClient _client;

        public ApiClient()
        {
            _client = new HttpClient { BaseAddress = new Uri("https://localhost:7062/") };
        }

        public async Task<T> GetAsync<T>(string url)
        {
            
            var response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonResponse);
            }

            return default(T); 
        }

        

        public async Task<bool> PostAsync<T>(string endpoint, T data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(endpoint, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> PutAsync<T>(string endpoint, T data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(endpoint, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<HttpResponseMessage> DeleteAsync(string endpoint)
        {
            var response = await _client.DeleteAsync(endpoint);
            return response;
        }

    }
}