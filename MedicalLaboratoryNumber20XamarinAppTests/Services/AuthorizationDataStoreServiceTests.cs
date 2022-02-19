using MedicalLaboratoryNumber20XamarinApp.Models;
using MedicalLaboratoryNumber20XamarinApp.Models.ResponseModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace MedicalLaboratoryNumber20XamarinApp.Services.Tests
{
    [TestClass()]
    public class AuthorizationDataStoreServiceTests
    {
        public static AuthorizationDataStoreService service =
            new AuthorizationDataStoreService(LaboratoryAPI
                .BaseUrl
                .Replace("10.0.2.2", "127.0.0.1"));

        [TestMethod]
        public async Task CreateAsync_LoginIsGdunkerly0_PassportNumberIs129038()
        {
            // Arrange.
            string expected = "129038";
            string json = "{\"Login\":\"gdunkerly0\",\"password\":\"IGU2Q1qifXuf\"}";

            // Act.
            ResponsePatient patient = await service.CreateAsync(json);
            string actual = patient.PassportNumber;

            // Assert.
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task CreateAsync_LoginIsEmpty_ReturnsNull()
        {
            // Arrange.
            ResponsePatient expected = null;
            string json = "{\"password\":\"IGU2Q1qifXuf\"}";

            // Act.
            ResponsePatient actual = await service.CreateAsync(json);

            // Assert.
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task CreateAsync_PasswordIsEmpty_ReturnsNull()
        {
            // Arrange.
            ResponsePatient expected = null;
            string json = "{\"Login\":\"gdunkerly0\"}";

            // Act.
            ResponsePatient actual = await service.CreateAsync(json);

            // Assert.
            Assert.AreEqual(expected, actual);
        }
    }
}