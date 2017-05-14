using ArcTouchApp.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ArcTouchApp.UnitTests.Repositories
{
    [TestClass]
    public class ConfigurationsRepository
    {
        private IConfigurationRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            _repository = new ConfigurationRepository();
        }

        [TestMethod]
        public async Task  Must_Returns_API_Configurations()
        {
            var actual = await _repository.GetConfigurationsAsync();

            Assert.IsNotNull(actual);
            Assert.AreNotEqual(0, actual.change_keys.Length);
        }
    }
}
