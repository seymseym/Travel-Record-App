using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using TravelRecordApp.View;
using Xamarin.Forms;

namespace TravelRecordApp.ViewModel
{
    public class MainViewModel: ContentPage, INotifyPropertyChanged
    {
        public ICommand LoginCommand => new Command(Login);
        public MainViewModel()
        {

        }
        private string _emailEntry;

        public string EmailEntry
        {
            get { return _emailEntry; }
            set { SetProperty(ref _emailEntry, value); }
        }

        private string _passwordEntry;


        public string PasswordEntry
        {
            get { return _passwordEntry; }
            set { SetProperty(ref _passwordEntry, value); }
        }

        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        public void Login()
        {
            bool isEmailEmpty = string.IsNullOrEmpty(EmailEntry);
            bool isPasswordEmpty = string.IsNullOrEmpty(PasswordEntry);

            if (isEmailEmpty || isPasswordEmpty)
            {
                
            }
            else
            {
                App.Current.MainPage.Navigation.PushAsync(new HomePage());
            }
        }

    }
}
