using DatingApp_Phone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp_Phone.Services
{
    public class RegisterUserService : IRegisterUserService
    {
        private User _user;
        private string gender;

        public RegisterUserService(User user)
        {
            _user = user;
        }

        public string GetGender()
        {
            return gender;
        }

        public User GetUser()
        {
            return _user;
        }

        public void SetGender(string gender)
        {
            this.gender = gender;
        }

        public void SetUser(User user)
        {
            this._user = user;
        }
    }
}
