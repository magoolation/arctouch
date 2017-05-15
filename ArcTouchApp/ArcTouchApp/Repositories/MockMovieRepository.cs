using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArcTouchApp.DTOS;
using System.IO;
using PCLStorage;
using Newtonsoft.Json;

namespace ArcTouchApp.Repositories
{
    public class MockMovieRepository : IMovieRepository
    {
        public async Task<MovieDTO> GetMovieAsync(int id = 1)
        {
            string content = ResourceHelper.LoadFile("movie.json");
            return JsonConvert.DeserializeObject<MovieDTO>(content);
        }

        public async Task<IEnumerable<MovieInfoDTO>> GetUpcomingMoviesAsync(int page = 1)
        {
            string content = ResourceHelper.LoadFile("upcoming.json");
            return JsonConvert.DeserializeObject<UpcomingMoviesDTO>(content).results;
        }

        public async Task<IEnumerable<SearchResultDTO>> SearchMovieByTitle(string title)
        {
            string content = ResourceHelper.LoadFile("search.json");
            return JsonConvert.DeserializeObject<SearchMovieResultsDTO>(content).results;
        }
    }
}
