using DatingApp_Phone.Models;
using DatingApp_Phone.Views;
using System.Windows.Input;
using DatingApp_Phone.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Nancy.TinyIoc;

namespace DatingApp_Phone.ViewModels
{
    public class RegisterNameViewModel : BaseViewModel
    {
        private readonly IRegisterUserService _registerUserService;

        public ICommand ContinueFromName { get; }

        public RegisterNameViewModel()
        {
            _registerUserService = TinyIoCContainer.Current.Resolve<IRegisterUserService>();

            Title = "Name";
            Headline = "What's Your First Name?";
            ContinueFromName = new Command(OnButtonClicked);
        }

        private async void OnButtonClicked(object obj)
        {
            User user = _registerUserService.GetUser();

            user.firstname = EntryName;

            _registerUserService.SetUser(user);

            await Shell.Current.GoToAsync("RegisterDateOfBirthPage");
        }
    }
}