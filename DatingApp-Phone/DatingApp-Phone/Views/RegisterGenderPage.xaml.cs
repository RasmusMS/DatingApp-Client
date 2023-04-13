using DatingApp_Phone.Utility;
using System;
using Xamarin.Forms;

namespace DatingApp_Phone.Views
{
    public partial class RegisterGenderPage : ContentPage
    {
        public RegisterGenderPage()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.RegisterGenderViewModel;
        }
    }
}