using DatingApp_Phone.Models;
using DatingApp_Phone.Services;
using DatingApp_Phone.Views;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DatingApp_Phone.ViewModels
{
    public class RegisterGenderViewModel : BaseViewModel
    {
        private readonly IRegisterUserService _registerUserService;
        private readonly IGenderDataService _genderDataService;

        public ICommand ContinueFromGender { get; }

        public RegisterGenderViewModel()
        {
            _registerUserService = TinyIoCContainer.Current.Resolve<IRegisterUserService>();
            _genderDataService = TinyIoCContainer.Current.Resolve<IGenderDataService>();

            Title = "Gender";
            Headline = "What Is Your Gender?";
            ContinueFromGender = new Command(OnButtonClicked);
        }

        private async void OnButtonClicked(object obj)
        {
            User user = _registerUserService.GetUser();

            /*List<Gender> genders = await _genderDataService.GetAllGendersAsync();

            Gender chosenGender = genders[0];
            user.genders = chosenGender;*/

            user.genders = new Gender { genders_id = 1 };

            _registerUserService.SetUser(user);

            await Shell.Current.GoToAsync("RegisterEmailPage");
        }

        /*void GenderChanged(object sender,EventArgs args)
        {
            RadioButton radioButton = sender as RadioButton;
            gender = (string)radioButton.Content;
        }*/
    }
}