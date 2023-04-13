using DatingApp_Phone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp_Phone.Services
{
    public class CountryDataService : ICountryDataService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryDataService()
        {
            _countryRepository = new CountryRepository();
        }


        public async Task<List<Country>> GetAllCountriesAsync()
        {
            return await _countryRepository.GetAllCountriesAsync();
        }

        public async Task<Country> GetCountryByIdAsync(int id)
        {
            return await _countryRepository.GetCountryByIdAsync(id);
        }

        public async Task<Country> GetCountryByNameAsync(string name)
        {
            return await _countryRepository.GetCountryByNameAsync(name);
        }
    }
}
