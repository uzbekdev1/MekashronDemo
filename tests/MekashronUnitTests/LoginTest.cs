using System.Globalization;
using System.Threading.Tasks;
using MekashronDomain.Models;
using MekashronDomain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MekashronUnitTests
{
    [TestClass]
    public class LoginTest
    {
        private readonly AccountService _service;

        public LoginTest()
        {
            _service = new AccountService();
        }

        [TestMethod]
        public async Task One_Time_Testing()
        {
            // Arrange
            var request = new LoginRequest
            {
                UserName = "elyor.dev@gmail.com",
                Password = "web@1234"
            };

            // Act 
            var item = await _service.Login(request);

            // Assert
            Assert.IsTrue(item.IsSuccess);
            Assert.AreEqual(item.ResultData.Email, request.UserName);
        }

        [TestMethod]
        [DataRow("elyor.dev@gmail.com", "web@1234")]
        [DataRow("elyor.dev@gmail.com", "web@1234")]
        [DataRow("elyor.dev@gmail.com", "web@1234")]
        [DataRow("elyor.dev@gmail.com", "web@1234")]
        public async Task Bulk_Data_Testing(string userName,string password)
        {
            // Arrange
            var request = new LoginRequest
            {
                UserName = userName,
                Password = password
            };

            // Act 
            var item = await _service.Login(request);

            // Assert
            Assert.IsTrue(item.IsSuccess);
            Assert.AreEqual(item.ResultData.Email, request.UserName);
        }
    }
}
