using DatingApp_Phone.Models;
using DatingApp_Phone.Services;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DatingApp_Phone.ViewModels
{
    public class FeedViewModel : BaseViewModel
    {
        public readonly IUserDataService _userDataService;
        public readonly IRegisterUserService _registerUserService;
        public List<User> userFeed;
        public List<User> dislikedUsers;
        public User testUser;
        public User testUser2;
        public int currentUser;

        public ICommand ContinueFromDislike { get; }
        public ICommand ContinueFromLike { get; }

        public FeedViewModel()
        {
            _userDataService = new UserDataService();

            userFeed = new List<User>();

            _registerUserService = TinyIoCContainer.Current.Resolve<IRegisterUserService>();

            Title = "Profile";

            GetUserFeed();
            currentUser = 0;

            //SetDummyUser();

            ContinueFromDislike = new Command(DislikeUser);
            ContinueFromLike = new Command(LikeUser);
        }

        // Runs in constructor. Shows first user.
        private void ShowFirstUserInFeed()
        {
            User firstUser = userFeed.ElementAt(0);
            ShowUserInFeed(firstUser);
        }

        // Binds the feed user to the view
        private void ShowUserInFeed(User user)
        {
            ShowName = user.firstname;
            //ShowBio = user.biography.bio;
            ShowLifestyles = user.lifestyles;
            ShowInterests = user.interests;
        }

        // Gets the next user in the feed and use the ShowUserInFeed function to show the user
        private void NextUserInFeed()
        {
            if (userFeed.Count > currentUser + 1)
            {
                currentUser++;
                User nextUser = userFeed.ElementAt(currentUser);
                ShowUserInFeed(nextUser);
            }
            else
            {
                GetUserFeed();
                currentUser = 0;
                User nextUser = userFeed.ElementAt(currentUser);
                ShowUserInFeed(nextUser);
            }
        }

        // Requests the API for a feed. The List userFeed is filled with user objects
        private async void GetUserFeed()
        {
            //User primaryUser = _registerUserService.GetUser();
            //primaryUser.token = "1|qZyyVtcWUCZRcTLdcN1oAczhGTP34HoNckKiQlVr";
            //_registerUserService.SetUser(primaryUser);

            List<User> users = await _userDataService.GetUserFeedAsync();

            foreach (User user in users)
            {
                List<Interest> interests = await _userDataService.GetUserInterestsAsync(user.id);
                List<Lifestyle> lifestyles = await _userDataService.GetUserLifestylesAsync(user.id);
                user.biography = await _userDataService.GetUserBioAsync(user.id);

                user.interests = interests;
                user.lifestyles = lifestyles;

                userFeed.Add(user);
            }

            ShowFirstUserInFeed();
        }

        // Gets current user in the feed and sends a like request to the API where the like is registered
        private async void LikeUser(object obj)
        {
            User likedUser = userFeed.ElementAt(currentUser);

            //await _userDataService.LikeUserAsync(likedUser.id);

            NextUserInFeed();
        }

        // Gets current user in the feed and sends a dislike request to the API where the dislike is registered
        private async void DislikeUser(object obj)
        {
            User dislikedUser = userFeed[currentUser];

            //await _userDataService.DislikeUserAsync(dislikedUser.id);

            NextUserInFeed();
        }

        // Set dummy user
        private void SetDummyUser()
        {
            testUser = new User
            {
                id = 10,
                firstname = "Elton",
                biography = new Bio
                {
                    bio = "Hey, my name is Elton John!"
                },
                lifestyles = new List<Lifestyle>
                {
                    new Lifestyle { type = "Smoker" },
                    new Lifestyle { type = "Atheist" },
                    new Lifestyle { type = "Meatlover" },
                },
                interests = new List<Interest>
                {
                    new Interest { name = "Fodbold" },
                    new Interest { name = "Hockey"},
                    new Interest { name = "Tennis"},
                }
            };

            testUser2 = new User
            {
                id = 11,
                firstname = "Mark",
                biography = new Bio {
                    bio = "My name is Mark, but my friends calls me Denmark!"
                },
                interests = new List<Interest>
                {
                    new Interest { name = "Hiking" },
                    new Interest { name = "Mountaineering"},
                    new Interest { name = "Summer"},
                }
            };

            userFeed.Add(testUser);
            userFeed.Add(testUser2);
        }
    }
}