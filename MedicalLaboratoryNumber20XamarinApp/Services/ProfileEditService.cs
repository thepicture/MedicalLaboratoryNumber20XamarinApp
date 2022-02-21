using MedicalLaboratoryNumber20XamarinApp.Models.Exceptions;
using MedicalLaboratoryNumber20XamarinApp.Models.RequestModels;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace MedicalLaboratoryNumber20XamarinApp.Services
{
    /// <summary>
    /// Реализует методы для изменения профиля пациента.
    /// </summary>
    public static class ProfileEditService
    {
        /// <summary>
        /// Изменяет профиль пациента.
        /// </summary>
        /// <param name="patient">Пациент.</param>
        public static async Task<bool> EditProfile(RequestPatient patient, string baseUri)
        {
            using (HttpClient client = new HttpClient())
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string jsonPatient = serializer.Serialize(patient);
                StringContent content = new StringContent(jsonPatient);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = new HttpMethod("PATCH"),
                    RequestUri = new Uri($"{baseUri}/sessions/edit"),
                    Content = content
                };
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    string reason = response.ReasonPhrase;
                    throw new EditProfileException(reason);
                }
            }
            return await Task<bool>.FromResult(true);
        }
    }
}
