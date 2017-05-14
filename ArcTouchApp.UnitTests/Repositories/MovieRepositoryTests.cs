using ArcTouchApp.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace ArcTouchApp.UnitTests.Repositories
{
    [TestClass]
    public class MovieRepositoryTests
    {
        private IMovieRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            _repository = new MovieRepository();
        }

        [TestMethod]
        public async Task Must_Returns_Upcoming_Movies()
        {
            var actual = await _repository.GetUpcomingMoviesAsync();

            Assert.IsNotNull(actual);
            Assert.AreEqual(20, actual.Count());
        }

        [TestMethod]
        public async Task Must_Returns_Guardians_of_the_Galaxy_Vol_2()
        {
            var actual = await _repository.GetMovieAsync(283995);

            Assert.IsNotNull(actual);
            Assert.AreEqual("Guardians of the Galaxy Vol. 2", actual.title);
        }

        [TestMethod]
        public async Task Must_Returns_Resident_Evil_Movies()
        {
            var actual = await _repository.SearchMovieByTitle("Resident Evil");

            Assert.IsNotNull(actual);
            Assert.AreNotEqual(0, actual.Count());
            Assert.IsTrue(actual.Any(m => m.title.Contains("Apocalypse")));
        }
    }
}