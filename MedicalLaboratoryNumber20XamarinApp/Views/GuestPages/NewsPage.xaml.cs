using MedicalLaboratoryNumber20XamarinApp.Models;
using MedicalLaboratoryNumber20XamarinApp.Models.ResponseModels;
using MedicalLaboratoryNumber20XamarinApp.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalLaboratoryNumber20XamarinApp.Views.GuestPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsPage : ContentPage
    {
        public NewsPage()
        {
            InitializeComponent();
            BindingContext = this;
            _ = LoadNewsAsync();
        }

        private async Task LoadNewsAsync()
        {
            IDataStoreService<ResponseNews> dataStore =
              new NewsDataStoreService(LaboratoryAPI.BaseUrl);
            NewsView.ItemsSource = await dataStore.ReadAllAsync();
        }

        private async void OnNewsRefreshing(object sender, EventArgs e)
        {
            IsBusy = true;
            await LoadNewsAsync();
            IsBusy = false;
        }
    }
}