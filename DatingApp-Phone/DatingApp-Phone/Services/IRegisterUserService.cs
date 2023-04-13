using DatingApp_Phone.Models;

namespace DatingApp_Phone.Services
{
    public interface IRegisterUserService
    {
        User GetUser();
        void SetUser(User user);
        string GetGender();
        void SetGender(string gender);
    }
}