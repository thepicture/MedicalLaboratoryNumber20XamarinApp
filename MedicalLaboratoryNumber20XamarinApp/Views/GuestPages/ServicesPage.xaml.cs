using MedicalLaboratoryNumber20XamarinApp.Models;
using MedicalLaboratoryNumber20XamarinApp.Models.ResponseModels;
using MedicalLaboratoryNumber20XamarinApp.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalLaboratoryNumber20XamarinApp.Views.GuestPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServicesPage : ContentPage
    {
        private readonly IDataStoreService<ResponseService> _dataStore =
            new ServicesDataStoreService(LaboratoryAPI.BaseUrl);
        public ServicesPage()
        {
            InitializeComponent();
            BindingContext = this;
            ServicesView.ItemsSource = Task.Run(GetServicesAsync).Result;
        }

        /// <summary>
        /// Получает услуги.
        /// </summary>
        /// <returns>Задача, представляющая 
        ///          выполненное получение услуг.</returns>
        private async Task<IEnumerable<ResponseService>> GetServicesAsync()
        {
            return await _dataStore.ReadAllAsync();
        }

        /// <summary>
        /// Срабатывает при обновлении списка услуг.
        /// </summary>
        private async void OnServicesRefreshingAsync(object sender, EventArgs e)
        {
            IsBusy = true;
            ServicesView.ItemsSource = await GetServicesAsync();
            IsBusy = false;
        }
    }
}