using MedicalLaboratoryNumber20XamarinApp.Models.ResponseModels;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace MedicalLaboratoryNumber20XamarinApp.Services
{
    public class ServicesDataStoreService : IDataStoreService<ResponseService>
    {
        private readonly string _baseUrl;

        public ServicesDataStoreService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<ResponseService> CreateAsync(string body)
        {
            return await Task.FromResult<ResponseService>(null);
        }

        public async Task<IEnumerable<ResponseService>> ReadAllAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client
                    .GetAsync($"{_baseUrl}/services");
                Stream content = await response.Content.ReadAsStreamAsync();
                DataContractJsonSerializer serializer =
                    new DataContractJsonSerializer(typeof(IEnumerable<ResponseService>));
                IEnumerable<ResponseService> result =
                    (IEnumerable<ResponseService>)serializer
                    .ReadObject(content);
                return result;
            }
        }

        public async Task<ResponseService> ReadSingleAsync(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client
                    .GetAsync($"{_baseUrl}/services/{id}");
                Stream content = await response.Content.ReadAsStreamAsync();
                DataContractJsonSerializer serializer =
                    new DataContractJsonSerializer(typeof(ResponseService));
                ResponseService result =
                    (ResponseService)serializer
                    .ReadObject(content);
                return result;
            }
        }

        public async Task<bool> UpdateAsync(string id, string body)
        {
            return await Task.FromResult(false);
        }
    }
}
