using DatingApp_Phone.Models;
using DatingApp_Phone.Services;
using DatingApp_Phone.Views;
using Nancy.TinyIoc;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DatingApp_Phone.ViewModels
{
    public class RegisterSuccessViewModel : BaseViewModel
    {
        private readonly IRegisterUserService _registerUserService;
        private readonly IUserDataService _userDataService;
        private readonly ICountryDataService _countryDataService;
        CancellationTokenSource cts;

        public ICommand ContinueFromSuccess { get; }

        public RegisterSuccessViewModel()
        {
            _registerUserService = TinyIoCContainer.Current.Resolve<IRegisterUserService>();
            _userDataService = new UserDataService();
            _countryDataService = new CountryDataService();
            //_userDataService = TinyIoCContainer.Current.Resolve<IUserDataService>();


            Title = "Success";
            Headline = "All Done!";

            ContinueFromSuccess = new Command(RegisterUser);
        }

        private async void RegisterUser()
        {
            Headline = "Creating Your Profile...";

            User user = _registerUserService.GetUser();

            user.active_profile = true;
            user.countries = new Country { id = 1 };

            //SetCountry();
            //await GetCurrentLocation();

            await _userDataService.CreateUserAsync(user);

            await Shell.Current.GoToAsync("ProfilePage");
        }

        async Task GetCurrentLocation()
        {
            User user = _registerUserService.GetUser();
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);

                if (location != null)
                {
                    try
                    {
                        var lat = 47.673988;
                        var lon = -122.121513;

                        var placemarks = await Geocoding.GetPlacemarksAsync(lat, lon);

                        var placemark = placemarks?.FirstOrDefault();
                        if (placemark != null)
                        {
                            var countryName = placemark.CountryName;

                            Country country = await _countryDataService.GetCountryByNameAsync(countryName);
                            user.countries.id = country.id;

                            _registerUserService.SetUser(user);
                        }
                    }
                    catch (FeatureNotSupportedException fnsEx)
                    {
                        // Feature not supported on device
                    }
                    catch (Exception ex)
                    {
                        // Handle exception that may have occurred in geocoding
                    }
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }

        protected void OnDisappearing()
        {
            if (cts != null && !cts.IsCancellationRequested)
                cts.Cancel();
            base.OnDisappearing();
        }

        //private async void SetCountry()
        //{
        //    User user = _registerUserService.GetUser();
        //    try
        //    {
        //        // Getting user device location
        //        var location = await Geolocation.GetLastKnownLocationAsync();

        //        if (location != null)
        //        {

        //            // Finding latitude and longitude for device
        //            double lat = location.Latitude;
        //            double lon = location.Longitude;
        //            try
        //            {
        //                // Searching for location based on latitude and longitude
        //                var placemarks = await Geocoding.GetPlacemarksAsync(lat, lon);

        //                var placemark = placemarks?.FirstOrDefault();
        //                if (placemark != null)
        //                {
        //                    var countryName = placemark.CountryName;

        //                    //!!!!!! Need to add search for country.
        //                    Country country = await _countryDataService.GetCountryByNameAsync(countryName);

        //                    var country_id = country.id;

        //                    user.countries_id = country_id;

        //                    Headline = user.countries_id.ToString();
        //                }
        //            }
        //            catch (FeatureNotSupportedException fnsEx)
        //            {
        //                // Feature not supported on device
        //            }
        //            catch (Exception ex)
        //            {
        //                // Handle exception that may have occurred in geocoding
        //            }
        //        }
        //    }
        //    catch (FeatureNotSupportedException fnsEx)
        //    {
        //        // Handle not supported on device exception
        //    }
        //    catch (FeatureNotEnabledException fneEx)
        //    {
        //        // Handle not enabled on device exception
        //    }
        //    catch (PermissionException pEx)
        //    {
        //        // Handle permission exception
        //    }
        //    catch (Exception ex)
        //    {
        //        // Unable to get location
        //    }
        //}
    }
}