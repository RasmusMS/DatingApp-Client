using DatingApp_Phone.Utility;
using Xamarin.Forms;

namespace DatingApp_Phone.Views
{
public partial class FeedPage : ContentPage
{
    public FeedPage()
    {
        InitializeComponent();
        BindingContext = ViewModelLocator.FeedViewModel;
        OnAppearing();
    }
}
}