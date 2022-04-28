using ArcTouchApp.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refit;
using System.Threading.Tasks;

namespace ArcTouchApp.UnitTests.Repositories
{
    [TestClass]
    public class ConfigurationsRepository
    {
        private ITheMovieDatabaseRepository _repository;        

        [TestInitialize]
        public void Setup()
        {
            _repository = RestService.For<ITheMovieDatabaseRepository>(Constants.API_URL);            
        }

        [TestMethod]
        public async Task  Must_Returns_API_Configurations()
        {
            var actual = await _repository.GetAPIConfigurationsAsync(Constants.API_KEY);

            Assert.IsNotNull(actual);
            Assert.AreNotEqual(0, actual.change_keys.Length);
        }
    }
}
