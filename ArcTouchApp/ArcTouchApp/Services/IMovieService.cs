using ArcTouchApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArcTouchApp.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieInfo>> GetUpcomingMoviesAsync(int page = 1);
        Task<Movie> GetMovieAsync(int id);
        Task<IEnumerable<MovieInfo>> GetMoviesByTitleAsync(string title);
    }
}
