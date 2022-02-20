using System.Threading.Tasks;

namespace MedicalLaboratoryNumber20XamarinApp.Services
{
    public interface ISecureStorageWrapper
    {
        Task SetAsync(string key, string value);
        Task<string> GetAsync(string key);
    }
}
