using DatingApp_Phone.Services;
using Nancy.TinyIoc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp_Phone.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IRegisterUserService _registerUserService;

        //remote
        private const string baseUrl = "http://192.168.0.208/api/v1/client/users/";
        //private const string baseUrl = "http://10.130.65.255/api/v1/client/users/";
        //private const string baseUrl = "http://localhost/api/v1/client/users/";

        public UserRepository()
        {
            _registerUserService = TinyIoCContainer.Current.Resolve<IRegisterUserService>();

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var url = new Uri(baseUrl);

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<User>>(content);
            }
            return null;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var url = new Uri($"{baseUrl}/{id}");

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(content);
            }
            return null;
        }

        public async Task<List<User>> GetUserFeedAsync()
        {
            if (_httpClient.DefaultRequestHeaders.Authorization == null)
            {
                //User user = _registerUserService.GetUser();
                //string token = user.token;
                _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer 1|qZyyVtcWUCZRcTLdcN1oAczhGTP34HoNckKiQlVr");
            }

        string thisUrl = "http://192.168.0.208/api/v1/client";
            var url = new Uri($"{thisUrl}/feed/");

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<User>>(content);
            }
            return null;
        }

        public async Task<List<User>> GetBlockedUsersAsync()
        {
            var url = new Uri($"{baseUrl}/blocked");
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<User>>(content);
            }
            return null;
        }

        public async Task<List<Interest>> GetUserInterestsAsync(int id)
        {
            if (_httpClient.DefaultRequestHeaders.Authorization == null)
            {
                User user = _registerUserService.GetUser();
                string token = user.token;
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer { token }");
            }

            string thisUrl = "http://192.168.0.208/api/v1/client/interests/users/";
            var url = new Uri($"{thisUrl}{id}");
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Interest>>(content);
            }
            return null;
        }

        public async Task<List<Lifestyle>> GetUserLifestylesAsync(int id)
        {
            if (_httpClient.DefaultRequestHeaders.Authorization == null)
            {
                User user = _registerUserService.GetUser();
                string token = user.token;
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer { token }");
            }
            string thisUrl = "http://192.168.0.208/api/v1/client/userlifestyles/";

            var url = new Uri($"{thisUrl}{id}");
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Lifestyle>>(content);
            }
            return null;
        }

        public async Task<List<User>> GetUserLikesAsync()
        {
            var url = new Uri($"{baseUrl}/likes");
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<User>>(content);
            }
            return null;
        }

        public async Task<List<User>> GetUserDislikesAsync()
        {
            var url = new Uri($"{baseUrl}/dislikes");
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<User>>(content);
            }
            return null;
        }

        public async Task<List<User>> GetUserMatchesAsync()
        {
            var url = new Uri($"{baseUrl}/matches");
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<User>>(content);
            }
            return null;
        }

        public async Task<Bio> GetUserBioAsync(int id)
        {
            if (_httpClient.DefaultRequestHeaders.Authorization == null) {
                User user = _registerUserService.GetUser();
                string token = user.token;
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer { token }");
            }
            string thisUrl = "http://192.168.0.208/api/v1/bios/";

            var url = new Uri($"{thisUrl}{id}");
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Bio>(content);
            }
            return null;
        }

        public async Task CreateUserAsync(User user)
        {
            Uri url = new Uri(baseUrl);

            string json = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                await _httpClient.PostAsync(url, content);
            } 
            catch
            {
 
            }
        }

        public async Task UpdateUserAsync(User user)
        {
            var url = new Uri(baseUrl);

            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await _httpClient.PutAsync(url, content);
        }

        public async Task UpdateUserInterestsAsync(List<Interest> interest)
        {
            var url = new Uri($"{baseUrl}/interests");

            var json = JsonConvert.SerializeObject(interest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await _httpClient.PutAsync(url, content);
        }

        public async Task UpdateUserLifestylesAsync(List<Lifestyle> lifestyle)
        {
            var url = new Uri($"{baseUrl}/lifestyles");

            var json = JsonConvert.SerializeObject(lifestyle);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await _httpClient.PutAsync(url, content);
        }

        public async Task UpdateUserGenderAsync(Gender gender)
        {
            Uri url = new Uri($"{baseUrl}/genders");

            string json = JsonConvert.SerializeObject(gender);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            await _httpClient.PutAsync(url, content);
        }

        public async Task UpdateUserPreferenceAsync(Preference preference)
        {
            var url = new Uri($"{baseUrl}/preferences");

            var json = JsonConvert.SerializeObject(preference);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await _httpClient.PutAsync(url, content);
        }

        public async Task DeleteUserAsync(int id)
        {
            var url = new Uri($"{baseUrl}/{id}");
            await _httpClient.DeleteAsync(url);
        }

        public Task<Gender> GetUserGenderAsync()
        {
            throw new NotImplementedException();
        }

        public async Task LikeUserAsync(int id)
        {
            Uri url = new Uri(baseUrl);

            string json = JsonConvert.SerializeObject(id);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(url, content);
        }

        public async Task DislikeUserAsync(int id)
        {
            Uri url = new Uri(baseUrl);

            string json = JsonConvert.SerializeObject(id);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(url, content);
        }

        public async Task<Login> CheckLogin(User user)
        {
            Uri url = new Uri("http://192.168.0.208/api/v1/client/login");

            string json = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Login>(result);
            }
            return null;
        }

        public async Task<List<Picture>> GetUserPicturesAsync()
        {
            Uri url = new Uri($"{baseUrl}/pictures");

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Picture>>(content);
            }
            return null;
        }

        public async Task<Picture> UploadPicture(Picture picture)
        {
            throw new NotImplementedException();
        }
    }
}
