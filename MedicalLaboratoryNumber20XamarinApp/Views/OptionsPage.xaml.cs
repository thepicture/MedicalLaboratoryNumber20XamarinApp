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
            SetTitle();
        }

        private async void SetTitle()
        {
            IsAuthorized = await SecureStorage.GetAsync("User") != null;
        }
        
        /// <summary>
        /// Производит навигацию на список услуг.
        /// </summary>
        private async void NavigateToServicesPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ServicesPage());
        }
    }
}
