using DatingApp_Phone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp_Phone.Services
{
    public interface IInterestDataService
    {
        Task<List<Interest>> GetAllInterestsAsync();
        Task<Interest> GetInterestByIdAsync(int id);
    }
}
