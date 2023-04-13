using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp_Phone.Models
{
    public interface IGenderRepository
    {
        Task<List<Gender>> GetAllGendersAsync();
        Task<Gender> GetGenderByIdAsync(int id);
        Task<Gender> GetGenderByNameAsync(string name);
    }
}
