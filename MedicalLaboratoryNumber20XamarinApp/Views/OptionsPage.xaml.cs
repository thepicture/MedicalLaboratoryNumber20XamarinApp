using MedicalLaboratoryNumber20XamarinApp.Models.RequestModels;
using MedicalLaboratoryNumber20XamarinApp.Services;
using MedicalLaboratoryNumber20XamarinApp.Views.AuthorizedPages;
using MedicalLaboratoryNumber20XamarinApp.Views.GuestPages;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MedicalLaboratoryNumber20XamarinApp
{
    public partial class OptionsPage : ContentPage
    {
        private RequestPatient _currentUser;
        private readonly IFeedback _feedback = new DisplayAlertFeedback();

        public RequestPatient CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }
        public OptionsPage()
        {
            InitializeComponent();
            BindingContext = this;
            _ = SetIsAuthorizedAsync();
        }

        /// <summary>
        /// Устанавливает данные текущего пользователя 
        /// в <see cref="CurrentUser"/>.
        /// </summary>
        private async Task SetIsAuthorizedAsync()
        {
            CurrentUser = await SessionService.GetSessionAsync();
            PerformGuestButton.IsVisible =
                ProfileButton.IsVisible =
                CurrentUser != null;
        }

        /// <summary>
        /// Осуществляет навигацию в список услуг.
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

        /// <summary>
        /// Осуществляет навигацию на страницу авторизации.
        /// </summary>
        private async void NavigateToAuthorizationPageAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AuthorizationPage());
        }

        /// <summary>
        /// Обновляет опции страницы.
        /// </summary>
        private async void RefreshOptions(object sender, EventArgs e)
        {
            await SetIsAuthorizedAsync();
        }

        /// <summary>
        /// Переходит в гостевой режим.
        /// </summary>
        private async void PerformGuestMode(object sender, EventArgs e)
        {
            if (await _feedback.AskAsync("Вы действительно " +
                "хотите перейти в режим гостя?"))
            {
                SessionService.ClearSession();
                await SetIsAuthorizedAsync();
            }
        }

        private async void PerformGoToProfilePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
    }
}
