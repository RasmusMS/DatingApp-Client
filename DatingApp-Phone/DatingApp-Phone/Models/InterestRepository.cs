using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp_Phone.Models
{
    class InterestRepository : IInterestRepository
    {
        private readonly HttpClient _httpClient;

        private const string baseUrl = "http://localhost/api/client/interests";

        public InterestRepository()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<List<Interest>> GetAllInterestsAsync()
        {
            Uri url = new Uri(baseUrl);

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Interest>>(content);
            }
            return null;
        }

        public async Task<Interest> GetInterestByIdAsync(int id)
        {
            Uri url = new Uri($"{baseUrl}/{id}");

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Interest>(content);
            }
            return null;
        }
    }
}
