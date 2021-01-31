using System.Threading.Tasks;
using MekashronDomain.Models;
using MekashronDomain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MekashronUnitTests
{
    [TestClass]
    public class AccountTest
    {
        private readonly AccountService _service;

        public AccountTest()
        {
            _service = new AccountService();
        }

        [TestMethod]
        public async Task LoginFunction()
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
    }
}
