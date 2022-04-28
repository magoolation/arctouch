using ArcTouchApp.DTOS;
using ArcTouchApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArcTouchApp.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<MovieInfoDTO>> GetUpcomingMoviesAsync(int page = 1);
        Task<MovieDTO> GetMovieAsync(int id);
        Task<IEnumerable<SearchResultDTO>> SearchMovieByTitle(string title);
    }
}
