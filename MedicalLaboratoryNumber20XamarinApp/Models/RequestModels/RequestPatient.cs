using System;

namespace MedicalLaboratoryNumber20XamarinApp.Models.RequestModels
{
    public class RequestPatient
    {
        public RequestCredentials Credentials { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        #region not mandatory
        public string FullName { get; set; }
        public string BirthDate { get; set; }
        public string PassportNumber { get; set; }
        public string PassportSeries { get; set; }
        public string SecurityNumber { get; set; }
        public DateTime BirthDateAsDateTime
        {
            get
            {
                if (BirthDate == null)
                {
                    return DateTime.Now;
                }
                return DateTime.Parse(BirthDate);
            }
        }

        public int Age => DateTime.Now.Year - BirthDateAsDateTime.Year;
        #endregion
    }
}