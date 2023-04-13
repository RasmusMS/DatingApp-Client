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
    public class ProfileViewModel : BaseViewModel
    {
        private readonly IRegisterUserService _registerUserService;
        private readonly IUserDataService _userDataService;
        public ICommand SaveProfileChanges { get; }

        public ProfileViewModel()
        {
            _registerUserService = TinyIoCContainer.Current.Resolve<IRegisterUserService>();
            _userDataService = TinyIoCContainer.Current.Resolve<IUserDataService>();
            Title = "Profile";

            //SetDummyUser();
            //ShowUserProfile();

            SaveProfileChanges = new Command(SaveChanges);
        }

        public void SetDummyUser()
        {
            User user = _registerUserService.GetUser();

            DateTime birthDay = new DateTime(2000, 5, 15);

            user.id = 9;
            user.firstname = "Marie Du Pont";
            user.email = "mariedp@gmail.com";
            user.birthday = birthDay;
            user.biography = new Bio
            {
                bio = "Jeg er 22 år gammel, og elsker hunde."
            };
            user.countries = new Country { name = "Denmark" };
            user.genders = new Gender { gender_name = "Female" };
            user.interests = new List<Interest>
            {
                new Interest { name = "Painting" },
                new Interest { name = "Baking" },
                new Interest { name = "Dogs" },
                new Interest { name = "Nature" },
                new Interest { name = "Fitness" },
            };
            user.active_profile = true;
            user.lifestyles = new List<Lifestyle>
            {
                new Lifestyle { type = "Vegan" },
                new Lifestyle { type = "Nonsmoker" },
                new Lifestyle { type = "Social drinking" },
            };

            _registerUserService.SetUser(user);
        }

        private async void ShowUserProfile()
        {
            User user = _registerUserService.GetUser();
            List<Interest> interests = await _userDataService.GetUserInterestsAsync(user.id);
            //List<Lifestyle> lifestyles = await _userDataService.GetUserLifestylesAsync(user.id);
            user.biography = await _userDataService.GetUserBioAsync(user.id);


            user.interests = interests;
            //user.lifestyles = lifestyles;
            
            ShowName = user.firstname;
            ShowBirth = user.birthday;
            ShowEmail = user.email;
            ShowInterests = user.interests;
            ShowBio = user.biography.bio;
        }

        private async void SaveChanges(object obj)
        {
            //User user = _registerUserService.GetUser();

            //user.bios.description = ShowBio;
            ShowUserProfile();
            //_registerUserService.SetUser(user);
        }


        public async void UpdateUserInfo(User updatedUser)
        {
            User user = _registerUserService.GetUser();

            user = updatedUser;

            await _userDataService.UpdateUserAsync(user);
        }

        public async void UpdateUserInterests()
        {
            User user = _registerUserService.GetUser();
            List<Interest> interests = user.interests;

            await _userDataService.UpdateUserInterestsAsync(interests);
        }

        public async void UpdateUserLifestyles()
        {
            User user = _registerUserService.GetUser();
            List<Lifestyle> lifestyles = user.lifestyles;

            await _userDataService.UpdateUserLifestylesAsync(lifestyles);
        }

        public async void UpdateUserBio()
        {
            User user = _registerUserService.GetUser();

            //await _userDataService.UpdateUserBioAsync(bio);
        }

        //public async List<Interest> GetUserInterests()
        //{
        //    List<Interest> interests = await _userDataService.GetUserInterestsAsync();

        //    return interests;
        //}
    }
}