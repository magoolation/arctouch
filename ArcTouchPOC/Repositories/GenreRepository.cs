using System;
using System.Threading.Tasks;
using ArcTouchApp.Models;
using System.Collections.Generic;
using System.Net.Http;
using ArcTouchApp.DTOS;
using Newtonsoft.Json;
using System.Linq;
using System.Diagnostics;

namespace ArcTouchApp.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private HttpClient _client = new HttpClient();

        public async Task<IEnumerable<Genre>> GetGenreListAsync()
        {            
            try
            {
                var url = new Uri($"{Constants.API_URL}/genre/movie/list?{Constants.API_KEY}");
                var response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var genreList = JsonConvert.DeserializeObject<GenreListDTO>(content);

                    return genreList.genres.Select(g => new Genre()
                    {
                        Id = g.id,
                        Name = g.name
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            return null;
        }
    }
}
