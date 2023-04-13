using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp_Phone.Models
{
    public interface IInterestRepository
    {
        Task<List<Interest>> GetAllInterestsAsync();
        Task<Interest> GetInterestByIdAsync(int id);
    }
}
