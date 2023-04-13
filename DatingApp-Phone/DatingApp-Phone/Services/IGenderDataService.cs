using DatingApp_Phone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp_Phone.Services
{
    public interface IGenderDataService
    {
        Task<List<Gender>> GetAllGendersAsync();
        Task<Gender> GetGenderByIdAsync(int id);
        Task<Gender> GetGenderByNameAsync(string name);
    }
}
