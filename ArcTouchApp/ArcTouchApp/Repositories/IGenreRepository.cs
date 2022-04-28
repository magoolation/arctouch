using ArcTouchApp.DTOS;
using ArcTouchApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArcTouchApp.Repositories
{
    public interface IGenreRepository
    {
        Task<IEnumerable<GenreDTO>> GetGenreListAsync();
    }
}
