using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArcTouchApp.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Refit;

namespace ArcTouchApp.UnitTests.Repositories
{
    [TestClass]
    public class GenreRepositoryTests
    {
        private ITheMovieDatabaseRepository _repository;        

        [TestInitialize]
        public void Setup()
        {
            _repository = RestService.For<ITheMovieDatabaseRepository>(Constants.API_URL);
        }

        [TestMethod]
        public async Task Must_Returns_Genre_List()
        {
            var actual = await _repository.GetGenreListAsync(Constants.API_KEY);

            Assert.IsNotNull(actual);
            Assert.AreNotEqual(0, actual.genres.Length);
        }
    }
}