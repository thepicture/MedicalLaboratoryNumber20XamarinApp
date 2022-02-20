using System.Threading.Tasks;

namespace MedicalLaboratoryNumber20XamarinApp.Services
{
    public class DisplayAlertFeedback : IFeedback
    {
        private const string Close = "Закрыть";
        private const string Yes = "Да";
        private const string No = "Нет";
        public async Task<bool> AskAsync(string message)
        {
            return await App.Current.MainPage.DisplayAlert("Подтвердить действие",
                                                           message,
                                                           Yes, No);
        }

        public async Task InformAsync(string message)
        {
            await App.Current.MainPage.DisplayAlert("Информация",
                                                        message,
                                                        Close);
        }

        public async Task InformErrorAsync(string message)
        {
            await App.Current.MainPage.DisplayAlert("Ошибка",
                                                       message,
                                                       Close);
        }

        public async Task WarnAsync(string message)
        {
            await App.Current.MainPage.DisplayAlert("Предупреждение",
                                                       message,
                                                       Close);
        }
    }
}
