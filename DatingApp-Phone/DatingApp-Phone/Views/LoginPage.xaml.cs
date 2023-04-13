using DatingApp_Phone.Utility;
using Xamarin.Forms;

namespace DatingApp_Phone.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.LoginViewModel;
        }
    }
}