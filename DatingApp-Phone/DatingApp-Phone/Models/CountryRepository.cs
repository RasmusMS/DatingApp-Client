using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp_Phone.Models
{
    public class CountryRepository : ICountryRepository
    {
        private readonly HttpClient _httpClient;

        //private const string baseUrl = "http://10.130.65.255/api/v1/client/countries";
        private const string baseUrl = "http://192.168.0.208/api/v1/client/countries";

        public CountryRepository()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            Uri url = new Uri(baseUrl);
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if(response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Country>>(content);
            }
            return null;
        }

        public async Task<Country> GetCountryByIdAsync(int id)
        {
            Uri url = new Uri($"{baseUrl}/{id}");
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if(response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Country>(content);
            }
            return null;
        }

        public async Task<Country> GetCountryByNameAsync(string name)
        {
            Uri url = new Uri($"{baseUrl}/{name}");
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Country>(content);
            }
            return null;
        }
    }
}
