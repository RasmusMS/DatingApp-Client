using DatingApp_Phone.Utility;
using Xamarin.Forms;

namespace DatingApp_Phone.Views
{
    public partial class RegisterDateOfBirthPage : ContentPage
    {
        public RegisterDateOfBirthPage()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.RegisterDateOfBirthViewModel;
        }
    }
}