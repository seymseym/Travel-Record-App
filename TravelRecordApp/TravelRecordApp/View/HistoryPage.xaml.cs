using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class HistoryPage : ContentPage
    {
        private MainViewModel viewModel;
        public HistoryPage() // constructor 
        {
            InitializeComponent();
            viewModel = new MainViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.ReadDataBase();
            postListView.ItemsSource = viewModel.PostList;
        }
    }
}