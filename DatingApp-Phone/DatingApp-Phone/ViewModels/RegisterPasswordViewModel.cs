using DatingApp_Phone.Models;
using DatingApp_Phone.Services;
using DatingApp_Phone.Views;
using Nancy.TinyIoc;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DatingApp_Phone.ViewModels
{
    public class RegisterPasswordViewModel : BaseViewModel
    {
        private readonly IRegisterUserService _registerUserService;

        public ICommand ContinueFromPassword { get; }
        public RegisterPasswordViewModel()
        {
            _registerUserService = TinyIoCContainer.Current.Resolve<IRegisterUserService>();

            Title = "Password";
            Headline = "Enter A Password";
            ContinueFromPassword = new Command(OnButtonClicked);
        }

        private async void OnButtonClicked(object obj)
        {
            User user = _registerUserService.GetUser();

            user.password = EntryPassword;

            _registerUserService.SetUser(user);

            await Shell.Current.GoToAsync("RegisterSuccessPage");
        }
    }
}