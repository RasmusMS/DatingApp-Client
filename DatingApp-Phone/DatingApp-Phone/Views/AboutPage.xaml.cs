using DatingApp_Phone.Utility;
using Xamarin.Forms;

namespace DatingApp_Phone.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.AboutViewModel;
        }
    }
}