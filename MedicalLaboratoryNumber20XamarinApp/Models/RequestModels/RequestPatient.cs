using System;

namespace MedicalLaboratoryNumber20XamarinApp.Models.RequestModels
{
    public class RequestPatient
    {
        public RequestCredentials Credentials;
        public string Phone;
        public string Email;
        public string Password;
        #region not mandatory
        public string FullName;
        public string BirthDate;
        public string PassportNumber;
        public string PassportSeries;
        public string SecurityNumber;
        #endregion
    }
}