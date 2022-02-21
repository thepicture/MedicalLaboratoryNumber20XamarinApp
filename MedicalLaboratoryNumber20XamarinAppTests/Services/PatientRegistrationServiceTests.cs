using MedicalLaboratoryNumber20XamarinApp.Models.Exceptions;
using MedicalLaboratoryNumber20XamarinApp.Models.RequestModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace MedicalLaboratoryNumber20XamarinApp.Services.Tests
{
    [TestClass()]
    public class PatientRegistrationServiceTests
    {
        public string MockUri = MedicalLaboratoryNumber20XamarinApp.Models
            .LaboratoryAPI
            .BaseUrl
            .Replace("10.0.2.2", "127.0.0.1");

        [TestMethod()]
        [ExpectedException(typeof(RegistrationException))]
        public async Task RegisterTest_NoFullName_ThrowsException()
        {
            // Arrange.
            RequestPatient patient = new RequestPatient
            {
                Credentials = new RequestCredentials
                {
                    Login = Guid.NewGuid().ToString(),
                    Password = Guid.NewGuid().ToString(),
                },
                FullName = null,
                BirthDate = DateTime.Now.ToString(),
                Email = Guid.NewGuid().ToString(),
                PassportNumber = "123456",
                PassportSeries = "1234",
                Password = null,
                Phone = Guid.NewGuid().ToString(),
                SecurityNumber = Guid.NewGuid().ToString()
            };

            // Act.
            _ = await PatientRegistrationService.Register(patient, MockUri);
        }

        [TestMethod()]
        [ExpectedException(typeof(RegistrationException))]
        public async Task RegisterTest_NoCredentials_ThrowsException()
        {
            // Arrange.
            RequestPatient patient = new RequestPatient
            {
                FullName = Guid.NewGuid().ToString(),
                BirthDate = DateTime.Now.ToString(),
                Email = Guid.NewGuid().ToString(),
                PassportNumber = "123456",
                PassportSeries = "1234",
                Password = null,
                Phone = Guid.NewGuid().ToString(),
                SecurityNumber = Guid.NewGuid().ToString()
            };

            // Act.
            _ = await PatientRegistrationService.Register(patient, MockUri);
        }

        [TestMethod()]
        public async Task RegisterTest_AllPresented_ReturnsTrue()
        {
            // Arrange.
            bool actual = true;
            RequestPatient patient = new RequestPatient
            {
                Credentials = new RequestCredentials
                {
                    Login = Guid.NewGuid().ToString(),
                    Password = Guid.NewGuid().ToString(),
                },
                FullName = Guid.NewGuid().ToString(),
                BirthDate = DateTime.Now.ToString(),
                Email = Guid.NewGuid().ToString(),
                PassportNumber = "123456",
                PassportSeries = "1234",
                Password = null,
                Phone = Guid.NewGuid().ToString(),
                SecurityNumber = Guid.NewGuid().ToString()
            };

            // Act.
            bool expected = await PatientRegistrationService.Register(patient, MockUri);

            // Assert.
            Assert.AreEqual(expected, actual);
        }
    }
}