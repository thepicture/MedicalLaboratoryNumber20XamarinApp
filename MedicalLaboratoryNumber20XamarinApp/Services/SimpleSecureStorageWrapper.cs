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
            if (value == null)
            {
                _ = SecureStorage.Remove(key);
                return;
            }
            await SecureStorage.SetAsync(key, value);
        }
    }
}
