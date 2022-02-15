using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using TravelRecordApp.Model;
using TravelRecordApp.View;
using Xamarin.Forms;

namespace TravelRecordApp.ViewModel
{
    public class MainViewModel: ContentPage, INotifyPropertyChanged
    {
        public ICommand LoginCommand => new Command(Login);
        public ICommand TabAddCommand => new Command(TabAdd);
        public ICommand SaveTravelCommand => new Command(SaveTravel);

        private string _experienceEntry;

        public string ExperienceEnrty
        {
            get { return _experienceEntry; }
            set { SetProperty(ref _experienceEntry, value); }
        }

        public static void ReadDataBase()
        {
            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            conn.CreateTable<Post>();
            var postList = conn.Table<Post>().ToList();
            conn.Close();
        }
        private void SaveTravel()
        {
            Post post = new Post()
            {
                Experience = ExperienceEnrty
            };

            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            conn.CreateTable<Post>();
            int rows = conn.Insert(post);
            conn.Close();

            if (rows > 0) // At least one element got inserted to the database, insertion successfull
            {
                App.Current.MainPage.DisplayAlert("Success", "Experience successfully inserted", "Ok");
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Fail", "Experience failed to be inserted", "Ok");
            }           
        }

        public MainViewModel()
        {

        }
        private void TabAdd()
        {
            App.Current.MainPage.Navigation.PushAsync(new NewTravelPage());
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
