using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArcTouchApp.DTOS;
using Newtonsoft.Json;
using PCLStorage;

namespace ArcTouchApp.Repositories
{
    public class MockGenreRepository : IGenreRepository
    {
        public async Task<IEnumerable<GenreDTO>> GetGenreListAsync()
        {            
            string content = ResourceHelper.LoadFile("genres.json");
            return JsonConvert.DeserializeObject<GenreListDTO>(content).genres;
        }
    }
}
