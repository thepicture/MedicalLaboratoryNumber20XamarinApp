
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
    public partial class ServicesPage : ContentPage
    {
        public ServicesPage()
        {
            InitializeComponent();
            BindingContext = this;
            _ = LoadServicesAsync();
        }

        /// <summary>
        /// Срабатывает при обновлении списка услуг.
        /// </summary>
        private async void OnServicesRefreshing(object sender, EventArgs e)
        {
            IsBusy = true;
            await LoadServicesAsync();
            IsBusy = false;
        }

        /// <summary>
        /// Подгружает услуги.
        /// </summary>
        /// <returns>Задача, репрезентирующая выполненную подгрузку.</returns>
        private async Task LoadServicesAsync()
        {
            IDataStoreService<ResponseService> dataStore =
                new ServicesDataStoreService(LaboratoryAPI.BaseUrl);
            ServicesView.ItemsSource = await dataStore.ReadAllAsync();
        }
    }
}