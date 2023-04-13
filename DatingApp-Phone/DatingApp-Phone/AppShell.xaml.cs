using DatingApp_Phone.ViewModels;
using DatingApp_Phone.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DatingApp_Phone
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("RegisterNamePage", typeof(RegisterNamePage));
            Routing.RegisterRoute("RegisterDateOfBirthPage", typeof(RegisterDateOfBirthPage));
            Routing.RegisterRoute("RegisterGenderPage", typeof(RegisterGenderPage));
            Routing.RegisterRoute("RegisterEmailPage", typeof(RegisterEmailPage));
            Routing.RegisterRoute("RegisterPasswordPage", typeof(RegisterPasswordPage));
            Routing.RegisterRoute("RegisterSuccessPage", typeof(RegisterSuccessPage));
            Routing.RegisterRoute("ProfilePage", typeof(ProfilePage));
            Routing.RegisterRoute("FeedPage", typeof(FeedPage));
        }

    }
}
