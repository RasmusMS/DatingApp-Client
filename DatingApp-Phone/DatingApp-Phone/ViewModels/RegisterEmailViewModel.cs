using DatingApp_Phone.Models;
using DatingApp_Phone.Services;
using DatingApp_Phone.Views;
using Nancy.TinyIoc;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DatingApp_Phone.ViewModels
{
    public class RegisterEmailViewModel : BaseViewModel
    {
        private readonly IRegisterUserService _registerUserService;

        public ICommand ContinueFromEmail { get; }
        public RegisterEmailViewModel()
        {
            _registerUserService = TinyIoCContainer.Current.Resolve<IRegisterUserService>();

            Title = "Email";
            Headline = "Enter Your E-mail";
            ContinueFromEmail = new Command(OnButtonClicked);
        }

        private async void OnButtonClicked(object obj)
        {
            User user = _registerUserService.GetUser();

            user.email = EntryEmail;

            //Headline = user.firstname;

            _registerUserService.SetUser(user);

            await Shell.Current.GoToAsync("RegisterPasswordPage");
        }
    }
}