using ArcTouchApp.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refit;
using System.Linq;
using System.Threading.Tasks;

namespace ArcTouchApp.UnitTests.Repositories
{
    [TestClass]
    public class MovieRepositoryTests
    {
        private ITheMovieDatabaseRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            _repository = RestService.For<ITheMovieDatabaseRepository>(Constants.API_URL);
        }

        [TestMethod]
        public async Task Must_Returns_Upcoming_Movies()
        {
            var actual = await _repository.GetUpcomingMoviesAsync(1, Constants.API_KEY);

            Assert.IsNotNull(actual);
            Assert.AreEqual(20, actual.results.Length);
        }

        [TestMethod]
        public async Task Must_Returns_Guardians_of_the_Galaxy_Vol_2()
        {
            var actual = await _repository.GetMovieAsync(283995, Constants.API_KEY);

            Assert.IsNotNull(actual);
            Assert.AreEqual("Guardians of the Galaxy Vol. 2", actual.title);
        }

        [TestMethod]
        public async Task Must_Returns_Resident_Evil_Movies()
        {
            var actual = await _repository.SearchMoviesByTitleAsync("Resident Evil", 1, Constants.API_KEY);

            Assert.IsNotNull(actual);
            Assert.AreNotEqual(0, actual.results.Length);
            Assert.IsTrue(actual.results.Any(m => m.title.Contains("Apocalypse")));
        }
    }
}