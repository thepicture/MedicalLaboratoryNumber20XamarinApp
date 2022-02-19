using System;

namespace MedicalLaboratoryNumber20XamarinApp.Models.ResponseModels
{
    public class ResponseNews
    {
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string PublicationDate { get; set; }
        public string NewsText { get; set; }
        public DateTime PublicationDateAsDateTime =>
            DateTime.Parse(PublicationDate);
        public string NewsTextFormatted =>
            NewsText.Replace("\\n", Environment.NewLine);
    }
}
