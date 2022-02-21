using System;
using System.Runtime.Serialization;

namespace MedicalLaboratoryNumber20XamarinApp.Models.Exceptions
{
    public class EditProfileException : Exception
    {
        public EditProfileException()
        {
        }

        public EditProfileException(string message) : base(message)
        {
        }

        public EditProfileException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EditProfileException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
