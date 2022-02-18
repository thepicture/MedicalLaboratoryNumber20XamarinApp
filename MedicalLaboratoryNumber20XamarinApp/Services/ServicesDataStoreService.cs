using MedicalLaboratoryNumber20XamarinApp.Models;
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
        public async Task<bool> CreateAsync<TRequestBody>(TRequestBody body)
        {
            return await Task.FromResult(false);
        }

        public async Task<IEnumerable<ResponseService>> ReadAllAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client
                    .GetAsync($"{LaboratoryAPI.BaseUrl}/services");
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
                    .GetAsync($"{LaboratoryAPI.BaseUrl}/services/{id}");
                Stream content = await response.Content.ReadAsStreamAsync();
                DataContractJsonSerializer serializer =
                    new DataContractJsonSerializer(typeof(ResponseService));
                ResponseService result =
                    (ResponseService)serializer
                    .ReadObject(content);
                return result;
            }
        }

        public async Task<bool> UpdateAsync<TRequestBody>(string id, TRequestBody body)
        {
            return await Task.FromResult(false);
        }
    }
}
