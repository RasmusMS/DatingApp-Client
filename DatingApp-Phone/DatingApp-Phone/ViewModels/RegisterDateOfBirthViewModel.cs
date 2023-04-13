using DatingApp_Phone.Models;
using DatingApp_Phone.Services;
using DatingApp_Phone.Views;
using Nancy.TinyIoc;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DatingApp_Phone.ViewModels
{
    public class RegisterDateOfBirthViewModel : BaseViewModel
    {
        private readonly IRegisterUserService _registerUserService;

        public ICommand ContinueFromDateOfBirth { get; }
        public RegisterDateOfBirthViewModel()
        {
            _registerUserService = TinyIoCContainer.Current.Resolve<IRegisterUserService>();

            Title = "Date Of Birth";
            Headline = "Date Of Birth?";
            ContinueFromDateOfBirth = new Command(OnButtonClicked);
        }

        private async void OnButtonClicked(object obj)
        {
            User user = _registerUserService.GetUser();

            user.birthday = BirthDate;

            _registerUserService.SetUser(user);

            await Shell.Current.GoToAsync("RegisterGenderPage");
        }
    }
}