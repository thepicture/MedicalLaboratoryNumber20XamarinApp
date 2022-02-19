using MedicalLaboratoryNumber20XamarinApp.Models.ResponseModels;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace MedicalLaboratoryNumber20XamarinApp.Services
{
    public class AuthorizationDataStoreService : IDataStoreService<ResponsePatient>
    {
        private readonly string _baseUrl;

        public AuthorizationDataStoreService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<ResponsePatient> CreateAsync(string body)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent requestContent = new StringContent(body);
                requestContent.Headers.ContentType =
                    new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await client
                    .PostAsync($"{_baseUrl}/sessions/login", requestContent);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return null;
                }

                Stream responseContent = await response.Content.ReadAsStreamAsync();
                DataContractJsonSerializer serializer =
                    new DataContractJsonSerializer(typeof(ResponsePatient));
                ResponsePatient result =
                    (ResponsePatient)serializer
                    .ReadObject(responseContent);
                return result;
            }
        }

        public async Task<IEnumerable<ResponsePatient>> ReadAllAsync()
        {
            return await Task.FromResult<IEnumerable<ResponsePatient>>(null);
        }

        public async Task<ResponsePatient> ReadSingleAsync(string id)
        {
            return await Task.FromResult<ResponsePatient>(null);
        }

        public async Task<bool> UpdateAsync(string id, string body)
        {
            return await Task.FromResult(false);
        }
    }
}
