using System;

namespace MedicalLaboratoryNumber20XamarinApp.Models.ResponseModels
{
    public class ResponsePatient
    {
        public string FullName { get; set; }
        public string BirthDate { get; set; }
        public string PassportNumber { get; set; }
        public string PassportSeries { get; set; }
        public string SecurityNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime BirthDateAsDateTime
            => DateTime.Parse(BirthDate);
    }
}