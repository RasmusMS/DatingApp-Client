using DatingApp_Phone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp_Phone.Services
{
    public class InterestDataService : IInterestDataService
    {
        private readonly IInterestRepository _interestRepository;

        public InterestDataService(IInterestRepository interestRepository)
        {
            _interestRepository = interestRepository;
        }
        public async Task<List<Interest>> GetAllInterestsAsync()
        {
            return await _interestRepository.GetAllInterestsAsync();
        }

        public async Task<Interest> GetInterestByIdAsync(int id)
        {
            return await _interestRepository.GetInterestByIdAsync(id);
        }
    }
}
