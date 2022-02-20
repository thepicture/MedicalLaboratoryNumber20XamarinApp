using MedicalLaboratoryNumber20XamarinApp.Services;
using Xamarin.Forms;

namespace MedicalLaboratoryNumber20XamarinApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SessionService.SessionSecureStorage = new SimpleSecureStorageWrapper();
            MainPage = new NavigationPage(new OptionsPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
