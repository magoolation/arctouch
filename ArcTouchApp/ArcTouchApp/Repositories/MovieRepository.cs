using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using ArcTouchApp.DTOS;

namespace ArcTouchApp.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private HttpClient _client = new HttpClient();                

        public async Task<MovieDTO> GetMovieAsync(int id)
        {
            var url = new Uri($"{Constants.API_URL}/movie/{id}?{Constants.API_KEY}");
            var response = await _client.GetAsync(url);
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<MovieDTO>(content);                
            }
                return null;
        }

        public async Task<IEnumerable<MovieInfoDTO>> GetUpcomingMoviesAsync(int page = 1)
        {
            var url = $"{Constants.API_URL}/movie/upcoming?{Constants.API_KEY}&page={page}";
            var response = await _client.GetAsync(new Uri(url));
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UpcomingDTO>(content).results;                    
            }
            return null;
        }
        
                

        public async Task<IEnumerable<SearchResultDTO>> SearchMovieByTitle(string title)
        {
            var url = new Uri($"{Constants.API_URL}/search/movie?{Constants.API_KEY}&query={title}");            
            var response = await _client.GetAsync(url);
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SearchResultsDTO>(content).results;                
            }
            return null;
        }
    }
}