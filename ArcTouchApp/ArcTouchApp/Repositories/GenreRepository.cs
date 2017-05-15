using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using ArcTouchApp.DTOS;
using Newtonsoft.Json;
using System.Diagnostics;
using ModernHttpClient;

namespace ArcTouchApp.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private HttpClient _client = new HttpClient(new NativeMessageHandler());

        public async Task<IEnumerable<GenreDTO>> GetGenreListAsync()
        {            
            try
            {
                var url = new Uri($"{Constants.API_URL}/genre/movie/list?{Constants.API_PARAMETER}");
                var response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<GenreListDTO>(content).genres;                        
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
