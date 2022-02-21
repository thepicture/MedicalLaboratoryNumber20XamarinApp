
using MedicalLaboratoryNumber20XamarinApp.Models;
using MedicalLaboratoryNumber20XamarinApp.Models.RequestModels;
using MedicalLaboratoryNumber20XamarinApp.Models.ResponseModels;
using MedicalLaboratoryNumber20XamarinApp.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalLaboratoryNumber20XamarinApp.Views.AuthorizedPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        private RequestPatient _currentUser;
        private readonly IFeedback _feedback = new DisplayAlertFeedback();
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = this;
            _ = LoadUser();
        }

        private async Task LoadUser()
        {
            CurrentUser = await SessionService.GetSessionAsync();
            CurrentUser.Password = CurrentUser.Credentials.Password;
            OnPropertyChanged(nameof(CurrentUser));
        }

        public RequestPatient CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        private async void PerformSavingProfile(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CurrentUser.Phone)
                || CurrentUser.Phone.Length > 50)
            {
                await _feedback.WarnAsync("Необходимо обязательно " +
                    "указать корректный телефон");
                return;
            }
            if (string.IsNullOrWhiteSpace(CurrentUser.Email)
                || CurrentUser.Email.Length > 50)
            {
                await _feedback.WarnAsync("Необходимо обязательно " +
                    "указать корректный телефон");
                return;
            }
            if (string.IsNullOrWhiteSpace(CurrentUser.Credentials.Password)
                || CurrentUser.Password.Length > 50)
            {
                await _feedback.WarnAsync("Необходимо обязательно " +
                    "указать корректный пароль");
                return;
            }
            try
            {
                if (await ProfileEditService.EditProfile(CurrentUser, LaboratoryAPI.BaseUrl))
                {
                    ResponsePatient patient = new ResponsePatient
                    {
                        FullName = CurrentUser.FullName,
                        BirthDate = CurrentUser.BirthDate,
                        Email = CurrentUser.Email,
                        PassportNumber = CurrentUser.PassportNumber,
                        PassportSeries = CurrentUser.PassportSeries,
                        Phone = CurrentUser.Phone,
                        SecurityNumber = CurrentUser.SecurityNumber
                    };

                    CurrentUser.Credentials.Password = CurrentUser.Password;
                    await SessionService.SetSessionAsync(patient, CurrentUser.Credentials);
                    await _feedback.InformAsync("Профиль успешно изменён!");
                }
            }
            catch (Exception)
            {
                await _feedback.InformErrorAsync("Не удалось " +
                     "изменить профиль. " +
                     "Вероятно, отсутствует доступ к сети");
            }
        }
    }
}