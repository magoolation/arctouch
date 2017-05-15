using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using ArcTouchApp.DTOS;
using ModernHttpClient;

namespace ArcTouchApp.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private HttpClient _client = new HttpClient(new NativeMessageHandler());                

        public async Task<MovieDTO> GetMovieAsync(int id)
        {
            var url = new Uri($"{Constants.API_URL}/movie/{id}?{Constants.API_PARAMETER}");
            var response = await _client.GetAsync(url).ConfigureAwait(false);
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<MovieDTO>(content);                
            }
                return null;
        }

        public async Task<IEnumerable<MovieInfoDTO>> GetUpcomingMoviesAsync(int page = 1)
        {
            var url = $"{Constants.API_URL}/movie/upcoming?{Constants.API_PARAMETER}&page={page}";
            var response = await _client.GetAsync(new Uri(url)).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UpcomingMoviesDTO>(content).results;                    
            }
            return null;
        }
        
                

        public async Task<IEnumerable<SearchResultDTO>> SearchMovieByTitle(string title)
        {
            var url = new Uri($"{Constants.API_URL}/search/movie?{Constants.API_PARAMETER}&query={title}");            
            var response = await _client.GetAsync(url).ConfigureAwait(false);
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SearchMovieResultsDTO>(content).results;                
            }
            return null;
        }
    }
}