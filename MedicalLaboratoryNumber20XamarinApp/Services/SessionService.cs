using MedicalLaboratoryNumber20XamarinApp.Models.RequestModels;
using MedicalLaboratoryNumber20XamarinApp.Models.ResponseModels;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MedicalLaboratoryNumber20XamarinApp.Services
{
    /// <summary>
    /// Реализует методы для работы с сессией пациента.
    /// </summary>
    public static class SessionService
    {
        public static ISecureStorageWrapper SessionSecureStorage;

        /// <summary>
        /// Сохраняет сессию асинхронно.
        /// </summary>
        /// <param name="responsePatient">Пациент.</param>
        /// <param name="credentials">Данные входа.</param>
        /// <returns></returns>
        public static async Task SetSessionAsync(
            ResponsePatient responsePatient,
            RequestCredentials credentials)
        {
            RequestPatient requestPatient = new RequestPatient
            {
                BirthDate = responsePatient.BirthDate,
                Credentials = credentials,
                Email = responsePatient.Email,
                FullName = responsePatient.FullName,
                PassportNumber = responsePatient.PassportNumber,
                PassportSeries = responsePatient.PassportSeries,
                Phone = responsePatient.Phone,
                SecurityNumber = responsePatient.SecurityNumber
            };

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(RequestPatient));
            using (StringWriter writer = new StringWriter())
            {
                xmlSerializer.Serialize(writer, requestPatient);
                await SessionSecureStorage.SetAsync("session", writer.ToString());
            }

        }

        /// <summary>
        /// Получает сессию асинхронно.
        /// </summary>
        /// <returns>Пациент.</returns>
        public static async Task<RequestPatient> GetSessionAsync()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(RequestPatient));
            string value = await SessionSecureStorage.GetAsync("session");
            if (value == null)
            {
                return null;
            }
            RequestPatient patient = (RequestPatient)xmlSerializer
                .Deserialize(new MemoryStream(Encoding.Unicode.GetBytes(value)));
            return patient;
        }
    }
}
