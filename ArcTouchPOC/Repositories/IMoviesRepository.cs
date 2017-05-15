using ArcTouchApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArcTouchApp.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<MovieInfo>> GetUpcomingMoviesAsync(int page = 1);
        Task<Movie> GetMovieAsync(int id);
        Task<IEnumerable<MovieInfo>> SearchMovieByTitle(string title);
    }
}
