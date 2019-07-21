using ProjectEPlant.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace ProjectEPlant.ViewsModels.Helpers
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        #region Properties

        public INavigation Navigation { get; set; }

        public FirebaseConnection WebApi;
        public FirebaseAuthService FirebaseAuth;

        #endregion

        public BaseViewModel(INavigation navigation)
        {
            Navigation = navigation;
            WebApi = new FirebaseConnection();
            FirebaseAuth = new FirebaseAuthService();
        }

        protected bool SetValue<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
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
