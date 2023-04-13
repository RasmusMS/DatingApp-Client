using DatingApp_Phone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp_Phone.Services
{
    public class GenderDataService : IGenderDataService
    {
        private readonly IGenderRepository _genderRepository;

        public GenderDataService()
        {
            _genderRepository = new GenderRepository();
        }

        public async Task<List<Gender>> GetAllGendersAsync()
        {
            return await _genderRepository.GetAllGendersAsync();   
        }

        public async Task<Gender> GetGenderByIdAsync(int id)
        {
            return await _genderRepository.GetGenderByIdAsync(id);
        }

        public async Task<Gender> GetGenderByNameAsync(string name)
        {
            return await _genderRepository.GetGenderByNameAsync(name);
        }
    }
}
