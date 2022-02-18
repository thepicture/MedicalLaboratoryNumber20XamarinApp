using MedicalLaboratoryNumber20XamarinApp.Views.GuestPages;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MedicalLaboratoryNumber20XamarinApp
{
    public partial class OptionsPage : ContentPage
    {
        private bool _isAuthorized;

        public bool IsAuthorized
        {
            get => _isAuthorized;
            set
            {
                _isAuthorized = value;
                OnPropertyChanged(nameof(IsAuthorized));
            }
        }
        public OptionsPage()
        {
            InitializeComponent();
            SetIsAuthorized();
        }

        /// <summary>
        /// Определяет, авторизован ли пользователь
        /// и устанавливает результат в <see cref="IsAuthorized"/>.
        /// </summary>
        private async void SetIsAuthorized()
        {
            IsAuthorized = await SecureStorage.GetAsync("User") != null;
        }
        
        /// <summary>
        /// Осуществляет навигацию на список услуг.
        /// </summary>
        private async void NavigateToServicesPageAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ServicesPage());
        }

        /// <summary>
        /// Осуществляет навигацию в новости лаборатории.
        /// </summary>
        private async void NavigateToNewsPageAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewsPage());
        }
    }
}
