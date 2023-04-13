using DatingApp_Phone.Models;
using DatingApp_Phone.Services;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp_Phone
{
    internal static class Startup
    {
        #region Methods

        internal static void RegisterServices()
        {
            TinyIoCContainer.Current.Register<IRegisterUserService, RegisterUserService>().AsSingleton();
            TinyIoCContainer.Current.Register<IGenderDataService, GenderDataService>();
            TinyIoCContainer.Current.Register<IUserDataService, UserDataService>().AsSingleton();
        }

        #endregion
    }
}

