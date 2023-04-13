using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp_Phone.Models
{
    public class GenderRepository : IGenderRepository
    {
        private readonly HttpClient _httpClient;

        private const string baseUrl = "http://192.168.0.208/api/v1/client/genders";
        //private const string baseUrl = "http://10.130.65.255/api/v1/client/genders";

        public GenderRepository()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<List<Gender>> GetAllGendersAsync()
        {
            Uri url = new Uri(baseUrl);

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Gender>>(content);
            }
            return null;
        }

        public async Task<Gender> GetGenderByIdAsync(int id)
        {
            Uri url = new Uri($"{baseUrl}/{id}");
            UriBuilder uri = new UriBuilder(url)
            {
                Port = 5432
            };

            HttpResponseMessage response = await _httpClient.GetAsync(uri.Uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Gender>(content);
            }
            return null;
        }

        public async Task<Gender> GetGenderByNameAsync(string name)
        {
            Uri url = new Uri($"{baseUrl}/{name}");

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Gender>(content);
            }
            return null;
        }
    }
}
