
using MedicalLaboratoryNumber20XamarinApp.Models.RequestModels;
using MedicalLaboratoryNumber20XamarinApp.Services;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalLaboratoryNumber20XamarinApp.Views.AuthorizedPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        private RequestPatient _currentUser;
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = this;
            _ = LoadUser();
        }

        private async Task LoadUser()
        {
            CurrentUser = await SessionService.GetSessionAsync();
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
    }
}