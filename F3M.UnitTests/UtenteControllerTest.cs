using F3M_UNITS.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace F3M.UnitTests
{
    [TestClass]
    public class UtenteControllerTest
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();
            return config;
        }
        [TestMethod]
        public void TestView()
        {
            var controller = new UtenteController(InitConfiguration());
            var result = controller.Informacao(14) as ViewResult;
            Assert.AreEqual("Informacao", result.ViewName);
        }
    }
}
