using DatingApp_Phone.Models;
using DatingApp_Phone.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace DatingApp_Phone.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        string headline = string.Empty;
        public string Headline
        {
            get { return headline; }
            set { SetProperty(ref headline, value);  }
        }

        string firstName = string.Empty;
        public string EntryName
        {
            get { return firstName; }
            set { SetProperty(ref firstName, value);  }
        }

        DateTime birthDate;
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { SetProperty(ref birthDate, value);  }
        }

        string email = string.Empty;
        public string EntryEmail
        {
            get { return email; }
            set { SetProperty(ref email, value);  }
        }

        string password = string.Empty;
        public string EntryPassword
        {
            get { return password; }
            set { SetProperty(ref password, value);  }
        }

        string showName = string.Empty;
        public string ShowName
        {
            get { return showName; }
            set { SetProperty(ref showName, value); }
        }

        DateTime showBirth;
        public DateTime ShowBirth
        {
            get { return showBirth; }
            set { SetProperty(ref showBirth, value); }
        }

        string showGender = string.Empty;
        public string ShowGender
        {
            get { return showGender; }
            set { SetProperty(ref showGender, value); }
        }

        string showEmail = string.Empty;
        public string ShowEmail
        {
            get { return showEmail; }
            set { SetProperty(ref showEmail, value); }
        }

        string showPassword = string.Empty;
        public string ShowPassword
        {
            get { return showPassword; }
            set { SetProperty(ref showPassword, value); }
        }

        string showBio = string.Empty;
        public string ShowBio
        {
            get { return showBio; }
            set { SetProperty(ref showBio, value);  }
        }

        List<Interest> showInterests;
        public List<Interest> ShowInterests
        {
            get { return showInterests; }
            set { SetProperty(ref showInterests, value); }
        }

        List<Lifestyle> showLifestyles;
        public List<Lifestyle> ShowLifestyles
        {
            get { return showLifestyles; }
            set { SetProperty(ref showLifestyles, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        internal void OnDisappearing()
        {
            throw new NotImplementedException();
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
