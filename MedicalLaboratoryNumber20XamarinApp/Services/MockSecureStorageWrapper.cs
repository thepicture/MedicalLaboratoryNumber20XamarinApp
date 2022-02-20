using System.Threading.Tasks;

namespace MedicalLaboratoryNumber20XamarinApp.Services
{
    public class MockSecureStorageWrapper : ISecureStorageWrapper
    {
        private string _value;
        public async Task<string> GetAsync(string key)
        {
            return await Task.FromResult<string>(_value);
        }

        public async Task SetAsync(string key, string value)
        {
            _value = value;
        }
    }
}
