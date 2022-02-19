using MedicalLaboratoryNumber20XamarinApp.Models.ResponseModels;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace MedicalLaboratoryNumber20XamarinApp.Services
{
    public class NewsDataStoreService : IDataStoreService<ResponseNews>
    {
        private readonly string _baseUrl;

        public NewsDataStoreService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<ResponseNews> CreateAsync(string body)
        {
            return await Task.FromResult<ResponseNews>(null);
        }

        public async Task<IEnumerable<ResponseNews>> ReadAllAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client
                    .GetAsync($"{_baseUrl}/news");
                Stream content = await response.Content.ReadAsStreamAsync();
                DataContractJsonSerializer serializer =
                    new DataContractJsonSerializer(typeof(IEnumerable<ResponseNews>));
                IEnumerable<ResponseNews> result =
                    (IEnumerable<ResponseNews>)serializer
                    .ReadObject(content);
                return result;
            }
        }

        public async Task<ResponseNews> ReadSingleAsync(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client
                    .GetAsync($"{_baseUrl}/news/{id}");
                Stream content = await response.Content.ReadAsStreamAsync();
                DataContractJsonSerializer serializer =
                    new DataContractJsonSerializer(typeof(ResponseNews));
                ResponseNews result =
                    (ResponseNews)serializer
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
