using DatingApp_Phone.Services;
using DatingApp_Phone.Views;
using Nancy.TinyIoc;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DatingApp_Phone
{
    public partial class App : Application
    {
        public string ip_address { get; }

        public App()
        {
            ip_address = "10.130.65.255";

            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            Startup.RegisterServices();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
