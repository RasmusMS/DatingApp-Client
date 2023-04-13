using DatingApp_Phone.Services;
using DatingApp_Phone.ViewModels;

namespace DatingApp_Phone.Utility
{
    public class ViewModelLocator
    {
        public static AboutViewModel AboutViewModel { get; set; } = new AboutViewModel();
        public static BaseViewModel BaseViewModel { get; set; } = new BaseViewModel();
        public static LoginViewModel LoginViewModel { get; set; } = new LoginViewModel();
        public static RegisterDateOfBirthViewModel RegisterDateOfBirthViewModel { get; set; } = new RegisterDateOfBirthViewModel();
        public static RegisterEmailViewModel RegisterEmailViewModel { get; set; } = new RegisterEmailViewModel();
        public static RegisterGenderViewModel RegisterGenderViewModel { get; set; } = new RegisterGenderViewModel();
        public static RegisterNameViewModel RegisterNameViewModel { get; set; } = new RegisterNameViewModel();
        public static RegisterPasswordViewModel RegisterPasswordViewModel { get; set; } = new RegisterPasswordViewModel();
        public static RegisterSuccessViewModel RegisterSuccessViewModel { get; set; } = new RegisterSuccessViewModel();
        public static ProfileViewModel ProfileViewModel { get; set; } = new ProfileViewModel();
        public static FeedViewModel FeedViewModel { get; set; } = new FeedViewModel();
    }
}
