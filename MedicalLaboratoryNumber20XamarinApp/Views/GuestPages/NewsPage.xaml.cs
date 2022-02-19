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
    public partial class NewsPage : ContentPage
    {
        private readonly IDataStoreService<ResponseNews> _dataStore =
            new NewsDataStoreService(LaboratoryAPI.BaseUrl);
        public NewsPage()
        {
            InitializeComponent();
            BindingContext = this;
            NewsView.ItemsSource = Task.Run(GetNewsAsync).Result;
        }

        /// <summary>
        /// Получает новости.
        /// </summary>
        /// <returns>Задача, представляющая 
        ///          выполненное получение новостей.</returns>
        private async Task<IEnumerable<ResponseNews>> GetNewsAsync()
        {
            return await _dataStore.ReadAllAsync();
        }

        /// <summary>
        /// Срабатывает при обновлении списка новостей.
        /// </summary>
        private async void OnNewsRefreshingAsync(object sender, EventArgs e)
        {
            IsBusy = true;
            NewsView.ItemsSource = await GetNewsAsync();
            IsBusy = false;
        }
    }
}