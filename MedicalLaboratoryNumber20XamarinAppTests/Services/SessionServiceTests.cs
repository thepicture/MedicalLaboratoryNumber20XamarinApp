using MedicalLaboratoryNumber20XamarinApp.Models.RequestModels;
using MedicalLaboratoryNumber20XamarinApp.Models.ResponseModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace MedicalLaboratoryNumber20XamarinApp.Services.Tests
{
    [TestClass()]
    public class SessionServiceTests
    {
        [TestMethod()]
        public async Task SetSessionAsyncTest_SetWithFullNameABC_CanGetAfter()
        {
            // Arrange.
            string expected = "ABC";
            ResponsePatient responsePatient = new ResponsePatient
            {
                FullName = "ABC",
                BirthDate = DateTime.Now.ToString(),
            };
            SessionService.SessionSecureStorage = new MockSecureStorageWrapper();

            // Act.
            await SessionService.SetSessionAsync(responsePatient, null);
            RequestPatient patient = await SessionService.GetSessionAsync();
            string actual = patient.FullName;

            // Assert.
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public async Task GetSessionAsyncTest_SetNull_ThrowsException()
        {
            // Arrange.
            SessionService.SessionSecureStorage = new MockSecureStorageWrapper();

            // Act.
            await SessionService.SetSessionAsync(null, null);
        }

        [TestMethod()]
        public async Task SetSessionAsyncTest_GetNothing_ReturnsNull()
        {
            // Arrange.
            RequestPatient expected = null;
            SessionService.SessionSecureStorage = new MockSecureStorageWrapper();

            // Act.
            RequestPatient actual = await SessionService.GetSessionAsync();

            // Assert.
            Assert.AreEqual(expected, actual);
        }
    }
}