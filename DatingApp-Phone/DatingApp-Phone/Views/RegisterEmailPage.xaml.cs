using DatingApp_Phone.Utility;
using Xamarin.Forms;

namespace DatingApp_Phone.Views
{
    public partial class RegisterEmailPage : ContentPage
    {
        public RegisterEmailPage()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.RegisterEmailViewModel;
        }
    }
}