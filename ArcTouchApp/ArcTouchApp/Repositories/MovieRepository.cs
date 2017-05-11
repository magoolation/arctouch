using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArcTouchApp.Models;
using System.Net.Http;
using Newtonsoft.Json;
using ArcTouchApp.DTOS;
using System.Linq;

namespace ArcTouchApp.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private HttpClient _client = new HttpClient();
        private IEnumerable<Genre> _genreList;

        public MovieRepository(IEnumerable<Genre> genreList)
        {
            _genreList = genreList;
        }

        public async Task<Movie> GetMovieAsync(int id)
        {
            var url = new Uri($"{Constants.API_URL}/movie/{id}?{Constants.API_KEY}");
            var response = await _client.GetAsync(url);
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<MovieDTO>(content);
                return new Movie()
                {
                    Id = dto.id,
                    Title = dto.title,
                    ReleaseDate = dto.release_date,
                    Genre = string.Join(", ", dto.genres.Select(g => g.name).ToArray()),
                    ImageUrl = GetImageUrl(dto.poster_path ?? dto.backdrop_path)
                };
            }
                return null;
        }

        public async Task<IEnumerable<MovieInfo>> GetUpcomingMoviesAsync(int page = 1)
        {
            var url = $"{Constants.API_URL}/movie/upcoming?{Constants.API_KEY}&page={page}";
            var response = await _client.GetAsync(new Uri(url));
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UpcomingDTO>(content)
                    .results.Select(movie => new MovieInfo()
                    {
                        Id = movie.id,
                        Title = movie.title,
                        ReleaseDate = movie.release_date,
                        ImageUrl = GetImageUrl(movie.poster_path ?? movie.backdrop_path ?? null),
                        Genre = GetMovieGenres(movie.genre_ids)
                    });
            }
            return null;
        }

        private string GetImageUrl(string path)
        {
            return path;
        }

        private async Task GetGenres()
        {
            
        }

        private string GetMovieGenres(int[] genre_ids)
        {
            List<string> genres = new List<string>();
            foreach (var id in genre_ids)
            {
                genres.Add(_genreList.Where(g => g.Id == id)
                    .Select(g => g.Name)
                    .First());
            }
            return string.Join(", ", genres.ToArray());
        }

        public async Task<IEnumerable<MovieInfo>> SearchMovieByTitle(string title)
        {
            var url = new Uri($"{Constants.API_URL}/search/movie?{Constants.API_KEY}&query={title}");            
            var response = await _client.GetAsync(url);
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<SearchResultsDTO>(content);

                return result.results.Select(r => new MovieInfo()
                {
                    Id = r.id,
                    Title = r.title,
                    ReleaseDate = r.release_date,
                    Genre = GetMovieGenres(r.genre_ids),
                    ImageUrl = GetImageUrl(r.poster_path ?? r.backdrop_path)
                });
            }
            return null;
        }
    }
}