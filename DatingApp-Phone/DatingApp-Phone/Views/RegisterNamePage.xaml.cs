using DatingApp_Phone.Utility;
using Xamarin.Forms;

namespace DatingApp_Phone.Views
{
    public partial class RegisterNamePage : ContentPage
    {
        public RegisterNamePage()
        {
            BindingContext = ViewModelLocator.RegisterNameViewModel;
            InitializeComponent();
        }
    }
}