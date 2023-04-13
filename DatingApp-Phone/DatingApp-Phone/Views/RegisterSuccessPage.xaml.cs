using DatingApp_Phone.Utility;
using Xamarin.Forms;

namespace DatingApp_Phone.Views
{
    public partial class RegisterSuccessPage : ContentPage
    {
        public RegisterSuccessPage()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.RegisterSuccessViewModel;
        }
    }
}