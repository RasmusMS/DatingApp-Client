using DatingApp_Phone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp_Phone.Services
{
    public interface ILoginDataService
    {
        Task<Login> CheckLogin(User user);
    }
}
