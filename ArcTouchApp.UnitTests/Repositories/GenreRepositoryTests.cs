using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArcTouchApp.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace ArcTouchApp.UnitTests.Repositories
{
    [TestClass]
    public class GenreRepositoryTests
    {
        private IGenreRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            _repository = new GenreRepository();
        }

        [TestMethod]
        public async Task Must_Returns_Genre_List()
        {
            var actual = await _repository.GetGenreListAsync();

            Assert.IsNotNull(actual);
            Assert.AreNotEqual(0, actual.Count());
        }
    }
}