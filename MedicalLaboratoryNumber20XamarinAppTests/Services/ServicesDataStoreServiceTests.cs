using MedicalLaboratoryNumber20XamarinApp.Models.ResponseModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalLaboratoryNumber20XamarinApp.Services.Tests
{
    [TestClass()]
    public class ServicesDataStoreServiceTests
    {
        public static ServicesDataStoreService service = new ServicesDataStoreService();

        [TestMethod]
        public async Task ReadAllAsyncTest_CountOfServices_Returns17()
        {
            // Arrange.
            int expected = 17;

            // Act.
            IEnumerable<ResponseService> response = await service.ReadAllAsync();
            int actual = response.Count();

            // Assert.
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task ReadSingleAsyncTest_GetById229_ReturnsAIDS()
        {
            // Arrange.
            string expected = "СПИД";

            // Act.
            ResponseService response = await service.ReadSingleAsync("229");
            string actual = response.Title;

            // Assert.
            Assert.AreEqual(expected, actual);
        }
    }
}