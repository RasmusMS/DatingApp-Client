using DatingApp_Phone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp_Phone.Services
{
    public class LoginDataService : ILoginDataService
    {
        private readonly IUserRepository _userRepository;

        public LoginDataService()
        {
            _userRepository = new UserRepository();
        }

        public async Task<Login> CheckLogin(User user)
        {
            return await _userRepository.CheckLogin(user);
        }
    }
}
