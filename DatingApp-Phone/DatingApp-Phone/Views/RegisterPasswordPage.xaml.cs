using DatingApp_Phone.Utility;
using Xamarin.Forms;

namespace DatingApp_Phone.Views
{
    public partial class RegisterPasswordPage : ContentPage
    {
        public RegisterPasswordPage()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.RegisterPasswordViewModel;
        }
    }
}