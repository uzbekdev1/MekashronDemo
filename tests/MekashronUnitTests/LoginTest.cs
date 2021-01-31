using System.Diagnostics;
using System.Threading.Tasks;
using MekashronDomain.Models;
using MekashronDomain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MekashronUnitTests
{
    /// <summary>
    /// Login functions
    /// </summary>
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
            var response = await _service.Login(request);

            // Assert
            Assert.IsTrue(response.IsSuccess);
            Assert.AreEqual(response.ResultData.Email, request.UserName);
        }

        [TestMethod]
        [DataRow("elyor@outlook.com", "web@1234")]
        public async Task Error_Data_Testing(string userName, string password)
        {
            // Arrange
            var request = new LoginRequest
            {
                UserName = userName,
                Password = password
            };

            // Act 
            var response = await _service.Login(request);

            // Assert
            Assert.IsFalse(response.IsSuccess);
            Assert.IsNotNull(response.ErrorMessage);

            #if DEBUG
                    Trace.WriteLine(response.ErrorMessage);
            #endif
        }
    }
}
