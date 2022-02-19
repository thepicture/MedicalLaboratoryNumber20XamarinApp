using MedicalLaboratoryNumber20XamarinApp.Models;
using MedicalLaboratoryNumber20XamarinApp.Models.RequestModels;
using MedicalLaboratoryNumber20XamarinApp.Models.ResponseModels;
using MedicalLaboratoryNumber20XamarinApp.Services;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalLaboratoryNumber20XamarinApp.Views.GuestPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorizationPage : ContentPage
    {
        private readonly IDataStoreService<ResponsePatient> _dataStore
            = new AuthorizationDataStoreService(LaboratoryAPI.BaseUrl);
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
                await DisplayAlert("Предупреждение",
                    "Не указан логин или пароль. " +
                    "Укажите логин или пароль, " +
                    "прежде чем авторизоваться",
                    "ОК");
                return;
            }
            string json = "{\"Login\":\""
                + Login.Text
                + "\",\"password\":\""
                + Password.Text
                + "\"}";
            ResponsePatient response = await _dataStore.CreateAsync(json);
            if (response == null)
            {
                await DisplayAlert("Предупреждение",
                   "Неверный логин или пароль. " +
                   "Проверьте правильность ввода. " +
                   "Регистр логина не важен, а регистр пароля важен",
                   "ОК");
                return;
            }
            await DisplayAlert("Информация",
               "Вы успешно авторизованы",
               "ОК");
        }
    }
}