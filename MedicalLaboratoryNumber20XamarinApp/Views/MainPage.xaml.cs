using Xamarin.Essentials;
using Xamarin.Forms;

namespace MedicalLaboratoryNumber20XamarinApp
{
    public partial class MainPage : ContentPage
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
        public MainPage()
        {
            InitializeComponent();
            SetTitle();
        }

        private async void SetTitle()
        {
            IsAuthorized = await SecureStorage.GetAsync("User") != null;
        }
    }
}
