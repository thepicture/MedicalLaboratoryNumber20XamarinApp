using MedicalLaboratoryNumber20XamarinApp.Models;
using MedicalLaboratoryNumber20XamarinApp.Models.ResponseModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalLaboratoryNumber20XamarinApp.Services.Tests
{
    [TestClass()]
    public class NewsDataStoreServiceTests
    {
        public static NewsDataStoreService service =
            new NewsDataStoreService(LaboratoryAPI
                .BaseUrl
                .Replace("10.0.2.2", "127.0.0.1"));

        [TestMethod]
        public async Task ReadAllAsyncTest_CountOfNews_Returns2()
        {
            // Arrange.
            int expected = 3;

            // Act.
            IEnumerable<ResponseNews> response = await service.ReadAllAsync();
            int actual = response.Count();

            // Assert.
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task ReadSingleAsyncTest_GetById3_ReturnsSuperDiscount()
        {
            // Arrange.
            string expected = "СУПЕР АКЦИЯ НА ВАКЦИНАЦИЮ!";

            // Act.
            ResponseNews response = await service.ReadSingleAsync("3");
            string actual = response.Title;

            // Assert.
            Assert.AreEqual(expected, actual);
        }
    }
}