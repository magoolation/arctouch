using ArcTouchApp.DTOS;
using Refit;
using System.Threading.Tasks;

namespace ArcTouchApp.Repositories
{
    public interface ITheMovieDatabaseRepository
    {
        [Get("/movie/upcoming?page={page}&api_key={key}")]
        Task<UpcomingMoviesDTO> GetUpcomingMoviesAsync(int page, string key);

        [Get("/movie/{id}?api_key={key}")]
        Task<MovieInfoDTO> GetMovieAsync(int id, string key);

        [Get("/search/movie?query={criteria}&page={page}&api_key={key}")]
        Task<SearchMovieResultsDTO> SearchMoviesByTitleAsync(string criteria, int page, string key);

        [Get("/genre/movie/list?api_key={key}")]
        Task<GenreListDTO> GetGenreListAsync(string key);

        [Get("/configuration?api_key={key}")]
        Task<ConfigurationsDTO> GetAPIConfigurationsAsync(string key);
    }
}
