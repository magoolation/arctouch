using ArcTouchApp.DTOS;
using ArcTouchApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArcTouchApp.Repositories
{
    interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetGenreListAsync();
    }
}
