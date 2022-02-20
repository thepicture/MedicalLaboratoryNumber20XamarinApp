using MedicalLaboratoryNumber20XamarinApp.Models;
using MedicalLaboratoryNumber20XamarinApp.Models.RequestModels;
using MedicalLaboratoryNumber20XamarinApp.Models.ResponseModels;
using MedicalLaboratoryNumber20XamarinApp.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalLaboratoryNumber20XamarinApp.Views.GuestPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorizationPage : ContentPage
    {
        private readonly IDataStoreService<ResponsePatient> _dataStore
            = new AuthorizationDataStoreService(LaboratoryAPI.BaseUrl);
        private readonly IFeedback _feedback = new DisplayAlertFeedback();
        public AuthorizationPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        /// <summary>
        /// Осуществляет авторизацию.
        /// </summary>
        private async void PerformAuthorizationAsync(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Login.Text)
                || string.IsNullOrWhiteSpace(Password.Text))
            {
                await _feedback.WarnAsync("Не указан "
                                          + "логин или пароль. "
                                          + "Укажите логин или пароль, "
                                          + "прежде чем авторизоваться");
                return;
            }
            string json = "{\"Login\":\""
                + Login.Text
                + "\",\"password\":\""
                + Password.Text
                + "\"}";
            ResponsePatient patient = await _dataStore.CreateAsync(json);
            if (patient == null)
            {
                await _feedback.WarnAsync("Неверный логин или пароль. "
                                          + "Проверьте правильность ввода. "
                                          + "Регистр логина не важен, "
                                          + "а регистр пароля важен");
                return;
            }
            RequestCredentials credentials = new RequestCredentials
            {
                Login = Login.Text,
                Password = Password.Text,
            };

            try
            {
                await SessionService.SetSessionAsync(patient, credentials);
                await _feedback.InformAsync("Вы успешно авторизованы");
                await Navigation.PopAsync();
            }
            catch (Exception)
            {
                await _feedback.InformErrorAsync("Не удалось авторизоваться. " +
                    "Ошибка в приложении. " +
                    "Перезайдите и попробуйте ещё раз");
            }
        }
    }
}