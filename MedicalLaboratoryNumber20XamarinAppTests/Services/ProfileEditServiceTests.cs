using MedicalLaboratoryNumber20XamarinApp.Models;
using MedicalLaboratoryNumber20XamarinApp.Models.Exceptions;
using MedicalLaboratoryNumber20XamarinApp.Models.RequestModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace MedicalLaboratoryNumber20XamarinApp.Services.Tests
{
    [TestClass()]
    public class ProfileEditServiceTests
    {
        public string MockUrl = LaboratoryAPI.BaseUrl
            .Replace("10.0.2.2", "127.0.0.1");
        [TestMethod()]
        [ExpectedException(typeof(EditProfileException))]
        public async Task EditProfileTest_EditLeadsToEmptyPhone_ThrowsException()
        {
            // Arrange.
            RequestPatient patient = new RequestPatient
            {
                Credentials = new RequestCredentials
                {
                    Login = "gdunkerly0",
                    Password = "IGU2Q1qifXuf"
                },
                Email = Guid.NewGuid().ToString(),
                Password = Guid.NewGuid().ToString()
            };
            // Act.
            _ = await ProfileEditService.EditProfile(patient, MockUrl);
        }

        [TestMethod()]
        [ExpectedException(typeof(EditProfileException))]
        public async Task EditProfileTest_EditLeadsToEmptyEmail_ThrowsException()
        {
            // Arrange.
            RequestPatient patient = new RequestPatient
            {
                Credentials = new RequestCredentials
                {
                    Login = "gdunkerly0",
                    Password = "IGU2Q1qifXuf"
                },
                Phone = Guid.NewGuid().ToString(),
                Password = Guid.NewGuid().ToString()
            };
            // Act.
            _ = await ProfileEditService.EditProfile(patient, MockUrl);
        }

        [TestMethod()]
        [ExpectedException(typeof(EditProfileException))]
        public async Task EditProfileTest_EditLeadsToEmptyPassword_ThrowsException()
        {
            // Arrange.
            RequestPatient patient = new RequestPatient
            {
                Credentials = new RequestCredentials
                {
                    Login = "gdunkerly0",
                    Password = "IGU2Q1qifXuf"
                },
                Phone = Guid.NewGuid().ToString(),
                Email = Guid.NewGuid().ToString()
            };
            // Act.
            _ = await ProfileEditService.EditProfile(patient, MockUrl);
        }

        [TestMethod()]
        [ExpectedException(typeof(EditProfileException))]
        public async Task EditProfileTest_NoCredentialsPresented_ThrowsException()
        {
            // Arrange.
            RequestPatient patient = new RequestPatient
            {
                Phone = Guid.NewGuid().ToString(),
                Email = Guid.NewGuid().ToString(),
                Password = Guid.NewGuid().ToString()
            };
            // Act.
            _ = await ProfileEditService.EditProfile(patient, MockUrl);
        }

        [TestMethod()]
        [ExpectedException(typeof(EditProfileException))]
        public async Task EditProfileTest_NoBirthDatePresented_ThrowsException()
        {
            // Arrange.
            RequestPatient patient = new RequestPatient
            {
                Credentials = new RequestCredentials
                {
                    Login = "gdunkerly0",
                    Password = "IGU2Q1qifXuf"
                },
                Phone = Guid.NewGuid().ToString(),
                Email = Guid.NewGuid().ToString(),
                Password = Guid.NewGuid().ToString()
            };
            // Act.
            _ = await ProfileEditService.EditProfile(patient, MockUrl);
        }

        [TestMethod()]
        public async Task EditProfileTest_SuccessfulEditing_ReturnsTrue()
        {
            // Arrange.
            bool expected = true;
            RequestPatient patient = new RequestPatient
            {
                Credentials = new RequestCredentials
                {
                    Login = "gdunkerly0",
                    Password = "IGU2Q1qifXuf"
                },
                BirthDate = DateTime.Now.ToString(),
                Phone = Guid.NewGuid().ToString(),
                Email = Guid.NewGuid().ToString(),
                Password = "IGU2Q1qifXuf"
            };

            // Act.
            bool actual = await ProfileEditService.EditProfile(patient, MockUrl);

            // Assert.
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(EditProfileException))]
        public async Task EditProfileTest_IncorrectCredentials_ThrowsException()
        {
            // Arrange.
            RequestPatient patient = new RequestPatient
            {
                Credentials = new RequestCredentials
                {
                    Login = "gdunkerly0",
                    Password = "IGU2Q1qifXuf__"
                },
                BirthDate = DateTime.Now.ToString(),
                Phone = Guid.NewGuid().ToString(),
                Email = Guid.NewGuid().ToString(),
                Password = "IGU2Q1qifXuf"
            };

            // Act.
            _ = await ProfileEditService.EditProfile(patient, MockUrl);
        }
    }
}