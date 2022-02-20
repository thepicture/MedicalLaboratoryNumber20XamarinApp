using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MedicalLaboratoryNumber20XamarinApp.Services
{
    public class SimpleSecureStorageWrapper : ISecureStorageWrapper
    {
        public async Task<string> GetAsync(string key)
        {
            return await SecureStorage.GetAsync(key);
        }

        public async Task SetAsync(string key, string value)
        {
            await SecureStorage.SetAsync(key, value);
        }
    }
}
