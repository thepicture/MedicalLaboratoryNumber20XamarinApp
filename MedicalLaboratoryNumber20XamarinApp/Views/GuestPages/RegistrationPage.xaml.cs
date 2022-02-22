using MedicalLaboratoryNumber20XamarinApp.Models.RequestModels;
using MedicalLaboratoryNumber20XamarinApp.Services;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalLaboratoryNumber20XamarinApp.Views.GuestPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        private const string FullNameRegex = @"\w+ \w+( \w+)?";
        private readonly IFeedback _feedback = new DisplayAlertFeedback();

        public RequestPatient CurrentUser { get; set; }
        public RegistrationPage()
        {
            InitializeComponent();
            BindingContext = this;
            CurrentUser = new RequestPatient();
            CurrentUser.Credentials = new RequestCredentials();
        }

        /// <summary>
        /// Осуществляет регистрацию.
        /// </summary>
        private async void PerformRegisterAsync(object sender, EventArgs e)
        {
            StringBuilder validationErrors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(CurrentUser.FullName) || !Regex.IsMatch(CurrentUser.FullName, FullNameRegex))
            {
                _ = validationErrors.AppendLine("ФИО должно быть предоставлено в формате " +
                    "[фамилия] [имя] [отчество]. Отчество можно опустить, " +
                    "если его нет");
            }
            if (string.IsNullOrWhiteSpace(CurrentUser.PassportNumber))
            {
                _ = validationErrors.AppendLine("Укажите номер паспорта. " +
                    "Номер паспорта - это число, " +
                    "состоящее от 1 до 6 цифр");
            }
            if (string.IsNullOrWhiteSpace(CurrentUser.PassportSeries))
            {
                _ = validationErrors.AppendLine("Укажите серию паспорта. " +
                    "Серия паспорта - это число, " +
                    "состоящее от 1 до 4 цифр");
            }
            if (string.IsNullOrWhiteSpace(CurrentUser.Phone))
            {
                _ = validationErrors.AppendLine("Укажите телефон");
            }
            if (string.IsNullOrWhiteSpace(CurrentUser.Email))
            {
                _ = validationErrors.AppendLine("Укажите email");
            }
            if (CurrentUser.BirthDate == null
                || string.IsNullOrWhiteSpace(CurrentUser.BirthDate)
                || CurrentUser.BirthDateAsDateTime >= DateTime.Now)
            {
                _ = validationErrors.AppendLine("Укажите корректную дату рождения");
            }
            if (string.IsNullOrWhiteSpace(CurrentUser.SecurityNumber))
            {
                _ = validationErrors.AppendLine("Укажите номер страхового полиса");
            }
            if (string.IsNullOrWhiteSpace(CurrentUser.SecurityNumber))
            {
                _ = validationErrors.AppendLine("Укажите номер страхового полиса");
            }
            if (CurrentUser.Credentials.Login == null
               || CurrentUser.Credentials.Login.Length > 100
               || CurrentUser.Credentials.Login.Any(c => ": ".Contains(c)))
            {
                _ = validationErrors.AppendLine("Логин обязателен " +
                    "длиной не больше 100 символов " +
                    "и не должен содержать двоеточие или пробел");
            }
            if (CurrentUser.Credentials.Password == null
                || CurrentUser.Credentials.Password.Length > 100
                || CurrentUser.Credentials.Password.Any(c => ": ".Contains(c)))
            {
                _ = validationErrors.AppendLine("Пароль обязателен " +
                    "длиной не больше 100 символов " +
                    "и не должен содержать двоеточие или пробел");
            }

            if (validationErrors.Length > 0)
            {
                await _feedback.WarnAsync(validationErrors.ToString());
                return;
            }

        }
    }
}