using MedicalLaboratoryNumber20XamarinApp.Models.Exceptions;
using MedicalLaboratoryNumber20XamarinApp.Models.RequestModels;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace MedicalLaboratoryNumber20XamarinApp.Services
{
    /// <summary>
    /// Реализует метод для регистрации пациента.
    /// </summary>
    public static class PatientRegistrationService
    {
        /// <summary>
        /// Регистрирует пациента.
        /// </summary>
        /// <param name="patient">Пациент.</param>
        /// <param name="baseUri">Идентификатор ресурса.</param>
        /// <returns></returns>
        public static async Task<bool> Register(RequestPatient patient, string baseUri)
        {
            using (HttpClient client = new HttpClient())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(RequestPatient));
                using (MemoryStream ms = new MemoryStream())
                {
                    serializer.WriteObject(ms, patient);
                    using (StreamReader sr = new StreamReader(ms))
                    {
                        ms.Position = 0;
                        string jsonPatient = sr.ReadToEnd();

                        StringContent content = new StringContent(jsonPatient);
                        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        HttpResponseMessage response = await client.PostAsync($"{baseUri}/sessions/register",
                                                                              content);
                        if (response.StatusCode != System.Net.HttpStatusCode.OK)
                        {
                            string reason = response.ReasonPhrase;
                            throw new RegistrationException(reason);
                        }
                    }
                }
            }
            return await Task<bool>.FromResult(true);
        }
    }
}
