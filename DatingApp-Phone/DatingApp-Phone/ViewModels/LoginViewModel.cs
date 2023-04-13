using DatingApp_Phone.Models;
using DatingApp_Phone.Services;
using DatingApp_Phone.Views;
using Nancy.TinyIoc;
using System.Windows.Input;
using Xamarin.Forms;

namespace DatingApp_Phone.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IRegisterUserService _registerUserService;
        private readonly ILoginDataService _loginDataService;

        public ICommand RegisterUserCommand { get; }
        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            _registerUserService = TinyIoCContainer.Current.Resolve<IRegisterUserService>();
            _loginDataService = new LoginDataService();

            LoginCommand = new Command(OnLoginClicked);
            RegisterUserCommand = new Command(OnRegisterClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            User user = _registerUserService.GetUser();

            user.email = EntryEmail;
            user.password = EntryPassword;

            Login login = await _loginDataService.CheckLogin(user);
            if (login.user != null)
            {
                user = login.user;
                user.token = login.token;

                _registerUserService.SetUser(user);

                await Shell.Current.GoToAsync("ProfilePage");
            } else
            {
                await Shell.Current.GoToAsync("RegisterNamePage");
            }
        }

        private async void OnRegisterClicked(object obj)
        {
            await Shell.Current.GoToAsync("RegisterNamePage");
        }
    }
}
